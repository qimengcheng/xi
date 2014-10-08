using System;
using System.Web.UI;

public partial class InventoryMgt_InPrint : Page
{
    IMInStoreMainD ins = new IMInStoreMainD();
    protected void Page_Load(object sender, EventArgs e)
    {

        Label9.Text = Request.QueryString["IMISM_ID"];
        Label1.Text = Request.QueryString["IMSSBD_Name"];
        Label2.Text = Request.QueryString["IMS_StoreName"];
        Label3.Text = Request.QueryString["IMISM_InStoreCompany"];
        Label4.Text = Request.QueryString["IMISM_ResponMan"];
        Label5.Text = Request.QueryString["IMISM_InStoreTime"];
        Label6.Text = Request.QueryString["IMISM_MakeMan"];
        Label7.Text = Session["UserName"].ToString().Trim();
        Label_WO_Type.Text = Request.QueryString["IMISM_InStoreNum"];
        Label8.Text = DateTime.Now.ToLongDateString();
        string temp = " and IMISM_ID ='" + Label9.Text.ToString() + "'";
        Gridviewl_InstoreDetail.DataSource = ins.Select_InStoreDelete(temp);
        Gridviewl_InstoreDetail.DataBind();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/InventoryMgt/IMInStore.aspx");
    }
    
}