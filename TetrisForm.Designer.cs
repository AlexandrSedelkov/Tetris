
namespace Tetris
{
    partial class TetrisForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TetrisForm));
            this.scoreLabel = new System.Windows.Forms.Label();
            this.linesLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tetrisLabel = new System.Windows.Forms.Label();
            this.highScoreTableLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.Location = new System.Drawing.Point(433, 239);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(27, 29);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "0";
            // 
            // linesLabel
            // 
            this.linesLabel.AutoSize = true;
            this.linesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linesLabel.Location = new System.Drawing.Point(433, 303);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(27, 29);
            this.linesLabel.TabIndex = 1;
            this.linesLabel.Text = "0";
            // 
            // pauseButton
            // 
            this.pauseButton.AutoSize = true;
            this.pauseButton.BackColor = System.Drawing.Color.MistyRose;
            this.pauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pauseButton.Location = new System.Drawing.Point(487, 410);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(54, 25);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Play";
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.AutoSize = true;
            this.exitButton.BackColor = System.Drawing.Color.MistyRose;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(496, 459);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(48, 25);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.AutoSize = true;
            this.aboutButton.BackColor = System.Drawing.Color.MistyRose;
            this.aboutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutButton.Location = new System.Drawing.Point(484, 435);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(69, 25);
            this.aboutButton.TabIndex = 6;
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.AutoSize = true;
            this.newGameButton.BackColor = System.Drawing.Color.MistyRose;
            this.newGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newGameButton.Location = new System.Drawing.Point(460, 385);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(117, 25);
            this.newGameButton.TabIndex = 7;
            this.newGameButton.Text = "New Game";
            this.newGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // tetrisLabel
            // 
            this.tetrisLabel.AutoSize = true;
            this.tetrisLabel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.tetrisLabel.Font = new System.Drawing.Font("Arial Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tetrisLabel.ForeColor = System.Drawing.Color.Purple;
            this.tetrisLabel.Location = new System.Drawing.Point(153, 4);
            this.tetrisLabel.Name = "tetrisLabel";
            this.tetrisLabel.Size = new System.Drawing.Size(155, 46);
            this.tetrisLabel.TabIndex = 8;
            this.tetrisLabel.Text = "TETRIS";
            // 
            // highScoreTableLabel
            // 
            this.highScoreTableLabel.AutoSize = true;
            this.highScoreTableLabel.BackColor = System.Drawing.Color.MistyRose;
            this.highScoreTableLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.highScoreTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.highScoreTableLabel.Location = new System.Drawing.Point(417, 20);
            this.highScoreTableLabel.Name = "highScoreTableLabel";
            this.highScoreTableLabel.Size = new System.Drawing.Size(180, 25);
            this.highScoreTableLabel.TabIndex = 9;
            this.highScoreTableLabel.Text = "High Score Tabel";
            this.highScoreTableLabel.Click += new System.EventHandler(this.HighScoreTableLabel_Click);
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(639, 709);
            this.Controls.Add(this.highScoreTableLabel);
            this.Controls.Add(this.tetrisLabel);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.linesLabel);
            this.Controls.Add(this.scoreLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TetrisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.Label pauseButton;
        private System.Windows.Forms.Label exitButton;
        private System.Windows.Forms.Label aboutButton;
        private System.Windows.Forms.Label newGameButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label tetrisLabel;
        private System.Windows.Forms.Label highScoreTableLabel;
    }
}

