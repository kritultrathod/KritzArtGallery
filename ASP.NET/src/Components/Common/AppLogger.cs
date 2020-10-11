using System;
using System.Configuration;
using System.Web;

namespace KritzArtGallery.Common
{
  public class AppLogger
  {

    public static void LogError(Exception Exp)
    {
      LogError(AppException.GetExceptionMessage(Exp));
    }
    public static void LogError(AppException Exp)
    {
      LogError(AppException.GetExceptionMessage(Exp));
    }

    public static void LogError(string Exp)
    {
      HttpContext context = HttpContext.Current;

      string referer = String.Empty;
      string sQuery = String.Empty;

      try
      {
        if (ConfigurationManager.AppSettings["ErrorLogFile"] != null)
        {
          string filePath =
              context.Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["ErrorLogFile"]));
          string errorDateTime = string.Format("{0}",
                                               DateTime.Now.ToString("dd MMM yyyy @ h:mm:ss tt"));
          try
          {
            if (context.Request.ServerVariables["HTTP_REFERER"] != null)
            {
              referer = context.Request.ServerVariables["HTTP_REFERER"].ToString();
            }
            sQuery =
                (context.Request.QueryString != null)
                    ? context.Request.QueryString.ToString()
                    : String.Empty;

            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true);
            if (Exp != null) sw.WriteLine("{0} \t {1} \t {2} \t {3} ", errorDateTime, Exp, referer, sQuery);
            sw.Close();
          }
          catch
          {
            return;
          }
        }
      }
      finally
      {
        if (context != null)
          context = null;
      }
    }
  }
}
