using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_CRMCompanySampleCountPrint : Page
{
    CRMCompanySampleCountD cd = new CRMCompanySampleCountD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["Time1"] == null || Request.QueryString["Time1"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["Time1"];
        }
        if (Request.QueryString["Time2"] == null || Request.QueryString["Time2"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["Time2"];
        }
        string condition = Request.QueryString["Getcondition()"];
        Gridview_OAInfo.DataSource =cd.SelectCRMCompanySampleCount(condition);
        Gridview_OAInfo.DataBind();
    }
    //导出excel
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "每月样品统计表");
    }
    //返回
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/CRMCompanySampleCount.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
    //打印
    protected void Button_Click(object sender, EventArgs e)
    {

    }

    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
    string condition = Request.QueryString["Getcondition()"];
        DataSet ds = cd.SelectCRMCompanySampleCount_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计数量";
            e.Row.Cells[4].Text = label_Num.Text.ToString();
        }
    }
}