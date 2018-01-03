import path from "path";
import webpack from "webpack";

var DIST_DIR = path.resolve(__dirname, "dist");

export default {
  entry: [
    "webpack-hot-middleware/client",
    path.join(__dirname, "/client/index.js")
  ],
  output: {
      path: DIST_DIR + "/app",
      filename: "bundle.js",
      publicPath: "/"
  },
  plugins: [
    new webpack.NoEmitOnErrorsPlugin(),
    new webpack.optimize.OccurrenceOrderPlugin(),
    new webpack.HotModuleReplacementPlugin()
  ],
  module: {
    loaders: [
      {
        test: /\.js$/,
        include: path.join(__dirname, "client"),
        loaders: ["babel-loader", "react-hot-loader/webpack"]
      }
    ]
  },
  resolve: {
    extensions: [".js"]
  }
}
