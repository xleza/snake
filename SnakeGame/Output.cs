using System;

namespace SnakeGame
{
    internal class Output
    {
        private readonly int _height;
        private readonly int _width;

        public Output(int height, int width)
        {
            _height = height;
            _width = width;

            Console.CursorVisible = false;

            Console.Write("╔");
            Console.SetCursorPosition(width, 0);
            Console.Write("╗");
            for (var i = 1; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("═");
                Console.SetCursorPosition(i, height);
                Console.Write("═");
            }

            Console.SetCursorPosition(0, height);
            Console.Write("╚");
            Console.SetCursorPosition(width, height);
            Console.Write("╝");

            for (var i = 1; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
                Console.SetCursorPosition(width, i);
                Console.Write("║");
            }
        }

        public void Draw(Point point, char symbol)
        {
            if (OnEdge())
                return;

            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(symbol);

            bool OnEdge() => point.X == 0 || point.Y == 0 || point.X == _width || point.Y == _height;
        }
        public void Clear(Point point) => Draw(point, ' ');
        public void ChangeScore(int score)
        {
            Console.SetCursorPosition(_width + 10, 0);
            Console.Write($"SCORE: {score}");
        }
    }
}
