using System.Threading;

namespace SnakeGame
{
    internal sealed class Game
    {
        private const char FoodSymbol = '*';
        private const char SnakeBodySymbol = 'O';

        private readonly Universe _universe;
        private readonly Output _output;
        private int _score;

        private Game(int universeHeight, int universeWidth, int sleep)
        {
            _universe = new Universe(universeHeight, universeWidth);
            _output = new Output(_universe.Height, _universe.Width);
            _output.ChangeScore(_score);
            var input = new Input(Direction.Right);

            CreateFood();
            var snake = CreateSnake();

            while (true)
            {
                Thread.Sleep(sleep);
                input.Scan();

                if (input.IsExit() || !snake.IsAlive)
                    break;

                _universe.Move(input.GetDirection());
                _output.Draw(snake.Head, SnakeBodySymbol);
            }
        }

        public static void Start(int universeHeight, int universeWidth, Difficulty difficulty) => new Game(universeHeight, universeWidth, 200 / (int)difficulty);

        private Food CreateFood()
        {
            var food = new Food(_universe.GetPositionForNewResident());
            food.Killed += Food_Killed;
            _universe.AddResident(food);
            _output.Draw(food.Head, FoodSymbol);

            return food;
        }

        private Snake CreateSnake()
        {
            var snake = new Snake(
                new Point(10, 10),
                _universe.GetNextPosition,
                _universe.GetResidentAt,
                _output.Clear);

            _universe.AddResident(snake);

            return snake;
        }

        private void Food_Killed(object sender, Food e)
        {
            _universe.RemoveResident(e);
            _output.Clear(e.Head);
            _output.ChangeScore(++_score);
            CreateFood();
        }
    }
}
