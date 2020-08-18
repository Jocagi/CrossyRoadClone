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
    public partial class Modos_de_juego : Form
    {
        public Modos_de_juego()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cruzarlacalle cs = new Cruzarlacalle();
            cs.Visible = true;

            this.Enabled = false;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ayudar_ancianos aa = new Ayudar_ancianos();
            aa.Visible = true;

            this.Enabled = false;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rescatar_mascotas rm = new Rescatar_mascotas();
            rm.Visible = true;

            this.Enabled = false;
            this.Visible = false;
        }
    }
}
