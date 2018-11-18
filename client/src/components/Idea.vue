<template>
  <div v-if="show">
    <md-card class="md-elevation-10">
      <md-card-header>
        <div class="md-title">{{idea.idea}}</div>
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
          if (response.data.status === 204) {
            this.show = false
          }
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

<style scoped>

</style>
