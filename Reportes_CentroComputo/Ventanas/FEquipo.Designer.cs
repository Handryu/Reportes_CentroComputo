namespace Reportes_CentroComputo
{
    partial class FEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEquipo));
            this.panelFondo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIDRaton = new System.Windows.Forms.TextBox();
            this.txtIDTeclado = new System.Windows.Forms.TextBox();
            this.txtIDMonitor = new System.Windows.Forms.TextBox();
            this.txtIDCPU = new System.Windows.Forms.TextBox();
            this.txtIDEquipo = new System.Windows.Forms.TextBox();
            this.btnOpenCPU = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.metroLabel5 = new System.Windows.Forms.Label();
            this.metroLabel4 = new System.Windows.Forms.Label();
            this.metroLabel3 = new System.Windows.Forms.Label();
            this.metroLabel2 = new System.Windows.Forms.Label();
            this.metroLabel1 = new System.Windows.Forms.Label();
            this.picFondo = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFondo
            // 
            this.panelFondo.Controls.Add(this.button1);
            this.panelFondo.Controls.Add(this.txtIDRaton);
            this.panelFondo.Controls.Add(this.txtIDTeclado);
            this.panelFondo.Controls.Add(this.txtIDMonitor);
            this.panelFondo.Controls.Add(this.txtIDCPU);
            this.panelFondo.Controls.Add(this.txtIDEquipo);
            this.panelFondo.Controls.Add(this.btnOpenCPU);
            this.panelFondo.Controls.Add(this.btnGuardar);
            this.panelFondo.Controls.Add(this.metroLabel5);
            this.panelFondo.Controls.Add(this.metroLabel4);
            this.panelFondo.Controls.Add(this.metroLabel3);
            this.panelFondo.Controls.Add(this.metroLabel2);
            this.panelFondo.Controls.Add(this.metroLabel1);
            this.panelFondo.Controls.Add(this.picFondo);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(0, 0);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(455, 388);
            this.panelFondo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(270, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIDRaton
            // 
            this.txtIDRaton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDRaton.Location = new System.Drawing.Point(130, 266);
            this.txtIDRaton.Name = "txtIDRaton";
            this.txtIDRaton.Size = new System.Drawing.Size(134, 22);
            this.txtIDRaton.TabIndex = 21;
            // 
            // txtIDTeclado
            // 
            this.txtIDTeclado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDTeclado.Location = new System.Drawing.Point(130, 207);
            this.txtIDTeclado.Name = "txtIDTeclado";
            this.txtIDTeclado.Size = new System.Drawing.Size(134, 22);
            this.txtIDTeclado.TabIndex = 20;
            // 
            // txtIDMonitor
            // 
            this.txtIDMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDMonitor.Location = new System.Drawing.Point(130, 153);
            this.txtIDMonitor.Name = "txtIDMonitor";
            this.txtIDMonitor.Size = new System.Drawing.Size(134, 22);
            this.txtIDMonitor.TabIndex = 19;
            this.txtIDMonitor.TextChanged += new System.EventHandler(this.txtIDMonitor_TextChanged);
            this.txtIDMonitor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDMonitor_KeyPress);
            // 
            // txtIDCPU
            // 
            this.txtIDCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCPU.Location = new System.Drawing.Point(130, 94);
            this.txtIDCPU.Name = "txtIDCPU";
            this.txtIDCPU.Size = new System.Drawing.Size(134, 22);
            this.txtIDCPU.TabIndex = 18;
            // 
            // txtIDEquipo
            // 
            this.txtIDEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDEquipo.Location = new System.Drawing.Point(130, 43);
            this.txtIDEquipo.Name = "txtIDEquipo";
            this.txtIDEquipo.Size = new System.Drawing.Size(134, 22);
            this.txtIDEquipo.TabIndex = 17;
            // 
            // btnOpenCPU
            // 
            this.btnOpenCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCPU.Location = new System.Drawing.Point(270, 94);
            this.btnOpenCPU.Name = "btnOpenCPU";
            this.btnOpenCPU.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCPU.TabIndex = 16;
            this.btnOpenCPU.Text = "Ver";
            this.btnOpenCPU.UseVisualStyleBackColor = true;
            this.btnOpenCPU.Click += new System.EventHandler(this.btnOpenCPU_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(368, 353);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel5.Location = new System.Drawing.Point(12, 269);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(76, 16);
            this.metroLabel5.TabIndex = 6;
            this.metroLabel5.Text = "ID del raton";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel4.Location = new System.Drawing.Point(12, 210);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(91, 16);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "ID del teclado";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel3.Location = new System.Drawing.Point(12, 156);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(90, 16);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "ID del monitor";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel2.Location = new System.Drawing.Point(12, 97);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 16);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "ID del CPU";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroLabel1.Location = new System.Drawing.Point(12, 46);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(88, 16);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "ID del equipo";
            // 
            // picFondo
            // 
            this.picFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFondo.Image = global::Reportes_CentroComputo.Properties.Resources.Logo2;
            this.picFondo.Location = new System.Drawing.Point(0, 0);
            this.picFondo.Name = "picFondo";
            this.picFondo.Size = new System.Drawing.Size(455, 388);
            this.picFondo.TabIndex = 13;
            this.picFondo.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 388);
            this.Controls.Add(this.panelFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipo";
            this.Load += new System.EventHandler(this.FEquipo_Load);
            this.panelFondo.ResumeLayout(false);
            this.panelFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Label metroLabel5;
        private System.Windows.Forms.Label metroLabel4;
        private System.Windows.Forms.Label metroLabel3;
        private System.Windows.Forms.Label metroLabel2;
        private System.Windows.Forms.Label metroLabel1;
        private System.Windows.Forms.PictureBox picFondo;
        private System.Windows.Forms.TextBox txtIDRaton;
        private System.Windows.Forms.TextBox txtIDTeclado;
        private System.Windows.Forms.TextBox txtIDMonitor;
        private System.Windows.Forms.TextBox txtIDCPU;
        private System.Windows.Forms.TextBox txtIDEquipo;
        private System.Windows.Forms.Button btnOpenCPU;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button1;
    }
}