using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_EquipUpkeepPlan : Page
{
    SpareD sd = new SpareD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("设备保养完成情况统计表"))))
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
    //绑定
    private void BindGrid_Detail(string condition1,string condition2)
    {
        Grid_Detail.DataSource = sd.S_EquipUpkeepPlan_Statistical(condition1,condition2);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (startime.Text.ToString() == ""|| endtime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请填入统计起止时间！')", true);
            return;
        }
        string condition1 = GetCondition1();
        string condition2 = GetCondition2();
        BindGrid_Detail(condition1, condition2);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition1()
    {
        string condition1;
        string temp = "";
        //统计时间
        if (startime.Text.ToString() != "" && endtime.Text.ToString() != "")
        {
            temp += " and EUP_PDate >= '" + startime.Text.Trim() + "' and EUP_PDate <= '" + endtime.Text.Trim() + "' and (EUP_UEndT>='" + endtime.Text.Trim() + "' or EUP_UEndT is null)";
        }
        //if (this.startime.Text.ToString() != "" && this.endtime.Text.ToString() == "")
        //{
        //    temp += " and EUP_PDate >= '" + startime.Text.Trim() + "' and EUP_PDate <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (EUP_UEndT>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' or EUP_UEndT is null)";
        //}
        //if (this.startime.Text.ToString() == "" && this.endtime.Text.ToString() != "")
        //{
        //    temp += " and EUP_PDate <= '" + endtime.Text.Trim() + "' and (EUP_UEndT>='" + endtime.Text.Trim() + "' or EUP_UEndT is null)";
        //}
        //if (this.startime.Text.ToString() == "" && this.endtime.Text.ToString() == "")
        //{
        //    temp += " and EUP_PDate <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (EUP_UEndT>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' or EUP_UEndT is null)";
        //}
        condition1 = temp;
        return condition1;
    }
    protected string GetCondition2()
    {
        string condition2;
        string temp = "";
        if (equipno.Text.ToString() != "")
        {
            temp += " and a.EI_No like '%" + equipno.Text.ToString() + "%'";
        }
        if (equipmodel.Text.ToString() != "")
        {
            temp += " and a.EMT_Type like '%" + equipmodel.Text.Trim() + "%'";
        }
        if (equipname.Text.ToString() != "")
        {
            temp += " and a.EN_EquipName like '%" + equipname.Text.Trim() + "%'";
        }
        if (equipper.Text.ToString() != "")
        {
            temp += " and a.EUP_UpkeepPer like '%" + equipper.Text.Trim() + "%'";
        }
        condition2 = temp;
        return condition2;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        equipno.Text = "";
        equipmodel.Text = "";
        equipname.Text = "";
        equipper.Text = "";
        startime.Text = "";
        endtime.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (startime.Text.ToString() == "" || endtime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请填入统计起止时间！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/EquipUpkeepPlanPrint.aspx?" + "&EI_No=" + equipno.Text.ToString() + "&EMT_Type=" + equipmodel.Text + "&EN_EquipName=" + equipname.Text + "&EUP_UpkeepPer=" + equipper.Text + "&startime=" + startime.Text + "&endtime=" + endtime.Text );
    }
    //Grid_Detail翻页
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Detail.BottomPagerRow;


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
        string condition1 = GetCondition1();
        string condition2 = GetCondition2();
        BindGrid_Detail(condition1, condition2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }


}