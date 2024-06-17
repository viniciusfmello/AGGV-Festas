using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FestaAniversario : Evento, IMesa, IDecoracao, IBolo, IMusica
{
    public int _precoMesa;
    public int _precoDecoracao;
    public int _precoBolo;
    public int _precoMusica;

    public List<Bebida> _bebidasFestaAniversario;
    public List<Produto> _produtosFestaAniversario;

    public FestaAniversario(DateTime data, int qtdConvidados, Espaco espaco, CategoriaEvento categoriaEvento) : base(data, qtdConvidados, espaco, TipoEvento.Standard, categoriaEvento)
    {
        _precoMesa = IMesa.DefinirPrecoMesa(qtdConvidados, TipoEvento.Standard);
        _precoDecoracao = IDecoracao.DefinirPrecoDecoracao(qtdConvidados, TipoEvento.Standard);
        _precoBolo = IBolo.DefinirPrecoBolo(qtdConvidados, TipoEvento.Standard);
        _precoMusica = IMusica.DefinirPrecoMusica(qtdConvidados, TipoEvento.Standard);
        _bebidasFestaAniversario = new List<Bebida>();
        _produtosFestaAniversario = new List<Produto>();
    }
    public double CalcularPrecoTotalFestaAniversario()
    {
        return _espacoEvento.valorEspaco + _precoMesa + _precoDecoracao + _precoBolo + _precoMusica + CalcularPrecoProdutosEvento(TipoEvento.Standard) + CalcularPrecoBebidasCasamento(_bebidasFestaAniversario);
    }
}

