using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munro17603375Task1
{
    abstract class Building
    {
        protected int x;
        protected int y;
        protected int health;
        protected string faction;
        protected string symbol;
        #region Constructor
        public Building(int x, int y, int health, string faction, string symbol)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.faction = faction;
            this.symbol = symbol;
        }
        #endregion
        #region Accessor
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public string Faction
        {
            get { return faction; }
            set { faction = value; }
        }
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        #endregion
        abstract public bool isDestroyed();
        abstract public string toString();
        abstract public void save();
    }
}
