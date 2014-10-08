using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PurchasingMgt_ReturnPayDetail : System.Web.UI.Page
{
    ReturnPayDetailD rd = new ReturnPayDetailD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "回款详细";
        this.Panel_OASearch.Visible = true;
        Getcondition();
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        this.label_Title.Text = "回款详细";
        BindGridview_OAInfo(condition);
        this.Panel_OAInfo.Visible = true;
    }
    private void BindGridview_OAInfo(string condition)
    {
        this.Gridview_OAInfo.DataSource = rd.SelectReturnPayDetail(condition);
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
            condition += "and CRMCIF_Name like'%" + this.TextBox4.Text + "%'";
        }
        if (this.TextBox3.Text != "")
        {
            condition += "and CRMCSBD_Name like'%" + this.TextBox3.Text + "%'";
        }
        if (this.TextBox2.Text != "" && this.TextBox5.Text != "")
        { 
        condition+="and SMCP_PaymentTime>='"+this.TextBox2.Text+"'"+"and SMCP_PaymentTime<='"+this.TextBox5.Text+"'";
        }
        else
        if (this.TextBox2.Text == "" && this.TextBox5.Text != "")
        {
            condition += "and SMCP_PaymentTime<='" + this.TextBox5.Text + "'";
        }
        else
        if (this.TextBox2.Text != "" && this.TextBox5.Text == "")
         {
          condition += "and SMCP_PaymentTime>='" + this.TextBox2.Text + "'";
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
        this.TextBox5.Text = "";
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {

        Response.Redirect("../REPORT_cc/ReturnPayDetailPrint.aspx?" + "&Getcondition()=" + Getcondition() + "&Time1=" + this.TextBox2.Text + "&Time2=" + this.TextBox5.Text);
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string condition = Getcondition();
        DataSet ds = rd.SelectReturnPayDetail_Total(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            this.label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计金额";
            e.Row.Cells[4].Text = this.label_Num.Text.ToString();
        }
    }
}