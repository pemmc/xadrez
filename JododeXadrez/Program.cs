﻿using System;

using JododeXadrez.tabuleiro;
using JododeXadrez.xadrez;

namespace JododeXadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

               
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(2, 4));

                tab.colocarPeca(new Torre(tab, Cor.Amarela), new Posicao(3, 5));

                Tela.imprimirTabuleiro(tab);
             

               
                Console.ReadLine();
            }

            catch (TabuleiroException e)
            {

                Console.WriteLine("Error Tabuleiro: " + e.Message);

            }
        }
    }
}
