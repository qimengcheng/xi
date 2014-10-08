using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WorkOrderSalary_WOSSalary : Page
{
    WOSSalaryL ws = new WOSSalaryL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["state"] == null)
            {
                label_pagestate.Text = "look";
            }
            else
            {
                label_pagestate.Text = Request.QueryString["state"];
            }
            string state = label_pagestate.Text;
            if (state.Trim() == "look")
            {
                Title = "工价系列查看";
                GridView_WOmain.Columns[2].Visible = false;
                GridView_WOmain.Columns[3].Visible = false;
                Button_AddSeries.Visible = false;
                Button_ChosePT.Visible = false;
                GridView_LPT.Columns[0].Visible = false;
                CheckBoxAll.Visible = false;
                CheckBoxfanxuan.Visible = false;
                Btn_deleting.Visible = false;

            }
            if (state.Trim() == "manage")
            {
                Title = "工价系列维护";
            }
            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("工价系列维护")) || (Session["UserRole"].ToString().Contains("工价系列查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("工价系列维护"))
                    {
                        GridView_WOmain.Columns[2].Visible = false;
                        GridView_WOmain.Columns[3].Visible = false;
                        Button_AddSeries.Visible = false;
                        Button_ChosePT.Visible = false;
                        GridView_LPT.Columns[0].Visible = false;
                        CheckBoxAll.Visible = false;
                        CheckBoxfanxuan.Visible = false;
                        Btn_deleting.Visible = false;

                    }
                    label_GridPageState.Text = "默认数据源";
                    string condition = " and 1=1";
                    GridView_WOmain.DataSource = ws.S_LaborCostSeries(condition);
                    GridView_WOmain.DataBind();
                    UpdatePanel_WOmain.Update();
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }
    }

    public void databind()
    {
        string condition;
        string LCS_Name = TextBox_Seriesname.Text.Trim() == "" ? " and 1=1 " : " and LCS_Name like '%" + TextBox_Seriesname.Text.Trim() + "%' ";
        condition = LCS_Name;
        GridView_WOmain.DataSource = ws.S_LaborCostSeries(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }

    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {

        for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
            if (CheckBoxAll.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxfanxuan.Checked = false;

    }
    protected void Checkfanxuan_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxAll.Checked = false;
    }
    protected void Btn_Search_Click(object sender, EventArgs e)//检索
    {
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

        databind();
        label_GridPageState.Text = "检索数据源";
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)//取消检索
    {
        label_GridPageState.Text = "默认数据源";

        TextBox_Seriesname.Text = "";
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        string condition = " and 1=1";
        GridView_WOmain.DataSource = ws.S_LaborCostSeries(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();
    }
    protected void Button_AddSeries_Click(object sender, EventArgs e)//新增工价系列
    {
        Panel_add.Visible = true;
        TextBox_Seriesname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)//工价系列表翻页
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_WOmain.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_WOmain.PageCount ? GridView_WOmain.PageCount - 1 : newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;


        if (label_GridPageState.Text == "默认数据源")
        {
            string condition = " and 1=1";
            GridView_WOmain.DataSource = ws.S_LaborCostSeries(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            databind();
        }
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)//工价系列行命令
    {
        if (e.CommandName == "Delete123")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);

                ws.D_LaborCostSeries(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            //panel 各种隐藏
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_pt.Visible = false;
            UpdatePanel_pt.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            GridView_WOmain.SelectedIndex = -1;

            databind();

            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_pt.Visible = false;
            UpdatePanel_pt.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
        }


        if (e.CommandName == "ptmgt")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_S.Text = al[1];
            label_SID.Text = al[0];

            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;
            //panel 各种隐藏
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_pt.Visible = true;
            GridView_LPT.DataSource = ws.S_LaborCostSeries_ProType(new Guid(label_SID.Text.Trim()));
            GridView_LPT.DataBind();


            UpdatePanel_pt.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();





        }

    }
    protected void GridView_WOmain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        label_Sname.Text = GridView_WOmain.Rows[e.NewEditIndex].Cells[1].Text.Trim();
        GridView_WOmain.EditIndex = e.NewEditIndex;
        GridView_WOmain.SelectedIndex = e.NewEditIndex;
        databind();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void GridView_WOmain_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name = ((TextBox)(GridView_WOmain.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();


        if (name != label_Sname.Text.Trim())
        {
            DataSet ds = ws.S_LaborCostSeries_panchong(name);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该工价系列！，请您再核对！')", true);
                return;
            }
            else
            {
                try
                {
                    Guid guid = new Guid(GridView_WOmain.DataKeys[e.RowIndex].Value.ToString());
                    ws.U_LaborCostSeries(name, guid);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑失败！，请您再核对！')", true);
                    return;
                }
            }


        }

        GridView_WOmain.EditIndex = -1;
        GridView_WOmain.SelectedIndex = -1;
        databind();
    }
    protected void GridView_WOmain_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_WOmain.EditIndex = -1;
        GridView_WOmain.SelectedIndex = -1;
        databind();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

    }
    protected void SelectProType(object sender, EventArgs e)
    {
        databind2();
    }
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = ""; 
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    ws.D_LaborCostSeries_ProType(new Guid(GridView_LPT.DataKeys[i].Values["PT_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的产品型号！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        GridView_LPT.DataSource = ws.S_LaborCostSeries_ProType(new Guid(label_SID.Text.Trim()));
        GridView_LPT.DataBind();


        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    ws.I_LaborCostSeries_ProType(new Guid(GridView_ProType.DataKeys[i].Values["PT_ID"].ToString().Trim()), new Guid(label_SID.Text.Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的产品型号！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);


        }
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        GridView_LPT.DataSource = ws.S_LaborCostSeries_ProType(new Guid(label_SID.Text.Trim()));
        GridView_LPT.DataBind();

        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {

        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox2.Checked = false;
    }
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_ProType.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_ProType.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;


        databind2();
    }
    protected void GridView_LPT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_LPT.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_LPT.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_LPT.PageCount ? GridView_LPT.PageCount - 1 : newPageIndex;
        GridView_LPT.PageIndex = newPageIndex;
        GridView_LPT.PageIndex = newPageIndex;


        //panel 各种隐藏
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        GridView_LPT.DataSource = ws.S_LaborCostSeries_ProType(new Guid(label_SID.Text.Trim()));
        GridView_LPT.DataBind();


        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_CancelAdd_Click(object sender, EventArgs e)
    {
        label_GridPageState.Text = "默认数据源";

        TextBox_Seriesname.Text = "";
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        string condition = " and 1=1";
        GridView_WOmain.DataSource = ws.S_LaborCostSeries(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();
    }
    protected void Button_ADD_Click(object sender, EventArgs e)
    {
        if (TextBox_Seriesname_Add.Text.Trim() == "")
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('工价系列不能为空！，请您再核对！')", true);
            return;
        }
        DataSet ds = ws.S_LaborCostSeries_panchong(TextBox_Seriesname_Add.Text.Trim());
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该工价系列！，请您再核对！')", true);
            return;
        }
        else
        {
            try
            {
                ws.I_LaborCostSeries(TextBox_Seriesname_Add.Text.Trim());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                Panel_add.Visible = false;
                TextBox_Seriesname_Add.Text = "";
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！，请您再核对！')", true);
                return;
            }
        }
        databind();


    }

    public void databind2()
    {
        string condition;
        string ptsname = TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + TextBox_Series.Text.Trim() + "%' ";
        string ptname = TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_ProductName.Text.Trim() + "%' ";
        condition = ptsname + ptname;
        GridView_ProType.DataSource = ws.S_LaborCostSeries_ProType_Condition(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    
    }

    protected void Button_ChosePT_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = true;
        GridView_ProType.DataSource = ws.S_LaborCostSeries_ProType_Condition("");
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    protected void Btn_CloseS_Click(object sender, EventArgs e)
    {
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    
}