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

                 else if (ch[i] == '!')  //느낌표 전각문자 변환이 되질 않아서 
                        ch[i] = '！';

            }

            return (new string(ch));

        }


        /*---길이 제한 만큼 출력 하기.---*/

        private string PrintOfLine(string sentence, int maximumLengthOfLine)
        {
            if (sentence.Length > maximumLengthOfLine)  // 최대 길이보다 출력해야할 문자열이 더 길면
            {
                Console.Write(" | " + sentence.Substring(0, maximumLengthOfLine) + " | "); //출력하고
                return sentence.Substring(maximumLengthOfLine); //출력못한 길이 반환.
            
            }

            else
            {
                /*오른쪽 정렬을 위해 string 앞에 출력할 공백이 반각문자이기 때문에 출력 횟수를 2배 해줘야 한다.*/
                // 계산
                // 출력해야할 공백 = (한줄에 출력할 최대 길이 - 출력할 문자) *2 
                // 전체 string.length = 출력해야할 공백 + 출력할 문자

                int length = maximumLengthOfLine * 2 - sentence.Length;
                Console.Write(" | "+ String.Format("{0," + length + "}", sentence) + " | "); // 오른쪽 정렬 STRING출력 후
                return ""; // 남은 출력 없음 반환.
            }
        }

        /*---------- UI ---------*/


        public void SearchingBookUI() //  책 찾기 
        {
            Console.Clear();
            Console.SetWindowSize(56, 15);
            string text = System.IO.File.ReadAllText(@"txt\Searching.txt", Encoding.Default);
            Console.WriteLine("{0}", text);

            Console.SetCursorPosition(Constants.SEARCHING_BOOK_INPUT_X, Constants.SEARCHING_BOOK_INPUT_Y);
            Console.Write("책 검 색 (0 : 뒤로가기) : ");

        }

        public void SearchingUserUI() // 유저 검색 
        {
            Console.Clear();
            Console.SetWindowSize(56, 15);
            string text = System.IO.File.ReadAllText(@"txt\SearchingUser.txt", Encoding.Default);
            Console.WriteLine("{0}", text);

            Console.SetCursorPosition(Constants.SEARCHING_BOOK_INPUT_X, Constants.SEARCHING_BOOK_INPUT_Y);
            Console.Write("유 저 검 색 (0 : 뒤로가기) : ");

        }


        public void BookUI(string index ="", string bookName = "", string publisher = "", string writer ="", string numberOfBooks ="")
        {

            Console.WriteLine();

            if (bookName != "" || publisher != "" || writer != "" || numberOfBooks != "")

            BookUI(PrintOfLine(index, Constants.INDEX_LENGTH_OF_LINE),
                   PrintOfLine(bookName, Constants.NAME_LENGTH_OF_LINE),
                   PrintOfLine(publisher,Constants.PUBLISHER_LENGTH_OF_LINE),
                   PrintOfLine(writer, Constants.WRITER_LENGTH_OF_LINE),
                   PrintOfLine(numberOfBooks,Constants.NUMBER_LENGTH_OF_LINE));

        }

        
        public void UserUI(string index = "",string userID = "", string userName = "", string userPhonenumber = "", string userAddress = "", string numberOfBooksBoorow = "") // 책 출력 UI
        {

            Console.WriteLine();

            if (userID!="" || userName != "" || userPhonenumber != "" || userAddress != "" || numberOfBooksBoorow != "")

                UserUI(PrintOfLine(index,Constants.INDEX_LENGTH_OF_LINE),
                    PrintOfLine(userID, Constants.USERID_LENGTH_OF_LINE),
                       PrintOfLine(userName, Constants.USERNAME_LENGTH_OF_LINE),
                       PrintOfLine(userPhonenumber, Constants.PHONENUMBER_LENGTH_OF_LINE),
                       PrintOfLine(userAddress, Constants.ADDRESS_LENGTH_OF_LINE),
                       PrintOfLine(numberOfBooksBoorow, Constants.NUMBEROFBOOKS_OF_LINE));

        }


        public void MyBookUI(string index = "", string bookName = "", string returnDate = "") // 내가 빌린 책 UI
        {

            Console.WriteLine();

            if (bookName != "" || returnDate != "" )

                BookUI(PrintOfLine(index, Constants.INDEX_LENGTH_OF_LINE),
                    PrintOfLine(bookName, Constants.NAME_LENGTH_OF_LINE),
                    PrintOfLine(returnDate, 30)
           
                    );

        }

        public void Alert(string warning, string warning2 = "", string warning3 = "") // 사용자 알림 ui. 최대 3줄의 안내를 제공한다.
        {
            
            Console.Clear();
            Console.SetWindowSize(73, 17);

            string text = System.IO.File.ReadAllText(@"txt\Alert.txt", Encoding.Default);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}", text);
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Constants.ALERT_X_FRAME, Constants.ALERT_Y_FRAME);
            Console.Write(warning);


            if (warning2 != "")
            {
                Console.SetCursorPosition(Constants.ALERT_X_FRAME, Constants.ALERT_Y_FRAME + 4);
                Console.Write(warning2);

            }

            if (warning3 != "")
            {

                Console.SetCursorPosition(Constants.ALERT_X_FRAME, Constants.ALERT_Y_FRAME + 8);
                Console.Write(warning3);

            }

        }


        /* 저장해 놓은 UI 배경 불러오기 + 출력*/

        public void IntroUI()
        {
            Console.Clear();
            Console.SetWindowSize(64, 27);
            string text = System.IO.File.ReadAllText(@"txt\Intro2.txt", Encoding.Default);
            Console.Write("{0}", text);
        }

        public void LoginUI()
        {
            Console.Clear();
            Console.SetWindowSize(77, 26);
            string text = System.IO.File.ReadAllText(@"txt\Login.txt", Encoding.Default);
            Console.Write("{0}", text);
        }

        public void UserMenuUI()
        {
            Console.Clear();
            Console.SetWindowSize(34, 37);
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

        public void UserSettingUI()
        {
            Console.Clear();
            Console.SetWindowSize(32, 35);
            string text = System.IO.File.ReadAllText(@"txt\UserSetting.txt", Encoding.Default);
            Console.Write("{0}", text);
        }

        public void DataUI() 
        {
            Console.Clear();
            Console.SetWindowSize(73, 25);
            string text = System.IO.File.ReadAllText(@"txt\SingInUI.txt", Encoding.Default);
            Console.Write("{0}", text);
        }


        /* 가이드 까지 출력해 줄 GETDATA UI함수*/
        public void DataUIWithGuide(string inputGuide,
                                       string guideForEnglish ="",
                                       string guideForKorean ="",
                                       string guideForNumber ="",
                                       string guideForSpecicalCharacter ="",
                                       string guideForBlank = "",
                                       string specialGuide = ""
                                       )
        {
            DataUI();

            Console.SetCursorPosition(0, Constants.SIGNIN_FRAME_Y +2);

            if (guideForEnglish != "")
                PrintGuideline("영어 : ", guideForEnglish);

            if (guideForKorean != "")
                PrintGuideline("한국어 : ", guideForKorean);

            if (guideForNumber != "")
                PrintGuideline("숫자 : ", guideForNumber);

            if (guideForSpecicalCharacter != "")
                PrintGuideline("특수문자 : ", guideForSpecicalCharacter);

            if (guideForBlank != "")
                PrintGuideline("공백 : ", guideForBlank);

            if (specialGuide!= "")
                PrintGuideline("\n", specialGuide);

            Console.SetCursorPosition(0, Constants.SIGNIN_FRAME_Y);
            Console.Write(inputGuide + " : ");
        }

        void PrintGuideline(string thisCharacter, string conditon)
       {
            Console.Write("\n\n");
            Console.Write(" {0} ", thisCharacter);
            Console.ForegroundColor = ConsoleColor.Red;  // 조건은 빨간색으로 출력할 예정.
            Console.Write(conditon);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
} 
