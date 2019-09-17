using System.Collections.Generic;

namespace SnakeGame
{
    abstract class Being
    {
        public bool IsAlive { get; private set; }

        public readonly LinkedList<Point> Body;
        public Point Head => Body.First.Value;

        protected Being(Point head)
        {
            Body = new LinkedList<Point>();
            Body.AddFirst(head);
            IsAlive = true;
        }

        public abstract void Move(Point direction);

        public virtual void Kill()
        {
            IsAlive = false;
        }
    }
}
