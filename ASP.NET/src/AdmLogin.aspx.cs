using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace KritzArtGallery
{
  public partial class AdmLogin : System.Web.UI.Page
  {
    string userid = ConfigurationManager.AppSettings["userid"];
    string password = ConfigurationManager.AppSettings["password"];

    protected void Page_Load(object sender, EventArgs e)
    {
      ClearControls();
      if (!IsPostBack)
      {
        userid = ConfigurationManager.AppSettings["userid"];
        password = ConfigurationManager.AppSettings["password"];
      }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
      ClearControls();
      if (txtUserID.Text == userid && txtPwd.Text == password)
      {
        Session["ssnLoginStatus"] = "true";
        if (Request.QueryString["returl"] == null)
        {
          Response.Redirect("~/admArtGallery.aspx");

        }
        else
        {
          Response.Redirect(Request.QueryString["returl"].ToString());
        }
      }
      else
      {
        lblErrormsg.Text = "Please provide correct login details";
      }
    }
    protected void ClearControls()
    {
      lblErrormsg.Text = string.Empty;
    }
  }
}
