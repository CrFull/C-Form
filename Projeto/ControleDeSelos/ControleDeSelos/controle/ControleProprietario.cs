using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeSelos.modelo;
using ControleDeSelos.dao;

namespace ControleDeSelos.controle
{
    class ControleProprietario
    {
        //Definição dos Atributos da Classe ControleProprietario
        private List<Proprietario> listaDeProprietarios;
        private DAOProprietario daoProprietario;



        //Método responsável pelo Controle de Inserções de Proprietários. Se comunica com DAOProprietario e Modelo Proprietario
        //Recebe os Dados dos Campos da TelaPropritario
        public bool inserirProprietario(String nome, String sobrenome,String CPF, String funcao, String Matricula)
        {
            Proprietario p = construirProprietario(nome, sobrenome,CPF, funcao, Matricula,0); //Instancia um objeto do tipo Modelo Proprietario, recebendo os dados do método construirProprietario.
            daoProprietario = new DAOProprietario(); //Instancia um objeto do tipo DAOAdm para realizar os procedimetos do Banco de Dados
            if (daoProprietario.inserir(p) > 0) //Se o método de inserir retornar true(se o inserimento der Certo) é retornado true. Caso o contrário, false. O parametro passado é o objeto construido anteriormente
                return true; //Retorne true se for inserido
            return false;//Retorna false se não for

        }

        //Método responsável pela modelagem dos dados passados, em um objeto Modelo Proprietario.
        private Proprietario construirProprietario(String nome, String sobrenome, String CPF, String funcao, String Matricula, int id)
        {
            Proprietario p = new Proprietario(); //Instancia o objeto do tipo Modelo Proprietario para a modelagem de dados
            p.NomeProp = nome; //Seta o Nome do Objeto(Proprietario,p) com o valor do nome passado
            p.SobreNomeProp = sobrenome; //Seta o Nome do Objeto(Proprietario,p) com o valor do nome passado
            p.MatriculaProp = Matricula; //Seta a Matricula do Objeto(Proprietario,p) com o valor da matricula passada
            p.CPFProp = CPF; //Seta o CPF do Objeto(Proprietario,p) com o valor do CPF passado
            p.FuncaoProp = funcao; //Seta a Funcao do Objeto(Proprietario,p) com o valor da funcao passada
            return p; // Retorna o Objeto
        }

        //Métodos responsáveis pelo Controle de Seleção 

        //Carregamento de todos os dados do BD
        public List<Proprietario> carregarTodosOsDados()
        {
            listaDeProprietarios = new List<Proprietario>(); //Cria uma lista do tipo Proprietario
            daoProprietario = new DAOProprietario(); //Instancia o DAO do Proprietario
            listaDeProprietarios = daoProprietario.carregarTodosOsDados(); //A lista recebe a outra lista com os dados que foi retornada do método carregarTodosOsDados na classe DAOProprietario

            return listaDeProprietarios; //Retorna a lista recebida
        }


        //Seleção de Proprietario pelos atributos funcao,nome,matricula e CPF
        public List<Proprietario> selecionarProprietarioPorAtributos(String elemento, String tupla)
        {
            daoProprietario = new DAOProprietario(); //Instancia um objeto do tipo DAOAdm para realizar os procedimetos do Banco de Dados
            listaDeProprietarios = new List<Proprietario>();
            listaDeProprietarios = daoProprietario.selecionarProprietarioPorAtributos(elemento, tupla);
            return listaDeProprietarios;
        }

        public int selecionaIDProprietario(String cpf)
        {
            daoProprietario = new DAOProprietario(); //Instancia um objeto do tipo DAOAdm para realizar os procedimetos do Banco de Dados
            int id = daoProprietario.selcionaIDProprietario(cpf);
            return id;
        }

        public bool atualizarProprietario(String nome, String sobrenome, String CPF, String funcao, String Matricula,int id)
        {

            Proprietario p = construirProprietario(nome, sobrenome, CPF, funcao, Matricula,0); //Instancia um objeto do tipo Modelo Proprietario, recebendo os dados do método construirProprietario.
            daoProprietario = new DAOProprietario(); //Instancia um objeto do tipo DAOAdm para realizar os procedimetos do Banco de Dados
            if (daoProprietario.atualizar(p,id) > 0) //Se o método de inserir retornar true(se o inserimento der Certo) é retornado true. Caso o contrário, false. O parametro passado é o objeto construido anteriormente
                return true; //Retorne true se for inserido
            return false;//Retorna false se não for
        }

        public bool apagarProprietario(int idProprietario)
        {
            daoProprietario = new DAOProprietario(); //Instancia um objeto do tipo DAOAdm para realizar os procedimetos do Banco de Dados
            if (daoProprietario.deletar(idProprietario) > 0) //Se o método de inserir retornar true(se o inserimento der Certo) é retornado true. Caso o contrário, false. O parametro passado é o objeto construido anteriormente
                return true; //Retorne true se for inserido
            return false;//Retorna false se não for
        }

    }
}
