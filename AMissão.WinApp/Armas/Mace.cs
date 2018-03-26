using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMissão.WinApp.Armas
{
    public class Mace : Weapon
    {
        public Mace(Game game, Point location) : base (game, location)
        {
        }
        public override string Name
        {
            get
            {
                return "Mace";
            }
        }
        public override void Attack(Direction direction, Random random)
        {
            this.DamageEnemy(direction, 20, 6, random);
        }
    }
}
