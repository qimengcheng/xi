using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IQCMgt_IQCItemsMgt : Page
{
    IQCBasicDataD iQCBasicDataL = new IQCBasicDataD();
    IQCBasicDataInfo iQCBasicDataInfo = new IQCBasicDataInfo();
    static Guid id2=new Guid();
    static Guid idItem = new Guid();
    static Guid id3=new Guid();
    static Guid idValue = new Guid();
    static string cond1 = " and IMMBD_IsIQC=1", cond2 = "", cond3 = "",cond3R="", condSearch1 = "", Grid2Cond = "", Grid3Cond = "";
    static string edit2 = "", edit3 = "";//用于存储grid2、grid3编辑状态
    #region 页面加载
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid1(cond1);
        string Role = Request.QueryString["state"].ToString();
        if (!Page.IsPostBack)
        {
            cond1 = " and IMMBD_IsIQC=1";
            BindGrid1(cond1);
            UpdatePanel_GridMaterial.Update();
            LblGridMaterial.Text = "进料检验物料表";
            Grid_Material.Columns[6].Visible = false;
            if (!((Session["UserRole"].ToString().Contains("进料检验检验项目维护")) || (Session["UserRole"].ToString().Contains("进料检验检验项目查看"))))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        if (Role == "Item" && Session["UserRole"].ToString().Contains("进料检验检验项目维护"))
        {
            Title = "进料检验检验项目维护";
        }
        else if (Role == "Item" && Session["UserRole"].ToString().Contains("进料检验检验项目查看"))
        {
            Title = "进料检验检验项目查看";
            Grid_Material.Columns[5].Visible = false;
            Grid_Material.Columns[6].Visible = false;
            Btn_NewIQCItems.Visible = false;
            Grid_IQCItems.Columns[5].Visible = false;
            Grid_IQCItems.Columns[6].Visible = false;
            Btn_NewStandard.Visible = false;
            Grid_ItemsValue.Columns[4].Visible = false;
            Grid_ItemsValue.Columns[5].Visible = false;
        }
    }
    #endregion

    #region 物料检索栏
    //检索栏检索按钮
    protected void BtnSearchMaterial_Click(object sender, EventArgs e)
    {
        if (Ddl_Au.SelectedValue == "0")
        {
            Grid_Material.Columns[4].Visible = true;
            Grid_Material.Columns[5].Visible = true;
            Grid_Material.Columns[6].Visible = false;
            condSearch1 = "";//以此变量存储物料检索栏是否处于检索所有的状态
            LblGridMaterial.Text = "进料检验物料表";
            cond1 = " and IMMBD_IsIQC=1";
            if (TxtMaterialType.Text != "")
            {
                cond1 = cond1 + " and IMMT_MaterialType like '%'+ Ltrim(Rtrim('" + TxtMaterialType.Text + "'))+'%'";
            }
            if (TxtMaterialName.Text != "")
            {
                cond1 = cond1 + " and IMMBD_MaterialName like '%'+ Ltrim(Rtrim('" + TxtMaterialName.Text + "'))+'%'";
            }
            if (TxtSpecificationModel.Text != "")
            {
                cond1 = cond1 + " and IMMBD_SpecificationModel like '%'+ Ltrim(Rtrim('" + TxtSpecificationModel.Text + "'))+'%'";
            }
        }
        else if (Ddl_Au.SelectedValue == "1")
        {
            Grid_Material.Columns[4].Visible = false;
            Grid_Material.Columns[5].Visible = false;
            Grid_Material.Columns[6].Visible = true;
            condSearch1 = "all";//以此变量存储物料检索栏是否处于检索所有的状态
            LblGridMaterial.Text = "非进料检验物料表";
            cond1 = " and (IMMBD_IsIQC=0 or IMMBD_IsIQC is null) ";
            if (TxtMaterialType.Text != "")
            {
                cond1 = cond1 + " and IMMT_MaterialType like '%'+ Ltrim(Rtrim('" + TxtMaterialType.Text + "'))+'%'";
            }
            if (TxtMaterialName.Text != "")
            {
                cond1 = cond1 + " and IMMBD_MaterialName like '%'+ Ltrim(Rtrim('" + TxtMaterialName.Text + "'))+'%'";
            }
            if (TxtSpecificationModel.Text != "")
            {
                cond1 = cond1 + " and IMMBD_SpecificationModel like '%'+ Ltrim(Rtrim('" + TxtSpecificationModel.Text + "'))+'%'";
            }
        }
        BindGrid1 (cond1 );
        UpdatePanel_GridMaterial.Update();
    }

    //重置
    protected void BtnResetMaterial_Click(object sender, EventArgs e)
    {
        TxtMaterialType.Text = "";
        TxtMaterialName.Text = "";
        TxtSpecificationModel.Text = "";
        if (condSearch1 == "")
        {
            Grid_Material.Columns[4].Visible = true;
            Grid_Material.Columns[5].Visible = true;
            Grid_Material.Columns[6].Visible = false;
            cond1 = " and IMMBD_IsIQC=1";
            LblGridMaterial.Text = "进料检验物料表";
        }
        else if (condSearch1 == "all")
        {
            Grid_Material.Columns[4].Visible = false;
            Grid_Material.Columns[5].Visible = false;
            Grid_Material.Columns[6].Visible = true;
            cond1 = " and (IMMBD_IsIQC=0 or IMMBD_IsIQC is null) ";
            LblGridMaterial.Text = "非料检验物料表";
        }
        BindGrid1(cond1);
        UpdatePanel_SearchMaterial.Update();
        UpdatePanel_GridMaterial.Update();
    }

    #endregion

    #region 物料表Grid1
    //操作Gridview的命令行
    protected void Grid_Material_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            id2 = new Guid(e.CommandArgument.ToString());
            BindGrid2(id2);
            Grid2Cond = "id";//用id表示grid2绑定id检索，用空表示grid2绑定模糊检索
            TxtIQCItems.Text = "";
            DdlstNeedValue.ClearSelection();
            Panel_IQCItemsMgt.Visible = true;
            UpdatePanel_IQCItemsMgt.Update();
        }
        if (e.CommandName == "Delete_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                if (iQCBasicDataL.Delete_IMMaterialBasicData_IQC(guid) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该物料不属于检验物料，无法删除！')", true);
                    return;
                }
                //expTestL.Insert_ExpSampleType(expSampleType_ExpItems);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            if (guid == id2)//如果点击的检验项目维护与所删除的是同一列，则关闭子级窗口
            {
                TxtIQCItems.Text = "";
                DdlstNeedValue.ClearSelection();
                Panel_IQCItemsMgt.Visible = false;
                UpdatePanel_IQCItemsMgt.Update();
                TxtStandard.Text = "";
                TxtRemarks.Text = "";
                Panel_SearchStandard.Visible = false;
                UpdatePanel_SearchStandard.Update();
            }
            BindGrid1(cond1);
            UpdatePanel_GridMaterial.Update();
        }
        if (e.CommandName == "Chs_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                if (iQCBasicDataL.Insert_IMMaterialBasicData_IQC(guid) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该物料已经属于检验物料！')", true);
                    return;
                }
                //expTestL.Insert_ExpSampleType(expSampleType_ExpItems);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            BindGrid1(cond1);
            UpdatePanel_GridMaterial.Update();
        }

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
                    Grid_Material.Rows[i].Cells[j].Text = Grid_Material.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

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
        //if (condSearch1 == "")
        //{
        //    cond1 = " and IMMBD_IsIQC=1";
        //}
        //else if (condSearch1 == "all")
        //{
        //    cond1 = " and (IMMBD_IsIQC=0 or IMMBD_IsIQC is null) ";
        //}
        BindGrid1(cond1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Material.PageCount ? Grid_Material.PageCount - 1 : newPageIndex;
        Grid_Material.PageIndex = newPageIndex;
        Grid_Material.DataBind();
    }
    #endregion

    #region 检验项目检索栏
    //检索栏检索按钮
    protected void Btn_SearchIQCItems_Click(object sender, EventArgs e)
    {
            Grid2Cond = "";//表示grid2绑定模糊查询数据
            cond2 = " IMMBD_MaterialID='" + Convert.ToString(id2) + "' ";
            if (TxtIQCItems.Text != "")
            {
                cond2 = cond2 + " and IQCIT_Items like '%'+ Ltrim(Rtrim('" + TxtIQCItems.Text + "'))+'%'";
            }
            if (DdlstNeedValue.SelectedItem.ToString() != "请选择")
            {
                cond2 = cond2 + " and IQCIT_NeedValue='" + DdlstNeedValue.SelectedItem.ToString() + "'";
            }
            BindGrid2M(cond2);
            UpdatePanel_IQCItemsMgt.Update();
    }

    //重置
    protected void Btn_ResetIQCItems_Click(object sender, EventArgs e)
    {
        TxtIQCItems.Text = "";
        DdlstNeedValue.ClearSelection();
        Grid2Cond = "";
        cond2 = " IMMBD_MaterialID='" + Convert.ToString(id2) + "' ";
        BindGrid2M(cond2);
        UpdatePanel_IQCItemsMgt.Update();
    }

    //检索栏新增按钮
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        edit2 = "";
        Txt_EditItems.Text = "";
        Ddl_EditValues.ClearSelection();
        Panel_EditItems.Visible = true;
        UpdatePanel_EditItems.Update();


    }

    //检索栏关闭按钮
    protected void Btn_ClsIQCItems_Click(object sender, EventArgs e)
    {
        TxtIQCItems.Text = "";
        DdlstNeedValue.ClearSelection();
        Panel_IQCItemsMgt.Visible = false;
        UpdatePanel_IQCItemsMgt.Update();
        TxtStandard.Text = "";
        TxtRemarks.Text = "";
        Panel_SearchStandard.Visible = false;
        UpdatePanel_SearchStandard.Update();
        Txt_EditItems.Text = "";
        Ddl_EditValues.ClearSelection();
        Panel_EditItems.Visible = false;
        UpdatePanel_EditItems.Update();
        Panel_EditStandard.Visible = false;
        UpdatePanel_EditStandard.Update();
    }
    #endregion

    #region  检验项目维护栏

    protected void Btn_EditSubmitIQCItems_Click(object sender, EventArgs e)
    {
        if (edit2 == "")
        {
            if (Txt_EditItems.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (Ddl_EditValues.SelectedItem.ToString() == "请选择")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            IQCBasicDataInfo IQC = new IQCBasicDataInfo();
            IQC.IMMBD_MaterialID = id2;
            IQC.IQCIT_Items = Txt_EditItems.Text;
            IQC.IQCIT_NeedValue = Ddl_EditValues.SelectedItem.ToString();
            try
            {
                if (iQCBasicDataL.Insert_IQCItemsTable(IQC) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该检验项目已经存在！')", true);
                    return;
                }
                //expTestL.Insert_ExpSampleType(expSampleType_ExpItems);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            Txt_EditItems.Text = "";
            Ddl_EditValues.ClearSelection();
            Grid2Cond = "";
            cond2 = " IMMBD_MaterialID='" + Convert.ToString(id2) + "' ";
            BindGrid2M(cond2);
            UpdatePanel_IQCItemsMgt.Update();
        }
        if (edit2 != "")
        {
            if (Txt_EditItems.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (Ddl_EditValues.SelectedItem.ToString() == "请选择")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            iQCBasicDataInfo.IQCIT_ID = idItem;
            iQCBasicDataInfo.IMMBD_MaterialID = id2;
            iQCBasicDataInfo.IQCIT_Items = Txt_EditItems.Text;
            iQCBasicDataInfo.IQCIT_NeedValue = Ddl_EditValues.SelectedItem.ToString();
            try
            {
                if (iQCBasicDataL.Update_IQCItemsTable(iQCBasicDataInfo) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该检验项目已经存在！')", true);
                    return;
                }
                //expTestL.Insert_ExpSampleType(expSampleType_ExpItems);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            edit2 = "";
            Txt_EditItems.Text = "";
            Ddl_EditValues.ClearSelection();
            Grid2Cond = "";
            cond2 = " IMMBD_MaterialID='" + Convert.ToString(id2) + "' ";
            BindGrid2M(cond2);
            UpdatePanel_IQCItemsMgt.Update();
            Panel_EditItems.Visible = false;
        }
        UpdatePanel_EditItems.Update();
    }
    protected void Btn_EditClsIQCItems_Click(object sender, EventArgs e)
    {
        Txt_EditItems.Text = "";
        Ddl_EditValues.ClearSelection();
        Panel_EditItems.Visible = false;
        UpdatePanel_EditItems.Update();
    }
    #endregion


    #region 检验项目Grid2
    //操作Gridview的命令行
    protected void Grid_IQCItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_ItemValue")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_IQCItems.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            id3 = new Guid(e.CommandArgument.ToString());
            BindGrid3(id3);
            Grid3Cond = "id";//用id表示grid3绑定id检索，用空表示grid3绑定模糊检索
            Panel_SearchStandard.Visible = true;
            UpdatePanel_SearchStandard.Update();
        }
        if (e.CommandName == "Edt_Item")
        {
            edit2 = "edit";
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_IQCItems.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Guid guid = new Guid(e.CommandArgument.ToString());
            iQCBasicDataInfo = iQCBasicDataL.Search_IQCItemsTable_ID(guid)[0];
            Txt_EditItems.Text = iQCBasicDataInfo.IQCIT_Items;
            id2 = iQCBasicDataInfo.IMMBD_MaterialID;
            idItem = iQCBasicDataInfo.IQCIT_ID;
            if (iQCBasicDataInfo.IQCIT_NeedValue == "是")
            {
                Ddl_EditValues.SelectedValue = "1";
            }
            else if (iQCBasicDataInfo.IQCIT_NeedValue == "否")
            {
                Ddl_EditValues.SelectedValue = "2";
            }
            Panel_EditItems.Visible = true;
            UpdatePanel_EditItems.Update();
        }
        if (e.CommandName == "Delete_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_IQCItems.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                iQCBasicDataL.Delete_IQCItemsTable(guid);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            if (guid == id3)//若删除的检验项目打开了子级检验标准，则关闭子级窗口
            {
                TxtStandard.Text = "";
                TxtRemarks.Text = "";
                Panel_SearchStandard.Visible = false;
                UpdatePanel_SearchStandard.Update();
            }
            Grid2Cond = "";
            cond2 = " IMMBD_MaterialID='" + Convert.ToString(id2) + "' ";
            BindGrid2M(cond2);
            UpdatePanel_IQCItemsMgt.Update();
        }

    }

    //悬浮框显示
    protected void Grid_IQCItems_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_IQCItems.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_IQCItems.Rows[i].Cells.Count; j++)
            {
                Grid_IQCItems.Rows[i].Cells[j].ToolTip = Grid_IQCItems.Rows[i].Cells[j].Text;
                if (Grid_IQCItems.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_IQCItems.Rows[i].Cells[j].Text = Grid_IQCItems.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_IQCItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_IQCItems.BottomPagerRow;


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
        if (Grid2Cond == "")
        {
            BindGrid2M(cond2); ;
        }
        else if (Grid2Cond == "id")
        {
            BindGrid2(id2);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_IQCItems.PageCount ? Grid_IQCItems.PageCount - 1 : newPageIndex;
        Grid_IQCItems.PageIndex = newPageIndex;
        Grid_IQCItems.DataBind();
    }
    #endregion

    #region 检验标准检索栏
    //检索栏检索按钮
    protected void Btn_SearchStandard_Click(object sender, EventArgs e)
    {
            Grid3Cond = "";//表示grid3绑定模糊查询数据
            cond3 = TxtStandard.Text;
            cond3R = TxtRemarks.Text;
            BindGrid3M(id3, cond3, cond3R);
            UpdatePanel_SearchStandard.Update();
    }

    //重置
    protected void Btn_ResetStandard_Click(object sender, EventArgs e)
    {
        edit3 = "";
        TxtStandard.Text = "";
        TxtRemarks.Text = "";
        Grid3Cond = "";
        cond3 = "";
        cond3R = "";
        BindGrid3M(id3, cond3,cond3R);
        UpdatePanel_SearchStandard.Update();
    }

    //检索栏新增按钮
    protected void Btn_NewStandard_Click(object sender, EventArgs e)
    {
        edit3 = "";
        Txt_EditStandard.Text = "";
        Txt_EditNote.Text = "";
        Panel_EditStandard.Visible = true;
        UpdatePanel_EditStandard.Update();
    }
    //检索栏关闭按钮
    protected void Btn_ClsStandard_Click(object sender, EventArgs e)
    {
        TxtStandard.Text = "";
        TxtRemarks.Text = "";
        Panel_SearchStandard.Visible = false;
        UpdatePanel_SearchStandard.Update();
        Txt_EditStandard.Text = "";
        Txt_EditNote.Text = "";
        Panel_EditStandard.Visible = false;
        UpdatePanel_EditStandard.Update();
    }
    #endregion

    #region // 检验标准维护栏

    protected void Btn_EditSubmitStandard_Click(object sender, EventArgs e)
    {
        if (edit3 == "")
        {
            if (Txt_EditStandard.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            IQCBasicDataInfo IQC = new IQCBasicDataInfo();
            IQC.IQCIT_ID = id3;
            IQC.IQCIT_Standard = Txt_EditStandard.Text;
            IQC.IQCIT_Remarks = Txt_EditNote.Text;
            try
            {
                if (iQCBasicDataL.Insert_IQCStandardTable(IQC) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该检验标准已经存在！')", true);
                    return;
                }
                //expTestL.Insert_ExpSampleType(expSampleType_ExpItems);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            Txt_EditStandard.Text = "";
            Txt_EditNote.Text = "";
            Grid3Cond = "";
            cond3 = "";
            cond3R = "";
            BindGrid3M(id3, cond3, cond3R);
            UpdatePanel_SearchStandard.Update();
        }
        if (edit3 != "")
        {
            if (Txt_EditStandard.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            iQCBasicDataInfo.IQCST_ID = idValue;
            iQCBasicDataInfo.IQCIT_ID = id3;
            iQCBasicDataInfo.IQCIT_Standard = Txt_EditStandard.Text;
            iQCBasicDataInfo.IQCIT_Remarks = Txt_EditNote.Text;
            try
            {
                if (iQCBasicDataL.Update_IQCStandardTable(iQCBasicDataInfo) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该检验标准已经存在！')", true);
                    return;
                }
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
            edit3 = "";
            Txt_EditStandard.Text = "";
            Txt_EditNote.Text = "";
            Grid3Cond = "";
            cond3 = "";
            cond3R = "";
            BindGrid3M(id3, cond3, cond3R);
            UpdatePanel_SearchStandard.Update();
            Panel_EditStandard.Visible = false;
        }
        UpdatePanel_EditStandard.Update();

    }
    protected void Btn_EditClsStandard_Click(object sender, EventArgs e)
    {
        Txt_EditStandard.Text = "";
        Txt_EditNote.Text = "";
        Panel_EditStandard.Visible = false;
        UpdatePanel_EditStandard.Update();
    }
    #endregion

    #region 检验标准Grid3
    //操作Gridview的命令行
    protected void Grid_ItemsValue_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_ItemValue")
        {
            edit3 = "edit";//用“edit”表示处于编辑状态：可以重置、提交、关闭（不能检索、新增），用空表示非编辑状态：可以检索、新增、重置、关闭（不能提交）
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ItemsValue.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Guid guid = new Guid(e.CommandArgument.ToString());
            iQCBasicDataInfo = iQCBasicDataL.Search_IQCStandardTable_ID(guid)[0];
            Txt_EditStandard.Text = iQCBasicDataInfo.IQCIT_Standard;
            id3 = iQCBasicDataInfo.IQCIT_ID;
            idValue = iQCBasicDataInfo.IQCST_ID;
            Txt_EditNote.Text = iQCBasicDataInfo.IQCIT_Remarks;
            Panel_EditStandard.Visible = true;
            UpdatePanel_EditStandard.Update();
        }
        if (e.CommandName == "Delete_ItemValue")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ItemsValue.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                iQCBasicDataL.Delete_IQCStandardTable(guid);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            Grid3Cond = "";
            cond3 = "";
            cond3R = "";
            BindGrid3M(id3, cond3,cond3R);
            UpdatePanel_SearchStandard.Update();
        }

    }

    //悬浮框显示
    protected void Grid_ItemsValue_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ItemsValue.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_ItemsValue.Rows[i].Cells.Count; j++)
            {
                Grid_ItemsValue.Rows[i].Cells[j].ToolTip = Grid_ItemsValue.Rows[i].Cells[j].Text;
                if (Grid_ItemsValue.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_ItemsValue.Rows[i].Cells[j].Text = Grid_ItemsValue.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_ItemsValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ItemsValue.BottomPagerRow;


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
        if (Grid3Cond == "")
        {
            BindGrid3M(id3,cond3,cond3R); ;
        }
        else if (Grid3Cond == "id")
        {
            BindGrid3(id3);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ItemsValue.PageCount ? Grid_ItemsValue.PageCount - 1 : newPageIndex;
        Grid_ItemsValue.PageIndex = newPageIndex;
        Grid_ItemsValue.DataBind();
    }
    #endregion

    #region 私有调用函数
    //绑定进料检验物料Gridview
    private void BindGrid1(string condition)
    {

        Grid_Material.DataSource = iQCBasicDataL.Search_IMMaterialBasicData_IQC(condition);
        Grid_Material.DataBind();
    }

    //绑定检验项目Gridview
    private void BindGrid2(Guid IMMBD_MaterialID)
    {

        Grid_IQCItems.DataSource = iQCBasicDataL.Search_IQCItemsTable(IMMBD_MaterialID);
        Grid_IQCItems.DataBind();
    }
    //绑定模糊检索检验项目Gridview
    private void BindGrid2M(string condition)
    {
        Grid_IQCItems.DataSource = iQCBasicDataL.Search_IQCItemsTable_M(condition);
        Grid_IQCItems.DataBind();
    }

    //绑定检验标准Gridview
    private void BindGrid3(Guid ID)
    {
        Grid_ItemsValue.DataSource = iQCBasicDataL.Search_IQCStandardTable(ID);
        Grid_ItemsValue.DataBind();
    }

    //绑定模糊查询检验标准Gridview
    private void BindGrid3M(Guid ID, string IQCIT_Standard, string IQCIT_Remarks)
    {
        Grid_ItemsValue.DataSource = iQCBasicDataL.Search_IQCStandardTable_M(ID, IQCIT_Standard, IQCIT_Remarks);
        Grid_ItemsValue.DataBind();
    }
    #endregion
}