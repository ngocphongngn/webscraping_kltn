import { api } from "@/utils/base-axios";
const service = api(process.env.VUE_APP_BASE_API);
export default {
    /**
     * Hàm lấy danh sách job
     */
    async GetListJob() {
        var url = `/Job`;
        var res = await service.get(url, {
            headers: {
            }
        });
        return res;
    },

    /**
     * Ham` crawl du lieu
     */
    async CrawlData(data){
        try {
            var url = '/Job/Crawler';
            return await service.post(url, data, {
                headers: {
                },
            });
        } catch (error) {
            console.log(error + data);
        }
    }
}