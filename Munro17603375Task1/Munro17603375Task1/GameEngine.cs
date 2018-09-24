using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munro17603375Task1
{
    class GameEngine
    {
        Map m = new Map();
        
        public void conditions(int v)
        {
            Random rnd = new Random();
            int newX = m.unitsOnMap[v].X;
            int newY = m.unitsOnMap[v].Y;
            Unit closestUnit = m.unitsOnMap[v].closestUnit(m.unitsOnMap);
            if (m.unitsOnMap[v].Health < 25) 
            {
                m.unitsOnMap[v].movement(m.unitsOnMap[v].X, m.unitsOnMap[v].Y);
            }
            else if ((m.unitsOnMap[v].attackRange(m.unitsOnMap[v]) == true))
            {
                m.unitsOnMap[v].combat(closestUnit);
            }
            if ((m.unitsOnMap[v].Y < closestUnit.Y))
                {
                    if (m.map[newX, newY + 1] == ".")
                    {
                        m.moveUnits(v, newX, newY + 1);
                    }
                }
                if ((m.unitsOnMap[v].Y > closestUnit.Y))
                {
                    if (m.map[newX, newY - 1] == ".")
                    {
                        m.moveUnits(v, newX, newY - 1);
                    }
                }
                if ((m.unitsOnMap[v].X < closestUnit.X))
                {
                    if (m.map[newX + 1, newY] == ".")
                    {
                        m.moveUnits(v, newX + 1, newY);
                    }
                }
                if ((m.unitsOnMap[v].X > closestUnit.X))
                {
                    if (m.map[newX - 1, newY] == ".")
                    {
                        m.moveUnits(v, newX - 1, newY);
                    }
                }
        }
        public string display(int x, int y)
        {
            return m.status(x, y);
        }
        public void draw()
        {
            m.populateMap();
        }
        public string mapPopulate(int x, int y)
        {
            string location = m.map[x,y];
            return location;
        }
        public void updateMap()
        { 
                m.updateUnits();   
        }
        public int size()
        {
            int size = m.size;
           return size;
        }
    }
}
