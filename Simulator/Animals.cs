using Simulator.Maps;

namespace Simulator
{
    public class Animals : IMappable
    {

        private string _description="Unknown";
        private bool canFly=true;

        public string Description
        {
            get => _description;
            init
            {
                _description = Validator.Shortener(value, 3, 15, '#');
            }
        }
        public int Size { get; set; } = 3;
        public virtual string Info => $"{Description} <{Size}>";

        public Map? Map { get; private set; }

        public Point? Position { get; set; }

        public virtual char Symbol => 'A';

        public virtual void Go(Direction direction)
        {
            if (Map == null || Position == null)
                throw new InvalidOperationException("Stwór nie znajduje się na mapie");

            var newPosition = Map.Next(Position.Value, direction);

            if (Map.Exist(newPosition))
            {
                Map.Move(this, Position.Value, newPosition);
                Position = newPosition;
            }
        }


        public void InitMapAndPosition(Map map, Point position)
        {
            if (!map.Exist(position))
                throw new ArgumentOutOfRangeException("Punkt znajduje się poza granicami mapy");

            Map = map;
            Position = position;
            Map.Add(this, position);
        }

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}