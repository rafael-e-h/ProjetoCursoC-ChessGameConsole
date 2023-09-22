using ChessConsoleGame.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsoleGame
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = System.ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        imprimirPeca(null, "- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = System.ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h ");
            

        }

        public static void imprimirPeca(Peca peca, string outro = "")
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
                    //ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(peca);

                    //Console.ForegroundColor = aux;
                }
            }
            else
            {
                Console.BackgroundColor = System.ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Gray;
                if (outro != "")
                {
                    Console.Write(outro);
                }
            }
            Console.BackgroundColor = System.ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
