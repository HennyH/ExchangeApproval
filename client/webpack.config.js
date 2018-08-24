const path = require('path');
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
    plugins: [
      new HtmlWebpackPlugin({ hash: devMode ? false : true }),
      new MiniCssExtractPlugin()
    ],
    module: {
      rules: [
        { test: /\.js$/, exclude: /node_modules/, loader: 'babel-loader'},
        {
          test: /\.css$/,
          // CSS files that come from node_modules we don't want to turn
          // into modules that get bundled into our index.js. We have a
          // seperate CSS rule to cover CSS from node_modules.
          exclude: /node_modules/,
          use: [
            devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
            {
              loader: 'css-loader',
              options: { modules: true, camelCase: true }
            },
            'postcss-loader'
          ]
        },
        // Import CSS from node_modules just as if it were a style-sheet.
        {
          test: /\.css$/,
          include: /node_modules/,
          use: [
            devMode ? 'style-loader' : MiniCssExtractPlugin.loader,
            'css-loader',
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

