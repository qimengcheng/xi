using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Capacity_CapacityBasic : Page
{
    CapacityBasicL csl = new CapacityBasicL();
    ErrorRelevantL erl = new ErrorRelevantL();
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                LbCanBeUsedItem.Attributes.Add("onClick", "listboxSelect()");//为listbox注册客户端单击事件

                try
                {
                    if (!((Session["UserRole"].ToString().Contains("产能核定基础信息维护")) || (Session["UserRole"].ToString().Contains("产能核定基础信息查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                        Response.Redirect("~/Default.aspx");
                    }
                    label_pagestate.Text = Request.QueryString["state"];
                    string state = label_pagestate.Text;
                    if (Session["UserRole"].ToString().Contains("产能核定基础信息查看") && state.Trim() == "look")
                    {
                        Title = "产能核定基础信息查看";
                        GridView_CS.Columns[2].Visible = false;
                        GridView_CS.Columns[3].Visible = false;
                        Button_AddCS.Visible = false;
                        Button_AddPT.Visible = false;
                        GridView_PT.Columns[2].Visible = false;

                        GridView_Basic.Columns[5].Visible = false;
                        GridView_Basic.Columns[6].Visible = false;
                        Button_AddBasic.Visible = false;

                    }
                    if (Session["UserRole"].ToString().Contains("产能核定基础信息维护") && state.Trim() == "manage")
                    {
                        Title = "产能核定基础信息维护";
                    }
                    label_GridPageState.Text = "默认数据源";
                    string condition = " and 1=1";
                    GridView_CS.DataSource = csl.S_CSName(condition);
                    GridView_CS.DataBind();
                    UpdatePanel_CS.Update();
                    GridView_CS.SelectedIndex = -1;

                    // GridView_Detail.EditIndex = -1;
                    //各种pannel隐藏
                    Panel_Add.Visible = false;
                    UpdatePanel_Add.Update();
                    Panel_PT.Visible = false;
                    UpdatePanel_PT.Update();
                    Panel_Product.Visible = false;
                    UpdatePanel_Product.Update();
                    Panel_Basic.Visible = false;
                    TextBox_PBC.Text = "";
                    UpdatePanel_Basic.Update();
                    TextBox_PT.Text = "";
                    TextBox_Series.Text = "";
                    TextBox_ProductName.Text = "";
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                    Response.Redirect("~/Default.aspx");
                }
            }
        }


    public void databind1()
    {
        string condition;
        string CSN_Name = TextBox_CS_Search.Text.Trim() == "" ? " and 1=1 " : " and CSN_Name like '%" + TextBox_CS_Search.Text.Trim() + "%' ";
        condition = CSN_Name;
        GridView_CS.DataSource = csl.S_CSName(condition);
        GridView_CS.DataBind();
        UpdatePanel_CS.Update();
    }

    public void databind2()
    {
        string condition;
        string PT_Name = TextBox_PT.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_PT.Text.Trim() + "%' ";
        condition = PT_Name;
        GridView_PT.DataSource = csl.S_CSName_ProType(label_CSN_ID.Text.Trim(), condition);
        GridView_PT.DataBind();
        UpdatePanel_PT.Update();
    }

    public void databind3()
    {
        string condition;
        string PT_Name = TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_ProductName.Text.Trim() + "%' ";
        string PS_Name = TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + TextBox_Series.Text.Trim() + "%' ";

        condition = PT_Name;
        GridView_ProType.DataSource = csl.S_ProTypeForCSName(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    public void databind4()
    {
        string condition;
        string PBC_Name = TextBox_PBC.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_PBC.Text.Trim() + "%' ";
        condition = PBC_Name;
        GridView_Basic.DataSource = csl.S_CSeries(label_CSN_ID3.Text.Trim(), condition);
        GridView_Basic.DataBind();
        UpdatePanel_Basic.Update();
    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        GridView_CS.EditIndex = -1;
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        UpdatePanel_Basic.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        GridView_CS.EditIndex = -1;
        TextBox_CS_Search.Text = "";
        databind1();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        UpdatePanel_Basic.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Button_AddCS_Click(object sender, EventArgs e)
    {
        GridView_CS.EditIndex = -1;
        databind1();
        UpdatePanel_CS.Update();
        Panel_Add.Visible = true;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        UpdatePanel_Basic.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Button_Add_Cancel_Click(object sender, EventArgs e)
    {
        TextBox_CS_Search.Text = "";
        Panel_Add.Visible = false;
    }
    protected void Button_Add_Confirm_Click(object sender, EventArgs e)
    {
        if (TextBox_CS_Add.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string condition = " and CSN_Name='" + TextBox_CS_Add.Text.Trim() + "'";
        DataSet ds = csl.S_CSName(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产能核定系列名称，请您再次核对！')", true);
            return;
        }
        else
        {

            try
            {

                csl.I_CSName(TextBox_CS_Add.Text.Trim());
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！')", true);
                return;
            }

            Panel_Add.Visible = false;
            TextBox_CS_Add.Text = "";
            TextBox_CS_Search.Text = "";
            databind1();


        }

    }

    protected void GridView_CS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
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
        databind1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_CS.PageCount ? GridView_CS.PageCount - 1 : newPageIndex;
        GridView_CS.SelectedIndex = -1;
        GridView_CS.EditIndex = -1;
        GridView_CS.PageIndex = newPageIndex;
        databind1();
        //各种pannel隐藏
        TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Basic.Visible = false;
        TextBox_PBC.Text = "";
        UpdatePanel_Basic.Update();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void GridView_CS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete123")//
        {
            GridView_CS.EditIndex = -1;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            // GridView_WOmain.SelectedIndex = row.RowIndex;

            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                csl.D_CSName(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            //panel 各种隐藏
            TextBox_PT.Text = "";
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            Panel_Basic.Visible = false;
            TextBox_PBC.Text = "";
            UpdatePanel_Basic.Update();
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PT.Visible = false;
            UpdatePanel_PT.Update();
            databind1();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }

        if (e.CommandName == "CapacityPT")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CS.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_CSN_ID.Text = al[0].Trim();
            label_CSN_Name2.Text = al[1].Trim();
            databind2();
            GridView_PT.SelectedIndex = -1;
            GridView_PT.EditIndex = -1;
            //panel 各种隐藏
            Panel_Basic.Visible = false;
            TextBox_PBC.Text = "";
            UpdatePanel_Basic.Update();
            TextBox_PT.Text = "";
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PT.Visible = true;
            UpdatePanel_PT.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            GridView_CS.EditIndex = -1;
            databind1();
            UpdatePanel_CS.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }


        if (e.CommandName == "CapacityUnit")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CS.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_CSN_ID3.Text = al[0].Trim();
            label_CSN_Name3.Text = al[1].Trim();
            Panel_Basic.Visible = true;
            databind4();
            GridView_Basic.SelectedIndex = -1;
            GridView_Basic.EditIndex = -1;
            //panel 各种隐藏
            TextBox_PT.Text = "";
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PT.Visible = false;
            UpdatePanel_PT.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            GridView_CS.EditIndex = -1;
            databind1();
            UpdatePanel_CS.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }
    }

    protected void GridView_CS_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_CS.EditIndex = e.NewEditIndex;
        databind1();
        label_CSN_Name.Text = GridView_CS.DataKeys[e.NewEditIndex].Values["CSN_Name"].ToString();
        //panel 各种隐藏
        TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        TextBox_PBC.Text = "";
        UpdatePanel_Basic.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void GridView_CS_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (((TextBox)(GridView_CS.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim() != label_CSN_Name.Text.Trim())
        {
            string condition = " and CSN_Name='" + ((TextBox)(GridView_CS.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim() + "'";
            DataSet ds = csl.S_CSName(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产能核定系列名称，请您再次核对！')", true);
                //  GridView_CS.SelectedIndex = -1;
                // GridView_CS.EditIndex = -1;
                // return;
            }
            else
            {

                try
                {

                    csl.U_CSName(new Guid(GridView_CS.DataKeys[e.RowIndex].Values["CSN_ID"].ToString().Trim()), ((TextBox)(GridView_CS.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim());
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('应输入日期格式！')", true);
                    return;
                }


            }
        }
        GridView_CS.SelectedIndex = -1;
        GridView_CS.EditIndex = -1;
        //panel 各种隐藏
        TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        databind1();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        TextBox_PBC.Text = "";
        UpdatePanel_Basic.Update();

    }
    protected void GridView_CS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_CS.SelectedIndex = -1;
        GridView_CS.EditIndex = -1;
        databind1();
        //panel 各种隐藏
        TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        TextBox_PBC.Text = "";
        UpdatePanel_Basic.Update();
    }
    protected void Button_SearchPT_Click(object sender, EventArgs e)
    {
        databind2();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_ResetPT_Click(object sender, EventArgs e)
    {
        TextBox_PT.Text = "";
        databind2();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_AddPT_Click(object sender, EventArgs e)
    {
        Panel_Product.Visible = true;
        databind3();
    }
    protected void GridView_PT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_PT.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_PT.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_PT.PageCount ? GridView_PT.PageCount - 1 : newPageIndex;
        GridView_PT.PageIndex = newPageIndex;
        GridView_PT.PageIndex = newPageIndex;

        databind2();
        GridView_PT.SelectedIndex = -1;
        GridView_PT.EditIndex = -1;
        //各种pannel隐藏
        //  TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        TextBox_PBC.Text = "";
        UpdatePanel_Basic.Update();
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

    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_ProType.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
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

        databind3();
        GridView_ProType.SelectedIndex = -1;
        GridView_ProType.EditIndex = -1;
        //各种pannel隐藏

        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = true;
        UpdatePanel_Product.Update();
        Panel_Basic.Visible = false;
        TextBox_PBC.Text = "";
        UpdatePanel_Basic.Update();
    }
    protected void Button_ClosePT_Click(object sender, EventArgs e)
    {
        TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

    }
    protected void Button_SearchProduct_Click(object sender, EventArgs e)
    {
        databind3();
    }
    protected void Button_CloseProduct_Click(object sender, EventArgs e)
    {
        //  TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        //   Panel_PT.Visible = false;
        //  UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
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
                    csl.I_CSName_ProType(new Guid(label_CSN_ID.Text.Trim()), new Guid(GridView_ProType.DataKeys[i].Values["PT_ID"].ToString().Trim()));
                    //  ws.I_LaborCostSeries_ProType(new Guid(GridView_ProType.DataKeys[i].Values["PT_ID"].ToString().Trim()), new Guid(label_SID.Text.Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的产品型号！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);


        }
        TextBox_PT.Text = "";
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";

        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = true;
        databind2();
        databind3();

        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;


        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void GridView_PT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeletePT")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            // GridView_WOmain.SelectedIndex = row.RowIndex;

            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                csl.D_CSName_ProType(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            //panel 各种隐藏
            TextBox_PT.Text = "";
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PT.Visible = true;
            UpdatePanel_PT.Update();
            databind2();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel_Basic.Visible = false;
            TextBox_PBC.Text = "";
            UpdatePanel_Basic.Update();
        }
    }
    protected void Button_ResetProduct_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        databind3();
    }
    protected void Button_CloseBasic_Click(object sender, EventArgs e)
    {
        TextBox_PBC.Text = "";
        Panel_Basic.Visible = false;
        UpdatePanel_Basic.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Button_BasicSearch_Click(object sender, EventArgs e)
    {
        databind4();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Button_Basic_Reset_Click(object sender, EventArgs e)
    {
        TextBox_PBC.Text = "";
        databind4();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void GridView_Basic_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Basic.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Basic.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Basic.PageCount ? GridView_Basic.PageCount - 1 : newPageIndex;
        GridView_Basic.PageIndex = newPageIndex;
        GridView_Basic.PageIndex = newPageIndex;
        Panel_Basic.Visible = true;
        databind4();
        GridView_Basic.SelectedIndex = -1;
        GridView_Basic.EditIndex = -1;
        //各种pannel隐藏

        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        UpdatePanel_Basic.Update();
    }
    protected void GridView_Basic_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Basic")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            // GridView_WOmain.SelectedIndex = row.RowIndex;

            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                csl.D_CSeries(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            //panel 各种隐藏
            TextBox_PT.Text = "";
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            Panel_Basic.Visible = true;
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_PT.Visible = false;
            UpdatePanel_PT.Update();
            databind4();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();

            //   TextBox_PBC.Text = "";
            UpdatePanel_Basic.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }

        if (e.CommandName == "Edit_Basic")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Basic.SelectedIndex = row.RowIndex;

            DropDownList_PBC.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList_PBC.DataTextField = "PBC_Name";
            DropDownList_PBC.DataValueField = "PBC_ID";
            DropDownList_PBC.DataBind();
            string[] al = e.CommandArgument.ToString().Split(new char[] { '?' });
            DropDownList_PBC.SelectedItem.Text = al[1];
            DropDownList_PBC.Enabled = false;
            Label_ID.Text = al[0];
            TextBox1.Text = al[2];
            TextBox2.Text = al[3];
            TxtFormulaEdit.Text = al[4];
            LabelAddOrEdit.Text = "编辑";
            Panel1.Visible = true;
            UpdatePanel1.Update();
        }
    }
    protected void Button_AddBaiscInfo_Click(object sender, EventArgs e)
    {
        if (DropDownList_PBC.Text == "" || TextBox1.Text == "" || TextBox2.Text == "" || TxtFormulaEdit.Text=="")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (LabelAddOrEdit.Text == "新增")
        {
            if (LblRecordIsCheckOK.Text != "true" )//保证提交的时候一定经过了公式校验
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先校验公式，且格式正确才能进行提交！')", true);
                return;
            }
            string condition = " and a.PBC_ID='" + DropDownList_PBC.SelectedValue.ToString().Trim() + "'";
            DataSet ds = csl.S_CSeries(label_CSN_ID3.Text.Trim(),condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该工序的产能核定基础信息，请您再次核对！')", true);
                return;
            }
            else
            {
                try
                {
                    int n3 = TextBox1.Text.Trim() == "" ? 0 : Convert.ToInt32(TextBox1.Text.Trim());
                    int n4 = TextBox2.Text.Trim() == "" ? 0 : Convert.ToInt32(TextBox2.Text.Trim());
                    string CS_Formulate = TxtFormulaEdit.Text;
                    csl.I_CSeries(new Guid(label_CSN_ID3.Text.Trim()), new Guid(DropDownList_PBC.SelectedValue.ToString().Trim()), n3, n4, CS_Formulate);

                }
                catch (Exception)
                {

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert(“新增失败！，请您再核对单位产能输入的是整数形式！')", true);

                    return;
                }
            }
        }
        if (LabelAddOrEdit.Text == "编辑")
        {
            if (LblRecordIsCheckOK.Text != "true")//保证提交的时候一定经过了公式校验
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先校验公式，且格式正确才能进行提交！')", true);
                return;
            }
            try
            {
                int n1 = TextBox1.Text.Trim() == "" ? 0 : Convert.ToInt32(TextBox1.Text.Trim());
                int n2 = TextBox2.Text.Trim() == "" ? 0 : Convert.ToInt32(TextBox2.Text.Trim());
                string CS_Formulate = TxtFormulaEdit.Text;
                csl.U_CSeries(new Guid(Label_ID.Text.Trim()), n1, n2, CS_Formulate);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert(“新增失败！，请您再核对单位产能输入的是整数形式！')", true);
                return;
            }
        }
            DropDownList_PBC.SelectedIndex = 0;
            TextBox1.Text = "";
            TextBox2.Text = "";
            Panel1.Visible = false;
            UpdatePanel1.Update();
            databind4();
    }
    protected void Button_CloseBasicInfo_Click(object sender, EventArgs e)
    {
        DropDownList_PBC.SelectedIndex = 0;
        TextBox1.Text = "";
        TextBox2.Text = "";
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }

    protected void Button_AddBasic_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TxtFormulaEdit.Text = "";
        LabelAddOrEdit.Text = "新增";
        DropDownList_PBC.DataSource = csl.S_PBCraft_Capacity(new Guid(label_CSN_ID3.Text.Trim()));
        DropDownList_PBC.DataTextField = "PBC_Name";
        DropDownList_PBC.DataValueField = "PBC_ID";
        DropDownList_PBC.DataBind();
        DropDownList_PBC.SelectedIndex = 0;
        label_CSN_Name_ADD.Text = label_CSN_Name3.Text;
        DropDownList_PBC.Enabled = true;
        Panel1.Visible = true;
        UpdatePanel1.Update();
    }

    #region //公式编辑器
    private int GetCountByChar(string str1, char ch)
    {
        int count = 0;
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] == ch)
            {
                count++;
            }
        }
        return count;
    }//自定义根据字符str1查找字符ch出现的次数，返回次数count

    protected void Button2_Click(object sender, EventArgs e)//校验公式按钮
    {
        //基本格式的验证（但是存在某些特殊情况，使得错误的公式能逃过公式合法性的验证，此称为罪犯）
        //if (TxtFormulaEdit.Text == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('格式错误：请录入公式')", true);
        //    return;
        //}
        string target = TxtFormulaEdit.Text;

        //string[] Array = target.Split(new char[6] { '/', '*', '-', '+', '(', ')' });
        string[] Array = target.Split(new char[7] { '/', '*', '-', '+', '(', ')', ',' });
        foreach (string item1 in Array)
        {
            decimal d;//判断是否有运算项为0
            if (decimal.TryParse(item1, out d))
            {
                if (d == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误（0不能作为单独的运算项）！')", true);
                    LblRecordIsCheckOK.Text = "false";
                    return;
                }
            }
            decimal k;//判断是否全是合法的可选字段（但前台设定为不可编辑状态，因此这类情况一般不会发生）
            //if (!(decimal.TryParse(item1, out k)) && item1 != "")
            if (!(decimal.TryParse(item1, out k)) && item1 != "" && item1.ToString() != "Max" && item1.ToString() != "Min" && item1.ToString() != "Sum" && item1.ToString() != "Avg")
            {
                if (!LbCanBeUsedItem.Items.Contains(LbCanBeUsedItem.Items.FindByText(item1)))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误（有非法字段）！')", true);
                    LblRecordIsCheckOK.Text = "false";
                    return;
                }
            }
        }

        if (target.Contains("."))//如果有小数点，则小数点一定要是decimal的组成部分
        {
            foreach (string item in Array)
            {
                if (item != "")
                {
                    if (!LbCanBeUsedItem.Items.Contains(LbCanBeUsedItem.Items.FindByText(item)))
                    {
                        decimal m;
                        if (!decimal.TryParse(item, out m))
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！（小数点格式错误）')", true);
                            LblRecordIsCheckOK.Text = "false";
                            return;
                        }
                    }
                }
            }
        }

        if (target.Contains("(") || target.Contains(")"))//有括号时：1、括号要成对出现 2、“（”在“）”之前 3、最后一个“（”和第一个“）”中间有字段
        {
            if (GetCountByChar(target, '(') != GetCountByChar(target, ')'))//如果“（”与“）”出现的次数不相等
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！（括号需要成对出现）')", true);
                LblRecordIsCheckOK.Text = "false";
                return;
            }
            if (target.IndexOf('(') >= target.IndexOf(')'))//“（”在“）”之后
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！（前后括号反向）')", true);
                LblRecordIsCheckOK.Text = "false";
                return;
            }
            if (target.IndexOf(')') - target.LastIndexOf('(') <= 1)//（1+2）（2-4）或者（1+2）3（2-4）这种情况
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！')", true);
                LblRecordIsCheckOK.Text = "false";
                return;
            }
            else
            {
                string st = target.Substring(target.LastIndexOf('('), target.IndexOf(')') - target.LastIndexOf('('));
                string[] Array2 = st.Split(new char[7] { '/', '*', '-', '+', '(', ')', ',' });//再次切割
                foreach (string item in Array2)
                {
                    decimal i;
                    if (!(decimal.TryParse(item, out i)) && item != "")
                    {
                        if (!LbCanBeUsedItem.Items.Contains(LbCanBeUsedItem.Items.FindByText(item)))
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！')", true);
                            LblRecordIsCheckOK.Text = "false";
                            return;
                        }
                    }
                }
            }
        }
        else//没有括号时，运算符不能作为起始和结束符号，并且符号不能紧挨着使用
        {
            string[] Array3 = target.Split(new char[5] { '/', '*', '-', '+',',' });
            if (Array3.Contains(""))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！（运算符格式错误）')", true);
                LblRecordIsCheckOK.Text = "false";
                return;
            }
        }

        //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('" + Array[2] + "')", true);

        string[] Array4 = target.Split(new char[5] { '/', '*', '-', '+', ',' });
        if (Array4.Contains(""))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！（运算符格式错误）')", true);
            LblRecordIsCheckOK.Text = "false";
            return;
        }

        //捕捉罪犯（方法：以现在的公式进行一次计算，能计算出结果，则表示公式正确，否则错误）
        //try
        //{
        //    csl.Update_YanZhengGongShi_Capacity(new Guid(Label_ID.Text), TxtFormulaEdit.Text);
        //}
        //catch (Exception)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('公式错误！请核实：(1)格式有误;(2)分母可能为0')", true);
        //    return;
        //}

        //聚合函数只能用一个，且括号只能有一对（根据现目前的实际情况，暂定如此）
        int j = 0;
        string[] str = { "Max", "Min", "Avg", "Sum" };
        for (int i = 0; i < str.Length; i++)
        {
            if (target.IndexOf(str[i]) != -1)
            {
                j += 1;
                if (j >= 2)//此举是为了保证聚合函数Max，Min，Avg，Sum只会出现一个
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！（运算符格式错误）')", true);
                    LblRecordIsCheckOK.Text = "false";
                    return;
                }
                if (j >= 1)
                {
                    int a = target.LastIndexOf('(');
                    int b = target.IndexOf(str[i]);
                    if (target.LastIndexOf('(') - target.IndexOf(str[i]) >= 4)//括号只能有一对，此举是为了保证存储过程p_calc_Capacity在截断“Max(a,b)”字符串时不会出错
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式错误！（有多余的括号）')", true);
                        LblRecordIsCheckOK.Text = "false";
                        return;
                    }
                }
            }
        }
        
        LblRecordIsCheckOK.Text = "true";
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('格式正确！')", true);
    }

    protected void Button3_Click(object sender, EventArgs e)//重置
    {
        TxtFormulaEdit.Text = "";
    }
    #endregion




}