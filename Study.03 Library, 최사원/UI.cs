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

        public void DeleteReadLine(int length)
        {
            for (int i = 0; i < length; i++)
                Console.Write(" ");

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
            Console.Clear();
            Console.SetWindowSize(56, 15);
            string text = System.IO.File.ReadAllText(@"txt\Searching.txt", Encoding.Default);
            Console.WriteLine("{0}", text);

            Console.SetCursorPosition(Constants.SEARCHING_BOOK_INPUT_X, Constants.SEARCHING_BOOK_INPUT_Y);
            Console.Write("책 검색 (q : 뒤로가기) : ");

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


        public void MyBookUI(string index = "", string bookName = "", string returnDate = "")
        {

            Console.WriteLine();

            if (bookName != "" || returnDate != "" )

                BookUI(PrintOfLine(index, Constants.INDEX_LENGTH_OF_LINE),
                    PrintOfLine(bookName, Constants.NAME_LENGTH_OF_LINE),
                    PrintOfLine(returnDate, 30)
           
                    );

        }




        public void Alert(string warning, string warning2 = "", string warning3 = "")
        {
            Console.Clear();
            string text = System.IO.File.ReadAllText(@"txt\Alert.txt", Encoding.Default); 
            Console.WriteLine("{0}", text);
            Console.SetCursorPosition(Constants.ALERT_X_FRAME, Constants.ALERT_Y_FRAME);
            Console.Write(warning);
            if (warning2 != "")
            {
                Console.SetCursorPosition(Constants.ALERT_X_FRAME, Constants.ALERT_Y_FRAME + 1);
                Console.Write(warning2);

            }


            if (warning3 != "")
            {

                Console.SetCursorPosition(Constants.ALERT_X_FRAME, Constants.ALERT_Y_FRAME + 2);
                Console.Write(warning3);

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
            Console.SetWindowSize(79, 16);
            string text = System.IO.File.ReadAllText(@"txt\Login.txt", Encoding.Default);
            Console.Write("{0}", text);
        }

        public void UserMenuUI()
        {
            Console.Clear();
            Console.SetWindowSize(34, 32);
            string text = System.IO.File.ReadAllText(@"txt\UserMenu.txt", Encoding.Default);
            Console.Write("{0}", text);
        }

        public void AdministratorMenuUI()
        {
            Console.Clear();
            Console.SetWindowSize(34, 32);
            string text = System.IO.File.ReadAllText(@"txt\AdministratorMenu.txt", Encoding.Default);
            Console.Write("{0}", text);
        }

        public void BookMenuUI()
        {
            Console.Clear();
            Console.SetWindowSize(34, 32);
            string text = System.IO.File.ReadAllText(@"txt\BookSetting.txt", Encoding.Default);
            Console.Write("{0}", text);
        }


    }
} 
