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

                    //Agora limpa a tela e imprimo com as posições marcadas
                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                    
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
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
