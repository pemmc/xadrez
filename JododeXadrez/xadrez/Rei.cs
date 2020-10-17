using System;
using JododeXadrez.tabuleiro;


namespace JododeXadrez.xadrez
{
    public class Rei : Peca
    {

        public Rei(Tabuleiro tab, Cor cor) : base (tab, cor)
        {


        }

        public override string ToString()
        {

            return "R";

        }

    }
}
