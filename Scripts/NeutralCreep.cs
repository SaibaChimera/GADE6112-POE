﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace MyRTSGame
{
    class NeutralCreep : Unit
    {
        private int minXBoundary;
        private int maxXBoundary;
        private int minYBoundary;
        private int maxYBoundary;
        private const int DAMAGE = 7;
        public NeutralCreep(int x, int y, int health, int speed, bool attack, int range, string faction, string symbol, string name, int minXBoundary,int maxXBoundary, int minYBoundary, int maxYBoundary)
              : base(x, y, health, speed, attack, range, faction, symbol, name)
        {
            this.minXBoundary = minXBoundary;
            this.maxXBoundary = maxXBoundary;
            this.minYBoundary = minYBoundary;
            this.maxYBoundary = maxYBoundary;
        }

        public override bool isAlive()
        {
            if (Health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void movement(int x, int y)
        {
            if (x < minXBoundary)
                X = x;
            if (y < minYBoundary)
                Y = y;
            if (x > maxXBoundary)
                X = x;
            if (y > maxYBoundary)
                Y = y;
            if (x >= 0 && x < 20)
                X = x;
            if (y >= 0 && y < 20)
                Y = y;
        }
        public override bool attackRange(Unit enemy)
        {
            if (Math.Abs(this.X - enemy.X) <= this.Range || (Math.Abs(this.Y - enemy.Y) <= this.Range))
                return true;

            return false;
        }
        public override Unit closestUnit(List<Unit> list)
        {
            Unit closest = null;
            int attackRangeX, attackRangeY;
            double shortestRange = 1000;
            double AOE;
            foreach (Unit u in list)
            {
                attackRangeX = Math.Abs(this.X - u.X);
                attackRangeY = Math.Abs(this.Y - u.Y);

                AOE = Math.Sqrt(Math.Pow(attackRangeX, 2) + Math.Pow(attackRangeY, 2));

                if (attackRangeX < shortestRange && u.Faction != faction)
                {
                    shortestRange = attackRangeX;
                    closest = u;
                }
                if (attackRangeY < shortestRange && u.Faction != faction)
                {
                    shortestRange = attackRangeY;
                    closest = u;
                }
            }
            return closest;
        }
        public override void combat(Unit enemy)
        {
            enemy.Health = enemy.Health - DAMAGE;
        }
        public override bool attackRangeBuilding(FactoryBuilding enemy)
        {
            if (Math.Abs(this.X - enemy.X) <= this.Range || (Math.Abs(this.Y - enemy.Y) <= this.Range))
                return true;

            return false;
        }
        public override void combatBuilding(FactoryBuilding enemy)
        {
            enemy.Health = enemy.Health - DAMAGE;
        }
        public override string toString()
        {
            string output = "";
            output += "Name: ";
            output += "x: " + X + Environment.NewLine;
            output += "y: " + Y + Environment.NewLine;
            output += "Health: " + Health + Environment.NewLine;
            output += "Speed: " + Speed + Environment.NewLine;
            output += "Attack: " + (Attack ? "Yes" : "No") + Environment.NewLine;
            output += "Attack Range: " + Range + Environment.NewLine;
            output += "Faction: " + Faction + Environment.NewLine;
            output += "Symbol: " + Symbol + Environment.NewLine;
            output += "Name: " + Name +Environment.NewLine;
            return output;
        }
        
    }
}
