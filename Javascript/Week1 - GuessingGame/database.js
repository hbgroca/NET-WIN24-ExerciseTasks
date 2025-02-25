const mysql = require('mysql2');

const connection = mysql.createConnection({
    host: 'localhost',
    user: 'Slumpomatorn',
    password: '1234',
    database: 'slumpomatorn9000'
});

connection.connect((err) => {
    if (err) {
        console.error('Error connecting to the database:', err.stack);
        return;
    }
    console.log('Connected to the database as id ' + connection.threadId);
});

module.exports = connection;