using System.Collections.Generic;

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
        private int numberOfMax;

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
            numberOfMax = 2;

        }

        public UserVO(int code)
        {
            this.code = code;
            id = "Admin";
            password = "835";
            name = "관리자";
            address = "세종대 학술 정보원";
            phonenumber = "01071705993";
            numberOfMax = 3;

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
            get
            {
                return password;
            }

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

        public int NumberOfMax
        {
            get
            {
                return numberOfMax;
            }
        }

        public List<borrowingBook> BorrowingBooks
        {
            get
            {
                return borrowingBooks;
            }
        }
    }

}
