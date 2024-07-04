namespace ControleDeSelos
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opProprietario = new System.Windows.Forms.ToolStripMenuItem();
            this.opVeiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.opSair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opProprietario,
            this.opVeiculo,
            this.opSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opProprietario
            // 
            this.opProprietario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opProprietario.Image = global::ControleDeSelos.Properties.Resources.person_icon_icons1;
            this.opProprietario.Name = "opProprietario";
            this.opProprietario.Size = new System.Drawing.Size(116, 24);
            this.opProprietario.Text = "Proprietário";
            this.opProprietario.Click += new System.EventHandler(this.opProprietario_Click_1);
            // 
            // opVeiculo
            // 
            this.opVeiculo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opVeiculo.Image = global::ControleDeSelos.Properties.Resources.car_13260;
            this.opVeiculo.Name = "opVeiculo";
            this.opVeiculo.Size = new System.Drawing.Size(85, 24);
            this.opVeiculo.Text = "Veículo";
            this.opVeiculo.Click += new System.EventHandler(this.opVeiculo_Click);
            // 
            // opSair
            // 
            this.opSair.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opSair.Image = global::ControleDeSelos.Properties.Resources.seo_social_web_network_internet_322_icon_icons_com_61532;
            this.opSair.Name = "opSair";
            this.opSair.Size = new System.Drawing.Size(62, 24);
            this.opSair.Text = "Sair";
            this.opSair.Click += new System.EventHandler(this.opSair_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 407);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opProprietario;
        private System.Windows.Forms.ToolStripMenuItem opVeiculo;
        private System.Windows.Forms.ToolStripMenuItem opSair;
    }
}