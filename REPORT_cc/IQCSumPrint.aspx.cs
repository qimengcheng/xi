using System;
using System.Web.UI;

public partial class REPORT_cc_IQCSumPrint : Page
{
    IQCSumD iqcSumD = new IQCSumD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        string InStoreTime = Request.QueryString["InStoreTime"] == "" ? " and 1=1 " : " and convert(varchar(10),IMISM_InStoreTime,23) = '" + Request.QueryString["InStoreTime"] + "'";
        string MaterialName = Request.QueryString["MaterialName"] == "" ? " and 1=1 " : " and Name like '%" + Request.QueryString["MaterialName"] + "%' ";
        string SpecificationModel = Request.QueryString["SpecificationModel"] == "" ? " and 1=1 " : " and Model like '%" + Request.QueryString["SpecificationModel"] + "%' ";
        string BatchNum = Request.QueryString["BatchNum"] == "" ? " and 1=1 " : " and IMISD_BatchNum like '%" + Request.QueryString["BatchNum"] + "%' ";
        string SupplyName = Request.QueryString["SupplyName"] == "" ? " and 1=1 " : " and PMSI_SupplyName like '%" + Request.QueryString["SupplyName"] + "%' ";
        string Result = Request.QueryString["Result"] == "" ? " and 1=1 " : " and IQCDT_Result like '%" + Request.QueryString["Result"] + "%' ";
        string condition;
        condition = InStoreTime + MaterialName + SpecificationModel + BatchNum + SupplyName + Result;
        GridView_IQCSumPrint.DataSource = iqcSumD.SearchIQCSum(condition);
        GridView_IQCSumPrint.DataBind();
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridView_IQCSumPrint.AllowPaging = false;
        GridView_IQCSumPrint.AllowSorting = false;
        GridView_IQCSumPrint.DataBind();
        ExcelHelper.GridViewToExcel(GridView_IQCSumPrint, "IQC检验汇总表");
        GridView_IQCSumPrint.AllowSorting = true;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/IQCSum.aspx");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}