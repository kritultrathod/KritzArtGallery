using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KritzArtGallery.DataAccessLayer;
using System.Data.SqlClient;
using KritzArtGallery.Common;

namespace KritzArtGallery
{
  public partial class admArtDetails : System.Web.UI.Page
  {
    private Int32 artID;
    int DESC_TEXT_LEN = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["ssnLoginStatus"] == null || Session["ssnLoginStatus"].ToString() != "true")
      {
        string s = Request.Url.ToString();
        Response.Redirect("AdmLogin.aspx?returl=" + Request.Url);
      }

      string lengthFunction = "function isMaxLength(txtBox) {";
      lengthFunction += " if(txtBox) { ";
      lengthFunction += "     return ( txtBox.value.length <" + DESC_TEXT_LEN + ");";
      lengthFunction += " }";
      lengthFunction += "}";

      this.txtDescription.Attributes.Add("onkeypress", "return isMaxLength(this);");
      ClientScript.RegisterClientScriptBlock(
          this.GetType(),
          "txtLength",
          lengthFunction, true);

      //--------------------------
      if (Request.QueryString["id"] != null)
      {
        artID = Int32.Parse(Request.QueryString["id"]);
      }
      else
      {
        imgPreview.Visible = false;// hide preview if add a new art
      }
      if (!IsPostBack)
      {
        clearControls();
        if (Request.QueryString["id"] != null)
        {
          artID = Int32.Parse(Request.QueryString["id"]);

          SqlDataReader reader = ArtDetails.getEditArtDetails(artID);
          reader.Read();

          // Handling Image dimentions
          System.Drawing.Image Image;
          imgLink.HRef = "artDetails.aspx?id=" + artID;
          if (File.Exists(Server.MapPath("~/images/small-images/" + reader["ImageSmall"].ToString())))
          {
            Image = System.Drawing.Image.FromFile(Server.MapPath("~/images/small-images/" + reader["ImageSmall"].ToString()));
            imgPreview.ImageUrl = "~/images/small-images/" + reader["ImageSmall"].ToString();
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

          lblSmallFilename.Text = reader["ImageSmall"].ToString();
          lblLargeFilename.Text = reader["ImageLarge"].ToString();
          txtArtName.Text = reader["Name"].ToString();
          txtArtist.Text = reader["Artist"].ToString();
          txtDimensionIn.Text = reader["DimInch"].ToString();
          txtDimensionCm.Text = reader["DimCm"].ToString();
          txtPrice.Text = reader["Price"].ToString();
          txtDescription.Text = reader["Description"].ToString();
          chkDisplayPrice.Checked = (bool)reader["Private"] ? false : true;
          chkDisplayPrice.Text = chkDisplayPrice.Checked ? "Uncheck to hide the price" : "Check to display price";
          if ((bool)reader["Available"])
          {
            ddlAvaliable.SelectedIndex = 0;
          }
          else
          {
            ddlAvaliable.SelectedIndex = 1;
          }
          chkEmail.Checked = (bool)reader["SendAFriend"];
          chkEmail.Text = chkEmail.Checked ? "Uncheck to disallow mailing" : "Check to allow mailing";
        }
      }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      string SmallImageName = string.Empty;
      string LargeImageName = string.Empty;
      Int32 retVal = -1;
      if (Page.IsValid)
      {

        SmallImageName = (ctrSmallUpload.HasFile) ? ctrSmallUpload.FileName : lblSmallFilename.Text;
        LargeImageName = ctrLargeUpload.HasFile ? ctrLargeUpload.FileName : lblLargeFilename.Text;

        if (ctrSmallUpload.HasFile && File.Exists(Server.MapPath("~/images/small-images/") + SmallImageName))
        {
          lblMessage.Text = "Error : Small image name already exists. Please rename the image and retry";
        }
        else if (ctrLargeUpload.HasFile && File.Exists(Server.MapPath("~/images/big-images/") + LargeImageName))
        {
          lblMessage.Text = "Error : Large image name already exists. Please rename the image and retry";
        }
        else
        {
          if (ctrSmallUpload.HasFile)
          {
            //Enhanced code for creating thumbnail on the fly. UPDATED 24-SEP-08 Not PUBLISHED FOR RELEASE CONSISTANCY.
            //UploadThumbnail(ctrSmallUpload.PostedFile.FileName, SmallImageName); 
            ctrSmallUpload.SaveAs(Server.MapPath("~/images/small-images/") + ctrSmallUpload.FileName);

          }
          if (ctrLargeUpload.HasFile)
          {
            ctrLargeUpload.SaveAs(Server.MapPath("~/images/big-images/") + ctrLargeUpload.FileName);

          }
          KritzArtGallery.DataAccessLayer.ArtDetails objDetails = new ArtDetails();

          objDetails.ID = artID;
          objDetails.Name = txtArtName.Text;
          objDetails.Artist = txtArtist.Text;
          objDetails.DimInch = txtDimensionIn.Text;
          objDetails.DimCm = txtDimensionCm.Text;
          objDetails.Description = txtDescription.Text;
          objDetails.Price = decimal.Parse(txtPrice.Text.ToString());
          objDetails.Private = chkDisplayPrice.Checked ? false : true;
          objDetails.Available = bool.Parse(ddlAvaliable.SelectedValue);
          objDetails.SendAFriend = chkEmail.Checked;
          objDetails.ImageSmall = SmallImageName;
          objDetails.ImageLarge = LargeImageName;

          if (artID > 0)
          {
            retVal = objDetails.updateArtDetails();
            if (retVal == 0)
              Response.Redirect("~/admArtGallery.aspx?op=edt");
            else
              lblMessage.Text = "An error occured while updating the Art";
          }
          else
          {
            retVal = objDetails.addArtDetails();
            if (retVal == 0)
              Response.Redirect("~/admArtGallery.aspx?op=ad");
            else
              lblMessage.Text = "An error occured while adding new Art";
          }
        }
      }
    }
    protected void clearControls()
    {
      //ctrSmallUpload.
      //ctrLargeUpload.FileName= string.Empty;
      txtArtName.Text = string.Empty;
      txtArtist.Text = string.Empty;
      txtDimensionIn.Text = string.Empty;
      txtDimensionCm.Text = string.Empty;
      txtPrice.Text = string.Empty;
      txtDescription.Text = string.Empty;
      chkDisplayPrice.Checked = false;
      //chkAvaliable.Checked = false;
      chkEmail.Checked = false;

    }
    protected void batCancel_Click(object sender, EventArgs e)
    {
      Response.Redirect("~/admArtGallery.aspx");
    }
    protected void UploadThumbnail(string ThumbnailImagePath, string SmallImageName)
    {
      String src;
      String dest;
      int thumbHeight;
      int thumbWidth;

      src = ThumbnailImagePath;
      dest = Server.MapPath("~/images/small-images/") + SmallImageName;


      System.Drawing.Image srcImage = System.Drawing.Image.FromFile(src);

      int srcImageWidth = srcImage.Width;
      int srcImageHeight = srcImage.Height;

      //Max Thumbnail Width="190" Max Thumbnail Height="140"
      Decimal sizeRatio;
      if (srcImageWidth > srcImageHeight)
      {
        sizeRatio = ((Decimal)srcImageHeight / srcImageWidth);
        thumbWidth = 190; // set default thumbnail width
        thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth); // adjust thumbnail height
      }
      else
      {
        sizeRatio = ((Decimal)srcImageWidth / srcImageHeight);
        thumbHeight = 140; // set default thumbnail height
        thumbWidth = Decimal.ToInt32(sizeRatio * thumbHeight); // adjust thumbnail width
      }

      //int thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth);
      Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);

      //Create a System.Drawing.Graphics object from the Bitmap which we will use to draw the high quality scaled image 
      System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);

      //Set the System.Drawing.Graphics object property SmoothingMode to HighQuality 
      gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

      //Set the System.Drawing.Graphics object property CompositingQuality to HighQuality
      gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

      //Set the System.Drawing.Graphics object property InterpolationMode to High
      gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

      //Draw the original image into the target Graphics object scaling to the desired width and height
      System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
      gr.DrawImage(srcImage, rectDestination, 0, 0, srcImageWidth, srcImageHeight, GraphicsUnit.Pixel);

      //Save to destination file
      bmp.Save(dest);

      //dispose / release  resources
      bmp.Dispose();
      srcImage.Dispose();
    }

    //protected void btnLogout_Click(object sender, ImageClickEventArgs e)
    //{
    //    Session["ssnLoginStatus"] = null;
    //    Response.Redirect("AdmLogin.aspx");
    //}
    //protected void chkHidePrice_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkHidePrice.Checked)
    //    {
    //        chkHidePrice.Text = "Yes";
    //    }
    //    else
    //    {
    //        chkHidePrice.Text = "No";
    //    }
    //}
    //protected void chkEmail_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkEmail.Checked)
    //    {
    //        chkEmail.Text = "Yes";
    //    }
    //    else
    //    {
    //        chkEmail.Text = "No";
    //    }
    //}
  }
}
