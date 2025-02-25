const cors = require('cors');
const bodyParser = require('body-parser');
const express = require('express');

const applyMiddlewares = (app) => {
    app.use(cors());
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(express.json());
};

module.exports = applyMiddlewares;