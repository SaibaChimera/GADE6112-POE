using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace MyRTSGame
{
    class Tower : Building
    {
        const int DAMAGE = 10;
        private bool attack;
        private int range;
        public Tower(int x, int y, int health, string faction, string symbol, bool attack, int range)
        : base(x, y, health, faction, symbol)
        {
            this.attack = attack;
            this.range = range;
        }
        public Unit closestUnit(List<Unit> list)
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
        public void combat(Unit enemy)
        {
            enemy.Health = enemy.Health - DAMAGE;
        }
        public bool attackRange(Unit enemy)
        {
            if (Math.Abs(this.X - enemy.X) <= this.range || (Math.Abs(this.Y - enemy.Y) <= this.range))
                return true;

            return false;
        }
        public override string toString()
        {
            string output = "";
            output += "x: " + X + Environment.NewLine;
            output += "y: " + Y + Environment.NewLine;
            output += "Health: " + Health + Environment.NewLine;
            output += "Faction: " + Faction + Environment.NewLine;
            output += "Symbol" + Symbol + Environment.NewLine;
            return output;
        }
        override public bool isDestroyed()
        {
            if (health <= 0)
                return false;
            else
                return true;
        }
        
    }
}
