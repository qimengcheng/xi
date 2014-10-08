using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProductionBasicInfo_PBPTIPS : Page
{
    IPSD ip = new IPSD();
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
                Title = "产品测试参数基础查看";
                Button3.Visible = false;
                GridView1.Columns[2].Visible = false;
                GridView1.Columns[3].Visible = false;
                GridView2.Columns[2].Visible = false;
                GridView2.Columns[3].Visible = false;
                Button5.Visible = false;
               

            }
            if (state == "manage")
            {
                Title = "产品测试参数基础维护";
            }

            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("产品测试参数基础维护")) || (Session["UserRole"].ToString().Contains("产品测试参数基础查看"))))
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("产品测试参数基础维护"))
                    {
                        Title = "产品测试参数基础查看";
                        Button3.Visible = false;
                        GridView1.Columns[2].Visible = false;
                        GridView1.Columns[3].Visible = false;
                        GridView2.Columns[2].Visible = false;
                        GridView2.Columns[3].Visible = false;
                        Button5.Visible = false;
                    }
                    databind1();
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
    public void databind1()
    {
        string condition;
        string IPSM_Type = Txt_search.Text.Trim() == "" ? " and 1=1 " : " and IPSM_Type like '%" + Txt_search.Text.Trim() + "%' ";
        condition = IPSM_Type;
        GridView1.DataSource = ip.S_IPSMain(condition);
        GridView1.DataBind();
        GridView1.SelectedIndex = -1;
        UpdatePanel_PS.Update();

    }
    public void databind2()
    {
        
        GridView2.DataSource = ip.S_IPSDetail(new Guid(Label_MID.Text.Trim()));
        GridView2.DataBind();
        GridView2.SelectedIndex = -1;
        UpdatePanel1.Update();
    }
    public void clear()
    {
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel3.Visible = false;
        UpdatePanel2.Update();

    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        databind1();
        clear();

    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        Txt_search.Text = "";
        databind1();
        clear();

    }
    protected void Button_ADD1_Click(object sender, EventArgs e)
    {
        Panel_AddPS.Visible = true;
        TextBox1.Text = "";
        UpdatePanel_AddPS.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel3.Visible = false;
        UpdatePanel2.Update();
    }
    protected void Btn_confirmAdd1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('测试参数类别不能为空！')", true);
            return;
        }
        DataSet ds = ip.S_IPSMain("");
        DataRow[] rows = ds.Tables[0].Select("IPSM_Type='" + TextBox1.Text.Trim() + "'");
        if (rows.Length > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已存在该测试参数类别！请重新填写')", true);
            return;
        }
        try
        {
            ip.I_IPSMain(TextBox1.Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败')", true);
            return;
        }
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        databind1();

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


        //绑定数据源

        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView1.PageIndex = newPageIndex;

        databind1();
        clear();


    }
    protected void Gridview_PS_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
        databind1();
        clear();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete1")
        {
            try
            {
                // this.Lab_State.Text = "Delete1";
                string id = e.CommandArgument.ToString();
                Guid guid_id = new Guid(id);
                ip.D_IPSMain(guid_id);
                databind1();
                clear();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该测试类别已有详细项目信息或产品型号已引用该测试类别，无法删除，请另外新建！')", true);

            }

        }
        if (e.CommandName == "CheckProType")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string id = al[0];
            Label2.Text = al[1] + " 所属 ";
            Label_MID.Text = id;
            databind2();
            Panel_AddPS.Visible = false;
            UpdatePanel_AddPS.Update();
            Panel1.Visible = true;
            Panel3.Visible = false;
            UpdatePanel2.Update();

          


        }
    }
    protected void Gridview_PS_Editing(object sender, GridViewEditEventArgs e)
    {
        GridView1.SelectedIndex = e.NewEditIndex;
        GridView1.EditIndex = e.NewEditIndex;
        Label3.Text =GridView1.Rows[e.NewEditIndex].Cells[1].Text.Trim();
        databind1();
        clear();
    }
    protected void Gridview_PS_Updating(object sender, GridViewUpdateEventArgs e)
    {
        string type = Convert.ToString(((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        if (Label3.Text.Trim() != type)
        {
            DataSet ds = ip.S_IPSMain("");
            DataRow[] rows = ds.Tables[0].Select("IPSM_Type='" + type + "'");
            if (rows.Length > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已存在该测试参数类别！请重新填写')", true);
                return;
            }
            else
            {
                Guid gid = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
                ip.U_IPSMain(gid, type);
                GridView1.EditIndex = -1;
                GridView1.SelectedIndex = -1; 
                databind1();
               
            }
        }
        else
        {
            GridView1.EditIndex = -1;
            GridView1.SelectedIndex = -1;
            databind1();
        }

    }
    protected void Gridview2_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        GridView2.SelectedIndex = -1;
        databind2();
 
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete1")
        {
            try
            {
                // this.Lab_State.Text = "Delete1";
                string id = e.CommandArgument.ToString();
                Guid guid_id = new Guid(id);
                ip.D_IPSDetail(guid_id);
                databind2();
                Panel_AddPS.Visible = false;
                UpdatePanel_AddPS.Update();
                Panel1.Visible = true;
                UpdatePanel1.Update();
                Panel3.Visible = false;
                UpdatePanel2.Update();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('产品型号可能已引用该测试详细项目，无法删除，请另外新建！')", true);

            }
        }
    }
    protected void Gridview2_Editing(object sender, GridViewEditEventArgs e)
    {
       // GridView2.SelectedIndex = e.NewEditIndex;
        GridView2.EditIndex = e.NewEditIndex;
        Label18.Text = GridView2.Rows[e.NewEditIndex].Cells[1].Text.Trim().ToString();
        //if ((GridView2.Rows[e.NewEditIndex].RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (GridView2.Rows[e.NewEditIndex].RowState == DataControlRowState.Edit))
        //{
        //    TextBox curText;
        //    for (int i = 0; i <= GridView2.Columns.Count; i++)
        //    {

        //        curText = (TextBox)GridView2.Rows[e.NewEditIndex].Cells[i].Controls[0];

        //        curText.Attributes.Add("Width ", "100%");
        //    }
        //}
        databind2();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        Panel1.Visible = true;
        UpdatePanel1.Update();
        Panel3.Visible = false;
        UpdatePanel2.Update();
    }
    protected void Gridview2_Updating(object sender, GridViewUpdateEventArgs e)
    {
        string type = Convert.ToString(((TextBox)(GridView2.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        if (Label18.Text.Trim() != type)
        {
            DataSet ds = ip.S_IPSDetail(new Guid(Label_MID.Text.Trim()));
            DataRow[] rows = ds.Tables[0].Select("IPSD_Type='" + type + "'");
            if (rows.Length > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已存在该测试参数类别的详细项目！请重新填写')", true);
                return;
            }
            else
            {
                Guid gid = new Guid(GridView2.DataKeys[e.RowIndex].Value.ToString());
                ip.U_IPSDetail(gid, type);
                GridView2.EditIndex = -1;
                GridView2.SelectedIndex = -1;
                databind2();
                
            }
        }
        else
        {
            GridView2.EditIndex = -1;
            GridView2.SelectedIndex = -1;
            databind2();
        }
    }
    protected void Button_Add2_Click(object sender, EventArgs e)
    {
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        Panel1.Visible = true;
        UpdatePanel1.Update();
        Panel3.Visible = true;
        TextBox2.Text = "";
        UpdatePanel2.Update();
    }
    protected void Btn_Confirm2_Click(object sender, EventArgs e)
    {
        DataSet ds = ip.S_IPSDetail(new Guid(Label_MID.Text.Trim()));
        DataRow[] rows = ds.Tables[0].Select("IPSD_Type='" + TextBox2.Text.Trim()+ "'");
        if (rows.Length > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已存在该测试参数类别的详细项目！请重新填写')", true);
            return;
        }
        else
        {
            ip.I_IPSDetail(new Guid(Label_MID.Text.Trim()), TextBox2.Text.Trim());
            
        }
        Panel3.Visible = false;
        databind2();
        UpdatePanel2.Update();
    }
    protected void Button_Cancel2_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        databind2();
        UpdatePanel2.Update();
    }
    protected void Button_Cancel7_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel3.Visible = false;
        UpdatePanel2.Update();
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 200)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 200) + "...";
                }


            }
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
        
            ((TextBox)e.Row.Cells[1].Controls[0]).Attributes.Add("style ", "width:100%;");
          
           
        }
    }
}