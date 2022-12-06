using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaXPTO
{
    public class Produtos
    {
        //atributos da classe
        private int codigo;     
        private string nomeProduto;
        private int categoria;
        private double preco;

        //construtor
        public Produtos (int codigo, string nomeProduto, int categoria, double preco)
        {
            this.codigo = codigo;
            this.nomeProduto = nomeProduto;
            this.preco = preco;
            this.categoria = categoria;
        }

        //seletores
        public int getCodigo()
        {
            return codigo;
        }

        public string getNomeProduto()
        {
            return nomeProduto;
        }

        public double getPreco()
        {
            return preco;
        }

        public int getCategoria()
        {
            return categoria;
        }


        //modificadores
        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public void setNomeProduto(string nomeProduto)
        {
            this.nomeProduto = nomeProduto;
        }

        public void setPreco(double preco)
        {
            this.preco = preco;
        }

        public void setCategoria(int categoria)
        {
            this.categoria = categoria;
        }
    }
}
