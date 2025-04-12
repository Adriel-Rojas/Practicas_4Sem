using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void practica1GestionDeContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestCont Frm = new GestCont();
            Frm.Show();
        }

        private void practica2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Practica2 Frm2 = new Practica2();
            Frm2.MdiParent = this;
            Frm2.Show();
        }
    }
}
