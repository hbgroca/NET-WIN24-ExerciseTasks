const express = require('express');
const http = require('http'); // Use http instead of https
const cors = require('cors');
const bodyParser = require('body-parser');
const app = express();

const applyMiddlewares = require('./middlewares');
const routes = require('./routes');

// Använd cors-middleware
app.use(cors());
app.use(bodyParser.json()); // Middleware to parse JSON
app.use(bodyParser.urlencoded({ extended: true })); // Middleware to parse URL-encoded data

// Använd middlewares
applyMiddlewares(app);

// Använd rutter
app.use('/', routes);

const PORT = process.env.PORT || 3000;

http.createServer(app).listen(PORT, () => {
    console.log(`HTTP Server is running on port ${PORT}`);
});