<template>
  <div class="register">
      <div id="register">
            <div id="logo">
                <img class="img-logo" src="@/assets/images/icon-jobseeking2.png"/>
            </div>
            
            <div class="main-register">
                <div class="title-register">
                    Đăng ký tài khoản
                </div>

                <div class="d-flex">
                    <div class="left-infor">
                        <div class="full-name">
                            <div class="text-name">
                                Họ và tên
                            </div>
                            <div class="input-name">
                                <input type="text" >
                            </div>
                        </div>
                        <div class="email">
                            <div class="text-email">
                                Địa chỉ email
                            </div>
                            <div class="input-email">
                                <input type="text">
                            </div>
                        </div>
                        <div class="password">
                            <div class="text-password">
                                Mật khẩu
                            </div>
                            <div class="input-password">
                                <input type="password">
                            </div>
                        </div>
                        <div class="password">
                            <div class="text-password">
                                Nhập lại mật khẩu
                            </div>
                            <div class="input-password">
                                <input type="password">
                            </div>
                        </div>
                        
                        
                    </div>
                    <div class="right-infor">
                         <div class="d-flex mode-ntd">
                            <div class="isCandidate">
                                <el-radio v-model="isCandidate" label="1">Ứng viên tìm việc</el-radio>
                            </div>
                            <div class="isCandidate">
                                <el-radio v-model="isCandidate" label="2">Nhà tuyển dụng</el-radio>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="btn-register">
                    <btn :type="'btn-primary'" :name="'Đăng nhập'" class="btnregister"></btn>
                </div>
                
                
                
            </div>
      </div>
  </div>
</template>
<script>

import btn from "@/components/buttons";
export default {
name: "Register",
components: {
    "btn": btn
},
data(){
    return{
        isCandidate: "1",
    }
},
computed: {
    
},
watch:{
    isCandidate(val){
        let x = val;
        debugger
        console.warn(x);
    }
},
methods: {
}
};
</script>
<style lang="scss">
    html{
        background-color: #f2f2f2;
        .el-radio__inner{
            border-color: #606266;
        }
    }
    .register{
        width: 100%;
        .isCandidate{
            margin-left: 50px;
            height: 40px;
        }
        .title-register{
            text-align: center;
            padding-top: 15px;
            height: 55px;
            font-size: 25px;
            font-weight: bold;
        }
        #register{
            width: 900px;
            height: 530px;
            position: absolute;
            top: 70px;
            left: 19%;
            #logo{
                width: 100%;
                height: 120px;
                .img-logo {
                    height: 110px;
                    position: relative;
                    left: 44%;
                    top: 10px;
                }
            }
            .main-register{
                width: 100%;
                height: 430px;
                background-color: white;
                padding-left: 20px;
                padding-right: 20px;
                .left-infor{
                    width: 50%;
                    height: 100%;
                    border-right: 1px solid #ccc;
                    padding-right: 20px;
                    .full-name{
                        height: 70px;
                        .text-name{
                            height: 20px;
                            font-size: 15px;
                        }
                        .input-name{
                            input{
                                height: 35px;
                                width: 100%;
                                padding-left: 10px;
                            }
                        }
                    }
                    .email{
                        height: 70px;
                        .text-email{
                            height: 20px;
                            font-size: 15px;
                        }
                        .input-email{
                            input{
                                height: 35px;
                                width: 100%;
                                padding-left: 10px;
                            }
                        }
                    }
                    .password{
                        height: 70px;
                        .text-password{
                            height: 20px;
                            font-size: 15px;
                        }
                        .input-password{
                            input{
                                height: 35px;
                                width: 100%;
                                padding-left: 10px;
                            }
                        }
                    }
                }
                
            }
           
        }
    }
</style>
