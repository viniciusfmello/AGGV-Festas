using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IBolo
    {
        public static int DefinirPrecoBolo(int qtdPessoas, TipoEvento tipoEvento)
        {
            if (tipoEvento == TipoEvento.Premier)
                return 20 * qtdPessoas;
            else if (tipoEvento == TipoEvento.Luxo)
                return 15 * qtdPessoas;
            else if (tipoEvento == TipoEvento.Standard)
                return 10 * qtdPessoas;
            else
                return 0;
        }
    }
}
