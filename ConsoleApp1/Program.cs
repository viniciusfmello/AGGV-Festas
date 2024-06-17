using ConsoleApp1.Enums;
using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        static Empresa empresa = new Empresa();

        static void Main(string[] args)
        {
            bool opcaoValida = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bem-vindo ao AGGV Festas\n");
            Console.ResetColor();
            TipoEvento tipoEvento = TipoEvento.Nulo;
            Espaco espacoEvento = null;
            int quantidadeConvidados = 0;

            Console.WriteLine("Temos 8 tipos de espaços incríveis para você, com capacidades variando entre 100, 200 e 500 convidados!");
            do
            {
                Console.WriteLine("\nDigite a quantidade de convidados desejada no casamento:");
                quantidadeConvidados = int.Parse(Console.ReadLine());

                if (quantidadeConvidados <= 0 || quantidadeConvidados > 500)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNós não temos espaço adequado para suportar a quantidade de pessoas informada. A quantidade máxima que nossos espaços suportam é de 500 pessoas");
                    Console.ResetColor();
                }
                else
                {
                    espacoEvento = empresa.EscolherMelhorEspaco(quantidadeConvidados);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\nO espaço que mais se adequa para a quantidade de convidados para o casamento é: {espacoEvento}");
                    Console.ResetColor();
                    break;
                }
            } while (true);



            DateTime ProcurarData = empresa.ProcurarDataMaisProxima(espacoEvento);
            Console.WriteLine($"\nNossos casamentos são realizados na data mais próxima da atual, contando 30 dias a partir do dia de hoje.");
            Console.WriteLine("\nComo são realizados apenas um casamento por dia, é possível que haja um casamento já agendado para este espaço na data mais próxima. Logo, calcularemos a próxima data mais próxima.\n");

            Console.WriteLine($"A data escolhida para o seu evento é: {ProcurarData}\nO espaço selecionado foi o: {espacoEvento}\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPara continuarmos com a criação do seu Evento, precisamos de estabelecer o tipo de evento. Escolha o tipo desejado:\n");
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
            Console.WriteLine("Qual tipo de evento você deseja contratar?\n");
            Console.WriteLine("1 - Casamento\n2 - Formatura\n3 - Festa de empresa\n4 - Festa de aniversário\n5 - Evento livre\n");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    contratarCasamento(ProcurarData, quantidadeConvidados, espacoEvento, tipoEvento);
                    opcaoValida = true;
                    break;
                case 2:
                    contratarFormatura(ProcurarData, quantidadeConvidados, espacoEvento, tipoEvento);
                    opcaoValida = true;
                    break;
                case 3:
                    contratarFestaEmpresa(ProcurarData, quantidadeConvidados, espacoEvento, tipoEvento);
                    opcaoValida = true;
                    break;
                case 4:
                    if(tipoEvento == TipoEvento.Standard) { 
                    contratarFestaAniversario(ProcurarData, quantidadeConvidados, espacoEvento);
                    opcaoValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Festa de aniversário só aceita eventos do padrão Standard, qualquer outro tipo de evento não se encaixa nas condições de Festa de Aniversário");
                    }
                    break;
                case 5:
                    contratarEventoLivre(ProcurarData, quantidadeConvidados, espacoEvento, tipoEvento);
                    opcaoValida = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida, digite apenas uma opção existente");
                    Console.ResetColor();

                    break;
            } while (!opcaoValida) ;
        }

        static void contratarCasamento(DateTime data, int quantidadeConvidados, Espaco espacoEvento, TipoEvento tipoEvento)
        {


            Casamento Casamento = new Casamento(data, quantidadeConvidados, espacoEvento, tipoEvento, CategoriaEvento.Casamento);

            Console.WriteLine("\nAgora vou precisar que você escolha as quantidades de bebidas que ofereceremos em seu casamento: ");

            Casamento.ColocarBebidasEventoPorTipo(tipoEvento, Casamento._bebidasCasamento);

            Casamento.EscolherQuantidadePrecoBebidas(Casamento._bebidasCasamento);

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("\nVocê já selecionou o que precisamos para gerar um orçamento para você. Estamos calculando o valor do casamento!");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nAqui está o valor total do seu casamento: {Casamento.CalcularPrecoTotalCasamento(tipoEvento)} ");

            Console.ResetColor();
        }
        static void contratarFormatura(DateTime data, int quantidadeConvidados, Espaco espacoEvento, TipoEvento tipoEvento)
        {
            Formatura Formatura = new Formatura(data, quantidadeConvidados, espacoEvento, tipoEvento, CategoriaEvento.Formatura);
            Console.WriteLine("\nAgora vou precisar que você escolha as quantidades de bebidas que ofereceremos em seu evento de formatura: ");

            Formatura.ColocarBebidasEventoPorTipo(tipoEvento, Formatura._bebidasFormatura);

            Formatura.EscolherQuantidadePrecoBebidas(Formatura._bebidasFormatura);

            Console.WriteLine("\nVocê já selecionou o que precisamos para gerar um orçamento para você. Estamos calculando o valor do casamento!");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nAqui está o valor total da sua formatura: {Formatura.CalcularPrecoTotalFormatura(tipoEvento)} ");
            Console.ResetColor();

        }
        static void contratarFestaEmpresa(DateTime data, int quantidadeConvidados, Espaco espacoEvento, TipoEvento tipoEvento)
        {
            FestaEmpresa festaEmpresa = new FestaEmpresa(data, quantidadeConvidados, espacoEvento, tipoEvento, CategoriaEvento.FestaEmpresa);

            Console.WriteLine("\nAgora vou precisar que você escolha as quantidades de bebidas que ofereceremos em seu evento de festa empresarial: ");
            festaEmpresa.ColocarBebidasEventoPorTipo(tipoEvento, festaEmpresa._bebidasFestaEmpresa);
            festaEmpresa.EscolherQuantidadePrecoBebidas(festaEmpresa._bebidasFestaEmpresa);
            Console.WriteLine("\nVocê já selecionou o que precisamos para gerar um orçamento para você. Estamos calculando o valor do casamento!");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nAqui está o valor total da sua formatura: {festaEmpresa.CalcularPrecoTotalFestaEmpresa(tipoEvento)} ");
            Console.ResetColor();
        }
        static void contratarFestaAniversario(DateTime data, int quantidadeConvidados, Espaco espacoEvento)
        {
            FestaAniversario festaAniversario = new FestaAniversario(data, quantidadeConvidados, espacoEvento, CategoriaEvento.FestaAniversario);
            Console.WriteLine("\nAgora vou precisar que você escolha as quantidades de bebidas que ofereceremos em seu evento de festa de aniversário: ");
            festaAniversario.ColocarBebidasEventoPorTipo(TipoEvento.Standard, festaAniversario._bebidasFestaAniversario);
            festaAniversario.EscolherQuantidadePrecoBebidas(festaAniversario._bebidasFestaAniversario);
            Console.WriteLine("\nVocê já selecionou o que precisamos para gerar um orçamento para você. Estamos calculando o valor do casamento!");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nAqui está o valor total da sua formatura: {festaAniversario.CalcularPrecoTotalFestaAniversario()} ");
            Console.ResetColor();

        }
        static void contratarEventoLivre(DateTime data, int quantidadeConvidados, Espaco espacoEvento, TipoEvento tipoEvento)
        {

        }

    }
}