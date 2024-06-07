using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Standard : ITipoEvento
{
    public List<Produto> _listaProdutos;

    public Standard()
    {
        _listaProdutos = new List<Produto>();
    }

    public void DefinirTipoEvento(TipoEvento tipoEvento)
    {
        
    }
}

