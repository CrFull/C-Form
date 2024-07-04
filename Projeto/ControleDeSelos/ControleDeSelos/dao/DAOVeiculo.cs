using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeSelos.modelo;
using MySql.Data.MySqlClient;

namespace ControleDeSelos.dao
{
    class DAOVeiculo
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        private MySqlDataReader cursor;
        private string sql;
        private List<Veiculo> listaDeVeiculos;

        public DAOVeiculo()
        {
            string str = "";
            str = "server=localhost;userid=root;password=;database=controledeselos";
            this.conexao = new MySqlConnection(str);
        }

        public int inserir(Veiculo v)
        {
            int resultado = 0;

            conexao.Open();
            sql = "insert into veiculo (cor,marca,CPF,modelo,placa,selo) values (@cor,@marca,@CPF,@modelo,@placa,@selo)";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@cor", v.corVeiculo);
            comando.Parameters.AddWithValue("@marca", v.marcaVeiculo);
            comando.Parameters.AddWithValue("@cpf", v.CPFProprietario);
            comando.Parameters.AddWithValue("@modelo", v.modeloVeiculo);
            comando.Parameters.AddWithValue("@placa", v.placaVeiculo);
            comando.Parameters.AddWithValue("@selo", v.seloVeiculo);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }

        public List<Veiculo> carregarTodosOsDados()
        {
            //Criação de um lista do tipo Veículo
            listaDeVeiculos = new List<Veiculo>();

            //Abertura da conexão 
            conexao.Open();
            //Comando SQL que será executado
            sql = "select * from veiculo order by selo";
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
                //Instancia de um objeto do tipo Veículo
                Veiculo v = new Veiculo();
                v.corVeiculo = cursor.GetString("cor");
                v.marcaVeiculo = cursor.GetString("marca");
                v.CPFProprietario = cursor.GetString("cpf");
                v.modeloVeiculo = cursor.GetString("modelo");
                v.placaVeiculo = cursor.GetString("placa");
                v.seloVeiculo = cursor.GetString("selo");
                //Adicionando um objeto criado a uma lista de Veículos
                listaDeVeiculos.Add(v);
            }
            //Fechamento da conexao
            conexao.Close();
            return listaDeVeiculos; //Retorna a lista criada

        }

        public List<String> selcionaSeloVeiculo(String cpf)
        {
            List<String> selo = new List<string>();
            //Comando SQL que será executado
            sql = "select selo from veiculo where cpf = @cpf";
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
            while (cursor.Read())
                //Se houver resultados(se o cursor tiver coisas para ler) 
                selo.Add(cursor.GetString("selo"));

        
            //Fechamento da conexao
            conexao.Close();
            return selo; //Retorna o id
        }

        public List<Veiculo> selecionarVeiculoPorAtributos(String elemento, String tupla)
        {
            //Criação de um lista do tipo Veículo
            listaDeVeiculos = new List<Veiculo>();
            //Comando SQL que será executado
            sql = "select * from veiculo where " + tupla + " = @elemento";
            listaDeVeiculos = procuraNoBanco(elemento, listaDeVeiculos, sql);
            return listaDeVeiculos;
        }

        private List<Veiculo> procuraNoBanco(String elemento, List<Veiculo> listaDeProprietarios, String sql)
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
                //Instancia de um objeto do tipo Veículo
                Veiculo v = new Veiculo();
                v.corVeiculo = cursor.GetString("cor");
                v.marcaVeiculo = cursor.GetString("marca");
                v.CPFProprietario = cursor.GetString("cpf");
                v.modeloVeiculo = cursor.GetString("modelo");
                v.placaVeiculo = cursor.GetString("placa");
                v.seloVeiculo = cursor.GetString("selo");
                //Adicionando um objeto criado a uma lista de Veículos
                listaDeVeiculos.Add(v);
            }
            //Fechamento da conexao
            conexao.Close();
            return listaDeVeiculos; //Retorna a lista criada
        }

        public int atualizar(Veiculo v)
        {
            int resultado = 0;

            conexao.Open();
            sql = "update veiculo set cor = @cor,marca = @marca ,modelo = @modelo ,placa = @placa where selo = @selo ";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@cor", v.corVeiculo);
            comando.Parameters.AddWithValue("@marca", v.marcaVeiculo);
            comando.Parameters.AddWithValue("@modelo", v.modeloVeiculo);
            comando.Parameters.AddWithValue("@placa", v.placaVeiculo);
            comando.Parameters.AddWithValue("@selo", v.seloVeiculo);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }

        public int atualizar(Veiculo v,String seloNovo)
        {
            int resultado = 0;

            conexao.Open();
            sql = "update veiculo set cor = @cor,marca = @marca ,modelo = @modelo ,placa = @placa,selo = @seloNovo where selo = @selo ";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@cor", v.corVeiculo);
            comando.Parameters.AddWithValue("@marca", v.marcaVeiculo);
            comando.Parameters.AddWithValue("@modelo", v.modeloVeiculo);
            comando.Parameters.AddWithValue("@placa", v.placaVeiculo);
            comando.Parameters.AddWithValue("@seloNovo", seloNovo);
            comando.Parameters.AddWithValue("@selo", v.seloVeiculo);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }

        public int atualizar(String cpfNovo, String cpfAntigo)
        {
            int resultado = 0 ;
            conexao.Open();
            sql = "update veiculo set CPF = @CPF where CPF = @cpfAntigo";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@CPF", cpfNovo);
            comando.Parameters.AddWithValue("@cpfAntigo", cpfAntigo);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }

        public int deletar(String selo)
        {
            int resultado = 0;

            conexao.Open();
            sql = "delete from veiculo where selo = @selo";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@selo", selo);
            comando.Prepare();
            resultado = comando.ExecuteNonQuery();
            conexao.Close();
            return resultado;
        }

    }
}
