namespace Proyecto_Calle
{
    partial class Nivel8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nivel8));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.HiScore = new System.Windows.Forms.Label();
            this.SumaPuntos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Policias = new System.Windows.Forms.Label();
            this.Jugador = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.segundos = new System.Windows.Forms.Label();
            this.Movimiento = new System.Windows.Forms.Timer(this.components);
            this.Crear_Carro = new System.Windows.Forms.Timer(this.components);
            this.Tiempo = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Muerte = new System.Windows.Forms.Timer(this.components);
            this.Disable_KeyDown = new System.Windows.Forms.Timer(this.components);
            this.Detener_Carros = new System.Windows.Forms.Timer(this.components);
            this.Carril1 = new System.Windows.Forms.PictureBox();
            this.Carril2 = new System.Windows.Forms.PictureBox();
            this.Carril3 = new System.Windows.Forms.PictureBox();
            this.Carril4 = new System.Windows.Forms.PictureBox();
            this.Pausar_Punteo = new System.Windows.Forms.Timer(this.components);
            this.Policia_de_Transito = new System.Windows.Forms.Timer(this.components);
            this.EspacioSemaforo = new System.Windows.Forms.PictureBox();
            this.Semaforos = new System.Windows.Forms.PictureBox();
            this.Semaforo_Verde_Rojo = new System.Windows.Forms.Timer(this.components);
            this.PantallaFinal = new System.Windows.Forms.PictureBox();
            this.MensajeFinal = new System.Windows.Forms.Label();
            this.BotonMenu = new System.Windows.Forms.Button();
            this.BotonVolverajugar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Ancianos_por_rescatar = new System.Windows.Forms.Label();
            this.Perro_Imagen = new System.Windows.Forms.PictureBox();
            this.Meta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Jugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EspacioSemaforo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Semaforos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PantallaFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Perro_Imagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Meta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(115, 507);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hi Score:";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.Color.Transparent;
            this.Score.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Score.Location = new System.Drawing.Point(75, 507);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(20, 21);
            this.Score.TabIndex = 2;
            this.Score.Text = "0";
            // 
            // HiScore
            // 
            this.HiScore.AutoSize = true;
            this.HiScore.BackColor = System.Drawing.Color.Transparent;
            this.HiScore.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HiScore.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.HiScore.Location = new System.Drawing.Point(194, 507);
            this.HiScore.Name = "HiScore";
            this.HiScore.Size = new System.Drawing.Size(20, 21);
            this.HiScore.TabIndex = 3;
            this.HiScore.Text = "0";
            // 
            // SumaPuntos
            // 
            this.SumaPuntos.AutoSize = true;
            this.SumaPuntos.BackColor = System.Drawing.Color.Transparent;
            this.SumaPuntos.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumaPuntos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SumaPuntos.Location = new System.Drawing.Point(86, 470);
            this.SumaPuntos.Name = "SumaPuntos";
            this.SumaPuntos.Size = new System.Drawing.Size(0, 21);
            this.SumaPuntos.TabIndex = 4;
            this.SumaPuntos.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(695, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Policias de transito:";
            // 
            // Policias
            // 
            this.Policias.AutoSize = true;
            this.Policias.BackColor = System.Drawing.Color.Transparent;
            this.Policias.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Policias.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Policias.Location = new System.Drawing.Point(854, 507);
            this.Policias.Name = "Policias";
            this.Policias.Size = new System.Drawing.Size(20, 21);
            this.Policias.TabIndex = 6;
            this.Policias.Text = "0";
            // 
            // Jugador
            // 
            this.Jugador.BackColor = System.Drawing.Color.Transparent;
            this.Jugador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Jugador.Image = global::Proyecto_Calle.Properties.Resources.Personaje_Frente_1;
            this.Jugador.Location = new System.Drawing.Point(475, 419);
            this.Jugador.Name = "Jugador";
            this.Jugador.Size = new System.Drawing.Size(44, 68);
            this.Jugador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Jugador.TabIndex = 8;
            this.Jugador.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(241, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tiempo:";
            // 
            // segundos
            // 
            this.segundos.AutoSize = true;
            this.segundos.BackColor = System.Drawing.Color.Transparent;
            this.segundos.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.segundos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.segundos.Location = new System.Drawing.Point(309, 507);
            this.segundos.Name = "segundos";
            this.segundos.Size = new System.Drawing.Size(30, 21);
            this.segundos.TabIndex = 10;
            this.segundos.Text = "50";
            // 
            // Movimiento
            // 
            this.Movimiento.Enabled = true;
            this.Movimiento.Interval = 120;
            this.Movimiento.Tick += new System.EventHandler(this.Movimiento_Tick);
            // 
            // Crear_Carro
            // 
            this.Crear_Carro.Enabled = true;
            this.Crear_Carro.Interval = 2000;
            this.Crear_Carro.Tick += new System.EventHandler(this.Crear_Carro_Tick);
            // 
            // Tiempo
            // 
            this.Tiempo.Enabled = true;
            this.Tiempo.Interval = 1000;
            this.Tiempo.Tick += new System.EventHandler(this.Tiempo_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_Calle.Properties.Resources.Pausa;
            this.pictureBox1.Location = new System.Drawing.Point(906, 492);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Muerte
            // 
            this.Muerte.Interval = 1000;
            this.Muerte.Tick += new System.EventHandler(this.Muerte_Tick);
            // 
            // Disable_KeyDown
            // 
            this.Disable_KeyDown.Interval = 190;
            this.Disable_KeyDown.Tick += new System.EventHandler(this.Disable_KeyDown_Tick);
            // 
            // Detener_Carros
            // 
            this.Detener_Carros.Interval = 200;
            this.Detener_Carros.Tick += new System.EventHandler(this.Detener_Carros_Tick);
            // 
            // Carril1
            // 
            this.Carril1.BackColor = System.Drawing.Color.Transparent;
            this.Carril1.Location = new System.Drawing.Point(-1, 372);
            this.Carril1.Name = "Carril1";
            this.Carril1.Size = new System.Drawing.Size(960, 41);
            this.Carril1.TabIndex = 12;
            this.Carril1.TabStop = false;
            this.Carril1.Visible = false;
            // 
            // Carril2
            // 
            this.Carril2.BackColor = System.Drawing.Color.Transparent;
            this.Carril2.Location = new System.Drawing.Point(-1, 294);
            this.Carril2.Name = "Carril2";
            this.Carril2.Size = new System.Drawing.Size(960, 38);
            this.Carril2.TabIndex = 13;
            this.Carril2.TabStop = false;
            this.Carril2.Visible = false;
            // 
            // Carril3
            // 
            this.Carril3.BackColor = System.Drawing.Color.Transparent;
            this.Carril3.Location = new System.Drawing.Point(-1, 167);
            this.Carril3.Name = "Carril3";
            this.Carril3.Size = new System.Drawing.Size(960, 42);
            this.Carril3.TabIndex = 14;
            this.Carril3.TabStop = false;
            this.Carril3.Visible = false;
            // 
            // Carril4
            // 
            this.Carril4.BackColor = System.Drawing.Color.Transparent;
            this.Carril4.Location = new System.Drawing.Point(-1, 90);
            this.Carril4.Name = "Carril4";
            this.Carril4.Size = new System.Drawing.Size(960, 45);
            this.Carril4.TabIndex = 15;
            this.Carril4.TabStop = false;
            this.Carril4.Visible = false;
            // 
            // Pausar_Punteo
            // 
            this.Pausar_Punteo.Interval = 1000;
            this.Pausar_Punteo.Tick += new System.EventHandler(this.Pausar_Punteo_Tick);
            // 
            // Policia_de_Transito
            // 
            this.Policia_de_Transito.Interval = 5000;
            this.Policia_de_Transito.Tick += new System.EventHandler(this.Policia_de_Transito_Tick);
            // 
            // EspacioSemaforo
            // 
            this.EspacioSemaforo.Enabled = false;
            this.EspacioSemaforo.Location = new System.Drawing.Point(858, 294);
            this.EspacioSemaforo.Name = "EspacioSemaforo";
            this.EspacioSemaforo.Size = new System.Drawing.Size(101, 119);
            this.EspacioSemaforo.TabIndex = 16;
            this.EspacioSemaforo.TabStop = false;
            this.EspacioSemaforo.Visible = false;
            // 
            // Semaforos
            // 
            this.Semaforos.BackColor = System.Drawing.Color.Transparent;
            this.Semaforos.Enabled = false;
            this.Semaforos.Image = global::Proyecto_Calle.Properties.Resources.Semaforo;
            this.Semaforos.Location = new System.Drawing.Point(883, 215);
            this.Semaforos.Name = "Semaforos";
            this.Semaforos.Size = new System.Drawing.Size(76, 73);
            this.Semaforos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Semaforos.TabIndex = 17;
            this.Semaforos.TabStop = false;
            this.Semaforos.Visible = false;
            // 
            // Semaforo_Verde_Rojo
            // 
            this.Semaforo_Verde_Rojo.Interval = 10;
            this.Semaforo_Verde_Rojo.Tick += new System.EventHandler(this.Semaforo_Verde_Rojo_Tick);
            // 
            // PantallaFinal
            // 
            this.PantallaFinal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PantallaFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PantallaFinal.Enabled = false;
            this.PantallaFinal.Location = new System.Drawing.Point(929, 429);
            this.PantallaFinal.Name = "PantallaFinal";
            this.PantallaFinal.Size = new System.Drawing.Size(30, 38);
            this.PantallaFinal.TabIndex = 18;
            this.PantallaFinal.TabStop = false;
            this.PantallaFinal.Visible = false;
            // 
            // MensajeFinal
            // 
            this.MensajeFinal.AutoSize = true;
            this.MensajeFinal.BackColor = System.Drawing.Color.Black;
            this.MensajeFinal.Enabled = false;
            this.MensajeFinal.Font = new System.Drawing.Font("Tempus Sans ITC", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MensajeFinal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MensajeFinal.Location = new System.Drawing.Point(-552, 361);
            this.MensajeFinal.Name = "MensajeFinal";
            this.MensajeFinal.Size = new System.Drawing.Size(591, 126);
            this.MensajeFinal.TabIndex = 19;
            this.MensajeFinal.Text = "MensajeFinal";
            this.MensajeFinal.Visible = false;
            // 
            // BotonMenu
            // 
            this.BotonMenu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BotonMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonMenu.Enabled = false;
            this.BotonMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BotonMenu.Font = new System.Drawing.Font("Tempus Sans ITC", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonMenu.ForeColor = System.Drawing.Color.Yellow;
            this.BotonMenu.Location = new System.Drawing.Point(870, 429);
            this.BotonMenu.Name = "BotonMenu";
            this.BotonMenu.Size = new System.Drawing.Size(23, 32);
            this.BotonMenu.TabIndex = 20;
            this.BotonMenu.Text = "Menu";
            this.BotonMenu.UseVisualStyleBackColor = false;
            this.BotonMenu.Visible = false;
            this.BotonMenu.Click += new System.EventHandler(this.BotonMenu_Click);
            // 
            // BotonVolverajugar
            // 
            this.BotonVolverajugar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BotonVolverajugar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonVolverajugar.Enabled = false;
            this.BotonVolverajugar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BotonVolverajugar.Font = new System.Drawing.Font("Tempus Sans ITC", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonVolverajugar.ForeColor = System.Drawing.Color.Yellow;
            this.BotonVolverajugar.Location = new System.Drawing.Point(899, 429);
            this.BotonVolverajugar.Name = "BotonVolverajugar";
            this.BotonVolverajugar.Size = new System.Drawing.Size(24, 30);
            this.BotonVolverajugar.TabIndex = 21;
            this.BotonVolverajugar.Text = "Volver a jugar?";
            this.BotonVolverajugar.UseVisualStyleBackColor = false;
            this.BotonVolverajugar.Visible = false;
            this.BotonVolverajugar.Click += new System.EventHandler(this.BotonVolverajugar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(358, 507);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mascotas por ayudar:";
            // 
            // Ancianos_por_rescatar
            // 
            this.Ancianos_por_rescatar.AutoSize = true;
            this.Ancianos_por_rescatar.BackColor = System.Drawing.Color.Transparent;
            this.Ancianos_por_rescatar.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ancianos_por_rescatar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Ancianos_por_rescatar.Location = new System.Drawing.Point(526, 507);
            this.Ancianos_por_rescatar.Name = "Ancianos_por_rescatar";
            this.Ancianos_por_rescatar.Size = new System.Drawing.Size(20, 21);
            this.Ancianos_por_rescatar.TabIndex = 23;
            this.Ancianos_por_rescatar.Text = "3";
            // 
            // Perro_Imagen
            // 
            this.Perro_Imagen.BackColor = System.Drawing.Color.Transparent;
            this.Perro_Imagen.Image = global::Proyecto_Calle.Properties.Resources.Perro;
            this.Perro_Imagen.Location = new System.Drawing.Point(635, 278);
            this.Perro_Imagen.Name = "Perro_Imagen";
            this.Perro_Imagen.Size = new System.Drawing.Size(75, 70);
            this.Perro_Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Perro_Imagen.TabIndex = 24;
            this.Perro_Imagen.TabStop = false;
            // 
            // Meta
            // 
            this.Meta.BackColor = System.Drawing.Color.Transparent;
            this.Meta.Location = new System.Drawing.Point(-1, 1);
            this.Meta.Name = "Meta";
            this.Meta.Size = new System.Drawing.Size(960, 69);
            this.Meta.TabIndex = 25;
            this.Meta.TabStop = false;
            this.Meta.Visible = false;
            // 
            // Nivel8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Calle.Properties.Resources.Nivel1_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(959, 541);
            this.Controls.Add(this.Meta);
            this.Controls.Add(this.Ancianos_por_rescatar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BotonVolverajugar);
            this.Controls.Add(this.BotonMenu);
            this.Controls.Add(this.MensajeFinal);
            this.Controls.Add(this.PantallaFinal);
            this.Controls.Add(this.Semaforos);
            this.Controls.Add(this.EspacioSemaforo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.segundos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Jugador);
            this.Controls.Add(this.Policias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SumaPuntos);
            this.Controls.Add(this.HiScore);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Perro_Imagen);
            this.Controls.Add(this.Carril2);
            this.Controls.Add(this.Carril1);
            this.Controls.Add(this.Carril3);
            this.Controls.Add(this.Carril4);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nivel8";
            this.Text = "Rescatar Mascotas- Facil";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nivel1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Jugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carril4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EspacioSemaforo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Semaforos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PantallaFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Perro_Imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Meta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label HiScore;
        private System.Windows.Forms.Label SumaPuntos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Policias;
        private System.Windows.Forms.PictureBox Jugador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label segundos;
        private System.Windows.Forms.Timer Movimiento;
        private System.Windows.Forms.Timer Crear_Carro;
        private System.Windows.Forms.Timer Tiempo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer Muerte;
        private System.Windows.Forms.Timer Disable_KeyDown;
        private System.Windows.Forms.Timer Detener_Carros;
        private System.Windows.Forms.PictureBox Carril1;
        private System.Windows.Forms.PictureBox Carril2;
        private System.Windows.Forms.PictureBox Carril3;
        private System.Windows.Forms.PictureBox Carril4;
        private System.Windows.Forms.Timer Pausar_Punteo;
        private System.Windows.Forms.Timer Policia_de_Transito;
        private System.Windows.Forms.PictureBox EspacioSemaforo;
        private System.Windows.Forms.PictureBox Semaforos;
        private System.Windows.Forms.Timer Semaforo_Verde_Rojo;
        private System.Windows.Forms.PictureBox PantallaFinal;
        private System.Windows.Forms.Label MensajeFinal;
        private System.Windows.Forms.Button BotonMenu;
        private System.Windows.Forms.Button BotonVolverajugar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Ancianos_por_rescatar;
        private System.Windows.Forms.PictureBox Perro_Imagen;
        private System.Windows.Forms.PictureBox Meta;
    }
}