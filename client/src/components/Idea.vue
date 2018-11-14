<template lang="html">
  <div>
    <sui-card class="blue centered">
      <sui-card-content>
        <sui-card-header>
          <font-awesome-icon icon="lightbulb" />
        </sui-card-header>
      </sui-card-content>
      <sui-card-content>
        <sui-card-description>
            {{idea}}
        </sui-card-description>
      </sui-card-content>
    </sui-card>
  </div>
</template>

<script>
export default {
  name: 'Idea',
  props: {
    idea: Object
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
