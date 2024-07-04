using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleDeSelos.controle;

namespace ControleDeSelos
{
    public partial class MenuPrincipal : Form
    {

        public MenuPrincipal()
        {  
            InitializeComponent();
        }

        private ControleTelas cT;


        private void opSair_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Você deseja sair da aplicação?", "Sair da Aplicação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                //Saindo da Aplicação
                Application.ExitThread();                
            }
        }

        private void opProprietario_Click_1(object sender, EventArgs e)
        {
            cT = new ControleTelas();
            cT.receberInstanciaPai = this;
            cT.abrirTelaProprietario();
        }

        private void opVeiculo_Click(object sender, EventArgs e)
        {
            cT = new ControleTelas();
            cT.receberInstanciaPai = this;
            cT.abrirTelaVeiculo();
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode); //Fecha as threads que restarem do programa ao clicar no Botão X no canto superior direito
        }
    }
}
