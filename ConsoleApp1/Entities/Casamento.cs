﻿using ConsoleApp1.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Casamento : Evento, ICategoriaEvento, IMesa, IBolo, IDecoracao, IMusica
{
    public int PrecoMesa;
    public int PrecoDecoracao;
    public int PrecoBolo;
    public int  PrecoMusica;
    
    public Casamento(DateTime data, int qtdConvidados, Espaco espaco, TipoEvento tipoEvento, CategoriaEvento categoriaEvento) : base(data, qtdConvidados, espaco, tipoEvento, categoriaEvento)
    {
        PrecoMesa = IMesa.DefinirPrecoMesa(qtdConvidados, tipoEvento);
        PrecoDecoracao = IDecoracao.DefinirPrecoDecoracao(qtdConvidados, tipoEvento);
        PrecoBolo = IBolo.DefinirPrecoBolo(qtdConvidados, tipoEvento);
        PrecoMusica = IMusica.DefinirPrecoMusica(qtdConvidados, tipoEvento);
    }
    
}