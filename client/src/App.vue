<template>
  <div id="app">
    <Idea v-bind:idea="idea"/>
  </div>
</template>

<script>
import axios from 'axios'

import Idea from './components/Idea.vue'

export default {
  name: 'app',
  components: {
    Idea
  },
  data () {
    return {
      idea: null
    }
  },
  mounted () {
    axios
      .get('/function/get-ideas')
      .then(response => (this.idea = response))
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
