using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_SalaryEachMonthAnalysis : System.Web.UI.Page
{
    SalaryEachMonthAnalysisD sd = new SalaryEachMonthAnalysisD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "月度薪资分析表";
        BindDropDownList1();
        this.Panel_OASearch.Visible = true;
        Getcondition();
    }
    protected void BindDropDownList1()
    {
        if (this.DropDownList_Year.SelectedValue=="")
        {
            DropDownList_Year.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        }
        if (this.DropDownList_Month.SelectedValue=="")
        {
            DropDownList_Month.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        }
       
        for (int y = 1; y <= 12; y++)
        {
            DropDownList_Month.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }
        for (int m = 2012; m <= 2062; m++)
        {
            DropDownList_Year.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
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
        this.Gridview_OAInfo.DataSource = sd.SelectSalaryEachMonthAnalysis(condition);
        this.Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.DropDownList_Year.SelectedValue != "选择年份")
        {
            condition += "and SDBT_Year='" + this.DropDownList_Year.SelectedValue.ToString() + "'";
        }
        if (this.DropDownList_Month.SelectedValue != "选择月份")
        {
            condition += "and SDBT_Month='" + this.DropDownList_Month.SelectedValue.ToString() + "'";
        }
        if (this.TextBox3.Text != "")
        {
            condition += "and SDBT_Dep like'%" + this.TextBox3.Text + "%'";
        }
        if (this.TextBox4.Text != "")
        {
            condition += "and SDBT_Post='" + this.TextBox4.Text + "'";
        }
       
        return condition;
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.DropDownList_Year.SelectedValue = "选择年份";
        this.DropDownList_Month.SelectedValue = "选择月份";
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
        Response.Redirect("../REPORT_cc/SalaryEachMonthAnalysisPrint.aspx?" + "&Getcondition()=" + Getcondition());
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
}