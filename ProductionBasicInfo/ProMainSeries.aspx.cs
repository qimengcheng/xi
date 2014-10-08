using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProductionBasicInfo_ProMainSeries : Page
{
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
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
                Title = "产品大型号查看";
                GridView_WOmain.Columns[2].Visible = false;
                GridView_WOmain.Columns[3].Visible = false;
                Button_AddTeam.Visible = false;
                Button_ChosePT.Visible = false;
                GridView_LPT.Columns[0].Visible = false;
                CheckBoxAll.Visible = false;
                CheckBoxfanxuan.Visible = false;
                Btn_deleting.Visible = false;
            }
            if (state.Trim() == "manage")
            {
                Title = "产品大型号管理";
            }

            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("产品大型号管理")) || (Session["UserRole"].ToString().Contains("产品大型号查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("产品大型号管理"))
                    {

                      //  this.Title = "产品大型号查看";
                        GridView_WOmain.Columns[2].Visible = false;
                        GridView_WOmain.Columns[3].Visible = false;
                        Button_AddTeam.Visible = false;
                        Button_ChosePT.Visible = false;
                        GridView_LPT.Columns[0].Visible = false;
                        CheckBoxAll.Visible = false;
                        CheckBoxfanxuan.Visible = false;
                        Btn_deleting.Visible = false;

                    }
                    if (Session["UserRole"].ToString().Contains("产品大型号管理"))
                    {
                       // this.Title = "产品大型号管理";
                    }
                    databind1();
                    GridView_WOmain.SelectedIndex = -1;
                    GridView_WOmain.EditIndex = -1;
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
        string PMS_Name = TextBox_Teamname.Text.Trim() == "" ? " and 1=1 " : " and PMS_Name like '%" + TextBox_Teamname.Text.Trim() + "%' ";
        condition = PMS_Name;
        GridView_WOmain.DataSource = ppl.S_ProMainSeries(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }

    public void databind2()
    {


        GridView_LPT.DataSource = ppl.S_ProMainSeries_Protype(" and PMS_ID='" + label_SID.Text.Trim() + "'");
        GridView_LPT.DataBind();
        UpdatePanel_pt.Update();

    }
    public void databind3()
    {

        string condition;
        string ptsname = TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + TextBox_Series.Text.Trim() + "%' ";
        string ptname = TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_ProductName.Text.Trim() + "%' ";
        condition = ptsname + ptname;
        GridView_ProType.DataSource = ppl.S_Protype_ProMainSeries(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();

    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        databind1();
        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;

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
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
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
                    ppl.U_Protype_ProMainSeries(new Guid(label_SID.Text.Trim()), new Guid(GridView_ProType.DataKeys[i].Values["PT_ID"].ToString().Trim()));
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
        TextBox_ProductName.Text = "";
        TextBox_Series.Text = "";
        databind2();
        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void SelectProType(object sender, EventArgs e)
    {
        databind3();
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
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
        for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
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
    protected void Btn_CloseS_Click(object sender, EventArgs e)
    {
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    ppl.D_Protype_ProMainSeries(new Guid(GridView_LPT.DataKeys[i].Values["PT_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的产品型号！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }

        databind2();
        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Button_ADD_Click(object sender, EventArgs e)
    {
        if (TextBox_wtname_Add.Text.Trim() == "")
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('产品大型号名称不能为空！，请您再核对！')", true);
            return;
        }
        DataSet ds = ppl.S_ProMainSeries(" and PMS_Name='" + TextBox_wtname_Add.Text.Trim() + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该产品大型号！，请您再核对！')", true);
            return;
        }
        else
        {
            try
            {
                ppl.I_ProMainSeries(TextBox_wtname_Add.Text.Trim());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                databind1();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！，请您再核对！')", true);
                return;
            }
        }
    }
    protected void Button_CancelAdd_Click(object sender, EventArgs e)
    {
        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
    }
    protected void Button_AddTeam_Click(object sender, EventArgs e)
    {
        Panel_add.Visible = true;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        TextBox_Teamname.Text = "";
        databind1();

        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_WOmain.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_WOmain.PageCount ? GridView_WOmain.PageCount - 1 : newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;
        databind1();

        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void GridView_WOmain_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_WOmain.EditIndex = -1;
        GridView_WOmain.SelectedIndex = -1;
        databind1();
        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete12")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                ppl.D_ProMainSeries(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            databind1();
            Panel_add.Visible = false;
            TextBox_wtname_Add.Text = "";
            UpdatePanel_add.Update();
            Panel_pt.Visible = false;
            UpdatePanel_pt.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            CheckBoxAll.Checked = false;
            CheckBoxfanxuan.Checked = false;
            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;
        }

        if (e.CommandName == "membermgt")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_S.Text = al[1];
            label_SID.Text = al[0];

            databind2();
            Panel_add.Visible = false;
            TextBox_wtname_Add.Text = "";
            UpdatePanel_add.Update();
            Panel_pt.Visible = true;
            UpdatePanel_pt.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            CheckBoxAll.Checked = false;
            CheckBoxfanxuan.Checked = false;
            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;





        }
    }
    protected void GridView_WOmain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        label_Sname.Text = GridView_WOmain.Rows[e.NewEditIndex].Cells[1].Text.Trim();
        GridView_WOmain.EditIndex = e.NewEditIndex;
        GridView_WOmain.SelectedIndex = e.NewEditIndex;
        databind1();
        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = false;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void GridView_WOmain_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name = ((TextBox)(GridView_WOmain.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();


        if (name != label_Sname.Text.Trim())
        {
            DataSet ds = ppl.S_ProMainSeries(" and PMS_Name='" + name + "'");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该产品大型号！，请您再核对！')", true);
                return;
            }
            else
            {
                try
                {
                    Guid guid = new Guid(GridView_WOmain.DataKeys[e.RowIndex].Value.ToString());
                    ppl.U_ProMainSeries(guid, name);
                    //   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑失败！，请您再核对！')", true);
                    return;
                }
            }


        }

        GridView_WOmain.EditIndex = -1;
        GridView_WOmain.SelectedIndex = -1;
        databind1();
    }
    protected void GridView_LPT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_LPT.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_LPT.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_LPT.PageCount ? GridView_LPT.PageCount - 1 : newPageIndex;
        GridView_LPT.PageIndex = newPageIndex;
        GridView_LPT.PageIndex = newPageIndex;

        databind2();
        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
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


        databind3();
    }
    protected void Button_ChosePT_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        databind3();

        Panel_add.Visible = false;
        TextBox_wtname_Add.Text = "";
        UpdatePanel_add.Update();
        Panel_pt.Visible = true;
        UpdatePanel_pt.Update();
        Panel_Product.Visible = true;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        databind3();
    }
}