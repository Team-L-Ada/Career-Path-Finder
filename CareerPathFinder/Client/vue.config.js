module.exports = {
  configureWebpack: {
    devServer: {
      sockHost: "debug.iamaleks.dev",
      sockPort: 443,
      disableHostCheck: true
    }
  },
  chainWebpack: config => {
    config.module.rules.delete('eslint');
}
};