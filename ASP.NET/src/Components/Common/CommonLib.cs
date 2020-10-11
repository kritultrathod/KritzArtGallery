using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace KritzArtGallery.Common
{
  public class CommonLib
  {

    public static string GetSortDirection(string strSortDir)
    {

      switch (strSortDir)
      {
        case "ASC":
          strSortDir = "DESC";
          break;
        case "DESC":
          strSortDir = "ASC";
          break;
      }

      return strSortDir;

    }

    public static string GetRandomPassword(int length)
    {
      // Get the GUID
      string guidResult = System.Guid.NewGuid().ToString();

      // Remove the hyphens
      guidResult = guidResult.Replace("-", string.Empty);

      // Make sure length is valid
      if (length <= 0 || length > guidResult.Length)
        throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

      // Return the first length bytes
      return guidResult.Substring(0, length);
    }

    /// <summary>
    /// Sends the mail.
    /// </summary>
    /// <param name="from">The mail from.</param>
    /// <param name="to">The mail to.</param>
    /// <param name="subject">The mail subject.</param>
    /// <param name="messageBody">The mail message body.</param>
    /// <param name="isBodyHtml">if set to <c>true</c> [is body HTML].</param>
    /// <returns>
    /// True, if the mail is sent successfully, otherwise false
    /// </returns>
    public static bool SendMail(string from, string to, string subject, string messageBody, bool isBodyHtml)
    {
      try
      {
        string smtpServerName = ConfigurationManager.AppSettings["SmtpServer"];
        //string smtpUserName = ConfigurationManager.AppSettings["SmtpUser"];
        //string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

        MailMessage mailMessage = new MailMessage();
        mailMessage.Body = messageBody;
        mailMessage.IsBodyHtml = isBodyHtml;
        mailMessage.From = new MailAddress(from);
        mailMessage.Subject = subject;
        mailMessage.To.Add(to);

        //NetworkCredential networkCredential = new NetworkCredential(smtpUserName, smtpPassword);
        SmtpClient smtpClient = new SmtpClient(smtpServerName);
        //smtpClient.Credentials = networkCredential;
        smtpClient.Send(mailMessage);

        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Sends the mail.
    /// </summary>
    /// <param name="from">The mail from.</param>
    /// <param name="to">The mail to.</param>
    /// <param name="subject">The mail subject.</param>
    /// <param name="messageBody">The mail message body.</param>
    /// <param name="isBodyHtml">if set to <c>true</c> [is body HTML].</param>
    /// <param name="cc">The cc.</param>
    /// <param name="bcc">The BCC.</param>
    /// <returns>
    /// True, if the mail is sent successfully, otherwise false
    /// </returns>
    public static bool SendMail(string from, string to, string subject,
                                string messageBody, bool isBodyHtml, string[] cc, string[] bcc)
    {
      try
      {
        string smtpServerName = ConfigurationManager.AppSettings["SmtpServer"];
        //string smtpUserName = ConfigurationManager.AppSettings["SmtpUser"];
        //string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

        MailMessage mailMessage = new MailMessage();
        mailMessage.Body = messageBody;
        mailMessage.IsBodyHtml = isBodyHtml;
        mailMessage.From = new MailAddress(from);
        GetMailAddressCollection(cc, mailMessage, true);
        GetMailAddressCollection(bcc, mailMessage, false);
        mailMessage.Subject = subject;
        mailMessage.To.Add(to);

        //NetworkCredential networkCredential = new NetworkCredential(smtpUserName, smtpPassword);
        SmtpClient smtpClient = new SmtpClient(smtpServerName);
        //smtpClient.Credentials = networkCredential;
        smtpClient.Send(mailMessage);

        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }



    /// <summary>
    /// Gets the mail address collection.
    /// </summary>
    /// <param name="mailAddresses">The mail addresses.</param>
    /// <param name="mailMessage">The mail message.</param>
    /// <param name="CC">if set to <c>true</c> [CC].</param>
    private static void GetMailAddressCollection(string[] mailAddresses, MailMessage mailMessage, bool CC)
    {
      if (mailAddresses.Length > 0)
      {
        foreach (string mailAddress in mailAddresses)
        {
          if (CC)
          {
            mailMessage.CC.Add(mailAddress);
          }
          else
          {
            mailMessage.Bcc.Add(mailAddress);
          }
        }
      }
    }

    public static Decimal ConvertToDecimal(string strIntegerValue)
    {
      try
      {
        if (strIntegerValue == "" || strIntegerValue == null)
        {
          return 0;
        }
        else
        {
          return Convert.ToDecimal(strIntegerValue);
        }
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("An error occurred while processing Common.ConvertToInt32.", ex);
      }
    }
    public static Int32 ConvertToInt32(string strIntegerValue)
    {
      try
      {
        if (strIntegerValue == "" || strIntegerValue == null)
        {
          return 0;
        }
        else
        {
          return Convert.ToInt32(strIntegerValue);
        }
      }
      catch (AppException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new AppException("An error occurred while processing Common.ConvertToInt32.", ex);
      }
    }
  }
}
