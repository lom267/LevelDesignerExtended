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
        public Map myMap { get; set; }
        public MapController myMapController { get; set; }
        public MapConstructor myMapConstructor { get; set; }
        public MouseEventHandler myDetectMouse { get; set; }
        string dragSourceName;

        public MapDesignerView()
        {
            myMap = new Map(this);
            myMapController = new MapController(myMap);
            myMapConstructor = new MapConstructor(myMapController);
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
            if (myMap.rows > 0 && myMap.cols > 0)
            {
                if (myMapController.myMap.rows > 2 && myMapController.myMap.cols > 2)
                {
                    lblWarning.Text = "";
                    myMapConstructor.drawMap(e, myMap.myCells);
                }
                else
                {
                    lblWarning.Text = "Please enter atleast 3 columns and 3 rows.";
                }
            }
        }

        private void pbxMap_MouseMove(object sender, MouseEventArgs e)
        {
            myDetectMouse.onMouseHover(e, myMap.myCells);
            pbxMap.Invalidate();
        }

        private void pbxMap_MouseUp(object sender, MouseEventArgs e)
        {
            Point mouse = myMapController.myMap.myForm.pbxMap.PointToClient(Cursor.Position);
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
                    myDetectMouse.onMouseClick(e, myMap.myCells);
                }
                if (e.Button == MouseButtons.Right)
                {
                    myDetectMouse.editCell(e, myMap.myCells);
                }
                pbxMap.Invalidate();
            }
        }

        private void pbxMap_DragDrop(object sender, DragEventArgs e)
        {
            {
                if (dragSourceName == "pbxMinotaur")
                {
                    myDetectMouse.setMinotaur(e, myMap.myCells);
                }
                else if (dragSourceName == "pbxTheseus")
                {
                    myDetectMouse.setTheseus(e, myMap.myCells);
                }
                else if (dragSourceName == "pbxExit")
                {
                    myDetectMouse.setExit(e, myMap.myCells);
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
    }
}
