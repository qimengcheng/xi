<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchasingPlanTwo.aspx.cs" Inherits="PurchasingMgt_PurchasingPlan"  MasterPageFile="~/Other/MasterPage.master" Title="采购计划管理" %>
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
       <%-- 检索--%>
   <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label21" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList11" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList7" runat="server">
                                <asp:ListItem>选择状态</asp:ListItem>
                                    <asp:ListItem>已新建</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem> 
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button5" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchMonthPlan" Width="70px" />
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button6" runat="server" Text="新建采购计划" CssClass="Button02" Height="24px"
                                    OnClick="CreateMonthPlan" Width="90px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_MonthPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MonthPlan" runat="server" Visible="True">
                <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>采购计划表</legend>
                    <asp:GridView ID="Gridview_MonthPlan" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="PMPPM_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_MonthPlan_PageIndexChanging" 
                        OnRowCommand="Gridview_MonthPlan_RowCommand" 
                        ondatabound="Gridview_MonthPlan_DataBound" 
                        onrowdatabound="Gridview_MonthPlan_RowDataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="PMPPM_ID" HeaderText="计划ID" ReadOnly="True" SortExpression="PMPPM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPPM_Year" HeaderText="年份" ReadOnly="false" SortExpression="PMPPM_Year"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPPM_Month" HeaderText="月份" ReadOnly="false" SortExpression="PMPPM_Month">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PMPPM_State" HeaderText="状态" ReadOnly="false" SortExpression="PMPPM_State">
                                <ItemStyle />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="PMPPM_Man" HeaderText="制定人" ReadOnly="True" SortExpression="PMPPM_Man"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPPM_Time" HeaderText="制定时间" SortExpression="PMPPM_Time"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail1" runat="server" CommandName="Detail1" OnClientClick="false"
                                        CommandArgument='<%#Eval("PMPPM_ID")%>'>详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除吗?')"
                                        CommandArgument='<%#Eval("PMPPM_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check1" runat="server" CommandName="Check1" 
                                        CommandArgument='<%#Eval("PMPPM_ID")%>'>审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Mat1" runat="server" CommandName="Mat1" 
                                        CommandArgument='<%#Eval("PMPPM_ID")%>'>查看材料月计划</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="MatWeek" runat="server" CommandName="MatWeek" 
                                        CommandArgument='<%#Eval("PMPPM_ID")%>'>查看材料周计划</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LookCheck" runat="server" CommandName="LookCheck" 
                                        CommandArgument='<%#Eval("PMPPM_ID")%>'>查看会签审核详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                  <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Buy1" runat="server" CommandName="Buy1" 
                                        CommandArgument='<%#Eval("PMPPM_ID")%>'>执行</asp:LinkButton>
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
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel_Detail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Detail" runat="server" Visible="false">
                <asp:Label ID="label53" runat="server" Visible="false"></asp:Label><asp:Label ID="label38" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend> <asp:Label ID="label31" runat="server" Visible="true"></asp:Label>采购计划详细表</legend>
                    <asp:Button ID="Button31" runat="server" Text="更新当前页计划数量" CssClass="Button02" Height="24px"
                                    OnClick="UpdateDetailNum" Width="140px" />
                    <table style="width:100%">
                        <tr>
                            <td>

                                <asp:CheckBox ID="CheckBox3" runat="server" Text="周计划剩余购买数不为0" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
                            </td>
                            <td align="right">
                                  <asp:Label ID="Label50" runat="server" ForeColor="Red"></asp:Label>
                            </td>

                        </tr>
                     </table>

                    <asp:GridView ID="Gridview_DetailPlan" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="30" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="PMPPD_ID,IMMBD_MaterialID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Detail_PageIndexChanging" 
                        OnRowCommand="Gridview_Detail_RowCommand" ondatabound="Gridview_DetailPlan_DataBound" 
                     
                      >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                          <asp:TemplateField Visible="false">
                                <ItemStyle Width="5%"  />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PMPPD_ID" HeaderText="计划ID" ReadOnly="True" SortExpression="PMPPD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="wuliaoID" ReadOnly="false" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="false" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="false" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PMPPD_Price" HeaderText="单价" ReadOnly="false" SortExpression="PMPPD_Price">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPPD_Num" HeaderText="材料计划数量" ReadOnly="false" SortExpression="PMPPD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                           
                              <asp:BoundField DataField="IMIM_TotalNum" HeaderText="库存" ReadOnly="false" SortExpression="IMIM_TotalNum">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PMPPD_ActualNum" HeaderText="采购计划数量" ReadOnly="True" SortExpression="PMPPD_ActualNum"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="UnitName" HeaderText="单位" ReadOnly="false" SortExpression="UnitName">
                                <ItemStyle />
                            </asp:BoundField>
                           
                            
                            <asp:BoundField DataField="PMPPD_Remark" HeaderText="备注" SortExpression="PMPPD_Remark"  >
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="PMPPD_ProductRequest" HeaderText="产品要求" ReadOnly="false" SortExpression="PMPPD_ProductRequest">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="采购计划数量" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Width="80px" Text='<%#Eval("PMPPD_ActualNum")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                              <asp:BoundField DataField="TotalNum" HeaderText="周计划累计" ReadOnly="false"  Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PMPPD_BuyNum" HeaderText="已购买数" ReadOnly="false" SortExpression="PMPPD_BuyNum">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Dnum" HeaderText="周计划剩余购买数" ReadOnly="false" SortExpression="Dnum">
                                <ItemStyle />
                            </asp:BoundField>
                            
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("PMPPD_ID")%>'>填写备注及产品要求</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认正确收货吗?')"
                                        CommandArgument='<%#Eval("PMPPD_ID")%>'>删除</asp:LinkButton>
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
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                      <table style="width:100%">
                    <tr>
                        <td style="width:30%" align="right">
                         
                                     <asp:Button ID="Button2" runat="server" Text="插入拟采购表单" CssClass="Button02" Height="24px" Visible="false"
                                    OnClick="Order_MonthPlan" Width="140px" />
                        
                        </td>
                        <td style="width:40%" align="center">
                         <asp:Button ID="Button32" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseDetail" Width="70px" />
                         
                        </td>
                        <td style="width:30%" align="left">
                        
                         <asp:Button ID="Button33" runat="server" Text="提交采购计划" CssClass="Button02" Height="24px"
                                    OnClick="TijiaoPlanMain" Width="140px" />
                        </td>
                    </tr></table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <asp:Label ID="label20" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label28" runat="server" Visible="true"></asp:Label>采购计划审核会签详情表</legend>
                    <asp:GridView ID="Gridview4" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="PMPPM_ID" GridLines="None"
                        Width="100%" 
                        ondatabound="Gridview_MonthPlan1_DataBound" 
 >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="PMPPM_ID" HeaderText="计划ID" ReadOnly="True" SortExpression="PMPPM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPPM_R1CheckResult" HeaderText="财务主管审核结果" ReadOnly="false" SortExpression="PMPPM_R1CheckResult"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPPM_R1CheckOpinion" HeaderText="财务主管审核意见" ReadOnly="false" SortExpression="PMPPM_R1CheckOpinion">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PMPPM_R1CheckTime" HeaderText="财务主管审核时间" ReadOnly="false" SortExpression="PMPPM_R1CheckTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="PMPPM_R2CheckResult" HeaderText="主管经理审核结果" ReadOnly="True" SortExpression="PMPPM_R2CheckResult"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPPM_R2CheckOpinion" HeaderText="主管经理审核意见" SortExpression="PMPPM_R2CheckOpinion"   >
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="PMPPM_R2CheckTime" HeaderText="主管经理审核时间" ReadOnly="false" SortExpression="PMPPM_R2CheckTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="PMPPM_CFOCheckResult" HeaderText="财务总监审核结果" SortExpression="PMPPM_CFOCheckResult"   >
                                <ItemStyle />
                            </asp:BoundField>
                        <asp:BoundField DataField="PMPPM_CFOCheckOpinion" HeaderText="财务总监审核意见" SortExpression="PMPPM_CFOCheckOpinion"   >
                                <ItemStyle />
                             </asp:BoundField>
                             <asp:BoundField DataField="PMPPM_CFOCheckTime" HeaderText="财务总监审核时间" SortExpression="PMPPM_CFOCheckTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                           
                        </Columns>
                    
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>  <table style="width:100%">
                    <tr>
                       
                        <td style="width:40%" align="center">
                         <asp:Button ID="Button27" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseCheckDetail" Width="70px" />
                         
                        </td>
                     
                    </tr></table>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%-- 新建投诉类别--%>
   <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <asp:Label ID="label1" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>新建采购计划</legend>
                    <table style="width: 100%">
                        <tr>
                             <td style="width: 25%" align="right">
                                <asp:Label ID="Label5" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList8" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label17" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList9" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    
                        </table>
                        <table width="100%">
                        <tr>
                            <td style="width:50%"  align="center">
                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewPlanMain" Width="70px" />
                            </td>
                              <td style="width:50%"  align="center">
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="CloseNewPlanMain" Text="关闭"   Width="70px" />
                            </td>
                        </tr>
                    </table>
                  
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%-- 审核--%>
          <asp:UpdatePanel ID="UpdatePanel_ADDCheck" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ADDCheck" runat="server" Visible="false">
                <fieldset>
                <asp:Label ID="Label33" runat="server"  Visible="false"></asp:Label>
                       <asp:Label ID="Label29" runat="server"  Visible="false"></asp:Label>
                     <asp:Label ID="Label30" runat="server"  Visible="false"></asp:Label>
                    <legend>审核栏</legend>
                    <table style="width: 100%;">
                        <tr>
                         
                            <td style="width: 15%" align="right">
                                审核人:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox_AddMan" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">
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
                          
                            <td align="right">
                                审核意见:<br/>（200字内）
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox_AddOpinion" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button19" runat="server" CssClass="Button02" OnClick="Check_OK" Height="24px"
                                    Text="通过" Width="70px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                                <asp:Button ID="Button20" runat="server" CssClass="Button02" OnClick="Check_NotOK" Height="24px"
                                    Text="驳回" Width="70px" />
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button21" runat="server" CssClass="Button02" OnClick="Check_Canel"
                                    Text="关闭" Width="70px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <%--投诉类别表--%>
  
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <asp:Label ID="label32" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>拟采购表单</legend>
                    <asp:GridView ID="Gridview5" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                      
                        DataKeyNames="PMPMT_ID" GridLines="None"
                        Width="100%" 
                        ondatabound="Gridview_MonthPlan1_DataBound" 
 >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="PMPMT_ID" HeaderText="计划ID" ReadOnly="True" 
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" >
                                <ItemStyle />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="PMPMT_Num" HeaderText="数量" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" HeaderText="单位" >
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="PMPMT_Price" HeaderText="单价" ReadOnly="true">
                                <ItemStyle />
                            </asp:BoundField>
                        </Columns>
                    
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>  <table style="width:100%">
                          <asp:Label ID="temp_alter" runat="server" Visible="true" Text="拟采购表单里的物料将生成一个订单，所以请确保拟采购表单里的物料是向同一供应商采购的！" ForeColor="Red"></asp:Label>
                    <tr>

                       <td style="width:40%" align="center">
                         <asp:Button ID="Button28" runat="server" Text="生成采购订单" CssClass="Button02" Height="24px"
                                    OnClick="OrderCreate" Width="93px" />
                         
                        </td>
                        <td style="width:40%" align="center">
                         <asp:Button ID="Button23" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseCheckDetail" Width="70px" />
                         
                        </td>
                     
                    </tr></table>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- 新建投诉类别--%>
   <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel9" runat="server" Visible="false">
                <asp:Label ID="label25" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>编辑采购计划详细</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label26" runat="server" Text="产品要求：（200字内）"></asp:Label>
                            </td>
                            <td  style="width:85%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1" Enabled="true"  Width="90%" 
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                           
                           
                        </tr>
                    
                        <tr>
                            <td  align="center">
                                <asp:Label ID="Label27" runat="server" Text="备注：<br/>（200字内）"></asp:Label>
                            </td>
                            <td  colspan="2" align="left">
                                <asp:TextBox runat="server" ID="TextBox5" Enabled="true"  Width="90%" 
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                        <table width="100%">
                        <tr>
                            <td style="width:50%"  align="center">
                                <asp:Button ID="Button12" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmDetailUpdate" Width="70px" />
                            </td>
                              <td style="width:50%"  align="center">
                                <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="CloseDetailUpdate" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                  
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%-- 检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Choose" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Choose" runat="server" Visible="false">
                <asp:Label ID="label2" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>材料周计划查看</legend>
                    <table style="width:100%">
                    
                   
                        <tr>
                             <td style="width: 10%" align="center">
                                <asp:Label ID="Label23" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 23%" align="left">
                                <asp:DropDownList ID="DropDownList10" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label45" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 23%" align="left">
                                <asp:DropDownList ID="DropDownList12" runat="server">
                                </asp:DropDownList>
                            </td>
                                 <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="周次："></asp:Label>
                            </td>
                            <td style="width: 23%" align="left">
                                <asp:DropDownList ID="DropDownList13" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                         <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button10" runat="server" Text="查看对应初始材料月计划" CssClass="Button02" Height="24px"
                                    OnClick="SearchMatMonthOriginal" Width="140px" />
                            </td>
                              <td colspan="2"  align="center">
                               <asp:Button ID="Button7" runat="server" Text="查看对应材料周计划" CssClass="Button02" Height="24px"
                                    OnClick="SearchMatWeekOriginal" Width="140px" />
                            </td>
                              <td colspan="2"  align="left">
                               <asp:Button ID="Button11" runat="server" Text="查看对应新增材料月计划" CssClass="Button02" Height="24px"
                                    OnClick="SearchMatMonthAddtion" Width="140px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_MatMonthOriginal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MatMonthOriginal" runat="server" Visible="false">
                <asp:Label ID="label24" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>  <asp:Label ID="label46" runat="server" Visible="true"></asp:Label>初始材料月计划</legend>
                    <asp:GridView ID="Gridview_MatMonthOriginal" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" BorderColor="#C0DE98"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="MMPD_ID,IMMBD_MaterialID,MMPD_Note,MMPD_Num" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_MatMonthOriginal_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MMPD_ID" HeaderText="售后类别ID" ReadOnly="True" SortExpression="MMPD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="false" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="false" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True" SortExpression="IMMBD_SpecificationModel"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MMPD_Num" HeaderText="数量" SortExpression="MMPD_Num"   >
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName"  >
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PMP_AddPlan" HeaderText="是否新增" SortExpression="PMP_AddPlan"  >
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="MMPD_Note" HeaderText="备注" SortExpression="MMPD_Note"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
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
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                      <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                           <%-- <td>
                            </td>--%>
                           <%-- <td>
                                <asp:CheckBox Visible="false" ID="Cbx2_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_NativeMonthPlan_SelectAll_CheckedChanged" />
                                &nbsp;
                                <asp:Button ID="ButtonPro" Height="24px" Width="70px" runat="server" Visible="false" CssClass="Button02" Text="提 交" OnClick="Plan_MatOriginal" />

                            </td>--%>
                            
                            <td align="center">
                            <asp:Button ID="Button26" runat="server" Width="70px" CssClass="Button02" Height="24px" Text="关闭" OnClick="Close_MatOriginal" />
                            </td>
                        </tr>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_AdditionPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AdditionPlan" runat="server" Visible="false">
                <asp:Label ID="label47" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>  <asp:Label ID="label48" runat="server" Visible="true"></asp:Label>新增材料月计划</legend>
                    <asp:GridView ID="Gridview_AdditionPlan" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" BorderColor="#C0DE98"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="MMPD_ID,IMMBD_MaterialID,MMPD_Note,MMPD_Num" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_AdditionPlan_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MMPD_ID" HeaderText="售后类别ID" ReadOnly="True" SortExpression="MMPD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="false" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="false" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True" SortExpression="IMMBD_SpecificationModel"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MMPD_Num" HeaderText="数量" SortExpression="MMPD_Num"   >
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName"  >
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="MMPD_Note" HeaderText="备注" SortExpression="MMPD_Note"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
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
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                      <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox1" Visible="false" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_ADDMonthPlan_SelectAll_CheckedChanged" />
                                &nbsp;
                                <asp:Button ID="Button8" Visible="false" runat="server" Height="24px" CssClass="Button02" Width="70px" Text="提 交" OnClick="OK_AdditionPlan" />

                            </td>

                            <td align="left">
                             <asp:Button ID="Button29" runat="server" Height="24px" CssClass="Button02" Width="70px" Text="关闭" OnClick="Close_AdditionPlan" />
                            </td>
                        </tr>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_Week" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          

            <asp:Panel ID="Panel_Week" runat="server" Visible="false">
    
                <fieldset>
                    <legend>  <asp:Label ID="label18" runat="server" Visible="true"></asp:Label>材料周计划</legend>
                <asp:Label ID="label14" runat="server" Visible="false"></asp:Label> <asp:Label ID="label34" runat="server" Visible="False"></asp:Label>
             
            
                  
                    <table style="width:100%">
                    
                   
                        <tr>
                             <td style="width: 10%" align="center">
                                <asp:Label ID="Label35" runat="server" Text="周次："></asp:Label>
                            </td>
                            <td style="width: 23%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label36" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 23%" align="left">
                                 <asp:TextBox ID="TextBox12" runat="server" ></asp:TextBox>
                            </td>
                                 <td style="width: 10%" align="center">
                                <asp:Label ID="Label37" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 23%" align="left">
                                <asp:TextBox ID="TextBox13" runat="server"  ></asp:TextBox>
                            </td>
                        </tr>
                       <tr>
                           <td>
                               &nbsp;
                           </td>
                       </tr>
                         <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="Button17" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchMatWeek" Width="140px" />
                            </td>
                           
                        </tr>
                     
                    
                    </table>
                
        
               
                    <asp:GridView ID="Gridview_Week" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" BorderColor="#C0DE98"
                        PageSize="10" AllowPaging="True" AllowSorting="True"  GridLines="None" DataKeyNames="ID"
                        Width="100%" OnPageIndexChanging="Gridview_Week_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:BoundField DataField="ID" HeaderText="物料ID" ReadOnly="false" SortExpression="ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PWP_SN" HeaderText="周次" ReadOnly="false" SortExpression="PWP_SN"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                        
                            <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="false" SortExpression="Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="Model" HeaderText="规格型号" ReadOnly="True" SortExpression="Model"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TNum" HeaderText="总计数量" SortExpression="TNum"  >
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="Unit" HeaderText="单位" SortExpression="Unit"  >
                                <ItemStyle />
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
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                      <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                          <%--  <td>
                            </td>--%>
                   <%--         <td>
                             <asp:CheckBox ID="CheckBox3" Visible="false" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_WeekPlan_SelectAll_CheckedChanged" />
                                &nbsp;
                                <asp:Button ID="Button17" Visible="false" runat="server" Height="24px" CssClass="Button02" Width="90px"  Text="生成采购订单" OnClick="WeekToOrder"  />

                            </td>--%>

                            <td align="center">
                             <asp:Button ID="Button18" runat="server" Height="24px" CssClass="Button02" Width="70px" Text="关闭" OnClick="Close_WeeKPlan" />
                            </td>
                        </tr>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

  
    <asp:UpdatePanel ID="UpdatePanel_PMPurchaseOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMPurchaseOrder" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label8" runat="server" Visible="true" Text="采购订单表"></asp:Label>
                    </legend>
                    <asp:GridView ID="Gridview3" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None" PageSize="2"
                        AllowPaging="True" AllowSorting="True" DataKeyNames="PMPO_PurchaseOrderID" OnPageIndexChanging="Gridview3_PageIndexChanging"
                        Width="100%" EnableModelValidation="True" 
                         onrowcommand="Gridview3_RowCommand" OnRowDataBound="Gridview3_RowDataBound1" 
                      >
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMPO_PurchaseOrderID" HeaderText="采购订单ID" 
                                SortExpression="PMPO_PurchaseOrderID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="供应商编号" 
                                SortExpression="PMSI_ID" Visible="False" />
                            <asp:BoundField DataField="PMPO_PurchaseOrderNum" HeaderText="采购订单号" 
                                SortExpression="PMPO_PurchaseOrderNum" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                                SortExpression="PMSI_SupplyName" />
                            <asp:BoundField DataField="PMPO_ArriverCondition" HeaderText="到货情况" 
                                SortExpression="PMPO_ArriverCondition" Visible="False" />
                            <asp:BoundField DataField="PMPO_MakeTime" HeaderText="制定时间" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="PMPO_MakeTime" />
                            <asp:BoundField DataField="PMPO_MakeMan" HeaderText="制定人" 
                                SortExpression="PMPO_MakeMan" Visible="False" />
                            <asp:BoundField DataField="PMPO_PlanArrTime" HeaderText="预计到货日期" SortExpression="PMPO_PlanArrTime"
                          DataFormatString="{0:yyyy-MM-dd}"    />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" 
                                SortExpression="PMPO_PayWay" />
                            <asp:BoundField DataField="PMPO_PaymentTime" HeaderText="账期" 
                                SortExpression="PMPO_PaymentTime" />
                            <asp:BoundField DataField="PMPO_BillNum" HeaderText="开票单号" 
                                SortExpression="PMPO_BillNum" Visible="False" />
                            <asp:BoundField DataField="PMPO_BillTime" HeaderText="开票日期" 
                                SortExpression="PMPO_BillTime" Visible="False" />
                            <asp:BoundField DataField="PMPO_TotalMoney" HeaderText="总额" 
                                SortExpression="PMPO_TotalMoney" />
                            <asp:BoundField DataField="PMPO_ResidueMoney" HeaderText="剩余付款" 
                                SortExpression="PMPO_ResidueMoney" Visible="False" />
                            <asp:BoundField DataField="PMPO_AlreadyPay" HeaderText="是否结款" 
                                SortExpression="PMPO_AlreadyPay" Visible="False" />
                            <asp:BoundField DataField="PMPO_CountInPayables" HeaderText="是否算入应付款" 
                                SortExpression="PMPO_CountInPayables" Visible="False" />
                            <asp:BoundField DataField="PMPO_State" HeaderText="状态" 
                                SortExpression="PMPO_State" />
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnLook1" runat="server" CommandName="Look1" CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>查看详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnMakey" runat="server" CommandName="Edit1" CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>编辑详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除吗?')"
                                        CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        
                        </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label9" runat="server" Text="新增采购订单"></asp:Label></legend>
                    <asp:Label ID="pdid" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
                      <asp:Label ID="Label_Way" runat="server" Visible="false"></asp:Label>
                  
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label10" runat="server" Text="供应商名称："></asp:Label>
                            </td>
                            <td style="width: 12%; height: 20px;" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Enabled="false" > </asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:Button ID="Button14" runat="server" Text="选择..." CssClass="Button02" Height="24px"
                                    OnClick="Button_Select3" Width="50px" />
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label11" runat="server" Text="付款方式："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList6" runat="server" Width="130px">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>现货现款</asp:ListItem>
                                    <asp:ListItem>先货后款</asp:ListItem>
                                    <asp:ListItem>预付款</asp:ListItem>
                                </asp:DropDownList>
                                
                            </td>
                             <td style="width: 12%" align="right">
                                <asp:Label ID="Label12" runat="server" Text="账期："></asp:Label>
                            </td>
                            <td style="height: 20px;" align="left">
                                <asp:TextBox ID="TextBox4" runat="server" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr>

                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label13" runat="server" Text="预到货期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                     ></asp:TextBox>
                            </td>
                            <td></td>
                             <td style="width: 15%" align="right">
                                <asp:Label ID="Label3" runat="server" Text="付款提醒日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                     ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%" align="left">
                                &nbsp;
                            </td>
                             <td style="width: 15%" align="left">
                                &nbsp;
                            </td>
                            <td  colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button15" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_Create" Width="70px" />
                            </td>
                            <td style="width: 15%" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button16" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="Button_Reset4" Visible="true" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel_PMPurchaseOrderDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMPurchaseOrderDetail" runat="server" Visible="false">
                <fieldset>
                    <asp:Label ID="label_MaterialID" runat="server"  Visible="false"></asp:Label>
                    <legend>采购订单详细表</legend>
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="2" AllowPaging="True" AllowSorting="True" DataKeyNames="PMPOD_PurchaseDetailID,IMMBD_MaterialID,PMPOD_ProductRequest,PMPOD_Remark,PMPOD_Price,PMPOD_Num"
                        GridLines="None" Width="100%" OnPageIndexChanging="Gridview1_PageIndexChanging"
                     
                        OnRowCommand="Gridview1_RowCommand" ondatabound="Gridview1_DataBound" OnRowDataBound="Gridview1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="PMPOD_PurchaseDetailID" HeaderText="采购订单详细表ID" ReadOnly="True" SortExpression="PMPOD_PurchaseDetailID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPOD_Price" HeaderText="单价"  SortExpression="PMPOD_Price">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPOD_Num" HeaderText="数量" ReadOnly="True"
                                SortExpression="PMPOD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPOD_TotalMoney" HeaderText="总额" SortExpression="PMPOD_TotalMoney" ReadOnly="True">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName" ReadOnly="True">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPOD_ProductRequest" HeaderText="产品要求"  SortExpression="PMPOD_ProductRequest"
                             >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPOD_Remark" HeaderText="备注"  SortExpression="PMPOD_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                           
                             <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="ButtonDelete1" runat="server" CommandName="Edit1" CommandArgument='<%#Eval("PMPOD_PurchaseDetailID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete1" CommandArgument='<%#Eval("PMPOD_PurchaseDetailID")%>'>删除</asp:LinkButton>
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
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                     <table width="100%">
                        <tr>
                        <td align="right" style="width: 34%">
                                <asp:Button ID="Button22" runat="server" CssClass="Button02" Height="24px" OnClick="ButtonMark"
                                    Text="提交" Width="70px" />
                                </td>
                            <td align="center" style="width: 20%">
                                
                                &nbsp;
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Button ID="Button24" runat="server" CssClass="Button02" Height="24px" OnClick="ButtonCancel"
                                    Text="关闭" Width="70px" />
                                &nbsp;
                            </td>
                        </tr>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                <asp:Label ID="Label7" runat="server"  Visible="false"></asp:Label>
                    <legend>   <asp:Label ID="Label16" runat="server"  Visible="true"></asp:Label>采购详细订单编辑</legend>
                    <table style="width: 100%;">
                        <tr>
                         
                            <td style="width: 15%" align="right">
                                单价:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox8" runat="server" Width="100%"    onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">
                                数量：
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox9" runat="server" Width="98%"
                                    onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                          
                            <td align="right">
                                产品要求:<br />（200字内）
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox10" runat="server" Height="80px" MaxLength="200" onkeyup="this.value = this.value.slice(0, 200)"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                          
                            <td align="right">
                                备注:<br />（200字内）
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox11" runat="server" Height="80px" MaxLength="200" onkeyup="this.value = this.value.slice(0, 200)"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Edit_OrderDetail" Height="24px"
                                    Text="提交" Width="70px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                               
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button25" runat="server" CssClass="Button02" OnClick="Clsoe_OrderDetail" Height="24px"
                                    Text="关闭" Width="70px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>供应商查询</legend>
                    <table style="width:100%">
                     <tr>
            
                             <td align="right" style="width: 30%">
                                <asp:Label ID="Label15" runat="server" Text="供应商名称："></asp:Label>
                            </td>
                            <td align="left" style="width: 20%">
                                <asp:TextBox ID="PurchaseOrderID" runat="server" > </asp:TextBox>
                            </td>
                            <td align="left">
                            <asp:Button ID="Button4" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="Search_Supply" Width="70px" /></td>
           
            </tr>
                    </table>
                    <asp:Label ID="LabelSupplyID" runat="server" Visible="false"></asp:Label>
                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None" PageSize="20"
                        AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="PMSI_SupplyName,PMSI_ID" OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging"
                        Width="100%" EnableModelValidation="True" 
                       
                        onrowcommand="Gridview2_RowCommand1">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle />
                        <Columns>
                            
                            <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" SortExpression="PMSI_ID" Visible="False">
                                <ItemStyle   />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编码" SortExpression="PMSI_SupplyNum" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" SortExpression="PMSI_SupplyName" />
                       <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Choose3" CommandArgument='<%#Eval("PMSI_ID")%>'>选择</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle  />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                   
                </fieldset>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    </asp:Content>