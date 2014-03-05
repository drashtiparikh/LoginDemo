using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginBusiness;
using System.Data;
using LoginDataProp;
using System.Net.Mail;
using System.Net;

public partial class Registration : System.Web.UI.Page
{

    #region Variable Declaration
    UserDataBAL userDataBAL;
    UserData userData;
    DataSet ds;
    SendMailFuntion sendMailFuntion;
    #endregion

    #region Page Methods

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMsgtext.Text = string.Empty;

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        userDataBAL = new UserDataBAL();
        userData = new UserData();
        userData.FirstName = txtFirstName.Text;
        userData.LastName = txtLastName.Text;
        userData.Emailid = txtEmailId.Text;
        userData.Password = txtPassword.Text;
        userData.PhoneNo = txtPhoneNumber.Text;

        bool resultExists = userDataBAL.selectExistsUserData(userData);
        if (resultExists == true)
        {
            lblMsgtext.Text = "Email id is already registered with the website.";
            lblMsgtext.CssClass = "errorText";
        }
        else
        {

            bool result = userDataBAL.insertUserData(userData);

            if (result == true)
            {
                String originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
                String parentDirectory = originalPath.Substring(0, originalPath.LastIndexOf("/"));

                string encryptedId = StringCipher.Encrypt(Convert.ToString(userData.Id), "123");

                string mailLink = parentDirectory + "/CheckUserData.aspx?" + "id=" + encryptedId;

                sendMailFuntion = new SendMailFuntion();
                string mailBody = "Please click on the link to confirm your registration. <br/> " + mailLink;
                bool mailResult = sendMailFuntion.SendMail(userData.Emailid, userData.Emailid, "Confirmation Link", mailBody);

                if (mailResult == true)
                {
                    lblMsgtext.Text = "You are successfully registered in web site. please check your mail.";
                    lblMsgtext.CssClass = "msgText";
                }
                else
                {
                    lblMsgtext.Text = "You are not successfully registered. Mail Send failure.";
                    lblMsgtext.CssClass = "errorText";
                }
            }
            else
            {
                lblMsgtext.Text = "You are not successfully registered. please try again.";
                lblMsgtext.CssClass = "errorText";

            }
        }
        clearControls();
    }

    #endregion

    #region Methods
    protected void clearControls()
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtEmailId.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtConfimPassword.Text = string.Empty;
        txtPhoneNumber.Text = string.Empty;
    }

    #endregion
}