﻿using System;
using System.Collections.Generic;
using System.Drawing;
using AMissão.WinApp.Inimigos;
using AMissão.WinApp.Armas;

namespace AMissão.WinApp
{
    public class Game
    {
        public List<Enemy> Enemies;
        public Weapon WeaponInRoom;
        private Player player;
        public Point PlayerLocation
        {
            get { return player.Location; }
        }
        public int PlayerHitPoints
        {
            get { return player.HitPoints; }
        }
        public List<string> PlayerWeapons
        {
            get { return player.Weapons; }
        }
        private int level = 0;
        public int Level
        {
            get { return level; }
        }
        private Rectangle boundaries;
        public Rectangle Boundaries
        {
            get { return boundaries; }
        }
        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70), boundaries);
        }
        public void Move(Direction direction, Random random)
        {
            player.Move(direction);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }
        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }
        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }
        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }
        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }
        public string GetEquippedWeapon()
        {
            return player.GetEquippedWeapon();
        }
        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }
        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left + random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,
                boundaries.Top + random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        }
        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), boundaries));
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                case 2:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), boundaries));
                    WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;
                case 3:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Zombie(this, GetRandomLocation(random), boundaries));
                    WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;
                case 4:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), boundaries));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), boundaries));
                    if (player.Weapons.Contains("Bow"))
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));                    
                    else
                        WeaponInRoom = new Bow(this, GetRandomLocation(random));

                    break;
                case 5:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), boundaries));
                    Enemies.Add(new Zombie(this, GetRandomLocation(random), boundaries));
                    WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;
                case 6:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), boundaries));
                    Enemies.Add(new Zombie(this, GetRandomLocation(random), boundaries));
                    WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;
                case 7:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), boundaries));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), boundaries));
                    Enemies.Add(new Zombie(this, GetRandomLocation(random), boundaries));
                    if (player.Weapons.Contains("Mace"))
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    else
                        WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;
                case 8:
                    //exit
                    break;
                default:
                    break;
            }
        }
    }
}
