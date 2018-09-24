using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munro17603375Task1
{
    abstract class Unit
    {
        protected int x;
        protected int y;
        protected int health;
        protected int speed;
        protected bool attack;
        protected int range;
        protected string faction;
        protected string symbol;
        protected string name;
        #region Constructor
        public Unit(int x,int y, int health, int speed, bool attack, int range, string faction, string symbol,string name)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.range = range;
            this.faction = faction;
            this.symbol = symbol;
            this.name = name;
        }
        #endregion
        //destructor
        ~Unit()
        {

        }
        #region Accessors
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
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public bool Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int Range
        {
            get { return range; }
            set { range = value; }
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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        abstract public void movement(int x,int y);

        abstract public bool attackRange(Unit enemy);

        abstract public Unit closestUnit(List<Unit>u);

        abstract public void combat(Unit enemy);

        abstract public bool isAlive();

        abstract public string toString();

        abstract public void save();
    }
}
