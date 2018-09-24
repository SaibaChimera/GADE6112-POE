using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munro17603375Task1
{
    class RangeUnit : Unit
    {
        const int DAMAGE = 2;
        public RangeUnit(int x, int y, int health, int speed, bool attack, int range, string faction, string symbol)
      : base(x, y, health, speed, attack, range, faction, symbol)
        {

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
            if (x >= 0 && x < 20)
                X = x;
            if (y >= 0 && y < 20)
                Y = y;
        }
        public override bool attackRange(Unit enemy)
        {
            if (this.Faction.Equals(enemy.Faction))
            {
                if (Math.Abs(this.X - enemy.X) <= this.Range || (Math.Abs(this.Y - enemy.Y) <= this.Range))
                    return true;
            }
            return false;
        }
        public override Unit closestUnit(List<Unit> list)
        {
            double AOE;
            Unit closest = null;
            int attackRangeX, attackRangeY;
            int shortestRange = 1000;
            foreach (Unit u in list)
            {
                attackRangeX = Math.Abs(this.X - u.X);
                attackRangeY = Math.Abs(this.Y - u.Y);
                 AOE = Math.Sqrt(Math.Pow(attackRangeX, 2) + Math.Pow(attackRangeY, 2));
                if (attackRangeX < shortestRange)
                {
                    shortestRange = attackRangeX;
                    closest = u;
                }
                if (attackRangeY < shortestRange)
                {
                    shortestRange = attackRangeY;
                    closest = u;
                }

            }
            return closest;
        }
        public override void combat(Unit enemy)
        {
            if (this.attackRange(enemy))
            {
                enemy.Health -= DAMAGE;
            }
        }
        public override string toString()
        {
            string output = "";
            output += "x: " + X + Environment.NewLine;
            output += "y: " + Y + Environment.NewLine;
            output += "Health: " + Health + Environment.NewLine;
            output += "Speed: " + Speed + Environment.NewLine;
            output += "Attack: " + (Attack ? "Yes" : "No") + Environment.NewLine;
            output += "Attack Range: " + Range + Environment.NewLine;
            output += "Faction: " + Faction + Environment.NewLine;
            output += "Symbol" + Symbol + Environment.NewLine;
            return output;
        }
    }
}
