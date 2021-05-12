<template>
  <div class="admin">
      <div id="header">
          <div id="logo">
              <img class="img-logo" src="@/assets/images/icon-jobseeking2.png"/>
          </div>
      </div>
  </div>
</template>
<script>

export default {
  components: {
    
  },
  computed: {
  }
};
</script>
<style lang="scss" scoped>
    .admin{
        #header{
            width: 100%;
            height: 150px;
            background-color: #207bc1;
        }
        #logo{
            display: flex;
            align-items: center;
            .img-logo {
                height: 110px;
                position: absolute;
                top: 20px;
                left: 45%;
            }
        }
    }
</style>
