<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="EMEquipUnusedApp.aspx.cs" Inherits="EquipMgt_EMEquipUnusedApp"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <%--报废检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Label ID="Lab_Status" runat="server"  Visible="False"></asp:Label>
            <asp:Panel ID="Panel_Search" runat="server" UpdateMode="Conditional">
            <fieldset>
                <legend>设备报废情况检索</legend>
                <asp:Panel ID="Panel14" runat="server" UpdateMode="Conditional">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Lbltype" runat="server" Text="设备类型："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="130px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label1" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="Textname" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label2" runat="server" Text="设备型号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="Textmodel" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="Textno" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="使用年限(年)："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextUseYear" runat="server" Width="130px" Height="20px" 
                            onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/^[0-9]*$'))" 
                            onKeyUp="value=value.replace(/[^\d]/g,'')"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label7" runat="server" Text="申请单编号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextAppNO" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td  align="right">
                            <asp:Label ID="Label5" runat="server" Text="申请人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextAppPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label6" runat="server" Text="申请时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextAppTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                 Text='<%# Eval("EUA_AppTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" Text="申请单状态："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="待提交" Value="待提交"></asp:ListItem>
                                <asp:ListItem Text="已提交" Value="已提交"></asp:ListItem>
                                <asp:ListItem Text="审批通过" Value="审批通过"></asp:ListItem>
                                <asp:ListItem Text="审批驳回" Value="审批驳回"></asp:ListItem>
                                <asp:ListItem Text="总经理批准" Value="总经理批准"></asp:ListItem>
                                <asp:ListItem Text="总经理驳回" Value="总经理驳回"></asp:ListItem>
                                <asp:ListItem Text="已完成" Value="已完成"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel7" runat="server" >
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width: 15%">
                            <asp:Label ID="Label9" runat="server" Text="审批部门："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextApprover" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 12%">
                            <asp:Label ID="Label21" runat="server" Text="审批时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextApprovalT" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUA_ApprovalT","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td  align="right" style="width: 12%">
                            <asp:Label ID="Label31" runat="server" Text="审批结果："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="通过" Value="通过"></asp:ListItem>
                                <asp:ListItem Text="不通过" Value="不通过"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                     </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel11" runat="server"  >
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width: 15%">
                            <asp:Label ID="Label32" runat="server" Text="报废处理人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextDealPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 12%">
                            <asp:Label ID="Label33" runat="server" Text="报废处理时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextDealTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUA_DealTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd }"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 12%">
                            <asp:Label ID="Label59" runat="server" Text="总经理批准时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextAllowT" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUA_AllowT","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd }"></asp:TextBox>
                        </td>
                    </tr>
                     </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel12" runat="server"  >
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width: 30%">
                            <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" 
                                CssClass="Button02" OnClick="Btn_Search_Click" Height="24px" />
                        </td>
                        <td style="width: 40%" align="center">
                            <asp:Button ID="Btn_New" runat="server" Text="新增报废申请" Width="90px" 
                                CssClass="Button02" OnClick="Btn_New_Click" Height="24px" />
                        </td>
                        <td align="left" >
                            <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Text="重置" 
                                Width="70px" OnClick="Btn_Clear_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <%--设备报废信息表--%>
    <asp:UpdatePanel ID="UpdatePanel_UnusedApp" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_UnusedApp" runat="server" UpdateMode="Conditional">
                <fieldset>
                    <legend>设备报废信息表</legend>
                    <asp:Label ID="Label_euaid" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label777" runat="server"  Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_UnusedApp" runat="server" DataKeyNames="EUA_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_UnusedApp_PageIndexChanging" OnRowCommand="Grid_UnusedApp_RowCommand"
                        OnRowDataBound="Grid_UnusedApp_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EUA_ID" HeaderText="设备报废申请ID" ReadOnly="True" SortExpression="EUA_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EI_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETT_Type" HeaderText="设备类型" ReadOnly="True" SortExpression="ETT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" ReadOnly="True" SortExpression="EN_EquipName">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_Type" HeaderText="设备型号" ReadOnly="True" SortExpression="EMT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_No" HeaderText="设备编号" ReadOnly="True" SortExpression="EI_No">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUA_UseYear" HeaderText="使用年限(年)" ReadOnly="True" SortExpression="EUA_UseYear">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EUA_AppPer" HeaderText="申请人" ReadOnly="True" SortExpression="EUA_AppPer">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EUA_AppTime" HeaderText="申请时间">
                                <ItemTemplate>
                                    <asp:Label ID="EUA_AppTime" runat="server" Text='<%# Eval("EUA_AppTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EUA_Reason" HeaderText="报废原因" SortExpression="EUA_Reason" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUA_AppNO" HeaderText="申请单编号" SortExpression="EUA_AppNO">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EUA_AppState" HeaderText="申请单状态" SortExpression="EUA_AppState">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUA_Approver" HeaderText="审批人" SortExpression="EUA_Approver">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EUA_ApprovalT" HeaderText="审批时间">
                                <ItemTemplate>
                                    <asp:Label ID="EUA_ApprovalT" runat="server" Text='<%# Eval("EUA_ApprovalT","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EUA_ApprovalSugg" HeaderText="审批意见" SortExpression="EUA_ApprovalSugg" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUA_ApprovalRes" HeaderText="审批结果" SortExpression="EUA_ApprovalRes">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EUA_DealPer" HeaderText="报废处理人" SortExpression="EUA_DealPer">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EUA_DealTime" HeaderText="报废处理时间">
                                <ItemTemplate>
                                    <asp:Label ID="EUA_DealTime" runat="server" Text='<%# Eval("EUA_DealTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","
                                +Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EUA_UseYear")+","+Eval("EUA_AppPer")+","+Eval("EUA_AppTime")+","+Eval("EUA_Reason")
                                +","+Eval("EUA_AppNO")+","+Eval("EUA_AppState")+","+Eval("EUA_Approver")+","+Eval("EUA_ApprovalT")+","+Eval("EUA_ApprovalSugg")+","
                                +Eval("EUA_ApprovalRes")+","+Eval("EUA_DealPer")+","+Eval("EUA_DealTime")+","+Eval("EUA_Approver2")+","+Eval("EUA_ApprovalT2")+","+Eval("EUA_ApprovalSugg2")+","
                                +Eval("EUA_ApprovalRes2")+","+Eval("EUA_Allower")+","+Eval("EUA_AllowT")+","+Eval("EUA_AllowSugg")+","
                                +Eval("EUA_AllowRes")%>' CommandName="Look1"
                                        OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandArgument='<%#Eval("EUA_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","
                                +Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EUA_UseYear")+","+Eval("EUA_AppPer")+","+Eval("EUA_AppTime")+","+Eval("EUA_Reason")
                                +","+Eval("EUA_AppNO")+","+Eval("EUA_AppState")%>' CommandName="Edit1" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Approval1" runat="server" CommandArgument='<%#Eval("EUA_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","
                                +Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EUA_UseYear")+","+Eval("EUA_AppPer")+","+Eval("EUA_AppTime")+","+Eval("EUA_Reason")
                                +","+Eval("EUA_AppNO")+","+Eval("EUA_AppState")+","+Eval("EUA_Approver")+","+Eval("EUA_ApprovalT")+","+Eval("EUA_ApprovalSugg")+","
                                +Eval("EUA_ApprovalRes")+","+Eval("EUA_Approver2")+","+Eval("EUA_ApprovalT2")+","+Eval("EUA_ApprovalSugg2")+","
                                +Eval("EUA_ApprovalRes2")%>' CommandName="Approval1" OnClientClick="false">审批</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Deal1" runat="server" CommandArgument='<%#Eval("EUA_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","
                                +Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EUA_UseYear")+","+Eval("EUA_AppPer")+","+Eval("EUA_AppTime")+","+Eval("EUA_Reason")
                                +","+Eval("EUA_AppNO")+","+Eval("EUA_AppState")+","+Eval("EUA_Approver")+","+Eval("EUA_ApprovalT")+","+Eval("EUA_ApprovalSugg")+","
                                +Eval("EUA_ApprovalRes")+","+Eval("EUA_Approver2")+","+Eval("EUA_ApprovalT2")+","+Eval("EUA_ApprovalSugg2")+","
                                +Eval("EUA_ApprovalRes2")+","+Eval("EUA_Allower")+","+Eval("EUA_AllowT")+","+Eval("EUA_AllowSugg")+","
                                +Eval("EUA_AllowRes")%>' CommandName="Deal1" OnClientClick="false">报废处理</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EUA_ID")+","+Eval("EUA_AppState")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle  />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Allow1" runat="server" CommandArgument='<%#Eval("EUA_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","
                                +Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EUA_UseYear")+","+Eval("EUA_AppPer")+","+Eval("EUA_AppTime")+","+Eval("EUA_Reason")
                                +","+Eval("EUA_AppNO")+","+Eval("EUA_AppState")+","+Eval("EUA_Approver")+","+Eval("EUA_ApprovalT")+","+Eval("EUA_ApprovalSugg")+","
                                +Eval("EUA_ApprovalRes")+","+Eval("EUA_Approver2")+","+Eval("EUA_ApprovalT2")+","+Eval("EUA_ApprovalSugg2")+","
                                +Eval("EUA_ApprovalRes2")%>' CommandName="Allow1" OnClientClick="false">批准</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
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
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <%--增加报废申请时，首先查询并选择已有的设备--%>
    <asp:UpdatePanel ID="UpdatePanel_searchInf" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_searchInf" runat="server" Visible="false">
                <fieldset>
                    <legend>选择设备台账</legend>
                    <asp:Label ID="Label_eiid" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_type" runat="server"   Visible="False"></asp:Label>
                    <asp:Label ID="Label_name" runat="server"   Visible="False"></asp:Label>
                    <asp:Label ID="Label_model" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_no" runat="server"   Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 22%" align="right">
                                <asp:Label ID="Label12" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 19%">
                                <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 17%" align="right">
                                <asp:Label ID="Label13" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox2" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox3" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox4" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td >
                                <asp:Button ID="Search_info" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_info_Click" Height="24px" />
                            </td>
                            <td >
                                <asp:Button ID="Clear_info" runat="server" CssClass="Button02" OnClick="Clear_info_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                            <td >
                                <asp:Button ID="Close_info" runat="server" CssClass="Button02" OnClick="Close_info_Click"
                                    Text="关闭" Width="70px" Height="24px" />
                            </td>
                        </tr>
                    </table>
                    <%--   设备台账列表--%>
                    <asp:GridView ID="Grid_EquipInfo" runat="server" DataKeyNames="EI_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%" PageSize="5"
                        AllowPaging="True" Font-Strikeout="False" UseAccessibleHeader="False" OnPageIndexChanging="Grid_EquipInfo_PageIndexChanging"
                        OnRowCommand="Grid_EquipInfo_RowCommand" OnRowDataBound="Grid_EquipInfo_RowDataBound"
                        GridLines="None">
                       <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EI_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EI_ID"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETT_Type" HeaderText="设备类型" ReadOnly="True" SortExpression="ETT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_Type" HeaderText="设备型号" SortExpression="EMT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_No" HeaderText="设备编号" SortExpression="EI_No">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_Location" HeaderText="设备位置" SortExpression="EI_Location">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EI_AcceptDate" HeaderText="验收日期">
                            <ItemTemplate>
                                <asp:Label ID="EI_AcceptDate" runat="server" Text='<%# Eval("EI_AcceptDate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="EI_State" HeaderText="设备状态" SortExpression="EI_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add_UnusedApp" runat="server" CommandName="Add_UnusedApp" OnClientClick="false"
                                        CommandArgument='<%#Eval("EI_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EI_AcceptDate")%>'>
                                        新增报废申请</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
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
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <%--新增报废申请--%>
    <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_New" runat="server" Visible="False">
                <fieldset>
                    <legend>报废申请单</legend>
                    <asp:Panel ID="Panel8" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label14" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <%--<asp:DropDownList ID="DropDownList5" runat="server" Height="20px" Width="120px" Enabled="false">
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="Textaddtype" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label15" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="Textaddname" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label17" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textaddmodel" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label18" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textaddno" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label19" runat="server" Text="使用年限(年)："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textaddyear" runat="server" Width="130px" Height="20px"  MaxLength="16"
                                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" ></asp:TextBox>
                                <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textaddyear" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label20" runat="server" Text="申请单编号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textaddappno" runat="server" Width="130px" Height="20px" MaxLength="50" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label22" runat="server" Text="申请人："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textaddperson" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textaddperson" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label23" runat="server" Text="申请时间："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textaddtime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                    Text='<%# Eval("EUA_AppTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textaddtime" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                            </td>
                            <td >
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label25" runat="server" Text="报废原因：<br/>(250字内)"></asp:Label>
                            </td>
                            <td colspan="5" >
                                <asp:TextBox ID="Textaddres" runat="server" Width="628px" Height="80px" TextMode="MultiLine"
                                    MaxLength="250" onfocus="annotation('Label52');" 
                                    onblur="javascript:leave('Label52');"></asp:TextBox>
                                <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textaddres" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel9" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Button ID="Button1" runat="server" Text="保存" Width="70px" 
                                    CssClass="Button02" OnClick="Btn_Save_Click" ValidationGroup="addvalidation" 
                                    Height="24px"/>
                            </td>
                            <td style="height: 16px; " colspan="2" align="center">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Text="提交" 
                                    Width="70px" OnClick="Btn_Submit_Click" ValidationGroup="addvalidation" 
                                    Height="24px"/>
                            </td>
                            <td style="height: 16px;" colspan="2" align="left">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Btn_Cancel_Click" Height="24px" />
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel10" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="right" colspan="2" >
                                <asp:Button ID="Button4" runat="server" Text="保存" Width="70px" 
                                    CssClass="Button02" OnClick="Btn_Save_Click1" ValidationGroup="addvalidation" 
                                    Height="24px"/>
                            </td>
                            <td style="height: 16px; " colspan="2" align="center">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Text="提交" 
                                    Width="70px" OnClick="Btn_Submit_Click1" ValidationGroup="addvalidation" 
                                    Height="24px"/>
                            </td>
                            <td style="height: 16px;" colspan="2" align="left">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Btn_Cancel_Click1" Height="24px" />
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
<%--查看报废详情--%>
    <asp:UpdatePanel ID="UpdatePanel_Look" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Look" runat="server" Visible="False">
                <fieldset>
                    <legend>报废申请详情</legend>
                    <asp:Label ID="Label57" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label58" runat="server"  Visible="False"></asp:Label>
                    <asp:Panel ID="Panel1" runat="server">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label24" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="Textlooktype" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width:  12%" align="right">
                                <asp:Label ID="Label26" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width:  20%">
                                <asp:TextBox ID="Textlookname" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width:  10%" align="right">
                                <asp:Label ID="Label27" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textlookmodel" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td  align="right">
                                <asp:Label ID="Label28" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textlookno" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td  align="right">
                                <asp:Label ID="Label29" runat="server" Text="使用年限(年)："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textlookyear" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label30" runat="server" Text="申请单编号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textlookappno" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td  align="right">
                                <asp:Label ID="Label34" runat="server" Text="申请人："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textlookper" runat="server" Width="130px" Height="20px" ></asp:TextBox>
                            </td>
                            <td  align="right">
                                <asp:Label ID="Label35" runat="server" Text="申请时间："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textlooktime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                    Text='<%# Eval("EUA_AppTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                            </td>
                            <td  align="right">
                                <asp:Label ID="Label37" runat="server" Text="申请单状态："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="Textlooksta" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  align="right">
                                <asp:Label ID="Label36" runat="server" Text="报废原因：<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5" >
                                <asp:TextBox ID="Textlookres" runat="server" Width="89%" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onfocus="annotation('Label52');" 
                                    onblur="javascript:leave('Label52');"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="right" style="width: 15%" >
                                <asp:Label ID="Label38" runat="server" Text="审批人："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="Textlookapper" runat="server" Width="130px" Height="20px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textlookapper" ValidationGroup="updatevalidation_sp"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right" style="width: 12%" >
                                <asp:Label ID="Label39" runat="server" Text="审批时间："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="Textlookapptime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                     Text='<%# Eval("EUA_ApprovalT","{0:yyyy-MM-dd HH:mm:ss}") %>'  DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textlookapptime" ValidationGroup="updatevalidation_sp"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td  align="right" style="width: 10%" >
                                <asp:Label ID="Label40" runat="server" Text="审批结果："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Textlookappre" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  align="right">
                                <asp:Label ID="Label41" runat="server" Text="审批意见：<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5" >
                                <asp:TextBox ID="Textlookappsug" runat="server" Width="89%" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onfocus="annotation('Label52');" onblur="javascript:leave('Label52');"></asp:TextBox>
                                <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" style="width: 15%" >
                                <asp:Label ID="Label47" runat="server" Text="审批人："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px" Height="20px" MaxLength="10" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 12%" >
                                <asp:Label ID="Label48" runat="server" Text="审批时间："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="TextBox5" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                     Text='<%# Eval("EUA_ApprovalT2","{0:yyyy-MM-dd HH:mm:ss}") %>'  DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            </td>
                            <td  align="right" style="width: 10%" >
                                <asp:Label ID="Label49" runat="server" Text="审批结果："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  align="right">
                                <asp:Label ID="Label50" runat="server" Text="审批意见：<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5" >
                                <asp:TextBox ID="TextBox7" runat="server" Width="89%" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onfocus="annotation('Label52');" onblur="javascript:leave('Label52');"></asp:TextBox>
                                <asp:Label ID="Label51" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel13" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="right" style="width: 15%" >
                                <asp:Label ID="Label52" runat="server" Text="批准人："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="TextBox8" runat="server" Width="130px" Height="20px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textlookapper" ValidationGroup="updatevalidation_sp"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right" style="width: 12%" >
                                <asp:Label ID="Label53" runat="server" Text="批准时间："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="TextBox9" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                     Text='<%# Eval("EUA_ApprovalT","{0:yyyy-MM-dd HH:mm:ss}") %>'  DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textlookapptime" ValidationGroup="updatevalidation_sp"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td  align="right" style="width: 10%" >
                                <asp:Label ID="Label54" runat="server" Text="批准结果："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox10" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  align="right">
                                <asp:Label ID="Label55" runat="server" Text="批准意见：<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5" >
                                <asp:TextBox ID="TextBox11" runat="server" Width="89%" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onfocus="annotation('Label52');" onblur="javascript:leave('Label52');"></asp:TextBox>
                                <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel3" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  align="right" style="width: 15%" >
                                <asp:Label ID="Label42" runat="server" Text="报废处理人："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="Textlookdealper" runat="server" Width="130px" Height="20px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textlookdealper" ValidationGroup="updatevalidation_cl"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td  align="right" style="width: 12%" >
                                <asp:Label ID="Label43" runat="server" Text="报废处理时间："></asp:Label>
                            </td>
                            <td style="width: 20%" >
                                <asp:TextBox ID="Textlookdealtime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                    Text='<%# Eval("EUA_DealTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textlookdealtime" ValidationGroup="updatevalidation_cl"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td  align="right" style="width: 10%" ></td>
                            <td ></td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel4" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="height: 16px;" colspan="6" align="center">
                                <asp:Button ID="look_close" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="look_close_Click" Height="24px" />
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel5" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  align="right" colspan="2" style="width: 35%;">
                                <asp:Button ID="Approval_ok" runat="server" Text="通过" Width="70px" 
                                    CssClass="Button02" OnClick="Approval_ok_Click" 
                                    ValidationGroup="updatevalidation_sp" Height="24px"/>
                            </td>
                            <td style="height: 16px; width: 32%;" colspan="2" align="center">
                                <asp:Button ID="Approval_nok" runat="server" CssClass="Button02" Text="驳回" 
                                    Width="70px" OnClick="Approval_nok_Click" ValidationGroup="updatevalidation_sp" 
                                    Height="24px"/>
                            </td>
                            <td  align="left" colspan="2">
                                <asp:Button ID="Approval_cancel" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Approval_cancel_Click" Height="24px" />
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel6" runat="server" Visible="False">
                        <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  align="right" style="width: 35%;">
                                <asp:Button ID="deal_ok" runat="server" Text="提交" Width="70px" 
                                    CssClass="Button02" OnClick="deal_ok_Click" 
                                    ValidationGroup="updatevalidation_cl" Height="24px" />
                            </td>
                            <td style="height: 16px; width: 32%;" colspan="2" align="center"></td>
                            <td  align="left" colspan="2">
                                <asp:Button ID="deal_cancel" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="deal_cancel_Click" Height="24px" />
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>
