using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Empresa
{
    public List<Espaco> _listaEspacos;
    public List<Evento> _listaEventos;

    public Empresa()
    {
        _listaEspacos = new List<Espaco>();
        _listaEventos = new List<Evento>();
    }
}
