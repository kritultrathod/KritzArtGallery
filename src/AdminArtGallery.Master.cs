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
  public partial class AdminArtGallery : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["ssnLoginStatus"] == null || Session["ssnLoginStatus"].ToString() != "true")
      {
        lnkLogin.Text = "Login";
      }
      else
      {
        lnkLogin.Text = "Logout";
      }

      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      Response.Cache.SetExpires(DateTime.Now); //or a date much earlier than current time
    }

    protected void lnkLogin_Click(object sender, EventArgs e)
    {
      Session["ssnLoginStatus"] = null;
      Session.Abandon();
      Response.Redirect("~/admLogin.aspx");
    }

    protected void btnArtGallery_Click(object sender, EventArgs e)
    {
      if (Session["ssnSearch"] != null)
      {
        Session["ssnSearch"] = null;
        Session["ssnIsSearch"] = null;
      }
      Response.Redirect("admArtGallery.aspx");
    }

  }
}
