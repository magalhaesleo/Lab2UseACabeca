using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMissão.WinApp.Inimigos
{
    public class Ghost : Enemy
    {
        public Ghost(Game game, Point location, Rectangle boundaries) : base (game, location,boundaries, 8)
        {
        }
        public override void Move(Random random)
        {
            Direction dir = FindPlayerDirection(game.PlayerLocation);

            if (random.Next(0, 3) == 0)
            {                
                this.location = Move(dir, game.Boundaries);
            }

            if (NearPlayer())
            {
                Attack(FindPlayerDirection(game.PlayerLocation), random);
            }
        }

        protected override void Attack(Direction direction, Random random)
        {
            game.HitPlayer(3, random);
        }
    }
}
