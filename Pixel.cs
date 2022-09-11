using System;
namespace Lesson17_18
{
    public readonly struct Pixel
    {
        private const char PixelChar = '█';
        public Pixel(int x, int y, ConsoleColor color, int pixelSize = 3)
        {
            X = x;
            Y = y;
            Color = color;
            PixelSize = pixelSize;
        }
        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }
        public int PixelSize { get; }

        public void Draw()
        {
            Console.ForegroundColor = Color; 
            for (int x = 0; x < PixelSize; x++)
            {
                Console.SetCursorPosition(left: X * PixelSize + x, top: Y * PixelSize + Y);
                Console.Write(PixelChar);


            }
        }
        public void Clear()
        {
            Console.SetCursorPosition(left: X, top: Y);
            Console.Write(' ');
        }
    }
}

