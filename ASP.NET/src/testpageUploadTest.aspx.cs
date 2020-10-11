using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace KritzArtGallery
{
  public partial class UploadTest : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
      if (FileUpload1.HasFile)
      {
        string ThumbnailImagePath = FileUpload1.PostedFile.FileName;
        FileUpload1.SaveAs(Server.MapPath("~/images/big-images/") + FileUpload1.FileName);
        UploadThumbnail(ThumbnailImagePath);
        lblError.Text = "Image Uploaded Sucessfully";

      }
      else
      {
        lblError.Text = "Please select an image file to upload";
      }
    }
    protected void UploadThumbnail(string ThumbnailImagePath)
    {
      String src;
      String dest;
      int thumbHeight;
      int thumbWidth;

      src = ThumbnailImagePath;
      dest = Server.MapPath("~/images/big-images/thumb_")/*("~/images/small-images/")*/ + FileUpload1.FileName;


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
  }
}
