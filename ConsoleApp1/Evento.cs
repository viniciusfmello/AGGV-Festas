using ConsoleApp1;
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

    public Evento(DateTime data, int qtdConvidados, Espaco espaco, ITipoEvento tipoEvento, ICategoriaEvento categoriaEvento)
    {
        _dataEvento = data;
        _qtdConvidados = qtdConvidados;
        _espacoEvento = espaco;
        _tipoEvento = tipoEvento;
        _categoriaEvento = categoriaEvento;
    }
}


