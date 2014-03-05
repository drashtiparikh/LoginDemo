using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPage : System.Web.UI.Page
{

    #region Page Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMsgtext.Text = @"Some Error has been occured. Please check Log file for more details.";
            lblMsgtext.CssClass = "errorText";
        }
    }
    #endregion
}