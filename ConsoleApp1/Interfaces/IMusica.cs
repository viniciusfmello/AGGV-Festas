using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IMusica
    {
        public static int DefinirPrecoMusica(int qtdPessoas, TipoEvento tipoEvento)
        {
            if (tipoEvento == TipoEvento.Premier)
                return 30 * qtdPessoas;
            else if (tipoEvento == TipoEvento.Luxo)
                return 25 * qtdPessoas;
            else if (tipoEvento == TipoEvento.Standard)
                return 20 * qtdPessoas;
            else
                return 0;
        }
    }
}
