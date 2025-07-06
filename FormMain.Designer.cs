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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            pictureBoxBoard = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelScore = new ToolStripStatusLabel();
            toolStripStatusLabelLives = new ToolStripStatusLabel();
            labelGameOver = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxBoard
            // 
            pictureBoxBoard.BackColor = Color.Black;
            pictureBoxBoard.Dock = DockStyle.Bottom;
            pictureBoxBoard.Location = new Point(0, 26);
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
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelScore, toolStripStatusLabelLives });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(598, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelScore
            // 
            toolStripStatusLabelScore.ForeColor = Color.FromArgb(128, 255, 255);
            toolStripStatusLabelScore.Name = "toolStripStatusLabelScore";
            toolStripStatusLabelScore.Size = new Size(61, 20);
            toolStripStatusLabelScore.Text = "Score: 0";
            // 
            // toolStripStatusLabelLives
            // 
            toolStripStatusLabelLives.ForeColor = Color.FromArgb(128, 255, 255);
            toolStripStatusLabelLives.Name = "toolStripStatusLabelLives";
            toolStripStatusLabelLives.Size = new Size(56, 20);
            toolStripStatusLabelLives.Text = "Lives: 3";
            // 
            // labelGameOver
            // 
            labelGameOver.AutoSize = true;
            labelGameOver.BackColor = Color.Black;
            labelGameOver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelGameOver.ForeColor = Color.Yellow;
            labelGameOver.Location = new Point(224, 265);
            labelGameOver.Name = "labelGameOver";
            labelGameOver.Size = new Size(189, 56);
            labelGameOver.TabIndex = 2;
            labelGameOver.Text = "G A M E  O V E R\r\nPress \"esc\" to restart\r\n";
            labelGameOver.TextAlign = ContentAlignment.MiddleCenter;
            labelGameOver.Visible = false;
            // 
            // FormMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(598, 626);
            Controls.Add(labelGameOver);
            Controls.Add(statusStrip1);
            Controls.Add(pictureBoxBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(616, 673);
            MinimumSize = new Size(616, 673);
            Name = "FormMain";
            Text = "Pac-Man";
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
        private ToolStripStatusLabel toolStripStatusLabelLives;
        private Label labelGameOver;
    }
}