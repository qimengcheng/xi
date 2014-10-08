using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EquipMgt_EMEquipName_Model : Page
{
    EquipNameModelL equipNameModelL = new EquipNameModelL();
    EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo = new EMEquipName_EMEquipModelTableInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdatePanel_Name.Visible = true;
            BindGrid_EquipName("");

            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "EMName" && Session["UserRole"].ToString().Contains("设备基础信息管理"))
                {
                    Title = "设备基础信息管理";
                }
                if (Lab_Status.Text == "EMNameLook" && Session["UserRole"].ToString().Contains("设备基础信息查看"))
                {
                    Title = "设备基础信息查看";
                    New_name.Visible = false;
                    Grid_EquipName.Columns[4].Visible = false;
                    Grid_EquipName.Columns[5].Visible = false;
                    New_model.Visible = false;
                    Grid_EquipModel.Columns[7].Visible = false;
                    Grid_EquipModel.Columns[8].Visible = false;
                    New_spare.Visible = false;
                    Grid_EquipSpare.Columns[8].Visible = false;
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
    //绑定设备名称
    private void BindGrid_EquipName(string condition)
    {
        Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo(condition);
        Grid_EquipName.DataBind();
    }
    //某设备名称下，绑定设备型号
    private void BindGrid_EquipModel(string condition)
    {
        Grid_EquipModel.DataSource = equipNameModelL.Search_EquipModelTableInfo(condition);
        Grid_EquipModel.DataBind();
    }
    //模糊查询,绑定备件表
    private void BindGrid_EquipSpare(string condition)
    {
        Grid_EquipSpare.DataSource = equipNameModelL.Search_EquipFreqUsedSpareInfo(condition);
        Grid_EquipSpare.DataBind();
    }
    //模糊查询,绑定备选备件表
    private void BindGrid_NewEquipSpare(string condition)
    {
        Grid_NewEquipSpare.DataSource = equipNameModelL.Search_EquipFreqUsedSpare_InsertInfo(condition);
        Grid_NewEquipSpare.DataBind();
    }
    //设备型号对应物料信息
    private void BindGridView1(string condition)
    {
        GridView1.DataSource = equipNameModelL.Search_EquipModelTable_IMMaterialBasicData(condition);
        GridView1.DataBind();
    }
    #endregion 绑定

    #region 检索名称

    //检索设备名称
    protected void Search_name_Click(object sender, EventArgs e)
    {
        Grid_EquipName.EditIndex = -1;
        string condition = GetCondition2();
        Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo(condition);
        Grid_EquipName.DataBind();
        UpdatePanel_Name.Update();
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_Model.Visible = false;
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected string GetCondition2()
    {
        string condition;
        string temp = "";
        if (Txtname.Text.ToString() != "")
        {
            temp += " and EN_EquipName like '%" + Txtname.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    protected void Clear_name_Click(object sender, EventArgs e)
    {
        Grid_EquipName.EditIndex = -1;
        Txtname.Text = "";
        UpdatePanel_Searchname.Update();
        BindGrid_EquipName("");
        UpdatePanel_Name.Update();
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_Model.Visible = false;
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
;    }
    protected void New_name_Click(object sender, EventArgs e)
    {
        Grid_EquipName.EditIndex = -1;
        Grid_EquipName.SelectedIndex = -1;
        BindGrid_EquipName("");
        UpdatePanel_Name.Update();
        Clear();
        Panel_NewName.Visible = true;
        UpdatePanel_NewName.Update();
        Panel_Model.Visible = false;
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    
    //私有清空的方法
    private void Clear()
    {
        NewName.Text = "";
        NewModel.Text = "";
        Txtmodel.Text = "";
        TextMaterialName.Text = "";
        TextMaterialCode.Text = "";
        TextSpecificationModel.Text = "";
        Textnewspname.Text = "";
        Textnewspno.Text = "";
        Textnewspmodel.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    #endregion 检索名称

    #region 设备名称Gridview相关
    protected void Grid_EquipName_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();

        if (e.CommandName == "Look_Model")//点击查看设备型号
        {
            Clear();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipName.SelectedIndex = row.RowIndex;
            //this.Label_enid.Text = Convert.ToString(e.CommandArgument);
            //string eN_ID = e.CommandArgument.ToString(); 
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string eN_ID = al[0];
            Label_enid.Text = eN_ID;
            string enname = al[1];
            Label_enname.Text = enname;
            Panel_Model.Visible = true;
            Label_enname0.Text = Label_enname.Text;
            BindGrid_EquipModel(" and EN_ID='" + eN_ID + "'");
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Grid_EquipName.EditIndex = -1;
            BindGrid_EquipName("");
            UpdatePanel_Name.Update();
        }
        if (e.CommandName == "Delete_Name")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipName.SelectedIndex = row.RowIndex;

            Guid eN_ID = new Guid(Convert.ToString(e.CommandArgument));
            Label_enid.Text = Convert.ToString(eN_ID);
            equipNameModelL.Delete_EquipNameInfo(eN_ID);
            BindGrid_EquipName("");
            UpdatePanel_Name.Update();
        }
    }
    //显示编辑设备名称状态
    protected void Grid_EquipName_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_Model.Visible = false;
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update(); 
        Panel1.Visible = false;
        UpdatePanel1.Update();

        Grid_EquipName.EditIndex = e.NewEditIndex;
        BindGrid_EquipName("and EN_EquipName like '%" + Txtname.Text.ToString() + "%'");
    }
    //Gridview编辑设备名称
    protected void Grid_EquipName_RowUpdating(object sender, GridViewUpdateEventArgs e)
    { 
        Guid eN_ID = new Guid(Grid_EquipName.DataKeys[e.RowIndex].Value.ToString());
        //名称
        if (((TextBox)(Grid_EquipName.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('设备名称不能为空！')", true);
            return;
        }
        string eN_EquipName = Convert.ToString(((TextBox)(Grid_EquipName.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        DataSet ds = equipNameModelL.Search_EquipNameInfo("and EN_EquipName = '" + eN_EquipName + " '");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备名称，不能重名！')", true);
            return;
        }
        Grid_EquipName.EditIndex = -1;
        eMEquipName_EMEquipModelTableInfo.EN_ID = eN_ID;
        eMEquipName_EMEquipModelTableInfo.EN_EquipName = eN_EquipName;
        equipNameModelL.Update_EquipNameInfo(eMEquipName_EMEquipModelTableInfo);
        BindGrid_EquipName("");
        Txtname.Text = "";
        UpdatePanel_Searchname.Update();
        UpdatePanel_Name.Update();
    }
    //取消编辑
    protected void Grid_EquipName_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_EquipName.EditIndex = -1;
        Txtname.Text = "";
        UpdatePanel_Searchname.Update();
        BindGrid_EquipName("");
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
        BindGrid_EquipName("");
        //this.Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo("");
        //this.Grid_EquipName.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipName.PageCount ? Grid_EquipName.PageCount - 1 : newPageIndex;
        Grid_EquipName.PageIndex = newPageIndex;
        Grid_EquipName.DataBind();
    }
    //Gridview行变色
    protected void Grid_EquipName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion

    #region 新增设备名称
    protected void BtnOK_NewName_Click(object sender, EventArgs e)
    {
        if (NewName.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewName, GetType(), "alert", "alert('标记*的为必填项，请填写完整！！')", true);
            return;
        }
        DataSet ds = equipNameModelL.Search_EquipNameInfo("and EN_EquipName = '" + NewName.Text+"'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备名称，不能重名！')", true);
            return;
        }
        string eN_EquipName = NewName.Text.ToString();
        eMEquipName_EMEquipModelTableInfo.EN_EquipName = eN_EquipName;
        equipNameModelL.Insert_EquipNameInfo(eMEquipName_EMEquipModelTableInfo);
        BindGrid_EquipName("");
        Panel_NewName.Visible = false;
        UpdatePanel_Name.Update();
    }
    protected void BtnCancel_NewName_Click(object sender, EventArgs e)
    {
        if (Panel_NewName.Visible)
        {
            Panel_NewName.Visible = false;
        }
    }
    #endregion 新增设备名称

    #region 检索型号
    protected void Search_model_Click(object sender, EventArgs e)
    {
        Grid_EquipModel.EditIndex = -1;
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Guid eN_ID = new Guid(Label_enid.Text.ToString());
        string condition = GetCondition3();
        Grid_EquipModel.DataSource = equipNameModelL.Search_EquipModelTableInfo(condition);
        Grid_EquipModel.DataBind();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected string GetCondition3()
    {
        string condition;
        string temp = "";
        if (Txtmodel.Text.ToString() != "")
        {
            temp += " and EMT_Type like '%" + Txtmodel.Text.ToString() + "%'";
        }
        temp += " and EN_ID ='" + new Guid(Label_enid.Text.ToString()) + "'";
        condition = temp;
        return condition;
    }
    protected void Clear_model_Click(object sender, EventArgs e)
    {
        Grid_EquipModel.EditIndex = -1;
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Txtmodel.Text = "";
        BindGrid_EquipModel("and EN_ID ='" + new Guid(Label_enid.Text.ToString()) + "'");
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Close_model_Click(object sender, EventArgs e)
    {
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_Model.Visible = false;
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void New_model_Click(object sender, EventArgs e)
    {
        Clear();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Panel_NewModel.Visible = true;
        UpdatePanel_NewModel.Visible = true;
        TextBox1.Text = Label_enname.Text;
        UpdatePanel_NewModel.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Grid_EquipModel.EditIndex = -1;
        BindGrid_EquipModel("and EN_ID ='" + new Guid(Label_enid.Text.ToString()) + "'");
    }
    #endregion 检索型号

    #region 设备型号Gridview相关
    protected void Grid_EquipModel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        if (e.CommandName == "Look_Spare")//点击查看设备型号
        {
            //this.Label_enid.Text = Convert.ToString(e.CommandArgument);
            //string eN_ID = e.CommandArgument.ToString(); 
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipModel.SelectedIndex = row.RowIndex;

            Grid_EquipModel.EditIndex = -1;
            BindGrid_EquipModel("and EN_ID ='" + new Guid(Label_enid.Text.ToString()) + "'");
            Clear();
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string eMT_ID = al[0];
            Label_mid.Text = eMT_ID;
            string eMT_Type = al[1];
            Label_mname.Text = eMT_Type;
            Panel_Spare.Visible = true;
            Label_enname1.Text = Label_enname.Text;
            Label_mname1.Text = Label_mname.Text;
            string condition = " AND x.EMT_ID='" + eMT_ID + "'";
            BindGrid_EquipSpare(condition);
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "Delete_Model")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipModel.SelectedIndex = row.RowIndex;

            Guid EN_ID = new Guid(Label_enid.Text.ToString());
            Guid EMT_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipNameModelL.Delete_EquipModelTableInfo(EN_ID,EMT_ID);
            BindGrid_EquipModel("and EN_ID='"+Label_enid.Text.ToString()+"'");
            //this.UpdatePanel_Model.Update();
        }
    }
    //显示编辑设备型号状态
    protected void Grid_EquipModel_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        Grid_EquipModel.EditIndex = e.NewEditIndex;
        string condition = GetCondition3();
        BindGrid_EquipModel(condition);
    }
    //Gridview编辑设备型号
    protected void Grid_EquipModel_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid eN_ID = new Guid(Label_enid.Text.ToString());
        Guid eMT_ID = new Guid(Grid_EquipModel.DataKeys[e.RowIndex].Value.ToString());
        //型号不为空
        if (((TextBox)(Grid_EquipModel.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('设备型号不能为空！')", true);
            return;
        }
        string eMT_Type = Convert.ToString(((TextBox)(Grid_EquipModel.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
        DataSet ds = equipNameModelL.Search_EquipModelTableInfo("and EN_ID='" + eN_ID + "'  and EMT_Type='" + eMT_Type + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备型号，不能重名！')", true);
            return;
        }
        Grid_EquipModel.EditIndex = -1;
        eMEquipName_EMEquipModelTableInfo.EN_ID = eN_ID;
        eMEquipName_EMEquipModelTableInfo.EMT_ID = eMT_ID;
        eMEquipName_EMEquipModelTableInfo.EMT_Type = eMT_Type;
        equipNameModelL.Update_EquipModelTableInfo(eMEquipName_EMEquipModelTableInfo);
        BindGrid_EquipModel("and EN_ID='" + eN_ID + "' ");
        Txtmodel.Text = "";
        //this.UpdatePanel_Model.Update();
    }
    //取消编辑
    protected void Grid_EquipModel_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_EquipModel.EditIndex = -1;
        Txtmodel.Text = "";
        BindGrid_EquipModel("and EN_ID='" + Label_enid.Text.ToString() + "'");
    }

    //Gridview翻页
    protected void Grid_EquipModel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipModel.BottomPagerRow;


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
        //Guid EN_ID = new Guid(this.Label_enid.Text.ToString());
        //this.Grid_EquipModel.DataSource = equipNameModelL.Search_EquipModelTable_DataInfo(EN_ID);
        //this.Grid_EquipModel.DataBind();
        //若之前没有绑定BindGrid_EquipModel，则每次绑定Grid_EquipModel时只需调用BindGrid_EquipModel，否则每次都要用上述这种方式绑定。
        //Guid EN_ID = new Guid(this.Label_enid.Text.ToString());
        BindGrid_EquipModel("and EN_ID='" + Label_enid.Text.ToString() + "'");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipModel.PageCount ? Grid_EquipModel.PageCount - 1 : newPageIndex;
        Grid_EquipModel.PageIndex = newPageIndex;
        Grid_EquipModel.DataBind();
    }
    //Gridview行变色
    protected void Grid_EquipModel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion

    #region 某名称下，新增型号
    protected void BtnOK_NewModel_Click(object sender, EventArgs e)
    {
        if (NewModel.Text.ToString() == "" || TextBox2.Text.ToString() == "" || TextBox3.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewModel, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eN_ID = new Guid(Label_enid.Text.ToString());
        string eMT_Type = NewModel.Text.ToString();
        Guid iMMBD_MaterialID = new Guid(Label99.Text.ToString());
        DataSet ds = equipNameModelL.Search_EquipModelTableInfo("and EN_ID='" + eN_ID + "' and EMT_Type='" + eMT_Type + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备型号，不能重名！')", true);
            return;
        }
        eMEquipName_EMEquipModelTableInfo.EN_ID = eN_ID;
        eMEquipName_EMEquipModelTableInfo.EMT_Type = eMT_Type;
        eMEquipName_EMEquipModelTableInfo.IMMBD_MaterialID = iMMBD_MaterialID;
        equipNameModelL.Insert_EquipModelTableInfo(eMEquipName_EMEquipModelTableInfo);
        //BindGrid_EquipModel(Convert.ToString(eN_ID));
        BindGrid_EquipModel("and EN_ID ='" + eN_ID + "'");
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void BtnCancel_NewModel_Click(object sender, EventArgs e)
    {
        if (Panel_NewModel.Visible)
        {
            Panel_NewModel.Visible = false;
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        BindGridView1("");
        TextBox4.Text = "";
        TextBox5.Text = "";
        UpdatePanel1.Update();
    }
    #endregion 某名称下，新增型号

    #region 检索备件
    protected void Search_spare_Click(object sender, EventArgs e)
    {
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        string condition = GetCondition();
        BindGrid_EquipSpare(condition);
        Panel_Spare.Visible = true;
        //this.UpdatePanel_Spare.Update();
    }
        //获取模糊查询条件
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (TextMaterialName.Text.ToString() != "")
        {
            temp += " and IMMBD_MaterialName like '%" + TextMaterialName.Text.ToString() + "%'";
        }
        if (TextMaterialCode.Text.ToString() != "")
        {
            temp += " and  IMMBD_MaterialCode like '%" + TextMaterialCode.Text.ToString() + "%'";
        }
        if (TextSpecificationModel.Text.ToString() != "")
        {
            temp += " and  IMMBD_SpecificationModel like '%" + TextSpecificationModel.Text.ToString() + "%'";
        }
        temp += "and x.EMT_ID='"+Label_mid.Text.ToString()+"'";
        //temp += "and this.Label_enid.Text";
        //this.labelcodition.Text = conditon;
        condition = temp;
        return condition;
    }
    protected void Clear_spare_Click(object sender, EventArgs e)
    {
        TextMaterialName.Text = "";
        TextMaterialCode.Text = "";
        TextSpecificationModel.Text = "";
        BindGrid_EquipSpare("and x.EMT_ID='" + Label_mid.Text.ToString() + "'");
        Panel_NewName.Visible = false;
        UpdatePanel_NewName.Update();
        Panel_NewModel.Visible = false;
        UpdatePanel_NewModel.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
    }
    protected void Close_spare_Click(object sender, EventArgs e)
    {
        Panel_Spare.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        //this.UpdatePanel_Spare.Update();
    }
    protected void New_spare_Click(object sender, EventArgs e)
    {
        Clear();
        Panel_NewSpare.Visible = true;
        UpdatePanel_NewSpare.Visible = true;
        string condition = "";
        BindGrid_NewEquipSpare(condition);
        //addspareequipname.Text = this.Label_enname.Text;
        //addspareequipmadel.Text = this.Label_mname.Text;
        UpdatePanel_NewSpare.Update();
    }
    #endregion 检索备件

    #region 备件Gridview相关
    protected void Grid_EquipSpare_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        if (e.CommandName == "Delete_Spare")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipSpare.SelectedIndex = row.RowIndex;

            Guid EMT_ID = new Guid(Label_mid.Text.ToString());
            Guid EFUS_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipNameModelL.Delete_EquipFreqUsedSpareInfo(EMT_ID,EFUS_ID);
            string condition = " AND x.EMT_ID='" + EMT_ID + "'";
            BindGrid_EquipSpare(condition);
            //this.UpdatePanel_Spare.Update();
            
        }
    }
    //Gridview翻页
    protected void Grid_EquipSpare_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipSpare.BottomPagerRow;


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
        BindGrid_EquipSpare(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipSpare.PageCount ? Grid_EquipSpare.PageCount - 1 : newPageIndex;
        Grid_EquipSpare.PageIndex = newPageIndex;
        Grid_EquipSpare.DataBind();
    }
    //Gridview行变色
    protected void Grid_EquipSpare_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    #endregion

    #region 某型号下，增加备件
    //检索备选备件
    protected void Search_newspare_Click(object sender, EventArgs e)
    {
        string condition = GetCondition1();
        BindGrid_NewEquipSpare(condition);
        Panel_NewSpare.Visible = true;
        //this.UpdatePanel_Spare.Update();
    }
    protected string GetCondition1()
    {
        string condition;
        string temp = "";
        if (Textnewspname.Text.ToString() != "")
        {
            temp += " and IMMBD_MaterialName like '%" + Textnewspname.Text.ToString() + "%'";
        }
        if (Textnewspno.Text.ToString() != "")
        {
            temp += " and  IMMBD_MaterialCode like '%" + Textnewspno.Text.ToString() + "%'";
        }
        if (Textnewspmodel.Text.ToString() != "")
        {
            temp += " and  IMMBD_SpecificationModel like '%" + Textnewspmodel.Text.ToString() + "%'";
        }
        //temp += "and X.EMT_ID='" + this.Label_mid.Text.ToString() + "'";
        condition = temp;
        return condition;
    }
    protected void Clear_newspare_Click(object sender, EventArgs e)
    {
        Textnewspname.Text = "";
        Textnewspno.Text = "";
        Textnewspmodel.Text = "";
        //BindGrid_NewEquipSpare("and X.EMT_ID='" + this.Label_mid.Text.ToString() + "'");
        BindGrid_NewEquipSpare("");
    }

    //选中的行，翻页不消失
    protected ArrayList SelectedItems
    {
        get
        {
            return (ViewState["mySelectedItems"] != null) ? (ArrayList)ViewState["mySelectedItems"] : null;
        }
        set
        {
            ViewState["mySelectedItems"] = value;
        }
    }
    protected void CollectSelected()
    {
        ArrayList selectedItems = null;
        if (SelectedItems == null)
            selectedItems = new ArrayList();
        else
            selectedItems = SelectedItems;
        //获取选择的记录
        for (int i = 0; i < Grid_NewEquipSpare.Rows.Count; i++)
        {
            //string id = this.GridView_ProType.Rows[i].Cells[1].Text;
            CheckBox cb = Grid_NewEquipSpare.Rows[i].FindControl("ckb") as CheckBox;
            string id = Grid_NewEquipSpare.DataKeys[i].Values[0].ToString();
            if (selectedItems.Contains(id) && !cb.Checked)
                selectedItems.Remove(id);
            if (!selectedItems.Contains(id) && cb.Checked)
                selectedItems.Add(id);
        }
        SelectedItems = selectedItems;
    }
    //备选备件GridView
    protected void Grid_NewEquipSpare_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void Grid_NewEquipSpare_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_NewEquipSpare.BottomPagerRow;

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
        CollectSelected();
        //BindGrid_NewEquipSpare("");
        string condition = GetCondition1();
        BindGrid_NewEquipSpare(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_NewEquipSpare.PageCount ? Grid_NewEquipSpare.PageCount - 1 : newPageIndex;
        Grid_NewEquipSpare.PageIndex = newPageIndex;
        Grid_NewEquipSpare.DataBind();
    }
    protected void Grid_NewEquipSpare_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //这里的处理是为了回显之前选中的情况
        if (e.Row.RowIndex > -1 && SelectedItems != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("ckb") as CheckBox;
            string id = Grid_NewEquipSpare.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }

    //选择备件以及提交
    protected void BtnOK_NewSpare_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Grid_NewEquipSpare.Rows)
        {
            CheckBox cb = item.FindControl("ckb") as CheckBox;
            if (cb.Checked)
            {
                Guid eMT_ID = new Guid(Label_mid.Text.ToString());
                Guid iMMBD_MaterialID = new Guid(Grid_NewEquipSpare.DataKeys[item.RowIndex].Value.ToString());
                string condition = "and x.EMT_ID='"+ eMT_ID +"' and b.IMMBD_MaterialID='"+ iMMBD_MaterialID+"'";
                DataSet ds = equipNameModelL.Search_EquipFreqUsedSpareInfo(condition);
                //DataTable dt = ds.Tables[0];
                //string d = Convert.ToString( dt.Rows[0][0]);
                //if (!(ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的则添加。
                //{
                //    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, this.GetType(), "aa", "alert('系统中已有该设备的备件，不能重复选择!')", true);
                //}
                if (!(ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的也不添加。
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, GetType(), "aa", "alert('系统中已有该设备的备件，不能重复选择!')", true);
                    return;
                }
                else
                {
                    equipNameModelL.Insert_EquipFreqUsedSpareInfo(eMT_ID, iMMBD_MaterialID);
                    //string condition = "and x.EMT_ID='eMT_ID'";
                    BindGrid_EquipSpare("and x.EMT_ID='" + eMT_ID + "'");
                    //this.UpdatePanel_Spare.Update();
                    UpdatePanel_NewSpare.Update();
                }
            }
        }
    }
    protected void BtnCancel_NewSpare_Click(object sender, EventArgs e)
    {
        if (Panel_NewSpare.Visible)
        {
            Panel_NewSpare.Visible = false;
        }
    }

    #endregion 某型号下，增加备件

    #region 物料信息及GridView1
    protected void Button2_Click(object sender, EventArgs e)
    {
        string condition = GetCondition9();
        BindGridView1(condition);
    }
    protected string GetCondition9()
    {
        string condition;
        string temp = "";
        if (TextBox4.Text.ToString() != "")
        {
            temp += " and IMMBD_MaterialName like '%" + TextBox4.Text.ToString() + "%'";
        }
        if (TextBox5.Text.ToString() != "")
        {
            temp += " and  IMMBD_SpecificationModel like '%" + TextBox5.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox5.Text = "";
        BindGridView1("");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        bool temp = false;

        foreach (GridViewRow item in GridView1.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                Guid iMMBD_MaterialID = new Guid(GridView1.DataKeys[item.RowIndex].Value.ToString());
                Label99.Text = iMMBD_MaterialID.ToString();
                TextBox2.Text = GridView1.Rows[item.RowIndex].Cells[2].Text.ToString();
                TextBox3.Text = GridView1.Rows[item.RowIndex].Cells[3].Text.ToString();
                temp = true;
                Panel1.Visible = false;
                UpdatePanel1.Update();
                UpdatePanel_NewModel.Update();
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, GetType(), "alert", "alert('请选择物料信息！')", true);
            return;
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Panel1.Visible=false;
        UpdatePanel1.Update();
    }
    //GridView1
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;

            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox8");   // refer to the TextBox with the NewPageIndex value
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
        string condition = GetCondition9();
        BindGridView1(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
    #endregion 物料信息及GridView1


}