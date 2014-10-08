using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ProductionBasicInfo_PBIProductBaiscInfoMgt : Page
{
    ProSeriesInfo_ProTypeInfo pplinfo = new ProSeriesInfo_ProTypeInfo();
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    User us = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["state"] == null)
            {
                label_pagestate.Text = "look";
            }
            else
            {
                label_pagestate.Text = Request.QueryString["state"];
            }

            string state = label_pagestate.Text;
            if (state == "look")
            {
			    Title = "产品基础信息查看";
                GridView1.Columns[2].Visible = false;
                GridView1.Columns[3].Visible = false;
                Button_Add.Visible = false;
                Btn_AddPT.Visible = false;
                GridView2.Columns[9].Visible = false;
                GridView2.Columns[10].Visible = false;
                Btn_I_parameter.Visible = false;
                Btn_U_parameter.Visible = false;

            }
            if (state == "manage")
            {


            }


            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("产品基础信息维护")) || (Session["UserRole"].ToString().Contains("产品基础信息查看"))))
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("产品基础信息维护"))
                    {

                        Title = "产品基础信息查看";
                        GridView1.Columns[2].Visible = false;
                        GridView1.Columns[3].Visible = false;
                        Button_Add.Visible = false;
                        Btn_AddPT.Visible = false;
                        GridView2.Columns[9].Visible = false;
                        GridView2.Columns[10].Visible = false;
                        Btn_I_parameter.Visible = false;
                        Btn_U_parameter.Visible = false;

                    }


                    GridView1.SelectedIndex = -1;
                    GridView2.SelectedIndex = -1;
                    GridView_Parameter.SelectedIndex = -1;
                    GridView1.DataSource = ppl.SList_ProSeries();
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                    Response.Redirect("~/Default.aspx");

                }



            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Default.aspx");
        }


    }
    #region 各种按钮事件
    protected void Btn_Search_Click(object sender, EventArgs e) //搜索产品系列
    {
        Label_Grid1_State.Text = "模糊搜索数据源";
        Label_Search.Text = Txt_search.Text.Trim();
        if (Txt_search.Text != "")
        {
            GridView1.DataSource = ppl.S_ProSeries(Txt_search.Text.Trim());
            GridView1.DataBind();
            UpdatePanel_PS.Update();
        }
        else
        {
            Label_Grid1_State.Text = "默认数据源";
            GridView1.DataSource = ppl.SList_ProSeries();
            GridView1.DataBind();
            UpdatePanel_PS.Update();

        }
    }
    protected void Button_Cancel_Click(object sender, EventArgs e) //取消搜索产品系列
    {
        Label_Grid1_State.Text = "默认数据源";
        Txt_search.Text = "";
        GridView1.DataSource = ppl.SList_ProSeries();
        GridView1.DataBind();
        UpdatePanel_PS.Update();
        UpdatePanel_Search.Update();
        UpdatePanel_AddPS.Update();

        //无关信息隐藏
        Panel_PT.Visible = false;
        Panel_AddPS.Visible = false;
        Panel_AddPT.Visible = false;
        Panel_CheckParameter.Visible = false;
        Panel_Parameter.Visible = false;
        UpdatePanel_PT.Update();
        UpdatePanel_AddPS.Update();
        UpdatePanel_AddPT.Update();
        UpdatePanel_CheckParameter.Update();
        UpdatePanel_Parameter.Update();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)//提交新增产品型号
    {
        Label_Grid1_State.Text = "默认数据源";

        DataSet ds = ppl.S_ProSeries_Name(txt_PS.Text);
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产品系列名称，不能重名！')", true);
            return;
        }
        if (txt_PS.Text != "")
        {
            pplinfo.PS_Name = txt_PS.Text.Trim();
            ppl.I_ProSeries(pplinfo);
            ScriptManager.RegisterStartupScript(Panel_AddPS, typeof(Page), "alert", "alert('产品系列新增成功!')", true);
            GridView1.DataSource = ppl.SList_ProSeries();
            GridView1.DataBind();
            UpdatePanel_PS.Update();
            txt_PS.Text = "";
            Panel_AddPS.Visible = false;
            UpdatePanel_AddPS.Update();
            UpdatePanel_PS.Update();
        }

        else
        {
            ScriptManager.RegisterStartupScript(Panel_AddPS, typeof(Page), "alert", "alert('产品系列名称不能为空！')", true);
        }


    }
    protected void Btn_Cancel_Click(object sender, EventArgs e) //取消新增
    {
        Label_Grid1_State.Text = "默认数据源";
        txt_PS.Text = "";
        UpdatePanel_AddPS.Update();
        UpdatePanel_PS.Update();
    }
    protected void Button_Add_Click(object sender, EventArgs e)//弹出新增产型号
    {
        Panel_AddPS.Visible = true;
        UpdatePanel_AddPS.Update();
    }
    #endregion
    #region 产品系列表代码
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = ppl.SList_ProSeries();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_ProSeries(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源

        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView1.PageIndex = newPageIndex;

        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }  //行分页
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Delete1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            GridView1.SelectedIndex = -1;

            // this.Lab_State.Text = "Delete1";
            string id = e.CommandArgument.ToString();
            Guid guid_id = new Guid(id);
            ppl.D_ProSeries(guid_id);
            GridView1.DataSource = ppl.SList_ProSeries();
            GridView1.DataBind();
            UpdatePanel_PS.Update();
            //无关信息隐藏
            Panel_PT.Visible = false;
            Panel_AddPS.Visible = false;
            Panel_AddPT.Visible = false;
            Panel_CheckParameter.Visible = false;
            Panel_Parameter.Visible = false;
            UpdatePanel_PT.Update();
            UpdatePanel_AddPS.Update();
            UpdatePanel_AddPT.Update();
            UpdatePanel_CheckParameter.Update();
            UpdatePanel_Parameter.Update();

        }


        if (e.CommandName == "CheckProType")
        {
            Panel_PT.Visible = true;
            GridView2.SelectedIndex = -1;
            GridView_Parameter.SelectedIndex = -1;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = al[0];
            Label_PsName.Text = al[1] + " 所属";
            Label_PS.Text = id;
            Guid guid_id = new Guid(id);
            string condition = " PS_ID='" + id + "'";
            GridView2.DataSource = ppl.S_ProSeries_ProType(condition);
            GridView2.DataBind();
            UpdatePanel_PT.Update();
            //无关信息隐藏
            Panel_AddPS.Visible = false;
            Panel_AddPT.Visible = false;
            Panel_CheckParameter.Visible = false;
            Panel_Parameter.Visible = false;
            UpdatePanel_AddPS.Update();
            UpdatePanel_AddPT.Update();
            UpdatePanel_CheckParameter.Update();
            UpdatePanel_Parameter.Update();

        }
    } //行链接按钮命令
    protected void Gridview_PS_Editing(object sender, GridViewEditEventArgs e)//显示编辑产品系列状态
    {
        GridView1.SelectedIndex = e.NewEditIndex;
        GridView1.EditIndex = e.NewEditIndex;

        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = ppl.SList_ProSeries();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_ProSeries(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源
        //无关信息隐藏
        Panel_PT.Visible = false;
        Panel_AddPS.Visible = false;
        Panel_AddPT.Visible = false;
        Panel_CheckParameter.Visible = false;
        Panel_Parameter.Visible = false;
        UpdatePanel_PT.Update();
        UpdatePanel_AddPS.Update();
        UpdatePanel_AddPT.Update();
        UpdatePanel_CheckParameter.Update();
        UpdatePanel_Parameter.Update();

    }
    protected void Gridview_PS_CancelingEdit(object sender, GridViewCancelEditEventArgs e)//取消编辑
    {
        GridView1.EditIndex = -1;
        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = ppl.SList_ProSeries();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_ProSeries(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源
    }
    protected void Gridview_PS_Updating(object sender, GridViewUpdateEventArgs e) //Grid编辑产品系列
    {
        DataSet ds = ppl.S_ProSeries_Name(Convert.ToString(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString()));
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产品系列名称，不能重名！')", true);
            return;
        }
        pplinfo.PS_ID = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
        pplinfo.PS_Name = Convert.ToString(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        ppl.U_ProSeries(pplinfo);

        GridView1.EditIndex = -1;
        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = ppl.SList_ProSeries();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_ProSeries(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源
        UpdatePanel_PS.Update();

    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头
            foreach (TableCell Tc in e.Row.Cells) //对每一单元格      
                if (Tc.HasControls())
                    if (((LinkButton)Tc.Controls[0]).CommandArgument == Label_sort.Text)
                        //if (((LinkButton)Tc.Controls[0]).CommandArgument == Convert.ToString(Session["sort"]))
                        //是否为排序列
                        if (GridViewSortDirection == SortDirection.Ascending) //依排序方向加入方向箭头
                            Tc.Controls.Add(new LiteralControl("↓"));
                        else
                            Tc.Controls.Add(new LiteralControl("↑"));

    }  //Grid 行初始化
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    { //实现选中操作行变色 
        //   if (this.Label_Grid1_Color.Text != null && Convert.ToString(e.Row.RowIndex) == this.Label_Grid1_Color.Text)
        //   {
        //     e.Row.BackColor = System.Drawing.Color.SkyBlue;
        //  }

        //鼠标经过时，行背景色变 
        //    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#FFD9EC'");
        //鼠标移出时，行背景色还原 
        //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
        // e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;select(this)");//点击行变色
        //     e.Row.Attributes["style"] = "Cursor:hand"; //鼠标悬停的行显示手型

    } //Grid外观设置
    #region 排序代码
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)//排序
    {
        string sortExpression = e.SortExpression;
        Label_sort.Text = e.SortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)  //设置排序方向
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, " ASC");
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, " DESC");
        }

    }
    public SortDirection GridViewSortDirection
    {//属性设置
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }
    private void SortGridView(string sortExpression, string direction)
    {
        if (Label_Grid1_State.Text == "默认数据源")
        {
            DataSet ds = ppl.SList_ProSeries();
            DataTable dt = ds.Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            DataSet ds = ppl.S_ProSeries(Label_Search.Text.Trim());
            DataTable dt = ds.Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }

    }
    #endregion

    #endregion



    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range

        string condition;
        string psid = " PS_ID='" + Label_PS.Text.Trim() + "'";
        string pt_name = Txt_PT_Search.Text.Trim() == "" ? "1=1" : "PT_Name like '%" + Txt_PT_Search.Text.Trim() + "%'";
        condition = psid + " and " + pt_name;
        GridView2.DataSource = ppl.S_ProSeries_ProType(condition);
        GridView2.DataBind();
        UpdatePanel_PT.Update();

        //绑定数据源

        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView2.PageIndex = newPageIndex;

        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();

    }
    protected void Gridview_PT_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check_Parameter")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            //无关信息隐藏

            Panel_AddPS.Visible = false;
            Panel_AddPT.Visible = false;
            Panel_CheckParameter.Visible = false;


            UpdatePanel_AddPS.Update();
            UpdatePanel_AddPT.Update();
            UpdatePanel_CheckParameter.Update();



            GridView_Parameter.SelectedIndex = -1;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string prid = al[0];
            Label_PRID.Text = prid;
            string ptname = al[1];
            string ptid = al[2];
            Label_PTP.Text = ptname;
            Label_PT_ID.Text = ptid;
            Panel_Parameter.Visible = true;
            if (prid == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该产品尚未制定工艺路线！')", true);
                return;
            }
            Guid guid_id = new Guid(prid);
            GridView_Parameter.DataSource = ppl.S_ProType_ProcessRoute(guid_id);
            GridView_Parameter.DataBind();
            UpdatePanel_Parameter.Update();

        }
        if (e.CommandName == "Delete_PT")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            GridView2.SelectedIndex = -1;

            //无关信息隐藏

            Panel_AddPS.Visible = false;
            Panel_AddPT.Visible = false;
            Panel_Parameter.Visible = false;
            Panel_CheckParameter.Visible = false;

            UpdatePanel_Parameter.Update();
            UpdatePanel_AddPS.Update();
            UpdatePanel_AddPT.Update();
            UpdatePanel_CheckParameter.Update();

            string id = e.CommandArgument.ToString();
            Guid guid_id = new Guid(id);
            ppl.D_ProType(guid_id);
            string condition;
            string psid = " PS_ID='" + Label_PS.Text.Trim() + "'";
            string pt_name = Txt_PT_Search.Text.Trim() == "" ? "1=1" : "PT_Name like '%" + Txt_PT_Search.Text.Trim() + "%'";
            condition = psid + " and " + pt_name;
            GridView2.DataSource = ppl.S_ProSeries_ProType(condition);
            GridView2.DataBind();
            UpdatePanel_PT.Update();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

        }
        if (e.CommandName == "Edit_PT")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            //无关信息隐藏

            Panel_AddPS.Visible = false;
            // this.Panel_AddPT.Visible = false;
            Panel_Parameter.Visible = false;
            Panel_CheckParameter.Visible = false;

            UpdatePanel_Parameter.Update();
            UpdatePanel_AddPS.Update();
            // this.UpdatePanel_AddPT.Update();
            UpdatePanel_CheckParameter.Update();

            DropDownList_BOM.DataSource = ppl.S_BOM_Name();
            DropDownList_BOM.DataTextField = "BOM_Name";
            DropDownList_BOM.DataValueField = "BOM_ID";
            DropDownList_BOM.DataBind();
            DropDownList_BOM.Items.Insert(0, new ListItem("请选择", ""));

            DropDownList_PR.DataSource = ppl.S_PR_Name();
            DropDownList_PR.DataTextField = "PR_Name";
            DropDownList_PR.DataValueField = "PR_ID";
            DropDownList_PR.DataBind();
            DropDownList_PR.Items.Insert(0, new ListItem("请选择", ""));


            string[] a = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ptname = a[0];
            string ptspecial = a[1];
            string prid = a[2];
            string bomid = a[3];
            Label_PT_ID.Text = a[4];

            Txt_PT.Text = ptname;
            Label_ptname.Text = ptname;
            DropDownList_Special.SelectedValue = ptspecial;

            DropDownList_PR.Items.FindByValue(prid.ToString().Trim()).Selected = true;
            DropDownList_BOM.Items.FindByValue(bomid.ToString().Trim()).Selected = true;
            Label_submitState.Text = "编辑";
            Panel_AddPT.Visible = true;

            UpdatePanel_AddPT.Update();

        }




    }
    protected void Gridview_PT_Editing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void Gridview_PT_Updating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Btn_SearchPT_Click(object sender, EventArgs e)
    {
        string condition;
        string id = " PS_ID='" + Label_PS.Text.Trim() + "'";
        string pt_name = Txt_PT_Search.Text.Trim() == "" ? "1=1" : "PT_Name like '%" + Txt_PT_Search.Text.Trim() + "%'";
        condition = id + " and " + pt_name;
        GridView2.DataSource = ppl.S_ProSeries_ProType(condition);
        GridView2.DataBind();
        UpdatePanel_PT.Update();
    }
    protected void Button_CancelPT_Click(object sender, EventArgs e)
    {
        Txt_PT_Search.Text = "";
        string condition;
        string id = " PS_ID='" + Label_PS.Text.Trim() + "'";
        string pt_name = Txt_PT_Search.Text.Trim() == "" ? "1=1" : "PT_Name like '%" + Txt_PT_Search.Text.Trim() + "%'";
        condition = id + " and " + pt_name;
        GridView2.DataSource = ppl.S_ProSeries_ProType(condition);
        GridView2.DataBind();
        UpdatePanel_PT.Update();

    }
    protected void Button_Close_PT_Click(object sender, EventArgs e)
    {

        GridView2.SelectedIndex = -1;
        GridView_Parameter.SelectedIndex = -1;
        Panel_PT.Visible = false;
        Panel_AddPT.Visible = false;
        UpdatePanel_AddPT.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        Txt_PT_Search.Text = "";
    }
    protected void Button_Close_PSSearch_Click(object sender, EventArgs e)
    {

        Panel_AddPS.Visible = false;
        txt_PS.Text = "";
    }
    protected void Btn_AddPT_Click(object sender, EventArgs e)
    {
        DropDownList_BOM.DataSource = ppl.S_BOM_Name();
        DropDownList_BOM.DataTextField = "BOM_Name";
        DropDownList_BOM.DataValueField = "BOM_ID";
        DropDownList_BOM.DataBind();
        DropDownList_BOM.Items.Insert(0, new ListItem("请选择", ""));

        DropDownList_PR.DataSource = ppl.S_PR_Name();
        DropDownList_PR.DataTextField = "PR_Name";
        DropDownList_PR.DataValueField = "PR_ID";
        DropDownList_PR.DataBind();
        DropDownList_PR.Items.Insert(0, new ListItem("请选择", ""));

        Label_submitState.Text = "新增";
        Panel_AddPT.Visible = true;
        Txt_PT.Text = "";
        DropDownList_BOM.SelectedIndex = 0;
        DropDownList_PR.SelectedIndex = 0;
        DropDownList_Special.SelectedIndex = 0;

        UpdatePanel_AddPT.Update();

    }
    protected void Btn_AddPTSubmit_Click(object sender, EventArgs e)
    {

        if (Txt_PT.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('产品名称不能为空！')", true);
            return;
        }

        string pt_name = "PT_Name ='" + Txt_PT.Text.Trim() + "'";
        DataSet ds = ppl.S_ProSeries_ProType(pt_name);
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0 && Label_ptname.Text != Txt_PT.Text)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产品型号名称，不能重名！')", true);
            return;
        }


        if (DropDownList_BOM.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择BOM（物料清单）！')", true);
            return;
        }
        if (DropDownList_PR.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择工艺路线！')", true);
            return;
        }
        pplinfo.PS_ID = new Guid(Label_PS.Text.Trim());
        pplinfo.PT_Name = Txt_PT.Text.Trim();
        pplinfo.PT_Special = DropDownList_Special.SelectedItem.Text.Trim();
        pplinfo.BOM_ID = new Guid(DropDownList_BOM.SelectedValue);
        pplinfo.PR_ID = new Guid(DropDownList_PR.SelectedValue);
        pplinfo.PT_Man = Session["UserName"].ToString();

        if (Label_submitState.Text == "新增")
        {
            ppl.I_ProType(pplinfo);
            Txt_PT.Text = "";
            DropDownList_PR.SelectedIndex = 0;
            DropDownList_BOM.SelectedIndex = 0;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您已添加成功！')", true);
        }
        if (Label_submitState.Text == "编辑")
        {
            pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
            ppl.U_ProType(pplinfo);
            Txt_PT.Text = "";
            DropDownList_PR.SelectedIndex = 0;
            DropDownList_BOM.SelectedIndex = 0;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您已修改成功！')", true);
        }
        string condition = " PS_ID='" + Label_PS.Text.Trim() + "'";
        GridView2.DataSource = ppl.S_ProSeries_ProType(condition);
        GridView2.DataBind();
        UpdatePanel_PT.Update();
        Panel_AddPT.Visible = false;
    }
    protected void Btn_CancelPT_Click(object sender, EventArgs e)
    {
        Txt_PT.Text = "";
        Panel_AddPT.Visible = false;
        UpdatePanel_AddPT.Update();
    }
    protected void GridView_Parameter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Parameter.BottomPagerRow;


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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        GridView_Parameter.DataSource = ppl.S_ProType_ProcessRoute(new Guid(Label_PRID.Text));
        GridView_Parameter.DataBind();
        UpdatePanel_Parameter.Update();

        //绑定数据源

        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Parameter.PageCount ? GridView_Parameter.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_Parameter.PageIndex = newPageIndex;

        GridView_Parameter.PageIndex = newPageIndex;
        GridView_Parameter.DataBind();


    }
    protected void GridView_Parameter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check_PT_Parameter")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Parameter.SelectedIndex = row.RowIndex;
               string[] a = e.CommandArgument.ToString().Split(new char[] { ',' });
            string pbcid = a[0];
            Label_PBCID.Text = pbcid;
            Panel_CheckParameter.Visible = true;
            UpdatePanel_CheckParameter.Update();
            Guid guid_id = new Guid(pbcid);
            DataSet ds = ppl.S_ProProcessParameter(new Guid(Label_PT_ID.Text.Trim()), guid_id);
            DataTable dt = ds.Tables[0];
            DataView dv = ds.Tables[0].DefaultView;
            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您尚未制定工艺参数或合格率标准，请先输入相关参数并制定！您将看到参考的工艺参数和合格率标准')", true);

                DataSet ds2 = ppl.S_PBCraftInfo(new Guid(Label_PBCID.Text));
                DataTable dt2 = ds2.Tables[0];
                DataView dv2 = ds2.Tables[0].DefaultView;
                foreach (DataRowView datav in dv2)
                {
                    Txt_parameter.Text = datav["PBC_Parameter"].ToString().Trim();
                    Txt_PassRate.Text = datav["PBC_PassRate"].ToString().Trim();

                }
                // this.Txt_parameter.Text = "";
                // this.Txt_PassRate.Text = "";
                TextBox_Note.Text = "";
                if (!Session["UserRole"].ToString().Contains("产品基础信息维护"))
                {
                    Panel_CheckParameter.Visible = false;
                    UpdatePanel_CheckParameter.Update();
                }
                return;
            }

            foreach (DataRowView datav in dv)
            {
                Txt_parameter.Text = datav["PPP_Parameter"].ToString().Trim();
                Txt_PassRate.Text = datav["PPP_PassRate"].ToString().Trim();
                TextBox_Note.Text = datav["PPP_Note"].ToString().Trim();

            }
            Label_PT2.Text = Label_PTP.Text +" "+ a[1]+" ";

        }

    }
    protected void GridView_Parameter_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_Parameter_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_Parameter_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void Btn_I_parameter_Click(object sender, EventArgs e)
    {
        try
        { decimal a = Convert.ToDecimal(Txt_PassRate.Text); }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合格率标准必须是小数形式')", true);
            return;
        }
       

        if (Convert.ToDecimal(Txt_PassRate.Text) > 1 || Convert.ToDecimal(Txt_PassRate.Text) < 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合格率标准应该是0至1之间的小数形式')", true);
            return;
        }
        DataSet ds = ppl.S_ProProcessParameter(new Guid(Label_PT_ID.Text.Trim()), new Guid(Label_PBCID.Text.Trim()));
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('已经制定过了工艺参数或合格率标准，您只能修改')", true);
            //return;
            pplinfo.PPP_Parameter = Txt_parameter.Text;
            pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
            pplinfo.PBC_ID = new Guid(Label_PBCID.Text.Trim());
            pplinfo.PPP_Note = TextBox_Note.Text;
            pplinfo.PPP_PassRate = Convert.ToDecimal(Txt_PassRate.Text);
            ppl.U_ProProcessParameter(pplinfo);


        }
        else
        {
            pplinfo.PPP_Parameter = Txt_parameter.Text;
            pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
            pplinfo.PBC_ID = new Guid(Label_PBCID.Text.Trim());
            pplinfo.PPP_Note = TextBox_Note.Text;
            pplinfo.PPP_PassRate = Convert.ToDecimal(Txt_PassRate.Text);
            ppl.I_ProProcessParameter(pplinfo);
        }
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功')", true);
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        Txt_parameter.Text = "";
        Txt_PassRate.Text = "";
        TextBox_Note.Text = "";

    }
    protected void Btn_U_parameter_Click(object sender, EventArgs e)
    {
        DataSet ds = ppl.S_ProProcessParameter(new Guid(Label_PT_ID.Text.Trim()), new Guid(Label_PBCID.Text.Trim()));
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改失败！您尚未制定工艺参数或合格率标准，您需要先制定！')", true);
            return;
        }
        if (Convert.ToDecimal(Txt_PassRate.Text) > 1 || Convert.ToDecimal(Txt_PassRate.Text) <= 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合格率标准应该是0至1之间的小数形式')", true);
            return;
        }
        pplinfo.PPP_Parameter = Txt_parameter.Text;
        pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
        pplinfo.PBC_ID = new Guid(Label_PBCID.Text.Trim());
        pplinfo.PPP_Note = TextBox_Note.Text;
        pplinfo.PPP_PassRate = Convert.ToDecimal(Txt_PassRate.Text);
        ppl.U_ProProcessParameter(pplinfo);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功')", true);
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        Txt_parameter.Text = "";
        Txt_PassRate.Text = "";
        TextBox_Note.Text = "";

    }
    protected void Button_Close_parameter_Click(object sender, EventArgs e)
    {

    }
    protected void Btn_Close_Parameter_Click(object sender, EventArgs e)
    {
        Panel_Parameter.Visible = false;
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        GridView_Parameter.SelectedIndex = -1;

    }
    protected void Button_Close_CheckParameter_Click(object sender, EventArgs e)
    {
        Panel_CheckParameter.Visible = false;
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        Txt_parameter.Text = "";
        Txt_PassRate.Text = "";
    }

    protected void GridView1_DataBound(object sender, EventArgs e)//产品系列表鼠标悬停
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;
                if (GridView1.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void GridView_Parameter_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Parameter.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Parameter.Rows[i].Cells.Count; j++)
            {
                GridView_Parameter.Rows[i].Cells[j].ToolTip = GridView_Parameter.Rows[i].Cells[j].Text;
                if (GridView_Parameter.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Parameter.Rows[i].Cells[j].Text = GridView_Parameter.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
}