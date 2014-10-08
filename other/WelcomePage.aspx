<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="WelcomePage.aspx.cs" Inherits="Other_WelcomePage" Title="欢迎登录" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
    <table style="width: 100%;">
        <tr>
            <td align="center">
                <table style="width: 90%; height: 130px;">
            <tr>
                <td scope="col">
                
                    <fieldset style="height: 600px">
                    <legend>欢迎</legend>
                    <div><MARQUEE   direction="up" onmousemout="this.start()" onmouseover="this.start()" scrollamount=2 scrolldelay="10"  height="500"><span>
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="../images/welcome1.jpg" Width="100%"></asp:Image>
               <asp:Image ID="Image2" runat="server" ImageUrl="../images/welcome2.jpg" Width="100%" ></asp:Image>
                           
                    </span></MARQUEE></div>
                    </fieldset>
                </td>
            </tr>
            </table></td>
        </tr>
    </table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

    </ContentTemplate>
    </asp:UpdatePanel>
    
    
  
    
</asp:Content>

