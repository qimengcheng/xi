<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMDiaobo.aspx.cs" Inherits="InventoryMgt_IMDiaobo"
    MasterPageFile="~/Other/MasterPage.master" Title="调拨管理" %>
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
    <asp:UpdatePanel ID="UpdatePanel_KucunSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_KucunSearch" runat="server" Visible="false">
                <asp:Label ID="label_Kucunsearch" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>调拨单检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label" runat="server" Text="调拨单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="调出仓库："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="调入仓库："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>选择时间 </asp:ListItem>
                                    <asp:ListItem>调出时间</asp:ListItem>
                                    <asp:ListItem>调入时间</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" colspan="3">
                                从
                                <asp:TextBox runat="server" ID="TextBox5" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  Width="43%"></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox6" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  Width="43%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchDiaoboMain" Width="80px" />
                            </td>
                            <td colspan="2" align="left">
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="Button3" runat="server" Text="新建调拨单" CssClass="Button02" Height="24px"
                                    OnClick="NewDiaoboMain" Width="90px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--调拨主表--%>
    <asp:UpdatePanel ID="UpdatePanel_DiaoboMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_DiaoboMain" runat="server" Visible="false">
                <asp:Label ID="label11" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>调拨表</legend>
                    <asp:GridView ID="Gridview_DiaoboMain" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="IMA_AllotID,IMA_InHouse,IMA_OutHouse" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Kucun_PageIndexChanging" 
                        OnRowCommand="Gridview_Kucun_RowCommand" 
                        onrowdatabound="Gridview_DiaoboMain_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <%--<FooterStyle CssClass="GridViewFooterStyle" />--%>
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="IMA_AllotID" HeaderText="调拨单ID" ReadOnly="True" SortExpression="IMA_AllotID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMA_AllotNum" HeaderText="调拨单号" ReadOnly="True" SortExpression="IMA_AllotNum"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMA_AllotState" HeaderText="状态" ReadOnly="True" SortExpression="IMA_AllotState">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="OutName" HeaderText="调出仓库" ReadOnly="True" SortExpression="OutName"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMA_OutHouseMang" HeaderText="调出管理员" SortExpression="IMA_OutHouseMang">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMA_OutHouseTime" HeaderText="调出日期" ReadOnly="True" SortExpression="IMA_OutHouseTime"
                                DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="InName" HeaderText="调入仓库" ReadOnly="True" SortExpression="InName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMA_InHouseMang" HeaderText="调入管理员" SortExpression="IMA_InHouseMang">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMA_InHouseTime" HeaderText="调入时间" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="IMA_InHouseTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandName="Look1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMA_AllotID")%>'>查看详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMA_AllotID")%>'>调出编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMA_AllotID")%>'>调入编辑</asp:LinkButton>
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
    <%-- 检索--%>
    <asp:UpdatePanel ID="UpdatePanel_NewDiaoboMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewDiaoboMain" runat="server" Visible="false">
                <asp:Label ID="label1" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>新建调拨单</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="调出仓库："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="调入仓库："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewDiaoboMain" Width="80px" />
                            </td>
                            <td colspan="2" align="center">
                            <asp:Button ID="Button4" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseNewDiaoboMain" Width="80px" /></td>
                            
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <%--调拨主表--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Label ID="label6" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="label7" runat="server" Visible="false"></asp:Label>
                    
                <fieldset>
                    <legend><asp:Label ID="label14" runat="server" Visible="true"></asp:Label>调拨详细表</legend>
                    <asp:Button ID="Button11" runat="server" Text="新增物料" CssClass="Button02" Height="24px"
                                    OnClick="NewWuliao" Width="90px" />
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="IMAD_AllotID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview1_PageIndexChanging" 
                        onrowcommand="Gridview1_RowCommand" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <%--<FooterStyle CssClass="GridViewFooterStyle" />--%>
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="IMAD_AllotID" HeaderText="调拨单详细ID" ReadOnly="True" SortExpression="IMAD_AllotID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True" SortExpression="IMMBD_MaterialName"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品名称" ReadOnly="True" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True" SortExpression="IMMBD_SpecificationModel"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMAD_AllotNum" HeaderText="调拨数量" SortExpression="IMAD_AllotNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMAD_Anomaly" HeaderText="是否异常" ReadOnly="True" SortExpression="IMAD_Anomaly"
                              >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMAD_ActualCountNum" HeaderText="清点数目" ReadOnly="True" SortExpression="IMAD_ActualCountNum">
                                <ItemStyle />
                            </asp:BoundField>
                           <asp:BoundField DataField="IMSA_AreaName" HeaderText="入库区域" ReadOnly="True" SortExpression="IMSA_AreaName">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:TemplateField Visible="true" HeaderText="" >
                                <ItemTemplate>
                                   <asp:LinkButton ID="Dian" runat="server" CommandName="Dian" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMAD_AllotID")%>'>清点与入库区域安排</asp:LinkButton>
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
                    <table style="width:100%">
                    <tr>
                      <td style="width:25%" align="center">  <asp:Button ID="Button8" runat="server" Text="提交调拨单" CssClass="Button02" Height="24px"
                                    OnClick="BaocunDiaoboMain" Width="90px" /></td>
                        <td style="width:25%" align="center">  <asp:Button ID="Button5" runat="server" Text="正常接受" CssClass="Button02" Height="24px"
                                    OnClick="DiaoboMainOK" Width="90px" /></td>
                        <td style="width:25%" align="center">  <asp:Button ID="Button6" runat="server" Text="异常拒收" CssClass="Button02" Height="24px"
                                    OnClick="DiaoboMainNotOK" Width="90px" /></td>
                        <td style="width:25%" align="center">  <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseDiaoboMain" Width="90px" /></td>
                    </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%-- 清点和预安排--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
              <asp:Label ID="label15" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>  <asp:Label ID="label12" runat="server" Visible="true"></asp:Label>清点和库存安排</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label9" runat="server" Text="清点数量："></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                              
                                <asp:TextBox ID="TextBox2" runat="server" Height="16px" 
                                    ></asp:TextBox>
                              
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="调入区域："></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                                <asp:DropDownList ID="DropDownList8" runat="server">
                                </asp:DropDownList>
                            </td>
                         
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button9" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmQingdian" Width="80px" />
                            </td>
                            
                            <td colspan="2" align="center">
                                <asp:Button ID="Button10" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseQingdian" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--库存检索开始--%>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_kucun" runat="server" Visible="false">
              <asp:Label ID="label8" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>库存物料检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label38" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="label_OutHouseMID" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="label13" runat="server" Visible="False"></asp:Label>
                        <tr>
                         
                           
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label41" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label42" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox4"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button22" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectMat" Width="80px" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button23" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColseMat" Width="80px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
           <%-- </asp:Panel>
            <asp:Panel ID="Panel_kucun1" runat="server" Visible="true">--%>
                <fieldset>
                 <asp:Label ID="label_SourceSort" runat="server" Visible="False"></asp:Label>
                    <legend>库存列表</legend>
                    <asp:GridView ID="Gridview_Pur" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" GridLines="None"
                        DataKeyNames="IMIM_ID,IMMBD_MaterialID,PT_ID" OnPageIndexChanging="Gridview_Pur_PageIndexChanging"
                        Width="100%" onrowcommand="Gridview_Pur_RowCommand" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <%--<FooterStyle CssClass="GridViewFooterStyle" />--%>
                        <Columns>
                           
                            <asp:BoundField DataField="IMIM_ID" HeaderText="库存主表ID" ReadOnly="True" SortExpression="IMIM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True"
                                SortExpression="IMMBD_MaterialID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="PT_ID" HeaderText="产品ID" ReadOnly="True"
                                SortExpression="PT_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="True"
                                SortExpression="Name" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Model" HeaderText="规格型号" ReadOnly="True"
                                SortExpression="Model" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMIM_Level" HeaderText="档次" SortExpression="IMIM_Level">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Unit" HeaderText="单位" ReadOnly="True"
                                SortExpression="Unit" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIM_TotalNum" HeaderText="总数量" SortExpression="IMIM_TotalNum">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMIM_ActualArrangeNum" HeaderText="已分配数量" SortExpression="IMIM_ActualArrangeNum">
                                <ItemStyle />
                            </asp:BoundField>  
                                            
                                      <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Choose5" runat="server" CommandName="Choose5" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMIM_ID")%>'>选择明细</asp:LinkButton>
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
                    </asp:GridView>
                 
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_KucunD" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_KucunD" runat="server" Visible="false">
           <asp:Label ID="label27" runat="server" Visible="False"></asp:Label>
           <asp:Label ID="label54" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label28" runat="server" Visible="true"></asp:Label>的库存详细表</legend>
                    <asp:GridView ID="Gridview_Kucun" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" GridLines="None"
                        DataKeyNames="IMID_ID" OnPageIndexChanging="Gridview_KucunD_PageIndexChanging"
                        Width="100%" ondatabound="Gridview_Kucun_DataBound" 
                        onrowdatabound="Gridview_Kucun_RowDataBound"  >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <%--<FooterStyle CssClass="GridViewFooterStyle" />--%>
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="3%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="IMID_ID" HeaderText="库存详细ID" ReadOnly="True" SortExpression="IMID_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商" ReadOnly="True"
                                SortExpression="PMSI_SupplyName" >
                                <ItemStyle/>
                            </asp:BoundField>
                           
                              <asp:BoundField DataField="IMS_StoreName" HeaderText="库房" ReadOnly="True"
                                SortExpression="IMS_StoreName" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMSA_AreaName" HeaderText="库存区域" ReadOnly="True"
                                SortExpression="IMSA_AreaName" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_Num" HeaderText="数量" SortExpression="IMID_Num">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_InHouseTime" HeaderText="入库时间" SortExpression="IMID_InHouseTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="IMID_QA" HeaderText="检验结果" SortExpression="IMID_QA"  >
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMID_DownLevel" HeaderText="是否降档" SortExpression="IMID_DownLevel"  >
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMID_DownLevelPara" HeaderText="降档参数" SortExpression="IMID_DownLevelPara">
                                <ItemStyle />
                            </asp:BoundField> 
                                <asp:TemplateField Visible="true" HeaderText="调拨数量">
                                <ItemTemplate >
                                     <asp:TextBox runat="server" ID="TextBox8" Width="95px" Enabled="true" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"> </asp:TextBox>
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
                    </asp:GridView>   
                    <table width="100%">
                     <tr>
                        <td style="width:50%" align="center">
                          <asp:Button ID="Button20" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmStoreD" Width="90px" />
                        </td>
                         <td style="width:50%" align="center">
                          <asp:Button ID="Button21" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseStoreD" Width="90px" />
                        </td>
                     </tr>
                    </table>           
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
