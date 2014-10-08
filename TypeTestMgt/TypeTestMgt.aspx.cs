using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TypeTestMgt_TypeTestMgt : Page
{
    TypeTestL typeTestL = new TypeTestL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Panel_TypeTestMan.Visible = true;
            ClosePanel();
            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "Typetest" && Session["UserRole"].ToString().Contains("型式实验管理"))
                {
                    Title = "型式实验管理";
                    Btn_New.Visible = true;
                    Grid_TypeTestMan.Columns[6].Visible = false;//查看详情
                    Grid_TypeTestMan.Columns[7].Visible = true;//编辑
                    Grid_TypeTestMan.Columns[8].Visible = true;//选择产品型号
                    Grid_TypeTestMan.Columns[9].Visible = true;//删除
                    //string condition = GetCondition3();
                    //BindGrid_TypeTestMan(condition);
                    BindGrid_TypeTestMan("");
                }
                if (Lab_Status.Text == "Typetestlook" && Session["UserRole"].ToString().Contains("型式实验查看"))
                {
                    Title = "型式实验查看";
                    Btn_New.Visible = false;
                    Grid_TypeTestMan.Columns[6].Visible = true;//查看详情
                    Grid_TypeTestMan.Columns[7].Visible = false;//编辑
                    Grid_TypeTestMan.Columns[8].Visible = false;//选择产品型号
                    Grid_TypeTestMan.Columns[9].Visible = false;//删除
                    //this.DropDownList1.Items.FindByValue("已制定").Enabled = false;
                    //string condition = GetCondition3();
                    //BindGrid_TypeTestMan(condition);
                    BindGrid_TypeTestMan("");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    //protected string GetCondition3()
    //{
    //    string condition;
    //    string temp = "";
    //    if (this.Lab_Status.Text == "Typetest" && Session["UserRole"].ToString().Contains("型式实验管理"))
    //    {
    //        temp += "";
    //    }
    //    if (this.Lab_Status.Text == "Typetestlook" && Session["UserRole"].ToString().Contains("型式实验查看"))
    //    {
    //        temp += "and TTM_State='已完成'";
    //    }
    //    condition = temp;
    //    return condition;
    //}

    #region 绑定
    private void BindGrid_TypeTestMan(string condition)
    {
        Grid_TypeTestMan.DataSource = typeTestL.Search_TypeTestMan(condition);
        Grid_TypeTestMan.DataBind();
    }
    private void BindGridView_Detail(string condition)
    {
        GridView_Detail.DataSource = typeTestL.Search_TypeTestDetail(condition);
        GridView_Detail.DataBind();
    }
    private void BindGrid_Newpt(string condition)
    {
        Grid_Newpt.DataSource = typeTestL.Search_ProType_ProSeries(condition);
        Grid_Newpt.DataBind();
    }
    #endregion 绑定

    #region 型式实验计划检索
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Grid_TypeTestMan.EditIndex = -1;
        string condition = GetCondition();
        BindGrid_TypeTestMan(condition);
        Panel_TypeTestMan.Visible = true;
        UpdatePanel_TypeTestMan.Update();
        UpdatePanel_Search.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_TypeTest.Visible = false;
        UpdatePanel_TypeTest.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (TextTTM_Year.Text.ToString() != "")
        {
            temp += " and TTM_Year='" + TextTTM_Year.Text.ToString() + "'";
        }
        if (TextTTM_Month.Text.ToString() != "")
        {
            temp += " and  TTM_Month ='" + TextTTM_Month.Text.ToString() + "'";
        }
        if (DropDownList1.Text.ToString() != "")
        {
            temp += " and TTM_State='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (TextTTM_Maker.Text.ToString() != "")
        {
            temp += " and  TTM_Maker like '%" + TextTTM_Maker.Text.ToString() + "%'";
        }
        if (TextTTM_Time.Text.ToString() != "")
        {
            //temp += " and  TTM_Time = '" + this.TextTTM_Time.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),TTM_Time)=DateDiff(dd,getdate(),'" + TextTTM_Time.Text.ToString() + "')";
        }
        if (Lab_Status.Text == "Typetest" && Session["UserRole"].ToString().Contains("型式实验管理"))
        {
            temp += "";
        }
        if (Lab_Status.Text == "Typetestlook" && Session["UserRole"].ToString().Contains("型式实验查看"))
        {
            temp += "and TTM_State='已完成'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        Grid_TypeTestMan.EditIndex = -1;
        TextTTM_Year.Text = "";
        TextTTM_Month.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextTTM_Maker.Text = "";
        TextTTM_Time.Text = "";
        UpdatePanel_Search.Update();
        //string condition = GetCondition3();
        BindGrid_TypeTestMan("");
        Panel_TypeTestMan.Visible = true;
        UpdatePanel_TypeTestMan.Update();
        UpdatePanel_Search.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_TypeTest.Visible = false;
        UpdatePanel_TypeTest.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Grid_TypeTestMan.EditIndex = -1;
        Grid_TypeTestMan.SelectedIndex = -1;
        BindGrid_TypeTestMan("");
        UpdatePanel_TypeTestMan.Update();
        addyear.Text = DateTime.Now.ToString("yyyy");
        addmonth.Text = DateTime.Now.AddMonths(1).ToString("MM");
        addmaker.Text = Session["UserName"].ToString().Trim();
        addtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Panel_TypeTest.Visible = true;
        UpdatePanel_TypeTest.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    #endregion 型式实验计划检索

    #region 型式实验计划列表及Grid_TypeTestMan
    protected void Grid_TypeTestMan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_TypeTest.Visible = false;
        UpdatePanel_TypeTest.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();

        if (e.CommandName == "Look1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_TypeTestMan.SelectedIndex = row.RowIndex;

            Grid_TypeTestMan.EditIndex = -1;
            add_detail.Visible = false;
            GridView_Detail.Columns[12].Visible = true;
            GridView_Detail.Columns[13].Visible = false;
            GridView_Detail.Columns[14].Visible = true;
            GridView_Detail.Columns[15].Visible = false;
            GridView_Detail.Columns[16].Visible = false;
            Guid TTM_TypePlanID = new Guid(Convert.ToString(e.CommandArgument));
            Label_ttmid.Text = TTM_TypePlanID.ToString();
            BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "'");
            Panel_Detail.Visible=true;

            //foreach (GridViewRow gvr in GridView_Detail.Rows)
            //{
            //    //if (this.GridView_Detail.Rows[gvr.].Cells[7] = "")
            //    if (gvr.Cells[7] = "")
            //    {
            //        LinkButton cb = this.GridView_Detail.Rows[gvr.RowIndex].FindControl("Down2") as LinkButton;
            //        cb.Text = "";
            //    }
            //}

            UpdatePanel_Detail.Update();
            Panel1.Visible = true;
            Panel10.Visible = false;
            ClosePanel();
            UpdatePanel_upload.Update();
        }
        if (e.CommandName == "Item1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_TypeTestMan.SelectedIndex = row.RowIndex;

            Grid_TypeTestMan.EditIndex = -1;
            BindGrid_TypeTestMan("");
            add_detail.Visible = true;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid TTM_TypePlanID = new Guid(al[0]);
            Label_ttmid.Text = TTM_TypePlanID.ToString();
            string TTM_State = al[1];
            BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "' ");
            Panel_Detail.Visible = true;
            if (TTM_State == "已制定")
            {
                Panel1.Visible = false;
                Panel10.Visible = true;
                GridView_Detail.Columns[12].Visible = true;
                GridView_Detail.Columns[13].Visible = true;
                GridView_Detail.Columns[14].Visible = true;
                GridView_Detail.Columns[15].Visible = true;
                GridView_Detail.Columns[16].Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                Panel10.Visible = false;
                add_detail.Visible = false;
                GridView_Detail.Columns[12].Visible = true;
                GridView_Detail.Columns[13].Visible = true;
                GridView_Detail.Columns[14].Visible = false;
                GridView_Detail.Columns[15].Visible = false;
            }
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox4.Text = "";
            DropDownList2.SelectedValue = "";
            UpdatePanel_Detail.Update();
            ClosePanel();
            UpdatePanel_upload.Update();
        }
        if (e.CommandName == "Delete1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_TypeTestMan.SelectedIndex = row.RowIndex;

            Guid TTM_TypePlanID = new Guid(Convert.ToString(e.CommandArgument));
            DataSet ds = typeTestL.Search_TypeTestMan_TypeTestDetail(TTM_TypePlanID);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请先在“计划详情”中删除实验报告！')", true);
                return;
            }
            typeTestL.Delete_TypeTestMan(TTM_TypePlanID);
            //string condition = GetCondition3();
            BindGrid_TypeTestMan("");
            UpdatePanel_TypeTestMan.Update();
        }
    }
    //显示编辑状态
    protected void Grid_TypeTestMan_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string TTM_State = (Grid_TypeTestMan.Rows[e.NewEditIndex].Cells[5].Text.Trim().ToString());
        if (TTM_State == "已完成")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTestMan, GetType(), "aa", "alert('该状态下不能编辑!')", true);
            return;
        }
        Grid_TypeTestMan.EditIndex = e.NewEditIndex;
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_TypeTest.Visible = false;
        UpdatePanel_TypeTest.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
        string condition = GetCondition();
        BindGrid_TypeTestMan(condition);
    }
    //Gridview编辑
    protected void Grid_TypeTestMan_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid tTM_TypePlanID = new Guid(Grid_TypeTestMan.DataKeys[e.RowIndex].Value.ToString());
        //年份不为空
        if (((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('年份不能为空！')", true);
            return;
        }
        Int16 m2;
        if (!(Int16.TryParse(((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].Cells[1].Controls[0])).Text, out m2)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTestMan, GetType(), "alert", "alert('年份必须为整数！')", true);
            return;
        }
        Int16 tTM_Year = m2;
        //月份不为空
        if (((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月份不能为空！')", true);
            return;
        }
        Byte m3;
        if (!(Byte.TryParse(((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].Cells[2].Controls[0])).Text, out m3)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTestMan, GetType(), "alert", "alert('月份必须为整数！')", true);
            return;
        }
        Byte tTM_Month = m3;
        //制定人不为空
        //if (((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('制定人不能为空！')", true);
        //    return;
        //}
        string tTM_Maker = (Grid_TypeTestMan.Rows[e.RowIndex].Cells[3].Text.Trim().ToString());
        //制定时间不为空
        //if (((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString() == "")
        if (((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].FindControl("TTM_Time"))).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定时间不能为空！')", true);
            return;
        }
        DateTime tTM_Time = Convert.ToDateTime(((TextBox)(Grid_TypeTestMan.Rows[e.RowIndex].FindControl("TTM_Time"))).Text.Trim().ToString());
        //判断重复
        DataSet ds = typeTestL.Search_TypeTestMan("and TTM_Year = '" + tTM_Year + " ' and TTM_Month = '" + tTM_Month + " '  and TTM_State = '已制定'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该月已有型式实验计划，不能重复！')", true);
            return;
        }
        Grid_TypeTestMan.EditIndex = -1;
        typeTestL.Update_TypeTestMan(tTM_TypePlanID, tTM_Year, tTM_Month,tTM_Maker, tTM_Time);
        //string condition = GetCondition3();
        BindGrid_TypeTestMan("");
        TextTTM_Year.Text = "";
        TextTTM_Month.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextTTM_Maker.Text = "";
        TextTTM_Time.Text = "";
        UpdatePanel_Search.Update();
        UpdatePanel_TypeTestMan.Update();
    }
    //取消编辑
    protected void Grid_TypeTestMan_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_TypeTestMan.EditIndex = -1;
        TextTTM_Year.Text = "";
        TextTTM_Month.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextTTM_Maker.Text = "";
        TextTTM_Time.Text = "";
        //string condition = GetCondition3();
        BindGrid_TypeTestMan("");
        UpdatePanel_Search.Update();
        UpdatePanel_TypeTestMan.Update();
    }

    //Gridview翻页
    protected void Grid_TypeTestMan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_TypeTestMan.BottomPagerRow;


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
        BindGrid_TypeTestMan(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_TypeTestMan.PageCount ? Grid_TypeTestMan.PageCount - 1 : newPageIndex;
        Grid_TypeTestMan.PageIndex = newPageIndex;
        Grid_TypeTestMan.DataBind();
    }

    protected void Grid_TypeTestMan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 型式实验计划列表及Grid_TypeTestMan

    #region 型式实验计划详情及GridView_Detail
    //GridView_Detail
    protected void GridView_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_TypeTest.Visible = false;
        UpdatePanel_TypeTest.Update();

        if (e.CommandName == "Up2")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Detail.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid TTD_DetailID = new Guid(al[0]);
            Label_ttdid.Text = Convert.ToString(TTD_DetailID);
            string TTD_RepRoute = al[1];
            //判重
            if (TTD_RepRoute!="")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('实验报告已上传,不能重复！')", true);
                return;
            }
            ShowPanel();
            UpdatePanel_upload.Update();
            reportno.Text = "";
            upper.Text = Session["UserName"].ToString().Trim();
            uptime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
            GridView_Detail.EditIndex = -1;
            BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "' ");
        }
        if (e.CommandName == "Delete2")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Detail.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid  TTD_DetailID = new Guid(al[0]);
            string TTD_RepRoute = al[1];
            typeTestL.Delete_TypeTestDetail(TTD_DetailID);
            if (TTD_RepRoute!="")
            {
                string delfile = Server.MapPath("~/") + TTD_RepRoute;
                File.Delete(delfile);
            }
            BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "'");
            ClosePanel();
            UpdatePanel_upload.Update();
            UpdatePanel_Detail.Update();
        }
    }
    //显示编辑状态
    protected void GridView_Detail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_Detail.EditIndex = e.NewEditIndex;
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();

        string condition2 = GetCondition2();
        BindGridView_Detail(condition2);
        //BindGridView_Detail("and a.TTM_TypePlanID='" + this.Label_ttmid.Text + "'");
    }
    //Gridview编辑
    protected void GridView_Detail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid TTD_DetailID = new Guid(GridView_Detail.DataKeys[e.RowIndex].Value.ToString());
        string TTD_Company = ((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString();

        GridView_Detail.EditIndex = -1;
        typeTestL.Update_TypeTestDetail_company(TTD_DetailID, TTD_Company);
        string condition2 = GetCondition2();
        BindGridView_Detail(condition2);
        //BindGridView_Detail("and a.TTM_TypePlanID='" + this.Label_ttmid.Text + "'");
        UpdatePanel_Detail.Update();
    }
    //取消编辑
    protected void GridView_Detail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Detail.EditIndex = -1;
        BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "'");
        UpdatePanel_Detail.Update();
    }
    protected void GridView_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Detail.BottomPagerRow;


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
        string condition2 = GetCondition2();
        BindGridView_Detail(condition2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Detail.PageCount ? GridView_Detail.PageCount - 1 : newPageIndex;
        GridView_Detail.PageIndex = newPageIndex;
        GridView_Detail.DataBind();
    }
    protected void GridView_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[12].Text == "&nbsp;" || e.Row.Cells[12].Text == "")
            {
                e.Row.Cells[14].Enabled = false;
            }
        }
    }
    //protected string GetCondition2()
    //{
    //    string condition2;
    //    string temp = "";
    //    if (this.Lab_Status.Text == "Typetest" && Session["UserRole"].ToString().Contains("型式实验管理"))
    //    {
    //        temp += " and TTD_IsUploaded='否'";
    //    }
    //    if (this.Lab_Status.Text == "Typetestlook" && Session["UserRole"].ToString().Contains("型式实验查看"))
    //    {
    //        temp += " and TTD_IsUploaded='是'";
    //    }
    //    temp += "";
    //    condition2 = temp + "and a.TTM_TypePlanID='" + this.Label_ttmid.Text + "'";
    //    return condition2;
    //}
    //按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView_Detail.EditIndex = -1;
        string condition2 = GetCondition2();
        BindGridView_Detail(condition2);
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    protected string GetCondition2()
    {
        string condition2;
        string temp = "";
        if (TextBox4.Text.ToString() != "")
        {
            temp += " and TTD_Company like '%" + TextBox4.Text.ToString() + "%'";
        }
        if (TextBox5.Text.ToString() != "")
        {
            temp += " and PS_Name like '%" + TextBox5.Text.ToString() + "%'";
        }
        if (TextBox6.Text.ToString() != "")
        {
            temp += " and PT_Name like '%" + TextBox6.Text.ToString() + "%'";
        }
        if (TextBox7.Text.ToString() != "")
        {
            temp += " and TTD_ExpNO like '%" + TextBox7.Text.ToString() + "%'";
        }
        if (TextBox8.Text.ToString() != "")
        {
            temp += " and TTD_ReportNO like '%" + TextBox8.Text.ToString() + "%'";
        }
        if (DropDownList2.Text.ToString() != "")
        {
            temp += " and TTD_IsUploaded='" + DropDownList2.SelectedValue.ToString() + "'";
        }
        if (DropDownList4.SelectedValue.ToString() != "")
        {
            temp += " and TTD_IsPass='" + DropDownList4.SelectedValue.ToString() + "'";
        }
        condition2 = temp + "and a.TTM_TypePlanID='" + Label_ttmid.Text + "'";
        return condition2;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView_Detail.EditIndex = -1;
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox4.Text = "";
        DropDownList2.SelectedValue = "";
        DropDownList4.SelectedValue = "";
        BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "' ");
        UpdatePanel_Detail.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    protected void add_detail_Click(object sender, EventArgs e)
    {
        GridView_Detail.EditIndex = -1;
        BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "' ");
        Panel_Newpt.Visible = true;
        UpdatePanel_Newpt.Update();
        textps.Text = "";
        textpt.Text = "";
        BindGrid_Newpt("");
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    protected void ok_detail_Click(object sender, EventArgs e)
    {
        Guid tTM_TypePlanID = new Guid(Label_ttmid.Text.ToString());
        string tTM_State = "已完成";
        DataSet ds = typeTestL.Search_TypeTestMan("and TTM_TypePlanID = '" + tTM_TypePlanID + "' and TTM_State='" + tTM_State + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('此实验计划已完成，不能重复提交！')", true);
            return;
        }
        DataSet ds1 = typeTestL.Search_TypeTestMan_TypeTestDetail_not(tTM_TypePlanID);
        DataTable dt1 = ds1.Tables[0];
        if (dt1.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('还有未上传的实验报告，不能提交！')", true);
            return;
        }
        typeTestL.Update_TypeTestMan_done(tTM_TypePlanID, tTM_State);
        //string condition = GetCondition3();
        BindGrid_TypeTestMan("");
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        UpdatePanel_TypeTestMan.Update();
    }
    protected void close_detail_Click(object sender, EventArgs e)
    {
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    protected void close_detail2_Click(object sender, EventArgs e)
    {
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    #endregion 型式实验计划详情及GridView_Detail

    #region 新增型式实验计划
    protected void Ok_new_Click(object sender, EventArgs e)
    {
        if (addyear.Text.ToString() == "" || addmonth.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        //年份
        Int16 m4;
        if (!(Int16.TryParse(addyear.Text.ToString(), out m4)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTest, GetType(), "alert", "alert('年份输入不合法！')", true);
            return;
        }
        if (m4 > 10000 || m4 < 1900)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTest, GetType(), "alert", "alert('年份输入不合法！')", true);
            return;
        }
        Int16 tTM_Year = m4;
        //月份
        Byte m5;
        if (!(Byte.TryParse(addmonth.Text.ToString(), out m5)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTest, GetType(), "alert", "alert('月份输入不合法！')", true);
            return;
        }
        if (m5 > 12 || m5 < 1)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTest, GetType(), "alert", "alert('月份输入不合法！')", true);
            return;
        }
        Byte tTM_Month = m5;
        
        //状态、制定人、制定时间
        string tTM_State = "已制定";
        string tTM_Maker = addmaker.Text.ToString();
        DateTime tTM_Time = Convert.ToDateTime(addtime.Text.ToString());
        //判断重复
        DataSet ds = typeTestL.Search_TypeTestMan("and TTM_Year = '" + tTM_Year + " ' and TTM_Month = '" + tTM_Month + " ' and TTM_State = '已制定'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该月已有型式实验计划，不能重复！')", true);
            return;
        }
        Grid_TypeTestMan.EditIndex = -1;
        typeTestL.Insert_TypeTestMan(tTM_Year, tTM_Month, tTM_State, tTM_Maker, tTM_Time);
        //string condition = GetCondition3();
        BindGrid_TypeTestMan("");
        Panel_TypeTest.Visible = false;
        UpdatePanel_TypeTest.Update();
        UpdatePanel_TypeTestMan.Update();
        ScriptManager.RegisterClientScriptBlock(UpdatePanel_TypeTest, GetType(), "alert", "alert('请在“计划详情”中为该计划选择产品型号！')", true);
    }
    protected void Cancel_new_Click(object sender, EventArgs e)
    {
        Panel_TypeTest.Visible = false;
        UpdatePanel_TypeTest.Update();
    }
    #endregion 新增型式实验计划

    #region 选择产品型号及Grid_Newpt
    //精确搜索
    protected void Search_newpt_Click(object sender, EventArgs e)
    {
        string condition1 = GetCondition1();
        BindGrid_Newpt(condition1);
    }
    protected string GetCondition1()
    {
        string condition1;
        string temp = "";
        if (textps.Text.ToString() != "")
        {
            temp += " and b.PS_Name like '%" + textps.Text.ToString() + "%'";
        }
        if (textpt.Text.ToString() != "")
        {
            temp += " and  a.PT_Name like '%" + textpt.Text.ToString() + "%'";
        }
        temp += "";
        condition1 = temp;
        return condition1;
    }
    protected void Clear_newpt_Click(object sender, EventArgs e)
    {
        textps.Text = "";
        textpt.Text = "";
        BindGrid_Newpt("");
    }
    //获取或设置选中项的集合(选中的行，翻页不消失)
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
    //从当前页收集选中项的情况
    protected void CollectSelected()
    {
        ArrayList selectedItems = null;
        if (SelectedItems == null)
            selectedItems = new ArrayList();
        else
            selectedItems = SelectedItems;
        //获取选择的记录
        for (int i = 0; i < Grid_Newpt.Rows.Count; i++)
        {
            //string id = this.GridView_ProType.Rows[i].Cells[1].Text;
            CheckBox cb = Grid_Newpt.Rows[i].FindControl("ckb") as CheckBox;
            string id = Grid_Newpt.DataKeys[i].Values[0].ToString();
            if (selectedItems.Contains(id) && !cb.Checked)
                selectedItems.Remove(id);
            if (!selectedItems.Contains(id) && cb.Checked)
                selectedItems.Add(id);
        }
        SelectedItems = selectedItems;
    }
    //Grid_Newpt
    protected void Grid_Newpt_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void Grid_Newpt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Newpt.BottomPagerRow;

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
        CollectSelected();
        string condition1 = GetCondition1();
        BindGrid_Newpt(condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Newpt.PageCount ? Grid_Newpt.PageCount - 1 : newPageIndex;
        Grid_Newpt.PageIndex = newPageIndex;
        Grid_Newpt.DataBind();
    }
    //回显之前选中的情况
    protected void Grid_Newpt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1 && SelectedItems != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("ckb") as CheckBox;
            string id = Grid_Newpt.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }
    //选择后提交
    protected void BtnOK_Newpt_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Grid_Newpt.Rows)
        {
            CheckBox cb = item.FindControl("ckb") as CheckBox;
            if (cb.Checked)
            {
                Guid pT_ID = new Guid(Grid_Newpt.DataKeys[item.RowIndex].Value.ToString());
                Guid tTM_TypePlanID = new Guid(Label_ttmid.Text.ToString());
                string tTD_IsUploaded = "否";

                DataSet ds = typeTestL.Search_TypeTestDetail("and a.TTM_TypePlanID = '" + tTM_TypePlanID + "' and b.PT_ID='" + pT_ID + "'");
                if (!(ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的也不添加。
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Newpt, GetType(), "aa", "alert('此产品型号已选，不能重复!')", true);
                    return;
                }
                else
                {
                    typeTestL.Insert_TypeTestDetail(pT_ID, tTM_TypePlanID, tTD_IsUploaded);
                    BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "'");
                    UpdatePanel_Detail.Update();
                    UpdatePanel_Newpt.Update();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Newpt, GetType(), "alert", "alert('请编辑厂家名称！')", true);
                }
            }
        }
    }
    protected void BtnCancel_Newpt_Click(object sender, EventArgs e)
    {
        Panel_Newpt.Visible = false;
        UpdatePanel_Newpt.Update();
    }
    #endregion 选择产品型号及Grid_Newpt

    #region 上传实验报告
    protected void ok_upload_Click(object sender, EventArgs e)
    {
        if (reportno.Text.ToString() == "" || FileUpload1.PostedFile.FileName == "" || DropDownList3.SelectedValue=="")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
        if (FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx" || fileExrensio == ".rar" || fileExrensio == ".zip")//判断文件扩展名
            {
                try
                {
                    if (!Directory.Exists(UploadURL))//判断文件夹是否已经存在
                    {
                        Directory.CreateDirectory(UploadURL);//创建文件夹
                    }
                    FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('上传失败！')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('请选择文件!')", true);
            return;
        }

        //string filePath = UploadURL + newname + fullname;//存储上传的路径
        string filePath = "file/" + newname + fullname;
        Guid TTD_DetailID = new Guid(Label_ttdid.Text.ToString()); ;
        string TTD_IsUploaded = "是";
        string TTD_ReportNO = reportno.Text;
        string TTD_UpPer = upper.Text;
        DateTime TTD_UpTime = Convert.ToDateTime(uptime.Text);
        string TTD_RepRoute = filePath;
        string TTD_IsPass = DropDownList3.SelectedValue;

        DataSet ds4 = typeTestL.Search_TypeTestDetail("and TTD_ReportNO = '" + reportno.Text + "'");
        DataTable dt4 = ds4.Tables[0];
        if (dt4.Rows.Count != 0)
        //if (!(ds4.Tables[0].Rows.Count == 0))
        {
            ScriptManager.RegisterStartupScript(UpdatePanel_upload, GetType(), "aa", "alert('实验报告编号不能重复！')", true);
            return;
        }
        typeTestL.Update_TypeTestDetail(TTD_DetailID, TTD_IsUploaded, TTD_ReportNO, TTD_UpPer, TTD_UpTime, TTD_RepRoute, TTD_IsPass);
        BindGridView_Detail("and a.TTM_TypePlanID='" + Label_ttmid.Text + "'");

        ClosePanel();
        UpdatePanel_upload.Update();
    }
    private void ShowPanel()//显示“上传实验报告”框
    {
        string script = "document.getElementById('Panel99').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
    }
    private void ClosePanel()//关闭“上传实验报告”框
    {
        string script = "document.getElementById('Panel99').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel", script, true);
    }
    protected void cancel_upload_Click(object sender, EventArgs e)
    {
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    #endregion 上传实验报告
}