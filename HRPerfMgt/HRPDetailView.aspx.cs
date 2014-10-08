using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class HRPerfMgt_HRPDetailView : Page
{
    HRPerfL hRPerfL = new HRPerfL();
    HRPtypeInfo hRPtypeInfo = new HRPtypeInfo();
    HRPItemL hRPItemL = new HRPItemL();
    HRPItemInfo hRPItemInfo = new HRPItemInfo();
    HRDDetailL hRDDetailL = new HRDDetailL();//
    NewEmpInfoAddL neiaL = new NewEmpInfoAddL();//调用来绑定审核人和考核人的选择列表
    private static string str;
    private static string condition;
    private static string con1;
    private static string con2;
    private static string con3;
    private static string Condition3;//考核人和审核人选择栏,对应的检索条件
    private static string flag;//判断是考核人还是审核人的标志
    private static Guid id;
    private static char charFlag;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["status"] == "PerMainView")
        {
            Title = "绩效基础数据查看";
        }
        if (!IsPostBack)
        {
            BindGrid("");

        }
    }
    #region//绩效考核类型检索栏
    private void BindGrid(string HRPAT_Type)
    {
        Grid_Type.DataSource = hRPerfL.Search_HRPerformAssessType(HRPAT_Type);
        Grid_Type.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        str = TxtType.Text.Trim();
        BindGrid(str);
        UpdatePanel_Grid.Update();
        LblStateForGrid_Type.Text = "检索后";
    }
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        TxtAperson.Text = "";
        TxtCperson.Text = "";
        Panel_NewType.Visible = false;
        UpdatePanel_NewType.Update();
        Panel_SearchEmployee.Visible = false;
        Panel_Grid_Detail.Visible = false;
        Panel_AddEmployee.Visible = false;
        UpdatePanel_SearchEmployee.Update();
        UpdatePanel_Grid_Detail.Update();
        UpdatePanel_AddEmployee.Update();

        Panel_NewType.Visible = false;
        UpdatePanel_NewType.Update();
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();

        Panel_NewType.Visible = true;
        UpdatePanel_NewType.Update();
        TxtNewType.Text = "";
        Label28.Text = "新增";
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TxtType.Text = "";
        BindGrid("");
        LblStateForGrid_Type.Text = "检索前";
        UpdatePanel_Grid.Update();
        Panel_SearchEmployee.Visible = false;
        UpdatePanel_SearchEmployee.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (Label28.Text == "新增")
        {
            hRPtypeInfo.HRPAT_ID = Guid.NewGuid();
            if (TxtNewType.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入员工类型！')", true);
                return;
            }
            else if (TxtAperson.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入考核人！')", true);
                return;
            }
            else if (TxtAperson.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入考核人！')", true);
                return;
            }
            else
            {
                hRPtypeInfo.HRPAT_PType = TxtNewType.Text;
                hRPtypeInfo.HRPAT_APerson = Label29.Text.Trim();
                hRPtypeInfo.HRPAT_CPerson = Label30.Text.Trim();
                hRPtypeInfo.HRPAT_IsDeleted = false;
                try
                {
                    int i = hRPerfL.Insert_HRPerformAssessType(hRPtypeInfo);
                    //this.UpdatePanel_NewType.Update();
                    if (i <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的员工类型！')", true);
                        return;
                    }
                    else
                    {
                        BindGrid(LblStateForGrid_Type.Text);
                        UpdatePanel_Grid.Update();
                        UpdatePanel_NewType.Update();
                        TxtNewType.Text = "";
                        Panel_NewType.Visible = false;
                        BindGrid("");
                        //BindItem("");
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增考核类型成功！')", true);
                    }


                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex + "')", true);
                }
            }

        }
        if (Label28.Text == "编辑")
        {
            hRPtypeInfo.HRPAT_ID = new Guid(Label27.Text);
            if (TxtNewType.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入员工类型！')", true);
                return;
            }
            else if (TxtAperson.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入考核人！')", true);
                return;
            }
            else if (TxtAperson.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入考核人！')", true);
                return;
            }
            else
            {
                hRPtypeInfo.HRPAT_PType = TxtNewType.Text;
                if (Label29.Text.Trim() == "")
                {
                    Label29.Text = Label31.Text.Trim();
                }
                if (Label30.Text.Trim() == "")
                {
                    Label30.Text = Label32.Text.Trim();
                }
                hRPtypeInfo.HRPAT_APerson = Label29.Text.Trim();
                hRPtypeInfo.HRPAT_CPerson = Label30.Text.Trim();
                try
                {

                    int i = hRPerfL.Update_HRPerformAssessType_Person(hRPtypeInfo);
                    if (i <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('更新失败！')", true);
                        return;
                    }
                    else
                    {
                        BindGrid(LblStateForGrid_Type.Text);
                        UpdatePanel_Grid.Update();
                        UpdatePanel_NewType.Update();
                        TxtNewType.Text = "";
                        Panel_NewType.Visible = false;
                        BindGrid("");
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('更新考核类型成功！')", true);
                    }


                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('更新失败！" + ex + "')", true);
                }
            }

        }



    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {

        TxtAperson.Text = "";
        TxtCperson.Text = "";
        UpdatePanel_NewType.Update();
        Panel_NewType.Visible = false;

    }

    protected void Grid_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Type.BottomPagerRow;


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

        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(TxtType.Text.Trim());
        }

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Type.PageCount ? Grid_Type.PageCount - 1 : newPageIndex;
        Grid_Type.PageIndex = newPageIndex;
        Grid_Type.DataBind();
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }
    #endregion

    #region//GridView的RowCommand的删除、编辑和新增
    protected void Grid_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Type")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Type.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            hRPerfL.Delete_HRPerformAssessType(guid);
            hRPItemL.Delete_HRPerformceItem(guid);
            BindGrid("");
            //BindItem("");
        }
        if (e.CommandName == "Delete_Type_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Type.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            //hRPerfL.Delete_HRPerformAssessType(guid);
            hRPItemL.Delete_HRPerformceItem(guid);
            //BindGrid("");
            BindItem("");
        }
        if (e.CommandName == "Edit_Post")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Panel3.Visible = true;
            UpdatePanel3.Update();
            LblState.Text = "编辑";
            Label49.Text = e.CommandArgument.ToString();
            id = new Guid(Label49.Text);
            HRPItemInfo hR = hRPItemL.SearchByID_HRPItem(id)[0];
            TextBox_newItem1.Text = hR.HRPI_Items;
            TextBox_newItem2.Text = hR.HRPI_Contents;
            TextBox_newItem3.Text = hR.HRPI_StanScore;
            TextBox_newItem4.Text = hR.HRPI_AssStandard;
            TextBox_newItem5.Text = hR.HRPI_Remarks;
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Edit1")
        {
            Panel_NewType.Visible = false;
            UpdatePanel_NewType.Update();
            Panel_SearchEmployee.Visible = false;
            Panel_Grid_Detail.Visible = false;
            Panel_AddEmployee.Visible = false;
            UpdatePanel_SearchEmployee.Update();
            UpdatePanel_Grid_Detail.Update();
            UpdatePanel_AddEmployee.Update();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Type.SelectedIndex = row.RowIndex;
            Label48.Text = e.CommandArgument.ToString();
            Guid guid = new Guid(Label48.Text);
            Panel2.Visible = true;
            UpdatePanel2.Update();
            BindItem("");

        }
        if (e.CommandName == "Edit2")
        {
            Panel_NewType.Visible = false;
            UpdatePanel_NewType.Update();
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            con1 = " and HRPAT_ID='" + e.CommandArgument.ToString() + "'";
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Type.SelectedIndex = row.RowIndex;
            Label50.Text = e.CommandArgument.ToString();
            Guid guid = new Guid(Label50.Text);
            Panel_SearchEmployee.Visible = true;
            Panel_Grid_Detail.Visible = true;
            UpdatePanel_SearchEmployee.Update();
            UpdatePanel_Grid_Detail.Update();
            BindGridForEmployee(Grid_Detail, con1);
            Bind_DdlDep(DdlSearchDep);
            Bind_DdlPost(DdlSearchPost, "");
        }
        if (e.CommandName == "Edit3")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Panel_NewType.Visible = true;
            UpdatePanel_NewType.Update();
            Label28.Text = "编辑";
            Label27.Text = e.CommandArgument.ToString();
            id = new Guid(Label27.Text);
            HRPtypeInfo hRType = hRPerfL.SearchByID_HRPerformAssessType(id)[0];
            DataSet dtAperson = neiaL.Search_ForTeacher_HRDDetail("and UMUI_UserID like '%" + hRType.HRPAT_APerson.Trim() + "%' ");
            DataSet dtCperson = neiaL.Search_ForTeacher_HRDDetail("and UMUI_UserID like '%" + hRType.HRPAT_CPerson.Trim() + "%' ");
            TxtAperson.Text = Convert.ToString(dtAperson.Tables[0].Rows[0]["UMUI_UserName"]);
            TxtCperson.Text = Convert.ToString(dtCperson.Tables[0].Rows[0]["UMUI_UserName"]);
            DataSet dtApersonID = neiaL.Search_ForTeacher_HRDDetail("and UMUI_UserName like '%" + hRType.HRPAT_APerson + "%' ");
            DataSet dtCpersonID = neiaL.Search_ForTeacher_HRDDetail("and UMUI_UserName like '%" + hRType.HRPAT_CPerson + "%' ");
            TxtNewType.Text = hRType.HRPAT_PType;
            Label31.Text = hRType.HRPAT_APerson;
            Label32.Text = hRType.HRPAT_CPerson;
            UpdatePanel_NewType.Update();
        }
    }
    #endregion
    protected void Grid_Type_RowEditing(object sender, GridViewEditEventArgs e)
    {

        Grid_Type.EditIndex = e.NewEditIndex;
        GridView2.EditIndex = e.NewEditIndex;
        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
            BindItem("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(TxtType.Text.Trim());
            BindItem(TxtItem1.Text.Trim());
        }
    }
    protected void Grid_Type_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_Type.EditIndex = -1;
        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(TxtType.Text.Trim());
        }
    }
    protected void Grid_Type_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        hRPtypeInfo.HRPAT_ID = new Guid(Grid_Type.DataKeys[e.RowIndex].Value.ToString());
        hRPItemInfo.HRPI_ItemID = new Guid(GridView2.DataKeys[e.RowIndex].Value.ToString());
        hRPtypeInfo.HRPAT_PType = ((TextBox)(Grid_Type.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
        hRPItemInfo.HRPI_Items = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
        hRPItemInfo.HRPI_StanScore = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString();
        hRPItemInfo.HRPI_AssStandard = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString();
        hRPItemInfo.HRPI_Remarks = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString();
        int i = hRPerfL.Update_HRPerformAssessType(hRPtypeInfo);
        if (i <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的员工类型！')", true);
            return;
        }
        Grid_Type.EditIndex = -1;
        GridView2.EditIndex = -1;
        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
            BindItem("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(TxtType.Text.Trim());
            BindItem(TxtItem1.Text.Trim());
        }
        UpdatePanel_Grid.Update();
        UpdatePanel2.Update();
    }
    protected void Grid_Type_RowUpdating_Item(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            hRPItemInfo.HRPI_ItemID = new Guid(GridView2.DataKeys[e.RowIndex].Value.ToString());
            hRPItemInfo.HRPI_Items = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
            hRPItemInfo.HRPI_Contents = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString();
            hRPItemInfo.HRPI_StanScore = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString();
            hRPItemInfo.HRPI_AssStandard = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString();
            hRPItemInfo.HRPI_Remarks = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim().ToString();

            GridView2.EditIndex = -1;
            if (LblStateForGrid_Type.Text == "检索前")
            {
                BindItem("");
            }
            if (LblStateForGrid_Type.Text == "检索后")
            {
                BindItem(TxtItem1.Text.Trim());
            }
            UpdatePanel2.Update();
        }
        catch (Exception)
        {

            throw;
        }

    }


    #region//维护考核项目
    private void BindItem(string cond)
    {
        GridView2.DataSource = hRPItemL.Search_HRPerformceItem(" and HRPAT_ID = '" + new Guid(Label48.Text) + "'" + cond);
        GridView2.DataBind();
        DataSet sumData = hRPItemL.Search_HRPerformceItem(" and HRPAT_ID = '" + new Guid(Label48.Text) + "'");
        int count = sumData.Tables[0].Rows.Count;
        int sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += Convert.ToInt32(sumData.Tables[0].Rows[i]["HRPI_StanScore"]);
        }
        TextBox1.Text = Convert.ToString(sum);
    }
    private void AlertSum()
    {
        DataSet sumData = hRPItemL.Search_HRPerformceItem(" and HRPAT_ID = '" + new Guid(Label48.Text) + "'");
        int count = sumData.Tables[0].Rows.Count;
        int sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += Convert.ToInt32(sumData.Tables[0].Rows[i]["HRPI_StanScore"]);
        }
        if (sum != 100)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('各项目的标准得分之和要为100分！')", true);
        }
        TextBox1.Text = Convert.ToString(sum);
    }//当标准得分之和不为100分时发出警告
    protected void ItemBtnSearch_Click(object sender, EventArgs e)
    {
        condition = TxtItem1.Text.Trim() == "" ? "" : " and HRPI_Items like '%" + TxtItem1.Text.Trim() + "%'";
        condition += TxtItem2.Text.Trim() == "" ? "" : " and HRPI_Contents like '%" + TxtItem2.Text.Trim() + "%'";
        condition += TxtItem3.Text.Trim() == "" ? "" : " and HRPI_AssStandard like '%" + TxtItem3.Text.Trim() + "%'";
        try
        {
            BindItem(condition);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        LblRecordIsSearch.Text = "检索后";
        UpdatePanel2.Update();

    }
    protected void ItemBtnNew_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        UpdatePanel3.Update();
        TextBox_newItem1.Text = "";
        TextBox_newItem2.Text = "";
        TextBox_newItem3.Text = "";
        TextBox_newItem4.Text = "";
        TextBox_newItem5.Text = "";
        LblState.Text = "新增";
    }

    protected void BtnSubmit_Item(object sender, EventArgs e)
    {
        if (LblState.Text == "新增")
        {
            hRPItemInfo.HRPI_ItemID = Guid.NewGuid();
            hRPItemInfo.HRPAT_ID = new Guid(Label48.Text);
            if (TextBox_newItem1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入考核项目！')", true);
                return;
            }
            else
                hRPItemInfo.HRPI_Items = TextBox_newItem1.Text;
            hRPItemInfo.HRPI_Contents = TextBox_newItem2.Text;
            hRPItemInfo.HRPI_StanScore = TextBox_newItem3.Text;
            hRPItemInfo.HRPI_AssStandard = TextBox_newItem4.Text;
            hRPItemInfo.HRPI_Remarks = TextBox_newItem5.Text;
            hRPItemInfo.HRPI_IsDeleted = false;
            try
            {

                int i = hRPItemL.Insert_HRPerformceItem(hRPItemInfo);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的考核类型！')", true);
                    return;
                }
                BindItem("");
                UpdatePanel2.Update();
                UpdatePanel3.Update();
                TextBox_newItem1.Text = "";
                TextBox_newItem2.Text = "";
                TextBox_newItem3.Text = "";
                TextBox_newItem4.Text = "";
                Panel3.Visible = false;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex + "')", true);
            }
        }

        if (LblState.Text == "编辑")
        {


            HRPItemInfo hr = new HRPItemInfo();
            hr.HRPI_ItemID = new Guid(Label49.Text);
            hr.HRPAT_ID = new Guid(Label48.Text);
            hr.HRPI_Items = TextBox_newItem1.Text;
            hr.HRPI_Contents = TextBox_newItem2.Text;
            hr.HRPI_StanScore = TextBox_newItem3.Text;
            hr.HRPI_AssStandard = TextBox_newItem4.Text;
            hr.HRPI_Remarks = TextBox_newItem5.Text;
            try
            {
                int i = hRPItemL.Update_HRPerformceItem(hr);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的考核类型！')", true);
                    return;
                }
                BindItem("");
                UpdatePanel2.Update();
                UpdatePanel3.Update();
                Panel3.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        AlertSum();

    }
    protected void BtnCancel_Item(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void BtnReset_Item(object sender, EventArgs e)
    {
        TxtItem1.Text = "";
        TxtItem2.Text = "";
        TxtItem3.Text = "";
        LblRecordIsSearch.Text = "检索前";
        BindItem("");
    }

    protected void Grid_Type_PageIndexChangingItem(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxItem");   // refer to the TextBox with the NewPageIndex value
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

        if (LblRecordIsSearch.Text == "检索前")
        {
            BindItem("");
        }
        if (LblRecordIsSearch.Text == "检索后")
        {
            //BindGrid(TxtType.Text.Trim());
            BindItem(condition);
        }

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }
    protected void BtnCancelItem_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();

    }

    protected void Grid_Type_RowDataBound_Item(object sender, GridViewRowEventArgs e)
    {

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;

            }
        }
    }
    #endregion

    #region//绑定部门和岗位
    private void Bind_DdlDep(DropDownList ddl)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail_BDOrganizationSheet().Tables[0].DefaultView;
        ddl.DataTextField = "BDOS_Name";
        ddl.DataValueField = "BDOS_Code";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定Dropdownlist中的DdlDep——部门，参数是欲绑定的Dropdownlist

    private void Bind_DdlPost(DropDownList ddl, string BDOS_Code)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        ddl.DataTextField = "HRP_Post";
        ddl.DataValueField = "HRP_ID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定Dropdownlist中的DdlDep——岗位,参数是欲绑定岗位的DropDownList和部门代码

    protected void DdlSearchDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlPost(DdlSearchPost, DdlSearchDep.SelectedValue.ToString());
    }//DdropdownList二级联动:根据部门中的选项，实现下级自动绑定（要实现此方法，前台必须设定触发器,以及该事件源的控件的属性AuotoPostback为true）
    #endregion

    #region//绩效考核的员工信息栏

    private void BindGridForEmployee(GridView gv, string condition)
    {
        gv.DataSource = hRDDetailL.Search_HRDDetail(condition);
        gv.DataBind();
    }//绑定Gridview(属于该账套的员工列表)
    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        //string condition = con1;
        con1 = TxtSearchStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        con1 += TxtSearchName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        con1 += DdlSearchDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlSearchDep.SelectedValue + "'";
        con1 += DdlSearchPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlSearchPost.SelectedValue + "'";
        try
        {
            BindGridForEmployee(Grid_Detail, con1 + " and HRPAT_ID='" + Label50.Text + "'");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        LabelForSearchEmployee.Text = "检索后";
        UpdatePanel_SearchEmployee.Update();
        UpdatePanel_Grid_Detail.Update();
    }//xxx的员工信息栏的“检索”

    protected void BtnResetEmployee_Click(object sender, EventArgs e)
    {
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        DdlSearchDep.ClearSelection();
        DdlSearchPost.ClearSelection();
        LabelForSearchEmployee.Text = "检索前";
        BindGridForEmployee(Grid_Detail, " and HRPAT_ID='" + Label50.Text + "'");
        UpdatePanel_SearchEmployee.Update();
        UpdatePanel_Grid_Detail.Update();
    }//xxx的员工信息栏的“重置”

    protected void BtnAddEmployee_Click(object sender, EventArgs e)
    {
        try
        {
            con2 = " and HRPAT_ID is null";
            Panel_AddEmployee.Visible = true;
            BindGridForEmployee(GridViewAdd, con2);
        }
        catch (Exception ex)
        {

            throw ex;
        }

        Bind_DdlDep(DdlAddDep);
        Bind_DdlPost(DdlAddPost, "");
        UpdatePanel_AddEmployee.Update();
    }//xxx的员工信息栏的“新增员工”

    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Detail")
        {

            Guid guid = new Guid(e.CommandArgument.ToString());
            hRPerfL.Delete_HRPerformAssessType_HRDDetail(guid);
            BindGridForEmployee(Grid_Detail, con1);
            UpdatePanel_SearchEmployee.Update();
            UpdatePanel_Grid_Detail.Update();
            //if (Panel_AddEmployee.Visible == true)
            //{
            //    BindGridForEmployee(GridViewAdd, con2);
            //    UpdatePanel_AddEmployee.Update();
            //}
        }
    }//属于该账套的员工列表中的Gridview的删除

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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox3");   // refer to the TextBox with the NewPageIndex value
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
        if (LabelForSearchEmployee.Text == "检索前")
        {
            BindGridForEmployee(Grid_Detail, " and HRPAT_ID='" + Label50.Text + "'");
        }
        if (LabelForSearchEmployee.Text == "检索后")
        {
            BindGridForEmployee(Grid_Detail, con1 + " and HRPAT_ID='" + Label50.Text + "'");
        }


        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }//员工列表的翻页

    protected void BtnCancelEmployee_Click(object sender, EventArgs e)
    {

        Panel_SearchEmployee.Visible = false;
        Panel_Grid_Detail.Visible = false;
        UpdatePanel_SearchEmployee.Update();
        UpdatePanel_Grid_Detail.Update();
        Panel_AddEmployee.Visible = false;
        UpdatePanel_AddEmployee.Update();
    }//关闭员工列表

    protected void Grid_Detail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Detail.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Detail.Rows[i].Cells.Count; j++)
            {
                Grid_Detail.Rows[i].Cells[j].ToolTip = Grid_Detail.Rows[i].Cells[j].Text;
                if (Grid_Detail.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Detail.Rows[i].Cells[j].Text = Grid_Detail.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }//
    #endregion
    #region//绩效考核的员工新增栏
    protected void BtnAddSearch_Click(object sender, EventArgs e)
    {
        //string condition = con2;
        con2 = TxtAddStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtAddStaffNO.Text.Trim() + "%'";
        con2 += TxtAddName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtAddName.Text.Trim() + "%'";
        con2 += DdlAddDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlAddDep.SelectedValue + "'";
        con2 += DdlAddPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlAddPost.SelectedValue + "'";
        try
        {
            BindGridForEmployee(GridViewAdd, con2 + " and HRPAT_ID is null");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检索失败！" + ex + "')", true);
            return;
        }
        LabelForAddEmployee.Text = "检索后";
        UpdatePanel_AddEmployee.Update();

    }//员工新增栏的“检索”

    protected void BtnAddReset_Click(object sender, EventArgs e)
    {
        TxtAddStaffNO.Text = "";
        TxtAddName.Text = "";
        DdlAddDep.ClearSelection();
        DdlAddPost.ClearSelection();
        LabelForAddEmployee.Text = "检索前";
        BindGridForEmployee(GridViewAdd, " and HRPAT_ID is null");
    }//员工新增栏的“重置”

    protected void BtnAddSubmit_Click(object sender, EventArgs e)
    {
        int count = 0;
        try
        {
            Guid g2 = new Guid(Label50.Text);
            for (int i = 0; i < GridViewAdd.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked)
                {
                    count += 1;
                    Guid g1 = new Guid(GridViewAdd.Rows[i].Cells[0].Text.ToString());
                    hRPerfL.Insert_HRPerformAssessType_HRDDetail(g1, g2);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex.ToString() + "')", true);
        }
        if (count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择需要添加的员工！')", true);
            return;
        }
        BindGridForEmployee(Grid_Detail, con1);
        //UpdatePanel_SearchEmployee.Update();
        UpdatePanel_Grid_Detail.Update();
        BindGridForEmployee(GridViewAdd, con2);
        UpdatePanel_AddEmployee.Update();
        Panel_AddEmployee.Visible = false;
        UpdatePanel_AddEmployee.Update();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
    }//员工新增栏的“提交”

    protected void BtnAddCancel_Click(object sender, EventArgs e)
    {

        TxtAddStaffNO.Text = "";
        TxtAddName.Text = "";
        DdlAddDep.ClearSelection();
        DdlAddPost.ClearSelection();
        Cbx_SelectAll.Checked = false;
        Cbx_SelectAllCancel.Checked = false;
        Cbx_SelectOpposite.Checked = false;
        Panel_AddEmployee.Visible = false;
    }//员工新增栏的“取消”

    protected void DdlAddDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlPost(DdlAddPost, DdlAddDep.SelectedValue.ToString());
    }//DdropdownList二级联动:根据部门中的选项，实现下级自动绑定（要实现此方法，前台必须设定触发器,以及该事件源的控件的属性AuotoPostback为true）

    protected void Cbx_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        Cbx_SelectAllCancel.Checked = false;
        Cbx_SelectOpposite.Checked = false;
        for (int i = 0; i <= GridViewAdd.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");

            if (Cbx_SelectAll.Checked)
            {
                cbox.Checked = true;
            }
        }
    }//全选

    protected void Cbx_SelectAllCancel_CheckedChanged(object sender, EventArgs e)
    {
        Cbx_SelectAll.Checked = false;
        Cbx_SelectOpposite.Checked = false;

        for (int i = 0; i <= GridViewAdd.Rows.Count - 1; i++)
        {
            if (Cbx_SelectAllCancel.Checked)
            {
                CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");
                cbox.Checked = false;
            }
        }
    }//全不选

    protected void Cbx_SelectOpposite_CheckedChanged(object sender, EventArgs e)
    {
        Cbx_SelectAll.Checked = false;
        Cbx_SelectAllCancel.Checked = false;
        for (int i = 0; i <= GridViewAdd.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");
            if (Cbx_SelectOpposite.Checked)
            {
                if (!cbox.Checked)
                {
                    cbox.Checked = true;
                }
                else
                    cbox.Checked = false;
            }
        }
    }//反选
    #endregion
    #region//绩效考核员工新增栏的翻页

    protected void GridViewAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridViewAdd.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox4");   // refer to the TextBox with the NewPageIndex value
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
        if (LabelForAddEmployee.Text == "检索前")
        {
            BindGridForEmployee(GridViewAdd, " and HRPAT_ID is null");
        }
        if (LabelForAddEmployee.Text == "检索后")
        {
            BindGridForEmployee(GridViewAdd, con2 + " and HRPAT_ID is null");
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridViewAdd.PageCount ? GridViewAdd.PageCount - 1 : newPageIndex;
        GridViewAdd.PageIndex = newPageIndex;
        GridViewAdd.PageIndex = newPageIndex;
        GridViewAdd.DataBind();
    }//GridViewAdd进行翻页
    #endregion



    #region//考核人和审核人选择栏

    private void BindGridView_Teacher(string Condition)
    {

        GridView_Teacher.DataSource = neiaL.Search_ForTeacher_HRDDetail(Condition);
        GridView_Teacher.DataBind();
    }//考核人和审核人列表GridView_Teacher
    protected void BtnSearchPeopleOut_Click(object sender, EventArgs e)
    {
        Condition3 = TextBox2.Text.Trim() == "" ? " " : " and UMUI_UserID like '%" + TextBox2.Text.Trim() + "%'";
        Condition3 += TextBox3.Text.Trim() == "" ? " " : " and UMUI_UserName like '%" + TextBox3.Text.Trim() + "%'";
        Condition3 += TextBox4.Text.Trim() == "" ? " " : " and BDOS_Name like '%" + TextBox4.Text.Trim() + "%'";
        Label9.Text = "检索后";
        BindGridView_Teacher(Condition3);
        UpdatePanel4.Update();
    }//检索
    protected void BtnResetPeopleOut_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        Label9.Text = "检索前";
        BindGridView_Teacher("");
        UpdatePanel4.Update();
    }//重置

    protected void GridView_SalaryItemAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            try
            {
                LbLblRecordSIT_ItemID2.Text = e.CommandArgument.ToString();
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                int i = drv.RowIndex;

                if (flag == "考核人")
                {
                    Label29.Text = GridView_Teacher.Rows[i].Cells[0].Text.ToString();
                    TxtAperson.Text = GridView_Teacher.Rows[i].Cells[1].Text.ToString();
                }
                else
                {
                    Label30.Text = GridView_Teacher.Rows[i].Cells[0].Text.ToString();
                    TxtCperson.Text = GridView_Teacher.Rows[i].Cells[1].Text.ToString();
                }

                Panel4.Visible = false;
                UpdatePanel4.Update();
                UpdatePanel_NewType.Update();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }//表中的选择
    #endregion


    protected void BtnSelect1_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        BindGridView_Teacher("");
        UpdatePanel4.Update();
        flag = "考核人";
    }
    protected void BtnSelect2_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        BindGridView_Teacher("");
        UpdatePanel4.Update();
        flag = "审核人";
    }
    protected void GridView_Teacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Teacher.BottomPagerRow;


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
        if (Label9.Text == "检索前")
        {
            BindGridView_Teacher("");
        }
        if (Label9.Text == "检索后")
        {
            BindGridView_Teacher(Condition3);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Teacher.PageCount ? GridView_Teacher.PageCount - 1 : newPageIndex;
        GridView_Teacher.PageIndex = newPageIndex;
        GridView_Teacher.DataBind();
    }

    protected void GridView_Teacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge1(this)");
            }
        }
    }


}