<%@ Page Title="入库发货统计表" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="InOutStoreSum.aspx.cs" Inherits="REPORT_cc_InOutStoreSum" EnableEventValidation="false" %>

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
                <legend>入库发货检索</legend>
                        <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 20%">
                        </td>
                        <td style="width: 9%" align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="统计年份："></asp:Label>
                        </td>
                        <td style="width: 15%">
                            <asp:TextBox ID="TxtYear" runat="server" Width="155px" 
                                onfocus="new WdatePicker(this,'%Y',false)"></asp:TextBox>
                        </td>
                        <td align="center" style="width: 20%">
                            <asp:Button ID="BtnExcel" runat="server" CssClass="Button02" Height="24px"
                                    Text="导出Excel" Width="70px" OnClick="BtnExcel_Click"/>
                        </td>
                        <td align="center" style="width: 20%">
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" OnClick="BtnReset_Click"/>
                        </td>
                        <td style="width: 20%">
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="BtnExcel" />
    </Triggers>
</asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server">
            <fieldset>
                <legend>入库发货统计表</legend>
                <asp:GridView ID="Grid1" runat="server" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                    Visible="true" GridLines="None" AllowPaging="True" PageSize="10" UseAccessibleHeader="False" OnRowCreated="GridInOutStoreSum_RowCreated"  >
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHead" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <Columns>
                        <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="系列名称"></asp:BoundField>
                        <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                        
                        <asp:BoundField DataField="Sales_Plan1" SortExpression="Sales_Plan1" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan1" SortExpression="Production_Plan1" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality1" SortExpression="Production_Reality1" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore1" SortExpression="Production_Instore1" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore1" SortExpression="Production_Outstore1" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline1" SortExpression="Production_InStoreDeadline1" HeaderText="1月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish1" SortExpression="Production_Finish1" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion1" SortExpression="Production_Proportion1" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan2" SortExpression="Sales_Plan2" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan2" SortExpression="Production_Plan2" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality2" SortExpression="Production_Reality2" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore2" SortExpression="Production_Instore2" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore2" SortExpression="Production_Outstore2" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline2" SortExpression="Production_InStoreDeadline2" HeaderText="2月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish2" SortExpression="Production_Finish2" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion2" SortExpression="Production_Proportion2" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan3" SortExpression="Sales_Plan3" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan3" SortExpression="Production_Plan3" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality3" SortExpression="Production_Reality3" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore3" SortExpression="Production_Instore3" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore3" SortExpression="Production_Outstore3" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline3" SortExpression="Production_InStoreDeadline3" HeaderText="3月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish3" SortExpression="Production_Finish3" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion3" SortExpression="Production_Proportion3" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan4" SortExpression="Sales_Plan4" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan4" SortExpression="Production_Plan4" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality4" SortExpression="Production_Reality4" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore4" SortExpression="Production_Instore4" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore4" SortExpression="Production_Outstore4" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline4" SortExpression="Production_InStoreDeadline4" HeaderText="4月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish4" SortExpression="Production_Finish4" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion4" SortExpression="Production_Proportion4" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan5" SortExpression="Sales_Plan5" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan5" SortExpression="Production_Plan5" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality5" SortExpression="Production_Reality5" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore5" SortExpression="Production_Instore5" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore5" SortExpression="Production_Outstore5" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline5" SortExpression="Production_InStoreDeadline5" HeaderText="5月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish5" SortExpression="Production_Finish5" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion5" SortExpression="Production_Proportion5" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan6" SortExpression="Sales_Plan6" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan6" SortExpression="Production_Plan6" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality6" SortExpression="Production_Reality6" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore6" SortExpression="Production_Instore6" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore6" SortExpression="Production_Outstore6" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline6" SortExpression="Production_InStoreDeadline6" HeaderText="6月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish6" SortExpression="Production_Finish6" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion6" SortExpression="Production_Proportion6" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan7" SortExpression="Sales_Plan7" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan7" SortExpression="Production_Plan7" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality7" SortExpression="Production_Reality7" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore7" SortExpression="Production_Instore7" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore7" SortExpression="Production_Outstore7" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline7" SortExpression="Production_InStoreDeadline7" HeaderText="7月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish7" SortExpression="Production_Finish7" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion7" SortExpression="Production_Proportion7" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan8" SortExpression="Sales_Plan8" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan8" SortExpression="Production_Plan8" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality8" SortExpression="Production_Reality8" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore8" SortExpression="Production_Instore8" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore8" SortExpression="Production_Outstore8" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline8" SortExpression="Production_InStoreDeadline8" HeaderText="8月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish8" SortExpression="Production_Finish8" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion8" SortExpression="Production_Proportion8" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan9" SortExpression="Sales_Plan9" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan9" SortExpression="Production_Plan9" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality9" SortExpression="Production_Reality9" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore9" SortExpression="Production_Instore9" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore9" SortExpression="Production_Outstore9" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline9" SortExpression="Production_InStoreDeadline9" HeaderText="9月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish9" SortExpression="Production_Finish9" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion9" SortExpression="Production_Proportion9" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan10" SortExpression="Sales_Plan10" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan10" SortExpression="Production_Plan10" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality10" SortExpression="Production_Reality10" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore10" SortExpression="Production_Instore10" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore10" SortExpression="Production_Outstore10" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline10" SortExpression="Production_InStoreDeadline10" HeaderText="10月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish10" SortExpression="Production_Finish10" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion10" SortExpression="Production_Proportion10" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan11" SortExpression="Sales_Plan11" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan11" SortExpression="Production_Plan11" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality11" SortExpression="Production_Reality11" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore11" SortExpression="Production_Instore11" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore11" SortExpression="Production_Outstore11" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline11" SortExpression="Production_InStoreDeadline11" HeaderText="11月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish11" SortExpression="Production_Finish11" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion11" SortExpression="Production_Proportion11" HeaderText="投入产出比"></asp:BoundField>

                        <asp:BoundField DataField="Sales_Plan12" SortExpression="Sales_Plan12" HeaderText="本月销售计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Plan12" SortExpression="Production_Plan12" HeaderText="本月投产计划"></asp:BoundField>
                        <asp:BoundField DataField="Production_Reality12" SortExpression="Production_Reality12" HeaderText="本月实际投产"></asp:BoundField>
                        <asp:BoundField DataField="Production_Instore12" SortExpression="Production_Instore12" HeaderText="本月入库"></asp:BoundField>
                        <asp:BoundField DataField="Production_Outstore12" SortExpression="Production_Outstore12" HeaderText="本月发货"></asp:BoundField>
                        <asp:BoundField DataField="Production_InStoreDeadline12" SortExpression="Production_InStoreDeadline12" HeaderText="12月25日库存"></asp:BoundField>
                        <asp:BoundField DataField="Production_Finish12" SortExpression="Production_Finish12" HeaderText="完成率"></asp:BoundField>
                        <asp:BoundField DataField="Production_Proportion12" SortExpression="Production_Proportion12" HeaderText="投入产出比"></asp:BoundField>

                    </Columns>
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

