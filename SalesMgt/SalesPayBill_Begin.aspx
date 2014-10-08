<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesPayBill_Begin.aspx.cs" Inherits="SalesMgt_SalesPayBillBegin"  MasterPageFile="~/Other/MasterPage.master" Title="客户初始金额" %>

<script runat="server">
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    <asp:UpdatePanel ID="UpdatePanel_SearchMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchMain" runat="server" Visible="true">
                <asp:Label ID="label21" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 12%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox13"></asp:TextBox>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                           <td>    <asp:Button ID="Button7" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchMain" Width="70px" />&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="新增" CssClass="Button02" Height="24px"
                                    OnClick="NewMainOpen" Width="70px" />
                            </td>
                           
                            </tr>
                     
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_Main" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel__Main" runat="server" Visible="True">
                <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>客户金额表</legend>
                    <asp:GridView ID="Gridview_Main" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="SMCBPM_ID,CRMCIF_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Main_PageIndexChanging" 
                        OnRowCommand="Gridview_Main_RowCommand" 
                       >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMCBPM_ID" HeaderText="价格账期ID" ReadOnly="True" SortExpression="SMCBPM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCIF_ID" HeaderText="kehuID" ReadOnly="True" SortExpression="CRMCIF_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="false" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPM_TotalLoan" HeaderText="贷款总额" ReadOnly="false" SortExpression="SMCBPM_TotalLoan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPM_MaturityLoan" HeaderText="到期贷款" ReadOnly="True" SortExpression="SMCBPM_MaturityLoan"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPM_NoBillTotal" HeaderText="未开票贷款总额" ReadOnly="True" SortExpression="SMCBPM_NoBillTotal"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPM_Man" HeaderText="制定人" ReadOnly="True" SortExpression="SMCBPM_Man"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPM_Time" HeaderText="最后修改时间" ReadOnly="True" SortExpression="SMCBPM_Time"
                                Visible="true "  DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                         
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMCBPM_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除吗?')"
                                        CommandArgument='<%#Eval("SMCBPM_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>  
                             
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="AllSee" runat="server" CommandName="AllSee" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMCBPM_ID")%>'>总表修改历史查看</asp:LinkButton>
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
      <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <asp:Label ID="label34" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>客户金额总表修改记录</legend>
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="SMCBPMCH_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview1_PageIndexChanging" 
                      
                       >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMCBPMCH_ID" HeaderText="价格账期ID" ReadOnly="True" SortExpression="SMCBPMCH_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                          
                            <asp:BoundField DataField="SMCBPMCH_TPre" HeaderText="改前贷款总额" ReadOnly="false" SortExpression="SMCBPMCH_TPre"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPMCH_TAfter" HeaderText="改后贷款总额" ReadOnly="false" SortExpression="SMCBPMCH_TAfter">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPMCH_BPre" HeaderText="改前到期贷款" ReadOnly="True" SortExpression="SMCBPMCH_BPre"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPMCH_BAfter" HeaderText="改后到期贷款" ReadOnly="True" SortExpression="SMCBPMCH_BAfter"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPMCH_NPre" HeaderText="改前未开票总额" ReadOnly="True" SortExpression="SMCBPMCH_NPre"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPMCH_NAfter" HeaderText="改后未开票总额" ReadOnly="True" SortExpression="SMCBPMCH_NAfter"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>

                            <asp:BoundField DataField="SMCBPMCH_Man" HeaderText="修改人" ReadOnly="True" SortExpression="SMCBPMCH_Man"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCBPMCH_Day" HeaderText="修改时间" ReadOnly="True" SortExpression="SMCBPMCH_Day"
                                Visible="true "  DataFormatString="{0:yyyy-MM-dd}">
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
                      <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: center">
                                <asp:Button ID="Button12" runat="server" CssClass="Button02" OnClick="CloseHistory" Height="24px"
                                    Text="关闭" Width="70px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            </tr>
                          </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <%-- 审核--%>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                <asp:Label ID="Label3" runat="server"  Visible="false"></asp:Label><asp:Label ID="Label29" runat="server"  Visible="false"></asp:Label>
                    <legend><asp:Label ID="Label7" runat="server"  Visible="true"></asp:Label><asp:Label ID="Label26" runat="server"  Visible="true"></asp:Label>
                        客户金额表</legend>
                    <table style="width: 100%;">
                         <tr>
                      
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label27" runat="server" Text="客户名称："></asp:Label>
                            </td>
                              <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox15" Enabled="false"></asp:TextBox>                                <asp:Button ID="Button11" runat="server" 
    Text="选择…" CssClass="Button02" Height="20px"
                                    OnClick="SearchCustom_Main" Width="50px" />
                            
                                  <asp:Label ID="Label59" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            
                            </td>
                              <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="贷款总额："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                                <asp:Label ID="Label57" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                              </tr>
                        <tr>
                              <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="到期贷款："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox4" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                                <asp:Label ID="Label56" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                               <td style="width: 10%" align="center">
                                <asp:Label ID="Label28" runat="server" Text="未开票总额："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox18" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                                <asp:Label ID="Label58" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="NewMain" Height="24px"
                                    Text="提交" Width="70px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                               
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="NewMainClose" Height="24px"
                                    Text="关闭" Width="70px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_SearchCus" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_SearchCus" runat="server" Visible="false">
                <asp:Label ID="label6" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>客户检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label12" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox6"></asp:TextBox>
                            </td>
                            <td style="width:30%"  align="right">
                                <asp:Button ID="Button22" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchCustomer" Width="70px" />
                            </td>
                              <td style="width:25%"  align="center">
                               <asp:Button ID="Button23" runat="server" Text="取消" CssClass="Button02" Height="24px"
                                    OnClick="CloseSearchCustomer" Width="70px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel_Custom" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_Custom" runat="server" Visible="false">
                <asp:Label ID="label41" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>客户表</legend>
                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="CRMCIF_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview2_PageIndexChanging" onrowcommand="Gridview2_RowCommand" 
                         >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCIF_ID" HeaderText="客户ID" ReadOnly="True" SortExpression="CRMCIF_ID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                             
                             <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle Width="45%"/>
                            </asp:BoundField>
                     <asp:BoundField DataField="CRMCIF_Address" HeaderText="地址" ReadOnly="True" SortExpression="CRMCIF_Address"
                                Visible="true">
                                <ItemStyle Width="45%"/>
                            </asp:BoundField>
                       
                         <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check2" runat="server" CommandName="Check2" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCIF_ID")%>'>选择</asp:LinkButton>
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
               
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    </asp:Content>