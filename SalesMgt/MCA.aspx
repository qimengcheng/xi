<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MCA.aspx.cs" Inherits="SalesMgt_MCA"  MasterPageFile="~/Other/MasterPage.master" Title="配套加工申请" %>
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
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="true">
                <asp:Label ID="label21" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="申请单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox13"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label45" runat="server" Text="产品名称："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox runat="server" ID="TextBox14"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label46" runat="server" Text="申请部门："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox17" 
                                   ></asp:TextBox>
                            </td>
                            </tr>
                        <tr>
                            <td align="center">
                                申请时间从：
                            </td>
                            <td>

                                  <asp:TextBox runat="server" ID="TextBox4" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" ></asp:TextBox>
                            </td>
                          <td align="center">到</td>
                             <td>

                                  <asp:TextBox runat="server" ID="TextBox8" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" ></asp:TextBox>
                            </td>
                             <td style="width: 20%" align="center">
                                <asp:Label ID="Label18" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox9" 
                                   ></asp:TextBox>
                            </td>
                        </tr>
                            <tr>
                            <td colspan="2" align="right">  <asp:Button ID="Button7" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchApply" Width="70px" /></td>
                            <td align="center" colspan="2">
                               <asp:Button ID="Button8" runat="server" Text="新建申请单" CssClass="Button02" Height="24px"
                                    OnClick="NewApply" Width="90px" />
                            </td>
                        
                              <td colspan="2"  align="left">
                               <asp:Button ID="Button1" runat="server" Text="转至报表页" CssClass="Button02" Height="24px"
                                    OnClick="RepartTo" Width="90px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_JiaZhang" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel__JiaZhang" runat="server" Visible="true">
                <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>机械加工维修申请表</legend>
                    <asp:GridView ID="Gridview_JiaZhang" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                        PageSize="10" AllowPaging="True" AllowSorting="false" 
                        DataKeyNames="MCA_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_JiaZhang_PageIndexChanging" 
                        OnRowCommand="Gridview_JiaZhang_RowCommand" 
                        onrowdatabound="Gridview_JiaZhang_RowDataBound" OnDataBound="Gridview_JiaZhang_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="MCA_ID" HeaderText="价格账期ID" ReadOnly="True" SortExpression="MCA_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MCA_ApplyNum" HeaderText="申请单号" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MCA_Product" HeaderText="产品名称" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="MCA_Mount" HeaderText="数量" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="MCA_Price" HeaderText="单价" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="MCA_State" HeaderText="状态" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="MCA_Depart" HeaderText="申请部门" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="MCA_Man" HeaderText="申请人" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="MCA_Note" HeaderText="申请备注" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="MCA_Time" HeaderText="申请时间" ReadOnly="false"  DataFormatString="{0:yyyy-MM-dd}"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="MCA_Upload" HeaderText="附件" ReadOnly="false" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down2" runat="server" NavigateUrl='<%#"~/"+Eval("MCA_UploadPath")+"?path={0}"%>'>下载附件</asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandName="Look1" OnClientClick="false"
                                        CommandArgument='<%#Eval("MCA_ID")%>'>进度查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckD" runat="server" CommandName="CheckD" OnClientClick="false"
                                        CommandArgument='<%#Eval("MCA_ID")%>'>部门审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Price1" runat="server" CommandName="Price1" 
                                        CommandArgument='<%#Eval("MCA_ID")%>'>报价填写</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                                <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckM" runat="server" CommandName="CheckM" 
                                        CommandArgument='<%#Eval("MCA_ID")%>'>副总审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Over1" runat="server" CommandName="Over1" 
                                        CommandArgument='<%#Eval("MCA_ID")%>'>确认领取</asp:LinkButton>
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
   
   
    

    
      <%-- 审核--%>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                <asp:Label ID="Label3" runat="server"  Visible="false"></asp:Label>
                     <asp:Label ID="Label14" runat="server"  Visible="false"></asp:Label>
                    <legend><asp:Label ID="Label7" runat="server"  Visible="true"></asp:Label> <asp:Label ID="label8" runat="server" Visible="true"></asp:Label>机械加工维修表</legend>
                    <table style="width: 100%;">
                         <tr bgcolor="skyblue">
                              <td style="width: 15%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="产品名称(100字内)："></asp:Label>
                            </td>
                            <td style="width: 55%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3" MaxLength="100"  Width="99%"></asp:TextBox>
                            </td>
                             <td style="width: 15%" align="center">
                                <asp:Label ID="Label13" runat="server" Text="数量："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox2"  onkeyup="this.value=this.value.replace(/[^\d]/g,'')" ></asp:TextBox>
                            </td>
                              
                        </tr>
                        <tr bgcolor="skyblue">
                          
                            <td>
                                维修要求:(200字内)
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox5" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="Skyblue">
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="有附件"/>
                            </td>
                            <td>
                             
                            <asp:Label ID="Label15" runat="server" Text="上传路径："></asp:Label>
                            </td>
                            <td>
                                   <asp:LinkButton ID="LinkButton1" runat="server" Text="选择上传文件" OnClick="LinkButton1_Click">选择上传文件</asp:LinkButton>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr bgcolor="LightGrey">
                         
                            <td style="width: 15%" align="center">
                                部门审核人:
                            </td>
                            <td style="width: 25%">
                                 <asp:Label ID="Label9" runat="server" ></asp:Label>
                            </td>
                            <td style="width: 20%" align="right">
                                部门审核时间:
                            </td>
                            <td  style="width:40%">
                                 <asp:Label ID="Label5" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="LightGrey">
                          
                            <td align="center" >
                                部门审核意见:<br/>（200字内）
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox_AddOpinion" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                          <tr bgcolor="skyblue">
                         
                            <td style="width: 15%" align="center">
                                申报单价:
                            </td>
                               <td style="width: 25%">
                                <asp:TextBox ID="TextBox1" runat="server"   onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </td>
                                 <td style="width: 15%" align="center">
                                总额:
                            </td>
                                 <td style="width: 15%" align="center">
                                     <asp:Label ID="Label2" runat="server" ></asp:Label>
                            </td>
                              </tr>
                         <tr bgcolor="LightGrey">
                         
                            <td style="width: 15%" align="center">
                                报价审核人:
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="Label10" runat="server" ></asp:Label>
                            </td>
                            <td style="width: 20%" align="right">
                                报价审核时间:
                            </td>
                            <td >
                                 <asp:Label ID="Label6" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr bgcolor="LightGrey">
                          
                            <td align="center">
                                报价审核意见:<br/>（200字内）
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox6" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                              <tr bgcolor="skyblue">
                         
                            <td style="width: 15%" align="center">
                                收货人:
                            </td>
                               <td style="width: 25%">
                                <asp:TextBox ID="TextBox7" runat="server"  ReadOnly="true" Enabled="False" ></asp:TextBox>
                            </td>
                                   <td style="width: 15%" align="center">
                                收货时间:
                            </td>
                                   <td style="width: 15%" align="center">
                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                            </td>
                              </tr>
                        
                    </table>
                  </asp:Panel>
              <asp:Panel runat="server" ID="Panel3" Visible="false">
                    <table style="width: 100%">
                        <tr>
                              <asp:Label ID="Label11" runat="server"  Visible="false"></asp:Label>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="NewApplyOK" Height="24px"
                                    Text="提交" Width="80px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                               
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="NewApplyCanel" Height="24px"
                                    Text="关闭" Width="80px" />
                            </td>
                    </table>
            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" Visible="false">                
                    <table style="width: 100%; height: 35px;">
                        <tr>
                              <asp:Label ID="Label12" runat="server" Visible="false"></asp:Label>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button19" runat="server" CssClass="Button02" OnClick="Check_OK"
                                    Text="通过" Width="80px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                                <asp:Button ID="Button20" runat="server" CssClass="Button02" OnClick="Check_NotOK"
                                    Text="驳回" Width="80px" />
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button21" runat="server" CssClass="Button02" OnClick="Check_Canel"
                                    Text="关闭" Width="80px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="Panel99">
        <asp:UpdatePanel ID="UpdatePanel_upload" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset>
                    <legend>上传分析报告</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="Label16" runat="server" Visible="false"></asp:Label>
                        <tr style="height: 16px;">
                            <td align="right" style="width: 25%"></td>
                            <td align="center">
                                <asp:Label ID="Label48" runat="server" Text="上传附件： "></asp:Label>

                                <asp:FileUpload ID="FileUpload1" runat="server" Width="281px" Height="20px" />
                                <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" style="width: 25%"></td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" align="right">
                                <asp:Button ID="ok_upload" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="ok_upload_Click" ValidationGroup="loadvalidation" />
                            </td>
                            <td style="height: 16px;" align="center"></td>
                            <td align="left">
                                <asp:Button ID="cancel_upload" runat="server" Text="关闭" Width="70px" CssClass="Button02" OnClick="cancel_upload_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ok_upload" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </asp:Content>