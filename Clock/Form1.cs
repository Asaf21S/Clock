using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        int main = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (main == 0)
            {
                int high = 12;
                SolidBrush ledOn = new SolidBrush(Color.Red);
                SolidBrush ledOff = new SolidBrush(Color.FromArgb(230, 230, 230));
                SolidBrush shadow = new SolidBrush(Color.Black);

                Rectangle[] dots =
                    {
                        new Rectangle(385 + high, 120 - high, 30, 30),
                        new Rectangle(385 + high, 250 - high, 30, 30),
                        new Rectangle(780 + high, 120 - high, 30, 30),
                        new Rectangle(780 + high, 250 - high, 30, 30)
                    };
                for (int i = 0; i < dots.Length; i++)
                {
                    e.Graphics.FillRectangle(ledOn, dots[i]);
                    Point dottopLeft = new Point(dots[i].Location.X, dots[i].Location.Y);
                    Point dotdownLeft = new Point(dots[i].Location.X, dots[i].Location.Y + dots[i].Height);
                    Point dotdownRight = new Point(dots[i].Location.X + dots[i].Width, dots[i].Location.Y + dots[i].Height);
                    Point dottopLeft_ = new Point(dots[i].Location.X - high, dots[i].Location.Y + high);
                    Point dotdownLeft_ = new Point(dots[i].Location.X - high, dots[i].Location.Y + dots[i].Height + high);
                    Point dotdownRight_ = new Point(dots[i].Location.X + dots[i].Width - high, dots[i].Location.Y + dots[i].Height + high);
                    Point[] points = { dottopLeft, dotdownLeft, dotdownRight, dotdownRight_, dotdownLeft_, dottopLeft_ };
                    e.Graphics.FillPolygon(shadow, points);
                }
                Rectangle[] rects =
                    {
                        new Rectangle(76, 80, 88, 20),
                        new Rectangle(55, 101, 20, 88),
                        new Rectangle(165, 101, 20, 88),
                        new Rectangle(76, 190, 88, 20),
                        new Rectangle(55, 211, 20, 88),
                        new Rectangle(165, 211, 20, 88),
                        new Rectangle(76, 300, 88, 20),

                        new Rectangle(241, 80, 88, 20),
                        new Rectangle(220, 101, 20, 88),
                        new Rectangle(330, 101, 20, 88),
                        new Rectangle(241, 190, 88, 20),
                        new Rectangle(220, 211, 20, 88),
                        new Rectangle(330, 211, 20, 88),
                        new Rectangle(241, 300, 88, 20),

                        new Rectangle(471, 80, 88, 20),////////
                        new Rectangle(450, 101, 20, 88),//////////
                        new Rectangle(560, 101, 20, 88),
                        new Rectangle(471, 190, 88, 20),
                        new Rectangle(450, 211, 20, 88),
                        new Rectangle(560, 211, 20, 88),
                        new Rectangle(471, 300, 88, 20),

                        new Rectangle(636, 80, 88, 20),
                        new Rectangle(615, 101, 20, 88),
                        new Rectangle(725, 101, 20, 88),
                        new Rectangle(636, 190, 88, 20),
                        new Rectangle(615, 211, 20, 88),
                        new Rectangle(725, 211, 20, 88),
                        new Rectangle(636, 300, 88, 20),

                        new Rectangle(866, 80, 88, 20),
                        new Rectangle(845, 101, 20, 88),
                        new Rectangle(955, 101, 20, 88),
                        new Rectangle(866, 190, 88, 20),
                        new Rectangle(845, 211, 20, 88),
                        new Rectangle(955, 211, 20, 88),
                        new Rectangle(866, 300, 88, 20),

                        new Rectangle(1031, 80, 88, 20),
                        new Rectangle(1010, 101, 20, 88),
                        new Rectangle(1120, 101, 20, 88),
                        new Rectangle(1031, 190, 88, 20),
                        new Rectangle(1010, 211, 20, 88),
                        new Rectangle(1120, 211, 20, 88),
                        new Rectangle(1031, 300, 88, 20)
                    };

                DateTime current = new DateTime();
                current = DateTime.Now;

                int[] digits = new int[6];
                digits[0] = (current.Hour) / 10;
                digits[1] = (current.Hour) % 10;
                digits[2] = (current.Minute) / 10;
                digits[3] = (current.Minute) % 10;
                digits[4] = (current.Second) / 10;
                digits[5] = (current.Second) % 10;

                for (int i = 0; i < digits.Length; i++)
                {
                    bool[] leds = SetLeds(digits[i]);
                    for (int j = 0; j < leds.Length; j++)
                    {
                        if (leds[j] == false)
                        {
                            //e.Graphics.FillRectangle(ledOff, rects[(i * 7) + j]);
                        }
                        else
                        {
                            rects[(i * 7) + j].Location = new Point(rects[(i * 7) + j].Location.X, rects[(i * 7) + j].Location.Y);
                            e.Graphics.FillRectangle(ledOn, rects[(i * 7) + j]);
                            Point topLeft = new Point(rects[(i * 7) + j].Location.X, rects[(i * 7) + j].Location.Y);
                            Point downLeft = new Point(topLeft.X, topLeft.Y + rects[(i * 7) + j].Height);
                            Point downRight = new Point(topLeft.X + rects[(i * 7) + j].Width, topLeft.Y + rects[(i * 7) + j].Height);
                            Point topRight = new Point(rects[(i * 7) + j].Location.X + rects[(i * 7) + j].Width, rects[(i * 7) + j].Location.Y);

                            if (j == 0)
                            {
                                Point[] compl = { new Point(topLeft.X, topLeft.Y), new Point(topLeft.X - 8, topLeft.Y), new Point(topLeft.X - 14, topLeft.Y + 6), new Point(topLeft.X - 1, topLeft.Y + 19), new Point(topLeft.X, topLeft.Y + 19) };
                                e.Graphics.FillPolygon(ledOn, compl);
                                Point[] compr = { new Point(topRight.X, topRight.Y), new Point(topRight.X + 8, topRight.Y), new Point(topRight.X + 14, topRight.Y + 6), new Point(topRight.X + 1, topRight.Y + 19), new Point(topRight.X, topRight.Y + 19) };
                                e.Graphics.FillPolygon(ledOn, compr);

                                //Point[] points = { topLeft, downLeft, downRight, downRighth, downLefth, topLefth };
                                //e.Graphics.FillPolygon(shadow, points);
                            }
                            else if (j == 1)
                            {
                                Point[] compu = { new Point(topLeft.X, topLeft.Y), new Point(topLeft.X, topLeft.Y - 8), new Point(topLeft.X + 6, topLeft.Y - 14), new Point(topLeft.X + 19, topLeft.Y - 1), new Point(topLeft.X + 19, topLeft.Y) };
                                e.Graphics.FillPolygon(ledOn, compu);
                                Point[] compd = { new Point(downLeft.X, downLeft.Y), new Point(downLeft.X + 10, downLeft.Y + 10), new Point(downRight.X, downRight.Y) };
                                e.Graphics.FillPolygon(ledOn, compd);
                            }
                            else if (j == 2)
                            {
                                Point[] compu = { new Point(topRight.X, topRight.Y), new Point(topRight.X, topRight.Y - 8), new Point(topRight.X - 6, topRight.Y - 14), new Point(topRight.X - 19, topRight.Y - 1), new Point(topRight.X - 19, topRight.Y) };
                                e.Graphics.FillPolygon(ledOn, compu);
                                Point[] compd = { new Point(downLeft.X, downLeft.Y), new Point(downLeft.X + 10, downLeft.Y + 10), new Point(downRight.X, downRight.Y) };
                                e.Graphics.FillPolygon(ledOn, compd);
                            }
                            else if (j == 3)
                            {
                                Point[] compl = { new Point(topLeft.X, topLeft.Y), new Point(topLeft.X - 10, topLeft.Y + 10), new Point(downLeft.X, downLeft.Y) };
                                e.Graphics.FillPolygon(ledOn, compl);
                                Point[] compr = { new Point(topRight.X, topRight.Y), new Point(topRight.X + 10, topRight.Y + 10), new Point(downRight.X, downRight.Y) };
                                e.Graphics.FillPolygon(ledOn, compr);
                            }
                            else if (j == 4)
                            {
                                Point[] compu = { new Point(topLeft.X, topLeft.Y), new Point(topLeft.X + 10, topLeft.Y - 10), new Point(topRight.X, topRight.Y) };
                                e.Graphics.FillPolygon(ledOn, compu);
                                Point[] compd = { new Point(downLeft.X, downLeft.Y), new Point(downLeft.X, downLeft.Y + 8), new Point(downLeft.X + 6, downLeft.Y + 14), new Point(downLeft.X + 19, downLeft.Y + 1), new Point(downLeft.X + 19, downLeft.Y) };
                                e.Graphics.FillPolygon(ledOn, compd);
                            }
                            else if (j == 5)
                            {
                                Point[] compu = { new Point(topLeft.X, topLeft.Y), new Point(topLeft.X + 10, topLeft.Y - 10), new Point(topRight.X, topRight.Y) };
                                e.Graphics.FillPolygon(ledOn, compu);
                                Point[] compd = { new Point(downRight.X, downRight.Y), new Point(downRight.X, downRight.Y + 8), new Point(downRight.X - 6, downRight.Y + 14), new Point(downRight.X - 19, downRight.Y + 1), new Point(downRight.X - 19, downRight.Y) };
                                e.Graphics.FillPolygon(ledOn, compd);
                            }
                            else if (j == 6)
                            {
                                Point[] compl = { new Point(downLeft.X, downLeft.Y), new Point(downLeft.X - 8, downLeft.Y), new Point(downLeft.X - 14, downLeft.Y - 6), new Point(downLeft.X - 1, downLeft.Y - 19), new Point(downLeft.X, downLeft.Y - 19) };
                                e.Graphics.FillPolygon(ledOn, compl);
                                Point[] compr = { new Point(downRight.X, downRight.Y), new Point(downRight.X + 8, downRight.Y), new Point(downRight.X + 14, downRight.Y - 6), new Point(downRight.X + 1, downRight.Y - 19), new Point(downRight.X, downRight.Y - 19) };
                                e.Graphics.FillPolygon(ledOn, compr);
                            }
                        }
                    }
                }
            }
            else if (main == 1)
            {
                change_clock.Visible = false;
                Size formSize = new Size(1011, 1039);
                this.Size = formSize;
                this.StartPosition = FormStartPosition.Manual;
                this.BackColor = Color.Black;
                Pen a = new Pen(Color.White);
                a.Width = 100;
                e.Graphics.DrawEllipse(a, 150, 150, 700, 700);

                TextBox[] numbers = new TextBox[12];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = new TextBox();
                    numbers[i].Text = Convert.ToString(i + 1);
                    numbers[i].Font = new Font("Arial", 30);
                    numbers[i].Size = new Size(50, 50);
                    numbers[i].BackColor = Color.White;
                    Pen p = new Pen(Color.White);
                    int variance = 3;
                    Graphics g = e.Graphics;
                    g.DrawRectangle(p, new Rectangle(numbers[i].Location.X - variance, numbers[i].Location.Y - variance, numbers[i].Width + variance, numbers[i].Height + variance));
                    numbers[i].ForeColor = Color.Black;
                    this.Controls.Add(numbers[i]);
                }
                numbers[0].Location = new Point(650, 172);
                numbers[1].Location = new Point(778, 300);
                numbers[2].Location = new Point(825, 475);
                numbers[3].Location = new Point(778, 650);
                numbers[4].Location = new Point(650, 778);
                numbers[5].Location = new Point(475, 825);
                numbers[6].Location = new Point(300, 778);
                numbers[7].Location = new Point(172, 650);
                numbers[8].Location = new Point(125, 475);
                numbers[9].Location = new Point(172, 300);
                numbers[10].Location = new Point(300, 172);
                numbers[11].Location = new Point(475, 125);
            }
        }

        public bool[] SetLeds(int digit)
        {
            bool[] leds = new bool[7];
            for (int l = 0; l < leds.Length; l++)
            {
                leds[l] = false;
            }

            if (digit == 0)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i != 3)
                        leds[i] = true;
                }
            }
            else if (digit == 1)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i == 2 || i == 5)
                        leds[i] = true;
                }
            }
            else if (digit == 2)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i != 1 && i != 5)
                        leds[i] = true;
                }
            }
            else if (digit == 3)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i != 1 && i != 4)
                        leds[i] = true;
                }
            }
            else if (digit == 4)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i != 0 && i != 4 && i != 6)
                        leds[i] = true;
                }
            }
            else if (digit == 5)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i != 2 && i != 4)
                        leds[i] = true;
                }
            }
            else if (digit == 6)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i != 2)
                        leds[i] = true;
                }
            }
            else if (digit == 7)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i == 0 || i == 2 || i == 5)
                        leds[i] = true;
                }
            }
            else if (digit == 8)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    leds[i] = true;
                }
            }
            else if (digit == 9)
            {
                for (int i = 0; i < leds.Length; i++)
                {
                    if (i != 4)
                        leds[i] = true;
                }
            }
            return leds;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void change_clock_Click(object sender, EventArgs e)
        {
            main = 1;
        }
    }
}
