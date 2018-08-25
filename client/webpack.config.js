const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = (env, options) => {
  const devMode = options.mode !== "production";
  return {
    context: path.resolve(__dirname),
    entry: './index.js',
    output: {
      path: path.join(path.resolve(__dirname), '/dist'),
      filename: 'index.js'
    },
    externals: {
      $: 'jQuery'
    },
    plugins: [
      new HtmlWebpackPlugin({
        hash: devMode ? false : true,
        template: './index.html'
      }),
      new MiniCssExtractPlugin()
    ],
    devtool: 'eval-source-map',
    module: {
      rules: [
        { test: /\.js$/, exclude: [/node_modules/, /node_modules/], loader: 'babel-loader'},
        {
          test: /\.css$/,
          exclude: /node_modules/,
          use: [
            devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
            {
              loader: 'css-loader',
              options: { modules: true, camelCase: true }
            },
            'postcss-loader'
          ]
        }
      ]
    },
    devServer: {
      contentBase: path.join(path.resolve(__dirname), '/dist'),
      compress: true,
      port: 9000,
      historyApiFallback: true
    }
  };
};

