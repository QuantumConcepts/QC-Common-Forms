namespace QuantumConcepts.Common.Forms.UI.Controls
{
    partial class Toolbox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toolbox));
            this.leftPictureBox = new System.Windows.Forms.PictureBox();
            this.rightPictureBox = new System.Windows.Forms.PictureBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPictureBox
            // 
            this.leftPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("leftPictureBox.Image")));
            this.leftPictureBox.Location = new System.Drawing.Point(0, 0);
            this.leftPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.leftPictureBox.Name = "leftPictureBox";
            this.leftPictureBox.Size = new System.Drawing.Size(12, 20);
            this.leftPictureBox.TabIndex = 0;
            this.leftPictureBox.TabStop = false;
            // 
            // rightPictureBox
            // 
            this.rightPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("rightPictureBox.Image")));
            this.rightPictureBox.Location = new System.Drawing.Point(245, 0);
            this.rightPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.rightPictureBox.Name = "rightPictureBox";
            this.rightPictureBox.Size = new System.Drawing.Size(10, 20);
            this.rightPictureBox.TabIndex = 2;
            this.rightPictureBox.TabStop = false;
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.headerLabel.Location = new System.Drawing.Point(10, 0);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(235, 20);
            this.headerLabel.TabIndex = 4;
            this.headerLabel.Text = "dasfdsfas";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerPanel.BackgroundImage")));
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Controls.Add(this.rightPictureBox);
            this.headerPanel.Controls.Add(this.leftPictureBox);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(255, 20);
            this.headerPanel.TabIndex = 3;
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "Toolbox";
            this.Size = new System.Drawing.Size(255, 150);
            ((System.ComponentModel.ISupportInitialize)(this.leftPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightPictureBox)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox leftPictureBox;
        private System.Windows.Forms.PictureBox rightPictureBox;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel headerPanel;
    }
}
