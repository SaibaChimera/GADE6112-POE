using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Munro17603375Task1
{
    class NeutralCamp : Building
    {
        private int spawnPointX;
        private int spawnPointY;
        private int tickPerProduction;
        public NeutralCamp(int x, int y, int health, string faction, string symbol, int spawnPointX, int spawnPointY, int tickPerProduction)
        : base(x, y, health, faction, symbol)
        {
            this.spawnPointX = spawnPointX;
            this.spawnPointY = spawnPointY;
            this.tickPerProduction = tickPerProduction;
        }
        public int SpawnPointX
        {
            get { return spawnPointX; }
            set { spawnPointX = value; }
        }
        public int SpawnPointY
        {
            get { return spawnPointY; }
            set { spawnPointY = value; }
        }
        public int TickPerProduction
        {
            get { return tickPerProduction; }
            set { tickPerProduction = value; }
        }
        public Unit spawnUnits()
        {
            Random rnd = new Random();
            Unit tmp = null;
            bool attackOption = (rnd.Next(1, 3) % 2 == 0 ? true : false);
            tmp = new NeutralCreep(spawnPointX, spawnPointY, 100, -1, attackOption, 1, faction, "W", "Wolf", spawnPointX - 3, spawnPointX + 3, spawnPointY - 3, spawnPointY + 3);
            return tmp;
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
        public override void save()
        { 
            FileStream outFile = null;
            StreamWriter structure = null;
            try
            {
                outFile = new FileStream(@"Files\StructuresCamps.txt", FileMode.Append, FileAccess.Write);
                structure = new StreamWriter(outFile);
                structure.WriteLine(X);
                structure.WriteLine(Y);
                structure.WriteLine(Health);
                structure.WriteLine(Faction);
                structure.WriteLine(Symbol);
                structure.WriteLine(spawnPointX);
                structure.WriteLine(spawnPointY);
                structure.Close();
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
                    structure.Close();
                    outFile.Close();
                }
            }
        }
    }
}
