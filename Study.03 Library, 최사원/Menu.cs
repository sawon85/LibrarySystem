using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study._03_Library__최사원
{
    class Menu
    {
        LibrarySystem librarySystem;
        ExceptionHandling exception;

        public Menu()
        {
            Console.CursorVisible = false;
            librarySystem = new LibrarySystem();
            exception = new ExceptionHandling();
        }

        /*--- Login ---*/

        private void LoginUI()
        {

        }

        public void SignInUI()
        {
            string id, password, name, phonenumber, address;

            Console.Write("아이디를 입력하세요:");
            while (true)
            {
                id = Console.ReadLine();
                if (exception.ID(id))
                    break;
                Console.Write("아이디는 영어 (숫자 포함 가능) 4 ~ 10글자, 한글,공백,특수문자는 불가능합니다. ");
            }

            Console.Write("비밀번호를 입력하세요:");
            while (true)
            {
                password = Console.ReadLine();
                if (exception.Password(password))
                    break;
                Console.Write("비밀번호는 영어, 숫자, 특수문자 포함 8 ~ 16글자, 한글 공백 특수문자는 불가능합니다.");
            }

            Console.Write("이름을 입력하세요:");
            while (true)
            {
                name = Console.ReadLine();
                if (exception.KoreanName(name))
                    break;
            }

            Console.Write("핸드폰 번호를 입력하세요:");
            while (true)
            {
                phonenumber = Console.ReadLine();
                if (exception.Phonenumber(phonenumber))
                    break;
            }

            Console.Write("주소를 입력하세요:");
            while (true)
            {
                address = Console.ReadLine();
                if (exception.Address(address))
                    break;
            }

            librarySystem.SignIn(id, password, name, address, phonenumber);
        }

        public void LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("1. 로그인");
                Console.WriteLine("2. 회원가입");

                switch (exception.Button())
                {
                    case Constants.LOGIN:
                        if (librarySystem.Login())
                            UserMenu();
                        break;

                    case Constants.SIGNIN:
                        SignInUI();
                        break;
                }
            }

        }

        /*---USER---*/
        private void UserUI(List<UserVO> userList)
        {
            UserVO user;

            for(int index=1; index<userList.Count;index++)
            {
                user = userList[index];
                Console.WriteLine( index + ".   " + user.ID + user.Phonenumber + user.Address);

            }

            int button = int.Parse(Console.ReadLine());

            WhatBookBorrowed(userList[button]);
        }

        private void WhatBookBorrowed(UserVO user)
        {

            for(int i=0; i<user.BorrowingBooks.Count;i++)
            {
                Console.WriteLine("빌린 책 : " + user.BorrowingBooks[i].book.BookName);
                Console.WriteLine("반납 날짜" + string.Format("{0:yyyy년 MM월 dd일}", user.BorrowingBooks[i].returnDate));
            }
  
        }

        /*---BOOK---*/

        private void BookUI(List<BookVO> bookList, int who)
        {

            BookVO book;

            for (int index = 0; index < bookList.Count; index++)
            {
                book = bookList[index];
                Console.WriteLine(index + 1 + ".   " + book.BookName + book.NumberOfBook + book.Publisher + book.Writer);

            }


            string input = Console.ReadLine();

            switch (input)
            {

                case "1":

                    int button = int.Parse(input);

                    if (who == Constants.USER)
                        User_BookMenu(bookList[button - 1]);

                    else if (who == Constants.ADMINISTRATOR)

                        Administrator_BookMenu(bookList[button - 1]);

                    break;

                default:

                    SearchingBook(librarySystem.BookData,input,who);
                    break;
            }
        }

        private void User_BookMenu(BookVO book)
        {
            DateTime? returnTime = librarySystem.IsBookBorrowed(book);

            if (returnTime!= null)
            {
                Console.WriteLine("반납하기");
                Console.WriteLine(string.Format("{0:yyyy년 MM월 dd일}",returnTime) + "까지 반납하셔야 됩니다.");
                librarySystem.ReturnBook(book);
            }

            else if (librarySystem.CanBorrowMore(book))
            {
                Console.WriteLine("대출하기");
                librarySystem.BorrowBook(book);
                Console.WriteLine("반납 날짜는 " + DateTime.Now.AddDays(14).ToLongDateString() + "입니다");
            }

            else if(!librarySystem.DoesUserCanBorrow())
            {
                Console.WriteLine("대여 가능한 권 수를 보두 대여 하셨기 때문에 대여할 수 없습니다.");
            }

            else // 경우의 수는 책이 하나도 남지 않았을 때 뿐이다.
            {
                Console.WriteLine("현재 남은 재고가 없기 때문에 대여하실 수 없습니다.");
            }

        }

        private void SearchingBook(List<BookVO> bookData,string check, int who)
        {
            List<BookVO> bookSearched = new List<BookVO>();

            foreach (BookVO book in bookData)
            {
                if (exception.Search(check, book.BookName))
                    bookSearched.Add(book);
            }

            BookUI(bookSearched, who);
        }

        private void Administrator_BookMenu(BookVO book)
        {
            Console.WriteLine("1. 책 개수 수정");
            Console.WriteLine("2. 책 삭제");

            switch (exception.Button())
            {
                case Constants.UPDATE_BOOK_COUNT:
                    UpdateNumberOfBook(book);
                        break;
                    

                case Constants.DELETE_BOOK :
                    {
                        if (book.NumberOfLoans > 0)
                        {
                            Console.WriteLine("대여중인 책이 있습니다. 반납이 모두 완료된 후 삭제해 주십시오.");
                            return;
                        }

                        librarySystem.DeleteBook(book);

                        break;
                    }
            }
        }

        private void NewBook()
        {

            string name, publisher, writer, numberOfBooks;

            Console.WriteLine("책 제목을 입력해 주세요 :");

            while (true)
            {
                name = Console.ReadLine();
                if (!exception.BlankCheck(name))
                    break;
            }

            while (true)
            {
                publisher = Console.ReadLine();
                if (!exception.BlankCheck(name))
                    break;
            }

            while (true)
            {
                writer = Console.ReadLine();
                if (!exception.BlankCheck(writer))
                    break;
            }
            while (true)
            {
                numberOfBooks = Console.ReadLine();
                if (exception.OnlyNumberCheck(numberOfBooks))
                    break;
            }

            librarySystem.NewBook(name, publisher, writer, int.Parse(numberOfBooks));

        }

        private void UpdateNumberOfBook(BookVO book)
        {
            Console.WriteLine("책 개수를 수정합니다. 현재 전체" + (book.NumberOfBook + book.NumberOfLoans) + "권 있습니다.");

            int numberOfBooks;

            while (true)
            {
                numberOfBooks = exception.Button();

                if (numberOfBooks >= book.NumberOfLoans)
                    break;

                Console.WriteLine("빌려간 책이" + book.NumberOfLoans + "개 있습니다. 이 보다 크게 적어주세요");
            }

            librarySystem.UpdateNumberOfBook(book, numberOfBooks);

        }

        private void myBook()
        {

            foreach(borrowingBook myBookData in  librarySystem.MyBook())
            {
                Console.Write(myBookData.book.BookName + " : ");
                Console.WriteLine(string.Format("{0:yyyy년 MM월 dd일}", myBookData.returnDate) + "까지 반납하셔야 됩니다.");

            }

        }

        /*--------------------------USER--------------------------*/

        private void UserMenu()
        {
            while (true)
            {
                
                Console.WriteLine("1. 책 목록");
                Console.WriteLine("2. 내가 빌린 책");
                Console.WriteLine("3. 정보 수정");
                Console.WriteLine("4. 관리자 모드");
                Console.WriteLine("5. 로그 아웃");
                Console.WriteLine("6. 회원 탈퇴"); 

                switch (exception.Button())
                {
                    case Constants.BOOKS:
                        BookUI(librarySystem.BookData,Constants.USER);
                        break;

                    case Constants.MYBOOKS :
                        myBook();
                        break;

                    case Constants.USER_SETTING:
                        break;

                    case Constants.ADMINISTRATOR_MODE:
                        if (librarySystem.IntoAdministratorMode())
                            AdministratorMenu();
                        break;

                    case Constants.LOGOUT:
                        librarySystem.Logout();
                        return;

                    case Constants.WITHDRAWAL:
                        if (librarySystem.Withdrawal())
                            return;
                        else
                            break;

                }
            }
        }

        /*--Administrator---*/

        private void AdministratorMenu()

        {
            while (true)
            {

                Console.WriteLine("1. 책 관리");
                Console.WriteLine("2. 회원 관리");
                Console.WriteLine("4. 유저 모드");

                switch (exception.Button())
                {
                    case Constants.BOOK_SETTING:
                        BookUI(librarySystem.BookData,Constants.ADMINISTRATOR);
                        break;

                    case Constants.ALL_OF_USERS:
                        UserUI(librarySystem.UserData);
                        break;

                    case Constants.BOOK_BORROWED:
                        break;

                    case Constants.USER_MODE:
                        return;

                }
            }
        }
    }
}
