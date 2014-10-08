using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class PurchasingMgt_OrderDeliverPrint : System.Web.UI.Page
{
    OrderDeliverD od = new OrderDeliverD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = od.SelectOrderDeliver(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PurchasingMgt/OrderDeliver.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "销售发货单");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        string condition = Request.QueryString["Getcondition()"];
        DataSet ds = od.SelectOrderDeliver_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            this.label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计金额";

            e.Row.Cells[15].Text = this.label_Num.Text.ToString();

        }
    }
}