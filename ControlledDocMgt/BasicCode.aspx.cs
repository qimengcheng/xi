using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlledDocMgt_BasicCode : Page
{
    BasicCodeL basicCodeL = new BasicCodeL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "受控文件基础数据维护";
            BindGrid_BDOS("");
            BindDropDownList1();
            UpdatePanel_BDOS.Update();
            BindGrid_CDDep("");
            //BindDropDownList3();
            UpdatePanel_CDDep.Update();
            BindGrid_Third("");
            UpdatePanel_Third.Update();
            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "BasicCode" && Session["UserRole"].ToString().Contains("受控文件基础数据维护"))
                {
                    Title = "受控文件基础数据维护";
                }
                if (Lab_Status.Text == "BasicLook" && Session["UserRole"].ToString().Contains("受控文件基础数据查看"))
                {
                    Title = "受控文件基础数据查看";
                    Btn_NewBDOS.Visible = false;
                    Grid_BDOS.Columns[4].Visible = false;
                    Grid_BDOS.Columns[5].Visible = false;
                    Btn_NewCDDep.Visible = false;
                    Grid_CDDep.Columns[3].Visible = false;
                    Grid_CDDep.Columns[4].Visible = false;
                    Btn_NewThird.Visible = false;
                    Grid_Third.Columns[3].Visible = false;
                    Grid_Third.Columns[4].Visible = false;
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
    //绑定部门及代码列表Grid_BDOS
    private void BindGrid_BDOS(string condition)
    {
        Grid_BDOS.DataSource = basicCodeL.Search_BDOrganization_depcode(condition);
        Grid_BDOS.DataBind();
    }
    //DropDownList1下拉表绑定
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
        DropDownList1.DataTextField = "BDOS_Name";
        DropDownList1.DataValueField = "BDOS_Name";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    //DropDownList2下拉表绑定
    private void BindDropDownList2()
    {
        DropDownList2.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
        DropDownList2.DataTextField = "BDOS_Name";
        DropDownList2.DataValueField = "BDOS_Name";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    }
    //岗位分发代码列表Grid_CDDep
    private void BindGrid_CDDep(string condition)
    {
        Grid_CDDep.DataSource = basicCodeL.Search_CDDepDistributeCodeT(condition);
        Grid_CDDep.DataBind();
    }
    //DropDownList3下拉表绑定
    //private void BindDropDownList3()
    //{
    //    this.DropDownList3.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
    //    this.DropDownList3.DataTextField = "BDOS_Name";
    //    this.DropDownList3.DataValueField = "BDOS_Name";
    //    this.DropDownList3.DataBind();
    //    this.DropDownList3.Items.Insert(0, new ListItem("请选择", ""));
    //}
    //DropDownList4下拉表绑定
    //private void BindDropDownList4()
    //{
    //    this.DropDownList4.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
    //    this.DropDownList4.DataTextField = "BDOS_Name";
    //    this.DropDownList4.DataValueField = "BDOS_Name";
    //    this.DropDownList4.DataBind();
    //    this.DropDownList4.Items.Insert(0, new ListItem("请选择", ""));
    //}
    //第三层次文件类别代码列表Grid_Third
    private void BindGrid_Third(string condition)
    {
        Grid_Third.DataSource = basicCodeL.Search_CDThirdLevelCode(condition);
        Grid_Third.DataBind();
    }
    #endregion 绑定

    #region 部门代码检索
    protected void Btn_SearchBDOS_Click(object sender, EventArgs e)
    {
        Grid_BDOS.EditIndex = -1;
        string condition = GetCondition();
        BindGrid_BDOS(condition);
        Panel_BDOS.Visible = true;
        UpdatePanel_BDOS.Update();
        Panel_NewBDOS.Visible = false;
        UpdatePanel_NewBDOS.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (DropDownList1.Text.ToString() != "")
        {
            temp += " and BDOS_Name='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (TextBDOScode.Text.ToString() != "")
        {
            temp += " and BDOS_DepCode like '%" + TextBDOScode.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_ClearBDOS_Click(object sender, EventArgs e)
    {
        Grid_BDOS.EditIndex = -1;
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList1();
        TextBDOScode.Text = "";
        BindGrid_BDOS("");
        UpdatePanel_BDOS.Update();
        Panel_NewBDOS.Visible = false;
        UpdatePanel_NewBDOS.Update();
    }
    protected void Btn_NewBDOS_Click(object sender, EventArgs e)
    {
        Grid_BDOS.EditIndex = -1;
        Grid_BDOS.SelectedIndex = -1;
        BindGrid_BDOS("");
        UpdatePanel1.Update();
        Clear();
        BindDropDownList2();
        Panel_NewBDOS.Visible = true;
        UpdatePanel_NewBDOS.Update();
    }
    //私有清空的方法
    private void Clear()
    {
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList2();
        newBDOScode.Text = "";
        //DropDownList4.Items.Insert(0, new ListItem("请选择", ""));
        //BindDropDownList4();
        newCDdep.Text = "";
        newCDcode.Text = "";
        newType.Text = "";
        newDocCode.Text = "";
    }
    #endregion 部门代码检索

    #region Grid_BDOS相关
    //Gridview删除
    protected void Grid_BDOS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_NewBDOS.Visible = false;
        UpdatePanel_NewBDOS.Update();

        if (e.CommandName == "Delete_BDOS")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_BDOS.SelectedIndex = row.RowIndex;

            string BDOS_Code = Convert.ToString(e.CommandArgument);
            basicCodeL.Delete_BDOrganization_depcode(BDOS_Code);
            BindGrid_BDOS("");
            UpdatePanel_BDOS.Update();
        }
    }
    //显示编辑
    protected void Grid_BDOS_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_NewBDOS.Visible = false;
        UpdatePanel_NewBDOS.Update();
        Grid_BDOS.EditIndex = e.NewEditIndex;
        string condition = GetCondition();
        BindGrid_BDOS(condition);
    }
    //Gridview编辑
    protected void Grid_BDOS_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string bDOS_Name = Convert.ToString(Grid_BDOS.Rows[e.RowIndex].Cells[1].Text.Trim().ToString());
        //类型不为空
        if (((TextBox)(Grid_BDOS.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('部门代码不能为空！')", true);
            return;
        }
        string bDOS_DepCode = Convert.ToString(((TextBox)(Grid_BDOS.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim());
        if (((TextBox)(Grid_BDOS.Rows[e.RowIndex].FindControl("BDOS_No"))).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编号随机码起点不能为空！')", true);
            return;
        }
        if (((TextBox)(Grid_BDOS.Rows[e.RowIndex].FindControl("BDOS_No"))).Text.Trim().ToString().Length!= 3)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('必须为3位数！')", true);
            return;
        }
        string bDOS_No = Convert.ToString(((TextBox)(Grid_BDOS.Rows[e.RowIndex].FindControl("BDOS_No"))).Text.Trim());
        //DataSet ds = basicCodeL.Search_BDOrganization_depcode("and BDOS_DepCode = '" + bDOS_DepCode + " '");
        //DataTable dt = ds.Tables[0];
        //if (dt.Rows.Count != 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('已有此代码，不能重名！')", true);
        //    return;
        //}
        Grid_BDOS.EditIndex = -1;
        basicCodeL.Insert_Update_BDOrganization_depcode(bDOS_Name, bDOS_DepCode, bDOS_No);
        BindGrid_BDOS("");
        UpdatePanel_BDOS.Update();
    }
    //取消编辑
    protected void Grid_BDOS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_BDOS.EditIndex = -1;
        UpdatePanel_BDOS.Update();
        BindGrid_BDOS("");
    }
    //Gridview翻页
    protected void Grid_BDOS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_BDOS.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox1");   // refer to the TextBox with the NewPageIndex value
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
        BindGrid_BDOS(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_BDOS.PageCount ? Grid_BDOS.PageCount - 1 : newPageIndex;
        Grid_BDOS.PageIndex = newPageIndex;
        Grid_BDOS.DataBind();
    }
    //Gridview行变色
    protected void Grid_BDOS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion Grid_BDOS相关

    #region 新增部门代码
    //新增确认
    protected void BtnOK_NewBDOS_Click(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue.ToString() == "" || newBDOScode.Text.ToString() == "" || TextBox4.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox4.Text.Length != 3)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('必须为3位数！')", true);
            return;
        }
        string bDOS_Name = DropDownList2.SelectedValue.ToString();
        string bDOS_DepCode = newBDOScode.Text.ToString();
        string bDOS_No = TextBox4.Text.ToString().Trim();
        basicCodeL.Insert_Update_BDOrganization_depcode(bDOS_Name, bDOS_DepCode, bDOS_No);
        BindGrid_BDOS("");
        UpdatePanel_BDOS.Update();
        Panel_NewBDOS.Visible = false;
        UpdatePanel_NewBDOS.Update();
    }
    //新增取消
    protected void BtnCancel_NewBDOS_Click(object sender, EventArgs e)
    {
        Panel_NewBDOS.Visible = false;
        UpdatePanel_NewBDOS.Update();
    }  
    #endregion 新增部门代码

    #region 岗位代码检索
    protected void Btn_SearchCDDep_Click(object sender, EventArgs e)
    {
        Grid_CDDep.EditIndex = -1;
        string condition = GetCondition2();
        BindGrid_CDDep(condition);
        Panel_CDDep.Visible = true;
        UpdatePanel_CDDep.Update();
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
    }
    protected string GetCondition2()
    {
        string condition;
        string temp = "";
        //if (this.DropDownList3.Text.ToString() != "")
        //{
        //    temp += " and BDOS_Name='" + this.DropDownList3.SelectedValue.ToString() + "'";
        //}
        if (TextDep.Text.ToString() != "")
        {
            temp += " and CDDDCT_Dep like '%" + TextDep.Text.ToString() + "%'";
        }
        if (TextCode.Text.ToString() != "")
        {
            temp += " and CDDDCT_Code like '%" + TextCode.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_ClearCDDep_Click(object sender, EventArgs e)
    {
        Grid_CDDep.EditIndex = -1;
        //DropDownList3.Items.Insert(0, new ListItem("请选择", ""));
        //BindDropDownList3();
        TextDep.Text = "";
        TextCode.Text = "";
        BindGrid_CDDep("");
        UpdatePanel_CDDep.Update();
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
    }
    protected void Btn_NewCDDep_Click(object sender, EventArgs e)
    {
        Grid_CDDep.EditIndex = -1;
        Grid_CDDep.SelectedIndex = -1;
        BindGrid_CDDep("");
        UpdatePanel2.Update();
        Clear();
        //BindDropDownList4();
        Panel_NewCDDep.Visible = true;
        UpdatePanel_NewCDDep.Update();
    }
    #endregion 岗位代码检索

    #region Grid_CDDep相关
    //Gridview删除
    protected void Grid_CDDep_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
        if (e.CommandName == "Delete_CDDep")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_BDOS.SelectedIndex = row.RowIndex;

            Guid CDDDCT_ID = new Guid(Convert.ToString(e.CommandArgument));
            basicCodeL.Delete_CDDepDistributeCodeT(CDDDCT_ID);
            BindGrid_CDDep("");
            UpdatePanel_CDDep.Update();
        }
    }
    //显示编辑
    protected void Grid_CDDep_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
        Grid_CDDep.EditIndex = e.NewEditIndex;
        string condition = GetCondition2();
        BindGrid_CDDep(condition);
    }
    //Gridview编辑
    protected void Grid_CDDep_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid cDDDCT_ID = new Guid(Grid_CDDep.DataKeys[e.RowIndex].Value.ToString());
        //string bDOS_Name = Convert.ToString(Grid_CDDep.Rows[e.RowIndex].Cells[1].Text.Trim().ToString());
        //string cDDDCT_Dep = Convert.ToString(((TextBox)(Grid_CDDep.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim());
        string cDDDCT_Dep = Convert.ToString(Grid_CDDep.Rows[e.RowIndex].Cells[1].Text.Trim().ToString());
        string cDDDCT_Code = Convert.ToString(((TextBox)(Grid_CDDep.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim());
        //岗位不为空
        //if (((TextBox)(Grid_CDDep.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('岗位不能为空！')", true);
        //    return;
        //}
        //岗位代码不为空
        if (((TextBox)(Grid_CDDep.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('岗位代码不能为空！')", true);
            return;
        }
        //DataSet ds = basicCodeL.Search_CDDepDistributeCodeT(" and( CDDDCT_Code='" + cDDDCT_Code + "' and BDOS_Name!='" + bDOS_Name + "') or (BDOS_Name='" + bDOS_Name + "' and CDDDCT_Dep = '" + cDDDCT_Dep + " ' and CDDDCT_Code='" + cDDDCT_Code + "') or (BDOS_Name!='" + bDOS_Name + "' and CDDDCT_Dep = '" + cDDDCT_Dep + " ')");
        DataSet ds = basicCodeL.Search_CDDepDistributeCodeT(" and CDDDCT_Code='" + cDDDCT_Code + "' ");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已有此岗位及代码，不能重名！')", true);
            return;
        }
        Grid_CDDep.EditIndex = -1;
        basicCodeL.Update_CDDepDistributeCodeT(cDDDCT_ID, cDDDCT_Dep, cDDDCT_Code);
        BindGrid_CDDep("");
        UpdatePanel_CDDep.Update();
    }
    //取消编辑
    protected void Grid_CDDep_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_CDDep.EditIndex = -1;
        UpdatePanel_CDDep.Update();
        BindGrid_CDDep("");
    }
    //Gridview翻页
    protected void Grid_CDDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_CDDep.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox2");   // refer to the TextBox with the NewPageIndex value
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
        string condition = GetCondition2();
        BindGrid_CDDep(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_CDDep.PageCount ? Grid_CDDep.PageCount - 1 : newPageIndex;
        Grid_CDDep.PageIndex = newPageIndex;
        Grid_CDDep.DataBind();
    }
    //Gridview行变色
    protected void Grid_CDDep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion Grid_CDDep相关

    #region 新增岗位代码
    //新增确认
    protected void BtnOK_NewCDDep_Click(object sender, EventArgs e)
    {
        if (newCDdep.Text.ToString() == "" || newCDcode.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        //string bDOS_Name = this.DropDownList4.SelectedValue.ToString();
        string cDDDCT_Dep = newCDdep.Text.ToString();
        string cDDDCT_Code = newCDcode.Text.ToString();
        //DataSet ds = basicCodeL.Search_BDOrganization_depcode("and BDOS_Name = '" + bDOS_Name + "' and BDOS_DepCode!=''");
        DataSet ds = basicCodeL.Search_CDDepDistributeCodeT(" and (a.CDDDCT_Code='" + cDDDCT_Code + "' or a.CDDDCT_Dep='" + cDDDCT_Dep + "')");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已有代码，不能重复！')", true);
            return;
        }
        basicCodeL.Insert_CDDepDistributeCodeT(cDDDCT_Dep, cDDDCT_Code);
        BindGrid_CDDep("");
        UpdatePanel_CDDep.Update();
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
    }
    //新增取消
    protected void BtnCancel_NewCDDep_Click(object sender, EventArgs e)
    {
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
    }
    #endregion 新增岗位代码

    #region 第三层次文件类别代码检索
    protected void Btn_SearchThird_Click(object sender, EventArgs e)
    {
        Grid_Third.EditIndex = -1;
        string condition = GetCondition3();
        BindGrid_Third(condition);
        Panel_Third.Visible = true;
        UpdatePanel_Third.Update();
        Panel_NewThird.Visible = false;
        UpdatePanel_NewThird.Update();
    }
    protected string GetCondition3()
    {
        string condition;
        string temp = "";
        if (TextType.Text.ToString() != "")
        {
            temp += " and CDTLC_DocType like '%" + TextType.Text.ToString() + "%'";
        }
        if (TextDocCode.Text.ToString() != "")
        {
            temp += " and CDTLC_Code like '%" + TextDocCode.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_ClearThird_Click(object sender, EventArgs e)
    {
        Grid_Third.EditIndex = -1;
        TextType.Text = "";
        TextDocCode.Text = "";
        BindGrid_Third("");
        UpdatePanel_Third.Update();
        Panel_NewThird.Visible = false;
        UpdatePanel_NewThird.Update();
    }
    protected void Btn_NewThird_Click(object sender, EventArgs e)
    {
        Grid_Third.EditIndex = -1;
        Grid_Third.SelectedIndex = -1;
        BindGrid_Third("");
        UpdatePanel_Third.Update();
        Clear();
        Panel_NewThird.Visible = true;
        UpdatePanel_NewThird.Update();
    }
    #endregion 部门第三层次文件类别代码检索代码检索

    #region Grid_Third相关
    //Gridview删除
    protected void Grid_Third_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_NewThird.Visible = false;
        UpdatePanel_NewThird.Update();

        if (e.CommandName == "Delete_Third")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_BDOS.SelectedIndex = row.RowIndex;

            Guid CDTLC_ID = new Guid(Convert.ToString(e.CommandArgument));
            basicCodeL.Delete_CDThirdLevelCode(CDTLC_ID);
            BindGrid_Third("");
            UpdatePanel_BDOS.Update();
        }
    }
    //显示编辑
    protected void Grid_Third_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_NewThird.Visible = false;
        UpdatePanel_NewThird.Update();
        Grid_Third.EditIndex = e.NewEditIndex;
        string condition = GetCondition3();
        BindGrid_Third(condition);
    }
    //Gridview编辑
    protected void Grid_Third_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid cDTLC_ID = new Guid(Grid_Third.DataKeys[e.RowIndex].Value.ToString());
        //string cDTLC_DocType = Convert.ToString(((TextBox)(Grid_Third.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim());
        string cDTLC_DocType = Convert.ToString(Grid_Third.Rows[e.RowIndex].Cells[1].Text.Trim().ToString());
        string cDTLC_Code = Convert.ToString(((TextBox)(Grid_Third.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim());
        //文件类别不为空
        //if (((TextBox)(Grid_Third.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString() == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('文件类别不能为空！')", true);
        //    return;
        //}
        //文件类别代码不为空
        if (((TextBox)(Grid_Third.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('文件类别代码不能为空！')", true);
            return;
        }
        //DataSet ds = basicCodeL.Search_CDThirdLevelCode("and (CDTLC_DocType != '" + cDTLC_DocType + " 'and CDTLC_Code='" + cDTLC_Code + "') or (CDTLC_DocType = '" + cDTLC_DocType + " ' and CDTLC_Code='" + cDTLC_Code + "')");
        DataSet ds = basicCodeL.Search_CDThirdLevelCode("and CDTLC_Code='" + cDTLC_Code + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已有此代码，不能重名！')", true);
            return;
        }
        Grid_Third.EditIndex = -1;
        basicCodeL.Update_CDThirdLevelCode(cDTLC_ID, cDTLC_DocType, cDTLC_Code);
        BindGrid_Third("");
        UpdatePanel_Third.Update();
    }
    //取消编辑
    protected void Grid_Third_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_Third.EditIndex = -1;
        UpdatePanel_Third.Update();
        BindGrid_Third("");
    }
    //Gridview翻页
    protected void Grid_Third_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Third.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox3");   // refer to the TextBox with the NewPageIndex value
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
        string condition = GetCondition3();
        BindGrid_Third(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Third.PageCount ? Grid_Third.PageCount - 1 : newPageIndex;
        Grid_Third.PageIndex = newPageIndex;
        Grid_Third.DataBind();
    }
    //Gridview行变色
    protected void Grid_Third_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion Grid_Third相关

    #region 新增第三层次文件类别代码
    //新增确认
    protected void BtnOK_NewThird_Click(object sender, EventArgs e)
    {
        if (newType.Text.ToString() == "" || newDocCode.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string cDTLC_DocType = newType.Text.ToString();
        string cDTLC_Code = newDocCode.Text.ToString();
        DataSet ds = basicCodeL.Search_CDThirdLevelCode("and (CDTLC_DocType = '" + cDTLC_DocType + "' or CDTLC_Code = '" + cDTLC_Code + "')");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已有此文件类别代码，不能重复！')", true);
            return;
        }
        basicCodeL.Insert_CDThirdLevelCode(cDTLC_DocType, cDTLC_Code);
        BindGrid_Third("");
        UpdatePanel_Third.Update();
        Panel_NewThird.Visible = false;
        UpdatePanel_NewThird.Update();
    }
    //新增取消
    protected void BtnCancel_NewThird_Click(object sender, EventArgs e)
    {
        Panel_NewThird.Visible = false;
        UpdatePanel_NewThird.Update();
    }
    #endregion 新增第三层次文件类别代码

}