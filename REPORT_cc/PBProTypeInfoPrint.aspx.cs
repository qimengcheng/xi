using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_PBProTypeInfoPrint : System.Web.UI.Page
{
    PBProTypeInfoD pbInfo = new PBProTypeInfoD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string ProSeries = Request.QueryString["ProSeries"] == "" ? " and 1=1 " : " and PS_Name like '%" + Request.QueryString["ProSeries"] + "%' ";
        string PTName = Request.QueryString["PTName"] == "" ? " and 1=1 " : " and PT_Name like '%" + Request.QueryString["PTName"] + "%' ";
        string PTCode = Request.QueryString["PTCode"] == "" ? " and 1=1 " : " and PT_Code like '%" + Request.QueryString["PTCode"] + "%' ";
        string condition;
        condition = ProSeries + PTName + PTCode;

        Grid_ProType.DataSource = pbInfo.SearchPBTypeInfo(condition);
        Grid_ProType.DataBind();
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Grid_ProType.AllowPaging = false;
        Grid_ProType.AllowSorting = false;
        Grid_ProType.DataBind();
        ExcelHelper.GridViewToExcel(Grid_ProType, "产品型号说明表");
        Grid_ProType.AllowSorting = true;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PBProTypeInfo.aspx");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}