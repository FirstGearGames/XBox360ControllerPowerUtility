namespace Xbox360ControllerPowerUtility
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
            this.TmrCheckInput = new System.Windows.Forms.Timer(this.components);
            this.pboxLogo = new System.Windows.Forms.PictureBox();
            this.TmrHideForm = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TmrCheckInput
            // 
            this.TmrCheckInput.Enabled = true;
            this.TmrCheckInput.Tick += new System.EventHandler(this.TmrCheckInput_Tick);
            // 
            // pboxLogo
            // 
            this.pboxLogo.Image = global::Xbox360ControllerPowerUtility.Properties.Resources._6389cc874fcb1b8374873f9050df2ed9;
            this.pboxLogo.Location = new System.Drawing.Point(0, 0);
            this.pboxLogo.Name = "pboxLogo";
            this.pboxLogo.Size = new System.Drawing.Size(650, 128);
            this.pboxLogo.TabIndex = 0;
            this.pboxLogo.TabStop = false;
            // 
            // TmrHideForm
            // 
            this.TmrHideForm.Enabled = true;
            this.TmrHideForm.Interval = 3000;
            this.TmrHideForm.Tick += new System.EventHandler(this.TmrHideForm_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 128);
            this.ControlBox = false;
            this.Controls.Add(this.pboxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XBox 360 Controller POWER UTILITY";
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TmrCheckInput;
        private System.Windows.Forms.PictureBox pboxLogo;
        private System.Windows.Forms.Timer TmrHideForm;
    }
}

