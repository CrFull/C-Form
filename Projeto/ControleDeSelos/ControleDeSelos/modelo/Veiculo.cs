using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSelos.modelo
{
    class Veiculo
    {
        private String CPF; 
        private String modelo;
        private String marca;
        private String placa;
        private String cor;
        private String selo;

        public String CPFProprietario
        {
            get { return this.CPF; }
            set { this.CPF = value; }
        }

        public String modeloVeiculo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        public String marcaVeiculo
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        public String placaVeiculo
        {
            get { return this.placa; }
            set { this.placa = value; }
        }

        public String corVeiculo
        {
            get { return this.cor; }
            set { this.cor = value; }
        }

        public String seloVeiculo
        {
            get { return this.selo; }
            set { this.selo = value; }
        }

    }
}
