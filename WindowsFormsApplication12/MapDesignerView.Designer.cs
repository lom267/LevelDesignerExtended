﻿namespace MapDesigner
{
    partial class MapDesignerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.btnDrawMap = new System.Windows.Forms.Button();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblCols = new System.Windows.Forms.Label();
            this.lblCellBg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.pbxMap = new System.Windows.Forms.PictureBox();
            this.rbDiamond = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbWood = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbxMinotaur = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.rbBrick = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rbClay = new System.Windows.Forms.RadioButton();
            this.pbxTheseus = new System.Windows.Forms.PictureBox();
            this.pbxExit = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMinotaur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTheseus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1255, 699);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbxTheseus);
            this.panel1.Controls.Add(this.pbxExit);
            this.panel1.Controls.Add(this.pbxMinotaur);
            this.panel1.Controls.Add(this.numCols);
            this.panel1.Controls.Add(this.btnDrawMap);
            this.panel1.Controls.Add(this.numRows);
            this.panel1.Controls.Add(this.lblRows);
            this.panel1.Controls.Add(this.lblCols);
            this.panel1.Controls.Add(this.lblCellBg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 693);
            this.panel1.TabIndex = 9;
            // 
            // numCols
            // 
            this.numCols.Font = new System.Drawing.Font("AR BONNIE", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCols.Location = new System.Drawing.Point(252, 129);
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(62, 46);
            this.numCols.TabIndex = 3;
            // 
            // btnDrawMap
            // 
            this.btnDrawMap.Font = new System.Drawing.Font("AR BONNIE", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawMap.Location = new System.Drawing.Point(15, 204);
            this.btnDrawMap.Name = "btnDrawMap";
            this.btnDrawMap.Size = new System.Drawing.Size(143, 52);
            this.btnDrawMap.TabIndex = 4;
            this.btnDrawMap.Text = "Draw Map";
            this.btnDrawMap.UseVisualStyleBackColor = true;
            this.btnDrawMap.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // numRows
            // 
            this.numRows.Font = new System.Drawing.Font("AR BONNIE", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRows.Location = new System.Drawing.Point(252, 65);
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(62, 46);
            this.numRows.TabIndex = 1;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("AR BONNIE", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRows.Location = new System.Drawing.Point(9, 76);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(74, 35);
            this.lblRows.TabIndex = 0;
            this.lblRows.Text = "Rows";
            this.lblRows.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Font = new System.Drawing.Font("AR BONNIE", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCols.Location = new System.Drawing.Point(13, 140);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(99, 35);
            this.lblCols.TabIndex = 2;
            this.lblCols.Text = "Columns";
            this.lblCols.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCellBg
            // 
            this.lblCellBg.AutoSize = true;
            this.lblCellBg.Font = new System.Drawing.Font("AR DESTINE", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellBg.Location = new System.Drawing.Point(9, -4);
            this.lblCellBg.Name = "lblCellBg";
            this.lblCellBg.Size = new System.Drawing.Size(343, 56);
            this.lblCellBg.TabIndex = 6;
            this.lblCellBg.Text = "Design a Map";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbClay);
            this.panel2.Controls.Add(this.lblWarning);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.rbBrick);
            this.panel2.Controls.Add(this.rbDiamond);
            this.panel2.Controls.Add(this.pbxMap);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.rbWood);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(353, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 693);
            this.panel2.TabIndex = 10;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(3, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 13);
            this.lblWarning.TabIndex = 0;
            // 
            // pbxMap
            // 
            this.pbxMap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbxMap.Location = new System.Drawing.Point(0, 0);
            this.pbxMap.Name = "pbxMap";
            this.pbxMap.Padding = new System.Windows.Forms.Padding(1);
            this.pbxMap.Size = new System.Drawing.Size(699, 699);
            this.pbxMap.TabIndex = 5;
            this.pbxMap.TabStop = false;
            this.pbxMap.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbxMap_DragDrop);
            this.pbxMap.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbxMap_DragEnter);
            this.pbxMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxMap_Paint);
            this.pbxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxMap_MouseMove);
            this.pbxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxMap_MouseUp);
            // 
            // rbDiamond
            // 
            this.rbDiamond.AutoSize = true;
            this.rbDiamond.Location = new System.Drawing.Point(773, 681);
            this.rbDiamond.Name = "rbDiamond";
            this.rbDiamond.Size = new System.Drawing.Size(14, 13);
            this.rbDiamond.TabIndex = 2;
            this.rbDiamond.TabStop = true;
            this.rbDiamond.Tag = "diamond";
            this.rbDiamond.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MapDesigner.Properties.Resources.diamond;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(705, 525);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rbWood
            // 
            this.rbWood.AutoSize = true;
            this.rbWood.Location = new System.Drawing.Point(773, 331);
            this.rbWood.Name = "rbWood";
            this.rbWood.Size = new System.Drawing.Size(14, 13);
            this.rbWood.TabIndex = 0;
            this.rbWood.TabStop = true;
            this.rbWood.Tag = "wood";
            this.rbWood.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::MapDesigner.Properties.Resources.wood;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(705, 175);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 150);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pbxMinotaur
            // 
            this.pbxMinotaur.BackgroundImage = global::MapDesigner.Properties.Resources.minotaur;
            this.pbxMinotaur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxMinotaur.Location = new System.Drawing.Point(0, 593);
            this.pbxMinotaur.Name = "pbxMinotaur";
            this.pbxMinotaur.Size = new System.Drawing.Size(100, 100);
            this.pbxMinotaur.TabIndex = 0;
            this.pbxMinotaur.TabStop = false;
            this.pbxMinotaur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxMinotaur_MouseDown);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::MapDesigner.Properties.Resources.brick;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(705, 350);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(150, 150);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // rbBrick
            // 
            this.rbBrick.AutoSize = true;
            this.rbBrick.Location = new System.Drawing.Point(773, 156);
            this.rbBrick.Name = "rbBrick";
            this.rbBrick.Size = new System.Drawing.Size(14, 13);
            this.rbBrick.TabIndex = 1;
            this.rbBrick.TabStop = true;
            this.rbBrick.Tag = "brick";
            this.rbBrick.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::MapDesigner.Properties.Resources.clay;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(705, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 150);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // rbClay
            // 
            this.rbClay.AutoSize = true;
            this.rbClay.Location = new System.Drawing.Point(773, 506);
            this.rbClay.Name = "rbClay";
            this.rbClay.Size = new System.Drawing.Size(14, 13);
            this.rbClay.TabIndex = 3;
            this.rbClay.TabStop = true;
            this.rbClay.Tag = "clay";
            this.rbClay.UseVisualStyleBackColor = true;
            // 
            // pbxTheseus
            // 
            this.pbxTheseus.BackgroundImage = global::MapDesigner.Properties.Resources.theseus;
            this.pbxTheseus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxTheseus.Location = new System.Drawing.Point(212, 593);
            this.pbxTheseus.Name = "pbxTheseus";
            this.pbxTheseus.Size = new System.Drawing.Size(100, 100);
            this.pbxTheseus.TabIndex = 1;
            this.pbxTheseus.TabStop = false;
            this.pbxTheseus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxTheseus_MouseDown);
            // 
            // pbxExit
            // 
            this.pbxExit.BackgroundImage = global::MapDesigner.Properties.Resources.exit;
            this.pbxExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxExit.Location = new System.Drawing.Point(106, 593);
            this.pbxExit.Name = "pbxExit";
            this.pbxExit.Size = new System.Drawing.Size(100, 100);
            this.pbxExit.TabIndex = 2;
            this.pbxExit.TabStop = false;
            this.pbxExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxExit_MouseDown);
            // 
            // MapDesignerView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1255, 699);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "MapDesignerView";
            this.Text = "Design a Map";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMinotaur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTheseus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.Button btnDrawMap;
        public System.Windows.Forms.NumericUpDown numRows;
        public System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.Label lblCellBg;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pbxMap;
        public System.Windows.Forms.Label lblWarning;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbxExit;
        private System.Windows.Forms.PictureBox pbxTheseus;
        public System.Windows.Forms.RadioButton rbClay;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.RadioButton rbBrick;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbxMinotaur;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.RadioButton rbWood;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.RadioButton rbDiamond;

    }
}

