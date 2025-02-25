import React, { useState, useEffect } from 'react';
import './css/todo.css';



function Todolist(){
    const [tasks, setTasks] = useState([]); // Array med alla tasks
    const [tasksDone, setTasksDone] = useState([]); // Array med alla färiga tasks
    const [inputField, setInputField] = useState(''); // Inputfältet uppdateras med newTask
    const [isComponentLoaded, setIsComponentLoaded] = useState(false);

    // Uppdaterar inputField med det som skrivs in i input-fältet
    function handleInputChange(event){ 
        setInputField(event.target.value);
    };

    // Add task
    function addTask(event){
        event.preventDefault(); // Förhindra att sidan laddas om
        // Om inputField är tom
        if(inputField == ''){
            console.log('Inget att lägga till');
            return;
        };

        // Lägg till inputField i tasks
        setTasks([...tasks, inputField]); // Lägg till inputField i tasks

        console.log(`Lagt till ${inputField} i tasks`);
        
        // Hoppa till botten av sidan
        goToBottom();
        
        // Rensa inputfältet
        setInputField('');
    };

    function goToBottom(){
        window.scrollTo(0,document.body.scrollHeight);
    }

    // Task done
    function doneTask(index){
        const cloneOfTasksArray = [...tasks]; // Skapa kopior av tasks-arrayen
        const taskToMove = cloneOfTasksArray[index]; // Hämta tasket som ska flyttas
        cloneOfTasksArray.splice(index, 1); // Ta bort elementet på index, och endast det elementet
        setTasks(cloneOfTasksArray); // Uppdatera tasks med den nya arrayen

        setTasksDone([...tasksDone, taskToMove]); // Lägg till tasket i tasksDone

        console.log(`Flyttat ${taskToMove} från tasks till tasksDone`);
    };

    // Remove
    function deleteTask(index){
        const cloneOfTasksArray = [...tasks]; // Skapa kopior av tasks-arrayen

        console.log(`Raderat ${cloneOfTasksArray[index]} från tasks`);

        cloneOfTasksArray.splice(index, 1); // Ta bort elementet på index, och endast det elementet
        setTasks(cloneOfTasksArray); // Uppdatera tasks med den nya arrayen
    };
    function deleteDoneTask(index){
        const cloneOfTasksArray = [...tasksDone];

        console.log(`Raderat ${cloneOfTasksArray[index]} från done tasks`);

        cloneOfTasksArray.splice(index, 1); // Ta bort elementet på index, och endast det elementet
        setTasksDone(cloneOfTasksArray); // Uppdatera tasks med den nya arrayen
    };

    // Move task up or down
    function moveTask(index, direction){
        // Om index är 0 och direction är up, eller om index är tasks.length-1 och direction är down
        if(index == 0 && direction == 'up' || index == tasks.length-1 && direction == 'down'){
            console.log('Kan inte flytta tasket längre');
            return;
        }

        const cloneOfTasksArray = [...tasks]; // Skapa en kopia av tasks-arrayen
        const taskToMove = cloneOfTasksArray[index]; // Hämta tasket som ska flyttas
        cloneOfTasksArray.splice(index, 1); // Ta bort elementet på index, och endast det elementet
        if(direction == 'up'){
            console.log(`Flyttat ${taskToMove} från index ${index} till index ${index-1}`);
            cloneOfTasksArray.splice(index-1, 0, taskToMove); // Lägg till tasket på index-1
        } else if(direction == 'down'){
            console.log(`Flyttat ${taskToMove} från index ${index} till index ${index+1}`);
            cloneOfTasksArray.splice(index+1, 0, taskToMove); // Lägg till tasket på index+1
        }

        setTasks(cloneOfTasksArray); // Uppdatera tasks med den nya arrayen
    };

    function saveToLocalStorage(){
        localStorage.setItem('tasks', JSON.stringify(tasks));
        localStorage.setItem('tasksDone', JSON.stringify(tasksDone));

        console.log('Sparat tasks och tasksDone till localStorage');
    };

    function getFromLocalStorage(){
        const tasksFromLocalStorage = JSON.parse(localStorage.getItem('tasks'));
        const tasksDoneFromLocalStorage = JSON.parse(localStorage.getItem('tasksDone'));

        if(tasksFromLocalStorage){
            setTasks(tasksFromLocalStorage);
            console.log('Hämtat tasks från localStorage');
        }
        if(tasksDoneFromLocalStorage){
            setTasksDone(tasksDoneFromLocalStorage);
            console.log('Hämtat tasksDone från localStorage');
        }
    }

    // Kör vi getFromLocalStorage när komponenten laddas
    useEffect(() => {
        getFromLocalStorage();
        setIsComponentLoaded(true);
    }, []);

    useEffect(() => {
        if (isComponentLoaded) {
            saveToLocalStorage();
        }
    }, [tasks, tasksDone]);

    return (
    <>
    <div className='todo-wrapper'>
        <main className='main'>
            <div className='bg-logo'>
                <h1>MIN</h1>
                <h1>TODO</h1>
                <h1>LISTA</h1>
            </div>
            
            <section className='tasks-wrapper'>
                <ul>
                <h3>Att göra</h3>
                <p className='tasks-empty-string'>{tasks.length === 0 ? 'Här var det tomt. Lägg till en ny uppgift.' : ''}</p>
                {tasks.map((task, index, array) => 
                    <li key={index}>
                        <span className='text'>
                            {task}
                        </span>
                        <div className='btn-wrapper'>
                            {/* <button onClick={()=>{deleteTask(index)}} className='delete-btn'>X</button> */}
                            <button onClick={()=>{moveTask(index, 'up')}} className='moveUp-btn'>☝</button>
                            <button onClick={()=>{moveTask(index, 'down')}} className='moveDown-btn'>👇</button>
                            <button onClick={()=>{doneTask(index)}} className='done-btn'>✔</button>
                        </div>
                    </li>
                    )}
                </ul>
            </section>

            <section className="doneTasks-wrapper">
                <div className='doneTasks-container'>
                    <div className='doneTasks-header'>
                        <h3>Avklarade</h3>
                        <div className='doneTasks-header-right'>
                            <p>({tasksDone.length})</p>
                            <button className='btn-view-done-tasks show' onClick={() => {document.querySelector('.view-done-tasks-list').classList.toggle('hidden')}}>👁</button>
                        </div>
                    </div>
                    <ul className='view-done-tasks-list hidden'>
                        {tasksDone.map((task, index, array) => 
                            <li key={index}>
                                <span className='text'>
                                    {task}
                                </span>
                                <div>
                                    <button onClick={()=>{deleteDoneTask(index)}} className='delete-btn'>X</button>
                                </div>
                            </li>
                        )}
                    </ul>
                </div>

            </section>
        </main>

        <footer className=''>
            <div className='todo-list'>
                {/* <h1>To Do Lista</h1> */}
                <form className='inputs'>
                    <input type="text" name="input-submit" id="input-text" value={inputField} onChange={handleInputChange} placeholder='Lägg till uppgift...' />
                    <input id='input-submit' type="submit" value="Lägg till" className='add-btn' onClick={addTask}/>
                </form>
            </div>
        </footer>

    </div>
    </>);
};

export default Todolist;