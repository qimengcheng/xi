using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_SalaryYearCompare : System.Web.UI.Page
{
    SalaryYearCompareD sd = new SalaryYearCompareD();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "年度薪资对比表";
        BindDropDownList1();
        this.Panel_OASearch.Visible = true;
        Getcondition();
       
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.label_Year.Text != "")
        {
            condition += this.label_condition.Text.ToString() ;
        }
        if (this.TextBox4.Text != "")
        {
            condition += "and SDBT_Post='" + this.TextBox4.Text + "'";
        }

        return condition;
    }
    protected void BindDropDownList1()
    {
        if (this.DropDownList_Year.SelectedValue=="")
        {
            DropDownList_Year.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        }
        for (int m = 2012; m <= 2062; m++)
        {
            DropDownList_Year.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    protected void DropDownList_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (this.DropDownList_Year.SelectedValue != "请选择年份")
        {
            this.label_Year.Text += this.DropDownList_Year.SelectedValue + ";";
            this.label_Year.Visible = true;
            this.label_condition.Text += "or SDBT_Year='" + this.DropDownList_Year.SelectedValue.ToString() + "'";
                
        }
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        this.Panel_OAInfo.Visible = true;
        this.label_Year.Text = "";
        
    }
    private void BindGridview_OAInfo(string condition)
    {
        this.Gridview_OAInfo.DataSource = sd.SelectSalaryYearCompare(condition);
        this.Gridview_OAInfo.DataBind();
    }

    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.DropDownList_Year.SelectedValue = "选择年份";
        this.label_Year.Text = "";
        this.label_condition.Text = "";
        this.TextBox4.Text = "";
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/SalaryYearComparePrint.aspx?" + "&Getcondition()=" + Getcondition() + "&Year=" + this.label_Year.Text);
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

}