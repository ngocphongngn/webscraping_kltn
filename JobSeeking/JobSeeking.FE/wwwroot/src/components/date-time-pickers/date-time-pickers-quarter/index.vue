<template>
  <div>
    <VueDatePicker
      class="mintax-quater-picker"
      v-model="valueDate"
      :min-date="minDate"
      :max-date="maxDate"
      type="quarter"
      :locale="locale"
      @onChange="getValue"
      format="[Quý ]Q - YYYY"
      no-header
      :style="getWidth"
      color="#0E1D61"
      :placeholder="placeholder"
    />
  </div>
</template>

<script>
export default {
  props: {
    /**
     * Giá trị
     */
    value: {
      type: String,
    },

    /**
     * Ngày giới hạn nhỏ nhất
     */
    minDate: {
      type: String,
      default: "",
    },

    /**
     * Ngày giới hạn lớn nhất
     */
    maxDate: {
      type: String,
      default: "",
    },

    /**
     * Truyền vào độ rộng
     */
    width: {
      type: String,
      default: "",
    },
    /**
     * Truyền vào placeholder
     */
    placeholder: {
      type: String,
      default: "Quí-Năm",
    },
  },
  data() {
    return {
      valueDate: null,
      /**
       * Định dạng ngày ngôn ngữ việt nam theo quý
       */
      locale: {
        lang: {
          name: "vi",
          weekdays: "Thứ 2_Thứ 3_Thứ 4_Thứ 5_Thứ 6_Thứ 7_Chủ Nhật".split("_"),
          weekdaysShort: "T2_T3_T4_T5_T6_T7_CN".split("_"),
          weekStart: 1,
          months: "Quý 1__/_Quý 2__/_Quý 3__/_Quý 4__/".split("_"),
          monthsShort: "Th.1_Th.2_Th.3_Th.4_Th.5_Th.6_Th.7_Th.8_Th.9_Th.10_Th.11_Th.12".split(
            "_"
          ),
          formats: {
            LT: "HH:mm",
            LTS: "HH:mm:ss",
            L: "DD/MM/YYYY",
            LL: "D MMMM YYYY",
            LLL: "D MMMM YYYY HH:mm",
            LLLL: "dddd D MMMM YYYY HH:mm",
          },
          ordinal: (n) => `${n}º`,
          buttonCancel: "Hủy",
          buttonValidate: "Ok",
          rangeHeaderText: "Dalle %d Alle 13",
        },
      },
    };
  },
  methods: {
    getValue() {
      this.$emit("getValue", this.value);
    },
  },
  computed: {
    getWidth() {
      return "width: " + this.width + ";";
    },
  },
  watch: {
    value(val) {
      this.valueDate = val;
    },
    valueDate(val) {
      this.$emit("getValue", val);
    },
  },
  created() {
    this.valueDate = this.value;
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang="scss">
@import "~@/styles/variables.scss";
.vd-wrapper {
  &:hover {
    border-color: $primary !important;
    color: $dark !important;
  }
  &:focus {
    border-color: $primary !important;
    color: $dark !important;
  }
  &:active {
    border-color: $primary !important;
    color: $dark !important;
  }
}
.vd-picker__input--is-active {
  border-color: $primary !important;
  color: $dark !important;
}
.vd-picker__input--is-active.vd-picker__input {
  border-color: $primary !important;
}
.vd-wrapper:not(.vd-wrapper--inline) {
  height: 40px;
  padding: 5px;
  width: 125px;
  border: 1px solid #ccc;
  border-radius: 5px;
  color: $dark;
}
.vd-picker__input-wrapper {
  width: 104px;
  padding-right: 16px;
}
.vd-picker__input-wrapper input {
  font-size: 13px;
  height: 24px;
  width: 95px;
  padding-right: 16px;
}

.vd-picker__controls-label button:not(:hover):not(:focus) {
  font-size: 16px;
  font-weight: 700;
  color: $dark;
}

.vd-picker__selects-quarters button {
  font-size: 13px;
  color: $dark;
  &:hover {
    background-color: $hover-blue;
  }
}

.vd-icon.vd-icon {
  margin-left: 8px;
  color: $dark;
}

.vd-picker__controls-label button:hover {
  font-size: 16px;
  font-weight: 700;
}

.vd-menu__content.vd-menu__content--active.vd-menu__content--fixed,
.vd-picker,
.vd-picker__body {
  min-width: 243px !important;
  width: 243px;
  height: 173px !important;
}

.vd-picker__table {
  height: 173px - 56px;
}

.vd-picker__selects-quarters {
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(2, 1fr);
  padding: 10px 16px 16px 16px;
}

.vd-picker__selects-years__list button {
  cursor: pointer;
}

.vd-picker__selects-quarters button {
  flex-direction: column;
  border: 1px solid $bg-color-3;
  border-radius: 6px;
}

.vd-picker__selects-quarters_text {
  margin: 8px 0 0 0;
  font-size: 11px;
}

.vd-picker__selects-quarters_text:first-child {
  font-size: 13px;
  font-weight: 100;
}
.vd-menu__content.vd-menu__content--active {
  z-index: 2000000000 !important;
}
.vd-menu__content.vd-menu__content--active.vd-menu__content--fixed {
  margin-left: -5px;
  margin-top: 9px;
}

.vd-picker__input-icon {
  margin-bottom: 3px;
}
.vd-picker__controls {
  .vd-icon {
    margin: 0 !important;
    width: 32px !important;
    height: 32px !important;
    border: 1px solid $bg-color-3;
    border-radius: 6px;

    &:hover {
      background: $hover-grey;
    }
  }
}

.vd-picker__controls-prev {
  padding: 20px 0px 4px 20px !important;
}
.vd-picker__controls-next {
  padding: 20px 20px 4px 0 !important;
}

.vd-picker__controls-wrapper {
  padding-top: 20px;
  pointer-events: none;
}
</style>
