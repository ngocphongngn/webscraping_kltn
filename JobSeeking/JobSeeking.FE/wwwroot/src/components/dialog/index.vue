<template>
    <div>
        <el-dialog
            custom-class="dialogel"
            :fullscreen="fullscreen"
            :title="titleDialog"
            :visible.sync="dialog"
            :width="width"
            @close="closeDialog()"
            :close-on-click-modal="closeonclickmodal"
            :id="id">
            <div>
                <slot name="body"></slot>
            </div>
            <span slot="footer">
                <slot name="footer"></slot>
            </span>
        </el-dialog>
    </div>
</template>
<script>
import Dialog from "@/mixins/dialog";
export default {
    name: "warn",
    props:{
        /**
         * Truyền xuống tittle của dialog
         */
        titleDialog:{
            type: String,
            default: ""
        },
        /**
         * Truyền xuống width dialog
         */
        width: {
            type: String,
            default: '500px'
        },
        /**
         * Có cho phép ấn vào bên ngoài dialog không
         */
        closeonclickmodal:{
            type: Boolean,
            default: false
        },
        /**
         * Truyền vào id để có thể tự chỉnh css nếu cần
         */
        id:{
            type: String,
            default: ""
        },
        /**
         * Truyền xuống biến có full màn hình không
         */
        fullscreen:{
            type: Boolean,
            default: false
        }
        
    },
    mixins: [Dialog],
}
</script>
<style lang="scss">
.dialogel{
    min-width: 200px;
}
</style>