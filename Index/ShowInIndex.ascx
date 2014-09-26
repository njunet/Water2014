<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowInIndex.ascx.cs" Inherits="Maticsoft.Web.Admin.Material.ShowInIndex1" %>
<asp:GridView ID="GridViewArticle" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                ShowHeader="False" CellPadding="0"  Width="100%" 
    BorderStyle="None" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 17px">
                                        <div align="left">
                                            <asp:Label ID="Label1" runat="server" CssClass="text_blue" Text="●"  
                                                Height="16px" ToolTip='<%# Eval("MaterialId") %>' ></asp:Label>
                                            <asp:HyperLink ID="HyperLink1" runat="server" ToolTip='<%# Eval("Name").ToString() +Eval("Receiver").ToString()+"("+Eval("IssureTime","{0:d}").ToString()+")"%>'　NavigateUrl='<%#"Show.aspx?MaterialId="+ Eval("MaterialId") %>'
                                                Target="_blank" Text='<%# Eval("Name").ToString().Length>MyTitleLenth?Eval("Name").ToString().Substring(0,MyTitleLenth)+"...":Eval("Name")%>'></asp:HyperLink>
                                                 <asp:Label ID="LabelReceiver" runat="server" 
                                                Text='<%# " "+Eval("Receiver") %>' ></asp:Label>
                                            <asp:Label ID="LabelAddTime" runat="server" ForeColor="Gray" 
                                                Text='<%# "("+Eval("IssureTime","{0:d}") +")" %>' ></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle BorderWidth="0px" HorizontalAlign="Left" Height="10px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle BorderWidth="0px" />
               <PagerTemplate>
                   &nbsp;
               </PagerTemplate>
            </asp:GridView>