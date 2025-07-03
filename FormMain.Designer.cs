namespace PacMan
{
    partial class FormMain
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
            pictureBoxBoard = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelScore = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxBoard
            // 
            pictureBoxBoard.BackColor = Color.Black;
            pictureBoxBoard.Dock = DockStyle.Bottom;
            pictureBoxBoard.Location = new Point(0, 22);
            pictureBoxBoard.MaximumSize = new Size(600, 600);
            pictureBoxBoard.MinimumSize = new Size(600, 600);
            pictureBoxBoard.Name = "pictureBoxBoard";
            pictureBoxBoard.Size = new Size(600, 600);
            pictureBoxBoard.TabIndex = 0;
            pictureBoxBoard.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Black;
            statusStrip1.Dock = DockStyle.Top;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelScore, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(600, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelScore
            // 
            toolStripStatusLabelScore.ForeColor = Color.FromArgb(128, 255, 255);
            toolStripStatusLabelScore.Name = "toolStripStatusLabelScore";
            toolStripStatusLabelScore.Size = new Size(48, 17);
            toolStripStatusLabelScore.Text = "Score: 0";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ForeColor = Color.FromArgb(128, 255, 255);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(45, 17);
            toolStripStatusLabel1.Text = "Lives: 3";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 622);
            Controls.Add(statusStrip1);
            Controls.Add(pictureBoxBoard);
            MaximumSize = new Size(616, 661);
            MinimumSize = new Size(616, 661);
            Name = "FormMain";
            Text = "Form1";
            KeyDown += FormMain_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxBoard;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelScore;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
