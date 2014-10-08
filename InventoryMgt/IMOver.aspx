<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMOver.aspx.cs" Inherits="InventoryMgt_IMOver" 
  MasterPageFile="~/Other/MasterPage.master" Title="库存报废"%>
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
                    <legend>库存检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                            </td>
                          
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="物料规格："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                  <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                            
                            </td>
                           <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                           
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="物料编码："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="延期天数："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                  <asp:TextBox runat="server" ID="TextBox7"></asp:TextBox>
                            
                            </td>
                           <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="库房："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            
                            </td>
                        </tr>
                        <tr>
                           
                           
                           
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="入库时间从："></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                
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
                                    OnClick="SearchKucun" Width="80px" />
                            </td>
                            <td colspan="2" align="left">
                                
                            </td>
                             <td colspan="2" align="left">
                                <asp:Button ID="Button3" runat="server" Text="超期库存查看" CssClass="Button02" Height="24px"
                                    OnClick="ChaoqiKucun" Width="110px" />
                            </td>
                            
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--库存主表--%>
     <asp:UpdatePanel ID="UpdatePanel_Kucun" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Kucun" runat="server" Visible="false">  
                  <asp:Label ID="label11" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>物料库存表</legend>
                    <asp:GridView ID="Gridview_Kucun" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="IMID_ID"
                        GridLines="None" Width="100%" OnPageIndexChanging="Gridview_Kucun_PageIndexChanging"
                        OnRowCommand="Gridview_Kucun_RowCommand" 
                        >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                        
                            <asp:BoundField DataField="IMID_ID" HeaderText="库存详细ID" ReadOnly="True" SortExpression="IMID_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True" SortExpression="IMMBD_MaterialName"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True" SortExpression="IMMBD_SpecificationModel"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_Num" HeaderText="数量" ReadOnly="True" SortExpression="IMID_Num" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMS_StoreName" HeaderText="库房" ReadOnly="True" SortExpression="IMS_StoreName">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMSA_AreaName" HeaderText="区域" SortExpression="IMSA_AreaName">
                                <ItemStyle />
                            </asp:BoundField>
                           
                             <asp:BoundField DataField="IMID_InHouseTime" HeaderText="入库时间" ReadOnly="True"  DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="IMID_InHouseTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_StorageDay" HeaderText="质保期限" ReadOnly="True" SortExpression="IMMBD_StorageDay">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMID_DelayDay" HeaderText="延期天数" ReadOnly="True" SortExpression="IMID_DelayDay"   >
                                <ItemStyle />
                            </asp:BoundField>
                           
                           
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Apply" runat="server" CommandName="Apply" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMID_ID")%>'>报废申请</asp:LinkButton>
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
   <%--报废申请部分--%>
    <asp:UpdatePanel ID="UpdatePanel_Apply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Apply" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label22" runat="server" Visible="true"></asp:Label>报废申请</legend> <asp:Label ID="label10" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="right">
                                申请人:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchanman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">
                                申请时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchantime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            
                            <td align="right">
                                申请原因：<br />（200字内）
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_lingdaoyijian" runat="server" Height="80px" MaxLength="200" onblur="javascript:leave('LB1004');"
                                   TextMode="MultiLine" Width="99%" onkeyup="this.value = this.value.slice(0, 200)" ></asp:TextBox>
                            </td>
                        </tr>
                     
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 33%; text-align: center">
                                    <asp:Button ID="BT_TKOK" runat="server" CssClass="Button02" OnClick="ConfirmApply" Height="24px"
                                        Text="提交" Width="80px" />
                                    <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                </td>
                               
                                <td style="width: 33%; text-align: center">
                                    <asp:Button ID="BT_TKCancel" runat="server" CssClass="Button02" OnClick="CloseApply"  Height="24px"
                                   Text="关闭" Width="80px" />
                                </td>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%-- 报废申请检索--%>
    <asp:UpdatePanel ID="UpdatePanel_SearchApply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchApply" runat="server" Visible="false">
             <asp:Label ID="label7" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>报废申请检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox8"></asp:TextBox>
                            </td>
                          
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" Text="物料规格："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                  <asp:TextBox runat="server" ID="TextBox9"></asp:TextBox>
                            
                            </td>
                           <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox10"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                           
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" Text="申请人："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox11"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" Text="申请状态："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                 <asp:ListItem>选择状态</asp:ListItem>
                                    <asp:ListItem>待分析</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                </asp:DropDownList>
                            
                            </td>
                           <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" Text="库房："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                            
                            </td>
                        </tr>
                        <tr>
                           
                           
                           
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label16" runat="server" Text="申请时间从："></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                
                                <asp:TextBox runat="server" ID="TextBox13" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  Width="43%"></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox14" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  Width="43%"></asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button2" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchApply" Width="80px" />
                            </td>
                          
                             <td colspan="2" align="center">
                                <asp:Button ID="Button4" runat="server" Text="查看待分析的申请单" CssClass="Button02" Height="24px"
                                    OnClick="LookFApply" Width="130px" />
                            </td>
                             <td colspan="2" align="left">
                                <asp:Button ID="Button5" runat="server" Text="查看待审核的申请单" CssClass="Button02" Height="24px"
                                    OnClick="LookSApply" Width="130px" />
                            </td>
                            
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--报废申请表--%>
     <asp:UpdatePanel ID="UpdatePanel_ApplyMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ApplyMain" runat="server" Visible="false">  
                  <asp:Label ID="label17" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>报废申请表</legend>
                    <asp:GridView ID="Gridview_Apply" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="IMMS_ID"
                        GridLines="None" Width="100%" OnPageIndexChanging="Gridview_Apply_PageIndexChanging"
                        OnRowCommand="Gridview_Apply_RowCommand" 
                        onrowdatabound="Gridview_Apply_RowDataBound" ondatabound="Gridview_Apply_DataBound" 
                        >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                        
                            <asp:BoundField DataField="IMMS_ID" HeaderText="报废申请ID" ReadOnly="True" SortExpression="IMMS_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True" SortExpression="IMMBD_MaterialName"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True" SortExpression="IMMBD_SpecificationModel"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_Num" HeaderText="数量" ReadOnly="True" SortExpression="IMID_Num" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMS_StoreName" HeaderText="库房" ReadOnly="True" SortExpression="IMS_StoreName">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMSA_AreaName" HeaderText="区域" SortExpression="IMSA_AreaName">
                                <ItemStyle />
                            </asp:BoundField>
                           
                             <asp:BoundField DataField="IMMS_ApplyMan" HeaderText="申请人" ReadOnly="True"  
                                SortExpression="IMMS_ApplyMan">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMMS_AnalysisReason" HeaderText="申请原因" ReadOnly="True" SortExpression="IMMS_AnalysisReason" >
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMS_ApplyTime" HeaderText="申请时间" ReadOnly="True" SortExpression="IMMS_ApplyTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMMS_AnalysisResult" HeaderText="分析结果" ReadOnly="True" SortExpression="IMMS_AnalysisResult" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMS_State" HeaderText="状态" ReadOnly="True" SortExpression="IMMS_State"   >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMS_ScrapCheckMan" HeaderText="审核人" ReadOnly="True" SortExpression="IMMS_ScrapCheckMan"   >
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMMS_ScrapCheckOpinion" HeaderText="审核意见" ReadOnly="True" SortExpression="IMMS_ScrapCheckOpinion"   >
                                <ItemStyle />
                            </asp:BoundField>
                           
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Fenxi" runat="server" CommandName="Fenxi" OnClientClick="false" 
                                        CommandArgument='<%#Eval("IMMS_ID")%>'>报废分析</asp:LinkButton> 
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Shenhe" runat="server" CommandName="Shenhe" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMMS_ID")%>'>报废审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Zhixing" runat="server" CommandName="Zhixing" OnClientClick="return confirm('确认执行吗？')" 
                                        CommandArgument='<%#Eval("IMMS_ID")%>'>报废执行</asp:LinkButton>
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
     <%--报废分析部分--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label18" runat="server" Visible="true"></asp:Label>的报废分析</legend> <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                      
                        <tr>
                            
                            <td align="right">
                                分析结果：<br />（200字内）
                            </td>
                            <td style="width:80%">
                                <asp:TextBox ID="TextBox16" runat="server" Height="80px" MaxLength="200" onblur="javascript:leave('LB1004');"
                                   TextMode="MultiLine" Width="90%" onkeyup="this.value = this.value.slice(0, 200)" ></asp:TextBox>
                            </td>
                        </tr>
                     
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 33%; text-align: center">
                                    <asp:Button ID="Button6" runat="server" CssClass="Button02" OnClick="ConfirmFenxi" Height="24px"
                                        Text="提交" Width="80px" />
                                    <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                </td>
                               
                                <td style="width: 33%; text-align: center">
                                    <asp:Button ID="Button7" runat="server" CssClass="Button02" OnClick="CloseFenxi" Height="24px"
                                   
                                        Text="关闭" Width="80px" />
                                </td>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%--报废审核部分--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label20" runat="server" Visible="true"></asp:Label>的报废审核</legend> <asp:Label ID="label21" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                      
                        <tr>
                            
                            <td align="right">
                                审核意见：<br />（200字内）
                            </td>
                            <td style="width:80%" >
                                <asp:TextBox ID="TextBox19" runat="server" Height="80px" MaxLength="200" onblur="javascript:leave('LB1004');"
                                   TextMode="MultiLine" Width="99%" onkeyup="this.value = this.value.slice(0, 200)" ></asp:TextBox>
                            </td>
                        </tr>
                     
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 33%; text-align: center">
                                    <asp:Button ID="Button8" runat="server" CssClass="Button02" OnClick="CheckOK" Height="24px"
                                        Text="通过" Width="80px" />
                                    <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                </td>
                               <td style="width: 33%; text-align: center">
                                    <asp:Button ID="Button10" runat="server" CssClass="Button02" OnClick="CheckNotOK" Height="24px"
                                    
                                        Text="驳回" Width="80px" />
                                </td>
                                <td style="width: 33%; text-align: center">
                                    <asp:Button ID="Button9" runat="server" CssClass="Button02" OnClick="CloseCheck" Height="24px"
                                        Text="关闭" Width="80px" />
                                </td>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   </asp:Content>