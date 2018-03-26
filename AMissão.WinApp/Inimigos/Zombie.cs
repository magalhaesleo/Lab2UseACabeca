using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMissão.WinApp.Inimigos
{
    public class Zombie : Enemy
    {
        public Zombie(Game game, Point location, Rectangle boundaries) : base (game, location, boundaries, 10)
        {
        }
        public override void Move(Random random)
        {
            Direction dir = FindPlayerDirection(game.PlayerLocation);
            int probability = random.Next(0, 3);
            if (probability == 0 || probability == 1)
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
            game.HitPlayer(4, random);
        }
    }
}
