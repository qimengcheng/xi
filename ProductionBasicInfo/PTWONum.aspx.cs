using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class ProductionBasicInfo_PTWONum : Page
{
    WOCodeD ppl = new WOCodeD();
    User us = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.SelectedIndex = -1;
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
            try
            {
                if (Request.QueryString["state"].ToString() != "")
                {
                    label_pagestate.Text = Request.QueryString["state"].ToString();
                }
                if (label_pagestate.Text == "codeman" && Session["UserRole"].ToString().Contains("随工单产品代码维护"))
                {
                    Title = "随工单产品代码维护";
                }
                if (label_pagestate.Text == "codelook" && Session["UserRole"].ToString().Contains("随工单产品代码查看"))
                {
                    Title = "随工单产品代码查看";
                    Button_Add.Visible = false;
                    GridView1.Columns[2].Visible = false;
                    GridView1.Columns[3].Visible = false;
                    Btn_AddPT.Visible = false;
                    GridView2.Columns[0].Visible = false;
                    CheckBoxAll.Visible = false;
                    CheckBoxfanxuan.Visible = false;
                    Btn_deleting.Visible = false;
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");

            }
        }
    }
    public void databind()
    {
        string condition;
        string WOC_ID = " WOC_ID='" + Label_PS.Text.Trim() + "'";
        string PT_Name = Txt_PT_Search.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + Txt_PT_Search.Text.Trim() + "%' ";
        string PT_Code = Txt_PT_Search0.Text.Trim() == "" ? " and 1=1 " : " and PT_Code like '%" + Txt_PT_Search0.Text.Trim() + "%' ";
        condition = WOC_ID + PT_Name + PT_Code;
        GridView2.DataSource = ppl.S_WorkOrderCode_ProType(condition);
        GridView2.DataBind();
        UpdatePanel_PT.Update();

    }
    public void databind2()
    {
        string condition;

        string PT_Name = TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_Series.Text.Trim() + "%' ";
        string PT_Code = TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and PT_Code like '%" + TextBox_ProductName.Text.Trim() + "%' ";
        condition = PT_Name + PT_Code;
        GridView_ProType.DataSource = ppl.S_Protype_WorkOrderCode_ForChose(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();

    }
    protected void GridView1_DataBound(object sender, EventArgs e)
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
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        Label_Grid1_State.Text = "模糊搜索数据源";
        Label_Search.Text = Txt_search.Text.Trim();
        if (Txt_search.Text != "")
        {
            GridView1.DataSource = ppl.S_WorkOrderCode(Txt_search.Text.Trim());
            GridView1.DataBind();
            UpdatePanel_PS.Update();
        }
        else
        {
            Label_Grid1_State.Text = "默认数据源";
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
            UpdatePanel_PS.Update();
        }
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        Label_Grid1_State.Text = "默认数据源";
        Txt_search.Text = "";
        GridView1.DataSource = ppl.SList_WorkOrderCode();
        GridView1.DataBind();
        UpdatePanel_PS.Update();
        UpdatePanel_Search.Update();
        UpdatePanel_AddPS.Update();
        //无关信息隐藏
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();

        GridView1.SelectedIndex = -1;
        UpdatePanel_PS.Update();

        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_Add_Click(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
        GridView1.DataSource = ppl.SList_WorkOrderCode();
        GridView1.DataBind();
        UpdatePanel_PS.Update();
        Panel_AddPS.Visible = true;
        UpdatePanel_AddPS.Update();
        Panel_Product.Visible = false;
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        UpdatePanel_Product.Update();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        Label_Grid1_State.Text = "默认数据源";

        DataSet ds = ppl.S_WorkOrderCode_Name(txt_PS.Text);
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该随工单产品代码，不能重名！')", true);
            return;
        }
        if (txt_PS.Text.Trim() != "")
        {
            string PS_Name = txt_PS.Text.Trim();
            ppl.I_WorkOrderCode(PS_Name);
            ScriptManager.RegisterStartupScript(Panel_AddPS, typeof(Page), "alert", "alert('随工单产品代码新增成功!')", true);
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
            UpdatePanel_PS.Update();
            txt_PS.Text = "";
            Panel_AddPS.Visible = false;
            UpdatePanel_AddPS.Update();
            UpdatePanel_PS.Update();
        }
        else
        {
            ScriptManager.RegisterStartupScript(Panel_AddPS, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
        }
        Regex rx = new Regex("^[\u4E00-\u9FA5]+$");
        if (rx.IsMatch(txt_PS.Text.ToString()))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('随工单产品代码中不能含有汉字！请核对')", true);
            return;
        }
        if (!(txt_PS.Text.Trim().Length == 2))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('随工单产品代码只能为两位！')", true);
            return;
        }

    }
    protected void Button_Close_PSSearch_Click(object sender, EventArgs e)
    {

        Panel_AddPS.Visible = false;
        txt_PS.Text = "";
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
            DataSet ds = ppl.SList_WorkOrderCode();
            DataTable dt = ds.Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            DataSet ds = ppl.S_WorkOrderCode(Label_Search.Text.Trim());
            DataTable dt = ds.Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }

    }
    protected void Gridview_PS_Editing(object sender, GridViewEditEventArgs e)
    {
        GridView1.SelectedIndex = e.NewEditIndex;
        GridView1.EditIndex = e.NewEditIndex;

        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_WorkOrderCode(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源
        //无关信息隐藏
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();

    }
    protected void Gridview_PS_Updating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = ppl.S_WorkOrderCode_Name(Convert.ToString(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString()));
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该随工单产品代码，不能重名！')", true);
            return;
        }
        Guid WOC_ID = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
        string WOC_Name = Convert.ToString(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        ppl.U_WorkOrderCode(WOC_ID, WOC_Name);

        GridView1.EditIndex = -1;
        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_WorkOrderCode(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源
        UpdatePanel_PS.Update();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            GridView1.SelectedIndex = -1;

            try
            { 
                string id = e.CommandArgument.ToString();
                Guid guid_id = new Guid(id);
                ppl.D_WorkOrderCode(guid_id); 
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！请先删除该代码下所属的产品型号！')", true);
            }
            
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
            UpdatePanel_PS.Update();
            //无关信息隐藏

            Panel_AddPS.Visible = false;

            UpdatePanel_AddPS.Update();

        }
        if (e.CommandName == "CheckProType")
        {
            Panel_PT.Visible = true;
            GridView2.SelectedIndex = -1;

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = al[0];
            Label_PsName.Text = al[1] + " 所属";
            Label_PS.Text = id;
            Guid guid_id = new Guid(id);


            databind();
            //无关信息隐藏
            Panel_AddPS.Visible = false;
            UpdatePanel_AddPS.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();


        }
    }
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
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_WorkOrderCode(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源

        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView1.PageIndex = newPageIndex;

        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();

        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
    }
    protected void Gridview_PS_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = ppl.SList_WorkOrderCode();
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = ppl.S_WorkOrderCode(Txt_search.Text.Trim());
            GridView1.DataBind();
        } //绑定数据源
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Btn_SearchPT_Click(object sender, EventArgs e)
    {
        databind();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_CancelPT_Click(object sender, EventArgs e)
    {
        Txt_PT_Search.Text = "";
        Txt_PT_Search0.Text = "";
        databind();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Btn_AddPT_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        databind2();
        Panel_Product.Visible = true;
        UpdatePanel_Product.Update();

    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
            if (CheckBoxAll.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxfanxuan.Checked = false;
    }
    protected void Checkfanxuan_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxAll.Checked = false;
    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    ppl.D_Protype_WorkOrderCode(new Guid(GridView2.DataKeys[i].Values["PT_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的产品型号！请您核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！请您核对！')", true);


        }

        databind();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Btn_CloseS_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        UpdatePanel_PS.Update();
    }
    protected void SelectProType(object sender, EventArgs e)
    {
        databind2();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        databind2();
    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    ppl.U_Protype_WorkOrderCode(new Guid(Label_PS.Text.Trim()), new Guid(GridView_ProType.DataKeys[i].Values["PT_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的产品型号！请您核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！请您核对！')", true);


        }
        TextBox_ProductName.Text = "";
        TextBox_Series.Text = "";
        databind();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        DataBind();
        GridView2.PageIndex = 0;
        GridView2.SelectedIndex = -1;
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox2.Checked = false;
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView2.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;

        databind();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
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
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_ProType.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_ProType.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;


        databind2();
    }
}