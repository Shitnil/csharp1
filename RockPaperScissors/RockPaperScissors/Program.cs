using System;

namespace RockPaperScissors
{
    internal class Program
    {
        static int GetInput(string msg, int min, int max)
        {
            Console.WriteLine(msg);
            string inp = Console.ReadLine();
            int i;
            bool result = Int32.TryParse(inp, out i);
            Console.Write("> ");
            if (result){
                if (i > 4 || i < 1)
                {
                    Console.Error.WriteLine(i + " is not in the range of the function");
                    return GetInput(msg, min, max);
                }
                else
                {
                    return i;
                }
            }
            else
            {
                Console.Error.WriteLine(inp + " is not a number");
                return (GetInput(msg, min, max));
            } 
        }
        enum Move
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        };

        static int GetWinner(Move p1, Move p2)
        {
            int win;
            if ((p1==Move.Rock && p2==Move.Scissors) || (p1==Move.Paper && p2==Move.Rock) || (p1==Move.Scissors && p2==Move.Paper))
                win = 1;
            else if (p1==p2)
                win = 0;
            else
                win= 2;
            return win;
        }

        static void DisplayWinner(int res, string p1,string p2)
        {
            if (res == 0)
                Console.WriteLine("It's a Draw!");
            else if (res == 1)
                Console.WriteLine(p1);
            else
                Console.WriteLine(p2);
        }

        static void PrintString(string txt, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(txt);
        }

        static string StringReverse(string s, bool reverse)
        {
            string r = "";
            
            if (!reverse)
            {
                return s;
            }
            int n = s.Length-1;
            while (n >= 0)
            {
                if (s[n] == '(')
                    r += ')';    
                else if (s[n] == ')')
                    r += '(';
                else
                    r += s[n];
                n--;
            }
            return r;
        }

        static void PrintRock(int x, int y, bool reverse)
        {
            PrintString(StringReverse("     _______         ",reverse), x, y);
            PrintString(StringReverse("---'    ____)        ",reverse), x, y + 1);
            PrintString(StringReverse("      (_____)        ",reverse), x, y + 2);
            PrintString(StringReverse("      (_____)        ",reverse), x, y + 3);
            PrintString(StringReverse("      (____)         ",reverse), x, y + 4);
            PrintString(StringReverse("---.__(___)          ",reverse), x, y + 5);
        }
        static void PrintPaper(int x, int y, bool reverse)
        {
            PrintString(StringReverse("     _______         ",reverse), x, y);
            PrintString(StringReverse("---'     ___)_____   ",reverse), x, y + 1);
            PrintString(StringReverse("          ________)  ",reverse), x, y + 2);
            PrintString(StringReverse("          _________) ",reverse), x, y + 3);
            PrintString(StringReverse("         ________)   ",reverse), x, y + 4);
            PrintString(StringReverse("---.__________)      ",reverse), x, y + 5);
        }
        static void PrintScissors(int x, int y, bool reverse)
        {
            PrintString(StringReverse("     _______         ",reverse), x, y);
            PrintString(StringReverse("---'    ____)_____   ",reverse), x, y + 1);
            PrintString(StringReverse("          ________)  ",reverse), x, y + 2);
            PrintString(StringReverse("       ____________) ",reverse), x, y + 3);
            PrintString(StringReverse("      (____)         ",reverse), x, y + 4);
            PrintString(StringReverse("---.__(___)          ",reverse), x, y + 5);
        }

        static void PrintMove(Move m, int x, int y, bool reverse)
        {
            if (m==Move.Rock)
                PrintRock(x, y, reverse);
            else if (m == Move.Paper)
                PrintPaper(x, y, reverse);
            else
                PrintScissors(x, y, reverse);           
        }

        static void PlayAgainstHuman()
        {
            while (true)
            {
                
                Console.WriteLine("Player 1's Turn:");
                int pm1 = GetInput("Rock 1 | Paper 2 | Scissors 3 | Quit 4", 1, 4);
                if (pm1 == 4)
                    break;
                Console.WriteLine("Player 2's Turn:");
                int pm2 = GetInput("Rock 1 | Paper 2 | Scissors 3 | Quit 4", 1, 4);
                if (pm2 == 4)
                    break;
                Console.Clear();
                Move m1 = (Move) pm1;
                Move m2 = (Move) pm2;
                DisplayWinner(GetWinner(m1, m2), "Player 1 is the winner", "Player 2 is the winner");
                Console.WriteLine();
                PrintMove(m1,2,2, false);
                PrintString("VS",25, 5);
                PrintMove(m2,28, 2,true);
            }
        }

        static Move GetAiMove()
        {
            Random rand = new Random();
            return (Move) rand.Next(1, 4);
        }

        static void PlayAgainstAi()
        {
            while (true)
            {   
                Console.WriteLine("Player 1's Turn:");
                int pm1 = GetInput("Rock 1 | Paper 2 | Scissors 3 | Quit 4", 1, 4);
                if (pm1 == 4)
                    break;
                int ai = (int) GetAiMove();                
                if (ai == 4)
                    break;
                Console.Clear();
                Move m1 = (Move) pm1;
                Move m2 = (Move) ai;
                DisplayWinner(GetWinner(m1, m2), "You won!", "You lost to an AI?");
                Console.WriteLine();
                PrintMove(m1,2,2, false);
                PrintString("VS",25, 5);
                PrintMove(m2,28, 2,true);
            }
        }
    }
}