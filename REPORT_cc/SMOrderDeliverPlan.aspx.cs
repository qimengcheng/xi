using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SMOrderDeliverPlan : Page
{
    SMOrderDeliverPlanL dp = new SMOrderDeliverPlanL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title="发货计划统计表";
            BindDeliverPlan();
            try
            {
                if (!((Session["UserRole"].ToString().Contains("发货计划统计"))))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }

        }
     

    }
    #region 发货计划
    //发货计划检索
    protected void SearchDeliverPlan(object sender, EventArgs e)
    {
        if (TextBox9.Text.ToString() == "")
        {
            Label5.Text = "";
        }
        else
        {
            string temp = " and a.SMDP_Time between '" + TextBox9.Text.ToString() + "' and '"+ TextBox15.Text.ToString()+"'";
            Label5.Text = temp;
        }
        BindDeliverPlan();
    }
    //绑定发货表
    protected void BindDeliverPlan()
    {
        GridView_OrderDeliverPlan.DataSource = dp.Select_DeliverPlan(Label5.Text.ToString().Trim());
        GridView_OrderDeliverPlan.DataBind();
        UpdatePanel_OrderDeliverPlan.Update();
    }
    
    #endregion
  
    #region gridview
    //发货计划表
    protected void GridView_OrderDeliverPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_OrderDeliverPlan.BottomPagerRow;


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

        BindDeliverPlan();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_OrderDeliverPlan.PageCount ? GridView_OrderDeliverPlan.PageCount - 1 : newPageIndex;
        GridView_OrderDeliverPlan.PageIndex = newPageIndex;
        GridView_OrderDeliverPlan.DataBind();
    }

    protected void PrintDeliverPlan(object sender, EventArgs e)
    {
        string price;
        if(CheckBox1.Checked)
        {
            price="printY";
        }
        else
        {
            price="printN";
        }
        Response.Redirect("../REPORT_cc/SMOrderDeliverPlanPrint.aspx?" + "&startime=" + TextBox9.Text + "&endtime=" + TextBox15.Text+"&print="+price);
    }
    
}
    #endregion