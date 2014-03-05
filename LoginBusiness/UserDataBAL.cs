using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoginDataAccess;
using System.Data;
using LoginDataProp;

namespace LoginBusiness
{
    public class UserDataBAL
    {
        #region Variable Declaration
        UserDataDAL userDataDAL;
        #endregion

        #region Methods

        public bool insertUserData(UserData userData)
        {
            userDataDAL = new UserDataDAL();
            return userDataDAL.insertUserData(userData);
        }

        public bool updateUserData(UserData userData)
        {
            userDataDAL = new UserDataDAL();
            return userDataDAL.updateUserData(userData);
        }

        public DataSet selectAllUserData()
        {
            userDataDAL = new UserDataDAL();
            return userDataDAL.selectAllUserData();
        }


        public bool selectUserData(UserData userData)
        {
            userDataDAL = new UserDataDAL();
            return userDataDAL.selectUserData(userData);
        }

        public bool selectExistsUserData(UserData userData)
        {
            userDataDAL = new UserDataDAL();
            return userDataDAL.selectExistsUserData(userData);
        }


        #endregion

        #region Functions
        #endregion
    }
}
