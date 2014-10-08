using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_EquipOutput : Page
{
    SpareD sd = new SpareD();
    EquipNameModelL equipNameModelL = new EquipNameModelL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("设备产量统计表"))))
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

    #region 绑定
    private void BindGrid_EquipName(string condition)
    {
        Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo(condition);
        Grid_EquipName.DataBind();
    }
    private void BindGridView1(string condition)
    {
        GridView1.DataSource = equipNameModelL.Search_EquipNameInfo(condition);
        GridView1.DataBind();
    }
    private void BindGrid_Detail(string condition1, string time)
    {
        Grid_Detail.DataSource = sd.S_EquipOutput_Statistical(condition1, time);
        Grid_Detail.DataBind();
    }
    #endregion 绑定

    #region 统计数据维护
    //打开统计数据维护
    protected void Senior_DetailOPEN_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = false;
        UpdatePanel_Grid.Update();
        Senior_DetailOPEN.Visible = false;
        Senior_DetailCLOSE.Visible = true;
        Panel1.Visible = true;
        UpdatePanel1.Update();
        BindGridView1(" and EN_Output is not null and EN_WorkTime is not null and EN_Output!=-1 and EN_WorkTime!=-1");
        UpdatePanel_Search.Update();
    }
    //关闭统计数据维护
    protected void Senior_DetailCLOSE_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
    }
    //选择统计设备按钮
    protected void New_name_Click(object sender, EventArgs e)
    {
        Panel_Name.Visible = true;
        BindGrid_EquipName(" and (EN_Output is null or EN_Output=-1) and (EN_WorkTime is null or EN_WorkTime=-1)");
        UpdatePanel_Name.Update();
    }
    //GridView1相关
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        if (e.CommandName == "Delete_Name")//取消统计
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            Grid_EquipName.EditIndex = -1;
            Guid EN_ID = new Guid(Convert.ToString(e.CommandArgument));
            sd.Update_EquipmentName_Output(EN_ID, -1, -1);
            BindGrid_EquipName(" and (EN_Output is null or EN_Output=-1) and (EN_WorkTime is null or EN_WorkTime=-1)");
            UpdatePanel_Name.Update();
            BindGridView1(" and EN_Output is not null and EN_WorkTime is not null and EN_Output!=-1 and EN_WorkTime!=-1");
            UpdatePanel_Search.Update();
        }
    }
    //GridView1显示编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView1(" and EN_Output is not null and EN_WorkTime is not null and EN_Output!=-1 and EN_WorkTime!=-1");
    }
    //GridView1编辑
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid EN_ID = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //待操作时间
        if (((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('小时理论产量不能为空！')", true);
            return;
        }
        float m1;
        if (!(float.TryParse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text, out m1)))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('小时理论产量必须为数字！')", true);
            return;
        }
        float EN_Output = m1;
        //控制限
        if (((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月工作全时间不能为空！')", true);
            return;
        }
        float m2;
        if (!(float.TryParse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text, out m2)))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月工作全时间必须为数字！')", true);
            return;
        }
        float EN_WorkTime = m2;

        GridView1.EditIndex = -1;
        sd.Update_EquipmentName_Output(EN_ID, EN_Output, EN_WorkTime);
        BindGridView1(" and EN_Output is not null and EN_WorkTime is not null and EN_Output!=-1 and EN_WorkTime!=-1");
        UpdatePanel1.Update();
    }
    //GridView1取消编辑
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView1(" and EN_Output is not null and EN_WorkTime is not null and EN_Output!=-1 and EN_WorkTime!=-1");
        UpdatePanel1.Update();
    }
    //GridView1翻页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;

            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox1");   // refer to the TextBox with the NewPageIndex value
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
        GridView1.EditIndex = -1;
        BindGridView1(" and EN_Output is not null and EN_WorkTime is not null and EN_Output!=-1 and EN_WorkTime!=-1");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    //关闭按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
    }
    //Grid_EquipName相关
    protected void Grid_EquipName_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
        if (e.CommandName == "Choose_Item")//选择
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipName.SelectedIndex = row.RowIndex;
            Guid EN_ID = new Guid(Convert.ToString(e.CommandArgument));
            sd.Update_EquipmentName_Output(EN_ID, 1, 572);
            BindGridView1(" and EN_Output is not null and EN_WorkTime is not null and EN_Output!=-1 and EN_WorkTime!=-1");
            UpdatePanel1.Update();
            BindGrid_EquipName(" and (EN_Output is null or EN_Output=-1) and (EN_WorkTime is null or EN_WorkTime=-1)");
            UpdatePanel_Name.Update();
        }
    }
    //Grid_EquipName翻页
    protected void Grid_EquipName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipName.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox2");   // refer to the TextBox with the NewPageIndex value
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
        Grid_EquipName.EditIndex = -1;
        BindGrid_EquipName(" and (EN_Output is null or EN_Output=-1) and (EN_WorkTime is null or EN_WorkTime=-1)");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipName.PageCount ? Grid_EquipName.PageCount - 1 : newPageIndex;
        Grid_EquipName.PageIndex = newPageIndex;
        Grid_EquipName.PageIndex = newPageIndex;
        Grid_EquipName.DataBind();
    }
    protected void Grid_EquipName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 统计数据维护

    #region 统计
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        if (startime.Text.ToString() == "" || endtime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请填入统计起止时间！')", true);
            return;
        }
        string condition1 = GetCondition1();
        string time = "BETWEEN '" + startime.Text.Trim() + "' AND '" + endtime.Text.Trim() + "'";
        BindGrid_Detail(condition1, time);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition1()
    {
        string condition1;
        string temp = "";
        if (textname.Text.ToString() != "")
        {
            temp += " and EN_EquipName like '%" + textname.Text.ToString() + "%'";
        }
        if (textno.Text.ToString() != "")
        {
            temp += " and EI_No like '%" + textno.Text.Trim() + "%'";
        }
        if (texttype.Text.ToString() != "")
        {
            temp += " and EMT_Type like '%" + texttype.Text.Trim() + "%'";
        }
        condition1 = temp;
        return condition1;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        textname.Text = "";
        textno.Text = "";
        texttype.Text = "";
        startime.Text = "";
        endtime.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        if (startime.Text.ToString() == "" || endtime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请填入统计起止时间！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/EquipOutputPrint.aspx?" + "&EI_No=" + textno.Text.ToString() + "&EN_EquipName=" + textname.Text + "&EMT_Type=" + texttype.Text + "&startime=" + startime.Text + "&endtime=" + endtime.Text);
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
        string time = "BETWEEN '" + startime.Text.Trim() + "' AND '" + endtime.Text.Trim() + "'";
        BindGrid_Detail(condition1, time);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }
    #endregion 统计

}