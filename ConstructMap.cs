using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapDesigner
{
    public class MapConstructor : IMapConstructor
    {
        public MapController myMapController { get; set; }
        public MapConstructor(MapController mapController)
        {
            this.myMapController = mapController;
        }

        public void drawMap(PaintEventArgs e, List<Cell> cells)
        {
            Graphics g = e.Graphics;
            drawCellBgImage(e, cells);
            drawHighlightedSquare(g, cells);

            for (int i = 0; i < cells.Count; i++)
            {
                drawWalls(0, i, cells, g);
            }
            for (int i = 0; i < cells.Count; i++)
            {
                drawWalls(1, i, cells, g);
            }
            drawBorder(cells, g);
            drawMinotaur(e, cells);
            drawTheseus(e, cells);
            drawExit(e, cells);
        }

        void drawWalls(int wall, int i, List<Cell> cells, Graphics g)
        {
            int[] mapData = myMapController.getMapData(i, cells);
            int startOfCol = mapData[0];
            int endOfCol = mapData[1];
            int startOfRow = mapData[2];
            int endOfRow = mapData[3];
            CellSide rightSide = cells[i].myRightWall;
            CellSide bottomSide = cells[i].myBottomWall;

            if (rightSide.hasWall == wall)
            {
                g.DrawLine(setPen(rightSide), endOfCol,
                startOfRow - 1, endOfCol, endOfRow + 1);
            }
            if (bottomSide.hasWall == wall)
            {
                g.DrawLine(setPen(bottomSide), endOfCol + 1,
                endOfRow, startOfCol - 1, endOfRow);
            }
        }

        public Pen setPen(CellSide side)
        {
            Pen myPen = new Pen(Brushes.Black, 3);

            if (side.isHighlighted == true)
            {
                myPen.Color = Color.Red;
                return myPen;
            }

            if (side.hasWall == 0)
            {
                myPen.Color = Color.LightBlue;
                myPen.Width = 1;
            }
            return myPen;
        }

        public void drawCellBgImage(PaintEventArgs e, List<Cell> cells)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int startOfRow = mapData[2];

                Bitmap cellBG = cells[i].myBgImage;

                g.DrawImage(cellBG, new RectangleF(new Point(startOfCol,
                startOfRow), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
            }
        }

        void drawHighlightedSquare(Graphics g, List<Cell> cells)
        {
            Point mouse = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);

            int col = (mouse.X - myMapController.myMap.boardXPos) / myMapController.myMap.myCellSize;
            int row = (mouse.Y - myMapController.myMap.boardYPos) / myMapController.myMap.myCellSize;
            int startOfCol = myMapController.myMap.boardXPos + col * myMapController.myMap.myCellSize;
            int endOfCol = startOfCol + myMapController.myMap.myCellSize;
            int startOfRow = myMapController.myMap.boardYPos + row * myMapController.myMap.myCellSize;
            int endOfRow = startOfRow + myMapController.myMap.myCellSize;
            int leftEdgeOfMap = myMapController.myMap.boardXPos;
            int rightEdgeOfMap = leftEdgeOfMap + myMapController.myMap.myWidth;
            int topEdgeOfMap = myMapController.myMap.boardYPos;
            int bottomEdgeOfMap = topEdgeOfMap + myMapController.myMap.myHeight;

            if (mouse.X > leftEdgeOfMap &&
                mouse.X < rightEdgeOfMap &&
                mouse.Y > topEdgeOfMap &&
                mouse.Y < bottomEdgeOfMap)
            {
                if (mouse.X > startOfCol &&
                    mouse.X < endOfCol &&
                    mouse.Y > startOfRow &&
                    mouse.Y < endOfRow)
                {
                    Brush brush = new SolidBrush(Color.FromArgb(80, 77, 255, 204));
                    g.FillRectangle(brush, startOfCol, startOfRow, myMapController.myMap.myCellSize, myMapController.myMap.myCellSize);
                }
            }
        }

        void drawBorder(List<Cell> cells, Graphics g)
        {
            foreach (Cell cell in myMapController.myMap.myCells)
            {
                int col = cell.myColumn;
                int row = cell.myRow;
                Pen myPen = new Pen(Brushes.Black, 3);
                int startOfCol = myMapController.myMap.boardXPos + col * myMapController.myMap.myCellSize;
                int endOfCol = startOfCol + myMapController.myMap.myCellSize;
                int startOfRow = myMapController.myMap.boardYPos + row * myMapController.myMap.myCellSize;
                int endOfRow = startOfRow + myMapController.myMap.myCellSize;

                int cellToRight = cells.FindIndex(item => item.myColumn == col + 1 && item.myRow == row);
                if (cellToRight < 0)
                {
                    g.DrawLine(myPen, endOfCol,
                    startOfRow - 1, endOfCol, endOfRow + 1);
                }

                int cellToLeft = cells.FindIndex(item => item.myColumn == col - 1 && item.myRow == row);
                if (cellToLeft < 0)
                {
                    g.DrawLine(myPen, startOfCol,
                    startOfRow - 1, startOfCol, endOfRow + 1);
                }

                int cellAbove = cells.FindIndex(item => item.myColumn == col && item.myRow == row - 1);
                if (cellAbove < 0)
                {
                    g.DrawLine(myPen, startOfCol - 1,
                    startOfRow, endOfCol + 1, startOfRow);
                }

                int cellBelow = cells.FindIndex(item => item.myColumn == col && item.myRow == row + 1);
                if (cellBelow < 0)
                {
                    g.DrawLine(myPen, startOfCol - 1,
                    endOfRow, endOfCol + 1, endOfRow);
                }
            }
        }

        public void drawMinotaur(PaintEventArgs e, List<Cell> cells)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int startOfRow = mapData[2];

                Bitmap minotaur = myMapController.myMap.minotaur;

                if (cells[i].hasMinotaur)
                {
                    g.DrawImage(minotaur, new RectangleF(new Point(startOfCol,
                    startOfRow), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
                }
            }
        }

        public void drawTheseus(PaintEventArgs e, List<Cell> cells)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int startOfRow = mapData[2];

                Bitmap theseus = myMapController.myMap.theseus;

                if (cells[i].hasTheseus)
                {
                    g.DrawImage(theseus, new RectangleF(new Point(startOfCol,
                    startOfRow), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
                }
            }
        }

        public void drawExit(PaintEventArgs e, List<Cell> cells)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int startOfRow = mapData[2];

                Bitmap exit = myMapController.myMap.exitImage;

                if (cells[i].isExit)
                {
                    g.DrawImage(exit, new RectangleF(new Point(startOfCol,
                    startOfRow), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
                }
            }
        }
    }
}