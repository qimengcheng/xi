<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="SalaryMgt_Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView2" runat="server">
                        
    </asp:GridView>

     <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" 
                                    Text="导入" Width="70px" 
        onclick="Button6_Click" />
      <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" 
                                    Text="导出" Width="70px" onclick="Button1_Click" 
         />
    <asp:FileUpload ID="FileUpload" runat="server" />
</asp:Content>

