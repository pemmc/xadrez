﻿using System;

using JododeXadrez.tabuleiro;

namespace JododeXadrez
{
    public class Tela
    {

        //Método estático
        public static void imprimirTabuleiro(Tabuleiro tab)
        {

            for (int i = 0; i < tab.linhas; i++)
            {

                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {

                    if(tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");

                    } 
                }

                Console.WriteLine();

            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {

                Console.Write(peca);

            }

            else if(peca.cor == Cor.Amarela)
            {

                ConsoleColor aux = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(peca);

                Console.ForegroundColor = aux;

            }

        }
    }

}
