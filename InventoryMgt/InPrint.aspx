<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InPrint.aspx.cs" Inherits="InventoryMgt_InPrint" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Stylesheet" href="../css/style.css" />
    <style type="text/css">
        table
        {
            border: 1px solid #BABABA;
            border-collapse: collapse;
        }
        td
        {
            border: 1px dotted #BABABA;
            height: 30px;
        }
        /*tr{border:1px solid rgb(221, 221, 221)}*/
        .auto-style4
        {
            width: 271px;
        }
        
        .auto-style5
        {
            width: 234px;
        }
    </style>
</head>
<script language="Javascript">
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
    <%--<p style="font-size: 30px;">
        希尔电子有限公司-入库单</p>--%>
        <div style="text-align: center;">
           <asp:Image ID="Image2" runat="server" ImageUrl="~/images/share.jpg" Height="28px" Width="49px"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Font-Size="28px" Visible="true" Text="希尔电子有限公司入库单"></asp:Label>
            </div>
        
    <div style="text-align: left;">
        <fieldset>
        <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
            <legend><asp:Label ID="Label_WO_Type" runat="server" Font-Size="20px" Visible="true"></asp:Label>
                <asp:Label ID="Label19" runat="server" Font-Size="20px" Visible="true" Text="的入库单信息"></asp:Label>
            </legend>
            <table cellpadding="0" cellspacing="0" style="width: 100%;" class="table">
                <tr>
                    <td class="auto-style5">
                       <asp:Label ID="Label11"  Font-Size="18px" runat="server" Text="入库类别:"></asp:Label> <asp:Label ID="Label1"  Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                         <asp:Label ID="Label12"  Font-Size="18px" runat="server" Text="入库库房:"></asp:Label><asp:Label ID="Label2" Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label13"  Font-Size="18px" runat="server" Text="入库单位:"></asp:Label> <asp:Label ID="Label3" Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                         <asp:Label ID="Label14"  Font-Size="18px" runat="server" Text="责任人:"></asp:Label><asp:Label ID="Label4" Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label15"  Font-Size="18px" runat="server" Text="入库时间:"></asp:Label> <asp:Label ID="Label5" Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="Label16"  Font-Size="18px" runat="server" Text="录入人:"> </asp:Label><asp:Label ID="Label6" Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                         <asp:Label ID="Label17"  Font-Size="18px" runat="server" Text="打印人:"></asp:Label><asp:Label ID="Label7" Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                       <asp:Label ID="Label18"  Font-Size="18px" runat="server" Text="打印时间:"> </asp:Label> <asp:Label ID="Label8" Font-Size="18px" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

            </table>
        </fieldset>
    </div>
 
    <div style="text-align: left; width: 1024px">
        <fieldset>
            <legend> <asp:Label ID="Label20"  Font-Size="18px" runat="server" Text="入库单详细信息"> </asp:Label> </legend>
                    <asp:GridView ID="Gridviewl_InstoreDetail" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                   DataKeyNames="IMISM_ID"
                        GridLines="None" Width="100%" Font-Size="Large">
                         <HeaderStyle ForeColor="Black" Font-Bold="false" Font-Size="Large"/>  
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="IMISD_ID" HeaderText="详细表ID" ReadOnly="True" SortExpression="IMISD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品ID" ReadOnly="True" SortExpression="PT_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_ID" HeaderText="主表ID" ReadOnly="True" SortExpression="IMISM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="True" SortExpression="Name">
                                <ItemStyle />

                            </asp:BoundField>
                            <asp:BoundField DataField="Model" HeaderText="规格型号" ReadOnly="True" SortExpression="Model" HtmlEncode="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISD_BatchNum" HeaderText="批号" ReadOnly="True" SortExpression="IMISD_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_Level" HeaderText="档次" ReadOnly="True" SortExpression="IMIDS_Level">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="Unit" HeaderText="单位" SortExpression="Unit">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISD_ShouldArrNum" HeaderText="应到数量" SortExpression="IMISD_ShouldArrNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_ActualArrNum" HeaderText="实到数量" SortExpression="IMIDS_ActualArrNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_PerWeight" HeaderText="单位重量" ReadOnly="True" SortExpression="IMIDS_PerWeight">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_TotalWeight" HeaderText="总重量" ReadOnly="True" SortExpression="IMIDS_TotalWeight">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMSA_AreaName" HeaderText="预入库区域" ReadOnly="True"
                                SortExpression="IMSA_AreaName">
                                <ItemStyle />
                            </asp:BoundField>
                          
                          
                        </Columns>
                        
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
          
        </fieldset>
    </div>
  
    <!--endprint-->
    <asp:Button runat="server" OnClientClick="preview()" CssClass="Button02" Text="打印"
        Width="58px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" CssClass="Button02" OnClick="Button1_Click"
        Text="返回" Width="55px" />
    </form>
</body>
</html>
