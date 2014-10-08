using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_WorkOrderPrint : Page
{
    private WorkOrderPrintD wo = new WorkOrderPrintD();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["WO_Num"] == null)
        {
            wonum.Text = "S2EA1001";
            wonum2.Text = "*S2EA1001*";
        }
        else
        {
            wonum2.Text = "*"+Request.QueryString["WO_Num"]+"*";
            wonum.Text = Request.QueryString["WO_Num"];
        }
        if (Request.QueryString["WO_Type"] == null)
        {
            Label_WO_Type.Text = "正常";
        }
        else
        {
            Label_WO_Type.Text = Request.QueryString["WO_Type"];
        }
        GridView1.DataSource = wo.Query_BatchNum(wonum.Text);
        GridView1.DataBind();
        Title = "随工单打印";
        int rz;
        if (Label_WO_Type.Text.Trim() == "检验")
        {
            rz = 1;
            //    this.GridView2.Columns[1].Visible = true;
            //  this.GridView2.Columns[2].Visible = true;
            Label20.Text = "以下为检验随工单的工艺路线，与常规产品路线不同，蓝色表示需要认证的工序，认证合格后才能进行非蓝色工序";

        }
        else
        {
            rz = 0;

        }
        GridView2.DataSource = wo.Query_PBCraftInfo(wonum.Text, rz);
        GridView2.DataBind();


        DataTable dtTable = new DataTable();

        DataColumn dc = new DataColumn();

        dc = dtTable.Columns.Add("ID", Type.GetType("System.Int32"));
        DataRow drRow = dtTable.NewRow();
        drRow["ID"] = 0;
        dtTable.Rows.Add(drRow);
        GridView3.DataSource = dtTable;
        GridView3.DataBind();
        DataSet ds = wo.Query_PrintInfo(wonum.Text);

        try
        {
            Label1.Text = ds.Tables[0].Rows[0]["WO_Num"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["WO_ChipNum"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["WO_Level"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["WO_SN"].ToString();
            Label5.Text = ds.Tables[0].Rows[0]["WO_OrderNum"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["WO_Type"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["PT_Parameters"].ToString();
        }
        catch 
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('没有相关随工单！')", true);
        }
        try
        {
            Label7.Text = Session["UserName"].ToString();
        }
        catch
        {
            Response.Redirect("~/Default.aspx");
        }
        Label8.Text = DateTime.Now.ToString("u");
        Label9.Text = ds.Tables[0].Rows[0]["WO_ProType"].ToString();
        Label10.Text = ds.Tables[0].Rows[0]["WO_EpoxyResin"].ToString();
        Label11.Text = ds.Tables[0].Rows[0]["WO_Mould"].ToString();
        Label12.Text = ds.Tables[0].Rows[0]["WO_Num"].ToString();
        TextBox1.Text = ds.Tables[0].Rows[0]["WO_Num"].ToString();
        TextBox1.ReadOnly = true;



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductionProcess/WorkOrderCreate.aspx");
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Label_WO_Type.Text.Trim() == "检验")
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                if (drv["PRD_RenZhengOrder"].ToString().Trim() != "")
                {
                    e.Row.BackColor = Color.SkyBlue;

                }
            }

        }
    }
}