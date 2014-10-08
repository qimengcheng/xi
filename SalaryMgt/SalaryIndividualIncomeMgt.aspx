<%@ Page Title="个人所得税基础信息维护页面" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="SalaryIndividualIncomeMgt.aspx.cs" Inherits="SalaryMgt_SalaryIndividualIncomeMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Secrch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Secrch" runat="server">
                <fieldset>
                    <legend>个税检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblASNameSearch" runat="server" CssClass="STYLE2" Text="下限值："></asp:Label>
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtASNameSearch" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="上限值："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="税率(%)："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="速算扣除数："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="right" colspan="2">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" onclick="Btn_Search_Click" />
                            </td>
                            <td style="width: 20%" align="center" colspan="2">
                                <asp:Button ID="Btn_New" runat="server" CssClass="Button02" Height="24px" Text="新增个税标准"
                                    Width="90px" onclick="Btn_New_Click" />
                            </td>
                            <td style="height: 20%" align="center">
                                <asp:Button ID="Btn_Reset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" onclick="Btn_Reset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>个人所得税标准列表</legend>
                    <asp:GridView ID="Grid_Tax" runat="server" DataKeyNames="SIIT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" onpageindexchanging="Grid_Tax_PageIndexChanging" 
                        onrowcommand="Grid_Tax_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SIIT_ID" HeaderText="SIIT_ID" SortExpression="SIIT_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SIIT_Min" HeaderText="应纳税所得额下限值" SortExpression="SIIT_Min">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SIIT_Max" HeaderText="应纳税所得额上限值" SortExpression="SIIT_Max">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SIIT_Rate" HeaderText="税率(%)" SortExpression="SIIT_Rate">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SIIT_Deduction" HeaderText="速算扣除数" SortExpression="SIIT_Deduction">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnTheEdit" runat="server" CommandArgument='<%#Eval("SIIT_ID")+","+Eval("SIIT_Min")+","+Eval("SIIT_Max")+","+Eval("SIIT_Rate")+","+Eval("SIIT_Deduction")%>'
                                        CommandName="TheEdit" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Tax" runat="server" CommandName="Delete_Tax" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SIIT_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>个税标准<asp:Label ID="Label4" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="下限值："></asp:Label>
                                <asp:Label ID="LblRecordID" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox4" runat="server" Width="130px"  MaxLength="9"
                                    onkeyup="this.value=this.value.replace(/[^\d]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label49" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="上限值："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox5" runat="server" Width="130px"  MaxLength="9"
                                    onkeyup="this.value=this.value.replace(/[^\d]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="税率(%)："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox6" runat="server" Width="100px"  MaxLength="2"
                                    onkeyup="this.value=this.value.replace(/[^\d]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>&nbsp
                                <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="0-100整数"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="速算扣除数："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox7" runat="server" Width="130px"  MaxLength="6"
                                    onkeyup="this.value=this.value.replace(/[^\d]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="right" colspan="2">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" onclick="Button1_Click" />
                            </td>
                            <td style="width: 20%" align="center" colspan="2">

                            </td>
                            <td style="height: 20%" align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" onclick="Button3_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
