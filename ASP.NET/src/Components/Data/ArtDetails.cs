using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KritzArtGallery.Core;
using KritzArtGallery.Common;
using KritzArtGallery.Interface;

namespace KritzArtGallery.DataAccessLayer
{
  public class ArtDetails : DataObject, IArtDetails
  {
    private Int32 _ID;
    private string _Name;
    private string _Artist;
    private string _DimInch;
    private string _DimCm;
    private string _Description;
    private decimal _Price;
    private bool _Private;
    private bool _Available;
    private bool _SendAFriend;
    private string _ImageSmall;
    private string _ImageLarge;

    #region IArtDetails Members
    public Int32 ID
    {
      get { return _ID; }
      set { _ID = value; }
    }
    public string Name
    {
      get { return _Name; }
      set { _Name = value; }
    }
    public string Artist
    {
      get { return _Artist; }
      set { _Artist = value; }
    }
    public string DimInch
    {
      get { return _DimInch; }
      set { _DimInch = value; }
    }
    public string DimCm
    {
      get { return _DimCm; }
      set { _DimCm = value; }
    }
    public string Description
    {
      get { return _Description; }
      set { _Description = value; }
    }
    public decimal Price
    {
      get { return _Price; }
      set { _Price = value; }
    }
    public bool Private
    {
      get { return _Private; }
      set { _Private = value; }
    }
    public bool Available
    {
      get { return _Available; }
      set { _Available = value; }
    }
    public bool SendAFriend
    {
      get { return _SendAFriend; }
      set { _SendAFriend = value; }
    }
    public string ImageSmall
    {
      get { return _ImageSmall; }
      set { _ImageSmall = value; }
    }
    public string ImageLarge
    {
      get { return _ImageLarge; }
      set { _ImageLarge = value; }
    }
    #endregion

    // Get Art Details for the - ListView Page
    public static SqlDataReader getArtDetails(int pageIndex, int PageLen)
    {
      SqlParameter[] MsSqlParameter = {
          new SqlParameter( "@startRowIndex", pageIndex),
                    new SqlParameter( "@maximumRows", PageLen)
          };
      SqlDataReader MsDataReader = null;
      try
      {
        MsDataReader = SqlHelper.ExecuteReader(ConnectionString, "GET_RECORDS", MsSqlParameter);
        return MsDataReader;
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("A Database error occurred while retriving the Art Details.", ex);
      }
      finally
      {
      }
    }
    public static DataTable getArtDetails(string sSearch)
    {
      try
      {
        //MsDataReader = SqlHelper.ExecuteReader(ConnectionString, "GET_RECORDS", MsSqlParameter);
        //return MsDataReader;
        SqlParameter[] MsSqlParameter = {
          new SqlParameter( "@sSearch", sSearch),
          };
        return SqlHelper.ExecuteDataset(ConnectionString, "GET_RECORDS", MsSqlParameter).Tables[0];
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("A Database error occurred while retriving the Art Details.", ex);
      }
      finally
      {
      }
    }
    // Delete Selected art - ListView Page 
    public static Int32 delArtDetails(Int32 ID)
    {
      SqlParameter[] MsSqlParameter = {
                    new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, String.Empty, DataRowVersion.Default, null),
          new SqlParameter( "@ID", ID)
          };
      Int32 retVal = -1;
      try
      {
        retVal = Int32.Parse(SqlHelper.ExecuteNonQuery(ConnectionString, "DEL_RECORDS", MsSqlParameter).ToString());
        return retVal;
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("A Database error occurred while deleting the Art Details.", ex);
      }
      finally
      {
      }
    }
    // Get Selected Art Details - Edit Page
    public static SqlDataReader getEditArtDetails(Int32 ID)
    {
      SqlParameter[] MsSqlParameter = {
          new SqlParameter( "@ID", ID)
          };
      SqlDataReader MsDataReader = null;
      try
      {
        MsDataReader = SqlHelper.ExecuteReader(ConnectionString, "GET_EDIT_RECORD_DETAILS", MsSqlParameter);
        return MsDataReader;
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("A Database error occurred while Retriving Art Details for Edit.", ex);
      }
      finally
      {
      }
    }
    // Add Selected art details - Edit Page 
    public Int32 addArtDetails()
    {
      SqlParameter[] MsSqlParameter = {
                    new SqlParameter( "ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, String.Empty, DataRowVersion.Default, null),
          new SqlParameter( "@ID", this.ID),
          new SqlParameter( "@Name", this.Name),
          new SqlParameter( "@Artist", this.Artist),
          new SqlParameter( "@DimInch", this.DimInch),
          new SqlParameter( "@DimCm", this.DimCm),
          new SqlParameter( "@Description", this.Description),
          new SqlParameter( "@Price", this.Price),
          new SqlParameter( "@Private", this.Private),
          new SqlParameter( "@Available", this.Available),
          new SqlParameter( "@SendAFriend", this.SendAFriend),
          new SqlParameter( "@ImageSmall", this.ImageSmall),
          new SqlParameter( "@ImageLarge", this.ImageLarge),
          };
      Int32 retVal = -1;
      try
      {
        SqlHelper.ExecuteNonQuery(ConnectionString, "ART_ADD", MsSqlParameter);
        retVal = Int32.Parse(MsSqlParameter[0].Value.ToString());
        return retVal;
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("A Database error occurred while Adding the Art Details.", ex);
      }
      finally
      {
      }
    }
    // Update Selected art details - Edit Page 
    public Int32 updateArtDetails()
    {
      SqlParameter[] MsSqlParameter = {
                    new SqlParameter( "ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, String.Empty, DataRowVersion.Default, null),
          new SqlParameter( "@ID", this.ID),
          new SqlParameter( "@Name", this.Name),
          new SqlParameter( "@Artist", this.Artist),
          new SqlParameter( "@DimInch", this.DimInch),
          new SqlParameter( "@DimCm", this.DimCm),
          new SqlParameter( "@Description", this.Description),
          new SqlParameter( "@Price", this.Price),
          new SqlParameter( "@Private", this.Private),
          new SqlParameter( "@Available", this.Available),
          new SqlParameter( "@SendAFriend", this.SendAFriend),
          new SqlParameter( "@ImageSmall", this.ImageSmall),
          new SqlParameter( "@ImageLarge", this.ImageLarge),
          };
      Int32 retVal = -1;
      try
      {
        SqlHelper.ExecuteNonQuery(ConnectionString, "ART_UPD", MsSqlParameter);
        retVal = Int32.Parse(MsSqlParameter[0].Value.ToString());
        return retVal;
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("A Database error occurred while Updating the Art Details.", ex);
      }
      finally
      {
      }
    }
  }
}
