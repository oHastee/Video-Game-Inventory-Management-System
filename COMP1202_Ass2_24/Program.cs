// Oscar Piedrasanta Diaz 101061602
// Valeria Arce 101462436
// Kadir Cinar 101469903
using System;
using System.IO; // System Input Output

internal class Game
{
    // attributes
    private int itemNumber;
    private string itemName;
    private double price;
    private int rating;
    private int quantity;

    public Game(int itemNumber, string itemName, double price, int rating, int quantity)
    {
        this.itemNumber = itemNumber;
        this.itemName = itemName;
        this.price = price;
        this.rating = rating;
        this.quantity = quantity;
    }
    /*public Game()
    {

    }*/

    // Ensuring that the rating of the game is between 0-5
    public int Rating
    {
        get { return rating; }
        set
        {
            if (value == 0 || value == 1 || value == 2 || value == 3 || value == 4 || value == 5)
            {
                rating = value;
            }
            else
            {
                rating = 5;
            }
        }
    }
    // Getters:
    public int getNumber() { return itemNumber; }
    public string getName() { return itemName; }
    public double getPrice() { return price; }
    public double getRating() { return rating; }
    public int getQuantity() { return quantity; }

    public override string ToString()
    {
        return itemNumber + "," + itemName + "," + price + "," + rating + "," + quantity;
    }
}

namespace Comp1202_Ass2_24
{
    class Program
    {
        static void Main(string[] args)
        {
            Game[] inventory = new Game[1000]; // creating an array to hold up to 1000 game objects
            // Intial games
            inventory[0] = new Game(1001, "Call of Duty: Modern Warfare II", 40.00, 5, 10);
            inventory[1] = new Game(1002, "Grand Theft Auto V", 55.00, 4, 10);
            inventory[2] = new Game(1003, "The Legend of Zelda: Breath of the Wild", 60.99, 4, 31);
            inventory[3] = new Game(1004, "Minecraft", 25.99, 3, 4);
            inventory[4] = new Game(1005, "Fortnite", 40.00, 5, 20);

            string path = "VideoGames.txt"; // Define the file path for saving inventory data
            if (!File.Exists(path)) // checks if the the VideoGames.txt file exsits
            {
                StreamWriter sw = new StreamWriter(path);
                if (inventory[0] != null)
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] != null) // Check if the element is initialized
                        {
                            sw.WriteLine(inventory[i].ToString()); // Write inventory data to the file
                        }
                    }
                sw.Close();
            }
            else
            {
                Console.Write("Welcome to "); // Placeholder for the welcome message
            }
            // Menu
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Access Saved Inventory");
                Console.WriteLine("2. Add New Items");
                Console.WriteLine("3. Search for an item based on item number");
                Console.WriteLine("4. Search for an item based on max price");
                Console.WriteLine("5. Perform Statistical Analysis");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();


                try
                {
                    int choice = Convert.ToInt32(userInput);
                    // switch statement for the menu
                    switch (choice)
                    {
                        case 1:
                            // Access Saved Inventory
                            Console.WriteLine("\nCurrent Inventory:\n");
                            StreamReader sr = new StreamReader("VideoGames.txt");
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                Console.WriteLine(line); // // Print each line from the file
                            }
                            Console.WriteLine("\n");
                            sr.Close();
                            break;
                        case 2:
                            // Add New Items
                            bool foundEmptySlot = false;
                            for (int i = 0; i < inventory.Length; i++)
                            {
                                if (inventory[i] == null) // Find an empty slot in the array
                                {
                                    foundEmptySlot = true;

                                    Console.WriteLine("Adding New Game");
                                    StreamWriter sw = new StreamWriter(path, true);

                                    // Converting from string to apporpiate data type
                                    Console.Write("Enter item number: ");
                                    int itemNumber = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Enter item name: ");
                                    string itemName = Console.ReadLine();

                                    Console.Write("Enter price: $");
                                    double price = Convert.ToDouble(Console.ReadLine());

                                    Console.Write("Enter user rating: ");
                                    int rating = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Enter quantity available: ");
                                    int quantity = Convert.ToInt32(Console.ReadLine());

                                    inventory[i] = new Game(itemNumber, itemName, price, rating, quantity);

                                    sw.WriteLine(inventory[i].ToString()); // Write new game data to the file
                                    sw.Close(); // Close the StreamWritter

                                    Console.WriteLine("New game added to the inventory.");
                                    break;
                                }
                            }
                            if (!foundEmptySlot) // If array is full
                            {
                                Console.WriteLine("Inventory is full. Cannot add more games.");
                            }
                            break;
                        case 3:
                            // Search for an Item based on item number
                            Console.Write("Enter item number to search: ");
                            int searchItemNumber = Convert.ToInt32(Console.ReadLine());

                            bool found = false;

                            sr = new StreamReader("VideoGames.txt");

                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                string[] gameInfo = line.Split(',');

                                if (gameInfo.Length >= 5 && int.Parse(gameInfo[0]) == searchItemNumber)
                                {
                                    // Print the information of the found game
                                    Console.WriteLine("\nItem Number: " + gameInfo[0]);
                                    Console.WriteLine("Item Name: " + gameInfo[1]);
                                    Console.WriteLine("Price: $" + gameInfo[2]);
                                    Console.WriteLine("User Rating: " + gameInfo[3]);
                                    Console.WriteLine("Quantity Available: " + gameInfo[4]);

                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("\nItem with item number " + searchItemNumber + " not found in the inventory.");
                            }

                            if (sr != null)
                            {
                                sr.Close();
                            }

                            break; // Exit the loop once the game is found
                        case 4:
                            // Search for games based on max price
                            Console.Write("Enter maximum price: ");
                            double maxPrice = Convert.ToDouble(Console.ReadLine());

                            bool foundPrice = false;
                            StreamReader srPrice = null;

                            srPrice = new StreamReader("VideoGames.txt");  // Open the file for reading

                            while (!srPrice.EndOfStream)
                            {
                                string line = srPrice.ReadLine();
                                string[] gameInfo = line.Split(',');

                                if (gameInfo.Length >= 5 && double.Parse(gameInfo[2]) <= maxPrice) // Check if the line contains enough data components and the price is within the specified range
                                {
                                    // Print the information of the games within the specified price range
                                    Console.WriteLine("\nItem Number: " + gameInfo[0]);
                                    Console.WriteLine("Item Name: " + gameInfo[1]);
                                    Console.WriteLine("Price: $" + gameInfo[2]);
                                    Console.WriteLine("User Rating: " + gameInfo[3]);
                                    Console.WriteLine("Quantity Available: " + gameInfo[4]);

                                    foundPrice = true;
                                }
                            }

                            if (!foundPrice) // If no games were found in the specified price range, display a message
                            {
                                Console.WriteLine("\nNo games found within the specified price range.");
                            }

                            if (srPrice != null)
                            {
                                srPrice.Close();
                            }

                            break;
                        case 5:
                            // Perform Statistical Analysis
                            // Initialization
                            double totalPrices = 0;
                            double lowestPrice = double.MaxValue;
                            double highestPrice = double.MinValue;
                            string lowestPriceItem = "";
                            string highestPriceItem = "";
                            int itemCount = 0;

                            StreamReader srAnalysis = null; 

                            srAnalysis = new StreamReader("VideoGames.txt");  // Open the file for reading

                            while (!srAnalysis.EndOfStream)
                            {
                                string line = srAnalysis.ReadLine();
                                string[] gameInfo = line.Split(','); // Split the line into individual data components

                                if (gameInfo.Length >= 3)  // Check if the line contains enough data components
                                {
                                    double price = double.Parse(gameInfo[2]);

                                    // Calculate the total prices and count the items
                                    totalPrices += price; 
                                    itemCount++;

                                    // Find the lowest price and corresponding item
                                    if (price < lowestPrice)
                                    {
                                        lowestPrice = price;
                                        lowestPriceItem = gameInfo[1];
                                    }

                                    // Find the highest price and corresponding item
                                    if (price > highestPrice)
                                    {
                                        highestPrice = price;
                                        highestPriceItem = gameInfo[1];
                                    }
                                }
                            }

                            // If there are items in the inventory, perform analysis and display results
                            if (itemCount > 0)
                            {
                                double meanPrice = totalPrices / itemCount;
                                double priceRange = highestPrice - lowestPrice;

                                Console.WriteLine("\nStatistical Analysis:");
                                Console.WriteLine("Mean Price: $" + meanPrice);
                                Console.WriteLine("Price Range: $" + priceRange);
                                Console.WriteLine("Item with Lowest Price: " + lowestPriceItem + " ($" + lowestPrice + ")");
                                Console.WriteLine("Item with Highest Price: " + highestPriceItem + " ($" + highestPrice + ")");
                            }
                            else
                            {
                                // If no items are in stock, display a message
                                Console.WriteLine("\nNo items in stock for statistical analysis.");
                            }

                            if (srAnalysis != null)
                            {
                                srAnalysis.Close();
                            }

                            break;
                        case 6:
                            /* SaveInventory();*/
                            Environment.Exit(0); // Exit the program
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (FormatException) // Handles error if user enters a letter 
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid number."); // error message upon entering a string and not an int
                }
            }
        }


    }
}