using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using KritzArtGallery.DataAccessLayer;
using System.Data.SqlClient;

namespace KritzArtGallery
{
  public partial class admArtGallery : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      clearControls();
      if (Session["ssnLoginStatus"] == null || Session["ssnLoginStatus"].ToString() != "true")
      {
        string s = Request.Url.ToString();
        Response.Redirect("AdmLogin.aspx?returl=" + Request.Url);
      }
      if (Request.QueryString["op"] != null)
      {
        switch (Request.QueryString["op"].ToString())
        {
          case "edt":
            lblMessage.Text = "The art details updated sucessfully"; break;
          case "ad":
            lblMessage.Text = "The art details added sucessfully"; break;
        }
      }
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
    protected void Page_PreRender(object sender, EventArgs e)
    {
      if (Session["ssnLoginStatus"] == null || Session["ssnLoginStatus"].ToString() != "true")
      {
        string s = Request.Url.ToString();
        Response.Redirect("AdmLogin.aspx?returl=" + Request.Url);
      }

    }
    protected void Page_Render(object sender, EventArgs e)
    {
      Page.ClientScript.RegisterForEventValidation(this.UniqueID);
    }

    protected void repArtView_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      if (e.CommandName == "Edit")
      {
        Response.Redirect("~/admArtDetails.aspx?id=" + e.CommandArgument.ToString());
      }

      if (e.CommandName == "Delete")
      {
        try
        {
          e.CommandArgument.ToString();
          SqlDataReader reader = ArtDetails.getEditArtDetails(Int32.Parse(e.CommandArgument.ToString()));
          reader.Read();

          string smallpath =
          Server.MapPath("~/images/small-images/" + reader["ImageSmall"].ToString());
          string bigpath =
          Server.MapPath("~/images/big-images/" + reader["ImageLarge"].ToString());

          if (File.Exists(smallpath)) File.Delete(smallpath);
          if (File.Exists(bigpath)) File.Delete(bigpath);

          int retVal = ArtDetails.delArtDetails(Convert.ToInt32(e.CommandArgument));
          switch (retVal)
          {
            case 1: lblMessage.Text = "Record deleted sucessfully."; repeaterDatabind(txtSearch.Text); break;
            default: lblMessage.Text = "An error occured retrieving the record or the record not found"; break;
          }
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
    protected void btnAddNewArt_Click(object sender, EventArgs e)
    {
      Response.Redirect("~/admArtDetails.aspx");
    }
    protected void clearControls()
    {
      lblMessage.Text = string.Empty;
    }
    protected void repArtView_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      bool boolDisplayPrice = bool.Parse(DataBinder.Eval(e.Item.DataItem, "Private").ToString());
      bool boolAvailable = bool.Parse(DataBinder.Eval(e.Item.DataItem, "Available").ToString());
      bool boolSendAFriend = bool.Parse(DataBinder.Eval(e.Item.DataItem, "SendAFriend").ToString());

      Label lblPrivate = (Label)e.Item.FindControl("lblPrivate");
      Label lblSendAFriend = (Label)e.Item.FindControl("lblSendAFriend");
      Label lblAvailable = (Label)e.Item.FindControl("lblAvailable");

      //Availability (req-quote / sold)
      if (boolAvailable)
      {
        lblAvailable.Text = "Get Quote (Available)";
      }
      else
      {
        lblAvailable.Text = "Sold";
        lblAvailable.ForeColor = System.Drawing.Color.Red;
      }

      //price (display / hide)
      if (boolDisplayPrice)
      {
        lblPrivate.Text = "No";
      }
      else
      {
        lblPrivate.Text = "Yes";
      }

      //enable SendAFriend ?
      if (boolSendAFriend)
      {
        lblSendAFriend.Text = "Yes";
      }
      else
      {
        lblSendAFriend.Text = "No";
      }

      // Handling image dimentions
      System.Drawing.Image Image;
      Image imgPreview = (Image)e.Item.FindControl("imgPreview");

      if (File.Exists(
          Server.MapPath("~/images/small-images/" + DataBinder.Eval(e.Item.DataItem, "ImageSmall").ToString())))
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

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
      Session["ssnSearch"] = txtSearch.Text;
      Session["ssnIsSearch"] = "true";
      Response.Redirect("admArtGallery.aspx");
      //repeaterDatabind(txtSearch.Text);
    }
    //protected void btnLogout_Click(object sender, ImageClickEventArgs e)
    //{
    //    Session["ssnLoginStatus"] = null;
    //    Session.Abandon();
    //}
  }
}
