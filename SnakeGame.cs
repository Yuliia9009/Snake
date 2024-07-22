using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class SnakeGame
{
    const int Width = 20;
    const int Height = 20;
    const char SnakeChar = '*';
    const char FoodChar = 'O';
    const char BorderChar = '#';
    const char EmptyChar = ' ';

    static int InitialGameSpeed = 500; 
    static int GameSpeed;

    public void Start()
    {
        Console.WriteLine("Welcome to Snake Game!");
        Console.WriteLine("Rules:");
        Console.WriteLine("1. Use arrow keys to move the snake.");
        Console.WriteLine("2. The snake grows longer when it eats food.");
        Console.WriteLine("3. The game ends if the snake runs into the walls or itself.");
        Console.WriteLine("Press 1 to start the game, 0 to exit.");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1)
            {
                PlayGame();
            }
            else if (key == ConsoleKey.D0)
            {
                break;
            }
        }
    }

    void PlayGame()
    {
        GameSpeed = InitialGameSpeed; 
        var snake = new List<Position> { new Position(Width / 2, Height / 2) };
        var direction = Direction.Right;
        var food = GenerateFood(snake);
        var score = 0;

        Console.Clear();
        DrawBorders();
        DrawScore(score); 

        Draw(snake, food);

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                direction = GetDirection(key, direction);
            }

            var head = GetNextPosition(snake.First(), direction);
            if (IsGameOver(head, snake))
            {
                break;
            }

            snake.Insert(0, head);

            if (head.Equals(food))
            {
                food = GenerateFood(snake);
                score++;
                GameSpeed -= 50;
                if (GameSpeed < 100)
                    GameSpeed = 100;
            }
            else
            {
                var tail = snake.Last();
                snake.RemoveAt(snake.Count - 1);
                Console.SetCursorPosition(tail.X, tail.Y);
                Console.Write(EmptyChar);
            }

            Draw(snake, food);
            DrawScore(score);
            Thread.Sleep(GameSpeed);
        }

        Console.SetCursorPosition(0, Height + 3);
        Console.WriteLine($"Game Over! Your score: {score}");
        Console.WriteLine("Press 1 to play again, 0 to exit.");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1)
            {
                PlayGame();
            }
            else if (key == ConsoleKey.D0)
            {
                break;
            }
        }
    }

    void DrawBorders()
    {
        for (int x = 0; x <= Width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write(BorderChar);
            Console.SetCursorPosition(x, Height);
            Console.Write(BorderChar);
        }

        for (int y = 0; y <= Height; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(BorderChar);
            Console.SetCursorPosition(Width, y);
            Console.Write(BorderChar);
        }
    }

    void Draw(List<Position> snake, Position food)
    {
        foreach (var pos in snake)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(SnakeChar);
        }

        Console.SetCursorPosition(food.X, food.Y);
        Console.Write(FoodChar);
    }

    void DrawScore(int score)
    {
        Console.SetCursorPosition(0, Height + 1);
        Console.Write($"Score: {score}".PadRight(Width + 1)); 
    }

    Position GenerateFood(List<Position> snake)
    {
        var random = new Random();
        Position food;

        do
        {
            food = new Position(random.Next(1, Width), random.Next(1, Height));
        } while (snake.Contains(food) || IsBorder(food) || food.Y == 0 || food.Y == Height);

        return food;
    }

    bool IsBorder(Position pos)
    {
        return pos.X == 0 || pos.X == Width || pos.Y == 0 || pos.Y == Height;
    }

    Direction GetDirection(ConsoleKey key, Direction currentDirection)
    {
        return key switch
        {
            ConsoleKey.UpArrow => currentDirection == Direction.Down ? currentDirection : Direction.Up,
            ConsoleKey.DownArrow => currentDirection == Direction.Up ? currentDirection : Direction.Down,
            ConsoleKey.LeftArrow => currentDirection == Direction.Right ? currentDirection : Direction.Left,
            ConsoleKey.RightArrow => currentDirection == Direction.Left ? currentDirection : Direction.Right,
            _ => currentDirection
        };
    }

    Position GetNextPosition(Position current, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Position(current.X, current.Y - 1),
            Direction.Down => new Position(current.X, current.Y + 1),
            Direction.Left => new Position(current.X - 1, current.Y),
            Direction.Right => new Position(current.X + 1, current.Y),
            _ => current
        };
    }

    bool IsGameOver(Position head, List<Position> snake)
    {
        return head.X <= 0 || head.X >= Width || head.Y <= 0 || head.Y >= Height || snake.Contains(head);
    }
}
