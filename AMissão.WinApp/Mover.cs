using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMissão.WinApp
{
    public abstract class Mover
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location
        {
            get { return location; }
        }
        protected Game game;
        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }
        public bool Nearby(Point location, Point target, int radius)
        {
            if (Math.Abs(location.X - target.X) < radius &&
                (Math.Abs(location.Y - target.Y) < radius))
            {
                return true;
            }
            return false;
        }
        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(location.X - locationToCheck.X) < distance &&
                (Math.Abs(location.Y - locationToCheck.Y) < distance))
            {
                return true;
            }
            return false;
        }
        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            Point newLocation = target;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y -= MoveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= boundaries.Bottom)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                        newLocation.X += MoveInterval;
                    break;
                default:
                    break;
            }
            return newLocation;
        }

        public Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = location;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y -= MoveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= boundaries.Bottom)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                        newLocation.X += MoveInterval;
                    break;
                default:
                    break;
            }
            return newLocation;
        }

    }
}
