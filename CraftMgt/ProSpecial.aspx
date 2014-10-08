<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProSpecial.aspx.cs" Inherits="ProductionBasicInfo_ProSpecial"
    MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .auto-style7 {
            width: 19%;
        }
        .auto-style8 {
            width: 17%;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:UpdatePanel ID="UpdatePanel_SupplySearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SupplySearch" runat="server" Visible="true">
                <fieldset>
                    <legend>检索条件<asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label></legend>
                    <asp:Label ID="labelcodition" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="label_Title" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label2" runat="server" Text="特殊产品编号："></asp:Label>
                            </td>
                            <td style="width: 12%; height: 20px;" align="left">
                                <asp:TextBox ID="Mory" runat="server"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label3" runat="server" Text="申请人："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label1" runat="server" Text="申请时间："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="Button_Sh1" Width="70px" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button3" runat="server" Text="新增特殊产品申请" CssClass="Button02" Height="24px"
                                    OnClick="Button_New" Width="145px" />
                            </td>
                            <td style="width: 15%" align="center" colspan="2">
                                <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Button_Reset" Visible="true" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Preserve" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Preserve" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_WHB" runat="server" Visible="true" Text="特殊产品申请单"></asp:Label>
                    </legend>
                    <asp:Label ID="label_PT_ID" runat="server" Visible="false"></asp:Label>
                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None"
                        PageSize="10" OnRowCommand="Gridview2_RowCommand" AllowPaging="True" AllowSorting="True"
                        DataKeyNames="PT_ID" OnPageIndexChanging="Gridview2_PageIndexChanging" Width="100%"
                        OnDataBound="Gridview2_DataBound" EnableModelValidation="True" OnRowDataBound="Gridview2_RowDataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品ID" SortExpression="PT_ID" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_SpecialCode" HeaderText="特殊产品编号" SortExpression="PT_SpecialCode" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name" />
                            <asp:BoundField DataField="PT_SpecialNeed" HeaderText="客户要求" SortExpression="PT_SpecialNeed" />
                            <asp:BoundField DataField="PT_Note" HeaderText="备注" SortExpression="PT_Note"></asp:BoundField>
                            <asp:BoundField DataField="PT_SpecialTypeMan" HeaderText="申请人" SortExpression="PT_SpecialTypeMan" />
                            <asp:BoundField DataField="PT_SpecialTypeTime" HeaderText="申请时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                SortExpression="PT_SpecialTypeTime" />
                            <asp:BoundField DataField="PT_CSate" HeaderText="申请状态" SortExpression="PT_CSate" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLok3" runat="server" CommandName="Edit1" CommandArgument='<%#Eval("PT_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLok4" runat="server" CommandName="Cancel1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("PT_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLook3" runat="server" CommandName="SelectDept" CommandArgument='<%#Eval("PT_ID")%>'>选择会签部门</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btMake" runat="server" CommandName="Make" CommandArgument='<%#Eval("PT_ID")%>'>制定</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLook4" runat="server" CommandName="Design" CommandArgument='<%#Eval("PT_ID")%>'>会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLook5" runat="server" CommandName="Look" CommandArgument='<%#Eval("PT_ID")%>'>查看会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLook6" runat="server" CommandName="Lookinfo" CommandArgument='<%#Eval("PT_ID")%>'>查看基础数据</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLook7" runat="server" CommandName="MAcc" CommandArgument='<%#Eval("PT_ID")%>'>上传附件</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                        <ItemTemplate >
                        <asp:HyperLink ID="DownS" runat="server"   CommandArgument='<%#Eval("PT_SAccPath")%>'  NavigateUrl='<%#"~/"+Eval("PT_SAccPath")+"?path={0}"%>'>查看申请附件</asp:HyperLink>
                         </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField>
                        <ItemTemplate >
                        <asp:HyperLink ID="DownM" runat="server"   CommandArgument='<%#Eval("PT_MAccPath")%>'  NavigateUrl='<%#"~/"+Eval("PT_MAccPath")+"?path={0}"%>'>查看制定附件</asp:HyperLink>
                         </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="PT_SAccPath" HeaderText="申请附件" SortExpression="PT_SAccPath" Visible="False" />
                            <asp:BoundField DataField="PT_MAccPath" HeaderText="制定附件" SortExpression="PT_MAccPath" Visible="False" />
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="printpreview" runat="server"  CommandName="printpreview">打印</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewProjectInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewProjectInfo" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_Change" runat="server" Visible="true"></asp:Label>
                    </legend>
                    <asp:Label ID="label_RTX" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="label_Acc" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%">
                        <tr>
                             <td  align="right" colspan="6">
                <asp:Button ID="Button27" runat="server" Text="上传附件" CssClass="Button02" Height="24px" OnClick="Button_Aline"
                    Width="90px" />
            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label5" runat="server" Text="客户要求：</br>(1000字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox4" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 1000)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label4" runat="server" Text="备注：</br>(200字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox2" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                                    Width="93%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1">
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" OnClick="ConfirmProject "
                                    Text="提交" Width="70px" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" OnClick="CanelProject"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="Div1" >
     <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
       
        <ContentTemplate>
             
                <fieldset>
                    <legend> 附件上传</legend>
                     <asp:Label ID="label_AccNum" runat="server"  Visible="false"></asp:Label>
                     <asp:Label ID="label_AccName" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="label_Coutersign" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="Label_FilePath" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="LabelQ_SaveDirectory" runat="server"  Visible="false"></asp:Label>
    <table style="width: 100%;">
    <tr style="height: 16px;">
    <td style="width: 16%" align="right">
                <asp:Label ID="Label51" runat="server" Text="附件编号："></asp:Label>
            </td>
             <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox18" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
             <td align="right" style="width: 10%">
                <asp:Label ID="Label53" runat="server" Text="附件名称："></asp:Label>
            </td>
             <td align="left" class="auto-style8">
                <asp:TextBox runat="server" ID="TextBox19" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
    <td style="width: 8%" align="right">
                <asp:Label ID="Label55" runat="server" Text="上传文件："></asp:Label>
               
                </td>
                 <td style="width: 17%" align="left">
                     <asp:FileUpload ID="FileUpload1" runat="server" Width="140px" />
                   <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
            </tr>
            <tr>
            <td  align="center" colspan="1">
            </td>
             <td  align="center" colspan="2">
                <asp:Button ID="Button28" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button1_Fox"
                    Width="90px" />
            </td>
             <td  align="center" colspan="2">
                <asp:Button ID="Button29" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button1_Emi"
                    Width="90px" />
            </td>
            </tr>
     </table>
     </fieldset>
        </ContentTemplate>
     
<Triggers>
    <asp:PostBackTrigger ControlID="Button28" />
        </Triggers>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button_TijiaoWeihu" EventName="Click" />
        </Triggers>--%>
        </asp:UpdatePanel>
  </div>


    <asp:UpdatePanel ID="UpdatePanel_Org" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Org" runat="server" Visible="false">
                <fieldset>
                    <legend>部门查询</legend>
                    <asp:Label ID="Label_PMSCAC_ID" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 17%; height: 20px;" align="right">
                            </td>
                            <td style="width: 12%; height: 20px;" align="right">
                                <asp:Label ID="Label60" runat="server" Text="部门名称："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20px;" align="left">
                                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 17%; height: 20px;" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Button ID="Button31" runat="server" CssClass="Button02" Height="24px" OnClick="Button1_Kil"
                                    Text="检索" Width="80px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button32" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Button_CoMl" Width="80px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="Gridview3" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="BDOS_Code"
                        OnPageIndexChanging="Gridview3_PageIndexChanging" Width="100%" EnableModelValidation="True"
                        OnDataBound="Gridview3_DataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckMarkup" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="BDOS_Code" HeaderText="部门ID" SortExpression="BDOS_Code"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门名称" SortExpression="BDOS_Name" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td width="34%" align="right">
                                <asp:Button ID="Button33" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_ComSPP" Width="70px" />
                            </td>
                            <td style="width: 20%" align="center">
                                &nbsp;
                            </td>
                            <td style="width: 20%" align="center">
                                &nbsp;
                            </td>
                            <td width="30%" align="left">
                                <asp:Button ID="Button34" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="Button_CancelSPP" Width="70px" />
                            </td>
                        </tr>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
                <fieldset>
                    <legend>特殊产品会签表</legend>
                    <asp:Label ID="label_PTC_ID" runat="server" Visible="false"></asp:Label>
                    <asp:GridView ID="Gridview4" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None"
                        PageSize="10" OnRowCommand="Gridview4_RowCommand" AllowPaging="True" AllowSorting="True"
                        OnRowDataBound="Gridview4_RowDataBound" DataKeyNames="PTC_ID" OnPageIndexChanging="Gridview_4_PageIndexChanging"
                        Width="100%" OnDataBound="Gridview4_DataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:BoundField DataField="PTC_ID" HeaderText="会签ID" SortExpression="PTC_ID" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="PTC_Dep" HeaderText="会签部门" SortExpression="PTC_Dep"></asp:BoundField>
                            <asp:BoundField DataField="PTC_State" HeaderText="会签结果" SortExpression="PTC_State">
                            </asp:BoundField>
                            <asp:BoundField DataField="PTC_Suggestion" HeaderText="会签意见" SortExpression="PTC_Suggestion">
                            </asp:BoundField>
                            <asp:BoundField DataField="PTC_Man" HeaderText="会签人" SortExpression="PTC_Man"></asp:BoundField>
                            <asp:BoundField DataField="PTCC_Time" HeaderText="会签时间" DataFormatString="{0:yyyy-MM-dd HH:mm }"
                                SortExpression="PTCC_Time"></asp:BoundField>
                            <%-- <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Modify1" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Mylo" runat="server" CommandName="Myloo" CommandArgument='<%#Eval("PTC_ID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Myllo" runat="server" CommandName="Mylloo" CommandArgument='<%#Eval("PTC_ID")%>'>会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Miko" runat="server" CommandName="Miko" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("PTC_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 20%" align="center">
                                &nbsp;
                            </td>
                            <td width="30%" align="left">
                                <asp:Button ID="Button37" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Ccl"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false" Enabled="true">
                <fieldset>
                    <legend>
                        <asp:Label ID="label40" runat="server" Visible="true"></asp:Label></legend>
                    <asp:Label ID="label_RTX1" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="labelCheckState" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td align="right" style="width: 15%; height: 20px;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 12%; height: 20px;">
                                <asp:Label ID="label41" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td align="right" style="width: 15%; height: 20px;">
                                <asp:Label ID="Label42" runat="server" Text="会签人：" Visible="false"></asp:Label>
                            </td>
                            <td align="left" style="width: 15%; height: 20px;">
                                <asp:Label ID="label43" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td align="right" style="width: 15%; height: 20px;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 15%; height: 20px;">
                                <asp:Label ID="label44" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td align="right" style="width: 15%; height: 20px;">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 15%; height: 20px;">
                                &nbsp;
                            </td>
                            <tr>
                                <td style="width: 15%" align="center">
                                    <asp:Label ID="label45" runat="server" Visible="true" Text="会签意见："></asp:Label>
                                    <br />
                                    <asp:Label ID="labelXZ3" runat="server" Text="(200字以内)" Visible="true"></asp:Label>
                                </td>
                                <td style="width: 17%" align="left" colspan="7">
                                    <asp:TextBox runat="server" ID="TextBox15" Height="81px" Width="90%" Visible="true"
                                        Enabled="true" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                        onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                                </td>
                            </tr>
                            <%-- </table>--%>
                            <%--  </fieldset>
       </asp:Panel>
       <asp:Panel ID="Panel5" runat="server" Visible="false"  >
                <fieldset>
                    <legend>  </legend>--%>
                            <%--<table style="width: 100%;">--%>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="false" Enabled="true">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 15%">
                            &nbsp;
                        </td>
                        <td style="width: 15%" align="center" colspan="2">
                            <asp:Button ID="Button22" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                                OnClick="ButtonPass" Text="通过" Width="70px" />
                        </td>
                        <td style="width: 15%" align="center">
                            <asp:Button ID="Button23" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                                OnClick="ButtonUnpass" Text="驳回" Width="70px" />
                        </td>
                        <td style="width: 15%" align="center" colspan="2">
                            <asp:Button ID="Button24" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                OnClick="ButtonClose" Width="70px" />
                        </td>
                        <td style="width: 15%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%" align="center" colspan="8">
                            <asp:Button ID="Button30" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                OnClick="Button_CClose" Width="70px" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
