using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class CraftMgt_ProcessRouteMgt : Page
{
    CMProcessRouteL cmpr = new CMProcessRouteL();
    CMProcessRouteInfo cminfo = new CMProcessRouteInfo();
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    protected void Page_Load(object sender, EventArgs e) //权限判定
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

                Button_AddPR.Visible = false;
                Title = "工艺路线查看";
                GridView_PR.Columns[5].Visible = false;
                GridView_PR.Columns[6].Visible = false;
                GridView_CraftMgt.Columns[7].Visible = false;
                GridView_CraftMgt.Columns[8].Visible = false;
                Button_AddCraft.Visible = false;
                Label1.Visible=false;
                DropDownList1.Visible = false;
                Button_copy.Visible = false;

            }
            if (state == "manage")
            {
                Title = "工艺路线管理";

            }


            if (!IsPostBack)//页面初始化
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("工艺路线查看")) || (Session["UserRole"].ToString().Contains("工艺路线管理"))))
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("工艺路线管理"))
                    {
                        Button_AddPR.Visible = false;
                        Title = "工艺路线查看";
                        GridView_PR.Columns[5].Visible = false;
                        GridView_PR.Columns[6].Visible = false;
                        GridView_CraftMgt.Columns[7].Visible = false;
                        GridView_CraftMgt.Columns[8].Visible = false;
                        Button_AddCraft.Visible = false;
                        Label1.Visible = false;
                        DropDownList1.Visible = false;
                        Button_copy.Visible = false;
                    }
                    label_GridPageState.Text = "默认数据源";

                    string condition = " and 1=1";
                    GridView_Doc.DataSource = cmpr.S_ProcessRoute_Doc(condition);
                    GridView_Doc.DataBind();
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



    #region  工艺文件表
    protected void Btn_Search_Click(object sender, EventArgs e)//点击检索，检索工艺文件表
    {
        label_GridPageState.Text = "检索数据源";

        //无关信息隐藏
        Panel_PR.Visible = false;
        Panel_AddOrEditPR.Visible = false;
        Panel_CraftMgt.Visible = false;
        Panel_Craft.Visible = false;
        GridView_CraftMgt.EditIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;
        GridView_PR.EditIndex = -1;
        GridView_PR.SelectedIndex = -1;
        UpdatePanel_PR.Update();
        UpdatePanel_AddOrEditPR.Update();
        UpdatePanel_CraftMgt.Update();
        UpdatePanel_Craft.Update();

        dataBind();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)//重置
    {
        clear();
    }
    public void clear()
    {
        //无关信息隐藏
        Panel_PR.Visible = false;
        Panel_AddOrEditPR.Visible = false;
        Panel_CraftMgt.Visible = false;
        Panel_Craft.Visible = false;
        GridView_CraftMgt.EditIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;
        GridView_PR.EditIndex = -1;
        GridView_PR.SelectedIndex = -1;
        UpdatePanel_PR.Update();
        UpdatePanel_AddOrEditPR.Update();
        UpdatePanel_CraftMgt.Update();
        UpdatePanel_Craft.Update();
        GridView_Doc.SelectedIndex = -1;
        TextBox_DocType.Text = "";
        TextBox_ApplySN.Text = "";
        TextBox_ApplyTime1.Text = "";
        TextBox_ApplyTime2.Text = "";
        TextBox_AppMan.Text = "";
        TextBox_ChagenType.Text = "";
        TextBox_DocSN.Text = "";
        TextBox_PRName.Text = "";
        TextBox_State.Text = "";
        TextBox_VersionNum.Text = "";
        label_GridPageState.Text = "默认数据源";
        string condition = " and 1=1";
        GridView_Doc.DataSource = cmpr.S_ProcessRoute_Doc(condition);
        GridView_Doc.DataBind();
        UpdatePanel_Doc.Update();
    }
    public void dataBind()//检索数据源绑定
    {
        string condition;
        string CDA_DocName = TextBox_PRName.Text.Trim() == "" ? " and 1=1 " : " and CDA_DocName like '%" + TextBox_PRName.Text.Trim() + "%' ";
        string CDA_DocNO = TextBox_DocSN.Text.Trim() == "" ? " and 1=1 " : " and CDA_DocNO like '%" + TextBox_DocSN.Text.Trim() + "%' ";
        string CDA_AppNO = TextBox_ApplySN.Text.Trim() == "" ? " and 1=1 " : " and CDA_AppNO like '%" + TextBox_ApplySN.Text.Trim() + "%' ";
        string CDA_EditionNO = TextBox_VersionNum.Text.Trim() == "" ? " and 1=1 " : " and CDA_EditionNO like '%" + TextBox_VersionNum.Text.Trim() + "%' ";
        string CDA_DocType = TextBox_DocType.Text.Trim() == "" ? " and 1=1 " : "and CDA_DocType like '%" + TextBox_DocType.Text.Trim() + "%' ";
        string CDA_ChangedType = TextBox_ChagenType.Text.Trim() == "" ? " and 1=1 " : "and CDA_ChangedType like '%" + TextBox_ChagenType.Text.Trim() + "%' ";
        string CDA_AppState = TextBox_State.Text.Trim() == "" ? " and 1=1 " : "and CDA_AppState like '%" + TextBox_State.Text.Trim() + "%' ";
        string CDA_AppPer = TextBox_AppMan.Text.Trim() == "" ? " and 1=1 " : "and CDA_AppPer like '%" + TextBox_AppMan.Text.Trim() + "%' ";

        if ((TextBox_ApplyTime1.Text != "" && TextBox_ApplyTime2.Text == "") || (TextBox_ApplyTime1.Text == "" && TextBox_ApplyTime2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }

        string CDA_AppTime = (TextBox_ApplyTime1.Text.Trim() == "" && TextBox_ApplyTime2.Text.Trim() == "") ? " and 1=1 " : " and CDA_AppTime between   ' " + TextBox_ApplyTime1.Text.Trim() + "' and ' " + TextBox_ApplyTime2.Text.Trim() + "'";



        condition = CDA_DocName + CDA_DocNO + CDA_AppNO + CDA_EditionNO + CDA_DocType + CDA_AppState + CDA_AppPer + CDA_AppTime + CDA_ChangedType;

        GridView_Doc.DataSource = cmpr.S_ProcessRoute_Doc(condition);
        GridView_Doc.DataBind();
        UpdatePanel_Doc.Update();
    }
    protected void Button_Craft_Click(object sender, EventArgs e)//检索工艺文件表
    {
        foreach (GridViewRow item in GridView_Craft.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {

                Guid prid = new Guid(Label_PRID.Text.ToString());
                Guid pbcid = new Guid(GridView_Craft.DataKeys[item.RowIndex].Value.ToString());
                cmpr.I_PRDetail_PBCraftInfo(prid, pbcid);
                GridView_CraftMgt.DataSource = cmpr.S_ProcessRoute_PRDetail(prid);
                GridView_CraftMgt.DataBind();
                Panel_CraftMgt.Visible = true;
                UpdatePanel_CraftMgt.Update();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                Panel_Craft.Visible = false;
                UpdatePanel_Craft.Update();

            }
        }
    }
    protected void GridView_Doc_PageIndexChanging(object sender, GridViewPageEventArgs e)//工艺文件表分页
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Doc.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Doc.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Doc.PageCount ? GridView_Doc.PageCount - 1 : newPageIndex;
        GridView_Doc.PageIndex = newPageIndex;
        GridView_Doc.PageIndex = newPageIndex;


        if (label_GridPageState.Text == "默认数据源")
        {
            string condition = " and 1=1";
            GridView_Doc.DataSource = cmpr.S_ProcessRoute_Doc(condition);
            GridView_Doc.DataBind();
            UpdatePanel_Doc.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
        Panel_PR.Visible = false;
        Panel_AddOrEditPR.Visible = false;
        Panel_CraftMgt.Visible = false;
        Panel_Craft.Visible = false;
        GridView_CraftMgt.EditIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;
        GridView_PR.EditIndex = -1;
        GridView_PR.SelectedIndex = -1;
        UpdatePanel_PR.Update();
        UpdatePanel_AddOrEditPR.Update();
        UpdatePanel_CraftMgt.Update();
        UpdatePanel_Craft.Update();
        GridView_Doc.SelectedIndex = -1;
        UpdatePanel_Doc.Update();
    }
    protected void GridView_Doc_RowCommand(object sender, GridViewCommandEventArgs e)//工艺文件链接按钮事件
    {
        if (e.CommandName == "Detail")//查看详情
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Doc.SelectedIndex = row.RowIndex;
            Panel_CraftMgt.Visible = false;
            UpdatePanel_CraftMgt.Update();
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid cdaid = new Guid(al[0]);
            label_cdaid.Text = al[0];
            Label_CDAstate.Text = al[1];
            GridView_PR.DataSource = cmpr.S_ProcessRoute(cdaid);
            GridView_PR.DataBind();
            Panel_PR.Visible = true;
            UpdatePanel_PR.Update();
            GridView_PR.SelectedIndex = -1;

            Panel_AddOrEditPR.Visible = false;
            UpdatePanel_AddOrEditPR.Update();
            Panel_Craft.Visible = false;
            UpdatePanel_Craft.Update();
        }
    }
    protected void GridView_Doc_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_Doc_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    #endregion
    #region 工艺路线表
    protected void GridView_PR_PageIndexChanging(object sender, GridViewPageEventArgs e)//工艺路线表分页
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_PR.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_PR.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_PR.PageCount ? GridView_PR.PageCount - 1 : newPageIndex;
        GridView_PR.PageIndex = newPageIndex;
        GridView_PR.PageIndex = newPageIndex;
        GridView_PR.DataSource = cmpr.S_ProcessRoute(new Guid(label_cdaid.Text.Trim()));
        GridView_PR.DataBind();
        Panel_PR.Visible = true;
        UpdatePanel_PR.Update();
        GridView_PR.SelectedIndex = -1;
        GridView_Craft.SelectedIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;

        //无关信息隐藏
        // this.Panel_PR.Visible = false;
        Panel_AddOrEditPR.Visible = false;
        Panel_CraftMgt.Visible = false;
        Panel_Craft.Visible = false;
        //    UpdatePanel_PR.Update();
        UpdatePanel_AddOrEditPR.Update();
        UpdatePanel_CraftMgt.Update();
        UpdatePanel_Craft.Update();
    }
    protected void GridView_PR_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void GridView_PR_RowCommand(object sender, GridViewCommandEventArgs e) //工艺路线表中的链接按钮事件
    {
        if (e.CommandName == "CraftMgt000") //工艺路线所属工序管理
        {
            Panel_CraftMgt.Visible = true;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_PR.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = al[0];
            Label_prnamecheck.Text = al[1];
            Guid prid = new Guid(id);
            Label_PRID.Text = id;
            GridView_CraftMgt.DataSource = cmpr.S_ProcessRoute_PRDetail(prid);
            GridView_CraftMgt.DataBind();
            GridView_CraftMgt.SelectedIndex = -1;
            Panel_AddOrEditPR.Visible = false;
            Panel_CraftMgt.Visible = true;
            Panel_Craft.Visible = false;
            UpdatePanel_AddOrEditPR.Update();
            UpdatePanel_Craft.Update();
            DropDownList1.DataSource = ppl.S_PR_Name();
            DropDownList1.DataTextField = "PR_Name";
            DropDownList1.DataValueField = "PR_ID";
            DropDownList1.DataBind();
            DataSet ds3 = cmpr.S_ProcessRoute_PRDetail(prid);
            DataTable dt3 = ds3.Tables[0];
            if (dt3.Rows.Count != 0)
            {
                Button_copy.Attributes.Add("OnClick", "return confirm('工艺路线中已存在部分工序，是否仍然复制插入?')");

            }
            else
            {


                Button_copy.Attributes.Remove("OnClick");
                Button_copy.Attributes.Add("OnClick", "return confirm('工艺路线中尚无工序，将会复制所选工艺路线中的工序，确定吗?')");

            }
            UpdatePanel_CraftMgt.Update();
        }
        if (e.CommandName == "Edit_PR")//编辑工艺路线
        {
            //无关信息隐藏
            //  this.Panel_PR.Visible = false;
            //  this.Panel_AddOrEditPR.Visible = false;
            Panel_CraftMgt.Visible = false;
            Panel_Craft.Visible = false;
            GridView_CraftMgt.EditIndex = -1;
            GridView_CraftMgt.SelectedIndex = -1;
            // GridView_PR.EditIndex = -1;
            //   GridView_PR.SelectedIndex = -1;
            //   UpdatePanel_PR.Update();
            //   UpdatePanel_AddOrEditPR.Update();
            UpdatePanel_CraftMgt.Update();
            UpdatePanel_Craft.Update();



            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_PR.SelectedIndex = row.RowIndex;
            label_AddOrEdit.Text = "编辑";
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_PRID.Text = al[0];
            Guid prid = new Guid(al[0]);
            Label_PRName.Text = al[1];
            TextBox_AddOrEditPRName.Text = al[1];
            DropDownList_Special.SelectedValue = al[2];
            Panel_AddOrEditPR.Visible = true;
            UpdatePanel_AddOrEditPR.Update();



        }
        if (e.CommandName == "Delete_PR") //删除工艺路线
        {
            //无关信息隐藏
            //  this.Panel_PR.Visible = false;
            //  this.Panel_AddOrEditPR.Visible = false;
            Panel_CraftMgt.Visible = false;
            Panel_Craft.Visible = false;
            GridView_CraftMgt.EditIndex = -1;
            GridView_CraftMgt.SelectedIndex = -1;
            // GridView_PR.EditIndex = -1;
            //   GridView_PR.SelectedIndex = -1;
            //   UpdatePanel_PR.Update();
            //   UpdatePanel_AddOrEditPR.Update();
            UpdatePanel_CraftMgt.Update();
            UpdatePanel_Craft.Update();

            GridView_PR.SelectedIndex = -1;
            GridView_PR.EditIndex = -1;


            string prid = e.CommandArgument.ToString();
            cminfo.PR_ID = new Guid(prid);
            cmpr.D_ProcessRoute(cminfo);
            GridView_PR.DataSource = cmpr.S_ProcessRoute(new Guid(label_cdaid.Text.Trim()));
            GridView_PR.DataBind();
            Panel_PR.Visible = true;
            UpdatePanel_PR.Update();


        }
    }
    protected void GridView_PR_Editing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView_PR_Updating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView_PR_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_PR_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Btn_ClosePR_Click(object sender, EventArgs e)//关闭工艺路线表及其子页面
    {
        //无关信息隐藏
        Panel_PR.Visible = false;
        Panel_AddOrEditPR.Visible = false;
        Panel_CraftMgt.Visible = false;
        Panel_Craft.Visible = false;
        GridView_CraftMgt.EditIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;
        GridView_PR.EditIndex = -1;
        GridView_PR.SelectedIndex = -1;
        UpdatePanel_PR.Update();
        UpdatePanel_AddOrEditPR.Update();
        UpdatePanel_CraftMgt.Update();
        UpdatePanel_Craft.Update();

    }
    #endregion
    #region 工序管理表
    protected void GridView_CraftMgt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_CraftMgt_CancelingEdit(object sender, GridViewCancelEditEventArgs e)//工艺路线表取消编辑
    { //无关信息隐藏 
        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();

        GridView_CraftMgt.SelectedIndex = -1;
        GridView_CraftMgt.EditIndex = -1;
        GridView_CraftMgt.DataSource = cmpr.S_ProcessRoute_PRDetail(new Guid(Label_PRID.Text));
        GridView_CraftMgt.DataBind();
        UpdatePanel_CraftMgt.Update();
    }
    protected void GridView_CraftMgt_RowCommand(object sender, GridViewCommandEventArgs e)//工艺路线链接按钮事件
    {
        if (e.CommandName == "Delete_CraftMgt") //删除工艺路线所属工序
        {
            //无关信息隐藏 
            Panel_Craft.Visible = false;
            UpdatePanel_Craft.Update();

            GridView_CraftMgt.SelectedIndex = -1;
            GridView_CraftMgt.EditIndex = -1;


            string prdid = e.CommandArgument.ToString();
            cminfo.PRD_ID = new Guid(prdid);
            cmpr.D_ProcessRoute_PRDetail(cminfo);
            GridView_CraftMgt.DataSource = cmpr.S_ProcessRoute_PRDetail(new Guid(Label_PRID.Text));
            GridView_CraftMgt.DataBind();
            UpdatePanel_CraftMgt.Update();
            DataSet ds3 = cmpr.S_ProcessRoute_PRDetail(new Guid(Label_PRID.Text));
            DataTable dt3 = ds3.Tables[0];
            if (dt3.Rows.Count != 0)
            {
                Button_copy.Attributes.Add("OnClick", "return confirm('工艺路线中已存在部分工序，是否仍然复制插入?')");

            }
            else
            {
                Button_copy.Attributes.Remove("OnClick");
                Button_copy.Attributes.Add("OnClick", "return confirm('工艺路线中尚无工序，将会复制所选工艺路线中的工序，确定吗?')");
            }

        }

    }
    protected void GridView_CraftMgt_Editing(object sender, GridViewEditEventArgs e)//显示编辑工序管理列表状态
    {
        GridView_CraftMgt.EditIndex = e.NewEditIndex;

        //无关信息隐藏 
        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();



        GridView_CraftMgt.DataSource = cmpr.S_ProcessRoute_PRDetail(new Guid(Label_PRID.Text));
        GridView_CraftMgt.DataBind();
        UpdatePanel_CraftMgt.Update();
    }
    protected void GridView_CraftMgt_Updating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            cminfo.PRD_ID = new Guid(GridView_CraftMgt.DataKeys[e.RowIndex].Values["PRD_ID"].ToString());
            //string a = GridView_CraftMgt.Rows[e.RowIndex].Cells[2].Text.Trim().ToString();
            //string b = GridView_CraftMgt.Rows[e.RowIndex].Cells[4].Text.Trim().ToString();
            //string c = GridView_CraftMgt.Rows[e.RowIndex].Cells[1].Text.Trim().ToString();
            cminfo.PRD_Order = Convert.ToInt16(((TextBox)(GridView_CraftMgt.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
            cminfo.PRD_Note = ((TextBox)(GridView_CraftMgt.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString();
            cminfo.PRD_Doc = ((TextBox)(GridView_CraftMgt.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString();
            cminfo.PRD_Way = ((TextBox)(GridView_CraftMgt.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim().ToString();
            cmpr.U_ProcessRoute_PRDetail(cminfo);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('排序必须是整数！')", true);
            return;
        }
        GridView_CraftMgt.SelectedIndex = -1;
        GridView_CraftMgt.EditIndex = -1;
        GridView_CraftMgt.DataSource = cmpr.S_ProcessRoute_PRDetail(new Guid(Label_PRID.Text));
        GridView_CraftMgt.DataBind();
        UpdatePanel_CraftMgt.Update();

    }
    protected void GridView_CraftMgt_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_CraftMgt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {

            for (int i = 2; i <= 2; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "3");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");
            }
            ((TextBox)e.Row.Cells[4].Controls[0]).Attributes.Add("MaxLength", "25");
            ((TextBox)e.Row.Cells[5].Controls[0]).Attributes.Add("MaxLength", "25");
            ((TextBox)e.Row.Cells[6].Controls[0]).Attributes.Add("MaxLength", "200");
        }
    }
    #endregion

    #region
    protected void GridView_Craft_PageIndexChanging(object sender, GridViewPageEventArgs e)//工序表分页
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Craft.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Craft.PageCount ? GridView_Craft.PageCount - 1 : newPageIndex;
        GridView_Craft.PageIndex = newPageIndex;
        GridView_Craft.PageIndex = newPageIndex;
        GridView_Craft.DataSource = cmpr.S_ProcessRoute_PBCraftInfo(new Guid(Label_PRID.Text));
        GridView_Craft.DataBind();
        GridView_Craft.SelectedIndex = -1;

    }
    protected void GridView_Craft_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    #endregion
    protected void Btn_CloseCraftMgt_Click(object sender, EventArgs e)//关闭工序管理列表
    {//无关信息隐藏

        Panel_CraftMgt.Visible = false;
        Panel_Craft.Visible = false;
        GridView_CraftMgt.EditIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;
        GridView_PR.EditIndex = -1;
        GridView_PR.SelectedIndex = -1;

        UpdatePanel_CraftMgt.Update();
        UpdatePanel_Craft.Update();

    }
    protected void Btn_CloseCraft_Click(object sender, EventArgs e)//关闭工序列表
    {

        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();
    }
    protected void Cbx2_SelectAll_CheckedChanged(object sender, EventArgs e)//全选按钮
    {
        for (int i = 0; i <= GridView_Craft.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView_Craft.Rows[i].FindControl("CheckBox2");
            if (Cbx2_SelectAll.Checked)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
        UpdatePanel_Craft.Update();
    }

    protected void Btn_AddPR_Click(object sender, EventArgs e)//新增工艺路线
    {
        label_AddOrEdit.Text = "新增";
        TextBox_AddOrEditPRName.Text = "";
        DropDownList_Special.SelectedValue = "否";
        Label_PRName.Text = "";
        Panel_AddOrEditPR.Visible = true;
        UpdatePanel_AddOrEditPR.Update();


        Panel_CraftMgt.Visible = false;

        Panel_Craft.Visible = false;
        GridView_Craft.SelectedIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;
        GridView_PR.SelectedIndex = -1;
        UpdatePanel_Craft.Update();
        UpdatePanel_CraftMgt.Update();

    }
    protected void Button_CancelPR_Click(object sender, EventArgs e)//取消新增或编辑工艺路线
    {
        Panel_AddOrEditPR.Visible = false;
        UpdatePanel_AddOrEditPR.Update();
    }
    protected void Button_Submit_PR_Click(object sender, EventArgs e)
    {
        if (TextBox_AddOrEditPRName.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('工艺路线名称不能为空！')", true);
            return;

        }
        if (label_AddOrEdit.Text == "新增")
        {

            DataSet ds = cmpr.S_ProcessRoute(new Guid(label_cdaid.Text));
            DataRow[] rows = ds.Tables[0].Select("PR_Name='" + TextBox_AddOrEditPRName.Text + "'");
            if (rows.Length > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已存在该工艺路线名称！请重新填写')", true);
                return;
            }
            cminfo.CDA_ID = new Guid(label_cdaid.Text);
            cminfo.PR_Special = DropDownList_Special.SelectedItem.Text;
            cminfo.PR_WritePeople = Session["UserName"].ToString();
            cminfo.PR_Name = TextBox_AddOrEditPRName.Text;
            cmpr.I_ProcessRoute(cminfo);
            Panel_AddOrEditPR.Visible = false;
            UpdatePanel_AddOrEditPR.Update();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            GridView_PR.DataSource = cmpr.S_ProcessRoute(new Guid(label_cdaid.Text));
            GridView_PR.DataBind();
            UpdatePanel_PR.Update();
        }
        if (label_AddOrEdit.Text == "编辑")
        {
            DataSet ds = cmpr.S_ProcessRoute(new Guid(label_cdaid.Text));
            DataRow[] rows = ds.Tables[0].Select("PR_Name='" + TextBox_AddOrEditPRName.Text + "'");
            if (rows.Length > 0 && TextBox_AddOrEditPRName.Text != Label_PRName.Text)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已存在该工艺路线名称！请重新填写')", true);
                return;
            }

            cminfo.PR_ID = new Guid(Label_PRID.Text);
            cminfo.PR_Special = DropDownList_Special.SelectedItem.Text;
            cminfo.PR_WritePeople = Session["UserName"].ToString();
            cminfo.PR_Name = TextBox_AddOrEditPRName.Text;
            cmpr.U_ProcessRoute(cminfo);
            Panel_AddOrEditPR.Visible = false;
            UpdatePanel_AddOrEditPR.Update();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
            GridView_PR.DataSource = cmpr.S_ProcessRoute(new Guid(label_cdaid.Text));
            GridView_PR.DataBind();
            UpdatePanel_PR.Update();
        }
    }
    protected void Btn_AddCraft_Click(object sender, EventArgs e)//新增工序按钮事件
    {
        Panel_Craft.Visible = true;

        GridView_Craft.DataSource = cmpr.S_ProcessRoute_PBCraftInfo(new Guid(Label_PRID.Text));
        GridView_Craft.DataBind();
        UpdatePanel_Craft.Update();

        //无关信息隐藏
        // this.Panel_PR.Visible = false;
        Panel_AddOrEditPR.Visible = false;
        // this.Panel_CraftMgt.Visible = false;
        //this.Panel_Craft.Visible = false;
        //  UpdatePanel_PR.Update();
        UpdatePanel_AddOrEditPR.Update();
        //    UpdatePanel_CraftMgt.Update();
        //  UpdatePanel_Craft.Update();
        GridView_Craft.SelectedIndex = -1;
        GridView_CraftMgt.SelectedIndex = -1;

    }
    protected void GridView_CraftMgt_DataBound(object sender, EventArgs e)//工序管理表鼠标悬停
    {
        for (int i = 0; i < GridView_CraftMgt.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_CraftMgt.Rows[i].Cells.Count; j++)
            {
                GridView_CraftMgt.Rows[i].Cells[j].ToolTip = GridView_CraftMgt.Rows[i].Cells[j].Text;
                if (GridView_CraftMgt.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_CraftMgt.Rows[i].Cells[j].Text = GridView_CraftMgt.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_Craft_DataBound(object sender, EventArgs e)//工序表鼠标悬停
    {
        for (int i = 0; i < GridView_Craft.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Craft.Rows[i].Cells.Count; j++)
            {
                GridView_Craft.Rows[i].Cells[j].ToolTip = GridView_Craft.Rows[i].Cells[j].Text;
                if (GridView_Craft.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Craft.Rows[i].Cells[j].Text = GridView_Craft.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_PR_DataBound(object sender, EventArgs e)//工艺路线表鼠标悬停
    {
        for (int i = 0; i < GridView_PR.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_PR.Rows[i].Cells.Count; j++)
            {
                GridView_PR.Rows[i].Cells[j].ToolTip = GridView_PR.Rows[i].Cells[j].Text;
                if (GridView_PR.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_PR.Rows[i].Cells[j].Text = GridView_PR.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void GridView_Doc_DataBound(object sender, EventArgs e)//工艺路线文件鼠标悬停
    {
        for (int i = 0; i < GridView_Doc.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Doc.Rows[i].Cells.Count; j++)
            {
                GridView_Doc.Rows[i].Cells[j].ToolTip = GridView_Doc.Rows[i].Cells[j].Text;
                if (GridView_Doc.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_Doc.Rows[i].Cells[j].Text = GridView_Doc.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void Btn_copy_Click(object sender, EventArgs e)
    {
        //string script = "if(confirm('该工艺路线已有部分工序信息了，是否还继续复制插入？')) {document.getElementById('Button2').click();} else {return;}";
        Guid prid1 = new Guid(DropDownList1.SelectedValue.ToString().Trim());
        Guid prid2 = new Guid(Label_PRID.Text.Trim());
        try
        {
            if (DropDownList1.SelectedValue.ToString().Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('尚未选择工艺路线或选择的工艺路线为空，不能复制，请核对！')", true);
                return;
            }
            else
            {



                //if (dt3.Rows.Count != 0)
                //{
                //    // string reference = ClientScript.GetCallbackEventReference(this, "args", "sucess", "", "Error", false);
                //    // string callbackScript="function CallServerMethod(args,context){\n"+reference+";\n"
                //    // string msg = "该工艺路线中已有部分工序，是否继续复制插入？";
                //    // ClientScript.RegisterStartupScript(this.GetType(), "CallServerMethod", callbackScript);
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "confirm", " <script language='javascript' >if(confirm('确认码?'))document.getElementById('Hf').value='1'; else document.getElementById('Hf').value='0'; </script>", true);
                //    ClientScript.RegisterStartupScript(this.GetType(), "confirm", " return if(confirm('确认码?')) document.getElementById('hf').value='1'; else document.getElementById('hf').value='0';");
                //    if (hf.Value.Equals("1"))
                //    {
                //        cmpr.I_CopyPRDetail(prid1, prid2);


                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('复制成功！')", true);
                //        this.hf.Value = "";
                //        return;
                //    }
                //    if (hf.Value.Equals("0"))
                //    {
                //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('已取消复制！')", true);

                //        return;
                //    }

                //}
                //else
                //{
                cmpr.I_CopyPRDetail(prid1, prid2);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('复制成功！')", true);
                //}
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('复制失败！')", true);
            return;
        }

        GridView_CraftMgt.DataSource = cmpr.S_ProcessRoute_PRDetail(prid2);
        GridView_CraftMgt.DataBind();
        DataSet ds3 = cmpr.S_ProcessRoute_PRDetail(prid2);
        DataTable dt3 = ds3.Tables[0];
        if (dt3.Rows.Count != 0)
        {
            Button_copy.Attributes.Add("OnClick", "return confirm('工艺路线中已存在部分工序，是否仍然复制插入?')");

        }
        else
        {

            Button_copy.Attributes.Remove("OnClick");
            Button_copy.Attributes.Add("OnClick", "return confirm('工艺路线中尚无工序，将会复制所选工艺路线中的工序，确定吗?')");

        }
        UpdatePanel_CraftMgt.Update();
    }

}