using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Study._03_Library__최사원
{
    class Program
    {

        static void Main(string[] args)
        {
            SawonIntro sawon = new SawonIntro();
           sawon.Intro();

            
            Menu ui = new Menu();
            ui.IntroMenu();
            
        }
    }
}
