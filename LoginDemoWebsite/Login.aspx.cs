using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginBusiness;
using LoginDataProp;

public partial class Login : System.Web.UI.Page
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
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtEmailId.Text = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
            Session.Abandon();
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registration.aspx");

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        userData = new UserData();
        userDataBAL = new UserDataBAL();

        userData.Emailid = txtEmailId.Text;
        userData.Password = txtPassword.Text;

        bool result = userDataBAL.selectUserData(userData);

        if (result == true)
        {
            if (userData.Id != 0)
            {
                Session["id"] = userData.Id;
                Session["firstname"] = userData.FirstName;

                if (chkRememberMe.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txtEmailId.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();


                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMsgtext.Text = "Please enter correct Emailid and password";
                lblMsgtext.CssClass = "errorText";
            }

        }
        else
        {
            lblMsgtext.Text = "Please enter correct Emailid and password ";
            lblMsgtext.CssClass = "errorText";
        }
    }

    #endregion

}