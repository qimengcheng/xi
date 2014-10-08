using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalaryMgt_SalaryTimeItemMaintanance : System.Web.UI.Page
{
    SalaryTimeItemMaintananceInfo sTIMInfo = new SalaryTimeItemMaintananceInfo();
    SalaryTimeItemMaintananceL sTIML = new SalaryTimeItemMaintananceL();
    private static string condition;
    private static Guid id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid("");
            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    this.Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (this.Lab_Status.Text == "Time" && Session["UserRole"].ToString().Contains("计时项目维护"))
                {
                    this.Title = "计时项目维护";
                }
                if (this.Lab_Status.Text == "TimeLook" && Session["UserRole"].ToString().Contains("计时项目查看"))
                {
                    this.Title = "计时项目查看";
                    Btn_New_TimeItem.Visible = false;
                    Grid_TimeItem.Columns[5].Visible = false;
                    Grid_TimeItem.Columns[6].Visible = false;
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");

            }
        }
    }

    private void BindGrid(string con)
    {
        Grid_TimeItem.DataSource = sTIML.SearchByCondition_SalaryTimeItem(con);
        Grid_TimeItem.DataBind();
    }//绑定Gridview的方法，允许多次调用

    private void HistoryBindGrid(Guid guid)
    {
        GridView_TimeItemHistory.DataSource = sTIML.Search_SalaryTimeItemHistory(guid);
        GridView_TimeItemHistory.DataBind();
    }//绑定历史计时工价Gridview的方法，允许多次调用

    protected void Btn_Search_TimeItem_Click(object sender, EventArgs e)
    {
        condition = TxtSCraft.Text == "" ? "" : " and b.PBC_Name like '%" + TxtSCraft.Text.Trim() + "%' ";
        condition += TxtSName.Text == "" ? "" : " and a.STI_Name like '%" + TxtSName.Text.Trim() + "%' ";
        condition += TxtSUnitPrice.Text == "" ? "" : " and a.STI_UnitPrice ='" + TxtSUnitPrice.Text.Trim() + "' ";
        BindGrid(condition);
        LblRecordIsSearch.Text = "检索后";
        this.Grid_TimeItem.SelectedIndex = -1;
        UpdatePanel_TimeItemSecrch.Update();
        UpdatePanel_TimeItemGrid.Update();
    }//计时项目检索栏的“检索”

    protected void Btn_Reset_Click(object sender, EventArgs e)
    {
        TxtSCraft.Text = "";
        TxtSName.Text = "";
        TxtSUnitPrice.Text = "";
        BindGrid("");
        LblRecordIsSearch.Text = "检索前";
        this.Grid_TimeItem.SelectedIndex = -1;
        UpdatePanel_TimeItemGrid.Update();
    }//计时项目检索栏的“重置”

    protected void Btn_New_TimeItem_Click(object sender, EventArgs e)
    {
        Panel_Maintanace.Visible = true;
        LblAddOrEdit.Text = "新增";
        LabelExecDate.Visible = false;
        TextBox_Execdate.Visible = false;
        CbIsRecord.Visible = false;
        TextBox_Execdate.Text = "";
        CbIsRecord.Checked = false;
        Clear();
        BindDdlCraft();
        UpdatePanel_Maintanace.Update();
    }//计时项目检索栏的“新增计时项目”

    private void Clear()
    {
        DdlCraft.ClearSelection();
        TxtName.Text = "";
        TxtUnitPrice.Text = "";
        TextBox_Execdate.Text = "";
    }//清除计时项目中的值

    private void BindDdlCraft()
    {
        DdlCraft.DataSource = sTIML.SearchCraftForDdl_SalaryTimeItem();
        DdlCraft.DataTextField = "PBC_Name";
        DdlCraft.DataValueField = "PBC_ID";
        DdlCraft.DataBind();
        DdlCraft.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定工序DdlCraft

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (LblAddOrEdit.Text == "新增")
        {
            if (DdlCraft.Text == "" || TxtName.Text == "" || TxtUnitPrice.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                sTIMInfo.STI_ID = new Guid();
                sTIMInfo.PBC_ID = new Guid(DdlCraft.SelectedValue.ToString());
                sTIMInfo.STI_Name = TxtName.Text;
                decimal d1;
                if (decimal.TryParse(TxtUnitPrice.Text, out d1))
                    sTIMInfo.STI_UnitPrice = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入合法的单价！')", true);
                    return;
                }
                sTIMInfo.STI_IsDeleted = false;
                int i = sTIML.Insert_SalaryTimeItem(sTIMInfo);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('同一工序下存在相同的计时名称，请核实！')", true);
                    return;
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增成功！')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败！" + ex.ToString() + "')", true);
            }
            Panel_Maintanace.Visible = false;
            BindGrid("");

            UpdatePanel_Maintanace.Update();
            UpdatePanel_TimeItemGrid.Update();
        }
        if (LblAddOrEdit.Text == "编辑")
        {
            if (DdlCraft.Text == "" || TxtName.Text == "" || TxtUnitPrice.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                if (!CbIsRecord.Checked)
                {
                    SalaryTimeItemMaintananceInfo sTIMInfoEdit = new SalaryTimeItemMaintananceInfo();
                    sTIMInfoEdit.STI_ID = new Guid(LblRecordSTI_ID.Text);
                    sTIMInfoEdit.PBC_ID = new Guid(DdlCraft.SelectedValue.ToString());
                    sTIMInfoEdit.STI_Name = TxtName.Text;
                    decimal d2;
                    if (decimal.TryParse(TxtUnitPrice.Text, out d2))
                        sTIMInfoEdit.STI_UnitPrice = d2;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入合法的单价！')", true);
                        return;
                    }
                    int i = sTIML.Update_SalaryTimeItem(sTIMInfoEdit);
                    if (i <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('同一工序下存在相同的计时名称，请核实！')", true);
                        return;
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);
                }
                else 
                {
                    if (TextBox_Execdate.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入执行日期')", true);
                        return;
                    }
                    SalaryTimeItemMaintananceInfo sTIMInfoEdit2 = new SalaryTimeItemMaintananceInfo();
                    sTIMInfoEdit2.STI_ID = new Guid(LblRecordSTI_ID.Text);
                    sTIMInfoEdit2.PBC_ID = new Guid(DdlCraft.SelectedValue.ToString());
                    sTIMInfoEdit2.STI_Name = TxtName.Text;


                    SalaryTimeItemChangeRecordInfo sTICRInfoEdit = new SalaryTimeItemChangeRecordInfo();
                    sTICRInfoEdit.STI_ID = new Guid(LblRecordSTI_ID.Text);
                    sTICRInfoEdit.STICR_FormerPrice = Convert.ToDecimal(LblRecordFormerPrice.Text);
                    sTICRInfoEdit.STICR_NewPrice = Convert.ToDecimal(TxtUnitPrice.Text);
                    sTICRInfoEdit.STICR_OpPerson = Session["UserName"].ToString().Trim();
                    sTICRInfoEdit.STICR_ExecDate = Convert.ToDateTime(TextBox_Execdate.Text);
                    decimal d1;
                    if (decimal.TryParse(LblRecordFormerPrice.Text, out d1))
                        sTICRInfoEdit.STICR_FormerPrice = d1;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('原单价不合法，禁止编辑！')", true);
                        return;
                    }
                    decimal d2;
                    if (decimal.TryParse(TxtUnitPrice.Text, out d2))
                    {
                        sTICRInfoEdit.STICR_NewPrice = d2;
                        sTIMInfoEdit2.STI_UnitPrice = d2;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入合法的单价')", true);
                        return;
                    }
                    DateTime d3;
                    if (DateTime.TryParse(TextBox_Execdate.Text, out d3))
                        sTICRInfoEdit.STICR_ExecDate = d3;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入合法的执行日期')", true);
                        return;
                    }
                    
                    int j=sTIML.Update_SalaryTimeItem(sTIMInfoEdit2);
                    if (j <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('同一工序下存在相同的计时名称，请核实！')", true);
                        return;
                    }

                    else
                    {
                        sTIML.Insert_SalaryTimeItemRecord(sTICRInfoEdit);
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('工价更改成功！')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑失败！" + ex.ToString() + "')", true);
            }
            Panel_Maintanace.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(condition);
            UpdatePanel_Maintanace.Update();
            UpdatePanel_TimeItemGrid.Update();
        }

    }//计时项目"提交"
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel_Maintanace.Visible = false;
        UpdatePanel_Maintanace.Update();
    }//计时项目"取消"

    #region//Grid_TimeItem的事件
    protected void Grid_TimeItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Maintance_TimeItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.Grid_TimeItem.SelectedIndex = row.RowIndex;
            Panel_Maintanace.Visible = true;
            Clear();

            this.Panel_TimeItemGrid.Visible = true;
            LabelExecDate.Visible = true;
            TextBox_Execdate.Visible = true;
            TextBox_Execdate.Text = "";
            CbIsRecord.Visible = true;
            CbIsRecord.Checked = false;
            LblAddOrEdit.Text = "编辑";

            LblRecordSTI_ID.Text = e.CommandArgument.ToString();
            ////为Dropdownlist绑定值，否则会出错
            BindDdlCraft();
            id = new Guid(LblRecordSTI_ID.Text);

            SalaryTimeItemMaintananceInfo hR2 = sTIML.SearchByID_SalaryTimeItem(id)[0];
            DdlCraft.Items.FindByValue(hR2.PBC_ID.ToString()).Selected = true;
            TxtName.Text = hR2.STI_Name;
            TxtUnitPrice.Text = hR2.STI_UnitPrice.ToString();
            LblRecordFormerPrice.Text = hR2.STI_UnitPrice.ToString();
            this.UpdatePanel_Maintanace.Update();

        }
        if (e.CommandName == "Delete_TimeItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.Grid_TimeItem.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            sTIML.Delete_SalaryTimeItem(guid);
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(condition);
            UpdatePanel_TimeItemGrid.Update();
        }

        if (e.CommandName == "Maintance_TimeItemHistory")
        {
            try
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                this.Grid_TimeItem.SelectedIndex = row.RowIndex;
                Panel_TimItemHistory.Visible = true;
                this.Panel_TimeItemGrid.Visible = true;
                string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
                CraftName.Text = str[1].ToString();
                TimeName.Text = str[2].ToString();
                guidText.Text = str[0].ToString();
                Guid guid = new Guid(guidText.Text);
                HistoryBindGrid(guid);
                UpdatePanel_TimeItemHistoryGridView.Update();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }//Grid_TimeItem中的“编辑”“删除” “查看历史工价”

    protected void Grid_TimeItem_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_TimeItem.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_TimeItem.Rows[i].Cells.Count; j++)
            {
                Grid_TimeItem.Rows[i].Cells[j].ToolTip = Grid_TimeItem.Rows[i].Cells[j].Text;
                if (Grid_TimeItem.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_TimeItem.Rows[i].Cells[j].Text = Grid_TimeItem.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }//Grid_TimeItem的Tooltip

    protected void Grid_TimeItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_TimeItem.BottomPagerRow;


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
            BindGrid("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGrid(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_TimeItem.PageCount ? this.Grid_TimeItem.PageCount - 1 : newPageIndex;
        this.Grid_TimeItem.PageIndex = newPageIndex;
        this.Grid_TimeItem.PageIndex = newPageIndex;
        this.Grid_TimeItem.DataBind();
    }//Grid_TimeItem的翻页

    protected void GridView_TimeItemHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView_TimeItemHistory.BottomPagerRow;


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
        Guid guid = new Guid(guidText.Text);
        HistoryBindGrid(guid);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView_TimeItemHistory.PageCount ? this.GridView_TimeItemHistory.PageCount - 1 : newPageIndex;
        this.GridView_TimeItemHistory.PageIndex = newPageIndex;
        this.GridView_TimeItemHistory.DataBind();
    }
    #endregion
    protected void btnHistoryClose_Click(object sender, EventArgs e)
    {
        Panel_TimItemHistory.Visible = false;
        UpdatePanel_TimeItemHistoryGridView.Update();
    }
}