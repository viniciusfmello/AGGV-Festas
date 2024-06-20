using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
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

    public Empresa()
    {
        _listaEventos = new List<Evento>();
    }
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

    public void AdicionarEventoNoArquivo(Evento festa, string caminhoArquivo)
    {
        string eventoString = FormatEvento(festa);

        // Abre o arquivo para escrita, criando-o se não existir, e usando append para adicionar ao final
        using (StreamWriter arq = new StreamWriter(caminhoArquivo, append: true))
        {
            arq.WriteLine(eventoString);
        }

        Console.WriteLine("Evento adicionado no arquivo com sucesso!");
    }

    static string FormatEvento(Evento evento)
    {
        if(evento is Casamento)
        {
            Casamento casamento = evento as Casamento;
            string produtosString = string.Join(";", casamento._produtosCasamento.ConvertAll(p => p._nome));
            string bebidasString = string.Join(";", casamento._bebidasCasamento.ConvertAll(b => $"{b._nome}:{b._quantidade}"));
            return $"{casamento._qtdConvidados}|{casamento._espacoEvento.nomeEspaco}|{casamento._espacoEvento.capacidadeMaxima}|{casamento._espacoEvento.valorEspaco}|{casamento._dataEvento.ToShortDateString()}|{casamento._categoriaEvento}|{casamento.valorTotalFesta}|{casamento._tipoEvento}|{produtosString}|{bebidasString}|{casamento.PrecoDecoracao}|{casamento.PrecoBolo}|{casamento.PrecoMusica}|{casamento.PrecoMesa}";
        }
        else if (evento is FestaAniversario)
        {
            FestaAniversario festaAniversario = evento as FestaAniversario;
            string produtosString = string.Join(";", festaAniversario._produtosFestaAniversario.ConvertAll(p => p._nome));
            string bebidasString = string.Join(";", festaAniversario._bebidasFestaAniversario.ConvertAll(b => $"{b._nome}:{b._quantidade}"));
            return $"{festaAniversario._qtdConvidados}|{festaAniversario._espacoEvento.nomeEspaco}|{festaAniversario._espacoEvento.capacidadeMaxima}|{festaAniversario._espacoEvento.valorEspaco}|{festaAniversario._dataEvento.ToShortDateString()}|{festaAniversario._categoriaEvento}|{festaAniversario.valorTotalFesta}|{festaAniversario._tipoEvento}|{festaAniversario._precoDecoracao}|{festaAniversario._precoBolo}|{festaAniversario._precoMusica}|{festaAniversario._precoMesa}|{produtosString}|{bebidasString}";
        }
        else if (evento is Formatura)
        {
            Formatura formatura = evento as Formatura;
            string produtosString = string.Join(";", formatura._produtosFormatura.ConvertAll(p => p._nome));
            string bebidasString = string.Join(";", formatura._bebidasFormatura.ConvertAll(b => $"{b._nome}:{b._quantidade}"));
            return $"{formatura._qtdConvidados}|{formatura._espacoEvento.nomeEspaco}|{formatura._espacoEvento.capacidadeMaxima}|{formatura._espacoEvento.valorEspaco}|{formatura._dataEvento.ToShortDateString()}|{formatura._categoriaEvento}|{formatura.valorTotalFesta}|{formatura._tipoEvento}|{produtosString}|{bebidasString}|{formatura._precoDecoracao}|{formatura._precoMusica}|{formatura._precoMesa}";

        }
        else if (evento is FestaEmpresa)
        {
            FestaEmpresa festaEmpresa = evento as FestaEmpresa;
            string produtosString = string.Join(";", festaEmpresa._produtosFestaEmpresa.ConvertAll(p => p._nome));
            string bebidasString = string.Join(";", festaEmpresa._bebidasFestaEmpresa.ConvertAll(b => $"{b._nome}:{b._quantidade}"));
            return $"{festaEmpresa._qtdConvidados}|{festaEmpresa._espacoEvento.nomeEspaco}|{festaEmpresa._espacoEvento.capacidadeMaxima}|{festaEmpresa._espacoEvento.valorEspaco}|{festaEmpresa._dataEvento.ToShortDateString()}|{festaEmpresa._categoriaEvento}|{festaEmpresa.valorTotalFesta}|{festaEmpresa._tipoEvento}|{produtosString}|{bebidasString}|{festaEmpresa._precoMusica}|";
        }
        else
        {
            FestaLivre festaLivre = evento as FestaLivre;
            string produtosString = string.Join(";", festaLivre._listaProdutosFestaLivre.ConvertAll(p => p._nome));
            string bebidasString = string.Join(";", festaLivre._listaBebidasFestaLivre.ConvertAll(b => $"{b._nome}:{b._quantidade}"));
            return $"{festaLivre._qtdConvidados}|{festaLivre._espacoEvento.nomeEspaco}|{festaLivre._espacoEvento.capacidadeMaxima}|{festaLivre._espacoEvento.valorEspaco}|{festaLivre._dataEvento.ToShortDateString()}|{festaLivre._categoriaEvento}|{festaLivre.valorTotalFesta}|{festaLivre._tipoEvento}|{produtosString}|{bebidasString}";

        }

    }


}