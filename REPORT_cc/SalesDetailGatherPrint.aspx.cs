using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class PurchasingMgt_SalesDetailGatherPrint : System.Web.UI.Page
{
    SalesDetailGatherD sd = new SalesDetailGatherD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = sd.SelectSalesDetailGather(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PurchasingMgt/SalesDetailGather.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "销售明细汇总表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        string condition = Request.QueryString["Getcondition()"];
        DataSet ds = sd.SelectSalesDetailGather_Total(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "合计";
                e.Row.Cells[6].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[7].Text = dt.Rows[0][1].ToString();
                e.Row.Cells[5].Text = "均价：" + dt.Rows[0][2].ToString();
            }
        }
    }
}