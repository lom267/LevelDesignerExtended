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
    public class Map
    {
        public Map()
        {
        }

        public int rows { get; set; }
        public int cols { get; set; }
        public int boardXPos { get; set; }
        public int boardYPos { get; set; }
        public int myCellSize { get; set; }
        public Bitmap cellBgImage { get; set; }
        public Bitmap minotaur { get; set; }
        public Bitmap theseus { get; set; }
        public Bitmap exitImage { get; set; }
        public string exitCellPlacement { get; set; }
        public int myWidth { get; set; }
        public int myHeight { get; set; }
        private List<Cell> m_cells = new List<Cell>();
        public List<Cell> myCells
        {
            get
            {
                return m_cells;
            }
            set
            {
                m_cells = value;
            }
        }
    }
}