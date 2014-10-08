using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class PurchasingMgt_OrderReturn : System.Web.UI.Page
{
    OrderReturnD od = new OrderReturnD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "销售退货单";
        this.Panel_OASearch.Visible = true;
        Getcondition();
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        this.Panel_OAInfo.Visible = true;
    }
    private void BindGridview_OAInfo(string condition)
    {
        this.Gridview_OAInfo.DataSource = od.SelectOrderReturn(condition);
        this.Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.TextBox1.Text != "")
        {
            condition += "and PT_Name='" + this.TextBox1.Text + "'";
        }
        if (this.TextBox2.Text != "")
        {
            condition += "and SMRC_ReturnOrderNum='" + this.TextBox2.Text + "'";
        }
        if (this.TextBox3.Text != "")
        {
            condition += "and CRMCIF_Name like'%" + this.TextBox3.Text + "%'";
        }
        if (this.TextBox4.Text != "")
        {
            condition += "and SMSO_ComOrderNum='" + this.TextBox4.Text + "'";
        }
        if (this.TextBox_SPTime2.Text != "")
        {
            condition += "and SMRC_MakeTime='" + this.TextBox_SPTime2.Text + "'";
        }
        if (this.TextBox5.Text != "")
        {
            condition = "and SMRC_MakeMan='" + this.TextBox5.Text + "'";
        }
        return condition;
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.TextBox_SPTime2.Text = "";

        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        this.TextBox3.Text = "";
        this.TextBox4.Text = "";
        this.TextBox5.Text = "";
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../PurchasingMgt/OrderReturnPrint.aspx?" + "&Getcondition()=" + Getcondition());
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string condition = Getcondition();
        DataSet ds = od.SelectOrderReturn_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            this.label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计金额";

            e.Row.Cells[16].Text = this.label_Num.Text.ToString();

        }
    }
}