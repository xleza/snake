using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal sealed class Input
    {
        private readonly Dictionary<ConsoleKey, Point> _directions;
        private ConsoleKey _pressedButton;
        private Point _activeDirection;

        public Input(Point defaultDirection)
        {
            _activeDirection = defaultDirection;
            _directions = new Dictionary<ConsoleKey, Point>
            {
                { ConsoleKey.RightArrow , Direction.Right },
                { ConsoleKey.UpArrow , Direction.Up },
                { ConsoleKey.LeftArrow , Direction.Left },
                { ConsoleKey.DownArrow , Direction.Down }
            };
        }

        public void Scan() => Task.Run(() => _pressedButton = Console.ReadKey(true).Key);
        public bool IsExit() => _pressedButton == ConsoleKey.Escape;

        public Point GetDirection()
        {
            if (_directions.ContainsKey(_pressedButton) && !IsOpposite(_directions[_pressedButton]))
                _activeDirection = _directions[_pressedButton];

            return _activeDirection;
        }

        private bool IsOpposite(Point newDirection) => _activeDirection.X == newDirection.X * -1 && _activeDirection.Y == newDirection.Y * -1;
    }
}
