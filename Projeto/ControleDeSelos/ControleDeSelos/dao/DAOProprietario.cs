using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeSelos.modelo;
using MySql.Data.MySqlClient;

namespace ControleDeSelos.dao

{
    class DAOProprietario
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        private MySqlDataReader cursor;
        private string sql;
        private List<Proprietario> listaDeProprietarios;

        public DAOProprietario()
        {
            string str = "";
            str = "server=localhost;userid=root;password=;database=controledeselos";
            this.conexao = new MySqlConnection(str);
        }
        public int inserir(Proprietario p)
        {
            int resultado = 0;

            conexao.Open();
            sql = "insert into proprietario (nome,matricula,CPF,funcao,sobrenome) values (@nome,@matricula,@cpf,@funcao,@sobrenome)";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@nome", p.NomeProp);
            comando.Parameters.AddWithValue("@matricula", p.MatriculaProp);
            comando.Parameters.AddWithValue("@cpf", p.CPFProp);
            comando.Parameters.AddWithValue("@funcao", p.FuncaoProp);
            comando.Parameters.AddWithValue("@sobrenome", p.SobreNomeProp);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }
       
        public List<Proprietario> carregarTodosOsDados()
        {
            //Criação de um lista do tipo Proprietario
            listaDeProprietarios = new List<Proprietario>();

            //Abertura da conexão 
            conexao.Open();
            //Comando SQL que será executado
            sql = "select * from proprietario order by nome asc";
            //Criação do objeto de comando de SQL
            this.comando = new MySqlCommand();
            //Setando o comando SQL
            comando.CommandText = sql;
            //Setando o caminho que de execução do comando(conexão)
            comando.Connection = conexao;
            //Um cursor que aponta para a tabela retornada pelo SQL no Banco de Dados
            this.cursor = comando.ExecuteReader();

            while (cursor.Read()) //Enquanto houver resultados(enquanto o cursor tiver coisas para ler)
            {
                //Instancia de um objeto do tipo Proprietario
                Proprietario p = new Proprietario();
                //Setando cada atributo do objeto Proprietario criado com o nome da tabela correspondente e o tipo de dado(int,GetInt,varchar,GetString, etc) 
                p.NomeProp = cursor.GetString("nome");
                p.MatriculaProp = cursor.GetString("matricula");
                p.CPFProp = cursor.GetString("CPF");
                p.FuncaoProp = cursor.GetString("funcao");
                p.SobreNomeProp = cursor.GetString("sobrenome");
                //Adicionando um objeto criado a uma lista de Proprietarios
                listaDeProprietarios.Add(p);
            }
            //Fechamento da conexao
            conexao.Close();
            return listaDeProprietarios; //Retorna a lista criada

        }

        public List<Proprietario> selecionarProprietarioPorAtributos(String elemento,String tupla)
        {
            //Criação de um lista do tipo Proprietario
            listaDeProprietarios = new List<Proprietario>();
            //Comando SQL que será executado
            sql = "select * from proprietario where "+tupla+" = @elemento";
            listaDeProprietarios = procuraNoBanco(elemento, listaDeProprietarios,sql);
            return listaDeProprietarios;
        }
        public int selcionaIDProprietario(String cpf)
        {
            int id;
            //Comando SQL que será executado
            sql = "select id from proprietario where cpf = @cpf";
            conexao.Open();
            //Criação do objeto de comando de SQL
            this.comando = new MySqlCommand();
            //Setando o comando SQL
            comando.CommandText = sql;
            //Setando o caminho que de execução do comando(conexão)
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@cpf", cpf);
            //Um cursor que aponta para a tabela retornada pelo SQL no Banco de Dados
            this.cursor = comando.ExecuteReader();
            if (cursor.Read()) //Se houver resultados(se o cursor tiver coisas para ler)
                id = cursor.GetInt32("id");
            else
                id = 0;
            //Fechamento da conexao
            conexao.Close();
            return id; //Retorna o id
        }

        private List<Proprietario> procuraNoBanco(String elemento,List<Proprietario>listaDeProprietarios,String sql)
        {
            //Abertura da conexão 
            conexao.Open();

            //Criação do objeto de comando de SQL
            this.comando = new MySqlCommand();
            //Setando o comando SQL
            comando.CommandText = sql;
            //Setando o caminho que de execução do comando(conexão)
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@elemento", elemento);

            //Um cursor que aponta para a tabela retornada pelo SQL no Banco de Dados
            this.cursor = comando.ExecuteReader();
            while (cursor.Read()) //Enquanto houver resultados(enquanto o cursor tiver coisas para ler)
            {
                //Instancia de um objeto do tipo Proprietario
                Proprietario p = new Proprietario();
                //Setando cada atributo do objeto Proprietario criado com o nome da tabela correspondente e o tipo de dado(int,GetInt,varchar,GetString, etc) 
                p.NomeProp = cursor.GetString("nome");
                p.MatriculaProp = cursor.GetString("matricula");
                p.CPFProp = cursor.GetString("CPF");
                p.FuncaoProp = cursor.GetString("funcao");
                p.SobreNomeProp = cursor.GetString("sobrenome");
                //Adicionando um objeto criado a uma lista de Proprietarios
                listaDeProprietarios.Add(p);
            }
            //Fechamento da conexao
            conexao.Close();
            return listaDeProprietarios; //Retorna a lista criada
        }

        public int atualizar(Proprietario p,int id)
        {
            int resultado = 0;

            conexao.Open();
            sql = "update proprietario set nome=@nome,sobrenome=@sobrenome,matricula=@matricula,funcao=@funcao, cpf=@cpf where id = @id";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@nome", p.NomeProp);
            comando.Parameters.AddWithValue("@matricula", p.MatriculaProp);
            comando.Parameters.AddWithValue("@cpf", p.CPFProp);
            comando.Parameters.AddWithValue("@funcao", p.FuncaoProp);
            comando.Parameters.AddWithValue("@sobrenome", p.SobreNomeProp);
            comando.Parameters.AddWithValue("@id", id);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }

        public int deletar(int id)
        {
            int resultado = 0;

            conexao.Open();
            sql = "delete from proprietario where id = @id";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@id", id);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }


    }
}
