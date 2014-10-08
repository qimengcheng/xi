<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="HSFDue.aspx.cs" Inherits="Laputa_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <fieldset>
                    <legend>有毒物质检索
                    </legend>
                    <table style="width: 100%" >
                        <tr>
                            <td style="width: 67px" >材料名称：</td>
                            <td style="width: 158px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 59px" >供应商：</td>
                            <td style="width: 171px" >
                                <asp:TextBox ID="TextBox2" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 70px" >测试报告号:</td>
                            <td style="width: 167px" >
                                <asp:TextBox ID="TextBox3" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 67px" >&nbsp;</td>
                            <td style="width: 158px">
                                <asp:Button ID="Search" runat="server" CssClass="Button02" Text="检索" Width="66px" OnClick="Search_Click" />
                            </td>
                            <td style="width: 59px" >&nbsp;</td>
                            <td style="width: 171px">
                                <asp:Button  class="Button02"  value="重置"  runat="server" Text="重置" OnClick="Unnamed1_Click" Width="60px"/>
                            </td>
                            <td style="width: 70px" >
                                <asp:Label ID="HSFID" runat="server" Text="HSFID" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 167px">
                                <asp:Label ID="ReportID" runat="server" Text="ReportID" Visible="False"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" >
                
                <fieldset>
                    <legend>
                        
                        有毒物质报告表 </legend>
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"  EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSFReport_ID" HeaderText="HSFReportID" Visible="false"  />
                            <asp:BoundField DataField="HSF_MaterialName" HeaderText="材料名称" />
                            <asp:BoundField DataField="HSF_Provider" HeaderText="供应商" />
                            <asp:BoundField DataField="HSFReport_Num" HeaderText="测试报告号" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Type" HeaderText="类型" />
                            <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Date" HeaderText="测试日期" Visible="true" DataFormatString="{0:yyyy-MM-dd } " />
                            <asp:BoundField DataField="Duedate" DataFormatString="{0:yyyy-MM-dd } " HeaderText="到期日期" />
                            <asp:BoundField DataField="DaysLeft" HeaderText="剩余到期天数" />
                            <asp:BoundField DataField="HSFReport_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Time" HeaderText="录入日期" Visible="true" DataFormatString="{0:yyyy-MM-dd } "  />
                            <asp:BoundField DataField="HSFReport_Note" HeaderText="备注" Visible="true"  />

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down" runat="server" NavigateUrl='<%#"~/"+Eval("HSFReport_Url")%>' >下载报告</asp:HyperLink >
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    
                    </asp:GridView>
                    <table style="text-align: left; width: 100%;">
           
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

