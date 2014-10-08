using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EquipMgt_EMEquipUpkeepItem : Page
{
    EquipUpkeepItemL equipUpkeepItemL =new EquipUpkeepItemL();
    EquipNameModelL equipNameModelL = new EquipNameModelL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "设备保养项目管理";
            Panel_Search.Visible = true;
            UpdatePanel_Search.Update();
            string condition = "";
            BindGrid_EquipUpkeepItem(condition);

            try
            {
                if (!((Session["UserRole"].ToString().Contains("设备保养项目管理"))))
                {
                    Response.Redirect("~/Default.aspx");

                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");

            }
        }
    }
    #region 绑定
    //绑定设备保养项目gridview
    private void BindGrid_EquipUpkeepItem(string condition)
    {
        Grid_EquipUpkeepItem.DataSource = equipUpkeepItemL.Search_EquipUpkeepItemInfo(condition);
        Grid_EquipUpkeepItem.DataBind();
    }
    #endregion 绑定

    #region 检索设备保养项目
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Grid_EquipUpkeepItem.EditIndex = -1;
        string condition = GetCondition();
        BindGrid_EquipUpkeepItem(condition);
        Panel_Item.Visible = true;
        UpdatePanel_Item.Update();
        Panel_searchname.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (Textname.Text.ToString() != "")
        {
            temp += " and EN_EquipName like '%" + Textname.Text.ToString() + "%'";
        }
        if (Textitems.Text.ToString() != "")
        {
            temp += " and  EUI_Items like '%" + Textitems.Text.ToString() + "%'";
        }
        if (Textperiod.Text.ToString() != "")
        {
            temp += " and  EUI_Period = '" + Textperiod.Text.ToString() + "'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        Grid_EquipUpkeepItem.EditIndex = -1;
        Textname.Text = "";
        Textitems.Text = "";
        Textperiod.Text = "";
        UpdatePanel_Search.Update();
        BindGrid_EquipUpkeepItem("");
        UpdatePanel_Item.Update();
        Panel_searchname.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Grid_EquipUpkeepItem.EditIndex = -1;
        BindGrid_EquipUpkeepItem("");
        UpdatePanel_Item.Update();
        Clear();
        Panel_searchname.Visible = true;
        UpdatePanel_searchname.Visible = true;
        Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo("");
        Grid_EquipName.DataBind();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    //私有清空的方法
    private void Clear()
    {
        Textnameadd.Text = "";
        Textaddname.Text = "";
        Textadditem.Text = "";
        Textaddperiod.Text = "";
    }
    #endregion 检索设备保养项目

    #region 保养项目Gridview相关

    //Gridview删除
    protected void Grid_EquipUpkeepItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_searchname.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        if (e.CommandName == "Delete_Item")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipUpkeepItem.SelectedIndex = row.RowIndex;

            Guid EUI_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipUpkeepItemL.Delete_EquipUpkeepItemInfo(EUI_ID);
            BindGrid_EquipUpkeepItem("");
            UpdatePanel_Item.Update();
        }
    }
    //显示编辑状态
    protected void Grid_EquipUpkeepItem_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grid_EquipUpkeepItem.EditIndex = e.NewEditIndex;
        string condition = GetCondition();
        BindGrid_EquipUpkeepItem(condition);
        Panel_searchname.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    //Gridview编辑
    protected void Grid_EquipUpkeepItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Guid eUI_ID = new Guid(Grid_EquipUpkeepItem.DataKeys[e.RowIndex]["EUI_ID"].ToString());
        Guid eN_ID = new Guid(Grid_EquipUpkeepItem.DataKeys[e.RowIndex]["EN_ID"].ToString());
        //项目不为空
        if (((TextBox)(Grid_EquipUpkeepItem.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('保养项目不能为空！')", true);
            return;
        }
        string eUI_Items = Convert.ToString(((TextBox)(Grid_EquipUpkeepItem.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
        //周期不为空
        if (((TextBox)(Grid_EquipUpkeepItem.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('保养周期不能为空！')", true);
            return;
        }
        decimal m2;
        if (!(Decimal.TryParse(((TextBox)(Grid_EquipUpkeepItem.Rows[e.RowIndex].Cells[4].Controls[0])).Text, out m2)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('保养周期只能为两位小数！')", true);
            return;
        }
        decimal eUI_Period = m2;
        //short eUI_Period = Convert.ToInt16 (((TextBox)(Grid_EquipUpkeepItem.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString());
        //判断重复
        DataSet ds = equipUpkeepItemL.Search_EquipUpkeepItemInfo("and EUI_Items = '" + eUI_Items + " ' and b.EN_ID='" + eN_ID + " ' and EUI_Period='" + eUI_Period + " '");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该保养项目未做任何改变！')", true);
            return;
        }
        Grid_EquipUpkeepItem.EditIndex = -1;
        equipUpkeepItemL.Update_EquipUpkeepItemInfo(eUI_ID, eN_ID, eUI_Items, eUI_Period);
        BindGrid_EquipUpkeepItem("");
        Textname.Text = "";
        Textitems.Text = "";
        Textperiod.Text = "";
        UpdatePanel_Search.Update();
        UpdatePanel_Item.Update();
    }
    //取消编辑
    protected void Grid_EquipUpkeepItem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_EquipUpkeepItem.EditIndex = -1;
        Textname.Text = "";
        Textitems.Text = "";
        Textperiod.Text = "";
        UpdatePanel_Search.Update();
        BindGrid_EquipUpkeepItem("");
    }
    //Gridview翻页
    protected void Grid_EquipUpkeepItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipUpkeepItem.BottomPagerRow;


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
        string condition = GetCondition();
        BindGrid_EquipUpkeepItem(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipUpkeepItem.PageCount ? Grid_EquipUpkeepItem.PageCount - 1 : newPageIndex;
        Grid_EquipUpkeepItem.PageIndex = newPageIndex;
        Grid_EquipUpkeepItem.DataBind();
    }
    //Gridview行变色
    protected void Grid_EquipUpkeepItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 保养项目Gridview相关

    #region 检索名称
    protected void Search_name_Click(object sender, EventArgs e)
    {
        Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo("and EN_EquipName like '%" + Textnameadd.Text.ToString() + "%'");
        Grid_EquipName.DataBind();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected void Clear_name_Click(object sender, EventArgs e)
    {
        Textnameadd.Text = "";
        Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo("");
        Grid_EquipName.DataBind();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected void Close_name_Click(object sender, EventArgs e)
    {
        Panel_searchname.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    #endregion 检索名称

    #region 设备名称gridview
    protected void Grid_EquipName_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        if (e.CommandName == "Add_Info")//点击查看设备型号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipName.SelectedIndex = row.RowIndex;

            Clear();
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EN_ID = al[0];
            Label_nid.Text = EN_ID;
            string EN_EquipName = al[1];
            Label_nname.Text = EN_EquipName;
            Textaddname.Text = Label_nname.Text;
            Panel_New.Visible = true;
            UpdatePanel_New.Update();
            //string condition = " AND x.EMT_ID='" + eMT_ID + "'";
            //BindGrid_EquipSpare(condition);
            //this.Panel_Model.Visible = true;
            //this.UpdatePanel_Model.Update();
        }
    }
    //Gridview翻页
    protected void Grid_EquipName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipName.BottomPagerRow;


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
        Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo("and EN_EquipName like '%" + Textnameadd.Text.ToString() + "%'");
        Grid_EquipName.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipName.PageCount ? Grid_EquipName.PageCount - 1 : newPageIndex;
        Grid_EquipName.PageIndex = newPageIndex;
        Grid_EquipName.DataBind();
    }
    //Gridview行变色
    protected void Grid_EquipName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 设备名称gridview

    #region 某名称下，新增保养项目
    protected void BtnOK_New_Click(object sender, EventArgs e)
    {
        if ((Textadditem.Text.ToString() == "") || (Textaddperiod.Text.ToString() == ""))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eN_ID = new Guid(Label_nid.Text.ToString());
        string eN_EquipName = Label_nname.Text.ToString();
        string eUI_Items = Textadditem.Text.ToString();
        decimal m1;
        if (!(Decimal.TryParse(Textaddperiod.Text, out m1)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('保养周期只能为两位小数！')", true);
            return;
        }
        decimal eUI_Period = m1;
        //short eUI_Period = Convert.ToInt16(this.Textaddperiod.Text.ToString());
        
        DataSet ds = equipUpkeepItemL.Search_EquipUpkeepItemInfo("and EUI_Items = '" + eUI_Items + " ' and b.EN_ID='" + eN_ID + " '");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备的保养项目，不能重名！')", true);
            return;
        }
        Grid_EquipUpkeepItem.EditIndex = -1;
        equipUpkeepItemL.Insert_EquipUpkeepItemInfo(eN_ID, eUI_Items,eUI_Period);
        BindGrid_EquipUpkeepItem("");
        //this.Panel_New.Visible = false;
        //this.UpdatePanel_New.Update();
        UpdatePanel_Item.Update();
        Textadditem.Text = "";
        Textaddperiod.Text = "";
    }
    protected void BtnCancel_New_Click(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
        }
    }
    #endregion 某名称下，新增保养项目
}
