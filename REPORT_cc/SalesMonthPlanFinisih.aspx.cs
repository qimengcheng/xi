using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_SalesMonthPlanFinisih : Page
{
    SalesMonthPlanFinisihD sd=new SalesMonthPlanFinisihD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "每月销售计划完成情况统计";
            BindDropDownList1();
            Panel_OASearch.Visible = true;
            GetCondition();
        }
    }
    protected void BindDropDownList1()//检索
    {
        DropDownList_Month.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        DropDownList_Year.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        for (int y = 1; y <= 12; y++)
        {
            DropDownList_Month.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }
        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList_Year.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        if (DropDownList_Year.SelectedValue == "选择年份" || DropDownList_Month.SelectedValue == "选择月份")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('请年份和月份！')", true);
            return;
        }
        else
        {
            string year = DropDownList_Year.SelectedValue.ToString();
            string month = DropDownList_Month.SelectedValue.ToString();
            BindGridview_OAInfo(year,month);
            Panel_OAInfo.Visible = true;
        }
    }
    private string GetCondition()
    {
        string condition = "";
        if (DropDownList_Year.SelectedValue != "选择年份" && DropDownList_Month.SelectedValue != "选择月份")
        {
            condition += "and SMSMPM_Year='" + DropDownList_Year.SelectedValue + "'" + "and SMSMPM_Month='" +(Convert.ToInt32(DropDownList_Month.SelectedValue)-1) + "'" + "and IMISM_InStoreTime>='" + DropDownList_Year.SelectedValue + "-" + DropDownList_Month.SelectedValue + "-" + "26" + "'" + "and IMISM_InStoreTime<='" + DropDownList_Year.SelectedValue  + "-" + DropDownList_Month.SelectedValue + "-" + "25" + "'";
        }
       
        
        return condition;
    }
    private void BindGridview_OAInfo(string  year,string month)
    {
    Gridview_OAInfo.DataSource=sd.SelectSalesMonthPlanFinisih(year,month);
    Gridview_OAInfo.DataBind();
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        DropDownList_Month.SelectedValue = "选择月份";
        DropDownList_Year.SelectedValue = "选择年份";
        Panel_OAInfo.Visible = false;
    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_OAInfo.Visible = false;
    }
    //打印报表
    protected void Button2_Click1(object sender, EventArgs e)
    {
        string Time1 = DropDownList_Year.SelectedValue.ToString().Trim();
        string Time2 = DropDownList_Month.SelectedValue.ToString().Trim();

        Response.Redirect("../REPORT_cc/SalesMonthPlanFinisihPrint.aspx?" + "&year=" + Time1 + "&month=" + Time2 );
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}