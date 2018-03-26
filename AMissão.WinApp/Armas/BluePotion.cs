using System;
using System.Drawing;

namespace AMissão.WinApp.Armas
{
    public class BluePotion : Weapon, IPotion
    {
        private bool used = false;
        public BluePotion(Game game, Point location) : base(game, location)
        {
        }
        public override string Name
        {
            get
            {
                return "BluePotion";
            }
        }
        
        public bool Used
        {
            get
            {
                return used;
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            if (!used)
            {
                this.game.IncreasePlayerHealth(5, random);
                used = true;
            }
        }
    }
}