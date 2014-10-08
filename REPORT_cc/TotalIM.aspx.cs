using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_TotalIM : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("库存统计报表"))))
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
    private void BindGrid_Detail(DateTime start, DateTime end,string condition)
    {
        Grid_Detail.DataSource = sd.S_TotalIM(start, end,condition);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (startime.Text.ToString() == "" || endtime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写统计时间！')", true);
            return;
        }
        DateTime start = Convert.ToDateTime(startime.Text.ToString());
        DateTime end = Convert.ToDateTime(endtime.Text.ToString());
        string condition = GetCondition();
        BindGrid_Detail(start, end,condition);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (TextBox1.Text.ToString() != "")
        {
            temp += " and mat.Name like '%" + TextBox1.Text.ToString() + "%'";
        }
        if (TextBox2.Text.ToString() != "")
        {
            temp += " and mat.Model like '%" + TextBox2.Text.Trim() + "%'";
        }
        if (TextBox3.Text.ToString() != "")
        {
            temp += " and mat.Unit like '%" + TextBox3.Text.Trim() + "%'";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        startime.Text = "";
        endtime.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (startime.Text.ToString() == "" || endtime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写统计时间！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/TotalIMPrint.aspx?" + "&start=" + startime.Text + "&end=" + endtime.Text + "&Name=" + TextBox1.Text + "&Model=" + TextBox2.Text + "&Unit=" + TextBox3.Text);
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
        DateTime start = Convert.ToDateTime(startime.Text.ToString());
        DateTime end = Convert.ToDateTime(endtime.Text.ToString());
        string condition = GetCondition();
        BindGrid_Detail(start, end, condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }


}