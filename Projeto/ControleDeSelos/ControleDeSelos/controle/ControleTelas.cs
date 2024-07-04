using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeSelos.controle
{
    class ControleTelas
    {
        private TelaProprietario telaP; 
        private TelaVeiculo telaV;
        public Form receberInstanciaPai { get; set; } //Atributo que recebe a instancia do Form Pai para referencia-lo no Form Filho.

        //Função responsável pelo Controle da Abertura da Tela MenuPrincipal
        public void abrirMenuPrincipal()
        {
            MenuPrincipal menu = new MenuPrincipal(); //Instancia de um objeto Form do tipo MenuPrincipal
            menu.Show(); //Mostra a Tela na Aplicação
        }

        //Função responsável pelo Controle da Abertura da TelaProprietario
        public void abrirTelaProprietario()
        {
            if (checkStatus(telaP) == false) //Se o método checkStatus retornar false quer dizer que não há instancia do objeto Form em questão na Aplicação, então um é criado.
            {
                telaP = new TelaProprietario(); // Instancia de um objeto Form do tipo TelaProprietario
                telaP.MdiParent = receberInstanciaPai; //Seta o Form Pai(MenuPrincipal) para o Form filho(TelaProprietario) criado.
                telaP.Show(); //Mostra a Tela na Aplicação
            }
        }

        //Função responsável pelo Controle da Abertura da TelaVeiculo
        public void abrirTelaVeiculo()
        {
            if (checkStatus(telaV) == false) //Se o método checkStatus retornar false quer dizer que não há instancia do objeto Form em questão na Aplicação, então um é criado.
            {
                telaV = new TelaVeiculo(); // Instancia de um objeto Form do tipo TelaVeiculo
                telaV.MdiParent = receberInstanciaPai;//Seta o Form Pai(MenuPrincipal) para o Form filho(TelaVeiculo) criado.
                telaV.Show(); //Mostra a Tela na Aplicação
            }
        }


        //Funções responsáveis por verficar se já há um Form Filho na Aplicação, para evitar que mais de um Form filho do mesmo tipo seja aberto e comprometa a integridade do programa
       public bool checkStatus(TelaProprietario telaP)
        {
            if (Application.OpenForms.OfType<TelaProprietario>().Count() > 0)
                return true; //Retorna true se um Form TelaProprietario já estiver instanciada(criada)
            return false; //Retorna false se um Form TelaProprietario não estiver instanciada(criada)

        }
        public bool checkStatus(TelaVeiculo telaV)
        {
            if (Application.OpenForms.OfType<TelaVeiculo>().Count() > 0)
                return true; //Retorna true se um Form TelaVeiculo já estiver instanciada(criada)
            return false; //Retorna false se um Form TelaVeiculo não estiver instanciada(criada)
        }
    }

    


}
