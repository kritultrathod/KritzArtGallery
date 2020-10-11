using System;


namespace KritzArtGallery.Common
{
  public class AppException : ApplicationException
  {

    string strUserMessage;
    string strLogMessage;
    int intUserErrNumber;
    Exception varInnerExp;
    public AppException(string strUserMessage)
    {
      this.strUserMessage = strUserMessage;
    }
    public AppException(string strUserMessage, string strLogMessage)
    {
      this.strUserMessage = strUserMessage;
      this.strLogMessage = strLogMessage;
    }
    public AppException(string strUserMessage, Exception varInnerExp)
    {
      if (strUserMessage != null) this.strUserMessage = strUserMessage;
      if (varInnerExp != null) this.varInnerExp = varInnerExp;
    }

    public AppException(string strUserMessage, string strLogMessage, int intUserErrNumber)
    {
      if (strUserMessage != null) this.strUserMessage = strUserMessage;
      if (strLogMessage != null) this.strLogMessage = strLogMessage;
      this.intUserErrNumber = intUserErrNumber;

    }
    public string UserMessage
    {
      get { return strUserMessage; }
    }

    public string LogMessage
    {
      get { return strLogMessage; }
    }

    public int UserErrNumber
    {
      get { return intUserErrNumber; }

    }
    public Exception InnerExp
    {
      get { return varInnerExp; }
    }
    public static string GetExceptionMessage(Exception e)
    {
      if (e.Message != null)
        return e.InnerException == null ? " # : " + e.ToString() + " $ : " + e.Source : " # : " + e.ToString() + " $ : " + e.Source + " -> " + GetExceptionMessage(e.InnerException);
      else
        return "In GetExceptionMessage the e.Message cannot be null";
    }
    public static string GetExceptionMessage(AppException e)
    {
      if (e.Message != null)
        return e.varInnerExp == null ? " @ : " + e.UserMessage + " $ : " + e.LogMessage : " @ : " + e.UserMessage + " $ : " + e.LogMessage + " -> " + GetExceptionMessage(e.varInnerExp);
      else
        return "In GetExceptionMessage the e.Message cannot be null";
    }


  }
}
