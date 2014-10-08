<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="PBProTypeInfo.aspx.cs" Inherits="REPORT_cc_PBProTypeInfo" %>

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
                    <legend>产品查询</legend>
                       <table style="width:100%;">
                        <tr style="height: 16px;">
                            <td style="width:5%">
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtProSeries" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtProType" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label23" runat="server" CssClass="STYLE2" Text="产品编码：" ></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtProCode" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width:5%">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;" align="center">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="BtnSearchProType" runat="server" CssClass="Button02" Height="24px"
                                     Text="检索" Width="70px" onclick="BtnSearchProType_Click"  />
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="BtnPrintReport" runat="server" CssClass="Button02" Height="24px"
                                     Text="打印报表" Width="70px" onclick="BtnPrintReport_Click"  />
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="BtnResetProType" runat="server" CssClass="Button02" Height="24px"
                                     Text="重置" Width="70px" onclick="BtnResetProType_Click"  />
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_ProType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ProType" runat="server">
                <fieldset>
                    <legend>型号说明表</legend>
                    <asp:GridView ID="Grid_ProType" runat="server" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        Visible="true" GridLines="None" AllowPaging="True" PageSize="10" 
                        UseAccessibleHeader="False" 
                        onpageindexchanging="Grid_ProType_PageIndexChanging" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PS_ID" HeaderText="产品系列ID" SortExpression="PS_ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="系列"></asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="ChipSize" SortExpression="ChipSize" HeaderText="芯片大小"></asp:BoundField>
                            <asp:BoundField DataField="ElectricCondition" SortExpression="ElectricCondition" HeaderText="电性情况"></asp:BoundField>
                            <asp:BoundField DataField="HuanYangCondition" SortExpression="HuanYangCondition" HeaderText="环氧物料情况"></asp:BoundField>
                            <asp:BoundField DataField="QiaoKeConditon" SortExpression="QiaoKeConditon" HeaderText="桥壳物料情况"></asp:BoundField>
                            <asp:BoundField DataField="FootMethod" SortExpression="FootMethod" HeaderText="引脚方式"></asp:BoundField>
                            <asp:BoundField DataField="WarpMethod" SortExpression="WarpMethod" HeaderText="包装方式"></asp:BoundField>
                            <asp:BoundField DataField="PT_Note" SortExpression="PT_Note" HeaderText="备注"></asp:BoundField>
                            <asp:BoundField DataField="PT_Code" SortExpression="PT_Code" HeaderText="产品编码"></asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
   </asp:Content>

