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
    interface IMapConstructor
    {
        void drawMap(PaintEventArgs e, List<Cell> cells);
        void drawMapEdges(PaintEventArgs e);
        Pen setPen(CellSide wall);
    }
}
