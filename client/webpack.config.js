const path = require('path')
const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
  context: path.resolve(__dirname),
  entry: './index.js',
  output: {
    path: path.join(path.resolve(__dirname), '/dist'),
    filename: 'index.js'
  },
  plugins: [
    new HtmlWebpackPlugin()
  ],
  module: {
    rules: [
      { test: /\.js$/, exclude: /node_modules/, loader: 'babel-loader'}
    ]
  },
  devServer: {
    contentBase: path.join(path.resolve(__dirname), '/dist'),
    compress: true,
    port: 9000,
    historyApiFallback: true
  }
}