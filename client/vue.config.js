// vue.config.js
module.exports = {
  configureWebpack: config => {
    if (process.env.NODE_ENV === 'production') {
      // mutate config for production...
    } else {
      // mutate for development...
    }
  },
  devServer: {
    proxy: {
      '/function': {
        target: 'http://192.168.0.13:31112',
        changeOrigin: true
      }
    }
  }
}
