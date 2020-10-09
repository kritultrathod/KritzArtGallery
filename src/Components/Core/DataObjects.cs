using System.Configuration;

namespace KritzArtGallery.Core
{
  public abstract class DataObject
  {
    public static string ConnectionString
    {
      get
      {
        return ConfigurationManager.AppSettings["ConnectionString"];
      }
    }
  }
}

