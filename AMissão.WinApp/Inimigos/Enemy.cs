﻿using System;
using System.Drawing;

namespace AMissão.WinApp.Inimigos
{
    public abstract class Enemy : Mover
    {
        private const int NearPlayerDistance = 25;
        private int hitPoints;
        public int HitPoints
        {
            get { return hitPoints; }
        }
        public bool Dead
        {
            get
            {
                if (hitPoints <= 0)
                    return true;

                return false;
            }
        }

        public Enemy(Game game, Point location, Rectangle boundaries, int hitPoints) : base (game, location)
        {
            this.hitPoints = hitPoints;
        }
        public abstract void Move(Random random);
        protected abstract void Attack(Direction direction, Random random);
        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }
        protected bool NearPlayer()
        {
            return (Nearby(game.PlayerLocation, NearPlayerDistance));
        }
        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove;
            if (playerLocation.X > location.X + 10)
                directionToMove = Direction.Right;
            else if (playerLocation.X < location.X - 10)
                directionToMove = Direction.Left;
            else if (playerLocation.Y < location.Y - 10)
                directionToMove = Direction.Up;
            else
                directionToMove = Direction.Down;
            return directionToMove;
        }
    }
}