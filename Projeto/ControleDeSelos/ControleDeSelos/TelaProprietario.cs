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
using ControleDeSelos.modelo;
namespace ControleDeSelos
{
    public partial class TelaProprietario : Form
    {

        private int editar = 0;
        private ControleProprietario cP;
        private ControleVeiculo cV;
        private ControleTelas cT;
        private List<Proprietario> listaDeProprietarios;
        private String aux;

        public TelaProprietario()
        {
            InitializeComponent();
            formatoCadastro();
            verficarProprietariosSemVeiculo();
            
        }
        
          
        private void carregarDadosParaDataGridView(List<Proprietario> lista)
        {
            dgvProprietario.Rows.Clear();
            listaDeProprietarios = new List<Proprietario>();
            cP = new ControleProprietario();
            listaDeProprietarios = lista;
            string[] dados = new string[5];
            foreach (Proprietario p in listaDeProprietarios)
            {
                //Inclusão dos dados do proprietario no vetor
                dados[0] = p.MatriculaProp;
                dados[1] = p.NomeProp;
                dados[2] = p.SobreNomeProp;
                dados[3] = p.CPFProp;
                dados[4] = p.FuncaoProp;
                //Adição dos dados na linha do DataGridView dgvProprietario
                dgvProprietario.Rows.Add(dados);
            }
            
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != String.Empty)
            {
                cP = new ControleProprietario();
                Proprietario p = new Proprietario();
                listaDeProprietarios = new List<Proprietario>();
                string[] atributos = new string[6];
                atributos[0] = "nome";
                atributos[1] = "sobrenome";
                atributos[2] = "CPF";
                atributos[3] = "funcao";
                atributos[4] = "matricula";
                atributos[5] = "id";
                bool achou = false;
                for (int i = 0; i < atributos.Length; i++)
                {
                    listaDeProprietarios = cP.selecionarProprietarioPorAtributos(txtBuscar.Text, atributos[i]);
                    if (listaDeProprietarios.Count != 0)
                    {
                        carregarDadosParaDataGridView(listaDeProprietarios);
                        achou = true;
                        break;
                    }
                }
                if (p.NomeProp != String.Empty)
                {
                    achou = true;
                    carregarDadosParaDataGridView(listaDeProprietarios);
                }
                if (achou == false)
                {
                    MessageBox.Show("Nada encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarDadosParaDataGridView(cP.carregarTodosOsDados());
                }

            }
            else
            {
                MessageBox.Show("Campo de Busca Vazio!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                carregarDadosParaDataGridView(cP.carregarTodosOsDados());
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (editar == 1)
            {
                formatoCadastro();
            }
            else
            {
                if (checaCampos())
                {
                    if(checaRepeticaoMatricula(txtMatricula.Text) && checaRepeticaoCPF(txtCPF.Text))
                    {

                        String nome = txtNome.Text;
                        String sobrenome = txtSobrenome.Text;
                        String CPF = txtCPF.Text;
                        String matricula = txtMatricula.Text;
                        String funcao;
                        if (rbnAluno.Checked)
                            funcao = "Aluno";
                        else
                            funcao = "Servidor";

                        cP = new ControleProprietario();
                        if (cP.inserirProprietario(nome, sobrenome, CPF, funcao, matricula))
                        {
                            MessageBox.Show("Inserido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos();
                            carregarDadosParaDataGridView(cP.carregarTodosOsDados());
                            cT = new ControleTelas();
                            TelaVeiculo t = new TelaVeiculo();
                            if (cT.checkStatus(t) == false)
                                MessageBox.Show("Cadastre o(s) Veículos(s) do Proprietário adicionado", "Cadastro de Veículo(s)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cT.abrirTelaVeiculo();
                            
                            
                        }
                        else
                            MessageBox.Show("Erro ao inserir!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }else
                    {
                        MessageBox.Show("Matricula e/ou CPF repetidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatricula.Text = "";
                        txtCPF.Text = "";
                        txtMatricula.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Campos Vazios Detectados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (verficarProprietariosSemVeiculo() == false)
            {
                if (editar == 1)
                {
                    if (checaCampos())
                    {
                        if (checaRepeticaoMatricula(txtMatricula.Text) && checaRepeticaoCPF(txtCPF.Text))
                        {
                            String nome = txtNome.Text;
                            String sobrenome = txtSobrenome.Text;
                            String CPF = txtCPF.Text;
                            String matricula = txtMatricula.Text;
                            String funcao;
                            if (rbnAluno.Checked)
                                funcao = "Aluno";
                            else
                                funcao = "Servidor";
                            int id = Convert.ToInt32(txtID.Text);

                            cP = new ControleProprietario();
                            cV = new ControleVeiculo();
                            if (cV.atualizarVeiculo(CPF, aux) && cP.atualizarProprietario(nome, sobrenome, CPF, funcao, matricula, id))
                            {
                                MessageBox.Show("Atualizado com sucesso!", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                carregarDadosParaDataGridView(cP.carregarTodosOsDados());
                                formatoCadastro();
                            }
                            else
                                MessageBox.Show("Erro ao atualizar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Matricula e/ou CPF repetidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMatricula.Text = "";
                            txtMatricula.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Campos Vazios Detectados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cP = new ControleProprietario();
            cV = new ControleVeiculo();
            int idProprietario = 0;
            String cpf;
            List<String> selo;
            //Navegar no Datagridview e verificar, que linhas foram selecionadas
            //ou seja, marcadas com checkbox
            
            DialogResult resposta = MessageBox.Show("Você realmente deseja apagar esses dados?", "Apagar Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                foreach (DataGridViewRow linha in dgvProprietario.Rows)
                {
                    if (linha.Cells["colExcluir"].Value != null)
                    {
                        cpf = linha.Cells["colCPF"].Value.ToString();
                        idProprietario = cP.selecionaIDProprietario(cpf);
                        cP.apagarProprietario(idProprietario);
                        selo = cV.selecionaSeloVeiculo(cpf);
                        foreach (String s in selo)
                            cV.apagarVeiculo(s);
                    }
                }

                if (editar == 1)
                {
                    editar = 0;
                    formatoCadastro();
                }
            }

            carregarDadosParaDataGridView(cP.carregarTodosOsDados());
          
            
        }

        private void btnCarregarData_Click(object sender, EventArgs e)
        {
            carregarDadosParaDataGridView(cP.carregarTodosOsDados());
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (editar == 1)
            {
                formatoCadastro();
                editar = 0;
            }
            limparCampos();
        }

        private void limparCampos()
        {
            txtMatricula.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtBuscar.Text = "";
            txtSobrenome.Text = "";
            txtID.Text = "";
            txtNome.Focus();
            foreach (DataGridViewRow linha in dgvProprietario.Rows)
            {
                if (linha.Cells["colExcluir"].Value != null)
                    linha.Cells["colExcluir"].Value = null;

            }
        }

        private void formatoCadastro()
        {
            editar = 0;
            limparCampos();
            this.btnSalvar.Size = new System.Drawing.Size(135, 39);
            this.btnSalvar.Location = new System.Drawing.Point(294, 510);
            btnSalvar.Text = "CADASTRAR";
            lblCadastro.Text = "CADASTRO";
            btnEditar.Hide();
            txtID.Enabled = false;
            txtID.Visible = false;
            lblID.Visible = false;
            txtBuscar.Focus();
            cP = new ControleProprietario();
            carregarDadosParaDataGridView(cP.carregarTodosOsDados());
            this.AcceptButton = btnSalvar;
        }

        private void dgvProprietario_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (verficarProprietariosSemVeiculo() == false)
            {
                if (editar != 1)
                {
                    btnEditar.Show();
                    lblCadastro.Text = "EDITAR";
                    btnSalvar.Left -= 250;
                    btnSalvar.Text = "CADASTRO";
                }

                editar = 1;
                txtMatricula.Text = dgvProprietario.CurrentRow.Cells["colMatricula"].Value.ToString();
                txtNome.Text = dgvProprietario.CurrentRow.Cells["colNome"].Value.ToString();
                txtSobrenome.Text = dgvProprietario.CurrentRow.Cells["colSobrenome"].Value.ToString();
                txtCPF.Text = dgvProprietario.CurrentRow.Cells["colCPF"].Value.ToString();
                String funcaoNaTabela = dgvProprietario.CurrentRow.Cells["colAlunoServidor"].Value.ToString();
                if (funcaoNaTabela == "Aluno")
                    rbnAluno.Checked = true;
                else
                    rbnServidor.Checked = true;

                cP = new ControleProprietario();
                txtID.Text = cP.selecionaIDProprietario(txtCPF.Text).ToString();
                aux = txtCPF.Text;
                txtID.Visible = true;
                lblID.Visible = true;
                this.AcceptButton = btnEditar;
            }

        }


        private bool checaCampos()
        {
            if (txtCPF.Text == String.Empty ||txtSobrenome.Text == String.Empty || txtMatricula.Text == String.Empty  || txtNome.Text == String.Empty || rbnAluno.Checked == false && rbnServidor.Checked == false)
                return false;
            return true;
        }
        private bool checaRepeticaoMatricula(String matricula)
        {
            cP = new ControleProprietario();
            List<Proprietario> lista = cP.selecionarProprietarioPorAtributos(matricula, "matricula");
            int qtdEncontrados = 0;
            foreach(Proprietario p in lista)
            {
                if (p.MatriculaProp.Equals(matricula))
                    qtdEncontrados++;
            }
            if (qtdEncontrados == 1 && editar == 1 || qtdEncontrados == 0 && editar == 0 || qtdEncontrados == 0 && editar == 1)
                return true;
            
          
            return false;

        }

        private bool checaRepeticaoCPF(String CPF)
        {
            cP = new ControleProprietario();
            List<Proprietario> lista = cP.selecionarProprietarioPorAtributos(CPF, "cpf");
            int qtdEncontrados = 0;
            foreach (Proprietario p in lista)
            {
                if (p.CPFProp.Equals(CPF))
                    qtdEncontrados++;
            }
            if (qtdEncontrados == 1 && editar == 1 || qtdEncontrados == 0 && editar == 0 || qtdEncontrados == 0 && editar == 1)
                return true;
            return false;

        }

        private bool verficarProprietariosSemVeiculo()
        {
            cV = new ControleVeiculo();
            cP = new ControleProprietario();
            
            List<Proprietario> listaProprietarios = new List<Proprietario>();

            foreach(Proprietario p in listaDeProprietarios)
            {
                if(!cV.selecionarVeiculoPorAtributos(p.CPFProp,"cpf").Any())
                {
                    MessageBox.Show("Há Proprietários sem veículos! Não será possível editar Proprietários se estes não tiverem veículo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cT = new ControleTelas();
                    cT.abrirTelaVeiculo();
                    MessageBox.Show("Cadastre pelo menos um veículo para cada proprietário! Se precisar, use o campo de busca para procurar os dados.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

      

        private void TelaProprietario_Enter(object sender, EventArgs e)
        {
            carregarDadosParaDataGridView(cP.carregarTodosOsDados());
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtBuscar, "Campo para Busca.");
        }

        private void picBuscar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(picBuscar, "Clique para buscar.");
        }

        private void dgvProprietario_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(dgvProprietario, "Tabela de Proprietários inseridos.");
        }

        private void btnCarregarData_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnCarregarData, "Clique para Carregar os dados da Tabela.");
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtID, "ID correspondente ao Proprietário Selecionado");
        }

        private void txtNome_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtNome, "Campo para o Nome do Proprietario");
        }

        private void txtSobrenome_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtSobrenome, "Campo para o Sobrenome do Proprietario");
        }

        private void txtMatricula_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtMatricula, "Campo para a matrícula do Proprietario");
        }

        private void txtCPF_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtCPF, "Campo para o CPF do Proprietario");
        }

        private void btnLimpar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnLimpar, "Clique para Limpar os Campos");
        }

        private void btnEditar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnEditar, "Clique para Editar o Proprietário");
        }

        private void btnSalvar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnSalvar, "Clique para Cadastrar o Proprietário");
        }

        private void btnExcluir_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnExcluir, "Clique para Excluir o(s) Proprietário(s)");
        }
    }
}
