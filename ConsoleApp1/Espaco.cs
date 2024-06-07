using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Espaco
    {
        public string nomeEspaco;
        public int capacidadeMaxima;
        public bool disponibilidade;
        public double valorEspaco;

        public Espaco(string nomeEspaco, int capacidadeMaxima)
        {
            this.nomeEspaco = nomeEspaco;
            this.capacidadeMaxima = capacidadeMaxima;
        }
    }

