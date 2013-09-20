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
    public class MouseEventHandler
    {
        public MapController myMapController { get; set; }
        public MouseEventHandler(MapController mapController)
        {
            this.myMapController = mapController;
        }

        public void onMouseHover(MouseEventArgs e, List<Cell> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int column = mapData[0];
                int row = mapData[1];
                int right = mapData[2];
                int bottom = mapData[3];
                int forgiveness = 10;

                if (e.X > column + myMapController.myMap.myCellSize - forgiveness &&
                    e.X < column + myMapController.myMap.myCellSize + forgiveness &&
                    e.Y > row && e.Y < row + myMapController.myMap.myCellSize)
                {
                    myMapController.myMap.myCells[i].myRightWall.isHighlighted = true;
                }
                else
                {
                    myMapController.myMap.myCells[i].myRightWall.isHighlighted = false;
                }

                if (e.Y > row + myMapController.myMap.myCellSize - forgiveness &&
                    e.Y < row + myMapController.myMap.myCellSize + forgiveness &&
                    e.X > column && e.X < column + myMapController.myMap.myCellSize)
                {
                    myMapController.myMap.myCells[i].myBottomWall.isHighlighted = true;
                }
                else
                {
                    myMapController.myMap.myCells[i].myBottomWall.isHighlighted = false;
                }
            }
        }

        public void setMinotaur(DragEventArgs e, List<Cell> cells)
        { 
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int column = mapData[0];
                int row = mapData[1];
                int right = mapData[2];
                int bottom = mapData[3];

                Point RelativeMouseLoc = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);
                
                if (RelativeMouseLoc.X > column &&
                    RelativeMouseLoc.X < column + myMapController.myMap.myCellSize
                    && RelativeMouseLoc.Y > row && RelativeMouseLoc.Y <
                    row + myMapController.myMap.myCellSize)
                {
                    myMapController.myMap.myCells[i].hasMinotaur = true;
                }
                else
                {
                    myMapController.myMap.myCells[i].hasMinotaur = false;
                }
            }
        }

        public void setTheseus(DragEventArgs e, List<Cell> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int column = mapData[0];
                int row = mapData[1];
                int right = mapData[2];
                int bottom = mapData[3];

                Point RelativeMouseLoc = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);

                if (RelativeMouseLoc.X > column &&
                    RelativeMouseLoc.X < column + myMapController.myMap.myCellSize
                    && RelativeMouseLoc.Y > row && RelativeMouseLoc.Y <
                    row + myMapController.myMap.myCellSize)
                {
                    myMapController.myMap.myCells[i].hasTheseus = true;
                }
                else
                {
                    myMapController.myMap.myCells[i].hasTheseus = false;
                }
            }
        }

        public void setExit(DragEventArgs e, List<Cell> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int column = mapData[0];
                int row = mapData[1];
                int right = mapData[2];
                int bottom = mapData[3];

                Point RelativeMouseLoc = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);

                if (RelativeMouseLoc.X > column &&
                    RelativeMouseLoc.X < column + myMapController.myMap.myCellSize
                    && RelativeMouseLoc.Y > row && RelativeMouseLoc.Y <
                    row + myMapController.myMap.myCellSize)
                {
                    myMapController.myMap.myCells[i].isExit = true;
                }
                else
                {
                    myMapController.myMap.myCells[i].isExit = false;
                }
            }
        }

        public void editCell(MouseEventArgs e, List<Cell> cells)
        {
            Point mouse = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);

            int col = (mouse.X - myMapController.myMap.boardXPos) / myMapController.myMap.myCellSize;
            int row = (mouse.Y - myMapController.myMap.boardYPos) / myMapController.myMap.myCellSize;
            int startOfCol = (col * myMapController.myMap.myCellSize) + myMapController.myMap.boardXPos;
            int endOfCol = startOfCol + myMapController.myMap.myCellSize;
            int startOfRow = (row * myMapController.myMap.myCellSize) + myMapController.myMap.boardYPos;
            int endOfRow = startOfRow + myMapController.myMap.myCellSize;

            for (int i = 0; i < cells.Count; i++)
            {
                Cell cell = myMapController.myMap.myCells[i];
               
                if (mouse.X > startOfCol && mouse.X < endOfCol &&
                    mouse.Y > startOfRow && mouse.Y < endOfRow)
                {
                    int index = cells.FindIndex(item => item.myColumn == col && item.myRow == row);
                    if (index >= 0)
                    {

                        if (cell.myColumn == col && cell.myRow == row)
                        {
                            cells.Remove(cell);
                            return;
                        }
                    }
                    else
                    {
                        Bitmap image = myMapController.myMap.cellBgImage;
                        cells.Add(new Cell(col, row, new CellSide(0, false), new CellSide(0, false), myMapController.myMap, image));
                        return;
                    }
                }
            }
        }


        public void onMouseClick(MouseEventArgs e, List<Cell> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int column = mapData[0];
                int row = mapData[1];
                int right = mapData[2];
                int bottom = mapData[3];
                int forgiveness = 10;

                if (e.X > column + myMapController.myMap.myCellSize - forgiveness &&
                    e.X < column + myMapController.myMap.myCellSize + forgiveness &&
                    e.Y > row && e.Y < row + myMapController.myMap.myCellSize)
                {
                    if (myMapController.myMap.myCells[i].myRightWall.hasWall == 1)
                    {
                        myMapController.myMap.myCells[i].myRightWall.hasWall = 0;
                    }
                    else
                    {
                        myMapController.myMap.myCells[i].myRightWall.hasWall = 1;
                    }
                }

                if (e.Y > row + myMapController.myMap.myCellSize - forgiveness &&
                    e.Y < row + myMapController.myMap.myCellSize + forgiveness &&
                    e.X > column && e.X < column + myMapController.myMap.myCellSize)
                {
                    if (myMapController.myMap.myCells[i].myBottomWall.hasWall == 1)
                    {
                        myMapController.myMap.myCells[i].myBottomWall.hasWall = 0;
                    }
                    else
                    {
                        myMapController.myMap.myCells[i].myBottomWall.hasWall = 1;
                    }
                }
            }
        }
    }
}