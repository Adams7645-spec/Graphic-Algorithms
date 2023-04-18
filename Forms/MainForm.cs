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

        private int MouseX;
        private int MouseY;

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
            CanvasPictureBox.Invalidate();
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

        //Canvas
        private void CanvasPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Вызывать в отдельном методе
            Graphics Canvas = CanvasPictureBox.CreateGraphics();
            Brush brush = Brushes.Black;
            Pen pen = new Pen(brush);
            Canvas.DrawEllipse(pen, 50, 50, 10, 10);
        }

        private void CanvasPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }
    }
}
