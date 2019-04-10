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
        int userCount = 0;
        int bookCount = 0;


        public LibrarySystem()
        {
            bookData = new List<BookVO>();
            userData = new List<UserVO>();
            loginUser = null;

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
            SetPersonData("dddddd", "dddddddd", "유진", "양천구 목동", "01044444444");
            SetPersonData("dddddd", "dddddddd", "김수정", "  ", "01044444444");
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
            SetBookData("해리포터", "SK", "JK.롤링", 30);
            SetBookData("고요할수록 밝아지는 것들", "수오서재", "혜민 스님", 30);
            SetBookData("나는 나로 살기로 했다(100쇄 기념 스페셜 에디션)(양장본 HardCover)", "마음의숲", "김수현", 30);
            SetBookData("곰돌이 푸, 행복한 일은 매일 있어(한정판 벚꽃 에디션)(양장본 HardCover) ", "일에이치코리아", "곰돌이 푸 (원작)", 30);
            SetBookData("해커스 토익 기출 보카(TOEIC VOCA)(2019)(5판) ", "해커스어학연구소", "David Cho", 30);
        }


        /*---User--*/

        public void SignIn(string id, string password, string name, string address, string phonenumber)
        {

            int userCode = ++userCount;

            UserVO newperson = new UserVO(userCode, id, password, name, address, phonenumber);

            userData.Add(newperson);
        }


        private bool PasswordChecking(UserVO user, string inputPassword)
        {

            if (user.Password==inputPassword)
            {
                loginUser = user;
                Console.WriteLine("login");
                return true;
            }

            return false;
        }

        public bool Login(string inputID, string inputPassword)
        {

            foreach (UserVO user in userData)
            {
                if (user.ID == inputID)
                    return PasswordChecking(user, inputPassword);
            }

            return false;
        }

        public void Logout()
        {
            loginUser = null;

        }

        public bool Withdrawal()
        {
            if (loginUser.Code == Constants.ADMINISTRATOR)
            {
                Console.WriteLine("관리자는 탈퇴하실 수 없습니다.");
                return false;
            }
            if (loginUser.BorrowingBooks.Count > 0)
            {
                Console.WriteLine("책을 모두 반납하신 후에 이용하세요.");
                return false;
            }

            userData.Remove(loginUser);
            loginUser = null;

            return true;
        }

        public virtual bool BorrowingBook(BookVO book)
        {

            if (CanBorrowMore(book))
            {
                borrowingBook newBook;
                newBook.book = book;
                Console.WriteLine(newBook.book.BookName);
                newBook.returnDate = DateTime.Now.AddDays(14);
                loginUser.BorrowingBooks.Add(newBook);
                return true;
            }

            return false;
        }

        public void ReturnBook(BookVO bookReturned)
        {
            foreach (borrowingBook book in loginUser.BorrowingBooks)
            {
                if (bookReturned == book.book)
                {
                    loginUser.BorrowingBooks.Remove(book);
                    return;
                }

            }
        }

        public DateTime? IsBorrowedAlready(BookVO checkingBook)
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

        public bool DoesUserCanBorrow()
        {
            if (loginUser.BorrowingBooks.Count == loginUser.NumberOfMax)
                return false;

            return true;
        }

        public bool CanBorrowMore(BookVO book)
        {
            if (DoesUserCanBorrow() && IsBookEnough(book))
                return true;

            return false;
        }


        /*BOOK*/

        public void BorrowBook(BookVO book)
        {
                 BorrowingBook(book);
                book.NumberOfLoans++;
            book.NumberOfBook--;
          
        }

        public DateTime? IsBookBorrowed(BookVO book)
        {
            return IsBorrowedAlready(book);

        }

        public bool IsBookEnough(BookVO book)
        {
            if (book.NumberOfBook==0)
                return false;

            return true;
        }

  
        public List<borrowingBook> MyBook()
        {
            return loginUser.BorrowingBooks;
        }


        public void UpdateNumberOfBook(BookVO book,int numberOfBook)
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

        public bool IntoAdministratorMode()
        {
            if (loginUser.Code == 0)
                return true;

            else
                return false;

        }

        public void NewBook(string name, string publisher, string writer, int numberOfBooks)
        {

            BookVO newBook = new BookVO(++bookCount, name,publisher,writer,numberOfBooks);

            bookData.Add(newBook);
        }

      public void DeleteBook(BookVO book)
        {

            bookData.Remove(book);
        }

    }
}
