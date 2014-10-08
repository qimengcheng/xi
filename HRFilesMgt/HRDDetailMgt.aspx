<%@ Page Title="人事档案维护" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="HRDDetailMgt.aspx.cs" Inherits="HRFilesMgt_HRDDetailMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

        function ValidtorTime(start, end) {
            var idstart = "ctl00_ContentPlaceHolder1_" + start;
            var idend = "ctl00_ContentPlaceHolder1_" + end;
            var d1 = new Date(document.getElementById(idstart).value.replace(/\-/g, "\/"));
            var d2 = new Date(document.getElementById(idend).value.replace(/\-/g, "\/"));
            if (d1 > d2) {
                return false;
            }
            return true;
        }

        function onlynumanddot(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, "");
        }

        function annotation(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'visible';
            return false;
        }
        function leave(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'hidden';
            return false;
        }

        function isdigit(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var s = document.getElementById(id).value;
            var r, re;
            re = /\d*/i; //\d表示数字,*表示匹配多个数字
            r = s.match(re);
            return (r == s) ? true : false;
        }


        function textCounter(num) {

            var textbox = document.getElementById("<%=TxtRemarks.ClientID %>");

            if (textbox.value.length > num) {
                textbox.value = textbox.value.substring(0, num);
            }

        }  
    </script>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlSDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>人事档案检索栏</legend>
                    <asp:Panel ID="Panel77" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="工号："></asp:Label>
                                <asp:Label ID="LblState" runat="server" Text="LblState" Visible="false"></asp:Label>
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtSStaffNO" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtSName" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="员工类型:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlSType" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="部门："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DdlSDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlSDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="岗位："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlSPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label100" runat="server" Text="户口："></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="单击选择">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="城镇" Value="城镇"></asp:ListItem>
                                    <asp:ListItem Text="农村" Value="农村"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel5" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 10%; height: 16px;" align="center">
                                    <asp:Label ID="Label119" runat="server" CssClass="STYLE2" Text="学历："></asp:Label>
                                </td>
                                <td style="width: 20%; height: 16px;">
                                    <asp:DropDownList ID="DropDownList6" runat="server" ToolTip="单击选择">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="小学" Value="小学"></asp:ListItem>
                                    <asp:ListItem Text="初中" Value="初中"></asp:ListItem>
                                    <asp:ListItem Text="职高" Value="职高"></asp:ListItem>
                                    <asp:ListItem Text="中师" Value="中师"></asp:ListItem>
                                    <asp:ListItem Text="技校" Value="技校"></asp:ListItem>
                                    <asp:ListItem Text="中专" Value="中专"></asp:ListItem>
                                    <asp:ListItem Text="高中" Value="高中"></asp:ListItem>
                                    <asp:ListItem Text="高职" Value="高职"></asp:ListItem>
                                    <asp:ListItem Text="大专" Value="大专"></asp:ListItem>
                                    <asp:ListItem Text="本科" Value="本科"></asp:ListItem>
                                    <asp:ListItem Text="硕士" Value="硕士"></asp:ListItem>
                                    <asp:ListItem Text="博士" Value="博士"></asp:ListItem>
                                    <asp:ListItem Text="其他" Value="其他"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="Label120" runat="server" CssClass="STYLE2" Text="毕业学校："></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="TextBox20" runat="server" Width="155px"></asp:TextBox>
                                </td>
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="Label121" runat="server" CssClass="STYLE2" Text="专业："></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="TextBox21" runat="server" Width="155px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="Label110" runat="server" CssClass="STYLE2" Text="性别："></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:DropDownList ID="DropDownList3" runat="server" ToolTip="单击选择">
                                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                        <asp:ListItem Text="男" Value="男"></asp:ListItem>
                                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="Label111" runat="server" CssClass="STYLE2" Text="合同到期日期："></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TextBox13" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label112" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox14" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10%; height: 16px;" align="center">
                                    <asp:Label ID="Label113" runat="server" CssClass="STYLE2" Text="社保："></asp:Label>
                                </td>
                                <td style="width: 20%; height: 16px;">
                                    <asp:DropDownList ID="DropDownList4" runat="server" ToolTip="单击选择">
                                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                        <asp:ListItem Text="已买" Value="已买"></asp:ListItem>
                                        <asp:ListItem Text="未买" Value="未买"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="center" >
                                    <asp:Label ID="Label114" runat="server" CssClass="STYLE2" Text="入职日期："></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TextBox15" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label115" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox16" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 10%; height: 16px;" align="center">
                                    <asp:Label ID="Label116" runat="server" CssClass="STYLE2" Text="公积金："></asp:Label>
                                </td>
                                <td style="width: 20%; height: 16px;">
                                    <asp:DropDownList ID="DropDownList5" runat="server" ToolTip="单击选择">
                                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                        <asp:ListItem Text="已买" Value="已买"></asp:ListItem>
                                        <asp:ListItem Text="未买" Value="未买"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td  align="center" >
                                    <asp:Label ID="Label117" runat="server" CssClass="STYLE2" Text="转正日期："></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TextBox17" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label118" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox19" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:LinkButton ID="Senior_DetailOPEN" runat="server" CommandName="Senior_DetailOPEN"  ForeColor="Blue" Font-Underline="True" 
                            onclick="Senior_DetailOPEN_Click" Text=">> 打开高级检索" Visible="false" ></asp:LinkButton>
                        <asp:LinkButton ID="Senior_DetailCLOSE" runat="server" CommandName="Senior_DetailCLOSE"  ForeColor="Blue" Font-Underline="True" 
                            onclick="Senior_DetailCLOSE_Click" Text="<< 关闭高级检索" Visible="false"></asp:LinkButton>
                        <asp:Label ID="Label_OpenOrClose" runat="server" Text="Label_OpenOrClose" Visible="false"></asp:Label>
                        <asp:Panel ID="Panel6" runat="server" Visible="false">
                            <table style="width: 100%;">
                                <tr>
                                    <td align="center" style="width: 10%;">
                                        <asp:Label ID="Label124" runat="server"  Text="奖惩类型：" ></asp:Label>
                                    </td>
                                    <td  style="width: 20%;">
                                        <asp:DropDownList ID="DropDownList7" runat="server" Height="20px">
                                            <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                            <asp:ListItem Text="奖励" Value="奖励"></asp:ListItem>
                                            <asp:ListItem Text="处罚" Value="处罚"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center"  style="width: 10%;">
                                        <asp:Label ID="Label130" runat="server"   Text="发生时间："></asp:Label>
                                    </td>
                                    <td colspan="3"  style="width: 50%;">
                                        <asp:TextBox ID="TextBox26" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                            DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label122" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox22" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                            DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td align="center">
                                        <asp:Label ID="Label126" runat="server"   Text="奖惩金额："></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="TextBox24" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/^(\-)*(\d+)\.(\d\d).*$/,'$1$2.$3')"
                                            onafterpaste="this.value=this.value.replace(/^(\-)*(\d+)\.(\d\d).*$/,'$1$2.$3')"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label132" runat="server"   Text="生效时间："></asp:Label>
                                    </td>
                                    <td  colspan="3">
                                        <asp:TextBox ID="TextBox27" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                            DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label123" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox23" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                            DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td align="center" >
                                        <asp:Label ID="Label128" runat="server"   Text="批准人："></asp:Label>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="TextBox25" runat="server" Width="155px" ></asp:TextBox>
                                    </td>
                                    <td  align="center">
                                        <asp:Label ID="Label134" runat="server"   Text="奖惩内容：" ></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TextBox28" runat="server" Width="95%" MaxLength="200"></asp:TextBox>
                                    </td>
                                    </tr>
                                </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel1" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                <td style="width: 30%; height: 15px;"  align="right" >
                                    <asp:Label ID="LblRecordID" runat="server" Text="LblRecordID" Visible="false"></asp:Label>
                                    <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                        Width="70px" OnClick="BtnSearch_Click" CausesValidation="False" />
                                </td>
                                <td style="width: 40%; height: 15px;" align="center" >
                                    <asp:Button ID="BtnNew" runat="server" CssClass="Button02" Height="24px" Text="新增人事档案"
                                        Width="90px" OnClick="BtnNew_Click" CausesValidation="False" />
                                    <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。" Visible="false"/>
                                </td>
                                <td align="left" >
                                    <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                        Visible="true" Width="70px" OnClick="BtnReset_Click1" CausesValidation="False" />
                                </td>
                            </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                <td style="width: 30%; height: 15px;"  align="right" >
                                    <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                        Width="70px" OnClick="BtnSearchQuit_Click" CausesValidation="False" />
                                </td>
                                <td style="width: 40%; height: 15px;">
                                </td>
                                <td align="left" >
                                    <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                        Visible="true" Width="70px" OnClick="BtnResetQuit_Click1" CausesValidation="False" />
                                </td>
                            </tr>
                            </table>
                        </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>人事档案列表</legend>
                    <asp:Label ID="Label_sort" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="Labeldereciton" runat="server" Visible="false"></asp:Label>
                    <asp:Button ID="BtnWorklength" runat="server" CssClass="Button02" Height="24px" Text="一键更新工龄" Width="90px" OnClick="BtnWorklength_Click" ToolTip="点击此处，更新所有在职员工的工龄。" Visible="false"/>
                    <asp:GridView ID="Grid_Detail" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="10" GridLines="None" OnRowCommand="Grid_Detail_RowCommand" OnPageIndexChanging="Grid_Detail_PageIndexChanging"
                        OnDataBound="Grid_Detail_DataBound" OnRowCreated="Grid_Detail_RowCreated" OnSorting="Grid_Detail_Sorting">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRET_EmpType" HeaderText="员工类型" SortExpression="HRET_EmpType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_EntryDate" HeaderText="入职日期" SortExpression="HRDD_EntryDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_ContactEDate" HeaderText="合同到期日期" SortExpression="HRDD_ContactEDate" Visible="true" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLook_Detail" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="Look_Detail" OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Detail" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="Edit_Detail" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Detail" runat="server" CommandName="Delete_Detail"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("HRDD_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnPersonnelChanges" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="PersonnelChanges" OnClientClick="false">人事异动</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLook_PersonnelChangesRecord" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="Look_PersonnelChangesRecord" OnClientClick="false">查看异动记录</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSalaryChange" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="SalaryChange" OnClientClick="false">调薪</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLook_SalaryRecord" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="Look_SalaryRecord" OnClientClick="false">查看调薪记录</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Quit" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="Edit_Quit" OnClientClick="false">离职</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Re" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="Edit_Re" OnClientClick="false">复职</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_DetailQuit" runat="server" CommandName="Delete_DetailQuit"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("HRDD_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnRewardsPublishment" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="RewardsPublishment" OnClientClick="false">奖惩情况</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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

    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel7" runat="server" Visible="false">
                <fieldset>
                    <legend>高级检索列表</legend>
                    <asp:GridView ID="GridView7" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="10" GridLines="None" OnRowCommand="GridView7_RowCommand" OnPageIndexChanging="GridView7_PageIndexChanging"
                        OnDataBound="GridView7_DataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRET_EmpType" HeaderText="员工类型" SortExpression="HRET_EmpType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_ID" HeaderText="奖惩情况ID" ReadOnly="True" SortExpression="HRRewards_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Type" HeaderText="奖惩类型" SortExpression="HRRewards_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Money" HeaderText="奖惩金额" SortExpression="HRRewards_Money">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Agree" HeaderText="批准人" SortExpression="HRRewards_Agree">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="HRRewards_Time" HeaderText="发生时间">
                                <ItemTemplate>
                                    <asp:Label ID="HRRewards_Time" runat="server" Text='<%# Eval("HRRewards_Time","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="HRRewards_OkTime" HeaderText="生效时间">
                                <ItemTemplate>
                                    <asp:Label ID="HRRewards_OkTime" runat="server" Text='<%# Eval("HRRewards_OkTime","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HRRewards_Content" HeaderText="奖惩内容" SortExpression="HRRewards_Content">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Note" HeaderText="备注" SortExpression="HRRewards_Note">
                                <ItemStyle />
                            </asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox34" runat="server" Width="20px"></asp:TextBox>
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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

    <asp:UpdatePanel ID="UpdatePanel_Detail" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_Detail" runat="server" Visible="false">
                <fieldset>
                    <legend>人事档案详情</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="工号:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtStaffNO" runat="server" Width="155px" Enabled="false" MaxLength="10" onkeyup="this.value=this.value.replace(/[^0-9a-zA-Z]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9a-zA-Z]/g,'')"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtStaffNO" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="姓名:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtName" runat="server" Width="155px" MaxLength="10"></asp:TextBox>
                                <asp:Label ID="Label67" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtName" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%; height: 16px;" align="center">
                                <asp:Label ID="Label33" runat="server" CssClass="STYLE2" Text="联系电话:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 16px;">
                                <asp:TextBox ID="TxtTel" runat="server" Width="155px" MaxLength="15" onkeyup="this.value=this.value.replace(/[^0-9-]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9-]/g,'')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="部门:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlDep" runat="server" ToolTip="单击选择" AutoPostBack="true" OnSelectedIndexChanged="DdlDep_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="Label68" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlDep" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="岗位:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:Label ID="Label69" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlPost" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="员工类型:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlType" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:Label ID="Label70" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <asp:Label ID="Label86" runat="server" Text="注意员工类型！" ForeColor="Red" Visible="true"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlType" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="基本工资(元):"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtBasicWage" runat="server" Width="155px" Text="0" MaxLength="16"
                                    onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                    <asp:Label ID="Label71" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:TextBox ID="TxtBasicWage" runat="server" Width="155px" Text="0" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"
                                 onafterpaste="this.value=this.value.replace(^-?([1-9]\d*\.\d{1,2}|0\.\d[1-9]|0\.[1-9]\d|[1-9]\d*|0)$,'')"></asp:TextBox>--%>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtBasicWage" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="全勤工资(元):"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtFullTimeWage" runat="server" Width="155px" Text="0" MaxLength="16"
                                    onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                    <asp:Label ID="Label72" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtFullTimeWage" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="户口:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlRegistration" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>城镇</asp:ListItem>
                                    <asp:ListItem>农村</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="绩效工资(元):"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtPerformWage" runat="server" Width="155px" Text="0" MaxLength="16"
                                    onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                    <asp:Label ID="Label73" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtPerformWage" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="加班工资(元):"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtOverTimeWage" runat="server" Width="155px" Text="0" MaxLength="16"
                                    onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                 <asp:Label ID="Label85" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label27" runat="server" CssClass="STYLE2" Text="民族:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtNationality" runat="server" Width="155px" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="合同签订日期:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtContactSDate" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtContactSDate" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="合同到期日期:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtContactEDate" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtContactEDate" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="婚否:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlIsMarried" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="入职日期:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtEntryDate" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                 <asp:Label ID="Label101" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtEntryDate" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="转正日期:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtConverseDate" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtConverseDate" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label20" runat="server" CssClass="STYLE2" Text="工龄（年）:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtWorklength" runat="server" Width="155px" MaxLength="10" Enabled="false" 
                                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label25" runat="server" CssClass="STYLE2" Text="身份证号:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtIDCard" runat="server" Width="155px" MaxLength="18" onkeyup="this.value=this.value.replace(/[^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)]/g,'')"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label23" runat="server" CssClass="STYLE2" Text="性别:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlSex" runat="server" ToolTip="单击选择" Enabled="false">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                        <asp:ListItem Text="男" Value="男"></asp:ListItem>
                                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label24" runat="server" CssClass="STYLE2" Text="出生日期:" ></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtDateOfBirth" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtDateOfBirth" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label29" runat="server" CssClass="STYLE2" Text="学历:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlEduBackg" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>小学</asp:ListItem>
                                    <asp:ListItem>初中</asp:ListItem>
                                    <asp:ListItem>职高</asp:ListItem>
                                    <asp:ListItem>中师</asp:ListItem>
                                    <asp:ListItem>技校</asp:ListItem>
                                    <asp:ListItem>中专</asp:ListItem>
                                    <asp:ListItem>高中</asp:ListItem>
                                    <asp:ListItem>高职</asp:ListItem>
                                    <asp:ListItem>大专</asp:ListItem>
                                    <asp:ListItem>本科</asp:ListItem>
                                    <asp:ListItem>硕士</asp:ListItem>
                                    <asp:ListItem>博士</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label28" runat="server" CssClass="STYLE2" Text="毕业学校:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtGSchool" runat="server" Width="155px" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label30" runat="server" CssClass="STYLE2" Text="专业:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtMajor" runat="server" Width="155px" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label34" runat="server" CssClass="STYLE2" Text="证件是否齐全:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlCertificateComplete" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%; height: 16px;" align="center">
                                <asp:Label ID="Label32" runat="server" CssClass="STYLE2" Text="社保:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 16px;">
                                <asp:DropDownList ID="DdlHasSocial" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>已买</asp:ListItem>
                                    <asp:ListItem>未买</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label37" runat="server" CssClass="STYLE2" Text="公积金:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlHasAccumulation" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>已买</asp:ListItem>
                                    <asp:ListItem>未买</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%; height: 16px;" align="center">
                                <asp:Label ID="Label31" runat="server" CssClass="STYLE2" Text="家庭住址:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 16px;">
                                <asp:TextBox ID="TxtHAddress" runat="server" Width="155px" MaxLength="40"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label35" runat="server" CssClass="STYLE2" Text="紧急联络人:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtEmergencyPer" runat="server" Width="155px" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label36" runat="server" CssClass="STYLE2" Text="联络人电话:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtEmergencyNo" runat="server" Width="155px" MaxLength="15" onkeyup="this.value=this.value.replace(/[^0-9-]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9-]/g,'')"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                            <table style="width: 100%;">
                                <tr style="height: 16px;">
                                    <td style="width: 10%" align="center">
                                        <asp:Label ID="Label81" runat="server" Text="离职时间:"></asp:Label>
                                    </td>
                                    <td style="width: 20%">
                                        <asp:TextBox ID="TextBox1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                            DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                        <asp:Label ID="Label84" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:Label ID="Label82" runat="server" Text="离职方式:"></asp:Label>
                                    </td>
                                    <td style="width: 20%">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td style="width: 10%" align="center"></td>
                                    <td style="width: 20%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 10%" align="center">
                                        <asp:Label ID="Label83" runat="server" Text="离职原因:"></asp:Label>
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="TextBox3" runat="server" Width="600px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table style="width: 100%;">
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnSubmit" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnSubmit_Click" ValidationGroup="Detail" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCancel_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Changes" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlDepChangeAfter" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_Changes" runat="server" Visible="false">
                <fieldset>
                    <legend>人事异动栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label38" runat="server" CssClass="STYLE2" Text="工号:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtStaffNOChange" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label39" runat="server" CssClass="STYLE2" Text="姓名:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtNameChange" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label40" runat="server" CssClass="STYLE2" Text="原部门:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlDepChangeBefore" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label41" runat="server" CssClass="STYLE2" Text="原岗位:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlPostChangeBefore" runat="server" ToolTip="单击选择" Enabled="False">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label42" runat="server" CssClass="STYLE2" Text="异动部门:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlDepChangeAfter" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlDepChangeAfter_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="Label74" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlDepChangeAfter" ValidationGroup="Change"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label43" runat="server" CssClass="STYLE2" Text="异动岗位:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlPostChangeAfter" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:Label ID="Label75" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlPostChangeAfter" ValidationGroup="Change"></asp:RequiredFieldValidator>--%>
                            </td>
                            <tr style="height: 16px;">
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="Label44" runat="server" CssClass="STYLE2" Text="异动管理员:"></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="TxtManager" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="Label45" runat="server" CssClass="STYLE2" Text="异动时间:"></asp:Label>
                                </td>
                                <td style="width: 20%">
                                    <asp:TextBox ID="TxtTime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                        DataFormatString="{0:yyyy-MM-dd HH:MM:SS}" Width="155px" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 16px;">
                                <td style="width: 10%" align="center">
                                    <asp:Label ID="Label46" runat="server" CssClass="STYLE2" Text="备注<br>(200字内)"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ID="TxtRemarks" runat="server" Width="600px" Height="70px" TextMode="MultiLine"
                                        MaxLength="200" onfocus="annotation('Label47');" onblur="javascript:leave('Label47');"
                                        onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                                </td>
                                <td style="width: 10%; text-align: center">
                                    <asp:Label ID="Label47" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label><br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="BtnSubmitChange" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                        Width="70px" OnClick="BtnSubmitChange_Click" ValidationGroup="Change" />
                                </td>
                                <td colspan="3" align="center">
                                    <asp:Button ID="BtnCancelChange" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                        Visible="true" Width="70px" OnClick="BtnCancelChange_Click" CausesValidation="False" />
                                </td>
                            </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Record" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Record" runat="server" Visible="false">
                <fieldset>
                    <legend>异动记录栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label48" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtStaffNORecord" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label49" runat="server" CssClass="STYLE2" Text="姓名:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtNameRecord" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <fieldset>
                                    <legend>异动历史记录列表</legend>
                                    <asp:GridView ID="Grid_ChangeRecord" runat="server" DataKeyNames="HRPCR_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                                        GridLines="None" OnPageIndexChanging="Grid_ChangeRecord_PageIndexChanging" OnDataBound="Grid_ChangeRecord_DataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRPCR_ID" HeaderText="人事异动ID" ReadOnly="True" SortExpression="HRPCR_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPCR_FormerDep" HeaderText="原部门" SortExpression="HRPCR_FormerDep">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPCR_FormerPost" HeaderText="原岗位" SortExpression="HRPCR_FormerPost">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPCR_Dep" HeaderText="异动部门" SortExpression="HRPCR_Dep">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPCR_Post" HeaderText="异动岗位" SortExpression="HRPCR_Post">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPCR_Administrator" HeaderText="异动管理员" SortExpression="HRPCR_Administrator">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPCR_Time" HeaderText="异动时间" SortExpression="HRPCR_Time">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPCR_Remarks" HeaderText="备注" SortExpression="HRPCR_Remarks">
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
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="BtnClose" runat="server" CssClass="Button02" Height="24px" OnClick="BtnClose_Click"
                                    Text="关闭" Visible="true" Width="70px" />
                            </td>
                        </tr>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SalaryChange" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SalaryChange" runat="server" Visible="false">
                <fieldset>
                    <legend>调薪管理栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 12%" align="center">
                                <asp:Label ID="Label50" runat="server" Text="工号:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtStaffNOSalaryChange" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="center">
                                <asp:Label ID="Label51" runat="server" Text="姓名:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtNameSalaryChange" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="center">
                                <asp:Label ID="Label52" runat="server" Text="原基本工资:" Enabled="False"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TxtFormerBasicSalary" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td align="center">
                                <asp:Label ID="Label53" runat="server"  Text="原全勤工资:" Enabled="False"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TxtFormerFullTimeWage" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label54" runat="server"   Text="原绩效工资:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TxtFormerPerformWage" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label55" runat="server"   Text="原加班工资:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TxtFormerOverTimeWage" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                            </td>
                            <tr >
                                <td  align="center">
                                    <asp:Label ID="Label60" runat="server"   Text="基本工资(元):" Enabled="False"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TxtNowBasicSalary" runat="server" Width="140px" MaxLength="10" 
                                    onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                    <asp:Label ID="Label76" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*"
                                        ControlToValidate="TxtNowBasicSalary" ValidationGroup="Salary"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td  align="center">
                                    <asp:Label ID="Label61" runat="server"   Text="全勤工资(元):"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TxtNowFullTimeWage" runat="server" Width="140px" 
                                        MaxLength="10" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                        <asp:Label ID="Label77" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*"
                                        ControlToValidate="TxtNowFullTimeWage" ValidationGroup="Salary"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td  align="center">
                                    <asp:Label ID="Label62" runat="server"   Text="绩效工资(元):"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TxtNowPerformWage" runat="server" Width="140px" MaxLength="10" 
                                    onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                    <asp:Label ID="Label78" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*"
                                        ControlToValidate="TxtNowPerformWage" ValidationGroup="Salary"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr >
                                <td align="center">
                                    <asp:Label ID="Label63" runat="server"   Text="加班工资(元):"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TxtNowOverTimeWage" runat="server" Width="140px" 
                                        MaxLength="10" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                        <asp:Label ID="Label79" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*"
                                        ControlToValidate="TxtNowOverTimeWage" ValidationGroup="Salary"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label56" runat="server"   Text="调薪负责人:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtChargePer" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label57" runat="server"   Text="调薪时间:"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TxtSalryTime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                        DataFormatString="{0:yyyy-MM-dd HH:MM:SS}" Width="140px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr >
                                <td align="center">
                                    <asp:Label ID="Label58" runat="server"   Text="调薪原因:<br>(200字内)"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ID="TxtReason" runat="server" Width="100%" Height="70px" TextMode="MultiLine"
                                        MaxLength="200" onfocus="annotation('Label59');" onblur="javascript:leave('Label59');"
                                        onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                                        
                                </td>
                                <td >
                                <asp:Label ID="Label80" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*"
                                        ControlToValidate="TxtReason" ValidationGroup="Salary"></asp:RequiredFieldValidator>--%>
                                    <asp:Label ID="Label59" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="BtnSalaryChangeSubmit" runat="server" Text="提交" CssClass="Button02"
                                        Height="24px" Width="70px" OnClick="BtnSalaryChangeSubmit_Click1" ValidationGroup="Salary" />
                                </td>
                                <td colspan="3" align="center">
                                    <asp:Button ID="BtnSalaryChangeCancel" runat="server" Text="关闭" CssClass="Button02"
                                        Height="24px" Visible="true" Width="70px" OnClick="BtnSalaryChangeCancel_Click"
                                        CausesValidation="False" />
                                </td>
                            </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_SalaryRecord" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SalaryRecord" runat="server" Visible="false">
                <fieldset>
                    <legend>调薪记录栏<asp:Label ID="Label22" runat="server" Text="" Visible="false"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label64" runat="server" CssClass="STYLE2" Text="工号:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSRecordStaffNO" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label65" runat="server" CssClass="STYLE2" Text="姓名:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSRecordName" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <fieldset>
                                    <legend>调薪历史记录列表</legend>
                                    <asp:GridView ID="GridView_SalaryRecord" runat="server" DataKeyNames="HRSR_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                                        GridLines="None" OnPageIndexChanging="GridView_SalaryRecord_PageIndexChanging"
                                        OnDataBound="GridView_SalaryRecord_DataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRSR_ID" HeaderText="调薪记录ID" ReadOnly="True" SortExpression="HRSR_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRSR_AdjBasicWage" HeaderText="基本工资" SortExpression="HRSR_AdjBasicWage">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRSR_AdjFTWage" HeaderText="全勤工资" SortExpression="HRSR_AdjFTWage">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRSR_AdjPWage" HeaderText="绩效工资" SortExpression="HRSR_AdjPWage">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRSR_AdjOTWage" HeaderText="加班工资" SortExpression="HRSR_AdjOTWage">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRSR_ChargePer" HeaderText="异动负责人" SortExpression="HRSR_ChargePer">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRSR_Time" HeaderText="调薪时间" SortExpression="HRSR_Time">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRSR_Reason" HeaderText="调薪原因" SortExpression="HRSR_Reason">
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
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="BtnSalaryRecordClose" runat="server" CssClass="Button02" Height="24px"
                                    Text="关闭" Visible="true" Width="70px" OnClick="BtnSalaryRecordClose_Click" />
                            </td>
                        </tr>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePane_reward" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_reward" runat="server" Visible="false">
                <fieldset>
                    <legend>奖惩情况表</legend>
                    <asp:Label ID="Label97" runat="server" Text="" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label88" runat="server" CssClass="STYLE2" Text="工号:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox4" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label89" runat="server" CssClass="STYLE2" Text="姓名:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox5" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="center">
                                <asp:Button ID="BtnRewardNew" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增" Visible="true" Width="70px" OnClick="BtnRewardNew_Click" />
                            </td>
                            <td align="center">
                                <asp:Button ID="BtnRewardnewClose" runat="server" CssClass="Button02" Height="24px"
                                    Text="关闭" Visible="true" Width="70px" OnClick="BtnRewardnewClose_Click" />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                    <asp:GridView ID="GridView_Reward" runat="server" DataKeyNames="HRRewards_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                                        GridLines="None" OnPageIndexChanging="GridView_Reward_PageIndexChanging"  OnRowCommand="GridView_Reward_RowCommand" 
                                        OnDataBound="GridView_Reward_DataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRRewards_ID" HeaderText="奖惩情况ID" ReadOnly="True" SortExpression="HRRewards_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRRewards_Type" HeaderText="奖惩类型" SortExpression="HRRewards_Type">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRRewards_Money" HeaderText="奖惩金额" SortExpression="HRRewards_Money">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRRewards_Agree" HeaderText="批准人" SortExpression="HRRewards_Agree">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField SortExpression="HRRewards_Time" HeaderText="发生时间">
                                                <ItemTemplate>
                                                    <asp:Label ID="HRRewards_Time" runat="server" Text='<%# Eval("HRRewards_Time","{0:yyyy-MM-dd}") %>'
                                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle/>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="HRRewards_OkTime" HeaderText="生效时间">
                                                <ItemTemplate>
                                                    <asp:Label ID="HRRewards_OkTime" runat="server" Text='<%# Eval("HRRewards_OkTime","{0:yyyy-MM-dd}") %>'
                                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle/>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="HRRewards_Content" HeaderText="奖惩内容" SortExpression="HRRewards_Content">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRRewards_Note" HeaderText="备注" SortExpression="HRRewards_Note">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnlook_Rewards" runat="server" CommandName="look_Rewards"
                                                        CommandArgument='<%#Eval("HRRewards_ID")%>'>查看详情</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnedit_Rewards" runat="server" CommandName="edit_Rewards"
                                                       CommandArgument='<%#Eval("HRRewards_ID")%>'>编辑</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDelete_Rewards" runat="server" CommandName="Delete_Rewards"
                                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("HRRewards_ID")%>'>删除</asp:LinkButton>
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
                                                        <asp:TextBox ID="textbox44" runat="server" Width="20px"></asp:TextBox>
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
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                    <tr>
                        <td align="center">
                            <asp:Button ID="BtnRewardnewClose11" runat="server" CssClass="Button02" Height="24px"
                                Text="关闭" Visible="true" Width="70px" OnClick="BtnRewardnewClose_Click11" />
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
                    <legend><asp:Label ID="Label99" runat="server"></asp:Label>奖惩详请</legend>
                    <asp:Label ID="Label98" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="editornew" runat="server" Text="" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label87" runat="server" Text="工号:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="TextBox6" runat="server" Width="130px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label90" runat="server" Text="姓名:" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="TextBox7" runat="server" Width="130px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%"></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label92" runat="server"  Text="奖惩类型:" ></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="130px">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="奖励" Value="奖励"></asp:ListItem>
                                    <asp:ListItem Text="处罚" Value="处罚"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label91" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label93" runat="server"   Text="奖惩金额:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox9" runat="server" Width="130px" MaxLength="15" onkeyup="this.value=this.value.replace(/^(\-)*(\d+)\.(\d\d).*$/,'$1$2.$3')"
                                    onafterpaste="this.value=this.value.replace(/^(\-)*(\d+)\.(\d\d).*$/,'$1$2.$3')"></asp:TextBox>
                                <asp:Label ID="Label94" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label108" runat="server"   Text="批准人:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox12" runat="server" Width="130px" ></asp:TextBox>
                                <asp:Label ID="Label109" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td align="center">
                                <asp:Label ID="Label103" runat="server"   Text="发生时间:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox10" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="130px"></asp:TextBox>
                                <asp:Label ID="Label104" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label106" runat="server"   Text="生效时间:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox11" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="130px"></asp:TextBox>
                                <asp:Label ID="Label107" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <tr >
                                <td  align="center">
                                    <asp:Label ID="Label95" runat="server"   Text="奖惩内容:<br>(200字内)" ></asp:Label>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="TextBox8" runat="server" Width="90%" Height="70px" TextMode="MultiLine"
                                        MaxLength="200"></asp:TextBox>
                                    <asp:Label ID="Label96" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr >
                                <td align="center">
                                    <asp:Label ID="Label105" runat="server"   Text="备注:<br>(200字内)"></asp:Label>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="TextBox18" runat="server" Width="90%" Height="70px" TextMode="MultiLine"
                                        MaxLength="200"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="BtnRewardSubmit" runat="server" Text="提交" CssClass="Button02"
                                        Height="24px" Width="70px" OnClick="BtnRewardSubmit_Click" />
                                </td>
                                <td align="center" colspan="2" >
                                    <asp:Button ID="BtnRewardCancel11" runat="server" Text="关闭" CssClass="Button02"
                                        Height="24px" Visible="true" Width="70px" OnClick="BtnRewardCancel_Click11"/>
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="BtnRewardCancel" runat="server" Text="关闭" CssClass="Button02"
                                        Height="24px" Visible="true" Width="70px" OnClick="BtnRewardCancel_Click"/>
                                </td>
                            </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
