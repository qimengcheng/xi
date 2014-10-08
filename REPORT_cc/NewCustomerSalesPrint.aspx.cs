using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_NewCustomerSalesPrint : System.Web.UI.Page
{
    NewCustomerSalesD nd = new NewCustomerSalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string condition = Request.QueryString["Getcondition()"];
        string year=Request.QueryString["year"];
        this.Labelstart.Text = year + "年新客户";
        this.Gridview_OAInfo.DataSource = nd.SelectNewCustomerSales(condition,year);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/NewCustomerSales.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "新客户销售额汇总表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
    }
}