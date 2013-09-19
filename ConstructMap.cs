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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawCellBgImage(e, cells);

            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int column = mapData[0];
                int row = mapData[1];
                CellSide right = cells[i].myRightWall;
                CellSide bottom = cells[i].myBottomWall;

                g.DrawLine(setPen(right), column + myMapController.myMap.myCellSize,
                row, column + myMapController.myMap.myCellSize, row + myMapController.myMap.myCellSize);

                g.DrawLine(setPen(bottom), column + myMapController.myMap.myCellSize,
                row + myMapController.myMap.myCellSize, column, row + myMapController.myMap.myCellSize);
            }
            drawMapEdges(e);
            drawMinotaur(e, cells);
            drawTheseus(e, cells);
            drawExit(e, cells);
        }

        public void drawMapEdges(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Brushes.Black, 3);

            int cols = myMapController.myMap.cols;
            int rows = myMapController.myMap.rows;
            int boardXPos = myMapController.myMap.boardXPos;
            int boardYPos = myMapController.myMap.boardYPos;
            int squareSize = myMapController.myMap.myCellSize;

            Point[] points = new Point[] 
            { new Point { X = boardXPos - 1, Y = boardYPos }, 
              new Point { X = boardXPos + (squareSize * cols), Y = boardYPos }, 
              new Point { X = boardXPos + (squareSize * cols), Y = boardYPos + (squareSize * rows) }, 
              new Point { X = boardXPos, Y = boardYPos + (squareSize * rows) },
              new Point { X = boardXPos, Y = boardYPos - 1 } };

            g.DrawLines(myPen, points);
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
                int column = mapData[0];
                int row = mapData[1];

                Bitmap cellBG = cells[i].myBgImage;

                g.DrawImage(cellBG, new RectangleF(new Point(column,
                row), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
            }
        }

        public void drawMinotaur(PaintEventArgs e, List<Cell> cells)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int column = mapData[0];
                int row = mapData[1];

                Bitmap minotaur = myMapController.myMap.minotaur;

                if (cells[i].hasMinotaur)
                {
                    g.DrawImage(minotaur, new RectangleF(new Point(column,
                    row), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
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
                int column = mapData[0];
                int row = mapData[1];

                Bitmap theseus = myMapController.myMap.theseus;

                if (cells[i].hasTheseus)
                {
                    g.DrawImage(theseus, new RectangleF(new Point(column,
                    row), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
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
                int column = mapData[0];
                int row = mapData[1];

                Bitmap exit = myMapController.myMap.exitImage;

                if (cells[i].isExit)
                {
                    g.DrawImage(exit, new RectangleF(new Point(column,
                    row), new SizeF(myMapController.myMap.myCellSize, myMapController.myMap.myCellSize)));
                }
            }
        }
    }
}