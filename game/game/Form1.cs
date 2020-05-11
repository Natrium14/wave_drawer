using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            air1.X = 0;
            air1.Y = panel1.Height / 2;
            air2.X = 0;
            air2.Y = panel2.Height / 2;
            air3.X = 0;
            air3.Y = panel2.Height / 2;
            air4.X = 0;
            air4.Y = panel3.Height / 2;
            air5.X = 0;
            air5.Y = panel3.Height / 2;
            p_p1.X = 0;
            p_p1.Y = panel5.Height / 2;
            p_p2.X = panel6.Width /2 ;
            p_p2.Y = 0;

            color_list.Add(Color.Black);
            color_list.Add(Color.Red);
            color_list.Add(Color.Blue);
            color_list.Add(Color.Green);
            color_list.Add(Color.Violet);
            color_list.Add(Color.Orange);
            color_list.Add(Color.Olive);
            color_list.Add(Color.Navy);
            color_list.Add(Color.Gray);

            
            color_list1.Add(Color.Black);
            color_list1.Add(Color.Red);
            color_list1.Add(Color.Blue);
            color_list1.Add(Color.Green);
            color_list1.Add(Color.Violet);
            color_list1.Add(Color.Orange);
            color_list1.Add(Color.Olive);
            color_list1.Add(Color.Navy);
            color_list1.Add(Color.Gray);

            color_list2.Add(Color.Black);
            color_list2.Add(Color.Red);
            color_list2.Add(Color.Blue);
            color_list2.Add(Color.Green);
            color_list2.Add(Color.Violet);
            color_list2.Add(Color.Orange);
            color_list2.Add(Color.Olive);
            color_list2.Add(Color.Navy);
            color_list2.Add(Color.Gray); 

            comboBox1.DataSource = color_list;
            comboBox1.DisplayMember = "Name";
            comboBox4.DataSource = color_list;
            comboBox4.DisplayMember = "Name";
            comboBox8.DataSource = color_list;
            comboBox8.DisplayMember = "Name";
            comboBox5.DataSource = color_list1;
            comboBox5.DisplayMember = "Name";
            comboBox6.DataSource = color_list1;
            comboBox6.DisplayMember = "Name";
            comboBox9.DataSource = color_list2;
            comboBox9.DisplayMember = "Name";

            size_pen.Add(1);
            size_pen.Add(2);
            size_pen.Add(3);
            size_pen.Add(5);
            size_pen.Add(10);
            size_pen.Add(15);
            size_pen.Add(20);

            comboBox2.DataSource = size_pen;
            comboBox3.DataSource = size_pen;
            comboBox7.DataSource = size_pen;

            gr = panel1.CreateGraphics();
        }

        int t1 = 1,t2=0,t3=0,t4=0;
        Graphics gr,gr1,gr2;
        Pen pen, pen1, pen2, pen3;
        Point air1, air2, air3, air4, air5;
        /*Perpendicular */
        Graphics gr_p1, gr_p2, gr_p3;
        Point p_p1, p_p2, p_p3;
        Pen pen_p;
        ///////
        double v0 = 1;
        List<Color> color_list = new List<Color>();
        List<Color> color_list1 = new List<Color>();
        List<Color> color_list2 = new List<Color>();
        List<int> size_pen = new List<int>();
        int x1 = 0, x2 = 0, y1 = 0, y2 = 0,x1_p=0,x2_p=0,y1_p=0,y2_p=0;
        

        private void butStart1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Color c = (Color)comboBox1.SelectedItem;
            int width = (int)comboBox2.SelectedValue;
            pen = new Pen(c, width);
            y1 = 0;
            x1 = 0;
            y2 = 0;
            x2 = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = Convert.ToDouble(textBox1.Text); // Амплитуда
            var b = Math.Exp(-Convert.ToDouble(textBox3.Text)/1000 * t1); // Коэфф затухания
            double c = 0; // Функция колебания

            if (radioBut_Sin.Checked)
            {
                c = Math.Sin((Convert.ToDouble(textBox2.Text)/1000 * air1.X) * 180 / Math.PI); // Функция колебания SIN
            }
            if (radioBut_Cos.Checked)
            {
                c = Math.Cos((Convert.ToDouble(textBox2.Text)/1000 * air1.X) * 180 / Math.PI); // Функция колебания SIN
            }

            air1.X = t1;
            air1.Y = Convert.ToInt32(a * b * c);
            var halfPanel = panel1.Height / 2;

            y2 = air1.Y;
            x2 = air1.X;
            gr.DrawLine(pen, x1, y1 + halfPanel, x2, y2 + halfPanel);
            y1 = air1.Y;
            x1 = air1.X;       

            label1.Text = t1 + " мс";
            t1++;

            if (t1 % 50 == 0)
            {
                gr.DrawLine(new Pen(Color.Black, 1), x1, halfPanel + 5, x1, halfPanel - 5);
                gr.DrawString(t1.ToString(), new Font("Consolas", 10), Brushes.Black, x1 - 5, halfPanel + 10);
            }

            if (t1 == 100)
            {
                var t13 = 1;
            }

            try
            {
                double q1 = 0;
                double q2 = 0;
                double q3 = 0;

                if (radioBut_Sin.Checked)
                {
                    q1 = a * Math.Exp(-Convert.ToDouble(textBox3.Text) / 1000 * (t1 - 2)) * Math.Sin((Convert.ToDouble(textBox2.Text) / 1000 * (t1 - 1)) * 180 / Math.PI);
                    q2 = a * Math.Exp(-Convert.ToDouble(textBox3.Text) / 1000 * t1) * Math.Sin((Convert.ToDouble(textBox2.Text) / 1000 * t1) * 180 / Math.PI);
                    q3 = a * Math.Exp(-Convert.ToDouble(textBox3.Text) / 1000 * (t1 + 2)) * Math.Sin((Convert.ToDouble(textBox2.Text) / 1000 * (t1 + 1)) * 180 / Math.PI);
                }
                if (radioBut_Cos.Checked)
                {
                    q1 = a * Math.Exp(-Convert.ToDouble(textBox3.Text) / 1000 * (t1 - 2)) * Math.Cos((Convert.ToDouble(textBox2.Text) / 1000 * (t1 - 1)) * 180 / Math.PI);
                    q2 = a * Math.Exp(-Convert.ToDouble(textBox3.Text) / 1000 * t1) * Math.Cos((Convert.ToDouble(textBox2.Text) / 1000 * t1) * 180 / Math.PI);
                    q3 = a * Math.Exp(-Convert.ToDouble(textBox3.Text) / 1000 * (t1 + 2)) * Math.Cos((Convert.ToDouble(textBox2.Text) / 1000 * (t1 + 1)) * 180 / Math.PI);
                }

                if ((q2 < q1 && q2 < q3) || (q2 > q1 && q2 > q3))
                {
                    if (checkBox1.Checked)
                    {
                        if (halfPanel < y1 + halfPanel)
                            gr.DrawString((-air1.Y).ToString(), new Font("Consolas", 8), Brushes.Black, x1 - 5, y1 + halfPanel + 15);
                        else
                            gr.DrawString((-air1.Y).ToString(), new Font("Consolas", 8), Brushes.Black, x1 - 5, y1 + halfPanel - 15);
                    }
                }

            }
            catch(Exception ee) { }
            

            if (air1.X == panel1.Width)
            {
                timer1.Stop();
                t1 = 1;
                air1.X = 0;
                air1.Y = 0;
            }            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            air1.X = 0;
            air1.Y = panel1.Height / 2;
            air2.X = 0;
            air2.Y = panel2.Height / 2;
            air3.X = 0;
            air3.Y = panel2.Height / 2;
            air4.X = 0;
            air4.Y = panel3.Height / 2;
            air5.X = 0;
            air5.Y = panel3.Height / 2;
            p_p1.X = 0;
            p_p1.Y = panel5.Height / 2;
            p_p2.X = panel6.Width / 2;
            p_p2.Y = 0;

            gr = panel1.CreateGraphics();
            gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, panel1.Height / 2), new Point(panel1.Width, panel1.Height / 2));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Color c = (Color)comboBox1.SelectedItem;
                pen.Color = c;
            }
            catch(Exception ee) { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int width = (int)comboBox2.SelectedValue;
                pen.Width = width;
            }
            catch(Exception ee) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.WhiteSmoke);
            gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, panel1.Height / 2), new Point(panel1.Width, panel1.Height / 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            t1 = 0;
            air1.X = 0;
            air1.Y = this.Height / 2;
            y1 = air1.Y;
            x1 = air1.X;
            y2 = air1.Y;
            x2 = air1.X;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            gr1 = panel2.CreateGraphics();
            gr1.DrawLine(new Pen(Brushes.Black, 2), new Point(0, panel2.Height / 2), new Point(panel2.Width, panel2.Height / 2));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                air2.X = Convert.ToInt32(v0 * t2);
                air2.Y = Convert.ToInt32(Convert.ToDouble(textBox6.Text) * Math.Exp(-Convert.ToDouble(textBox4.Text) * t2) * Math.Cos((Convert.ToDouble(textBox5.Text) * air2.X) * 180 / Math.PI));
                gr1.DrawEllipse(pen1, air2.X, air2.Y + panel2.Height / 2, (int)comboBox3.SelectedItem, (int)comboBox3.SelectedItem);
                
                int a = air2.Y;
                
                air2.X = Convert.ToInt32(v0 * t2);
                air2.Y = Convert.ToInt32(Convert.ToDouble(textBox9.Text) * Math.Exp(-Convert.ToDouble(textBox7.Text) * t2) * Math.Cos((Convert.ToDouble(textBox8.Text) * air2.X) * 180 / Math.PI));
                gr1.DrawEllipse(pen2, air2.X, air2.Y + panel2.Height / 2, (int)comboBox3.SelectedItem, (int)comboBox3.SelectedItem);

                Pen pen3 = new Pen(Color.Black, 2);

                air3.X = Convert.ToInt32(v0 * t2);
                air3.Y = air2.Y + a;//Convert.ToInt32(Convert.ToDouble(textBox9.Text) * Math.Exp(-Convert.ToDouble(textBox7.Text) * t2) * Math.Cos((Convert.ToDouble(textBox8.Text) * air2.X) * 180 / Math.PI));
               // gr1.DrawEllipse(pen3, air3.X, air3.Y + panel2.Height / 2, 2, 2);
                              
                y2 = air3.Y;
                x2 = air3.X;
                gr1.DrawLine(pen3, x1, y1 + panel2.Height / 2, x2, y2 + panel2.Height / 2);
                y1 = air3.Y;
                x1 = air3.X;


                label12.Text = t2 + " sec";
                t2 = t2 + 1;

            }
            catch (Exception ee) { }
            if (air2.X == panel2.Width)
            {
                timer2.Stop();
                t2 = 0;
                air2.X = 0;
                air2.Y = panel2.Height / 2;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            y1 = panel2.Height/2;
            x1 = 0;
            y2 = panel2.Height / 2;
            x2 = 0;
            Color c1 = (Color)comboBox4.SelectedItem;
            pen1 = new Pen(c1, 1);
            Color c2 = (Color)comboBox5.SelectedItem;
            pen2 = new Pen(c2, 1);
            timer2.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            t2 = 0;
            air2.X = 0;
            air2.Y = this.Height / 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gr1.Clear(Color.White);
            gr1.DrawLine(new Pen(Brushes.Black, 2), new Point(0, panel2.Height / 2), new Point(panel2.Width, panel2.Height / 2));
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                air5.X = Convert.ToInt32(v0 * t3);
                air5.Y = Convert.ToInt32(Convert.ToDouble(textBox15.Text) * Math.Exp(-Convert.ToDouble(textBox13.Text) * t3) * Math.Cos((Convert.ToDouble(textBox14.Text) * air5.X) * 180 / Math.PI));
                gr2.DrawEllipse(pen1, air5.X, air5.Y + panel2.Height / 2, (int)comboBox7.SelectedItem, (int)comboBox7.SelectedItem);
                
                int a = air5.Y;

                air5.X = Convert.ToInt32(v0 * t3);
                air5.Y = Convert.ToInt32(Convert.ToDouble(textBox12.Text) * Math.Exp(-Convert.ToDouble(textBox10.Text) * t3) * Math.Cos((Convert.ToDouble(textBox11.Text) * air5.X) * 180 / Math.PI));
                gr2.DrawEllipse(pen2, air5.X, air5.Y + panel3.Height / 2, (int)comboBox7.SelectedItem, (int)comboBox7.SelectedItem);

                int b = air5.Y;

                air5.X = Convert.ToInt32(v0 * t3);
                air5.Y = Convert.ToInt32(Convert.ToDouble(textBox18.Text) * Math.Exp(-Convert.ToDouble(textBox16.Text) * t3) * Math.Cos((Convert.ToDouble(textBox17.Text) * air5.X) * 180 / Math.PI));
                gr2.DrawEllipse(pen3, air5.X, air5.Y + panel3.Height / 2, (int)comboBox7.SelectedItem, (int)comboBox7.SelectedItem);

                Pen pen4 = new Pen(Color.Black, 2);

                air4.X = Convert.ToInt32(v0 * t3);
                air4.Y = air5.Y + a + b;//Convert.ToInt32(Convert.ToDouble(textBox9.Text) * Math.Exp(-Convert.ToDouble(textBox7.Text) * t2) * Math.Cos((Convert.ToDouble(textBox8.Text) * air2.X) * 180 / Math.PI));
               // gr2.DrawEllipse(pen4, air4.X, air4.Y + panel3.Height / 2, 2, 2);

                y2 = air4.Y;
                x2 = air4.X;
                gr2.DrawLine(pen4, x1, y1 + panel3.Height / 2, x2, y2 + panel3.Height / 2);
                y1 = air4.Y;
                x1 = air4.X;
                
                label26.Text = t3 + " sec";
                t3 = t3 + 1;

            }
            catch (Exception ee) { }
            if (air4.X == panel3.Width)
            {
                timer3.Stop();
                t3 = 0;
                air4.X = 0;
                air4.Y = panel3.Height / 2;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            Color c1 = (Color)comboBox8.SelectedItem;
            pen1 = new Pen(c1, 1);
            Color c2 = (Color)comboBox6.SelectedItem;
            pen2 = new Pen(c2, 1);
            Color c3 = (Color)comboBox9.SelectedItem;
            pen3 = new Pen(c3, 1);
            y1 = panel3.Height / 2;
            x1 = 0;
            y2 = panel3.Height / 2;
            x2 = 0;
            timer3.Start();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gr2.Clear(Color.White);
            gr2.DrawLine(new Pen(Brushes.Black, 2), new Point(0, panel3.Height / 2), new Point(panel3.Width, panel3.Height / 2));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            t3 = 0;
            air5.X = 0;
            air5.Y = this.Height / 2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            gr2 = panel3.CreateGraphics();
            gr2.DrawLine(new Pen(Brushes.Black, 2), new Point(0, panel3.Height / 2), new Point(panel3.Width, panel3.Height / 2));
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            pen_p = new Pen(Color.Black, 1);


            y1 = panel5.Height / 2;
            x1 = 0;
            y2 = panel5.Height / 2;
            x2 = 0;
            y1_p = 0;
            x1_p = panel6.Width / 2;
            y2_p = 0;
            x2_p = panel6.Width / 2;

            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    //first osc
                    p_p1.X = Convert.ToInt32(v0 * t4);
                    p_p1.Y = Convert.ToInt32(Convert.ToDouble(textBox19.Text)/*Math.Exp(-Convert.ToDouble(textBox3.Text) * t1)*/* Math.Sin((Convert.ToDouble(textBox20.Text) * p_p1.X) * 180 / Math.PI));
                    y2 = p_p1.Y;
                    x2 = p_p1.X;
                    gr_p1.DrawLine(pen_p, x1, y1 + panel5.Height / 2, x2, y2 + panel5.Height / 2);
                    y1 = p_p1.Y;
                    x1 = p_p1.X;
                }
                if (radioButton2.Checked)
                {
                    //first osc
                    p_p1.X = Convert.ToInt32(v0 * t4);
                    p_p1.Y = Convert.ToInt32(Convert.ToDouble(textBox19.Text)/*Math.Exp(-Convert.ToDouble(textBox3.Text) * t1)*/* Math.Cos((Convert.ToDouble(textBox20.Text) * p_p1.X) * 180 / Math.PI));
                    y2 = p_p1.Y;
                    x2 = p_p1.X;
                    gr_p1.DrawLine(pen_p, x1, y1 + panel5.Height / 2, x2, y2 + panel5.Height / 2);
                    y1 = p_p1.Y;
                    x1 = p_p1.X;
                }
                if (radioButton3.Checked)
                {
                    //second osc
                    p_p2.Y = Convert.ToInt32(v0 * t4);
                    p_p2.X = Convert.ToInt32(Convert.ToDouble(textBox21.Text)/*Math.Exp(-Convert.ToDouble(textBox3.Text) * t1)*/* Math.Sin((Convert.ToDouble(textBox22.Text) * p_p2.Y) * 180 / Math.PI));
                    y2_p = p_p2.Y;
                    x2_p = p_p2.X;
                    gr_p2.DrawLine(pen_p, x1_p + panel6.Width / 2, y1_p, x2_p + panel6.Width / 2, y2_p);
                    y1_p = p_p2.Y;
                    x1_p = p_p2.X;
                }
                if (radioButton4.Checked)
                {
                    //second osc
                    p_p2.Y = Convert.ToInt32(v0 * t4);
                    p_p2.X = Convert.ToInt32(Convert.ToDouble(textBox21.Text)/*Math.Exp(-Convert.ToDouble(textBox3.Text) * t1)*/* Math.Cos((Convert.ToDouble(textBox22.Text) * p_p2.Y) * 180 / Math.PI));
                    y2_p = p_p2.Y;
                    x2_p = p_p2.X;
                    gr_p2.DrawLine(pen_p, x1_p + panel6.Width / 2, y1_p, x2_p + panel6.Width / 2, y2_p);
                    y1_p = p_p2.Y;
                    x1_p = p_p2.X;
                }
                //third osc
                gr_p3.DrawEllipse(pen_p, p_p1.Y + panel4.Width / 2, p_p2.X + panel4.Height / 2, 1, 1);


                label31.Text = t4 + " sec";
                t4 = t4 + 1;
                /*
                if (t4 == 3000)
                {
                    timer4.Stop();
                    y1 = panel5.Height / 2;
                    x1 = 0;
                    y2 = panel5.Height / 2;
                    x2 = 0;
                    y1_p = 0;
                    x1_p = panel6.Width / 2;
                    y2_p = 0;
                    x2_p = panel6.Width / 2;
                    t4 = 0;
                }
                */
            }
            catch (Exception ee) { }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            timer4.Stop();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            gr_p3 = panel4.CreateGraphics();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            gr_p1 = panel5.CreateGraphics();
            gr_p1.DrawLine(new Pen(Brushes.Black, 2), new Point(0, panel5.Height / 2), new Point(panel5.Width, panel5.Height / 2));
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            gr_p2 = panel6.CreateGraphics();
            gr_p2.DrawLine(new Pen(Brushes.Black, 2), new Point(panel6.Width / 2, 0), new Point(panel6.Width/2, panel6.Height));
        }

        private void button15_Click(object sender, EventArgs e)
        {

            y1 = panel5.Height / 2;
            x1 = 0;
            y2 = panel5.Height / 2;
            x2 = 0;
            y1_p = 0;
            x1_p = panel6.Width / 2;
            y2_p = 0;
            x2_p = panel6.Width / 2;
            t4 = 0;
            timer4.Stop();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            gr_p1.Clear(Color.White);
            gr_p2.Clear(Color.White);
            gr_p3.Clear(Color.White);
            gr_p2.DrawLine(new Pen(Brushes.Black, 2), new Point(panel6.Width / 2, 0), new Point(panel6.Width / 2, panel6.Height));
            gr_p1.DrawLine(new Pen(Brushes.Black, 2), new Point(0, panel5.Height / 2), new Point(panel5.Width, panel5.Height / 2));
        }
       


    }
}
