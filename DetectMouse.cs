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