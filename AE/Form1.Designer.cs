namespace AE
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.imagen_cargar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iniciar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t_umbral_distancia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.t_umbral = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.num_indi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.image_final = new System.Windows.Forms.PictureBox();
            this.acciones_realizadas = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.f_cruce = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.f_mutacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagen_cargar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_final)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openfile";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Examinar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imagen_cargar
            // 
            this.imagen_cargar.Location = new System.Drawing.Point(25, 94);
            this.imagen_cargar.Name = "imagen_cargar";
            this.imagen_cargar.Size = new System.Drawing.Size(229, 230);
            this.imagen_cargar.TabIndex = 1;
            this.imagen_cargar.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Imagen original";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // iniciar
            // 
            this.iniciar.Enabled = false;
            this.iniciar.Location = new System.Drawing.Point(378, 404);
            this.iniciar.Name = "iniciar";
            this.iniciar.Size = new System.Drawing.Size(75, 23);
            this.iniciar.TabIndex = 4;
            this.iniciar.Text = "Iniciar";
            this.iniciar.UseVisualStyleBackColor = true;
            this.iniciar.Click += new System.EventHandler(this.iniciar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.t_umbral_distancia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.t_umbral);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.num_indi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(27, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 152);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros del AE";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // t_umbral_distancia
            // 
            this.t_umbral_distancia.Location = new System.Drawing.Point(115, 62);
            this.t_umbral_distancia.Name = "t_umbral_distancia";
            this.t_umbral_distancia.Size = new System.Drawing.Size(100, 20);
            this.t_umbral_distancia.TabIndex = 5;
            this.t_umbral_distancia.Text = "5";
            this.t_umbral_distancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Umbral distancia:";
            // 
            // t_umbral
            // 
            this.t_umbral.Location = new System.Drawing.Point(115, 38);
            this.t_umbral.Name = "t_umbral";
            this.t_umbral.Size = new System.Drawing.Size(100, 20);
            this.t_umbral.TabIndex = 3;
            this.t_umbral.Text = "100";
            this.t_umbral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Umbral de grises:";
            // 
            // num_indi
            // 
            this.num_indi.Location = new System.Drawing.Point(91, 16);
            this.num_indi.Name = "num_indi";
            this.num_indi.Size = new System.Drawing.Size(124, 20);
            this.num_indi.TabIndex = 1;
            this.num_indi.Text = "100";
            this.num_indi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Num Individuos";
            // 
            // image_final
            // 
            this.image_final.Location = new System.Drawing.Point(297, 56);
            this.image_final.Name = "image_final";
            this.image_final.Size = new System.Drawing.Size(675, 329);
            this.image_final.TabIndex = 6;
            this.image_final.TabStop = false;
            // 
            // acciones_realizadas
            // 
            this.acciones_realizadas.FormattingEnabled = true;
            this.acciones_realizadas.Location = new System.Drawing.Point(659, 404);
            this.acciones_realizadas.Name = "acciones_realizadas";
            this.acciones_realizadas.Size = new System.Drawing.Size(313, 69);
            this.acciones_realizadas.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(656, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Acciones realizadas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.f_mutacion);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.f_cruce);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(8, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 64);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Factores";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cruce";
            // 
            // f_cruce
            // 
            this.f_cruce.Location = new System.Drawing.Point(106, 15);
            this.f_cruce.Name = "f_cruce";
            this.f_cruce.Size = new System.Drawing.Size(100, 20);
            this.f_cruce.TabIndex = 1;
            this.f_cruce.Text = "0.5";
            this.f_cruce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mutación";
            // 
            // f_mutacion
            // 
            this.f_mutacion.Location = new System.Drawing.Point(106, 40);
            this.f_mutacion.Name = "f_mutacion";
            this.f_mutacion.Size = new System.Drawing.Size(100, 20);
            this.f_mutacion.TabIndex = 3;
            this.f_mutacion.Text = "0.5";
            this.f_mutacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 512);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.acciones_realizadas);
            this.Controls.Add(this.image_final);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.iniciar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imagen_cargar);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imagen_cargar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_final)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox imagen_cargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button iniciar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox num_indi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_umbral;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_umbral_distancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox image_final;
        private System.Windows.Forms.ListBox acciones_realizadas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox f_mutacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox f_cruce;
        private System.Windows.Forms.Label label6;
    }
}

