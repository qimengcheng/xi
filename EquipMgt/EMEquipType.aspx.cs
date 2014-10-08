using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class EquipMgt_EMEquipType : Page
{
    EquipTypeL equipTypeL = new EquipTypeL();
    EMEquipTypeTableInfo eMEquipTypeTableInfo = new EMEquipTypeTableInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "设备类型管理";
            UpdatePanel_TypeItem.Visible = true;
            BindGrid_EquipType("");

            try
            {
                if (!((Session["UserRole"].ToString().Contains("设备类型管理"))))
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
    private void BindGrid_EquipType(string condition)
    {
        Grid_EquipType.DataSource = equipTypeL.Search_EquipTypeTableInfo(condition);
        Grid_EquipType.DataBind();
    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Grid_EquipType.EditIndex = -1;
        string condition = GetCondition();
        Grid_EquipType.DataSource = equipTypeL.Search_EquipTypeTableInfo(condition);
        Grid_EquipType.DataBind();
        UpdatePanel_TypeItem.Update();
        Panel_NewType.Visible = false;
        UpdatePanel_NewType.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (Txtname.Text.ToString() != "")
        {
            temp += " and ETT_Type like '%" + Txtname.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        Grid_EquipType.EditIndex = -1;
        Txtname.Text = "";
        UpdatePanel_Search.Update();
        BindGrid_EquipType("");
        UpdatePanel_TypeItem.Update();
        Panel_NewType.Visible = false;
        UpdatePanel_NewType.Update();
    }
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Grid_EquipType.EditIndex = -1;
        Grid_EquipType.SelectedIndex = -1;
        BindGrid_EquipType("");
        UpdatePanel_TypeItem.Update();
        Clear();
        Panel_NewType.Visible = true;
        UpdatePanel_NewType.Visible = true;
        UpdatePanel_NewType.Update();
    }
    //私有清空的方法
    private void Clear()
    {
        TxtAddType.Text = "";
    }

    #region Gridview相关

    //Gridview删除设备类型
    protected void Grid_EquipType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_NewType.Visible = false;
        UpdatePanel_NewType.Update();

        if (e.CommandName == "Delete_Type")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipType.SelectedIndex = row.RowIndex;

            Guid ETT_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipTypeL.Delete_EquipTypeTableInfo(ETT_ID);
            BindGrid_EquipType("");
            UpdatePanel_TypeItem.Update();
        }
    }
    //显示编辑设备类型状态
    protected void Grid_EquipType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_NewType.Visible = false;
        UpdatePanel_NewType.Update();
        Grid_EquipType.EditIndex = e.NewEditIndex;
        BindGrid_EquipType("and ETT_Type like '%" + Txtname.Text.ToString() + "%'");
    }
    //Gridview编辑设备类型
    protected void Grid_EquipType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid eTT_ID = new Guid(Grid_EquipType.DataKeys[e.RowIndex].Value.ToString());
        //类型不为空
        if (((TextBox)(Grid_EquipType.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('设备类型不能为空！')", true);
            return;
        }
        string eTT_Type = Convert.ToString(((TextBox)(Grid_EquipType.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        DataSet ds = equipTypeL.Search_EquipTypeTableInfo("and ETT_Type = '" + eTT_Type + " '");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0) 
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备类型名称，不能重名！')", true);
            return;
        }
        Grid_EquipType.EditIndex = -1;
        eMEquipTypeTableInfo.ETT_ID = eTT_ID;
        eMEquipTypeTableInfo.ETT_Type = eTT_Type;
        equipTypeL.Update_EquipTypeTableInfo(eMEquipTypeTableInfo);
        BindGrid_EquipType("");
        Txtname.Text = "";
        UpdatePanel_Search.Update();
        UpdatePanel_TypeItem.Update();
    }
    //取消编辑
    protected void Grid_EquipType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_EquipType.EditIndex = -1;
        Txtname.Text = "";
        UpdatePanel_Search.Update();
        BindGrid_EquipType("");
    }

    //Gridview翻页
    protected void Grid_EquipType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {   
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipType.BottomPagerRow;


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
        BindGrid_EquipType("");
        Grid_EquipType.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        Grid_EquipType.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipType.PageCount ? Grid_EquipType.PageCount - 1 : newPageIndex;
        Grid_EquipType.PageIndex = newPageIndex;
        Grid_EquipType.DataBind();
    }

     //Gridview行变色
    protected void Grid_EquipType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion

    //新增确认
    protected void BtnOK_NewType_Click(object sender, EventArgs e)
    {
        if (TxtAddType.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewType, GetType(), "alert", "alert('标记*的为必填项，请填写完整！！')", true);
            return;
        }
        DataSet ds = equipTypeL.Search_EquipTypeTableInfo("and ETT_Type = '" + TxtAddType.Text.ToString() + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备类型名称，不能重名！')", true);
            return;
        }
        string eTT_Type = TxtAddType.Text.ToString();
        eMEquipTypeTableInfo.ETT_Type = eTT_Type;
        equipTypeL.Insert_EquipTypeTableInfo(eMEquipTypeTableInfo);
        BindGrid_EquipType("");
        Panel_NewType.Visible = false;
        UpdatePanel_TypeItem.Update();
    }

    //新增取消
    protected void BtnCancel_Info_FailureMode_Click(object sender, EventArgs e)
    {
        if (Panel_NewType.Visible)
        {
            Panel_NewType.Visible = false;
        }
    }  
}