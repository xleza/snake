using System;

namespace SnakeGame
{
    internal sealed class Food : Being
    {

        public event EventHandler<Food> Killed = delegate { };

        public Food(Point head) : base(head)
        {
        }

        public override void Move(Point direction)
        {

        }

        public override void Kill()
        {
            base.Kill();
            Killed.Invoke(this, this);
        }
    }
}
