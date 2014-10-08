using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Capacity_CapacityInfo : Page
{
    CapacityBasicL csl = new CapacityBasicL();
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
            if (state.Trim() == "look")
            {
                Title = "产能核定查看";
                GridView_CS.Columns[4].Visible = false;
                GridView_CS.Columns[5].Visible = false;
                GridView_CS.Columns[6].Visible = false;
                Button_Add.Visible = false;
                GridView_PBCraftDetail.Columns[12].Visible = false;

            }
            if (state.Trim() == "manage")
            {
                Title = "产能核定维护";
            }
            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("产能核定维护")) || (Session["UserRole"].ToString().Contains("产能核定查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("产能核定维护"))
                    {
                        //this.Title = "产能核定基础信息查看";
                        GridView_CS.Columns[4].Visible = false;
                        GridView_CS.Columns[5].Visible = false;
                        GridView_CS.Columns[6].Visible = false;
                        Button_Add.Visible = false;
                        GridView_PBCraftDetail.Columns[12].Visible = false;

                    }


                    label_GridPageState.Text = "默认数据源";
                    string condition = " and 1=1";
                    GridView_CS.DataSource = csl.S_CapacityInfo(condition);
                    GridView_CS.DataBind();
                    UpdatePanel_CS.Update();
                    GridView_CS.SelectedIndex = -1;
                    //各种pannel隐藏
                    Panel_Add.Visible = false;
                    UpdatePanel_Add.Update();
                    TextBox_Note_Add.Text = "";
                    GridView_CS.EditIndex = -1;
                    GridView_CS.SelectedIndex = -1;
                    Panel_PBC.Visible = false;
                    GridView_PBC.SelectedIndex = -1;
                    Panel_PBCraftDetail.Visible = false;
                    Panel_ResultCheck.Visible = false;
                    UpdatePanel_ResultCheck.Update();
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
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }
    }
    public void databind1()
    {
        string condition;
        string CI_P = TextBox_makepeople.Text.Trim() == "" ? " and 1=1 " : " and CI_P like '%" + TextBox_makepeople.Text.Trim() + "%' ";
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string CI_T = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and CI_T between   ' " + TextBox_WO_Time1.Text.Trim() + "' and ' " + TextBox_WO_Time2.Text.Trim() + "'";


        condition = CI_P + CI_T;
        GridView_CS.DataSource = csl.S_CapacityInfo(condition);
        GridView_CS.DataBind();
        UpdatePanel_CS.Update();
    }
    public void databind2()
    {

        GridView_PBC.DataSource = csl.S_CSeries_PBCraftInfo();
        GridView_PBC.DataBind();
        UpdatePanel_PBC.Update();


    }
    public void databind3()
    {

        GridView_PBCraftDetail.DataSource = csl.S_CapacityDetailInfo("", Label_PBC_ID.Text.Trim(), Label_CI_ID.Text.Trim());
        GridView_PBCraftDetail.DataBind();
        UpdatePanel_PBCraftDetail.Update();


    }
    protected void Button_AddCS_Click(object sender, EventArgs e)
    {
        Panel_Add.Visible = true;
        UpdatePanel_Add.Update();
        GridView_CS.EditIndex = -1;
        GridView_CS.SelectedIndex = -1;
        databind1();
        Panel_PBC.Visible = false;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        GridView_CS.EditIndex = -1;
        GridView_CS.SelectedIndex = -1;
        TextBox_Note_Add.Text = "";
        //各种pannel隐藏
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PBC.Visible = false;
        GridView_PBC.SelectedIndex = -1;
        UpdatePanel_PBC.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        TextBox_makepeople.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        TextBox_Note_Add.Text = "";
        //各种pannel隐藏
        GridView_CS.EditIndex = -1;
        GridView_CS.SelectedIndex = -1;
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PBC.Visible = false;
        GridView_PBC.SelectedIndex = -1;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }
    protected void Button_Add_Confirm_Click(object sender, EventArgs e)
    {
        if (TextBox_Note_Add.Text == "" )
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }

        try
        {

            csl.I_CapacityInfo(Session["UserName"].ToString().Trim(), TextBox_Note_Add.Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！')", true);
            return;
        }

        Panel_Add.Visible = false;
        databind1();



    }
    protected void Button_Add_Cancel_Click(object sender, EventArgs e)
    {
        GridView_CS.EditIndex = -1;
        GridView_CS.SelectedIndex = -1;
        TextBox_Note_Add.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
    }
    protected void GridView_CS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_CS.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_CS.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_CS.PageCount ? GridView_CS.PageCount - 1 : newPageIndex;
        GridView_CS.PageIndex = newPageIndex;
        GridView_CS.PageIndex = newPageIndex;

        databind1();
        GridView_CS.SelectedIndex = -1;
        GridView_CS.EditIndex = -1;
        //各种pannel隐藏
        TextBox_Note_Add.Text = "";
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PBC.Visible = false;
        GridView_PBC.SelectedIndex = -1;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }
    protected void GridView_CS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_CS.SelectedIndex = -1;
        GridView_CS.EditIndex = -1;
        databind1();
        //各种pannel隐藏
        TextBox_Note_Add.Text = "";
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PBC.Visible = false;
        GridView_PBC.SelectedIndex = -1;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }
    protected void GridView_CS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete123")//
        {
            //GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            // GridView_WOmain.SelectedIndex = row.RowIndex;

            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                csl.D_CapacityInfo(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            //各种pannel隐藏
            TextBox_Note_Add.Text = "";
            databind1();
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PBC.Visible = false;
            GridView_PBC.SelectedIndex = -1;
            UpdatePanel_PBC.Update();
            Panel_PBCraftDetail.Visible = false;
            UpdatePanel_PBCraftDetail.Update();
            Panel_ResultCheck.Visible = false;
            UpdatePanel_ResultCheck.Update();
        }

        if (e.CommandName == "Capacitymake")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CS.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_CI_ID.Text = al[0].Trim();
            Label_Date.Text = al[1];
            databind2();

            //各种pannel隐藏
            TextBox_Note_Add.Text = "";
            databind1();
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PBC.Visible = true;
            GridView_PBC.SelectedIndex = -1;
            UpdatePanel_PBC.Update();
            Panel_PBCraftDetail.Visible = false;
            UpdatePanel_PBCraftDetail.Update();
            Panel_ResultCheck.Visible = false;
            UpdatePanel_ResultCheck.Update();
            GridView_CS.EditIndex = -1;
            databind1();
        }
        if (e.CommandName == "Capacitycheck")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CS.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_CIID2.Text = al[0].Trim();
           
            //各种pannel隐藏
            TextBox_Note_Add.Text = "";
            databind1();
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PBC.Visible = false;
            GridView_PBC.SelectedIndex = -1;
            UpdatePanel_PBC.Update();
            Panel_PBCraftDetail.Visible = false;
            UpdatePanel_PBCraftDetail.Update();
            Panel_ResultCheck.Visible = true;
            GridView_ResultCheck.DataSource = csl.S_CapacityDetailInfo_ResultCheck(al[0].Trim());
            GridView_ResultCheck.DataBind();
            UpdatePanel_ResultCheck.Update();
            GridView_CS.EditIndex = -1;
            databind1();
        }
    }
    protected void GridView_CS_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_CS.EditIndex = e.NewEditIndex;
        GridView_CS.SelectedIndex = e.NewEditIndex;
        databind1();
        //各种pannel隐藏
        TextBox_Note_Add.Text = "";
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PBC.Visible = false;
        GridView_PBC.SelectedIndex = -1;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }
    protected void GridView_CS_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            csl.U_CapacityInfo(new Guid(GridView_CS.DataKeys[e.RowIndex].Values["CI_ID"].ToString().Trim()), Session["UserName"].ToString().Trim(), ((TextBox)(GridView_CS.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑失败！')", true);
            return;
        }
        GridView_CS.SelectedIndex = -1;
        GridView_CS.EditIndex = -1;
        //各种pannel隐藏
        TextBox_Note_Add.Text = "";
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PBC.Visible = false;
        GridView_PBC.SelectedIndex = -1;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }

    protected void GridView_PBC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_PBC.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_PBC.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_PBC.PageCount ? GridView_PBC.PageCount - 1 : newPageIndex;
        GridView_PBC.PageIndex = newPageIndex;
        GridView_PBC.PageIndex = newPageIndex;

        databind2();
        //  GridView_CS.SelectedIndex = -1;
        // GridView_CS.EditIndex = -1;
        //各种pannel隐藏
        TextBox_Note_Add.Text = "";
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PBC.Visible = true;
        GridView_PBC.SelectedIndex = -1;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }

    protected void GridView_PBC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CapacityPBC")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_PBC.SelectedIndex = row.RowIndex;

            GridView_PBCraftDetail.EditIndex = -1;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_PBC_ID.Text = al[0].Trim();
            Label_PBC_Name.Text = al[1].Trim();
            databind3();
            Panel_PBCraftDetail.Visible = true;
            //各种pannel隐藏
            TextBox_Note_Add.Text = "";
            databind1();
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PBC.Visible = true;      
            UpdatePanel_PBC.Update();
            Panel_ResultCheck.Visible = false;
            UpdatePanel_ResultCheck.Update();

        }
    }
    protected void Button_ClosePBC_Click(object sender, EventArgs e)
    {
        Panel_PBC.Visible = false;
        UpdatePanel_PBC.Update();
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();
        GridView_PBC.SelectedIndex = -1;
    }
    protected void GridView_PBCraftDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_PBCraftDetail.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_PBCraftDetail.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox33");
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
        newPageIndex = newPageIndex >= GridView_PBCraftDetail.PageCount ? GridView_PBCraftDetail.PageCount - 1 : newPageIndex;
        GridView_PBCraftDetail.PageIndex = newPageIndex;
        GridView_PBCraftDetail.PageIndex = newPageIndex;
        databind3();
        
    }
    protected void GridView_PBCraftDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }
    protected void Button_PBCraftDetail_Click(object sender, EventArgs e)
    {
        Panel_PBCraftDetail.Visible = false;
        UpdatePanel_PBCraftDetail.Update();

    }
     
    protected void GridView_PBCraftDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_PBCraftDetail.EditIndex = -1;
        GridView_PBCraftDetail.SelectedIndex = -1;
        databind3();
    }
    protected void GridView_PBCraftDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_PBCraftDetail.EditIndex = e.NewEditIndex;
        GridView_PBCraftDetail.SelectedIndex = e.NewEditIndex;
        databind3();

    }
    protected void GridView_PBCraftDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string cdiid = GridView_PBCraftDetail.DataKeys[e.RowIndex].Values["CDI_ID"].ToString().Trim();
        string csid = GridView_PBCraftDetail.DataKeys[e.RowIndex].Values["CS_ID"].ToString().Trim();

        Int32 v1;
        if (!(Int32.TryParse(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim(), out v1)))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('机器数只能为整数！')", true);
            return;
        }
        int m = v1;
        decimal v2;
        if (!(decimal.TryParse(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim(), out v2)))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('机器时数只能为两位小数！')", true);
            return;
        }
        decimal mt = v2;
        Int32 v3;
        if (!(Int32.TryParse(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim(), out v3)))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('人工数只能为整数！')", true);
            return;
        }
        int p = v3;
        decimal v4;
        if (!(decimal.TryParse(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[9].Controls[0])).Text.Trim(), out v4)))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('人工时数只能为两位小数！')", true);
            return;
        }
        decimal pt = v4;
        if (cdiid != "")
        {
            try
            {
                //int m = Convert.ToInt32(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim());
                //decimal mt = Convert.ToDecimal(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim());
                //int p = Convert.ToInt32(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim());
                //decimal pt = Convert.ToDecimal(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[9].Controls[0])).Text.Trim());
                csl.U_CapacityDetailInfo(new Guid(cdiid), m, mt, p, pt);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
                return;
            }
        }
        else
        {
            try
            {
                //int m = Convert.ToInt32(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim());
                //decimal mt = Convert.ToDecimal(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim());
                //int p = Convert.ToInt32(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim());
                //decimal pt = Convert.ToDecimal(((TextBox)(GridView_PBCraftDetail.Rows[e.RowIndex].Cells[9].Controls[0])).Text.Trim());
                csl.I_CapacityDetailInfo(new Guid(Label_CI_ID.Text.Trim()),new Guid(csid),m,mt,p,pt);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
                return;
            }
        
        }
        GridView_PBCraftDetail.SelectedIndex = -1;
        GridView_PBCraftDetail.EditIndex = -1;
        databind3();

    }
    protected void GridView_ResultCheck_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_ResultCheck.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_ResultCheck.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox44");
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
        newPageIndex = newPageIndex >= GridView_ResultCheck.PageCount ? GridView_ResultCheck.PageCount - 1 : newPageIndex;
        GridView_ResultCheck.PageIndex = newPageIndex;
        GridView_ResultCheck.PageIndex = newPageIndex;
        GridView_ResultCheck.DataSource = csl.S_CapacityDetailInfo_ResultCheck(Label_CIID2.Text);
        GridView_ResultCheck.DataBind();
        UpdatePanel_ResultCheck.Update();
    }
    protected void Button_1_Click(object sender, EventArgs e)
    {
        Panel_ResultCheck.Visible = false;
        UpdatePanel_ResultCheck.Update();
    }
}
