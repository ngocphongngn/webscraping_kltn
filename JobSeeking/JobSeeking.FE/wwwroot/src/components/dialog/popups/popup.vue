<template>
    <div v-if="isPopup">
        <el-dialog
            :title="params.title"
            :visible.sync="isPopup"
            width="400px"
            id="noty-dialog"
            :close-on-click-modal='false'
            @close="resetState()"
        >
            <div class="icon-popup" v-if="type != 'info'">
                <img v-if="type=='warn'" style="width: 30px; height: 30; margin-right: 10px" src="@/icons/Group 17652@2x.png">
                <img v-if="type=='delete'" style="width: 30px; height: 30px; margin-right: 10px" src="@/icons/Group 17653@2x.png">
            </div>
            <div class="text-dialog" v-html="params.content"></div>
            <span slot="footer" class="dialog-footer">
                <el-button v-for="(item,index) in params.buttons" :key="index" :class="item.class" @click="handleClick(item)">{{item.text}}</el-button>
            </span>
        </el-dialog>
    </div>
</template>
<script>
export default {
    name: "Popup",
    data(){
        return{
            title: "tét",
            isPopup: false,
            type: "info",
            params: {
                title: "Đây là popup thông báo",
                content: "Thử nghiệm lần thứ n",
                buttons: [
                    {
                        text: "Không",
                        class: "btn-grey",
                        callback: ()=>{}
                    },
                    {
                        text: "Đóng",
                        class: "btn-primary",
                        callback: ()=>{}
                    }
                ]
            }
        }
    },
    methods:{

        /**
         * Hàm hiển thị popup success
         */
        warn: function(title, content, buttons) {
            this.resetState()
            this.type = "warn"
            this.open(title, content, buttons)
        },

        /**
         * Hàm hiển thị popup success
         */
        error: function(title, content, buttons) {
            this.resetState()
            this.type = "error"
            this.open(title, content, buttons)
        },
        
        /**
         * Hàm hiển thị popup delete
         */
        delete: function(title, content, buttons) {
            this.resetState()
            this.type = "delete"
            this.open(title, content, buttons)
        },

        /**
         * Hàm hiển thị popup success
         */
        info: function(title, content, buttons) {
            this.resetState()
            this.type = "info"
            this.open(title, content, buttons)
        },

        /**
         * Hàm mở popup
         */
        open: function(title, content, buttons){
            this.params.title = title
            this.params.content = content
            if(!Array.isArray(buttons)){
                alert("Lỗi truyền vào popup, cần truyền vào mảng button, vào dialog để xem chi tiết")
            }
            this.params.buttons = buttons
            this.isPopup = true
        },

        /**
         * Reset trạng thái của popup về mặc định
         */
        resetState: function(){
            this.isPopup = false
            this.type = "info"
        },

        /**
         * Hàm xử lý sự kiện cho các button
         */
        handleClick: function(button){
            this.resetState()
            if (typeof button.callback !== 'function'){
                alert('Bạn phải truyền vào là một function');
            }
            else{
                button.callback()
            }
        }
    },
}
</script>
<style lang="scss" scoped>
@import "@/styles/variables.scss";
    .icon-popup{
        display: flex;
        align-items: center;
        padding-left: 7px;;
        width: 45px;
        height: 45px;
        border-radius: 50px;
        background-color: $bg-color-1;
        margin-right: 10px;
    }
    .img{
        width: 30px;
        height: 30px;
        margin-right: 10px
    }
</style>