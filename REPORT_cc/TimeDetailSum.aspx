<%@ Page Title="年度计时工资信息统计表" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="TimeDetailSum.aspx.cs" Inherits="REPORT_cc_TimeDetailSum" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                <legend>年度计时工资信息统计检索</legend>
                        <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 20%">
                        </td>
                        <td style="width: 7%" align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="统计年份："></asp:Label>
                        </td>
                        <td style="width: 15%">
                            <asp:TextBox ID="TxtYear" runat="server" Width="155px" 
                                onfocus="new WdatePicker(this,'%Y',false)"></asp:TextBox>
                        </td>
                        <td style="width: 20%">
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;" align="center">
                    <tr>
                        <td style="width: 20%">
                        </td>
                        <td align="center" style="width: 20%">
                            <asp:Button ID="BtnSearchMaterial" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchMaterial_Click" />
                        </td>
                        <td align="center" style="width: 20%">
                            <asp:Button ID="BtnToExcel" runat="server" CssClass="Button02" Height="24px"
                                    Text="导出Excel" Width="70px" OnClick="BtnToExcel_Click"/>
                        </td>
                        <td align="center" style="width: 20%">
                            <asp:Button ID="BtnResetMaterial" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" OnClick="BtnResetMaterial_Click" />
                        </td>
                        <td style="width: 20%">
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
    </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="BtnToExcel" />
    </Triggers>
</asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server">
            <fieldset>
                <legend>年度计时工资信息统计表</legend>
                <asp:GridView ID="Grid1" runat="server" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                    Visible="true" GridLines="None" AllowPaging="True" PageSize="15" UseAccessibleHeader="False" OnRowCreated="Grid1_RowCreated" OnPageIndexChanging="Grid1_PageIndexChanging"  >
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHead" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <Columns>
                        <asp:BoundField DataField="工序" SortExpression="工序" HeaderText="工序">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时项目" SortExpression="计时项目" HeaderText="计时项目">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang1" SortExpression="chanliang1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang1" SortExpression="shichang1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia1" SortExpression="danjia1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine1" SortExpression="jine1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang2" SortExpression="chanliang2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang2" SortExpression="shichang2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia2" SortExpression="danjia2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine2" SortExpression="jine2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang3" SortExpression="chanliang3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang3" SortExpression="shichang3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia3" SortExpression="danjia3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine3" SortExpression="jine3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang4" SortExpression="chanliang4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang4" SortExpression="shichang4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia4" SortExpression="danjia4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine4" SortExpression="jine4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang5" SortExpression="chanliang5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang5" SortExpression="shichang5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia5" SortExpression="danjia5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine5" SortExpression="jine5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang6" SortExpression="chanliang6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang6" SortExpression="shichang6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia6" SortExpression="danjia6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine6" SortExpression="jine6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang7" SortExpression="chanliang7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang7" SortExpression="shichang7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia7" SortExpression="danjia7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine7" SortExpression="jine7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang8" SortExpression="chanliang8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang8" SortExpression="shichang8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia8" SortExpression="danjia8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine8" SortExpression="jine8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang9" SortExpression="chanliang9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang9" SortExpression="shichang9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia9" SortExpression="danjia9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine9" SortExpression="jine9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang10" SortExpression="chanliang10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang10" SortExpression="shichang10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia10" SortExpression="danjia10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine10" SortExpression="jine10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang11" SortExpression="chanliang11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang11" SortExpression="shichang11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia11" SortExpression="danjia11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine11" SortExpression="jine11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chanliang12" SortExpression="chanliang12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="shichang12" SortExpression="shichang12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="danjia12" SortExpression="danjia12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="jine12" SortExpression="jine12">
                            <ItemStyle />
                        </asp:BoundField>
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

