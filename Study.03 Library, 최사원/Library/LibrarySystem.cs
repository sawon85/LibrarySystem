using System;
using System.Collections.Generic;


namespace Study._03_Library__최사원
{
    class LibrarySystem
    {

        List<BookVO> bookData;
        List<UserVO> userData;
        UserVO loginUser;
        UI ui;
        int userCount = 0;
        int bookCount = 0;


        public LibrarySystem()
        {
            bookData = new List<BookVO>();
            userData = new List<UserVO>();
            loginUser = null;
            ui = new UI();

            SaveAdministratorData();
            InitPeopleData();
            InitBookData();
        }

        /*---사전 데이터---*/

        private void SaveAdministratorData()
        {
            UserVO administrator = new UserVO(0);
            userData.Add(administrator);
        }

        private void SetPersonData(string id, string password, string name, string address, string phonenumber)
        {
            UserVO person = new UserVO(++userCount, id, password, name, address, phonenumber);
            userData.Add(person);

        }

        private void InitPeopleData()
        {
           
            SetPersonData("aaaaaa", "aaaaaabb", "김영진", "인천광역시 논현동", "01011111111");
            SetPersonData("bbbbbb", "bbbbbbbb", "김도훈", "경기도 부천시", "01022222222");
            SetPersonData("cccccc", "cccccccc", "김성엽", "서울특별시 건대 언저리", "01033333333");
            SetPersonData("ffffff", "ffffffff", "짱구", "짱구집", "01066666666");
            SetPersonData("gggggg", "gggggggg", "김예진", "세종대 기숙사", "0107777777");
            SetPersonData("hhhhhh", "hhhhhhhh", "해리포터", "호그와트", "01088888888");
            SetPersonData("iiiiii", "iiiiiiii", "유진", "서울 신도림 언저리", "01099999999");
            SetPersonData("jjjjjj", "jjjjjjjj", "김수정", "경기도 양평구", "01010101010");
        }

        private void SetBookData(string bookName, string publisher, string writer, int numberOfBook)
        {
            BookVO book = new BookVO(++bookCount, bookName, publisher, writer, numberOfBook);
            bookData.Add(book);
        }

        private void InitBookData()
        {
            SetBookData("컴퓨터 시스템 구조론", "삼성", "김원일", 30);
            SetBookData("알고리즘 및 실습", "LG", "국형준", 20);
            SetBookData("세종대에서 살아남기", "신구", "세종냥이", 1);
            SetBookData("해리포터", "SK", "JK.롤링", 0);
            SetBookData("고요할수록 밝아지는 것들", "수오서재", "혜민 스님", 25);
            SetBookData("나는 나로 살기로 했다(100쇄 기념 스페셜 에디션)(양장본 HardCover)", "마음의숲", "김수현", 28);
            SetBookData("곰돌이 푸, 행복한 일은 매일 있어(한정판 벚꽃 에디션)(양장본 HardCover) ", "일에이치코리아", "곰돌이 푸 (원작)", 30);
            SetBookData("해커스 토익 기출 보카(TOEIC VOCA)(2019)(5판) ", "해커스어학연구소", "David Cho", 0);
            SetBookData("OpenCV 4로 배우는 컴퓨터 비전과 머신 러닝) ", "길벗", "황선규", 1);
            SetBookData("Adventures of Sherlock Homes (Oxford World Classics)(New Jacket)", "Oxford University Press, USA", "Doyle, Arthur Conan ", 1);
            SetBookData("마법천자문. 44: 죄를 씻어 내라! 목욕할 욕", "아울북", "김현수", 9);
            SetBookData("죽고 싶지만 떡볶이는 먹고 싶어", "흔", "백세희", 2);
            SetBookData("나미야 잡화점의 기적(양장본 HardCover)", "현대문학","하가시노 게이고", 1);
            SetBookData("Who? Special 손흥민(아시안 게임 금메달 기념 한정판)(양장본 HardCover)","다산어린이", "강진희", 3);
            SetBookData("나는 나로 살기로 했다(100쇄 기념 스페셜 에디션)(양장본 HardCover)", "마음의숲", "김수현", 4);
            SetBookData("꽃을 보듯 너를 본다(30만부 기념 스페셜 에디션)(J.H CLASSIC 2)(양장본 HardCover)", "지혜", "나태주", 11);
            SetBookData("이기적 유전자 (40주년 기념판)", "을유문화사", "리처드 도킨스", 8);
            SetBookData("지적 대화를 위한 넓고 얕은 지식: 현실너머 편", "한빛비즈", "채사장", 1);
            SetBookData("가면산장 살인사건(양장본 HardCover)","재인", "히가시노 게이고", 3);
            SetBookData("약간의 거리를 둔다(한정판 고양이 에디션)", "책읽는고양이", "고노 아야코", 0);
            SetBookData("왜 나는 너를 사랑하는가(개정판)", "청미래", "알랭 드 보통", 11);
            SetBookData("빨강머리 앤이 하는 말", "아르테(arte)", "백영옥", 8);
            SetBookData("보통의 존재", "달", "이석원", 20);
            SetBookData("어쩌면 별들이 너의 슬픔을 가져갈지도 몰라(한정 스페셜 에디션)(감성치유 라이팅북)", "예담", "강용택(엮음)", 2);
            SetBookData("서랍에 저녁을 넣어 두었다", "문학과지성사", "한강", 1);
            SetBookData("사랑하라 한번도 상처받지 않은 것처럼", "류시화", "오래된미래", 15);
            SetBookData("딸아, 외로울 때는 시를 읽으렴", "걷는나무", "신현림(엮음)", 2);
            SetBookData("석가의 해부학 노트(모든 그림 그리는 이들을 위한)", "성안당", "석정현", 1);
            SetBookData("마법의 디자인", "우듬지", "사카모토 신지", 2);
            SetBookData("아몬드(양장본 HardCover)", "창비", "송원평", 1);
            SetBookData("파도가 바다의 일이라면", "문학동네", "김연수", 0);
            SetBookData("위저드 베이커리", "창비", "구병모", 8);
            SetBookData("사서함 110호의 우편물", "시공사", "이도우",1);
            SetBookData("살인자의 기억법", "문학동네", "김영하", 2);
            SetBookData("피프티 피플", "창비", "정세랑", 2);
            SetBookData("난장이가 쏘아 올린 작은 공", "이성과힘", "조세희", 1);
            SetBookData("나는 나를 파괴할 권리가 있다(3판)", "문학동네", "김영하", 2);
            SetBookData("추리 천재 엉덩이 탐정. 1: 보라 부인의 암호 사건(양장본 HardCover)", "아이세움", "트롤", 2);
            SetBookData("설민석의 한국사 대모험. 1", "아이휴먼", "설민석", 2);
            SetBookData("나의 라임오렌지나무(초등학생을 위한)","동녘주니어", "J. M. 바스콘셀로스", 2);
            SetBookData("이기적 유전자(40주년 기념판)", "리처드 도킨스", "을유문화사", 13);
            SetBookData("정재승의 과학 콘서트(개정증보판)", "어크로스", "정재승", 3);
            SetBookData("아내를 모자로 착각한 남자(개정판)(양장본 HardCover)", "알마", "올이버 색스", 5);
            SetBookData("페르마의 마지막 정리(개정판)(갈릴레오 총서 3)(양장본 HardCover)", "영람카디널", "사이먼 싱", 12);
            SetBookData("우리 본성의 선한 천사(사이언스 클래식 24)(양장본 HardCover)", "사이언스북스", "스티븐 핑거", 12);
            SetBookData("どうしても嫌いな人 す-ちゃんの決心", "幻冬舍", "益田ミリ／[著]", 3);
            SetBookData("ソロモンの僞證 第3部[上卷]", "新潮社", "宮部みゆき／著", 1);
            SetBookData("騎士團長殺し 第２部 遷ろうメタファ-編 ", "村上春樹", "宮部みゆき／著", 1);
            SetBookData("Charlie und die Schokoladenfabrik", "Rowohlt", "Dahl, Roald", 3);
            SetBookData("The Philosophy of Snoopy", "Canongate Books", "Schulz, Charles M", 4);
            SetBookData("SCHRITTE INTERNATIONAL 3: DEUTSCH ALS FREMDSPRACHE KURSBUCH + ARBEITSBUCH MIT AUDIO-CD ZUM ARBEITSB", "Hueber", "Silke Hilpert  ", 23);
            SetBookData("Le Petit Nicolas", "Gallimard", "Goscinny, Rene", 3);

        }
        
        /*---User--*/

        public bool IsAlreadyUsedID(string inputID) //사용하고 있는 아이
        {
            foreach (UserVO user in userData)
            {
                if (user.ID == inputID)
                {
                    return true;
                }
            }

            return false;
        }
        public void SignIn(string id, string password, string name, string address, string phonenumber)
        {

            int userCode = ++userCount;

            UserVO newperson = new UserVO(userCode, id, password, name, address, phonenumber);

            userData.Add(newperson);
        }


        private bool PasswordChecking(UserVO user, string inputPassword)
        {

            if (user.Password == inputPassword)
            {
                loginUser = user;
                Console.WriteLine("login");
                return true;
            }

            return false;
        }


        public bool Login(string inputID, string inputPassword) //로그인 
        {

            foreach (UserVO user in userData)
            {
                if (user.ID == inputID)
                    return PasswordChecking(user, inputPassword);  //비밀번호 체크
            }

            return false;
        }

        public void Logout()
        {
            loginUser = null;

        }

        public bool Withdrawal()  //회원탈퇴
        {
            if (loginUser.Code == Constants.ADMINISTRATOR)
            {
                ui.Alert("관리자는 탈퇴하실 수 없습니다.","","<<ENTER>>");  //팝업
                Console.Read();
                return false;
            }
            if (loginUser.BorrowingBooks.Count > 0)
            {
                ui.Alert("책을 모두 반납하신 후에 이용하세요.","","<<ENTER>>");
                Console.Read();
                return false;
            }

            userData.Remove(loginUser);
            loginUser = null;

            return true;
        }

        public virtual bool BorrowingBook(BookVO book) //책 빌리는 중
        {

            if (CanBorrowMore(book))
            {
                borrowingBook newBook;
                newBook.book = book;
                newBook.returnDate = DateTime.Now.AddDays(14);
                loginUser.BorrowingBooks.Add(newBook);
                return true;
            }

            return false;
        }

        public void ReturnBook(BookVO bookReturned)  //책 반납
        {
            foreach (borrowingBook book in loginUser.BorrowingBooks)
            {
                if (bookReturned == book.book)
                {
                    loginUser.BorrowingBooks.Remove(book);
                    bookReturned.NumberOfBook++;
                    bookReturned.NumberOfLoans--;
                    return;
                }

            }
        }

        public DateTime? IsBorrowedAlready(BookVO checkingBook)  //동일 책을 이미 빌렸었나요
        {

            foreach (borrowingBook book in loginUser.BorrowingBooks)
            {
                if (checkingBook == book.book)
                {
                    return book.returnDate;
                }
            }

            return null;
        }

        public bool DoesUserCanBorrow()  //유저는 책 빌릴 수 있는 지
        {
            if (loginUser.BorrowingBooks.Count == loginUser.NumberOfMax)
                return false;

            return true;
        }

        public bool CanBorrowMore(BookVO book)  // 책이 충분하고 유저도 책을 빌릴 수 있는 가.
        {
            if (DoesUserCanBorrow() && IsBookEnough(book))
                return true;

            return false;
        }

        public void PrintMyData()  //내 데이터 추가
        {
            Console.Clear();
            Console.SetWindowSize(37, 15);
            

            Console.WriteLine("\n 아이디 : {0} \n", loginUser.ID);

            Console.WriteLine(" 이름 : {0} \n",loginUser.Name);

            Console.WriteLine(" 전화번호 : {0} \n" ,loginUser.Phonenumber);

            Console.WriteLine(" 주소 : \n  {0} \n \n \n ", loginUser.Address);

            Console.WriteLine("<<<<<<<<<<<< Enter >>>>>>>>>>>>>>>");


            Console.Read();
            return;
        }

        public void UserSetting(string password = "", string phonenumber = "", string address = "") //유저 정보 변경
        {
            if(password!="")
            loginUser.Password = password;

            else if (phonenumber != "")
                loginUser.Phonenumber = phonenumber;

            else if (address != "")
                loginUser.Address = address;

        }

        /*BOOK*/

        public void BorrowBook(BookVO book)  // 책이 빌려지면
        {
            BorrowingBook(book);
            book.NumberOfLoans++;
            book.NumberOfBook--;

        }

        public DateTime? IsBookBorrowed(BookVO book) // 이 유저는 책을 빌렸었는가
        {
            return IsBorrowedAlready(book);

        }

        public bool IsBookEnough(BookVO book)  //책이 지금 충분히 있는가.
        {
            if (book.NumberOfBook == 0)
                return false;

            return true;
        }


        public List<borrowingBook> MyBook()
        {
            return loginUser.BorrowingBooks;  //책을 빌리기
        }


        public void UpdateNumberOfBook(BookVO book, int numberOfBook)  // 책 수량 변경
        {
            book.NumberOfBook = numberOfBook; 
        }

        /*AdministratorMode*/

        public List<BookVO> BookData 
        {
            get
            {
                return bookData;
            }
        }

        public List<UserVO> UserData
        {
            get
            {
                return userData;
            }
        }

        public bool IntoAdministratorMode() //관리자 모드로 진입하기 위해 
        {
            if (loginUser.Code == 0)
                return true;

            else
                return false;

        }

        public void NewBook(string name, string publisher, string writer, int numberOfBooks)
        {

            BookVO newBook = new BookVO(++bookCount, name, publisher, writer, numberOfBooks);

            bookData.Add(newBook);
        }

        public void DeleteBook(BookVO book)
        {

            bookData.Remove(book);
        }

    }
}
