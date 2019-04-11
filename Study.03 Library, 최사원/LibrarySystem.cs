using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            UI ui = new UI();

            SaveAdministratorData();
            SavePeopleData();
            SaveBooksData();
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

        private void SavePeopleData()
        {
           
            SetPersonData("aaaaaa", "aaaaaabb", "김영진", "인천광역시 논현동", "01011111111");
            SetPersonData("bbbbbb", "bbbbbbbb", "김도훈", "경기도 부천시", "01022222222");
            SetPersonData("cccccc", "cccccccc", "김성엽", "서울특별시 건대 언저리", "01033333333");
            SetPersonData("ffffff", "ffffffff", "짱구", "짱구집", "01066666666");
            SetPersonData("gggggg", "gggggggg", "김예진", "세종대 기숙사", "0107777777");
            SetPersonData("gggggg", "gggggggg", "해리포터", "호그와트", "0107777777");
        }

        private void SetBookData(string bookName, string publisher, string writer, int numberOfBook)
        {
            BookVO book = new BookVO(++bookCount, bookName, publisher, writer, numberOfBook);
            bookData.Add(book);
        }

        private void SaveBooksData()
        {
            SetBookData("컴퓨터 시스템 구조론", "삼성", "김원일", 30);
            SetBookData("알고리즘 및 실습", "LG", "국형준", 20);
            SetBookData("세종대에서 살아남기", "신구", "세종냥이", 30);
            SetBookData("해리포터", "SK", "JK.롤링", 0);
            SetBookData("고요할수록 밝아지는 것들", "수오서재", "혜민 스님", 30);
            SetBookData("나는 나로 살기로 했다(100쇄 기념 스페셜 에디션)(양장본 HardCover)", "마음의숲", "김수현", 30);
            SetBookData("곰돌이 푸, 행복한 일은 매일 있어(한정판 벚꽃 에디션)(양장본 HardCover) ", "일에이치코리아", "곰돌이 푸 (원작)", 30);
            SetBookData("해커스 토익 기출 보카(TOEIC VOCA)(2019)(5판) ", "해커스어학연구소", "David Cho", 30);
            SetBookData("OpenCV 4로 배우는 컴퓨터 비전과 머신 러닝) ", "길벗", "황선규", 1);
            SetBookData("Adventures of Sherlock Homes (Oxford World Classics)(New Jacket)", "Oxford University Press, USA", "Doyle, Arthur Conan ", 1);
        }


        /*---User--*/

        public bool IsAlreadyUsedID(string inputID) //사용하고 있는 아이디
        {
            foreach (UserVO user in userData)
            {
                if (user.ID == inputID)
                    return true;
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
                ui.Alert("관리자는 탈퇴하실 수 없습니다.",warning3: "<<ENTER>>");  //팝업
                Console.Read();
                return false;
            }
            if (loginUser.BorrowingBooks.Count > 0)
            {
                ui.Alert("책을 모두 반납하신 후에 이용하세요.", warning3: "<<ENTER>>");
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
