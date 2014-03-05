using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginBusiness;
using LoginDataProp;

public partial class CheckUserData : System.Web.UI.Page
{
    #region Variable Declaration
    UserDataBAL userDataBAL;
    UserData userData;
    #endregion

    #region Page Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string querystringId = Convert.ToString(Request.QueryString["id"]);
            if (querystringId != null)
            {
                userDataBAL = new UserDataBAL();
                userData = new UserData();

                string userId = StringCipher.Decrypt(querystringId, "123");

                userData.Id = Convert.ToInt32(userId);
                bool resultUpdate = userDataBAL.updateUserData(userData);

                if (resultUpdate == true)
                {
                    lblMsgtext.Text = @"Your email id is confirmed in web site. Please <a href=""Login.aspx"" > Login </a> into your account .";
                    lblMsgtext.CssClass = "msgText";
                }
                else
                {
                    lblMsgtext.Text = "Your email id is confirmed in web site.";
                    lblMsgtext.CssClass = "errorText";
                }
            }
        }
    }
    #endregion
}