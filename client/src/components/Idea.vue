<template>
  <div v-if="show">
    <md-card class="md-elevation-10">
      <md-card-header>
        <div class="md-title">{{idea.idea}}</div>
        <div class="md-subhead">{{idea.id}}</div>
      </md-card-header>

      <md-card-actions>
        <md-button v-on:click="deleteIdea" class="md-icon-button md-raised md-accent"><md-icon>delete</md-icon></md-button>
      </md-card-actions>
    </md-card>
    <br />
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Idea',
  props: {
    idea: Object
  },
  methods: {
    deleteIdea: function (event) {
      axios
        .post('/function/delete-idea', this.idea.id)
        .then(response => {
          // TODO: Check status codes and perform respective actions
          this.show = false
        })
        .catch(error => {
          console.log(error)
        })
    }
  },
  data () {
    return {
      show: true
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
