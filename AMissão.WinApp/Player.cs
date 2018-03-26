using System;
using System.Collections.Generic;
using System.Drawing;
using AMissão.WinApp.Armas;

namespace AMissão.WinApp
{
    public class Player : Mover
    {
        private Weapon equippedWeapon;
        private int hitPoints;
        public int HitPoints
        {
            get { return hitPoints; }
        }
        private List<Weapon> inventory = new List<Weapon>();
        public List<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }

        public Player(Game game, Point location, Rectangle boundaries) : base (game, location)
        {
            hitPoints = 10;
        }
        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            hitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                if (Nearby(location, game.WeaponInRoom.Location, 2))
                    inventory.Add(game.WeaponInRoom.PickUpWeapon());
            }
        }

        public void Attack(Direction direction, Random random)
        {
            if (equippedWeapon != null)
            {
                equippedWeapon.Attack(direction, random);
            }
        }
        public string GetEquippedWeapon()
        {
            return equippedWeapon.Name;
        }
    }
}