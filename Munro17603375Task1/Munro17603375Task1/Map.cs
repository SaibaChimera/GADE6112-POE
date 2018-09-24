using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Munro17603375Task1
{
    class Map
    {
        Random rnd = new Random();
        int x;
        int y;
        private const int MAX_RANDOM_UNIT = 50;
        public const string FIELD_SYMBOL = ".";
        public int size;
        public List<Unit> unitsOnMap = new List<Unit>();
        public string[,] map = new string[20, 20];
        public string [,] Grid
        {
            get
            {
                return map;
            }
        }
   //Unit tmp = new MeleeUnit(z,y,100,-1.attackOption,1,team,"M")
   //
        public void populateMap()
        {
            size = rnd.Next(25, MAX_RANDOM_UNIT);
            MessageBox.Show(Convert.ToString(size));
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        map[i, j] = ".";
                    }
                }
            for (int j = 0; j <= size; j++)
            {
                placeUnits(j);
            }
            
           
        }
        public void checkHealth()
        {
            for (int i = 0; i < size; i++)
            {
                if (!unitsOnMap[i].isAlive())
                {
                    map[unitsOnMap[i].X, unitsOnMap[i].Y] = ".";
                    unitsOnMap.Remove(unitsOnMap[i]);
                    size--;
                }
            }
        }
        public void placeUnits(int j)
        {
            bool attackOption = false;
            string team ;
            int teampick;
            int typepick;
                do
                {
                    x = rnd.Next(0, 19);
                    y = rnd.Next(0, 19);
                }
                while (map[x, y] != FIELD_SYMBOL);
                teampick = rnd.Next(1, 3);
                typepick = rnd.Next(1, 3);
                if (teampick % 2 == 0)
                {
                    team = "Purple";
                }
                else
                {
                    team = "Yellow";
                }
                if (typepick % 2 == 0)
                {
                    Unit tmp = new MeleeUnit(x, y, 100, -1, attackOption, 1, team, "M");
                    unitsOnMap.Add(tmp);
                map[x, y] = unitsOnMap[j].Symbol;
                }
                else
                {
                    Unit tmp = new RangeUnit(x, y, 100, -1, attackOption, 1, team, "R");
                    unitsOnMap.Add(tmp);
                map[x, y] = unitsOnMap[j].Symbol;
                }
        }
        public void moveUnits(int v, int newX, int newY)
        {
            if ((newX >= 0 && newX < 20) && (newY >= 0 && newY <= 20)) 
            {
                map[unitsOnMap[v].X, unitsOnMap[v].Y] = FIELD_SYMBOL;
                unitsOnMap[v].movement(newX, newY);
                map[unitsOnMap[v].X, unitsOnMap[v].Y] = unitsOnMap[v].Symbol;
            }
        }
        public string status(int x, int y)
        {
            string display = "";
            for (int i = 0; i < unitsOnMap.Count - 1; i++)
            {
                if (unitsOnMap[i].X == x && unitsOnMap[i].Y == y)
                {
                    display = unitsOnMap[i].toString();
                }
            }
            return display;
        }
        public string updateUnits()
        {
            string output = "";
            for (int x = 0; x == 20; x++)
            {
                for (int y = 0; y == 20; y++)
                {
                    output += map[x, y];
                   
                }
                output = Environment.NewLine;
            }
            return output;
        }

    }
}
