namespace ConsoleApp1
{
    internal class Program
    {
        static Espaco[] espacos = {
            new Espaco('A', 100, 10000),
            new Espaco('B', 100,10000),
            new Espaco('C', 100,10000),
            new Espaco('D', 100,10000),
            new Espaco('E', 200,17000),
            new Espaco('F', 200,17000),
            new Espaco('G', 50,8000),
            new Espaco('H', 500,35000)
            };
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
        static Espaco menuEscolhaEspaco()
        {
            Console.WriteLine("Perfeito! Chegou a hora de apresentar nossas opções de espaço que melhor se adeque à cerimônia desejada");
            foreach (var espaco in espacos)
            {
                Console.WriteLine($"Espaço {espaco.nomeEspaco}: R$ {espaco.valorEspaco}");
            }
            Console.WriteLine("\nDigite o nome do espaço que te atende melhor:");
            char nomeEspaco = char.Parse(Console.ReadLine());
            for (int i = 0; i < espacos.Length; i++)
            {
                if (nomeEspaco == espacos[i].nomeEspaco)
                {
                    return espacos[i];
                }
            }
            return null;

        }
        static void contratarCasamento()
        {
            Console.WriteLine("Quantas convidados terão no casamento?");
            int qtdConvidados = int.Parse(Console.ReadLine());
            if (qtdConvidados < 0)
            {
                Console.WriteLine("Não é possível ter 0 convidados no casamento.");
            }
            if (qtdConvidados > 500)
            {
                Console.WriteLine("infelizmente nosso maior espaço coporta apenas 500 convidados");
            }
            else
            {
                Espaco espacoDesejado = menuEscolhaEspaco();
                Console.WriteLine("Certo, agora precisamos saber a data que você deseja realizar o casamento. Segue abaixo algumas de nossas regras:\n\n");
                Console.WriteLine("- Os casamentos são realizados somente às sextas e sábados.\n- Agendamentos de datas apenas com 30 dias de antecedência\n- Realizamos apenas um casamento por dia");
            
            Console.ReadLine();
            }
        }
        static void contratarFormatura()
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
        }
    
}
}
