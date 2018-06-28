namespace Reportes_CentroComputo
{
    partial class FLimpieza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLimpieza));
            this.Fondo = new System.Windows.Forms.PictureBox();
            this.background = new System.ComponentModel.BackgroundWorker();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).BeginInit();
            this.SuspendLayout();
            // 
            // Fondo
            // 
            this.Fondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fondo.Image = global::Reportes_CentroComputo.Properties.Resources.Logo3;
            this.Fondo.Location = new System.Drawing.Point(0, 0);
            this.Fondo.Name = "Fondo";
            this.Fondo.Size = new System.Drawing.Size(539, 229);
            this.Fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Fondo.TabIndex = 0;
            this.Fondo.TabStop = false;
            // 
            // background
            // 
            this.background.DoWork += new System.ComponentModel.DoWorkEventHandler(this.background_DoWork);
            this.background.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.background_ProgressChanged);
            this.background.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.background_RunWorkerCompleted);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(12, 12);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(515, 36);
            this.pBar.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 69);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(515, 148);
            this.txtLog.TabIndex = 2;
            this.txtLog.Text = "";
            // 
            // FLimpieza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 229);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.Fondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FLimpieza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Limpieza";
            this.Load += new System.EventHandler(this.FLimpieza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Fondo;
        private System.ComponentModel.BackgroundWorker background;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}