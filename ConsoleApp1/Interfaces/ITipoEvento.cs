using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ITipoEvento
{
   public static ITipoEvento DefinirTipoEvento(TipoEvento tipoEvento)
    {
        if (tipoEvento == TipoEvento.Premier)
            return new Premier();
        else if (tipoEvento == TipoEvento.Luxo)
            return new Luxo();
        else if (tipoEvento == TipoEvento.Standard)
            return new Standard();
        else
            return null;
    }

}
