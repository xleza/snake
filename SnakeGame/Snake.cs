using System;

namespace SnakeGame
{
    internal sealed class Snake : Being
    {
        private readonly Func<Point, Point, Point> _getNextPosition;
        private readonly Func<Point, Being> _getResidentAt;
        private readonly Action<Point> _clear;
        private int _length = 1;

        public Snake(
            Point head,
            Func<Point, Point, Point> getNextPosition,
            Func<Point, Being> getResidentAt,
            Action<Point> clear) : base(head)
        {
            _getNextPosition = getNextPosition;
            _getResidentAt = getResidentAt;
            _clear = clear;
        }

        private void Grow() => _length++;

        public override void Move(Point direction)
        {
            var nextPosition = _getNextPosition(Head, direction);
            var existing = _getResidentAt(nextPosition);
            if (existing != null)
            {
                existing.Kill();
                Grow();
            }

            Body.AddFirst(nextPosition);

            while (Body.Count > _length)
            {
                _clear(Body.Last.Value);
                Body.RemoveLast();
            }
        }
    }
}
