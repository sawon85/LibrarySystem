using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study._03_Library__최사원
{
    public class BookVO
    {
        private int code;
        private string bookName;
        private string publisher;
        private string writer;
        private int numberOfBook;
        private int numberOfLoans;

        BookVO()
        {
            numberOfLoans = 0;
        }

        public string BookName
        {
         
            get
            {
                return bookName;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }
        }

        public string Writer
        {
            get
            {
                return writer;
            }
        }

        public int NumberOfBook
        {
            get
            {
                return numberOfBook;
            }

            set
            {
                numberOfBook = value;
            }
        }

        public int NumberOfLoans
        {

            get
            {
                return numberOfLoans;
            }

            set
            {
                numberOfLoans = value;
            }
        }

        public BookVO(int code, string bookName, string publisher, string writer, int numberOfBook = 1)
        {
            this.code = code;
            this.bookName = bookName;
            this.publisher = publisher;
            this.writer = writer;
            this.numberOfBook = numberOfBook;
           
        }

        public void newBook(int numberOfBook)
        {
            this.numberOfBook += numberOfBook;
        }


    }
}
