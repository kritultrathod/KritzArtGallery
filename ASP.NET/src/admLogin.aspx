<%@ Page MasterPageFile="~/AdminArtGallery.Master" Language="C#" AutoEventWireup="true"
  CodeBehind="AdmLogin.aspx.cs" Inherits="KritzArtGallery.AdmLogin" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <%--<h3 class="artgallery_content>Login</h3>--%>
  <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td align="left" class="artgallery_content" colspan="2">
        <h3>Login</h3>
      </td>
    </tr>
    <tr>
      <td align="center">
        <table width="50%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td class="artgallery_head" colspan="2">
              <asp:Label ID="lblErrormsg" runat="server" ForeColor="Red" Width="300px"></asp:Label><br />
              <asp:ValidationSummary ID="valLoginSummary" runat="server" ValidationGroup="vallogin"
                DisplayMode="List" Width="300px" />
            </td>
          </tr>
          <tr>
            <td class="artgallery_head">User ID
            </td>
            <td class="artgallery_content">
              <asp:TextBox ID="txtUserID" runat="server" AccessKey="U" MaxLength="20" Width="150px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="valReqLogin" runat="server" ErrorMessage="Please provide the User ID"
                ControlToValidate="txtUserID" Display="None" ValidationGroup="vallogin"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head">Password &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="artgallery_content">
              <asp:TextBox ID="txtPwd" runat="server" AccessKey="P" MaxLength="20" TextMode="Password"
                Width="150px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="valReqPassword" runat="server" ControlToValidate="txtPwd"
                Display="None" ErrorMessage="Please provide the Password" ValidationGroup="vallogin"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td>&nbsp;
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" colspan="2">
              <asp:Button ID="btnLogin" CssClass="button" runat="server" Text="Login" Width="100"
                OnClick="btnLogin_Click" ValidationGroup="vallogin" />
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Content>
