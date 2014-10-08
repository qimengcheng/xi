using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_SalaryYearComparePrint : System.Web.UI.Page
{
    SalaryYearCompareD sd = new SalaryYearCompareD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = sd.SelectSalaryYearCompare(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SalaryYearCompare.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        string Year = Request.QueryString["Year"]+"年度薪资对比表";
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, Year);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
    }
}