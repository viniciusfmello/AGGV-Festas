using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IDecoracao
    {
        public static int DefinirPrecoDecoracao(int qtdPessoas, TipoEvento tipoEvento)
        {
            if (tipoEvento == TipoEvento.Premier)
                return 100 * qtdPessoas;
            else if (tipoEvento == TipoEvento.Luxo)
                return 75 * qtdPessoas;
            else if (tipoEvento == TipoEvento.Standard)
                return 50 * qtdPessoas;
            else
                return null;
        }
    }
}
