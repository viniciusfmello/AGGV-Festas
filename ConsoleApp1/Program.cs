using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        static Empresa empresa = new Empresa();
        static Evento evento;
        static Espaco espaco;
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao AGGV Festas\n");
            Console.WriteLine("Qual tipo de evento você deseja contratar?\n");
            Console.WriteLine("1 - Casamento\n2 - Formatura\n3 - Festa de empresa\n4 - Festa de aniversário\n5 - Evento livre\n");
            int opcao = int.Parse(Console.ReadLine());
            //tratar excessão
            switch (opcao)
            {
                case 1:
                    contratarCasamento();
                    break;
                case 2:
                    contratarFormatura();
                    break;
                case 3:
                    contratarFestaEmpresa();
                    break;
                case 4:
                    contratarFestaAniversario();
                    break;
                case 5:
                    contratarEventoLivre();
                    break;
                default:
                    Console.WriteLine("Opção inválida, digite apenas uma opção existente");
                    break;
            }
            
        }
        static void contratarCasamento()
        {
            Console.WriteLine("Digite a quantidade de convidados que terão no casamento");
            int quantidadeConvidados = int.Parse(Console.ReadLine());
            if (quantidadeConvidados < 0 || quantidadeConvidados > 500)
            {
                Console.WriteLine("Nós não temos espaço adequado para suportar a quantidade de pessoas informada");
            }
            Espaco espacoCasamento = empresa.EscolherMelhorEspaco(quantidadeConvidados);
            //informar para o usuário o espaço selecionado
            DateTime ProcurarData = empresa.ProcurarDataMaisProxima(espacoCasamento);
            //informar para o usuário a data e o espaço que será realizado o casamento 



        }
        static void contratarFormatura()
        {
            
        }
        static void contratarFestaEmpresa()
        {
          
        }
        static void contratarFestaAniversario()
        {
           
        }
        static void contratarEventoLivre()
        {
            
        }

    }
}