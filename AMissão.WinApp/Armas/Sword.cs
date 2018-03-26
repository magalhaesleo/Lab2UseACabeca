using System;
using System.Drawing;

namespace AMissão.WinApp.Armas
{
    public class Sword : Weapon
    {
        public Sword(Game game, Point location) : base (game, location)
        {
        }
        public override string Name
        {
            get
            {
                return "Sword";
            }
        }
        public override void Attack(Direction direction, Random random)
        {
            this.DamageEnemy(direction, 10, 3, random);
        }
    }
}