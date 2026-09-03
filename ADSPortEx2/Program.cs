using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree<VideoGame> tree = new AVLTree<VideoGame>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Retro Gaming Preservation Project");
                Console.WriteLine("1. Add Video Game to Tree");
                Console.WriteLine("2. Display Tree In-Order");
                Console.WriteLine("3. Display Tree Pre-Order");
                Console.WriteLine("4. Display Tree Post-Order");
                Console.WriteLine("5. Find Earliest Game by Release Year");
                Console.WriteLine("6. Display Tree Height");
                Console.WriteLine("7. Display Total Count of Games");
                Console.WriteLine("8. Update an Existing Game");
                Console.WriteLine("9. List All Games by Year");
                Console.WriteLine("10. Remove Game from Tree");
                Console.WriteLine("11. Exit");
                Console.WriteLine("");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    string title = "";
                    string developer = "";

                    while (string.IsNullOrWhiteSpace(title))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter Title: ");
                        title = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Title cannot be empty. Please enter a valid title.");
                        }
                    }

                    while (string.IsNullOrWhiteSpace(developer))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter Developer: ");
                        developer = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(developer))
                        {
                            Console.WriteLine("Developer cannot be empty. Please enter a valid developer.");
                        }
                    }

                    int year = GetValidYearInput();
                    tree.InsertItem(new VideoGame(title, developer, year));
                }
                else if (choice == "2")
                {
                    string inOrderOutput = "";
                    tree.InOrder(ref inOrderOutput);
                    Console.WriteLine("");
                    Console.WriteLine("In-Order Traversal:");
                    Console.WriteLine(inOrderOutput);
                }
                else if (choice == "3")
                {
                    string preOrderOutput = "";
                    tree.PreOrder(ref preOrderOutput);
                    Console.WriteLine("");
                    Console.WriteLine("Pre-Order Traversal:");
                    Console.WriteLine(preOrderOutput);
                }
                else if (choice == "4")
                {
                    string postOrderOutput = "";
                    tree.PostOrder(ref postOrderOutput);
                    Console.WriteLine("");
                    Console.WriteLine("Post-Order Traversal:");
                    Console.WriteLine(postOrderOutput);
                }
                else if (choice == "5")
                {
                    VideoGame earliest = tree.EarliestGame();
                    if (earliest != null)
                    {
                        Console.WriteLine($"Earliest Game: {earliest.Title} - {earliest.Developer} ({earliest.Releaseyear})");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("No games in the tree.");
                    }
                }
                else if (choice == "6")
                {
                    Console.WriteLine($"Tree Height: {tree.Height()}");
                }
                else if (choice == "7")
                {
                    Console.WriteLine($"Total games in the tree: {tree.Count()}");
                    Console.WriteLine("");
                }
                else if (choice == "8")
                {
                    string title = "";
                    string developer = "";

                    while (string.IsNullOrWhiteSpace(title))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter the Title of the game you want to update: ");
                        title = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Title cannot be empty. Please enter a valid title.");
                        }
                    }

                    while (string.IsNullOrWhiteSpace(developer))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter the New Developer: ");
                        developer = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(developer))
                        {
                            Console.WriteLine("Developer cannot be empty. Please enter a valid developer.");
                        }
                    }

                    int year = GetValidYearInput();

                    VideoGame updatedGame = new VideoGame(title, developer, year);
                    tree.Update(updatedGame);
                }
                else if (choice == "9")
                {
                    int year = GetValidYearInput();
                    tree.ListByYear(year);
                }
                else if (choice == "10")
                {
                    string titleToRemove = "";
                    while (string.IsNullOrWhiteSpace(titleToRemove))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Enter the Title of the game you want to remove: ");
                        Console.WriteLine("");
                        titleToRemove = Console.ReadLine().Trim();
                    }

                    VideoGame gameToRemove = new VideoGame(titleToRemove, "", 0);

                    int countBefore = tree.Count();
                    tree.RemoveItem(gameToRemove);
                    int countAfter = tree.Count();

                    if (countAfter < countBefore)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Successfully removed {titleToRemove} from the tree.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"{titleToRemove} was not found nor removed.");
                        Console.WriteLine("");
                    }
                }
                else if (choice == "11")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Thank you. Goodbye.");
                    return;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static int GetValidYearInput()
        {
            int year;
            while (true)
            {
                Console.WriteLine("");
                Console.Write("Enter Release Year: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out year) && year > 1940)
                {
                    return year;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid input. Please enter a valid year past 1940.");
                }
            }
        }
    }
}
