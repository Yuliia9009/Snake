# Snake Game

Welcome to the classic **Snake** game, implemented in **C#**! This version of the game recreates the atmosphere of the original game popular on Nokia phones, and adds new elements for an even more engaging gameplay experience.

## 📜 History of the Game

The **Snake** game first appeared in 1976 and quickly became one of the most popular arcade games. However, it gained true fame in the late 1990s when it was pre-installed on Nokia mobile phones. The simplicity of the rules and the addictive gameplay made **Snake** one of the most beloved games for millions of people around the world.

## 🎮 Game Rules

- **Controls**: Use the arrow keys on your keyboard to control the snake. The snake moves continuously forward, and you can change its direction.
- **Objective**: Eat as much food as possible to increase the length of the snake and earn points.
- **Food**: After each piece of food is eaten, the snake grows by one cell.
- **Boundaries**: The game ends if the snake collides with the boundary of the playing field or with itself.
- **Score**: The game score is displayed above the playing field.

## 🛠️ Technologies and Approaches Used

### Programming Language

- **C#**

### Development Environment

- **Visual Studio**

### Data Structures and Algorithms

- **List**: Used to store the positions of the snake segments. The list allows dynamic resizing and simplifies working with sequences of data.
- **Enumeration (Enum)**: Used to define the directions of the snake's movement. Enumeration makes the code more readable and understandable.
- **Structure (Struct)**: Used to represent the position on the playing field. The structure allows organizing data as objects with a fixed size.

### Design Patterns

- **Adapter**: This pattern is used to handle user input and change the direction of the snake's movement. The adapter allows abstraction from specific input and works with it through a unified interface.
- **Recursion**: Used to restart the game after it ends. Recursion makes it easy to manage game states and restart the game without unnecessary complexity.
- **Encapsulation**: This object-oriented programming principle is used to hide implementation details and provide only the necessary interface for interacting with objects. For example, methods for changing the snake's direction and checking for collisions.
- **Iterator**: Used for sequential access to the elements of the snake's collection. The iterator provides a convenient way to traverse elements without exposing the underlying structure of the collection.

## 📁 Project Structure

The project is divided into several files for ease of navigation and understanding of the code:

### `Program.cs`

Contains the entry point of the application and is responsible for starting the game.

### `SnakeGame.cs`

Contains the main game class, which implements all the game logic, including snake control, food generation, collision handling, and displaying the playing field.

### `Direction.cs`

Contains an enumeration to represent the directions of the snake's movement.

### `Position.cs`

Contains a structure to represent the position on the playing field.

## 🚀 Running the Game

To run the game, follow these steps:

1. Clone the repository.
   ```sh
   git clone https://github.com/Yuliia9009/Snake.git
   ```
2. Open the project in Visual Studio.
3. Build and run the project.
4. Follow the on-screen instructions to start the game.

## 📜 License

This project is licensed under the MIT License. For more details, see the [LICENSE](LICENSE.md) file.
```
