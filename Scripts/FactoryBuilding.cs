using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace MyRTSGame
{
    class FactoryBuilding : Building
    {
        private int spawnPointX;
        private int spawnPointY;
        private int tickPerProduction;
        private int unitsToProduce;
        public List<Unit> unitsOnMap = new List<Unit>();
        public FactoryBuilding(int x, int y, int health, string faction, string symbol,int spawnPointX, int spawnPointY, int tickPerProduction, int unitsToProduce)
    : base(x, y, health, faction, symbol)
        {
            this.spawnPointX = spawnPointX;
            this.spawnPointY = spawnPointY;
            this.tickPerProduction = tickPerProduction;
            this.unitsToProduce = unitsToProduce;
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
        public int UnitsToProduce
        {
            get { return unitsToProduce; }
            set { unitsToProduce = value; }
        }
        override public bool isDestroyed()
        {
            if (health <= 0)
                return false;
            else
                return true;
        }
        public Unit spawnUnits(int currentTick)
        {
            Random rnd = new Random();
            Unit tmp = null;
            int typepick;
            typepick = rnd.Next(1, 3);
            bool attackOption = (rnd.Next(1, 3) % 2 == 0 ? true : false);
            if (unitsToProduce > 0)
            {
                if (currentTick % tickPerProduction == 0)
                {
                    if (typepick % 2 == 0)
                    {
                        tmp = new MeleeUnit(spawnPointX, spawnPointY, 100, -1, attackOption, 1, faction, "M", "Hunter");
                    }
                    else
                    {
                        tmp = new RangeUnit(spawnPointX, spawnPointY, 100, -1, attackOption, 1, faction, "R", "Ranger");
                    }
                }
                unitsToProduce -= 1;
            }
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
    }
}
