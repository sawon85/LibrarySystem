using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Study._03_Library__최사원
{
    class ExceptionHandling
    {
        public ExceptionHandling() { }


        /*---기본 문자 체크---*/

        public bool BlankCheck(string sentence)
        {
            if (sentence.Trim() == "")
                return true;

            return false;
        }

        public bool SpaceCheck(string sentence)
        {
            Regex blankMatch = new Regex(@"(?=.*[\s]){1}");

            Match match = blankMatch.Match(sentence);

            if (match.Success)
                return true;

            else
                return false;
        }

        public bool EnglishCheck(string sentence)
        {
            Regex englishMatch = new Regex("(?=.*[a-zA-Z]).{1}");

            Match match = englishMatch.Match(sentence);

            if (match.Success)
                return true;

            else
                return false;
        }

        public bool NumberCheck(string sentence)
        {
            Regex numberCheck = new Regex("(?=.*[0-9]).{1}");

            Match match = numberCheck.Match(sentence);

            if (match.Success)
                return true;

            else
                return false;
        }

        public bool SpecialCharacterCheck(string sentence)
        {
            Regex specialCharacterCheck = new Regex(@"(?=.*[-~.,`!@\#$%^&*\()\=+|\\/:;?""<>']).{1}");

            Match match = specialCharacterCheck.Match(sentence);

            if (match.Success)
                return true;

            else
                return false;
        }

        public bool KoreanCheck(string sentence)
        {
            Regex koreanCheck1 = new Regex("(?=.*[ㄱ-ㅎ]).{1}");
            Match match1 = koreanCheck1.Match(sentence);
            Regex koreanCheck2 = new Regex("(?=.*[가-힣]).{1}");
            Match match2 = koreanCheck2.Match(sentence);

            if (match1.Success || match2.Success)
                return true;

            else
                return false;
        }

        public bool StrangeKoreanCheck(string sentence)
        {

            Regex koreanCheck = new Regex("(?=.*[ㄱ-ㅎ]).{1}");

            Match match = koreanCheck.Match(sentence);

            if (match.Success)
                return true;

            else
                return false;
        }

        public bool OnlyNumberCheck(string sentence)
        {
            if (NumberCheck(sentence) && !EnglishCheck(sentence) && !KoreanCheck(sentence) && !SpecialCharacterCheck(sentence) && !SpaceCheck(sentence))
                return true;

            return false;
        }

        public bool IsNormalChar(string character)
        {
            if (NumberCheck(character) || EnglishCheck(character) || KoreanCheck(character) || SpecialCharacterCheck(character) || character == " ")
                return true;

            return false;

        }

        /*---회원가입 정규식--*/

        public bool KoreanName(string name)
        {
            Regex nameMatch = new Regex(@"^[가-힣]{2,4}$");

            Match match = nameMatch.Match(name);

            if (match.Success && name.Length < 5 && !StrangeKoreanCheck(name) && !SpaceCheck(name) && !EnglishCheck(name) && !SpecialCharacterCheck(name))
                return true;

            else
                return false;
        }

        public bool ID(string id)
        {
            Regex idMatch1 = new Regex("(^([a-zA-z])(?=.*[0-9])).{4,10}$");
            Regex idMatch2 = new Regex("^[a-zA-z]{4,10}$");

            Match match1 = idMatch1.Match(id);
            Match match2 = idMatch2.Match(id);

            if ((match1.Success || match2.Success) && id.Length < 11 && !SpecialCharacterCheck(id) && !SpaceCheck(id) && !KoreanCheck(id))
                return true;

            else
                return false;
        }

        public bool Password(string password)  // 8~16 영어, 특수문자 숫자 필수 포함
        {
            Regex passwordMatch1 = new Regex(@"((?=.*[a-zA-Z])(?=.*[0-9])(?=.*[~.,`!-@\#$%^&*\()\=+|\\/:;?""<>']).{8,16})");


            Match match1 = passwordMatch1.Match(password);


            if (match1.Success && EnglishCheck(password) && SpecialCharacterCheck(password) && NumberCheck(password) && !SpaceCheck(password) && !KoreanCheck(password) && password.Length < 16)
                return true;

            else
                return false;
        }

        public bool Phonenumber(string phonenumber)
        {
            Regex phonenumberMatch = new Regex("^01[016789]([0-9]{8})");

            Match match = phonenumberMatch.Match(phonenumber);

            if (match.Success && phonenumber.Length < 12)
                return true;

            else
                return false;
        }

        public bool Address(string address)
        {
            Regex addressMatch = new Regex(@"((?=.*[가-힣])(?=.*\s)(?=.*[0-9]).{8,16})");
            Regex specialCharacterCheck = new Regex(@"(?=.*[~.,`!@\#$%^&*\()\=+|\\/:;?""<>']).{1}");

            Match match = addressMatch.Match(address);
            Match match2 = specialCharacterCheck.Match(address);

            if (match.Success && !EnglishCheck(address) && !match2.Success && !StrangeKoreanCheck(address))
                return true;

            else
                return false;
        }

        public bool Address2(string address)
        {
            Regex addressMatch = new Regex(@"(^[가-힣]+[시도]\s)([가-힣]+[구시군]\s)?([가-힣]+[구시]\s)?([가-힣]+[면읍]\s)?([가-힣]+[동리로길])");

            Match match = addressMatch.Match(address);

            if (match.Success && !EnglishCheck(address))
                return true;

            else
                return false;
        }
        /*---책 데이터 정규식---*/

        public bool BookData(string bookData)
        {

            Regex koreanCheck1 = new Regex("(?=.*[가-힣]).{1}");

            Match match1 = koreanCheck1.Match(bookData);


            if (BlankCheck(bookData))
                return false;

            else if (!EnglishCheck(bookData) && !match1.Success)
                return false;

            else
                return true;
        }

        /*---특정 문자 검색---*/

        public bool Search(string check, string sentence)
        {

            Regex search = new Regex("(?=.*" + check + ").{1}");

            Match match = search.Match(sentence);

            if (match.Success)
                return true;

            else
                return false;
        }

        /*---숫자 입력, 숫자 반환---*/

        public int? Button()
        {
            string button;


            button = Console.ReadLine();

            if (OnlyNumberCheck(button))
            {
                return int.Parse(button);
            }

            return null;

        }

        /*문자 입력 + 종료 이벤트 발생*/

        public string InputString()
        {
            string sentence = "";

            while (true)
            {
                var key = Console.ReadKey();


                if (key.Key == ConsoleKey.Escape)
                    return null;

                else if (IsNormalChar(key.KeyChar.ToString()))
                {

                    sentence = sentence + key.KeyChar.ToString();
                    continue;
                }
                else if (key.Key == ConsoleKey.Enter)
                {

                    return sentence;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    Console.Write(" ");
                    if (sentence != "")
                    {
                        if(KoreanCheck(sentence[sentence.Length-1].ToString()))
                            Console.Write("\b");
                        Console.Write("\b");
                        sentence = sentence.Substring(0, sentence.Length - 1);
                    }
                    continue;
                }

                else
                {
                    Console.Write("\b");
                    Console.Write(" ");
                    Console.Write("\b");

                }    
            }

        }

        public string InputPassword()
        {
            string sentence = "";

            while (true)
            {
                var key = Console.ReadKey();


                if (key.Key == ConsoleKey.Escape)
                    return null;

                else if (IsNormalChar(key.KeyChar.ToString()))
                {

                    Console.Write("\b");
                        if (KoreanCheck(key.KeyChar.ToString()))
                            Console.Write("\b");

                        Console.Write("*");
                    sentence = sentence + key.KeyChar;
                    
                    continue;
                }
                else if (key.Key == ConsoleKey.Enter)
                {

                    return sentence;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    Console.Write(" ");
                    if (sentence != "")
                    {
                        Console.Write("\b");
                        sentence = sentence.Substring(0, sentence.Length - 1);
                    }
                    continue;
                }

                else
                {
                    Console.Write("\b");
                    Console.Write(" ");
                    Console.Write("\b");

                }
            }

        }

        public bool? GetYesOrNo()  //yse가 눌렸는지 no가 눌렸는 지 확인
        {

            string yerOrNo = Console.ReadLine();


            switch (yerOrNo)
            {

                case "Y":
                case "y":
                    return true;

                case "N":
                case "n":
                    return false;

                default:
                    return null;  //입력을 하나라도 받고 그 입력이 y나 n이 아니면 그 입력을 지우기 위해 null값으로 판단을 해준다.

            }
        }

    }
}
