using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HSFMgt_HSFBasicDataMgt : Page
{
    HSFBasicDataL hSFBasicDataL = new HSFBasicDataL();
    HSFContrItemsInfo hSFContrItemsInfo = new HSFContrItemsInfo();
    HSFReskLevelInfo hSFReskLevelInfo = new HSFReskLevelInfo();
    static Guid idI = new Guid();
    static Guid idR = new Guid();
    static Guid idM = new Guid();
    static string Bindc1 = "", Bindc2 = "",BindcR="",BindcM1="",BindcM2="";//记录检索栏检索条件用于绑定gridview数据

    #region 页面加载
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridviewRisk(BindcR);
        BindGridview(Bindc1, Bindc2);
        string Role = Request.QueryString["state"].ToString();
        if (!Page.IsPostBack)
        {
            if (!((Session["UserRole"].ToString().Contains("管制项目维护")) || (Session["UserRole"].ToString().Contains("管制项目查看"))))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        if (Role == "Item" && Session["UserRole"].ToString().Contains("管制项目维护"))
        {
            Title = "有毒物质基础数据维护";
        }
        else if (Role == "Item" && Session["UserRole"].ToString().Contains("管制项目查看"))
        {
            Title = "有毒物质基础数据维护";
            BtnNewItems.Visible = false;
            Grid_ControlItems.Columns[6].Visible = false;
            Grid_ControlItems.Columns[7].Visible = false;
        }
        else
        {
            Panel_SearchItems.Visible = false;
            Panel_GridViewItem.Visible = false;
        }
        if (Role == "Item" && Session["UserRole"].ToString().Contains("风险等级维护"))
        {
            Title = "有毒物质基础数据维护";
        }
        else if (Role == "Item" && Session["UserRole"].ToString().Contains("风险等级查看"))
        {
            BtnNewRisk.Visible = false;
            Grid_Risk.Columns[2].Visible = false;
            Grid_Material.Columns[4].Visible = false;
            Grid_Material.Columns[5].Visible = false;
        }
        else
        {
            Panel_RiskLevel.Visible = false;
            Panel_GridRisk.Visible = false;
        }
    }
    #endregion

    #region 管制项目检索栏
    //检索栏检索按钮
    protected void BtnSearchItems_Click(object sender, EventArgs e)
    {
        Bindc1 = TxtItemName.Text;
        Bindc2 = TextBoundary.Text;
        BindGridview(Bindc1, Bindc2);
        UpdatePanel_GridViewItem.Update();
    }

    //检索栏新增按钮
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        Clear();
        LblControlItem.Text = "新建管制项目";
        Panel_NewControlItem.Visible = true;
        UpdatePanel_NewControlItem.Update();
        LblState.Text = "New";
    }

    //重置
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TxtItemName.Text = "";
        TextBoundary.Text = "";
        UpdatePanel_SearchItems.Update();
        Bindc2 = Bindc1 = "";
        BindGridview(Bindc1, Bindc2);
        UpdatePanel_GridViewItem.Update();
    }
    #endregion

    #region 管制项目维护窗口
    //维护窗口提交按钮
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (LblState.Text == "New")
        {

            if (TxtNewItemName.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制项目！')", true);
                return;
            }
            else
                hSFContrItemsInfo.HSFCI_ItemName = TxtNewItemName.Text;
            if (TextNewBoundary.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制对象范围！')", true);
                return;
            }
            else
                hSFContrItemsInfo.HSFCI_Boundary = TextNewBoundary.Text;
            if (TextNewPeriod.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制周期！')", true);
                return;
            }
            else
                hSFContrItemsInfo.HSFCI_Period =Convert.ToInt16( TextNewPeriod.Text);
            if (TextNewRemindDay.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入提前报警时限！')", true);
                return;
            }
            else
                hSFContrItemsInfo.HSFCI_RemindDay = Convert.ToInt16(TextNewRemindDay.Text);
            if (TextNewStandard.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制标准！')", true);
                return;
            }
            else
                hSFContrItemsInfo.HSFCI_Standard = TextNewStandard.Text;
            try
            {
                if (hSFBasicDataL.Insert_HSFContrItems(hSFContrItemsInfo) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该管制项目已经存在！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            Clear();
            Bindc1 = Bindc2 = "";
            BindGridview(Bindc1, Bindc2);
            Panel_NewControlItem.Visible = false;
            UpdatePanel_NewControlItem.Update();
            UpdatePanel_GridViewItem.Update();

        }
        else if (LblState.Text == "Edit")
        {
            HSFContrItemsInfo HSF = new HSFContrItemsInfo();
            HSF.HSFCI_ItemID = idI;
            if (TxtNewItemName.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制项目！')", true);
                return;
            }
            else
                HSF.HSFCI_ItemName = TxtNewItemName.Text;
            if (TextNewBoundary.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制对象范围！')", true);
                return;
            }
            else
                HSF.HSFCI_Boundary = TextNewBoundary.Text;
            if (TextNewPeriod.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制周期！')", true);
                return;
            }
            else
                HSF.HSFCI_Period = Convert.ToInt16(TextNewPeriod.Text);
            if (TextNewRemindDay.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入提前报警时限！')", true);
                return;
            }
            else
                HSF.HSFCI_RemindDay = Convert.ToInt16(TextNewRemindDay.Text);
            if (TextNewStandard.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入管制标准！')", true);
                return;
            }
            else
                HSF.HSFCI_Standard = TextNewStandard.Text;
            try
            {
                if (hSFBasicDataL.Update_HSFContrItems(HSF) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该管制项目已经存在！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('修改成功！')", true);
            Clear();
            Bindc1 = Bindc2 = "";
            BindGridview(Bindc1, Bindc2);
            Panel_NewControlItem.Visible = false;
            UpdatePanel_NewControlItem.Update();
            UpdatePanel_GridViewItem.Update();
        }

    }

    //维护窗口关闭按钮
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        if (Panel_NewControlItem.Visible)
        {
            Panel_NewControlItem.Visible = false;
        }
    }
    #endregion

    #region 管制项目GridView
    //操作Gridview的命令行
    protected void Grid_ControlItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_ControlItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ControlItems.SelectedIndex = row.RowIndex;
            Panel_NewControlItem.Visible = true;
            UpdatePanel_NewControlItem.Update();
            LblState.Text = "Edit";
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            //this.Grid_BDOrgSheet_1.Rows[gvr.RowIndex].BackColor = System.Drawing.Color.SkyBlue;
            //Session["index"] = gvr.RowIndex;
            idI = new Guid(e.CommandArgument.ToString());
            HSFContrItemsInfo HSF = hSFBasicDataL.Search_HSFContrItems_ID(idI)[0];
            LblControlItem.Text = HSF.HSFCI_ItemName + " 编辑";
            TxtNewItemName.Text = HSF.HSFCI_ItemName;
            TextNewBoundary.Text = HSF.HSFCI_Boundary;
            TextNewPeriod.Text =Convert.ToString( HSF.HSFCI_Period);
            TextNewRemindDay.Text = Convert.ToString(HSF.HSFCI_RemindDay);
            TextNewStandard.Text = HSF.HSFCI_Standard;
            UpdatePanel_NewControlItem.Update();

        }
        if (e.CommandName == "Delete_ControlItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ControlItems.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            hSFBasicDataL.Delete_HSFContrItems(guid);
            BindGridview(Bindc1, Bindc2);
            UpdatePanel_GridViewItem.Update();
        }

    }
    //行变色
    protected void Grid_ControlItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //实现选中操作行变色
            if (Session["index"] != null && e.Row.RowIndex == Convert.ToInt16(Session["index"]))
            {
                e.Row.BackColor = Color.SkyBlue;
            }

            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#FFD9EC'");
            //鼠标移出时，行背景色还原 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            //e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色
            e.Row.Attributes["style"] = "Cursor:hand"; //鼠标悬停的行显示手型

        }
    }
    //排序
    protected void Grid_ControlItems_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == Grid_ControlItems.Attributes["SortExpression"])
        {

            //获得下一次的排序状态

            sortDirection = (Grid_ControlItems.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        Grid_ControlItems.Attributes["SortExpression"] = sortExpression;

        Grid_ControlItems.Attributes["SortDirection"] = sortDirection;

        //重新绑定数据

        Grid_ControlItems.DataBind();
    }

    //悬浮框显示
    protected void Grid_ControlItems_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ControlItems.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_ControlItems.Rows[i].Cells.Count; j++)
            {
                Grid_ControlItems.Rows[i].Cells[j].ToolTip = Grid_ControlItems.Rows[i].Cells[j].Text;
                if (Grid_ControlItems.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_ControlItems.Rows[i].Cells[j].Text = Grid_ControlItems.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }

    protected void Grid_ControlItems_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头

            foreach (TableCell MyHeader in e.Row.Cells) //对每一单元格      

                if (MyHeader.HasControls())

                    if (((LinkButton)MyHeader.Controls[0]).CommandArgument == Grid_ControlItems.SortExpression)
                        //是否为排序列

                        if (Grid_ControlItems.SortDirection == SortDirection.Ascending) //依排序方向加入方向箭头

                            MyHeader.Controls.Add(new LiteralControl("▲"));

                        else

                            MyHeader.Controls.Add(new LiteralControl("▼"));
    }
    //翻页
    protected void Grid_ControlItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ControlItems.BottomPagerRow;


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
        BindGridview(Bindc1, Bindc2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ControlItems.PageCount ? Grid_ControlItems.PageCount - 1 : newPageIndex;
        Grid_ControlItems.PageIndex = newPageIndex;
        Grid_ControlItems.DataBind();
    }
    #endregion

    #region 风险等级检索栏
    //检索栏检索按钮
    protected void BtnSearchRisk_Click(object sender, EventArgs e)
    {
        BindcR = TxtRiskLevel.Text;
        BindGridviewRisk(BindcR);
        UpdatePanel_GridRisk.Update();
    }

    //检索栏新增按钮
    protected void BtnNewRisk_Click(object sender, EventArgs e)
    {
        TxtNewRisk.Text = "";
        Panel_NewRisk.Visible = true;
        UpdatePanel_NewRisk.Update();
    }

    //重置
    protected void BtnResetRisk_Click(object sender, EventArgs e)
    {
        TxtRiskLevel.Text = "";
        UpdatePanel_RiskLevel.Update();
        BindcR = "";
        BindGridviewRisk(BindcR);
        UpdatePanel_GridRisk.Update();
    }
    #endregion

    #region 风险等级维护窗口
    //维护窗口提交按钮
    protected void BtnOK_NewRisk_Click(object sender, EventArgs e)
    {
        if (TxtNewRisk.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入风险等级！')", true);
                return;
            }
            try
            {
                if (hSFBasicDataL.Insert_HSFReskLevel(TxtNewRisk.Text) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该风险等级已经存在！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            TxtNewRisk.Text = "";
            BindcR = "";
            BindGridviewRisk(BindcR);
            Panel_NewRisk.Visible = false;
            UpdatePanel_NewRisk.Update();
            UpdatePanel_GridRisk.Update();
    }

    //维护窗口关闭按钮
    protected void BtnCls_NewRisk_Click(object sender, EventArgs e)
    {
        if (Panel_NewRisk.Visible)
        {
            Panel_NewRisk.Visible = false;
        }
    }
    #endregion

    #region 风险等级GridView
    //操作Gridview的命令行
    protected void Grid_Risk_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_RiskLevel")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Risk.SelectedIndex = row.RowIndex;
            LblSearchCond.Text = "RiskAll";
            LblGridMaterial.Text = "该风险等级下物料";
            Panel_SearchMaterial.Visible = true;
            Panel_GridMaterial.Visible = true;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            //this.Grid_BDOrgSheet_1.Rows[gvr.RowIndex].BackColor = System.Drawing.Color.SkyBlue;
            //Session["index"] = gvr.RowIndex;
            idR = new Guid(e.CommandArgument.ToString());
            BindGridMRisk(idR);
            TxtMaterialType.Text = "";
            TextMaterialName.Text = "";
            UpdatePanel_SearchMaterial.Update();
            UpdatePanel_GridMaterial.Update();

        }
        if (e.CommandName == "Delete_RiskLevel")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Risk.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            hSFBasicDataL.Delete_ExpSampleType(guid);
            BindGridviewRisk(BindcR);
            UpdatePanel_GridRisk.Update();
        }

    }
    //行变色
    protected void Grid_Risk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //实现选中操作行变色
            if (Session["index"] != null && e.Row.RowIndex == Convert.ToInt16(Session["index"]))
            {
                e.Row.BackColor = Color.SkyBlue;
            }

            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#FFD9EC'");
            //鼠标移出时，行背景色还原 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            //e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色
            e.Row.Attributes["style"] = "Cursor:hand"; //鼠标悬停的行显示手型

        }
    }
    //排序
    protected void Grid_Risk_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == Grid_Risk.Attributes["SortExpression"])
        {

            //获得下一次的排序状态

            sortDirection = (Grid_Risk.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        Grid_Risk.Attributes["SortExpression"] = sortExpression;

        Grid_Risk.Attributes["SortDirection"] = sortDirection;

        //重新绑定数据

        Grid_Risk.DataBind();
    }

    //悬浮框显示
    protected void Grid_Risk_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Risk.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Risk.Rows[i].Cells.Count; j++)
            {
                Grid_Risk.Rows[i].Cells[j].ToolTip = Grid_Risk.Rows[i].Cells[j].Text;
                if (Grid_Risk.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Risk.Rows[i].Cells[j].Text = Grid_Risk.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }

    protected void Grid_Risk_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头

            foreach (TableCell MyHeader in e.Row.Cells) //对每一单元格      

                if (MyHeader.HasControls())

                    if (((LinkButton)MyHeader.Controls[0]).CommandArgument == Grid_Risk.SortExpression)
                        //是否为排序列

                        if (Grid_Risk.SortDirection == SortDirection.Ascending) //依排序方向加入方向箭头

                            MyHeader.Controls.Add(new LiteralControl("▲"));

                        else

                            MyHeader.Controls.Add(new LiteralControl("▼"));
    }
    //翻页
    protected void Grid_Risk_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Risk.BottomPagerRow;


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
        BindGridviewRisk(BindcR);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Risk.PageCount ? Grid_Risk.PageCount - 1 : newPageIndex;
        Grid_Risk.PageIndex = newPageIndex;
        Grid_Risk.DataBind();
    }
    #endregion

    #region 物料检索栏

    //检索栏检索物料按钮
    protected void BtnSearchMaterial_Click(object sender, EventArgs e)
    {
        LblGridMaterial.Text = "该风险等级所属物料列表";
        BindcM1 = TxtMaterialType.Text;
        BindcM2 = TextMaterialName.Text;
        LblSearchCond.Text = "RiskCond";
        BindGridMRiskF(idR,BindcM1, BindcM2);
        UpdatePanel_GridMaterial.Update();
    }

    //检索栏检索所有按钮
    protected void BtnSearchRest_Click(object sender, EventArgs e)
    {
        LblGridMaterial.Text = "所有物料列表";
        BindcM1 = TxtMaterialType.Text;
        BindcM2 = TextMaterialName.Text;
        LblSearchCond.Text = "All";
        BindGridMAll(BindcM1, BindcM2);
        UpdatePanel_GridMaterial.Update();
    }

    //重置
    protected void BtnResetM_Click(object sender, EventArgs e)
    {
        TxtMaterialType.Text = "";
        TextMaterialName.Text = "";
        UpdatePanel_SearchMaterial.Update();
        BindcM1 = BindcM2 = "";
        if (LblSearchCond.Text == "RiskAll")
        {
            BindGridMRisk(idR);
        }
        else if (LblSearchCond.Text == "RiskCond")
        {
            BindGridMRiskF(idR, BindcM1, BindcM2);
        }
        else if (LblSearchCond.Text == "All")
        {
            BindGridMAll(BindcM1, BindcM2);
        }
        UpdatePanel_GridMaterial.Update();
    }

    //取消按钮
    protected void BtnCls_Material_Click(object sender, EventArgs e)
    {
        if (Panel_SearchMaterial.Visible)
        {
            Panel_SearchMaterial.Visible = false;
            UpdatePanel_SearchMaterial.Update();
        }
        if (Panel_GridMaterial.Visible)
        {
            Panel_GridMaterial.Visible = false;
            UpdatePanel_GridMaterial.Update();
        }
    }

    #endregion

    #region 物料GridView
    //操作Gridview的命令行
    protected void Grid_Material_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Chs_Risk")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            //this.Grid_BDOrgSheet_1.Rows[gvr.RowIndex].BackColor = System.Drawing.Color.SkyBlue;
            //Session["index"] = gvr.RowIndex;
            idM = new Guid(e.CommandArgument.ToString());
            hSFReskLevelInfo.IMMBD_MaterialID = idM;
            hSFReskLevelInfo.HSFRL_RiskLevelID = idR;
            hSFBasicDataL.Insert_HSFReskLevel_M(hSFReskLevelInfo);
            BindGridMAll("", "");
            UpdatePanel_GridMaterial.Update();

        }
        if (e.CommandName == "Delete_Material")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            hSFBasicDataL.Delete_HSFReskLevel_M(guid);
            if (LblSearchCond.Text == "RiskAll")
            {
                BindGridMRisk(idR);
            }
            else if (LblSearchCond.Text == "RiskCond")
            {
                BindGridMRiskF(idR, BindcM1, BindcM2);
            }
            else if (LblSearchCond.Text == "All")
            {
                BindGridMAll(BindcM1, BindcM2);
            }
            UpdatePanel_GridMaterial.Update();
        }
    }
    //protected void Grid_Material_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    if (e.CommandName == "chs_Material")
    //    {
    //        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
    //        Grid_Material.SelectedIndex = row.RowIndex;
    //        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
    //        idM = new Guid(e.CommandArgument.ToString());
    //        hSFReskLevelInfo.IMMBD_MaterialID = idM;
    //        hSFReskLevelInfo.HSFRL_RiskLevelID = idR;
    //        hSFBasicDataL.Insert_HSFReskLevel_M(hSFReskLevelInfo);
    //        BindGridMAll("", "");
    //        UpdatePanel_GridMaterial.Update();
    //    }
    //    if (e.CommandName == "Delete_Material")
    //    {
    //        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
    //        Grid_Material.SelectedIndex = row.RowIndex;
    //        Guid guid = new Guid(e.CommandArgument.ToString());
    //        hSFBasicDataL.Delete_HSFReskLevel_M(guid);
    //        if (LblSearchCond.Text == "RiskAll")
    //        {
    //            BindGridMRisk(idR);
    //        }
    //        else if (LblSearchCond.Text == "RiskCond")
    //        {
    //            BindGridMRiskF(idR, BindcM1, BindcM2);
    //        }
    //        else if (LblSearchCond.Text == "All")
    //        {
    //            BindGridMAll(BindcM1, BindcM2);
    //        }
    //        this.UpdatePanel_GridMaterial.Update();
    //    }

    //}
    //行变色
    protected void Grid_Material_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //实现选中操作行变色
            if (Session["index"] != null && e.Row.RowIndex == Convert.ToInt16(Session["index"]))
            {
                e.Row.BackColor = Color.SkyBlue;
            }

            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#FFD9EC'");
            //鼠标移出时，行背景色还原 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            //e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色
            e.Row.Attributes["style"] = "Cursor:hand"; //鼠标悬停的行显示手型

        }
    }
    //排序
    protected void Grid_Material_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == Grid_Material.Attributes["SortExpression"])
        {

            //获得下一次的排序状态

            sortDirection = (Grid_Material.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        Grid_Material.Attributes["SortExpression"] = sortExpression;

        Grid_Material.Attributes["SortDirection"] = sortDirection;

        //重新绑定数据

        Grid_Material.DataBind();
    }

    //悬浮框显示
    protected void Grid_Material_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Material.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Material.Rows[i].Cells.Count; j++)
            {
                Grid_Material.Rows[i].Cells[j].ToolTip = Grid_Material.Rows[i].Cells[j].Text;
                if (Grid_Material.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Material.Rows[i].Cells[j].Text = Grid_Risk.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }

    protected void Grid_Material_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头

            foreach (TableCell MyHeader in e.Row.Cells) //对每一单元格      

                if (MyHeader.HasControls())

                    if (((LinkButton)MyHeader.Controls[0]).CommandArgument == Grid_Material.SortExpression)
                        //是否为排序列

                        if (Grid_Material.SortDirection == SortDirection.Ascending) //依排序方向加入方向箭头

                            MyHeader.Controls.Add(new LiteralControl("▲"));

                        else

                            MyHeader.Controls.Add(new LiteralControl("▼"));
    }
    //翻页
    protected void Grid_Material_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Material.BottomPagerRow;


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
        if (LblSearchCond.Text == "RiskAll")
        {
            BindGridMRisk(idR);
        }
        else if (LblSearchCond.Text == "RiskCond")
        {
            BindGridMRiskF(idR, BindcM1, BindcM2);
        }
        else if (LblSearchCond.Text == "All")
        {
            BindGridMAll(BindcM1, BindcM2);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Material.PageCount ? Grid_Material.PageCount - 1 : newPageIndex;
        Grid_Material.PageIndex = newPageIndex;
        Grid_Material.DataBind();
    }
    #endregion

    #region 私有调用函数
    //绑定管制项目Gridview
    private void BindGridview(string condition1, string condition2)
    {

        Grid_ControlItems.DataSource = hSFBasicDataL.Search_HSFContrItems(condition1, condition2);
        Grid_ControlItems.DataBind();
    }

    //绑定风险等级Gridview
    private void BindGridviewRisk(string condition1)
    {

        Grid_Risk.DataSource = hSFBasicDataL.Search_HSFReskLevel(condition1);
        Grid_Risk.DataBind();
    }
    //绑定所有物料Gridview
    private void BindGridMAll(string IMMT_MaterialType, string IMMBD_MaterialName)
    {
        Grid_Material.DataSource = hSFBasicDataL.Search_IMMaterialBasicData_M(IMMT_MaterialType, IMMBD_MaterialName);
        Grid_Material.DataBind();
    }

    //绑定某风险等级下物料Gridview
    private void BindGridMRisk(Guid ID)
    {
        Grid_Material.DataSource = hSFBasicDataL.Search_HSFReskLevel_M(ID);
        Grid_Material.DataBind();
    }

    //绑定模糊检索某风险等级下物料Gridview
    private void BindGridMRiskF(Guid ID,string cond1,string cond2)
    {
        Grid_Material.DataSource = hSFBasicDataL.Search_IMMaterialBasicData_RL(ID, cond1, cond2);
        Grid_Material.DataBind();
    }

    //私有清空的方法
    private void Clear()
    {
        TxtNewItemName.Text = "";
        TextNewBoundary.Text = "";
        TextNewPeriod.Text = "";
        TextNewRemindDay.Text = "";
        TextNewStandard.Text = "";
    }

    #endregion
   

}