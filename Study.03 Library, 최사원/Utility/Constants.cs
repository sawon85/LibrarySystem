﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study._03_Library__최사원
{
    public struct borrowingBook
    {

        public BookVO book;
        public DateTime returnDate;

    }

    static class Constants
    {
        /*---code ---*/

        public const int USER_MENU = 0;
        public const int ADMINISTRATOR_MENU = 1;



        /*---button---*/

        //login menu
        public const int LOGIN = 1;
        public const int SIGNIN = 2;

        //user menu
        public const int BOOKS = 1;
        public const int MYBOOKS = 2;
        public const int USER_SETTING = 3;
        public const int ADMINISTRATOR = 4;
        public const int LOGOUT = 5;
        public const int WITHDRAWAL = 6;

        //Administrator menu
        public const int BOOK_SETTING= 1;
        public const int ALL_OF_USERS = 2;
        public const int BOOK_BORROWED= 3;
        public const int USER_MODE = 4;

        //Book menu _ USER
        public const int BORROW_BOOK = 1;
        public const int RETURN_BOOK = 2;

        //Book menu _ ADMINISTRATOR
        public const int UPDATE_BOOK_COUNT = 1;
        public const int DELETE_BOOK = 2;
        


    }
}
