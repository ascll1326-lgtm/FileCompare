namespace FileCompare
{
    partial class fmApp
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
            splitContainer = new SplitContainer();
            panel3 = new Panel();
            lvwLeftDir = new ListView();
            이름 = new ColumnHeader();
            크기 = new ColumnHeader();
            수정일 = new ColumnHeader();
            panel2 = new Panel();
            btnLeftDir = new Button();
            txtLeftDir = new TextBox();
            panel1 = new Panel();
            btnCopyFromLeft = new Button();
            lblAppName = new Label();
            panel6 = new Panel();
            txtRightDir = new TextBox();
            btnRightDir = new Button();
            panel5 = new Panel();
            btnCopyFromRight = new Button();
            panel7 = new Panel();
            lvwRightDir = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(10, 10);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panel3);
            splitContainer.Panel1.Controls.Add(panel2);
            splitContainer.Panel1.Controls.Add(panel1);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panel6);
            splitContainer.Panel2.Controls.Add(panel5);
            splitContainer.Panel2.Controls.Add(panel7);
            splitContainer.Size = new Size(2050, 936);
            splitContainer.SplitterDistance = 998;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(lvwLeftDir);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 358);
            panel3.Name = "panel3";
            panel3.Size = new Size(998, 578);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint_1;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwLeftDir.Columns.AddRange(new ColumnHeader[] { 이름, 크기, 수정일 });
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Location = new Point(0, 0);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(995, 578);
            lvwLeftDir.TabIndex = 0;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            lvwLeftDir.View = View.Details;
            // 
            // 이름
            // 
            이름.Text = "이름";
            이름.Width = 600;
            // 
            // 크기
            // 
            크기.Text = "크기";
            크기.Width = 150;
            // 
            // 수정일
            // 
            수정일.Text = "수정일";
            수정일.Width = 1000;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLeftDir);
            panel2.Controls.Add(txtLeftDir);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 175);
            panel2.Name = "panel2";
            panel2.Size = new Size(998, 183);
            panel2.TabIndex = 0;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Anchor = AnchorStyles.Right;
            btnLeftDir.Location = new Point(803, 117);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(150, 39);
            btnLeftDir.TabIndex = 2;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLeftDir.Location = new Point(30, 117);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(754, 39);
            txtLeftDir.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCopyFromLeft);
            panel1.Controls.Add(lblAppName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(998, 175);
            panel1.TabIndex = 0;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Anchor = AnchorStyles.Right;
            btnCopyFromLeft.Location = new Point(803, 68);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(150, 46);
            btnCopyFromLeft.TabIndex = 0;
            btnCopyFromLeft.Text = ">>>";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            btnCopyFromLeft.Click += btnCopyFromLeft_Click;
            // 
            // lblAppName
            // 
            lblAppName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 25.875F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.FromArgb(0, 192, 0);
            lblAppName.Location = new Point(53, 26);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(471, 92);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtRightDir);
            panel6.Controls.Add(btnRightDir);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 175);
            panel6.Name = "panel6";
            panel6.Size = new Size(1047, 183);
            panel6.TabIndex = 0;
            panel6.Paint += panel6_Paint;
            // 
            // txtRightDir
            // 
            txtRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRightDir.Location = new Point(29, 117);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(830, 39);
            txtRightDir.TabIndex = 1;
            // 
            // btnRightDir
            // 
            btnRightDir.Anchor = AnchorStyles.Right;
            btnRightDir.Location = new Point(881, 117);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(150, 39);
            btnRightDir.TabIndex = 1;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            btnRightDir.Click += btnRightDir_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnCopyFromRight);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1047, 175);
            panel5.TabIndex = 0;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Anchor = AnchorStyles.Left;
            btnCopyFromRight.Location = new Point(40, 68);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(150, 46);
            btnCopyFromRight.TabIndex = 1;
            btnCopyFromRight.Text = "<<<";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            btnCopyFromRight.Click += btnCopyFromRight_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(lvwRightDir);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1047, 936);
            panel7.TabIndex = 0;
            panel7.Paint += panel3_Paint;
            // 
            // lvwRightDir
            // 
            lvwRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lvwRightDir.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lvwRightDir.FullRowSelect = true;
            lvwRightDir.GridLines = true;
            lvwRightDir.Location = new Point(3, 358);
            lvwRightDir.Name = "lvwRightDir";
            lvwRightDir.Size = new Size(1044, 575);
            lvwRightDir.TabIndex = 1;
            lvwRightDir.UseCompatibleStateImageBehavior = false;
            lvwRightDir.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "이름";
            columnHeader1.Width = 600;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "크기";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "수정일";
            columnHeader3.Width = 1000;
            // 
            // fmApp
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2070, 956);
            Controls.Add(splitContainer);
            Name = "fmApp";
            Padding = new Padding(10);
            Text = "File Compare";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private Panel panel1;
        private Panel panel2;
        private Panel panel7;
        private Panel panel3;
        private Label lblAppName;
        private Panel panel6;
        private Panel panel5;
        private TextBox txtLeftDir;
        private Button btnCopyFromLeft;
        private Button btnCopyFromRight;
        private Button btnLeftDir;
        private TextBox txtRightDir;
        private Button btnRightDir;
        private ListView lvwLeftDir;
        private ListView lvwRightDir;
        private ColumnHeader 이름;
        private ColumnHeader 크기;
        private ColumnHeader 수정일;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
