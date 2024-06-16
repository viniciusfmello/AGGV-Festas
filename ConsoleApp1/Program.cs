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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bem-vindo ao AGGV Festas\n");
            Console.ResetColor();
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
            Console.WriteLine("\nDigite a quantidade de convidados que terão no casamento");
            int quantidadeConvidados = int.Parse(Console.ReadLine());
            if (quantidadeConvidados < 0 || quantidadeConvidados > 500)
            {
                Console.WriteLine("\nNós não temos espaço adequado para suportar a quantidade de pessoas informada");
            }
            Espaco espacoCasamento = empresa.EscolherMelhorEspaco(quantidadeConvidados);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nO espaço que mais se adequa para a quantidade de convidados para o casamento é: {espacoCasamento}");
            Console.ResetColor();

            DateTime ProcurarData = empresa.ProcurarDataMaisProxima(espacoCasamento);
            Console.WriteLine($"\nNossos casamentos são realizados na data mais próxima da atual, contando 30 dias a partir do dia de hoje.");
            Console.WriteLine("\nComo são realizados apenas um casamento por dia, é possível que haja um casamento já agendado para este espaço na data mais próxima. Logo, calcularemos a próxima data mais próxima.\n");

            Console.WriteLine($"A data escolhida para o seu evento é: {ProcurarData}\nO espaço selecionado foi o: {espacoCasamento}\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPara continuarmos com a criação do seu Evento, precisamos de estabelecer o tipo de casamento. Escolha o tipo desejado:\n");
            Console.ResetColor();
            Console.WriteLine("\n1) Premier - R$ 60,00:\n- Canapé\n- Tartin\n- Bruschetta\n- Espetinho caprese");
            Console.WriteLine("\n2) Luxo - R$ 48,00:\n- Cestinha de bacalhau\n- Empadinha gourmet\n-Barquetes de legumes\n- Croquete de carne seca\n");
            Console.WriteLine("\b3) Standard - R$ 40,00:\n- Coxinha\n- Kibe\n- Empadinha\n- Pão de queijo\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("O valor de cada tipo será multiplicado pela quantidade de convidados no evento!");
            Console.ResetColor();
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

            Console.WriteLine("\nAgora vou precisar que você escolha as quantidades de bebidas que ofereceremos em seu casamento: ");

            Casamento.ColocarBebidasCasamentoPorTipo(tipoEvento);

            Casamento.EscolherQuantidadePrecoBebidas();

            Casamento.ListarBebidasPorEvento(Casamento._bebidasCasamento);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nVocê já selecionou o que precisamos para gerar um orçamento para você. Estamos calculando o valor do casamento!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAqui está o valor total do seu casamento: {Casamento.CalcularPrecoTotalCasamento(tipoEvento)} ");
            Console.ResetColor();
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