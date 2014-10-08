using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_NewCustomerSales : System.Web.UI.Page
{
    NewCustomerSalesD nd = new NewCustomerSalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "新客户销售额";
        this.Panel_OASearch.Visible = true;
        Getcondition();
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
       
        string year = this.DropDownList2.SelectedValue.ToString();
        string condition = Getcondition() + "and V_CustomerFirstDeliver.SMOD_Time like '"+year+"%"+"'";
        this.label_Title.Text = year + "年新客户";
        BindGridview_OAInfo(condition,year);
        this.Panel_OAInfo.Visible = true;
    }
    private void BindGridview_OAInfo(string condition,string year)
    {
        this.Gridview_OAInfo.DataSource = nd.SelectNewCustomerSales(condition,year);
        this.Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.TextBox1.Text != "")
        {
            condition += "and PT_Name like'%" + this.TextBox1.Text + "'";
        }
        if (this.TextBox2.Text != "")
        {
            condition += "and CRMCIF_SalesMan like'%" + this.TextBox2.Text + "'";
        }
        if (this.TextBox3.Text != "")
        {
            condition = "and CRMCIF_Name like'%" + this.TextBox3.Text + "%'";
        }
       
        return condition;
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
       

        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        this.TextBox3.Text = "";
        this.DropDownList2.SelectedValue = "2014";
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        string year = this.DropDownList2.SelectedValue.ToString();
        Response.Redirect("../REPORT_cc/NewCustomerSalesPrint.aspx?" + "&Getcondition()=" + Getcondition() + "&year=" + year);
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}