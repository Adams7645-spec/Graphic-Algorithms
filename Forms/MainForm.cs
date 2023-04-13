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
        private int ActionSpeed = 0;
        private int PixelDensity = 0;
        private int SelectedAlgorithm = 0;
        private List<Point> PointList = new List<Point> { };
        private Thread FrameThread;
        private enum AlgorithmEnum
        {
            Brasenhem,
            Bizier,
            ShapeFilling
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
            PointList.Clear();
            CanvasPanel.Invalidate();
        }

        //Radio Buttons
        private void uirb_Square_Click(object sender, EventArgs e)
        {
            uirb_Circle.Checked = false;
            uirb_Curve.Checked = false;
            uirb_none.Checked = false;
        }
        private void uirb_Circle_Click(object sender, EventArgs e)
        {
            uirb_Square.Checked = false;
            uirb_Curve.Checked = false;
            uirb_none.Checked = false;
        }
        private void uirb_Curve_Click(object sender, EventArgs e)
        {
            uirb_Square.Checked = false;
            uirb_Circle.Checked = false;
            uirb_none.Checked = false;
        }
        private void uirb_none_Click(object sender, EventArgs e)
        {
            uirb_Square.Checked = false;
            uirb_Circle.Checked = false;
            uirb_Curve.Checked = false;
        }
        private void uirb_Brasenhem_CheckedChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = ((int)AlgorithmEnum.Brasenhem);
        }
        private void uirb_Bizier_CheckedChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = ((int)AlgorithmEnum.Bizier);
        }
        private void uirb_ShapeFilling_CheckedChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = ((int)AlgorithmEnum.ShapeFilling);
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

        //Panels
        private void CanvasPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            PointList.Add(point);
            CanvasPanel.Invalidate();
        }
        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CanvasPanel.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5f);
            if (PointList.Count != 0)
            {
                for (int i = 0; i < PointList.Count; i++)
                {
                    graphics.DrawEllipse(pen, PointList[i].X, PointList[i].Y, 3f, 3f);
                }
            }
            if (PointList.Count == 2)
            {
                BresLineOrig(PointList[0], PointList[1]);
            }
        }
        private IEnumerable<Point> BresLineOrig(Point begin, Point end)
        {
            Graphics graphics = CanvasPanel.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Black);
            Point nextPoint = begin;
            int deltax = end.X - begin.X;
            int deltay = end.Y - begin.Y;
            int error = deltax / 2;
            int ystep = 1;

            if (end.Y < begin.Y)
            {
                ystep = -1;
            }

            while (nextPoint.X < end.X)
            {
                if (nextPoint != begin) yield return nextPoint;
                nextPoint.X++;

                error -= deltay;
                if (error < 0)
                {
                    nextPoint.Y += ystep;
                    error += deltax;
                }
                graphics.FillRectangle(brush, nextPoint.X, nextPoint.Y, 1, 1);
                Thread.Sleep(ActionSpeed * 10);
            }
        }
    }
}
