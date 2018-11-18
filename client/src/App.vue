<template>
  <div class="page-container">
    <md-app md-mode="fixed">
      <md-app-toolbar class="md-primary">
        <span class="md-title">Ideas</span>
      </md-app-toolbar>

      <md-app-content class="centered">
        <md-card class="md-elevation-10">
          <md-card-content>
            <md-field>
              <label>What's your idea?</label>
              <md-textarea v-model="input"></md-textarea>
            </md-field>
          </md-card-content>

          <md-card-actions>
            <md-button v-on:click="createIdea" class="md-icon-button md-raised md-primary"><md-icon>add</md-icon></md-button>
          </md-card-actions>
        </md-card>
        <br />
        <div v-for="idea in ideas.slice().reverse()" :key="idea.id">
          <Idea :idea="idea"></Idea>
        </div>
      </md-app-content>
    </md-app>
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
  methods: {
    createIdea: function (event) {
      if (this.input) {
        // Cache the current input as the request could take a while and the input could change.
        const currentInput = this.input
        axios
          .post('/function/create-idea', this.input)
          .then(response => {
            // TODO: Check status codes and perform respective actions
            this.ideas.push({ id: response.data.response.id, idea: currentInput })
            this.input = ''
          })
          .catch(error => {
            console.log(error)
          })
      }
    }
  },
  data () {
    return {
      ideas: null,
      input: ''
    }
  },
  mounted () {
    axios
      .get('/function/get-ideas')
      .then(response => {
        this.ideas = response.data.response.ideas
      })
      .catch(error => {
        console.log(error)
      })
  }
}
</script>

<style lang="scss" scoped>
  .centered {
    width: 33%;
    margin-left: auto;
    margin-right: auto;
    border: 0px;
  }
</style>
