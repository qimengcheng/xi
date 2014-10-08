using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IQCMgt_IQCCertificationMgt : Page
{
    IQCBasicDataD iQCBasicDataL = new IQCBasicDataD();
    IQCBasicDataInfo iQCBasicDataInfo = new IQCBasicDataInfo();
    static string PS_Name = "", PT_Name = "", cond = "", id4M = "", condSearch4="";
    static Guid id2 = new Guid();
    static Guid id3 = new Guid();
    static Guid id4 = new Guid();
    #region 页面加载
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            condSearch.Text = "";
        }
        if (condSearch.Text == "")
        {
            Grid_ProType.Columns[7].Visible = false;
            Grid_ProType.Columns[4].Visible = true;
            Grid_ProType.Columns[5].Visible = false;
            Grid_ProType.Columns[6].Visible = true;
            LblGridProType.Text = "认证产品型号表";
            BindGrid1RZ(PS_Name, PT_Name);
        }
        else if (condSearch.Text == "QT")
        {
            Grid_ProType.Columns[7].Visible = true;
            Grid_ProType.Columns[4].Visible = false;
            Grid_ProType.Columns[5].Visible = false;
            Grid_ProType.Columns[6].Visible = false;
            LblGridProType.Text = "其他产品型号表";
            BindGrid1QT(PS_Name, PT_Name);
        }
        string Role = Request.QueryString["state"].ToString();
        if (!Page.IsPostBack)
        {
            Grid_ProType.Columns[6].Visible = false;
            if (!((Session["UserRole"].ToString().Contains("认证信息维护")) || (Session["UserRole"].ToString().Contains("认证信息查看"))))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
       
         if (Role == "Certification" && Session["UserRole"].ToString().Contains("认证信息查看"))
        {
            Title = "认证信息查看";
            Grid_ProType.Columns[5].Visible = false;
            Grid_ProType.Columns[6].Visible = false;
            Btn_NewCFCraft.Visible = false;
            Grid_CFCraft.Columns[3].Visible = false;
            Btn_NewCFCFRoute.Visible = false;
            Grid_CFRoute.Columns[3].Visible = false;
        }
         else if (Role == "Certification" && Session["UserRole"].ToString().Contains("认证信息维护"))
        {
            Title = "认证信息维护";
            Grid_ProType.Columns[5].Visible = false;
            Grid_ProType.Columns[6].Visible = true;
            Btn_NewCFCraft.Visible = true;
            Grid_CFCraft.Columns[3].Visible = true;
            Btn_NewCFCFRoute.Visible = true;
            Grid_CFRoute.Columns[3].Visible = true;
        }
    }
    #endregion

    #region 产品型号检索栏
    //检索栏检索按钮
    protected void BtnSearchProType_Click(object sender, EventArgs e)
    {
        if (Ddl_RZ.SelectedValue == "0")
        {
            Grid_ProType.Columns[7].Visible = false;
            Grid_ProType.Columns[4].Visible = true;
            Grid_ProType.Columns[5].Visible = false;
            Grid_ProType.Columns[6].Visible = true;
            condSearch.Text = "";//以此变量存储物料检索栏是否处于检索所有的状态
            LblGridProType.Text = "认证产品型号表";
            if (TxtProSeries.Text != "")
            {
                PS_Name = TxtProSeries.Text;
            }
            if (TxtProType.Text != "")
            {
                PT_Name = TxtProType.Text;
            }
            BindGrid1RZ(PS_Name, PT_Name);
            UpdatePanel_GridProType.Update();
        }
        else if (Ddl_RZ.SelectedValue == "1")
        {
            Grid_ProType.Columns[7].Visible = true;
            Grid_ProType.Columns[4].Visible = false;
            Grid_ProType.Columns[5].Visible = false;
            Grid_ProType.Columns[6].Visible = false;
            LblGridProType.Text = "其他产品型号表";
            condSearch.Text = "QT";//以此变量存储检索栏是否处于检索其他的状态
            if (TxtProSeries.Text != "")
            {
                PS_Name = TxtProSeries.Text;
            }
            if (TxtProType.Text != "")
            {
                PT_Name = TxtProType.Text;
            }
            BindGrid1QT(PS_Name, PT_Name);
            UpdatePanel_GridProType.Update();
        }
    }

    //重置
    protected void BtnResetProType_Click(object sender, EventArgs e)
    {
        TxtProSeries.Text = "";
        TxtProType.Text = "";
        PS_Name = "";
        PT_Name = "";
        if (condSearch.Text == "")
        {
            Grid_ProType.Columns[7].Visible = true;
            Grid_ProType.Columns[4].Visible = true;
            Grid_ProType.Columns[5].Visible = true;
            Grid_ProType.Columns[6].Visible = false;
            LblGridProType.Text = "认证产品型号表";
            BindGrid1RZ(PS_Name, PT_Name);
        }
        else if (condSearch.Text == "QT")
        {
            Grid_ProType.Columns[7].Visible = false;
            Grid_ProType.Columns[4].Visible = false;
            Grid_ProType.Columns[5].Visible = false;
            Grid_ProType.Columns[6].Visible = true;
            LblGridProType.Text = "其他产品型号表";
            BindGrid1QT(PS_Name, PT_Name);
        }
        UpdatePanel_SearchProType.Update();
        UpdatePanel_GridProType.Update();
    }

    //检索栏检索其他按钮
    //protected void BtnSearchElse_Click(object sender, EventArgs e)
    //{
    //    Grid_ProType.Columns[3].Visible = false;
    //    Grid_ProType.Columns[4].Visible = false;
    //    Grid_ProType.Columns[5].Visible = false;
    //    Grid_ProType.Columns[6].Visible = true;
    //    LblGridProType.Text = "其他产品型号表";
    //    condSearch.Text = "QT";//以此变量存储检索栏是否处于检索其他的状态
    //    if (TxtProSeries.Text != "")
    //    {
    //        PS_Name = TxtProSeries.Text;
    //    }
    //    if (TxtProType.Text != "")
    //    {
    //        PT_Name = TxtProType.Text;
    //    }
    //    BindGrid1QT(PS_Name, PT_Name);
    //    this.UpdatePanel_GridProType.Update();
    //}

    #endregion

    #region 产品型号表Grid1
    //操作Gridview的命令行
    protected void Grid_ProType_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_CFCraft")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ProType.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            id2 = new Guid(e.CommandArgument.ToString());
            IQCBasicDataInfo IQC = new IQCBasicDataInfo();
            IQC = iQCBasicDataL.Search_ProType_ID(id2)[0];
            LblRZState.Text = IQC.PT_Name;
            BindGrid2(id2);
            Panel_GridCFCraft.Visible = true;
            UpdatePanel_GridCFCraft.Update();
            Panel_CFRoute.Visible = false;
            UpdatePanel_CFRoute.Update(); 
           condSearch4 = "";
            LblState.Text = "认证";//用“认证”标识grid4处于认证工序检索，“工艺”标识处于认证工艺路线检索
            LblGongxuState.Text = "认证";//用“认证”标识grid4处于认证工序编辑，“工艺”标识处于认证工艺路线编辑

            ((BoundField)Grid_Craft.Columns[1]).ReadOnly = false;//注意类型转换，你所操作的列的类型是BoundField

            ((BoundField)Grid_Craft.Columns[2]).ReadOnly = true;
          
            id4 = id2;
            IQCBasicDataInfo IQC1 = new IQCBasicDataInfo();
            IQC1 = iQCBasicDataL.Search_ProType_ID(id2)[0];
            LblSCState.Text = IQC1.PT_Name;
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();
        }
        if (e.CommandName == "Edt_CFRoute")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ProType.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            id3 = new Guid(e.CommandArgument.ToString());
            IQCBasicDataInfo IQC = new IQCBasicDataInfo();
            IQC = iQCBasicDataL.Search_ProType_ID(id3)[0];
            LblRTState.Text = IQC.PT_Name;
            BindGrid3(id3);
            Panel_CFRoute.Visible = true;
            UpdatePanel_CFRoute.Update();
            Panel_GridCFCraft.Visible = false;
            UpdatePanel_GridCFCraft.Update(); 
           condSearch4 = "";
            LblState.Text = "工艺";//用“认证”标识grid4处于认证工序检索，“工艺”标识处于认证工艺路线检索
            LblGongxuState.Text = "工艺";//用“认证”标识grid4处于认证工序编辑，“工艺”标识处于认证工艺路线编辑
            ((BoundField)Grid_Craft.Columns[1]).ReadOnly = true;//注意类型转换，你所操作的列的类型是BoundField

            ((BoundField)Grid_Craft.Columns[2]).ReadOnly = false;
           
            id4 = id3;
            IQCBasicDataInfo IQC1 = new IQCBasicDataInfo();
            IQC1 = iQCBasicDataL.Search_ProType_ID(id3)[0];
            LblSCState.Text = IQC1.PT_Name;
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();
        }
        if (e.CommandName == "Delete_ProType")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ProType.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                iQCBasicDataL.Delete_ProType_RZ(guid);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            BindGrid1RZ(PS_Name, PT_Name);
            UpdatePanel_GridProType.Update();
        }
        if (e.CommandName == "Chs_ProType")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ProType.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                iQCBasicDataL.Insert_ProType_RZ(guid);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            BindGrid1QT(PS_Name, PT_Name);
            UpdatePanel_GridProType.Update();
        }

    }

    //悬浮框显示
    protected void Grid_ProType_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ProType.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_ProType.Rows[i].Cells.Count; j++)
            {
                Grid_ProType.Rows[i].Cells[j].ToolTip = Grid_ProType.Rows[i].Cells[j].Text;
                if (Grid_ProType.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_ProType.Rows[i].Cells[j].Text = Grid_ProType.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ProType.BottomPagerRow;


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
        if (condSearch.Text == "")
        {
            BindGrid1RZ(PS_Name, PT_Name);
        }
        else if (condSearch.Text== "QT")
        {
            BindGrid1QT(PS_Name, PT_Name);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ProType.PageCount ? Grid_ProType.PageCount - 1 : newPageIndex;
        Grid_ProType.PageIndex = newPageIndex;
        Grid_ProType.DataBind();
    }
    #endregion

    #region 认证工序表Grid2
    //操作Gridview的命令行
    protected void Grid_CFCraft_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_CFCraft")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_CFCraft.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                iQCBasicDataL.Delete_PRDetail_RZ(guid);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            BindGrid2(id2);
            UpdatePanel_GridCFCraft.Update();
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();
        }

    }

    //悬浮框显示
    protected void Grid_CFCraft_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_CFCraft.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_CFCraft.Rows[i].Cells.Count; j++)
            {
                Grid_CFCraft.Rows[i].Cells[j].ToolTip = Grid_CFCraft.Rows[i].Cells[j].Text;
                if (Grid_CFCraft.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_CFCraft.Rows[i].Cells[j].Text = Grid_CFCraft.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_CFCraft_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_CFCraft.BottomPagerRow;


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
        BindGrid2(id2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_CFCraft.PageCount ? Grid_CFCraft.PageCount - 1 : newPageIndex;
        Grid_CFCraft.PageIndex = newPageIndex;
        Grid_CFCraft.DataBind();
    }

    //新增
    protected void Btn_NewCFCraft_Click(object sender, EventArgs e)
    {
       condSearch4 = "";
        LblState.Text = "认证";//用“认证”标识grid4处于认证工序检索，“工艺”标识处于认证工艺路线检索
        LblGongxuState.Text = "认证";//用“认证”标识grid4处于认证工序编辑，“工艺”标识处于认证工艺路线编辑

        ((BoundField)Grid_Craft.Columns[1]).ReadOnly = false;//注意类型转换，你所操作的列的类型是BoundField

        ((BoundField)Grid_Craft.Columns[2]).ReadOnly = true;
        //TxtOrder.Text="";
        //TxtName.Text = "";
        id4 = id2;
        IQCBasicDataInfo IQC = new IQCBasicDataInfo();
        IQC = iQCBasicDataL.Search_ProType_ID(id2)[0];
        LblSCState.Text = IQC.PT_Name;
        BindGrid4(id4);
        Panel_SearchCraft.Visible = true;
        UpdatePanel_SearchCraft.Update();
    }

    //关闭
    protected void Btn_ClsCFCraft_Click(object sender, EventArgs e)
    {
        Panel_GridCFCraft.Visible = false;
        UpdatePanel_GridCFCraft.Update();
        if (Panel_CFRoute.Visible == false)
        {
            Panel_SearchCraft.Visible = false;
            UpdatePanel_SearchCraft.Update();
        }
        else if (Panel_CFRoute.Visible == true)
        {
            ((BoundField)Grid_Craft.Columns[1]).ReadOnly = true;
            ((BoundField)Grid_Craft.Columns[2]).ReadOnly = false;
            LblState.Text = "工艺";
            //TxtOrder.Text = "";
            //TxtName.Text = "";
            id4 = id3;
            IQCBasicDataInfo IQC = new IQCBasicDataInfo();
            IQC = iQCBasicDataL.Search_ProType_ID(id3)[0];
            LblSCState.Text = IQC.PT_Name;
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();

        }
    }
    #endregion

    #region 认证工艺路线表Grid3
    //操作Gridview的命令行
    protected void Grid_CFRoute_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_CFRoute")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_CFCraft.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                iQCBasicDataL.Delete_PRDetail_RZR(guid);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            BindGrid2(id3);
            UpdatePanel_CFRoute.Update();
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();
        }

    }

    //悬浮框显示
    protected void Grid_CFRoute_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_CFRoute.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_CFRoute.Rows[i].Cells.Count; j++)
            {
                Grid_CFRoute.Rows[i].Cells[j].ToolTip = Grid_CFRoute.Rows[i].Cells[j].Text;
                if (Grid_CFRoute.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_CFRoute.Rows[i].Cells[j].Text = Grid_CFRoute.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_CFRoute_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_CFRoute.BottomPagerRow;


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
        BindGrid2(id3);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_CFRoute.PageCount ? Grid_CFRoute.PageCount - 1 : newPageIndex;
        Grid_CFRoute.PageIndex = newPageIndex;
        Grid_CFRoute.DataBind();
    }

    //新增
    protected void Btn_NewCFCFRoute_Click(object sender, EventArgs e)
    {
       condSearch4 = "";
        LblState.Text = "工艺";//用“认证”标识grid4处于认证工序检索，“工艺”标识处于认证工艺路线检索
        LblGongxuState.Text = "工艺";//用“认证”标识grid4处于认证工序编辑，“工艺”标识处于认证工艺路线编辑
        ((BoundField)Grid_Craft.Columns[1]).ReadOnly =true ;//注意类型转换，你所操作的列的类型是BoundField

        ((BoundField)Grid_Craft.Columns[2]).ReadOnly = false;
        //TxtOrder.Text = "";
        //TxtName.Text = "";
        id4 = id3;
        IQCBasicDataInfo IQC = new IQCBasicDataInfo();
        IQC = iQCBasicDataL.Search_ProType_ID(id3)[0];
        LblSCState.Text = IQC.PT_Name;
        BindGrid4(id4);
        Panel_SearchCraft.Visible = true;
        UpdatePanel_SearchCraft.Update();
    }

    //关闭
    protected void Btn_ClsCFCFRoute_Click(object sender, EventArgs e)
    {
        Panel_CFRoute.Visible = false;
        UpdatePanel_CFRoute.Update();
        if (Panel_GridCFCraft.Visible == false)
        {
            Panel_SearchCraft.Visible = false;
            UpdatePanel_SearchCraft.Update();
        }
        else if (Panel_GridCFCraft.Visible == true)
        {
            ((BoundField)Grid_Craft.Columns[1]).ReadOnly =false ;
            ((BoundField)Grid_Craft.Columns[2]).ReadOnly = true;
            LblState.Text = "认证";
            //TxtOrder.Text = "";
            //TxtName.Text = "";
            id4 = id2;
            IQCBasicDataInfo IQC = new IQCBasicDataInfo();
            IQC = iQCBasicDataL.Search_ProType_ID(id2)[0];
            LblSCState.Text = IQC.PT_Name;
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();

        }
    }
    #endregion

    #region 实际工艺路线检索栏
    //检索栏检索按钮
    //protected void Btn_SearchCraft_Click(object sender, EventArgs e)
    //{
    //   condSearch4 = "search";//用空表示绑定id，用“search”表示绑定检索条件
    //    if (TxtOrder.Text != "")
    //    {
    //        cond = " and PRD_Order like '%' + Ltrim(Rtrim('" + TxtOrder.Text + "'))+'%'";
    //    }
    //    if (TxtName.Text != "")
    //    {
    //        cond = cond + " and PRD_Order like '%' + Ltrim(Rtrim('" + TxtName.Text + "'))+'%'";
    //    }
    //    if (LblState.Text == "认证")
    //    {
    //        id4M=Convert.ToString( id2);
    //    }
    //    else if (LblState.Text == "工艺")
    //    {
    //        id4M = Convert.ToString(id3);
    //    }
    //    BindGrid4M(id4M, cond);
    //    this.UpdatePanel_SearchCraft.Update();
    //}

    //重置
    //protected void Btn_ResetCraft_Click(object sender, EventArgs e)
    //{
    //   condSearch4 = "search";
    //    TxtOrder.Text = "";
    //    TxtName.Text = "";
    //    cond = "";
    //    if (LblState.Text == "认证")
    //    {
    //        id4M = Convert.ToString(id2);
    //    }
    //    else if (LblState.Text == "工艺")
    //    {
    //        id4M = Convert.ToString(id3);
    //    }
    //    BindGrid4M(id4M, cond);
    //    this.UpdatePanel_SearchCraft.Update();
    //    UpdatePanel_SearchCraft.Update();
    //}

    //关闭
    //protected void Btn_ClsCraft_Click(object sender, EventArgs e)
    //{
    //    TxtOrder.Text = "";
    //    TxtName.Text = "";
    //    Panel_SearchCraft.Visible = false;
    //    UpdatePanel_SearchCraft.Update();
    //}

    #endregion

    #region 实际工艺路线表Grid4
    //操作Gridview的命令行
    //protected void Grid_Craft_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Edt_Craft")
    //    {
    //        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
    //        Grid_Craft.SelectedIndex = row.RowIndex;
    //        Guid guid = new Guid(e.CommandArgument.ToString());
    //        if (LblState.Text == "认证")
    //        {
    //            try
    //            {
    //                iQCBasicDataL.Insert_PRDetail_RZ(guid);
    //            }
    //            catch (Exception exc)
    //            {
    //                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
    //            }
    //            BindGrid2(id2);
    //            UpdatePanel_GridCFCraft.Update();
    //            BindGrid4(id4);
    //            UpdatePanel_Craft.Update();
    //        } 
    //        else if (LblState.Text == "工艺")
    //        {
    //            try
    //            {
    //                iQCBasicDataL.Insert_PRDetail_RZR(guid);
    //            }
    //            catch (Exception exc)
    //            {
    //                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
    //            }
    //            BindGrid3(id3);
    //            UpdatePanel_CFRoute.Update();
    //            BindGrid4(id4);
    //            UpdatePanel_Craft.Update();
    //        }       
    //    }

    //}

    //编辑
    protected void GridView_Craft_Editing(object sender, GridViewEditEventArgs e)
    {
        Grid_Craft.EditIndex = e.NewEditIndex;
        BindGrid4(id4);
        UpdatePanel_SearchCraft.Update();
    }

    //更新
    protected void GridView_Craft_Updating(object sender, GridViewUpdateEventArgs e)
    {
        if (LblGongxuState.Text == "认证")
        {
            Guid id = new Guid(Grid_Craft.DataKeys[e.RowIndex].Values["PRD_ID"].ToString());
            int PRD_RenZhengOrder,m1;
            if (((TextBox)(Grid_Craft.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString() == "")
            {
                try
                {
                    if (iQCBasicDataL.Insert_PRDetail_RZ(id) <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请输入工序或者确认认证工艺路线工序中没有该工序！')", true);
                        return;
                    }
                  //  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);
                }
                catch (Exception exc)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + exc + "')", true);
                } 
            }
            else  
            {
                if(int.TryParse(((TextBox)(Grid_Craft.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString(), out m1))
                 PRD_RenZhengOrder = m1;
                else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('序号请输入整数！')", true);
                        return;
                    }
                try
                {
                    if (iQCBasicDataL.Update_PRDetail_RZ(id, PRD_RenZhengOrder) <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请输入新工序或者确认认证工艺路线工序中没有该工序！')", true);
                        return;
                    }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('排序必须是整数！')", true);
                    return;
                }
            }
            BindGrid2(id2);
            UpdatePanel_GridCFCraft.Update();
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();
        }
        else if (LblGongxuState.Text == "工艺")
        {
            Guid id = new Guid(Grid_Craft.DataKeys[e.RowIndex].Values["PRD_ID"].ToString());
            int PRD_RouteOrder, m1;

            if (((TextBox)(Grid_Craft.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
            {
                try
                {
                    if (iQCBasicDataL.Insert_PRDetail_RZR(id) <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请输入工序或者确认认证工序中没有该工序！')", true);
                        return;
                    }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
                }
                catch (Exception exc)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + exc + "')", true);
                }
            }
            else
            {
                if (int.TryParse(((TextBox)(Grid_Craft.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString(), out m1))
                    PRD_RouteOrder = m1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('序号请输入整数！')", true);
                    return;
                }
                try
                {
                    if (iQCBasicDataL.Update_PRDetail_RZR(id, PRD_RouteOrder) <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请输入新工序或者确认认证工序中没有该工序！')", true);
                        return;
                    }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('排序必须是整数！')", true);
                    return;
                }
            }
            BindGrid3(id3);
            UpdatePanel_CFRoute.Update();
            BindGrid4(id4);
            UpdatePanel_SearchCraft.Update();
        }
        Grid_Craft.SelectedIndex = -1;
        Grid_Craft.EditIndex = -1;
        BindGrid4(id4);
        UpdatePanel_SearchCraft.Update();

    }

    //取消
    protected void GridView_Craft_CancelingEdit(object sender, GridViewCancelEditEventArgs e)//取消编辑
    {
        Grid_Craft.SelectedIndex = -1;
        Grid_Craft.EditIndex = -1;
        BindGrid4(id4);
        UpdatePanel_SearchCraft.Update();
    }

    //悬浮框显示
    protected void Grid_Craft_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Craft.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Craft.Rows[i].Cells.Count; j++)
            {
                Grid_Craft.Rows[i].Cells[j].ToolTip = Grid_Craft.Rows[i].Cells[j].Text;
                if (Grid_Craft.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Craft.Rows[i].Cells[j].Text = Grid_Craft.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    //protected void Grid_Craft_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView theGrid = sender as GridView;  // refer to the GridView
    //    int newPageIndex = 0;

    //    if (-2 == e.NewPageIndex)
    //    {
    //        TextBox txtNewPageIndex = null;
    //        GridViewRow pagerRow = this.Grid_Craft.BottomPagerRow;


    //        if (null != pagerRow)
    //        {
    //            txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
    //        }

    //        if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
    //        {
    //            newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
    //        }
    //    }
    //    else
    //    {
    //        newPageIndex = e.NewPageIndex;
    //    }
    //    if (condSearch4 == "")
    //    {
    //        BindGrid4(id4);
    //    }
    //    else if (condSearch4 == "search")
    //    {
    //        BindGrid4M(id4M,cond);
    //    }
    //    newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
    //    newPageIndex = newPageIndex >= this.Grid_CFRoute.PageCount ? this.Grid_Craft.PageCount - 1 : newPageIndex;
    //    this.Grid_Craft.PageIndex = newPageIndex;
    //    this.Grid_Craft.DataBind();
    //}

    //控制输入格式
    protected void Grid_Craft_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            if (LblGongxuState.Text == "认证")
            {
                for (int i = 1; i <= 1; i++)
                {
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "3");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");
                }
            }
            else if (LblGongxuState.Text == "工艺")
            {
                for (int i = 2; i <= 2; i++)
                {
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "3");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");
                } 
            }
        }
    }
    #endregion

    #region 私有调用函数
    //绑定认证产品型号Gridview1
    private void BindGrid1RZ(string PS_Name, string PT_Name)
    {

        Grid_ProType.DataSource = iQCBasicDataL.Search_ProType_RZ(PS_Name, PT_Name);
        Grid_ProType.DataBind();
    }

    //绑定其他产品型号Gridview1
    private void BindGrid1QT(string PS_Name, string PT_Name)
    {

        Grid_ProType.DataSource = iQCBasicDataL.Search_ProType_QT(PS_Name, PT_Name);
        Grid_ProType.DataBind();
    }

    //绑定认证工序Gridview2
    private void BindGrid2(Guid PT_ID)
    {

        Grid_CFCraft.DataSource = iQCBasicDataL.Search_PRDetail_RZ(PT_ID);
        Grid_CFCraft.DataBind();
    }

    //绑定认证工艺路线工序Gridview3
    private void BindGrid3(Guid PT_ID)
    {
        Grid_CFRoute.DataSource = iQCBasicDataL.Search_PRDetail_RZR(PT_ID);
        Grid_CFRoute.DataBind();
    }

    //绑定实际工艺路线工序Gridview4
    private void BindGrid4(Guid PT_ID)
    {
        Grid_Craft.DataSource = iQCBasicDataL.Search_PRDetail_SJ(PT_ID);
        Grid_Craft.DataBind();
    }

    //绑定模糊检索实际工艺路线工序Gridview4
    private void BindGrid4M(string PT_ID, string Condition)
    {
        Grid_Craft.DataSource = iQCBasicDataL.Search_PRDetail_SJM(PT_ID, Condition);
        Grid_Craft.DataBind();
    }
    #endregion
}