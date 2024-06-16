using ConsoleApp1.Enums;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        static Empresa empresa = new Empresa();

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
            TipoEvento tipoEvento = TipoEvento.Nulo;
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
            Console.WriteLine($"A data escolhida para o seu evento é: {ProcurarData.ToString()}\nO espaço selecionado foi o: {espacoCasamento.nomeEspaco} com capacidade para {espacoCasamento.capacidadeMaxima} pessoas.");
            //informar para o usuário os valores e explicação sobre os tipos de evento (premier, luxo, standard)
            Console.Write("Para continuarmos com a criação do seu Evento, precisamos de estabelecer o tipo de casamento sendo eles:\n1 - Premier\n2 - Luxo\n3 - Standard\nEscolha uma opção:");
            int opcao = int.Parse(Console.ReadLine());
            do
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Você escolheu a opção Premier, portanto o seu evento será baseado nas categorias de Premier informadas anteriormente.");
                        tipoEvento = TipoEvento.Premier;
                        break;
                    case 2:
                        Console.WriteLine("Você escolheu a opção Luxo, portanto o seu evento será baseado nas categorias de Luxo informadas anteriormente.");
                        tipoEvento = TipoEvento.Luxo;
                        break;
                    case 3:
                        Console.WriteLine("Você escolheu a opção Standard, portanto o seu evento será baseado nas categorias de Standard informadas anteriormente");
                        tipoEvento = TipoEvento.Standard;
                        break;
                    default:
                        Console.WriteLine("Você escolheu uma opção inválida, escolha outra opção: ");
                        opcao = int.Parse(Console.ReadLine());
                        break;
                }
            } while (tipoEvento == TipoEvento.Nulo);
            Casamento Casamento = new Casamento(ProcurarData, quantidadeConvidados, espacoCasamento, tipoEvento, CategoriaEvento.Casamento);

            Console.WriteLine("O tipo de evento escolhido fornece os seguintes produtos:");

            Casamento.ColocarProdutosCasamentoPorTipo(tipoEvento);

            Casamento.ListarProdutosPorEvento(Casamento._produtosCasamento);

            Console.WriteLine("Agora vou precisar que você escolha as quantidades de bebidas que ofereceremos em seu casamento: ");

            Casamento.ColocarBebidasCasamentoPorTipo(tipoEvento);

            Casamento.EscolherQuantidadePrecoBebidas();

            Casamento.ListarBebidasPorEvento(Casamento._bebidasCasamento);

            Console.WriteLine("Você já selecionou o que precisamos para gerar um orçamento para você.");

            Console.WriteLine($"Aqui está o valor total do seu casamento: {Casamento.CalcularPrecoTotalCasamento(tipoEvento)} ");
            



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