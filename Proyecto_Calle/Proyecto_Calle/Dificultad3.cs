using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Calle
{
    public partial class Rescatar_mascotas : Form
    {
        public Rescatar_mascotas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nivel7 N7 = new Nivel7();
            N7.Show();

            this.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Modos_de_juego md = new Modos_de_juego();
            md.Visible = true;

            this.Visible = false;
            this.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nivel8 N8 = new Nivel8();
            N8.Show();

            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nivel8 N8 = new Nivel8();
            N8.Show();

            this.Visible = false;
        }
    }
}
