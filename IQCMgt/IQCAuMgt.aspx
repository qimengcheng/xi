<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="IQCAuMgt.aspx.cs" Inherits="IQCMgt_IQCAuMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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

        function onlynumanddot(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, "");
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
    <asp:Label ID="Label30" runat="server" Visible="false"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel_SearchMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchMaterial" runat="server" >
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
                                <asp:Label ID="Label31" runat="server" CssClass="STYLE2" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TextBox1" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtMaterialCode" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr style="height: 7px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="LblPost" runat="server" CssClass="STYLE2" Text="到货时间："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:TextBox ID="TxtArriveTime1" runat="server" Width="155px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="到"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:TextBox ID="TxtArriveTime2" runat="server" Width="155px" 
                                    onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="right">
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="检索所有："></asp:Label>                                
                            </td>
                            <td style="width: 40%;" align="left">
                                <asp:DropDownList ID="Ddl_Au" runat="server" Width="155px" ToolTip="单击选择">
                                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            
                                 <td style="width: 7%" align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="供货单位："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtSupplyName" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                           <td colspan="2" align="center"><asp:CheckBox ID="CheckBox1" runat="server" Text="审核驳回" /> </td>
                        </tr>
                        
                    </table>
                    <table style="width: 100%;" align="center">
                        <tr>
                        <td style="width: 15%"></td>
                            <td align="center" style="width: 35%">
                                <asp:Button ID="BtnSearchMaterial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchMaterial_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 35%">
                                <asp:Button ID="BtnResetMaterial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetMaterial_Click" Text="重置" Width="70px" />
                            </td>
                        <td style="width: 15%"></td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_GridMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridMaterial" runat="server" >
                <fieldset>
                    <legend><asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text=""></asp:Label></legend>
                    <asp:GridView ID="Grid_Material" runat="server" DataKeyNames="IMISD_ID,IQCDT_ProResult" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="5" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Material_PageIndexChanging"
                        OnRowCommand="Grid_Material_RowCommand"
                        ondatabound="Grid_Material_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMISD_ID" HeaderText="入库单明细表ID" ReadOnly="True" SortExpression="IMISD_ID"
                                Visible="false">
                            </asp:BoundField>         
                            <asp:BoundField DataField="IQCDT_ID" HeaderText="入库单明细ID" ReadOnly="True" SortExpression="IQCDT_ID"
                                Visible="false">
                            </asp:BoundField>        
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                            </asp:BoundField>                             
                            <asp:BoundField DataField="IMISM_InStoreNum" SortExpression="IMISM_InStoreNum" HeaderText="入库单号">
                            </asp:BoundField>                        
                            <asp:BoundField DataField="IMMT_MaterialType" SortExpression="IMMT_MaterialType" HeaderText="物料类别">
                            </asp:BoundField>                
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName" HeaderText="物料名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" SortExpression="IMMBD_MaterialCode" HeaderText="物料编码">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel" HeaderText="规格型号">
                            </asp:BoundField>
                               <asp:BoundField DataField="IMISD_BatchNum" SortExpression="IMISD_BatchNum"
                                HeaderText="批号"></asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" SortExpression="PMSI_SupplyName" HeaderText="供货单位">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_ActualArrNum" SortExpression="IMIDS_ActualArrNum" HeaderText="到货数量">
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="单位">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_InStoreTime" SortExpression="IMISM_InStoreTime" HeaderText="到货日期">
                            </asp:BoundField>
                            <asp:BoundField DataField="IQCDT_ProResult" SortExpression="IQCDT_ProResult" HeaderText="预检结果">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnView_CertDetail" runat="server" CommandName="View_CertDetail"
                                        OnClientClick="false" CommandArgument='<%#Eval("IMISD_ID") +","+ Eval("IMMBD_MaterialName") +","+ Eval("IMMBD_MaterialID") +","+ Eval("IQCDT_ID")%>'>查看检验结果</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnNew_Test" runat="server" CommandArgument='<%#Eval("IMISD_ID") +","+ Eval("IMMBD_MaterialName") +","+ Eval("IMMBD_MaterialID")+","+ Eval("IQCDT_ID") %>'
                                        CommandName="New_Test" OnClientClick="false" >审核</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnView_Au" runat="server" CommandArgument='<%#Eval("IMISD_ID") +","+ Eval("IMMBD_MaterialName") +","+ Eval("IMMBD_MaterialID")  +","+ Eval("IQCDT_ID")%>'
                                        CommandName="View_Au" OnClientClick="false" >审核查看</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                             <asp:BoundField DataField="IQCDT_AResult" SortExpression="IQCDT_AResult" HeaderText="审核结果">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Rin" runat="server"  CommandArgument='<%#Eval("IMISD_ID") +","+ Eval("IMMBD_MaterialName") +","+ Eval("IMMBD_MaterialID")  +","+ Eval("IQCDT_ID")%>'
                                        CommandName="Rin" OnClientClick="false" >重录检验结果</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
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
    
    <asp:UpdatePanel ID="UpdatePanel_AddWorkOrder" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Ddl_AuRe" />
<asp:AsyncPostBackTrigger ControlID="Ddl_IsShengChan"></asp:AsyncPostBackTrigger>
        </Triggers>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Ddl_IsShengChan" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_AddWorkOrder" runat="server" Visible="false">
                <asp:Label ID="Label33" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="Lbl_Check" runat="server" CssClass="STYLE2" Text=""></asp:Label></legend>
                    <asp:Label ID="Label37" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td align="right" style="width: 13%;">
                                审核结果：
                            </td>
                            <td align="left" style="width: 20%">
                                <asp:DropDownList ID="Ddl_AuRe" runat="server" Width="150px" ToolTip="单击选择"  AutoPostBack="true"
                                OnSelectedIndexChanged="Ddl_AuRe_SelectedIndexChanged">
                                   <asp:ListItem  >请选择</asp:ListItem>
                                       <asp:ListItem >精选</asp:ListItem>
                                       <asp:ListItem >普通</asp:ListItem>
                                    <asp:ListItem >合格</asp:ListItem>
                                    <asp:ListItem >降档</asp:ListItem>
                                    <asp:ListItem >让步接收</asp:ListItem>
                                      <asp:ListItem >二次检验</asp:ListItem>
                                    <asp:ListItem >不合格</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" style="width: 10%;" >
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="审核时间：" Visible="false"></asp:Label>
                            </td>
                            <td align="left" style="width: 20%" visible="false">
                                <asp:TextBox ID="Txt_AuTime" runat="server"  Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="right">
                                <asp:Label ID="Label25" runat="server" CssClass="STYLE2" Text="审核人：" Visible="false"></asp:Label>
                                
                            </td>
                            <td style="width: 40%;" align="left">
                                <asp:TextBox ID="Txt_AuPer" runat="server"  Width="155px" MaxLength="10" 
                                    Height="17px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 7%;" align="right">
                                审核意见：<br>(50字以内)
                            </td>
                            <td colspan="7" align="left">
                                <asp:TextBox ID="Txt_AuAug" runat="server" Width="90%" TextMode="MultiLine" 
                                    MaxLength="50" onfocus="annotation('Label11');" onblur="javascript:leave('Label11');"
                                        onkeyup="this.value = this.value.substring(0, 50)" onafterpaste="this.value = this.value.substring(0, 50)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 7%;">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="降档详情：" Visible="false"></asp:Label><br>
                                <asp:Label ID="Label24" runat="server" CssClass="STYLE2" Text="(50字以内)" Visible="false"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="Txt_Jiangdang" runat="server" Width="90%" TextMode="MultiLine" 
                                    Visible="false" MaxLength="50"  onfocus="annotation('Label21');" onblur="javascript:leave('Label21');"
                                        onkeyup="this.value = this.value.substring(0, 50)" onafterpaste="this.value = this.value.substring(0, 50)"></asp:TextBox>  
                                <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>                                  
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 7%;" align="right">
                            <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="是否继续生产：" Visible="true"></asp:Label>                                
                            </td>
                            <td style="width: 15%;" align="left">
                                <asp:DropDownList ID="Ddl_IsShengChan" runat="server" Width="150px"  
                                    ToolTip="单击选择"   AutoPostBack="true"
                                OnSelectedIndexChanged="Ddl_IsShengChan_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                    <asp:ListItem Value="1" >是</asp:ListItem>
                                    <asp:ListItem Value="2" >否</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 7%;" align="right">
                            <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="档次要求：" Visible="false"></asp:Label>                                
                            </td>
                            <td style="width: 15%;" align="left">
                                <asp:DropDownList ID="DropDownList_Add_level" runat="server" Width="155px" Visible="false">
                                    <asp:ListItem>A档</asp:ListItem>
                                    <asp:ListItem>B档</asp:ListItem>
                                    <asp:ListItem>C档</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;" align="center">
                        <tr>
                           
                            <td style="width: 35%" align="center">
                                <asp:Button ID="Button_Submit_Add" runat="server" Text="提交" Width="70px" 
                                    ValidationGroup="Au" Height="24px"
                                    CssClass="Button02" OnClick="Btn_Submit_Add_Click" />
                                &nbsp;
                            </td>
                            <td style="width: 35%" align="center">
                                <asp:Button ID="Button1" runat="server" Text="驳回" Width="70px" 
                                    ValidationGroup="Au" Height="24px"
                                    CssClass="Button02" OnClick="Btn_Submit_Refuse_Click" />
                                &nbsp;
                            </td>
                            <td style="width: 35%" align="center">
                                &nbsp;<asp:Button ID="Button_CancelAdd" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CancelAdd_Click" Text="关闭" Width="70px" />
                                &nbsp;
                            </td>
                            <td style="width: 15%"></td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewExpApp" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewExpApp" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblExpApp" runat="server" CssClass="STYLE2" Text=""></asp:Label>
                              <asp:Label ID="Label32" runat="server" CssClass="STYLE2" Text="" Visible="false"></asp:Label>
                         <asp:Label ID="Label36" runat="server" Visible="false"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="物料类别："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtNewMaterialType" runat="server" Width="130px" MaxLength="25" Enabled="false"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtNewMaterialName" runat="server" Width="130px" MaxLength="50" Enabled="false"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtNewMode" runat="server" Width="130px" MaxLength="50" Enabled="false"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label22" runat="server" CssClass="STYLE2" Text="物料编码："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtNewMaterialCode" runat="server" Width="130px" MaxLength="50" Enabled="false"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="供货单位："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtNewSupplyName" runat="server" Width="130px" Enabled="false" 
                                    MaxLength="50" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="到货数量："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtActualNum" runat="server" Width="130px" Enabled="false" 
                                     ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="单位："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtNewUnit" runat="server" Width="130px" Enabled="false" 
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="到货日期："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtNewArrivalTime" runat="server" Width="130px" Enabled="false" 
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="投入数："></asp:Label>
                            </td>
                            <td style="width: 17%">                       
                                <asp:TextBox ID="TxtNewNum" Width="130px" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    onafterpaste="this.value=this.value.replace(/\D/g,'')" MaxLength="8" 
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label20" runat="server" CssClass="STYLE2" Text="检验人："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="TxtTestPerson" runat="server" Width="130px" Enabled="False" ></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="检验时间："></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <asp:TextBox ID="Txt_CheckTime" runat="server" Width="130px" Enabled="false" 
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="检验结果："></asp:Label>
                            </td>
                            <td style="width: 17%">
                             
                                <asp:DropDownList ID="Txt_CheckResult" runat="server" Width="150px" ToolTip="单击选择"  >
                                   <asp:ListItem  >请选择</asp:ListItem>
                                       <asp:ListItem >精选</asp:ListItem>
                                       <asp:ListItem >普通</asp:ListItem>
                                    <asp:ListItem >合格</asp:ListItem>
                                    <asp:ListItem >降档</asp:ListItem>
                                    <asp:ListItem >让步接收</asp:ListItem>
                                      <asp:ListItem >二次检验</asp:ListItem>
                                    <asp:ListItem >不合格</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label23" runat="server" CssClass="STYLE2" Text="说明："></asp:Label>
                            </td>
                            <td style="width: 17%" colspan="8">
                                <asp:TextBox ID="Txt_CheckSug" runat="server" Width="98%" TextMode="MultiLine" 
                                    Enabled="False" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label34" runat="server" CssClass="STYLE2" Text="实验记录："></asp:Label>
                                <br>
                                <asp:Label ID="Label35" runat="server" CssClass="STYLE2" Text="(200字以内)"></asp:Label>
                            </td>
                            <td colspan="7" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100%" MaxLength="100" TextMode="MultiLine" Enabled="false"
                                    onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                            </td>
                        </tr>
                         <tr >
                            <td style="width: 80%" colspan="8" >
                                   
                                         <asp:GridView ID="GridView2" runat="server"  AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    Visible="true" GridLines="None" AllowPaging="True" Font-Strikeout="False" UseAccessibleHeader="False" EmptyDataText="没有QA项目">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                
                         
                    <asp:BoundField HeaderText="随工单号"  DataField="WO_Num" />
                    <asp:BoundField HeaderText="QA项目名称" Visible="true"   DataField="BPT_Name"/>
                        <asp:BoundField HeaderText="QA项目数量" Visible="true"   DataField="WOBP_Num"/>

                </Columns>
            </asp:GridView>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 80%" colspan="8">
                                <asp:GridView ID="Grid_ETTestItem" runat="server" DataKeyNames="IQCIT_ID" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    Visible="true" GridLines="None" AllowPaging="True" Font-Strikeout="False" UseAccessibleHeader="False"
                                    OnPageIndexChanging="Grid_ETTestItem_PageIndexChanging" 
                                    OnRowCommand="Grid_ETTestItem_RowCommand"  
                                    OnDataBound="Grid_ETTestItem_DataBound" PageSize="5">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="IQCIT_ID" HeaderText="检验项目ID" ReadOnly="True" SortExpression="IQCIT_ID"
                                            Visible="false">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料基础数据ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                            Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="IQCIT_Items" SortExpression="IQCIT_Items" HeaderText="检验项目"
                                            ReadOnly="True">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IQCIT_NeedValue" SortExpression="IQCIT_NeedValue" HeaderText="是否录入对应值"
                                            ReadOnly="True">
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit_ItemAmount" runat="server" CommandArgument='<%#Eval("IQCIT_ID")%>'
                                                    CommandName="Edit_ItemAmount" OnClientClick="false">查看检验值</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
                            </td>
                        </tr>
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr style="height: 16px;">
                            <td colspan="3" align="center">
                                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnSubmit1_Click" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnSubmit" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnSubmit_Click" />
                            </td>
                          
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_Standard" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Standard" runat="server" Visible="false">
                <fieldset>
                    <legend>检验标准
                    </legend>
                    <asp:GridView ID="Grid_Standard" runat="server" DataKeyNames="IQCSV_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="5" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Standard_PageIndexChanging"
                        ondatabound="Grid_Standard_DataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IQCSV_ID" HeaderText="检验值ID" ReadOnly="True" SortExpression="IQCSV_ID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>                              
                            <asp:BoundField DataField="IQCIT_Standard" SortExpression="IQCIT_Standard"  HeaderText="检验标准" ReadOnly="True">
                            </asp:BoundField>                
                            <asp:BoundField DataField="IQCIT_Remarks" SortExpression="IQCIT_Remarks" HeaderText="备注" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="QCSV_Value" SortExpression="QCSV_Value" HeaderText="对应值">
                            </asp:BoundField>
                            <asp:BoundField DataField="QCSV_Result" SortExpression="QCSV_Result" HeaderText="检验结果">
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
                    <table style="width: 100%">
                        <tr style="width: 100%;  height: 16px;">
                            <td style="width: 100%" align="center" >
                                <asp:Button ID="Btn_Close" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px"  OnClick="Btn_Close2_Click" />
                            </td>
                        </tr>
                     </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     </asp:Content>