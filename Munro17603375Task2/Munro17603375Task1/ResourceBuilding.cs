using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Munro17603375Task1
{
    class ResourceBuilding : Building
    {
        private string resourceType;
        private int resourcesPerTick;
        private int resourcesRemaining;
        public ResourceBuilding(int x, int y, int health, string faction, string symbol, string resourceType,int resourcesPerTick, int resourcesRemaining)
      : base(x, y, health, faction, symbol)
        {
            this.resourceType = resourceType;
            this.resourcesPerTick = resourcesPerTick;
            this.resourcesRemaining = resourcesRemaining;
        }
        public int ResourcesRemaining
        {
            get { return resourcesRemaining; }
            set { resourcesRemaining = value; }
        }
        public int ResourcesPerTick
        {
            get { return resourcesPerTick; }
            set { resourcesPerTick = value; }
        }
        public string ResourceType
        {
            get { return resourceType; }
            set { resourceType = value; }
        }
        override public bool isDestroyed()
        {
            if (health < 0)
                return false;
            else
                return true;
        }
        public void collect(int total)
        {
            total += resourcesPerTick;
            resourcesRemaining -= resourcesPerTick;
            if (resourcesRemaining == 0)
                health = 0;
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
        public override void save()
        {
            FileStream outFile = null;
            StreamWriter structure = null;
            try
            {
                outFile = new FileStream(@"Files\Resources.txt", FileMode.Append, FileAccess.Write);
                structure = new StreamWriter(outFile);
                structure.WriteLine(x);
                structure.WriteLine(y);
                structure.WriteLine(health);
                structure.WriteLine(faction);
                structure.WriteLine(symbol);
                structure.WriteLine(resourceType);
                structure.WriteLine(resourcesPerTick);
                structure.WriteLine(resourcesRemaining);
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
