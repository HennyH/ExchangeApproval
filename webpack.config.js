const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const DirectoryNamedWebpackPlugin = require('directory-named-webpack-plugin');
const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;

module.exports = (env, options) => {
  const devMode = options.mode !== "production";
  return {
    context: path.resolve(__dirname, 'client'),
    entry: './index.js',
    output: {
      path: path.join(path.resolve(__dirname), 'wwwroot'),
      filename: 'index.js',
    },
    externals: {
      $: 'jQuery'
    },
    resolve: {
      alias: {
        FormHelpers: path.resolve(__dirname, 'client', 'components', 'FormHelpers'),
        Components: path.resolve(__dirname, 'client', 'components'),
        Assets: path.resolve(__dirname, 'client', 'assets'),
      },
      plugins: [
        new DirectoryNamedWebpackPlugin()
      ]
    },
    plugins: [
      new HtmlWebpackPlugin({
        hash: devMode ? false : true,
        template: './index.html'
      }),
      new MiniCssExtractPlugin(),
      ...(devMode ? [new BundleAnalyzerPlugin()] : [])
    ],
    devtool: 'eval-source-map',
    module: {
      rules: [
        { test: /\.svg$/, loader: 'svg-url-loader' },
        { test: /\.js$/, exclude: [/node_modules/], loader: 'babel-loader' },
        {
          test: /\.css$/,
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
      https: true,
      port: 9000,
      contentBase: path.join(path.resolve(__dirname), '/dist'),
      compress: true,
      historyApiFallback: true
    }
  };
};

