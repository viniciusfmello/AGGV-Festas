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
    public void ColocarBebidasCasamentoPorTipo(TipoEvento tipoBebida)
    {
        for (int i = 0; i < _bebidas.Count; i++)
        {
            if (_bebidas[i]._tipo == TipoEvento.Geral)
            {
                _bebidasCasamento.Add(_bebidas[i]);
            }


            if ((tipoBebida == TipoEvento.Premier || tipoBebida == TipoEvento.Standard) && _bebidas[i]._tipo == TipoEvento.LuxoIPremier)
            {
                _bebidasCasamento.Add(_bebidas[i]);
            }
        }
    }
    public void EscolherQuantidadePrecoBebidas()
    {
        int quantidade = 0;
        for (int i = 0; i < _bebidasCasamento.Count; i++)
        {
            Console.Write($"Digite a quantidade de {_bebidasCasamento[i]._nome} que você quer em seu casamento: ");
            quantidade = int.Parse(Console.ReadLine());
            _bebidasCasamento[i]._quantidade = quantidade;
        }
        Console.WriteLine("Foram escolhidas as quantidades de bebidas do seu evento, a seguir te mostrarei as quantidades escolhidas com os valores totais: ");
        for (int i = 0; i < _bebidasCasamento.Count; i++)
        {
            Console.WriteLine($"{_bebidasCasamento[i]._nome} - {_bebidasCasamento[i]._quantidade}: {_bebidasCasamento[i]._preco * _bebidasCasamento[i]._quantidade}.00 ");
        }
    }
    public double CalcularPrecoTotalCasamento(TipoEvento tipoEvento)
    {


        return _espacoEvento.valorEspaco + PrecoMesa + PrecoDecoracao + PrecoBolo + PrecoMusica + CalcularPrecoProdutosCasamento(tipoEvento) + CalcularPrecoBebidasCasamento();
    }

    public double CalcularPrecoProdutosCasamento(TipoEvento tipoEvento)
    {
        double valorProdutos = 0;
        if (tipoEvento == TipoEvento.Premier)
        {
            valorProdutos = _qtdConvidados * 60;
        }
        else if (tipoEvento == TipoEvento.Luxo)
        {
            valorProdutos = _qtdConvidados * 48;
        }
        else
        {
            valorProdutos = _qtdConvidados * 40;
        }
        return valorProdutos;
    }
    public double CalcularPrecoBebidasCasamento()
    {
        double totalBebidas = 0;

        foreach (var b in _bebidasCasamento)
        {
            totalBebidas += (b._preco * b._quantidade);
        }
        return totalBebidas;
    }
}

