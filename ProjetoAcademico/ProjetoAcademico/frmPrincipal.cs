using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAcademico
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarProfessor frm = new frmCadastrarProfessor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_Load_1(object sender, EventArgs e)
        {

        }
    }
}
