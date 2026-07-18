namespace PathfindingVisualizer
{
    partial class Visualizer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grid = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            XSizeBox = new TextBox();
            YSizeBox = new TextBox();
            trackBar1 = new TrackBar();
            selectStartToolStripMenuItem = new ToolStripMenuItem();
            selectEndToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            startToolStripMenuItem = new ToolStripMenuItem();
            generateToolStripMenuItem = new ToolStripMenuItem();
            pathfinderToolStripComboBox = new ToolStripComboBox();
            timer = new System.Windows.Forms.Timer(components);
            grid.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grid
            // 
            grid.Controls.Add(panel1);
            grid.Location = new Point(0, 26);
            grid.Name = "grid";
            grid.Size = new Size(508, 508);
            grid.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(XSizeBox);
            panel1.Controls.Add(YSizeBox);
            panel1.Location = new Point(141, 200);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 127);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 62);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Grid Size Y";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "Grid Size X";
            // 
            // XSizeBox
            // 
            XSizeBox.BorderStyle = BorderStyle.None;
            XSizeBox.Location = new Point(63, 27);
            XSizeBox.Name = "XSizeBox";
            XSizeBox.Size = new Size(100, 16);
            XSizeBox.TabIndex = 0;
            XSizeBox.TextChanged += textBox1_TextChanged;
            // 
            // YSizeBox
            // 
            YSizeBox.BorderStyle = BorderStyle.None;
            YSizeBox.Location = new Point(63, 80);
            YSizeBox.Name = "YSizeBox";
            YSizeBox.Size = new Size(100, 16);
            YSizeBox.TabIndex = 2;
            YSizeBox.TextChanged += textBox2_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(0, 534);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(508, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // selectStartToolStripMenuItem
            // 
            selectStartToolStripMenuItem.Name = "selectStartToolStripMenuItem";
            selectStartToolStripMenuItem.Size = new Size(77, 23);
            selectStartToolStripMenuItem.Text = "Select Start";
            selectStartToolStripMenuItem.Click += selectStartToolStripMenuItem_Click;
            // 
            // selectEndToolStripMenuItem
            // 
            selectEndToolStripMenuItem.Name = "selectEndToolStripMenuItem";
            selectEndToolStripMenuItem.Size = new Size(73, 23);
            selectEndToolStripMenuItem.Text = "Select End";
            selectEndToolStripMenuItem.Click += selectEndToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { startToolStripMenuItem, selectStartToolStripMenuItem, selectEndToolStripMenuItem, generateToolStripMenuItem, pathfinderToolStripComboBox });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(508, 27);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            startToolStripMenuItem.Name = "startToolStripMenuItem";
            startToolStripMenuItem.Size = new Size(43, 23);
            startToolStripMenuItem.Text = "Start";
            startToolStripMenuItem.Click += startToolStripMenuItem_Click;
            // 
            // generateToolStripMenuItem
            // 
            generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            generateToolStripMenuItem.Size = new Size(66, 23);
            generateToolStripMenuItem.Text = "Generate";
            generateToolStripMenuItem.Click += generateToolStripMenuItem_Click;
            // 
            // pathfinderToolStripComboBox
            // 
            pathfinderToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            pathfinderToolStripComboBox.Items.AddRange(new object[] { "A*", "Dijkstra's", "BFS", "DFS" });
            pathfinderToolStripComboBox.Name = "pathfinderToolStripComboBox";
            pathfinderToolStripComboBox.Size = new Size(121, 23);
            pathfinderToolStripComboBox.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            // 
            // timer
            // 
            timer.Interval = 500;
            timer.Tick += timer_Tick;
            // 
            // Visualizer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 580);
            Controls.Add(trackBar1);
            Controls.Add(grid);
            Controls.Add(menuStrip1);
            Name = "Visualizer";
            Text = "Visualizer";
            Load += Visualizer_Load;
            Resize += Visualizer_Resize;
            grid.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel grid;
        private ToolStripMenuItem selectStartToolStripMenuItem;
        private ToolStripMenuItem selectEndToolStripMenuItem;
        private MenuStrip menuStrip1;
        private TrackBar trackBar1;
        private ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.Timer timer;
        private TextBox XSizeBox;
        private ToolStripMenuItem generateToolStripMenuItem;
        private Label label2;
        private TextBox YSizeBox;
        private Label label1;
        private Panel panel1;
        private ToolStripComboBox pathfinderToolStripComboBox;
        private ToolStripMenuItem startToolStripMenuItem;
    }
}
