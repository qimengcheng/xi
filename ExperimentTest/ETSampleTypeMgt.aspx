<%@ Page Title="样品类型维护" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" 
CodeFile="ETSampleTypeMgt.aspx.cs" Inherits="ExperimentTest_ETExpSampleMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>样品类型检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="样品类型："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtSampleType" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right" colspan="2">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" 
                                    onclick="BtnSearch_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" 
                                    onclick="BtnNew_Click" Text="新增样品类型" Width="90px" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" 
                                    onclick="BtnReset_Click" Text="重置" Visible="true" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SampleType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SampleType" runat="server">
                <fieldset>
                    <legend>样品类型列表</legend>
                    <asp:GridView ID="Grid_SampleType" runat="server" 
                        DataKeyNames="EST_SampleTypeID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" GridLines="None"
                        UseAccessibleHeader="False" onpageindexchanging="Grid_SampleType_PageIndexChanging" 
                        onrowcommand="Grid_SampleType_RowCommand" EnableViewState="False" 
                        ondatabound="Grid_SampleType_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EST_SampleTypeID" HeaderText="样品类型ID" SortExpression="EST_SampleTypeID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EST_SampleType" HeaderText="样品类型" SortExpression="EST_SampleType" Visible="true">
                                <HeaderStyle Width="60%" />
                                <ItemStyle Width="60%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EST_IsDeleted" HeaderText="是否删除" SortExpression="EST_IsDeleted" Visible="false">
                                <ItemStyle />
                            </asp:BoundField> 

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Sampletype" runat="server" CommandArgument='<%#Eval("EST_SampleTypeID")%>'
                                        CommandName="Edit_Sampletype" OnClientClick="false">编辑</asp:LinkButton>
                                <ItemStyle Width="20%" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Sampletype" runat="server" CommandName="Delete_Sampletype"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("EST_SampleTypeID")%>'>删除</asp:LinkButton>
                                <ItemStyle Width="20%" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
    <asp:UpdatePanel ID="UpdatePanel_NewSampletype" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewSampletype" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="LblNewSampletype" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="样品类型:"></asp:Label>
                                <asp:Label ID="LblState" runat="server" Text="1" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 80%" align="left">
                                <asp:TextBox ID="TxtNewSampletype" runat="server" Width="200px" MaxLength="25"></asp:TextBox>
                                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td  align="right">
                            <asp:Button ID="BtnSubmit"  runat="server" Text="提交" CssClass="Button02" Height="24px"
                                Width="70px" onclick="BtnSubmit_Click" />
                            </td>
                            <td></td>
                            <td  align="left">
                            <asp:Button ID="BtnCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                Visible="true" Width="70px" onclick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
