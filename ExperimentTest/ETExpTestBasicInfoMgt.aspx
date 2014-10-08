<%@ Page  Title="实验项目管理" Language="C#" MasterPageFile="~/Other/MasterPage.master" 
    AutoEventWireup="true" CodeFile="ETExpTestBasicInfoMgt.aspx.cs" Inherits="ExperimentTest_ETExpTestBasicInfoMgt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel_SearchExpItem" runat="server" UpdateMode="Conditional">      
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchExpItem" runat="server" >
                <fieldset>
                    <legend>实验项目检索</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="height: 16px;" align="right">
                                <asp:Label ID="LblItem" runat="server" CssClass="STYLE2" Text="测试项目:"></asp:Label>
                            </td>
                            <td style="height: 16px;" align="left">
                                <asp:TextBox ID="TxtTestItem" runat="server" Width="192px"></asp:TextBox>
                            </td>
                            <td style="height: 16px;" align="right">
                                <asp:Label ID="LblCourse" runat="server" CssClass="STYLE2" Text="测试条件:"></asp:Label>
                            </td>
                            <td style="height: 16px;" align="left">
                                <asp:TextBox ID="TxtTestCondition" runat="server" Width="192px"></asp:TextBox>
                            </td>
                            <td style="height: 16px;" align="right">
                                <asp:Label ID="LblDep" runat="server" CssClass="STYLE2" Text="实验方法:"></asp:Label>
                            </td>
                            <td style="height: 16px;" align="left">
                                <asp:TextBox ID="TxtTestMethold" runat="server" Width="192px"></asp:TextBox>
                            </td>
                        </tr>
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 5%;">
                                <asp:Label ID="LblState" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 30%;" align="right">
                                <asp:Button ID="Btn_Search_ETExpItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" OnClick="Btn_Search_ETExpItem_Click" Width="70px" />
                            </td>
                            <td  style="width: 30%;" align="center">
                                <asp:Button ID="Btn_NEW_ETExpItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增" OnClick="Btn_NEW_ETExpItem_Click" Width="70px" />
                            </td>
                            <td  style="width: 30%;" align="left">
                                <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Height="24px" 
                                Text="重置"  OnClick="Btn_Clear_Click"  Width="70px"/>
                            </td>
                            <td style="width: 5%;"></td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--<br />--%>
    <asp:UpdatePanel ID="UpdatePanel_GridViewItem" runat="server" UpdateMode="Conditional">
        
        <ContentTemplate>
            <asp:Panel ID="Panel_GridViewItem" runat="server" >
                <fieldset>
                    <legend>实验项目列表</legend>
                    <asp:GridView ID="Grid_ETTestItem" runat="server" DataKeyNames="EI_ExpItemID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_ETTestItem_PageIndexChanging"
                        OnRowCommand="Grid_ETTestItem_RowCommand" EnableViewState="False" 
                        ondatabound="Grid_ETTestItem_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EI_ExpItemID" HeaderText="实验项目ID" ReadOnly="True" SortExpression="EI_ExpItemID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_IsDeleted" HeaderText="是否删除" ReadOnly="True"  SortExpression="EI_IsDeleted" 
                            Visible="false">
                            </asp:BoundField>                            
                            <asp:BoundField DataField="EI_ExpItem" SortExpression="EI_ExpItem" HeaderText="测试项目">
                                <HeaderStyle />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ExpCondtition" SortExpression="EI_ExpCondtition" HeaderText="测试条件">
                                <HeaderStyle />
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ExpMethold" SortExpression="EI_ExpMethold" HeaderText="实验方法">
                                <HeaderStyle />
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_ExpItem" runat="server" CommandArgument='<%#Eval("EI_ExpItemID")%>'
                                        CommandName="Edt_ExpItem" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_ExpItem" runat="server" CommandName="Delete_ExpItem"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("EI_ExpItemID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
<%--    <br />--%>
    <asp:UpdatePanel ID="UpdatePanel_NewExpItem" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewExpItem" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="LblNewExpItem" runat="server" Text=""></asp:Label></legend>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td >
                                            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="1" 
                                                onmouseover="changeto()" onmouseout="changeback()">
                                                <tr>
                                                    <td height="24">
                                                        <table width="100%" style="margin-bottom: 0px" class="STYLE2">
                                                            <tr>
                                                                <td style="height: 24px" width="10%" align="right">
                                                                    <asp:Label ID="Label31" runat="server" Text="测试项目:"></asp:Label>
                                                                </td>
                                                                <td style="height: 16px" width="80%" align="left">
                                                                    <asp:TextBox ID="TxtAddTestItem" runat="server" Width="500px" MaxLength="20"></asp:TextBox>
                                                                    <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 24px" width="10%" align="right">
                                                                    <asp:Label ID="Label2" runat="server" Text="测试条件:"></asp:Label><br>
                                                                    <asp:Label ID="Label1" runat="server" Text="(100字内)"></asp:Label>
                                                                </td>
                                                                <td style="height: 24px" width="20%" align="left">
                                                                    <asp:TextBox ID="TxtAddTestCondition" runat="server"  Width="700px"
                                                                        MaxLength="100"  onkeyup="this.value = this.value.substring(0, 100)" onafterpaste="this.value = this.value.substring(0, 100)"></asp:TextBox>
                                                                        <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 24px" width="10%" align="right">
                                                                    <asp:Label ID="Label3" runat="server" Text="实验方法:"></asp:Label><br>
                                                                    <asp:Label ID="Label4" runat="server" Text="(300字内)"></asp:Label>
                                                                </td>
                                                                <td style="height: 24px" width="20%" align="left">
                                                                    <asp:TextBox ID="TxtAddTestMethold" runat="server" Width="700px" style="overflow:hidden;" 
                                                                        MaxLength="300" TextMode="MultiLine" Height="56px" onkeyup="this.value = this.value.substring(0, 300)" onafterpaste="this.value = this.value.substring(0, 300)">
                                                                    </asp:TextBox>
                                                                    <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>                                                        
                                                        <table width="100%">
                                                            <tr>
                                                                <td  width="25%">
                                                                </td>
                                                                <td  width="25%" align="center">
                                                                    <asp:Button ID="BtnOK_ETItem" runat="server" Text="提交" CssClass="Button02" 
                                                                        OnClick="BtnOK_ETItem_Click" Height="24px"  Width="70px" />
                                                                </td>
                                                                <td  width="25%" align="center">
                                                                    <asp:Button ID="BtnCancel_Info_FailureMode" runat="server" Text="关闭" CssClass="Button02"
                                                                        OnClick="BtnCancel_Info_FailureMode_Click"  Width="70px" Height="24px" />
                                                                </td>
                                                                <td  width="25%">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
