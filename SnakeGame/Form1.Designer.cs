namespace SnakeGame
{
    partial class SnakeGame
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
            this.gameAreaPictureBox = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.difficultyComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameAreaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameAreaPictureBox
            // 
            this.gameAreaPictureBox.Location = new System.Drawing.Point(12, 12);
            this.gameAreaPictureBox.Name = "gameAreaPictureBox";
            this.gameAreaPictureBox.Size = new System.Drawing.Size(1150, 568);
            this.gameAreaPictureBox.TabIndex = 0;
            this.gameAreaPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gameAreaPictureBox_Paint);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(629, 586);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(186, 52);
            this.startButton.TabIndex = 1;
            this.startButton.TabStop = false;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // difficultyComboBox
            // 
            this.difficultyComboBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.difficultyComboBox.FormattingEnabled = true;
            this.difficultyComboBox.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard",
            "Insane"});
            this.difficultyComboBox.Location = new System.Drawing.Point(401, 586);
            this.difficultyComboBox.Name = "difficultyComboBox";
            this.difficultyComboBox.Size = new System.Drawing.Size(106, 21);
            this.difficultyComboBox.TabIndex = 0;
            this.difficultyComboBox.TabStop = false;
            this.difficultyComboBox.Text = "Select Difficulty";
            this.difficultyComboBox.SelectedIndexChanged += new System.EventHandler(this.difficultyComboBox_SelectedIndexChanged);
            this.difficultyComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.difficultyComboBox_KeyDown);
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1174, 648);
            this.Controls.Add(this.difficultyComboBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gameAreaPictureBox);
            this.KeyPreview = true;
            this.Name = "SnakeGame";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gameAreaPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gameAreaPictureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox difficultyComboBox;
    }
}

