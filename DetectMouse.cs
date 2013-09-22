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
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];
                int forgiveness = 10;

                if (e.X > endOfCol - forgiveness &&
                    e.X < endOfCol + forgiveness &&
                    e.Y > startOfRow && e.Y < endOfRow)
                {
                    myMapController.myMap.myCells[i].myRightWall.isHighlighted = true;
                }
                else
                {
                    myMapController.myMap.myCells[i].myRightWall.isHighlighted = false;
                }

                if (e.Y > endOfRow - forgiveness &&
                    e.Y < endOfRow + forgiveness &&
                    e.X > startOfCol && e.X < endOfCol)
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
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];

                Point RelativeMouseLoc = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);

                if (RelativeMouseLoc.X > startOfCol &&
                    RelativeMouseLoc.X < endOfCol
                    && RelativeMouseLoc.Y > startOfRow && RelativeMouseLoc.Y <
                    endOfRow)
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
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];

                Point RelativeMouseLoc = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);

                if (RelativeMouseLoc.X > startOfCol &&
                    RelativeMouseLoc.X < endOfCol
                    && RelativeMouseLoc.Y > startOfRow && RelativeMouseLoc.Y <
                    endOfRow)
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
            Point mouse = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);
            int col = (mouse.X - myMapController.myMap.boardXPos) / myMapController.myMap.myCellSize;
            int row = (mouse.Y - myMapController.myMap.boardYPos) / myMapController.myMap.myCellSize;

            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];

                Cell cell = myMapController.myMap.myCells[i];
                int index = cells.FindIndex(item => item.myColumn == col && item.myRow == row);
                if (index >= 0)
                {
                    if (cell.myColumn == col && cell.myRow == row)
                    {
                        cell.isExit = true;
                    }
                    else
                    {
                        cell.isExit = false;
                    }
                }
                
            }
        }

        public void editCell(MouseEventArgs e, List<Cell> cells)
        {
            Point mouse = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);

            int col = (mouse.X - myMapController.myMap.boardXPos) / myMapController.myMap.myCellSize;
            int row = (mouse.Y - myMapController.myMap.boardYPos) / myMapController.myMap.myCellSize;

            for (int i = 0; i < cells.Count; i++)
            {
                Cell cell = myMapController.myMap.myCells[i];
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

        public void onMouseClick(MouseEventArgs e, List<Cell> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, cells);
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];
                int forgiveness = 10;

                if (e.X > endOfCol - forgiveness &&
                    e.X < endOfCol + forgiveness &&
                    e.Y > startOfRow && e.Y < endOfRow)
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

                if (e.Y > endOfRow - forgiveness &&
                    e.Y < endOfRow + forgiveness &&
                    e.X > startOfCol && e.X < endOfCol)
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