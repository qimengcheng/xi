<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMOrderDeliverPlan.aspx.cs" Inherits="SalesMgt_SMOrderDeliverPlan" 
MasterPageFile="~/Other/MasterPage.master" Title="发货管理"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JS/ShortM.js" />
        </Scripts>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
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
    </script>
    <script type="text/javascript">

        function MaxLength(field, maxlimit) {
            var j = field.value.replace(/[^\x00-\xff]/g, "**").length;

            var tempString = field.value;
            var tt = "";
            if (j > maxlimit) {
                for (var i = 0; i < maxlimit; i++) {
                    if (tt.replace(/[^\x00-\xff]/g, "**").length < maxlimit)
                        tt = tempString.substr(0, i + 1);
                    else
                        break;
                }
                if (tt.replace(/[^\x00-\xff]/g, "**").length > maxlimit)
                    tt = tt.substr(0, tt.length - 1);
                field.value = tt;
            }
            else {
                ;
            }
        }
  
 
</script>
    <script type="text/javascript">
        function setRadio(nowRadio) {
            var myForm, objRadio;
            myForm = document.forms[0];
            ///alert(myForm);
            for (var i = 0; i < myForm.length; i++) {
                if (myForm.elements[i].type == "radio") {
                    objRadio = myForm.elements[i];
                    ///alert(objRadio.name);
                    if (objRadio != nowRadio && objRadio.name.indexOf("Gridview_MatType") > -1 && objRadio.name.indexOf("RadioButton1") > -1) {

                        if (objRadio.checked) {
                            objRadio.checked = false;
                        }

                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        function setRadio1(nowRadio) {
            var myForm, objRadio;
            myForm = document.forms[0];
            ///alert(myForm);
            for (var i = 0; i < myForm.length; i++) {
                if (myForm.elements[i].type == "radio") {
                    objRadio = myForm.elements[i];
                    ///alert(objRadio.name);
                    if (objRadio != nowRadio && objRadio.name.indexOf("Gridview_PT") > -1 && objRadio.name.indexOf("RadioButton2") > -1) {

                        if (objRadio.checked) {
                            objRadio.checked = false;
                        }

                    }
                }
            }
        }
    </script>
    <%--    // 弹出窗口的js--%>
    <script language="javascript" type="text/javascript">
        function test1() {
            var aa = window.confirm("单击“确定”继续。单击“取消”停止。");
            if (aa) {
                window.alert("你选了确定！");
            }
            else window.alert("你选了取消！");
        }
    </script>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <asp:Label ID="Label5" runat="server"  Visible="false"></asp:Label>
                <fieldset>
                    <legend>发货计划检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                        <td style="width: 20%" align="center">
                             
                            </td>
                            <td style="width: 15%" align="center">
                               发货计划日期：
                            </td>
                            <td align="left" style="width: 20%">
                                 <asp:TextBox runat="server" ID="TextBox9" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="120px"  ></asp:TextBox>
                            </td>
                            <td  align="left">
                                <asp:Button ID="Button2" runat="server" Text="检索" CssClass="Button02" 
                                    OnClick="SearchDeliverPlan" Width="70px" />
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="新建发货计划" CssClass="Button02" 
                            OnClick="NewDeliverPlan" Width="90px" />
                            </td>
                          
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 发货计划表--%>
     <asp:UpdatePanel ID="UpdatePanel_OrderDeliverPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OrderDeliverPlan" runat="server" Visible="true">
                <fieldset>
                    <legend>发货计划表</legend>
                    <asp:GridView ID="GridView_OrderDeliverPlan" runat="server" AllowPaging="True" PageSize="20"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMDP_ID"
                        AllowSorting="True" OnRowCommand="GridView_OrderDeliverPlan_RowCommand" 
                        Width="100%" OnPageIndexChanging="GridView_OrderDeliverPlan_PageIndexChanging" 
                        onrowcancelingedit="GridView_OrderDeliverPlan_RowCancelingEdit" 
                        onrowediting="GridView_OrderDeliverPlan_RowEditing" 
                        onrowupdating="GridView_OrderDeliverPlan_RowUpdating"
                        Font-Strikeout="False" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        
                            <asp:BoundField DataField="SMDP_ID" HeaderText="发货计划ID" Visible="false" />
                              <asp:BoundField DataField="SMDP_Time" HeaderText="计划日期" ReadOnly="True"  DataFormatString="{0:yyyy-MM-dd}"/>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="订单号" ReadOnly="True"/>  
                            <asp:BoundField DataField="SMSOD_OrderDelTime" HeaderText="订单交货期" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd }" />
                             <asp:BoundField DataField="SMSOD_OrderAdvanceDelTime" HeaderText="预交货期" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd}"/>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" />
                            <asp:BoundField DataField="SMSOD_MCode" HeaderText="物料编号" ReadOnly="true" />
                             <asp:BoundField DataField="SMSOD_Mount" HeaderText="订单数量" ReadOnly="true" />
                            <asp:BoundField DataField="SMDP_Num" HeaderText="发货数量" />
                            <asp:BoundField DataField="SMDP_MakeTime" HeaderText="制定时间" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd HH:mm}"/>
                            <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="单价" ReadOnly="true" />
                             <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消" />
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SMDP_ID")%>'>删除</asp:LinkButton>
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
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="false">
                <fieldset>
                    <legend>订单检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="right">
                                客户名称：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox3" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                公司订单号：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox4" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                客户订单号：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox5" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                产品型号：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox6" Width="98px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                业务员：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox7" Width="98px"></asp:TextBox>
                            </td>
                            <td align="right">
                                区域：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox8" Width="98px"></asp:TextBox>
                            </td>
                            <td align="right">
                                特殊产品：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>选择是否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                订单状态：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                    <asp:ListItem>选择订单状态</asp:ListItem>
                                    <asp:ListItem>已新建</asp:ListItem>
                                    <asp:ListItem>正常</asp:ListItem>
                                    <asp:ListItem>已发货</asp:ListItem>
                                    <asp:ListItem>冻结</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>选择日期类型</asp:ListItem>
                                    <asp:ListItem>下单日期</asp:ListItem>
                                    <asp:ListItem>交货期</asp:ListItem>
                                    <asp:ListItem>预交货期</asp:ListItem>
                                </asp:DropDownList>
                                从
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox runat="server" ID="TextBox1" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px"  ></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox2" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px"  ></asp:TextBox>
                            </td>
                            <td align="right">
                                订单类型：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                    <asp:ListItem>选择订单类型</asp:ListItem>
                                    <asp:ListItem>正常订单</asp:ListItem>
                                    <asp:ListItem>代工订单</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                付款方式：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>选择付款方式</asp:ListItem>
                                    <asp:ListItem>现款现货</asp:ListItem>
                                    <asp:ListItem>账期</asp:ListItem>
                                    <asp:ListItem>货到付款</asp:ListItem>
                                    <asp:ListItem>预付款</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button3" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchOrder" Width="70px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button1" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="ClearOrder" Width="70px" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button11" runat="server" Text="查看预设提醒订单" CssClass="Button02" Height="24px"
                                    OnClick="CreateOrdered" Width="110px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- 订单详细表开始-->
    <asp:UpdatePanel ID="UpdatePanel_OrderDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OrderDetail" runat="server" Visible="false">
                <fieldset>
                    <legend>订单表</legend>
                    <asp:Label ID="Label6" runat="server"  Visible="false"></asp:Label>
                    <asp:GridView ID="GridView_OrderDetail" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMSOD_ID"
                        Width="100%" AllowSorting="True" GridLines="None"
                        OnPageIndexChanging="GridView_OrderDetail_PageIndexChanging" 
                        onrowdatabound="GridView_OrderDetail_RowDataBound" 
                        onrowcommand="GridView_OrderDetail_RowCommand" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                           <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSOD_ID" HeaderText="订单详细ID" Visible="false" />
                                                       <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="公司订单号" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_CusOrderNum" HeaderText="客户订单号">  
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" />
                             <asp:BoundField DataField="SMCBPM_MaturityLoan" HeaderText="到期贷款" ReadOnly="True" />
                            <asp:BoundField DataField="CRMRBI_Name" HeaderText="区域" ReadOnly="True" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="true" />
                             <asp:BoundField DataField="SMSOD_MCode" HeaderText="物料编号" ReadOnly="true" />
                            <asp:BoundField DataField="IMIM_TotalNum" HeaderText="库存" ReadOnly="true" />   
                           
                            <asp:BoundField DataField="SMSOD_Mount" HeaderText="数量" ReadOnly="true" />
                             <asp:BoundField DataField="SMSOD_DelMount" HeaderText="已发货" ReadOnly="true" />
                               <asp:BoundField DataField="SMSOD_OrderDelTime" HeaderText="交货期" Visible="true" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd }" />
                                <asp:BoundField DataField="SMSOD_OrderAdvanceDelTime" HeaderText="预交货期" Visible="true" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd }" />
                            <asp:BoundField DataField="SMSOD_DelAlertTime" HeaderText="提醒天数" HeaderStyle-Width="40px">         
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_DelCondition" HeaderText="发货情况" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_AllowSpecDel" HeaderText="允许特殊发货" Visible="true"
                                HeaderStyle-Width="40px" ReadOnly="true"></asp:BoundField>
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Special1" runat="server" CommandName="Special1" OnClientClick="false" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSOD_ID")%>'>特殊发货申请</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="History" runat="server" CommandName="History" OnClientClick="false" 
                                        CausesValidation="false" CommandArgument='<%#Eval("SMSOD_ID")%>'>查看发货申请记录</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                                
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
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
                    <table style="width:100%">
                      <tr>
                            <td style="width: 30%" align="center">
                                </asp:Label> <asp:Label ID="Label2" runat="server" Text="欠款不允许发货"  BackColor="Red" Width="150px" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 30%" align="center">
                               </asp:Label> <asp:Label ID="Label4" runat="server" Text="欠款但允许特殊发货" BackColor="Green" Width="150px" Visible="true"></asp:Label>
                            </td>
                          <td style="width: 30%" align="center">
                               </asp:Label> <asp:Label ID="Label9" runat="server" Text="正常订单" BackColor="Skyblue" Width="150px" Visible="true"></asp:Label>
                            </td>
                    </table>
                    <table style="width: 100%">
                        <tr>
                         <td style="width: 30%" align="center">
                                  <asp:Label ID="Label7" runat="server" Text="插入发货计划的日期为："></asp:Label><asp:TextBox runat="server" ID="TextBox10" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px"  ></asp:TextBox>
                            </td>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmOrderInsert" Width="70px" />
                            </td>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CLoseOrderInsert" Width="70px" />
                            </td>
                          
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
        <%--申请制定开始--%>
       <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <asp:Label ID="Label3" runat="server"  Visible="false"></asp:Label>
                <fieldset>
                    <legend>特殊发货申请制定</legend>
                    <table style="width: 100%;">
                        <tr>
                      
                            <td style="width: 25%" align="right">
                               申请原因：<br />（200字内）
                            </td>
                            <td align="left" >
                                 <asp:TextBox runat="server" ID="TextBox12" 
                                 Width="90%" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                           
                              </tr>
                                <tr>
                            <td align="right">
                                <asp:Button ID="Button9" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmReason" Width="70px" />
                            </td>
                                <td align="center">
                                <asp:Button ID="Button10" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseReason" Width="70px" />
                            </td>
                          
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--申请开始--%>
       <asp:UpdatePanel ID="UpdatePanel_Shenqing" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Shenqing" runat="server" Visible="false">
                <asp:Label ID="Label1" runat="server"  Visible="false"></asp:Label>
                <fieldset>
                    <legend>特殊发货申请检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                        <td style="width: 10%" align="center">
                             客户名称:
                            </td>
                            <td style="width: 15%" align="center">
                                 <asp:TextBox runat="server" ID="TextBox13"  Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                             订单号:
                            </td>
                            <td style="width: 15%" align="center">
                                 <asp:TextBox runat="server" ID="TextBox11"  Width="98px"></asp:TextBox>
                            </td>
                             <td style="width: 10%" align="center">
                             业务员:
                            </td>
                            <td style="width: 15%" align="center">
                                 <asp:TextBox runat="server" ID="TextBox14"  Width="98px"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button5" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchApply" Width="80px" />    </td>
                             <td colspan="3" align="center">
                                      <asp:Button ID="Button8" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseSearchApply" Width="80px" />
                            </td>
                          
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <!-- 特殊发货申请表开始-->
    <asp:UpdatePanel ID="UpdatePanel_Shenqingbiao" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Shenqingbiao" runat="server" Visible="false">
                <fieldset>
                    <legend>特殊发货申请表</legend>
                    <asp:Label ID="Label8" runat="server"  Visible="false"></asp:Label>
                    <asp:GridView ID="GridView_shenqingbiao" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMSDA_ID"
                        Width="100%" AllowSorting="True" GridLines="None"
                        OnPageIndexChanging="GridView_shenqingbiao_PageIndexChanging" 
                        onrowcommand="GridView_shenqingbiao_RowCommand" 
                        ondatabound="GridView_shenqingbiao_DataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSDA_ID" HeaderText="申请ID" Visible="false" />
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" />
                              <asp:BoundField DataField="SMCBPM_TotalLoan" HeaderText="贷款总额" ReadOnly="True" />
                              <asp:BoundField DataField="SMSDA_TotalOverdueLoan" HeaderText="到期贷款" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="订单号">  
                            </asp:BoundField> 
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" />
                            <asp:BoundField DataField="SMSOD_Mount" HeaderText="数量" ReadOnly="True" />
                            <asp:BoundField DataField="SMSDA_ApplyMan" HeaderText="业务员" ReadOnly="true" />
                            <asp:BoundField DataField="SMSDA_ApplyReason" HeaderText="申请原因" ReadOnly="true" />   
                            <asp:BoundField DataField="SMSDA_ApplyTime" HeaderText="申请时间" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="SMSDA_ApplyState" HeaderText="状态" ReadOnly="true" />
                               <asp:BoundField DataField="SMSDA_CheckMan" HeaderText="审核人" Visible="true" ReadOnly="true"/>
                                <asp:BoundField DataField="SMSDA_CheckResult" HeaderText="审核结果" Visible="true" ReadOnly="true" />
                            <asp:BoundField DataField="SMSDA_CheckOpinion" HeaderText="审核意见" >         
                            </asp:BoundField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="delete1" runat="server" CommandName="delete1" OnClientClick="return confirm('确认删除此条记录么？')" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSDA_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="check1" runat="server" CommandName="checke1" OnClientClick="false" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSDA_ID")%>'>审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <%--  
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                        CausesValidation="false" CommandArgument='<%#Eval("SMSOD_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="History" runat="server" CommandName="History" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSOD_ID")%>'>查看预交货期修改历史</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
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
                  
                    <table style="width: 100%">
                        <tr>
                            <%--<td style="width: 30%" align="center">
                                <asp:Button ID="Button12" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmOrderInsert" Width="80px" />
                            </td>--%>
                            <td align="center">
                                <asp:Button ID="Button13" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="Closeshenqingbiao" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel_Check" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Check" runat="server" Visible="false">
                <fieldset>
                    <legend>特殊发货申请会签栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%">
                                <asp:Label ID="label12" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 10%">
                                审核人:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox_AddMan" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                审核时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox_Addtime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                审核意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox_AddOpinion" runat="server" Height="80px" MaxLength="200" onkeyup="this.value = this.value.slice(0, 200)"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button17" runat="server" CssClass="Button02" OnClick="BT_ADD_TKOK_Click" Height="24px"
                                    Text="通过" Width="70px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                                <asp:Button ID="Button18" runat="server" CssClass="Button02" OnClick="BT_ADD_TKNotOK_Click" Height="24px"
                                    Text="驳回" Width="70px" />
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button19" runat="server" CssClass="Button02" OnClick="BT_ADD_TKCanel_Click" Height="24px"
                                    Text="取消" Width="70px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   </asp:Content>