using ConsoleApp1;
using ConsoleApp1.Entities;
using ConsoleApp1.Enums;


public class Evento
{
    public int _qtdConvidados;
    public Espaco _espacoEvento;
    public DateTime _dataEvento;
    public ITipoEvento _tipoEvento;
    public CategoriaEvento _categoriaEvento;
    public List<Produto> _produtos = new List<Produto>()
    {
        new Produto { _nome = "Croquete carne seca", _tipo = TipoEvento.Luxo },
        new Produto { _nome = "Barquetes Legumes", _tipo = TipoEvento.Luxo},
        new Produto { _nome = "Empadinha Gourmet", _tipo= TipoEvento.Luxo},
        new Produto { _nome = "Cestinha de Bacalhau", _tipo = TipoEvento.Luxo },
        new Produto { _nome = "Canapé", _tipo = TipoEvento.Premier },
        new Produto { _nome = "Tartine", _tipo = TipoEvento.Premier},
        new Produto { _nome = "Bruschetta", _tipo = TipoEvento.Premier},
        new Produto { _nome = "Espetinho Caprese", _tipo = TipoEvento.Premier },
        new Produto { _nome = "Coxinha", _tipo = TipoEvento.Standard },
        new Produto { _nome = "Kibe", _tipo = TipoEvento.Standard },
        new Produto { _nome = "Empadinha", _tipo = TipoEvento.Standard },
        new Produto { _nome = "Pão de Queijo", _tipo = TipoEvento.Standard }

    };
    public List<Bebida> _bebidas = new List<Bebida>()
    {
        new Bebida {_nome = "Água com gás 1,5L", _preco = 5.00, _tipo = TipoEvento.Geral },
        new Bebida {_nome = "Suco Natural 1L", _preco = 7.00, _tipo = TipoEvento.Geral},
        new Bebida {_nome = "Refrigerante 2L", _preco = 8.00, _tipo = TipoEvento.Geral },
        new Bebida {_nome = "Cerveja Comum 600ml", _preco = 20.00, _tipo = TipoEvento.Geral},
        new Bebida {_nome = "Cerveja Artesanal 600ml", _preco = 30.00, _tipo= TipoEvento.LuxoIPremier},
        new Bebida {_nome = "Espumante Nacional", _preco = 80.00, _tipo = TipoEvento.Geral},
        new Bebida {_nome = "Espumante Importado", _preco = 140.00, _tipo = TipoEvento.LuxoIPremier}
    };

    public Evento(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento)
    {
        _dataEvento = data;
        _qtdConvidados = qtdConvidados;
        _espacoEvento = espaco;
        _tipoEvento = ITipoEvento.DefinirTipoEvento(tipoEvento);
        _categoriaEvento = categoriaEvento;
    }

    
    public void EscolherQuantidadePrecoBebidas(List<Bebida> bebidasEvento)
    {
        int quantidade = 0;
        for (int i = 0; i < bebidasEvento.Count; i++)
        {
            Console.Write($"Digite a quantidade de {bebidasEvento[i]._nome} que você quer em seu casamento: ");
            quantidade = int.Parse(Console.ReadLine());
            bebidasEvento[i]._quantidade = quantidade;
        }
        Console.WriteLine("Foram escolhidas as quantidades de bebidas do seu evento, a seguir te mostrarei as quantidades escolhidas com os valores totais: ");
        for (int i = 0; i < bebidasEvento.Count; i++)
        {
            Console.WriteLine($"{bebidasEvento[i]._nome} - {bebidasEvento[i]._quantidade}: {bebidasEvento[i]._preco * bebidasEvento[i]._quantidade}.00 ");
        }
    }
    public double CalcularPrecoProdutosEvento(TipoEvento tipoEvento)
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
    public double CalcularPrecoBebidasCasamento(List<Bebida> bebidasEvento)
    {
        double totalBebidas = 0;

        foreach (var b in bebidasEvento)
        {
            totalBebidas += (b._preco * b._quantidade);
        }
        return totalBebidas;
    }
    public void ColocarBebidasEventoPorTipo(TipoEvento tipoBebida, List<Bebida> bebidas)
    {
        for (int i = 0; i < _bebidas.Count; i++)
        {
            if (_bebidas[i]._tipo == TipoEvento.Geral)
            {
                bebidas.Add(_bebidas[i]);
            }
            if ((tipoBebida == TipoEvento.Premier || tipoBebida == TipoEvento.Standard) && _bebidas[i]._tipo == TipoEvento.LuxoIPremier)
            {
                bebidas.Add(_bebidas[i]);
            }
        }
    }
}


