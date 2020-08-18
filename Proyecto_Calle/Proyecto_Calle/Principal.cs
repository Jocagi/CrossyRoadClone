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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ingresar_Datos di = new Ingresar_Datos();
            di.Visible = true;

            this.Enabled = false;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("General.txt") && File.Exists("PuntajeNiveles.txt") && File.Exists("Policias_de_transito.txt"))
                {
                    Modos_de_juego mdj = new Modos_de_juego();
                    mdj.Visible = true;

                    this.Enabled = false;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Datos no encontrados");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
