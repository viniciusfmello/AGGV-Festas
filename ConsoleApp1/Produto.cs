using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Produto
{
    public string _nome;
    public double _preco;
    public TipoProduto _tipo;

    public Produto(string nome, double preco, TipoProduto tipo)
    {
        _nome = nome;
        _preco = preco;
        _tipo = tipo;
    }
}

public enum TipoProduto
{
   
}