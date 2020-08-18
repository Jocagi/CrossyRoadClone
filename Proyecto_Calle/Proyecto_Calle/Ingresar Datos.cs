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
    public partial class Ingresar_Datos : Form
    {
        public Ingresar_Datos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nombre.Text == "" || Carnet.Text == "")
                {
                    MessageBox.Show("Porfavor ingrese los datos");
                }
                else
                {
                    if (File.Exists("General.txt") && File.Exists("PuntajeNiveles.txt") && File.Exists("Policias_de_transito.txt"))
                    {
                        //Eliminar el archivo si existe
                        File.Delete("General.txt");
                        File.Delete("PuntajeNiveles.txt");
                        File.Delete("Policias_de_transito.txt");
                    }

                    //Default
                    Byte[] Info = new UTF8Encoding(true).GetBytes(Nombre.Text + "," + Carnet.Text);
                    Byte[] Puntaje = new UTF8Encoding(true).GetBytes("0,0,0,0,0,0,0,0,0");
                    Byte[] Policias = new UTF8Encoding(true).GetBytes("0");

                    using (FileStream Fs = File.Create("General.txt"))
                    {
                        Fs.Write(Info, 0, Info.Length);
                    }
                    using (FileStream Fs = File.Create("PuntajeNiveles.txt"))
                    {
                        Fs.Write(Puntaje, 0, Puntaje.Length);
                    }
                    using (FileStream Fs = File.Create("Policias_de_transito.txt"))
                    {
                        Fs.Write(Policias, 0, Policias.Length);
                    }


                    Modos_de_juego mdj = new Modos_de_juego();
                    mdj.Visible = true;

                    this.Enabled = false;
                    this.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
