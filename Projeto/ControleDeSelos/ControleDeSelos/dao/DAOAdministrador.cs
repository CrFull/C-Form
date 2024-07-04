using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ControleDeSelos.modelo;

namespace ControleDeSelos.dao
{
    class DAOAdministrador
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        private MySqlDataReader cursor;
        private string sql;

        public DAOAdministrador()
        {
            string str = "";
            str = "server=localhost;userid=root;password=;database=controledeselos";
            this.conexao = new MySqlConnection(str);
        }


        public bool consultarAdministrador(Administrador adm)
        {
            conexao.Open();
            sql = "Select * from administrador where id = @id and senha = @senha";
            this.comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conexao;
            comando.Parameters.AddWithValue("@id", adm.IdAdm);
            comando.Parameters.AddWithValue("@senha", adm.SenhaAdm);
            this.cursor = comando.ExecuteReader();
            if (cursor.Read())
            {
                conexao.Close();
                return true;
            }
            conexao.Close();
            return false;
        }
    }

}

