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
    public partial class MapDesignerView : Form
    {
        //public Map myMap { get; set; }
        public MapController myMapController { get; set; }
        //public MapConstructor myMapConstructor { get; set; }
        public MouseEventHandler myDetectMouse { get; set; }
        string dragSourceName;
        private PaintEventArgs paint;

        public int rows { get; set; }
        public int cols { get; set; }

        public MapDesignerView()
        {
            //myMap = new Map(this);
            myMapController = new MapController(this);
            //myMapConstructor = new MapConstructor(myMapController);
            myDetectMouse = new MouseEventHandler(myMapController);
            InitializeComponent();

            myMapController.setMinotaurImage();
            myMapController.setTheseusImage();
            myMapController.setExitImage();

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            
            myMapController.setMapComponents();
            pbxMap.Invalidate();

        }

        
        private void pbxMap_Paint(object sender, PaintEventArgs e)
        {
            //Need the first "if" here or somewhere else to stop the error 
            //message coming up before they click the button. It comes up after they click button
            //when they choose 0 rows and cols, from an exception handler in mapController.setCellSize()
            if (this.rows > 0 && this.cols > 0)
            {
                if (this.rows > 2 && this.cols > 2)
                {
                    lblWarning.Text = "";
                    //myMapConstructor.drawMap(e, myMap.myCells);
                    this.paint = e;
                    this.myMapController.drawMap(e);
                }
                else
                {
                    lblWarning.Text = "Please enter atleast 3 columns and 3 rows.";
                }
            }
        }

        private void pbxMap_MouseMove(object sender, MouseEventArgs e)
        {
            //myDetectMouse.onMouseHover(e, this.myMapController.getCells());
            for (int i = 0; i < this.myMapController.getCells().Count; i++)
            {
                int[] mapData = myMapController.getMapData(i, this.myMapController.getCells());
                int startOfCol = mapData[0];
                int endOfCol = mapData[1];
                int startOfRow = mapData[2];
                int endOfRow = mapData[3];
                int forgiveness = 10;

                if (e.X > endOfCol - forgiveness &&
                    e.X < endOfCol + forgiveness &&
                    e.Y > startOfRow && e.Y < endOfRow)
                {
                    //myMapController.myMap.myCells[i].myRightWall.isHighlighted = true;
                    this.myMapController.highlightWall(i, 1, true); // 1 for right wall
                }
                else
                {
                    //myMapController.myMap.myCells[i].myRightWall.isHighlighted = false;
                    this.myMapController.highlightWall(i, 1, false);
                }

                if (e.Y > endOfRow - forgiveness &&
                    e.Y < endOfRow + forgiveness &&
                    e.X > startOfCol && e.X < endOfCol)
                {
                    //myMapController.myMap.myCells[i].myBottomWall.isHighlighted = true;
                    this.myMapController.highlightWall(i, 2, true); // 2 for bottom wall
                }
                else
                {
                    //myMapController.myMap.myCells[i].myBottomWall.isHighlighted = false;
                    this.myMapController.highlightWall(i, 2, false);
                }
            }

            pbxMap.Invalidate();
        }

        private void pbxMap_MouseUp(object sender, MouseEventArgs e)
        {
            Point mouse = myMapController.view.pbxMap.PointToClient(Cursor.Position);
            int leftEdgeOfMap = myMapController.myMap.boardXPos;
            int rightEdgeOfMap = leftEdgeOfMap + myMapController.myMap.myWidth;
            int topEdgeOfMap = myMapController.myMap.boardYPos;
            int bottomEdgeOfMap = topEdgeOfMap + myMapController.myMap.myHeight;
            if (mouse.X > leftEdgeOfMap &&
                mouse.X < rightEdgeOfMap &&
                mouse.Y > topEdgeOfMap &&
                mouse.Y < bottomEdgeOfMap)
            {
                if (e.Button == MouseButtons.Left)
                {
                    myDetectMouse.onMouseClick(e, this.myMapController.getCells());
                }
                if (e.Button == MouseButtons.Right)
                {
                    myDetectMouse.editCell(e, this.myMapController.getCells());
                }
                pbxMap.Invalidate();
            }
        }

        private void pbxMap_DragDrop(object sender, DragEventArgs e)
        {
            {
                if (dragSourceName == "pbxMinotaur")
                {
                    myDetectMouse.setMinotaur(e, this.myMapController.getCells());
                }
                else if (dragSourceName == "pbxTheseus")
                {
                    myDetectMouse.setTheseus(e, this.myMapController.getCells());
                }
                else if (dragSourceName == "pbxExit")
                {
                    myDetectMouse.setExit(e, this.myMapController.getCells());
                }
            }
        }

        private void pbxMap_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pbxMinotaur_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (sender as Control);
            if (c != null)
                dragSourceName = c.Name;
                pbxMap.AllowDrop = true;
                pbxMinotaur.DoDragDrop(pbxMinotaur.Name, DragDropEffects.Copy |
                DragDropEffects.Move);
        }

        private void pbxTheseus_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (sender as Control);
            if (c != null)
                dragSourceName = c.Name;
                pbxMap.AllowDrop = true;
                pbxTheseus.DoDragDrop(pbxTheseus.Name, DragDropEffects.Copy |
                DragDropEffects.Move);
        }

        private void pbxExit_MouseDown(object sender, MouseEventArgs e)
        {

            Control c = (sender as Control);
            if (c != null)
                dragSourceName = c.Name;
                pbxMap.AllowDrop = true;
                pbxTheseus.DoDragDrop(pbxExit.Name, DragDropEffects.Copy |
                DragDropEffects.Move);
        }

        private void rbBrick_CheckedChanged(object sender, EventArgs e)
        {
            myMapController.setCellBgImage();
            pbxMap.Invalidate();
        }

        private void rbWood_CheckedChanged(object sender, EventArgs e)
        {
            myMapController.setCellBgImage();
            pbxMap.Invalidate();
        }

        private void rbDiamond_CheckedChanged(object sender, EventArgs e)
        {
            myMapController.setCellBgImage();
            pbxMap.Invalidate();
        }

        private void rbClay_CheckedChanged(object sender, EventArgs e)
        {
            myMapController.setCellBgImage();
            pbxMap.Invalidate();
        }

        public void drawBgImage(Bitmap image, RectangleF location)
        {
            Graphics g = this.paint.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawImage(image, location);
        }

        public void drawHighlightedCell(int startOfCol, int startOfRow, int cellSize)
        {
            Brush brush = new SolidBrush(Color.FromArgb(80, 77, 255, 204));
            this.paint.Graphics.FillRectangle(brush, startOfCol, startOfRow, cellSize, cellSize);
        }

        public void drawWall(int endOfCol, int startOfRow, int end, int endOfRow, CellSide cellSide = null, bool border = false)
        {
            if (border) this.paint.Graphics.DrawLine(new Pen(Brushes.Black, 3), endOfCol, startOfRow, end, endOfRow);
            else if (cellSide != null) this.paint.Graphics.DrawLine(setPen(cellSide), endOfCol, startOfRow, end, endOfRow);
        }

        private Pen setPen(CellSide side)
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

        public void drawImage(Bitmap image, RectangleF location)
        {
            this.paint.Graphics.DrawImage(image, location);
        }

        public Point getMousePosition()
        {
            return pbxMap.PointToClient(Cursor.Position);
        }
    }
}
