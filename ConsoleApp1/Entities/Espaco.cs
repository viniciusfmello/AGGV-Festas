using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Espaco
{
    public char nomeEspaco;
    public double capacidadeMaxima;
    public List<DisponibilidadeDia> disponibilidade;
    public double valorEspaco;

    public Espaco(char nomeEspaco, int capacidadeMaxima, double valorEspaco)
    {
        this.nomeEspaco = nomeEspaco;
        this.capacidadeMaxima = capacidadeMaxima;
        this.valorEspaco = valorEspaco;
        this.disponibilidade = new List<DisponibilidadeDia>();
    }
}