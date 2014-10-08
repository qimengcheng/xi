using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HSFMgt_HSFMaterialCIMgt : Page
{
    HSFBasicDataL hSFBasicDataL = new HSFBasicDataL();
    HSFContrItemsInfo hSFContrItemsInfo = new HSFContrItemsInfo();
    static Guid idI = new Guid();
    static Guid idM = new Guid();
    static string Bindc1 = "", Bindc2 = "", BindcN = "", BindcB = "";//记录检索栏检索条件用于绑定gridview数据

    #region 页面加载
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridMa(Bindc1,Bindc2);
        string Role = Request.QueryString["state"].ToString();
        if (!Page.IsPostBack)
        {
            if (!((Session["UserRole"].ToString().Contains("物料管制项目维护")) || (Session["UserRole"].ToString().Contains("物料管制项目查看"))))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        if (Role == "MaItem" && Session["UserRole"].ToString().Contains("物料管制项目维护"))
        {
            Title = "物料管制项目维护";
        }
        else if (Role == "MaItem" && Session["UserRole"].ToString().Contains("物料管制项目查看"))
        {
            Title = "物料管制项目查看";
            Grid_Material.Columns[3].Visible = false;
        }
    }
    #endregion

    #region 物料检索栏
    //检索栏检索按钮
    protected void BtnSearchMa_Click(object sender, EventArgs e)
    {
        Bindc1 = TxtMaType.Text;
        Bindc2 = TxtMaName.Text;
        BindGridMa(Bindc1, Bindc2);
        UpdatePanel_GridMa.Update();
    }

    //重置
    protected void BtnResetMa_Click(object sender, EventArgs e)
    {
        TxtMaType.Text = "";
        TxtMaName.Text = "";
        UpdatePanel_SearchMaterial.Update();
        Bindc2 = Bindc1 = "";
        BindGridMa(Bindc1, Bindc2);
        UpdatePanel_GridMa.Update();
    }
    #endregion

    #region 物料列表GridView
    //操作Gridview的命令行
    protected void Grid_Material_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_Items")
        {
            Grid_Item.Columns[7].Visible = true;
            Grid_Item.Columns[8].Visible = false;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            LblSearchCond.Text = "ItemAll";
            LblGridItem.Text = "该物料的管制项目";
            Panel_SearchCI.Visible = true;
            Panel_GridItem.Visible = true;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            //this.Grid_BDOrgSheet_1.Rows[gvr.RowIndex].BackColor = System.Drawing.Color.SkyBlue;
            //Session["index"] = gvr.RowIndex;
            idM = new Guid(e.CommandArgument.ToString());
            BindGridMItem(idM);
            TxtItemName.Text = "";
            TxtStandard.Text = "";
            UpdatePanel_SearchCI.Update();
            UpdatePanel_GridItem.Update();

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
        BindGridMa(Bindc1,Bindc2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Material.PageCount ? Grid_Material.PageCount - 1 : newPageIndex;
        Grid_Material.PageIndex = newPageIndex;
        Grid_Material.DataBind();
    }
    #endregion

    #region 物料检索栏

    //检索栏检索物料按钮
    protected void BtnSearchItem_Click(object sender, EventArgs e)
    {
        Grid_Item.Columns[7].Visible = true;
        Grid_Item.Columns[8].Visible = false;
        LblGridItem.Text = "该物料的管制项目列表";
        BindcN = TxtItemName.Text;
        BindcB = TxtStandard.Text;
        LblSearchCond.Text = "ItemCond";
        BindGridMItemF(idM, BindcN, BindcB);
        UpdatePanel_GridItem.Update();
    }

    //检索栏检索其他按钮
    protected void BtnSearchAll_Click(object sender, EventArgs e)
    {
        Grid_Item.Columns[7].Visible = false;
        Grid_Item.Columns[8].Visible = true;
        LblGridItem.Text = "所有管制项目列表";
        BindcN = TxtItemName.Text;
        BindcB = TxtStandard.Text;
        LblSearchCond.Text = "Rest";
        BindGridIAll(idM,BindcN, BindcB);
        UpdatePanel_GridItem.Update();
    }

    //重置
    protected void BtnResetItem_Click(object sender, EventArgs e)
    {
        TxtItemName.Text = "";
        TxtStandard.Text = "";
        UpdatePanel_SearchCI.Update();
        BindcN = BindcB = "";
        if (LblSearchCond.Text == "ItemAll")
        {
            BindGridMItem(idM);
        }
        else if (LblSearchCond.Text == "ItemCond")
        {
            BindGridMItemF(idM, BindcN, BindcB);
        }
        else if (LblSearchCond.Text == "Rest")
        {
            BindGridIAll(idM, BindcN, BindcB);
        }
        UpdatePanel_GridItem.Update();
    }

    //取消按钮
    protected void BtnCls_Item_Click(object sender, EventArgs e)
    {
        if (Panel_SearchCI.Visible)
        {
            Panel_SearchCI.Visible = false;
            UpdatePanel_SearchCI.Update();
        }
        if (Panel_GridItem.Visible)
        {
            Panel_GridItem.Visible = false;
            UpdatePanel_GridItem.Update();
        }
    }

    #endregion

    #region 物料GridView
    //操作Gridview的命令行
    protected void Grid_Item_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Chs_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Item.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            idI = new Guid(e.CommandArgument.ToString());
            try
            {
                if (hSFBasicDataL.Insert_HSFMaterialItemRelation(idI, idM) <= 0)
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
            BindGridIAll(idM,"", "");
            UpdatePanel_GridItem.Update();

        }
        if (e.CommandName == "Delete_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Item.SelectedIndex = row.RowIndex;
            idI = new Guid(e.CommandArgument.ToString());
            hSFBasicDataL.Delete_HSFMaterialItemRelation(idI, idM);
            if (LblSearchCond.Text == "ItemAll")
            {
                BindGridMItem(idM);
            }
            else if (LblSearchCond.Text == "ItemCond")
            {
                BindGridMItemF(idM, BindcN, BindcB);
            }
            else if (LblSearchCond.Text == "Rest")
            {
                BindGridIAll(idM, BindcN, BindcB);
            }
            UpdatePanel_GridItem.Update();
        }
    }

    //悬浮框显示
    protected void Grid_Item_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Item.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Item.Rows[i].Cells.Count; j++)
            {
                Grid_Item.Rows[i].Cells[j].ToolTip = Grid_Item.Rows[i].Cells[j].Text;
                if (Grid_Item.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Item.Rows[i].Cells[j].Text = Grid_Item.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }

    //翻页
    protected void Grid_Item_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Item.BottomPagerRow;


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
        if (LblSearchCond.Text == "ItemAll")
        {
            BindGridMItem(idM);
        }
        else if (LblSearchCond.Text == "ItemCond")
        {
            BindGridMItemF(idM, BindcN, BindcB);
        }
        else if (LblSearchCond.Text == "Rest")
        {
            BindGridIAll(idM, BindcN, BindcB);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Item.PageCount ? Grid_Item.PageCount - 1 : newPageIndex;
        Grid_Item.PageIndex = newPageIndex;
        Grid_Item.DataBind();
    }
    #endregion

    #region 私有调用函数
    //绑定物料Gridview
    private void BindGridMa(string condition1, string condition2)
    {

       Grid_Material.DataSource = hSFBasicDataL.Search_IMMaterialBasicData_M1(condition1, condition2);
       Grid_Material.DataBind();
    }

    
    //绑定模糊检索其他管制项目Gridview
    private void BindGridIAll(Guid id, string HSFCI_ItemName, string HSFCI_Boundary)
    {
        Grid_Item.DataSource = hSFBasicDataL.Search_HSFContrItems_Rest(id,HSFCI_ItemName, HSFCI_Boundary);
        Grid_Item.DataBind();
    }

    //绑定某物料的管制项目Gridview
    private void BindGridMItem(Guid ID)
    {
        Grid_Item.DataSource = hSFBasicDataL.Search_HSFContrItems_M(ID);
        Grid_Item.DataBind();
    }

    //绑定模糊检索某物料的管制项目Gridview
    private void BindGridMItemF(Guid ID, string cond1, string cond2)
    {
        Grid_Item.DataSource = hSFBasicDataL.Search_HSFContrItems_FM(ID, cond1, cond2);
        Grid_Item.DataBind();
    }

    #endregion
}