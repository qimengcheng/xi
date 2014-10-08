using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_SalesMonthPlanFinisihPrint : Page
{
    SalesMonthPlanFinisihD sd = new SalesMonthPlanFinisihD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        string year = Request.QueryString["year"];
        string month = Request.QueryString["month"];
        Gridview_OAInfo.DataSource = sd.SelectSalesMonthPlanFinisih(year,month);
        Gridview_OAInfo.DataBind();
    }
 
    //导出excel
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "每月销售计划完成情况统计表");
    }
    //返回
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SalesMonthPlanFinisih.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }
}