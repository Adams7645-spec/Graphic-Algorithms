using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicAlgorithms
{
    internal class UIRadioButton : RadioButton
    {
        private Color checkedColor = Color.MediumAquamarine;
        private Color unCheckedColor = Color.LightGray;

        public Color CheckedColor 
        { 
            get => checkedColor; 
            set
            { 
                checkedColor = value;
                this.Invalidate();
            } 
        }
        public Color UnCheckedColor
        {
            get => unCheckedColor;
            set
            {
                unCheckedColor = value;
                this.Invalidate();
            }
        }
        public UIRadioButton()
        {
            this.MinimumSize = new Size(0, 21);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float borderSize = 18f;
            float checkSize = 12f;
            RectangleF rectBorder = new RectangleF
            {
                X = 0.5f,
                Y = (this.Height - borderSize)/2,
                Width = borderSize,
                Height = borderSize
            };
            RectangleF rectCheck = new RectangleF
            {
                X = rectBorder.X + ((rectBorder.Width - checkSize)/2),
                Y = (this.Height - checkSize) / 2,
                Width = checkSize,
                Height = checkSize
            };
            using (Pen penBorder = new Pen(checkedColor, 1.6f))
            using (SolidBrush brushCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                graphics.Clear(this.BackColor);
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectBorder);
                    graphics.FillEllipse(brushCheck, rectCheck);
                }
                else
                {
                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder, rectBorder);
                }
                graphics.DrawString(this.Text, this.Font, brushText,
                    borderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + 30;
        }
    }
}
