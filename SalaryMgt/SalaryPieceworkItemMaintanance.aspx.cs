using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalaryMgt_SalaryPieceworkItemMaintanance : System.Web.UI.Page
{
    SalaryPieceworkItemMaintananceL sPIML = new SalaryPieceworkItemMaintananceL();
    SalaryPieceworkItemMaintananceInfo sPIMInfo = new SalaryPieceworkItemMaintananceInfo();
    SalaryTimeItemMaintananceL sTIML = new SalaryTimeItemMaintananceL();//计件项目与计时项目共用绑定工序函数
    private static string condition;
    private static string condition2;
    private static Guid id;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindGridPieceworkItem("");
            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    this.Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (this.Lab_Status.Text == "Piecework" && Session["UserRole"].ToString().Contains("计件项目维护"))
                {
                    this.Title = "计件项目维护";
                }
                if (this.Lab_Status.Text == "PieceworkLook" && Session["UserRole"].ToString().Contains("计件项目查看"))
                {
                    this.Title = "计件项目查看";
                    Btn_New_PieceworkItem.Visible = false;
                    Grid_PieceworkItem.Columns[7].Visible = false;
                    Grid_PieceworkItem.Columns[8].Visible = false;
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");

            }
        }
    }

    private void BindGridPieceworkItem(string constr)
    {
        Grid_PieceworkItem.DataSource = sPIML.SearchByCondition_SalaryPieceworkItem(constr);
        Grid_PieceworkItem.DataBind();
    }//绑定计件项目列表中的Gridview,允许多次调用

    private void HistoryBindGrid(Guid guid)
    {
        GridView_TimeItemHistory.DataSource = sPIML.SearchSalaryPieceItemChangeRecord(guid);
        GridView_TimeItemHistory.DataBind();
    }//绑定历史计时工价Gridview的方法，允许多次调用

    #region//计件项目检索栏
    protected void Btn_Search_PieceworkItem_Click(object sender, EventArgs e)
    {
        condition = TxtSCraft.Text == "" ? "" : " and b.PBC_Name like '%" + TxtSCraft.Text.Trim() + "%' ";
        condition += TxtSProType.Text == "" ? "" : " and SPS_Name like '%" + TxtSProType.Text.Trim() + "%' ";
        condition += TxtSUnitPrice.Text == "" ? "" : " and a.SPI_UnitPrice ='" + TxtSUnitPrice.Text.Trim() + "' ";
        condition += TxtItemName.Text.Trim() == "" ? "" : " and SPI_Name ='" + TxtItemName.Text.Trim() + "' ";
        BindGridPieceworkItem(condition);
        LblRecordIsSearch.Text = "检索后";
        this.Grid_PieceworkItem.SelectedIndex = -1;
        UpdatePanel_PieceworkItemSecrch.Update();
        UpdatePanel_PieceworkItemGrid.Update();
    }//计件项目检索栏 “检索”

    protected void Btn_Reset_Click(object sender, EventArgs e)
    {
        TxtSCraft.Text = "";
        TxtSProType.Text = "";
        TxtSUnitPrice.Text = "";
        BindGridPieceworkItem("");
        TxtItemName.Text = "";
        LblRecordIsSearch.Text = "检索前";
        this.Grid_PieceworkItem.SelectedIndex = -1;
        UpdatePanel_PieceworkItemSecrch.Update();
        UpdatePanel_PieceworkItemGrid.Update();
    }//计件项目检索栏 “重置”

    protected void Btn_New_PieceworkItem_Click(object sender, EventArgs e)
    {
        Panel_PieceworkItem.Visible = true;
        UpdatePanel_PieceworkItem.Update();
        LabelExecDate.Visible = false;
        TextBox_Execdate.Visible = false;
        CbIsRecord.Visible = false;
        TextBox_Execdate.Text = "";
        CbIsRecord.Checked = false;
        BindDdlCraft();
        ClearItem();
        LblAddOrEdit.Text = "新增";
    }//计件项目检索栏的“新增计件项目”
    #endregion


    #region//Grid_PieceworkItem的内置事件

    protected void Grid_PieceworkItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (e.CommandName == "Maintance_PieceworkItem")
        {
            try
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                this.Grid_PieceworkItem.SelectedIndex = row.RowIndex;
                Panel_PieceworkItem.Visible = true;
                ClearItem();

                LabelExecDate.Visible = true;
                TextBox_Execdate.Visible = true;
                TextBox_Execdate.Text = "";
                CbIsRecord.Visible = true;
                CbIsRecord.Checked = false;

                LblAddOrEdit.Text = "编辑";
                LblRecordSPI_ID.Text = StrArgument[0].ToString();
                LblRecordProTypeID.Text = StrArgument[2];
                LblRecordFormerPrice.Text = StrArgument[6];
                ////为Dropdownlist绑定值，否则会出错
                BindDdlCraft();
                id = new Guid(LblRecordSPI_ID.Text);
                //SalaryPieceworkItemMaintananceInfo sPIMI = sPIML.SearchByID_SalaryPieceworkItem(id)[0];
                DdlCraft.Items.FindByValue(StrArgument[1].ToString()).Selected = true;
                TxtItemNameEdit.Text = StrArgument[5].ToString();
                TxtProType.Text = StrArgument[4];
                TxtUnitPrice.Text = StrArgument[6];
                this.UpdatePanel_PieceworkItem.Update();
            }
            catch (Exception)
            {

                throw;
            }


        }
        if (e.CommandName == "Delete_PieceworkItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.Grid_PieceworkItem.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            sPIML.Delete_SalaryPieceworkItem(guid);
            if (LblRecordIsSearch.Text == "检索前")
                BindGridPieceworkItem("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGridPieceworkItem(condition);
            UpdatePanel_PieceworkItemGrid.Update();
        }

        if (e.CommandName == "Maintance_TimeItemHistory")
        {
            try
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                this.Grid_PieceworkItem.SelectedIndex = row.RowIndex;
                Panel_TimItemHistory.Visible = true;
                string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
                CraftName.Text = str[4].ToString();
                TimeName.Text = str[5].ToString();
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
    }
    protected void Grid_PieceworkItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_PieceworkItem.BottomPagerRow;


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
            BindGridPieceworkItem("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridPieceworkItem(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_PieceworkItem.PageCount ? this.Grid_PieceworkItem.PageCount - 1 : newPageIndex;
        this.Grid_PieceworkItem.PageIndex = newPageIndex;
        this.Grid_PieceworkItem.PageIndex = newPageIndex;
        this.Grid_PieceworkItem.DataBind();
    }
    protected void Grid_PieceworkItem_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_PieceworkItem.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_PieceworkItem.Rows[i].Cells.Count; j++)
            {
                Grid_PieceworkItem.Rows[i].Cells[j].ToolTip = Grid_PieceworkItem.Rows[i].Cells[j].Text;
                if (Grid_PieceworkItem.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_PieceworkItem.Rows[i].Cells[j].Text = Grid_PieceworkItem.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    #endregion

    #region//计件项目XX
    private void BindDdlCraft()
    {
        DdlCraft.DataSource = sTIML.SearchCraftForDdl_SalaryTimeItem();
        DdlCraft.DataTextField = "PBC_Name";
        DdlCraft.DataValueField = "PBC_ID";
        DdlCraft.DataBind();
        DdlCraft.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定工序DdlCraft

    private void ClearItem()
    {
        DdlCraft.ClearSelection();
        TxtProType.Text = "";
        TxtUnitPrice.Text = "";
        TxtItemNameEdit.Text = "";
    }//清空 计件项目XX

    protected void BtnChoose_Click(object sender, EventArgs e)
    {
        Panel_ProTypeChoose.Visible = true;
        UpdatePanel_ProTypeChoose.Update();
        BindGridProTypeChoose("");
    }//计件项目XX “选择...”


    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (LblAddOrEdit.Text == "新增")
        {
            if (DdlCraft.Text == "" || TxtProType.Text == "" || TxtUnitPrice.Text == "" || TxtItemNameEdit.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                sPIMInfo.SPI_ID = new Guid();
                sPIMInfo.SPS_ID = new Guid(LblRecordProTypeID.Text);
                sPIMInfo.PBC_ID = new Guid(DdlCraft.SelectedValue.ToString());
                decimal d1;
                if (decimal.TryParse(TxtUnitPrice.Text, out d1))
                    sPIMInfo.SPI_UnitPrice = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入合法的单价！')", true);
                    return;
                }
                sPIMInfo.SPI_IsDeleted = false;
                sPIMInfo.SPI_Name = TxtItemNameEdit.Text;
                int i = sPIML.Insert_SalaryPieceworkItem(sPIMInfo);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('存在重复，请核实！')", true);
                    return;
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增成功！')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败！" + ex.ToString() + "')", true);
            }
            Panel_PieceworkItem.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGridPieceworkItem("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGridPieceworkItem(condition);
            UpdatePanel_PieceworkItem.Update();
            UpdatePanel_PieceworkItemGrid.Update();
        }
        if (LblAddOrEdit.Text == "编辑")
        {
            if (DdlCraft.Text == "" || TxtProType.Text == "" || TxtUnitPrice.Text == "" || TxtItemNameEdit.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                if (!CbIsRecord.Checked)
                {
                    SalaryPieceworkItemMaintananceInfo sPIMInfo2 = new SalaryPieceworkItemMaintananceInfo();
                    sPIMInfo2.SPI_ID = new Guid(LblRecordSPI_ID.Text);
                    sPIMInfo2.PBC_ID = new Guid(DdlCraft.SelectedValue.ToString());
                    sPIMInfo2.SPS_ID = new Guid(LblRecordProTypeID.Text);
                    sPIMInfo2.SPI_Name = TxtItemNameEdit.Text;
                    decimal d2;
                    if (decimal.TryParse(TxtUnitPrice.Text, out d2))
                        sPIMInfo2.SPI_UnitPrice = d2;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入合法的单价！')", true);
                        return;
                    }
                    int i = sPIML.Update_SalaryPieceworkItem(sPIMInfo2);
                    if (i <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('存在重复，请核实！')", true);
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
                    SalaryPieceworkItemMaintananceInfo sPIMInfo3 = new SalaryPieceworkItemMaintananceInfo();
                    sPIMInfo3.SPI_ID = new Guid(LblRecordSPI_ID.Text);
                    sPIMInfo3.PBC_ID = new Guid(DdlCraft.SelectedValue.ToString());
                    sPIMInfo3.SPS_ID = new Guid(LblRecordProTypeID.Text);
                    sPIMInfo3.SPI_Name = TxtItemNameEdit.Text;
                    decimal d2;
                    if (decimal.TryParse(TxtUnitPrice.Text, out d2))
                    {
                        sPIMInfo3.SPI_UnitPrice = d2;
                        sPIMInfo3.SPICR_NewPrice = d2;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入合法的单价！')", true);
                        return;
                    }

                    sPIMInfo3.SPICR_FormerPrice = Convert.ToDecimal(LblRecordFormerPrice.Text);


                    sPIMInfo3.SPICR_OpPerson = Session["UserName"].ToString().Trim();
                    DateTime d;
                    if (DateTime.TryParse(TextBox_Execdate.Text, out d))
                        sPIMInfo3.SPICR_ExecDate = d;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('执行日期不合法！')", true);
                        return;
                    }
                    int i = sPIML.Update_SalaryPieceworkItem(sPIMInfo3);
                    if (i <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('存在重复，请核实！')", true);
                        return;
                    }
                    else
                    {
                        sPIML.Insert_SalaryPieceItemChangeRecord(sPIMInfo3);
                        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('工价更改成功！')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑失败！" + ex.ToString() + "')", true);
            }
            Panel_PieceworkItem.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGridPieceworkItem("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGridPieceworkItem(condition);
            UpdatePanel_PieceworkItem.Update();
            UpdatePanel_PieceworkItemGrid.Update();
        }


    }//计件项目XX “提交”

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel_PieceworkItem.Visible = false;
        UpdatePanel_PieceworkItem.Update();
        if (Panel_ProTypeChoose.Visible)
        {
            Panel_ProTypeChoose.Visible = false;
            UpdatePanel_ProTypeChoose.Update();
        }
    }//计件项目XX “取消”
    #endregion


    private void BindGridProTypeChoose(string constr)
    {
        GridView__ProTypeChoose.DataSource = sPIML.SearchByCondition_QZL_ProType(constr);
        GridView__ProTypeChoose.DataBind();
    }//绑定计件项目列表中的Gridview,允许多次调用



    protected void BtnCSearch_Click(object sender, EventArgs e)
    {
        condition2 = TxtCProType.Text == "" ? "" : " and SPS_Name like '%" + TxtCProType.Text.Trim() + "%' ";
        BindGridProTypeChoose(condition2);
        LblRecordIsCSearch.Text = "检索后";
        this.GridView__ProTypeChoose.SelectedIndex = -1;
        UpdatePanel_ProTypeChoose.Update();
    }//产品型号检索栏  “检索”

    protected void BtnCReset_Click1(object sender, EventArgs e)
    {
        TxtCProType.Text = "";
        BindGridProTypeChoose("");
    }//产品型号检索栏   “重置”

    protected void BtnCCancel_Click1(object sender, EventArgs e)
    {
        Panel_ProTypeChoose.Visible = false;
        UpdatePanel_ProTypeChoose.Update();
        TxtCProType.Text = "";
    }//产品型号检索栏   “取消”


    #region//GridView__ProTypeChoose的事件
    protected void GridView__ProTypeChoose_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView__ProTypeChoose.BottomPagerRow;


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
        if (LblRecordIsCSearch.Text == "检索前")
            BindGridProTypeChoose("");
        if (LblRecordIsCSearch.Text == "检索后")
            BindGridProTypeChoose(condition2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView__ProTypeChoose.PageCount ? this.GridView__ProTypeChoose.PageCount - 1 : newPageIndex;
        this.GridView__ProTypeChoose.PageIndex = newPageIndex;
        this.GridView__ProTypeChoose.PageIndex = newPageIndex;
        this.GridView__ProTypeChoose.DataBind();
    }
    protected void GridView__ProTypeChoose_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Maintance_Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.GridView__ProTypeChoose.SelectedIndex = -1;
            if (Panel_PieceworkItem.Visible == false)
            {
                Panel_PieceworkItem.Visible = true;
                UpdatePanel_PieceworkItem.Update();
            }
            TxtProType.Text = row.Cells[1].Text;
            LblRecordProTypeID.Text = e.CommandArgument.ToString();
            Panel_ProTypeChoose.Visible = false;
            UpdatePanel_ProTypeChoose.Update();
            UpdatePanel_PieceworkItem.Update();
        }
    }
    #endregion

    protected void btnHistoryClose_Click(object sender, EventArgs e)
    {
        Panel_TimItemHistory.Visible = false;
        UpdatePanel_TimeItemHistoryGridView.Update();
    }
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
}