<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMOrderDeliverPlan.aspx.cs" Inherits="REPORT_cc_SMOrderDeliverPlan" 
MasterPageFile="~/Other/MasterPage.master" Title="发货计划汇总"%>
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
                                发货计划日期从：
                            </td>
                            <td align="left" style="width:20%">
                                 <asp:TextBox runat="server" ID="TextBox9" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="120px"  ></asp:TextBox>
                            </td>
                       
                             <td align="left" style="width: 20%">
                                     <asp:Label ID="Label1" runat="server"  Visible="true" Text="到"></asp:Label>
                                 <asp:TextBox runat="server" ID="TextBox15" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="120px"  ></asp:TextBox>
                            </td>
                               <td  align="left">
                                   <asp:CheckBox ID="CheckBox1" runat="server" Text="打印是否显示单价"/>
                            </td>
                            <td  align="left">
                                <asp:Button ID="Button2" runat="server" Text="检索" CssClass="Button02" 
                                    OnClick="SearchDeliverPlan" Width="70px" />
                            </td>
                           
                          <td  align="left">
                                <asp:Button ID="Button4" runat="server" Text="打印报表" CssClass="Button02" 
                                    OnClick="PrintDeliverPlan" Width="70px" />
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
                    <asp:GridView ID="GridView_OrderDeliverPlan" runat="server" AllowPaging="True" PageSize="40"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMDP_ID"
                        AllowSorting="True" 
                        Width="100%" OnPageIndexChanging="GridView_OrderDeliverPlan_PageIndexChanging" 
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
   
   </asp:Content>