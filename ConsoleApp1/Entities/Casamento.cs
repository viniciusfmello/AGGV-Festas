using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Casamento : Evento, IMesa, IBolo, IDecoracao, IMusica
{
    public int PrecoMesa;
    public int PrecoDecoracao;
    public int PrecoBolo;
    public int PrecoMusica;
    public List<Produto> _produtosCasamento;
    public List<Bebida> _bebidasCasamento; 

    public Casamento(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento) : base(data, qtdConvidados, espaco, tipoEvento, categoriaEvento)
    {
        PrecoMesa = IMesa.DefinirPrecoMesa(qtdConvidados, tipoEvento);
        PrecoDecoracao = IDecoracao.DefinirPrecoDecoracao(qtdConvidados, tipoEvento);
        PrecoBolo = IBolo.DefinirPrecoBolo(qtdConvidados, tipoEvento);
        PrecoMusica = IMusica.DefinirPrecoMusica(qtdConvidados, tipoEvento);
        _produtosCasamento = new List<Produto>();
        _bebidasCasamento = new List<Bebida>();
    }
    public void ColocarProdutosCasamentoPorTipo(TipoEvento tipoProduto)
    {
        for (int i = 0; i < _produtos.Count; i++)
        {
            if (_produtos[i]._tipo == tipoProduto)
            {
                _produtosCasamento.Add(_produtos[i]);
            }
        }
    }
   
    public double CalcularPrecoTotalCasamento(TipoEvento tipoEvento)
    {
        return _espacoEvento.valorEspaco + PrecoMesa + PrecoDecoracao + PrecoBolo + PrecoMusica + CalcularPrecoProdutosEvento(tipoEvento) + CalcularPrecoBebidasEvento(_bebidasCasamento);
    }
    public void MostrarResumoCasamento(TipoEvento tipoEvento)
    {
        Console.WriteLine($"Valor do espaço:{_espacoEvento.valorEspaco}.00");
        Console.WriteLine($"Valor dos itens de mesa:{PrecoMesa}");
        Console.WriteLine($"Valor da decoração:{PrecoDecoracao}");
        Console.WriteLine($"Valor do bolo:{PrecoBolo}");
        Console.WriteLine($"Valor da música:{PrecoMusica}");
        Console.WriteLine($"Valor das comidas:{CalcularPrecoProdutosEvento(tipoEvento)}");
        Console.WriteLine("\nLista das comidas:");
        foreach(Produto a in _produtosCasamento)
        {
            Console.WriteLine($"- {a._nome}");
        }
        Console.WriteLine($"\nValor das bebidas:{CalcularPrecoBebidasEvento(_bebidasCasamento)}");
        Console.WriteLine("\nLista das bebidas");
        foreach (Bebida a in _bebidasCasamento)
        {
            Console.WriteLine($"- Bebida: {a._nome} - Quantidade: {a._quantidade}");
        }
    }

}

