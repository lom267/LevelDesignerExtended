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
    public class MapController
    {
        public Map myMap { get; set; }
        public MapController(Map map)
        {
            this.myMap = map;
        }

        private void setCells()
        {
            myMap.myCells.Clear();
            for (int row = 0; row < myMap.rows; row++)
            {
                for (int col = 0; col < myMap.cols; col++)
                {
                    myMap.myCells.Add(new Cell(col, row, new CellSide(0, false), new CellSide(0, false), myMap));
                }
            }
        }

        private int getLargestOutOfRowsAndCols()
        {
            if (myMap.cols > myMap.rows)
            {
                return myMap.cols;
            }
            else
            {
                return myMap.rows;
            }
        }
        
        private void setCellSize()
        {
            try
            {
                //We have to subtract 1 from the cellSize to allow for the thick outer pen lines
                //The plus 1 leaves room for one more cell for the exit
                double cellSize = (myMap.myForm.pbxMap.Width / getLargestOutOfRowsAndCols()) - 2 ;
                Math.Round(cellSize, 0);
                myMap.myCellSize = Convert.ToInt32(cellSize);

                foreach (Cell cell in myMap.myCells)
                {
                    cell.mySize = myMap.myCellSize;
                }
            }
            catch
            {
                myMap.myForm.lblWarning.Text = "Please enter atleast 3 columns and 3 rows.";
            }
        }

        private void setBoardPosition()
        {
            //If these aren't atleast 1, the map edge starts from 
            //off the picturebox because the pen line is thick.
            //They cannot be more than 1 or the map will move off the picturebox.
            //The thick pen line on the outer edge causes this complexity.
            //These -1's come about from the thick outer wall line taking one more pixel on the outside
            double yPos = (myMap.myForm.pbxMap.Height / 2) - (myMap.myHeight / 2) ;
            double Xpos = (myMap.myForm.pbxMap.Width / 2) - (myMap.myWidth / 2) ;
            Math.Round(yPos, 0);
            Math.Round(Xpos, 0);
            myMap.boardXPos = Convert.ToInt32(Xpos);
            myMap.boardYPos = Convert.ToInt32(yPos);
        }

        private void setPbxMapPosition()
        {
            double yPos = (myMap.myForm.panel2.Height / 2) - (myMap.myForm.pbxMap.Height / 2) - 1;
            double Xpos = (myMap.myForm.panel2.Width / 2) - (myMap.myForm.pbxMap.Width / 2) - 1;
            Math.Round(yPos, 0);
            Math.Round(Xpos, 0);
            myMap.myForm.pbxMap.Location = new Point(Convert.ToInt32(Xpos), Convert.ToInt32(yPos));
        }
        private void setMapDimensions()
        {
            myMap.rows = Convert.ToInt32(myMap.myForm.numRows.Value);
            myMap.cols = Convert.ToInt32(myMap.myForm.numCols.Value);
        }

        private void setMapLengthAndHeight()
        {
            myMap.myWidth = myMap.myCellSize * myMap.cols;
            myMap.myHeight = myMap.myCellSize * myMap.rows;
        }

        public void setMapComponents()
        {
            setMapDimensions();
            setCellSize();
            setCells();
            setMapLengthAndHeight();
            setBoardPosition();
            setPbxMapPosition();
            setCellBgImage();
        }

        public void setCellBgImage()
        {
            if (myMap.myForm.rbWood.Checked == true)
            {
                myMap.cellBgImage = (Bitmap)Bitmap.FromFile("Images/wood.png");
            }
            else if (myMap.myForm.rbBrick.Checked == true)
            {
                myMap.cellBgImage = (Bitmap)Bitmap.FromFile("Images/brick.png");
            }
            else if (myMap.myForm.rbDiamond.Checked == true)
            {
                myMap.cellBgImage = (Bitmap)Bitmap.FromFile("Images/diamond.png");
            }
            else if (myMap.myForm.rbClay.Checked == true)
            {
                myMap.cellBgImage = (Bitmap)Bitmap.FromFile("Images/clay.png");
            }
            foreach (Cell cell in myMap.myCells)
            {
                cell.myBgImage = myMap.cellBgImage;
            }
        }

        public void setMinotaurImage()
        {
            myMap.minotaur = (Bitmap)Bitmap.FromFile("Images/minotaur.png");
        }

        public void setTheseusImage()
        {
            myMap.theseus = (Bitmap)Bitmap.FromFile("Images/theseus.png");
        }

        public void setExitImage()
        {
            myMap.exitImage = (Bitmap)Bitmap.FromFile("Images/exit.png");
        }

        public int[] getMapData(int i, List<Cell> cell)
        {
            int startOfCol = myMap.boardXPos + myMap.myCells[i].myColumn * myMap.myCellSize;
            int endOfCol = startOfCol + myMap.myCellSize;
            int startOfRow = myMap.boardYPos + myMap.myCells[i].myRow * myMap.myCellSize;
            int endOfRow = startOfRow + myMap.myCellSize;
            int right = myMap.myCells[i].myRightWall.hasWall;
            int bottom = myMap.myCells[i].myBottomWall.hasWall;

            return new int[] { startOfCol, endOfCol, startOfRow, endOfRow, right, bottom };
        }
    }
}
