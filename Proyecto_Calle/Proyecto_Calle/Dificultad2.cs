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
    public partial class Ayudar_ancianos : Form
    {
        public Ayudar_ancianos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nivel4 N4 = new Nivel4();
            N4.Show();

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
            Nivel5 N5 = new Nivel5();
            N5.Show();

            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nivel6 N6 = new Nivel6();
            N6.Show();

            this.Visible = false;
        }
    }
}
