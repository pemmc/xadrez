using System;

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

                /*
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));
 
                Tela.imprimirTabuleiro(tab);
                */

                PosicaoXadrez pos = new PosicaoXadrez('c', 7);

                Console.WriteLine(pos);

                Console.WriteLine(pos.toPosicao());

                Console.ReadLine();
            }

            catch (TabuleiroException e)
            {

                Console.WriteLine("Error Tabuleiro: " + e.Message);

            }
        }
    }
}
