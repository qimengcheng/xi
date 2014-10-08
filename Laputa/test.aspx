<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Laputa_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" CellPadding="4"  EnableModelValidation="True" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
       
        <Columns>
            <asp:BoundField DataField="PCI_ID" HeaderText="PCI_ID" SortExpression="PCI_ID" />
            <asp:BoundField DataField="PT_Name" HeaderText="PT_Name" SortExpression="PT_Name" />
            <asp:BoundField DataField="PCI_Class" HeaderText="PCI_Class" SortExpression="PCI_Class" />
            <asp:BoundField DataField="PCI_Type" HeaderText="PCI_Type" SortExpression="PCI_Type" />
            <asp:BoundField DataField="PCI_Need" HeaderText="PCI_Need" SortExpression="PCI_Need" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <%--<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />--%>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
       
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>" SelectCommand="Proc_S_ProClassifiedInfo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="%" Name="TYPE" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

