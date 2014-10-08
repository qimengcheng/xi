using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_OrganizationManagement : Page
{
    static readonly OrganizationD Or = new OrganizationD();
    static DataSet _orcache = Or.Query_Organization(null,0);
   static List<string> _strList2 = (from DataRow dr in _orcache.Tables[0].Rows select dr[1].ToString().Trim()).ToList();
    private void RefeshCache()
    {
        _orcache = Or.Query_Organization(null, 0);
        _strList2 = (from DataRow dr in _orcache.Tables[0].Rows select dr[1].ToString().Trim()).ToList();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "组织机构管理";
            Panel3.Visible = false;
            Panel4.Visible = false;
            string name = TextBox1.Text;

            int level = Convert.ToInt32(DropDownList1.SelectedValue);

            if (GridView1 != null)
            {
                GridView1.DataSource = Or.Query_Organization(name, level);
                GridView1.DataBind();
            }
            Panel2.Visible = true;
            GridView1.Enabled = true;

            try
            {
                if (!Session["UserRole"].ToString().Contains("组织机构查看")&&!Session["UserRole"].ToString().Contains("组织机构管理"))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else if(!Session["UserRole"].ToString().Contains("组织机构管理"))
                {
                    GridView1.Columns[5 - 6].Visible = false;
                    GridView2.Columns[4 - 5].Visible = false;
                }
            }
            catch (Exception )
            {
                Response.Redirect("~/Default.aspx");
            }
           
           
            GridView1.SelectedIndex = -1;
            UpdatePanel2.Update();


        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "child")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            OrName.Text = row.Cells[1].Text;
            GridView2.DataSource = Or.Query_Organization(e.CommandArgument.ToString());
            GridView2.DataBind();
            Panel3.Visible = true;
            Panel4.Visible = false;
            GridView1.Enabled = true;
            OrCode.Text = e.CommandArgument.ToString();
            UpdatePanel3.Update();
            UpdatePanel4.Update();

        }

        if (e.CommandName == "mo")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            code.Text = e.CommandArgument.ToString();
            TextBox3.Text = row.Cells[1].Text;
            Panel4.Visible = true;
            Label3.Text = "修改";
            Panel3.Visible = false;
            DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByValue(row.Cells[2].Text));
            DropDownList2_SelectedIndexChanged(sender, e);
            if (row.Cells[4].Text == "")
            {
                DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList3.Items.FindByText("无"));
            }
            else
            {
            DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList3.Items.FindByText(row.Cells[4].Text));
             }
            Label4.Text = row.Cells[1].Text;
            UpdatePanel3.Update();
            UpdatePanel4.Update();

        }
        if (e.CommandName == "del")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            string code = e.CommandArgument.ToString();
            int a=Or.DeleteOr(code);
            string name = TextBox1.Text;



            int level = Convert.ToInt32(DropDownList1.SelectedValue);
            GridView1.DataSource = Or.Query_Organization(name, level);
            GridView1.DataBind();
            GridView1.SelectedIndex = -1;
            UpdatePanel2.Update();

        }
    }

    protected void MainSearch_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text;



        int level = Convert.ToInt32(DropDownList1.SelectedValue);

        if (GridView1 != null)
        {
            GridView1.DataSource = Or.Query_Organization(name, level);
            GridView1.DataBind();
        }
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
        GridView1.Enabled = true;
        GridView1.SelectedIndex = -1;
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
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
        {
            newPageIndex = e.NewPageIndex;
        }
        string name = TextBox1.Text;



        int level = Convert.ToInt32(DropDownList1.SelectedValue);
        GridView1.DataSource = Or.Query_Organization(name, level);
        GridView1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    protected void create_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        flag.Text = "Label";
        Label4.Text = "Label";
        Image2.Visible = false;
        DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByText("一级机构"));
        DropDownList3.Items.Clear();
        DropDownList3.Items.Add(new ListItem("无", "无"));
        Panel4.Visible = true;
        Label3.Text = "新增";
        UpdatePanel4.Update();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int level = Convert.ToInt16(DropDownList2.SelectedValue);
        DropDownList3.Items.Clear();
        if (level == 1)
        {
            DropDownList3.Items.Add(new ListItem("无", "无"));//增加Item
        }
        else
        {
            SqlDataReader myReader = Or.Query_Organization(level);

            while (myReader.Read())
            {
                DropDownList3.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["BDOS_Code"].ToString()));//增加Item
            }
        }


    }

    protected void Summit_Click(object sender, EventArgs e)
    {
        RefeshCache();

        #region 判断重复机构名称

        if (Label4.Text != "Label")
        {
            if (flag.Text == "Label")
            {
                if (TextBox3.Text == "")
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";
                }
                else if (_strList2.Contains(TextBox3.Text) && TextBox3.Text != Label4.Text)
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";

                }
                else
                {
                    Image2.ImageUrl = "~/images/button/ok.gif";
                    Image2.Visible = true;
                    flag.Text = "yes";
                }
            }
        }
        else
        {
            if (flag.Text == "Label")
            {
                if (TextBox3.Text == "")
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";
                }
                else if (_strList2.Contains(TextBox3.Text))
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";

                }
                else
                {
                    Image2.ImageUrl = "~/images/button/ok.gif";
                    Image2.Visible = true;
                    flag.Text = "yes";
                }
            }
        }

        #endregion

      
        if (flag.Text =="no")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('机构名称未填或有重复！')", true);
        }

        else if (Label3.Text == "新增")
        {


            string name = TextBox3.Text;
            int a = Or.Insert_BD(name, Convert.ToInt16(DropDownList2.SelectedValue), DropDownList3.SelectedValue);
            if (a == 1)
            {
                Panel4.Visible = false;
                UpdatePanel4.Update();
                string sname = TextBox1.Text;

                int level = Convert.ToInt32(DropDownList1.SelectedValue);
                GridView1.DataSource = Or.Query_Organization(sname, level);
                GridView1.DataBind();
                UpdatePanel2.Update();
                string code = OrCode.Text;
                GridView2.DataSource = Or.Query_Organization(code);
                GridView2.DataBind();
                UpdatePanel3.Update();
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('已存在该部门,新增失败！')", true);
            }
        }
        else if (Label3.Text == "修改")
            {
                string name = TextBox3.Text;
                int a = Or.Update_BD(code.Text, name, Convert.ToInt16(DropDownList2.SelectedValue), DropDownList3.SelectedValue);
                if (a == 1)
                {
                    Panel4.Visible = false;
                    UpdatePanel4.Update();
                    string sname = TextBox1.Text;

                    int level = Convert.ToInt32(DropDownList1.SelectedValue);
                    GridView1.DataSource = Or.Query_Organization(sname, level);
                    GridView1.DataBind();
                    UpdatePanel2.Update();
                    string code2 = OrCode.Text;
                    GridView2.DataSource = Or.Query_Organization(code2);
                    GridView2.DataBind();
                    UpdatePanel3.Update();
                    GridView1.SelectedIndex = -1;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该部门,新增失败！')", true);
                }
            }
        
    }


    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
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
        {
            newPageIndex = e.NewPageIndex;
        }
        string code = OrCode.Text;
        GridView2.DataSource = Or.Query_Organization(code);
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();


       
       
      
     
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "mo")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            code.Text = e.CommandArgument.ToString();
            TextBox3.Text = row.Cells[1].Text;
            Panel4.Visible = true;
            Label3.Text = "修改";
            if (row.Cells[4].Text == "")
            {
                DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList3.Items.FindByText("无"));
            }
            else
            {
                DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList3.Items.FindByText(row.Cells[4].Text));
            }
            Label4.Text = row.Cells[1].Text;
            UpdatePanel4.Update();

        }
        if (e.CommandName == "del")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            string code = e.CommandArgument.ToString();
            int a = Or.DeleteOr(code);
            GridView2.DataSource = Or.Query_Organization(code);
            GridView2.DataBind();
            UpdatePanel3.Update();

        }
    }
    protected void CloseM_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();

    }
    protected void CloseC_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void reset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("所有类型"));
        UpdatePanel1.Update();
        MainSearch_Click(sender, e);
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        RefeshCache();
        if (Label4.Text != "Label")
        {
            if (flag.Text == "Label")
            {
                if (TextBox3.Text == "")
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";
                }
                else if (_strList2.Contains(TextBox3.Text) && TextBox3.Text != Label4.Text)
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";

                }
                else
                {
                    Image2.ImageUrl = "~/images/button/ok.gif";
                    Image2.Visible = true;
                    flag.Text = "yes";
                }
            }
        }
        else
        {
            if (flag.Text == "Label")
            {
                if (TextBox3.Text == "")
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";
                }
                else if (_strList2.Contains(TextBox3.Text))
                {
                    Image2.ImageUrl = "~/images/button/delete.gif";
                    Image2.Visible = true;
                    flag.Text = "no";

                }
                else
                {
                    Image2.ImageUrl = "~/images/button/ok.gif";
                    Image2.Visible = true;
                    flag.Text = "yes";
                }
            }
        }
        UpdatePanel4.Update();
    }
}
