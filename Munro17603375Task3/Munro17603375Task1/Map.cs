﻿using System;
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
        public int moneyPurple = 0;
        public int moneyYellow = 0;
        public List<Unit> unitsOnMap = new List<Unit>();
        public List<FactoryBuilding> structuresOnMap = new List<FactoryBuilding>();
        public List<ResourceBuilding> resourcesOnMap = new List<ResourceBuilding>();
        public List<NeutralCamp> neutralCamps = new List<NeutralCamp>();
        public List<Tower> towers = new List<Tower>();
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
            NeutralCamp camp0 = new NeutralCamp(10, 19, 100, "Neutral", "N", 10, 18, 10);
            neutralCamps.Add(camp0);
            map[10, 19] = neutralCamps[0].Symbol;
            NeutralCamp camp1 = new NeutralCamp(0, 19, 100, "Neutral", "N", 0, 18, 10);
            neutralCamps.Add(camp1);
            map[0, 19] = neutralCamps[0].Symbol;
            NeutralCamp camp2 = new NeutralCamp(19, 0, 100, "Neutral", "N", 19, 1, 10);
            neutralCamps.Add(camp2);
            map[19, 0] = neutralCamps[0].Symbol;
            NeutralCamp camp3 = new NeutralCamp(19, 10, 100, "Neutral", "N", 19, 9, 10);
            neutralCamps.Add(camp3);
            map[19, 10] = neutralCamps[0].Symbol;
            Tower purpleTower = new Tower(17, 17, 100, "Purple", "T", true, 5);
            towers.Add(purpleTower);
            map[17, 17] = towers[0].Symbol;
            Tower yellowTower = new Tower(2, 2, 100, "Yellow", "T", true, 5);
            towers.Add(purpleTower);
            map[2, 2] = towers[1].Symbol;
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
            for (int i = 0; i < neutralCamps.Count; i++) 
            {
                if (tick%neutralCamps[i].TickPerProduction == 0)
                {
                    tmp = neutralCamps[i].spawnUnits();
                    if (tmp != null)
                    {
                        unitsOnMap.Add(tmp);
                        map[neutralCamps[i].SpawnPointX, neutralCamps[i].SpawnPointY] = unitsOnMap[count].Symbol;
                        count++;
                    }
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
        public void generateMoney()
        {
            resourcesOnMap[0].collect(moneyPurple);
            resourcesOnMap[1].collect(moneyYellow);
        }
        public void buyHealth()
        {
            if (moneyPurple >= 100)
            {
                moneyPurple -= 100;
                for (int i = 0; i < count; i++)
                {
                    if (unitsOnMap[i].Faction == "Purple")
                    {
                        unitsOnMap[i].Health += 50;
                    }
                }
            }
            if (moneyYellow >= 100)
            {
                moneyYellow -= 100;
                for (int i = 0; i < count; i++)
                {
                    if (unitsOnMap[i].Faction == "Yellow")
                    {
                        unitsOnMap[i].Health += 50;
                    }
                }
            }
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
            for (int i = 0; i < unitsOnMap.Count-1;i++)
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
            for (int i = 0; i < neutralCamps.Count; i++)
            {
                if (neutralCamps[i].X == x && neutralCamps[i].Y == y)
                {
                    display = neutralCamps[i].toString();
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
                    else if (symbol == "R")
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
            int minXBoundary;
            int maxXBoundary;
            int minYBoundary;
            int maxYBoundary;
            try
            {
                inFile = new FileStream(@"Files\CreepUnits.txt", FileMode.Open, FileAccess.Read);
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
                    minXBoundary = Convert.ToInt32(reader.ReadLine());
                    maxXBoundary = Convert.ToInt32(reader.ReadLine());
                    minYBoundary = Convert.ToInt32(reader.ReadLine());
                    maxYBoundary = Convert.ToInt32(reader.ReadLine());
                    tmp = new NeutralCreep(x, y, health, speed, attack, range, faction, symbol, name,minXBoundary,maxXBoundary,minYBoundary,maxYBoundary);
                    unitsOnMap.Add(tmp);
                    map[x, y] = symbol;
                    input = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }
            catch
            {

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
