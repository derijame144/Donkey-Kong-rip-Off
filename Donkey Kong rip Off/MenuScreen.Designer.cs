﻿namespace Donkey_Kong_rip_Off
{
    partial class MenuScreen
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
            this.titleLable.Location = new System.Drawing.Point(193, 236);
            this.titleLable.Name = "titleLable";
            this.titleLable.Size = new System.Drawing.Size(503, 71);
            this.titleLable.TabIndex = 0;
            this.titleLable.Text = "Donkey Kong";
            // 
            // playLabel
            // 
            this.playLabel.AutoSize = true;
            this.playLabel.BackColor = System.Drawing.SystemColors.Control;
            this.playLabel.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.playLabel.Location = new System.Drawing.Point(372, 435);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(142, 50);
            this.playLabel.TabIndex = 1;
            this.playLabel.Text = "Play";
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.exitLabel.Location = new System.Drawing.Point(372, 554);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(142, 50);
            this.exitLabel.TabIndex = 2;
            this.exitLabel.Text = "Exit";
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.titleLable);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(926, 1146);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MenuScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLable;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.Label exitLabel;
    }
}
