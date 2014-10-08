<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentReport.aspx.cs" Inherits="Laputa_PaymentReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend> 付款月计划检索
             
                
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 73px" > 供应商名称:</td>
                            <td style="width: 110px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 22px" > &nbsp;</td>
                            <td style="width: 63px" >
                                <asp:Button ID="Search" runat="server" CssClass="Button02" OnClick="Search_Click" Text=" 检索 " Width="66px" />
                            </td>
                            <td style="width: 45px" > 
                                &nbsp;</td>
                            <td style="width: 125px">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="print" Text="打印报表" Width="70px" />
                            </td>
                            <td style="width: 127px">
                                <asp:Button ID="reset" runat="server" CssClass="Button02" OnClick="reset_Click" Text=" 重置" Width="66px" />
                            </td>
                            <td >
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

   

 

    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
                <fieldset>
                    <legend>待付款详情</legend>
                    <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="PMSI_ID,PMPO_PayWay"
                                  GridLines="None" EmptyDataText=" 没有相关记录 "  OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDataBound="GridView3_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="PMSI_ID" Visible="True"  >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true"  />
                            <asp:BoundField DataField="PMSI_Material" HeaderText="物料名称" Visible="true"  />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" Visible="true"  />
                            <asp:BoundField DataField="TotalDebt" HeaderText="总欠款" />
                            <asp:BoundField DataField="AlreadyPay" HeaderText="已付款" Visible="true"  />
                           


                           
                            <asp:BoundField DataField="PayRate" HeaderText="付款率" />
                           


                           
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>