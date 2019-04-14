using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Study._03_Library__최사원
{
    class Menu
    {
        LibrarySystem librarySystem;
        ExceptionHandling exception;
        UI ui;

        public Menu()
        {
            Console.CursorVisible = true;
            librarySystem = new LibrarySystem();
            exception = new ExceptionHandling();
            ui = new UI();
        }

        /*--- Login ---*/

        private void AlertOfCantUse()
        {
            ui.Alert("조건을 숙지하고 다시 입력해주세요", "다시 입력해!", "<<< E N T E R >>>");
                Console.Read();
        }


        public void SetID(out string id)   //유저 회원가입을 위해 아이디를 입력받는 함수 
        {
            while (true)
            {
                ui.DataUIWithGuide("사용할 아이디를 입력하세요",
                    guideForEnglish:"필수 포함",
                    guideForKorean:"불가",
                    guideForNumber:"첫 글자 불가, 영어와 함께 사용 가능",
                    guideForSpecicalCharacter:"불가",
                    guideForBlank : "불가",
                    specialGuide : "다른 유저와 이름이 겹치면 사용 불가, 4~10글자 사용가능"
                    );

                id = exception.InputString();

                if (id == null)
                    return;

                if (librarySystem.IsAlreadyUsedID(id))  //사용하고 있는 아이디면 다시 입력받기
                {
                    ui.Alert("다른 유저가 사용중인 아이디 입니다.", warning3: "<<Enter>>");
                    Console.Read();
                    continue;
                }

                else if (exception.ID(id))
                    break;

                AlertOfCantUse();
            }
        }

        public void SetPassword(out string password)  //유저 회원가입을 위해 비밀번호를 입력받는 함수
        {
            while (true)
            {
                ui.DataUIWithGuide("비밀번호는 영어, 숫자, 특수문자 포함 8 ~ 16글자, 한글, 공백 불가. ",
                    "사용할 비밀번호를 입력하세요 : "
                    );
                ui.DataUIWithGuide("사용할 비밀번호를 입력하세요",
                    guideForEnglish:"필수",
                    guideForKorean:"불가",
                    guideForBlank:"불가",
                    guideForNumber:"필수",
                    guideForSpecicalCharacter:"필수",
                    specialGuide:"8~16글자 사용 가능"
                    );

                password = exception.InputPassword();
                if (password == null)
                    return;

                if (!exception.Password(password))
                {
                    AlertOfCantUse();
                    continue;
                }

                ui.DataUIWithGuide("비밀번호를 한 번 더 입력하세요");

                string password2 = exception.InputPassword();
                if (password2 == null)
                {
                    password = null;
                    return;
                }

                else if (password == password2)
                    return;

                else
                {
                    ui.Alert("비밀번호가 일치하지 않습니다.", "다시 입력해!", "<< E N T E R>>");
                    Console.Read();
                }
            }


        }

        public void SetName(out string name)  //회원가입 이름을 입력받는 함수
        {
            while (true)
            {
         
                ui.DataUIWithGuide("이름을 입력하세요",
                    guideForKorean : "자음 모음이 결합된 한글만 사용가능",
                    specialGuide:"3~5글자 사용가능"
                    );

                name = exception.InputString();
                
                if (name == null)
                    return;

                if (exception.KoreanName(name))
                    break;

                AlertOfCantUse();
            }

        }

        public void SetPhonenumber(out string phonenumber) //핸드폰 번호를 입력받는 함수
        {
            while (true)
            {
                ui.DataUIWithGuide("핸드폰 번호를 입력하세요",
                    guideForNumber:"숫자만 사용가능",
                    specialGuide:"01000000000형식으로 입력하세요."
                    );
                phonenumber = exception.InputString();

                if (phonenumber == null)
                    return;

                if (exception.Phonenumber(phonenumber))
                    break;

                AlertOfCantUse();
            }
        }

        public void SetAddress(out string address) //회원가입 주소를 입력받는 함수
        {
            while (true)
            {
                ui.DataUIWithGuide("주소를 입력하세요 : ",
                       guideForEnglish: "불가",
                       guideForSpecicalCharacter : " '-' 만 사용가능",
                       guideForNumber: "필수",
                       specialGuide:"OO시 OO구 OO동 111-11 형식으로 입력 하세요."
                       );

                Console.WriteLine();

                address = exception.InputString();

                if (address == null)
                    return;

                if (exception.Address2(address) && exception.Address(address))
                    break;

                AlertOfCantUse();
            }
        }

        public void SignIn()
        {

            string id, password, name, phonenumber, address;

            SetID(out id);
            if (id == null) return;

            SetPassword(out password);
            if (password == null) return;

            SetName(out name);
            if (name == null) return;

            SetPhonenumber(out phonenumber);
            if (phonenumber == null) return;

            SetAddress(out address);
            if (address == null) return;

            librarySystem.SignIn(id, password, name, address, phonenumber);  //저장

            ui.Alert("회원가입이 완료 되었습니다.", "waiting....");  //회원가입이 되었다는 표시 0.5초 
            Thread.Sleep(500);

        }

        public void IntroMenu()
        {

            while (true)
            {

                ui.IntroUI();
                switch (exception.Button())
                {
                    case Constants.LOGIN:
                        Login();
                        break;

                    case Constants.SIGNIN:
                        SignIn();
                        break;
                }
            }

        }

        private void Login()
        {
            switch (GetIdAndPassword())
            {
                case true: UserMenu();
                    break;

                case false:

                    ui.Alert("로그인에 실패하셨습니다,.", warning3: "<<Enter>>");  //로그인 실패 시에 완료
                    Console.Read();  //엔터 누르면 삭제
                    return;

                case null:
                    return;
            }
        }


        public bool? GetIdAndPassword()
        {
            ui.LoginUI();

            Console.SetCursorPosition(26,16);   //아이디 입력받는 위치
            string inputID = exception.InputString();
            if (inputID == null) return null;

            Console.SetCursorPosition(29,18);    //비밀번호 입력받는 위치
            string inputPassword = exception.InputPassword();
            if (inputPassword == null) return null;

            return librarySystem.Login(inputID, inputPassword); //로그인이 가능한지 데이터를 비교해서 library함수에서 BOOL형을 반환
        }

        /*---USER---*/

        /*---BOOK---*/

        private void ShowBooks(List<BookVO> bookList, int who)  // 책을 출력하는 함수
        {

            while (true)
            {
                Console.Clear();
                Console.SetWindowSize(137, 48);

                BookVO book;
                ui.BookUI("", ui.Half2Full("책 이름"), ui.Half2Full("출판사"), ui.Half2Full("작가"), ui.Half2Full("남은 책"));  //맨 위에 출력할 정보 출력
                Console.WriteLine();


                for (int index = 0; index < bookList.Count; index++)
                {
                    book = bookList[index];

                    //책 데이터에서 모든 책을 하나 하나 출력

                    ui.BookUI(ui.Half2Full((index + 1).ToString()), ui.Half2Full(book.BookName), ui.Half2Full(book.Publisher), ui.Half2Full(book.Writer), ui.Half2Full(book.NumberOfBook.ToString()));
                    // Console.WriteLine(index + 1 + ".   " + book.BookName + book.NumberOfBook + book.Publisher + book.Writer);

                }

                if (who == Constants.USER)  //유저모드라면 
                    Console.Write(" \n\n   대출이나 반납을 원하시는 책 번호를 입력하세요 ( 0 : 뒤로가기) : ");

                else  //관리자 모드라면
                    Console.Write(" \n\n   수량 수정이나 책 삭제를 원하는 책 번호를 입력하세요. ( 0 : 뒤로가기) : ");

                string input = Console.ReadLine();


                if (input == Constants.EXIT)
                    return;

                else if (exception.OnlyNumberCheck(input))
                {

                    int index = int.Parse(input) - 1;

                    if (index >= 0 && index < bookList.Count)
                    {
                        BookMenu(bookList[index], who);  //입력받는 값이 책 번호 범위내에 있으면 북 메뉴로 넘어간다.
                        return;

                    }
                }

            }
        }

        void BookMenu(BookVO book, int who)
        {
            if (who == Constants.USER)  // 유저 모드 북메뉴로 진입
                User_BookMenu(book);

            else if (who == Constants.ADMINISTRATOR) //관리자용 북 메뉴로 진입.
                Administrator_BookMenu(book);

        }

        private bool DoesReturn(BookVO book, DateTime? returnTime)  
        {
            while (true)
            {
                ui.Alert("반납하기",
                   string.Format("{0:yyyy년 MM월 dd일}", returnTime) + "까지 반납하셔야 됩니다.",
                   "반납하시겠습니까 (Y/N)?"
                   );   //반납 팝업 출력

                switch (exception.GetYesOrNo())
                {

                    case true: return true;
                    case false: return false;
                    case null: break; //null이면 다시 화면 재조정

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
                   );  //대출 팝업 출력

                switch (exception.GetYesOrNo())
                {

                    case true: return true;
                    case false: return false;
                    case null: break;

                }
            }
        }

        private void User_BookMenu(BookVO book)
        {
            DateTime? returnTime = librarySystem.IsBookBorrowed(book);  //유저가 책을 빌렸었나요?


            if (returnTime != null)  // 반납날짜가 초기화 되었다. -> 빌린 상태이다.
            {
                if (DoesReturn(book, returnTime))  // 반납할거야?
                {
                    librarySystem.ReturnBook(book);  //반납~

                }

            }

            else if (librarySystem.CanBorrowMore(book))    //한 사람이 대여할 수 있는 책 최대 2권 (관리자는 3권) 모두 사용했는가?, 재고가 있는 가?
            {
                if (DoesBorrow(book))  //대여가능, 대여할거야?
                {
                    ui.Alert(book.BookName, "반납 날짜는 " + DateTime.Now.AddDays(14).ToLongDateString() + "입니다"); // 대여날짜 팝업
                    librarySystem.BorrowBook(book); // 책을 빌렸다는 데이터 초기화

                }
            }

            else if (!librarySystem.DoesUserCanBorrow())  // 사용자가 대여할 수 있는 여유가 있음
            {
                ui.Alert("대여 가능한 권 수를 모두 대여 하셨기 때문에 대여할 수 없습니다.", warning3: "<<Enter>>");
                Console.Read();
            }

            else // 마지막 경우의 수는 책이 하나도 남지 않았을 때 뿐이다.
            {
                ui.Alert("현재 남은 재고가 없기 때문에 대여하실 수 없습니다.",warning3:"<<Enter>>");
                Console.Read();
            }

            return;
        }

        private void SearchingBook(List<BookVO> bookData, int who) // 책 검색하기
        {
            List<BookVO> bookIsSearched = new List<BookVO>();  //와일문 밖으로 빼서 선언 후 생성.

            while (true)
            {
                ui.SearchingBookUI();  //출력 초기화
                bookIsSearched.Clear(); // 리스트 초기화

                string check = Console.ReadLine(); //검색할 단어

                if (check == Constants.EXIT) //함수 종료
                    return;

                foreach (BookVO book in bookData)  
                {
                    if (exception.Search(check, book.BookName)|| exception.Search(check, book.Publisher)|| exception.Search(check, book.Writer)) // 검색할 단어 모든 책 제목에서 검색 -> 정규식 사용
                        bookIsSearched.Add(book);   // 책 제목에 포함이 되면 리스트에 추가
                }

                ShowBooks(bookIsSearched, who); // 이 리스트를 이용해 Showbook을 재 사용.
            }
        }



        private void Administrator_BookMenu(BookVO book) // 관리자 bookmenu
        {

            while (true)
            {

                ui.BookMenuUI();

                switch (exception.Button()) 
                {
                    case Constants.UPDATE_BOOK_COUNT: //책 권 수 초기화
                        {
                            UpdateNumberOfBook(book);
                            return;
                        }

                    case Constants.DELETE_BOOK:  //책 삭제
                        {
                            if (book.NumberOfLoans > 0)  // 누군가 빌려갔다면 삭제 불가
                            {
                                ui.Alert("대여중인 책이 있습니다. 반납이 모두 완료된 후 삭제해 주십시오.",warning3:"<<Enter>>"); //팝업
                                Console.Read();
                                return;
                            }

                            librarySystem.DeleteBook(book);
                            ui.Alert("성공적으로 삭제 되었습니다.", warning3: "<<Enter>>"); //삭제
                            Console.Read();
                            return;
                        }

                    case Constants.ADMINISTRATOR_BACK: //함수 종료
                        return;

                    case null: continue; //제대로된 입력값이 아니면 다시 출력 초기화
                }
            }
        }

        private void GetBookData(out string bookData, string Guide)  //책 데이터 입력 받기 책 데이터 예외는 그렇게 까다롭지 않기 때문에
        {

            
            while (true)
            {
           
                bookData = "";


                ui.DataUIWithGuide(Guide,
                    guideForSpecicalCharacter: "특수문자만 사용 불가",
                    guideForBlank: "공백만 사용 불가",
                    guideForNumber: "숫자만 사용 불가"
                    );

                bookData = exception.InputString();

                if (bookData == null)
                    return;

                if (exception.BookData(bookData))
                    return;

                AlertOfCantUse();

            }

        }

        private void NewBook()
        {
            Console.Clear();

            string name, publisher, writer;
            int numberOfBooks;

            GetBookData(out name, "책 이름을 입력하세요");
            if (name == null) return;

            GetBookData(out publisher, "출판사를 입력하세요");
            if (publisher == null) return;

            GetBookData(out writer, "작가를 입력하세요");
            if (publisher == null) return;

            while (true)
            {
                ui.DataUIWithGuide("책 수량을 입력하세요", guideForNumber : "숫자만 입력 가능합니다.");

                string number = exception.InputString();

                if (number == null)
                    return;

                if (!exception.OnlyNumberCheck(number))
                    continue;

                else if (int.Parse(number) < 0)
                {
                    ui.Alert("책 수량은 0 보다 크게 입력해 주세요.", "<<< E N T E R >>>");
                    Console.Read();
                }

                else
                {
                    numberOfBooks = int.Parse(number);
                    break;
                }
            }

            librarySystem.NewBook(name, publisher, writer, numberOfBooks);  // 책 데이터 추가
            ui.Alert("책이 추가 되었습니다.\n\n 책 이름 :" + name + "\n 작가 : " + writer + "\n 출판사 : " + publisher
                + "\n수량 : " + numberOfBooks ,warning3: "\n <<< E N T E R >>>");
            Console.Read();
        }

        private void UpdateNumberOfBook(BookVO book)  //책 수량 업데이트
        {

            int numberOfBooks;
            int? button;

            while (true)
            {
                ui.Alert("책 개수를 수정합니다.", "현재 전체" + (book.NumberOfBook + book.NumberOfLoans) + "권 있습니다.", "입력 : "); //빌려간 권 수까지 팝업 출력

                button = exception.Button();

                if (button == null) continue;

                numberOfBooks = int.Parse(button.ToString());

                if (numberOfBooks >= book.NumberOfLoans) // 대여해준 권 수 보다 크거나 같으면 성공.
                    break;

                ui.Alert("빌려간 책이" + book.NumberOfLoans + "개 있습니다. 이 보다 크게 적어주세요",warning3:"<<Enter>>"); // 아니라면 이보다 크게 적도록.
                Console.Read();
            }

            librarySystem.UpdateNumberOfBook(book, numberOfBooks); //책 수량 업데이트

        }

        private void MyBook() //내가 빌린 책 
        {
            Console.Clear(); 
            

            if (librarySystem.MyBook().Count == 0) //빌린 책이 없으면
            {
                ui.Alert("현재 빌린 책이 없습니다.", warning3: "<<Enter>>"); 
                Console.Read();
                return;
            }


            Console.SetWindowSize(145,14);
            Console.WriteLine("\n < < < 현재 내가 빌린 책 > > > \n\n");

            int index = 1;

            foreach (borrowingBook myBookData in librarySystem.MyBook())  //모든 책 데이터 출력 -> 책 목록과는 다르게 반납날짜를 출력해준다,
            {

                ui.MyBookUI(ui.Half2Full(index.ToString()), ui.Half2Full(myBookData.book.BookName), ui.Half2Full(string.Format("{0:yyyy년 MM월 dd일}", myBookData.returnDate) + "까지 반납하셔야 됩니다."));
                Console.WriteLine();
                index++;
            }

            Console.Write(" \n\n  반납을 원하시는 책 번호를 입력하세요 (0 : 뒤로가기) : "); //바로 반납할 수 있도록

            string input = Console.ReadLine();

            if (input == Constants.EXIT)
                return;

            else if (exception.OnlyNumberCheck(input))
            {
                index = 0;

                index = int.Parse(input) - 1;

                if (index >= 0 && index < librarySystem.MyBook().Count)
                {
                    User_BookMenu(librarySystem.MyBook()[index].book);
                    MyBook();
                    return;
                }

            }

        }
        private void SearchingUser(List<UserVO> userData) // 책 검색하기
        {
            List<UserVO> userSearched= new List<UserVO>();  //와일문 밖으로 빼서 선언 후 생성.

            while (true)
            {
                ui.SearchingUserUI();  //출력 초기화
                userSearched.Clear(); // 리스트 초기화

                string check = Console.ReadLine(); //검색할 단어

                if (check == Constants.EXIT) //함수 종료
                    return;

                foreach (UserVO user in userData)
                {
                    if (exception.Search(check, user.Name) ||
                        exception.Search(check,user.ID)||
                        exception.Search(check,user.Address)
                        ) // 검색할 단어 모든 책 제목에서 검색 -> 정규식 사용
                        userSearched.Add(user);   // 책 제목에 포함이 되면 리스트에 추가
                }

                ShowUsers(userSearched); // 이 리스트를 이용해 Showbook을 재 사용.
                return;
            }
        }



        /*--------------------------USER--------------------------*/

        private void UserMenu()  //사용자 메뉴
        {
            while (true)
            {
                ui.UserMenuUI();

                switch (exception.Button())
                {
                    case Constants.BOOKS:
                        ShowBooks(librarySystem.BookData, Constants.USER);
                        break;

                    case Constants.SEARCHING_BOOK:
                        SearchingBook(librarySystem.BookData, Constants.USER);
                        break;

                    case Constants.MYBOOKS: //내가 빌린 책
                        MyBook();
                        break;

                    case Constants.USER_SETTING: //내 데이터 수정
                        UserSettingMenu();
                        break;

                    case Constants.ADMINISTRATOR_MODE: //관리자 모드
                        if (librarySystem.IntoAdministratorMode())
                            AdministratorMenu();
                        else
                        {
                            ui.Alert("관리자 아이디만 진입할 수 있습니다.", warning3:"<<< E N T E R >>>");
                            Console.Read();
                        }
                        break;

                    case Constants.LOGOUT: //로그아웃
                        {
                            librarySystem.Logout();
                            return;
                        }

                    case Constants.WITHDRAWAL:  //회원탈퇴
                        {
                            if (librarySystem.Withdrawal())  // 관리자는 회원 탈퇴 불가
                                return;

                            else
                                break;
                        }

                    case null: continue;

                }

            }
        }

        private void UserSettingMenu()  //유저 세팅 메뉴
        {
            while (true)
            {
                ui.UserSettingUI();

                switch (exception.Button())
                {
                    case Constants.CHANGE_PASSWORD:  //비밀번호 변경
                        {
                            string password;
                            SetPassword(out password);                               // 회원가입 함수 
                            if (password == null)
                                return;
                            librarySystem.UserSetting(password: password);  
                            break;
                        }

                    case Constants.CHANGE_PHONENUMBER:  //핸드폰 번호 변경
                        {
                            string phonenumber;
                            SetPhonenumber(out phonenumber);
                            if (phonenumber == null)
                                return;
                            librarySystem.UserSetting(phonenumber: phonenumber);
                            break;
                        }

                    case Constants.CHANGE_ADDRESS: //주소 변경
                        {
                            string address;
                            SetAddress(out address);
                            if (address == null)
                                return;
                            librarySystem.UserSetting(address: address);
                            break;
                        }

                    case Constants.PRINT_MY_DATA:  // 내 정보 출력
                        {
                            librarySystem.PrintMyData();
                            break;
                        }

                    case Constants.USER_SETTING_BACK: // 뒤로 돌아가기
                        return;

                    case null: continue;

                }

            }
        }

        /*--Administrator---*/

        private void AdministratorMenu()  //관리자 메뉴
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
                        ShowUsers(librarySystem.UserData);
                        break;

                    case Constants.SEARCHING_USER:
                        SearchingUser(librarySystem.UserData);
                        break;

                    case Constants.USER_MODE:
                        return;

                    case null:
                        continue;

                }
            }
        }

        private void ShowUsers(List<UserVO> userList)  //유저 출력
        {

            while (true)
            {
                Console.Clear();
                Console.SetWindowSize(137, 48);


                ui.UserUI(ui.Half2Full("번호"),ui.Half2Full("유저 아이디"), ui.Half2Full("이름"), ui.Half2Full("핸드폰 번호"), ui.Half2Full("주소"), ui.Half2Full("대출 수"));
                Console.WriteLine();

                int index = 1;

                foreach (UserVO user in userList)
                {
                    ui.UserUI(ui.Half2Full((index++).ToString()),ui.Half2Full(user.ID), ui.Half2Full(user.Name), ui.Half2Full(user.Phonenumber), ui.Half2Full(user.Address), ui.Half2Full(user.BorrowingBooks.Count().ToString()));
                }

                Console.Write("\n\n 대여 목록을 보고 싶은 유저 번호를 입력하세요 : (0 : 돌아가기) : ");

                string input = Console.ReadLine();


                if (input == Constants.EXIT)
                    return;

                else if (exception.OnlyNumberCheck(input))
                {

                    index = int.Parse(input) - 1;

                    if (index >= 0 && index < userList.Count)
                    {
                        ShowUserBook(userList[index]);

                    }
                }
            }
        }

        private void ShowUserBook(UserVO user)
        {

            Console.Clear();

            if (user.BorrowingBooks.Count == 0) //빌린 책이 없으면
            {
                ui.Alert("현재 빌린 책이 없습니다.", warning3: "<<Enter>>");
                Console.Read();
                return;
            }


            Console.SetWindowSize(145, 14);
            Console.WriteLine("\n < < < 현재 내가 빌린 책 > > > \n\n");

            int index = 1;

            foreach (borrowingBook userBookData in user.BorrowingBooks)  //모든 책 데이터 출력 -> 책 목록과는 다르게 반납날짜를 출력해준다,
            {

                ui.MyBookUI(ui.Half2Full(index.ToString()), ui.Half2Full(userBookData.book.BookName), ui.Half2Full(string.Format("{0:yyyy년 MM월 dd일}", userBookData.returnDate) + "까지 반납하셔야 됩니다."));
                Console.WriteLine();
                index++;
            }

            Console.WriteLine("<< E N T E R>>");
            Console.Read();
        }
    }
   }
