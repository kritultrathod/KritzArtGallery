using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using KritzArtGallery.DataAccessLayer;

namespace KritzArtGallery
{
  public partial class ArtGallery : Page
  {

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        txtSearch.Text = string.Empty;
        if (Session["ssnSearch"] != null)
        {
          if (Session["ssnIsSearch"] != null)
          {
            txtSearch.Text = Session["ssnSearch"].ToString();
          } // else keep textbox empty
        }
      }
      repeaterDatabind(txtSearch.Text);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
      //Session["ssnSearch"] = null;
    }
    protected void repeaterDatabind(string sSearch)
    {
      CollectionPager1.DataSource = ArtDetails.getArtDetails(sSearch).DefaultView;
      CollectionPager1.BindToControl = repArtView;

      if (CollectionPager1.TotalRecords == 0)
      {
        lblMessage.Text = "No records found";
        repArtView.DataSource = null;
        repArtView.DataBind();
      }
      else
      {
        lblMessage.Text = string.Empty;
        repArtView.DataSource = CollectionPager1.DataSourcePaged;
        repArtView.DataBind();
      }
    }

    protected void ImageSmall_PreRender(object sender, EventArgs e)
    {
      //if (((Image)sender).Width.Value > ((Image)sender).Height.Value) { };
    }

    protected void repArtView_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      //bool boolPrice = DataBinder.Eval(e.Item.DataItem, "Private") != null ? bool.Parse(DataBinder.Eval(e.Item.DataItem, "Private").ToString()) : false;
      Label lblPrice = (Label)e.Item.FindControl("lblPrice");
      HtmlAnchor lnkReqQuote = (HtmlAnchor)e.Item.FindControl("lnkReqQuote");
      HtmlAnchor lnkSendToFriend = (HtmlAnchor)e.Item.FindControl("lnkSendToFriend");

      lblPrice.Text = "Rs. " + string.Format("{0:##,###.##}", DataBinder.Eval(e.Item.DataItem, "Price"));
      //string.Format("{0:C}", DataBinder.Eval(e.Item.DataItem, "Price").ToString());


      bool boolPrice = bool.Parse(DataBinder.Eval(e.Item.DataItem, "Private").ToString());
      bool boolAvailable = bool.Parse(DataBinder.Eval(e.Item.DataItem, "Available").ToString());
      bool boolSendAFriend = bool.Parse(DataBinder.Eval(e.Item.DataItem, "SendAFriend").ToString());

      //  mailto:?&CC=&Subject=Please%2C%20I%20insist%21&Body=Please%20click%20below%20link%20to%20view%20the%20art%0Dhttp://localhost:2251/artDetails.aspx?id=>
      lnkReqQuote.HRef = "mailto:kritzart@gmail.com?Subject=Request%20for%20quote&Body=Dear%20Admin,%0D%0DUser%20would%20like%20to%20get%20the%20quote%20for%20http://" +
          Request.Url.Authority.ToString() + "/artDetails.aspx?id=" + DataBinder.Eval(e.Item.DataItem, "ID").ToString() +
      "%0D%0DThank%20You.%0DTeam%20Kritz%20Art%20Gallery%0D";

      lnkSendToFriend.HRef = lnkSendToFriend.HRef = "mailto:?Subject=Kritz%20Art%20Gallery%20Reference&Body=Hi,%0DPlease%20click%20below%20link%20to%20view%20the%20art%0D%0Dhttp://" +
          Request.Url.Authority.ToString() + "/artDetails.aspx?id=" + DataBinder.Eval(e.Item.DataItem, "ID").ToString() +
      "%0D%0DThank%20you,%0DTeam%20Kritz%20Art%20Gallery%0D";

      //lnkReqQuote.HRef =
      //    "mailto:kritzart@gmail.com?&CC=&Subject=Please%2C%20I%20insist%21&Body=Please%20click%20below%20link%20to%20view%20the%20art%0Dhttp://" +
      //    Request.Url.Authority.ToString() + "/artDetails.aspx?id=" + DataBinder.Eval(e.Item.DataItem, "ID").ToString() + 
      //    "%0DThank%20you,%0DTeam%20Kritz%20Art%20Gallery";

      //lnkSendToFriend.HRef =
      //    "mailto:?&CC=&Subject=Please%2C%20I%20insist%21&Body=Please%20click%20below%20link%20to%20view%20the%20art%0Dhttp://" +
      //    Request.Url.Authority.ToString() + "/artDetails.aspx?id=" + DataBinder.Eval(e.Item.DataItem, "ID").ToString() + 
      //    "%0DThank%20you,%0DTeam%20Kritz%20Art%20Gallery";
      //hide price?
      if (boolPrice)
      {
        lblPrice.Text = string.Empty;
      }
      else
      {
        lnkReqQuote.HRef = string.Empty;
        lnkReqQuote.Disabled = true;
      }
      //if Available
      if (!boolAvailable)
      {
        lblPrice.Text = "Sold";
        lblPrice.ForeColor = System.Drawing.Color.Red;
        lnkReqQuote.HRef = string.Empty;
        lnkReqQuote.Disabled = true;
      }
      //enable SendAFriend ?
      if (!boolSendAFriend)
      {
        lnkSendToFriend.HRef = string.Empty;
        lnkSendToFriend.Disabled = true;
      }
      // Handling image dimentions
      System.Drawing.Image Image;
      Image imgPreview = (Image)e.Item.FindControl("imgPreview");
      imgPreview.ImageUrl = "~/images/small-images/" + DataBinder.Eval(e.Item.DataItem, "ImageSmall").ToString();

      if (File.Exists(Server.MapPath("~/images/big-images/" + DataBinder.Eval(e.Item.DataItem, "ImageLarge").ToString())))
      {
        Image = System.Drawing.Image.FromFile(Server.MapPath("~/images/small-images/" + DataBinder.Eval(e.Item.DataItem, "ImageSmall").ToString()));
        imgPreview.ImageUrl = "~/images/small-images/" + DataBinder.Eval(e.Item.DataItem, "ImageSmall").ToString();
      }
      else
      {
        Image = System.Drawing.Image.FromFile(Server.MapPath("~/images/small-missing.JPG"));
        imgPreview.ImageUrl = "~/images/small-missing.JPG";
      }
      if (Image.Height > Image.Width)
      {
        imgPreview.Height = 130;
      }
      else
      {
        imgPreview.Width = 180;
      }
      Image.Dispose();
      imgPreview.Dispose();
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
      Session["ssnSearch"] = txtSearch.Text;
      Session["ssnIsSearch"] = "true";
      Response.Redirect("ArtGallery.aspx");
      //repeaterDatabind(Session["ssnSearch"].ToString());
    }
  }
}
