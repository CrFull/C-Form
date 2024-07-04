using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Inclusão do MySql.Data dentro do Projeto
using MySql.Data.MySqlClient;

namespace ProjetoAcademico
{
    public partial class frmCadastrarProfessor : Form
    {
        public frmCadastrarProfessor()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome, email, matricula;
            string strconexao,sql;
            int retorno;

            //Recuperação de dados
            nome = txtNome.Text;
            email = txtEmail.Text;
            matricula = txtMatricula.Text;

            //Criação da String de conexao
            //A string de conexão indica em que máquina está o SGBD (server), qual 
            //o usuário e senha (userid e password) iremos utilizar para nos conectar
            //ao SGBD e qual banco queremos manipular (database)
            strconexao = "server=localhost;userid=root;password=;database=bdacademico";
            //Criação do canal de comunicação entre o C# e o SGBD
            //É por este canal que iremos enviar os comandos SQL
            MySqlConnection con = new MySqlConnection(strconexao);
            //Abertura do canal de comunicação para enviarmos
            //os comandos
            con.Open();
            //Criação do comando SQL
            //Perceba que aqui usamos variaveis nomeadas (@nome,@email,@matricula)
            //Estas variaveis nomeadas serão substituidas pelos conteúdos 
            //das variaveis que guardam os conteúdos que estão vindo da Tela 
            sql = "insert into professor (nome,email,matricula) values (@nome,@email,@matricula)";
            //Criação do objeto de comando
            //Neste objeto será incluído os comandos SQL a serem enviados
            //ao SGBD
            MySqlCommand envelope = new MySqlCommand();
            //Aqui estamos associando o envelope ao canal de comunicação criado
            envelope.Connection = con;
            //Aqui estamos associando o comando SQL ao envelope
            envelope.CommandText = sql;
            //Aqui estamos indicando que no local em que está o
            //@nome será trocado o conteúdo da variável nome
            //o mesmo ocorrerá com @email e @matricula
            envelope.Parameters.AddWithValue("@nome", nome);
            envelope.Parameters.AddWithValue("@email", email);
            envelope.Parameters.AddWithValue("@matricula", matricula);
            //Neste momento ocorrerá a permuta de conteúdo das variáveis
            //nomeadas com o conteúdo das variáveis
            //E assim, o comando SQL ficará no ponto para ser enviado 
            //ao SGBD
            envelope.Prepare();
            //Neste ponto o comando SQL será disparado do C# ao SGBD
            //através do canal de comunicação
            //Aguardamos o retorno do SGBD (se for um valor maior que 0 a gravação deu certo)
            //Caso o retorno seja menor que 0 então deu erro na gravação
            retorno = envelope.ExecuteNonQuery();
            if (retorno>0)
            {
                //Se der tudo certo, enviamos a mensagem abaixo
                MessageBox.Show("Dados salvos com sucesso.");
            }
            else
            {
                //Caso algo dê errado, enviamos a mensagem abaixo
                MessageBox.Show("Falha na gravação dos dados.");
            }
        }
    }
}
