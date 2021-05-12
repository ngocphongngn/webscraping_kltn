using JobSeeking.BE.API.Interfaces;
using JobSeeking.BE.ApplicationCore.Entities.Base;
using JobSeeking.BE.ApplicationCore.Entities.JobSeeking;
using JobSeeking.BE.ApplicationCore.Entities.Crawler;
using JobSeeking.BE.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using JobSeeking.BE.ApplicationCore.Interfaces.Base;
using JobSeeking.BE.ApplicationCore.Properties;
using static JobSeeking.BE.ApplicationCore.Enums.Enumeration;

namespace JobSeeking.BE.API.Services
{
    public class JobService: IJobService

    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ICommonRepository<Specialty> _commonRepository;
        private readonly ILogger<JobService> _logger;
        // key api của customsearch
        private static string apiKey = "AIzaSyBZ-kKRGxjkdWw5F8cV6W5qMvsYJn9IsTE";
        private static string cx = "2a3ef7c413aae270f";

        public JobService(IJobRepository jobRepository, ILogger<JobService> logger, ISpecialtyRepository specialtyRepository, ICommonRepository<Specialty> commonRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
            _specialtyRepository = specialtyRepository;
            _commonRepository = commonRepository;
        }
        public async Task<ActionServiceResult> CrawlerJobFromOtherSystem(List<int> lstSystemCode)
        {
            var res = new ActionServiceResult();
            var listLink = new List<ResultLink>();
            //delete all job
            await _jobRepository.Delete(new object[] {});
            foreach (var systemCode in lstSystemCode)
            {
                //lay link de zo crawl
                var link = this.GetLinkByCustomSearchAPI(systemCode);
                foreach(var i in link.Result)
                {
                    listLink.Add(i);
                }
            }
            var jobListMaster = new List<Job>();
            foreach (var item in listLink)
            {
                List<Job> jobs = new List<Job>();
                jobs = this.CrawlMaster(item.Link, item.SystemCode);
                foreach (var items in jobs)
                {
                    jobListMaster.Add(items);
                }
            }
            foreach(var job in jobListMaster)
            {
                job.JobID = Guid.NewGuid();
                var insertMasterJob = await _jobRepository.AddAsync(job, true);
                if(insertMasterJob == null)
                {
                    res.Success = false;
                    res.Message = Resources.ErrorAddEntity;
                    res.SystemCode = SystemCode.ErrorAddEntity;
                }
            }
            res.Data = jobListMaster.Count;
            return res;
        }

        /// <summary>
        /// nnphong - function goi custom search api -> get link de crawler
        /// </summary>
        /// <returns></returns>
        public async Task<List<ResultLink>> GetLinkByCustomSearchAPI(int systemCode)
        {
            var results = new List<ResultLink>();
            //lấy danh sách cách ngành nghề để search
            var listSearchQuery = await _specialtyRepository.GetListAsync();

                string text = "";
                //topCV
                switch (systemCode) {
                    //vn indeed
                    case 1:
                        foreach (var searchQuery in listSearchQuery)
                        {
                            text = searchQuery.JobPosition + " " + searchQuery.SpecialtyName;
                            int page = 1;
                            var res = new ResultLink();
                            while (page < 10) //muốn lấy 100 link thì để là 100
                            {
                                var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + text + "&start=" + page);
                                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                Stream dataStream = response.GetResponseStream();
                                StreamReader reader = new StreamReader(dataStream);
                                string responseString = reader.ReadToEnd();
                                dynamic jsonData = JsonConvert.DeserializeObject(responseString);

                                //foreach (var item in jsonData.items){}
                                res.Title = jsonData.items[0].title;
                                res.Link = jsonData.items[0].link;
                                res.SystemCode = systemCode;
                                page += 10;
                            }
                            results.Add(res);
                        }
                        break;
                    //topCV
                    case 2:
                        var link = new ResultLink();
                        link.Title = "Việc làm mới nhất";
                        link.Link = "https://www.topcv.vn/tim-viec-lam-moi-nhat";
                        link.SystemCode = 2;
                        results.Add(link);
                        break;
                }
           
            return results;
        }

        public List<Job> CrawlMaster(string url, int systemCode)
        {
            List<Job> jobs = new List<Job>();
            //config chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            using (var driver = new ChromeDriver("C:\\Users\\ADMIN\\Downloads", options))
            {
               
                switch (systemCode)
                {
                    //vn indeed
                    case 1:
                        try
                        {
                            var start = 0;
                            var urlPaging = url.Substring(0, 22) + "jobs?q=" + url.Substring(44) + "&start=";
                            while (start <= 100)
                            {
                                if(start > 0)
                                {
                                    //phan tich url phan trang
                                    url = urlPaging + start;
                                }
                                // Go to the URL
                                driver.Navigate().GoToUrl(url);
                                // lấy ra cục html gồm list jobs
                                By getHtmlBlock = By.XPath("//td[@id = 'resultsCol']");
                                ReadOnlyCollection<IWebElement> listJobs = driver.FindElements(getHtmlBlock);

                                // dùng vòng for để lấy từng job ra
                                foreach (var item in listJobs)
                                {
                                    // lấy ra được 1 job
                                    ReadOnlyCollection<IWebElement> aJob = item.FindElements(By.ClassName("jobsearch-SerpJobCard"));
                                    // lấy ra từng thông tin trogn job master
                                    foreach (var obj in aJob)
                                    {
                                        var job = new Job();
                                        //thông tin tên
                                        try
                                        {
                                            job.JobName = obj.FindElement(By.ClassName("title")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //địa điểm làm việc
                                        try
                                        {
                                            job.Location = obj.FindElement(By.ClassName("location")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //lương
                                        try
                                        {
                                            job.Salary = obj.FindElement(By.ClassName("salaryText")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //cty
                                        try
                                        {
                                            job.CompanyName = obj.FindElement(By.ClassName("company")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //ngay cap nhat
                                        try
                                        {
                                            job.UpdateTime = obj.FindElement(By.ClassName("date-a11y")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //thông tin hệ thống lấy dữ liệu
                                        job.SystemID = systemCode;

                                        try
                                        {
                                            var urlSelector = obj.FindElement(By.ClassName("jobtitle"));
                                            //link tới detail
                                            job.UrlDetail = urlSelector.GetAttribute("href");

                                            //detail
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //load len detail
                                        //driver.Navigate().GoToUrl(linkDetail);
                                        //var mota = driver.FindElementByClassName("description");
                                        jobs.Add(job);
                                    }
                                }
                                start+=10;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;

                    case 2:
                        try
                        {
                            var page = 0;
                            while (page <= 2)
                            {
                                //phan tich url phan trang
                                url = url + "&page=" + page;
                                // Go to the URL
                                driver.Navigate().GoToUrl(url);
                                // lấy ra cục html gồm list jobs
                                By getHtmlBlock = By.XPath("//div[@id = 'box-job-result']");
                                ReadOnlyCollection<IWebElement> listJobs = driver.FindElements(getHtmlBlock);

                                // dùng vòng for để lấy từng job ra
                                foreach (var item in listJobs)
                                {
                                    // lấy ra được 1 job
                                    ReadOnlyCollection<IWebElement> aJob = item.FindElements(By.ClassName("job-ta"));
                                    // lấy ra từng thông tin trogn job master
                                    foreach (var obj in aJob)
                                    {
                                        var job = new Job();
                                        //thông tin tên
                                        try
                                        {
                                            job.JobName = obj.FindElement(By.ClassName("transform-job-title")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //địa điểm làm việc
                                        try
                                        {
                                            job.Location = obj.FindElement(By.ClassName("address")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //lương
                                        try
                                        {
                                            job.Salary = obj.FindElement(By.ClassName("salary")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //cty
                                        try
                                        {
                                            job.CompanyName = obj.FindElement(By.ClassName("row-company")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //ngay cap nhat
                                        try
                                        {
                                            job.UpdateTime = obj.FindElement(By.ClassName("updated_at")).Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //thông tin hệ thống lấy dữ liệu
                                        job.SystemID = systemCode;

                                        try
                                        {
                                            var urlSelector = obj.FindElement(By.ClassName("company-logo"));
                                            //link tới detail
                                            job.UrlDetail = urlSelector.GetAttribute("href");

                                            //detail
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }

                                        //load len detail
                                        //driver.Navigate().GoToUrl(linkDetail);
                                        //var mota = driver.FindElementByClassName("description");
                                        jobs.Add(job);
                                    }
                                }
                                page ++;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                }
                
                //var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
            }
            return jobs;
        }
    }
}
