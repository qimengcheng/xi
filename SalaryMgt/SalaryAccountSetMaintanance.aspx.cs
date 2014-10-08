using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


public partial class SalaryMgt_SalaryAccountSetMaintanance : System.Web.UI.Page
{
    SalaryAccountSetMaintananceInfo ssmInfo = new SalaryAccountSetMaintananceInfo();
    SalaryAccountSetMaintananceL sSML = new SalaryAccountSetMaintananceL();
    HRDDetailL hRDDetailL = new HRDDetailL();//调用该业务逻辑的目的：绑定部门和岗位
    private static string con1;
    private static string con2;
    private static string con = " ";
    private static string str;//用来记录公式
    private static string condition;
    protected void Page_Load(object sender, EventArgs e)
    {
        #region//权限控制
        if (!((Session["UserRole"].ToString().Contains("薪资账套维护"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "Set")
        {
            this.Title = "薪资账套维护";
        }
        #endregion
        if (!IsPostBack)
        {
            BindGrid_Set("");

            LbCanBeUsedItem.Attributes.Add("onClick", "listboxSelect()");//为listbox注册客户端单击事件
        }//页面首次加载时，Grid_Set默认绑定的数据
    }

    #region//薪资账套检索栏
    protected void Btn_Search_Set_Click(object sender, EventArgs e)
    {

        con = TxtASNameSearch.Text.Trim() == "" ? " " : " and SAS_ASName like " + "'%" + TxtASNameSearch.Text.Trim() + "%'";
        if (DropDownList3.Text.Trim() == "请选择")
            con += " ";
        else
        {
            con += " and SAS_Type= '" + DropDownList3.Text + "'";
        }
        BindGrid_Set(con);
        LblStateForGrid_Set.Text = "检索后";//用该Label记录是否进行了检索，以便gridview编辑后重新进行绑定
        UpdatePanel_SetGrid.Update();
    }//薪资账套检索栏的“检索”按钮的单击事件

    protected void Btn_Reset_Click(object sender, EventArgs e)
    {
        TxtASNameSearch.Text = "";
        DropDownList3.ClearSelection();
        BindGrid_Set("");
        UpdatePanel_SetGrid.Update();
        LblStateForGrid_Set.Text = "检索前";
    }//薪资账套检索栏的“重置”按钮的单击事件

    protected void Btn_New_Set_Click(object sender, EventArgs e)
    {
        Label20.Text = "新增";
        TxtASNameNew.Text = "";
        Panel_NewSet.Visible = true;
        TxtASNameNew.Text = "";
        this.UpdatePanel_NewSet.Update();
    }//点击新增账套的单击事件
    #endregion

    #region//新增账套
    protected void BtnOK_NewSet_Click(object sender, EventArgs e)
    {
        if (Label20.Text == "新增")
        {
            if (TxtASNameNew.Text != "")
            {
                ssmInfo.SAS_ASID = Guid.Empty;
                ssmInfo.SAS_ASName = TxtASNameNew.Text.Trim();
                ssmInfo.SAS_Type = DropDownList1.SelectedValue;
                ssmInfo.SAS_IsDeleted = false;
                try
                {
                    if (sSML.Insert_SalaryAccountSet(ssmInfo) <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('重复的账套名，请核实！')", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交失败！" + ex + "')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！！')", true);
                return;
            }
            this.Panel_NewSet.Visible = false;
            BindGrid_Set("");
            UpdatePanel_NewSet.Update();
            UpdatePanel_SetGrid.Update();
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增成功！')", true);
        }
        if (Label20.Text == "编辑")
        {
            ssmInfo.SAS_ASID = new Guid(LblRecordID.Text);
            ssmInfo.SAS_ASName = TxtASNameNew.Text;
            ssmInfo.SAS_Type = DropDownList1.SelectedValue;
            try
            {
                int i = sSML.Update_SalaryAccountSet(ssmInfo);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('该帐套中存在重复的工资项目名称！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            Grid_Set.EditIndex = -1;
            if (LblStateForGrid_Set.Text == "检索前")
            {
                BindGrid_Set("");
            }
            if (LblStateForGrid_Set.Text == "检索后")
            {
                BindGrid_Set(con);
            }
            this.UpdatePanel_SetGrid.Update();
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);
        }
    }//新增账套面板中的“提交”的单击事件 

    protected void BtnCancel_NewSet_Click(object sender, EventArgs e)
    {
        Panel_NewSet.Visible = false;
        TxtASNameNew.Text = "";
        DropDownList1.ClearSelection();
    }//新增账套面板中的“取消”的单击事件
    #endregion

    #region//Grid_Set的事件(薪资账套列表中的Gridview)
    protected void Grid_Set_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Set")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.Grid_Set.SelectedIndex = row.RowIndex;

            Guid guid = new Guid(e.CommandArgument.ToString());
            sSML.Delete_SalaryAccountSet(guid);
            BindGrid_Set("");
        }
        if (e.CommandName == "Maintance_SalaryItem")
        {
            Panel_SalaryItemMaintanance.Visible = true;
            LblRecordSAS_ASID.Text = e.CommandArgument.ToString();//记录下账套的ID
            if (Panel_SearchEmployee.Visible == true && LblRecordSAS_ASID.Text != LblBindSAS_ASID.Text)
            {
                Panel_SearchEmployee.Visible = false;
                UpdatePanel_SearchEmployee.Update();
            }
            Panel_AddEmployee.Visible = false;
            UpdatePanel_AddEmployee.Update();
            Panel_ItemMaintanance.Visible = false;
            UpdatePanel_ItemMaintanance.Update();
            Panel_ItemGridSelect.Visible = false;
            UpdatePanel_ItemGridSelect.Update();
            Panel_EditFormula.Visible = false;
            UpdatePanel_EditFormula.Update();

            BindGridForSalaryItem(" and SAS_ASID='" + new Guid(e.CommandArgument.ToString()) + "'");
            this.UpdatePanel_SalaryItemMaintanance.Update();
            TxtASName.Text = ((GridViewRow)((LinkButton)e.CommandSource).Parent.Parent).Cells[1].Text.Trim().ToString();
            LblTheSet.Text = ((GridViewRow)((LinkButton)e.CommandSource).Parent.Parent).Cells[1].Text.Trim().ToString();

        }
        if (e.CommandName == "Maintance_Employee")
        {
            con1 = " and SAS_ASID='" + e.CommandArgument.ToString() + "'";
            Panel_SearchEmployee.Visible = true;

            BindGridForEmployee(Grid_Detail, con1);
            UpdatePanel_SearchEmployee.Update();
            Panel_AddEmployee.Visible = false;
            UpdatePanel_AddEmployee.Update();
            LblTheSet2.Text = ((GridViewRow)((LinkButton)e.CommandSource).Parent.Parent).Cells[1].Text.Trim().ToString();
            LblBindSAS_ASID.Text = e.CommandArgument.ToString();//记录下账套的ID
            if (Panel_SalaryItemMaintanance.Visible == true && LblRecordSAS_ASID.Text != LblBindSAS_ASID.Text)
            {
                Panel_SalaryItemMaintanance.Visible = false;
                UpdatePanel_SalaryItemMaintanance.Update();
                Panel_ItemGridSelect.Visible = false;
                UpdatePanel_ItemGridSelect.Update();
                Panel_ItemMaintanance.Visible = false;
                UpdatePanel_ItemMaintanance.Update();
                Panel_EditFormula.Visible = false;
                UpdatePanel_EditFormula.Update();

            }

            Bind_DdlDep(DdlSearchDep);
            Bind_DdlPost(DdlSearchPost, "");
        }
        if (e.CommandName == "TheEdit")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.Grid_Set.SelectedIndex = row.RowIndex;
            string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label20.Text = "编辑";
            LblRecordID.Text = StrArgument[0];
            TxtASNameNew.Text=StrArgument[1];
            DropDownList1.Items.FindByText(StrArgument[2].ToString()).Selected = true;
            DropDownList1.Enabled = false;
            Panel_NewSet.Visible = true;
            UpdatePanel_NewSet.Update();
        }
    }//薪资账套列表中的Gridview的“删除““维护工资项目”“维护属于该账套的员工”

    protected void Grid_Set_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //每个单元格的Tooltip
        for (int i = 0; i < Grid_Set.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Set.Rows[i].Cells.Count; j++)
            {
                Grid_Set.Rows[i].Cells[j].ToolTip = Grid_Set.Rows[i].Cells[j].Text;

            }
        }
    }//Tooltip

    protected void Grid_Set_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Set.BottomPagerRow;


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
        if (LblStateForGrid_Set.Text == "检索前")
        {
            BindGrid_Set("");
        }
        if (LblStateForGrid_Set.Text == "检索后")
        {
            if (TxtASNameSearch.Text.Trim() != "")
                BindGrid_Set(" and SAS_ASName like '%" + TxtASNameSearch.Text.Trim() + "%'");
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Set.PageCount ? this.Grid_Set.PageCount - 1 : newPageIndex;
        this.Grid_Set.PageIndex = newPageIndex;
        this.Grid_Set.PageIndex = newPageIndex;
        this.Grid_Set.DataBind();
    }//翻页

    protected void Grid_Set_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.Grid_Set.EditIndex = e.NewEditIndex;
        if (LblStateForGrid_Set.Text == "检索前")
        {
            BindGrid_Set("");
        }
        if (LblStateForGrid_Set.Text == "检索后")
        {
            if (TxtASNameSearch.Text.Trim() != "")
                BindGrid_Set(" and SAS_ASName like '%" + TxtASNameSearch.Text.Trim() + "%'");
        }
    }//薪资账套列表中的Gridview的“编辑”

    protected void Grid_Set_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.Grid_Set.EditIndex = -1;
        if (LblStateForGrid_Set.Text == "检索前")
        {
            BindGrid_Set("");
        }
        if (LblStateForGrid_Set.Text == "检索后")
        {
            if (TxtASNameSearch.Text.Trim() != "")
                BindGrid_Set(" and SAS_ASName like '%" + TxtASNameSearch.Text.Trim() + "%'");
        }
    }//薪资账套列表中的Gridview中点击“编辑”之后的“取消”的单击事件

    protected void Grid_Set_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ssmInfo.SAS_ASID = new Guid(this.Grid_Set.DataKeys[e.RowIndex].Value.ToString());
        ssmInfo.SAS_ASName = ((TextBox)(this.Grid_Set.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
        if (ssmInfo.SAS_ASName.Length > 10)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('工资项目的名称过长，请修改！')", true);
            return;
        }
        try
        {
            int i = sSML.Update_SalaryAccountSet(ssmInfo);
            if (i <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('该帐套中存在重复的工资项目名称！')", true);
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


        Grid_Set.EditIndex = -1;
        if (LblStateForGrid_Set.Text == "检索前")
        {
            BindGrid_Set("");
        }
        if (LblStateForGrid_Set.Text == "检索后")
        {
            if (TxtASNameSearch.Text.Trim() != "")
                BindGrid_Set(" and SAS_ASName like '%" + TxtASNameSearch.Text.Trim() + "%'");
        }

        this.UpdatePanel_SetGrid.Update();
        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);
    }//薪资账套列表中的Gridview中点击“编辑”之后的“更新”的单击事件
    #endregion

    #region//工资项目维护栏
    protected void BtnNewItem_Click(object sender, EventArgs e)
    {
        Panel_ItemMaintanance.Visible = true;
        ClearSalaryItem();
        LblRecordItem.Text = "新增";
        LblRecordSIT_ItemID.Text = "";
        LblRecordSetForMaint.Text = TxtASName.Text;
        UpdatePanel_ItemMaintanance.Update();
        if (Panel_ItemGridSelect.Visible == true && LblRecordSetForMaint.Text != LblRecordSetForMaintForSelect.Text)
        {
            Panel_ItemGridSelect.Visible = false;
            UpdatePanel_ItemGridSelect.Update();
        }
        if (Panel_EditFormula.Visible == true)
        {
            Panel_EditFormula.Visible = false;
            UpdatePanel_EditFormula.Update();
        }
    }//工资项目维护栏的“新增工资项目”

    protected void BtnClosePanel_SalaryItemMaintanance_Click(object sender, EventArgs e)
    {
        TxtASName.Text = "";
        Panel_SalaryItemMaintanance.Visible = false;
        UpdatePanel_SalaryItemMaintanance.Update();
        if (Panel_ItemMaintanance.Visible)
        {
            Panel_ItemMaintanance.Visible = false;
            UpdatePanel_ItemMaintanance.Update();
        }

        if (Panel_ItemGridSelect.Visible)
        {
            Panel_ItemGridSelect.Visible = false;
            UpdatePanel_ItemGridSelect.Update();
        }
        if (Panel_EditFormula.Visible)
        {
            Panel_EditFormula.Visible = false;
            UpdatePanel_EditFormula.Update();
        }
    }//关闭
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

    #region//绑定所有的Gridview
    private void BindGrid_Set(string Condition)
    {
        this.Grid_Set.DataSource = sSML.Search_SalaryAccountSet(Condition);
        Grid_Set.DataBind();
    }//为薪资账套列表中的Gridview绑定值,以查询条件Condition为参数，允许多次调用

    private void BindGridForEmployee(GridView gv, string condition)
    {
        gv.DataSource = hRDDetailL.Search_HRDDetail(condition);
        gv.DataBind();
    }//绑定Gridview(属于该账套的员工列表)

    private void BindGridForSalaryItem(string condition)
    {
        GridView1.DataSource = sSML.Search_SalaryItemTable(condition);
        GridView1.DataBind();
    }//绑定Gridview1(工资项目列表)

    //private void BindGridForSalaryItemAll(string condition)
    //{
    //    GridView_SalaryItemAll.DataSource = sSML.Search_AllSalaryItems_SalaryItemTable(condition);
    //    GridView_SalaryItemAll.DataBind();
    //}//绑定GridView_SalaryItemAll(所有工资项目的列表)

    private void BindGridForSalaryItemAll(Guid g)
    {
        GridView_SalaryItemAll.DataSource = sSML.Search_FromOtherSet_SalaryItemTable(g);
        GridView_SalaryItemAll.DataBind();
    }//绑定GridView_SalaryItemAll(所有工资项目的列表)

    #endregion

    #region//GridViewAdd的事件

    protected void GridViewAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridViewAdd.BottomPagerRow;


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
        BindGridForEmployee(GridViewAdd, " and SAS_ASID is null");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridViewAdd.PageCount ? this.GridViewAdd.PageCount - 1 : newPageIndex;
        this.GridViewAdd.PageIndex = newPageIndex;
        this.GridViewAdd.PageIndex = newPageIndex;
        this.GridViewAdd.DataBind();
    }//GridViewAdd进行翻页
    #endregion

    #region//xxx的员工信息栏
    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        string condition = con1;
        condition += TxtSearchStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        condition += TxtSearchName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        condition += DdlSearchDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlSearchDep.SelectedValue + "'";
        condition += DdlSearchPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlSearchPost.SelectedValue + "'";
        try
        {
            BindGridForEmployee(Grid_Detail, condition);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        this.UpdatePanel_SearchEmployee.Update();

    }//xxx的员工信息栏的“检索”

    protected void BtnResetEmployee_Click(object sender, EventArgs e)
    {
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        DdlSearchDep.ClearSelection();
        DdlSearchPost.ClearSelection();
        BindGridForEmployee(Grid_Detail, con1);
    }//xxx的员工信息栏的“重置”

    protected void BtnAddEmployee_Click(object sender, EventArgs e)
    {
        try
        {
            con2 = " and SAS_ASID is null ";
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


    protected void BtnClosePanel_SearchEmployee_Click(object sender, EventArgs e)
    {
        Panel_SearchEmployee.Visible = false;
        UpdatePanel_SearchEmployee.Update();
        if (Panel_AddEmployee.Visible)
        {
            Panel_AddEmployee.Visible = false;
            UpdatePanel_AddEmployee.Update();
        }

    }//关闭

    #endregion

    #region//员工新增栏
    protected void BtnAddSearch_Click(object sender, EventArgs e)
    {
        condition = con2;
        condition += TxtAddStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtAddStaffNO.Text.Trim() + "%'";
        condition += TxtAddName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtAddName.Text.Trim() + "%'";
        condition += DdlAddDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlAddDep.SelectedValue + "'";
        condition += DdlAddPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlAddPost.SelectedValue + "'";
        try
        {
            BindGridForEmployee(GridViewAdd, condition);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('检索失败！" + ex + "')", true);
            return;
        }

        this.UpdatePanel_AddEmployee.Update();

    }//员工新增栏的“检索”

    protected void BtnAddReset_Click(object sender, EventArgs e)
    {
        TxtAddStaffNO.Text = "";
        TxtAddName.Text = "";
        DdlAddDep.ClearSelection();
        DdlAddPost.ClearSelection();
        BindGridForEmployee(GridViewAdd, con2);
    }//员工新增栏的“重置”

    protected void BtnAddSubmit_Click(object sender, EventArgs e)
    {
        int count = 0;
        try
        {
            Guid g2 = new Guid(LblBindSAS_ASID.Text);
            for (int i = 0; i < GridViewAdd.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked)
                {
                    count += 1;
                    Guid g1 = new Guid(GridViewAdd.Rows[i].Cells[0].Text.ToString());
                    sSML.Insert_SalaryAccountSet_HRDDetail(g1, g2);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交失败！" + ex.ToString() + "')", true);
        }
        if (count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请选择需要添加进账套的员工！')", true);
            return;
        }
        BindGridForEmployee(Grid_Detail, con1);
        UpdatePanel_SearchEmployee.Update();
        BindGridForEmployee(GridViewAdd, condition);
        UpdatePanel_AddEmployee.Update();
        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交成功！')", true);
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

    #region//Grid_Detail的内置事件
    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Detail")
        {

            Guid guid = new Guid(e.CommandArgument.ToString());
            sSML.Delete_SalaryAccountSet_HRDDetail(guid);
            BindGridForEmployee(Grid_Detail, con1);
            UpdatePanel_SearchEmployee.Update();
            if (Panel_AddEmployee.Visible == true)
            {
                BindGridForEmployee(GridViewAdd, con2);
                UpdatePanel_AddEmployee.Update();
            }
        }
    }//属于该账套的员工列表中的Gridview的删除

    protected void Grid_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //每个单元格的Tooltip
        for (int i = 0; i < Grid_Detail.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Detail.Rows[i].Cells.Count; j++)
            {
                Grid_Detail.Rows[i].Cells[j].ToolTip = Grid_Detail.Rows[i].Cells[j].Text;

            }
        }
    }

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
        //Grid_Post.DataBind();
        BindGridForEmployee(Grid_Detail, con1);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }
    #endregion

    #region//GridView1(工资项目列表)的自带事件
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit_Item")
        {
            try
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                this.GridView1.SelectedIndex = row.RowIndex;
                Guid guid = new Guid(e.CommandArgument.ToString());
                ssmInfo = sSML.SearchByID_SalaryItemTable(guid)[0];
                string item = ssmInfo.SIT_Items;
                if (item == "基本工资"
                    || item == "全勤工资" || item == "绩效工资" || item == "加班工资" || item == "工龄工资"
                    || item == "绩效扣款")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('该项数据源于系统默认值，不能进行编辑！')", true);
                    return;
                }
                if (item == "计时工资" || item == "计件工资" || item == "保险合计" || item == "险金合计" || item == "应发工资"
                    || item == "个人所得税扣款" || item == "实发工资")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('该项数据源于系统公式计算，不能进行编辑！')", true);
                    return;
                }
                Panel_ItemMaintanance.Visible = true;
                LblRecordItem.Text = "编辑";
                LblRecordSIT_ItemID.Text = e.CommandArgument.ToString();
                TxtSalaryItem.Text = ssmInfo.SIT_Items;
                TxtInitialValue.Text = ssmInfo.SIT_InitialValue.ToString();
                TxtFormula.Text = ssmInfo.SIT_Formula;
                UpdatePanel_ItemMaintanance.Update();

                Panel_ItemGridSelect.Visible = false;
                UpdatePanel_ItemGridSelect.Update();

                Panel_EditFormula.Visible = false;
                UpdatePanel_EditFormula.Update();
            }
            catch (Exception)
            {

                throw;
            }

        }
        if (e.CommandName == "Delete_Item")
        {
            Guid guid = new Guid(e.CommandArgument.ToString());
            int i = sSML.Delete_SalaryItemTable(guid);
            if (i > 0)
            {
                BindGridForSalaryItem(" and SAS_ASID='" + new Guid(LblRecordSAS_ASID.Text) + "'");
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('系统默认项，不能删除！')", true);
            UpdatePanel_SetGrid.Update();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView1.BottomPagerRow;


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
        BindGridForSalaryItem(" and SAS_ASID='" + new Guid(LblRecordSAS_ASID.Text) + "'");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView1.PageCount ? this.GridView1.PageCount - 1 : newPageIndex;
        this.GridView1.PageIndex = newPageIndex;
        this.GridView1.PageIndex = newPageIndex;
        this.GridView1.DataBind();
    }//GridView1的翻页

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //每个单元格的Tooltip
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;

            }
        }
    }//行变色以及每行的Tooltip
    #endregion

    #region//xxxx 工资项目新增/编辑
    protected void BtnSelect_Click(object sender, EventArgs e)
    {
        Panel_ItemGridSelect.Visible = true;
        BindGridForSalaryItemAll(new Guid(LblRecordSAS_ASID.Text));
        LblRecordSetForMaintForSelect.Text = LblRecordSetForMaint.Text;
        UpdatePanel_ItemGridSelect.Update();
    }//工资项目维护的“选择...”

    protected void BtnEditFormula_Click(object sender, EventArgs e)
    {
        Panel_EditFormula.Visible = true;
        TxtFormulaEdit.Text = TxtFormula.Text;
        ///
        ///进入公式编辑器后，ListBox进行绑定
        ///
        Guid newGuid;
        if (LblRecordSIT_ItemID.Text == "")
        {
            newGuid = new Guid();
        }
        else
            newGuid = new Guid(LblRecordSIT_ItemID.Text);
        LbCanBeUsedItem.DataSource = sSML.Search_AllSalaryItems_SalaryItemTable(newGuid, new Guid(LblRecordSAS_ASID.Text)).Tables[0].DefaultView;
        LbCanBeUsedItem.DataTextField = "SIT_Items";
        LbCanBeUsedItem.DataValueField = "SIT_Items";//绑定相同的值，方便单击选取
        LbCanBeUsedItem.DataBind();
        LblRecordItemForFormulate.Text = TxtSalaryItem.Text;
        TxtFormulaEdit.Text = TxtFormula.Text;
        UpdatePanel_EditFormula.Update();
    }//工资项目维护的“编辑公式...”

    protected void BtnSubmit_ItemMaintanance_Click(object sender, EventArgs e)
    {
        //计算公式和初始值只能二选一
        if (LblRecordItem.Text == "新增")
        {
            SalaryAccountSetMaintananceInfo ssmInfoOK = new SalaryAccountSetMaintananceInfo();
            if (TxtSalaryItem.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TxtSalaryItem.Text.ToString().Contains('+') || TxtSalaryItem.Text.ToString().Contains('-') || TxtSalaryItem.Text.ToString().Contains('*') || TxtSalaryItem.Text.ToString().Contains('/') || TxtSalaryItem.Text.ToString().Contains('#'))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('工资项目名称中不能包含+-*/#这些符号！')", true);
                return;
            }
            ssmInfoOK.SIT_ItemID = Guid.NewGuid();
            ssmInfoOK.SAS_ASID = new Guid(LblRecordSAS_ASID.Text);
            ssmInfoOK.SIT_Items = TxtSalaryItem.Text;

            decimal d;
            if (Decimal.TryParse(TxtInitialValue.Text, out d))
                ssmInfoOK.SIT_InitialValue = d;
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入正确的初始值！')", true);
                return;
            }
            ssmInfoOK.SIT_Formula = TxtFormula.Text;

            ssmInfoOK.SIT_IsDeleted = false;
            try
            {
                int i = sSML.Insert_SalaryItemTable(ssmInfoOK);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('该帐套中存在重复的工资项目名称！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败！" + ex + "')", true);
                return;
            }
            Panel_ItemMaintanance.Visible = false;
            UpdatePanel_ItemMaintanance.Update();
            BindGridForSalaryItem(" and SAS_ASID='" + new Guid(LblRecordSAS_ASID.Text) + "'");
            UpdatePanel_SalaryItemMaintanance.Update();
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增成功！')", true);
        }
        if (LblRecordItem.Text == "编辑")
        {
            SalaryAccountSetMaintananceInfo ssmInfoEdit = new SalaryAccountSetMaintananceInfo();
            if (TxtSalaryItem.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            ssmInfoEdit.SIT_ItemID = new Guid(LblRecordSIT_ItemID.Text.ToString());
            ssmInfoEdit.SAS_ASID = new Guid(LblRecordSAS_ASID.Text.ToString());
            ssmInfoEdit.SIT_Items = TxtSalaryItem.Text;
            decimal d;
            if (Decimal.TryParse(TxtInitialValue.Text, out d))
                ssmInfoEdit.SIT_InitialValue = d;
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入正确的初始值！')", true);
                return;
            }
            ssmInfoEdit.SIT_Formula = TxtFormula.Text;

            try
            {
                int i = sSML.Update_SalaryItemTable(ssmInfoEdit);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('该帐套中存在重复的工资项目名称！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            Panel_ItemMaintanance.Visible = false;
            UpdatePanel_ItemMaintanance.Update();
            BindGridForSalaryItem(" and SAS_ASID='" + new Guid(LblRecordSAS_ASID.Text) + "'");
            UpdatePanel_SalaryItemMaintanance.Update();
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);
        }


    }//工资项目新增/编辑的“提交”

    protected void BtnCancel_ItemMaintanancee_Click(object sender, EventArgs e)
    {
        ClearSalaryItem();
        Panel_ItemMaintanance.Visible = false;
        if (Panel_ItemGridSelect.Visible == true)
        {
            Panel_ItemGridSelect.Visible = false;
            UpdatePanel_ItemGridSelect.Update();
        }
        if (Panel_EditFormula.Visible == true)
        {
            Panel_EditFormula.Visible = false;
            UpdatePanel_EditFormula.Update();
        }
    }//工资项目新增/编辑的“取消”

    private void ClearSalaryItem()
    {
        TxtSalaryItem.Text = "";
        TxtInitialValue.Text = "0";
        TxtFormula.Text = "";
    }//清除工资项目新增/编辑中的工资项目、初始值和计算公式
    #endregion

    #region//您当前是为XXXX选择工资项目
    protected void BtnItemSearch_Click(object sender, EventArgs e)
    {
        BindGridForSalaryItemAll(new Guid(LblRecordSAS_ASID.Text));
        LblRecordIsSearch3.Text = "检索后";
        UpdatePanel_ItemGridSelect.Update();
    }//您当前是为XXXX选择工资项目的“检索”

    protected void BtnItemReset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        BindGridForSalaryItemAll(new Guid(LblRecordSAS_ASID.Text));
        UpdatePanel_ItemGridSelect.Update();

    }//您当前是为XXXX选择工资项目的“重置”


    protected void BtnCancelItem_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        LblRecordIsSearch3.Text = "检索前";
        Panel_ItemGridSelect.Visible = false;
        UpdatePanel_ItemGridSelect.Update();
    }//您当前是为XXXX选择工资项目的“取消”
    #endregion

    #region//GridView_SalaryItemAll的自带事件
    protected void GridView_SalaryItemAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ////每个单元格的Tooltip
        //for (int i = 0; i < GridView_SalaryItemAll.Rows.Count; i++)
        //{
        //    for (int j = 0; j < GridView_SalaryItemAll.Rows[i].Cells.Count; j++)
        //    {
        //        GridView_SalaryItemAll.Rows[i].Cells[j].ToolTip = GridView_SalaryItemAll.Rows[i].Cells[j].Text;

        //    }
        //}
    }

    protected void GridView_SalaryItemAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView_SalaryItemAll.BottomPagerRow;


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
        //if (LblRecordIsSearch3.Text == "检索前")
        BindGridForSalaryItemAll(new Guid(LblRecordSAS_ASID.Text));
        //if (LblRecordIsSearch3.Text == "检索后")
        //    BindGridForSalaryItemAll(" and SIT_Items like '%" + TextBox1.Text + "%'");

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView_SalaryItemAll.PageCount ? this.GridView_SalaryItemAll.PageCount - 1 : newPageIndex;
        this.GridView_SalaryItemAll.PageIndex = newPageIndex;
        this.GridView_SalaryItemAll.DataBind();
    }//翻页

    protected void GridView_SalaryItemAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            try
            {
                LbLblRecordSIT_ItemID2.Text = e.CommandArgument.ToString();
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                int i = drv.RowIndex;
                TxtSalaryItem.Text = GridView_SalaryItemAll.Rows[i].Cells[0].Text;
                Panel_ItemGridSelect.Visible = false;
                UpdatePanel_ItemGridSelect.Update();
                UpdatePanel_ItemMaintanance.Update();
                if (Panel_EditFormula.Visible == true)
                {
                    Panel_EditFormula.Visible = false;
                    UpdatePanel_EditFormula.Update();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }//表中的选择
    #endregion

    #region//公式编辑器
    private int GetCountByChar(string str1, char ch)
    {
        int count = 0;
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] == ch)
            {
                count++;
            }
        }
        return count;
    }//自定义根据字符查找该字符出现的次数

    protected void Button2_Click(object sender, EventArgs e)
    {
        //基本格式的验证（但是存在某些特殊情况，使得错误的公式能逃过公式合法性的验证，此称为罪犯）
        if (TxtFormulaEdit.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('格式错误：请录入公式')", true);
            return;
        }
        string target = TxtFormulaEdit.Text;
        string[] Array = target.Split(new char[6] { '/', '*', '-', '+', '(', ')' });
        foreach (string item1 in Array)//判断是否有运算项为0
        {
            decimal d;
            if (decimal.TryParse(item1, out d))
            {
                if (d == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('0不能作为单独的运算项！')", true);
                    return;
                }
            }
            decimal k;
            if (!(decimal.TryParse(item1, out k)) && item1 != "")
            {
                if (!LbCanBeUsedItem.Items.Contains(LbCanBeUsedItem.Items.FindByText(item1)))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('非法的字段组合！')", true);
                    return;
                }
            }

        }

        if (target.Contains("."))//如果有小数点，则小数点一定要是decimal的组成部分
        {
            foreach (string item in Array)
            {

                if (item != "")
                {
                    if (!LbCanBeUsedItem.Items.Contains(LbCanBeUsedItem.Items.FindByText(item)))
                    {
                        decimal m;
                        if (!decimal.TryParse(item, out m))
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('.格式错误！')", true);
                            return;
                        }
                    }
                }
            }
        }

        if (target.Contains("(") || target.Contains(")"))//有括号时：1、括号要成对出现 2、“（”在“）”之前 3、最后一个“（”和第一个“）”中间有字段
        {
            if (GetCountByChar(target, '(') != GetCountByChar(target, ')'))//如果“（”与“）”出现的次数不相等
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('（）需要成对出现！')", true);
                return;
            }
            if (target.IndexOf('(') >= target.IndexOf(')'))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('括号格式错误！')", true);
                return;
            }
            if (target.IndexOf(')') - target.LastIndexOf('(') <= 1)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('格式错误！')", true);
                return;
            }
            else
            {
                string st = target.Substring(target.LastIndexOf('('), target.IndexOf(')') - target.LastIndexOf('('));
                string[] Array2 = st.Split(new char[6] { '/', '*', '-', '+', '(', ')' });//再次切割
                foreach (string item in Array2)
                {
                    decimal i;
                    if (!(decimal.TryParse(item, out i)) && item != "")
                    {
                        if (!LbCanBeUsedItem.Items.Contains(LbCanBeUsedItem.Items.FindByText(item)))
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('格式错误！')", true);
                            return;
                        }
                    }
                }

            }

        }
        else//没有括号时，运算符不能作为起始和结束符号，并且符号不能紧挨着使用
        {
            string[] Array3 = target.Split(new char[4] { '/', '*', '-', '+' });
            if (Array3.Contains(""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('运算符格式错误！')", true);
                return;
            }
        }

        //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('" + Array[2] + "')", true);

        string[] Array4 = target.Split(new char[4] { '/', '*', '-', '+' });
        if (Array4.Contains(""))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('运算符格式错误！')", true);
            return;
        }
        //捕捉罪犯（方法：以现在的公式进行一次计算，能计算出结果，则表示公式正确，否则错误）
        try
        {
            sSML.Update_YanZhengGongShi(new Guid(LblRecordSAS_ASID.Text), TxtFormulaEdit.Text);
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('公式错误！请核实：(1)格式有误;(2)分母可能为0')", true);
            return;
        }

        LblRecordIsCheckOK.Text = "true";
        str = TxtFormulaEdit.Text;
        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('格式正确！')", true);
    }//校验公式

    protected void Button3_Click(object sender, EventArgs e)
    {
        TxtFormulaEdit.Text = "";
    }//重置
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (LblRecordIsCheckOK.Text == "true" && str == TxtFormulaEdit.Text)//保证提交的时候一定经过了公式校验
        {
            TxtFormula.Text = TxtFormulaEdit.Text;
            Panel_EditFormula.Visible = false;
            UpdatePanel_EditFormula.Update();
            UpdatePanel_ItemMaintanance.Update();
        }
        else
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请先校验公式，且格式正确才能进行提交！')", true);
    }//提交
    protected void Button6_Click(object sender, EventArgs e)
    {
        Panel_EditFormula.Visible = false;
        UpdatePanel_EditFormula.Update();
    }//取消
    #endregion

    #region//所有的GridView的Tooltip
    protected void Grid_Set_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Set.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Set.Rows[i].Cells.Count; j++)
            {
                Grid_Set.Rows[i].Cells[j].ToolTip = Grid_Set.Rows[i].Cells[j].Text;
                if (Grid_Set.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Set.Rows[i].Cells[j].Text = Grid_Set.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;
                if (GridView1.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_SalaryItemAll_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_SalaryItemAll.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_SalaryItemAll.Rows[i].Cells.Count; j++)
            {
                GridView_SalaryItemAll.Rows[i].Cells[j].ToolTip = GridView_SalaryItemAll.Rows[i].Cells[j].Text;
                if (GridView_SalaryItemAll.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_SalaryItemAll.Rows[i].Cells[j].Text = GridView_SalaryItemAll.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
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
    }
    protected void GridViewAdd_DataBound(object sender, EventArgs e)
    {

    }//因为GridViewAdd的人事档案ID是在客户端隐藏，如果此处使用Tooltip将使得ID的长度为15位+...的格式，而无法
    //转换成Guid
    #endregion



}