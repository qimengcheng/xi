<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="Laputa_UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate><asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>
                
                用户检索
            </legend>
        <table style="width: 100%" >
            <tr>
                <td style="width: 62px; text-align: right; height: 21px;" >用户名称：</td>
                <td style="height: 21px; width: 119px" >
                    <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 47px" >工号：</td>
                <td style="height: 21px; width: 125px" >
                    <asp:TextBox ID="TextBox2" runat="server" Width="89%"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 44px" >部门：</td>
                <td style="height: 21px; width: 85px;" >
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        
                      
                    </asp:DropDownList>
                </td>
                <td style="height: 21px; width: 73px;">权限名称：</td>
                <td style="height: 21px;width:124px">
                    <asp:TextBox ID="TextBox6" runat="server" Width="90%"></asp:TextBox>
                </td>
                <td style="height: 21px">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="包含已删除用户" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="right">
                    <asp:Button ID="Search" runat="server" CssClass="Button02" Text="检索" Width="66px" OnClick="Search_Click" />
                </td>
                <td  >&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="New" runat="server" CssClass="Button02" OnClick="New_Click" Text="新增" Width="66px" />
                </td>
                <td >&nbsp;</td>
                <td>
                    <asp:Button ID="reset" runat="server" CssClass="Button02" OnClick="reset_Click" Text="重置" Width="66px" />
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
            <legend>用户表 </legend>
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="15" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="UMUI_UserID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="UMUI_UserID" HeaderText="工号" Visible="True" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="UMUI_UserName" HeaderText="姓名" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="UMUI_RTXUserName" HeaderText="RTX用户名" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="所属部门" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="UMUI_UserRole" HeaderText="用户权限" Visible="true" SortExpression="PMP_ID" />
                            


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("UMUI_UserID") %>' CommandName="mod">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirm('您确认删除该用户吗?')" CommandArgument='<%# Eval("UMUI_UserID") %>' CommandName="del">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server"  OnClientClick="return confirm('您确认重置该用户密码吗?')"  CommandArgument='<%# Eval("UMUI_UserID") %>' CommandName="def">重置密码</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("UMUI_UserID") %>' CommandName="role">设置权限</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="copy" runat="server" CommandArgument='<%# Eval("UMUI_UserID") %>' CommandName="copyrole">复制他人权限</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel3" runat="server">
        <fieldset>
            <legend>
                <asp:Label ID="Label3" runat="server" Text="新增"></asp:Label>
                用户
                <asp:Label ID="code" runat="server" Text="code" Visible="False"></asp:Label>
             
                
            </legend>
       <table style="width:100%;text-align:left;">
            <tr>
                <td style="width: 10%"  >工号(用户名):</td>
                <td style="width: 15%"  >
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                </td>
                <td style="width: 5%" >
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/button/ok.gif" Visible="False" />
                </td>
                <td style="width: 7%" >用户名称:</td>
                <td style="width: 15%" >
                    <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged" ValidationGroup="C" Width="93%"></asp:TextBox>
                </td>
                <td style="width: 5%" >
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/button/ok.gif" Visible="False" />
                </td>
                <td style="width: 9%" >
                    RTX用户名:</td>
                <td style="width: 15%"  >
                    <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" OnTextChanged="TextBox5_TextChanged" ValidationGroup="C" Width="100%"></asp:TextBox>
                    </td>
                <td style="width: 5%">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/button/ok.gif" Visible="False" />
                </td>
                <td style="width: 7%" >
                    机构级别:</td>
                <td style="width: 8%" >
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 36px" ></td>
                <td align="right">
                    <asp:Button ID="SummitUser" runat="server" CssClass="Button02" OnClick="SummitUser_Click" Text="提交" Width="66px" />
                </td>
                <td style="width: 37px" >&nbsp;</td>
                <td style="width: 60px" >&nbsp;</td>
                <td align="center">
                    <asp:Button ID="CloseM" runat="server" CssClass="Button02" OnClick="CloseM_Click" Text="关闭" Width="66px" />
                </td>
                <td style="width: 35px" >
                    <asp:Label ID="flag" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td style="width: 61px" >
                    <asp:Label ID="flag2" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="flag3" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Button ID="CloseM0" runat="server" CssClass="Button02" OnClick="RTXSync_Click" Text="同步RTX用户名" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="RTXstate" runat="server" Text="normal" Visible="False"></asp:Label>
                </td>
                <td style="width: 59px" >
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td style="width: 72px" >
                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>

            </fieldset>
    </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
       
    <asp:Panel ID="Panel4" runat="server">
        <fieldset>
            <legend>
                用户权限
             
                
             
                <asp:Label ID="userid" runat="server" Text="userid" Visible="False"></asp:Label>
             
                
            </legend>
        <table style="width:100%;text-align:left;">
            <tr>
                <td style="width:15%; height: 20px;" colspan="3">
                    <fieldset>
                        <legend>系统管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>销售管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>客户关系管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>项目管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList4" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>采购管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList5" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>库存管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList6" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>工艺管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList7" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>生产基础信息管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList8" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>产能核定</legend>
                    <asp:CheckBoxList ID="CheckBoxList9" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>生产计划管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList10" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>生产过程管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList11" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>生产跟踪管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList12" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset class="hide">
                        <legend>生产问题产品处理</legend>
                    <asp:CheckBoxList ID="CheckBoxList13" runat="server" RepeatColumns="4" Width="100%" Visible="False">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>进料检验管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList14" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>实验测试管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList15" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>HSF有毒物质管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList16" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>计量器具管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList17" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>型式实验管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList18" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                   <fieldset>
                        <legend>设备管理模块</legend>
                    <asp:CheckBoxList ID="CheckBoxList20" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>人事档案管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList21" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>培训管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList22" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>薪资管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList23" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>绩效管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList24" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    <fieldset>
                        <legend>受控文件管理</legend>
                    <asp:CheckBoxList ID="CheckBoxList25" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>
                    
                       <fieldset>
                        <legend>报表服务</legend>
                    <asp:CheckBoxList ID="CheckBoxList19" runat="server" RepeatColumns="4" Width="100%">
                    </asp:CheckBoxList>
                        </fieldset>

                </td>
            </tr>
            <tr>
                <td style="width:15%; height: 20px;">
                    &nbsp;</td>
                <td style="width:15%; height: 20px;">
                    <asp:Button ID="SummitRole" runat="server" CssClass="Button02" Height="29px" OnClick="SummitRole_Click" Text="提交" Width="66px" />
                </td>
                <td style="width:15%; height: 20px;">
                    <asp:Button ID="CloseRole" runat="server" CssClass="Button02" OnClick="CloseRole_Click" Text="关闭" Width="66px" Height="29px" />
                </td>
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
            <legend>
                    
                用户检索
            </legend>
        <table style="width: 100%" >
            <tr>
                <td style="width: 62px; text-align: right; height: 21px;" >用户名称：</td>
                <td style="height: 21px; width: 119px" >
                    <asp:TextBox ID="TextBox7" runat="server" Width="90%"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 47px" >工号：</td>
                <td style="height: 21px; width: 125px" >
                    <asp:TextBox ID="TextBox8" runat="server" Width="89%"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 44px" >部门：</td>
                <td style="height: 21px; width: 85px;" >
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        
                      
                    </asp:DropDownList>
                </td>
                <td style="height: 21px; width: 73px;">权限名称：</td>
                <td style="height: 21px;width:124px">
                    <asp:TextBox ID="TextBox9" runat="server" Width="90%"></asp:TextBox>
                </td>
                <td style="height: 21px">
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="包含已删除用户" />
                </td>
            </tr>
            <tr>
                <td style="width: 62px" >
                    &nbsp;</td>
                <td style="width: 119px">
                    &nbsp;</td>
                <td style="width: 47px" >&nbsp;</td>
                <td style="width: 125px">
                    <asp:Button ID="Button1" runat="server" CssClass="Button02" 
                        OnClick="Search２_Click" Text="检索" Width="66px" />
                </td>
                <td style="width: 44px" >&nbsp;</td>
                <td style="width: 85px">
                    <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="reset_Click" Text="重置" Width="66px" />
                </td>
                <td style="width: 73px">&nbsp;</td>
                <td style="width: 124px">
                    <asp:Button ID="Close2" runat="server" CssClass="Button02" OnClick="Close2_Click" Text="关闭" Width="66px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
            </fieldset>
    </asp:Panel>
    <asp:Panel ID="Panel6" runat="server" Visible="False">
        <fieldset>
            <legend>用户表 </legend>
            <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="15" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView２_RowCommand"
                         DataKeyNames="UMUI_UserID"  OnPageIndexChanging="GridView2_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView2_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="UMUI_UserID" HeaderText="工号" Visible="True" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="UMUI_UserName" HeaderText="姓名" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="UMUI_RTXUserName" HeaderText="RTX用户名" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="所属部门" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="UMUI_UserRole" HeaderText="用户权限" Visible="true" SortExpression="PMP_ID" />
                            


                            <asp:TemplateField> 
                                <ItemTemplate>
                                    <asp:LinkButton ID="Choose" runat="server" CommandArgument='<%# Eval("UMUI_UserID") %>' CommandName="Choose">选择</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>