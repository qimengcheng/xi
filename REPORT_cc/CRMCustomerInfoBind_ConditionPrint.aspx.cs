using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_CRMCustomerInfoBind_ConditionPrint : System.Web.UI.Page
{
    CRMCustomerInfoBind_ConditionD cd = new CRMCustomerInfoBind_ConditionD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = cd.SelectCRMCustomerInfoBind_Condition(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PurchasingMgt/CRMCustomerInfoBind_Condition.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "客户档案汇总表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var gv = e.Row.Cells[6].FindControl("GridView3") as GridView;
            gv.DataSource = cd.SelectCRMCustomerContact(new Guid(e.Row.Cells[1].Text));
            gv.DataBind();
            }
           
        }
    
}