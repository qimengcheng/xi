using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class PurchasingMgt_OrderDeliver : System.Web.UI.Page
{
    OrderDeliverD od = new OrderDeliverD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "销售发货单";
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
        this.Gridview_OAInfo.DataSource = od.SelectOrderDeliver(condition);
        this.Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition = "";
        if(this.TextBox1.Text!="")
        {
            condition += "and PT_Name='"+this.TextBox1.Text+"'";
        }
        if(this.TextBox2.Text!="")
        {
        condition+="and SMSO_CusOrderNum='"+this.TextBox2.Text+"'";
        }
        if(this.TextBox3.Text!="")
        {
        condition+="and CRMCIF_Name like'%"+this.TextBox3.Text+"%'";
        }
        if(this.TextBox4.Text!="")
        {
        condition+="and SMSO_ComOrderNum='"+this.TextBox4.Text+"'";
        }
        if (this.TextBox_SPTime2.Text != "")
        {
            condition += "and SMOD_Time='" + this.TextBox_SPTime2.Text + "'" ;
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
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../PurchasingMgt/OrderDeliverPrint.aspx?" + "&Getcondition()=" + Getcondition());
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string condition = Getcondition();
        DataSet ds = od.SelectOrderDeliver_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            this.label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计金额";
           
           e.Row.Cells[14].Text = this.label_Num.Text.ToString();
          
        }
    }
}