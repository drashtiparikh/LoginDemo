using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginBusiness;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    #region Variable Declaration
    UserDataBAL userDataBAL;
    DataSet ds;

    #endregion

    #region Page Methods

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = new DataSet();
            ds = selectAllUserData();
        }
    }
    #endregion

    #region Methods

    protected DataSet selectAllUserData()
    {
        userDataBAL = new UserDataBAL();
        return userDataBAL.selectAllUserData();
    }

    #endregion

}