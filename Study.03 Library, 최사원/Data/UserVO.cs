using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Study._03_Library__최사원
{

    class UserVO
    {
        private int code;
        private string id;
        private string name;
        private string password;
        private string address;
        private string phonenumber;
        private int canBorrow = 2;

        List<borrowingBook> borrowingBooks = new List<borrowingBook>();

        public UserVO() { }

        public UserVO(int code, string id, string password, string name, string address, string phonenumber)
        {
            this.code = code;
            this.id = id;
            this.password = password;
            this.name = name;
            this.address = address;
            this.phonenumber = phonenumber;

        }

        public UserVO(int code)
        {
            this.code = code;
            id = "Admin";
            password = "835";
            name = "힘들다";
            address = "세종대 학술 정보원";
            phonenumber = "010-7170-5993";
            canBorrow = 3;

        }



        public string ID
        {
            get
            {
                return id;
            }

        }


        public string Password
        {
            //password는 get할 수 없음

            set
            {
                this.password = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                this.address = value;
            }
        }

        public string Phonenumber
        {
            get
            {
                return phonenumber;
            }

            set
            {
                this.phonenumber = value;
            }
        }

        public int Code
        {
            get
            {
                return code;
            }
        }

        public List<borrowingBook> BorrowingBooks
        {
            get
            {
                return borrowingBooks;
            }
        }

        public bool PasswordChecking(string beforeChecking)
        {
            if (password == beforeChecking)
                return true;

            return false;
        }


        public virtual bool BorrowingBook(BookVO book)
        {

            if (borrowingBooks.Count < canBorrow)
            {
                borrowingBook newBook;
                newBook.book = book;
                Console.WriteLine(newBook.book.BookName);
                newBook.returnDate = DateTime.Now.AddDays(14);
                borrowingBooks.Add(newBook);
                return true;
            }

            return false;
        }

        public void ReturnBook(BookVO bookReturned)
        {
            foreach (borrowingBook book in borrowingBooks)
            {
                if(bookReturned==book.book)
                {
                    borrowingBooks.Remove(book);
                    return;
                }

            }      
        }

        public DateTime? IsBorrowedFrom(BookVO checkingBook)
        {
          
            foreach(borrowingBook book in borrowingBooks)
            {
                if (checkingBook == book.book)
                {
                    return book.returnDate;
                }
            }

            return null;
        }

        public bool CanBorrowMore()
        {
            if (borrowingBooks.Count == canBorrow)
                return false;

            return true;
        }

    }

}
