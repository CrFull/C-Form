using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeSelos.modelo
{
    class Proprietario
    {
        private String nome;
        private String sobrenome;
        private String matricula;
        private String CPF;
        private String funcao;
        private int ID;

        public int IDProp
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public String NomeProp {
             get { return this.nome; }
            set { this.nome = value; }
        }

        public String SobreNomeProp
        {
            get { return this.sobrenome; }
            set { this.sobrenome = value; }
        }

        public String CPFProp
        {
            get { return this.CPF; }
            set { this.CPF = value; }
        }

        public String FuncaoProp
        {
            get { return this.funcao; }
            set { this.funcao = value; }
        }

        public String MatriculaProp
        {
            get { return this.matricula; }
            set { this.matricula = value; }
        }

    }
}
