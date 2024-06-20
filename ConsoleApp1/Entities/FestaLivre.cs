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
            return _espacoEvento.valorEspaco + CalcularPrecoProdutosEvento(tipoEvento) + CalcularPrecoBebidasEvento(_listaBebidasFestaLivre);
        }
        public void MostrarResumoFestaLivre(TipoEvento tipoEvento)
        {
            Console.WriteLine($"Valor do espaço:{_espacoEvento.valorEspaco}.00");
            Console.WriteLine($"Valor das comidas:{CalcularPrecoProdutosEvento(tipoEvento)}");
            Console.WriteLine("\nLista das comidas:");
            foreach (Produto a in _listaProdutosFestaLivre)
            {
                Console.WriteLine($"- {a._nome}");
            }
            Console.WriteLine($"\nValor das bebidas:{CalcularPrecoBebidasEvento(_listaBebidasFestaLivre)}");
            Console.WriteLine("\nLista das bebidas");
            foreach (Bebida a in _listaBebidasFestaLivre)
            {
                Console.WriteLine($"- Bebida: {a._nome} - Quantidade: {a._quantidade}");
            }
        }
    }
}
