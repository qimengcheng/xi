using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_HRMan : Page
{
    SalesMonthPlanFinisihD dp = new SalesMonthPlanFinisihD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title="人员配置统计表";

            try
            {
                if (!((Session["UserRole"].ToString().Contains("人员配置统计表"))))
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
        string condition = "";
        if (Label5.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择一种检索方式！')", true);
            return;
        }
        else
        {
            int sort = Convert.ToInt32(Label5.Text);
          GridView_OrderDeliverPlan.DataSource=  dp.Select_HRMan(condition, sort);
          GridView_OrderDeliverPlan.DataBind();
          UpdatePanel_OrderDeliverPlan.Update();
        }
         
    }
   
    
    #endregion
  
    #region gridview


    protected void PrintDeliverPlan(object sender, EventArgs e)
    {
       
        if (Label5.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择一种检索方式！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/HRManPrint.aspx?" + "&sort=" + Label5.Text+ "&condition=" );
    }

    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox3.Checked = false;
        CheckBox1.Checked = false;
        Label5.Text = "1";
        UpdatePanel1.Update();
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox1.Checked = false;
        CheckBox2.Checked = false;
        Label5.Text = "2";
        UpdatePanel1.Update();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox3.Checked = false;
        CheckBox2.Checked = false;
        Label5.Text = "3";
        UpdatePanel1.Update();
    }
}
    #endregion