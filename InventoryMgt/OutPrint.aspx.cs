using System;
using System.Web.UI;

public partial class InventoryMgt_InPrint : Page
{
    IMOutStoreD outs = new IMOutStoreD();
    protected void Page_Load(object sender, EventArgs e)
    {

        Label9.Text = Request.QueryString["IMOHM_ID"];
        Label1.Text = Request.QueryString["IMSSBD_Name"];
        Label2.Text = Request.QueryString["IMS_StoreName"];
        Label3.Text = Request.QueryString["IMOHM_OutHouseCompany"];
        Label4.Text = Request.QueryString["IMOHM_MakeMan"];
        Label5.Text = Request.QueryString["IMOHM_OuthouseTime"];
        Label6.Text = Request.QueryString["IMOHM_TakeAwayMan"];
        Label7.Text = Request.QueryString["IMOHM_TakeAwayMakeSureTime"];
        Label8.Text = Session["UserName"].ToString().Trim();
        Label_WO_Type.Text = Request.QueryString["IMOHM_OutHouseNum"];
        string id = Label9.Text.ToString();
        string temp = "";
        temp += " and a.IMOHM_ID like'%" + id + "%'";
        Gridview_OutD.DataSource = outs.Select_IMOuthouseDetail(temp);
        Gridview_OutD.DataBind();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/InventoryMgt/IMOutStore.aspx?status=OutLook");
    }
    
}