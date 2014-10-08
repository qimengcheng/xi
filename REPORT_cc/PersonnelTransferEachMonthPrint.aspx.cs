using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_PersonnelTransferEachMonthPrint : System.Web.UI.Page
{
    BillApplyD bd = new BillApplyD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        int year =Convert.ToInt32( Request.QueryString["year"]);
        int month = Convert.ToInt32(Request.QueryString["month"]);
        this.Gridview_OAInfo.DataSource = bd.SelectPersonnelTransferEachMonthC(year,month);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PersonnelTransferEachMonth.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(Request.QueryString["year"]);
        int month = Convert.ToInt32(Request.QueryString["month"]);
        string title=year+"年"+month+"月"+"人事流动月报表";
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, title);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
    }
}