using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Munro17603375Task1
{

    public partial class Form1 : Form
    {
        int tickCounter = 0;
        GameEngine engine = new GameEngine();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timerEvent();
        }
        public void timerEvent()
        {
            reDraw();
            for (int v = 0; v < engine.size(); v++)
            {
                engine.conditions(v);
            }
            engine.updateMap();
            engine.spawnInterval(tickCounter);
            lblTimer.Text = Convert.ToString(tickCounter++) ;
        }
        public void reDraw()
        {
            rchMap.Text = "";
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    rchMap.Text += engine.mapPopulate(x , y).PadRight(1);
                }
                rchMap.Text += Environment.NewLine;
            }
          
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine.draw();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (File.Exists(@"Files\Units.txt"))
            {
                File.Delete(@"Files\Units.txt");
            }
            if (File.Exists(@"Files\Structures.txt"))
            {
                File.Delete(@"Files\Structures.txt");
            }
            if (File.Exists(@"Files\Resources.txt"))
            {
                File.Delete(@"Files\Resources.txt");
            }
            engine.save();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            engine.read();
        }

        private void rchMap_MouseClick(object sender, MouseEventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            if (x <= 734)
            {
                x = 0;
            }
            else if (x > 734 && x <= 744)
            {
                x = 1;
            }
            else if (x > 744 && x <= 754)
            {
                x = 2;
            }
            else if (x > 754 && x <= 764)
            {
                x = 3;
            }
            else if (x > 764 && x <= 774)
            {
                x = 4;
            }
            else if (x > 774 && x <= 784)
            {
                x = 5;
            }
            else if (x > 784 && x <= 794)
            {
                x = 6;
            }
            else if (x > 794 && x <= 804)
            {
                x = 7;
            }
            else if (x > 804 && x <= 814)
            {
                x = 8;
            }
            else if (x > 814 && x <= 824)
            {
                x = 9;
            }
            else if (x > 824 && x <= 834)
            {
                x = 10;
            }
            else if (x > 834 && x <= 844)
            {
                x = 11;
            }
            else if (x > 844 && x <= 854)
            {
                x = 12;
            }
            else if (x > 854 && x <= 864)
            {
                x = 13;
            }
            else if (x > 864 && x <= 874)
            {
                x = 14;
            }
            else if (x > 874 && x <= 884)
            {
                x = 15;
            }
            else if (x > 884 && x <= 894)
            {
                x = 16;
            }
            else if (x > 894 && x <= 904)
            {
                x = 17;
            }
            else if (x > 904 && x <= 914)
            {
                x = 18;
            }
            else
            {
                x = 19;
            }
            if (y <= 190)
            {
                y = 0;
            }
            else if (y > 190 && y <= 210)
            {
                y = 1;
            }
            else if (y > 210 && y <= 230)
            {
                y = 2;
            }
            else if (y > 230 && y <= 250)
            {
                y = 3;
            }
            else if (y > 250 && y <= 270)
            {
                y = 4;
            }
            else if (y > 270 && y <= 290)
            {
                y = 5;
            }
            else if (y > 290 && y <= 310)
            {
                y = 6;
            }
            else if (y > 310 && y <= 330)
            {
                y = 7;
            }
            else if (y > 330 && y <= 350)
            {
                y = 8;
            }
            else if (y > 350 && y <= 370)
            {
                y = 9;
            }
            else if (y > 370 && y <= 390)
            {
                y = 10;
            }
            else if (y > 390 && y <= 410)
            {
                y = 11;
            }
            else if (y > 410 && y <= 430)
            {
                y = 12;
            }
            else if (y > 430 && y <= 450)
            {
                y = 13;
            }
            else if (y > 450 && y <= 470)
            {
                y = 14;
            }
            else if (y > 470 && y <= 490)
            {
                y = 15;
            }
            else if (y > 490 && y <= 510)
            {
                y = 16;
            }
            else if (y > 510 && y <= 530)
            {
                y = 17;
            }
            else if (y > 530 && y <= 540)
            {
                y = 18;
            }
            else
            {
                y = 19;
            }
            txtStatus.Text = engine.display(x, y);

        }
    }
}

