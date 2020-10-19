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
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            xeque = false;

            colocarPecas();

        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();

            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);

            }

            return pecaCapturada;
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);

                throw new TabuleiroException("Você não pode se colocar em xeque!");

            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;

            }

            if (estaEmXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;

            }
            else
            {
                turno++;

                mudaJogador();

            }
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);

            p.decrincrementarQteMovimentos();

            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);

                
            }

            tab.colocarPeca(p, origem);
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

        private Cor adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Amarela;

            }
            else
            {
                return Cor.Branca;

            }

        }

        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;

                }

            }

            return null;

        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);

            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor: " + cor + " no tabuleiro:");

            }

            foreach(Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();


                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;

                }

            }

            return false;
        }

        public bool estaEmXequeMate(Cor cor)
        {
            if(!estaEmXeque(cor))
            {
                return false;
            }

            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();

                for (int i=0; i<tab.linhas; i++)
                {
                    for (int j = 0; j < tab.linhas; j++)
                    {
                        if(mat[i,j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);

                            Peca pecaCapturada = executaMovimento(x.posicao, new Posicao(i, j));

                            bool testeXeque = estaEmXeque(cor);

                            desfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                            {
                                return false;

                            }

                        }

                    }

                }

            }

            return true;
        }

        public void colocarNovaPeca(Peca peca, char coluna, int linha)
        {

            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());

            pecas.Add(peca);

        }

        private void colocarPecas()
        {
            /*Padrão inicial

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
            */

            //Padrão cheque-mate
            colocarNovaPeca(new Torre(tab, Cor.Branca), 'c', 1);
            colocarNovaPeca(new Rei(tab, Cor.Branca), 'd', 1);
            colocarNovaPeca(new Torre(tab, Cor.Branca), 'h', 7);

            colocarNovaPeca(new Rei(tab, Cor.Amarela), 'a', 8);
            colocarNovaPeca(new Torre(tab, Cor.Amarela), 'b', 8);

        }


    }
}
