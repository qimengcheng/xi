using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventoryMgt_IMMaterialBasicDataManagement : Page
{
    MaterialBasicDataL mat = new MaterialBasicDataL();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
           
            DropDownList1.Items.Insert(0, new ListItem("选择物料类别", "选择物料类别"));
            BindDropDownList1();
            DropDownList2.Items.Insert(0, new ListItem("选择物料类别", "选择物料类别"));
            BindDropDownList2();
            UpdatePanel_MatType.Visible = true;
            BindGridView_MatType();
            UpdatePanel_MatType.Update();
            UpdatePanel_MaterBasicData.Update();
            BindDropdownList();
            }
           
            #region 权限

            try
            {
                if (!((Session["UserRole"].ToString().Contains("物料基础数据维护")) || (Session["UserRole"].ToString().Contains("物料基础数据查看"))))
                {
                    Response.Redirect("~/Default.aspx");

                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }

            //if (Session["UserRole"].ToString().Contains("物料基础数据查看"))

            if (Request.QueryString["status"] == "IMMaterialBasicSearch")
            {
                {
                    Title = "物料基础数据查看";
                    Gridview_MatType.Columns[4].Visible = false;
                    Gridview_MatType.Columns[5].Visible = false;
                    Button2.Visible = false;
                    GridView_MaterialBasicData.Columns[11].Visible = false;
                    GridView_MaterialBasicData.Columns[12].Visible = false;
                    Button8.Visible = false;
                    UpdatePanel_Search.Update();
                    UpdatePanel_MatType.Update();
                    UpdatePanel_MaterBasicData.Update();
                    Button12.Visible = false;
                    UpdatePanel1.Update();
                }
                //if (Session["UserRole"].ToString().Contains("物料基础数据维护"))
                if (Request.QueryString["status"] == "IMMaterialBasicEdit")
                {
                    Title = "物料基础数据维护";
                    Gridview_MatType.Columns[4].Visible = true;
                    Gridview_MatType.Columns[5].Visible = true;
                    Button2.Visible = true;
                    GridView_MaterialBasicData.Columns[11].Visible = true;
                    GridView_MaterialBasicData.Columns[12].Visible = true;
                    Button8.Visible = true;
                    UpdatePanel_Search.Update();
                    UpdatePanel_MatType.Update();
                    UpdatePanel_MaterBasicData.Update();
                    Button12.Visible = true;
                    UpdatePanel1.Update();
                }
            #endregion
        }
    }
    //下拉表绑定
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = mat.Select_V_MaterialType();
        DropDownList1.DataTextField = "IMMT_MaterialType";
        DropDownList1.DataValueField = "IMMt_MaterialTypeID";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("选择物料类型", ""));

    }
    //新建物料名称下拉框绑定
    private void BindDropDownList2()
    {
        DropDownList2.DataSource = mat.Select_V_MaterialType();
        DropDownList2.DataTextField = "IMMT_MaterialType";
        DropDownList2.DataValueField = "IMMt_MaterialTypeID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("选择物料类型", ""));

    }

    //绑定类型表
    private void BindGridView_MatType()
    {
       
        try
        {
            if (label_Mattypesource.Text == "search")
            {
                Gridview_MatType.DataSource = mat.Select_MaterialTypeCondition(GetCondition1());
                Gridview_MatType.DataBind();
            }
            else
            {
                Gridview_MatType.DataSource = mat.Select_V_MaterialType();
                Gridview_MatType.DataBind();
            }
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }

    }
    //gridview点击绑定物料名称表
    private void BindGridView_MatBasicData_Gridview(string iid)
    {


        try
        {
            Guid id = new Guid(iid);
            GridView_MaterialBasicData.DataSource = mat.Select_MaterialBasicDataForGridview(id);
            GridView_MaterialBasicData.DataBind();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }

    }
    //模糊查询绑定物料名称表
    private void BindGridView_MatBasicData_Serarch(string conditon)
    {
        //conditon = GetCondition();
        
        try
        {
            GridView_MaterialBasicData.DataSource = mat.Select_MaterialBasicData(conditon);
            GridView_MaterialBasicData.DataBind();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }
    }


    #region 翻页各种操作

    protected void GridView_MatType_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头
            foreach (TableCell MyHeader in e.Row.Cells) //对每一单元格      
                if (MyHeader.HasControls())
                    if (((LinkButton)MyHeader.Controls[0]).CommandArgument == Gridview_MatType.SortExpression)
                        //是否为排序列
                        if (Gridview_MatType.SortDirection == SortDirection.Ascending) //依排序方向加入方向箭头
                            MyHeader.Controls.Add(new LiteralControl("↑"));
                        else
                            MyHeader.Controls.Add(new LiteralControl("↓"));
    }

    protected void GridView_MaterialBasicData_DataBound(object sender, EventArgs e)
    {

        for (int i = 0; i < GridView_MaterialBasicData.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_MaterialBasicData.Rows[i].Cells.Count; j++)
            {
                GridView_MaterialBasicData.Rows[i].Cells[j].ToolTip = GridView_MaterialBasicData.Rows[i].Cells[j].Text;
                if (GridView_MaterialBasicData.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_MaterialBasicData.Rows[i].Cells[j].Text = GridView_MaterialBasicData.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        } 
    }
    protected void Gridview_MatType_DataBound(object sender, EventArgs e)
    {

        for (int i = 0; i < Gridview_MatType.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_MatType.Rows[i].Cells.Count; j++)
            {
                Gridview_MatType.Rows[i].Cells[j].ToolTip = Gridview_MatType.Rows[i].Cells[j].Text;
                if (Gridview_MatType.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_MatType.Rows[i].Cells[j].Text = Gridview_MatType.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    //根据条件控制gridview每列的显示
    protected void Gridview_MatType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")//点击查看物料名称
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));//first parent :rows,second parent:gridview;

            label_mattypeid.Text = Convert.ToString(gvr.RowIndex);
            label_mattypeid.Text = Convert.ToString(e.CommandArgument);
            Label_BasicData_Source.Text = "Gridview数据源";
            string iid = e.CommandArgument.ToString();
            Panel_MaterBasicData.Visible = true;
            BindGridView_MatBasicData_Gridview(iid);
            Label17.Text = Gridview_MatType.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "的";
            Panel_MaterBasicData.Visible = true;
            UpdatePanel_MaterBasicData.Update();
        }
        if (e.CommandName == "Delete1")
        {
            Guid mattypeid = new Guid(Convert.ToString(e.CommandArgument));
            mat.Delete_MaterialType(mattypeid);
            BindGridView_MatType();
            UpdatePanel_MatType.Update();
        }
       

    }
    //绑定dropdownlist4
    protected void BindDropdownList()
    {
        DropDownList4.DataSource = mat.Select_Unit_Mat();
        DropDownList4.DataTextField = "UnitName";
        DropDownList4.DataValueField = "UnitID";
        DropDownList4.DataBind();
        //this.DropDownList2.Items.Insert(0, new ListItem("选择物料类型", ""));
        
    }
    //点击gridview链接的操作。
    protected void GridView_MatBasicData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit2")
        //编辑
        {

            Panel_MatBasicDataNew.Visible = true;
            label1_PanelMatBasicState.Text = "修改";
            Label19.Text = "修改";
            UpdatePanel_MatBasicDataNew.Update();
            label1_BasicID.Text = e.CommandArgument.ToString();
            Guid id = new Guid(label1_BasicID.Text.ToString());
            DataSet ds = mat.Select_IMMaterialBasicData_One(id);
            DataTable dt = ds.Tables[0];
            BindDropDownList2();
            BindDropdownList();
            //this.DropDownList2.SelectedItem.Text = dt.Rows[0][0].ToString();
            DropDownList2.SelectedValue = dt.Rows[0][0].ToString();
            TextBox14.Text = "1";
            TextBox14.Enabled = true;
            TextBox_matnamenew.Text = dt.Rows[0][1].ToString();
            TextBox_matmodelnew.Text = dt.Rows[0][2].ToString();
            TextBox_safenew.Text = dt.Rows[0][3].ToString();
            DropDownList4.SelectedValue = dt.Rows[0][9].ToString();
            TextBox3.Text = dt.Rows[0][5].ToString();
            TextBox5.Text = dt.Rows[0][10].ToString();
            TextBox8.Text=dt.Rows[0][13].ToString();
            TextBox6.Text=dt.Rows[0][11].ToString();
            TextBox7.Text=dt.Rows[0][12].ToString();
            //this.DropDownList3.SelectedItem.Text = dt.Rows[0][6].ToString();
            if (dt.Rows[0][6].ToString() == "")
                DropDownList3.SelectedValue = "否";
            else
            DropDownList3.SelectedValue = dt.Rows[0][6].ToString();
            TextBox1.Text = dt.Rows[0][7].ToString();
            TextBox4.Text = dt.Rows[0][8].ToString();
            label1_BasicID.Text = e.CommandArgument.ToString();
            //ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_MatBasicDataNew, this.GetType(), "alert", "alert('必须重新选择物料类型和有害物质选项！')", true);

        }
        if (e.CommandName == "Delete2")
        //删除物料明细
        {
            string iid = e.CommandArgument.ToString();
            Guid id = new Guid(iid);
            mat.Delete_MaterialBasicData(id);
            if (Label_BasicData_Source.Text == "Gridview数据源")
            {
                BindGridView_MatBasicData_Gridview(label_mattypeid.ToString());
            }
            if (Label_BasicData_Source.Text == "模糊查询数据源")
            {
                BindGridView_MatBasicData_Serarch(GetCondition());
            }
            UpdatePanel_MaterBasicData.Update();

        }


    }
    //换页
    protected void Gridview_MatTypeID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_MatType.BottomPagerRow;


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
        BindGridView_MatType();
        Gridview_MatType.DataSource = mat.Select_V_MaterialType();
        Gridview_MatType.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_MatType.PageCount ? Gridview_MatType.PageCount - 1 : newPageIndex;
        Gridview_MatType.PageIndex = newPageIndex;
        Gridview_MatType.DataBind();

    }
    protected void GridView_MatBasicData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_MaterialBasicData.BottomPagerRow;


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
        if (Label_BasicData_Source.Text == "Gridview数据源")
        {
            BindGridView_MatBasicData_Gridview(label_mattypeid.Text.ToString());


        }
        if (Label_BasicData_Source.Text == "模糊查询数据源")
        {
            BindGridView_MatBasicData_Serarch(GetCondition());
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_MaterialBasicData.PageCount ? GridView_MaterialBasicData.PageCount - 1 : newPageIndex;
        GridView_MaterialBasicData.PageIndex = newPageIndex;
        GridView_MaterialBasicData.DataBind();

    }
    //Gridview编辑物料类型
    protected void Gridview_MatType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid mattypeid = new Guid(Gridview_MatType.DataKeys[e.RowIndex].Value.ToString());
        string mattypename = Convert.ToString(((TextBox)(Gridview_MatType.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        string comment = Convert.ToString(((TextBox)(Gridview_MatType.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
        //BindGridView_MatType();
        mat.Update_MaterialType(mattypeid, mattypename, comment);
        Gridview_MatType.EditIndex = -1;
        BindGridView_MatType();
        UpdatePanel_MatType.Update();
        Panel_MatTypeNew.Visible = false;
        UpdatePanel_MatTypeNew.Update();

    }
    //显示编辑物料类型状态
    protected void Gridview_MatType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview_MatType.EditIndex = e.NewEditIndex;
        BindGridView_MatType();
    }
    //取消编辑
    protected void Gridview_MatType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview_MatType.EditIndex = -1;
        BindGridView_MatType();
    }
    #endregion
    //模糊查询物料名称
    protected void SelectMatBasicData(object sender, EventArgs e)
    {
        
        try
        {
                 Label_BasicData_Source.Text = "模糊查询数据源";
                  string condition = GetCondition();
                BindGridView_MatBasicData_Serarch(condition);
                if (DropDownList1.SelectedValue != "")
                {
                    
                    Label17.Text = Gridview_MatType.Rows[0].Cells[1].Text.ToString();
                    Gridview_MatType.DataSource = mat.Select_MaterialTypeCondition("and IMMt_MaterialTypeID='" + DropDownList1.SelectedValue.ToString() + "'");
                    Gridview_MatType.DataBind();
                    UpdatePanel_MatType.Update();
                }
                else
                {
                    Label17.Text = "检索的";
                    UpdatePanel_MatType.Update();
                }
                
                 Panel_MaterBasicData.Visible = true;
                 UpdatePanel_MaterBasicData.Update();
                 //this.MatName.Text = "";
                 //this.Model.Text = "";
                 //this.SafeStock.Text = "";
                 //this.StockDay.Text = "";

        }
        catch (Exception)
        {
            
            //throw;
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Search, GetType(), "alert", "alert('you make some mistakes')", true);
        }
       
    }
    //获取模糊查询条件
    protected string GetCondition()
    {
        try
        {
            string conditon;
            string temp = "";
            if (DropDownList1.Text.ToString() != "")
            {
                temp += " and IMMt_MaterialTypeID='" + DropDownList1.SelectedValue.ToString() + "'";

            }
            if (MatName.Text.ToString() != "")
            {
                temp += " and IMMBD_MaterialName like '%" + MatName.Text.ToString() + "%'";
            }
            if (Model.Text.ToString() != "")
            {
                temp += " and  IMMBD_SpecificationModel like '%" + Model.Text.ToString() + "%'";
            }
            if (StockDay.Text.ToString() != "")
            {
                temp += " and  IMMBD_StorageDay = '" + StockDay.Text.ToString() + "'";
            }
            if (SafeStock.Text.ToString() != "")
            {
                temp += " and  IMMBD_SafeStock <= '" + SafeStock.Text.ToString() + "'";

            }
            temp += " and  IMMBD_IsDeleted =0";
            conditon = temp;
            labelcodition.Text = conditon;
            return conditon;
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
            string condition="";
            return condition;
        }
       

    }
    //查询条件1
    protected string GetCondition1()
    {
        string conditon;
        string temp = "";
        if (TextBox2.Text.ToString() != "")
        {
            temp += " and IMMT_MaterialType like '%" + TextBox2.Text.ToString() + "%'";

        }
        conditon = temp;
        labelcodition.Text = conditon;
        return conditon;
    }
    //重置
    protected void Clear(object sender, EventArgs e)
    //sender是动作,EventArgs是具体的参数
    {
        try
        {
            DropDownList1.Items.Insert(0, new ListItem("选择物料类别", "选择物料类别"));
            BindDropDownList1();
            MatName.Text = "";
            Model.Text = "";
            SafeStock.Text = "";
            StockDay.Text = "";
            UpdatePanel_Search.Update();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }
       
    }
    //新建物料类型-确认
    protected void ConfirmMatTypeNew(object sender, EventArgs e)
    {
        //try
        //{
            string mattypename = TextBox_NewTypeName.Text.ToString();
            string comment = TextArea1.InnerText.ToString();
            if (TextBox_NewTypeName.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_MatTypeNew, GetType(), "alert", "alert('必须填写物料名称')", true);
                return;
            }
            int temp = mat.Select_IMMaterialTypeRepeat(mattypename);
            if (temp != 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_MatTypeNew, GetType(), "alert", "alert('物料类型名称重复，不可以添加！')", true);
                return;
            }
            mat.Insert_MaterialType(mattypename, comment);
            BindGridView_MatType();
            UpdatePanel_MatType.Update();
            TextBox_NewTypeName.Text = "";
            TextArea1.InnerText = "";
            Panel_MatTypeNew.Visible = false;
            UpdatePanel_MatTypeNew.Update();    
            BindDropDownList1();
            BindDropDownList2();
            UpdatePanel_Search.Update();
            UpdatePanel_MatBasicDataNew.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_MatTypeNew, GetType(), "alert", "alert('提交成功！')", true);
        //}
        //catch (Exception)
        //{
        //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        //}
        


    }
    //新建物料烈性-关闭
    protected void CanelMatTye(object sender, EventArgs e)
    {
        try
        {
            Panel_MatTypeNew.Visible = false;
            TextBox_NewTypeName.Text = "";
            TextArea1.InnerText = "";
            UpdatePanel_MatTypeNew.Update();
            Panel_MatBasicDataNew.Visible = false;
            UpdatePanel_MatBasicDataNew.Update();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }
      
    }

    //新建物料名称-确认
    protected void ConfirmMatBasicDataNew(object sender, EventArgs e)
    {
        try
        {
            string id = label1_BasicID.Text.ToString();
            Guid matid;
            if (DropDownList2.SelectedItem.Text == "选择物料类型")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_MatBasicDataNew, GetType(), "alert", "alert('请选择对应的物料类别！')", true);
                return;
            }

            if (TextBox_matnamenew.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_MatBasicDataNew, GetType(), "alert", "alert('请填写物料名称！')", true);
                return;
            }

            Guid mattypeid = new Guid(DropDownList2.SelectedValue.ToString());
            string matname = TextBox_matnamenew.Text.ToString();
            string model = TextBox_matmodelnew.Text.ToString();
            decimal safe;
         
            if (TextBox_safenew.Text == "")
            {
                safe = Convert.ToDecimal(0);

            }
            else
            {
                safe = Convert.ToDecimal(TextBox_safenew.Text.ToString());

            }
            int storageday;
            if (TextBox3.Text.ToString() == "")
            {
                storageday = Convert.ToInt32(null);
            }
            else
            {
                storageday = Convert.ToInt32(TextBox3.Text.ToString());
            }
             int pianshu;
             if (TextBox8.Text == "")
             {
                 pianshu = 0;             
             }
             else
            { 
            pianshu = Convert.ToInt32( TextBox8.Text.ToString());
            }
            decimal zhuanrate ;
            if (TextBox6.Text == "")
            {
                zhuanrate = 0;
            }
            else
            {
            zhuanrate = Convert.ToDecimal(TextBox6.Text.ToString());
            }
            decimal peiweight;

            if (TextBox7.Text == "")
            {
                peiweight = 0;
            }
            else
            { 
            peiweight = Convert.ToDecimal(TextBox7.Text.ToString());
            }
             
            string harm = DropDownList3.SelectedItem.ToString();
            Guid unit = new Guid(DropDownList4.SelectedValue.ToString());
            string comment = TextBox4.Text.ToString();
            string para = TextBox1.Text.ToString();
            decimal rate = Convert.ToDecimal(TextBox14.Text.ToString());
            string code = TextBox5.Text.ToString();
            if (label1_PanelMatBasicState.Text == "新建")
            {
                int temp = mat.Select_IMMaterialBasicRepeat(matname, model);
                if (temp != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_MatBasicDataNew, GetType(), "alert", "alert('物料名称和规格型号重复，不可以添加！')", true);
                    return;
                }
            }
            if (label1_PanelMatBasicState.Text == "新建")
            {

                mat.Insert_MaterialBasicData(mattypeid, matname, model, safe, storageday, harm, unit, comment, para, code, pianshu, zhuanrate, peiweight);
            }
            if (label1_PanelMatBasicState.Text == "修改")
            {
                matid = new Guid(label1_BasicID.Text.ToString());
                mat.Update_MaterialBasicData(matid, mattypeid, matname, model, safe, storageday, harm, unit, comment, para, rate, code, pianshu, zhuanrate, peiweight);

            }
            if (Label_BasicData_Source.Text == "Gridview数据源")
            {
                BindGridView_MatBasicData_Gridview(label_mattypeid.Text.ToString());
            }
            if (Label_BasicData_Source.Text == "模糊查询数据源")
            {
                BindGridView_MatBasicData_Serarch(labelcodition.Text.ToString());
            }
            UpdatePanel_MaterBasicData.Update();
            Panel_MatBasicDataNew.Visible = false;
            TextBox_matnamenew.Text = "";
            TextBox_matmodelnew.Text = "";
            TextBox_safenew.Text = "";         
            TextBox3.Text = "";
            TextBox1.Text = "";
            TextBox4.Text = "";
            UpdatePanel_MatBasicDataNew.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_MatBasicDataNew, GetType(), "alert", "alert('提交成功！')", true);
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }

       

    }
    //新建物料类别，打开对应panel
    protected void NewMatType(object sender, EventArgs e)
    {
        try
        {
            Panel_MatTypeNew.Visible = true;
            UpdatePanel_MatTypeNew.Visible = true;
            UpdatePanel_MatTypeNew.Update();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }
       
    }
    //新建物料名称明细，打开对应panel
    protected void CreateMatBasicData(object sender, EventArgs e)
    {
        try
        {
            if (Label17.Text == "检索的")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_MaterBasicData, GetType(), "alert", "alert('在检索结果的情况下无法新建物料名称明细，请从物料类型表中点击 查看具体物料名称 进行操作！')", true);
            }
            else
            {
                label1_PanelMatBasicState.Text = "新建";
                Panel_MatBasicDataNew.Visible = true;
                DropDownList2.SelectedValue = label_mattypeid.Text.ToString();
                DropDownList2.Enabled = false;
                TextBox_matnamenew.Text = "";
                TextBox_matmodelnew.Text = "";
                TextBox_safenew.Text = "";
                //this.DropDownList4.SelectedValue = "";
                TextBox14.Text = "1";
                TextBox14.Enabled = false;
                TextBox3.Text = "";
                TextBox1.Text = "";
                UpdatePanel_MatBasicDataNew.Update();
            }
            
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }
       
    }
    //关闭对应的新建物料明细panel、
    protected void CanelMatBasicDataNew(object sender, EventArgs e)
    {
        try
        {
            Panel_MatBasicDataNew.Visible = false;
            UpdatePanel_MatBasicDataNew.Update();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }
       
    }
    //关闭物料明细表
    protected void CanelMatBasicData(object sender, EventArgs e)
    {
        try
        {
            Panel_MaterBasicData.Visible = false;
            UpdatePanel_MaterBasicData.Update();
            Panel_MatBasicDataNew.Visible = false;
            UpdatePanel_MatBasicDataNew.Update();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('you make some mistakes ');</script>");
        }
        
    }
    //关闭检索栏
    protected void ColseMaterialBasicSearch(object sender, EventArgs e)
    {
        Panel_Search.Visible = false;
        UpdatePanel_Search.Update();
    }
    //打开检索栏
    protected void SelectMatBasicData_open(object sender, EventArgs e)
    {
        Panel_Search.Visible = true;
        UpdatePanel_Search.Update();
    }
    //检索物料类别
    protected void SelectMaterialType(object sender, EventArgs e)
    {
        label_Mattypesource.Text = "search";
        BindGridView_MatType();
        UpdatePanel_MatType.Update();
        Panel_Search.Visible = false;
        UpdatePanel_Search.Update();
        Panel_MaterBasicData.Visible = false;
        UpdatePanel_MaterBasicData.Update();
    }


    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('修改默认单位会使得系统进行更新该物料库存，需要较长时间，请确定库存不进行其他操作并耐心等待！')", true);

    }

   
}

