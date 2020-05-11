namespace Asteric_IA
{
    partial class Inicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.buttonCargar = new System.Windows.Forms.Button();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.panelCuadro = new System.Windows.Forms.Panel();
            this.labelMaxColumnas = new System.Windows.Forms.Label();
            this.comboBoxVelocidad = new System.Windows.Forms.ComboBox();
            this.buttonCamino = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCargar
            // 
            this.buttonCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCargar.ForeColor = System.Drawing.Color.Navy;
            this.buttonCargar.Location = new System.Drawing.Point(115, 12);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(109, 23);
            this.buttonCargar.TabIndex = 5;
            this.buttonCargar.Text = "Cargar Mapa";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonIniciar.ForeColor = System.Drawing.Color.Navy;
            this.buttonIniciar.Location = new System.Drawing.Point(240, 12);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(67, 23);
            this.buttonIniciar.TabIndex = 13;
            this.buttonIniciar.Text = "Iniciar";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // panelCuadro
            // 
            this.panelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.panelCuadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCuadro.Location = new System.Drawing.Point(30, 70);
            this.panelCuadro.Name = "panelCuadro";
            this.panelCuadro.Size = new System.Drawing.Size(1000, 600);
            this.panelCuadro.TabIndex = 14;
            this.panelCuadro.Click += new System.EventHandler(this.panelCuadro_Click);
            // 
            // labelMaxColumnas
            // 
            this.labelMaxColumnas.AutoSize = true;
            this.labelMaxColumnas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelMaxColumnas.Location = new System.Drawing.Point(12, 208);
            this.labelMaxColumnas.Name = "labelMaxColumnas";
            this.labelMaxColumnas.Size = new System.Drawing.Size(10, 13);
            this.labelMaxColumnas.TabIndex = 8;
            this.labelMaxColumnas.Text = "-";
            // 
            // comboBoxVelocidad
            // 
            this.comboBoxVelocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVelocidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.comboBoxVelocidad.FormattingEnabled = true;
            this.comboBoxVelocidad.Items.AddRange(new object[] {
            "RAPIDO",
            "MEDIO",
            "LENTO"});
            this.comboBoxVelocidad.Location = new System.Drawing.Point(3, 11);
            this.comboBoxVelocidad.Name = "comboBoxVelocidad";
            this.comboBoxVelocidad.Size = new System.Drawing.Size(106, 21);
            this.comboBoxVelocidad.TabIndex = 17;
            this.comboBoxVelocidad.Text = "RAPIDO";
            this.comboBoxVelocidad.SelectedIndexChanged += new System.EventHandler(this.comboBoxVelocidad_SelectedIndexChanged);
            // 
            // buttonCamino
            // 
            this.buttonCamino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCamino.ForeColor = System.Drawing.Color.Navy;
            this.buttonCamino.Location = new System.Drawing.Point(323, 12);
            this.buttonCamino.Name = "buttonCamino";
            this.buttonCamino.Size = new System.Drawing.Size(67, 23);
            this.buttonCamino.TabIndex = 18;
            this.buttonCamino.Text = "Camino";
            this.buttonCamino.UseVisualStyleBackColor = true;
            this.buttonCamino.Click += new System.EventHandler(this.buttonCamino_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxVelocidad);
            this.panel1.Controls.Add(this.buttonCargar);
            this.panel1.Controls.Add(this.buttonIniciar);
            this.panel1.Controls.Add(this.buttonCamino);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 50);
            this.panel1.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(203)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(30, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 20);
            this.panel3.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(203)))));
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1030, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(29, 639);
            this.panel4.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(203)))));
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(30, 670);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1000, 19);
            this.panel5.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(203)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(30, 639);
            this.panel2.TabIndex = 22;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1059, 689);
            this.Controls.Add(this.panelCuadro);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMaxColumnas);
            this.Name = "Inicio";
            this.Text = "Asteric";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.Panel panelCuadro;
        private System.Windows.Forms.Label labelMaxColumnas;
        private System.Windows.Forms.ComboBox comboBoxVelocidad;
        private System.Windows.Forms.Button buttonCamino;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}

