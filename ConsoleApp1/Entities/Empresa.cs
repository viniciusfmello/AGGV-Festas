using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Empresa
{
    public List<Espaco> _listaEspacos;
    public List<Evento> _listaEventos;

    public Empresa()
    {
        _listaEspacos = new List<Espaco>();
        _listaEventos = new List<Evento>();
    }
    public Espaco EscolherMelhorEspaco(int quantidadeConvidados)
    {
        _listaEspacos.OrderBy(p => p.capacidadeMaxima); //ordena a lista de espaços por capacidade afim de escolher o melhor espaço
        for (int i = 0; i < _listaEspacos.Count; i++)
        {
            if (_listaEspacos[i].capacidadeMaxima >= quantidadeConvidados) { return _listaEspacos[i]; }
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
                while (!verificador)
                {
                    verificador = VerificarEspacoDisponivel(espaco, diaValido);
                    if (verificador)
                    {
                        return diaValido;
                    }
                    
                    else
                    {
                        diaValido = diaValido.AddDays(1);
                        verificador = VerificarEspacoDisponivel(espaco, diaValido);
                    }
                }
            }
            else
            {
                data30DiasDepois = data30DiasDepois.AddDays(1);
            }

        } while (diaValido == DateTime.MinValue);
        return DateTime.MinValue;
    }
    public bool VerificarEspacoDisponivel(Espaco espaco, DateTime data)
    {
        for (int i = 0; i < espaco.disponibilidade.Count; i++)
        {
            if (espaco.disponibilidade[i].dia == data && espaco.disponibilidade[i].disponivel)
                return true;
        }
        return false;
    }
}