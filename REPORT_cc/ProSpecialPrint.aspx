<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProSpecialPrint.aspx.cs" Inherits="REPORT_cc_ProSpecialPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Stylesheet" href="../css/style.css" />
      <script type="text/javascript" src="../JS/jquery-1.10.2.min.js"></script>
    <style type="text/css">
       .style1
        {
            width: 97px;
        }
        .style8
        {
            height: 40px;
            width: 118px;
        }
        .style9
        {
            width: 105px;
        }
    </style>
     <script type="text/javascript">
         $(document).ready(
          function () {
              $("th").css("border-left", "1px solid black");
              $(".cg tr td:first-child").css("border-left", "none");
              $(".cg th:first-child").css("border-left", "none");
          });
     </script>
             <style type="text/css">
      
         .table_border
         {
             border-collapse: collapse;
             border-bottom: 1px #DDD solid;
             border-left: 1px #DDD solid;
             border-color: black;
             width: 100%;
         }
         .table_border td
         {
             border-collapse: collapse;
             border-top: 1px #DDD solid;
             border-right: 1px #DDD solid;
             border-color: black;
         }
      
         .style12
         {
             width: 101px;
         }
         .cg {
             border: none;
         }
         .cg td
         {
             border-left: 1px solid black;
             border-collapse: collapse;
             border-right : 0px solid red;
             border-spacing: 0;
         }

        
       
   
        
         .style13
         {
             width: 114px;
         }
         .auto-style2 {
             height: 55px;
         }
         .auto-style3 {
             height: 17px;
         }
         .auto-style4 {
             height: 40px;
         }
                 .auto-style5 {
                     width: 821px;
                 }
         </style>
             </head>
             <script type="text/javascript" language="Javascript">
                 function preview() {
                     bdhtml = window.document.body.innerHTML;
                     sprnstr = "<!--startprint-->";
                     eprnstr = "<!--endprint-->";
                     prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
                     prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
                     window.document.body.innerHTML = prnhtml;
                     window.print();
                 }
             </script>
<body style="text-align: center; width: 1024px; margin: 0 auto; background-color: #FFFFFF;
    background-image: none">
    <form id="form1" runat="server" width="1024px">
    <!--startprint-->
    <p style="font-size: 18px;">
        特殊产品评审表
    </p>
    <div style="text-align: left;">
       
        <fieldset>
            <legend>特殊产品信息
            </legend>
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top" class="auto-style3" >
                        特殊产品编号
                    </td>
                    <td align="center" valign="top" class="auto-style3" >
                        产品型号
                    </td>
                    <td align="center" valign="top" class="auto-style3">
                        客户要求
                    </td>
                    <td align="center" valign="top" class="auto-style3">
                        申请人
                    </td>
                    <td align="center" valign="top" class="auto-style3">
                        申请时间</td>
                    <td align="center" valign="top" class="auto-style3">
                        申请状态</td>
                </tr>
                <tr>
                    <td align="center" valign="top" class="auto-style4" >
                        <asp:Label ID="LabelPT_SpecialCode" runat="server"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4" >
                        <asp:Label ID="LabelPT_Name" runat="server"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4">
                        <asp:Label ID="LabelPT_SpecialNeed" runat="server"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4">
                        <asp:Label ID="LabelPT_SpecialTypeMan" runat="server"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4">
                        <asp:Label ID="LabelPT_SpecialTypeTime" runat="server"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4">
                        <asp:Label ID="LabelPT_CSate" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>
        </fieldset>
    </div>
    <div style="text-align: left">
        <fieldset>
            <legend>物料清单(BOM)</legend>
                    <asp:GridView ID="GridView_bom" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowSorting="True" Width="100%"
                        DataKeyNames="BD_ID" EmptyDataText="无相关记录!" GridLines="None" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="BD_ID" SortExpression="BD_ID" HeaderText="BOM详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" SortExpression="IMMBD_MaterialID" HeaderText="物料ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName"
                                HeaderText="物料名称"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel"
                                HeaderText="规格型号"></asp:BoundField>
                            <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="用量单位">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_MUse" SortExpression="BD_MUse" HeaderText="标准用量"></asp:BoundField>
                            <asp:BoundField DataField="BD_MRUse" SortExpression="BD_MRUse" HeaderText="实际用量">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_Note" SortExpression="BD_Note" HeaderText="备注"></asp:BoundField>
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
        </fieldset>
    </div>
    <div style="text-align: left">
        <fieldset>
            <legend>工艺路线(流程)</legend>
                <asp:GridView ID="GridView_Pr" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" 
                        AllowSorting="True" Width="100%" DataKeyNames="PRD_ID" EmptyDataText="无相关记录!"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PRD_ID" SortExpression="PRD_ID" HeaderText="工艺路线详细id"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Order" SortExpression="PRD_Order" HeaderText="排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_RenZhengOrder" SortExpression="PRD_RenZhengOrder"
                                HeaderText="认证工序排序"></asp:BoundField>
                            <asp:BoundField DataField="PRD_RouteOrder" SortExpression="PRD_RouteOrder" HeaderText="认证路线排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Doc" SortExpression="PRD_Doc" HeaderText="相关文件"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Way" SortExpression="PRD_Way" HeaderText="管控方式"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Note" SortExpression="PRD_Note" HeaderText="备注"></asp:BoundField>
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
        </fieldset>
    </div>
    <div style="text-align: left; width: 1024px; font-size: small;">
        <fieldset>
            <legend>特殊产品会签表</legend>
                    <asp:GridView ID="Gridview4" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None"
                        PageSize="10" AllowSorting="True"
                         DataKeyNames="PTC_ID" 
                        Width="100%">
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
    </div>
    <div style="text-align: left; width: 100%; font-size: small;">
        <fieldset>
            <legend>备注</legend>
            <table style="width: 100%;border: 0">
                <tr>
                    <td align="left" class="auto-style5" rowspan="2">
                        <asp:TextBox ID="TextBoxLabelPT_Note" runat="server" Height="35px"  style="font-site：12px;"  TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </td>
                    <td align="left">
                        打印人：<asp:Label ID="LabelPrint" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        打印时间：<asp:Label ID="LabelTime" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
   
    <!--endprint-->
    <asp:Button ID="Button1" runat="server" OnClientClick="preview()" CssClass="Button02"
        Text="打印" Width="58px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBack" runat="server" CssClass="Button02"
        Text="返回" Width="55px" onclick="btnBack_Click" />
    </form>
</body>
</html>
