using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainningMgt_TrainingYearPlan : Page
{
    TrainningYearPlanMgtL typmL = new TrainningYearPlanMgtL();
    private static string Condition1;
    TrainingTypeMaintenanceL trainingTypeMaintenanceL = new TrainingTypeMaintenanceL();//用于绑定培训类型
    NETtainningL nETtainningL = new NETtainningL();//用于绑定负责的部门

    protected void Page_Load(object sender, EventArgs e)
    {
        #region//权限控制
        if (!((Session["UserRole"].ToString().Contains("培训年度计划维护") || (Session["UserRole"].ToString().Contains("培训年度计划查看")))))
        {
            Response.Redirect("~/Default.aspx");

        }

        if (Request.QueryString["status"].ToString() == "TraTYear")
        {
            Grid_YrarPlan.Columns[5].Visible = false;
            Title = "培训年度计划维护";
        }
        if (Request.QueryString["status"].ToString() == "TraTYearLook")
        {
            Grid_YrarPlan.Columns[6].Visible = false;
            Grid_YrarPlan.Columns[7].Visible = false;
            Grid_YrarPlan.Columns[8].Visible = false;
            BtnNew.Visible = false;
            Title = "培训年度计划查看";
        }
        #endregion



        if (!IsPostBack)
        {
            BindYear(DdlSYears);
            BindYear(DdlAYears);
            BindDdlMonth();
            BindGrid_YrarPlan("");
        }
    }


    #region//绑定Gridview
    private void BindGrid_YrarPlan(string Condition)
    {
        Grid_YrarPlan.DataSource = typmL.Search_TrainingYPlanMain(Condition);
        Grid_YrarPlan.DataBind();
    }//Grid_YrarPlan
    private void BindGridView_Item(string Condition)
    {
        GridView_Item.DataSource = typmL.Search_OtherTables_TrainingItemDetail(" and a.TYPM_ID='" + Label15.Text + "'" + Condition);
        GridView_Item.DataBind();
    }//GridView_Item
    #endregion

    private void BindYear(DropDownList ddl)//绑定年
    {
        for (int m = 2012; m <= 2035; m++)
        {
            ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        ddl.Items.Insert(0, new ListItem("请选择", ""));
        ddl.DataBind();
    }


    #region//培训年度计划检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Grid_YrarPlan.SelectedIndex = -1;
        Condition1 = DdlSYears.Text == "" ? " " : " and TYPM_Year ='" + DdlSYears.Text + "'";
        Condition1 += DdlState.Text == "请选择" ? " " : " and TYPM_State ='" + DdlState.Text + "'";
        Condition1 += TxtSPerson.Text.Trim() == "" ? " " : " and TYPM_Maker like '%" + TxtSPerson.Text.Trim() + "%'";
        Condition1 += TxtStartTime.Text.Trim() == "" ? " " : " and TYPM_Time >= '" + TxtStartTime.Text.Trim() + "'";
        Condition1 += TxtEndTime.Text.Trim() == "" ? " " : " and TYPM_Time <= '" + TxtEndTime.Text.Trim() + "'";
        BindGrid_YrarPlan(Condition1);
        LblRecordIsSearch.Text = "检索后";
        UpdatePanel2.Update();
    }//检索
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Grid_YrarPlan.SelectedIndex = -1;
        DdlSYears.ClearSelection();
        DdlState.ClearSelection();
        TxtSPerson.Text = "";
        TxtStartTime.Text = "";
        TxtEndTime.Text = "";
        LblRecordIsSearch.Text = "检索前";
        BindGrid_YrarPlan("");
        UpdatePanel2.Update();
    }//重置
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        LblAddOrEdit.Text = "新增";
        Panel3.Visible = true;
        UpdatePanel3.Update();
        DdlAYears.SelectedValue = (DateTime.Now.Year + 1).ToString();
        TxtPerson.Text = Session["Username"].ToString().Trim();
        TxtTime.Text = DateTime.Now.ToString();



    }//新增年度计划
    #endregion


    #region//Grid_YrarPlan的内置事件
    protected void Grid_YrarPlan_DataBound(object sender, EventArgs e)
    {

    }
    protected void Grid_YrarPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_YrarPlan.BottomPagerRow;


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
            BindGrid_YrarPlan("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGrid_YrarPlan(Condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_YrarPlan.PageCount ? Grid_YrarPlan.PageCount - 1 : newPageIndex;
        Grid_YrarPlan.PageIndex = newPageIndex;
        Grid_YrarPlan.DataBind();
    }
    protected void Grid_YrarPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "LookDetail")
        {
            Panel4.Visible = true;
            Label15.Text = e.CommandArgument.ToString();//记录编辑的主键，必须卸载绑定Gridview之前
            UpdatePanel4.Update();
            Grid_YrarPlan.SelectedIndex = row.RowIndex;
            BindGridView_Item("");//绑定Gridview
            GridView_Item.Columns[8].Visible = false;
            GridView_Item.Columns[9].Visible = false;
            Label14.Text = row.Cells[1].Text;
            Label17.Text = "查看";
            BtnSubmit.Visible = false;
        }
        if (e.CommandName == "EditDetail")
        {
            if (row.Cells[2].Text == "待提交")
            {
                Panel4.Visible = true;
                Label15.Text = e.CommandArgument.ToString();//记录编辑的主键，必须卸载绑定Gridview之前
                if (!BtnSubmit.Visible)
                    BtnSubmit.Visible = true;
                if (!GridView_Item.Columns[8].Visible)
                    GridView_Item.Columns[8].Visible = true;
                if (!GridView_Item.Columns[9].Visible)
                    GridView_Item.Columns[9].Visible = true;
                Grid_YrarPlan.SelectedIndex = row.RowIndex;
                Label14.Text = row.Cells[1].Text;
                Label17.Text = "编辑";
                BindGridView_Item("");//绑定Gridview
                UpdatePanel4.Update();
                //控制 面板弹出和关闭的逻辑


                if (Panel5.Visible)
                {
                    Panel5.Visible = false;
                    UpdatePanel5.Update();

                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交或已完成的年度计划不能进行编辑！')", true);


        }
        if (e.CommandName == "SubmitYearPlan")
        {
            if (row.Cells[2].Text == "待提交")
            {
                int i = 0;
                Grid_YrarPlan.SelectedIndex = -1;
                TrainningInfo neiaInfoForSubmit = new TrainningInfo();
                neiaInfoForSubmit.TYPM_ID = new Guid(e.CommandArgument.ToString());
                neiaInfoForSubmit.TYPM_State = "已提交";
                i = typmL.Update_ForSubmit_TrainingYPlanMain(neiaInfoForSubmit);
                if (LblRecordIsSearch.Text == "检索前")
                    BindGrid_YrarPlan("");
                if (LblRecordIsSearch.Text == "检索后")
                    BindGrid_YrarPlan(Condition1);
                UpdatePanel2.Update();
                if (i > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交！')", true);
                    //控制面板的消失逻辑
                    if (Panel3.Visible | Panel4.Visible | Panel5.Visible)
                    {

                        Panel4.Visible = false;
                        UpdatePanel4.Update();

                        Panel5.Visible = false;
                        UpdatePanel5.Update();
                    }
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败，必须具有培训项目！')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能对待提交状态的信息进行提交！')", true);
        }
        if (e.CommandName == "DeleteYearPlan")
        {
            if (row.Cells[2].Text == "待提交")
            {
                Grid_YrarPlan.SelectedIndex = -1;
                typmL.Delete_TrainingYPlanMain_TrainingItemDetail(new Guid(e.CommandArgument.ToString()));
                if (LblRecordIsSearch.Text == "检索前")
                    BindGrid_YrarPlan("");
                if (LblRecordIsSearch.Text == "检索后")
                    BindGrid_YrarPlan(Condition1);
                UpdatePanel2.Update();
                if (Panel3.Visible | Panel4.Visible | Panel5.Visible)
                {

                    Panel4.Visible = false;
                    UpdatePanel4.Update();

                    Panel5.Visible = false;
                    UpdatePanel5.Update();
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能删除待提交状态的信息！')", true);

        }
    }
    #endregion


    #region//培训年度计划XX
    protected void BtnSubmit1_Click(object sender, EventArgs e)
    {
        if (DdlAYears.Text == "" || TxtPerson.Text == "" || TxtTime.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        TrainningInfo tInfo = new TrainningInfo();
        int i = 0;
        tInfo.TYPM_Year = int.Parse(DdlAYears.SelectedValue); ;
        tInfo.TYPM_State = "待提交";
        tInfo.TYPM_Maker = TxtPerson.Text;
        try
        {
            i = typmL.Insert_TrainingYPlanMain(tInfo);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！'" + ex + ")", true);
        }
        if (i <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该年份的计划已存在，请核实！')", true);
            return;
        }
        Panel3.Visible = false;
        UpdatePanel3.Update();
        BindGrid_YrarPlan("");
        UpdatePanel2.Update();
        if (i > 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
        }
    }//提交
    protected void BtnCacel1_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }//取消
    #endregion


    #region//XX年度计划中的项目列表XX
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        Panel5.Visible = true;
        BindDdlType();
        BindDdlDep();
        //BindDdlMonth();
        UpdatePanel5.Update();
        Label12.Text = "新增";
        DdlMonth.ClearSelection();
        TxtTrainingItem.Text = "";
        TxtTarget.Text = "";
        DdlType.ClearSelection();
        DdlDep.ClearSelection();

    }//新增培训项目
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
        if (Panel5.Visible)
        {
            Panel5.Visible = false;
            UpdatePanel5.Update();
        }
    }//取消
    #endregion


    #region//动态绑定Dropdownlist
    //NETtainningL nETtainningL = new NETtainningL();//用于绑定负责的部门
    private void BindDdlDep()
    {
        DdlDep.DataSource = nETtainningL.Search_NETrainingItem_BDOrganizationSheet().Tables[0].DefaultView;
        DdlDep.DataTextField = "BDOS_Name";
        DdlDep.DataValueField = "BDOS_Code";
        DdlDep.DataBind();
        DdlDep.Items.Insert(0, new ListItem("请选择", ""));
    }
    //TrainingTypeMaintenanceL trainingTypeMaintenanceL = new TrainingTypeMaintenanceL();//用于绑定培训类型
    private void BindDdlType()
    {
        DdlType.DataSource = trainingTypeMaintenanceL.Search_TrainingTypeTable("");
        DdlType.DataTextField = "TTT_Type";
        DdlType.DataValueField = "TTT_TypeID";
        DdlType.DataBind();
        DdlType.Items.Insert(0, new ListItem("请选择", ""));
    }
    private void BindDdlMonth()
    {
        for (int m = 1; m <= 12; m++)
        {
            DdlMonth.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        DdlMonth.Items.Insert(0, new ListItem("请选择", ""));
        DdlMonth.DataBind();
    }
    #endregion


    #region//培训项目XX
    protected void BtnSubmit2_Click(object sender, EventArgs e)
    {
        if (Label12.Text == "新增")
        {
            if (DdlMonth.Text == "" || TxtTrainingItem.Text == "" || TxtTarget.Text == ""||
                DdlType.Text == "" || DdlDep.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            TrainningInfo neiaInfoForAdd = new TrainningInfo();
            neiaInfoForAdd.TTT_TypeID = new Guid(DdlType.SelectedValue);
            neiaInfoForAdd.TYPM_ID = new Guid(Label15.Text);
            neiaInfoForAdd.TID_Month = int.Parse(DdlMonth.SelectedValue);
            neiaInfoForAdd.TID_TLesson = TxtTrainingItem.Text;
            neiaInfoForAdd.TID_Target = TxtTarget.Text;
            neiaInfoForAdd.BDOS_Code = DdlDep.SelectedValue;
            int i = 0;
            try
            {
                i = typmL.Insert_TrainingItemDetail(neiaInfoForAdd);
                if (i > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + ex + "')", true);
                return;
            }
            BindGridView_Item("");
            Panel5.Visible = false;
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }

        if (Label12.Text == "编辑")
        {
            if (DdlMonth.Text == "" || TxtTrainingItem.Text == "" || TxtTarget.Text == "" ||
                DdlType.Text == "" || DdlDep.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            TrainningInfo neiaInfoForEdit = new TrainningInfo();
            neiaInfoForEdit.TTT_TypeID = new Guid(DdlType.SelectedValue);
            neiaInfoForEdit.TID_ID = new Guid(Label8.Text);
            neiaInfoForEdit.TID_Month = int.Parse(DdlMonth.SelectedValue);
            neiaInfoForEdit.TID_TLesson = TxtTrainingItem.Text;
            neiaInfoForEdit.TID_Target = TxtTarget.Text;
            neiaInfoForEdit.BDOS_Code = DdlDep.SelectedValue;
            int i = 0;
            try
            {
                i = typmL.Update_TrainingItemDetail(neiaInfoForEdit);
                if (i > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            BindGridView_Item("");
            Panel5.Visible = false;
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }
    }//提交(typmL)
    protected void BtnCacel2_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }//取消
    #endregion


    #region//GridView_Item的内置事件
    protected void GridView_Item_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView_Item_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Item.BottomPagerRow;


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
        BindGridView_Item("");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Item.PageCount ? GridView_Item.PageCount - 1 : newPageIndex;
        GridView_Item.PageIndex = newPageIndex;
        GridView_Item.DataBind();
    }
    protected void GridView_Item_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "EditItemInPlan1")
        {
            try
            {
                Panel5.Visible = true;
                Label12.Text = "编辑";
                BindDdlType();
                BindDdlDep();

                UpdatePanel5.Update();
                Label8.Text = e.CommandArgument.ToString();
                DdlMonth.SelectedValue = row.Cells[1].Text;
                TxtTrainingItem.Text = row.Cells[2].Text;
                TxtTarget.Text = row.Cells[3].Text;
                DdlType.Items.FindByValue(row.Cells[5].Text).Selected = true;
                DdlDep.Items.FindByValue(row.Cells[6].Text).Selected = true;
                //DdlType.SelectedValue = row.Cells[5].Text;
                //DdlDep.SelectedValue = row.Cells[6].Text;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('" + ex.Message.ToString() + "');</script>");
            }
        }
        if (e.CommandName == "DeleteItemInPlan1")
        {
            GridView_Item.SelectedIndex = -1;
            typmL.Delete_TrainingItemDetail(new Guid(e.CommandArgument.ToString()));
            BindGridView_Item("");
            UpdatePanel4.Update();
        }
    }
    #endregion
}