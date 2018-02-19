using System;
using Gtk;
using OxyPlot;
using OxyPlot.GtkSharp;
using OxyPlot.Series;
using OxyPlot.Axes;
using org.mariuszgromada.math.mxparser;

public partial class MainWindow : Gtk.Window
{
    private static double tiny = 0.001;
    private static int additional_points = 10;
    private static PlotModel _chart;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        PlotView plotView = new PlotView();
        this.eventbox1.Add(plotView);

        PlotModel chart = new PlotModel { Title = "" };

        plotView.Model = chart;
        plotView.ShowAll();

        var XAxis = new LinearAxis() { Position = AxisPosition.Bottom, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "X", Key = "X" };
        var YAxis = new LinearAxis() { Position = AxisPosition.Left, MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Y", Key = "Y" };
        chart.Axes.Add(XAxis);
        chart.Axes.Add(YAxis);

        chart.Series.Add(new LineSeries() { Title = textBox1.Text });
        chart.Series.Add(new LineSeries() { Title = "Derivative" });
        chart.Series.Add(new StairStepSeries() { Title = "RectangleRule" });
        chart.Series.Add(new LineSeries() { Title = "TrapezoidalRule" });
        chart.Series.Add(new LineSeries() { Title = "SimpsonRule" });
        chart.Series.Add(new LineSeries() { Title = "NewtonQuadrature" });
        chart.Series.Add(new LineSeries() { Title = "GaussQuadrature" });

        for (int i = 0; i < chart.Series.Count; ++i)
        {
            chart.Series[i].IsVisible = false;
            if (chart.Series[i] is LineSeries)
            {
                (chart.Series[i] as LineSeries).CanTrackerInterpolatePoints = false;
            }
        }

        (chart.Series[0] as LineSeries).CanTrackerInterpolatePoints = true;

        _chart = chart;

        DisableDisplays();
    }

    private void EnableDisplays()
    {
        button2.Sensitive = true;
        button3.Sensitive = true;
        button4.Sensitive = true;
        button5.Sensitive = true;
    }
    private void EnableIntegral()
    {
        textNB.Sensitive = true;
        textI.Sensitive = true;
        trackBarI.Sensitive = true;
        button1.Sensitive = true;
        EnableDisplays();
    }
    private void DisableDisplays()
    {
        button2.Sensitive = false;
        button3.Sensitive = false;
        button4.Sensitive = false;
        button5.Sensitive = false;
    }
    private void DisableIntegral()
    {
        textNB.Sensitive = false;
        textI.Sensitive = false;
        trackBarI.Sensitive = false;
        button1.Sensitive = false;
        DisableDisplays();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        EnableDisplays();

        for (int i = 0; i < _chart.Series.Count; ++i)
        {
            _chart.Series[i].IsVisible = false;
            if (_chart.Series[i] is LineSeries)
                (_chart.Series[i] as LineSeries).Points.Clear();
        }

        _chart.Series[0].IsVisible = true;

        double a = double.Parse(textA.Text);
        double b = double.Parse(textB.Text);
        double interval = double.Parse(textI.Text);
        string text = textBox1.Text;

        Argument x = new Argument("x = " + a);
        Expression exp = new Expression(text, x);
        double tmp = a;
        double subtmp;

        if (exp.checkSyntax())
        {
            _chart.Series[0].Title = text;

            (_chart.Series[0] as LineSeries).Points.Add(new DataPoint(tmp, exp.calculate()));

            while (tmp + interval <= b)
            {
                subtmp = interval / additional_points;

                for (int i = 1; i < additional_points; ++i)
                {
                    x = new Argument("x = " + (tmp + subtmp));
                    exp = new Expression(text, x);

                    (_chart.Series[0] as LineSeries).Points.Add(new DataPoint((tmp + subtmp), exp.calculate()));

                    subtmp += interval / additional_points;
                }
                tmp += interval;

                x = new Argument("x = " + tmp);
                exp = new Expression(text, x);
                (_chart.Series[0] as LineSeries).Points.Add(new DataPoint(tmp, exp.calculate()));
            }
        }
        else
            _chart.Series[0].IsVisible = false;
        _chart.InvalidatePlot(true);
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

        double max = (double)trackBarI.Adjustment.Upper / 1000;
        double min = (double)trackBarI.Adjustment.Lower / 1000;

        double interval;
        double save = -1;
        if (!double.TryParse(textI.Text, out interval))
            interval = min;
        else
            save = double.Parse(textI.Text);

        double a = double.Parse(textA.Text);
        double b = double.Parse(textB.Text);

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

        if (save != interval)
            textI.Text = interval.ToString();
        textI.SelectRegion(textI.SelectionBound, textI.SelectionBound);

        textNB.Text = ((int)(((b - a) / interval) + 1)).ToString();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (_chart.Series[0].IsVisible && !_chart.Series[2].IsVisible)
        {
            Series rect = _chart.Series[2];
            Series curve = _chart.Series[0];
            int len = (curve as LineSeries).Points.Count;
            rect.IsVisible = true;
            double a = double.Parse(textA.Text);
            double b = double.Parse(textB.Text);
            double n = double.Parse(textI.Text);

            Func<double, double> f = Function;

            double y;
            try
            {
                rect.Title = "Rectangle rule: Student area is " + integral.Integral.CompositeIntegralRectangleRule(a, b, n, f).ToString();
            }
            catch (Exception ex)
            {
                if (ex is NotImplementedException)
                {
                    rect.Title = "Rectangle rule: not implemented";
                }
                else if (ex is OverflowException)
                {
                    rect.Title = "Rectangle rule: overflow caught";
                }
                else
                    rect.Title = "Rectangle rule: " + ex.Message;
            }

            int it = 0;

            for (int i = 0; i < (curve as LineSeries).Points.Count - additional_points; i += additional_points)
            {
                y = (curve as LineSeries).Points[i].Y;
                for (int j = 0; j < additional_points; ++j)
                    (rect as StairStepSeries).Points.Add(new DataPoint((curve as LineSeries).Points[i].X, y));
                ++it;
            } 
            (rect as StairStepSeries).Points.Add(new DataPoint((curve as LineSeries).Points[len - 1].X, (curve as LineSeries).Points[len - 1].Y));
        }
        _chart.InvalidatePlot(true);
    }

    private void button5_Click(object sender, EventArgs e)
    {
        if (_chart.Series[0].IsVisible && !_chart.Series[3].IsVisible)
        {
            Series trap = _chart.Series[3];
            Series curve = _chart.Series[0];
            int len = (curve as LineSeries).Points.Count;
            //trap.Background = OxyColor.FromArgb(100, 0, 255, 0);
            trap.IsVisible = true;
            double a = double.Parse(textA.Text);
            double b = double.Parse(textB.Text);
            double n = double.Parse(textI.Text);

            Func<double, double> f = Function;

            double y1;
            double y2;
            try
            {
                trap.Title = "Trapezoidal rule: Student area is " + integral.Integral.CompositeIntegralTrapezoidalRule(a, b, n, f).ToString();
            }
            catch (Exception ex)
            {
                if (ex is NotImplementedException)
                {
                    trap.Title = "Trapezoidal rule: not implemented";
                }
                else if (ex is OverflowException)
                {
                    trap.Title = "Trapezoidal rule: overflow caught";
                }
                else
                    trap.Title = "Trapezoidal rule: " + ex.Message;
            }

            for (int i = 0; i < (curve as LineSeries).Points.Count - additional_points; i += additional_points)
            {
                y1 = (curve as LineSeries).Points[i].Y;
                y2 = (curve as LineSeries).Points[i + additional_points].Y;

                (trap as LineSeries).Points.Add(new DataPoint((curve as LineSeries).Points[i].X, y1));

                for (int j = 1; j < additional_points; ++j)
                    (trap as LineSeries).Points.Add(new DataPoint((curve as LineSeries).Points[i + j].X, (y1 * (additional_points - j) + y2 * j) / additional_points));
            }
            (trap as LineSeries).Points.Add(new DataPoint((curve as LineSeries).Points[len - 1].X, (curve as LineSeries).Points[len - 1].Y));
        }
        _chart.InvalidatePlot(true);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        if (_chart.Series[0].IsVisible && !_chart.Series[4].IsVisible)
        {
            Series simp = _chart.Series[4];
            Series curve = _chart.Series[0];
            int len = (curve as LineSeries).Points.Count;
            //simp.Background = OxyColor.FromArgb(100, 150, 100, 200);
            simp.IsVisible = true;
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
                simp.Title = "Simpson's rule: Student area is " + integral.Integral.CompositeIntegralSimpsonRule(a, b, n, f).ToString();
            }
            catch (Exception ex)
            {
                if (ex is NotImplementedException)
                {
                    simp.Title = "Simpson's rule: not implemented";
                }
                else if (ex is OverflowException)
                {
                    simp.Title = "Simpson's rule: overflow caught";
                }
                else
                    simp.Title = "Simpson's rule: " + ex.Message;
            }

            for (int i = 0; i < (curve as LineSeries).Points.Count - additional_points; i += additional_points)
            {
                pa = (curve as LineSeries).Points[i];
                pb = (curve as LineSeries).Points[i + additional_points];
                pm = (curve as LineSeries).Points[i + additional_points / 2];

                (simp as LineSeries).Points.Add(new DataPoint(pa.X, pa.Y));

                for (int j = 1; j < additional_points; ++j)
                {
                    x = (curve as LineSeries).Points[i + j].X;
                    part1 = pa.Y * ((x - pm.X) * (x - pb.X)) / ((pa.X - pm.X) * (pa.X - pb.X));
                    part2 = pm.Y * ((x - pa.X) * (x - pb.X)) / ((pm.X - pa.X) * (pm.X - pb.X));
                    part3 = pb.Y * ((x - pa.X) * (x - pm.X)) / ((pb.X - pa.X) * (pb.X - pm.X));
                    y = part1 + part2 + part3;
                    (simp as LineSeries).Points.Add(new DataPoint(x, y));
                }
            }
            (simp as LineSeries).Points.Add(new DataPoint((curve as LineSeries).Points[len - 1].X, (curve as LineSeries).Points[len - 1].Y));
        }
        _chart.InvalidatePlot(true);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        if (_chart.Series[5].IsVisible)
        {
            _chart.Series[5].IsVisible = false;
            (_chart.Series[5] as LineSeries).Points.Clear();
        }
        if (_chart.Series[0].IsVisible)
        {
            Series newt = _chart.Series[5];
            Series curve = _chart.Series[0];
            int len = (curve as LineSeries).Points.Count;
            newt.IsVisible = true;
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
            double xi;
            double xj;
            double xk;
            newt.Title = "degree " + d + " ";
            try
            {
                newt.Title += "Newton quadrature: Student area is " + newton.NewtonQuadrature.CompositeIntegralNewtonQuadrature(a, b, n, d, f).ToString();
            }
            catch (Exception ex)
            {
                if (ex is NotImplementedException)
                {
                    newt.Title += "Newton quadrature: not implemented";
                }
                else if (ex is OverflowException)
                {
                    newt.Title += "Newton quadrature: overflow caught";
                }
                else
                    newt.Title += "Newton quadrature: " + ex.Message;
            }

            Argument x;
            Expression exp;

            for (int i = 0; i < (curve as LineSeries).Points.Count - additional_points; i += additional_points)
            {

                pa = (curve as LineSeries).Points[i];
                pb = (curve as LineSeries).Points[i + additional_points];

                for (int index_point = 0; index_point < additional_points; ++index_point)
                {
                    xi = (curve as LineSeries).Points[i + index_point].X;
                    result = 0;

                    for (int j = 0; j <= d; ++j)
                    {
                        xj = pa.X + j * (pb.X - pa.X) / d;
                        x = new Argument("x = " + xj);
                        exp = new Expression(text, x);
                        product_of_factors = 1;

                        for (int k = 0; k <= d; ++k)
                        {
                            xk = pa.X + k * (pb.X - pa.X) / d;
                            if (k != j)
                            {
                                product_of_factors *= (xi - xk) / (xj - xk);
                            }
                        }

                        result += exp.calculate() * product_of_factors;
                    }
                    (newt as LineSeries).Points.Add(new DataPoint(xi, result));
                }
            }
            (newt as LineSeries).Points.Add(new DataPoint((curve as LineSeries).Points[len - 1].X, (curve as LineSeries).Points[len - 1].Y));
        }
        _chart.InvalidatePlot(true);
    }

    private double Function(double x)
    {
        foreach (DataPoint datapoint in (_chart.Series[0] as LineSeries).Points)
        {
            if (datapoint.X == x)
                return datapoint.Y;
        }

        string text = textBox1.Text;
        Argument arg = new Argument("x = " + x);
        Expression exp = new Expression(text, arg);
        return exp.calculate();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        DisableDisplays();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}