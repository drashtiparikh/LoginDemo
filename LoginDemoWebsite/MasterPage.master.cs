using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    #region Page Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["id"] == null || Convert.ToString(Session["id"]) == string.Empty)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
    #endregion
}
