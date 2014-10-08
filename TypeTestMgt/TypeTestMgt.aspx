<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="TypeTestMgt.aspx.cs" Inherits="TypeTestMgt_TypeTestMgt"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <%--型式实验计划检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <asp:Label ID="Lab_Status" runat="server"  Visible="False"></asp:Label>
           <asp:Panel ID="Panel_Search" runat="server" >
            <fieldset>
                <legend>型式实验计划检索</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Lbltype" runat="server" Text="年份："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextTTM_Year" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label1" runat="server" Text="月份："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="TextTTM_Month" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 10%" align="right">
                            <asp:Label ID="Label2" runat="server" Text="状态："></asp:Label>
                        </td>
                        <td >
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="130px">
                                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                <asp:ListItem Text="已制定" Value="已制定"></asp:ListItem>
                                <asp:ListItem Text="已完成" Value="已完成"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="制定人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextTTM_Maker" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="指定时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="TextTTM_Time" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("TTM_Time","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                        </td>
                        <td align="right"></td>
                        <td ></td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right" colspan="2">
                            <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" CssClass="Button02" OnClick="Btn_Search_Click" Height="24px"/>
                        </td>
                        <td style="height: 16px; " align="center" colspan="2">
                            <asp:Button ID="Btn_New" runat="server" Text="新增型式实验计划" Width="110px" CssClass="Button02" OnClick="Btn_New_Click" Height="24px"/>
                        </td>
                        <td  align="left" colspan="2">
                            <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Text="重置" Width="70px" OnClick="Btn_Clear_Click" Height="24px"/>
                        </td>
                    </tr>
                </table>
            </fieldset>
          </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--型式实验计划列表--%>
    <asp:UpdatePanel ID="UpdatePanel_TypeTestMan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TypeTestMan" runat="server" UpdateMode="Conditional">
                <fieldset>
                    <legend>型式实验计划列表</legend>
                    <asp:Label ID="Label_ttmid" runat="server" Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_TypeTestMan" runat="server" DataKeyNames="TTM_TypePlanID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%" 
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_TypeTestMan_PageIndexChanging" OnRowCommand="Grid_TypeTestMan_RowCommand"
                        onrowcancelingedit="Grid_TypeTestMan_RowCancelingEdit"  onrowediting="Grid_TypeTestMan_RowEditing" 
                        onrowupdating="Grid_TypeTestMan_RowUpdating" OnRowDataBound="Grid_TypeTestMan_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TTM_TypePlanID" HeaderText="型式实验计划ID" ReadOnly="True" SortExpression="TTM_TypePlanID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTM_Year" HeaderText="年份" SortExpression="TTM_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTM_Month" HeaderText="月份" SortExpression="TTM_Month" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTM_Maker" HeaderText="制定人" SortExpression="TTM_Maker" ReadOnly="True">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="TTM_Time" HeaderText="制定时间">
                                <ItemTemplate>
                                    <asp:Label ID="TTM_Time" runat="server" Text='<%# Eval("TTM_Time","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TTM_Time" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                        Text='<%# Eval("TTM_Time","{0:yyyy-MM-dd HH:mm:ss}") %>' ></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TTM_State" HeaderText="状态" ReadOnly="True" SortExpression="TTM_State" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandArgument='<%#Eval("TTM_TypePlanID")%>' CommandName="Look1"
                                        OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Item1" runat="server" CommandArgument='<%#Eval("TTM_TypePlanID")+","+Eval("TTM_State")%>'  
                                     CommandName="Item1" OnClientClick="false">计划详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("TTM_TypePlanID")%>'>删除</asp:LinkButton>
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

    <%--型式实验计划详情--%>
    <asp:UpdatePanel ID="UpdatePanel_Detail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Detail" runat="server" UpdateMode="Conditional"  Visible="False">
                <fieldset>
                    <legend>型式实验计划详情</legend>
                    <asp:Label ID="Label_ttdid" runat="server" Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 13%" align="right">
                                <asp:Label ID="Label14" runat="server" Text="厂家："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="TextBox4" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label15" runat="server" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="TextBox5" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 13%" align="right">
                                <asp:Label ID="Label17" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td >
                               <asp:TextBox ID="TextBox6" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label13" runat="server" Text="实验编号："></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox7" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label19" runat="server" Text="实验报告编号："></asp:Label>
                            </td>
                            <td >
                               <asp:TextBox ID="TextBox8" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label18" runat="server" Text="是否上传报告："></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="是" Value="是"></asp:ListItem>
                                    <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label22" runat="server" Text="实验结果："></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="合格" Value="合格"></asp:ListItem>
                                    <asp:ListItem Text="不合格" Value="不合格"></asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Text="检索" Width="70px" OnClick="Button1_Click" Height="24px"/>
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="add_detail" runat="server" CssClass="Button02" Text="新增产品型号" Width="110px" OnClick="add_detail_Click" Height="24px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Text="重置" Width="70px" OnClick="Button2_Click" Height="24px"/>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Detail" runat="server" DataKeyNames="TTD_DetailID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%" 
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="GridView_Detail_PageIndexChanging" OnRowCommand="GridView_Detail_RowCommand"
                        OnRowDataBound="GridView_Detail_RowDataBound" GridLines="None" onrowcancelingedit="GridView_Detail_RowCancelingEdit"  
                        onrowediting="GridView_Detail_RowEditing" onrowupdating="GridView_Detail_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TTD_DetailID" HeaderText="型式实验详情ID" ReadOnly="True" SortExpression="TTD_DetailID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" ReadOnly="True" SortExpression="PT_ID" Visible ="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTM_TypePlanID" HeaderText="型式实验计划ID" ReadOnly="True" SortExpression="TTM_TypePlanID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTD_Company" HeaderText="厂家名称" SortExpression="TTD_Company">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ReadOnly="True" SortExpression="PS_Name">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" SortExpression="PT_Name">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="TTD_ExpNO" HeaderText="实验编号" ReadOnly="True" SortExpression="TTD_ExpNO">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="TTD_IsUploaded" HeaderText="是否上传报告" ReadOnly="True" SortExpression="TTD_IsUploaded">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="TTD_ReportNO" HeaderText="实验报告编号" ReadOnly="True" SortExpression="TTD_ReportNO">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="TTD_UpPer" HeaderText="上传人" ReadOnly="True" SortExpression="TTD_UpPer">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="TTD_UpTime" HeaderText="上传时间" >
                                <ItemTemplate>
                                    <asp:Label ID="TTD_UpTime" runat="server" Text='<%# Eval("TTD_UpTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TTD_RepRoute" HeaderText="型式实验报告路径" ReadOnly="True" SortExpression="TTD_RepRoute" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTD_IsPass" HeaderText="实验结果" ReadOnly="True" SortExpression="TTD_IsPass">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑厂家" UpdateText="更新" CancelText="关闭" >
                                <ItemStyle />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down2" CommandName="Down2" runat="server" CommandArgument='<%#Eval("TTD_RepRoute")%>'
                                    NavigateUrl='<%#"~/"+Eval("TTD_RepRoute")+"?path={0}"%>'>下载实验报告</asp:HyperLink> 
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Up2" runat="server" CommandArgument='<%#Eval("TTD_DetailID")+","+Eval("TTD_RepRoute")%>' CommandName="Up2"
                                        OnClientClick="false">上传实验报告</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("TTD_DetailID")+","+Eval("TTD_RepRoute")%>'>删除</asp:LinkButton>
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
                    <asp:Panel ID="Panel10" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="right" style="width: 25%;"></td>
                            <td style="width: 33%" >
                                <asp:Button ID="ok_detail" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="ok_detail_Click" Height="24px" ToolTip="本月实验计划全部完毕后提交！"/>
                            </td>
                            <td style="height: 16px; "align="left">
                                <asp:Button ID="close_detail" runat="server" CssClass="Button02" Text="关闭" Width="70px" OnClick="close_detail_Click" Height="24px"/>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="center">
                                 <asp:Button ID="close_detail2" runat="server" CssClass="Button02" Text="关闭" Width="70px" OnClick="close_detail2_Click" Height="24px"/>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--新增型式实验计划--%>
    <asp:UpdatePanel ID="UpdatePanel_TypeTest" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TypeTest" runat="server" Visible="False">
                <fieldset>
                    <legend>新增型式实验计划</legend>
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 25%" align="right">
                            <asp:Label ID="Label37" runat="server" Text="年份："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="addyear" runat="server" Width="130px" Height="20px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="16"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="addyear" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label38" runat="server" Text="月份："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="addmonth" runat="server" Width="130px" Height="20px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="8"></asp:TextBox>
                            <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="addmonth" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                            <asp:Label ID="Label40" runat="server" Text="制定人："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="addmaker" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="addmaker" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td  align="right">
                            <asp:Label ID="Label41" runat="server" Text="制定时间："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="addtime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("TTM_Time","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"  Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="addtime" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right"></td>
                        <td colspan="2">
                            <asp:Button ID="Ok_new" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="Ok_new_Click" ValidationGroup="addvalidation" Height="24px"/>
                        </td>
                        <td style="height: 16px;" align="left">
                            <asp:Button ID="Cancel_new" runat="server" CssClass="Button02" Text="关闭" Width="70px" OnClick="Cancel_new_Click" Height="24px"/>
                        </td>
                    </tr>
                </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--选择产品型号--%>
      <asp:UpdatePanel ID="UpdatePanel_Newpt" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Newpt" runat="server" Visible="False">
                <fieldset>
                    <legend>选择产品型号</legend>
                    <table style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 15%;">
                            <asp:Label ID="Label45" runat="server" Text="产品系列：" ></asp:Label>
                        </td>
                        <td style="width: 18%;">
                            <asp:TextBox ID="textps" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 12%;">
                            <asp:Label ID="Label46" runat="server" Text="产品型号：" ></asp:Label>
                        </td>
                        <td style="width: 15%;">
                            <asp:TextBox ID="textpt" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width: 8%;"></td>
                        <td align="left">
                            <asp:Button ID="Search_newpt" runat="server" Text="检索" Width="70px" CssClass="Button02" onclick="Search_newpt_Click" Height="24px"/> </td>
                        <td align="left">
                            <asp:Button ID="Clear_newpt" runat="server" CssClass="Button02"  OnClick="Clear_newpt_Click" Text="重置" Width="70px" Height="24px"/> 
                        </td>
                    </tr>
                    <tr>
                       <td colspan="7" align="center">
                        <asp:GridView ID="Grid_Newpt" runat="server" DataKeyNames="PT_ID" AllowSorting="True" 
                            AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                            AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False" 
                            OnPageIndexChanging="Grid_Newpt_PageIndexChanging" 
                            onrowcommand="Grid_Newpt_RowCommand"
                            OnRowDataBound="Grid_Newpt_RowDataBound" GridLines="None">
                            <RowStyle CssClass="GridViewRowStyle" />  
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle  cssclass="GridViewHead"/>
                            <FooterStyle CssClass="GridViewFooterStyle" />
                              <Columns>
                              <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                  <asp:CheckBox ID="ckb" runat="server"/>
                                </ItemTemplate>
                                <ItemStyle/>
                              </asp:TemplateField>
                              <asp:BoundField DataField="PS_ID" HeaderText="产品系列ID" ReadOnly="True" SortExpression="PS_ID" Visible="False">
                                <ItemStyle />
                              </asp:BoundField>
                              <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" ReadOnly="True" SortExpression="PT_ID" Visible="False">
                                <ItemStyle />
                              </asp:BoundField>
                              <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ReadOnly="True" SortExpression="PS_Name">
                                <ItemStyle/>
                              </asp:BoundField>
                              <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                                <ItemStyle/>
                              </asp:BoundField>
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
                                </table>
                            </PagerTemplate>
                            <EmptyDataTemplate>
                                <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;" align="right" colspan="2">
                           <asp:Button ID="BtnOK_Newpt" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="BtnOK_Newpt_Click" ValidationGroup="addsparevalidation" Height="24px"/>
                       </td>
                        <td style="height: 30px">
                          </td>
                        <td></td>
                        <td style="height: 30px"align="left">
                            <asp:Button ID="BtnCancel_Newpt" runat="server" Text="关闭" CssClass="Button02" Width="70px" OnClick="BtnCancel_Newpt_Click"  Height="24px"/>
                        </td>
                    </tr>                              
                 </table>     
            </fieldset>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<%--上传实验报告--%>
 <div id="Panel99">
    <asp:UpdatePanel ID="UpdatePanel_upload" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>上传实验报告</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 17%" align="right">
                            <asp:Label ID="Label5" runat="server" Text="实验报告编号："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="reportno" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="reportno" ValidationGroup="loadvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 10%" align="right">
                            <asp:Label ID="Label6" runat="server" Text="上传人："></asp:Label>
                        </td>
                        <td style="width: 18%">
                            <asp:TextBox ID="upper" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="upper" ValidationGroup="loadvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 10%" align="right">
                            <asp:Label ID="Label7" runat="server" Text="上传时间："></asp:Label>
                        </td>
                        <td >
                            <asp:TextBox ID="uptime" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="uptime" ValidationGroup="loadvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right">
                                <asp:Label ID="Label23" runat="server" Text="实验结果："></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="130px">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="合格" Value="合格"></asp:ListItem>
                                    <asp:ListItem Text="不合格" Value="不合格"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" Text="上传附件："></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:FileUpload ID="FileUpload1" runat="server"  Width="362px" Height="20px"/>
                            <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                    ControlToValidate="FileUpload1" ValidationGroup="loadvalidation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="height: 16px;">
                        <td align="right" colspan="2">
                            <asp:Button ID="ok_upload" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="ok_upload_Click"  ValidationGroup="loadvalidation" Height="24px"/>
                            
                        </td>
                        <td style="height: 16px; " align="center" colspan="2"></td>
                        <td  align="left" colspan="2">
                            <asp:Button ID="cancel_upload" runat="server" Text="关闭" Width="70px" CssClass="Button02" OnClick="cancel_upload_Click"  Height="24px"/>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ok_upload" />
        </Triggers>
    </asp:UpdatePanel>
 </div>



</asp:Content>