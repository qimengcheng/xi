using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SalaryDetailEachMonth : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("每月薪资汇总表"))))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    //绑定
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_SalaryDetailEachMonth(condition);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        //时间必填
        if (textyear.Text.ToString() == "" || textmon.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写年份和月份！')", true);
            return;
        }
        //gridview标题
        Label11.Text = textyear.Text;
        Label12.Text = textmon.Text;
        if (textdep.Text == "")
        {
            Label13.Text = "所有部门";
        }
        else
        {
            Label13.Text = textdep.Text;
        }
        if (textpost.Text == "")
        {
            Label14.Text = "所有岗位";
        }
        else
        {
            Label14.Text = textpost.Text;
        }
        //检索
        string condition = GetCondition();
        BindGrid_Detail(condition);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (this.textno.Text.ToString() != "")
        {
            temp += " and SDBT_NO like '%" + this.textno.Text.ToString() + "%'";
        }
        if (this.textname.Text.ToString() != "")
        {
            temp += " and SDBT_Name like '%" + this.textname.Text.ToString() + "%'";
        }
        if (this.textdep.Text.ToString() != "")
        {
            temp += " and SDBT_Dep like '%" + this.textdep.Text.Trim() + "%'";
        }
        if (this.textpost.Text.ToString() != "")
        {
            temp += " and SDBT_Post like '%" + this.textpost.Text.Trim() + "%'";
        }
        if (this.textyear.Text.ToString() != "")
        {
            temp += " and SDBT_Year = '" + this.textyear.Text.Trim() + "'";
        }
        if (this.textmon.Text.ToString() != "")
        {
            temp += " and SDBT_Month = '" + this.textmon.Text.Trim() + "'";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        textno.Text = "";
        textname.Text = "";
        textdep.Text = "";
        textpost.Text = "";
        textyear.Text = "";
        textmon.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (textyear.Text.ToString() == "" || textmon.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写年份和月份！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/SalaryDetailEachMonthPrint.aspx?" + "&SDBT_NO=" + this.textno.Text.ToString() + "&SDBT_Name=" + this.textname.Text.ToString() + "&SDBT_Dep=" + textdep.Text + "&SDBT_Post=" + textpost.Text + "&SDBT_Year=" + textyear.Text + "&SDBT_Month=" + textmon.Text);
    }
    //Grid_Detail翻页
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Detail.BottomPagerRow;


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
        string condition = GetCondition();
        BindGrid_Detail(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }


}