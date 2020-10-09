<%@ Page Language="C#" MasterPageFile="~/UserArtGallery.Master" AutoEventWireup="true"
  CodeBehind="ArtGallery.aspx.cs" Inherits="KritzArtGallery.ArtGallery" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td align="right" class="artgallery_content" colspan="2" valign="bottom" style="height: 25px">
        <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
          <asp:TextBox ID="txtSearch" runat="server" BorderStyle="Groove" MaxLength="50" EnableViewState="False"></asp:TextBox><asp:ImageButton
            ID="btnSearch" runat="server" ImageUrl="~/images/search.jpg" OnClick="btnSearch_Click" />
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>&nbsp;
      </td>
    </tr>
    <tr>
      <td class="artgallery_content" align="Center">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
          <asp:Repeater ID="repArtView" runat="server" OnItemDataBound="repArtView_ItemDataBound">
            <ItemTemplate>
              <tr>
                <td class="text">
                  <!-- table -->
                  <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="190" height="140" align="center" valign="middle" class="photo_border">
                        <a href="<%# "artDetails.aspx?id="+DataBinder.Eval(Container.DataItem, "ID")%>">
                          <asp:Image ID="imgPreview" runat="server" ImageUrl='<%#"images/small-images/" + DataBinder.Eval(Container.DataItem, "ImageSmall")%>'
                            border="0" /></a>
                      </td>
                      <td align="center" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td valign="top">
                              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td height="30" align="left" class="artgallery_head" style="padding-left: 10px;">
                                    <%#DataBinder.Eval(Container.DataItem, "Artist")%>
                                  </td>
                                  <td width="6%" class="artgallery_content">&nbsp;</td>
                                  <td width="32%" align="left" class="artgallery_head">
                                    <asp:Label ID="lblPrice" runat="server" />&nbsp
                                  </td>
                                </tr>
                                <tr>
                                  <td height="32" colspan="2" align="left" class="artgallery_content" style="padding-left: 10px;">
                                    <%#DataBinder.Eval(Container.DataItem, "DimInch")%>
                                                                        (in)</td>
                                  <td align="left" class="artgallery_content">
                                    <a id="lnkReqQuote" runat="server">
                                      <asp:Image ID="imgReqQuote" runat="server" AlternateText="Request Quote" ImageUrl="~/images/request-quate.jpg" /></a>
                                  </td>
                                </tr>
                                <tr>
                                  <td height="32" align="left" class="artgallery_content" style="padding-left: 10px;">
                                    <%#DataBinder.Eval(Container.DataItem, "DimCm")%>
                                                                        (cm)
                                  </td>
                                  <td class="artgallery_content">&nbsp;</td>
                                  <td align="left" class="artgallery_content">
                                    <a id="lnkSendToFriend" runat="server">
                                      <asp:Image ID="imgSendToFriend" runat="server" AlternateText="Email To Friend" ImageUrl="~/images/email-to-friend.jpg" /></a>
                                  </td>
                                </tr>
                                <tr>
                                  <td height="36" align="left" class="artgallery_content" style="padding-left: 10px;">
                                    <%#DataBinder.Eval(Container.DataItem, "Description")%>
                                  </td>
                                  <td height="36" align="left" class="artgallery_head" style="padding-left: 10px;">&nbsp;</td>
                                  <td height="36" align="left" class="artgallery_head" style="padding-left: 10px;">&nbsp;</td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td align="right" class="artgallery_click" style="padding-right: 10px;">Click image to enlarge</td>
                      <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                      <td align="left" width="190">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td align="center" class="artgallery_head">
                              <%#DataBinder.Eval(Container.DataItem, "Name")%>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td align="center">&nbsp;</td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td class="text">&nbsp;</td>
              </tr>
              <tr>
                <td height="1" bgcolor="#DFDFDF" class="text"></td>
              </tr>
              <tr>
                <td class="text">&nbsp;</td>
              </tr>
            </ItemTemplate>
          </asp:Repeater>
          <tr>
            <td class="numbering" align="center">
              <strong>
                <cc1:CollectionPager
                  ID="CollectionPager1"
                  EnableViewState="false"
                  ControlCssClass="numbering"
                  PageNumbersDisplay="Numbers"
                  runat="server"
                  ResultsStyle="display:none"
                  PageSize="10"
                  BackNextStyle="color:#BB0000;text-decoration:none"
                  PageNumbersSeparator="|"
                  BackNextLinkSeparator=""
                  BackNextLocation="Split"
                  LabelText=""
                  BackText="<font style='color:#BB0000;text-decoration:none'>Prev Page |&nbsp;</font>"
                  NextText="<font style='color:#BB0000;text-decoration:none'>&nbsp;| Next Page</font>"
                  BackNextDisplay="HyperLinks"
                  UseSlider="true"
                  SliderSize="20">
                </cc1:CollectionPager>
              </strong>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Content>
