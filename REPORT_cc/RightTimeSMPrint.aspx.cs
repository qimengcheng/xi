using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_RightTimeSMPrint : System.Web.UI.Page
{
    RightTimeSMD rd = new RightTimeSMD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string condition = Request.QueryString["Getcondition()"];
        string name = Request.QueryString["name"];
        int num =Convert.ToInt32( Request.QueryString["num"]);
        this.Gridview_OAInfo.DataSource = rd.SelectRightTimeSM(condition);
        this.Gridview_OAInfo.DataBind();
        if (name != "" && name != "&nbsp;")
        {
            this.Gridview1.DataSource = rd.SelectRightTimeMaterial(name, num);
            this.Gridview1.DataBind();
            this.Button3.Visible = true;
        }
        else
        {
            this.Button3.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/RightTimeSM.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        //if(this.Gridview1.Rows.Count>0)
        //{
            string name = Request.QueryString["name"]+" 的物料详细表";
            ExcelHelper.GridViewToExcel(Gridview1, name);
        //}
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Button_Excel2(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "订单库存在制品一览表");
    }
}