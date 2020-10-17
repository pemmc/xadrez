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

        private bool podeMover(Posicao pos)
        {

            Peca p = tab.peca(pos);

            return p == null || p.cor != this.cor;
        }

        //este metodo la na super classe PECA é abstrata e agora aqui sera implementada para esta peca
        public override bool[,] movimentosPossiveis()
        {
            
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);

            if(tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            //nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            //sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            //sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            //noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            return mat;
        }


    }
}
