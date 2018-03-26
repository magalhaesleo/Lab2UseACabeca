using System;
using System.Drawing;

namespace AMissão.WinApp.Inimigos
{
    public class Bat : Enemy
    {
        public Bat(Game game, Point location, Rectangle boundaries) : base(game, location, boundaries, 6)
        {}
        public override void Move(Random random)
        {
            Direction dir = FindPlayerDirection(game.PlayerLocation);

            if (random.Next(0, 2) == 0)
            {
                Array arrayDirection = Enum.GetValues(typeof(Direction));
                dir = (Direction)arrayDirection.GetValue(random.Next(arrayDirection.Length));
            }

            this.location = Move(dir, game.Boundaries);
            
            if(NearPlayer())
            {
                Attack(FindPlayerDirection(game.PlayerLocation), random);
            }
        }

        protected override void Attack(Direction direction, Random random)
        {
            game.HitPlayer(2, random);
        }
    }
}