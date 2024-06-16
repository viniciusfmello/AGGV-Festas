using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Formatura :Evento, IMesa, IDecoracao, IMusica
{
    public int PrecoMesa;
    public int PrecoDecoracao;
    public int PrecoMusica;
    public Formatura(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento) : base(data, qtdConvidados, espaco, tipoEvento, categoriaEvento)
    {
        PrecoMesa = IMesa.DefinirPrecoMesa(qtdConvidados, tipoEvento);
        PrecoDecoracao = IDecoracao.DefinirPrecoDecoracao(qtdConvidados, tipoEvento);
        PrecoMusica = IMusica.DefinirPrecoMusica(qtdConvidados, tipoEvento);
    }

}