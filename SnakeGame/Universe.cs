using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    internal class Universe
    {
        public int Height { get; }
        public int Width { get; }

        private readonly List<Being> _residents;

        public Universe(int height, int width)
        {
            Height = height;
            Width = width;

            _residents = new List<Being>();
        }

        public void AddResident(Being resident) => _residents.Add(resident);
        public void RemoveResident(Being resident) => _residents.Remove(resident);

        public Point GetNextPosition(Point currentPosition, Point direction)
        {
            var x = (currentPosition.X + direction.X) % Width;
            var y = (currentPosition.Y + direction.Y) % Height;

            return new Point(x >= 0 ? x : Width, y > 0 ? y : Height);
        }

        public Being GetResidentAt(Point point) => _residents.FirstOrDefault(x => x.Body.Contains(point));

        public void Move(Point direction)
        {
            for (var i = 0; i < _residents.Count; i++)
            {
                _residents[i].Move(direction);
            }
        }

        public Point GetPositionForNewResident()
        {
            while (true)
            {
                var random = new Random();
                var point = new Point(random.Next(1, Width - 1), random.Next(1, Height - 1));
                if (GetResidentAt(point) != null) continue;

                return point;
            }
        }
    }
}
