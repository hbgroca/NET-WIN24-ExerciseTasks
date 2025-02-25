// Element
const inputHighestNumberUI = document.querySelector('.HighestNumber');
const inputTriesNumberUI = document.querySelector('.TriesNumber');
const inputValueUI = document.getElementsByClassName('inputValue')[0];

const triesLeftUI = document.querySelector('.guesses-left');
const statusUI = document.querySelector('.status');

const previusGuessesUI = document.getElementsByClassName('previusGuesses')[0];

// Variabler
let inputHighestNumber = 100; // Highest number
let inputTriesNumber = 10; // Try numbers
let inputValue = 0; // Keypad value
let wn = 0; // Winning number
let scoresFromDB = []; // Scores from DB
let username = ""; // Username
let userhighscore = 0; // Username
let userexistinDB = 0; // Username

const database = 'dbpdevelop.mynetgear.com'; // Database URL

// Arrays
const failMessages = ['Försök igen', 'Nästan', 'Du är på rätt spår', 'Kanske nästa gång', 'Nästan där', 'Nära', 'Du är nära'];
const winMessages = ['Grattis du vann!', 'Du är bäst!', 'Du är en vinnare!', 'Du är grym!', 'Du är bäst!', 'Bra jobbat!'];
let previusGuesses = [];


// Kontrollera om en unik identifierare redan finns, annars skapa en ny
let visitorId = getCookie('visitorId');
if (!visitorId) {
    visitorId = uuidv4(); // Generera en ny UUID
    setCookie('visitorId', visitorId, 365); // Spara i en cookie i 365 dagar
}


// GAME
async function startGame(){
    document.querySelector('.platsilistan').href = '#'+visitorId;

    // Kontrollera att numret är mellan 1 och 100.000.000
    inputHighestNumber = inputHighestNumberUI.value;
    if(inputHighestNumber < 1 || inputHighestNumber > 100000000){
        alert('Högsta numret måste vara mellan 1 och 100.000.000');
        return;
    }
    if(inputTriesNumberUI.value < 1 || inputTriesNumberUI.value > 1000){
        alert('Antal försök måste vara mellan 1 och 1000');
        return;
    }
    inputValueUI.max = inputHighestNumber;

    // Reset UI Text elements
    statusUI.firstElementChild.innerHTML = 'Gissa ett nummer';
    statusUI.children[1].innerHTML = 'Mellan <span>1</span> och <span>' + inputHighestNumber + '</span>';   
    // Dölj Fail, win och highscore
    document.querySelector('.blur-bg').style.display = 'none';
    document.querySelector('.card-fail').style.opacity = '0';
    document.querySelector('.card-fail').style.scale = '0';
    document.querySelector('.card-win').style.opacity = '0';
    document.querySelector('.card-win').style.scale = '0';
    // Visa Hero
    document.querySelector('.hero').style.opacity = '1';
    document.querySelector('.hero').style.scale = '1';
    document.querySelector('.card-inputside').style.opacity = '1';
    document.querySelector('.card-inputside').style.scale = '1';

    // Reset previusGuesses
    wn = gRn();
    previusGuesses = [];
    generatePreviusGuesses();
    
    inputTriesNumber = inputTriesNumberUI.value;
    inputValue = 0;
    inputValueUI.value = inputValue;
    triesLeftUI.innerHTML = inputTriesNumber;
}
function numpadClicked(input){
    // Clear input
    if(input === 'C'){
        inputValue = 0;
        inputValueUI.value = inputValue;
        return;
    }
    // Enter input
    if(input === 'Enter'){
        // Lägg till i previusGuesses
        previusGuesses.push(inputValueUI.value);
        generatePreviusGuesses();

        // Kolla om gissningen är rätt
        checkGuess();

        // Nollställ input
        inputValue = 0;
        inputValueUI.value = inputValue;

        return;
    }

    // Number inputs
    inputValue = '' + inputValue + input + '';
    inputValue = Number(inputValue);
    if(Number(inputValue) > inputHighestNumber){
        inputValue = inputHighestNumber;
    };

    inputValueUI.value = inputValue;
}
function checkGuess(){
    if(inputValueUI.value == wn){
        // Vinst
        gameWon();
        return;
    }

    // Uppdatera försök UI
    inputTriesNumber--;
    triesLeftUI.innerHTML = inputTriesNumber;

    // Försök slut
    if(inputTriesNumber <= 0){
        gameFailed();
        return;
    }

    // Uppdatera satus övre text
    const failMessage = failMessages[Math.floor(Math.random() * failMessages.length)];
    statusUI.firstElementChild.innerHTML = failMessage;
    
    // Uppdatera status nedre text
    let Message = 'Prova ett <span>högre</span> nummer';
    if (inputValue > wn){
        Message = 'Prova ett <span>lägre</span> nummer'
    }
    statusUI.children[1].innerHTML = Message;
}
function generatePreviusGuesses(){
    let html = '';
    for(let i = 0; i < previusGuesses.length; i++){
        html += '<li>' + previusGuesses[i] + '</li>';
    }
    previusGuessesUI.innerHTML = html;
}

// GAME ENDED
function gameFailed(){
    // Dölj Hero
    document.querySelector('.card-inputside').style.opacity = '0';
    document.querySelector('.card-inputside').style.scale = '0';
    // Visa Fail
    document.querySelector('.card-fail').style.opacity = '1';
    document.querySelector('.card-fail').style.scale = '1';

    document.querySelector('.card-fail-correctAnswer').innerHTML = wn;

    // Visa new highscore nedanför spelet
    generateScore();
    document.querySelector('.highscores').style.opacity = '1';
}
function gameWon(){
    // Dölj Input
    document.querySelector('.card-inputside').style.opacity = '0';
    document.querySelector('.card-inputside').style.scale = '0';
    // Visa Win
    document.querySelector('.card-win').style.opacity = '1';
    document.querySelector('.card-win').style.scale = '1';

    document.querySelector('.card-win').firstElementChild.innerHTML = winMessages[Math.floor(Math.random() * winMessages.length)];  
    document.querySelector('.win-score').innerHTML = calculateScore();  

    document.querySelector('.card-win-guesses').innerHTML = previusGuesses.length;
    document.querySelector('.card-win-correctAnswer').innerHTML = wn;

    // Visa new highscore rutan om spelaren har nytt highscore
    if(calculateScore() > userhighscore){
        document.querySelector('.inputUsername').value = username;
        document.querySelector('.blur-bg').style.display = 'flex';
    };
    
    // Visa new highscore nedanför spelet
    generateScore(); // Generera highscore-listan
    document.querySelector('.highscores').style.opacity = '1';
}
function cancelSave(){
    document.querySelector('.blur-bg').style.display = 'none';
}
function saveHighscore(){
    userhighscore = calculateScore();
    document.querySelector('.blur-bg').style.display = 'none';
    username = document.querySelector('.inputUsername').value;
    if(username == ''){
        username = 'Anonym';
    }

    if(userexistinDB == 0){
        // Add user to DB togheter with score
        addUser(username, Number(userhighscore));
        userexistinDB = 1;
    }else{
        // Update user score
        updateUser(username, Number(userhighscore));
    }
    // Refresh av highscore-listan
    scoresFromDB.push({user: username, score: userhighscore, visitorId: getCookie('visitorId')});

    generateScore(); // Generera highscore-listan

    // Skicka scroring till DB
    submitScore(username, Number(userhighscore));
    document.querySelector('.usertext').innerHTML = 'Användare: ' + username + ' - ' + userhighscore + ' poäng';
}



// FUNCTIONS
function gRn(){
    return Math.floor(Math.random() * inputHighestNumber) + 1;
}
function calculateScore(){
    let score = 0;
    if (inputTriesNumber == 0){
        score = 0;
    } else {
        score = Math.floor(inputHighestNumber / (Number(previusGuesses.length+1))*100);
    }
    return score;
}


// USER DATA
async function getUserScore() {
    const visitorId = getCookie('visitorId');
    if (!visitorId) {
        console.error('visitorId is not set');
        return;
    }
    const response = await fetch(`https://${database}:443/userscore?visitorId=${visitorId}`);
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    const userScore = await response.json();
    // console.log(userScore);
    return userScore;
}
getUserScore().then(userScore => {
    userScore.forEach(x => {
        userhighscore = x.hscore;
        username = x.name;

        document.querySelector('.usertext').innerHTML = 'Användare: ' + username + ' - ' + userhighscore + ' poäng';
    })
    }).catch(error => {
    console.error('Error fetching scores:', error);
});
async function addUser(name, hscore) {
    const visitorId = getCookie('visitorId');
    const response = await fetch(`https://${database}:443/add-user`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, hscore, visitorId })
    });
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    return await response.json();
}
async function updateUser(name, hscore) {
    try {
        const visitorId = getCookie('visitorId');
        const response = await fetch(`https://${database}:443/update-user`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ name, hscore, visitorId })
        });
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return await response.json();
    } catch (error) {
        console.error('Error updating user:', error);
    }
}


// HIGHSCORE LIST
async function generateScore() {
    // Filtrera bort dubbletter och behåll det högsta score värdet för varje användare baserat på visitorId
    const uniqueScores = scoresFromDB.reduce((acc, current) => {
        const existing = acc.find(item => item.visitorId === current.visitorId);
        if (!existing) {
            return acc.concat([current]);
        } else if (current.score > existing.score) {
            return acc.map(item => item.visitorId === current.visitorId ? current : item);
        } else {
            return acc;
        }
    }, []);
    scoresFromDB = uniqueScores;

    // Sortra på score
    scoresFromDB.sort((a, b) => b.score - a.score);

    // Skapa HTML för highscore-listan
    let html = '';
    scoresFromDB.forEach(x => {
        if(x.visitorId == getCookie('visitorId')){
            html += '<li style="color: orange; font-size: 1.3rem; font-weight: 600" id="' + x.visitorId + '">' + x.user + ' - ' + x.score + '</li>';
        }else{
            html += '<li id="' + x.visitorId + '">' + x.user + ' - ' + x.score + '</li>';
        }
    });

    // Skriv ut HTML
    document.querySelector('.highscore-list').innerHTML = html;
}
async function submitScore(user, score) {
    const visitorId = getCookie('visitorId');
    const response = await fetch(`https://${database}:443/submit-score`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ visitorId, user, score })
    });
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    return await response.json();
}
async function getScores() {
    try {
        const response = await fetch(`https://${database}:443/highscores`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const scores = await response.json();
        return scores;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}
getScores().then(scores => {
    scoresFromDB = scores;
}).catch(error => {
    console.error('Error fetching scores:', error);
});


// Cookie
// Funktion för att sätta en cookie
function setCookie(name, value, days) {
    const d = new Date();
    d.setTime(d.getTime() + (days * 24 * 60 * 60 * 1000));
    const expires = "expires=" + d.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}

// Funktion för att hämta en cookie
function getCookie(name) {
    const nameEQ = name + "=";
    const ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}


// Funktion för att generera en UUID
function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        const r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}