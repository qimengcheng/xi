<%@ Page Title="IQC检验汇总" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="IQCSum.aspx.cs" Inherits="REPORT_cc_IQCSum" %>


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
                    <legend>物料检索栏</legend>
                            <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 7%" align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtMaterialName" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtSpecificationModel" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="供货单位："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtSupplyName" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 7px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="LblPost" runat="server" CssClass="STYLE2" Text="来料日期：" ></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:TextBox ID="TxtInStoreTime" runat="server" Width="155px" 
                                    onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="检验结果："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtIQCResult" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                             <td style="width: 7%" align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="STYLE2" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtBatchNumber" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;" align="center">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="BtnSearchMaterial" runat="server" CssClass="Button02" Height="24px"
                                     Text="检索" Width="70px" OnClick="BtnSearchMaterial_Click"  />
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="BtnPrintReport" runat="server" CssClass="Button02" Height="24px"
                                     Text="打印报表" Width="70px" OnClick="BtnPrintReport_Click" />
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
    </asp:UpdatePanel>
   <%-- 待检物料信息表--%>
    <asp:UpdatePanel ID="UpdatePanel_IQCSum" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_IQCSum" runat="server">
                <fieldset>
                    <legend>IQC检验汇总表</legend>
                    <asp:GridView ID="Grid_IQCSum" runat="server" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        Visible="true" GridLines="None" AllowPaging="True" PageSize="10" UseAccessibleHeader="False" OnPageIndexChanging="Grid_IQCSum_PageIndexChanging" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMISM_InStoreTime" SortExpression="IMISM_InStoreTime" HeaderText="来料日期"></asp:BoundField>
                            <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="物料名称"></asp:BoundField>
                            <asp:BoundField DataField="Model" SortExpression="Model" HeaderText="规格型号"></asp:BoundField>
                            <asp:BoundField DataField="IMISD_BatchNum" SortExpression="IMISD_BatchNum" HeaderText="批号"></asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" SortExpression="PMSI_SupplyName" HeaderText="供货单位"></asp:BoundField>
                            <asp:BoundField DataField="IMIDS_ActualArrNum" SortExpression="IMIDS_ActualArrNum" HeaderText="到货数量"></asp:BoundField>
                            <asp:BoundField DataField="IQCDT_Result" SortExpression="IQCDT_Result" HeaderText="检验结果"></asp:BoundField>
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
            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>
   
   </asp:Content>
