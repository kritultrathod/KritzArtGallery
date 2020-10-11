<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub btnArtGallery_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    btnArtGallery
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
  <title>:: Kritz Art Gallery ::</title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="js/prototype.js"></script>
  <script type="text/javascript" src="js/scriptaculous.js?load=effects"></script>
  <script type="text/javascript" src="js/lightbox.js"></script>
  <script type="text/javascript" src="js/scrollDiv.js"></script>
  <link rel="stylesheet" href="css/lightbox.css" type="text/css" media="screen" />
  <script type="text/javascript" language="javascript">
    function Goto(page) {
      if (window.location.pathname != page)
        window.location = page;
    }
  </script>
  <style type="text/css">
    .gallery_thumbnail {
      height: 160px;
      width: 160px;
      padding: 5px;
    }

      .gallery_thumbnail img {
        border: solid 2px gray;
      }

    .gallery_row {
      margin: 20px;
    }
  </style>
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
              <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="726" height="267">
                <param name="movie" value="images/main-banner.swf" />
                <param name="quality" value="high" />
                <embed src="images/main-banner.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="726" height="267"></embed>
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
            <td><a href="index.aspx">
              <img src="images/home.jpg" alt="home" width="127" height="40" border="0" /></a></td>
            <td><a href="aboutUs.aspx">
              <img src="images/about-us.jpg" alt="about us" width="126" height="40" border="0" /></a></td>

            <%--<td><a href="artGallery.aspx"><img src="images/art-gallery.jpg" alt="art gallery" width="120" height="40" border="0" /></a></td>--%>
            <td>
              <asp:ImageButton ID="btnArtGallery" runat="server" ImageUrl="images/art-gallery.jpg" OnClick="btnArtGallery_Click" /></td>

            <td><a href="contactUs.aspx">
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
                  <td class="top_head" style="padding-left: 125px;"><strong>Our Best Collection</strong></td>
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
            <td height="16" colspan="2"></td>
          </tr>
          <tr>
            <td width="239" valign="top" style="padding-left: 31px;">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="top_head">Welcome to<br />
                    Kritz Art Gallery</td>
                </tr>
                <tr>
                  <td class="contain_sub" style="padding-top: 5px; padding-right: 30px;"><strong>Kritz Art Gallery</strong> situated in the heart of the Art World display’s Arts of various leading Artists like Ajay De, Suhas Roy, Datta Bansode, Laxman Aelay, Pratima Sheth, Srinivas, Shakeel, Contemporary as well as some great Masterpieces.</td>
                </tr>
                <tr>
                  <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td>
                          <img src="images/arrow.gif" alt="" width="9" height="5" /></td>
                        <td height="25" class="readmore"><a href="aboutUs.aspx" class="readmore"><strong>READ MORE </strong></a></td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
            <td width="490" align="left" valign="top">
              <table width="472" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td height="143" align="left" valign="top">
                    <table width="472" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td>
                          <img src="images/top-black-curve.jpg" alt="" width="472" height="6" /></td>
                      </tr>
                      <tr>
                        <td height="131" align="center" valign="middle" bgcolor="#383C3D">
                          <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                              <td width="7" align="left">
                                <img src="images/left-black-curve.jpg" alt="" width="7" height="130" /></td>
                              <td valign="top" class="border_curve">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td width="3%"><a href="#null" onmouseover="scrollDivRight('container')" onmouseout="stopMe()">
                                      <img src="images/privous.jpg" alt="" width="15" height="66" border="0" /></a></td>
                                    <td width="93%" height="130" align="center" valign="middle">
                                      <div id="container">
                                        <div id="scroller">
                                          <div class="content">
                                            <a href="images/big-images/abstract.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/abstract.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Abstract</div>
                                          </div>
                                          <div class="content">
                                            <a href="images/big-images/figurative.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/figurative.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Figurative</div>
                                          </div>
                                          <div class="content">
                                            <a href="images/big-images/landscape.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/landscape.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Landscape</div>
                                          </div>
                                          <div class="content">
                                            <a href="images/big-images/artifacts.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/artifacts.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Artifacts</div>
                                          </div>
                                          <div class="content">
                                            <a href="images/big-images/abstract2.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/abstract2.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Abstract</div>
                                          </div>
                                          <div class="content">
                                            <a href="images/big-images/figurative2.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/figurative2.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Figurative</div>
                                          </div>
                                          <div class="content">
                                            <a href="images/big-images/landscape2.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/landscape2.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Landscape</div>
                                          </div>
                                          <div class="content">
                                            <a href="images/big-images/artifacts2.jpg" rel="lightbox[lamb]" title="">
                                              <img src="images/artifacts2.jpg" width="96" height="105" border="0" /></a><div class="main_contain">Artifacts</div>
                                          </div>

                                        </div>
                                        <br style="clear: both" />
                                      </div>
                                    </td>
                                    <td width="4%" align="right"><a href="#null" onmouseover="scrollDivLeft('container')" onmouseout="stopMe()">
                                      <img src="images/next-photo.jpg" alt="" width="13" height="48" border="0" /></a></td>
                                  </tr>
                                </table>
                              </td>
                              <td width="7" align="right">
                                <img src="images/right-black-curve.jpg" alt="" width="7" height="130" /></td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <img src="images/bottom-blackcurve.jpg" alt="" width="472" height="6" /></td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td height="47" bgcolor="#161919">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="center" class="footer"><a href="index.aspx" class="footer">Home</a>  |  <a href="aboutUs.aspx" class="footer">About us</a>  |  <a href="artGallery.aspx" class="footer">Art Gallery</a>  |  <a href="contactUs.aspx" class="footer">Contact us</a></td>
            <td align="center" class="footer">Copyright &copy; 2007-2008 | Privacy Policy</td>
            <td align="center" class="footer"><a href="http://www.techjetsolutions.com/" target="_blank" class="footer">Website Develop by Techjet Solutions</a></td>
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
