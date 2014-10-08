<%@ Page Title="模板管理" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="TemplateUpload.aspx.cs" Inherits="ProductionBasicInfo_TemplateUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <asp:Label ID="Label_Grid1_Color" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Label_sort" runat="server"></asp:Label>
                <asp:Label ID="Label_Grid1_State" runat="server" Text="默认数据源" Visible="False"></asp:Label>
                <asp:Label ID="Label_Search" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>模板查询</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                模板名称：
                            </td>
                            <td style="width: 21%;">
                                <asp:TextBox ID="Txt_search" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width: 25%;">
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" 
                                    CssClass="Button02" onclick="Btn_Search_Click"
                                    />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button_SearchReset" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" onclick="Button_SearchReset_Click" />
                            </td>
                            <td style="width: 20%;" align="center">
                                <asp:Button ID="ButtonAdd" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增模板" Width="90px" onclick="ButtonAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="ButtonAdd" />
    </Triggers>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelAdd" runat="server" Visible="false">  
                <fieldset>
                    <legend>模板新增<asp:Label ID="Label2" runat="server" Visible="true">(上传图片格式为jpg,gif,bmp,png,图片大小不得超过8M)</asp:Label></legend>
                    
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                模板名称：
                            </td>
                            <td style="width: 21%;">
                                <asp:TextBox ID="txt_Tmp" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                            </td>
                            <td style="width: 25%;">
                                <asp:FileUpload ID="ImgFileUpload" runat="server" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="BtnUpload" runat="server" Text="模板上传" Width="70px" 
                                    Height="24px" CssClass="Button02" onclick="BtnSubmit_Click"
                                    />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="BtnAddReset" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" onclick="BtnAddReset_Click" />
                            </td>
                            <td style="width: 20%;" align="center">
                                <asp:Button ID="BtnAddClose" runat="server" CssClass="Button02" Height="24px" 
                                    Text="关闭" Width="70px" onclick="BtnAddClose_Click" />
                            </td>
                        </tr>
                    </table>           
                </fieldset>
        </asp:Panel>

            <asp:Panel ID="PanelEdit" runat="server" Visible="false">  
                <fieldset>
                    <legend>模板编辑<asp:Label ID="Label_ImgUrl" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_EditTmpID" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Visible="true">(上传图片格式为jpg,gif,bmp,png,图片大小不得超过8M)</asp:Label>
                    </legend>
                        
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                模板名称：
                            </td>
                            <td style="width: 21%;">
                                <asp:TextBox ID="TextBox_Edit" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                            </td>
                            <td style="width: 25%;">
                                <asp:FileUpload ID="FileUploadEdit" runat="server" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="ButtonSubmitEdit" runat="server" Text="模板上传" Width="70px" 
                                    Height="24px" CssClass="Button02" onclick="Btn_SubmitEdit_Click"
                                    />
                            </td>
                            <td style="width: 15%;" align="center">
                            </td>
                            <td style="width: 20%;" align="center">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                                    Text="关闭" Width="70px" onclick="Btn_EditClose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="BtnUpload" />
        <asp:PostBackTrigger ControlID="ButtonSubmitEdit" />
    </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_Temp" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="true">
                <fieldset>
                    <legend>模板系列表<asp:Label ID="Lab_State" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="2" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" AllowSorting="True"  Width="100%" 
                        DataKeyNames="TmpUpload_ID,TmpUpload_Name,TmpUpload_ImgUrl"
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowcommand="GridView1_RowCommand"  >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TmpUpload_ID" HeaderText="模板ID" SortExpression="TmpUpload_ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="TmpUpload_ImgUrl" HeaderText="文件路径" SortExpression="TmpUpload_ImgUrl" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="TmpUpload_Name" SortExpression="TmpUpload_Name" HeaderText="模板名称"></asp:BoundField>
                            <asp:BoundField DataField="TmpUpload_Person" SortExpression="TmpUpload_Person" HeaderText="上传人"></asp:BoundField>
                            <asp:BoundField DataField="TmpUpload_Time" SortExpression="TmpUpload_Time" HeaderText="上传时间"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditTemplateButton" runat="server" CommandArgument='<%# Eval("TmpUpload_ID") %>'
                                            CommandName="EditTemplate">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandArgument='<%# Eval("TmpUpload_ID") %>'
                                         CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckProType" runat="server" CommandArgument='<%# Eval("TmpUpload_ID")%>'
                                        CommandName="CheckProType">查看所属产品型号</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckImage" runat="server" CommandArgument='<%# Eval("TmpUpload_ID")%>'
                                        CommandName="CheckImage">查看模板图片</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
        <Triggers>
            <asp:PostBackTrigger ControlID="GridView1" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_ShowImage" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelShowImage" runat="server" Visible="false">
                
                <fieldset>
                    <legend><asp:Label ID="Label_ShowImgUrl" runat="server" Visible="false"></asp:Label><asp:Label ID="Label_ImgName" runat="server"></asp:Label>模板图片</legend>
                    <table style="width: 100%;">
                    <tr style="width: 100%;">
                        <td>
                            <asp:Image ID="TempImage" runat="server"/>
                        </td>
                    </tr>
                    <tr style="width: 100%;">
                        <td>
                        <asp:Button ID="ButtonCloseImg" runat="server" CssClass="Button02" Height="24px" align="right"
                                    Text="关闭" Width="70px" OnClick="ButtonCloseImg_Click"/>
                        </td>
                    </tr>
                    </table>
                    
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        产品型号表
                        <asp:Label ID="Label_TmpID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                产品型号：
                            </td>
                            <td style="width: 16%;">
                                <asp:TextBox ID="Txt_PT_Search" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="center">
                                产品编码：
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:TextBox ID="Txt_PT_Search0" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_SearchPT_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button_CancelPT_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_AddPT" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_AddPT_Click"
                                    Text="新增产品型号" Width="90px" />
                            </td>
                            <td style="width: 35%;" align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" AllowSorting="True"
                        Width="100%" DataKeyNames="PT_ID" EmptyDataText="无相关记录!" OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="PT_Code" SortExpression="PT_Code" HeaderText="产品编码"></asp:BoundField>
                            <asp:BoundField DataField="PT_Special" SortExpression="PT_Special" HeaderText="是否属于特殊产品">
                            </asp:BoundField>
                            <asp:BoundField DataField="BOM_Name" SortExpression="BOM_Name" HeaderText="BOM名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="BOM_ID" SortExpression="BOM_ID" HeaderText="BOMID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PR_Name" SortExpression="PR_Name" HeaderText="工艺路线名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="PR_ID" SortExpression="PR_ID" HeaderText="工艺路线ID" Visible="false">
                            </asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 320px;">
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxAll" runat="server" Text="全选" Width="80px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll_CheckedChanged" Style="margin-left: 0px" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxfanxuan" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan_CheckedChanged" />
                            </td>
                            <td>
                                <asp:Button ID="Btn_deleting" runat="server" CssClass="Button02" Height="24px" 
                                    Text="删除" Width="70px" onclick="Btn_deleting_Click" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_CloseS" runat="server" CssClass="Button02" Height="24px"  
                                    Text="关闭" Width="70px" onclick="Button_CloseS_Click" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                产品型号：
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                产品编码：
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Button ID="Button_ProTypeSearch" runat="server" CssClass="Button02" Height="24px"  
                                    Text="检索" Width="70px" onclick="Button_ProTypeSearch_Click" />
                                &nbsp;
                            </td>
                            <td align="left" style="width: 15%">
                                <asp:Button ID="Button_SearchProTypeReset" runat="server" CssClass="Button02" Height="24px"  
                                    Text="重置" Width="70px" onclick="Button_SearchProTypeReset_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        GridLines="None" DataKeyNames="PT_ID" AllowSorting="True" OnPageIndexChanging="GridView_ProType_PageIndexChanging">
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridviewHead" BorderStyle="Double" BorderWidth="1px" Height="26px"
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="PT_Code" HeaderText="产品编码" ItemStyle-Width="30%" />
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 310px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="全选" Width="83px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll2_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="Checkfanxuan2" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan2_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button_AddPTToSeries" runat="server" CssClass="Button02" Height="24px"
                                     Text="添加" Width="70px" onclick="Button_AddPTToSeries_Click" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    Text="关闭" Width="70px" onclick="Button_ClosePT_Click" />
                            </td>
                        </tr>
                    </table>
               </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

