using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PurchasingMgt_SalesDetailGather : System.Web.UI.Page
{
    SalesDetailGatherD sd = new SalesDetailGatherD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "销售明细汇总";
        this.Panel_OASearch.Visible = true;
        Getcondition();
    }
  //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        this.label_Title.Text = "销售明细汇总";
        BindGridview_OAInfo(condition);
        this.Panel_OAInfo.Visible = true;
    }
    private void BindGridview_OAInfo(string condition)
    {
        this.Gridview_OAInfo.DataSource = sd.SelectSalesDetailGather(condition);
        this.Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.TextBox1.Text != "")
        {
            condition += "and CRMRBI_Name like'%" + this.TextBox1.Text + "%'";
        }
        if (this.TextBox4.Text != "")
        {
            condition += "and CRMCIF_SalesMan like'%" + this.TextBox4.Text + "%'";
        }
        if (this.TextBox3.Text != "")
        {
            condition += "and CRMCIF_Name like'%" + this.TextBox3.Text + "%'";
        }
        if (this.TextBox2.Text != "")
        {
            condition += "and PT_Name like'%" + this.TextBox2.Text + "%'";
        }
        return condition;
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        this.TextBox3.Text = "";
        this.TextBox4.Text = "";
        this.TextBox2.Text = "";
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {

        Response.Redirect("../PurchasingMgt/SalesDetailGatherPrint.aspx?" + "&Getcondition()=" + Getcondition());
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string condition = Getcondition();
        DataSet ds = sd.SelectSalesDetailGather_Total(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计";
            e.Row.Cells[5].Text = dt.Rows[0][0].ToString();
            e.Row.Cells[6].Text = dt.Rows[0][1].ToString();
            e.Row.Cells[4].Text = "均价："+dt.Rows[0][2].ToString();
        } 
        }
    }
}