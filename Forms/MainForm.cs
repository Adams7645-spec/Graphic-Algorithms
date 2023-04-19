using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GraphicAlgorithms
{
    public partial class MainForm : Form
    {
        private bool isSettingsOpened = false;
        private bool isCanvasActive = false;

        private int ActionSpeed = 0;
        private int PixelDensity = 0;
        private AlgorithmEnum SelectedAlgorithm;
        private ShapeEnum SelectedShape;

        private (int, int) CurrentPair = (0, 0);
        private int CurrentSteep = 0;

        private List<Point> PointList = new List<Point> { };
        private List<Thread> ThreadList = new List<Thread> { };
        private enum AlgorithmEnum
        {
            Brasenhem,
            Bizier,
            ShapeFilling
        }
        private enum ShapeEnum
        {
            Square,
            Circle,
            Curve,
            NoShape
        }

        public MainForm()
        {
            InitializeComponent();
        }

        //Buttons
        private void button_Settings_Click(object sender, EventArgs e)
        {
            if (isSettingsOpened)
            {
                isSettingsOpened = false;
                panel_Settings.Visible = !Visible;
                panel_Settings.Enabled = !Enabled;
            }
            else
            {
                isSettingsOpened = true;
                panel_Settings.Visible = Visible;
                panel_Settings.Enabled = Enabled;
            }
        }
        private void button_Clear_Click(object sender, EventArgs e)
        {
            CurrentSteep = 0;
            PointList.Clear();
            KillThreads(ThreadList);
            CanvasPictureBox.Invalidate();
        }

        //Radio Buttons
        private void uirb_Square_Click(object sender, EventArgs e)
        {
            uirb_Circle.Checked = false;
            uirb_Curve.Checked = false;
            uirb_none.Checked = false;

            SelectedShape = ShapeEnum.Square;
            CurrentSteep = 0;
            PointList.Clear();
        }
        private void uirb_Circle_Click(object sender, EventArgs e)
        {
            uirb_Square.Checked = false;
            uirb_Curve.Checked = false;
            uirb_none.Checked = false;

            SelectedShape = ShapeEnum.Circle;
            CurrentSteep = 0;
            PointList.Clear();
        }
        private void uirb_Curve_Click(object sender, EventArgs e)
        {
            uirb_Square.Checked = false;
            uirb_Circle.Checked = false;
            uirb_none.Checked = false;

            SelectedShape = ShapeEnum.Curve;
            CurrentSteep = 0;
            PointList.Clear();
        }
        private void uirb_none_Click(object sender, EventArgs e)
        {
            uirb_Square.Checked = false;
            uirb_Circle.Checked = false;
            uirb_Curve.Checked = false;

            SelectedShape = ShapeEnum.NoShape;
            CurrentSteep = 0;
            PointList.Clear();
        }
        private void uirb_Brasenhem_CheckedChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = AlgorithmEnum.Brasenhem;
            PointList.Clear();
            CurrentSteep = 0;
            isCanvasActive = true;

            uirb_Curve.UnCheckedColor = Color.Gray;
            uirb_Square.UnCheckedColor = Color.Black;
            uirb_Circle.UnCheckedColor = Color.Black;

            uirb_Curve.Enabled = false;
            uirb_Square.Enabled = true;
            uirb_Circle.Enabled = true;
        }
        private void uirb_Bizier_CheckedChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = AlgorithmEnum.Bizier;
            PointList.Clear();
            CurrentSteep = 0;
            isCanvasActive = true;

            uirb_Curve.UnCheckedColor = Color.Black;
            uirb_Square.UnCheckedColor = Color.Gray;
            uirb_Circle.UnCheckedColor = Color.Gray;

            uirb_Curve.Enabled = true;
            uirb_Square.Enabled = false;
            uirb_Circle.Enabled = false;
        }
        private void uirb_ShapeFilling_CheckedChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = AlgorithmEnum.ShapeFilling;
            PointList.Clear();
            CurrentSteep = 0;
            isCanvasActive = true;

            uirb_Curve.UnCheckedColor = Color.Gray;
            uirb_Square.UnCheckedColor = Color.Gray;
            uirb_Circle.UnCheckedColor = Color.Gray;

            uirb_Curve.Enabled = false;
            uirb_Square.Enabled = false;
            uirb_Circle.Enabled = false;
        }

        //Track Bars
        private void trackBar_ActionSpeed_Scroll(object sender, EventArgs e)
        {
            ActionSpeed = trackBar_ActionSpeed.Value;
            label_ActionSpeed.Text = ActionSpeed.ToString();
        }
        private void trackBar_PixelDensity_Scroll(object sender, EventArgs e)
        {
            PixelDensity = trackBar_PixelDensity.Value;
            label_PixelDensity.Text = PixelDensity.ToString();
        }

        //Canvas
        private void CanvasPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }
        public void SetPixel(int X, int Y)
        {
            Graphics Canvas = CanvasPictureBox.CreateGraphics();
            Brush brush = Brushes.Black;
            Pen pen = new Pen(brush);
            Canvas.DrawEllipse(pen, X, Y, 1, 1);
        }

        //Draw at new thread
        private void BrasenhemLine()
        {
            if (PointList.Count % 2 == 0)
            {
                CurrentPair = (CurrentSteep - 1, CurrentSteep);
                ThreadStart brasLine = new ThreadStart(
                    delegate
                    {
                        DrawBrasenhemLine(PointList[CurrentPair.Item1], PointList[CurrentPair.Item2]);
                    });
                Thread thread = new Thread(brasLine);
                ThreadList.Add(thread);
                thread.Start();
            }

            CurrentSteep++;
        }
        private void BrasenhemCircle() //circle 
        {
            // радиус вычислить между первой и второй точкой
            if (PointList.Count % 2 == 0)
            {
                CurrentPair = (CurrentSteep - 1, CurrentSteep);
                ThreadStart brasLine = new ThreadStart(
                    delegate
                    {
                        DrawBrasenhemCircle(PointList[CurrentPair.Item1], PointList[CurrentPair.Item2]);
                    });
                Thread thread = new Thread(brasLine);
                ThreadList.Add(thread);
                thread.Start();
            }

            CurrentSteep++;
        }

        //Stuff
        private void CanvasPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (isCanvasActive)
            {
                SetPixel(e.X, e.Y);

                switch (SelectedAlgorithm)
                {
                    case AlgorithmEnum.Brasenhem:
                        PointList.Add(new Point(e.X, e.Y));
                        switch (SelectedShape)
                        {
                            case ShapeEnum.Square:
                                break;
                            case ShapeEnum.Circle:
                                BrasenhemCircle();
                                break;
                            case ShapeEnum.Curve:
                                break;
                            case ShapeEnum.NoShape:
                                BrasenhemLine();
                                break;
                        }
                        break;
                    case AlgorithmEnum.Bizier:
                        //BizierCurve();
                        break;
                    case AlgorithmEnum.ShapeFilling:
                        //ShapeFilling();
                        break;
                }
            }
        }
        private void KillThreads(List<Thread> threads)
        {
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Abort();
            }
            threads.Clear();
        }
        private void DrawBrasenhemLine(Point StartPoint, Point EndPoint)
        {
            int w = EndPoint.X - StartPoint.X;
            int h = EndPoint.Y - StartPoint.Y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;

            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);

            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;

            for (int i = 0; i <= longest; i++)
            {
                Thread.Sleep(ActionSpeed);
                SetPixel(StartPoint.X, StartPoint.Y);

                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    StartPoint.X += dx1;
                    StartPoint.Y += dy1;
                }
                else
                {
                    StartPoint.X += dx2;
                    StartPoint.Y += dy2;
                }
            }
        }
        private void DrawBrasenhemCircle(Point StartPoint, Point EndPoint)
        {
            int radiusX = Convert.ToInt32(Math.Pow(EndPoint.X - StartPoint.X, 2));
            int radiusY = Convert.ToInt32(Math.Pow(EndPoint.Y - StartPoint.Y, 2));
            int radXY = radiusX + radiusY;
            int CircleRadius = Convert.ToInt32(Math.Sqrt(radXY));

            int x = 0, y = CircleRadius;
            int d = 3 - 2 * CircleRadius;
            DrawCircle(StartPoint.X, StartPoint.Y, x, y);
            while (y >= x)
            {
                Thread.Sleep(ActionSpeed);
                x++;
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                    d = d + 4 * x + 6;
                DrawCircle(StartPoint.X, StartPoint.Y, x, y);
            }
        }
        private void DrawCircle(int xc, int yc, int x, int y)
        {
            SetPixel(xc + x, yc + y);
            SetPixel(xc - x, yc + y);
            SetPixel(xc + x, yc - y);
            SetPixel(xc - x, yc - y);
            SetPixel(xc + y, yc + x);
            SetPixel(xc - y, yc + x);
            SetPixel(xc + y, yc - x);
            SetPixel(xc - y, yc - x);
        }
    }
}