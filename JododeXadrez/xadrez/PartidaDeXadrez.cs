using System.Collections.Generic;
using JododeXadrez.tabuleiro;


namespace JododeXadrez.xadrez
{
    public class PartidaDeXadrez
    {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPecas();

        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();

            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);

            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);

            turno++;

            mudaJogador();

        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            { 
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");

            }

            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");

            }

            if (!tab.peca(pos).existemMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça de origem");

            }

        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posção de destinho inválida");

            }
             
           

        }


        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Amarela;

            }
            else if (jogadorAtual == Cor.Amarela)
            {
                jogadorAtual = Cor.Branca;

            }

        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {

                    aux.Add(x);
                    
                }

            }

            return aux;

        }


        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {

                    aux.Add(x);

                }

                aux.ExceptWith(pecasCapturadas(cor));
            }

            return aux;

        }

        public void colocarNovaPeca(Peca peca, char coluna, int linha)
        {

            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());

            pecas.Add(peca);

        }

        private void colocarPecas()
        {

            colocarNovaPeca(new Torre(tab, Cor.Branca), 'c', 1);

            colocarNovaPeca(new Torre(tab, Cor.Branca), 'c', 2);
            colocarNovaPeca(new Torre(tab, Cor.Branca), 'd', 2);
            colocarNovaPeca(new Torre(tab, Cor.Branca), 'e', 2);
            colocarNovaPeca(new Torre(tab, Cor.Branca), 'e', 1);

            colocarNovaPeca(new Rei(tab, Cor.Branca), 'd', 1);

            colocarNovaPeca(new Torre(tab, Cor.Amarela), 'c', 7);
            colocarNovaPeca(new Torre(tab, Cor.Amarela), 'c', 8);
            colocarNovaPeca(new Torre(tab, Cor.Amarela), 'd', 7);
            colocarNovaPeca(new Torre(tab, Cor.Amarela), 'e', 7);
            colocarNovaPeca(new Torre(tab, Cor.Amarela), 'e', 8);

            colocarNovaPeca(new Rei(tab, Cor.Amarela), 'd', 8);
            
        }


    }
}
