﻿using JododeXadrez.tabuleiro;

namespace JododeXadrez.tabuleiro
{
    //em razao do metodo abaixo ter que ser abstrato, esta classe tb mudou para abstrata
    public abstract class Peca
    {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos  { get; protected set; }
        public  Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        { 
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;

            this.qteMovimentos = 0;

        }

        public void incrementarQteMovimentos()
        {

            this.qteMovimentos++;

        }

        public void decrincrementarQteMovimentos()
        {

            this.qteMovimentos--;

        }

        public bool existemMovimentosPossiveis()
        {

            bool[,] mat = movimentosPossiveis();

            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if(mat[i,j])
                    {
                        return true;


                    }

                }

            }

            return false;

        }

        public bool movimentoPossivel(Posicao pos)
        {

            return movimentosPossiveis()[pos.linha, pos.coluna];

        }

        //nao pode ser implementada aqui nesta classe por isso abstrata o metodo e esta classe tb tem que ser abstrata
        //operacao que toda a classe de cada peca tera que ter dentro de cada peca especifica
        public abstract bool[,] movimentosPossiveis();


         
    }
}
