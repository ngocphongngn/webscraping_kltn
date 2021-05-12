<template>
    <div class="manage-data">
        <div class="title">
            <h2>Thực hiện lấy dữ liệu việc làm trên hệ thống:</h2>
        </div>
        <div class="ckBoxSystem">
            <div class="optSystem">
                <el-checkbox v-model="vnindeed">https://vn.indeed.com/</el-checkbox>
            </div>
            <div class="optSystem">
                <el-checkbox v-model="topcv">https://www.topcv.vn/</el-checkbox>
            </div>
            <div class="optSystem">
                <el-checkbox disabled>https://www.vietnamworks.com/</el-checkbox>
            </div>
        </div>
        <div class="btn-process">
            <!-- button search -->
            <btn :type="'btn-primary'" :name="'Thực hiện'" :handleClick="crawlJobsFromSystems"></btn>
        </div>

        <div v-if="loading" v-loading="loading"></div>
        <div class="wait">
            <div v-if="success === 'initial'">
            </div>
             <div v-else-if="success === 'loading'">
                <strong>Chờ đợi trong giấy lát ...</strong>
            </div>
            <div v-else-if="success === 'success'">
                <strong>Bạn đã thực hiện thành công lấy dữ liệu {{total}} công việc!</strong>
            </div>
            <div v-else-if="success === 'fail'">
                <strong>Thất bại !</strong>
            </div>
        </div>
        
        
    </div>
</template>

<script>
    import btn from "@/components/buttons";
    import JobService from "@/api/job-seeking/job.js";

    export default {
        name: "ManageData",
        components: {
            "btn": btn
        },
        data(){
            return{
                vnindeed: 0,
                topcv: 0,
                loading: false,
                success: 'initial',
                total: 0,
            }
        },
        created() {
            
        },
        watch:{
        },
        methods:{
            
            async crawlJobsFromSystems(){
                let me = this,
                    lstSystem = [];
                me.loading = true;
                me.success = "loading";
                if(me.vnindeed == true){
                    lstSystem.push(1);
                }
                if(me.topcv == true){
                    lstSystem.push(2);
                }
                var res = await JobService.CrawlData(lstSystem);
                debugger
                if (res.data.Success === true) {
                    debugger
                    me.loading = false;
                    me.total = res.data.Data;
                    me.success = "success";
                    this.$_Notification.success(
                        "Thành công",
                        "Lấy dữ liệu việc làm thành công !"
                    );
                }
                if (res.data.Success === false) {
                    me.success = "fail";
                    this.buttonDialog = [
                        {
                        text: "Đóng",
                        class: "btn-primary",
                        callback: this.closeDialog,
                        },
                    ];
                    this.$_Popup.warn(
                        "Thất bại",
                        "Lấy dữ liệu việc làm thất bại !",
                        this.buttonDialog
                    );
                }
                
            }
        }
    }
</script>

<style lang="scss" scoped>
    .manage-data{
        height: 100%;
        .title{
            width: 100%;
            height: 100px;
            h2{
                position: absolute;
                left: 27%;
            }
        }
        .ckBoxSystem{
            height: 100px;
            position: absolute;
            left: 30%;
            .optSystem{
                width: 30%;
                margin-bottom: 15px;
            }
        }
        .btn-process{
            position: absolute;
            right: 35%;
            margin-top: 20px;
        }
        .el-loading-spinner .circular{
            animation: loading-rotate 3s !important;
        }
        .wait{
            position: absolute;
            right: 43%;
            margin-top: 220px;
        }
    }
</style>