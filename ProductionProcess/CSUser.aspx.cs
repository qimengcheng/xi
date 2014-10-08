using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductionProcess_CSUser : Page
{
    CSUserD cs = new CSUserD();
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
                Title = "客户端操作员查看";
                GridView1.Columns[0].Visible = false;
                GridView1.Columns[5].Visible = false;
                GridView2.Columns[3].Visible = false;
                CheckBoxAll.Visible = false;
                CheckBoxfanxuan.Visible = false;
                Btn_deleting.Visible = false;
                Btn_AddPT.Visible = false;
                DropDownList1.Visible = false;
                Button_Add.Visible = false;



            }
            if (state == "manage")
            {

                Title = "客户端操作员管理";
            
            }
            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("客户端操作员查看")) || (Session["UserRole"].ToString().Contains("客户端操作员管理"))))
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("客户端操作员管理"))
                    {


                        Title = "客户端操作员查看";
                        GridView1.Columns[0].Visible = false;
                        GridView1.Columns[5].Visible = false;
                        GridView2.Columns[3].Visible = false;
                        CheckBoxAll.Visible = false;
                        CheckBoxfanxuan.Visible = false;
                        Btn_deleting.Visible = false;
                        Btn_AddPT.Visible = false;
                        DropDownList1.Visible = false;
                        Button_Add.Visible = false;

                    }
                    datebind1();
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
    public void datebind1()
    {
        string condition;
        string HRDD_StaffNO = Txt_search.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + Txt_search.Text.Trim() + "%' ";
        string HRDD_Name = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox1.Text.Trim() + "%' ";
        string pbcname = TextBox2.Text.Trim() == "" ? " and 1=1 " : " and pbcname like '%" + TextBox2.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name+pbcname;
        GridView1.DataSource = cs.S_CSUser(condition);
        GridView1.DataBind();
        UpdatePanel_PS.Update();
    }
    public void datebind2()
    {

        GridView2.DataSource = cs.S_CSUser_PBCraftInfo(new Guid(Label_HRDD_ID.Text.Trim()));
        GridView2.DataBind();
        UpdatePanel_PT.Update();
    }
    public void datebind3()
    {
        string condition;
        string HRDD_StaffNO = TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox_Series.Text.Trim() + "%' ";
        string HRDD_Name = TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox_ProductName.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        GridView_ProType.DataSource = cs.S_CSUser_HRDD_Detail(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        datebind1();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        Txt_search.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        datebind1();
        GridView1.PageIndex = 0;
        GridView1.SelectedIndex = -1;

        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
    }
    protected void Button_Add_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Panel_Product.Visible = true;

        GridView_ProType.PageIndex = 0;
        GridView1.PageIndex = 0;
        GridView1.SelectedIndex = 0;
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        datebind3();
        UpdatePanel_PS.Update();
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
                    cs.I_CSUser(new Guid(GridView_ProType.DataKeys[i].Values["HRDD_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的员工！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);


        }
        GridView1.SelectedIndex = -1;
        GridView1.PageIndex = 0;
        datebind1();

        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
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
        datebind3();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        GridView_ProType.SelectedIndex = -1;
    }
    protected void SelectProType(object sender, EventArgs e)
    {
        datebind3();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        datebind3();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete1")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                cs.D_CSUser(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            datebind1();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel_PT.Visible = false;
            UpdatePanel_PT.Update();
            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;

        }

        if (e.CommandName == "CheckProType")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_HRDD_ID.Text = al[0];
            Label_PS.Text = al[1];
            Panel_PT.Visible = true;
            DropDownList1.DataSource = cs.S_CSUser_PBCName(new Guid(al[0].Trim()));
            DropDownList1.DataTextField = "PBC_Name";
            DropDownList1.DataValueField = "PBC_ID";
            DropDownList1.DataBind();
            datebind2();


            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();

            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;





        }
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView1.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView1.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        datebind1();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        GridView1.SelectedIndex = -1;
    }
    protected void Btn_AddPT_Click(object sender, EventArgs e)
    {
        try
        {
            cs.I_CSUser_PBCraftInfo(new Guid(Label_HRDD_ID.Text.Trim()), new Guid(DropDownList1.SelectedValue.ToString()));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！，请您再核对！')", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！，请您再核对！')", true);
            return;
        }
        DropDownList1.DataSource = cs.S_CSUser_PBCName(new Guid(Label_HRDD_ID.Text.Trim()));
        DropDownList1.DataTextField = "PBC_Name";
        DropDownList1.DataValueField = "PBC_ID";
        DropDownList1.DataBind();
        datebind2();
    }
    protected void Button_Close_PT_Click(object sender, EventArgs e)
    {
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        GridView1.SelectedIndex = -1;
        UpdatePanel_PS.Update();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_PT")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                cs.D_CSUser_PBCraftInfo(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }
            DropDownList1.DataSource = cs.S_CSUser_PBCName(new Guid(Label_HRDD_ID.Text.Trim()));
            DropDownList1.DataTextField = "PBC_Name";
            DropDownList1.DataValueField = "PBC_ID";
            DropDownList1.DataBind();
            datebind2();
            
        }

    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {



    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        string link="";
        try
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    
                    sum++;
                    if(sum==1)
                    {
                        link = link + "no" + sum.ToString() + "=" + GridView1.DataKeys[i].Values["HRDD_StaffNO"].ToString().Trim() + "&name" + sum.ToString() + "=" + GridView1.DataKeys[i].Values["HRDD_Name"].ToString().Trim();
                    }
                    if (sum >1)
                    {
                        link = link + "&no" + sum.ToString() + "=" + GridView1.DataKeys[i].Values["HRDD_StaffNO"].ToString().Trim() + "&name" + sum.ToString() + "=" + GridView1.DataKeys[i].Values["HRDD_Name"].ToString().Trim();
                    }
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
        Response.Redirect("./PrintCSUser.aspx?" + link);
       
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
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
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
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
}