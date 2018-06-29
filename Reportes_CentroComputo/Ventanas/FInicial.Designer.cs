namespace Reportes_CentroComputo.Ventanas
{
    partial class FInicial
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
            myClose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInicial));
            this.Opciones = new System.Windows.Forms.ToolStrip();
            this.OpcionReportes = new System.Windows.Forms.ToolStripSplitButton();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verReporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpcionMapeo = new System.Windows.Forms.ToolStripButton();
            this.OpcionLimpieza = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tecnicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new System.Windows.Forms.ToolStripSplitButton();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tecnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripSplitButton();
            this.usuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.equipoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tecnicoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Fondo = new System.Windows.Forms.PictureBox();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.baseCentralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Opciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).BeginInit();
            this.SuspendLayout();
            // 
            // Opciones
            // 
            this.Opciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpcionReportes,
            this.OpcionMapeo,
            this.OpcionLimpieza,
            this.btnAdd,
            this.btnUpdate,
            this.btnDelete,
            this.toolStripSplitButton1});
            this.Opciones.Location = new System.Drawing.Point(0, 0);
            this.Opciones.Name = "Opciones";
            this.Opciones.Size = new System.Drawing.Size(574, 25);
            this.Opciones.TabIndex = 0;
            this.Opciones.Text = "toolStrip1";
            // 
            // OpcionReportes
            // 
            this.OpcionReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpcionReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.verReporteToolStripMenuItem});
            this.OpcionReportes.Image = ((System.Drawing.Image)(resources.GetObject("OpcionReportes.Image")));
            this.OpcionReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpcionReportes.Name = "OpcionReportes";
            this.OpcionReportes.Size = new System.Drawing.Size(69, 22);
            this.OpcionReportes.Text = "Reportes";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // verReporteToolStripMenuItem
            // 
            this.verReporteToolStripMenuItem.Name = "verReporteToolStripMenuItem";
            this.verReporteToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.verReporteToolStripMenuItem.Text = "Ver reporte";
            this.verReporteToolStripMenuItem.Click += new System.EventHandler(this.verReporteToolStripMenuItem_Click);
            // 
            // OpcionMapeo
            // 
            this.OpcionMapeo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpcionMapeo.Image = ((System.Drawing.Image)(resources.GetObject("OpcionMapeo.Image")));
            this.OpcionMapeo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpcionMapeo.Name = "OpcionMapeo";
            this.OpcionMapeo.Size = new System.Drawing.Size(48, 22);
            this.OpcionMapeo.Text = "Mapeo";
            this.OpcionMapeo.Click += new System.EventHandler(this.OpcionMapeo_Click);
            // 
            // OpcionLimpieza
            // 
            this.OpcionLimpieza.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpcionLimpieza.Image = ((System.Drawing.Image)(resources.GetObject("OpcionLimpieza.Image")));
            this.OpcionLimpieza.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpcionLimpieza.Name = "OpcionLimpieza";
            this.OpcionLimpieza.Size = new System.Drawing.Size(93, 22);
            this.OpcionLimpieza.Text = "Limpieza logica";
            this.OpcionLimpieza.ToolTipText = "Limpieza de temporales";
            this.OpcionLimpieza.Click += new System.EventHandler(this.OpcionLimpieza_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.equipoToolStripMenuItem,
            this.departamentoToolStripMenuItem,
            this.tecnicosToolStripMenuItem});
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 22);
            this.btnAdd.Text = "Agregar";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // equipoToolStripMenuItem
            // 
            this.equipoToolStripMenuItem.Name = "equipoToolStripMenuItem";
            this.equipoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.equipoToolStripMenuItem.Text = "Equipo";
            this.equipoToolStripMenuItem.Click += new System.EventHandler(this.equipoToolStripMenuItem_Click);
            // 
            // departamentoToolStripMenuItem
            // 
            this.departamentoToolStripMenuItem.Name = "departamentoToolStripMenuItem";
            this.departamentoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.departamentoToolStripMenuItem.Text = "Departamento";
            this.departamentoToolStripMenuItem.Click += new System.EventHandler(this.departamentoToolStripMenuItem_Click);
            // 
            // tecnicosToolStripMenuItem
            // 
            this.tecnicosToolStripMenuItem.Name = "tecnicosToolStripMenuItem";
            this.tecnicosToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tecnicosToolStripMenuItem.Text = "Tecnicos";
            this.tecnicosToolStripMenuItem.Click += new System.EventHandler(this.tecnicosToolStripMenuItem_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.equipoToolStripMenuItem1,
            this.departamentoToolStripMenuItem1,
            this.tecnicoToolStripMenuItem});
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 22);
            this.btnUpdate.Text = "Modificar";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // equipoToolStripMenuItem1
            // 
            this.equipoToolStripMenuItem1.Name = "equipoToolStripMenuItem1";
            this.equipoToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.equipoToolStripMenuItem1.Text = "Equipo";
            this.equipoToolStripMenuItem1.Click += new System.EventHandler(this.equipoToolStripMenuItem1_Click);
            // 
            // departamentoToolStripMenuItem1
            // 
            this.departamentoToolStripMenuItem1.Name = "departamentoToolStripMenuItem1";
            this.departamentoToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.departamentoToolStripMenuItem1.Text = "Departamento";
            this.departamentoToolStripMenuItem1.Click += new System.EventHandler(this.departamentoToolStripMenuItem1_Click);
            // 
            // tecnicoToolStripMenuItem
            // 
            this.tecnicoToolStripMenuItem.Name = "tecnicoToolStripMenuItem";
            this.tecnicoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tecnicoToolStripMenuItem.Text = "Tecnico";
            this.tecnicoToolStripMenuItem.Click += new System.EventHandler(this.tecnicoToolStripMenuItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem1,
            this.equipoToolStripMenuItem2,
            this.departamentoToolStripMenuItem2,
            this.tecnicoToolStripMenuItem1});
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 22);
            this.btnDelete.Text = "Eliminar";
            // 
            // usuarioToolStripMenuItem1
            // 
            this.usuarioToolStripMenuItem1.Name = "usuarioToolStripMenuItem1";
            this.usuarioToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.usuarioToolStripMenuItem1.Text = "Usuario";
            this.usuarioToolStripMenuItem1.Click += new System.EventHandler(this.usuarioToolStripMenuItem1_Click);
            // 
            // equipoToolStripMenuItem2
            // 
            this.equipoToolStripMenuItem2.Name = "equipoToolStripMenuItem2";
            this.equipoToolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.equipoToolStripMenuItem2.Text = "Equipo";
            this.equipoToolStripMenuItem2.Click += new System.EventHandler(this.equipoToolStripMenuItem2_Click);
            // 
            // departamentoToolStripMenuItem2
            // 
            this.departamentoToolStripMenuItem2.Name = "departamentoToolStripMenuItem2";
            this.departamentoToolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.departamentoToolStripMenuItem2.Text = "Departamento";
            this.departamentoToolStripMenuItem2.Click += new System.EventHandler(this.departamentoToolStripMenuItem2_Click);
            // 
            // tecnicoToolStripMenuItem1
            // 
            this.tecnicoToolStripMenuItem1.Name = "tecnicoToolStripMenuItem1";
            this.tecnicoToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.tecnicoToolStripMenuItem1.Text = "Tecnico";
            this.tecnicoToolStripMenuItem1.Click += new System.EventHandler(this.tecnicoToolStripMenuItem1_Click);
            // 
            // Fondo
            // 
            this.Fondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fondo.Image = global::Reportes_CentroComputo.Properties.Resources.Logo;
            this.Fondo.Location = new System.Drawing.Point(0, 25);
            this.Fondo.Name = "Fondo";
            this.Fondo.Size = new System.Drawing.Size(574, 381);
            this.Fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Fondo.TabIndex = 1;
            this.Fondo.TabStop = false;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baseCentralToolStripMenuItem,
            this.baseLocalToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(81, 22);
            this.toolStripSplitButton1.Text = "Sincronizar";
            // 
            // baseCentralToolStripMenuItem
            // 
            this.baseCentralToolStripMenuItem.Name = "baseCentralToolStripMenuItem";
            this.baseCentralToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.baseCentralToolStripMenuItem.Text = "Base central";
            this.baseCentralToolStripMenuItem.Click += new System.EventHandler(this.baseCentralToolStripMenuItem_Click);
            // 
            // baseLocalToolStripMenuItem
            // 
            this.baseLocalToolStripMenuItem.Name = "baseLocalToolStripMenuItem";
            this.baseLocalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.baseLocalToolStripMenuItem.Text = "Base local";
            this.baseLocalToolStripMenuItem.Click += new System.EventHandler(this.baseLocalToolStripMenuItem_Click);
            // 
            // FInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 406);
            this.Controls.Add(this.Fondo);
            this.Controls.Add(this.Opciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centro de Computo";
            this.Load += new System.EventHandler(this.FInicial_Load);
            this.Opciones.ResumeLayout(false);
            this.Opciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Opciones;
        private System.Windows.Forms.ToolStripButton OpcionMapeo;
        private System.Windows.Forms.ToolStripButton OpcionLimpieza;
        private System.Windows.Forms.PictureBox Fondo;
        private System.Windows.Forms.ToolStripSplitButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tecnicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tecnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton btnDelete;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem equipoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tecnicoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton OpcionReportes;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verReporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem baseCentralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseLocalToolStripMenuItem;
    }
}