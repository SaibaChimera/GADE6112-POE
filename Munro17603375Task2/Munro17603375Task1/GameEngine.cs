using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Munro17603375Task1
{
    class GameEngine
    {
        Map m = new Map();
        
        public void conditions(int v)
        {
            try
            {
                Random rnd = new Random();
                int newX = m.unitsOnMap[v].X;
                int newY = m.unitsOnMap[v].Y;
                Unit closestUnit = m.unitsOnMap[v].closestUnit(m.unitsOnMap);
                m.checkHealth();
                if (m.unitsOnMap[v].attackRange(closestUnit))
                {
                    m.unitsOnMap[v].combat(closestUnit);
                    m.checkHealth();
                    closestUnit = m.unitsOnMap[v].closestUnit(m.unitsOnMap);
                }
                if (m.unitsOnMap[v].Health < 25)
                {
                    m.unitsOnMap[v].movement(m.unitsOnMap[v].X, m.unitsOnMap[v].Y);
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
                if (m.structuresOnMap[0].isDestroyed() == false)
                {
                    m.map[m.structuresOnMap[0].X, m.structuresOnMap[0].Y] = ".";
                    m.structuresOnMap.Remove(m.structuresOnMap[0]);
                }
                if (m.structuresOnMap[1].isDestroyed() == false)
                {
                    m.map[m.structuresOnMap[1].X, m.structuresOnMap[1].Y] = ".";
                    m.structuresOnMap.Remove(m.structuresOnMap[1]);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {

            }
        }
        public void spawnInterval(int tick)
        {
            m.placeUnits(tick);
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
            int size = m.count;
           return size;
        }
        public string display(int x, int y)
        {
            return m.status(x, y);
        }
        public void save()
        {
            m.saveLists();
        }
        public void read()
        {
            m.readFile();
        }
    }
}
