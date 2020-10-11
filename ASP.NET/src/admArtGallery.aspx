<%@ Page MasterPageFile="~/AdminArtGallery.Master" Language="C#" AutoEventWireup="true"
  CodeBehind="admArtGallery.aspx.cs" Inherits="KritzArtGallery.admArtGallery" EnableEventValidation="false" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%--<script language="JavaScript">
<!--
function confirmSubmit()
{
var agree=confirm("Are you sure you wish to continue?");
if (agree)
	return true ;
else
	return false ;
}
</script>--%>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td align="right" class="artgallery_content" colspan="2" valign="bottom">
        <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
          <asp:TextBox ID="txtSearch" runat="server" BorderStyle="Groove"></asp:TextBox><asp:ImageButton
            ID="btnSearch" runat="server" ImageUrl="~/images/search.jpg" OnClick="btnSearch_Click" />
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <h3>Manage Gallery</h3>
      </td>
    </tr>
    <tr align="center">
      <td>
        <asp:LinkButton ID="btnAddNewArt" CssClass="numbering" runat="server" OnClick="btnAddNewArt_Click" Font-Bold="True">Add a new art</asp:LinkButton><br />
      </td>
    </tr>
    <tr>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td class="artgallery_content" align="center">
        <asp:Label ID="lblMessage" CssClass="message" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
          <asp:Repeater ID="repArtView" runat="server" OnItemCommand="repArtView_ItemCommand" OnItemDataBound="repArtView_ItemDataBound">
            <ItemTemplate>
              <tr>
                <td class="text">
                  <!-- table -->
                  <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <td>&nbsp
                    </td>
                    <td align="left" class="artgallery_content" style="padding-left: 10px;">
                      <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.jpg" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID")%>' />
                      <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/delete.jpg" CommandName="Delete" sCommandArgument='<%#DataBinder.Eval(Container.DataItem, "ID")%>' OnClientClick="return confirm('Are you sure you want to delete this Art?');" />
                    </td>
              </tr>
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
                            <td height="30" align="left" class="artgallery_head" style="padding-left: 10px;">Artist:
                            </td>
                            <td height="30" align="left" class="artgallery_content" style="padding-left: 10px;">
                              <%#DataBinder.Eval(Container.DataItem, "Artist")%>
                            </td>
                            <td width="6%" class="artgallery_content">&nbsp;</td>
                            <td align="left" class="artgallery_head" style="padding-left: 10px;">Price:
                            </td>
                            <td width="32%" align="left" class="artgallery_content" style="padding-left: 10px;">Rs.
                                                            <%# string.Format("{0:##,###.##}", DataBinder.Eval(Container.DataItem, "Price"))%>
                            </td>
                          </tr>
                          <tr>
                            <td height="32" align="left" class="artgallery_head" style="padding-left: 10px;">Dimension (In):
                            </td>
                            <td height="32" align="left" class="artgallery_content" style="padding-left: 10px;">
                              <%#DataBinder.Eval(Container.DataItem, "DimInch")%>
                                                            (in)</td>
                            <td align="left" class="artgallery_content">&nbsp
                            </td>
                            <td align="left" class="artgallery_head" style="padding-left: 10px;">Display Price:
                            </td>
                            <td align="left" class="artgallery_content" style="padding-left: 10px;">
                              <asp:Label ID="lblPrivate" runat="server" />
                            </td>
                          </tr>
                          <tr>
                            <td height="32" align="left" class="artgallery_head" style="padding-left: 10px;">Dimension (cm):
                            </td>
                            <td height="32" align="left" class="artgallery_content" style="padding-left: 10px;">
                              <%#DataBinder.Eval(Container.DataItem, "DimCm")%>
                                                            (cm)
                            </td>
                            <td class="artgallery_content">&nbsp;</td>
                            <td align="left" class="artgallery_head" style="padding-left: 10px;">Availablity:
                            </td>
                            <td align="left" class="artgallery_content" style="padding-left: 10px;">
                              <asp:Label ID="lblAvailable" runat="server" />
                            </td>
                          </tr>
                          <tr>
                            <td height="36" align="left" class="artgallery_head" style="padding-left: 10px;">Description:
                            </td>
                            <td colspan="4" height="36" align="left" class="artgallery_content" style="padding-left: 10px;">
                              <%#DataBinder.Eval(Container.DataItem, "Description")%>
                            </td>
                          </tr>
                          <tr>
                            <td height="36" align="left" class="artgallery_head" style="padding-left: 10px;">Send To Friend:
                            </td>
                            <td colspan="4" height="36" align="left" class="artgallery_content" style="padding-left: 10px;">
                              <asp:Label ID="lblSendAFriend" runat="server" />&nbsp
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td class="artgallery_click" align="right" style="padding-right: 10px;">Click image to enlarge</td>
                <td align="center" />
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
              </tr>
              </table>
                            <!-- End table -->
              </td> </tr>
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
                <cc1:CollectionPager ID="CollectionPager1" PageNumbersStyle="color:#BB0000;text-decoration:none"
                  PageNumberStyle="color:#BB0000;text-decoration:none" ControlCssClass="numbering"
                  PageNumbersDisplay="Numbers" runat="server" ResultsStyle="display:none" PageSize="10"
                  BackNextStyle='color:#BB0000;text-decoration:none ' PageNumbersSeparator="|"
                  BackNextLinkSeparator="|" BackNextLocation="Split" LabelText="" BackText="<font style='color:#BB0000;text-decoration:none'>Prev Page |&nbsp;</font>"
                  NextText="<font style='color:#BB0000;text-decoration:none'>&nbsp;| Next Page</font>"
                  BackNextDisplay="HyperLinks">
                </cc1:CollectionPager>
                <%--<cc1:CollectionPager ID="CollectionPager1" EnableViewState="false" ControlCssClass="numbering"
                                    PageNumbersDisplay="Numbers" runat="server" ResultsStyle="display:none" PageSize="10"
                                    BackNextStyle="color:#BB0000;text-decoration:none" PageNumbersSeparator="|" BackNextLinkSeparator="|"
                                    BackNextLocation="Split" LabelText="" BackText="<font style='color:#BB0000;text-decoration:none'>Prev Page |&nbsp;</font>"
                                    NextText="<font style='color:#BB0000;text-decoration:none'>&nbsp;| Next Page</font>"
                                    BackNextDisplay="HyperLinks" PagingMode="PostBack">
                                </cc1:CollectionPager>--%>
              </strong>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Content>
