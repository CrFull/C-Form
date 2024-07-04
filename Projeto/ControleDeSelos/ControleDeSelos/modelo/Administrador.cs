using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSelos.modelo
{
    class Administrador
    {
        private int ID;
        private String senha;

       public int IdAdm
        {
            get {  return this.ID; }
            set { this.ID = value; }
        }

        public String SenhaAdm
        {
            get { return this.senha; }
            set { this.senha = value; }
        }
    }
}
