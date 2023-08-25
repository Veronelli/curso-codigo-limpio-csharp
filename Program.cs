using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            int variable = 0;
            do
            {
                variable = ShowMainMenu();
                if (variable == 1)
                {
                    ShowMenuAdd();
                }
                else if (variable == 2)
                {
                    ShowMenuRemove();
                }
                else if (variable == 3)
                {
                    ShowMenuListTask();
                }
            } while (variable != 4);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();

            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                GetTaskList();
                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                

                if (TaskList?.Count < 0)
                    Console.WriteLine("Ingrese un id valido");

                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {task} eliminada");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error");
            }
        }

        public static void ShowMenuAdd()
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string task = Console.ReadLine();
            if (task != ""){
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            else{
                Console.WriteLine("Dato invalido");
            }
        }

        public static void ShowMenuListTask()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                GetTaskList();
            }
        }

        public static void GetTaskList()
        {
                Console.WriteLine("----------------------------------------");
                int indexTaskList = 0;
                TaskList.ForEach(p=> Console.WriteLine($"{++indexTaskList} . {p}"));

                Console.WriteLine("----------------------------------------");
        }
    }
}
