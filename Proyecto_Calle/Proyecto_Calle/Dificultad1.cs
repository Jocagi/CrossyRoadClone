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
    public partial class Cruzarlacalle : Form
    {
        public Cruzarlacalle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nivel1 N1 = new Nivel1();
            N1.Show();

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
            Nivel2 N2 = new Nivel2();
            N2.Show();

            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nivel3 N3 = new Nivel3();
            N3.Show();

            this.Visible = false;
        }
    }
}
