import Vue from 'vue'
import App from './App.vue'

import SuiVue from 'semantic-ui-vue'

import { library } from '@fortawesome/fontawesome-svg-core'
import { faLightbulb } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

library.add(faLightbulb)

Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.use(SuiVue)

Vue.config.productionTip = false

new Vue({
  render: h => h(App)
}).$mount('#app')
