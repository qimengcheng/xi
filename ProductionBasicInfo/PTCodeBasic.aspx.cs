using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class ProductionBasicInfo_PTCodeBasic : Page
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
            if (state == "look")
            {
                Title = "产品编码基础信息查看";
                GridView1.Columns[3].Visible = false;
                GridView1.Columns[4].Visible = false;
                Button_Add.Visible = false;



            }


            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("产品编码基础信息查看")) || (Session["UserRole"].ToString().Contains("产品编码基础信息维护"))))
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("产品编码基础信息维护"))
                    {

                        Title = "产品编码基础信息查看";
                        GridView1.Columns[3].Visible = false;
                        GridView1.Columns[4].Visible = false;
                        Button_Add.Visible = false;


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
        GridView2.DataSource = ppl.S_PTCB();
        GridView2.DataBind();
        UpdatePanel_PT.Update();
    }
    public void databind2()
    {
        string condition;
        string PTCB_Code = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and PTCB_Code like '%" + TextBox1.Text.Trim() + "%' ";
        condition = PTCB_Code;
        GridView1.DataSource = ppl.S_PTCB_Detail(condition, Label18.Text.Trim());
        GridView1.DataBind();
        UpdatePanel1.Update();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_PT")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label17.Text = al[1];
            Label18.Text = al[0];
            TextBox1.Text = "";
            Panel1.Visible = true;
            databind2();
            Panel2.Visible = false;
            UpdatePanel2.Update();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete1")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            try
            {
                ppl.D_PTCB_Detail(new Guid(al[0].Trim()));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            databind2();
            Panel2.Visible = false;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "Edit_PT")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;


            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            TextBox2.Text = al[1].Trim();
            Label19.Text = al[1].Trim();
            TextBox3.Text = al[2].Trim();
            Label2.Text = al[0];
            Panel2.Visible = true;
            Label1.Text = "编辑";
            if (Label18.Text.Trim() == "1")
            {
                TextBox2.MaxLength = 1;
            }
            if (Label18.Text.Trim() == "2")
            {
                TextBox2.MaxLength = 2;
            }
            if (Label18.Text.Trim() == "3")
            {
                TextBox2.MaxLength = 3;
            }
            if (Label18.Text.Trim() == "4")
            {
                TextBox2.MaxLength = 3;
            }
            if (Label18.Text.Trim() == "5")
            {
                TextBox2.MaxLength = 1;
            }
            if (Label18.Text.Trim() == "6")
            {
                TextBox2.MaxLength = 2;
            }
            if (Label18.Text.Trim() == "7")
            {
                TextBox2.MaxLength = 2;
            }
            if (Label18.Text.Trim() == "8")
            {
                TextBox2.MaxLength = 1;
            }
            if (Label18.Text.Trim() == "9")
            {
                TextBox2.MaxLength = 1;
            }
            if (Label18.Text.Trim() == "10")
            {
                TextBox2.MaxLength = 1;
            }
            if (Label18.Text.Trim() == "11")
            {
                TextBox2.MaxLength = 2;
            }
            UpdatePanel2.Update();
        }

    }
    protected void Button_s_Click(object sender, EventArgs e)
    {
        databind2();
    }
    protected void Button_r_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        databind2();
    }
    protected void Button_c_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        GridView2.SelectedIndex = -1;
        UpdatePanel_PT.Update();
    }
    protected void Button_Add_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Label1.Text = "新增";
        TextBox2.Text = "";
        TextBox3.Text = "";
        if (Label18.Text.Trim() == "1")
        {
            TextBox2.MaxLength = 1;
        }
        if (Label18.Text.Trim() == "2")
        {
            TextBox2.MaxLength = 2;
        }
        if (Label18.Text.Trim() == "3")
        {
            TextBox2.MaxLength = 3;
        }
        if (Label18.Text.Trim() == "4")
        {
            TextBox2.MaxLength = 3;
        }
        if (Label18.Text.Trim() == "5")
        {
            TextBox2.MaxLength = 1;
        }
        if (Label18.Text.Trim() == "6")
        {
            TextBox2.MaxLength = 2;
        }
        if (Label18.Text.Trim() == "7")
        {
            TextBox2.MaxLength = 2;
        }
        if (Label18.Text.Trim() == "8")
        {
            TextBox2.MaxLength = 1;
        }
        if (Label18.Text.Trim() == "9")
        {
            TextBox2.MaxLength = 1;
        }
        if (Label18.Text.Trim() == "10")
        {
            TextBox2.MaxLength = 1;
        }
        if (Label18.Text.Trim() == "11")
        {
            TextBox2.MaxLength = 2;
        }

        UpdatePanel2.Update();


    }
    protected void Button_submit_Click(object sender, EventArgs e)
    {
        Regex rx = new Regex("^[\u4E00-\u9FA5]+$");
        if (rx.IsMatch(TextBox2.Text.ToString()))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('固定代码中不能含有汉字！请核对')", true);
            return;
        }
        if (TextBox2.Text.Length != TextBox2.MaxLength)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请核对代码位数是否足够！" + "此固定代码位数为：" + TextBox2.MaxLength.ToString() + " ')", true);
            return;
        }
        if (Label1.Text.Trim() == "新增")
        {
            try
            {
                
                if (TextBox2.Text.Trim() == "" || TextBox3.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('固定代码和代码含义均不能为空！，请您再核对！')", true);
                    return;
                }
                DataSet ds = ppl.S_PTCB_Detail(" and PTCB_Code='" + TextBox2.Text.Trim() + "'", Label18.Text.Trim());
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该固定代码！，请您再核对！')", true);
                    return;
                }
                ppl.I_PTCB_Detail(Convert.ToInt32(Label18.Text.Trim()), TextBox2.Text.Trim(), TextBox3.Text.Trim());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);

            }

            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！，请您再核对！')", true);

                return;
            }
        }
        if (Label1.Text.Trim() == "编辑")
        {
            try
            {
                if (TextBox2.Text.Trim() == "" || TextBox3.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('固定代码和代码含义均不能为空！，请您再核对！')", true);
                    return;
                }
                if (Label19.Text.Trim() != TextBox2.Text.Trim())
                {
                    DataSet ds = ppl.S_PTCB_Detail(" and PTCB_Code='" + TextBox2.Text.Trim() + "'", Label18.Text.Trim());
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该固定代码！，请您再核对！')", true);
                        return;
                    }
                }
                ppl.U_PTCB_Detail(new Guid(Label2.Text.Trim()), TextBox2.Text.Trim(), TextBox3.Text.Trim());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑失败！，请您再核对！')", true);

                return;
            }
        }
        Panel2.Visible = false;
        UpdatePanel2.Update();
        databind2();
        GridView1.SelectedIndex = -1;
    }
    protected void Button_c2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
        GridView1.SelectedIndex = -1;
        UpdatePanel1.Update();
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
        databind2();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        GridView1.SelectedIndex = -1;

    }
}