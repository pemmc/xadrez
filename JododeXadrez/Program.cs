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
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida); 
                       
                        Console.WriteLine();

                        Console.WriteLine("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                        partida.validarPosicaoOrigem(origem);

                        //Agora limpa a tela e imprimo com as posições marcadas
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                        partida.validarPosicaoDestino(origem, destino);

                        partida.realizaJogada(origem, destino);


                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine("Error Tabuleiro: " + e.Message);
                        Console.ReadLine();

                    }
                }


                Console.Clear();
                Tela.imprimirPartida(partida);
            }

            catch (TabuleiroException e)
            {

                Console.WriteLine("Error Tabuleiro: " + e.Message);
                

            }
        }
    }
}
