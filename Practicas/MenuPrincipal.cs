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

        }

        private void practica2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void practica3ComponenetesYLibreriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void practica1GestionDeContactosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GestCont Frm = new GestCont();
            Frm.Show();
        }

        private void practica2InterfazGraficaDinamicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Practica2 Frm2 = new Practica2();
            Frm2.MdiParent = this;
            Frm2.Show();
        }

        private void practica3ComponentesYLibreriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Practica3 Frm3 = new Practica3();
            Frm3.MdiParent = this;
            Frm3.Show();
        }

        private void practica4ConcurrenciaNumerosPrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Frm4 = new Practica4();
            
        }

        private void practicaAccesoABaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void uNIDAD3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bDSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BDsql Frm5 = new BDsql();
            Frm5.MdiParent = this;
            Frm5.Show();
        }

        private void bDMySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBDMySQL Frm6 = new FBDMySQL();
            Frm6.MdiParent = this;
            Frm6.Show();
        }
    }
}
