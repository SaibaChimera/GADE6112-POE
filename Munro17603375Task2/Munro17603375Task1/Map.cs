using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Munro17603375Task1
{
    class Map
    {
        Random rnd = new Random();
        private const int MAX_RANDOM_UNIT = 50;
        public const string FIELD_SYMBOL = ".";
        public int count = 0;
        public int size;
        public List<Unit> unitsOnMap = new List<Unit>();
        public List<FactoryBuilding> structuresOnMap = new List<FactoryBuilding>();
        public List<ResourceBuilding> resourcesOnMap = new List<ResourceBuilding>();
        public string[,] map = new string[20, 20];
        public string [,] Grid
        {
            get
            {
                return map;
            }
        }
        public void populateMap()
        {
            size = rnd.Next(25, MAX_RANDOM_UNIT);
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        map[i, j] = ".";
                    }
                }
            FactoryBuilding tempPurple = new FactoryBuilding(19,19,500,"Purple","P",18,18,2,size);
            structuresOnMap.Add(tempPurple);
            map[19, 19] = structuresOnMap[0].Symbol;
            FactoryBuilding tempYellow = new FactoryBuilding(0, 0, 500, "Yellow", "Y", 1, 1, 2, size);
            structuresOnMap.Add(tempYellow);
            map[0, 0] = structuresOnMap[1].Symbol;
            ResourceBuilding teamPurple = new ResourceBuilding(18, 19, 200, "Purple", "$", "Gold", 2, 1000);
            resourcesOnMap.Add(teamPurple);
            map[18, 19] = resourcesOnMap[0].Symbol;
            ResourceBuilding teamYellow = new ResourceBuilding(0, 1, 200, "Yellow", "$", "Gold", 2, 1000);
            resourcesOnMap.Add(teamYellow);
            map[0, 1] = resourcesOnMap[1].Symbol;
        }
        public void placeUnits(int tick)
        {
            Unit tmp = null;
            if (tick % structuresOnMap[0].TickPerProduction == 0)
            {
                tmp = structuresOnMap[0].spawnUnits(tick);
                if (tmp != null)
                {
                    unitsOnMap.Add(tmp);
                    map[structuresOnMap[0].SpawnPointX, structuresOnMap[0].SpawnPointY] = unitsOnMap[count].Symbol;
                    count++;
                }
            }
            if (tick % structuresOnMap[1].TickPerProduction == 0)
            {
                tmp = structuresOnMap[1].spawnUnits(tick);
                if (tmp != null)
                {
                    unitsOnMap.Add(tmp);
                    map[structuresOnMap[1].SpawnPointX, structuresOnMap[1].SpawnPointY] = unitsOnMap[count].Symbol;
                    count++;
                }
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
        public void saveLists()
        {
            structuresOnMap[0].save();
            structuresOnMap[1].save();
            resourcesOnMap[0].save();
            resourcesOnMap[1].save();
            for (int v = 0; v < count; v++)
            {
                unitsOnMap[v].save();
            }
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
        public void checkHealth()
        {
            for (int i = 0; i < count; i++)
            {
                if (!unitsOnMap[i].isAlive())
                {
                    map[unitsOnMap[i].X, unitsOnMap[i].Y] = ".";
                    unitsOnMap.Remove(unitsOnMap[i]);
                    count--;
                }
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
            for (int i = 0; i < structuresOnMap.Count - 1; i++)
            {
                if (structuresOnMap[i].X == x && structuresOnMap[i].Y == y)
                {
                    display = structuresOnMap[i].toString();
                }
            }
            for (int i = 0; i < resourcesOnMap.Count - 1; i++)
            {
                if (resourcesOnMap[i].X == x && resourcesOnMap[i].Y == y)
                {
                    display = resourcesOnMap[i].toString();
                }
            }
            return display;
        }
        public void readFile()
        {
            FileStream inFile = null;
            StreamReader reader = null;
            string input;
            int x;
            int y;
            int health;
            int speed;
            bool attack;
            int range;
            string faction;
            string symbol;
            string name;
            Unit tmp = null;
            FactoryBuilding temp = null;
            ResourceBuilding temporary = null;
            try
            {
                inFile = new FileStream(@"Files\Units.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();
                while (input != null)
                {
                    x = Convert.ToInt32(input);
                    y = Convert.ToInt32(reader.ReadLine());
                    health = Convert.ToInt32(reader.ReadLine());
                    speed = Convert.ToInt32(reader.ReadLine());
                    attack = Convert.ToBoolean(reader.ReadLine());
                    range = Convert.ToInt32(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    name = reader.ReadLine();
                    if (symbol == "M")
                        tmp = new MeleeUnit(x, y, health, speed, attack, range, faction, symbol, name);
                    else
                        tmp = new RangeUnit(x, y, health, speed, attack, range, faction, symbol, name);
                    unitsOnMap.Add(tmp);
                    map[x, y] = symbol;
                    input = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();

                }
            }
            int spawnPointX;
            int spawnPointY;
            int tickPerProduction;
            int unitsToProduce;
            try
            {
                inFile = new FileStream(@"Files\Structures.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();
                while (input != null)
                {
                    x = Convert.ToInt32(input);
                    y = Convert.ToInt32(reader.ReadLine());
                    health = Convert.ToInt32(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    spawnPointX = Convert.ToInt32(reader.ReadLine());
                    spawnPointY = Convert.ToInt32(reader.ReadLine());
                    tickPerProduction = Convert.ToInt32(reader.ReadLine());
                    unitsToProduce = Convert.ToInt32(reader.ReadLine());
                    temp = new FactoryBuilding(x, y, health, faction, symbol, spawnPointX, spawnPointY, tickPerProduction, unitsToProduce);
                    structuresOnMap.Add(temp);
                    map[x, y] = symbol;
                    input = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();

                }
            }
            string typeOfResource;
            int resourcesPerTick;
            int resourcesRemaining;
            try
            {
                inFile = new FileStream(@"Files\Resources.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                input = reader.ReadLine();
                while (input != null)
                {
                    x = Convert.ToInt32(input);
                    y = Convert.ToInt32(reader.ReadLine());
                    health = Convert.ToInt32(reader.ReadLine());
                    faction = reader.ReadLine();
                    symbol = reader.ReadLine();
                    typeOfResource = reader.ReadLine();
                    resourcesPerTick = Convert.ToInt32(reader.ReadLine());
                    resourcesRemaining = Convert.ToInt32(reader.ReadLine());
                    temporary = new ResourceBuilding(x, y, health, faction, symbol, typeOfResource, resourcesPerTick, resourcesRemaining);
                    resourcesOnMap.Add(temporary);
                    map[x, y] = symbol;
                    input = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                if (inFile != null)
                {
                    reader.Close();
                    inFile.Close();

                }
            }
        }
    }
}
