const express = require('express');
const mysql = require('mysql2');

const connectionConfig = {
    host: 'localhost',
    user: 'Slumpomatorn',
    password: '1234',
    database: 'slumpomatorn9000'
};

let connection;

function handleDisconnect() {
    connection = mysql.createConnection(connectionConfig);

    connection.connect(err => {
        if (err) {
            console.error('Error connecting to database:', err);
            setTimeout(handleDisconnect, 2000); // Reconnect after 2 seconds
        } else {
            console.log('Connected to database');
        }
    });

    connection.on('error', err => {
        console.error('Database error:', err);
        if (err.code === 'PROTOCOL_CONNECTION_LOST') {
            handleDisconnect(); // Reconnect on connection loss
        } else {
            throw err;
        }
    });
}

function keepAlive() {
    connection.ping(err => {
        if (err) {
            console.error('Ping error:', err);
            handleDisconnect();
        } else {
            console.log('Ping successful');
        }
    });
}

handleDisconnect();
setInterval(keepAlive, 60000); // Ping the database every 60 seconds

const router = express.Router();

router.get('/highscores', (req, res) => {
    console.log('Received request to /highscores'); // Log request received
    const query = 'SELECT visitorId, user, score FROM highscores';
    connection.query(query, (error, results, fields) => {
        if (error) {
            console.error('Database error:', error); // Log database error
            res.status(500).send(error);
            return;
        }
        console.log('Fetched highscores:', results); // Log fetched results
        res.json(results);
    });
});

router.get('/userscore', (req, res) => {
    console.log('Received request to /userscore'); // Log request received
    const visitorId = req.query.visitorId;
    if (!visitorId) {
        console.error('visitorId is required'); // Log missing visitorId
        res.status(400).send('visitorId is required');
        return;
    }
    console.log('Fetching score for visitorId:', visitorId); // Log visitorId
    const query = 'SELECT name, hscore FROM users WHERE visitorId = ?';
    connection.query(query, [visitorId], (error, results) => {
        if (error) {
            console.error('Database error:', error); // Log database error
            res.status(500).send(error);
            return;
        }
        console.log('Fetched user score:', results); // Log fetched results
        res.json(results);
    });
});

router.post('/submit-score', (req, res) => {
    console.log('Received request to /submit-score'); // Log request received
    const { visitorId, user, score } = req.body;
    console.log('Received data:', { visitorId, user, score }); // Log received data
    const query = 'INSERT INTO highscores (visitorId, user, score) VALUES (?, ?, ?)';
    connection.query(query, [visitorId, user, score], (error, results) => {
        if (error) {
            console.error('Database error:', error); // Log database error
            res.status(500).send(error);
            return;
        }
        console.log('Score submitted:', results); // Log success message
        res.json(results);
    });
});

router.post('/add-user', (req, res) => {
    const { name, hscore, visitorId } = req.body;
    console.log('Received data:', { name, hscore, visitorId }); // Log received data
    const query = 'INSERT INTO users (name, hscore, visitorId) VALUES (?, ?, ?)';
    connection.query(query, [name, hscore, visitorId], (error, results, fields) => {
        if (error) {
            res.status(500).send(error);
            return;
        }
        res.json(results);
    });
});

router.put('/update-user', (req, res) => {
    console.log('Received request to /update-user'); // Log request received
    const { name, hscore, visitorId } = req.body;
    console.log('Received data:', { name, hscore, visitorId }); // Log received data

    if (!name || !hscore || !visitorId) {
        console.error('Missing required fields'); // Log missing fields
        res.status(400).json({ message: 'Missing required fields' });
        return;
    }

    const query = 'UPDATE users SET name = ?, hscore = ? WHERE visitorId = ?';
    connection.query(query, [name, hscore, visitorId], (error, results, fields) => {
        if (error) {
            console.error('Database error:', error); // Log database error
            res.status(500).send(error);
            return;
        }
        console.log('User updated successfully:', results); // Log success message
        res.status(200).json({ message: 'User updated successfully' });
    });
});

router.get('/generate-number', (req, res) => {
    const winningNumber = Math.floor(Math.random() * 100000000) + 1;
    res.status(200).json({ winningNumber });
});

module.exports = router;