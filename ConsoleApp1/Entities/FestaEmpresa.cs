using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FestaEmpresa : Evento, IMusica
{
    public int PrecoMusica;

    public FestaEmpresa(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento) : base(data, qtdConvidados, espaco, tipoEvento, categoriaEvento)
    {
        PrecoMusica = IMusica.DefinirPrecoMusica(qtdConvidados, tipoEvento);
    }

}