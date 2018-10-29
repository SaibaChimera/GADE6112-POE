using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
namespace MyRTSGame
{
    public class GameEngine : MonoBehaviour
    {

        Map m = new Map();
        [SerializeField]
        private GameObject floor;
        [SerializeField]
        private GameObject neutralCreep;
        [SerializeField]
        private GameObject purpleMelee;
        [SerializeField]
        private GameObject purpleRange;
        [SerializeField]
        private GameObject yellowMelee;
        [SerializeField]
        private GameObject yellowRange;
        [SerializeField]
        private GameObject purpleMeleeState2;
        [SerializeField]
        private GameObject purpleRangeState2;
        [SerializeField]
        private GameObject yellowMeleeState2;
        [SerializeField]
        private GameObject yellowRangeState2;
        [SerializeField]
        private GameObject purpleMeleeState3;
        [SerializeField]
        private GameObject purpleRangeState3;
        [SerializeField]
        private GameObject yellowMeleeState3;
        [SerializeField]
        private GameObject yellowRangeState3;
        [SerializeField]
        private GameObject purpleMeleeState4;
        [SerializeField]
        private GameObject purpleRangeState4;
        [SerializeField]
        private GameObject yellowMeleeState4;
        [SerializeField]
        private GameObject yellowRangeState4;
        [SerializeField]
        private GameObject grass;
        [SerializeField]
        private GameObject yellowVillage;
        [SerializeField]
        private GameObject purpleVillage;
        [SerializeField]
        private GameObject yellowVillageState2;
        [SerializeField]
        private GameObject purpleVillageState2;
        [SerializeField]
        private GameObject yellowVillageState3;
        [SerializeField]
        private GameObject purpleVillageState3;
        [SerializeField]
        private GameObject purpleTower;
        [SerializeField]
        private GameObject yellowTower;
        [SerializeField]
        private GameObject purpleGoldmine;
        [SerializeField]
        private GameObject yellowGoldmine;
        [SerializeField]
        private GameObject neutralCamp;
        [SerializeField]
        private int height;
        [SerializeField]
        private int width;
        // Use this for initialization
        void Start()
        {
            m.populateMap();
            int count = 0;
            for (int k = 0; k < height; k++)
            {
                var yPos = -k * 1;// * tileSize.y + yStart;
                
                for (int i = 0; i < width; i++)
                {
                    var xPos = i * 1;// tileSize.x - xStart;

                    Instantiate(floor, new Vector3(xPos, yPos, 1), Quaternion.identity);
                    Instantiate(grass, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    if (count == 0)
                    {
                        Instantiate(yellowVillage, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 11)
                    {
                        Instantiate(neutralCamp, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 42)
                    {
                        Instantiate(yellowTower, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 40)
                    {
                        Instantiate(yellowGoldmine, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 199)
                    {
                        Instantiate(neutralCamp, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    
                    if (count == 180)
                    {
                        Instantiate(neutralCamp, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 389)
                    {
                        Instantiate(neutralCamp, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 359)
                    {
                        Instantiate(purpleGoldmine, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 357)
                    {
                        Instantiate(purpleTower, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    if (count == 399)
                    {
                        Instantiate(purpleVillage, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    count++;
                }

            }
            StartCoroutine(Example());
        }

        void Update()
        {
            if (Input.GetKeyDown("escape"))
            {
                Application.Quit();
            }
           if (Input.GetKeyDown("space"))
            {
                m.buyHealth();
            }
            m.generateMoney();

        }

        IEnumerator Example()
        {
            yield return new WaitForSeconds(3);
            int count = 0;
            m.placeUnits(count);
            count++;
            if (m.structuresOnMap[1].Health > 450)
            {
                Instantiate(yellowVillage, new Vector3(m.structuresOnMap[1].X, -m.structuresOnMap[1].Y, 0), Quaternion.identity);
            }
            if (m.structuresOnMap[1].Health < 400)
            {
                Instantiate(yellowVillageState2, new Vector3(m.structuresOnMap[1].X, -m.structuresOnMap[1].Y, 0), Quaternion.identity);
            }
            if (m.structuresOnMap[1].Health < 300)
            {
                Instantiate(yellowVillageState3, new Vector3(m.structuresOnMap[1].X, -m.structuresOnMap[1].Y, 0), Quaternion.identity);
            }
            if (m.structuresOnMap[0].Health < 500)
            {
                Instantiate(purpleVillage, new Vector3(m.structuresOnMap[0].X, -m.structuresOnMap[0].Y, 0), Quaternion.identity);
            }
            if (m.structuresOnMap[0].Health < 400)
            {
                Instantiate(purpleVillageState2, new Vector3(m.structuresOnMap[0].X, -m.structuresOnMap[0].Y, 0), Quaternion.identity);
            }
            if (m.structuresOnMap[0].Health < 300)
            {
                Instantiate(purpleVillageState3, new Vector3(m.structuresOnMap[0].X, -m.structuresOnMap[0].Y, 0), Quaternion.identity);
            }
            Instantiate(purpleVillage, new Vector3(m.structuresOnMap[0].X, -m.structuresOnMap[0].Y, 0), Quaternion.identity);
            foreach (Unit temp in m.unitsOnMap)
            {
                if (temp.Symbol == "M")
                {
                    if (temp.Faction == "Purple")
                    {
                        if (temp.X < temp.closestUnit(m.unitsOnMap).X)
                        {

                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(purpleMeleeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(purpleMeleeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(purpleMeleeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(purpleMelee, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                        }
                        else
                        { 
                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(purpleMeleeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(purpleMeleeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(purpleMeleeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(purpleMelee, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                        }
                    }
                    else if (temp.Faction == "Yellow")
                    {

                        if (temp.X < temp.closestUnit(m.unitsOnMap).X)
                        {
                           
                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(yellowMeleeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(yellowMeleeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(yellowMeleeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(yellowMelee, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                        }
                        else
                        {
                            
                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(yellowMeleeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(yellowMeleeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(yellowMeleeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(yellowMelee, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                        }
                    }

                }
                if (temp.Symbol == "R")
                {
                    if (temp.Faction == "Purple")
                    {
                        
                        if (temp.X < temp.closestUnit(m.unitsOnMap).X)
                        {
                          
                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(purpleRangeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(purpleRangeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(purpleRangeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(purpleRange, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }

                        }
                        else
                        {
                            
                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(purpleRangeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(purpleRangeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(purpleRangeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(purpleRange, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }

                        }
                    }
                    else if (temp.Faction == "Yellow")
                    {
                        
                        if (temp.X < temp.closestUnit(m.unitsOnMap).X)
                        {
                           
                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(yellowRangeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(yellowRangeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(yellowRangeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(yellowRange, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 180, 0));
                            }

                        }
                        else
                        {
                           
                            if (temp.Health <= 25 && temp.Health > 0)
                            {
                                Instantiate(yellowRangeState4, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 50 && temp.Health > 25)
                            {
                                Instantiate(yellowRangeState3, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health <= 75 && temp.Health > 50)
                            {
                                Instantiate(yellowRangeState2, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }
                            if (temp.Health > 75)
                            {
                                Instantiate(yellowRange, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.Euler(0, 0, 0));
                            }

                        }
                    }
                }
                if (temp.Symbol == "W")
                    Instantiate(neutralCreep, new Vector3(temp.X * 1, -temp.Y * 1, 0), Quaternion.identity);
            }
            try
            {
                int team = 0;
                for (int v = 0; v < m.count; v++)
                {
                    if (m.unitsOnMap[v].Faction == "Purple")
                    {
                        team = 1;
                    }
                    else if (m.unitsOnMap[v].Faction == "Yellow")
                    {
                        team = 0;
                    }

                    int newX = m.unitsOnMap[v].X;
                    int newY = m.unitsOnMap[v].Y;
                    Unit closestUnit = m.unitsOnMap[v].closestUnit(m.unitsOnMap);
                    Unit closestRat = m.towers[0].closestUnit(m.unitsOnMap);
                    Unit closestRoach = m.towers[1].closestUnit(m.unitsOnMap);
                    m.checkHealth();
                    if (m.unitsOnMap[v].attackRange(closestUnit))
                    {
                        m.unitsOnMap[v].combat(closestUnit);
                        m.checkHealth();
                        closestUnit = m.unitsOnMap[v].closestUnit(m.unitsOnMap);
                    }
                    if (m.unitsOnMap[v].attackRangeBuilding(m.structuresOnMap[team]))
                    {
                        m.unitsOnMap[v].combatBuilding(m.structuresOnMap[team]);
                    }
                    if (m.unitsOnMap[v].Health < 25)
                    {
                        m.unitsOnMap[v].movement(m.unitsOnMap[v].X, m.unitsOnMap[v].Y);
                    }
                    if (m.unitsOnMap[v].Y < closestUnit.Y)
                    {
                        if (m.map[newX, newY + 1] == ".")
                        {
                            m.moveUnits(v, newX, newY + 1);
                        }
                    }
                    if (m.unitsOnMap[v].Y > closestUnit.Y)
                    {
                        if (m.map[newX, newY - 1] == ".")
                        {
                            m.moveUnits(v, newX, newY - 1);
                        }
                    }
                    if (m.unitsOnMap[v].X < closestUnit.X)
                    {
                        if (m.map[newX + 1, newY] == ".")
                        {
                            m.moveUnits(v, newX + 1, newY);
                        }
                    }
                    if (m.unitsOnMap[v].X > closestUnit.X)
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
                    if (m.towers[0].attackRange(closestRat))
                    {
                        m.towers[0].combat(closestRat);
                        m.checkHealth();
                    }
                    if (m.towers[1].attackRange(closestRoach))
                    {
                        m.towers[1].combat(closestUnit);
                        m.checkHealth();
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
            StartCoroutine(Example());

        }
    }
}
