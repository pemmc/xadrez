 
namespace JododeXadrez.tabuleiro
{
    public class Tabuleiro
    {

        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;

            pecas = new Peca[linhas, colunas];

        }

        //como um dos meus atributos PECA é privado
        //para que de fora uma classe o acesse
        //eu criei este método
        public Peca peca(int linha, int coluna)
        {

            return pecas[linha, coluna];
        }
    }
}
