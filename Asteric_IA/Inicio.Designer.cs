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
            this.buttonCargar = new System.Windows.Forms.Button();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.panelCuadro = new System.Windows.Forms.Panel();
            this.labelMaxColumnas = new System.Windows.Forms.Label();
            this.comboBoxVelocidad = new System.Windows.Forms.ComboBox();
            this.buttonCamino = new System.Windows.Forms.Button();
            this.textBoxInicio = new System.Windows.Forms.TextBox();
            this.textBoxFinal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCargar
            // 
            this.buttonCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCargar.ForeColor = System.Drawing.Color.Navy;
            this.buttonCargar.Location = new System.Drawing.Point(15, 73);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(109, 23);
            this.buttonCargar.TabIndex = 5;
            this.buttonCargar.Text = "Cargar Matriz";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReiniciar.ForeColor = System.Drawing.Color.Navy;
            this.buttonReiniciar.Location = new System.Drawing.Point(12, 162);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(109, 23);
            this.buttonReiniciar.TabIndex = 12;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = true;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonIniciar.ForeColor = System.Drawing.Color.Navy;
            this.buttonIniciar.Location = new System.Drawing.Point(15, 120);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(109, 23);
            this.buttonIniciar.TabIndex = 13;
            this.buttonIniciar.Text = "Iniciar";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // panelCuadro
            // 
            this.panelCuadro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.panelCuadro.Location = new System.Drawing.Point(231, 12);
            this.panelCuadro.Name = "panelCuadro";
            this.panelCuadro.Size = new System.Drawing.Size(419, 233);
            this.panelCuadro.TabIndex = 14;
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
            this.comboBoxVelocidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.comboBoxVelocidad.FormattingEnabled = true;
            this.comboBoxVelocidad.Items.AddRange(new object[] {
            "RAPIDO",
            "MEDIO",
            "LENTO"});
            this.comboBoxVelocidad.Location = new System.Drawing.Point(15, 31);
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
            this.buttonCamino.Location = new System.Drawing.Point(15, 208);
            this.buttonCamino.Name = "buttonCamino";
            this.buttonCamino.Size = new System.Drawing.Size(109, 23);
            this.buttonCamino.TabIndex = 18;
            this.buttonCamino.Text = "Camino";
            this.buttonCamino.UseVisualStyleBackColor = true;
            this.buttonCamino.Click += new System.EventHandler(this.buttonCamino_Click);
            // 
            // textBoxInicio
            // 
            this.textBoxInicio.Location = new System.Drawing.Point(15, 276);
            this.textBoxInicio.Name = "textBoxInicio";
            this.textBoxInicio.Size = new System.Drawing.Size(60, 20);
            this.textBoxInicio.TabIndex = 19;
            // 
            // textBoxFinal
            // 
            this.textBoxFinal.Location = new System.Drawing.Point(15, 302);
            this.textBoxFinal.Name = "textBoxFinal";
            this.textBoxFinal.Size = new System.Drawing.Size(60, 20);
            this.textBoxFinal.TabIndex = 20;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1195, 626);
            this.Controls.Add(this.textBoxFinal);
            this.Controls.Add(this.textBoxInicio);
            this.Controls.Add(this.buttonCamino);
            this.Controls.Add(this.comboBoxVelocidad);
            this.Controls.Add(this.panelCuadro);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.labelMaxColumnas);
            this.Controls.Add(this.buttonCargar);
            this.Name = "Inicio";
            this.Text = "Asteric";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.Button buttonReiniciar;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.Panel panelCuadro;
        private System.Windows.Forms.Label labelMaxColumnas;
        private System.Windows.Forms.ComboBox comboBoxVelocidad;
        private System.Windows.Forms.Button buttonCamino;
        private System.Windows.Forms.TextBox textBoxInicio;
        private System.Windows.Forms.TextBox textBoxFinal;
    }
}

