using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeSelos.dao;
using ControleDeSelos.modelo;

namespace ControleDeSelos.controle
{
    class ControleVeiculo
    {
        private List<Veiculo> listaDeVeiculos;
        private DAOVeiculo daoVeiculo;

        public bool inserirVeiculo(String cpf, String placa, String marca, String cor, String modelo,String tipoVeiculo)
        {
            String selo = constroiSelos(tipoVeiculo);
            Veiculo v = construirVeiculo(cpf, placa, marca,  cor,  modelo, selo); 
            daoVeiculo = new DAOVeiculo(); 
            if (daoVeiculo.inserir(v) > 0) 
                return true; 
            return false;

        }

        public String constroiSelos(String tipoVeiculo)
        {
            ConstruirSelo cS = new ConstruirSelo();
            String selo = cS.gerarSelo(tipoVeiculo);
            return selo;
        }

        public Veiculo construirVeiculo(String cpf, String placa, String marca, String cor, String modelo,String selo)
        {
            Veiculo v = new Veiculo(); 
            v.CPFProprietario = cpf;
            v.corVeiculo = cor;
            v.marcaVeiculo = marca;
            v.modeloVeiculo = modelo;
            v.placaVeiculo = placa;
            v.seloVeiculo = selo;
            return v;
        }

        public List<Veiculo> carregarTodosOsDados()
        {
            listaDeVeiculos = new List<Veiculo>(); 
            daoVeiculo = new DAOVeiculo(); 
            listaDeVeiculos = daoVeiculo.carregarTodosOsDados(); 

            return listaDeVeiculos; 
        }

        public List<Veiculo> selecionarVeiculoPorAtributos(String elemento, String tupla)
        {
            daoVeiculo = new DAOVeiculo(); 
            listaDeVeiculos = new List<Veiculo>();
            listaDeVeiculos = daoVeiculo.selecionarVeiculoPorAtributos(elemento, tupla);
            return listaDeVeiculos;
        }

        public List<String> selecionaSeloVeiculo(String cpf)
        {
            daoVeiculo = new DAOVeiculo(); 
            List<String> selo = daoVeiculo.selcionaSeloVeiculo(cpf);
            return selo;
        }

        public bool atualizarVeiculo(String placa, String marca, String cor, String modelo, String selo)
        {

            Veiculo v = construirVeiculo("", placa, marca, cor, modelo, selo); 
            daoVeiculo = new DAOVeiculo(); 
            if (daoVeiculo.atualizar(v) > 0) 
                return true; 
            return false;
        }
        public bool atualizarVeiculo(String placa, String marca, String cor, String modelo, String selo,String seloNovo)
        {

            Veiculo v = construirVeiculo("", placa, marca, cor, modelo, selo);
            daoVeiculo = new DAOVeiculo();
            if (daoVeiculo.atualizar(v,seloNovo) > 0)
                return true;
            return false;
        }

        public bool atualizarVeiculo(String CPFNovo,String cpfAntigo)
        {
            daoVeiculo = new DAOVeiculo(); 
            if (daoVeiculo.atualizar(CPFNovo, cpfAntigo) > 0)
                return true; 
            return false;
        }

        public bool apagarVeiculo(String selo)
        {
            daoVeiculo = new DAOVeiculo(); 
            if (daoVeiculo.deletar(selo) > 0)
                return true; 
            return false;
        }
    }
}
