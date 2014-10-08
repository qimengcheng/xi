<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="EMEquipUpkeepPlan.aspx.cs" 
Inherits="EquipMgt_EMEquipUpkeepPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <%--保养检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Label ID="Lab_Status" runat="server"  Visible="False"></asp:Label>
        <asp:Panel ID="Panel_Search" runat="server">
            <fieldset>
                <legend>设备保养计划检索</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 18%" align="right">
                            <asp:Label ID="Lbltype" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 13%">
                            <asp:TextBox ID="searchname" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label1" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td style="width: 13%">
                            <asp:TextBox ID="searchno" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label2" runat="server" Text="保养人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="searchUpkeepPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="保养预计时间(小时)："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="searchExpectTime" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="班次："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="白班" Value="白班"></asp:ListItem>
                                <asp:ListItem Text="夜班" Value="夜班"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="计划保养日期："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="searchPDate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUP_PDate","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="计划制定人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="searchPPerson" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="计划制定时间："></asp:Label>
                        </td>
                        <td >
                            <%--<asp:TextBox ID="searchMakingTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>--%>
                            <asp:TextBox ID="searchMakingTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label8" runat="server" Text="保养计划状态："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="待提交" Value="待提交"></asp:ListItem>
                                <asp:ListItem Text="已提交" Value="已提交"></asp:ListItem>
                                <asp:ListItem Text="已生成" Value="已生成"></asp:ListItem>
                                <asp:ListItem Text="保养开始" Value="保养开始"></asp:ListItem>
                                <asp:ListItem Text="已完成" Value="已完成"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
                    <asp:Panel ID="Panel9" runat="server" UpdateMode="Conditional">
                    <table style="width: 100%;">
                       <tr style="height: 16px;">
                        <td align="right"  style="width: 18%">
                            <asp:Label ID="Label9" runat="server" Text="计划生成人："></asp:Label>
                        </td>
                        <td  style="width: 13%">
                            <asp:TextBox ID="searchGeneratePer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td  align="right"  style="width: 15%">
                            <asp:Label ID="Label21" runat="server" Text="计划生成时间："></asp:Label>
                        </td>
                        <td  style="width: 13%">
                            <asp:TextBox ID="searchGenerateTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUP_GenerateTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td  align="right"  style="width: 15%">
                            <asp:Label ID="Label31" runat="server" Text="实际保养人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="searchActPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel10" runat="server" UpdateMode="Conditional">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right"  style="width: 18%">
                            <asp:Label ID="Label32" runat="server" Text="保养开始时间："></asp:Label>
                        </td>
                        <td  style="width: 13%">
                            <asp:TextBox ID="searchUStartT" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUP_UStartT","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td align="right"  style="width: 15%">
                            <asp:Label ID="Label10" runat="server" Text="保养结束时间："></asp:Label>
                        </td>
                        <td  style="width: 13%">
                            <asp:TextBox ID="searchUEndT" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUP_UEndT","{0:yyyy-MM-dd }") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td align="right"  style="width: 15%">
                        </td>
                        <td >
                        </td>
                    </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel11" runat="server" UpdateMode="Conditional">
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width: 30%;">
                            <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" 
                                CssClass="Button02" OnClick="Btn_Search_Click" Height="24px" />
                        </td>
                        <td style="width: 40%;" align="center">
                            <asp:Button ID="Btn_New" runat="server" Text="新增保养计划" Width="90px" 
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
    <%--保养打印--%>
    <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel12" runat="server" Visible="false">
            <fieldset>
                <legend>打印已生成的保养计划</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 18%" align="right">
                            <asp:Label ID="Label63" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 13%">
                            <asp:TextBox ID="TextBox3" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label64" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td style="width: 13%">
                            <asp:TextBox ID="TextBox9" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label65" runat="server" Text="保养人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextBox10" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label66" runat="server" Text="计划保养日期："></asp:Label>
                        </td>
                        <td colspan="3">
                           <asp:TextBox ID="TextBox11" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                           <asp:Label ID="Label67" runat="server" Text="至"></asp:Label>
                           &nbsp;&nbsp;&nbsp;
                           <asp:TextBox ID="TextBox20" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td align="center">
                            &nbsp;</td>
                        <td >
                            <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" 
                                OnClick="BtnPrint_Click" Text="打印" ToolTip="点击打印“已生成”的保养计划" Width="70px" />
                        </td>
                    </tr>
                    </table>
            </fieldset>
         </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--设备保养计划列表--%>
    <asp:UpdatePanel ID="UpdatePanel_EquipUpkeepPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_EquipUpkeepPlan" runat="server" UpdateMode="Conditional">
                <fieldset>
                    <legend>设备保养计划列表</legend>
                    <asp:Label ID="Label_eupid" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_eiid1" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_nid1" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_emtid" runat="server"  Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_EquipUpkeepPlan" runat="server" DataKeyNames="EUP_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%" 
                        AllowPaging="True" PageSize="15" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipUpkeepPlan_PageIndexChanging" OnRowCommand="Grid_EquipUpkeepPlan_RowCommand"
                        OnRowDataBound="Grid_EquipUpkeepPlan_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EUP_ID" HeaderText="设备保养计划ID" ReadOnly="True" SortExpression="EUP_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ID" HeaderText="设备台帐ID" ReadOnly="True" SortExpression="EI_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_ID" HeaderText="设备型号ID" ReadOnly="True" SortExpression="EMT_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" ReadOnly="True" SortExpression="EN_EquipName">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_No" HeaderText="设备编号" ReadOnly="True" SortExpression="EI_No">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUP_UpkeepPer" HeaderText="保养人" ReadOnly="True" SortExpression="EUP_UpkeepPer">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EUP_ExpectTime" HeaderText="保养预计时间(小时)" ReadOnly="True" SortExpression="EUP_ExpectTime">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EUP_Class" HeaderText="班次" SortExpression="EUP_Class" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EUP_PDate" HeaderText="计划保养日期" >
                                <ItemTemplate>
                                    <asp:Label ID="EUP_PDate" runat="server" Text='<%# Eval("EUP_PDate","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EUP_PPerson" HeaderText="计划制定人" SortExpression="EUP_PPerson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EUP_MakingTime" HeaderText="计划制定时间" >
                                <ItemTemplate>
                                    <asp:Label ID="EUP_MakingTime" runat="server" Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EUP_State" HeaderText="保养计划状态" SortExpression="EUP_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUP_GeneratePer" HeaderText="计划生成人" SortExpression="EUP_GeneratePer">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EUP_GenerateTime" HeaderText="计划生成时间">
                                <ItemTemplate>
                                    <asp:Label ID="EUP_GenerateTime" runat="server" Text='<%# Eval("EUP_GenerateTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EUP_ActPer" HeaderText="实际保养人" SortExpression="EUP_ActPer">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUP_OutPContents" HeaderText="计划外保养内容" SortExpression="EUP_OutPContents" Visible="False">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EUP_UStartT" HeaderText="保养开始时间">
                                <ItemTemplate>
                                    <asp:Label ID="EUP_UStartT" runat="server" Text='<%# Eval("EUP_UStartT","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="EUP_UEndT" HeaderText="保养结束时间">
                                <ItemTemplate>
                                    <asp:Label ID="EUP_UEndT" runat="server" Text='<%# Eval("EUP_UEndT","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EUP_Remarks" HeaderText="备注" SortExpression="EUP_Remarks" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandArgument='<%#Eval("EUP_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")+","
                                    +Eval("EUP_UpkeepPer")+","+Eval("EUP_ExpectTime")+","+Eval("EUP_Class")+","+Eval("EUP_PDate")+","+Eval("EUP_PPerson")+","
                                    +Eval("EUP_MakingTime")+","+Eval("EUP_GeneratePer")+","+Eval("EUP_GenerateTime")+","+Eval("EUP_ActPer")+","+Eval("EUP_OutPContents")+","
                                    +Eval("EUP_UStartT")+","+Eval("EUP_UEndT")+","+Eval("EUP_Remarks")%>' CommandName="Look1"
                                        OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Item1" runat="server" CommandArgument='<%#Eval("EUP_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")+","
                                    +Eval("EUP_UpkeepPer")+","+Eval("EUP_ExpectTime")+","+Eval("EUP_Class")+","+Eval("EUP_PDate")+","+Eval("EUP_PPerson")+","
                                    +Eval("EUP_MakingTime")+","+Eval("EI_ID")+","+Eval("EN_ID")+","+Eval("EUP_State")%>'  
                                     CommandName="Item1" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandArgument='<%#Eval("EUP_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")
                                      +","+Eval("EUP_UpkeepPer")+","+Eval("EUP_ExpectTime")+","+Eval("EUP_Class")+","+Eval("EUP_PDate")+","+Eval("EUP_PPerson")
                                      +","+Eval("EUP_MakingTime")+","+Eval("EI_ID")%>' 
                                    CommandName="Edit1" OnClientClick="false" >编辑保养计划</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:LinkButton ID="Generate1" runat="server" CommandArgument='<%#Eval("EUP_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")+","
                                    +Eval("EUP_UpkeepPer")+","+Eval("EUP_ExpectTime")+","+Eval("EUP_Class")+","+Eval("EUP_PDate")+","+Eval("EUP_PPerson")+","
                                    +Eval("EUP_MakingTime")+","+Eval("EI_ID")+","+Eval("EN_ID")+","+Eval("EUP_State")%>' CommandName="Generate1" OnClientClick="false">生成保养计划</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Deal1" runat="server" CommandArgument='<%#Eval("EUP_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")+","
                                    +Eval("EUP_UpkeepPer")+","+Eval("EUP_ExpectTime")+","+Eval("EUP_Class")+","+Eval("EUP_PDate")+","+Eval("EUP_PPerson")+","
                                    +Eval("EUP_MakingTime")+","+Eval("EUP_GeneratePer")+","+Eval("EUP_GenerateTime")+","+Eval("EMT_ID")+","+Eval("EUP_UStartT")%>' 
                                    CommandName="Deal1" OnClientClick="false">记录保养情况</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EUP_ID")+","+Eval("EUP_State")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle  />
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Start1" runat="server" CommandArgument='<%#Eval("EUP_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")+","
                                    +Eval("EUP_UpkeepPer")+","+Eval("EUP_ExpectTime")+","+Eval("EUP_Class")+","+Eval("EUP_PDate")+","+Eval("EUP_PPerson")+","
                                    +Eval("EUP_MakingTime")+","+Eval("EUP_GeneratePer")+","+Eval("EUP_GenerateTime")+","+Eval("EMT_ID")%>' 
                                    CommandName="Start1" OnClientClick="false">保养开始确认</asp:LinkButton>
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

    <%--增加保养计划时，首先查询并选择设备台账--%>
    <asp:UpdatePanel ID="UpdatePanel_searchInf" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_searchInf" runat="server" Visible="false">
                <fieldset >
                    <legend>选择设备台账</legend>
                    <asp:Label ID="Label_eiid" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label_nid" runat="server"   Visible="False"></asp:Label>
                    <%--<asp:Label ID="Label_no" runat="server" Text="Label_no" Visible="False"></asp:Label>--%>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label43" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList5" runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label44" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="infoname" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 16px">
                                <asp:Label ID="Label48" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td style="height: 16px" >
                                <asp:TextBox ID="infomodel" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right" style="height: 16px">
                                <asp:Label ID="Label49" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td style="height: 16px" >
                                <asp:TextBox ID="infono" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="Search_info" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_info_Click" Height="24px" />
                            </td>
                            <td >
                                <asp:Button ID="Clear_info" runat="server" CssClass="Button02" OnClick="Clear_info_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                            <td>
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
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_Location" HeaderText="设备位置" SortExpression="EI_Location">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EI_AcceptDate" HeaderText="验收日期">
                            <ItemTemplate>
                                <asp:Label ID="EI_AcceptDate" runat="server" Text='<%# Eval("EI_AcceptDate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                    DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="EI_Providor" HeaderText="供应商" SortExpression="EI_Providor">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_State" HeaderText="设备状态" SortExpression="EI_State">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add_plan" runat="server" CommandName="Add_plan" OnClientClick="false"
                                        CommandArgument='<%#Eval("EI_ID")+","+Eval("EN_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")%>'>建立计划</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add_last" runat="server" CommandName="Add_last" OnClientClick="false"
                                        CommandArgument='<%#Eval("EI_ID")+","+Eval("EN_ID")+","+Eval("EN_EquipName")+","+Eval("EI_No")%>'>查看上次保养项目</asp:LinkButton>
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

    <%--设备保养计划--%>
    <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional"> 
        <ContentTemplate>
        <asp:Panel ID="Panel_New" runat="server" UpdateMode="Conditional" Visible="false">
            <fieldset>
                <legend>设备保养计划</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 18%" align="right">
                            <asp:Label ID="Label14" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="newname" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label15" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="newno" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label17" runat="server" Text="保养人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="newUpkeepPer" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="newUpkeepPer" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label18" runat="server" Text="保养预计时间(小时)："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="newExpectTime" runat="server" Width="130px" Height="20px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" 
                                onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')" MaxLength="18"></asp:TextBox>
                            <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="newExpectTime" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label19" runat="server" Text="班次："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="白班" Value="白班"></asp:ListItem>
                                <asp:ListItem Text="夜班" Value="夜班"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList3" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label20" runat="server" Text="计划保养日期："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="newPDate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("EUP_PDate","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                            <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="newPDate" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label22" runat="server" Text="计划制定人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="newPPerson" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <asp:Label ID="Label50" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="newPPerson" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label23" runat="server" Text="计划制定时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="newMakingTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <asp:Label ID="Label51" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="newMakingTime" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right"></td>
                        <td ></td>
                    </tr>
                    <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Button ID="save_plan" runat="server" Text="保存" Width="70px" 
                                    CssClass="Button02" OnClick="save_plan_Click" ValidationGroup="addvalidation" 
                                    Height="24px" />
                            </td>
                            <td style="height: 16px; " colspan="2" align="center">
                                <%--<asp:Button ID="sub_plan" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="sub_plan_Click" ValidationGroup="addvalidation" />--%>
                            </td>
                            <td style="height: 16px;" colspan="2" align="left">
                                <asp:Button ID="cancel_plan" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="cancel_plan_Click" Height="24px" />
                            </td>
                     </tr> 
                </table>
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

 <%--设备保养计划之后，保养项目选择--%>
<%--<asp:UpdatePanel ID="UpdatePanel_Item" runat="server" UpdateMode="Conditional"> 
        <ContentTemplate>
        <asp:Panel ID="Panel_Item" runat="server" UpdateMode="Conditional" Visible="false">
        <fieldset>
            <legend>设备保养项目列表</legend>
            <table style="width: 100%;">
                <tr style="height: 16px;">
                    <td align="right" style="width: 35%;">
                       <asp:Button ID="last" runat="server" CssClass="Button02" Text="查看上次保养项目" Width="110px" OnClick="last_Click" />
                    </td>
                    <td align="center" style="width: 30%;">
                       <asp:Button ID="newitem" runat="server" CssClass="Button02" Text="新增保养项目" Width="90px" OnClick="newitem_Click" />
                    </td>
                    <td align="left">
                       <asp:Button ID="closeitem" runat="server" CssClass="Button02" Text="关闭" Width="70px" OnClick="closeitem_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="Grid_item" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                CssClass="GridViewStyle" DataKeyNames="EUI_ID" Font-Strikeout="False" GridLines="None" OnPageIndexChanging="Grid_item_PageIndexChanging" 
                onrowcommand="Grid_item_RowCommand" OnRowDataBound="Grid_item_RowDataBound" PageSize="2" 
                UseAccessibleHeader="False">
                <RowStyle CssClass="GridViewRowStyle" />  
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle  cssclass="GridViewHead"/>
                <FooterStyle CssClass="GridViewFooterStyle" />

                <Columns>
                    <asp:BoundField DataField="EUD_ID" HeaderText="保养明细ID" ReadOnly="True" SortExpression="EUD_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUP_ID" HeaderText="保养计划ID" ReadOnly="True" SortExpression="EUP_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EI_ID" HeaderText="设备台账ID" ReadOnly="True" SortExpression="EI_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_ID" HeaderText="保养项目ID" ReadOnly="True" SortExpression="EUI_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_Items" HeaderText="保养项目" SortExpression="EUI_Items">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_Period" HeaderText="保养周期(月)" SortExpression="EUI_Period">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Delete_item" runat="server" CommandName="Delete_item" OnClientClick="return confirm('您确认删除该记录吗?')"
                                CommandArgument='<%#Eval("EUD_ID")%>'>删除</asp:LinkButton>
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
                                <asp:TextBox ID="textbox3" runat="server" Width="20px"></asp:TextBox>
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
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
</asp:UpdatePanel>--%>

<%--设备保养计划详情--%>
    <asp:UpdatePanel ID="UpdatePanel_Look" runat="server" UpdateMode="Conditional"> 
        <ContentTemplate>
        <asp:Panel ID="Panel_Look" runat="server" UpdateMode="Conditional" Visible="false">
            <fieldset>
                <legend>设备保养计划详情</legend>
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 17%" align="right">
                            <asp:Label ID="Label11" runat="server" Text="设备名称："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="lookname" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 13%" align="right">
                            <asp:Label ID="Label24" runat="server" Text="设备编号："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="lookno" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 13%" align="right">
                            <asp:Label ID="Label25" runat="server" Text="保养人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="lookper" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookper" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label26" runat="server" Text="保养预计时间(小时)："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="looktime" runat="server" Width="130px" Height="20px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" 
                                onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')" MaxLength="18"></asp:TextBox>
                            <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                    ControlToValidate="looktime" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label27" runat="server" Text="班次："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="白班" Value="白班"></asp:ListItem>
                                <asp:ListItem Text="夜班" Value="夜班"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList4" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label28" runat="server" Text="计划保养日期："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="lookdate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("EUP_PDate","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                            <asp:Label ID="Label57" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookdate" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label29" runat="server" Text="计划制定人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="lookmakeper" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookmakeper" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label30" runat="server" Text="计划制定时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="lookmaketime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <asp:Label ID="Label59" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookmaketime" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td align="right"></td>
                        <td ></td>
                    </tr>
                    <tr>
                    <td align="right"></td>
                    <td align="left" colspan="2">
                        <asp:Button ID="Buttonchoose" runat="server" Text="新增保养项目" Width="110px" 
                            CssClass="Button02" OnClick="Buttonchoose_Click" Height="24px"/>
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                        <asp:Button ID="Buttonlast" runat="server" Text="查看上次保养项目" Width="110px" 
                            CssClass="Button02" OnClick="Buttonlast_Click" Height="24px"/>
                    </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label34" runat="server" Text="保养项目："></asp:Label>
                        </td>
                        <td  align="left" colspan="5">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                            CssClass="GridViewStyle" DataKeyNames="EUI_ID" Font-Strikeout="False" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" 
                            onrowcommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" PageSize="5" UseAccessibleHeader="False" Width="90%">
                            <RowStyle CssClass="GridViewRowStyle" />  
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle  cssclass="GridViewHead"/>
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="EUD_ID" HeaderText="保养明细ID" ReadOnly="True" SortExpression="EUD_ID" Visible="False">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EUP_ID" HeaderText="保养计划ID" ReadOnly="True" SortExpression="EUP_ID" Visible="False">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EI_ID" HeaderText="设备台账ID" ReadOnly="True" SortExpression="EI_ID" Visible="False">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EUI_ID" HeaderText="保养项目ID" ReadOnly="True" SortExpression="EUI_ID" Visible="False">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EUI_Items" HeaderText="保养项目" SortExpression="EUI_Items">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EUI_Period" HeaderText="保养周期(月)" SortExpression="EUI_Period">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_choose" runat="server" CommandName="Delete_choose" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EUD_ID")%>'>删除</asp:LinkButton>
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
                                            <asp:TextBox ID="textbox4" runat="server" Width="20px"></asp:TextBox>
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
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                <table style="width: 100%;">
                <tr style="height: 16px;">
                    <td align="right" style="width: 17%">
                        <asp:Label ID="Label35" runat="server" Text="计划生成人："></asp:Label>
                    </td>
                    <td style="width: 18%">
                        <asp:TextBox ID="lookgenper" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookgenper" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td align="right" style="width: 13%">
                        <asp:Label ID="Label36" runat="server" Text="计划生成时间："></asp:Label>
                    </td>
                    <td style="width: 18%">
                        <asp:TextBox ID="lookgentime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                            Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookgentime" ValidationGroup="SCvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td align="right" style="width: 13%"></td>
                    <td ></td>
                </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                <table style="width: 100%;">
                <tr>
                    <td align="right" style="width: 17%"></td>
                    <td align="left" colspan="5">
                        <asp:Button ID="Btn_spare" runat="server" Text="选择备件" Width="90px" 
                            CssClass="Button02" OnClick="Btn_spare_Click" Height="24px"/>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label38" runat="server" Text="所用备件："></asp:Label>
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
                                        <asp:TextBox ID="textbox5" runat="server" Width="20px"></asp:TextBox>
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
                <tr>
                    <td align="right">
                        <asp:Label ID="Label55" runat="server" Text="计划外的保养内容：<br/>(200字内)"></asp:Label>
                    </td>
                    <td colspan="5" >
                        <asp:TextBox ID="lookunplanned" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                            MaxLength="200" onfocus="annotation('Label52');" onblur="javascript:leave('Label52');"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label42" runat="server" Text="备注：<br/>(300字内)"></asp:Label>
                    </td>
                    <td colspan="5" >
                        <asp:TextBox ID="looknote" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                            MaxLength="300" onfocus="annotation('Label52');" onblur="javascript:leave('Label52');"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 16px;">
                    <td align="right">
                        <asp:Label ID="Label40" runat="server" Text="保养开始时间："></asp:Label>
                    </td>
                    <td style="width: 18%">
                        <asp:TextBox ID="lookbegtime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                            Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookbegtime" ValidationGroup="TJvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td align="right" style="width: 13%">
                        <asp:Label ID="Label41" runat="server" Text="保养结束时间："></asp:Label>
                    </td>
                    <td style="width: 18%">
                         <asp:TextBox ID="lookendtime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                            Text='<%# Eval("EUP_MakingTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                        <%--<asp:Label ID="Label60" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookendtime" ValidationGroup="TJvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td align="right" style="width: 13%">
                        <asp:Label ID="Label39" runat="server" Text="实际保养人："></asp:Label>
                        
                    </td>
                    <td >
                        <asp:TextBox ID="lookdealper" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                        <%--<asp:Label ID="Label61" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                    ControlToValidate="lookdealper" ValidationGroup="TJvalidation"></asp:RequiredFieldValidator>--%>
                    </td>
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
                    <td align="right" colspan="2">
                        <asp:Button ID="save_planedit" runat="server" Text="保存" Width="70px" 
                            CssClass="Button02" OnClick="save_planedit_Click" 
                            ValidationGroup="addvalidation" Height="24px"/>
                    </td>
                    <td style="height: 16px; " colspan="2" align="center">
                        <asp:Button ID="sub_planedit" runat="server" Text="提交" Width="70px" 
                            CssClass="Button02" OnClick="sub_planedit_Click" 
                            ValidationGroup="addvalidation" Height="24px"/>
                    </td>
                    <td style="height: 16px;" colspan="2" align="left">
                        <asp:Button ID="cancel_planedit" runat="server" CssClass="Button02" Text="关闭" 
                            Width="70px" OnClick="cancel_planedit_Click" Height="24px" />
                    </td>
                </tr> 
                </table>
                </asp:Panel>
                <asp:Panel ID="Panel6" runat="server" Visible="False">
                <table style="width: 100%;">
                <tr style="height: 16px;" >
                    <td align="right"  colspan="2" style="width: 35%">
                        <asp:Button ID="btn_Generate" runat="server" Text="生成" Width="70px" 
                            CssClass="Button02" OnClick="btn_Generate_Click" ValidationGroup="SCvalidation" 
                            Height="24px"/>
                    </td>
                    <td style="height: 16px; width: 31%" colspan="2" align="center"></td>
                    <td  align="left" colspan="2">
                        <asp:Button ID="Cancel_Generate" runat="server" CssClass="Button02" Text="关闭" 
                            Width="70px" OnClick="Cancel_Generate_Click" Height="24px" />
                    </td>
                </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="Panel7" runat="server" Visible="False">
                <table style="width: 100%;">
                <tr style="height: 16px;" >
                    <td align="right"  colspan="2" style="width: 35%">
                        <asp:Button ID="btn_Deal" runat="server" Text="提交" Width="70px" 
                            CssClass="Button02" OnClick="btn_Deal_Click" ValidationGroup="TJvalidation" 
                            Height="24px"/>
                    </td>
                    <td style="height: 16px; width: 31%" colspan="2" align="center"></td>
                    <td  align="left" colspan="2">
                        <asp:Button ID="Cancel_Deal" runat="server" CssClass="Button02" Text="关闭" 
                            Width="70px" OnClick="Cancel_Deal_Click" Height="24px" />
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="Panel8" runat="server" Visible="False">
                <table style="width: 100%;">
                <tr style="height: 16px;">
                    <td style="height: 16px; width:50%" align="center">
                        <asp:Button ID="Button1" runat="server" CssClass="Button02" Text="确认开始" 
                            Width="80px" OnClick="Button1_Click" Height="24px" />
                    </td>
                    <td align="center">
                        <asp:Button ID="Button2" runat="server" CssClass="Button02" Text="关闭" 
                            Width="80px" OnClick="Button2_Click" Height="24px" />
                    </td>
                </tr>
                </table>
                </asp:Panel>
        </fieldset>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<%--查看上次保养项目--%>
<asp:UpdatePanel ID="UpdatePanel_last" runat="server" UpdateMode="Conditional"> 
        <ContentTemplate>
        <asp:Panel ID="Panel_last" runat="server" UpdateMode="Conditional" Visible="false">
        <fieldset>
            <legend><asp:Label ID="Label60" runat="server"></asp:Label><asp:Label ID="Label61" runat="server"></asp:Label>上次保养项目查看</legend>
            <asp:GridView ID="Grid_last" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                CssClass="GridViewStyle" DataKeyNames="EUI_ID" Font-Strikeout="False" GridLines="None" OnPageIndexChanging="Grid_last_PageIndexChanging" 
                onrowcommand="Grid_last_RowCommand" OnRowDataBound="Grid_last_RowDataBound" PageSize="5" 
                UseAccessibleHeader="False">
                <RowStyle CssClass="GridViewRowStyle" />  
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle  cssclass="GridViewHead"/>
                <FooterStyle CssClass="GridViewFooterStyle" />

                <Columns>
                    <asp:BoundField DataField="EUI_ID" HeaderText="保养项目ID" ReadOnly="True" SortExpression="EUI_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID" Visible="False">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_Items" HeaderText="保养项目" SortExpression="EUI_Items">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_Period" HeaderText="保养周期(月)" SortExpression="EUI_Period">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_IsDeleted" HeaderText="是否删除" SortExpression="EUI_IsDeleted" Visible="False">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:TemplateField SortExpression="EUD_Time" HeaderText="上次保养日期">
                        <ItemTemplate>
                            <asp:Label ID="EUD_Time" runat="server" Text='<%# Eval("EUD_Time","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle/>
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
                                <asp:TextBox ID="textbox6" runat="server" Width="20px"></asp:TextBox>
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
            <table style="width: 100%;">
                <tr style="height: 16px;">
                    <td align="center"  colspan="3" >
                       <asp:Button ID="last_close" runat="server" CssClass="Button02" Text="关闭" 
                            Width="70px" OnClick="last_close_Click" Height="24px" />
                    </td>
                </tr>
            </table>
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
</asp:UpdatePanel>

<%--设备保养计划之后，保养项目选择--%>
     <asp:UpdatePanel ID="UpdatePanel_newitem" runat="server" UpdateMode="Conditional"> 
        <ContentTemplate>
        <asp:Panel ID="Panel_newitem" runat="server" UpdateMode="Conditional" Visible="false">
            <fieldset>
            <legend>可选的保养项目</legend>
            <asp:GridView ID="Grid_newitem" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                CssClass="GridViewStyle" DataKeyNames="EUI_ID" Font-Strikeout="False" GridLines="None"  OnPageIndexChanging="Grid_newitem_PageIndexChanging"  
                onrowcommand="Grid_newitem_RowCommand" OnRowDataBound="Grid_newitem_RowDataBound" PageSize="5" 
                UseAccessibleHeader="False">
                <RowStyle CssClass="GridViewRowStyle" />  
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle  cssclass="GridViewHead"/>
                <FooterStyle CssClass="GridViewFooterStyle" />

                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="ckb" runat="server" />
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:BoundField DataField="EUI_ID" HeaderText="保养项目ID" ReadOnly="True" SortExpression="EUI_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID" Visible="False">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName" Visible="false">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_Items" HeaderText="保养项目" SortExpression="EUI_Items">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_Period" HeaderText="保养周期(月)" SortExpression="EUI_Period">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="EUI_IsDeleted" HeaderText="是否删除" SortExpression="EUI_IsDeleted" Visible="False">
                        <ItemStyle/>
                    </asp:BoundField>
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
                                <asp:TextBox ID="textbox7" runat="server" Width="20px"></asp:TextBox>
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
            <table style="width: 100%;">
                <tr style="height: 16px;">
                    <td style="width: 35%;" align="right">
                        <asp:Button ID="Btn_Save" runat="server" Text="保存" Width="70px" 
                            CssClass="Button02" OnClick="Btn_Save_Click" Height="24px" />
                    </td>
                    <td style="width: 30%;" align="center" ></td>
                    <td align="left">
                        <asp:Button ID="Btn_Cancel" runat="server" CssClass="Button02" Text="关闭" 
                            Width="70px" OnClick="Btn_Cancel_Click" Height="24px" />
                    </td>
               </tr>
            </table>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                    ControlToValidate="useno" ValidationGroup="addsparevalidation"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="textbox8" runat="server" Width="20px"></asp:TextBox>
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


</asp:Content>