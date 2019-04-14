using System;
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

        public const int ADMINISTRATOR = 0;
        public const int USER = 1;



        /*---button---*/

        //login menu
        public const int LOGIN = 1;
        public const int SIGNIN = 2;

        //user menu
        public const int BOOKS = 1;
        public const int SEARCHING_BOOK = 2;
        public const int MYBOOKS = 3;
        public const int USER_SETTING = 4;
        public const int ADMINISTRATOR_MODE = 5;
        public const int LOGOUT = 6;
        public const int WITHDRAWAL = 7;


        //user setting
        public const int CHANGE_PASSWORD = 1;
        public const int CHANGE_PHONENUMBER = 2;
        public const int CHANGE_ADDRESS = 3;
        public const int PRINT_MY_DATA = 4;
        public const int USER_SETTING_BACK = 5;

        //Administrator menu
        public const int BOOK_SETTING= 1;
        public const int NEW_BOOK = 2;
        public const int ALL_OF_USERS= 3;
        public const int USER_MODE = 5;
        public const int SEARCHING_USER = 4;

        //Book menu _ USER
        public const int BORROW_BOOK = 1;
        public const int RETURN_BOOK = 2;

        //Book menu _ ADMINISTRATOR
        public const int UPDATE_BOOK_COUNT = 1;
        public const int DELETE_BOOK = 2;
        public const int ADMINISTRATOR_BACK = 3;


        public const string EXIT = "0";

        
       
        /*---UI---*/

            //book
        public const int INDEX_LENGTH_OF_LINE = 3;
        public const int NAME_LENGTH_OF_LINE= 30;
        public const int PUBLISHER_LENGTH_OF_LINE = 10;
        public const int WRITER_LENGTH_OF_LINE = 5;
        public const int NUMBER_LENGTH_OF_LINE = 5;

        //book
        public const int USERID_LENGTH_OF_LINE = 10;
        public const int USERNAME_LENGTH_OF_LINE = 5;
        public const int PHONENUMBER_LENGTH_OF_LINE = 11;
        public const int ADDRESS_LENGTH_OF_LINE = 10;
        public const int NUMBEROFBOOKS_OF_LINE = 3;
      


        /*---FRAME---*/
        public const int LOGIN_FRAME_X = 5;
        public const int LOGIN_FRAME_Y = 1;

        public const int SIGNIN_FRAME_X = 6;
        public const int SIGNIN_FRAME_Y = 3;

        public const int SEARCHING_BOOK_INPUT_X = 3;
        public const int SEARCHING_BOOK_INPUT_Y = 7;


        //Alert
        public const int ALERT_X_FRAME = 10;
        public const int ALERT_Y_FRAME = 3;



    }
}
