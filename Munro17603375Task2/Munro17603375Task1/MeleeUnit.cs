using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Munro17603375Task1
{
    class MeleeUnit : Unit
    {
        private const int DAMAGE = 5;
        public MeleeUnit(int x, int y, int health, int speed, bool attack, int range, string faction, string symbol, string name)
              : base(x, y, health, speed, attack, range, faction, symbol, name)
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

        public override void movement(int x,int y)
        {
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
        public override string toString()
        {
            string output ="";
            output += "Name: ";
            output += "x: " + X + Environment.NewLine;
            output += "y: " + Y + Environment.NewLine;
            output += "Health: " + Health + Environment.NewLine;
            output += "Speed: " + Speed + Environment.NewLine;
            output += "Attack: " + (Attack? "Yes":"No") + Environment.NewLine;
            output += "Attack Range: " + Range + Environment.NewLine;
            output += "Faction: " + Faction + Environment.NewLine;
            output += "Symbol: " + Symbol + Environment.NewLine;
            output += "Name: " + Environment.NewLine;
            return output;
        }
        public override void save()
        {
            FileStream outFile = null;
            StreamWriter units = null;

            try
            {
                outFile = new FileStream(@"Files\Units.txt", FileMode.Append,FileAccess.Write);
                units = new StreamWriter(outFile);
                units.WriteLine(x);
                units.WriteLine(y);
                units.WriteLine(health);
                units.WriteLine(speed);
                units.WriteLine(attack);
                units.WriteLine(range);
                units.WriteLine(faction);
                units.WriteLine(symbol);
                units.WriteLine(name);
                units.Close();
                outFile.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
               if (outFile != null)
                {
                    units.Close();
                    outFile.Close();
                }
            }
        }
    }
}
