<%@ Page Title="新员工培训信息新建" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="NewEmpInfoAdd.aspx.cs" Inherits="TrainningMgt_NewEmpInfoAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSPerson" runat="server" CssClass="STYLE2" Text="新建人："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSPerson" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSStartTime" runat="server" CssClass="STYLE2" Text="新建时间："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="right">
                                <asp:TextBox ID="TxtSStartTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                            </td>
                            <td style="width: 5%" align="center">
                                <asp:Label ID="LblSEndTime" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSEndTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="培训状态："></asp:Label>
                            </td>
                            <td style="width: 10%">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待提交</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>已完成</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right" colspan="3">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="Btn_Search_Click" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="Btn_New" runat="server" CssClass="Button02" Height="24px" Text="新增培训信息"
                                    Width="90px" OnClick="Btn_New_Click" />
                            </td>
                            <td style="height: 20%" align="left" colspan="3">
                                <asp:Button ID="Btn_Reset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Btn_Reset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>新员工培训信息列表</legend>
                    <asp:GridView ID="Grid_InfoList" runat="server" DataKeyNames="NETIMT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnDataBound="Grid_InfoList_DataBound" OnPageIndexChanging="Grid_InfoList_PageIndexChanging"
                        OnRowCommand="Grid_InfoList_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETIMT_ID" HeaderText="新员工培训项目ID" ReadOnly="True" SortExpression="NETIMT_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_Person" HeaderText="新建人" SortExpression="NETIMT_Person">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_Time" HeaderText="新建时间" SortExpression="NETIMT_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_Remarks" HeaderText="备注" SortExpression="NETIMT_Remarks">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_State" HeaderText="培训状态" SortExpression="NETIMT_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LbtnLookPerson" runat="server" CommandArgument='<%#Eval("NETIMT_ID")+","+Eval("NETIMT_State")%>'
                                        CommandName="LookPerson" OnClientClick="false">查看新员工</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LbtnEditPerson" runat="server" CommandArgument='<%#Eval("NETIMT_ID")+","+Eval("NETIMT_State")%>'
                                        CommandName="EditPerson" OnClientClick="false">编辑新员工</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLookCourse" runat="server" CommandArgument='<%#Eval("NETIMT_ID")+","+Eval("NETIMT_State")%>'
                                        CommandName="LookCourse" OnClientClick="false">查看培训项目</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditCourse" runat="server" CommandArgument='<%#Eval("NETIMT_ID")+","+Eval("NETIMT_State")%>'
                                        CommandName="EditCourse" OnClientClick="false">编辑培训项目</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSubmit" runat="server" CommandArgument='<%#Eval("NETIMT_ID")+","+Eval("NETIMT_State")%>'
                                        CommandName="Submit1" OnClientClick="false">提交</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%#Eval("NETIMT_ID")+","+Eval("NETIMT_State")%>'
                                        CommandName="Edit1" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("NETIMT_ID")+","+Eval("NETIMT_State")%>'>删除</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>新员工培训信息<asp:Label ID="Label4" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="新建人："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtAddPerson" runat="server" Width="130px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="新建时间："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtAddTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;">
                                <asp:Label ID="Label66" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="备注：<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="TxtAddRemarks" runat="server" Width="600px" Height="70px" TextMode="MultiLine"
                                    onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="BtnOK" runat="server" CssClass="Button02" Height="24px" Text="确定"
                                    Width="70px" OnClick="BtnOK_Click" />
                            </td>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnCancel" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>新员工编辑栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="left">
                                <asp:Button ID="BtnAddPeople" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="新增新员工" OnClick="BtnAddPeople_Click1" />
                            </td>
                            <td style="width: 20%">
                                 <asp:Label ID="LblRecordID" runat="server" Text="" Visible="false"></asp:Label></td>
                            <td style="width: 10%" align="center">
                                &nbsp;</td>
                            <td style="width: 20%">
                                &nbsp;</td>
                            <td style="width: 10%" align="center">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <legend>新员工培训的人员列表</legend>
                                    <asp:GridView ID="GridView_PeopleIn" runat="server" DataKeyNames="NETPCT_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                                        GridLines="None" OnDataBound="GridView_PeopleIn_DataBound" OnPageIndexChanging="GridView_PeopleIn_PageIndexChanging"
                                        OnRowCommand="GridView_PeopleIn_RowCommand">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="NETPCT_ID" HeaderText="培训人员选择ID" ReadOnly="True" SortExpression="NETPCT_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField DataField="NETPCT_Name" HeaderText="姓名" SortExpression="NETPCT_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NETPCT_Sex" HeaderText="姓别" SortExpression="NETPCT_Sex">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NETPCT_Date" HeaderText="报到日期" SortExpression="NETPCT_Date" HtmlEncode="False" DataFormatString="{0:yy-MM-dd}" >
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')"
                                                        CommandArgument='<%#Eval("NETPCT_ID")%>'>删除</asp:LinkButton>
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
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="BtnSalaryRecordClose" runat="server" CssClass="Button02" Height="24px"
                                    Text="关闭" Width="70px" OnClick="BtnSalaryRecordClose_Click" />
                            </td>
                        </tr>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>新员工新增栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtAddName" runat="server" Width="130px"></asp:TextBox>
                                <asp:Label ID="LabelAddName" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="姓别："></asp:Label>
                                
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtAddSex" runat="server" Width="130px"></asp:TextBox>
                                <asp:Label ID="LabelAddSex" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="报到日期："></asp:Label>

                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtDate" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                                <asp:Label ID="LabelDate" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                       
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnAddSubmit" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" OnClick="BtnAddSubmit_Click" />
                            </td>
                            <td>
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnAddCancel" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" OnClick="BtnAddCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <fieldset>
                    <legend>已有的培训项目列表</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="left">
                                <asp:Button ID="Btn_NEW_NETItem" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_NEW_NETItem_Click" Text="新增培训项目" Width="99px" />
                                   
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_ItemIn" runat="server" DataKeyNames="NETICT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnDataBound="GridView_ItemIn_DataBound" OnPageIndexChanging="GridView_ItemIn_PageIndexChanging"
                        OnRowCommand="GridView_ItemIn_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETICT_ID" HeaderText="培训项目选择ID" ReadOnly="True" SortExpression="NETICT_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningCourse" HeaderText="培训课程" SortExpression="NETI_TraningCourse">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningType" HeaderText="培训类别" SortExpression="NETI_TraningType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="授课部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_CreditHours" HeaderText="培训学时" SortExpression="NETI_CreditHours">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_TraningCourses" runat="server" CommandName="Delete_TraningCourse"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("NETICT_ID")%>'>删除</asp:LinkButton>
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
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblRecordID2" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="height: 20%" align="center">
                            </td>
                            <td align="center" style="height: 20%">
                                <asp:Button ID="BtnClose" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="BtnClose_Click" />
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="height: 20%">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel7" runat="server" Visible="false">
                <fieldset>
                    <legend>新员工培训项目新增栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="培训课程："></asp:Label>
                            </td>
                            <td style="height: 20%">
                                <asp:TextBox ID="TxtAddCourse" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="培训类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtAddType" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="授课部门："></asp:Label>
                            </td>
                            <td style="height: 20%">
                                <asp:TextBox ID="TxtAddDep" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Label ID="Label67" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="Button6_Click" />
                            </td>
                            <td>
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Width="70px" OnClick="Button7_Click" />
                            </td>
                        </tr>
                    </table>
                    <fieldset>
                        <legend>新员工培训项目列表</legend>
                        <asp:GridView ID="GridView_ItemAll" runat="server" DataKeyNames="NETI_ID" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                            AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                            GridLines="None" OnDataBound="GridView_ItemAll_DataBound" OnPageIndexChanging="GridView_ItemAll_PageIndexChanging"
                            OnRowCommand="GridView_ItemAll_RowCommand" OnSelectedIndexChanged="GridView_ItemAll_SelectedIndexChanged">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="NETI_ID" HeaderText="新员工培训项目ID" ReadOnly="True" SortExpression="NETI_ID">
                                    <FooterStyle CssClass="hidden" />
                                    <HeaderStyle CssClass="hidden" />
                                    <ItemStyle CssClass="hidden" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NETI_TraningCourse" HeaderText="培训课程" SortExpression="NETI_TraningCourse">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="NETI_TraningType" HeaderText="培训类别" SortExpression="NETI_TraningType">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="BDOS_Name" HeaderText="授课部门" SortExpression="BDOS_Name">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="NETI_CreditHours" HeaderText="培训学时" SortExpression="NETI_CreditHours">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="NETI_IsDeleted" HeaderText="是否删除" SortExpression="NETI_IsDeleted"
                                    ReadOnly="True" Visible="false">
                                    <ItemStyle />
                                </asp:BoundField>
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
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td colspan="2" align="right">
                                <asp:CheckBox ID="CbxAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="CbxAll_CheckedChanged" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:CheckBox ID="CbxAllNO" runat="server" Text="全不选" AutoPostBack="true" OnCheckedChanged="CbxAllNO_CheckedChanged" />
                            </td>
                            <td colspan="2" align="left">
                                <asp:CheckBox ID="CbxReverse" runat="server" Text="反选" AutoPostBack="true" OnCheckedChanged="CbxReverse_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnSubmitItem" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" OnClick="BtnSubmitItem_Click" />
                            </td>
                            <td>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="BtnCancelItem" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" OnClick="BtnCancelItem_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
