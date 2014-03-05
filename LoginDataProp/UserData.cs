using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginDataProp
{
    public class UserData
    {
        #region variable declaration

        private int _id;
        private string _firstName;
        private string _lastName;

        private string _emailid;
        private string _password;
        private string _phoneNo;
        private bool _isvalid;


        public const string ID = "Id";
        public const string FIRST_NAME = "FirstName";
        public const string LAST_NAME = "LastName";
        public const string EMAIL_ID = "Emailid";
        public const string PASSWORD = "Password";
        public const string PHONE_NO = "PhoneNo";
        public const string IS_VALID = "Isvalid";

        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Emailid
        {
            get { return _emailid; }
            set { _emailid = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }

        public bool Isvalid
        {
            get { return _isvalid; }
            set { _isvalid = value; }
        }

        #endregion



    }
}
