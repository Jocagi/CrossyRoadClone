using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Proyecto_Calle
{
    public partial class Nivel6 : Form
    {
        //Guardado
        int identificador = 5; //Este nivel
        String ArchivoPuntaje = "PuntajeNiveles.txt";
        String ArchivoPolicias = "Policias_de_transito.txt";
        String[,] MatrizGuardado = new String[2, 9];

        List<PictureBox> ListaCarros = new List<PictureBox>();
        List<PictureBox> Hitboxes = new List<PictureBox>();
        List<PictureBox> Transitos = new List<PictureBox>();
        
        Random aleatorio = new Random();
        bool Mover_Personaje = true;
        bool pausa = false;
        bool victoria = false;
        bool carro_detenido = false;

        int Policias_en_Pantalla = 0;
        int ContadorEmetras = -1;

        bool Movimiento_Combinado = false;

        //Posiciones
        const int Pos1 = 360;
        const int Pos2 = 220;
        const int Pos3 = 140;
        const int Pos4 = 70;

        //Detener carros
        bool policia = false;
        String Color_Semaforo = "Rojo";

        bool anciano = false; //otros modos de juego
        bool chucho = false; //otros modos de juego

        int punteo = 0;
        int Cont_Pausa = 0;
        int[] VelocidadCarril = new int[4] { 20, 20, 20, 20 };

        int AnimacionPersonaje = 1;
        int Interceptor = -1;

        public Nivel6()
        {
            InitializeComponent();

            LeerDatos(); //Datos de guardado

            this.Jugador.Location = new Point(475, 415); //Posicion constante

            //Evitar problema de la exepcion del policia
            Policias_en_Pantalla++;
            Policia_de_Transito.Enabled = true;
            policia = true;
            PictureBox Emetra = new PictureBox();
            Emetra.Location = new Point(-5000, -5000);
            Emetra.Size = new System.Drawing.Size(1, 1);
            Transitos.Add(Emetra);
            this.Controls.Add(Emetra);
            ContadorEmetras++;
            //

        }
        
        //Carril
        public void CarrosAleatorios(List<PictureBox> Carros, Form Juego, int carril) //Aparicion de carros
        {
            string Color = "Verde";
            int Probabilidad = aleatorio.Next(0, 100);
            int UbicacionCarro = carril; //Carril en el que aparecera el carro

            if (Probabilidad <= 60) //60% de apararicion de carros amarillos
            {
                Color = "Amarillo";
            }
            if (Probabilidad > 60 && Probabilidad <= 75) //25% de apararicion de carros verdes
            {
                Color = "Negro";
            }
            if (Probabilidad > 75 && Probabilidad <= 94) //10% de apararicion de carros azules
            {
                Color = "Azul";
            }
            if (Probabilidad > 94 && Probabilidad <= 98) //4% de apararicion de carros rojos
            {
                Color = "Rojo";
            }
            if (Probabilidad > 98) //1% de aparicion de carros negros
            {
                Color = "Verde";
            }

            //Crear carro 
            PictureBox carro = new PictureBox();
            carro.Location = new Point(0, UbicacionCarro);
            switch (Color)
            {
                case "Amarillo":
                    carro.Image = (Bitmap)Properties.Resources.CarroAmarillo;
                    break;
                case "Azul":
                    carro.Image = (Bitmap)Properties.Resources.CarroAzul;
                    break;
                case "Verde":
                    carro.Image = (Bitmap)Properties.Resources.CarroVerde;
                    break;
                case "Rojo":
                    carro.Image = (Bitmap)Properties.Resources.CarroRojo;
                    break;
                case "Negro":
                    carro.Image = (Bitmap)Properties.Resources.CarroNegro;
                    break;
                default:
                    break;
            }
            carro.SizeMode = PictureBoxSizeMode.AutoSize;
            carro.BackColor = System.Drawing.Color.Transparent;
            //carro.BackColor = System.Drawing.Color.Aqua; //pruebas

            carro.Size = new System.Drawing.Size(70, 35);
            carro.Tag = Color;

            ListaCarros.Add(carro);
            Juego.Controls.Add(carro);


            //Detectar que hay alredeor del carro
            //Hitboxes

            PictureBox hitbox = new PictureBox();
            hitbox.Location = new Point(100, UbicacionCarro +10);
            hitbox.BackColor = System.Drawing.Color.Transparent;
            //hitbox.BackColor = System.Drawing.Color.BlueViolet; //pruebas
            hitbox.Size = new System.Drawing.Size(85, 25);
            hitbox.SendToBack();
            hitbox.Visible = false;

            Hitboxes.Add(hitbox);
            Juego.Controls.Add(hitbox);

        }

        private void Movimiento_Tick(object sender, EventArgs e)
        {
            carro_detenido = false;
            
            try
            {

                if (pausa == false)
                {
                    //Mover carros

                    MovimientoCarros();

                    
                    if (Detener_Carros.Enabled == false)
                    {
                        RestaurarVelocidad();

                        Interceptor = -1; 

                        //Colision

                        for (int i = 0; i < ListaCarros.Count; i++)
                        {
                            //Resetear ancianos
                            if (ListaCarros[i].Bounds.IntersectsWith(Anciano_Imagen.Bounds) && anciano == false)
                            {
                                Anciano_Imagen.Location = new Point(80, 415);
                            }


                            if (ListaCarros[i].Bounds.IntersectsWith(Jugador.Bounds)) //Colision carro-jugador (perder vidas)
                            {
                                Jugador.Size = new System.Drawing.Size(75, 45);
                                Detener();
                                this.Jugador.Image = (Bitmap)Properties.Resources.Death;
                                Muerte.Enabled = true;
                                
                            }
                            
                            if (ListaCarros[i].Location.X >= 950) //Remover tras salir del limite
                            {
                                this.Controls.Remove(ListaCarros[i]);
                                ListaCarros.Remove(ListaCarros[i]);

                                this.Controls.Remove(Hitboxes[i]);
                                Hitboxes.Remove(Hitboxes[i]);
                            }

                            //verificacion carro verde - azul - semaforo - policia (Detener carros)

                            if (((ListaCarros[i].Tag.ToString() == "Verde" || ListaCarros[i].Tag.ToString() == "VerdeDetenido" || ((ListaCarros[i].Tag.ToString() == "Azul" || ListaCarros[i].Tag.ToString() == "AzulDetenido") && (anciano == true || chucho == true))) && Hitboxes[i].Bounds.IntersectsWith(Jugador.Bounds)) || (Hitboxes[i].Bounds.IntersectsWith(Transitos[ContadorEmetras].Bounds) && ListaCarros[i].Tag.ToString() != "Negro") || (Hitboxes[i].Bounds.IntersectsWith(EspacioSemaforo.Bounds) && Color_Semaforo == "Verde"))
                            {

                                for (int k = 0; k < ListaCarros.Count; k++) //Resuelve el error del carro gemelo
                                {
                                    if (ListaCarros[k].Tag.ToString() == "VerdeDetenido")
                                    {
                                        ListaCarros[k].Tag = "Verde";
                                    }
                                    if (ListaCarros[k].Tag.ToString() == "AzulDetenido")
                                    {
                                        ListaCarros[k].Tag = "Azul";
                                    }
                                    if (ListaCarros[k].Tag.ToString() == "AmarilloDetenido")
                                    {
                                        ListaCarros[k].Tag = "Amarillo";
                                    }
                                }

                                //Cambiar propiedad a "detenido"
                                if (ListaCarros[i].Tag.ToString() == "Verde")
                                {
                                    ListaCarros[i].Tag = "VerdeDetenido";
                                }
                                if (ListaCarros[i].Tag.ToString() == "Azul")
                                {
                                    ListaCarros[i].Tag = "AzulDetenido";
                                }
                                if (ListaCarros[i].Tag.ToString() == "Amarillo")
                                {
                                    ListaCarros[i].Tag = "AmarilloDetenido";
                                }

                                //Cambiar velocidad
                                if (ListaCarros[i].Bounds.IntersectsWith(Carril1.Bounds))
                                {
                                    VelocidadCarril[0] = 0;
                                    Interceptor = i;
                                }
                                if (ListaCarros[i].Bounds.IntersectsWith(Carril2.Bounds))
                                {
                                    VelocidadCarril[1] = 0;
                                    Interceptor = i;
                                }
                                if (ListaCarros[i].Bounds.IntersectsWith(Carril3.Bounds))
                                {
                                    VelocidadCarril[2] = 0;
                                    Interceptor = i;
                                }
                                if (ListaCarros[i].Bounds.IntersectsWith(Carril4.Bounds))
                                {
                                    VelocidadCarril[3] = 0;
                                    Interceptor = i;
                                }

                                Detener_Carros.Enabled = true;
                            }


                            //Verificacion carros rojos y negros
                            //Distingue diferentes carriles
                            if (carro_detenido == false && (ListaCarros[i].Location.X <= (Jugador.Location.X + 35)))
                            {
                                //if (Jugador.Bounds.IntersectsWith(Carril1.Bounds) && ListaCarros[i].Bounds.IntersectsWith(Carril2.Bounds) && (ListaCarros[i].Tag.ToString() == "Negro" || ListaCarros[i].Tag.ToString() == "Rojo"))
                                //{
                                //    ListaCarros[i].Location = new Point(ListaCarros[i].Location.X , Pos1);
                                //    Hitboxes[i].Location = new Point(Hitboxes[i].Location.X, Pos1);
                                //}
                                if (Jugador.Bounds.IntersectsWith(Carril2.Bounds) && ListaCarros[i].Bounds.IntersectsWith(Carril1.Bounds) && (ListaCarros[i].Tag.ToString() == "Negro" || ListaCarros[i].Tag.ToString() == "Rojo"))
                                {
                                    ListaCarros[i].Location = new Point(ListaCarros[i].Location.X , Pos2);
                                    Hitboxes[i].Location = new Point(Hitboxes[i].Location.X, Pos2);
                                }

                                if (Jugador.Bounds.IntersectsWith(Carril3.Bounds) && ListaCarros[i].Bounds.IntersectsWith(Carril4.Bounds) && (ListaCarros[i].Tag.ToString() == "Negro" || ListaCarros[i].Tag.ToString() == "Rojo"))
                                {
                                    ListaCarros[i].Location = new Point(ListaCarros[i].Location.X , Pos3);
                                    Hitboxes[i].Location = new Point(Hitboxes[i].Location.X, Pos3);
                                }
                                if (Jugador.Bounds.IntersectsWith(Carril4.Bounds) && ListaCarros[i].Bounds.IntersectsWith(Carril3.Bounds) && (ListaCarros[i].Tag.ToString() == "Negro" || ListaCarros[i].Tag.ToString() == "Rojo"))
                                {
                                    ListaCarros[i].Location = new Point(ListaCarros[i].Location.X , Pos4);
                                    Hitboxes[i].Location = new Point(Hitboxes[i].Location.X, Pos4);
                                }
                            }

                            //Anular la accion de un policia de transito
                            if (Transitos[ContadorEmetras].Bounds.IntersectsWith(ListaCarros[i].Bounds))
                            {
                                if (ListaCarros[i].Tag.ToString() == "Negro")
                                {

                                    Policia_de_Transito.Enabled = false;
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril1.Bounds)) { VelocidadCarril[0] = 20; }
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril2.Bounds)) { VelocidadCarril[1] = 20; }
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril3.Bounds)) { VelocidadCarril[2] = 20; }
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril4.Bounds)) { VelocidadCarril[3] = 20; }
                                    Transitos[ContadorEmetras].SetBounds(0, 0, 1, 1); 
                                    policia = false;
                                    this.Controls.Remove(Transitos[ContadorEmetras]);
                                    ListaCarros.Remove(Transitos[ContadorEmetras]);

                                    Policias_en_Pantalla = 0;
                                }
                                else
                                {
                                    Policias.Text = (Convert.ToInt16(Policias.Text) + 1).ToString();

                                    Policia_de_Transito.Enabled = false;
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril1.Bounds)) { VelocidadCarril[0] = 20; }
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril2.Bounds)) { VelocidadCarril[1] = 20; }
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril3.Bounds)) { VelocidadCarril[2] = 20; }
                                    if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril4.Bounds)) { VelocidadCarril[3] = 20; }
                                    Transitos[ContadorEmetras].SetBounds(0, 0, 1, 1);
                                    policia = false;
                                    this.Controls.Remove(Transitos[ContadorEmetras]);
                                    ListaCarros.Remove(Transitos[ContadorEmetras]);

                                    Policias_en_Pantalla = 0;
                                }
                            }


                            if (Hitboxes[i].Bounds.IntersectsWith(Jugador.Bounds)) //Esquivar un carro (punteo)
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    if (VelocidadCarril[k] == 0)
                                    {
                                        carro_detenido = true;
                                    }
                                }

                                if (carro_detenido == false)
                                {
                                    if (Pausar_Punteo.Enabled == false)
                                    {
                                        if (anciano == false && chucho == false)
                                        {
                                            punteo = Convert.ToInt16(Score.Text);
                                            punteo++;
                                            Score.Text = punteo.ToString();

                                            Pausar_Punteo.Enabled = true;
                                        }
                                        else
                                        {
                                            punteo = Convert.ToInt16(Score.Text);
                                            punteo += 2;
                                            Score.Text = punteo.ToString();

                                            Pausar_Punteo.Enabled = true;
                                        }

                                        //Policias por superar carro rojo
                                        if (ListaCarros[i].Tag.ToString() == "Rojo")
                                        {
                                            int policias;

                                            policias = Convert.ToInt16(Policias.Text);
                                            policias++;
                                            Policias.Text = policias.ToString();
                                            Pausar_Punteo.Enabled = true;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void Crear_Carro_Tick(object sender, EventArgs e)
        {
            //Crear nuevo carro

            int carril = aleatorio.Next(1, 3);
            int carril2 = aleatorio.Next(1, 3);

            switch (carril)
            {
                case 1:
                    if (VelocidadCarril[0] == 0)
                    {
                        if (VelocidadCarril[1] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos2);
                        }
                    }
                    else
                    {
                        if (VelocidadCarril[0] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos1);
                        }
                    }
                    break;
                case 2:
                    if (VelocidadCarril[1] == 0)
                    {
                        if (VelocidadCarril[0] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos1);
                        }
                    }
                    else
                    {
                        if (VelocidadCarril[1] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos2);
                        }
                    }
                    break;
                default:
                    break;
            }

            switch (carril2)
            {
                case 1:
                    if (VelocidadCarril[2] == 0)
                    {
                        if (VelocidadCarril[3] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos4);
                        }
                    }
                    else
                    {
                        if (VelocidadCarril[2] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos3);
                        }
                    }
                    break;
                case 2:
                    if (VelocidadCarril[3] == 0)
                    {
                        if (VelocidadCarril[2] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos3);
                        }
                    }
                    else
                    {
                        if (VelocidadCarril[3] != 0)
                        {
                            CarrosAleatorios(ListaCarros, this, Pos4);
                        }
                    }
                    break;
                default:
                    break;
            }

            //CarrosAleatorios(ListaCarros, this, 350, 305);
            //CarrosAleatorios(ListaCarros, this, 155, 85);
        }
        
        private void Tiempo_Tick(object sender, EventArgs e)
        {
            int time = Convert.ToInt16(segundos.Text);
            time--;
            segundos.Text = time.ToString();

            if (time <= 0)
            {
                GameOver();
            }
        }

        public void GameOver() //Agregar un... volver a jugar?
        {
            pictureBox1.Enabled = false;

            int policias;
            int puntos;
            int tiempo;

            int posicion;

            ListaCarros.Clear();
            Detener();

            if (victoria == true)
            { 
                //Puntos por segundo faltante
                puntos = Convert.ToInt16(Score.Text);
                tiempo = Convert.ToInt16(segundos.Text);

                puntos = puntos + (tiempo * 5);

                Score.Text = puntos.ToString();
                //


                policias = Convert.ToInt16(Policias.Text);
                policias++;
                Policias.Text = policias.ToString();


                if (Convert.ToInt16(Score.Text) > Convert.ToInt16(HiScore.Text))
                {
                    HiScore.Text = Score.Text;
                }

                posicion = Jugador.Location.X;

                Jugador.Image = (Bitmap)Properties.Resources.Victory;
                Jugador.Location = new Point(posicion, 55);

                //Mensaje de fin del juego

                PantallaFinal.Visible = true;
                PantallaFinal.Enabled = true;
                PantallaFinal.Size = new Size(690, 330);
                PantallaFinal.Location = new Point(140, 100);

                MensajeFinal.Visible = true;
                MensajeFinal.Enabled = true;
                MensajeFinal.Text = "Has Ganado!";
                MensajeFinal.Size = new Size(591, 126);
                MensajeFinal.Location = new Point(185, 140);
                MensajeFinal.BringToFront();

                BotonMenu.Visible = true;
                BotonMenu.Enabled = true;
                BotonMenu.Size = new Size(265, 65);
                BotonMenu.Location = new Point(205, 338);
                BotonMenu.BringToFront();

                BotonVolverajugar.Visible = true;
                BotonVolverajugar.Enabled = true;
                BotonVolverajugar.Size = new Size(280, 65);
                BotonVolverajugar.Location = new Point(495, 338);
                BotonVolverajugar.BringToFront();

                //Guardar datos

                MatrizGuardado[0, identificador] = HiScore.Text;
                MatrizGuardado[1, 0] = Policias.Text;
                GuardarDatos();

            }
            else
            {
                //Pantalla Game Over


                PantallaFinal.Visible = true;
                PantallaFinal.Enabled = true;
                PantallaFinal.Size = new Size(690, 330);
                PantallaFinal.Location = new Point(140, 100);

                MensajeFinal.Visible = true;
                MensajeFinal.Enabled = true;
                MensajeFinal.Text = "GAME OVER";
                MensajeFinal.Size = new Size(591, 126);
                MensajeFinal.Location = new Point(185, 140);
                MensajeFinal.BringToFront();

                BotonMenu.Visible = true;
                BotonMenu.Enabled = true;
                BotonMenu.Size = new Size(265, 65);
                BotonMenu.Location = new Point(205, 338);
                BotonMenu.BringToFront();

                BotonVolverajugar.Visible = true;
                BotonVolverajugar.Enabled = true;
                BotonVolverajugar.Size = new Size(280, 65);
                BotonVolverajugar.Location = new Point(495, 338);
                BotonVolverajugar.BringToFront();
            }
            
        }

        //Boton pausa
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Cont_Pausa == 0)
            {
                Detener();
                pictureBox1.Image = (Bitmap)Properties.Resources.Play;
            }
            else if (Cont_Pausa == 1)
            {
                Reanudar();
                pictureBox1.Image = (Bitmap)Properties.Resources.Pausa;
            }
        }

        private void Muerte_Tick(object sender, EventArgs e)
        {
            int puntos;

            puntos = Convert.ToInt16(Score.Text);
            puntos -= 5;
            Score.Text = puntos.ToString();

            if (Movimiento_Combinado == true)
            {
                puntos -= 5;
                Movimiento_Combinado = false;
                anciano = false;
                chucho = false;
            }

            this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Frente_1;
            this.Jugador.Location = new Point(475, 415);

            if (puntos <= 0)
            {
                puntos = 0;
                Score.Text = puntos.ToString();
            }

            Jugador.Size = new System.Drawing.Size(45, 70);
            Muerte.Enabled = false;
            Reanudar();
        }


        //Metodos de pausa
        public void Detener()
        {
            Movimiento.Enabled = false;
            Crear_Carro.Enabled = false;
            Tiempo.Enabled = false;
            Cont_Pausa++;

            pausa = true;
            

        }
        public void Reanudar()
        {
            Movimiento.Enabled = true;
            Crear_Carro.Enabled = true;
            Tiempo.Enabled = true;
            Cont_Pausa--;

            pausa = false;
        }

        public void MovimientoCarros()
        {

            //Movimiento
            int Movimiento = 0;

            foreach (PictureBox Carro in ListaCarros)
            {
                Movimiento = Carro.Location.X;

                //Determinar movimiento individual de cada carril
                if (Carro.Bounds.IntersectsWith(Carril1.Bounds)) 
                {
                    Movimiento += VelocidadCarril[0];
                }
                else if (Carro.Bounds.IntersectsWith(Carril2.Bounds))
                {
                    Movimiento += VelocidadCarril[1];
                }
                else if (Carro.Bounds.IntersectsWith(Carril3.Bounds))
                {
                    Movimiento += VelocidadCarril[2];
                }
                else if (Carro.Bounds.IntersectsWith(Carril4.Bounds))
                {
                    Movimiento += VelocidadCarril[3];
                }

                Carro.Location = new Point(Movimiento, Carro.Location.Y); //Nueva posicion
            }

            foreach (PictureBox Hitbox in Hitboxes)
            {
                Movimiento = Hitbox.Location.X;

                //Determinar movimiento individual de cada carril
                if (Hitbox.Bounds.IntersectsWith(Carril1.Bounds))
                {
                    Movimiento += VelocidadCarril[0];
                }
                else if (Hitbox.Bounds.IntersectsWith(Carril2.Bounds))
                {
                    Movimiento += VelocidadCarril[1];
                }
                else if (Hitbox.Bounds.IntersectsWith(Carril3.Bounds))
                {
                    Movimiento += VelocidadCarril[2];
                }
                else if (Hitbox.Bounds.IntersectsWith(Carril4.Bounds))
                {
                    Movimiento += VelocidadCarril[3];
                }

                Hitbox.Location = new Point(Movimiento, Hitbox.Location.Y);
            }

            if (Interceptor >= 0) //Movimiento de autos en la misma fila de un auto detenido
            {
                //Carros adelante
                for (int i = 0; i < Interceptor; i++)
                {
                    if (ListaCarros[i].Tag.ToString() != "VerdeDetenido" || ListaCarros[i].Tag.ToString() != "AzulDetenido" || ListaCarros[i].Tag.ToString() != "AmarilloDetenido") 
                    {
                        ListaCarros[i].Location = new Point(ListaCarros[i].Location.X + 20, ListaCarros[i].Location.Y);
                        Hitboxes[i].Location = new Point(Hitboxes[i].Location.X + 20, Hitboxes[i].Location.Y);
                    }
                    
                }
                
            }
        }

        private void Nivel1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Mover_Personaje == true)
            {
                if (pausa == false)
                {
                    bool derecha = false;
                    bool izquierda = false;
                    bool arriba = false;
                    bool abajo = false;
                    bool agarrar = false;
                    bool liberar = false;

                    bool Transito = false;

                    int x = Jugador.Location.X;
                    int y = Jugador.Location.Y;

                    //Movimiento
                    //Derecha, izquierda, arriba, abajo
                    if (e.KeyCode == Keys.Right || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D) { derecha = true; }
                    else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.A) { izquierda = true; }
                    else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.W) { arriba = true; }
                    else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.S) { abajo = true; }
                    //Noreste, Sureste, Noroeste, Suroeste
                    else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9 || e.KeyCode == Keys.E) { derecha = true; arriba = true; }
                    else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.X) { derecha = true; abajo = true; }
                    else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.Q) { izquierda = true; arriba = true; }
                    else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.Z) { izquierda = true; abajo = true; }

                    //Especiales
                    //Policias
                    else if (e.KeyCode == Keys.Space) { Transito = true; }
                    //Rescate
                    else if (e.KeyCode == Keys.V) { agarrar = true; }
                    else if (e.KeyCode == Keys.B) { liberar = true; }

                    //Metodos

                    if (Transito == true) //policias 
                    {
                        if (Jugador.Bounds.IntersectsWith(Carril1.Bounds) || Jugador.Bounds.IntersectsWith(Carril2.Bounds) || Jugador.Bounds.IntersectsWith(Carril3.Bounds) || Jugador.Bounds.IntersectsWith(Carril4.Bounds))
                        {
                            if (Policias_en_Pantalla == 0)
                            {
                                if (Convert.ToInt16(Policias.Text) > 0)
                                {
                                    Policias.Text = (Convert.ToInt16(Policias.Text) - 1).ToString();

                                    Policias_en_Pantalla++;
                                    Policia_de_Transito.Enabled = true;
                                    policia = true;

                                    PictureBox Emetra = new PictureBox();
                                    Emetra.Image = (Bitmap)Properties.Resources.Transito;
                                    Emetra.Location = new Point(x - 50, y);
                                    Emetra.BackColor = System.Drawing.Color.Transparent;
                                    //Emetra.BackColor = System.Drawing.Color.BlueViolet; //pruebas
                                    Emetra.Size = new System.Drawing.Size(45, 70);
                                    Emetra.SizeMode = PictureBoxSizeMode.Normal;
                                    Emetra.BringToFront();

                                    Transitos.Add(Emetra);
                                    this.Controls.Add(Emetra);

                                    ContadorEmetras++;
                                }
                            }
                        }
                    }


                    //Aqui van los chuchos y los ancianos
                    if (agarrar == true)
                    {

                        if (Jugador.Bounds.IntersectsWith(Anciano_Imagen.Bounds))
                        {
                            anciano = true;

                            Movimiento_Combinado = true;

                            Anciano_Imagen.Location = new Point(Jugador.Location.X + 55, Jugador.Location.Y);

                        }
                    }

                    if (liberar == true)
                    {
                        anciano = false;
                        Movimiento_Combinado = false;
                    }
                    //


                    if (derecha == true)
                    {
                        x += 35;

                        switch (AnimacionPersonaje)
                        {
                            case 1:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Derecha_2; AnimacionPersonaje++;
                                break;
                            case 2:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Derecha_3; AnimacionPersonaje++;
                                break;
                            case 3:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Derecha_1; AnimacionPersonaje = 1;
                                break;
                            default:
                                break;
                        }

                        if (Movimiento_Combinado == true)
                        {
                            if (x >= 885)
                            {
                                x = 885;
                            }

                        }
                        else
                        {
                            if (x >= 925)
                            {
                                x = 925;
                            }
                        }

                    }
                    if (arriba == true)
                    {
                        y -= 70; 

                        switch (AnimacionPersonaje)
                        {
                            case 1:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Atras_2; AnimacionPersonaje++;
                                break;
                            case 2:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Atras_3; AnimacionPersonaje++;
                                break;
                            case 3:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Atras_1; AnimacionPersonaje = 1;
                                break;
                            default:
                                break;
                        }
                        
                            if (y <= -15)
                            {
                                y = -10;
                            }
                         

                    }
                    if (izquierda == true)
                    {
                        x -= 35;

                        switch (AnimacionPersonaje)
                        {
                            case 1:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Izquierda_2; AnimacionPersonaje++;
                                break;
                            case 2:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Izquierda_3; AnimacionPersonaje++;
                                break;
                            case 3:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Izquierda_1; AnimacionPersonaje = 1;
                                break;
                            default:
                                break;
                        }

                        if (Movimiento_Combinado == true)
                        {
                            if (x <= 75)
                            {
                                x = 75;
                            }

                        }
                        else
                        {
                            if (x <= 0)
                            {
                                x = 0;
                            }
                        }
                        
                    }
                    if (abajo == true)
                    {
                        if (y + 70 < 420) //Limite inferior
                        {
                            y += 70;
                        }

                        switch (AnimacionPersonaje)
                        {
                            case 1:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Frente_2; AnimacionPersonaje++;
                                break;
                            case 2:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Frente_3; AnimacionPersonaje++;
                                break;
                            case 3:
                                this.Jugador.Image = (Bitmap)Properties.Resources.Personaje_Frente_1; AnimacionPersonaje = 1;
                                break;
                            default:
                                break;
                        }
                    }

                    Jugador.Location = new Point(x, y);
           
                    Disable_KeyDown.Enabled = true;

                    //Anciano
                    if (Movimiento_Combinado == true)
                    {
                        Anciano_Imagen.Location = new Point(x + 55, y);
                    }

                    if (Convert.ToInt16(Ancianos_por_rescatar.Text) <= 0)
                    {
                        victoria = true;
                        GameOver();
                    }

                    if (Movimiento_Combinado == false && liberar == true && Anciano_Imagen.Bounds.IntersectsWith(Meta.Bounds))
                    {
                        Ancianos_por_rescatar.Text = (Convert.ToInt16(Ancianos_por_rescatar.Text) - 1).ToString();
                        Anciano_Imagen.Location = new Point(80, 415);
                        Score.Text = (Convert.ToInt16(Score.Text) + 10).ToString();
                    }

                }
            }
        }

        private void Disable_KeyDown_Tick(object sender, EventArgs e)
        {
            if (Mover_Personaje == true)
            {
                Mover_Personaje = false;
            }
            else if(Mover_Personaje == false)
            {
                Mover_Personaje = true;
                Disable_KeyDown.Enabled = false;
            }
        }

        private void Detener_Carros_Tick(object sender, EventArgs e) //Para carros verdes, azules / semaforos y policias
        {
            Pausar_Punteo.Enabled = true;

            Detener_Carros.Enabled = false;
        }

        private void Pausar_Punteo_Tick(object sender, EventArgs e)
        {
            if (Detener_Carros.Enabled == false)
            {
                Pausar_Punteo.Enabled = false;
            }
        }

        private void RestaurarVelocidad()
        {
            for (int j = 0; j < 4; j++)
            {
                if (VelocidadCarril[j] == 0)
                {
                    VelocidadCarril[j] = 20;
                }
            }

        }

        private void Policia_de_Transito_Tick(object sender, EventArgs e)
        {
            if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril1.Bounds))
            {
                VelocidadCarril[0] = 20;
            }
            if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril2.Bounds))
            {
                VelocidadCarril[1] = 20;
            }
            if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril3.Bounds))
            {
                VelocidadCarril[2] = 20;
            }
            if (Transitos[ContadorEmetras].Bounds.IntersectsWith(Carril4.Bounds))
            {
                VelocidadCarril[3] = 20;
            }

            Transitos[ContadorEmetras].SetBounds(0, 0, 1, 1); //Resolver error del policia fantasma

            policia = false;

            this.Controls.Remove(Transitos[ContadorEmetras]);
            ListaCarros.Remove(Transitos[ContadorEmetras]);

            Policias_en_Pantalla--;
            Policia_de_Transito.Enabled = false;
        }

        private void Semaforo_Verde_Rojo_Tick(object sender, EventArgs e)
        {
            if (Semaforo_Verde_Rojo.Interval < 10000)
            {
                Semaforo_Verde_Rojo.Interval = 10000;
            }

            //Cambiar de color
            //Cambiar imagen

            if (Color_Semaforo == "Rojo")
            {
                Semaforos.Image = (Bitmap)Properties.Resources.SemaforoVerde;
                Color_Semaforo = "Verde";
            }
            else
            {
                Semaforos.Image = (Bitmap)Properties.Resources.SemaforoRojo;
                Color_Semaforo = "Rojo";
            }
            
        }

        private void BotonMenu_Click(object sender, EventArgs e)
        {
            Ayudar_ancianos menu = new Ayudar_ancianos();
            menu.Visible = true;

            this.Enabled = false;
            this.Visible = false;
        }

        private void BotonVolverajugar_Click(object sender, EventArgs e)
        {
            Nivel6 Reiniciar = new Nivel6();
            Reiniciar.Visible = true;

            this.Enabled = false;
            this.Visible = false;
        }

        public void LeerDatos()
        {
            try
            {
                using (StreamReader Sr = File.OpenText(ArchivoPuntaje))
                {
                    String texto = "";
                    String[] Guardado = new String[9];
                    
                    while ((texto = Sr.ReadLine()) != null)
                    {
                        Guardado = texto.Split(Convert.ToChar(","));

                        for (int j = 0; j < 9; j++)
                        {
                            MatrizGuardado[0, j] = Guardado[j];
                        }
                        
                    }
                }
                using (StreamReader Sr = File.OpenText(ArchivoPolicias))
                {
                    String texto = "";
                    String[] Guardado = new String[9];

                    while ((texto = Sr.ReadLine()) != null)
                    {
                        Guardado[0] = texto;
                        MatrizGuardado[1, 0] = Guardado[0];
                    }
                }

                HiScore.Text = MatrizGuardado[0,identificador];
                Policias.Text = MatrizGuardado[1,0];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GuardarDatos()
        {
            try
            {
                if (File.Exists(ArchivoPuntaje))
                {
                    //Eliminar el archivo si existe
                    File.Delete(ArchivoPuntaje);
                }
                if (File.Exists(ArchivoPolicias))
                {
                    //Eliminar el archivo si existe
                    File.Delete(ArchivoPolicias);
                }

                using (FileStream Fs = File.Create(ArchivoPuntaje))
                {
                    //Guardar Puntajes
                    String cadena = MatrizGuardado[0, 0];

                    for (int i = 1; i < 9; i++)
                    {
                        cadena += "," + MatrizGuardado[0, i];
                    }

                    Byte[] datos = new UTF8Encoding(true).GetBytes(cadena);
                    Fs.Write(datos, 0, datos.Length);
                }
                using (FileStream Fs = File.Create(ArchivoPolicias))
                {
                    //Guardar Policias
                    Byte[] datos = new UTF8Encoding(true).GetBytes(MatrizGuardado[1,0]);
                    Fs.Write(datos, 0, datos.Length);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
