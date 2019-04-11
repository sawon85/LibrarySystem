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
        UI ui;

        public Menu()
        {
            Console.CursorVisible = false;
            librarySystem = new LibrarySystem();
            exception = new ExceptionHandling();
            ui = new UI();
        }

        /*--- Login ---*/

 
        public void SignIn()
        {
            

            string id, password, name, phonenumber, address;
        
            while (true)
            {
                ui.SignInUIWithGuide("아이디는 영어 (숫자 포함 가능) 4 ~ 10글자, 한글,공백,특수문자는 불가. ",
                    "사용할 아이디를 입력하세요 : "
                    );
          
                id = Console.ReadLine();
                if (librarySystem.IsAlreadyUsedID(id))
                    continue;
                else if (exception.ID(id))
                    break;

            }

            while (true)
            {
                ui.SignInUIWithGuide("비밀번호는 영어, 숫자, 특수문자 포함 8 ~ 16글자, 한글, 공백 불가. ",
                    "사용할 비밀번호를 입력하세요 : "
                    );

                password = Console.ReadLine();
                if (exception.Password(password))
                    break;

            }

            while (true)
            {
                ui.SignInUIWithGuide("",
                    "비밀번호를 다시 입력하세요 :  "
                    );

                string password2 = Console.ReadLine();

                if (password == password2)
                    break;
               
            }


            while (true)
            {
                ui.SignInUIWithGuide("이름은 한글 2~5 글자. 영어, 공백, 특수문자는 불가. ",
                    "이름을 입력하세요 : "
                    );
                name = Console.ReadLine();
                if (exception.KoreanName(name))
                    break;
            }

            while (true)
            {
                ui.SignInUIWithGuide("휴대폰 번호는 01000000000형식으로 입력하세요. ",
                       "휴대폰 번호 입력 : "
                       );
                phonenumber = Console.ReadLine();
                if (exception.Phonenumber(phonenumber))
                    break;
            }

  
            while (true)
            {
                ui.SignInUIWithGuide("주소를 입력하세요. 영어 입력 불가",
                       "주소 입력 : "
                       );
                Console.WriteLine();
                address = Console.ReadLine();
                if (exception.Address(address))
                    break;
            }

            librarySystem.SignIn(id, password, name, address, phonenumber);
        }

        public void IntroMenu()
        {
            
            while (true)
            {

                ui.IntroUI();
                switch (exception.Button())
                {
                    case Constants.LOGIN:
                        if (Login())
                            UserMenu();
                        else
                        ui.Alert("로그인에 실패하셨습니다,.");
                        Console.Read();
                        break;
                        

                    case Constants.SIGNIN:
                        SignIn();
                        break;
                }
            }

        }

        public bool Login()
        {
            ui.LoginUI();

            Console.Write("아이디를 입력하세요:");
            string inputID = Console.ReadLine();
            Console.Write("비밀번호를 입력하세요:");
            string inputPassword = Console.ReadLine();

            return librarySystem.Login(inputID, inputPassword);
        }

        /*---USER---*/
        private void ShowUsers(List<UserVO> userList)
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

        private void ShowBooks(List<BookVO> bookList, int who)
        {

            while (true)
            {
                Console.Clear();
                Console.SetWindowSize(137, 48);

                BookVO book;
                ui.BookUI("", ui.Half2Full("책 이름"), ui.Half2Full("출판사"), ui.Half2Full("작가"), ui.Half2Full("남은 책"));
                Console.WriteLine();


                for (int index = 0; index < bookList.Count; index++)
                {
                    book = bookList[index];

                    ui.BookUI(ui.Half2Full((index + 1).ToString()), ui.Half2Full(book.BookName), ui.Half2Full(book.Publisher), ui.Half2Full(book.Writer), ui.Half2Full(book.NumberOfBook.ToString()));
                    // Console.WriteLine(index + 1 + ".   " + book.BookName + book.NumberOfBook + book.Publisher + book.Writer);

                }

                if(who==Constants.USER)
                     Console.Write(" \n\n   대출이나 반납을 원하시는 책 번호를 입력하세요 (q버튼 : 뒤로가기) : ");
                else
                    Console.Write(" \n\n   수량 수정이나 책 삭제를 원하는 책 번호를 입력하세요. (q버튼 : 뒤로가기) : ");

                string input = Console.ReadLine();

                if (exception.OnlyNumberCheck(input))
                {

                    int index = int.Parse(input) - 1;

                    if (index >= 0 && index < bookList.Count)
                    {
                        BookMenu(bookList[index], who);
                        return;
                    }


                }

                else if (input == "q")
                    return;
            }
        }

        void BookMenu(BookVO book, int who)
        {
            if(who == Constants.USER)
                User_BookMenu(book);
            else if(who==Constants.ADMINISTRATOR)
             Administrator_BookMenu(book);

        }

        private bool? GetYesOrNo()
        {

            string yerOrNo = Console.ReadLine();

            
            switch(yerOrNo)
            {

                case "Y":
                case "y":
                    return true;

                case "N":
                case "n":
                    return false;

                default:
                    return null;

            }
        }

        private bool DoesReturn(BookVO book, DateTime? returnTime)
        {
            while (true)
            {
                ui.Alert("반납하기",
                   string.Format("{0:yyyy년 MM월 dd일}", returnTime) + "까지 반납하셔야 됩니다.",
                   "반납하시겠습니까 (Y/N)?"
                   );

                switch (GetYesOrNo())
                {

                    case true: return true;
                    case false: return false;
                    case null: break;

                }
            }
        }

        private bool DoesBorrow(BookVO book)
        {
            while (true)
            {
                ui.Alert("대출하기",
                  "",
                   "대출하시겠습니까 (Y/N)?"
                   );

                switch (GetYesOrNo())
                {

                    case true: return true;
                    case false: return false;
                    case null: break;

                }
            }
        }

        private void User_BookMenu(BookVO book)
        {
            DateTime? returnTime = librarySystem.IsBookBorrowed(book);


            if (returnTime!= null)
            {
                if (DoesReturn(book, returnTime))
                {
                    librarySystem.ReturnBook(book);

                }
      
            }

            else if (librarySystem.CanBorrowMore(book))
            {
                if (DoesBorrow(book))
                {
                    ui.Alert(book.BookName,"반납 날짜는 " + DateTime.Now.AddDays(14).ToLongDateString() + "입니다");
                    librarySystem.BorrowBook(book);
 
                }
            }

            else if(!librarySystem.DoesUserCanBorrow())
            {
                ui.Alert("대여 가능한 권 수를 보두 대여 하셨기 때문에 대여할 수 없습니다.");
                Console.Read();
            }

            else // 경우의 수는 책이 하나도 남지 않았을 때 뿐이다.
            {
                ui.Alert("현재 남은 재고가 없기 때문에 대여하실 수 없습니다.");
                Console.Read();
            }

            return;
        }

        private void SearchingBook(List<BookVO> bookData,int who)
        {
            List<BookVO> bookIsSearched = new List<BookVO>();
            
            while (true)
            {
                ui.SearchingBookUI();
                bookIsSearched.Clear();

                string check = Console.ReadLine();

                if (check == "q")
                    return;

                foreach (BookVO book in bookData)
                {
                    if (exception.Search(check, book.BookName))
                        bookIsSearched.Add(book);
                }

                ShowBooks(bookIsSearched, who);
            }
        }

        private void Administrator_BookMenu(BookVO book)
        {

            while (true)
            {

                ui.BookMenuUI();

                switch (exception.Button())
                {
                    case Constants.UPDATE_BOOK_COUNT:
                        {
                            UpdateNumberOfBook(book);
                            return;
                        }

                    case Constants.DELETE_BOOK:
                        {
                            if (book.NumberOfLoans > 0)
                            {
                                Console.WriteLine("대여중인 책이 있습니다. 반납이 모두 완료된 후 삭제해 주십시오.");
                                return;
                            }

                            librarySystem.DeleteBook(book);
                            ui.Alert("성공적으로 삭제 되었습니다.");
                            Console.Read();
                            return;
                        }

                    case Constants.BACK:
                        return;

                    case null: continue;
                }
            }
        }

        private void NewBook()
        {
            Console.Clear();

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

            int numberOfBooks;
            int? button;

            while (true)
            {
                ui.Alert("책 개수를 수정합니다.", "현재 전체" + (book.NumberOfBook + book.NumberOfLoans) + "권 있습니다.", "입력 : ");

                button = exception.Button();

                if (button == null) continue;

                numberOfBooks = int.Parse(button.ToString());

                if (numberOfBooks >= book.NumberOfLoans)
                    break;

                ui.Alert("빌려간 책이" + book.NumberOfLoans + "개 있습니다. 이 보다 크게 적어주세요");
                Console.Read();
            }

            librarySystem.UpdateNumberOfBook(book, numberOfBooks);

        }

        private void MyBook()
        {
            Console.Clear();

            if(librarySystem.MyBook().Count==0)
            {
                ui.Alert("현재 빌린 책이 없습니다.");
                Console.Read();
                return;
            }


            Console.WriteLine("\n < < < 현재 내가 빌린 책 > > > \n\n");

            int index = 1;

            foreach(borrowingBook myBookData in  librarySystem.MyBook())
            {
                Console.Write(myBookData.book.BookName + " : ");
              
                ui.MyBookUI(ui.Half2Full(index.ToString()), ui.Half2Full(myBookData.book.BookName), ui.Half2Full(string.Format("{0:yyyy년 MM월 dd일}", myBookData.returnDate) + "까지 반납하셔야 됩니다."));
                Console.WriteLine();
                index++;
            }

            Console.Write(" \n\n  반납을 원하시는 책 번호를 입력하세요 (q버튼 : 뒤로가기) : ");

            string input = Console.ReadLine();

            index = 0;
            
            if (exception.OnlyNumberCheck(input))
            {

                index = int.Parse(input) - 1;

                if (index >= 0 && index < librarySystem.MyBook().Count)
                {
                    User_BookMenu(librarySystem.MyBook()[index].book);
                    MyBook();
                    return;
                }

            }

            else if (input == "q")
                return;
        }
    

        /*--------------------------USER--------------------------*/

        private void UserMenu()
        {
            while (true)
            {
                ui.UserMenuUI();

                switch (exception.Button())
                {
                    case Constants.BOOKS:
                        ShowBooks(librarySystem.BookData,Constants.USER);
                        break;

                    case Constants.SEARCHING_BOOK:
                        SearchingBook(librarySystem.BookData,Constants.USER);
                        break;

                    case Constants.MYBOOKS :
                        MyBook();
                        break;

                    case Constants.USER_SETTING:
                        break;

                    case Constants.ADMINISTRATOR_MODE:
                        if (librarySystem.IntoAdministratorMode())
                            AdministratorMenu();
                        break;

                    case Constants.LOGOUT:
                        {
                            librarySystem.Logout();
                            return;
                        }

                    case Constants.WITHDRAWAL:
                        {
                            if (librarySystem.Withdrawal())
                                return;

                            else
                                break;
                        }

                    case null: continue;

                }
                
            }
        }

        /*--Administrator---*/

        private void AdministratorMenu()

        {
            while (true)
            {
                ui.AdministratorMenuUI();

                switch (exception.Button())
                {
                    case Constants.BOOK_SETTING:
                        ShowBooks(librarySystem.BookData, Constants.ADMINISTRATOR);
                        break;

                    case Constants.NEW_BOOK:
                        NewBook();
                        break;

                    case Constants.ALL_OF_USERS:
                        break;

                    case Constants.USER_MODE:
                        return;

                    case null:
                        continue;

                }
            }
        }   
    }
}
