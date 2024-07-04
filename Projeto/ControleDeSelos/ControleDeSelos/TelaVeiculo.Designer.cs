namespace ControleDeSelos
{
    partial class TelaVeiculo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaVeiculo));
            this.btnExcluir = new System.Windows.Forms.Button();
            this.gboxCarMoto = new System.Windows.Forms.GroupBox();
            this.rbnMoto = new System.Windows.Forms.RadioButton();
            this.rbnCarro = new System.Windows.Forms.RadioButton();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.lblCor = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblProprietario = new System.Windows.Forms.Label();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.dgvVeiculos = new System.Windows.Forms.DataGridView();
            this.colSelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProprietario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnCarregarData = new System.Windows.Forms.Button();
            this.txtSelo = new System.Windows.Forms.TextBox();
            this.lblSelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.cmbProp = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gboxCarMoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeiculos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(523, 564);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(119, 44);
            this.btnExcluir.TabIndex = 31;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseEnter += new System.EventHandler(this.btnExcluir_MouseEnter);
            // 
            // gboxCarMoto
            // 
            this.gboxCarMoto.Controls.Add(this.rbnMoto);
            this.gboxCarMoto.Controls.Add(this.rbnCarro);
            this.gboxCarMoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxCarMoto.Location = new System.Drawing.Point(266, 441);
            this.gboxCarMoto.Name = "gboxCarMoto";
            this.gboxCarMoto.Size = new System.Drawing.Size(410, 105);
            this.gboxCarMoto.TabIndex = 30;
            this.gboxCarMoto.TabStop = false;
            this.gboxCarMoto.Text = "Carro/Moto";
            // 
            // rbnMoto
            // 
            this.rbnMoto.AutoSize = true;
            this.rbnMoto.Location = new System.Drawing.Point(234, 43);
            this.rbnMoto.Name = "rbnMoto";
            this.rbnMoto.Size = new System.Drawing.Size(61, 22);
            this.rbnMoto.TabIndex = 1;
            this.rbnMoto.TabStop = true;
            this.rbnMoto.Text = "Moto";
            this.rbnMoto.UseVisualStyleBackColor = true;
            // 
            // rbnCarro
            // 
            this.rbnCarro.AutoSize = true;
            this.rbnCarro.Location = new System.Drawing.Point(28, 43);
            this.rbnCarro.Name = "rbnCarro";
            this.rbnCarro.Size = new System.Drawing.Size(64, 22);
            this.rbnCarro.TabIndex = 0;
            this.rbnCarro.TabStop = true;
            this.rbnCarro.Text = "Carro";
            this.rbnCarro.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(310, 564);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(143, 44);
            this.btnSalvar.TabIndex = 29;
            this.btnSalvar.Text = "CADASTRAR";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseEnter += new System.EventHandler(this.btnSalvar_MouseEnter);
            // 
            // txtCor
            // 
            this.txtCor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCor.Location = new System.Drawing.Point(466, 353);
            this.txtCor.MaxLength = 50;
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(176, 24);
            this.txtCor.TabIndex = 28;
            this.txtCor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCor_KeyPress);
            this.txtCor.MouseEnter += new System.EventHandler(this.txtCor_MouseEnter);
            // 
            // lblCor
            // 
            this.lblCor.AutoSize = true;
            this.lblCor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCor.Location = new System.Drawing.Point(462, 328);
            this.lblCor.Name = "lblCor";
            this.lblCor.Size = new System.Drawing.Size(42, 20);
            this.lblCor.TabIndex = 27;
            this.lblCor.Text = "Cor:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(232, 353);
            this.txtPlaca.MaxLength = 7;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(176, 24);
            this.txtPlaca.TabIndex = 26;
            this.txtPlaca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlaca_KeyPress);
            this.txtPlaca.MouseEnter += new System.EventHandler(this.txtPlaca_MouseEnter);
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.Location = new System.Drawing.Point(228, 330);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(58, 20);
            this.lblPlaca.TabIndex = 25;
            this.lblPlaca.Text = "Placa:";
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(466, 294);
            this.txtMarca.MaxLength = 50;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(176, 24);
            this.txtMarca.TabIndex = 24;
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            this.txtMarca.MouseEnter += new System.EventHandler(this.txtMarca_MouseEnter);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(462, 271);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(63, 20);
            this.lblMarca.TabIndex = 23;
            this.lblMarca.Text = "Marca:";
            // 
            // lblProprietario
            // 
            this.lblProprietario.AutoSize = true;
            this.lblProprietario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProprietario.Location = new System.Drawing.Point(228, 271);
            this.lblProprietario.Name = "lblProprietario";
            this.lblProprietario.Size = new System.Drawing.Size(141, 20);
            this.lblProprietario.TabIndex = 21;
            this.lblProprietario.Text = "CPF Proprietario";
            // 
            // lblCadastro
            // 
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastro.Location = new System.Drawing.Point(378, 222);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(106, 20);
            this.lblCadastro.TabIndex = 20;
            this.lblCadastro.Text = "CADASTRO";
            // 
            // dgvVeiculos
            // 
            this.dgvVeiculos.AllowUserToAddRows = false;
            this.dgvVeiculos.AllowUserToDeleteRows = false;
            this.dgvVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelo,
            this.colProprietario,
            this.colPlaca,
            this.colModelo,
            this.colMarca,
            this.colCor,
            this.colExcluir});
            this.dgvVeiculos.Location = new System.Drawing.Point(127, 62);
            this.dgvVeiculos.Name = "dgvVeiculos";
            this.dgvVeiculos.Size = new System.Drawing.Size(707, 137);
            this.dgvVeiculos.TabIndex = 19;
            this.dgvVeiculos.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVeiculos_RowHeaderMouseDoubleClick_1);
            // 
            // colSelo
            // 
            this.colSelo.HeaderText = "Selo";
            this.colSelo.Name = "colSelo";
            // 
            // colProprietario
            // 
            this.colProprietario.HeaderText = "Proprietário";
            this.colProprietario.Name = "colProprietario";
            // 
            // colPlaca
            // 
            this.colPlaca.HeaderText = "Placa";
            this.colPlaca.Name = "colPlaca";
            // 
            // colModelo
            // 
            this.colModelo.HeaderText = "Modelo";
            this.colModelo.Name = "colModelo";
            // 
            // colMarca
            // 
            this.colMarca.HeaderText = "Marca";
            this.colMarca.Name = "colMarca";
            // 
            // colCor
            // 
            this.colCor.HeaderText = "Cor";
            this.colCor.Name = "colCor";
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colExcluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // picBuscar
            // 
            this.picBuscar.Image = global::ControleDeSelos.Properties.Resources.android_search_icon_icons_com_50501;
            this.picBuscar.Location = new System.Drawing.Point(540, 8);
            this.picBuscar.Name = "picBuscar";
            this.picBuscar.Size = new System.Drawing.Size(39, 28);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBuscar.TabIndex = 18;
            this.picBuscar.TabStop = false;
            this.picBuscar.Click += new System.EventHandler(this.picBuscar_Click);
            this.picBuscar.MouseEnter += new System.EventHandler(this.picBuscar_MouseEnter);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(250, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(284, 24);
            this.txtBuscar.TabIndex = 17;
            this.txtBuscar.MouseEnter += new System.EventHandler(this.txtBuscar_MouseEnter);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(174, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(70, 20);
            this.lblBuscar.TabIndex = 16;
            this.lblBuscar.Text = "Buscar:";
            // 
            // btnCarregarData
            // 
            this.btnCarregarData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarData.Location = new System.Drawing.Point(21, 135);
            this.btnCarregarData.Name = "btnCarregarData";
            this.btnCarregarData.Size = new System.Drawing.Size(90, 25);
            this.btnCarregarData.TabIndex = 32;
            this.btnCarregarData.Text = "Carregar Dados";
            this.btnCarregarData.UseVisualStyleBackColor = true;
            this.btnCarregarData.Click += new System.EventHandler(this.btnCarregarData_Click_1);
            this.btnCarregarData.MouseEnter += new System.EventHandler(this.btnCarregarData_MouseEnter);
            // 
            // txtSelo
            // 
            this.txtSelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelo.Location = new System.Drawing.Point(700, 326);
            this.txtSelo.Name = "txtSelo";
            this.txtSelo.ReadOnly = true;
            this.txtSelo.Size = new System.Drawing.Size(86, 24);
            this.txtSelo.TabIndex = 33;
            this.txtSelo.Visible = false;
            this.txtSelo.MouseEnter += new System.EventHandler(this.txtSelo_MouseEnter);
            // 
            // lblSelo
            // 
            this.lblSelo.AutoSize = true;
            this.lblSelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelo.Location = new System.Drawing.Point(705, 294);
            this.lblSelo.Name = "lblSelo";
            this.lblSelo.Size = new System.Drawing.Size(50, 20);
            this.lblSelo.TabIndex = 34;
            this.lblSelo.Text = "Selo:";
            this.lblSelo.Visible = false;
            // 
            // txtModelo
            // 
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(385, 411);
            this.txtModelo.MaxLength = 50;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(176, 24);
            this.txtModelo.TabIndex = 37;
            this.txtModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModelo_KeyPress);
            this.txtModelo.MouseEnter += new System.EventHandler(this.txtModelo_MouseEnter);
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(381, 388);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(72, 20);
            this.lblModelo.TabIndex = 36;
            this.lblModelo.Text = "Modelo:";
            // 
            // cmbProp
            // 
            this.cmbProp.FormattingEnabled = true;
            this.cmbProp.Location = new System.Drawing.Point(232, 296);
            this.cmbProp.Name = "cmbProp";
            this.cmbProp.Size = new System.Drawing.Size(176, 21);
            this.cmbProp.TabIndex = 38;
            this.cmbProp.Click += new System.EventHandler(this.cmbProp_Click);
            this.cmbProp.MouseEnter += new System.EventHandler(this.cmbProp_MouseEnter);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(321, 564);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(119, 44);
            this.btnEditar.TabIndex = 35;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEditar.MouseEnter += new System.EventHandler(this.btnEditar_MouseEnter);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(72, 321);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(120, 39);
            this.btnLimpar.TabIndex = 39;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click_1);
            this.btnLimpar.MouseEnter += new System.EventHandler(this.btnLimpar_MouseEnter);
            // 
            // TelaVeiculo
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 620);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.cmbProp);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblSelo);
            this.Controls.Add(this.txtSelo);
            this.Controls.Add(this.btnCarregarData);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.gboxCarMoto);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.lblCor);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.lblPlaca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblProprietario);
            this.Controls.Add(this.lblCadastro);
            this.Controls.Add(this.dgvVeiculos);
            this.Controls.Add(this.picBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaVeiculo";
            this.Text = "Veículo";
            this.Enter += new System.EventHandler(this.TelaVeiculo_Enter);
            this.Leave += new System.EventHandler(this.TelaVeiculo_Leave);
            this.gboxCarMoto.ResumeLayout(false);
            this.gboxCarMoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeiculos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.GroupBox gboxCarMoto;
        private System.Windows.Forms.RadioButton rbnMoto;
        private System.Windows.Forms.RadioButton rbnCarro;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.Label lblCor;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblProprietario;
        private System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.DataGridView dgvVeiculos;
        private System.Windows.Forms.PictureBox picBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnCarregarData;
        private System.Windows.Forms.TextBox txtSelo;
        private System.Windows.Forms.Label lblSelo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.ComboBox cmbProp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProprietario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ToolTip toolTip;
    }
}