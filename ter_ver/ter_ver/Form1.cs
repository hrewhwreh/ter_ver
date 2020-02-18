using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ter_ver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DrawGraph(zedGraphControl2, 1, 2);
            DrawGraph(zedGraphControl3, 2, 3);
        }

        private void DrawGraph(ZedGraphControl pane, int type, int colortype)
        {
            GraphPane Pane = pane.GraphPane;
            PointPairList list = new PointPairList();
            double x = 0.01;
            if (type == 1)
            {           
                for (int i = 0; i < 1000; i++)
                {
                    list.Add(x * i, x * i * Math.Exp(-(x * i) * (x * i) / 2));
                }
            }
            else
            {
                for (int i = 0; i < 1000; i++)
                {
                    list.Add(x * i, 1 - Math.Exp(-(x * i) * (x * i) / 2));
                }
            }
            if (colortype == 0)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Red, SymbolType.None);
            }
            if (colortype == 1)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Blue, SymbolType.None);
            }
            if (colortype == 2)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Black, SymbolType.None);
            }
            if (colortype == 3)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Purple, SymbolType.None);
            }
            if (colortype == 4)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Green, SymbolType.None);
            }
            if (colortype == 5)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Gold, SymbolType.None);
            }
            if (colortype == 6)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Violet, SymbolType.None);
            }
            if (colortype == 7)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Brown, SymbolType.None);
            }
            pane.AxisChange();
            pane.Invalidate();
        }

        private void DrawGraph_(ZedGraphControl pane, ref double[] x, int colortype)
        {
            GraphPane Pane = pane.GraphPane;
            PointPairList list = new PointPairList();
            for (int i = 0; i < x.Length; i++)
            {
                list.Add(x[i], x[i] * Math.Exp(-x[i] * x[i] / 2));
            }
            if (colortype == 0)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Red, SymbolType.None);
            }
            if (colortype == 1)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Blue, SymbolType.None);
            }
            if (colortype == 2)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Black, SymbolType.None);
            }
            if (colortype == 3)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Purple, SymbolType.None);
            }
            if (colortype == 4)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Green, SymbolType.None);
            }
            if (colortype == 5)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Gold, SymbolType.None);
            }
            if (colortype == 6)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Violet, SymbolType.None);
            }
            if (colortype == 7)
            {
                LineItem curve = Pane.AddCurve("", list, Color.Brown, SymbolType.None);
            }
            pane.AxisChange();
            pane.Invalidate();
        }

        void ShellSort(int n, double[] mass, int[] m2)
        {
            int i, j, step;
            double tmp1;
            int tmp2;
            for (step = n / 2; step > 0; step /= 2)
            {
                for (i = step; i < n; i++)
                {
                    tmp1 = mass[i];
                    tmp2 = m2[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (tmp1 < mass[j - step])
                        {
                            mass[j] = mass[j - step];
                            m2[j] = m2[j - step];
                        }
                        else
                        {
                            break;
                        }
                    }
                    mass[j] = tmp1;
                    m2[j] = tmp2;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            Random rnd = new Random();
            double sigma = Convert.ToDouble(textBox1.Text);
            int Number_steps = Convert.ToInt32(textBox2.Text);
            double[] y = new double[1];
            y[0] = sigma * Math.Sqrt(-2 * Math.Log(Math.E, 1 - rnd.NextDouble() * 0.9999999));
            int[] n = new Int32[1];
            n[0] = 1;         
            for (int i = 1; i < Number_steps; i++)
            {
                double tmp_y = sigma * Math.Sqrt(-2 * Math.Log(Math.E, 1 - rnd.NextDouble() * 0.9999999));
                int flag = 0;
                for (int j = 0; j < y.Length; j++)
                {
                    if (y[j] == tmp_y)
                    {
                        n[j]++;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Array.Resize(ref y, y.Length + 1);
                    Array.Resize(ref n, n.Length + 1);
                    y[y.Length - 1] = tmp_y;
                    n[y.Length - 1] = 1;
                }
            }
            ShellSort(y.Length, y, n);
            for (int i = 0; i < y.Length; i++)
            {
                dataGridView1.Rows.Add(i + 1, y[i], n[i], (double)(n[i]) / Number_steps);
            }
            int tmp = 0;
            for (int i = 0; i < y.Length; i++)
            {
                tmp += n[i];
            }
            label4.Text = Convert.ToString(tmp / Number_steps);
            DrawGraph(zedGraphControl1, 1, 5);
            DrawGraph_(zedGraphControl1, ref y, 7);
            if (checkBox1.Checked == true)
            {
                double v_s = 0;
                for (int i = 0; i < y.Length; i++)
                {
                    v_s += y[i] * n[i];
                }
                v_s = v_s / Number_steps;
                double v_d = 0;
                for (int i = 0; i < y.Length; i++)
                {
                    v_d += Math.Pow((y[i] - v_s), 2) * n[i];
                }
                v_d = v_d / Number_steps;
                double r_v = y[y.Length - 1] - y[0];
                double me = 0;
                if (y.Length % 2 == 1)
                {
                    me = y[y.Length / 2];
                }
                else
                {
                    me = y[y.Length / 2 - 1] + y[y.Length / 2];
                    me /= 2;
                }
                double mo = Math.Sqrt(Math.PI / 2) * sigma;
                double th = mo - v_s;
                if (th < 0)
                {
                    th = -th;
                }
                double dis = (2 - (Math.PI / 2)) * sigma * sigma;
                double td = dis - v_d;
                if (td < 0)
                {
                    td = -td;
                }
                dataGridView2.Rows.Add(mo, v_s, th, dis, v_d, td, me, r_v);

            }
        }
    }
}
