using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FestaEmpresa : Evento, IMusica
{
    public int _precoMusica;
    public List<Produto> _produtosFestaEmpresa;
    public List<Bebida> _bebidasFestaEmpresa;

    public FestaEmpresa(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento) : base(data, qtdConvidados, espaco, tipoEvento, categoriaEvento)
    {
        _precoMusica = IMusica.DefinirPrecoMusica(qtdConvidados, tipoEvento);
        _produtosFestaEmpresa = new List<Produto>();
        _bebidasFestaEmpresa = new List<Bebida>();
    }
    public double CalcularPrecoTotalFestaEmpresa(TipoEvento tipoEvento)
    {
        return _espacoEvento.valorEspaco + _precoMusica + CalcularPrecoProdutosEvento(tipoEvento) + CalcularPrecoBebidasCasamento(_bebidasFestaEmpresa);
    }
    public void MostrarResumoFestaEmpresa(TipoEvento tipoEvento)
    {
        Console.WriteLine($"Valor do espaço:{_espacoEvento.valorEspaco}.00");
        Console.WriteLine($"Valor da música:{_precoMusica}");
        Console.WriteLine($"Valor das comidas:{CalcularPrecoProdutosEvento(tipoEvento)}");
        Console.WriteLine("\nLista das comidas:");
        foreach (Produto a in _produtosFestaEmpresa)
        {
            Console.WriteLine($"- {a._nome}");
        }
        Console.WriteLine($"\nValor das bebidas:{CalcularPrecoBebidasCasamento(_bebidasFestaEmpresa)}");
        Console.WriteLine("\nLista das bebidas");
        foreach (Bebida a in _bebidasFestaEmpresa)
        {
            Console.WriteLine($"- Bebida: {a._nome} - Quantidade: {a._quantidade}");
        }
    }
}