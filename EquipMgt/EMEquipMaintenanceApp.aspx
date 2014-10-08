<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="EMEquipMaintenanceApp.aspx.cs" 
Inherits="EquipMgt_EMEquipMaintenanceApp"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

<%--维修检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Label ID="Lab_Status" runat="server"  Visible="False"></asp:Label>
            <fieldset>
                <legend>设备维修检索</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Lbltype" runat="server" Text="设备类型："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="130px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label1" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="Textname" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 15%" align="right">
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
                            <asp:Label ID="Label4" runat="server" Text="申请单编号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="EMA_AppNO" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label7" runat="server" Text="请修部门："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="130px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td  align="right">
                            <asp:Label ID="Label6" runat="server" Text="故障时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="EMA_BreakDownTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                 Text='<%# Eval("EMA_BreakDownTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label5" runat="server" Text="维修申请人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="EMA_AppPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" Text="故障报修时间："></asp:Label>
                        </td>
                        <td >
                             <asp:TextBox ID="EMA_AppTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                 Text='<%# Eval("EMA_AppTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    <asp:Panel ID="Panel32" runat="server" >
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td  align="right" style="width: 15%">
                            <asp:Label ID="Label31" runat="server" Text="申请单状态："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="待提交" Value="待提交"></asp:ListItem>
                                <asp:ListItem Text="已提交" Value="已提交"></asp:ListItem>
                                <asp:ListItem Text="已确认" Value="已确认"></asp:ListItem>
                                <asp:ListItem Text="已完成" Value="已完成"></asp:ListItem>
                                <asp:ListItem Text="已验收" Value="已验收"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 14%">
                            <asp:Label ID="Label9" runat="server" Text="维修接收确认人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="EMA_AckPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 15%">
                            <asp:Label ID="Label21" runat="server" Text="维修接收确认时间："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="EMA_AckTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                Text='<%# Eval("EMA_AckTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel33" runat="server" >
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width: 15%">
                            <asp:Label ID="Label32" runat="server" Text="验收人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="EMA_CheckPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 14%">
                            <asp:Label ID="Label33" runat="server" Text="验收时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="EMA_CheckTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EMA_CheckTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        <td align="right" style="width: 15%">
                            <asp:Label ID="Label10" runat="server" Text="验收结果："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="通过" Value="通过"></asp:ListItem>
                                <asp:ListItem Text="不通过" Value="不通过"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel34" runat="server" >
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width: 30%">
                            <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" 
                                CssClass="Button02" OnClick="Btn_Search_Click" Height="24px" />
                        </td>
                        <td style="width: 40%" align="center">
                            <asp:Button ID="Btn_New" runat="server" Text="新增维修申请" Width="100px" 
                                CssClass="Button02" OnClick="Btn_New_Click" Height="24px" />
                        </td>
                        <td align="left">
                            <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Text="重置" 
                                Width="70px" OnClick="Btn_Clear_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--设备维修信息表--%>
    <asp:UpdatePanel ID="UpdatePanel_MaintenanceApp" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MaintenanceApp" runat="server" UpdateMode="Conditional">
                <fieldset>
                    <legend>设备维修信息表</legend>
                    <asp:Label ID="Label_emaid" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_acktime" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_appno" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_appper" runat="server"  Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_MaintenanceApp" runat="server" DataKeyNames="EMA_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_MaintenanceApp_PageIndexChanging" OnRowCommand="Grid_MaintenanceApp_RowCommand"
                        OnRowDataBound="Grid_MaintenanceApp_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EMA_ID" HeaderText="故障申请单ID" ReadOnly="True" SortExpression="E,A_ID" Visible="False">
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
                            <asp:BoundField DataField="EMA_AppNO" HeaderText="申请单编号" ReadOnly="True" SortExpression="EMA_AppNO">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EMA_AppDep" HeaderText="请修部门" ReadOnly="True" SortExpression="EMA_AppDep">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EMA_BreakDownTime" HeaderText="故障时间">
                                <ItemTemplate>
                                    <asp:Label ID="EMA_BreakDownTime" runat="server" Text='<%# Eval("EMA_BreakDownTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMA_AppPer" HeaderText="维修申请人" SortExpression="EMA_AppPer">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EMA_AppTime" HeaderText="故障报修时间">
                                <ItemTemplate>
                                    <asp:Label ID="EMA_AppTime" runat="server" Text='<%# Eval("EMA_AppTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMA_AckPer" HeaderText="故障接收确认人" SortExpression="EMA_AckPer">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EMA_AckTime" HeaderText="故障接收确认时间">
                                <ItemTemplate>
                                    <asp:Label ID="EMA_AckTime" runat="server" Text='<%# Eval("EMA_AckTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMA_BDDetail" HeaderText="故障描述" SortExpression="EMA_BDDetail" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMA_AppState" HeaderText="申请单状态" SortExpression="EMA_AppState">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMA_CheckPer" HeaderText="验收人" SortExpression="EMA_CheckPer">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EMA_CheckTime" HeaderText="验收时间">
                                <ItemTemplate>
                                    <asp:Label ID="EMA_CheckTime" runat="server" Text='<%# Eval("EMA_CheckTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EMA_CheckRes" HeaderText="验收结果" SortExpression="EMA_CheckRes">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EMA_CheckSugg" HeaderText="验收意见" SortExpression="EMA_CheckSugg" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("EMA_AppDep")+","+Eval("EMA_BreakDownTime")+","+Eval("EMA_AppPer")+","+Eval("EMA_AppTime")
                                    +","+Eval("EMA_BDDetail")+","+Eval("EMA_AppState")+","+Eval("EMA_AppNO")+","+Eval("EMA_AckPer")+","+Eval("EMA_AckTime")
                                    +","+Eval("EMA_CheckPer")+","+Eval("EMA_CheckTime")+","+Eval("EMA_CheckRes")+","+Eval("EMA_CheckSugg")+","+Eval("EMA_ID")%>' 
                                    CommandName="Look1" OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandArgument='<%#Eval("EMA_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")
                                    +","+Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EMA_AppDep")+","+Eval("EMA_BreakDownTime")+","
                                    +Eval("EMA_AppPer")+","+Eval("EMA_AppTime")+","+Eval("EMA_BDDetail")+","+Eval("EMA_AppState")+","+Eval("EMA_AppNO")%>' 
                                    CommandName="Edit1" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Ack1" runat="server" CommandArgument='<%#Eval("EMA_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")
                                    +","+Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EMA_AppDep")+","+Eval("EMA_BreakDownTime")+","
                                    +Eval("EMA_AppPer")+","+Eval("EMA_AppTime")+","+Eval("EMA_BDDetail")+","+Eval("EMA_AppState")+","+Eval("EMA_AppNO")%>' 
                                    CommandName="Ack1" OnClientClick="false">接收确认</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="Deal1" runat="server" CommandArgument='<%#Eval("EMA_ID")+","+Eval("EMA_AckTime")%>' 
                                    CommandName="Deal1" OnClientClick="false"  >填写维修情况</asp:LinkButton>--%>
                                    <asp:LinkButton ID="Deal1" runat="server" CommandArgument='<%#Eval("EMA_ID")+","+Eval("EMA_AckTime")+","+Eval("EMA_AppNO")+","+Eval("EMA_AppPer")%>' 
                                    CommandName="Deal1" OnClientClick="false"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check1" runat="server" CommandArgument='<%#Eval("EMA_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")
                                    +","+Eval("EMT_Type")+","+Eval("EI_No")+","+Eval("EMA_AppDep")+","+Eval("EMA_BreakDownTime")+","
                                    +Eval("EMA_AppPer")+","+Eval("EMA_AppTime")+","+Eval("EMA_BDDetail")+","+Eval("EMA_AppState")+","+Eval("EMA_AppNO")
                                    +","+Eval("EMA_AckPer")+","+Eval("EMA_AckTime")%>' 
                                    CommandName="Check1" OnClientClick="false">维修验收</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EMA_ID")+","+Eval("EMA_AppState")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle  />
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
                                        <asp:TextBox ID="textbox1" runat="server" Width="20px"></asp:TextBox>
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

<%--真实维修情况--%>
    <asp:UpdatePanel ID="UpdatePanel_CN" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CN" runat="server" UpdateMode="Conditional" Visible="false">
                <fieldset>
                <legend>真实维修情况</legend>
                <asp:Label ID="Label_erdaoaid" runat="server"  Visible="False"></asp:Label>
                <asp:Label ID="Label_emt" runat="server"  Visible="False"></asp:Label>
                <asp:Label ID="Label94" runat="server"  Visible="False" Text="设备全部维修完毕后,请点击提交！" ForeColor="Red"></asp:Label>
                <fieldset>
                    <legend>厂内维修信息表</legend>
                       <asp:Button ID="choosereal" runat="server" Text="选择厂内维修设备" Width="120px" 
                        CssClass="Button02" OnClick="choosereal_Click" Height="24px" />
                    <asp:GridView ID="GridView_CN" runat="server" DataKeyNames="ERDAOA_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="GridView_CN_PageIndexChanging" OnRowCommand="GridView_CN_RowCommand"
                        OnRowDataBound="GridView_CN_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="ERDAOA_ID" HeaderText="真实故障信息ID" ReadOnly="True" SortExpression="ERDAOA_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EI_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EMT_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMA_ID" HeaderText="故障申请单ID" ReadOnly="True" SortExpression="EMA_ID" Visible="False">
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
                            <asp:BoundField DataField="ERDAOA_MaintPer" HeaderText="维修人" ReadOnly="True" SortExpression="ERDAOA_MaintPer">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_StartTime" HeaderText="维修开始时间">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_StartTime" runat="server" Text='<%# Eval("ERDAOA_StartTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="ERDAOA_EndTime" HeaderText="维修结束时间">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_EndTime" runat="server" Text='<%# Eval("ERDAOA_EndTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_ReasonMethod" HeaderText="故障原因及解决办法" SortExpression="ERDAOA_ReasonMethod"  Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_Remarks" HeaderText="备注" SortExpression="ERDAOA_Remarks"  Visible="False">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look_CN" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_MaintPer")+","+Eval("ERDAOA_StartTime")+","+Eval("ERDAOA_EndTime")+","+Eval("ERDAOA_ReasonMethod")
                                    +","+Eval("ERDAOA_Remarks")+","+Eval("EMT_ID")+","+Eval("ERDAOA_ID")%>' CommandName="Look_CN" OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="choosespare" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_MaintPer")+","+Eval("ERDAOA_StartTime")+","+Eval("ERDAOA_EndTime")+","+Eval("ERDAOA_ReasonMethod")
                                    +","+Eval("ERDAOA_Remarks")+","+Eval("EMT_ID")+","+Eval("ERDAOA_ID")%>' 
                                    CommandName="choosespare" OnClientClick="false">记录详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_CN" runat="server" CommandName="Delete_CN" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("ERDAOA_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle  />
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
                                        <asp:TextBox ID="textbox3" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </fieldset>
                <fieldset>
                    <legend>出厂维修信息表</legend>
                        <asp:Button ID="choosereal_cc" runat="server" Text="选择出厂维修设备" Width="120px" 
                        CssClass="Button02" OnClick="choosereal_cc_Click" Height="24px" />
                    <asp:GridView ID="GridView_CC" runat="server" DataKeyNames="ERDAOA_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="GridView_CC_PageIndexChanging" OnRowCommand="GridView_CC_RowCommand"
                        OnRowDataBound="GridView_CC_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="ERDAOA_ID" HeaderText="真实故障信息ID" ReadOnly="True" SortExpression="ERDAOA_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EI_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EMT_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMA_ID" HeaderText="故障申请单ID" ReadOnly="True" SortExpression="EMA_ID" Visible="False">
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
                            <asp:BoundField DataField="ERDAOA_OMaintAppNO" HeaderText="出厂维修申请单号" ReadOnly="True" SortExpression="ERDAOA_OMaintAppNO">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_OAppDep" HeaderText="出厂申请部门" ReadOnly="True" SortExpression="ERDAOA_OAppDep">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_OAppPer" HeaderText="出厂维修申请人" ReadOnly="True" SortExpression="ERDAOA_OAppPer">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_OAppTime" HeaderText="出厂申请时间">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_OAppTime" runat="server" Text='<%# Eval("ERDAOA_OAppTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_OAppState" HeaderText="出厂申请单状态" ReadOnly="True" SortExpression="ERDAOA_OAppState">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_OMaintePlace" HeaderText="出厂维修地点" ReadOnly="True" SortExpression="ERDAOA_OMaintePlace">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_Feature" HeaderText="基本特征" ReadOnly="True" SortExpression="ERDAOA_Feature" Visible="false">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_OReson" HeaderText="出厂原因" ReadOnly="True" SortExpression="ERDAOA_OReson" Visible="false">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_Approver" HeaderText="出厂申请审批人" ReadOnly="True" SortExpression="ERDAOA_Approver">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_ApprovalT" HeaderText="出厂申请审批时间">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_ApprovalT" runat="server" Text='<%# Eval("ERDAOA_ApprovalT","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_ApprovalSugg" HeaderText="出厂申请审批意见" SortExpression="ERDAOA_ApprovalSugg" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_ApprovalRes" HeaderText="出厂申请审批结果" SortExpression="ERDAOA_ApprovalRes">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_ExpectODate" HeaderText="预计出厂日期">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_ExpectODate" runat="server" Text='<%# Eval("ERDAOA_ExpectODate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="ERDAOA_ExpectIDate" HeaderText="预计回厂日期">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_ExpectIDate" runat="server" Text='<%# Eval("ERDAOA_ExpectIDate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_ExpectCost" HeaderText="预计费用" SortExpression="ERDAOA_ExpectCost">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_PerInCharge" HeaderText="负责人" SortExpression="ERDAOA_PerInCharge">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_RecordDate" HeaderText="记录日期">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_RecordDate" runat="server" Text='<%# Eval("ERDAOA_RecordDate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_FinanPer" HeaderText="财务审核人" SortExpression="ERDAOA_FinanPer">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_FinanTime" HeaderText="财务审核时间">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_FinanTime" runat="server" Text='<%# Eval("ERDAOA_FinanTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_FinanSugg" HeaderText="财务审核意见" SortExpression="ERDAOA_FinanSugg" Visible="false">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_FinanRes" HeaderText="财务审核结果" SortExpression="ERDAOA_FinanRes">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_OConfirmor" HeaderText="出厂确认人" SortExpression="ERDAOA_OConfirmor">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_OCTime" HeaderText="出厂确认时间" >
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_OCTime" runat="server" Text='<%# Eval("ERDAOA_OCTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="ERDAOA_ActODate" HeaderText="实际出厂时间">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_ActODate" runat="server" Text='<%# Eval("ERDAOA_ActODate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="ERDAOA_ActIDate" HeaderText="实际回厂日期">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_ActIDate" runat="server" Text='<%# Eval("ERDAOA_ActIDate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_ActCost" HeaderText="实际维修费用" SortExpression="ERDAOA_ActCost">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ERDAOA_PerfectPer" HeaderText="完善人" SortExpression="ERDAOA_PerfectPer">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_PerfectTime" HeaderText="完善时间" >
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_PerfectTime" runat="server" Text='<%# Eval("ERDAOA_PerfectTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ERDAOA_FinanConfirmor" HeaderText="财务确认人" SortExpression="ERDAOA_FinanConfirmor">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="ERDAOA_FCTime" HeaderText="财务确认时间">
                                <ItemTemplate>
                                    <asp:Label ID="ERDAOA_FCTime" runat="server" Text='<%# Eval("ERDAOA_FCTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look_CC" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")+","+Eval("ERDAOA_ID")
                                    +","+Eval("ERDAOA_Approver")+","+Eval("ERDAOA_ApprovalT")+","+Eval("ERDAOA_ApprovalSugg")+","+Eval("ERDAOA_ApprovalRes")
                                    +","+Eval("ERDAOA_ExpectODate")+","+Eval("ERDAOA_ExpectIDate")+","+Eval("ERDAOA_ExpectCost")+","+Eval("ERDAOA_PerInCharge")+","+Eval("ERDAOA_RecordDate")
                                    +","+Eval("ERDAOA_FinanPer")+","+Eval("ERDAOA_FinanTime")+","+Eval("ERDAOA_FinanSugg")+","+Eval("ERDAOA_FinanRes")
                                    +","+Eval("ERDAOA_OConfirmor")+","+Eval("ERDAOA_OCTime")+","+Eval("ERDAOA_ActODate")+","+Eval("ERDAOA_ActCost")+","+Eval("ERDAOA_ActIDate")
                                    +","+Eval("ERDAOA_PerfectPer")+","+Eval("ERDAOA_PerfectTime")+","+Eval("ERDAOA_FinanConfirmor")+","+Eval("ERDAOA_FCTime")%>' 
                                    CommandName="Look_CC" OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="choosespare_cc" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")
                                    +","+Eval("EMT_ID")+","+Eval("ERDAOA_ID")%>' 
                                    CommandName="choosespare_cc" OnClientClick="false">选择备件</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="App_CC" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")+","+Eval("ERDAOA_ID")%>' 
                                    CommandName="App_CC" OnClientClick="false">出厂维修审批</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Expect_CC" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")+","+Eval("ERDAOA_ID")
                                    +","+Eval("ERDAOA_Approver")+","+Eval("ERDAOA_ApprovalT")+","+Eval("ERDAOA_ApprovalSugg")+","+Eval("ERDAOA_ApprovalRes")
                                    %>' 
                                    CommandName="Expect_CC" OnClientClick="false">出厂维修预算</asp:LinkButton>
                                    <%--+","+Eval("ERDAOA_ExpectCost")+","+Eval("ERDAOA_ExpectODate")+","+Eval("ERDAOA_ExpectIDate")--%>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Finan_CC" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")+","+Eval("ERDAOA_ID")
                                    +","+Eval("ERDAOA_Approver")+","+Eval("ERDAOA_ApprovalT")+","+Eval("ERDAOA_ApprovalSugg")+","+Eval("ERDAOA_ApprovalRes")
                                    +","+Eval("ERDAOA_ExpectODate")+","+Eval("ERDAOA_ExpectIDate")+","+Eval("ERDAOA_ExpectCost")+","+Eval("ERDAOA_PerInCharge")
                                    +","+Eval("ERDAOA_RecordDate")%>' 
                                    CommandName="Finan_CC" OnClientClick="false">财务审核</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Confirmor_CC" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")+","+Eval("ERDAOA_ID")
                                    +","+Eval("ERDAOA_Approver")+","+Eval("ERDAOA_ApprovalT")+","+Eval("ERDAOA_ApprovalSugg")+","+Eval("ERDAOA_ApprovalRes")
                                    +","+Eval("ERDAOA_ExpectODate")+","+Eval("ERDAOA_ExpectIDate")+","+Eval("ERDAOA_ExpectCost")+","+Eval("ERDAOA_PerInCharge")+","+Eval("ERDAOA_RecordDate")
                                    +","+Eval("ERDAOA_FinanPer")+","+Eval("ERDAOA_FinanTime")+","+Eval("ERDAOA_FinanSugg")+","+Eval("ERDAOA_FinanRes")%>' 
                                    CommandName="Confirmor_CC" OnClientClick="false">出厂确认</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Act_CC" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")+","+Eval("ERDAOA_ID")
                                    +","+Eval("ERDAOA_Approver")+","+Eval("ERDAOA_ApprovalT")+","+Eval("ERDAOA_ApprovalSugg")+","+Eval("ERDAOA_ApprovalRes")
                                    +","+Eval("ERDAOA_ExpectODate")+","+Eval("ERDAOA_ExpectIDate")+","+Eval("ERDAOA_ExpectCost")+","+Eval("ERDAOA_PerInCharge")+","+Eval("ERDAOA_RecordDate")
                                    +","+Eval("ERDAOA_FinanPer")+","+Eval("ERDAOA_FinanTime")+","+Eval("ERDAOA_FinanSugg")+","+Eval("ERDAOA_FinanRes")
                                    +","+Eval("ERDAOA_OConfirmor")+","+Eval("ERDAOA_OCTime")%>' 
                                    CommandName="Act_CC" OnClientClick="false">完善回厂信息</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="FinanConfirmor_CC" runat="server" CommandArgument='<%#Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")
                                    +","+Eval("EI_No")+","+Eval("ERDAOA_OMaintAppNO")+","+Eval("ERDAOA_OAppDep")+","+Eval("ERDAOA_OAppPer")+","+Eval("ERDAOA_OAppTime")
                                    +","+Eval("ERDAOA_OAppState")+","+Eval("ERDAOA_OMaintePlace")+","+Eval("ERDAOA_Feature")+","+Eval("ERDAOA_OReson")+","+Eval("ERDAOA_ID")
                                    +","+Eval("ERDAOA_Approver")+","+Eval("ERDAOA_ApprovalT")+","+Eval("ERDAOA_ApprovalSugg")+","+Eval("ERDAOA_ApprovalRes")
                                    +","+Eval("ERDAOA_ExpectODate")+","+Eval("ERDAOA_ExpectIDate")+","+Eval("ERDAOA_ExpectCost")+","+Eval("ERDAOA_PerInCharge")+","+Eval("ERDAOA_RecordDate")
                                    +","+Eval("ERDAOA_FinanPer")+","+Eval("ERDAOA_FinanTime")+","+Eval("ERDAOA_FinanSugg")+","+Eval("ERDAOA_FinanRes")
                                    +","+Eval("ERDAOA_OConfirmor")+","+Eval("ERDAOA_OCTime")+","+Eval("ERDAOA_ActODate")+","+Eval("ERDAOA_ActCost")+","+Eval("ERDAOA_ActIDate")
                                    +","+Eval("ERDAOA_PerfectPer")+","+Eval("ERDAOA_PerfectTime")%>' 
                                    CommandName="FinanConfirmor_CC" OnClientClick="false">财务确认</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_CC" runat="server" CommandName="Delete_CC" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("ERDAOA_ID")+","+Eval("ERDAOA_OAppState")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle  />
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
                                        <asp:TextBox ID="textbox44" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </fieldset>
                <asp:Panel ID="Panel13" runat="server" Visible="False">
                <table style="width: 100%;">
                   <tr>  
                        <td align="right" style="width:33%">
                            <asp:Button ID="deal_ok" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="deal_ok_Click" Height="24px"  ToolTip="厂内、厂外设备全部维修完毕后提交！"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                           <asp:Button ID="close_real" runat="server" CssClass="Button02" 
                               OnClick="close_real_Click" Text="关闭" Width="70px" Height="24px" />
                       </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="Panel14" runat="server" Visible="False">
                <table style="width: 100%;">
                   <tr>  
                        <td align="center">
                            <asp:Button ID="deal_close" runat="server" Text="关闭" Width="70px" 
                                CssClass="Button02" OnClick="deal_close_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--增加厂内维修申请时，首先查询并选择已有的设备--%>
    <asp:UpdatePanel ID="UpdatePanel_searchInf" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_searchInf" runat="server" Visible="false">
                <fieldset>
                    <legend>选择设备台账</legend>
                    <asp:Label ID="Label_eiid" runat="server"  Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 23%" align="right">
                                <asp:Label ID="Label15" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:DropDownList ID="DropDownList5" runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 17%" align="right">
                                <asp:Label ID="Label13" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="infoname" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="infomodel" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label14" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="infono" runat="server" Width="150px" Height="20px"></asp:TextBox>
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
                            <asp:BoundField DataField="EI_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EI_ID" Visible="False">
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
                                    <asp:LinkButton ID="Add_MaintenanceApp" runat="server" CommandName="Add_MaintenanceApp" OnClientClick="false"
                                        CommandArgument='<%#Eval("EI_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")+","+Eval("EI_No")%>'>
                                    新增维修申请</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add_RealDetailAOApp_CN" runat="server" CommandName="Add_RealDetailAOApp_CN" OnClientClick="false"
                                        CommandArgument='<%#Eval("EI_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")+","+Eval("EI_No")%>'>
                                    填写厂内维修记录</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add_RealDetailAOApp_CC" runat="server" CommandName="Add_RealDetailAOApp_CC" OnClientClick="false"
                                        CommandArgument='<%#Eval("EI_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")+","+Eval("EI_No")%>'>
                                    申请出厂维修</asp:LinkButton>
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
                                        <asp:TextBox ID="textbox2" runat="server" Width="20px"></asp:TextBox>
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

<%--填写厂内维修记录--%>
    <asp:UpdatePanel ID="UpdatePanel_dealCN" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_dealCN" runat="server" Visible="False">
                <fieldset>
                    <legend>厂内维修记录</legend>
                    <asp:Panel ID="Panel9" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label37" runat="server" Text="设备类型："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="cntype" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label38" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="cnname" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label39" runat="server" Text="设备型号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="cnmodel" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label40" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="cnno" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label41" runat="server" Text="维修人："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="cnMaintPer" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                             ControlToValidate="cnMaintPer" ValidationGroup="cndealvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label54" runat="server" Text="维修开始时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="cnStart" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_StartTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                             ControlToValidate="cnStart" ValidationGroup="cndealvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label55" runat="server" Text="维修结束时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="cnEnd" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_EndTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                             ControlToValidate="cnEnd" ValidationGroup="cndealvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                    <td align="right" style="width: 17%"></td>
                    <td align="left" colspan="5">
                        <asp:Button ID="Btn_spare" runat="server" Text="选择备件" Width="90px" 
                            CssClass="Button02" OnClick="Btn_spare_Click" Height="24px"/>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label42" runat="server" Text="所用备件："></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:GridView ID="Grid_spare" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                        CssClass="GridViewStyle" DataKeyNames="EMSAUS_ID" Font-Strikeout="False" GridLines="None" OnPageIndexChanging="Grid_spare_PageIndexChanging" 
                        onrowcommand="Grid_spare_RowCommand" OnRowDataBound="Grid_spare_RowDataBound" PageSize="5" UseAccessibleHeader="False"  Width="90%">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EMSAUS_ID" HeaderText="备件使用记录ID" ReadOnly="True" SortExpression="EMSAUS_ID" Visible="False">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EFUS_ID" HeaderText="常用备件ID" ReadOnly="True" SortExpression="EFUS_ID" Visible="False">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="ETT_ID" HeaderText="设备型号ID" ReadOnly="True" SortExpression="ETT_ID" Visible="False">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"  Visible="False">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" SortExpression="IMMBD_MaterialCode">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SafeStock" HeaderText="安全库存" SortExpression="IMMBD_SafeStock">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIM_TotalNum" HeaderText="总数量" SortExpression="IMIM_TotalNum">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EMSAUS_UseAmount" HeaderText="使用数量" SortExpression="EMSAUS_UseAmount">
                            <ItemStyle/>
                            </asp:BoundField>            
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Delete_spare" runat="server"  CommandName="Delete_spare" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("EMSAUS_ID")%>'>删除</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle  />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex0" runat="server" 
                                            Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共<asp:Label ID="lblPageCount0" runat="server" 
                                            Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页 
                                        <asp:LinkButton ID="btnFirst0" runat="server" CausesValidation="False" 
                                            CommandArgument="First" CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev0" runat="server" CausesValidation="False" 
                                            CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext0" runat="server" CausesValidation="False" 
                                            CommandArgument="Next" CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast0" runat="server" CausesValidation="False" 
                                            CommandArgument="Last" CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox11" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo0" runat="server" CausesValidation="False" 
                                            CommandArgument="-1" CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label33" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        </asp:GridView>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td  align="right">
                            <asp:Label ID="Label43" runat="server" Text="故障原因及解决办法：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="cnReason" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');" 
                                onblur="javascript:leave('Label52');"></asp:TextBox>
                            <asp:Label ID="Label88" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                             ControlToValidate="cnReason" ValidationGroup="cndealvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <asp:Label ID="Label53" runat="server" Text="备注：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="cnRemarks" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');" 
                                onblur="javascript:leave('Label52');"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <%--厂内维修单填写的按钮--%>
                <asp:Panel ID="Panel10" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:35%">
                            <asp:Button ID="deal_cn" runat="server" Text="开始维修" Width="90px" 
                                CssClass="Button02" OnClick="deal_cn_Click" Height="24px" />
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_dealcn" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_dealcn_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--厂内维修查看的按钮--%>
                <asp:Panel ID="Panel11" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="height: 16px; " colspan="6" align="center">
                            <asp:Button ID="close_lookdealcn" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="close_lookdealcn_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <%--厂内维修单修改、选择备件后的按钮--%>
                <asp:Panel ID="Panel12" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:35%">
                            <asp:Button ID="btn_edit" runat="server" Text="完成维修" Width="90px" 
                                CssClass="Button02" OnClick="btn_edit_Click" ValidationGroup="cndealvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_edit" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_edit_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--填写出厂维修记录--%>
    <asp:UpdatePanel ID="UpdatePanel_dealCC" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_dealCC" runat="server" Visible="False">
                <fieldset>
                    <legend>出厂维修记录</legend>
                    <asp:Panel ID="Panel15" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label44" runat="server" Text="设备类型："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="cctype" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label48" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccname" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label49" runat="server" Text="设备型号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccmodel" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label50" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccno" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label51" runat="server" Text="出厂申请部门："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList7" runat="server" Height="20px" Width="130px">
                            </asp:DropDownList>
                            <asp:Label ID="Label90" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList7" ValidationGroup="ccaddvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label60" runat="server" Text="出厂维修申请人："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="ccOAppPer" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccOAppPer" ValidationGroup="ccaddvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label52" runat="server" Text="出厂申请时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccOAppTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_OAppTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccOAppTime" ValidationGroup="ccaddvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label63" runat="server" Text="出厂维修地点："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccPlace" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            <asp:Label ID="Label91" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccPlace" ValidationGroup="ccaddvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right"></td>
                        <td ></td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label56" runat="server" Text="出厂维修申请单号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccOMaintAppNO" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label61" runat="server" Text="出厂申请单状态："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccOAppState" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td align="right"></td>
                        <td ></td>
                    </tr>
                    <tr style="height: 16px;">
                        <td  align="right">
                            <asp:Label ID="Label62" runat="server" Text="基本特征：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="ccFeature" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');" 
                                onblur="javascript:leave('Label52');"></asp:TextBox>
                            <asp:Label ID="Label92" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccFeature" ValidationGroup="ccaddvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <asp:Label ID="Label64" runat="server" Text="出厂原因：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="ccOReson" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');" 
                                onblur="javascript:leave('Label52');"></asp:TextBox>
                            <asp:Label ID="Label93" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccOReson" ValidationGroup="ccaddvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel16" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr>
                    <td align="right" style="width: 15%"></td>
                    <td align="left" colspan="5">
                        <asp:Button ID="Btn_spare_cc" runat="server" Text="选择备件" Width="90px" 
                            CssClass="Button02" OnClick="Btn_spare_cc_Click" Height="24px"/>
                    </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label57" runat="server" Text="所用备件："></asp:Label>
                        </td>
                        <td align="left" colspan="5">
                            <asp:GridView ID="Grid_spare_cc" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                            CssClass="GridViewStyle" DataKeyNames="EMSAUS_ID" Font-Strikeout="False" GridLines="None" OnPageIndexChanging="Grid_spare_cc_PageIndexChanging" 
                            onrowcommand="Grid_spare_cc_RowCommand" OnRowDataBound="Grid_spare_cc_RowDataBound" PageSize="5" UseAccessibleHeader="False"  Width="90%">
                            <RowStyle CssClass="GridViewRowStyle" />  
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle  cssclass="GridViewHead"/>
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="EMSAUS_ID" HeaderText="备件使用记录ID" ReadOnly="True" SortExpression="EMSAUS_ID" Visible="False">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="EFUS_ID" HeaderText="常用备件ID" ReadOnly="True" SortExpression="EFUS_ID" Visible="False">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="ETT_ID" HeaderText="设备型号ID" ReadOnly="True" SortExpression="ETT_ID" Visible="False">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"  Visible="False">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" SortExpression="IMMBD_MaterialCode">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="IMMBD_SafeStock" HeaderText="安全库存" SortExpression="IMMBD_SafeStock">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="IMIM_TotalNum" HeaderText="总数量" SortExpression="IMIM_TotalNum">
                                <ItemStyle/>
                                </asp:BoundField>
                                <asp:BoundField DataField="EMSAUS_UseAmount" HeaderText="使用数量" SortExpression="EMSAUS_UseAmount">
                                <ItemStyle/>
                                </asp:BoundField>            
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_spare_cc" runat="server"  CommandName="Delete_spare_cc" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EMSAUS_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle  />
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="text-align: right">
                                            第<asp:Label ID="lblPageIndex0" runat="server" 
                                                Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                            页 共<asp:Label ID="lblPageCount0" runat="server" 
                                                Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                            页 
                                            <asp:LinkButton ID="btnFirst0" runat="server" CausesValidation="False" 
                                                CommandArgument="First" CommandName="Page" Text="首页" />
                                            <asp:LinkButton ID="btnPrev0" runat="server" CausesValidation="False" 
                                                CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                            <asp:LinkButton ID="btnNext0" runat="server" CausesValidation="False" 
                                                CommandArgument="Next" CommandName="Page" Text="下一页" />
                                            <asp:LinkButton ID="btnLast0" runat="server" CausesValidation="False" 
                                                CommandArgument="Last" CommandName="Page" Text="尾页" />
                                            <asp:TextBox ID="textbox55" runat="server" Width="20px"></asp:TextBox>
                                            <asp:LinkButton ID="btnGo0" runat="server" CausesValidation="False" 
                                                CommandArgument="-1" CommandName="Page" Text="GO" />
                                            <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="Label33" runat="server" Text="没有找到相关记录"></asp:Label>
                            </EmptyDataTemplate>
                            </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                  <asp:Panel ID="Panel17" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label58" runat="server" Text="出厂申请审批人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccApprover" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label94" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccApprover" ValidationGroup="ccApprovervalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label59" runat="server" Text="出厂申请审批时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccApprovalT" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_ApprovalT","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                           <%-- <asp:Label ID="Label95" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccApprovalT" ValidationGroup="ccApprovervalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label65" runat="server" Text="出厂申请审批结果："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccApprovalRes" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <asp:Label ID="Label66" runat="server" Text="出厂申请审批意见：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="ccApprovalSugg" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');"  onblur="javascript:leave('Label52');"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="Panel18" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 15%" align="right">
                        <asp:Label ID="Label69" runat="server" Text="预计出厂日期："></asp:Label>
                    </td>
                    <td style="width: 18%">
                        <asp:TextBox ID="ccExpectODate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("ERDAOA_ExpectODate","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                        <asp:Label ID="Label96" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccExpectODate" ValidationGroup="ccExpectvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td style="width: 14%" align="right">
                        <asp:Label ID="Label67" runat="server" Text="预计回厂日期："></asp:Label>
                    </td>
                    <td style="width: 18%">
                        <asp:TextBox ID="ccExpectIDate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("ERDAOA_ExpectIDate","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                        <asp:Label ID="Label97" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccExpectIDate" ValidationGroup="ccExpectvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td style="width: 14%" align="right">
                        <asp:Label ID="Label68" runat="server" Text="预计费用(元)："></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="ccExpectCost" runat="server" Width="130px" Height="20px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" 
                                onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')" MaxLength="18"></asp:TextBox>
                        <asp:Label ID="Label98" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccExpectCost" ValidationGroup="ccExpectvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label70" runat="server" Text="负责人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccPerInCharge" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label99" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccPerInCharge" ValidationGroup="ccExpectvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label71" runat="server" Text="记录日期："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccRecordDate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_RecordDate","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                           <%-- <asp:Label ID="Label100" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccRecordDate" ValidationGroup="ccExpectvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right"></td>
                        <td ></td>
                    </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel19" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label72" runat="server" Text="财务审核人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccFinanPer" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label101" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccFinanPer" ValidationGroup="ccFinanvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label73" runat="server" Text="财务审核时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccFinanTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_FinanTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label102" runat="server" Text="*" ForeColor="Red"></asp:Label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccFinanTime" ValidationGroup="ccFinanvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label74" runat="server" Text="财务审核结果："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccFinanRes" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <asp:Label ID="Label75" runat="server" Text="财务审核意见：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="ccFinanSugg" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');"  onblur="javascript:leave('Label52');"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="Panel20" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label76" runat="server" Text="出厂确认人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccOConfirmor" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label103" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccOConfirmor" ValidationGroup="ccConfirmorvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label77" runat="server" Text="出厂确认时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccOCTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_OCTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label104" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccOCTime" ValidationGroup="ccConfirmorvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right"></td>
                        <td ></td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="Panel21" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 15%" align="right">
                        <asp:Label ID="Label78" runat="server" Text="实际出厂日期："></asp:Label>
                    </td>
                    <td style="width: 18%">
                        <asp:TextBox ID="ccActODate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("ERDAOA_ActODate","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                        <asp:Label ID="Label105" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccActODate" ValidationGroup="ccActvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td style="width: 14%" align="right">
                        <asp:Label ID="Label79" runat="server" Text="实际回厂日期："></asp:Label>
                    </td>
                    <td style="width: 18%">
                        <asp:TextBox ID="ccActIDate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("ERDAOA_ActIDate","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                        <asp:Label ID="Label106" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccActIDate" ValidationGroup="ccActvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td style="width: 14%" align="right">
                        <asp:Label ID="Label80" runat="server" Text="实际维修费用(元)："></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="ccActCost" runat="server" Width="130px" Height="20px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" 
                                onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')" MaxLength="18"></asp:TextBox>
                        <asp:Label ID="Label107" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccActCost" ValidationGroup="ccActvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label81" runat="server" Text="完善人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="ccPerfectPer" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                           <%-- <asp:Label ID="Label108" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccPerfectPer" ValidationGroup="ccActvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label82" runat="server" Text="完善时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccPerfectTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_PerfectTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label109" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccPerfectTime" ValidationGroup="ccActvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right"></td>
                        <td ></td>
                    </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel22" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label83" runat="server" Text="财务确认人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccFinanConfirmor" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                           <%-- <asp:Label ID="Label110" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccFinanConfirmor" ValidationGroup="FinanConfirmorvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label84" runat="server" Text="财务确认时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="ccFCTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("ERDAOA_FCTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label111" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="*"
                                    ControlToValidate="ccFCTime" ValidationGroup="FinanConfirmorvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right"></td>
                        <td ></td>
                    </tr>
                </table>
                </asp:Panel>
                <%--出厂维修申请的按钮--%>
                <asp:Panel ID="Panel23" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:33%">
                            <asp:Button ID="deal_cc" runat="server" Text="保存" Width="70px" 
                                CssClass="Button02" OnClick="deal_cc_Click" ValidationGroup="ccaddvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_dealcc" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_dealcc_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--出厂维修修改、选择备件后的按钮--%>
                <asp:Panel ID="Panel24" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:33%">
                            <asp:Button ID="btn_editcc" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="btn_editcc_Click" 
                                ValidationGroup="ccaddvalidation" Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_editcc" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_editcc_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--出厂维修审批的按钮--%>
                <asp:Panel ID="Panel25" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" colspan="2" >
                            <asp:Button ID="Approver_ok" runat="server" Text="通过" Width="70px" 
                                CssClass="Button02" OnClick="Approver_ok_Click" 
                                ValidationGroup="ccApprovervalidation" Height="24px"/>
                        </td>
                        <td style="height: 16px; " colspan="2" align="center">
                            <asp:Button ID="Approver_notok" runat="server" CssClass="Button02" Text="驳回" 
                                Width="70px" OnClick="Approver_notok_Click" 
                                ValidationGroup="ccApprovervalidation" Height="24px"/>
                        </td>
                        <td style="height: 16px;" colspan="2" align="left">
                            <asp:Button ID="Approver_cancel" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Approver_cancel_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <%--出厂维修预计时间和费用的按钮--%>
                <asp:Panel ID="Panel26" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:33%">
                            <asp:Button ID="btn_Expect" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="btn_Expect_Click"  
                                ValidationGroup="ccExpectvalidation" Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_Expect" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_Expect_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--出厂维修财务审核的按钮--%>
                <asp:Panel ID="Panel27" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" colspan="2" >
                            <asp:Button ID="Finan_ok" runat="server" Text="通过" Width="70px" 
                                CssClass="Button02" OnClick="Finan_ok_Click"  
                                ValidationGroup="ccFinanvalidation" Height="24px"/>
                        </td>
                        <td style="height: 16px; " colspan="2" align="center">
                            <asp:Button ID="Finan_notok" runat="server" CssClass="Button02" Text="驳回" 
                                Width="70px" OnClick="Finan_notok_Click" ValidationGroup="ccFinanvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="height: 16px;" colspan="2" align="left">
                            <asp:Button ID="Finan_cancel" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Finan_cancel_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <%--出厂维修出厂确认的按钮--%>
                <asp:Panel ID="Panel28" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:33%">
                            <asp:Button ID="btn_Confirmor" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="btn_Confirmor_Click" 
                                ValidationGroup="ccConfirmorvalidation" Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_Confirmor" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_Confirmor_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--出厂维修实际时间和费用的按钮--%>
                <asp:Panel ID="Panel29" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:33%">
                            <asp:Button ID="btn_Act" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="btn_Act_Click" ValidationGroup="ccActvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_Act" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_Act_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--出厂维修财务确认的按钮--%>
                <asp:Panel ID="Panel30" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width:33%">
                            <asp:Button ID="btn_FinanConfirmor" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="btn_FinanConfirmor_Click" 
                                ValidationGroup="FinanConfirmorvalidation" Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_FinanConfirmor" runat="server" CssClass="Button02" 
                                Text="关闭" Width="70px" OnClick="Cancel_FinanConfirmor_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--出厂维修查看的按钮--%>
                <asp:Panel ID="Panel31" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="height: 16px; " colspan="6" align="center">
                            <asp:Button ID="close_lookdealcc" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="close_lookdealcc_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--选择备件--%>
      <asp:UpdatePanel ID="UpdatePanel_NewSpare" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewSpare" runat="server" Visible="False">
                <fieldset>
                    <legend>选择备件</legend>
                    <table style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 18%;">
                            <asp:Label ID="Label45" runat="server" Text="物料名称：" ></asp:Label>
                        </td>
                        <td style="width: 18%;">
                            <asp:TextBox ID="Textnewspname" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 10%;">
                            <asp:Label ID="Label46" runat="server" Text="物料编码：" ></asp:Label>
                        </td>
                        <td style="width: 18%;">
                            <asp:TextBox ID="Textnewspno" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td  align="right" style="width: 10%;">
                            <asp:Label ID="Label47" runat="server" Text="规格型号：" ></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="Textnewspmodel" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;" align="right">
                        <td >
                        <td >
                            <asp:Button ID="Search_newspare" runat="server" Text="检索" Width="70px" 
                                CssClass="Button02" onclick="Search_newspare_Click" Height="24px" />  
                        </td>
                        <td align="center"></td>
                        <td align="left" style="width: 9%">
                        </td>
                        <td align="left">
                            <asp:Button ID="Clear_newspare" runat="server" CssClass="Button02"  
                                OnClick="Clear_newspare_Click" Text="重置" Width="70px" Height="24px" /> 
                        </td>
                        <td > 
                        </td> 
                    </tr>
                    <tr>
                       <td colspan="6">
                        <asp:GridView ID="Grid_NewEquipSpare" runat="server" DataKeyNames="EFUS_ID" AllowSorting="True" 
                            AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                            AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False" 
                            OnPageIndexChanging="Grid_NewEquipSpare_PageIndexChanging" 
                            onrowcommand="Grid_NewEquipSpare_RowCommand"
                            OnRowDataBound="Grid_NewEquipSpare_RowDataBound" GridLines="None">
                            <RowStyle CssClass="GridViewRowStyle" />  
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle  cssclass="GridViewHead"/>
                            <FooterStyle CssClass="GridViewFooterStyle" />
                              <Columns>
                              <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                  <asp:CheckBox ID="ckb1" runat="server"/>
                                </ItemTemplate>
                                <ItemStyle />
                              </asp:TemplateField>
                              <asp:BoundField DataField="EFUS_ID" HeaderText="常用备件ID" ReadOnly="True" SortExpression="EFUS_ID" Visible="False">
                                <ItemStyle />
                              </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID" Visible="False">
                                <ItemStyle />
                              </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True" SortExpression="IMMBD_MaterialName">
                                <ItemStyle/>
                              </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" SortExpression="IMMBD_MaterialCode">
                                <ItemStyle/>
                              </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle/>
                              </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_SafeStock" HeaderText="安全库存" SortExpression="IMMBD_SafeStock">
                                <ItemStyle/>
                              </asp:BoundField>
                              <asp:BoundField DataField="IMIM_TotalNum" HeaderText="总数量" SortExpression="IMIM_TotalNum">
                                <ItemStyle/>
                              </asp:BoundField>
                              <asp:TemplateField HeaderText="使用数量">
                                 <ItemTemplate>
                                    <asp:TextBox id="useno" runat="server" Text="0" Width="40%" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="16"></asp:TextBox> 
                                     <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                    ControlToValidate="useno" ValidationGroup="addsparevalidation"></asp:RequiredFieldValidator>--%>
                                 </ItemTemplate>
                                 <ItemStyle/>
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
                                            <asp:TextBox ID="textbox22" runat="server" Width="20px"></asp:TextBox>
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
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="height: 30px;" align="right">
                            <asp:Button ID="BtnOK_NewSpare" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="BtnOK_NewSpare_Click" 
                                ValidationGroup="addsparevalidation" Height="24px"/>
                        </td>
                        <td style="height: 30px"></td>
                        <td></td>
                        <td style="height: 30px"align="left">
                            <asp:Button ID="BtnCancel_NewSpare" runat="server" Text="关闭" 
                                CssClass="Button02" Width="70px" OnClick="BtnCancel_NewSpare_Click" 
                                Height="24px" />
                        </td>
                        <td></td>
                    </tr>                              
                 </table>     
            </fieldset>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<%--维修申请单--%>
    <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_New" runat="server" Visible="False">
                <fieldset>
                    <legend>维修申请单</legend>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label12" runat="server" Text="设备类型："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextBox14" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label17" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextBox3" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label18" runat="server" Text="设备型号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextBox4" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label19" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextBox5" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label23" runat="server" Text="故障时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextBreakDownTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s',true)"
                                 Text='<%# Eval("EMA_BreakDownTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                            <asp:Label ID="Label85" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBreakDownTime" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label22" runat="server" Text="请修部门："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList6" runat="server" Height="20px" Width="130px">
                            </asp:DropDownList>
                            <asp:Label ID="Label86" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList6" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        
                        <td  align="right">
                            <asp:Label ID="Label24" runat="server" Text="维修申请人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextAppPer" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label87" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextAppPer" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label25" runat="server" Text="故障报修时间："></asp:Label>
                        </td>
                        <td >
                             <asp:TextBox ID="TextAppTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("EMA_AppTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:Label ID="Label88" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                             ControlToValidate="TextAppTime" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label20" runat="server" Text="申请单编号："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextAppNO" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label28" runat="server" Text="申请单状态："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextAppState" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <asp:Label ID="Label36" runat="server" Text="故障描述：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="TextBDDetail" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');" 
                                onblur="javascript:leave('Label52');"></asp:TextBox>
                            <asp:Label ID="Label89" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                             ControlToValidate="TextBDDetail" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label26" runat="server" Text="维修接收确认人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextAckPer" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                             ControlToValidate="TextAckPer" ValidationGroup="ackvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label27" runat="server" Text="维修接收确认时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextAckTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("EMA_AckTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                             ControlToValidate="TextAckTime" ValidationGroup="ackvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 12%" align="right"></td>
                        <td ></td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label29" runat="server" Text="验收人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextCheckPer" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                             ControlToValidate="TextCheckPer" ValidationGroup="checkvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%" align="right">
                            <asp:Label ID="Label30" runat="server" Text="验收时间："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextCheckTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("EMA_CheckTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                             ControlToValidate="TextCheckTime" ValidationGroup="checkvalidation"></asp:RequiredFieldValidator>--%>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label34" runat="server" Text="验收结果："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextCheckRes" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="right">
                            <asp:Label ID="Label35" runat="server" Text="验收意见：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="TextCheckSugg" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');" 
                                onblur="javascript:leave('Label52');"></asp:TextBox>
                            <asp:Label ID="Label87" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                             ControlToValidate="TextCheckSugg" ValidationGroup="checkvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <%--维修申请的按钮--%>
                    <asp:Panel ID="Panel4" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" colspan="2">
                            <asp:Button ID="Btn_Save" runat="server" Text="保存" Width="70px" 
                                CssClass="Button02" OnClick="Btn_Save_Click" ValidationGroup="addvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="height: 16px; " colspan="2" align="center">
                            <asp:Button ID="Btn_Submit" runat="server" CssClass="Button02" Text="提交" 
                                Width="70px" OnClick="Btn_Submit_Click" ValidationGroup="addvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="height: 16px;" colspan="2" align="left">
                            <asp:Button ID="Btn_Cancel" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Btn_Cancel_Click" Height="24px" />
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <%--维修申请单修改的按钮--%>
                    <asp:Panel ID="Panel5" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" colspan="2" >
                            <asp:Button ID="Btn_editSave" runat="server" Text="保存" Width="70px" 
                                CssClass="Button02" OnClick="Btn_editSave_Click" 
                                ValidationGroup="addvalidation" Height="24px"/>
                        </td>
                        <td style="height: 16px; " colspan="2" align="center">
                            <asp:Button ID="Btn_editSubmit" runat="server" CssClass="Button02" Text="提交" 
                                Width="70px" OnClick="Btn_editSubmit_Click" ValidationGroup="addvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="height: 16px;" colspan="2" align="left">
                            <asp:Button ID="Btn_editCancel" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Btn_editCancel_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <%--维修申请接收确认的按钮--%>
                <asp:Panel ID="Panel6" runat="server" Visible="False">
                  <table style="width: 100%;">
                    <tr style="height: 16px;" >
                        <td align="right" style="width:33%">
                            <asp:Button ID="btn_ack" runat="server" Text="确认" Width="70px" 
                                CssClass="Button02" OnClick="btn_ack_Click"  ValidationGroup="ackvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="width:32%"></td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_ack" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="Cancel_ack_Click" Height="24px" />
                        </td>
                    </tr>
                  </table>
                </asp:Panel>
                <%--维修申请验收的按钮--%>
                <asp:Panel ID="Panel7" runat="server" Visible="False">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" colspan="2" >
                            <asp:Button ID="check_ok" runat="server" Text="通过" Width="70px" 
                                CssClass="Button02" OnClick="check_ok_Click" ValidationGroup="checkvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="height: 16px; " colspan="2" align="center">
                            <asp:Button ID="check_notok" runat="server" CssClass="Button02" Text="驳回" 
                                Width="70px" OnClick="check_notok_Click" ValidationGroup="checkvalidation" 
                                Height="24px"/>
                        </td>
                        <td style="height: 16px;" colspan="2" align="left">
                            <asp:Button ID="check_cancel" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="check_cancel_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <%--维修申请单查看的按钮--%>
                <asp:Panel ID="Panel8" runat="server" Visible="False">
                 <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="height: 16px; " colspan="6" align="center">
                            <asp:Button ID="close_look" runat="server" CssClass="Button02" Text="关闭" 
                                Width="70px" OnClick="close_look_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>






</asp:Content>