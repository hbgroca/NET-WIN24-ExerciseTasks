using ConsoleApp1.Models;
using System.Data;

namespace ConsoleApp1
{
    internal class Program
    {
        static bool isRunning = true;

        static List<ToDo> ToDoList = [];
        

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("XOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOX");
                Console.WriteLine("XO ");
                Console.WriteLine("XO Att göra:");
                if (ToDoList.Count != 0) { printList(); } else Console.WriteLine("XO - Listan är tom, lägg till en ny todo nedan.");
                Console.WriteLine("XO ");
                Console.WriteLine(
                    "XO 1 Lägg till att göra\n" +
                    "XO 2 Toggla avklarad\n" +
                    "XO 3 Skriv ut listan \n" +
                    "XO 4 Ta bort\n" +
                    "XO 5 Avsluta");

                char input = Console.ReadKey().KeyChar;
                Console.WriteLine(input);
                switch (input)
                {
                    case '1':
                        {
                            AddToDo();
                            break;
                        }
                    case '2':
                        {
                            ToggleToDo();
                            break;
                        }
                    case '3':
                        {
                            PrintToDo();
                            break;
                        }
                    case '4':
                        {
                            RemoveToDo();
                            break;
                        }
                    case '5':
                        {
                            isRunning = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (isRunning);
        }

        static void AddToDo()
        {
            ToDo newTodo = new ToDo();
            Console.Clear();
            Console.WriteLine("XOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOX");
            Console.WriteLine("XO ");
            Console.Write("XO Lägg till att göra: ");
            newTodo.Todo = Console.ReadLine()!;

            if(newTodo.Todo == "") 
            {
                Console.WriteLine("Du glömde att skriva in något att göra, är du dement?");
                Console.ReadKey();
            }else ToDoList.Add(newTodo);
        }

        static void ToggleToDo()
        {
            Console.Clear();
            Console.WriteLine("XOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOX");
            Console.WriteLine("XO ");

            for (int i = 0; i < ToDoList.Count; i++)
            {
                Console.WriteLine($"XO - {i + 1} - {ToDoList[i].Todo}, avklarad: {ToDoList[i].IsDone}");
            };

            Console.WriteLine("XO");
            Console.Write("XO Vilket index vill du av-/markera som avklarad: ");

            string indexToRemove = Console.ReadLine()!;
            int.TryParse(indexToRemove, out int output);
            output--;
            if (output >= 0 && output < ToDoList.Count)
            {
                // Vänder på bool
                ToDoList[output].IsDone = !ToDoList[output].IsDone;
            }
            else
            {
                Console.WriteLine($"XO ");
                Console.WriteLine($"XO Du har gjort ett felaktigt val, är du helt jävla dum i huvudet? återgår till huvudmeny");
                Console.ReadKey();
            };
        }

        static void PrintToDo()
        {
            Console.Clear();
            Console.WriteLine("XOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOX");
            Console.WriteLine("XO ");
            for (int i = 0; i < ToDoList.Count; i++)
            {
                Console.WriteLine($"XO - {i + 1} - {ToDoList[i].Todo}, avklarad: {ToDoList[i].IsDone}");
            };
            Console.WriteLine("XO ");
            Console.WriteLine("XO - Tryck valfri knapp för att återgå till huvudmeny.");
            Console.ReadKey();
        }

        static void RemoveToDo() {
            Console.Clear();
            Console.WriteLine("XOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOXXOXOXOXOXOXOXOXOXOXOXOXOXOXOXOX");
            Console.WriteLine("XO ");

            for (int i = 0; i < ToDoList.Count; i++)
            {
                Console.WriteLine($"XO - {i+1} - {ToDoList[i].Todo}");
            };

            Console.WriteLine("XO");
            Console.Write("XO Vilket index vill du ta bort?: ");

            string indexToRemove = Console.ReadLine()!;
            int.TryParse(indexToRemove, out int output);
            output --;
            if (output >= 0 && output < ToDoList.Count)
            {
                ToDoList.Remove(ToDoList[output]);
            }
            else {
                Console.WriteLine($"XO ");
                Console.WriteLine($"XO Du har gjort ett felaktigt val, är du helt jävla dum i huvudet? återgår till huvudmeny");
                Console.ReadKey();
            };
        }

        static void printList()
        {
            List<ToDo> finishedTodos = new List<ToDo>();

            ToDoList.ForEach(x =>
            {
                if (x.IsDone)
                {
                    finishedTodos.Add(x);
                }
                else {
                    Console.WriteLine($"XO - {x.Todo}");
                }
            });
            if(finishedTodos.Count > 0) {
                Console.WriteLine("XO");
                Console.WriteLine("XO Avklarat");
                finishedTodos.ForEach(x => Console.WriteLine($"XO - {x.Todo}"));
            };
        }
    }
}
