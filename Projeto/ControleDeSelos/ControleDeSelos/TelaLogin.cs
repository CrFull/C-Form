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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        //Evento de Click do Botao btnLogin que fará os procedimentos de login dentro do padrão DAO/MVC
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Verfica se os campos de texto não estão vazios
            if (this.txtId.Text == String.Empty || this.txtSenha.Text == String.Empty )
            {
                //Se os campos estiverem vazios, mostra uma mensagem de erro avisando o usuário.
                MessageBox.Show("Campos Vazios Detectados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtId.Focus(); //Foca no campo txtId
                return;
            }
            else
            {
                //Recebimento dos dados e armazenamento em variáveis
                int IdAdm = Convert.ToInt32(txtId.Text);
                String senhaAdm = txtSenha.Text;

                //Início do Procedimento de login

                //Chama o Controle do Administrador para cuidar do Login
                ControleAdministrador cAdm = new ControleAdministrador();
                //Se o método fazerLogin retornar verdadeiro, é instanciado o Controle de Telas e a tela MenuPrincipal é aberta
                if (cAdm.fazerLogin(IdAdm, senhaAdm))
                {
                    ControleTelas cT = new ControleTelas();
                    cT.abrirMenuPrincipal();
                    this.Hide(); //Esconde a Tela de Login
                }
                //Se o método fazerLogin retornar falso, é mandando uma mensagem de erro ao usuário informando o ocorrido
                else
                {
                    MessageBox.Show("Não foi possível fazer o login!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        //Mensagens de Acessibilidade 

        private void txtId_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtId,"Digite o seu ID.");
        }

        private void imgLogin_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(imgLogin, "Imagem.");
        }

        private void txtSenha_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtSenha, "Digite a sua senha.");
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnLogin, "Fazer o Login");
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

       
    }
}
