namespace Donkey_Kong_rip_Off
{
    partial class GanmeOverScreen
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
            this.titleLable = new System.Windows.Forms.Label();
            this.playLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLable
            // 
            this.titleLable.AutoSize = true;
            this.titleLable.Font = new System.Drawing.Font("OCR A Extended", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLable.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.titleLable.Location = new System.Drawing.Point(195, 203);
            this.titleLable.Name = "titleLable";
            this.titleLable.Size = new System.Drawing.Size(503, 142);
            this.titleLable.TabIndex = 1;
            this.titleLable.Text = " Game Over\r\nPlay Again?\r\n";
            // 
            // playLabel
            // 
            this.playLabel.AutoSize = true;
            this.playLabel.BackColor = System.Drawing.SystemColors.Control;
            this.playLabel.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.playLabel.Location = new System.Drawing.Point(394, 494);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(112, 50);
            this.playLabel.TabIndex = 2;
            this.playLabel.Text = "Yes";
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.exitLabel.Location = new System.Drawing.Point(407, 597);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(82, 50);
            this.exitLabel.TabIndex = 3;
            this.exitLabel.Text = "No";
            // 
            // GanmeOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.titleLable);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GanmeOverScreen";
            this.Size = new System.Drawing.Size(926, 1146);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GanmeOverScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLable;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.Label exitLabel;
    }
}
