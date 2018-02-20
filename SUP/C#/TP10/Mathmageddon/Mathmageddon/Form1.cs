using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using org.mariuszgromada.math.mxparser;

namespace TPC10
{
    public partial class Form1 : Form
    {
        private static double tiny = 0.001;
        private static int additional_points = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.Legends[0].IsTextAutoFit = true;
            chart1.Series[0].LegendText = textBox1.Text;
            chart1.Series[0].IsValueShownAsLabel = false;
            chart1.Series[0].ChartType = SeriesChartType.Line; // Spline would be nice if only it worked as expected

            chart1.Series.Add("Derivative");
            chart1.Series.Add("RectangleRule");
            chart1.Series.Add("TrapezoidalRule");
            chart1.Series.Add("SimpsonRule");
            chart1.Series.Add("NewtonQuadrature");
            chart1.Series.Add("GaussQuadrature");

            chart1.Series.Add("Points");
            chart1.Series["Points"].ChartType = SeriesChartType.Point;
            chart1.Series["Points"].Color = Color.Black;

            for (int i = 0; i < chart1.Series.Count; ++i)
            {
                chart1.Series[i].IsVisibleInLegend = false;
                chart1.Series[i].IsXValueIndexed = true;
            }

            DisableDisplays();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableDisplays();
            for (int i = 0; i < chart1.Series.Count; ++i)
            {
                chart1.Series[i].IsVisibleInLegend = false;
                chart1.Series[i].Points.Clear();
            }

            chart1.Series[0].IsVisibleInLegend = true;

            double a = double.Parse(textA.Text);
            double b = double.Parse(textB.Text);
            double interval = double.Parse(textI.Text);
            string text = textBox1.Text;

            Argument x = new Argument("x = " + a);
            Expression exp = new Expression(text, x);
            int it = 0;
            double tmp = a;
            double subtmp;

            if (exp.checkSyntax())
            {
                chart1.Series[0].LegendText = text;

                chart1.Series[0].Points.AddXY(tmp, exp.calculate());
                chart1.Series["Points"].Points.AddXY(tmp, exp.calculate());

                while (tmp + interval <= b)
                {
                    subtmp = interval / additional_points;

                    for (int i = 1; i < additional_points; ++i)
                    {
                        x = new Argument("x = " + (tmp + subtmp));
                        exp = new Expression(text, x);

                        chart1.Series[0].Points.AddXY(tmp + subtmp, exp.calculate());
                        chart1.Series["Points"].Points.AddXY(tmp + subtmp, exp.calculate());

                        chart1.Series["Points"].Points.Last().Color = Color.Transparent;

                        subtmp += interval / additional_points;
                    }
                    tmp += interval;
                    
                    x = new Argument("x = " + tmp);
                    exp = new Expression(text, x);

                    chart1.Series[0].Points.AddXY(tmp, exp.calculate());
                    chart1.Series["Points"].Points.AddXY(tmp, exp.calculate());
                }
            }
            else
                chart1.Series[0].IsVisibleInLegend = false;
        }

        private void EnableDisplays()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            //button6.Enabled = true;
        }
        private void EnableIntegral()
        {
            textNB.Enabled = true;
            textI.Enabled = true;
            trackBarI.Enabled = true;
            button1.Enabled = true;
            EnableDisplays();
        }
        private void DisableDisplays()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            //button6.Enabled = false;
        }
        private void DisableIntegral()
        {
            textNB.Enabled = false;
            textI.Enabled = false;
            trackBarI.Enabled = false;
            button1.Enabled = false;
            DisableDisplays();
        }
        
        private void trackBarI_Scroll(object sender, EventArgs e)
        {
            DisableDisplays();
            textI.Text = ((double)trackBarI.Value / 1000).ToString("#.000");
        }

        private void textA_TextChanged(object sender, EventArgs e)
        {
            DisableDisplays();

            double a;
            if (!double.TryParse(textA.Text, out a))
            {
                textA.Text = "0";
            }
            double b = double.Parse(textB.Text);
            if (a < b - tiny)
            {
                EnableIntegral();

                double interval = double.Parse(textI.Text);
                interval = interval > b - a ? b - a : interval;
                textI.Text = interval.ToString();
                textNB.Text = ((int)((b - a) / interval) + 1).ToString();
            }
            else
                DisableIntegral();
        }

        private void textB_TextChanged(object sender, EventArgs e)
        {
            DisableDisplays();

            double b;
            if (!double.TryParse(textB.Text, out b))
            {
                textB.Text = "0";
            }
            double a = double.Parse(textA.Text);
            if (a < b - tiny)
            {
                EnableIntegral();

                double interval = double.Parse(textI.Text);
                interval = interval > b - a ? b - a : interval;
                textI.Text = interval.ToString();
                textNB.Text = ((int)((b - a) / interval) + 1).ToString();
            }
            else
                DisableIntegral();
        }

        private void textI_TextChanged(object sender, EventArgs e)
        {
            DisableDisplays();

            double interval;
            if (!double.TryParse(textI.Text, out interval))
                interval = 1;

            double a = double.Parse(textA.Text);
            double b = double.Parse(textB.Text);

            double max = (double)trackBarI.Maximum / 1000;
            double min = (double)trackBarI.Minimum / 1000;

            int nb_max = 10000;
            int nb_min = 2;

            interval = interval > max ? max : interval;
            interval = interval > b - a ? b - a : interval;
            interval = interval < min ? min : interval;

            int nb = (int)((b - a) / interval) + 1;
            if (nb < nb_min)
                interval = (b - a) / (nb_min - 1);
            if (nb > nb_max)
                interval = (b - a) / (nb_max - 1);

            trackBarI.Value = (int)(interval * 1000);

            textI.Text = interval.ToString();
            textI.SelectionStart = textI.TextLength;
            textI.SelectionLength = 0;

            textNB.Text = ((int)(((b - a) / interval) + 1)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chart1.Series[0].IsVisibleInLegend && !chart1.Series["RectangleRule"].IsVisibleInLegend)
            {
                Series rect = chart1.Series["RectangleRule"];
                Series curve = chart1.Series[0];
                rect.ChartType = SeriesChartType.Column;
                rect.Color = Color.FromArgb(50, 255, 0, 0);
                rect.IsVisibleInLegend = true;
                rect["PointWidth"] = additional_points.ToString();
                double a = double.Parse(textA.Text);
                double b = double.Parse(textB.Text);
                double n = double.Parse(textI.Text);

                Func<double, double> f = Function;

                double y;
                try
                {
                    rect.LegendText = "Rectangle rule: Student area is " + integral.Integral.CompositeIntegralRectangleRule(a, b, n, f).ToString();
                }
                catch (Exception ex)
                {
                    if (ex is NotImplementedException)
                    {
                        rect.LegendText = "Rectangle rule: not implemented";
                    }
                    else if (ex is OverflowException)
                    {
                        rect.LegendText = "Rectangle rule: overflow caught";
                    }
                    else
                        rect.LegendText = "Rectangle rule: " + ex.Message;
                }

                for (int i = 0; i < curve.Points.Count - additional_points; i += additional_points)
                {
                    y = curve.Points[i].YValues[0];
                    for (int j = 0; j < additional_points; ++j)
                    {
                        rect.Points.AddXY(curve.Points[i + j].XValue, y);
                        if (j != additional_points / 2)
                            rect.Points.Last().IsEmpty = true;
                    }
                }
                rect.Points.AddXY(curve.Points[curve.Points.Count - 1].XValue, 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (chart1.Series[0].IsVisibleInLegend && !chart1.Series["TrapezoidalRule"].IsVisibleInLegend)
            {
                Series trap = chart1.Series["TrapezoidalRule"];
                Series curve = chart1.Series[0];
                int len = curve.Points.Count;
                trap.ChartType = SeriesChartType.Line;
                trap.Color = Color.FromArgb(100, 0, 255, 0);
                trap.IsVisibleInLegend = true;
                double a = double.Parse(textA.Text);
                double b = double.Parse(textB.Text);
                double n = double.Parse(textI.Text);

                Func<double, double> f = Function;

                double y1;
                double y2;
                try
                {
                    trap.LegendText = "Trapezoidal rule: Student area is " + integral.Integral.CompositeIntegralTrapezoidalRule(a, b, n, f).ToString();
                }
                catch (Exception ex)
                {
                    if (ex is NotImplementedException)
                    {
                        trap.LegendText = "Trapezoidal rule: not implemented";
                    }
                    else if (ex is OverflowException)
                    {
                        trap.LegendText = "Trapezoidal rule: overflow caught";
                    }
                    else
                        trap.LegendText = "Trapezoidal rule: " + ex.Message;
                }

                for (int i = 0; i < curve.Points.Count - additional_points; i += additional_points)
                {
                    y1 = curve.Points[i].YValues[0];
                    y2 = curve.Points[i + additional_points].YValues[0];

                    trap.Points.AddXY(curve.Points[i].XValue, y1);

                    for (int j = 1; j < additional_points; ++j)
                        trap.Points.AddXY(curve.Points[i + j].XValue, (y1 * (additional_points - j) + y2 * j) / additional_points);
                }
                trap.Points.AddXY(curve.Points[len - 1].XValue, curve.Points[len - 1].YValues[0]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (chart1.Series[0].IsVisibleInLegend && !chart1.Series["SimpsonRule"].IsVisibleInLegend)
            {
                Series simp = chart1.Series["SimpsonRule"];
                Series curve = chart1.Series[0];
                int len = curve.Points.Count;
                simp.ChartType = SeriesChartType.Line;
                simp.Color = Color.FromArgb(100, 150, 100, 200);
                simp.IsVisibleInLegend = true;
                double a = double.Parse(textA.Text);
                double b = double.Parse(textB.Text);
                double n = double.Parse(textI.Text);

                Func<double, double> f = Function;

                double part1;
                double part2;
                double part3;
                DataPoint pa;
                DataPoint pb;
                DataPoint pm;
                double x;
                double y;
                try
                {
                    simp.LegendText = "Simpson's rule: Student area is " + integral.Integral.CompositeIntegralSimpsonRule(a, b, n, f).ToString();
                }
                catch (Exception ex)
                {
                    if (ex is NotImplementedException)
                    {
                        simp.LegendText = "Simpson's rule: not implemented";
                    }
                    else if (ex is OverflowException)
                    {
                        simp.LegendText = "Simpson's rule: overflow caught";
                    }
                    else
                        simp.LegendText = "Simpson's rule: " + ex.Message;
                }

                for (int i = 0; i < curve.Points.Count - additional_points; i += additional_points)
                {
                    pa = curve.Points[i];
                    pb = curve.Points[i + additional_points];
                    pm = curve.Points[i + additional_points / 2];

                    simp.Points.AddXY(pa.XValue, pa.YValues[0]);

                    for (int j = 1; j < additional_points; ++j)
                    {
                        x = curve.Points[i + j].XValue;
                        part1 = pa.YValues[0] * ((x - pm.XValue) * (x - pb.XValue)) / ((pa.XValue - pm.XValue) * (pa.XValue - pb.XValue));
                        part2 = pm.YValues[0] * ((x - pa.XValue) * (x - pb.XValue)) / ((pm.XValue - pa.XValue) * (pm.XValue - pb.XValue));
                        part3 = pb.YValues[0] * ((x - pa.XValue) * (x - pm.XValue)) / ((pb.XValue - pa.XValue) * (pb.XValue - pm.XValue));
                        y = part1 + part2 + part3;
                        simp.Points.AddXY(x, y);
                    }
                }
                simp.Points.AddXY(curve.Points[len - 1].XValue, curve.Points[len - 1].YValues[0]);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (chart1.Series["NewtonQuadrature"].IsVisibleInLegend)
            {
                chart1.Series["NewtonQuadrature"].IsVisibleInLegend = false;
                chart1.Series["NewtonQuadrature"].Points.Clear();
            }
            if (chart1.Series[0].IsVisibleInLegend)
            {
                Series simp = chart1.Series["NewtonQuadrature"];
                Series curve = chart1.Series[0];
                int len = curve.Points.Count;
                simp.ChartType = SeriesChartType.Line;
                simp.Color = Color.FromArgb(100, 150, 200, 100);
                simp.IsVisibleInLegend = true;
                double a = double.Parse(textA.Text);
                double b = double.Parse(textB.Text);
                double n = double.Parse(textI.Text);
                string text = textBox1.Text;
                int d = (int)numericUpDown1.Value;
                double result = 0;
                double product_of_factors = 1;

                Func<double, double> f = Function;
                
                DataPoint pa;
                DataPoint pb;
                simp.LegendText = "degree " + d + " ";
                try
                {
                    simp.LegendText += "Newton quadrature: Student area is " + newton.NewtonQuadrature.CompositeIntegralNewtonQuadrature(a, b, n, d, f).ToString();
                }
                catch (Exception ex)
                {
                    if (ex is NotImplementedException)
                    {
                        simp.LegendText += "Newton quadrature: not implemented";
                    }
                    else if (ex is OverflowException)
                    {
                        simp.LegendText += "Newton quadrature: overflow caught";
                    }
                    else
                        simp.LegendText += "Newton quadrature: " + ex.Message;
                }

                Argument x;
                Expression exp;

                for (int i = 0; i < curve.Points.Count - additional_points; i += additional_points)
                {

                    pa = curve.Points[i];
                    pb = curve.Points[i + additional_points];

                    for (int index_point = 0; index_point < additional_points; ++index_point)
                    {
                        double xi = curve.Points[i + index_point].XValue;
                        result = 0;

                        for (int j = 0; j <= d; ++j)
                        {
                            double xj = pa.XValue + j * (pb.XValue - pa.XValue) / d;
                            x = new Argument("x = " + xj);
                            exp = new Expression(text, x);
                            product_of_factors = 1;

                            for (int k = 0; k <= d; ++k)
                            {
                                double xk = pa.XValue + k * (pb.XValue - pa.XValue) / d;
                                if (k != j)
                                {
                                    product_of_factors *= (xi - xk) / (xj - xk);
                                }
                            }

                            result += exp.calculate() * product_of_factors;
                        }
                        simp.Points.AddXY(xi, result);
                    }
                }
                simp.Points.AddXY(curve.Points[len - 1].XValue, curve.Points[len - 1].YValues[0]);
            }
        }

        private double Function(double x)
        {
            try
            {
                return chart1.Series[0].Points.FindByValue(x, "X").YValues[0];
            }
            catch(Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    string text = textBox1.Text;
                    Argument arg = new Argument("x = " + x);
                    Expression exp = new Expression(text, arg);
                    return exp.calculate();
                }
                else throw ex;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DisableDisplays();
        }
    }
}
