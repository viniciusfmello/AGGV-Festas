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
                /*case 2:
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
                    break;*/
                default:
                    Console.WriteLine("Opção inválida, digite apenas uma opção existente");
                    break;
            }
        }
        static Espaco menuEscolhaEspaco(DateTime data)
        {
            Console.WriteLine("Perfeito! Chegou a hora de apresentar nossas opções de espaço que melhor se adeque à cerimônia desejada");
            foreach (var espaco in empresa._listaEspacos)
            {
                Console.WriteLine($"Espaço {espaco.nomeEspaco} - Capacidade: {espaco.capacidadeMaxima} pessoas: R$ {espaco.valorEspaco}");
            }
            Console.WriteLine("\nDigite o nome do espaço que te atende melhor:");
            string nomeEspaco = Console.ReadLine();
            for (int i = 0; i < empresa._listaEspacos.Count; i++)
            {
                if (empresa._listaEspacos[i].nomeEspaco.Equals(nomeEspaco))
                {
                    bool ehPossivelRealizar = empresa.verificaEspacoDisponivel(empresa._listaEspacos[i], data);
                    if (ehPossivelRealizar)

                        return empresa._listaEspacos[i];

                    else
                        return null;
                }
            }
            return null;

        }
        static void contratarCasamento()
        {
            int qtdConvidados;
            while (true)
            {
                Console.WriteLine("Quantos convidados terão no casamento?");
                if (int.TryParse(Console.ReadLine(), out qtdConvidados))
                {
                    if (qtdConvidados < 1)
                    {
                        Console.WriteLine("Não é possível ter 0 convidados no casamento. Tente novamente.");
                    }
                    else if (qtdConvidados > 500)
                    {
                        Console.WriteLine("Infelizmente nosso maior espaço comporta apenas 500 convidados. Tente novamente.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }
            Console.WriteLine("Certo, agora precisamos saber a data que você deseja realizar o casamento. Segue abaixo algumas de nossas regras:\n\n");
            Console.WriteLine("- Os casamentos são realizados somente às sextas e sábados.\n- Agendamentos de datas apenas com 30 dias de antecedência\n- Realizamos apenas um casamento por dia");
            Console.WriteLine("\n\nDigite uma data no formato DD/MM/AAAA para ser realizado do casamento:");
            string data = Console.ReadLine();
            DateTime dataCasamento;
            if (DateTime.TryParse(dataCasamento, out data))
            {
                
            }
            else
            {
                Console.WriteLine("A data informada é inválida");
            }
            Espaco espacoDesejado = menuEscolhaEspaco(dataCasamento);
        }
        /*static void contratarFormatura()
        {
            menuEscolhaEspaco();
        }
        static void contratarFestaEmpresa()
        {
            menuEscolhaEspaco();
        }
        static void contratarFestaAniversario()
        {
            menuEscolhaEspaco();
        }
        static void contratarEventoLivre()
        {
            menuEscolhaEspaco();
        }*/

    }
}