using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class FestaLivre : Evento 
    {
        public List<Produto> _listaProdutosFestaLivre;
        public List<Bebida> _listaBebidasFestaLivre;
        public FestaLivre(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento) : base (data, qtdConvidados, espaco,  tipoEvento, categoriaEvento)
        {
            _listaProdutosFestaLivre = new List<Produto>();
            _listaBebidasFestaLivre = new List<Bebida>();
        }



        public double CalcularPrecoTotalFestaLivre(TipoEvento tipoEvento)
        {
            valorTotalFesta = _espacoEvento.valorEspaco + CalcularPrecoProdutosEvento(tipoEvento) + CalcularPrecoBebidasEvento(_listaBebidasFestaLivre);
            return valorTotalFesta;
        }

        public void MostrarResumoFestaLivre()
        {
            Console.WriteLine($"Valor do espaço:{_espacoEvento.valorEspaco}.00");
        }
    }
}
