<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactUs.aspx.cs" Inherits="KritzArtGallery.contact_us" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
  <title>:: Kritz Art Gallery ::</title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#181b1b">
  <table width="726" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td height="97" align="center" valign="middle">
        <img src="images/top-banner2.jpg" alt="" width="726" height="96" border="0" usemap="#Map" /></td>
    </tr>
    <%--  
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                width="726" height="267">
                                <param name="movie" value="images/main-banner.swf" />
                                <param name="quality" value="high" />
                                <embed src="images/main-banner.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                    type="application/x-shockwave-flash" width="726" height="267"></embed>
                            </object>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    --%>
    <tr>
      <td>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td>
              <img src="images/left-cartain2.jpg" alt="" width="114" height="40" /></td>
            <td>
              <a href="index.aspx">
                <img src="images/home.jpg" alt="home" width="127" height="40" border="0" /></a></td>
            <td>
              <a href="aboutUs.aspx">
                <img src="images/about-us.jpg" alt="about us" width="126" height="40" border="0" /></a></td>
            <td>
              <a href="artGallery.aspx">
                <img src="images/art-gallery.jpg" alt="art gallery" width="120" height="40" border="0" /></a></td>
            <td>
              <a href="contactUs.aspx">
                <img src="images/contact-us.jpg" alt="contact us" width="124" height="40" border="0" /></a></td>
            <td>
              <img src="images/right-cartain2.jpg" alt="" width="115" height="40" /></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="114">
              <img src="images/left-cartain3.jpg" alt="" width="114" height="46" /></td>
            <td width="100%" valign="bottom" background="images/nav-bot-bg.jpg">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="top_head" style="padding-left: 125px;">&nbsp;</td>
                </tr>
              </table>
            </td>
            <td width="121" align="right">
              <img src="images/right-cartian3.jpg" alt="" width="115" height="46" /></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td height="184" valign="top" background="images/middle-bg.jpg">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="35" colspan="2" align="center" class="top_head">
              <strong>Contact Us </strong>
            </td>
          </tr>
          <tr>
            <td align="center" valign="top" class="main_contain">
              <strong>Kritz Art Gallery</strong><br />
              7 Norway Maple Junction<br />
              South Bend,<strong> </strong>Indiana&ndash; 46614, United States.<br />
              <br />
              <strong>Phone:</strong> +1 574-442-6226<br />
              <br />
              <strong>Mobile:</strong> +1 513-910-3557<br />
              <br />
              <strong>Email:</strong> <a href="mailto:kritzart@gmail.com" class="readmore1"><strong>kritzart@gmail.com</strong></a></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td height="47" bgcolor="#161919">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="center" class="footer">
              <a href="index.aspx" class="footer">Home</a> | <a href="aboutUs.aspx" class="footer">About us</a> | <a href="artGallery.aspx" class="footer">Art Gallery</a> | <a href="contactUs.aspx"
                class="footer">Contact us</a></td>
            <td align="center" class="footer">Copyright &copy; 2007-2008 | Privacy Policy</td>
            <td align="center" class="footer">
              <a href="http://www.techjetsolutions.com/" target="_blank" class="footer">Website Develop
                                by Techjet Solutions</a></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <map name="Map" id="Map">
    <area shape="rect" coords="590,39,610,59" href="index.aspx" />
    <area shape="rect" coords="618,39,641,59" href="mailto:kritzart@gmail.com" />
    <area shape="rect" coords="648,39,668,60" href="contactUs.aspx" />
  </map>
</body>
</html>
