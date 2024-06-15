using ConsoleApp1;
using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Evento
{
    public int _qtdConvidados;
    public Espaco _espacoEvento;
    public DateTime _dataEvento;
    public ITipoEvento _tipoEvento;
    public ICategoriaEvento _categoriaEvento;
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



    public Evento(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento)
    {
        _dataEvento = data;
        _qtdConvidados = qtdConvidados;
        _espacoEvento = espaco;
        _tipoEvento = ITipoEvento.DefinirTipoEvento(tipoEvento);
        //_categoriaEvento = ICategoriaEvento.DefinirCategoriaEvento(categoriaEvento);
    }

    public void ListarProdutosPorTipo(TipoEvento tipoProduto)
    {
        Console.WriteLine($"Lista de Produtos do tipo {tipoProduto}: ");
        foreach (Produto p in _produtos)
        {
            if (p._tipo == tipoProduto)
            {
                Console.WriteLine($"-{p._nome}");
            }
        }
    }
}


