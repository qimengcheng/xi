using System;
using System.Web.UI;

public partial class REPORT_cc_HRManPrint : Page
{
    SalesMonthPlanFinisihD dp = new SalesMonthPlanFinisihD();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //绑定
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = System.DateTime.Now.ToShortDateString();
        int sort =Convert.ToInt32( Request.QueryString["sort"]);
        string condition = Request.QueryString["condition"];
        GridView_OrderDeliverPlan.DataSource = dp.Select_HRMan("", sort);
        GridView_OrderDeliverPlan.DataBind();
    }

 
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/HRMan.aspx");
    }
    protected void ExcelOutput(object sender, EventArgs e)
    {
        GridView_OrderDeliverPlan.AllowPaging = false;
       GridView_OrderDeliverPlan.DataBind();
       ExcelHelper.GridViewToExcel(GridView_OrderDeliverPlan, "人员配置统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}