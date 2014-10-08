<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OutPrint.aspx.cs" Inherits="InventoryMgt_InPrint" %>

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
    <div style="text-align: center;">
           <asp:Image ID="Image2" runat="server" ImageUrl="~/images/share.jpg" Height="28px" Width="49px"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Font-Size="28px" Visible="true" Text="希尔电子有限公司出库单"></asp:Label>
            </div>
    <div style="text-align: left;">
        <fieldset>
        <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
            <legend><asp:Label ID="Label_WO_Type" runat="server" Font-Size="20px" Visible="true"></asp:Label> <asp:Label ID="Label19" runat="server" Font-Size="20px" Visible="true" Text="的出库单信息"></asp:Label>
            </legend>
            <table cellpadding="0" cellspacing="0" style="width: 100%;" class="table">
                <tr>
                    <td class="auto-style5">
                      <asp:Label ID="Label11" runat="server" Font-Size="18px" Text="出库类别:"></asp:Label>  <asp:Label ID="Label1" runat="server" Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                     <asp:Label ID="Label12" runat="server" Font-Size="18px" Text="出库库房:"></asp:Label>   <asp:Label ID="Label2" runat="server" Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                      <asp:Label ID="Label13" runat="server" Font-Size="18px" Text="出库对象:"></asp:Label>  <asp:Label ID="Label3" runat="server"  Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                    <td>
                     <asp:Label ID="Label14" runat="server" Font-Size="18px" Text="制定人:"></asp:Label>   <asp:Label ID="Label4" runat="server" Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                     <asp:Label ID="Label15" runat="server" Font-Size="18px" Text="制定时间:"></asp:Label>   <asp:Label ID="Label5" runat="server" Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                     <asp:Label ID="Label16" runat="server" Font-Size="18px" Text="领取人:"></asp:Label>   <asp:Label ID="Label6" runat="server" Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                     <asp:Label ID="Label17" runat="server" Font-Size="18px" Text="领取时间:"></asp:Label>   <asp:Label ID="Label7" runat="server" Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label18" runat="server" Font-Size="18px" Text="打印人:"></asp:Label>    <asp:Label ID="Label8" runat="server" Font-Size="18px" Text="Label"></asp:Label>
                    </td>
                </tr>

            </table>
        </fieldset>
    </div>
 
    <div style="text-align: left; width: 1024px">
        <fieldset>
            <legend>出库单详细信息 </legend>
                    <asp:GridView ID="Gridview_OutD" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" 
                       Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMOHD_ID" 
                        Width="100%" Font-Size="Large"   >
                           <HeaderStyle ForeColor="Black" Font-Bold="false" Font-Size="Large"/>  
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
<%--                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            
                            <asp:BoundField DataField="IMOHD_ID" HeaderText="出库单详细表ID" ReadOnly="True" SortExpression="IMOHD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRD_ID" HeaderText="领料单详细ID" ReadOnly="True"
                                SortExpression="IMRD_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_ID" HeaderText="库存详细物料ID" ReadOnly="True"
                                SortExpression="IMID_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMOHM_ID" HeaderText="出库主表ID" ReadOnly="True"
                                SortExpression="IMOHM_ID" Visible="False">
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
                             <asp:BoundField DataField="IMOHD_Num" HeaderText="数量" SortExpression="IMOHD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="unit" HeaderText="单位" SortExpression="unit">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="IMID_QA" HeaderText="检验结果" SortExpression="IMID_QA"  >
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMID_DownLevelPara" HeaderText="降档参数" SortExpression="IMID_DownLevelPara">
                                <ItemStyle />
                            </asp:BoundField> 
                              
                        </Columns>
                      
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
