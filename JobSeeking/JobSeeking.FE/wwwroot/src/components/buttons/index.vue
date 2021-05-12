<template>
  <div class="button-container">

    <el-button
      @click="handleClick"
      type="success"
      v-if="type == 'btn-success'"
      :icon="icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >{{ name }}</el-button>
    <!-- warning button -->
    <el-button
      @click="handleClick"
      type="warning"
      v-if="type == 'btn-waring'"
      :icon="icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >{{ name }}</el-button>
    <!-- danger button -->
    <el-button
      @click="handleClick"
      type="danger"
      v-if="type == 'btn-danger'"
      :icon="icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >{{ name }}</el-button>

    <!-- infor button -->
    <el-button
      @click="handleClick"
      type="infor"
      id="btn-tab"
      v-if="type == 'btn-infor'"
      :class="{ 'btn-infor-active': active == true }"
      :icon="icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >{{ name }}</el-button>

    <!-- text button -->
    <el-button
      @click="handleClick"
      type="text"
      v-if="type == 'btn-text'"
      :icon="icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >{{ name }}</el-button>
    <el-button
      class="btn-tool"
      @click="handleClick"
      type="tool"
      v-if="type == 'btn-tool'"
      :icon="getIcon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >{{ name }}</el-button>

     <!-- Multi Buton (V1.0)-->
    <div id="multi-button" v-if="type == 'multi-button'">
    <el-dropdown
      split-button
      class="btn-primary"
      :size="size"
      trigger="click"
      @click="handleClick"
    >
      <i :class="iconel" id="icon"></i>
      {{ name }}
      <el-dropdown-menu slot="dropdown">
        <el-dropdown-item v-for="(item, index) in dataDropdown" :key="index" :icon="item.icon" style="padding: 0px">
          <el-button type="text" @click="onClick" :nameVal="item.nameVal"> {{ item.name }}</el-button>
        </el-dropdown-item>
      </el-dropdown-menu>
    </el-dropdown>
    </div>

    <!-- Multi Buton 2 (V1.0) -->
    <div id="multi-button2" v-if="type == 'multi-button2'">
    <el-dropdown class="multi-button2" trigger="click">
      <el-button  :icon="icon" class="btn-primary" style="padding-right: 10px">
        <i :class="iconel" id="icon"/>
        {{name}}
        <i class="el-icon-arrow-down el-icon--right"></i>
      </el-button>
      <el-dropdown-menu slot="dropdown">
        <el-dropdown-item v-for="(item, index) in dataDropdown" :key="index" :icon="item.icon" style="padding: 0px">
          <el-button type="text" @click="onClick" :nameVal="item.nameVal">{{ item.name }}</el-button>
        </el-dropdown-item>
      </el-dropdown-menu>
    </el-dropdown>
    </div>

    <!-- Button primary -->
    <el-button
        @click="handleClick"
        v-if="type=='btn-primary'"
        class="btn-primary"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        {{name}}
    </el-button>
    <!-- Button primary icon-->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-primary-icon'"
      class="btn-primary-icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <slot name="icon">
      </slot>
      <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      {{name}}
    </el-button>

    <!-- Button primary mình icon-->
    <el-tooltip  effect="light" :content="tooltip" placement="top" popper-class="tooltip">
      <el-button
        @click="handleClick"
        v-if="type == 'btn-primary-onlyicon'"
        class="btn-primary-onlyicon favourite"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        <slot name="icon">
        </slot>
        <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      </el-button>
    </el-tooltip>

    <!-- Button grey -->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-grey'"
      class="btn-grey"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      {{name}}
    </el-button>

    <!-- Button grey icon-->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-grey-icon'"
      class="btn-grey-icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <slot name="icon">
      </slot>
      <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      {{name}}
    </el-button>

    <!-- Button grey mình icon-->
    <el-tooltip  effect="light" :content="tooltip" placement="top">
      <el-button
        @click="handleClick"
        v-if="type == 'btn-grey-onlyicon'"
        class="btn-grey-onlyicon"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        <slot name="icon">
        </slot>
        <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      </el-button>
    </el-tooltip>

    <!-- Button delete -->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-delete'"
      class="btn-delete"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      {{name}}
    </el-button>

    <!-- Button delete icon-->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-delete-icon'"
      class="btn-delete-icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <slot name="icon">
      </slot>
      <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      {{name}}
    </el-button>

    <!-- Button grey mình icon-->
    <el-tooltip  effect="light" :content="tooltip" placement="top">
      <el-button
        @click="handleClick"
        v-if="type == 'btn-delete-onlyicon'"
        class="btn-delete-onlyicon"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        <slot name="icon">
        </slot>
        <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      </el-button>
    </el-tooltip>

    <!-- Button button warn -->
    <el-button
      @click="handleClick"
      v-if="type == 'button warn'"
      class="button warn"
      :icon="icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <i :class="iconel" id="icon"></i>
      {{name}}
    </el-button>

    <!-- Button seconds -->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-seconds'"
      class="btn-seconds"
      :icon="getIcon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <i :class="iconel" id="icon"></i>
      {{name}}
    </el-button>

    <!-- Button seconds mình icon-->
    <el-tooltip  effect="light" :content="tooltip" placement="top">
      <el-button
        @click="handleClick"
        v-if="type == 'btn-seconds-icon'"
        class="btn-seconds-icon"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        <i :class="iconel" id="icon"></i>
      </el-button>
    </el-tooltip>

    <!-- Button white -->
    <el-button
        @click="handleClick"
        v-if="type=='btn-white'"
        class="btn-white"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        {{name}}
    </el-button>
    <!-- Button white icon-->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-white-icon'"
      class="btn-white-icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <slot name="icon">
      </slot>
      <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      {{name}}
    </el-button>

    <!-- Button white mình icon-->
    <el-tooltip  effect="light" :content="tooltip" placement="top" popper-class="tooltip">
      <el-button
        @click="handleClick"
        v-if="type == 'btn-white-onlyicon'"
        class="btn-white-onlyicon"
        :icon="getIcon"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        <slot name="icon">
        </slot>
        <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      </el-button>
    </el-tooltip>

    <!-- Button white2 (không có border)-->
    <el-button
        @click="handleClick"
        v-if="type=='btn-white2'"
        class="btn-white2"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        {{name}}
    </el-button>
    <!-- Button white2 icon-->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-white2-icon'"
      class="btn-white2-icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <slot name="icon">
      </slot>
      <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      {{name}}
    </el-button>

    <!-- Button white 2 mình icon-->
    <el-tooltip  effect="light" :content="tooltip" placement="top" popper-class="tooltip">
      <el-button
        @click="handleClick"
        v-if="type == 'btn-white2-onlyicon'"
        class="btn-white2-onlyicon"
        :icon="getIcon"
        :size="size"
        :plain="plain"
        :round="round"
        :circle="circle"
        :loading="loading"
        :disabled="disabled"
      >
        <slot name="icon">
        </slot>
        <i v-if="iconel != null" :class="iconel" id="iconel"></i>
      </el-button>
    </el-tooltip>

    <!-- Button button cảnh báo -->
    <el-button
      @click="handleClick"
      v-if="type == 'btn-warn'"
      class="btn-warn"
      :icon="icon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >
      <i :class="iconel" id="icon"></i>
      {{name}}
    </el-button>

    <!-- button tab -->
    <el-button
      @click="handleClick"
      id="btn-tab"
      v-if="type == 'btn-tab'"
      :class="{ 'btn-tab-active': active == true }"
      :icon="getIcon"
      :size="size"
      :plain="plain"
      :round="round"
      :circle="circle"
      :loading="loading"
      :disabled="disabled"
    >{{ name }}</el-button>

  </div>
</template>

<script>
import "@/styles/variables.scss";
export default {
  name: "Button",
  props: {
    /**
     * Tên icon muốn thêm vào
     */
    iconel:{
      type: String,
      default: null
    },
    /**
     * Dạng button = btn-primary / btn-success / btn-warning / btn-danger / btn-infor / btn-text / multi-button / multi-button2
     * Mặc định: btn-primary
     */
    type: {
      type: String,
      default: "primary" //default:
    },
    /**
     * Hàm xử lý click của button
     */
    handleClick: {
      type: Function,
      default: () => {}
    },
    /**
     * Tên button
     */
    name: {
      type: String,
      default: null
    },
    /**
     * icon hiển thị trên button
     */
    icon: {
      type: String,
      default: null
    },
    /**
     * Kích thước của button = mini / small / medium
     * Mặc định: medium
     */
    size: {
      type: String,
      default: "medium"
    },
    /**
     * Kiểu button có background mờ
     * Mặc định: false
     */
    plain: {
      type: Boolean,
      default: false
    },
    /**
     * Kiểu button có đường viền tròn
     * Mặc định: false
     */
    round: {
      type: Boolean,
      default: false
    },
    /**
     * Kiểu button hình tròn
     * Mặc định: false
     */
    circle: {
      type: Boolean,
      default: false
    },
    /**
     * Kiểu button có trạng thái loading
     * Nếu loading = true thì icon loading sẽ thay thế icon trong button
     * Mặc định: false
     */
    loading: {
      type: Boolean,
      default: false
    },
    /**
     * Tắt button
     * Mặc định: false
     */
    disabled: {
      type: Boolean,
      default: false
    },
    /**
     * Tên các subButton bên trong button dạng dropdown
     * Gồm các tham số truyền vào:
     *  name -> Tên của hiển thị của dropdown
     *  icon -> Icon hiển thị trên dropdown
     *  openModal -> Tên sự kiện để bắt event người dùng click vào dropdown
     * Mặc định: null
     */
    dataDropdown: {
      type: Array,
      default: null
    },
    /**
     * Sử dụng custom class
     * Mặc định: false
     */
    active: {
      type: Boolean,
      default: false
    },
    /**
     * Truyền vào tooltip
     */
    tooltip:{
      type: String,
      default: null
    }
  },
  watch: {},
  methods: {
    /**
     * Hàm bắt sự kiện click của các dropdown
     */
    onClick(e) {
      let name = e.currentTarget.getAttribute("nameVal");

      this.$emit(name);
    }
  },
  computed:{
    getIcon:{
      get(){
        debugger
        return "@/icons/" + this.icon + ".png";
      },
      set(){

      }
    }
  }
};
</script>
<style scoped>
  .btn-tab{
    border: none;
  }
  .favourite{
    width: 40px;
  }
</style>

