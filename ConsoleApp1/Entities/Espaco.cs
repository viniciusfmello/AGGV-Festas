using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Espaco
{
    public string nomeEspaco;
    public double capacidadeMaxima;
    public List<DateTime> datas;
    public double valorEspaco;

    public Espaco(string nomeEspaco, int capacidadeMaxima, double valorEspaco)
    {
        this.nomeEspaco = nomeEspaco;
        this.capacidadeMaxima = capacidadeMaxima;
        this.valorEspaco = valorEspaco;
        this.datas = new List<DateTime>();
    }
}