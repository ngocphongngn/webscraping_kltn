<template>
    <div id="search" class="d-flex">
        <div class="logo">
            <a href="http://localhost:8080/job-seeking/">
                <img class="img-logo" src="@/assets/images/icon-jobseeking2.png"/>
            </a>
        </div>
        <div class="search">
            <div class="title">
                Tìm kiếm việc làm tốt nhất từ các trang web tuyển dụng hàng đầu Việt Nam
            </div>
            <div class="searchinput d-flex">
                <div class="jobsearch">
                    <!-- search tẽxt -->
                    <fieldinput 
                        class="search-filter" 
                        type="input-icon" 
                        :iconel="'el-icon-search'" 
                        width="500px"
                        :placeholder="'Tìm kiếm việc làm'" 
                    ></fieldinput>
                </div>

                <div class="locationsearch d-flex">
                    <el-button
                        class="btn-white2-onlyicon"
                        :icon="'el-icon-location-information'"
                        :disabled="true"
                    >
                        <slot name="icon">
                        </slot>
                    </el-button>
                    <!-- location -->
                    <selectinput class="location-search" :placeholder="'Địa điểm'" type="label-none" :filterable="true" :list="list" style="width: 200px; " ></selectinput>
                </div>

                <div class="btnsearch">
                    <!-- button search -->
                    <btn class="mr-8 fl btn-search" :type="'btn-primary'" :name="'Tìm kiếm'" :handleClick="getListJobs"></btn>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import fieldinput from "@/components/inputs";
import selectinput from "@/components/select";
import btn from "@/components/buttons";
import JobService from "@/api/job-seeking/job.js";
export default {
    components: {
        "fieldinput" : fieldinput,
        "selectinput" : selectinput,
        "btn": btn
    },
    data() {
        return {
            listJob: {}
        };
    },
    methods: {
        async getListJobs(){
            let me = this;
            debugger
            var res = await JobService.GetListJob();
            if(res.Data.Success === true && res.data.Data !== null){
                me.listJob = res.data.Data
            }
        }
    },
    watch: {
    },
    computed:{
        
    },
    created(){
    }
    };
</script>
<style lang="scss" scoped>
@import "~@/styles/variables.scss";

</style>
