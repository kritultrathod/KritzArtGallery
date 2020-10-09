<%@ Page Language="C#" MasterPageFile="~/AdminArtGallery.Master" AutoEventWireup="true"
  CodeBehind="admArtDetails.aspx.cs" Inherits="KritzArtGallery.admArtDetails" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <%--        <tr>
            <td align="right" class="artgallery_content" colspan="2">
                <asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/images/logout.jpg" AlternateText="Logout" OnClick="btnLogout_Click" />
            </td>
        </tr>--%>
    <tr>
      <td class="artgallery_content">
        <h3>Manage Art</h3>
      </td>
    </tr>
    <tr>
      <td class="artgallery_content" align="center">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        <table align="center" border="0" style="text-align: left">
          <tr>
            <td colspan="2" class="artgallery_content" align="center">
              <asp:ValidationSummary runat="server" DisplayMode="BulletList" ID="valArt" ValidationGroup="valArtDetails" />
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Image (Small)
            </td>
            <td class="artgallery_content">
              <asp:FileUpload CssClass="artgallery" ID="ctrSmallUpload" runat="server" Width="300px" /><br />
              <asp:Label ID="lblSmallFilename" runat="server" />
            </td>
            <td width="190" height="140" align="center" valign="middle" rowspan="2" class="photo_border">
              <a id="imgLink" runat="server">
                <asp:Image ID="imgPreview" runat="server" border="0" /></a>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Image (Large)
            </td>
            <td colspan="2" class="artgallery_content">
              <asp:FileUpload CssClass="artgallery" ID="ctrLargeUpload" runat="server" Width="300px" /><br />
              <asp:Label ID="lblLargeFilename" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="height: 24px; width: 112px;">Art Name <span style="color: #ff3300">*</span></td>
            <td colspan="2" style="height: 24px">
              <asp:TextBox CssClass="artgallery" ID="txtArtName" runat="server" MaxLength="100"
                Width="300px" />
              <asp:RequiredFieldValidator ID="valReqArtName" runat="server" ErrorMessage="Please enter Art Name."
                ControlToValidate="txtArtName" ValidationGroup="valArtDetails" Display="None"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Artist Name <span style="color: #ff3300">*</span></td>
            <td colspan="2">
              <asp:TextBox CssClass="artgallery" ID="txtArtist" runat="server" MaxLength="50" Width="300px" />
              <asp:RequiredFieldValidator ID="ValReqArtist" runat="server" ErrorMessage="Please enter artist name."
                ControlToValidate="txtArtist" ValidationGroup="valArtDetails" Display="None"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Dimension (in) &nbsp;<span style="color: #ff3300">*</span></td>
            <td colspan="2">
              <asp:TextBox CssClass="artgallery" ID="txtDimensionIn" runat="server" MaxLength="15"
                Width="300px" />
              <asp:RequiredFieldValidator ID="ValReqDimensionIn" runat="server" ErrorMessage="Please enter dimensions in Inches"
                ControlToValidate="txtDimensionIn" ValidationGroup="valArtDetails" Display="None"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Dimension (cm)&nbsp; <span style="color: #ff3300">*</span></td>
            <td colspan="2">
              <asp:TextBox CssClass="artgallery" ID="txtDimensionCm" runat="server" MaxLength="15"
                Width="300px" />
              <asp:RequiredFieldValidator ID="ValReqDimensionCm" runat="server" ErrorMessage="Please enter dimension in centimeters"
                ControlToValidate="txtDimensionCm" ValidationGroup="valArtDetails" Display="None"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Price <span style="color: #ff3300">*</span></td>
            <td colspan="2">
              <asp:TextBox CssClass="artgallery" ID="txtPrice" runat="server" MaxLength="13" Width="300px" />
              <asp:RequiredFieldValidator ID="ValReqPrice" runat="server" ErrorMessage="Please enter art price."
                ControlToValidate="txtPrice" ValidationGroup="valArtDetails" Display="None"></asp:RequiredFieldValidator>
              <asp:CompareValidator ID="ValComPrice" runat="server" ErrorMessage="Please enter a valid price details"
                ControlToValidate="txtPrice" Operator="DataTypeCheck" Type="Double" Display="None"
                ValidationGroup="valArtDetails"></asp:CompareValidator>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Description
            </td>
            <td colspan="2">
              <asp:TextBox CssClass="artgallery" ID="txtDescription" TextMode="MultiLine" runat="server"
                Rows="3" Width="300px" MaxLength="500" BorderStyle="Groove" />
              <%--<asp:RequiredFieldValidator ID="ValReqDescription" runat="server" ErrorMessage="Please enter art description."
                                ControlToValidate="txtDescription" ValidationGroup="valArtDetails" Display="None"></asp:RequiredFieldValidator>--%>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <span class="message">Please don�t check display price if Get Quote button has to be displayed at user end.</span>
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="height: 24px; width: 112px;">Display Price
            </td>
            <td colspan="2" style="height: 24px" class="artgallery_content">
              <asp:CheckBox CssClass="artgallery" ID="chkDisplayPrice" runat="server" Width="300px" />
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Availabile
            </td>
            <td colspan="2">
              <asp:DropDownList ID="ddlAvaliable" runat="server" Width="305px" CssClass="artgallery">
                <asp:ListItem Value="True">Get Quote (Available)</asp:ListItem>
                <asp:ListItem Value="False">Sold</asp:ListItem>
              </asp:DropDownList>&nbsp;
            </td>
          </tr>
          <tr>
            <td class="artgallery_head" style="width: 112px">Send To Friend
            </td>
            <td colspan="2" class="artgallery_content">
              <asp:CheckBox CssClass="artgallery" ID="chkEmail" runat="server" Width="300px" />
            </td>
          </tr>
          <tr>
            <td colspan="3" style="text-align: center">
              <asp:Button CssClass="button" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                ValidationGroup="valArtDetails" />
              <asp:Button CssClass="button" ID="batCancel" runat="server" Text="Cancel" OnClick="batCancel_Click" />
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Content>
