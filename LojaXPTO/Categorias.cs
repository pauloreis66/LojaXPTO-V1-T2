using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaXPTO
{
    public class Categorias
    {
        //definir os atributos
        private int codigo;          //maior que 0
        private string categoria;    //3 a 50 chars
        private string zona;         //letra A a Z
        private int fila;            //1 a 100
        private int prateleira;      //1 a 10

        //contrutor
        public Categorias(int codigo, string categoria, string zona, int fila, int prateleira)
        {
            this.codigo = codigo;
            this.categoria = categoria;
            this.zona = zona;
            this.fila = fila;
            this.prateleira = prateleira;
        }

        public Categorias()
        {
            this.codigo = -1;
            this.categoria = String.Empty;
            this.zona = String.Empty;
            this.fila = 0;
            this.prateleira = 0;
        }

        //seletores
        public int getCodigo() { return codigo; }
        public string getCategoria() { return categoria; }
        public string getZona() { return zona; }
        public int getFila() { return fila; }
        public int getPrateleira() { return prateleira; }

        //modificadores
        public void setCodigo(int codigo) { this.codigo = codigo; }
        public void setCategoria(string categoria) { this.categoria = categoria; }
        public void setZona(string zona) { this.zona = zona; }
        public void setFila(int fila) { this.fila = fila; }
        public void setPrateleira(int prateleira) { this.prateleira = prateleira; }

    }
}
