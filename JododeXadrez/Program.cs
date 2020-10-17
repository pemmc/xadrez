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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (! partida.terminada)
                {

                    Console.Clear();

                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();

                    Console.WriteLine("Origem: ");

                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    Console.WriteLine("Destino: ");

                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);


                }


                Console.ReadLine();
            }

            catch (TabuleiroException e)
            {

                Console.WriteLine("Error Tabuleiro: " + e.Message);

            }
        }
    }
}
