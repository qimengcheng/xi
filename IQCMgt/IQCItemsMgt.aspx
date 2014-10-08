<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="IQCItemsMgt.aspx.cs" Inherits="IQCMgt_IQCItemsMgt" %>

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
    <asp:UpdatePanel ID="UpdatePanel_SearchMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchMaterial" runat="server" >
                <fieldset>
                    <legend>物料检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="物料类型："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtMaterialType" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtMaterialName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtSpecificationModel" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="right">
                                检索范围：
                            </td>
                            <td style="width: 40%;" align="left">
                                <asp:DropDownList ID="Ddl_Au" runat="server" ToolTip="单击选择" Width="200px">
                                    <asp:ListItem Value="0" Selected="True">进料检验物料</asp:ListItem>
                                    <asp:ListItem Value="1">非进料检验物料</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr>
                            <td align="right" style="width: 40%;">
                                <asp:Button ID="BtnSearchMaterial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchMaterial_Click" Text="检索" Width="70px" />
                            </td>
                            <td style="width: 20%;"></td>
                            <td align="left" style="width: 40%;">
                                <asp:Button ID="BtnResetMaterial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetMaterial_Click" Text="重置" Width="70px" />
                            </td>
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
                    <legend>
                        <asp:Label ID="LblGridMaterial" runat="server" CssClass="STYLE2" Text=""></asp:Label>
                    </legend>
                    <asp:GridView ID="Grid_Material" runat="server" DataKeyNames="IMMBD_MaterialID" AllowSorting="True"
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
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>                              
                            <asp:BoundField DataField="IMMT_MaterialType" SortExpression="IMMT_MaterialType" HeaderText="物料类型">
                            </asp:BoundField>                
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName" HeaderText="物料名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel" HeaderText="规格型号">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdt_Item" runat="server" CommandArgument='<%#Eval("IMMBD_MaterialID")%>'
                                        CommandName="Edt_Item" OnClientClick="false">检验项目维护</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Item" runat="server" CommandName="Delete_Item"
                                        OnClientClick="return confirm('您确认从进料检验物料中删除该物料吗?')" CommandArgument='<%#Eval("IMMBD_MaterialID")%>'>删除进料检验</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnChoose_Item" runat="server" CommandArgument='<%#Eval("IMMBD_MaterialID")%>'
                                        CommandName="Chs_Item" OnClientClick="false" >选择进料检验</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_IQCItemsMgt" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_IQCItemsMgt" runat="server" Visible="false">
                <fieldset>
                    <legend>检验项目检索</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="检验项目："></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:TextBox ID="TxtIQCItems" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="录入对应值："></asp:Label>
                            </td>
                            <td style="width: 40%">
                                <asp:DropDownList ID="DdlstNeedValue" runat="server" ToolTip="单击选择" Width="80px">
                                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="2">否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="Btn_SearchIQCItems" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_SearchIQCItems_Click" Text="检索" Width="70px" />
                            </td>      
                            <td align="center" colspan="2">
                                <asp:Button ID="Btn_NewIQCItems" runat="server" CssClass="Button02" 
                                    Height="24px" OnClick="BtnNew_Click"
                                    Text="新增" Width="70px" />
                            </td>    
                            <td align="left" colspan="2">
                                <asp:Button ID="Btn_ResetIQCItems" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ResetIQCItems_Click" Text="重置" Visible="true" Width="70px" />
                            </td>    
                        </tr>
                    </table>
                    <asp:GridView ID="Grid_IQCItems" runat="server" DataKeyNames="IQCIT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="5" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_IQCItems_PageIndexChanging"
                        OnRowCommand="Grid_IQCItems_RowCommand"
                        ondatabound="Grid_IQCItems_DataBound"  >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IQCIT_ID" HeaderText="检验项目ID" ReadOnly="True" SortExpression="IQCIT_ID" Visible="false">
                            </asp:BoundField>                              
                            <asp:BoundField DataField="IMMBD_MaterialID" SortExpression="IMMBD_MaterialID" ReadOnly="True" HeaderText="物料ID" Visible="false">
                            </asp:BoundField>                
                            <asp:BoundField DataField="IQCIT_Items" SortExpression="IQCIT_Items"  HeaderText="检验项目">
                            </asp:BoundField>
                            <asp:BoundField DataField="IQCIT_NeedValue" SortExpression="IQCIT_NeedValue"  HeaderText="是否需要录入对应值">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdt_ItemValue" runat="server" CommandArgument='<%#Eval("IQCIT_ID")%>'
                                        CommandName="Edt_ItemValue" OnClientClick="false">标准维护</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdt_Item" runat="server" CommandArgument='<%#Eval("IQCIT_ID")%>'
                                        CommandName="Edt_Item" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Item" runat="server" CommandName="Delete_Item"
                                        OnClientClick="return confirm('您确认删除该检验项目吗?')" CommandArgument='<%#Eval("IQCIT_ID")%>'>删除</asp:LinkButton>
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
                    <table style="width: 100%;" >
                        <tr>
                            <td align="center">
                                <asp:Button ID="Btn_ClsIQCItems" runat="server" CssClass="Button02" 
                                    Height="24px" OnClick="Btn_ClsIQCItems_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_EditItems" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_EditItems" runat="server" Visible="false">
                <fieldset>
                    <legend>检验项目维护</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="检验项目："></asp:Label>
                                <br>(40字以内)
                            </td>
                            <td style="width: 50%">
                                <asp:TextBox ID="Txt_EditItems" runat="server" Width="280px" MaxLength="40"  
                                    onfocus="annotation('Label8');" onblur="javascript:leave('Label8');"
                                        onkeyup="this.value = this.value.substring(0, 40)" 
                                    onafterpaste="this.value = this.value.substring(0, 40)" TextMode="MultiLine"></asp:TextBox>                                    
                                <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="录入对应值："></asp:Label>
                            </td>
                            <td style="width: 30%">
                                <asp:DropDownList ID="Ddl_EditValues" runat="server" ToolTip="单击选择" Width="80px">
                                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="2">否</asp:ListItem>
                                </asp:DropDownList>                                 
                                <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        </tr>
                            <tr>
                                <td align="right" style="width: 40%;">
                                    <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                                        OnClick="Btn_EditSubmitIQCItems_Click" Text="提交" ValidationGroup="Items" 
                                        Width="70px" />
                                </td>
                                <td style="width: 20%;">
                                </td>
                                <td align="left" style="width: 40%;">
                                    <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" 
                                        OnClick="Btn_EditClsIQCItems_Click" Text="关闭" Width="70px" />
                                </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SearchStandard" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchStandard" runat="server" Visible="false">
                <fieldset>
                    <legend>检验标准检索</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="检验标准："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtStandard" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="备注："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtRemarks" runat="server" Width="155px"></asp:TextBox>
                            </td>                  
                        </tr
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr style="height: 16px;">
                            <td align="right" >
                                <asp:Button ID="Btn_SearchStandard" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_SearchStandard_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_NewStandard" runat="server" CssClass="Button02" Height="24px" 
                                OnClick="Btn_NewStandard_Click"    Text="新增" Width="70px" />
                            </td>
                            <td align="left" >
                                <asp:Button ID="Btn_ResetStandard" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ResetStandard_Click" Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="Grid_ItemsValue" runat="server" DataKeyNames="IQCST_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="5" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_ItemsValue_PageIndexChanging"
                        OnRowCommand="Grid_ItemsValue_RowCommand"
                        ondatabound="Grid_ItemsValue_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IQCST_ID" HeaderText="检验标准ID" ReadOnly="True" SortExpression="IQCST_ID"
                                Visible="false">
                            </asp:BoundField>    
                            <asp:BoundField DataField="IQCIT_ID" HeaderText="检验项目ID" ReadOnly="True" SortExpression="IQCIT_ID"
                                Visible="false">
                            </asp:BoundField>            
                            <asp:BoundField DataField="IQCIT_Standard" SortExpression="IQCIT_Standard" HeaderText="检验标准">
                            </asp:BoundField>
                            <asp:BoundField DataField="IQCIT_Remarks" SortExpression="IQCIT_Remarks" HeaderText="备注">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdt_ItemValue" runat="server" CommandArgument='<%#Eval("IQCST_ID")%>'
                                        CommandName="Edt_ItemValue" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_ItemValue" runat="server" CommandName="Delete_ItemValue"
                                        OnClientClick="return confirm('您确认删除该检验标准吗?')" CommandArgument='<%#Eval("IQCST_ID")%>'>删除</asp:LinkButton>
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
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    </table>
                    <table style="width:100%">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="Btn_ClsStandard" runat="server" CssClass="Button02" 
                                        Height="24px" OnClick="Btn_ClsStandard_Click" Text="关闭" Width="70px" />
                                </td>
                            </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_EditStandard" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_EditStandard" runat="server" Visible="false">
                <fieldset>
                    <legend>检验标准维护</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="检验标准："></asp:Label>
                                <br>(200字以内)
                            </td>
                            <td style="width: 80%" align="left">
                                <asp:TextBox ID="Txt_EditStandard" runat="server" Width="500px" 
                                    MaxLength="200"  onfocus="annotation('Label9');" onblur="javascript:leave('Label9');"
                                        onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)" TextMode="MultiLine"></asp:TextBox>
                                    <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="备注："></asp:Label>
                                <br>(100字以内)
                            </td>
                            <td style="width: 80%" align="left">
                                <asp:TextBox ID="Txt_EditNote" runat="server" Width="500px" MaxLength="100"   
                                    onfocus="annotation('Label14');" onblur="javascript:leave('Label14');"
                                        onkeyup="this.value = this.value.substring(0, 100)" 
                                    onafterpaste="this.value = this.value.substring(0, 100)" TextMode="MultiLine"></asp:TextBox>
                            </td>         
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        </tr>
                            <tr>
                                <td align="right" style="width: 40%;">
                                    <asp:Button ID="Btn_EditSubmitStandard" runat="server" CssClass="Button02" 
                                        Height="24px" OnClick="Btn_EditSubmitStandard_Click" Text="提交" 
                                        ValidationGroup="Standard" Width="70px" />
                                </td>
                                <td style="width: 20%;">
                                </td>
                                <td align="left" style="width: 40%;">
                                    <asp:Button ID="Btn_EditClsStandard" runat="server" CssClass="Button02" 
                                        Height="24px" OnClick="Btn_EditClsStandard_Click" Text="关闭" Width="70px" />
                                </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 </asp:Content>