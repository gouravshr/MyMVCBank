
module.exports = {
    entry: "./src/index.js",
    output: {
        path: __dirname,
        filename: "bundle.js"
    },
    module: {
        rules: [
            // the 'transform-runtime' plugin tells babel to require the runtime
            // instead of inlining it.
            {test: /\.css$/, loader: "style-loader!css-loader"},
            { test: /\.svg$/,  loader: "url-loader?limit=10000&mimetype=image/svg+xml" },
            {
              test: /\.(js|jsx)$/,
              exclude: /(node_modules|bower_components)/,
              use: {
                loader: 'babel-loader',
                options: {
                  presets: ['es2015','stage-0','react'],
                  plugins: ['transform-runtime']
                }
              }
            }
          ]
    }
};
