using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Study._03_Library__최사원
{
    class SawonIntro
    {
        public SawonIntro() { }
        public void PrintWelcome()
        {
            string text = System.IO.File.ReadAllText(@"txt\Welcome.txt", Encoding.Default);
            Console.Write(text);
  
        }

        public void PrintLibrary()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string text = System.IO.File.ReadAllText(@"txt\Library.txt", Encoding.Default);
            Console.Write(text);
            Console.ResetColor();

        }

        public void Intro()
        {
            int start_X = 0;
            int start_Y = 0;

            for(int i=0;i<19;i++)
            {
                Console.SetWindowSize(63, 7+ i);
                Console.Clear();
                Console.SetCursorPosition(start_X, start_Y+i);
                PrintWelcome();
                Thread.Sleep(20); 
            }

            Console.SetCursorPosition(start_X, 3);
            PrintLibrary();

            Thread.Sleep(200);

            Console.SetWindowSize(63, 19);

            Console.SetCursorPosition(23, 17);


            Console.Write("<< E N T E R >>");
            

            Console.Read();

        }

    }
}
