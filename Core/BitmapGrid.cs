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
    internal class BitmapGrid
    {
        private int CellSize;
        private int width;
        private int height;
        private List<Point> cells;
        public readonly int gridWidth;
        public readonly int gridHeight;
        public BitmapGrid(int CellSize, int BitmapWidth, int BitmapHeight)
        {
            //
            //  CellSize = PixelDensity
            //
            this.CellSize = CellSize;
            this.width = BitmapWidth;
            this.height = BitmapHeight;
            cells = new List<Point>();
            for (int y = 0; y < BitmapHeight && y + CellSize < BitmapHeight; y += CellSize)
            {
                gridWidth++;
                for (int x = 0; x < BitmapWidth && x + CellSize < BitmapWidth; x += CellSize)
                {
                    gridHeight++;
                    cells.Add(new Point(x, y));
                }
            }
        }

        public Point GetCell(int x, int y)
        {
            int cellX = x / CellSize;
            int cellY = y / CellSize;
            try
            {
                return cells[cellY * (width / CellSize) + cellX];
            }
            catch
            {
                return cells[0];
            }
        }

        public void FillCell(int x, int y, Color color, Bitmap bitmap)
        {
            Point cell = GetCell(x, y);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(color), cell.X, cell.Y, CellSize, CellSize);
            }
        }
    }
}
