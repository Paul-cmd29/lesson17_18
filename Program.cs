using System;
using System.Linq;
using static System.Console;

namespace Lesson17_18
{
    class Program
    {
        private const int MapWidth = 30;
        private const int MapHeigth = 20;

        private const int ScreenWidth = MapWidth * 3;
        private const int ScreenHeigth = MapHeigth * 3;

        private const int Framems = 200;

        private const ConsoleColor BorderColor = ConsoleColor.Yellow;
        private const ConsoleColor HeadColor = ConsoleColor.Blue;
        private const ConsoleColor BodyColor = ConsoleColor.White;


        static void Main(string[] args)
        {
            SetWindowSize(ScreenWidth, ScreenHeigth);
            SetBufferSize(ScreenWidth, ScreenHeigth);
            CursorVisible = false;

            DrawBorder();
            Direction currentMovement = Direction.Right;

            var snake = new Snake(initialX: 10, initialY: 5, HeadColor, BodyColor);
            Stopwatch sw = new Stopwatch();

            while (true)
            {
                sw.Restart();
                Direction OldDir = currentMovement;
                while (sw.ElapsedMilisecond <= Framems)
                {
                    if (currentMovement == OldDir)
                    {
                        currentMovement = ReadMovement(currentMovement);

                    }

                }
                snake.Move(currentMovement);

                if (snake.Head.X == MapWidth - 1
                    || snake.Head.X == 0
                    || snake.Head.Y == MapHeight - 1
                    || snake.Head.Y == 0
                    || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                    break;


            }
            snake.Clear();
            SetCursorPosition(ScreenHeigth / 3, ScreenHeigth / 2);
            Console.WriteLine("Game Over!");

            ReadKey();
            static Direction ReadMovement(Direction currentDirection)
            {
                if (!KeyAvailable)
                    return currentDirection;
                ConsoleKey key = ReadKey(true).Key;

                currentDirection = key switch
                {
                    ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                    ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                    ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                    ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                    _ => currentDirection
                };
                return currentDirection;
            }

            static void DrawBorder()
            {
                for (int i = 0; i < MapWidth; i++)
                {
                    new Pixel(x: i, y: 0, BorderColor).Draw();
                    new Pixel(x: i, y: MapHeigth - 1, BorderColor).Draw();
                }

                for (int i = 0; i < MapHeigth; i++)
                {
                    new Pixel(x: i, y: 0, BorderColor).Draw();
                    new Pixel(x: MapWidth - 1, y: i, BorderColor).Draw();
                }
            }
        }
    }
}
//checked
