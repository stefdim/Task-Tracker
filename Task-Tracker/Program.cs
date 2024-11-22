using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;





namespace Task_Tracker
{

    class Program
    {

        static void Main(string[] args)
        {

            List<string> taskList = new List<string>();
            Console.Write("\n1. Display tasks\n2. Add task\n3. Delete task\n4. Update task\n(Type 'exit' to close)::>");
            string userInput = Console.ReadLine();



            if (File.Exists("taskFile.txt"))
            {
                taskList.AddRange(File.ReadAllLines("taskFile.txt"));
            }




            while (!(userInput == "exit"))
            {



                switch (userInput)
                {
                    case "1":
                        if (!taskList.Any())
                        {

                            Console.WriteLine("\nNo tasks yet.\n");
                            break;
                        }
                        else
                        {
                            foreach (string task in taskList)
                            {
                                Console.WriteLine(task + "\n");
                            }
                            break;
                        }
                    case "2":
                        Console.Write("New task: ");
                        string taskToAdd = Console.ReadLine();

                        // Check if the task already exists
                        if (taskList.Contains(taskToAdd))
                        {
                            Console.WriteLine($"\nTask \"{taskToAdd}\" already exists.\n");
                        }
                        else
                        {
                            // Add new task and save to file
                            taskList.Add(taskToAdd);
                            File.WriteAllLines("taskFile.txt", taskList);
                            Console.WriteLine($"\nTask \"{taskToAdd}\" added.\n");
                        }
                        break;
                    case "3":
                        Console.Write("Task to be deleted: ");
                        string taskToDelete = Console.ReadLine();
                        if (taskList.Contains(taskToDelete))
                        {
                            taskList.Remove(taskToDelete);
                            File.WriteAllLines("taskFile.txt", taskList);
                            Console.WriteLine($"\nTask '{taskToDelete}' has been removed!\n");

                        }
                        else
                        {
                            Console.WriteLine($"\nTask {taskToDelete} not found.\n");

                        }
                        break;
                    case "4":
                        Console.Write("\nTask to update: ");
                        string taskToUpdate = Console.ReadLine();
                        Console.Write("New(updated) task: ");
                        string updatedTask = Console.ReadLine();
                        if (taskList.Contains(taskToUpdate))
                        {
                            taskList.Remove(taskToUpdate);
                            taskList.Add(updatedTask);
                            File.WriteAllLines("taskFile.txt", taskList);
                            Console.WriteLine($"\nTask '{taskToUpdate}' has been updated to '{updatedTask}' sucessfully!\n");
                        }
                        else
                        {
                            Console.WriteLine($"\nTask '{taskToUpdate}' not found!\n");
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid input. Type the number of each option or type exit to close.\n");
                        break;

                }
                Console.Write("1. Display tasks\n2. Add task\n3. Delete task\n4. Update task\n(Type 'exit' to close)::>");
                userInput = Console.ReadLine();
            }


        }
    }




}

