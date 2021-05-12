<template>
    <div class="vn-indeed">
        <div class="quantity">
            Có <strong>{{totalJob}}</strong> việc làm trên <strong> <a href="https://vn.indeed.com">https://vn.indeed.com</a></strong> 
        </div>
        <div class="jobs d-flex">
            <div class="job d-flex" v-for="item in listJob" :key="item">
                <div class="info">
                    <div class="title">
                        {{item.JobName}}
                    </div>
                    <div class = "company">
                        {{item.CompanyName}}
                    </div>
                    <div class="place">
                        {{item.Location}}
                    </div>
                    <div class="salary">
                        {{item.Salary}}
                    </div>
                    <div class="updated-time">
                        {{item.UpdateTime}}
                    </div>
                </div>
                <div class="more">
                    <btn class="mr-8 fl like" :type="'btn-primary-onlyicon'" :iconel="'el-icon-star-off'" tooltip="Yêu thích" circle></btn>
                    <a href="">
                        <btn class="mr-8 fl detail" :type="'btn-white2-onlyicon'" :iconel="'el-icon-arrow-right'" tooltip="Xem chi tiết"></btn>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import btn from "@/components/buttons";
    import JobService from "@/api/job-seeking/job.js";
    export default {
        name: "VNIndeed",
        components:{
            btn,
        },
        data(){
            return{
                listJob: {},
                totalJob: 0,
            }
        },
        created(){
            this.getListJobs();
        },
        methods:{
            async getListJobs(){
                debugger
                let me = this;
                debugger
                var res = await JobService.GetListJob();
                if(res.data.Success === true && res.data.Data !== null){
                    me.listJob = res.data.Data;
                    me.totalJob = me.listJob.length;
                }
            }
        }
    }   
</script>

<style lang="scss" scoped>
    .vn-indeed{
        .quantity{
            height: 50px;
            line-height: 50px;
            margin-top: 10px;
        }
        .jobs{
            flex-wrap: wrap;
            .job{
                &:hover {
                    border: 1px solid #e8641b;
                    cursor: pointer;
                }
                border-radius: 5px;
                margin: 0 25px 15px 0;
                border: 1px solid #ccc;
                height: 190px;
                width: 500px;
                padding: 5px 0 0 10px;
                .info{
                    width: 80%;
                    .title{
                        font-weight: bold;
                        // text-align: center;
                        font-size: 15px;
                        height: 60px;
                        line-height: 30px;
                    } 
                    .company{
                        margin: 5px 0 5px 0;
                    }
                    .salary{
                        font-weight: bold;
                    }
                    .place{
                        margin: 5px 0 5px 0;
                    }
                    .updated-time{
                        font-size: 12px!important;
                        color: rgb(117, 112, 112);
                        margin: 5px 0 5px 0;
                    }
                }
                .more{
                    width: 50px;
                    margin: 5px 0 5px 10px;
                    .like{
                        margin-left: 20px;
                        width: 40px;
                        .el-button .el-tooltip .btn-primary-onlyicon .el-button--default .el-button--medium .is-circle{
                            width: 40px;
                        }
                    }
                    .detail{
                        margin-left: 20px;
                    }
                }
                
            }
        }
    }
</style>