namespace DuelingGame
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Canvas = new System.Windows.Forms.Panel();
            this.Floor = new System.Windows.Forms.PictureBox();
            this.tmrPlayer = new System.Windows.Forms.Timer(this.components);
            this.platform1 = new System.Windows.Forms.PictureBox();
            this.Canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform1)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.LightGray;
            this.Canvas.Controls.Add(this.platform1);
            this.Canvas.Controls.Add(this.Floor);
            this.Canvas.Location = new System.Drawing.Point(12, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(750, 400);
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // Floor
            // 
            this.Floor.BackColor = System.Drawing.Color.Gray;
            this.Floor.Location = new System.Drawing.Point(-35, 385);
            this.Floor.Name = "Floor";
            this.Floor.Size = new System.Drawing.Size(813, 50);
            this.Floor.TabIndex = 0;
            this.Floor.TabStop = false;
            // 
            // tmrPlayer
            // 
            this.tmrPlayer.Enabled = true;
            this.tmrPlayer.Interval = 10;
            this.tmrPlayer.Tick += new System.EventHandler(this.tmrPlayer_Tick);
            // 
            // platform1
            // 
            this.platform1.BackColor = System.Drawing.Color.Gray;
            this.platform1.Location = new System.Drawing.Point(0, 164);
            this.platform1.Name = "platform1";
            this.platform1.Size = new System.Drawing.Size(223, 10);
            this.platform1.TabIndex = 1;
            this.platform1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 428);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canvas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Canvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Timer tmrPlayer;
        private System.Windows.Forms.PictureBox Floor;
        private System.Windows.Forms.PictureBox platform1;
    }
}

