using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalaryMgt_SalaryReview : System.Web.UI.Page
{
    SalaryReviewL salaryReviewL = new SalaryReviewL();
    private static string Condition1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您长时间未操作，请重新登录！')", true);
            Response.Redirect("~/Default.aspx");
        }
        #region//权限控制
        if (!((Session["UserRole"].ToString().Contains("薪资个人查看"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "Review")
        {
            this.Title = "薪资个人查看";
        }
        #endregion
        if (!IsPostBack)
        {
            BindGridview1("");
        }
    }

    #region//绑定Gridview
    private void BindGridview1(string Condition)
    {
        GridView1.DataSource = salaryReviewL.Search_SearchEachPersonInYearMonth(Condition);
        GridView1.DataBind();
    }//绑定Gridview1的方法，允许多次调用
    
    #endregion

    #region//检索栏
    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Condition1 = TxtSearchStaffNO.Text.Trim() == "" ? " " : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        Condition1 += TxtSearchName.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        Condition1 += TxtSearchYear.Text.Trim() == "" ? " " : " and SMC_Year  ='" + TxtSearchYear.Text.Trim() + "'";
        Condition1 += TxtSearchMonth.Text.Trim() == "" ? " " : " and SMC_Month = '" + TxtSearchMonth.Text.Trim() + "'";
        LblRecordIsSearch.Text = "检索后";
        BindGridview1(Condition1);
        UpdatePanel2.Update();
    }//检索
    protected void BtnResetEmployee_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        TxtSearchYear.Text = "";
        TxtSearchMonth.Text = "";
        LblRecordIsSearch.Text = "检索前";
        BindGridview1("");
        UpdatePanel2.Update();
    }//重置
    #endregion

    #region//GridView1的内置事件
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView1.BottomPagerRow;


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
        //Grid_Post.DataBind();
        if (LblRecordIsSearch.Text == "检索前")
            BindGridview1("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridview1(Condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView1.PageCount ? this.GridView1.PageCount - 1 : newPageIndex;
        this.GridView1.PageIndex = newPageIndex;
        this.GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (e.CommandName == "SearchDetail")
        {
            GridView1.SelectedIndex = row.RowIndex;
            Panel3.Visible = true;
            Label10.Text = StrArgument[2] + StrArgument[3] + StrArgument[4] + "年" + StrArgument[5] + "月 的工资明细";
            Label47.Text = " and HRDD_ID= '" + StrArgument[1] + "' and SMC_Year='" + StrArgument[4] + "' and SMC_Month='" + StrArgument[5] + "'";
            TextBox1.Text = StrArgument[8];
            TextBox2.Text = StrArgument[9];
            TextBox3.Text = StrArgument[10];
            TextBox4.Text = StrArgument[11];
            TextBox5.Text = StrArgument[12];
            TextBox6.Text = StrArgument[13];
            TextBox7.Text = StrArgument[14];
            TextBox8.Text = StrArgument[15];
            TextBox9.Text = StrArgument[16];
            TextBox10.Text = StrArgument[17];
            TextBox11.Text = StrArgument[18];
            TextBox12.Text = StrArgument[19];
            TextBox13.Text = StrArgument[20];
            TextBox14.Text = StrArgument[21];
            TextBox15.Text = StrArgument[22];
            TextBox16.Text = StrArgument[23];
            TextBox17.Text = StrArgument[24];
            TextBox18.Text = StrArgument[25];
            TextBox19.Text = StrArgument[26];
            TextBox20.Text = StrArgument[27];
            TextBox21.Text = StrArgument[28];
            TextBox22.Text = StrArgument[29];
            TextBox23.Text = StrArgument[30];
            TextBox24.Text = StrArgument[31];
            TextBox25.Text = StrArgument[32];
            TextBox26.Text = StrArgument[33];
            TextBox27.Text = StrArgument[34];
            TextBox28.Text = StrArgument[35];
            TextBox29.Text = StrArgument[36];
            TextBox30.Text = StrArgument[37];
            TextBox31.Text = StrArgument[38];
            TextBox32.Text = StrArgument[39];
            TextBox33.Text = StrArgument[40];
            TextBox34.Text = StrArgument[41];
            TextBox35.Text = StrArgument[42];
            TextBox36.Text = StrArgument[43];
            UpdatePanel3.Update();
        }
    }
    #endregion


    protected void BtnClose_Click(object sender, EventArgs e)
    {
        if (Panel3.Visible)
        {
            Panel3.Visible = false;
            UpdatePanel3.Update();
        }
    }
}