using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Empresa
{
    public List<Espaco> _listaEspacos = new List<Espaco>()
    {
        new Espaco("A", 100, 10000.00),
        new Espaco("B", 100, 10000.00),
        new Espaco("C", 100, 10000.00),
        new Espaco("D", 100, 10000.00),
        new Espaco("E", 200, 17000.00),
        new Espaco("F", 200, 17000.00),
        new Espaco("G", 500, 8000.00),
        new Espaco("H", 500, 35000.00)
    };
    public List<Evento> _listaEventos;


    public Espaco EscolherMelhorEspaco(int quantidadeConvidados)
    {
        _listaEspacos.OrderBy(p => p.capacidadeMaxima); //ordena a lista de espaços por capacidade afim de escolher o melhor espaço
        for (int i = 0; i < _listaEspacos.Count; i++)
        {
            if (_listaEspacos[i].capacidadeMaxima >= quantidadeConvidados)
            {
                return _listaEspacos[i];
            }
        }
        return null;
    }
    public DateTime ProcurarDataMaisProxima(Espaco espaco)
    {
        DateTime dataAtual = DateTime.Now;
        DateTime data30DiasDepois = dataAtual.AddDays(30);
        DateTime diaValido = DateTime.MinValue;
        bool verificador = false;
        do
        {
            if (data30DiasDepois.DayOfWeek == DayOfWeek.Friday || data30DiasDepois.DayOfWeek == DayOfWeek.Saturday)
            {
                diaValido = data30DiasDepois;
                verificador = VerificarEspacoDisponivel(espaco, diaValido);

                if (verificador)
                    return diaValido;

            }

            data30DiasDepois = data30DiasDepois.AddDays(1);


        } while (diaValido == DateTime.MinValue);

        return DateTime.MinValue;
    }

    public bool VerificarEspacoDisponivel(Espaco espaco, DateTime data)
    {
        foreach (var space in _listaEspacos)
        {
            if (space.nomeEspaco == espaco.nomeEspaco)
            {
                foreach (var datas in space.datas)
                {
                    if (datas != DateTime.MinValue)
                        return false;
                }
                return true;
            }
        }
        return false;
    }

}