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
    public class Cell
    {
        public Cell(int col, int row, CellSide rightWall, CellSide bottomWall, Map map)
        {
            this.myColumn = col;
            this.myRow = row;
            this.myRightWall = rightWall;
            this.myBottomWall = bottomWall;
            this.myMap = map;
        }

        public Map myMap { get; set; }
        public Bitmap myBgImage { get; set; }
        public bool hasMinotaur { get; set; }
        public bool hasTheseus { get; set; }
        public bool isExit { get; set; }
        public int mySize { get; set; }
        public CellSide myRightWall { get; set; }
        public CellSide myBottomWall { get; set; }
        public int myColumn { get; set; }
        public int myRow { get; set; }
    }

    public class CellSide
    {
        public CellSide(int hasWall, bool highlighted)
        {
            this.hasWall = hasWall;
            this.isHighlighted = highlighted;
        }

        public bool isHighlighted { get; set; }
        public int hasWall { get; set; }
    }
}