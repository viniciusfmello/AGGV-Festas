using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Formatura : Evento, IMesa, IDecoracao, IMusica
{
    public int _precoMesa;
    public int _precoDecoracao;
    public int _precoMusica;
    public List<Produto> _produtosFormatura;
    public List<Bebida> _bebidasFormatura;
    public Formatura(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento) : base(data, qtdConvidados, espaco, tipoEvento, categoriaEvento)
    {
        _precoMesa = IMesa.DefinirPrecoMesa(qtdConvidados, tipoEvento);
        _precoDecoracao = IDecoracao.DefinirPrecoDecoracao(qtdConvidados, tipoEvento);
        _precoMusica = IMusica.DefinirPrecoMusica(qtdConvidados, tipoEvento);
        _produtosFormatura = new List<Produto>();
        _bebidasFormatura = new List<Bebida>();
    }

    public void ColocarProdutosFormaturaPorTipo(TipoEvento tipoProduto)
    {
        for (int i = 0; i < _produtos.Count; i++)
        {
            if (_produtos[i]._tipo == tipoProduto)
            {
                _produtosFormatura.Add(_produtos[i]);
            }
        }
    }
    public double CalcularPrecoTotalFormatura(TipoEvento tipoEvento)
    {
        valorTotalFesta = _espacoEvento.valorEspaco + _precoMesa + _precoDecoracao + _precoMusica + CalcularPrecoProdutosEvento(tipoEvento) + CalcularPrecoBebidasEvento(_bebidasFormatura);
        return valorTotalFesta;
    }
    public void MostrarResumoFormatura(TipoEvento tipoEvento)
    {
        Console.WriteLine($"Valor do espaço:{_espacoEvento.valorEspaco}.00");
        Console.WriteLine($"Valor dos itens de mesa:{_precoMesa}");
        Console.WriteLine($"Valor da decoração:{_precoDecoracao}");
        Console.WriteLine($"Valor da música:{_precoMusica}");
        Console.WriteLine($"Valor das comidas:{CalcularPrecoProdutosEvento(tipoEvento)}");
        Console.WriteLine("\nLista das comidas:");
        foreach (Produto a in _produtosFormatura)
        {
            Console.WriteLine($"- {a._nome}");
        }
        Console.WriteLine($"\nValor das bebidas:{CalcularPrecoBebidasEvento(_bebidasFormatura)}");
        Console.WriteLine("\nLista das bebidas");
        foreach (Bebida a in _bebidasFormatura)
        {
            Console.WriteLine($"- Bebida: {a._nome} - Quantidade: {a._quantidade}");
        }
    }

}