using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeSelos.modelo;
using ControleDeSelos.controle;
using ControleDeSelos.dao;

namespace ControleDeSelos.controle
{
    class ControleAdministrador
    {
        //Método responsável pelo Controle dos processos de login dos Administradores. Se comunica com o DAOAdministrador e o Modelo do Administrador
        //Recebe os Dados dos Campos da TelaLogin
        public bool fazerLogin(int ID, String Senha)
        {
            Administrador adm = construirAdm(ID, Senha); //Instancia um objeto do tipo Modelo Administrador, recebendo os dados do método construirAdm.
            DAOAdministrador daoAdm = new DAOAdministrador();//Instancia um objeto do tipo DAOAdm para realizar os procedimetos do Banco de Dados
            if (daoAdm.consultarAdministrador(adm)) //Se o método de consultarAdministrador retornar true(se existir Administrador) é retornado true. Caso o contrário, false. O parametro passado é o objeto construido anteriormente
                return true; //Retorna true se for encontrado
            return false; //Retorna false se não for encontrado
        }

        //Método responsável pela modelagem dos dados passados em um objeto Modelo Administrador.
        private Administrador construirAdm(int ID, String Senha)
        {
            Administrador adm = new Administrador(); //Instancia o objeto do tipo Modelo do Administrador para a modelagem de dados
            adm.IdAdm = ID;  //Seta o ID do Objeto(Administrador,adm) com o valor do ID passado

            ControleSenhas cS = new ControleSenhas(); //Instancia o controle de senhas que, como o próprio nome sugere, controla as procedimentos de senhas da aplicação(MD5)
            adm.SenhaAdm = cS.GerarMd5(Senha); //Seta a Senha do Administrador com o método da classe ControleDeSenhas para que a senha seja "criptografada".

            return adm; //Retorna o Objeto criado
        }

    }
}
