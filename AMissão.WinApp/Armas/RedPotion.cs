using System;
using System.Drawing;

namespace AMissão.WinApp.Armas
{
    public class RedPotion : Weapon, IPotion
    {
        private bool used = false;
        public RedPotion(Game game, Point location) : base(game, location)
        {
        }
        public override string Name
        {
            get
            {
                return "RedPotion";
            }
        }
        public override void Attack(Direction direction, Random random)
        {
            if (!used)
            {
                this.game.IncreasePlayerHealth(10, random);
                used = true;
            }
        }        
        public bool Used
        {
            get
            {
                return used;
            }
        }
    }
}
