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
    public partial class TelaVeiculo : Form
    {
        private int editar = 0;
        private ControleVeiculo cV;
        private List<Veiculo> listaDeVeiculos;
        
        public TelaVeiculo()
        {
            InitializeComponent();
            txtBuscar.Focus();
            btnEditar.Hide();
            cV = new ControleVeiculo();
            carregarDadosParaDataGridView(cV.carregarTodosOsDados());
            carregaCPFProprietarios();
            txtPlaca.CharacterCasing = CharacterCasing.Upper;
        }

        private void carregarDadosParaDataGridView(List<Veiculo> lista)
        {
            dgvVeiculos.Rows.Clear();
            listaDeVeiculos = new List<Veiculo>();
            cV = new ControleVeiculo();
            listaDeVeiculos = lista;
            string[] dados = new string[6];
            foreach (Veiculo v in listaDeVeiculos)
            {
                //Inclusão dos dados do veiculo no vetor
                dados[0] = v.seloVeiculo;
                dados[1] = v.CPFProprietario;
                dados[2] = v.placaVeiculo;
                dados[3] = v.modeloVeiculo;
                dados[4] = v.marcaVeiculo;
                dados[5] = v.corVeiculo;
                dgvVeiculos.Rows.Add(dados);
            }

        }

        private void carregaCPFProprietarios()
        {
            cmbProp.Items.Clear();
            ControleProprietario cP = new ControleProprietario();
            List<Proprietario> lista = cP.carregarTodosOsDados();
            foreach (Proprietario p in lista)
                cmbProp.Items.Add(p.CPFProp);
            
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
                    if (checaQtdVeiculosProprietario(cmbProp.SelectedItem.ToString()))
                    {
                        if (checaRepeticaoPlaca(txtPlaca.Text))
                        {
                            String cor = txtCor.Text;
                            String placa = txtPlaca.Text;
                            String CPF = cmbProp.SelectedItem.ToString();
                            String modelo = txtModelo.Text;
                            String marca = txtMarca.Text;
                            String tipoVeiculo;
                            if (rbnCarro.Checked)
                                tipoVeiculo = "CA";
                            else
                                tipoVeiculo = "MO";

                            cV = new ControleVeiculo();
                            if (cV.inserirVeiculo(CPF, placa, marca, cor, modelo, tipoVeiculo))
                            {
                                MessageBox.Show("Inserido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limparCampos();
                                carregarDadosParaDataGridView(cV.carregarTodosOsDados());

                            }
                            else
                                MessageBox.Show("Erro ao inserir!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            MessageBox.Show("Placa repetida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPlaca.Text = "";
                            txtPlaca.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("O proprietario selecionado já possui 2 veículos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbProp.SelectedValue = null;
                        cmbProp.Focus();
                    }
                      
                }
                else
                {
                    MessageBox.Show("Campos Vazios Detectados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != String.Empty)
            {
                cV = new ControleVeiculo();
                Veiculo v = new Veiculo();
                listaDeVeiculos = new List<Veiculo>();
                string[] atributos = new string[6];
                atributos[0] = "selo";
                atributos[1] = "cor";
                atributos[2] = "cpf";
                atributos[3] = "marca";
                atributos[4] = "modelo";
                atributos[5] = "placa";
                bool achou = false;
                for (int i = 0; i < atributos.Length; i++)
                {
                    listaDeVeiculos = cV.selecionarVeiculoPorAtributos(txtBuscar.Text, atributos[i]);
                    if (listaDeVeiculos.Count != 0)
                    {
                        carregarDadosParaDataGridView(listaDeVeiculos);
                        achou = true;
                        break;
                    }
                }
                if (v.CPFProprietario != String.Empty)
                {
                    achou = true;
                    carregarDadosParaDataGridView(listaDeVeiculos);
                }
                if (achou == false)
                {
                    MessageBox.Show("Nada encontrado!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarDadosParaDataGridView(cV.carregarTodosOsDados());
                }

            }
            else
            {
                MessageBox.Show("Campo de Busca Vazio!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                carregarDadosParaDataGridView(cV.carregarTodosOsDados());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (editar == 1)
            {
                if (checaCampos())
                {

                    if (checaRepeticaoPlaca(txtPlaca.Text))
                    {                      
                        String cor = txtCor.Text;
                        String placa = txtPlaca.Text;
                        String CPF = cmbProp.SelectedItem.ToString();
                        String modelo = txtModelo.Text;
                        String marca = txtMarca.Text;
                        String tipoVeiculo;
                        String selo = txtSelo.Text;
                        String seloNovo = null;
                        bool atualizou = false;
                        if (rbnCarro.Checked)
                            tipoVeiculo = "CA";
                        else
                            tipoVeiculo = "MO";

                        String começoDoSelo = selo.Substring(0, 2);
                        if (!começoDoSelo.Equals(tipoVeiculo))
                        {
                            seloNovo = cV.constroiSelos(tipoVeiculo);
                            atualizou = cV.atualizarVeiculo(placa, marca, cor, modelo, selo, seloNovo);
                        }
                        else
                            atualizou = cV.atualizarVeiculo(placa, marca, cor, modelo, selo);


                        cV = new ControleVeiculo();
                        if (atualizou)
                        {

                            MessageBox.Show("Atualizado com sucesso!", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limparCampos();
                            carregarDadosParaDataGridView(cV.carregarTodosOsDados());
                            formatoCadastro();

                        }
                        else
                            MessageBox.Show("Erro ao atualizar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Placa repetida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPlaca.Text = "";
                        txtPlaca.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Campos Vazios Detectados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }          
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ControleVeiculo cV = new ControleVeiculo();
            String selo;
            //Navegar no Datagridview e verificar, que linhas foram selecionadas
            //ou seja, marcadas com checkbox
            DialogResult resposta = MessageBox.Show("Você realmente deseja apagar esses dados?", "Apagar Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                foreach (DataGridViewRow linha in dgvVeiculos.Rows)
                {
                    if (linha.Cells["colExcluir"].Value != null)
                    {
                        selo = linha.Cells["colSelo"].Value.ToString();
                        cV.apagarVeiculo(selo);
                    }

                }
                if (editar == 1)
                {
                    editar = 0;
                    formatoCadastro();
                }
            }

            
            carregarDadosParaDataGridView(cV.carregarTodosOsDados());
        }

        private void btnCarregarData_Click_1(object sender, EventArgs e)
        {
            carregarDadosParaDataGridView(cV.carregarTodosOsDados());
            carregaCPFProprietarios();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
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
            txtBuscar.Text = "";
            txtCor.Text = "";
            txtMarca.Text = "";
            txtPlaca.Text = "";
            cmbProp.SelectedItem = null;
            txtSelo.Text = "";
            txtModelo.Text = "";
            txtBuscar.Focus();
            foreach (DataGridViewRow linha in dgvVeiculos.Rows)
            {
                if (linha.Cells["colExcluir"].Value != null)
                    linha.Cells["colExcluir"].Value = null;

            }
        }

        private void formatoCadastro()
        {
            editar = 0;
            limparCampos();
            this.btnSalvar.Location = new System.Drawing.Point(310, 564);
            this.btnSalvar.Size = new System.Drawing.Size(143, 44);
            btnSalvar.Text = "CADASTRAR";
            lblCadastro.Text = "CADASTRO";
            btnEditar.Hide();
            lblSelo.Hide();
            txtSelo.Hide();
            cmbProp.Enabled = true;
            this.AcceptButton = btnSalvar;
        }


        private void cmbProp_Click(object sender, EventArgs e)
        {
            carregaCPFProprietarios();
        }

        private bool checaCampos()
        {
            if (txtCor.Text == String.Empty  ||txtMarca.Text == String.Empty || txtPlaca.Text == String.Empty || rbnCarro.Checked == false && rbnMoto.Checked == false)
                return false;
            return true;
        }

        private bool checaRepeticaoPlaca(String placa)
        {
            cV = new ControleVeiculo();
            List<Veiculo> lista = cV.selecionarVeiculoPorAtributos(placa, "placa");
            int qtdEncontrados = 0;
            foreach (Veiculo v in lista)
            {
                if (v.placaVeiculo.Equals(placa))
                    qtdEncontrados++;
            }
            if (qtdEncontrados == 1 && editar == 1 || qtdEncontrados == 0 && editar == 0 || qtdEncontrados == 0 && editar == 1)
                return true;
            return false;

        }

       private bool checaQtdVeiculosProprietario(String cpf){
            cV = new ControleVeiculo();
            List<Veiculo> lista = cV.selecionarVeiculoPorAtributos(cpf, "cpf");
            int qtdEncontrados = 0;
            foreach (Veiculo v in lista)
            {
                if (v.CPFProprietario.Equals(cpf))
                    qtdEncontrados++;
            }
            if (qtdEncontrados < 2 && editar == 1 || qtdEncontrados < 2 && editar == 0)
                return true;
            return false;
       }

        
      
        private void dgvVeiculos_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(editar != 1)
            {
                editar = 1;
                btnEditar.Show();
                lblCadastro.Text = "EDITAR";
                btnSalvar.Left -= 250;
                btnSalvar.Text = "CADASTRO";
                lblSelo.Show();
                txtSelo.Show();
            }


            txtCor.Text = dgvVeiculos.CurrentRow.Cells["colCor"].Value.ToString();
            txtMarca.Text = dgvVeiculos.CurrentRow.Cells["colMarca"].Value.ToString();
            txtPlaca.Text = dgvVeiculos.CurrentRow.Cells["colPlaca"].Value.ToString();
            cmbProp.SelectedItem = dgvVeiculos.CurrentRow.Cells["colProprietario"].Value.ToString();
            txtSelo.Text = dgvVeiculos.CurrentRow.Cells["colSelo"].Value.ToString();
            txtModelo.Text = dgvVeiculos.CurrentRow.Cells["colModelo"].Value.ToString();
            String começoDoSelo = txtSelo.Text.Substring(0, 2);
            if (começoDoSelo.Equals("MO"))
                rbnMoto.Checked = true;
            else
                rbnCarro.Checked = true;
            cmbProp.Enabled = false;
            this.AcceptButton = btnEditar;

        }

        private void TelaVeiculo_Leave(object sender, EventArgs e)
        {
            cmbProp.SelectedItem = null;
            carregaCPFProprietarios();
        }

        private void TelaVeiculo_Enter(object sender, EventArgs e)
        {
            carregarDadosParaDataGridView(cV.carregarTodosOsDados());
        }


        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) && e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtCor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) && e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) && e.KeyChar == 32)
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

        private void btnCarregarData_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnCarregarData, "Clique para Carregar os dados da Tabela.");
        }

        private void cmbProp_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(cmbProp, "Campo de CPF de Proprietários.");
        }

        private void txtMarca_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtMarca, "Campo para a Marca do Veículo.");
        }

        private void txtPlaca_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtPlaca, "Campo para a Placa do Veículo.");
        }

        private void txtCor_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtCor, "Campo para a Cor do Veículo.");
        }

        private void txtSelo_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtSelo, "Selo correspondente ao Veículo Selecionado");
        }

        private void txtModelo_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(txtModelo, "Campo para o Modelo do Veículo.");
        }

        private void btnLimpar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnLimpar, "Clique para Limpar os Campos");
        }

        private void btnEditar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnEditar, "Clique para Editar Veículo");

        }

        private void btnExcluir_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnExcluir, "Clique para Excluir o(s) Veículo(s)");
        }

        private void btnSalvar_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnExcluir, "Clique para Cadastrar o Veículo");
        }
    }
}
