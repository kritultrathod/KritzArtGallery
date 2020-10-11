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
  public partial class UserArtGallery : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {
      //Session["ssnSearch"]=null;
    }

    protected void btnArtGallery_Click(object sender, EventArgs e)
    {
      if (Session["ssnSearch"] != null)
      {
        Session["ssnSearch"] = null;
        Session["ssnIsSearch"] = null;
      }
      Response.Redirect("ArtGallery.aspx");
    }
  }
}
