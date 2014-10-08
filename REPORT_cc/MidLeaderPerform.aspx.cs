using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_MidLeaderPerform : System.Web.UI.Page
{
    BillApplyD bd = new BillApplyD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "中干绩效考核表";
        BindDropDownList1();
        this.Panel_OASearch.Visible = true;

        if (this.DropDownList_Year.SelectedValue != "选择年份")
        {
            this.label_year.Text = this.DropDownList_Year.SelectedValue.ToString();
        }
       
    }
    protected void BindDropDownList1()
    {
        if (this.DropDownList_Year.SelectedValue == "")
        {
            DropDownList_Year.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        }
        

       
        for (int m = 2012; m <= 2062; m++)
        {
            DropDownList_Year.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        int year = 0;
       
        if (this.DropDownList_Year.SelectedValue != "选择年份")
        {
            year = Convert.ToInt32(this.DropDownList_Year.SelectedValue.ToString());
        }
       
        if (this.DropDownList_Year.SelectedValue == "选择年份" )
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('请选择年份！')", true);
            return;
        }
        BindGridview_OAInfo(year);
        this.Panel_OAInfo.Visible = true;
    }
    private void BindGridview_OAInfo(int year)
    {
        this.Gridview_OAInfo.DataSource = bd.SelectMidLeaderPerform(year);
        this.Gridview_OAInfo.DataBind();
    }

    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.DropDownList_Year.SelectedValue = "选择年份";
        

        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/MidLeaderPerformPrint.aspx?" + "&year=" + this.label_year.Text);
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Gridview_OAInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview_OAInfo.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        int year = Convert.ToInt32(this.label_year.Text);
      
        BindGridview_OAInfo(year);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview_OAInfo.PageCount ? this.Gridview_OAInfo.PageCount - 1 : newPageIndex;
        this.Gridview_OAInfo.PageIndex = newPageIndex;
        this.Gridview_OAInfo.DataBind();
    }
}