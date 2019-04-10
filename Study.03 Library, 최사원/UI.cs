using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Study._03_Library__최사원
{
    class UI
    {
        public UI()
        { }

         void Alert(string warning)
        {


        }

        public string Half2Full(string sHalf)

        {

            char[] ch = sHalf.ToCharArray(0, sHalf.Length);

            for (int i = 0; i < sHalf.Length; ++i)

            {

                if (ch[i] > 0x21 && ch[i] <= 0x7e)

                    ch[i] += (char)0xfee0;

                else if (ch[i] == 0x20)

                    ch[i] = (char)0x3000;

            }

            return (new string(ch));

        }



        private string PrintOfLine(string sentence, int maximumLengthOfLine)
        {
            if (sentence.Length > maximumLengthOfLine)
            {
                Console.Write(" | " + sentence.Substring(0, maximumLengthOfLine) + " | ");
                return sentence.Substring(maximumLengthOfLine);

            }

            else
            {
                /*오른쪽 정렬을 위해 출력할 이름 앞에 공백이 반각문자이기 때문에 출력 횟수를 2배 해줘야 한다.*/
                // 계산
                // 출력해야할 공백 = (최대 출력할 문자 - 출력할 문자) *2 + 출력할 문자
                //

                int length = maximumLengthOfLine * 2 - sentence.Length;
                Console.Write(" | "+ String.Format("{0," + length + "}", sentence) + " | ");
                return "";
            }
        }

        public void SearchingBookUI()
        {
            string text = System.IO.File.ReadAllText(@"txt\Searching.txt", Encoding.Default); // 저장된 txt에서 game ui를 가져와 출력
            Console.WriteLine("{0}", text);
        }

        public void BookUI(string index ="", string bookName = "", string publisher = "", string writer ="", string numberOfBooks ="")
        {
            Console.WriteLine();

            if (bookName != "" || publisher != "" || writer != "" || numberOfBooks != "")

            BookUI(PrintOfLine(index, Constants.INDEX_LENGTH_OF_LINE),
                PrintOfLine(bookName, Constants.NAME_LENGTH_OF_LINE),
                PrintOfLine(publisher,Constants.PUBLISHER_LENGTH_OF_LINE),
                PrintOfLine(writer, Constants.WRITER_LENGTH_OF_LINE),
                PrintOfLine(numberOfBooks,Constants.NUMBER_LENGTH_OF_LINE)
                );

        }

        public void Alert(string warning, string warning2 = "")
        {
            string text = System.IO.File.ReadAllText(@"txt\Alert.txt", Encoding.Default); 
            Console.WriteLine("{0}", text);
            Console.SetCursorPosition(Constants.ALERT_X_FRAME, Constants.ALERT_Y_FRAME);
            Console.WriteLine(warning);
            if (warning2 != "")
            {
                Console.SetCursorPosition(Constants.ALERT_X_FRAME+10, Constants.ALERT_Y_FRAME + 1);
                Console.WriteLine(warning2);
            }

        }

        public void IntroUI()
        {
            Console.Clear();
            Console.SetWindowSize(42, 24);
            string text = System.IO.File.ReadAllText(@"txt\Intro.txt", Encoding.Default);
            Console.Write("{0}", text);
        }

        public void LoginUI()
        {
            Console.Clear();
            Console.SetWindowSize(42, 24);
            string text = System.IO.File.ReadAllText(@"txt\Login.txt", Encoding.Default);
            Console.Write("{0}", text);
        }


    }
} 
