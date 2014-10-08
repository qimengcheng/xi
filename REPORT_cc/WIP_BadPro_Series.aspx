<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WIP_BadPro_Series.aspx.cs" Inherits="REPORT_cc_WIP_BadPro_Series"  MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    </script>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="155px"></asp:DropDownList>
                            </td>
                            <td align="center" style="width:10%;">
                                <asp:Label ID="Label2" runat="server" Text="统计时间："></asp:Label>
                            </td>
                            <td style="width:20%;">
                                <asp:TextBox ID="startime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                            <td align="center" style="width:10%;">
                                    <asp:Label ID="Label111" runat="server" Text="至"></asp:Label>
                            </td>
                            <td style="width:20%;">
                                <asp:TextBox ID="endtime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr style="height: 16px;">
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="系列："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="155px"></asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                </td>
                                </td>
                                <td>
                                </td>
                                <td align="center">
                                </td>
                                <td >
                                </td>
                        </tr>
                        <tr>
                             <td >
                             </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" Text="导出Excel" Width="80px" OnClick="Button2_Click" ToolTip="点击此处,跳转打印页面。"/>
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="80px" OnClick="BtnReset_Click"/></td>
                        <td align="left" >
                        </td>
                    </tr>
                    </table>
                        
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="Button2" />
    </Triggers>
    </asp:UpdatePanel>


</asp:Content>

