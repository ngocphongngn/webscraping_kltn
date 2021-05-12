<template>
  <div class="login">
      <div id="login">
            <div id="logo">
                <img class="img-logo" src="@/assets/images/icon-jobseeking2.png"/>
            </div>
            <div id="main-login">
                <div class="title-login">
                    Đăng nhập
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
                <el-checkbox :value="true">Ghi nhớ đăng nhập</el-checkbox>
                <div class="btn-login">
                    <btn :type="'btn-primary'" :name="'Đăng nhập'" class="btnLogin"></btn>
                </div>
                <div class="forgot-password">
                    <a href="">Quên mật khẩu</a>
                </div>
                <div class="btn-register">
                    <a href="/register">Bạn chưa có tài khoản? Đăng ký ngay</a>
                </div>
                <div class="btn-rule">
                    <a href="">Bạn đồng ý với điều khoản của Job Seeking? </a>
                </div>
                
            </div>
      </div>
  </div>
</template>
<script>

import btn from "@/components/buttons";
export default {
name: "Login",
    components: {
        "btn": btn
    },
  computed: {
    
  },
  methods: {
  }
};
</script>
<style lang="scss">
    html{
        background-color: #f2f2f2;
    }
    .login{
        width: 100%;
        #login{
            width: 450px;
            height: 530px;
            position: absolute;
            top: 70px;
            left: 36%;
            #logo{
                width: 100%;
                height: 120px;
                .img-logo {
                    height: 110px;
                    position: relative;
                    left: 37%;
                    top: 10px;
                }
            }
            #main-login{
                width: 100%;
                height: 430px;
                background-color: white;
                padding-left: 20px;
                padding-right: 20px;
                .title-login{
                    padding-top: 15px;
                    height: 55px;
                    font-size: 25px;
                    font-weight: bold;
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
                .btn-login{
                    padding-top: 20px;
                    height: 100px;
                    .btnLogin{
                        width: 100%;
                        button{
                            width: 100%;
                        }
                    }
                }
                .forgot-password{
                    text-align: center;
                }
                .btn-register{
                    margin-top: 5px;
                    text-align: center;
                    height: 50px;
                }
                .btn-rule{
                    text-align: center;
                    color: #e8641b;
                }
            }
           
        }
    }
</style>
