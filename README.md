# 🎮 Video Game Inventory Management System

## 📌 Overview
This is a C# console application that manages a video game inventory system. The program allows users to:
- View saved inventory from a file (`VideoGames.txt`)
- Add new games to the inventory
- Search for a game by item number
- Search for games within a price range
- Perform statistical analysis on the inventory

The inventory is stored in a text file and updated dynamically as users interact with the application.

## 🛠️ Features
- **Object-Oriented Design**: Uses a `Game` class to represent video games.
- **File Handling**: Reads and writes inventory data to `VideoGames.txt`.
- **Menu-driven Interface**: Provides an interactive menu for user operations.
- **Exception Handling**: Prevents crashes due to invalid input.
- **Statistical Analysis**: Calculates mean price, price range, highest/lowest priced items.

## 🚀 Getting Started

### Prerequisites
- .NET SDK (Latest version) 
- C# Compiler
- A terminal or command prompt

### Running the Program
1. **Clone the repository**
   ```sh
   git clone <your-repository-url>
   cd Comp1202_Ass2_24
   ```
2. **Compile the program**
   ```sh
   csc Program.cs
   ```
3. **Run the program**
   ```sh
   ./Program.exe
   ```

## 📂 File Structure
```
Comp1202_Ass2_24/
│── Program.cs      # Main application logic
│── Game.cs         # Game class for inventory items
│── VideoGames.txt  # Stored inventory data
│── README.md       # Project documentation
```

## 🛠️ Technologies Used
- **Programming Language**: C#
- **Framework**: .NET
- **File Handling**: StreamReader, StreamWriter
- **Data Storage**: Text file (`VideoGames.txt`)

## 🎯 Future Improvements
- Add **update and delete** functionality for games
- Store data in a **database (SQLite, MySQL)** instead of a text file
- Implement a **GUI using WinForms or WPF**
- Use **LINQ** for more efficient search operations

## 🌍 License
This project is open-source under the MIT License.

## 🤝 Contributing
Feel free to submit issues and pull requests to improve this project!

## 👤 Author
**Oscar Piedrasanta Diaz**  
✉️ Contact: [oscarpiediaz@gmail.com](mailto:oscarpiediaz@gmail.com)
