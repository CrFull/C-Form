using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSelos
{
    class ConstruirSelo
    {
        private String selo;

        public string gerarSelo(String tipoVeiculo)
        {
            Random randNum = new Random();
            return this.selo = tipoVeiculo + randNum.Next(250);
        }
    }
}
