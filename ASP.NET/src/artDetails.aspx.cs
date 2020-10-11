using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KritzArtGallery.DataAccessLayer;
namespace KritzArtGallery
{
  public partial class artDetails : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //GridView1.DataSource = ArtDetails.getEditArtDetails(Int32.Parse(Request.QueryString["id"]));
      //GridView1.DataBind();

      SqlDataReader detailsOfArt = ArtDetails.getEditArtDetails(Int32.Parse(Request.QueryString["id"]));
      detailsOfArt.Read();

      lblName.Text = detailsOfArt["Name"].ToString();
      lblArtist.Text = detailsOfArt["Artist"].ToString();
      lblDimInch.Text = detailsOfArt["DimInch"].ToString();
      lblDimCm.Text = detailsOfArt["DimCm"].ToString();
      lblDescription.Text = detailsOfArt["Description"].ToString();
      lblPrice.Text = "Rs. " + string.Format("{0:##,###.##}", detailsOfArt["Price"]);

      bool boolPrice = bool.Parse(detailsOfArt["Private"].ToString());
      bool boolAvailable = bool.Parse(detailsOfArt["Available"].ToString());
      bool boolSendAFriend = bool.Parse(detailsOfArt["SendAFriend"].ToString());

      lnkReqQuote.HRef = "mailto:kritzart@gmail.com?Subject=Request%20for%20quote&Body=Dear%20Admin,%0D%0DUser%20would%20like%20to%20get%20the%20quote%20for%20http://" +
          Request.Url.Authority.ToString() + "/artDetails.aspx?id=" + detailsOfArt["ID"].ToString() +
      "%0D%0DThank%20You.%0DTeam%20Kritz%20Art%20Gallery%0D";

      lnkSendToFriend.HRef = lnkSendToFriend.HRef = "mailto:?Subject=Kritz%20Art%20Gallery%20Reference&Body=Hi,%0DPlease%20click%20below%20link%20to%20view%20the%20art%0D%0Dhttp://" +
      Request.Url.Authority.ToString() + "/artDetails.aspx?id=" + detailsOfArt["ID"].ToString() +
      "%0D%0DThank%20you,%0DTeam%20Kritz%20Art%20Gallery%0D";

      //hide price?
      if (boolPrice)
      {
        lblPrice.Text = string.Empty;
      }
      else
      {
        //lblPrice.Text = DataBinder.Eval(e.Item.DataItem, "Price").ToString();
        lnkReqQuote.HRef = string.Empty;
        lnkReqQuote.Disabled = true;
      }
      //if Available
      if (boolAvailable)
      {
        //imgReqQuote.ImageUrl = "~/img/sold.jpg";
      }
      else
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

      imgLargeImage.ImageUrl = "~/images/big-images/" + detailsOfArt["ImageLarge"].ToString();
      Image imgPreview = (Image)imgLargeImage;
      if (File.Exists(
          Server.MapPath("~/images/big-images/" + detailsOfArt["ImageLarge"].ToString())))
      {
        Image = System.Drawing.Image.FromFile(Server.MapPath("~/images/big-images/" + detailsOfArt["ImageLarge"].ToString()));
        imgPreview.ImageUrl = "~/images/big-images/" + detailsOfArt["ImageLarge"].ToString();
        lnkFullImage.HRef = "~/images/big-images/" + detailsOfArt["ImageLarge"].ToString();
      }
      else
      {
        Image = System.Drawing.Image.FromFile(Server.MapPath("~/images/big-missing.JPG"));
        imgPreview.ImageUrl = "~/images/big-missing.JPG";
        lnkFullImage.HRef = "~/images/big-missing.JPG";
      }
      if (Image.Height > Image.Width)
      {
        imgPreview.Height = 400;
      }
      else
      {
        imgPreview.Width = 600;
      }
      Image.Dispose();
      imgPreview.Dispose();
    }
  }
}
