using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Premier : ITipoEvento
{
    public List<Produto> _listaProdutos;

    public Premier()
    {
        _listaProdutos = new List<Produto>();
    }

}
