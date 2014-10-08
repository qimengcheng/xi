using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_ProductSum : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("产品流量统计"))))
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
    private void BindGrid_Detail(DateTime start,DateTime end)
    {
        Grid_Detail.DataSource = sd.S_ProductSum(start,end);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if(startime.Text.ToString()==""||endtime.Text.ToString()=="")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写统计时间！')", true);
            return;
        }
        DateTime start = Convert.ToDateTime(startime.Text.ToString());
        DateTime end=Convert.ToDateTime(endtime.Text.ToString());
        BindGrid_Detail(start, end);
        UpdatePanel_Grid.Update();
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        startime.Text = "";
        endtime.Text = "";
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
        Response.Redirect("../REPORT_cc/ProductSumPrint.aspx?" + "&start=" + startime.Text + "&end=" + endtime.Text);
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
        BindGrid_Detail(start, end);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }


}