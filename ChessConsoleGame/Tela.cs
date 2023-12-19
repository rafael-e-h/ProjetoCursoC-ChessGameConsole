using ChessConsoleGame.tabuleiro;
using ChessConsoleGame.xadrez;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessConsoleGame
{
    class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);

            if (!partida.terminada)
            {

                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                    Console.WriteLine("XEQUE!");

            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: !" + partida.jogadorAtual);
            }

        }


        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.WriteLine();
        }


        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto){
                Console.Write(x + " ");
            }
            Console.Write("]");
        }


        public static void imprimirTabuleiro(Tabuleiro tab)
        {
           ConsoleColor color_defaultforeground = System.Console.ForegroundColor;
           ConsoleColor color_defaultbackground = System.Console.BackgroundColor;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = System.ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                   imprimirPeca(tab.peca(i, j));   
                }
                Console.WriteLine();
            }

           Console.BackgroundColor = System.ConsoleColor.DarkGray;
           Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  a b c d e f g h ");

            Console.WriteLine();
            Console.BackgroundColor = color_defaultbackground;
            Console.ForegroundColor = color_defaultforeground;

        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {

            ConsoleColor color_defaultforeground = System.Console.ForegroundColor;
            ConsoleColor color_defaultbackground = System.Console.BackgroundColor;
            ConsoleColor color_can = System.ConsoleColor.Green;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = System.ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        imprimirPeca(tab.peca(i, j), color_can);
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i, j));
                    }
                   
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = System.ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  a b c d e f g h ");
            Console.WriteLine();
            Console.BackgroundColor = color_defaultbackground;
            Console.ForegroundColor = color_defaultforeground;

        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)
            {
               Console.ForegroundColor = ConsoleColor.Black;
               Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write("- ");
            }
            else
            {
                if (peca != null)
                {
                    if (peca.cor == Cor.Branca)
                    {
                       Console.ForegroundColor = ConsoleColor.Black;
                       Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(peca);

                    }
                    else if (peca.cor == Cor.Preta)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                       Console.Write(peca);
                    }
                }
                else
                {
                    Console.BackgroundColor = System.ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ");
                Console.BackgroundColor = System.ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void imprimirPeca(Peca peca, ConsoleColor customColor)
        {

            if (peca == null)
            {    
                if (customColor != null)
                {
                    Console.BackgroundColor = customColor;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write("- ");
            }
            else
            {
                if (peca != null)
                {
                    if (customColor != null)
                    {
                        Console.BackgroundColor = customColor;
                    }
                    else if (peca.cor == Cor.Branca)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (peca.cor == Cor.Preta)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(peca);
                }
                else
                {
                    Console.BackgroundColor = System.ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write(" ");
                Console.BackgroundColor = System.ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

    }
}
