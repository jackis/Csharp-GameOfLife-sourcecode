using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ass2
{
    public partial class Form1 : Form
    {
        int[,] show = new int[101, 101];
        int[,] calc = new int[101, 101];
        int sum = 0;

        public Form1()
        {
            InitializeComponent();
            start(); //fill arrays with 0
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void start()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    show[x, y] = 0;
                    calc[x, y] = 0;
                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            //this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void copy()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    show[x, y] = calc[x, y];
                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            Refresh();
            //this.Paint += new PaintEventHandler(Form1_Paint);
        }



        private void newgeneration()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    if ((y == 0) && (x == 0))   // Top left
                    {
                        if (show[x + 1, y] + show[x + 1, y + 1] + show[x, y + 1] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 0) && (x == 100))   // Top right
                    {
                        if (show[x - 1, y] + show[x - 1, y + 1] + show[x, y + 1] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 100) && (x == 0))   // Bottom Left
                    {
                        if (show[x, y - 1] + show[x + 1, y - 1] + show[x + 1, y] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 100) && (x == 100)) // Bottom Right
                    {
                        if (show[x, y - 1] + show[x - 1, y - 1] + show[x - 1, y] == 3)
                        {
                            calc[x, y] = 1;
                        }
                        else
                        {
                            calc[x, y] = 0;
                        }
                    }

                    if ((y == 0) && (x > 0) && (x < 100)) //top
                    {
                        //int sum = 0;
                        sum = show[x - 1, y] + show[x - 1, y + 1] + show[x, y + 1] + show[x + 1, y + 1] + show[x + 1, y];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x == 0) && (y != 0) && (y != 100)) //left
                    {
                        //int sum = 0;
                        sum = show[x, y - 1] + show[x + 1, y - 1] + show[x + 1, y] + show[x + 1, y + 1] + show[x, y + 1] + 1;

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x == 100) && (y != 0) && (y != 100)) //right
                    {
                        //int sum = 0;
                        sum = show[x, y - 1] + show[x - 1, y - 1] + show[x - 1, y] + show[x - 1, y + 1] + show[x, y + 1];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((y == 100) && (x != 0) && (x != 100)) //bottom
                    {
                        //int sum = 0;
                        sum = show[x - 1, y] + show[x - 1, y - 1] + show[x, y - 1] + show[x + 1, y - 1] + show[x + 1, y];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x != 0) && (y != 0) && (x != 100) && (y != 100)) //center
                    {
                        //int sum = 0;
                        sum = show[x - 1, y - 1] + show[x, y - 1] + show[x + 1, y - 1] + show[x - 1, y] + show[x + 1, y] + show[x - 1, y + 1] + show[x, y + 1] + show[x + 1, y + 1];

                        if ((show[x, y] == 0) && (sum == 3))
                        {
                            calc[x, y] = 1;
                        }

                        if ((show[x, y] == 1) && (sum <= 1))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && (sum >= 4))
                        {
                            calc[x, y] = 0;
                        }

                        if ((show[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            calc[x, y] = 1;
                        }

                        sum = 0;
                    }

                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            copy();
            //this.Paint += new PaintEventHandler(Form1_Paint);
        }


        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 0;
            int x = 0;
            while (y < 100)
            {
                while (x < 100)
                {
                    if (show[x, y] == 1)
                    {
                        Brush brush = new SolidBrush(Color.Yellow);
                        g.FillRectangle(brush, x * 5 + 5, y * 5 + 5, 4, 4);
                    }
                    else
                    {
                        Brush brush = new SolidBrush(Color.Black);
                        g.FillRectangle(brush, x * 5 + 5, y * 5 + 5, 4, 4);
                    }
                    x++;
                }
                x = 0;
                y++;
            }
            x = 0;
            y = 0;
        }

        int starts = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (starts == 1)
            {
                starts = 0;
            }
            else
            {
                starts = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (starts == 1)
            {
                newgeneration();
            }
            else { Refresh(); }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int xe = e.X;
            int ye = e.Y;
            show[(xe - 5) / 5, (ye - 5) / 5] = 1;
            calc[(xe - 5) / 5, (ye - 5) / 5] = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start();
            starts = 0;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (starts == 1)
            {
                starts = 0;
            }
            else
            {
                starts = 1;
            }
        }


    }
}
