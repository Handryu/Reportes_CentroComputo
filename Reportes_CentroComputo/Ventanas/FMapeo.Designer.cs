namespace Reportes_CentroComputo
{
    partial class FMapeo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMapeo));
            this.Fondo = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Variables = new System.Windows.Forms.ToolStripButton();
            this.gCSV = new System.Windows.Forms.ToolStripButton();
            this.Mapa = new System.Windows.Forms.ToolStripSplitButton();
            this.gMapa = new System.Windows.Forms.ToolStripMenuItem();
            this.cMapa = new System.Windows.Forms.ToolStripMenuItem();
            this.Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.Cerrar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fondo
            // 
            this.Fondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fondo.Image = global::Reportes_CentroComputo.Properties.Resources.Logo3;
            this.Fondo.Location = new System.Drawing.Point(0, 0);
            this.Fondo.Name = "Fondo";
            this.Fondo.Size = new System.Drawing.Size(821, 510);
            this.Fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Fondo.TabIndex = 0;
            this.Fondo.TabStop = false;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BackgroundImage = global::Reportes_CentroComputo.Properties.Resources.Logo3;
            this.panel.Location = new System.Drawing.Point(0, 28);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(821, 482);
            this.panel.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Variables,
            this.gCSV,
            this.Mapa,
            this.Cerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Variables
            // 
            this.Variables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Variables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Variables.Name = "Variables";
            this.Variables.Size = new System.Drawing.Size(57, 22);
            this.Variables.Text = "Variables";
            this.Variables.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Variables.Click += new System.EventHandler(this.Variables_Click);
            // 
            // gCSV
            // 
            this.gCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gCSV.Image = ((System.Drawing.Image)(resources.GetObject("gCSV.Image")));
            this.gCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gCSV.Name = "gCSV";
            this.gCSV.Size = new System.Drawing.Size(76, 22);
            this.gCSV.Text = "Generar CSV";
            this.gCSV.Click += new System.EventHandler(this.gCSV_Click);
            // 
            // Mapa
            // 
            this.Mapa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gMapa,
            this.cMapa,
            this.Nuevo});
            this.Mapa.Name = "Mapa";
            this.Mapa.Size = new System.Drawing.Size(53, 22);
            this.Mapa.Text = "Mapa";
            this.Mapa.ToolTipText = "Opciones de Mapa";
            // 
            // gMapa
            // 
            this.gMapa.Name = "gMapa";
            this.gMapa.Size = new System.Drawing.Size(149, 22);
            this.gMapa.Text = "Guardar mapa";
            this.gMapa.ToolTipText = "Guarda el estado del mapa enun archivo";
            this.gMapa.Click += new System.EventHandler(this.gMapa_Click);
            // 
            // cMapa
            // 
            this.cMapa.Name = "cMapa";
            this.cMapa.Size = new System.Drawing.Size(149, 22);
            this.cMapa.Text = "Cargar mapa";
            this.cMapa.ToolTipText = "Carga un archivo de mapa";
            this.cMapa.Click += new System.EventHandler(this.cMapa_Click);
            // 
            // Nuevo
            // 
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(149, 22);
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // Cerrar
            // 
            this.Cerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Cerrar.Image = ((System.Drawing.Image)(resources.GetObject("Cerrar.Image")));
            this.Cerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(43, 22);
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // FMapeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 510);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.Fondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMapeo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FMapeo";
            this.Load += new System.EventHandler(this.FMapeo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Fondo;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Variables;
        private System.Windows.Forms.ToolStripButton gCSV;
        private System.Windows.Forms.ToolStripSplitButton Mapa;
        private System.Windows.Forms.ToolStripMenuItem gMapa;
        private System.Windows.Forms.ToolStripMenuItem cMapa;
        private System.Windows.Forms.ToolStripButton Cerrar;
        private System.Windows.Forms.ToolStripMenuItem Nuevo;
    }
}