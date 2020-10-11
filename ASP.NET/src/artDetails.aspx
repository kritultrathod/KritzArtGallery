<%@ Page MasterPageFile="~/UserArtGallery.Master" Language="C#" AutoEventWireup="true"
  CodeBehind="artDetails.aspx.cs" Inherits="KritzArtGallery.artDetails" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="Content">
  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="5">
    <tr>
      <td align="right">
        <asp:LinkButton ID="lnkBack" runat="server" OnClientClick="window.history.back(); return false;"
          CssClass="numbering" Text="Back"></asp:LinkButton>
      </td>
    </tr>
    <tr>
      <td colspan="2" class="artgallery_content" align="Center">
        <h3>
          <asp:Label ID="lblName" runat="server"></asp:Label></h3>
      </td>
    </tr>
    <tr>
      <td width="100%" height="100%" align="center" valign="middle" colspan="2">
        <a id="lnkFullImage" runat="server" class="border" rel="lightbox[lamb]">
          <asp:Image ID="imgLargeImage" runat="server" /></a>
      </td>
    </tr>
    <tr>
      <td align="right" class="artgallery_click" style="padding-right: 10px;">Click image to enlarge</td>
      <td align="center">&nbsp;</td>
    </tr>
    <tr>
      <td align="center">
        <table width="100%" border="0" cellspacing="5" cellpadding="5">
          <tr>
            <td class="artgallery_content" colspan="2" align="center">
              <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="padding-left: 10px;">
              <asp:Label ID="lblArtist" runat="server"></asp:Label>
            </td>
            <td class="artgallery_head">
              <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td class="artgallery_content" style="padding-left: 10px;">
              <asp:Label ID="lblDimInch" runat="server"></asp:Label>
              (In)
            </td>
            <td>
              <%--<a id="lnkReqQuote" runat="server" href='<%#"mailto:admin@Kritzart.com?&CC=&Subject=Please%2C%20I%20insist%21&Body=Please%20click%20below%20link%20to%20view%20the%20art%0Dhttp://localhost:2251/artDetails.aspx?id=" + Request.QueryString["Id"].ToString()%>'>--%>
              <a id="lnkReqQuote" runat="server" href="Mailto:">
                <asp:Image ID="imgReqQuote" runat="server" AlternateText="Request Quote" ImageUrl="~/images/request-quate.jpg" /></a>
            </td>
          </tr>
          <tr>
            <td class="artgallery_content" style="padding-left: 10px;">
              <asp:Label ID="lblDimCm" runat="server"></asp:Label>
              (cm)
            </td>
            <td>
              <%--<a id="lnkSendToFriend" runat="server" href='<%#"mailto:?&CC=&Subject=Please%2C%20I%20insist%21&Body=Please%20click%20below%20link%20to%20view%20the%20art%0Dhttp://localhost:2251/artDetails.aspx?id=" + Request.QueryString["Id"].ToString()%>'>--%>
              <a id="lnkSendToFriend" runat="server" href="Mailto:">
                <asp:Image ID="imgSendToFriend" runat="server" AlternateText="Email To Friend" ImageUrl="~/images/email-to-friend.jpg" /></a>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Content>
