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
    
}