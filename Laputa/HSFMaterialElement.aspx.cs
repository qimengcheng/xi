using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_HSFMaterialElement : Page
{
    private readonly HSFElementD ele = new HSFElementD();
    private readonly HSFMaterialElementD me = new HSFMaterialElementD();

    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = me.QueryMaterial(TextBox1.Text, TextBox2.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    private void bind()
    {
        GridView1.DataSource = me.QueryMaterial(TextBox1.Text, TextBox2.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            Label1.Text = "修改";

            TextBox11.Text = row.Cells[1].Text;
            TextBox12.Text = row.Cells[2].Text;
          

            if (!row.Cells[4].Text.Contains("&"))
            {
                DropDownList1.SelectedIndex =
                    DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(row.Cells[2].Text));
            }
            TextBox13.Text = row.Cells[3].Text;
            if (row.Cells[5].ToolTip!="")
            {
                TextBox14.Text = row.Cells[5].ToolTip;
            }
            else
            {
                TextBox14.Text = row.Cells[5].Text;
            }
          
            ElementID.Text = e.CommandArgument.ToString();
            Panel5.Visible = true;
            UpdatePanel5.Update();
        }

        if (e.CommandName == "De")
        {
            int a = me.DeleteHSF(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert",
                a > 0 ? "alert('删除成功！');" : "alert('失败了诶...');", true);
            bind();
            
        }
        if (e.CommandName == "SetDetail")
        {
            HSFID.Text = e.CommandArgument.ToString();

            Panel4.Visible = true;
            GridView3.DataSource = ele.Query("",new Guid(HSFID.Text));
            GridView3.DataBind();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "Details")
        {
            HSFID.Text = e.CommandArgument.ToString();

            Panel3.Visible = true;
            GridView2.DataSource = me.QueryDetail(new Guid(HSFID.Text));
            GridView2.DataBind();
            UpdatePanel3.Update();
        }
        if (e.CommandName == "copy")
        {
            HSFID.Text = e.CommandArgument.ToString();
            GridView4.DataSource = me.QueryMaterial(TextBox4.Text, TextBox5.Text);
           GridView4.DataBind();
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = true;
            Panel7.Visible = true;
            UpdatePanel3.Update();
            UpdatePanel4.Update(); 
            UpdatePanel5.Update();
            UpdatePanel6.Update(); 
            
        }
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

        GridView1.DataSource = me.QueryMaterial(TextBox1.Text, TextBox2.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }

    protected void Summit_Click(object sender, EventArgs e)
    {
        if (Label1.Text == "新增")
            
        {
            if (TextBox11.Text == "" || TextBox12.Text == "" || TextBox13.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('标*的为必填项,请核对后再提交')", true);
            }
            else
            {
                string name = TextBox11.Text;
                string provider = TextBox12.Text;
                string texture = TextBox13.Text;
                string note = TextBox14.Text;
                string level = DropDownList1.SelectedValue;

                int a = me.InsertMaterial(name, provider, texture, level, note);
                if (a == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增成功！')",
                        true);
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('已经有相同名称相同供应商的物料了!')",
                        true);
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
                GridView1.DataSource = me.QueryMaterial("", "");
                GridView1.DataBind();
                UpdatePanel2.Update();
            }
        }
        else
        {
            var id = new Guid(ElementID.Text);
            string name = TextBox11.Text;
            string provider = TextBox12.Text;
            string texture = TextBox13.Text;
            string note = TextBox14.Text;
            string level = DropDownList1.SelectedValue;
            int a = me.UpdateMaterial(id, name,provider,texture,level,note);
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('更新成功！')",
                    true);
                Panel5.Visible = false;
                UpdatePanel5.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...')",
                    true);
                Panel5.Visible = false;
                UpdatePanel5.Update();
            }
            GridView1.DataSource = me.QueryMaterial("", "");
            GridView1.DataBind();
            UpdatePanel2.Update();
        }
    }

    protected void AddMaterial_Click(object sender, EventArgs e)
    {
        Label1.Text = "新增";
        Panel5.Visible = true;
        UpdatePanel5.Update();
    }

    protected void close_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }


    protected void SearchE_Click(object sender, EventArgs e)
    {
        string name = TextBox3.Text;
        GridView3.DataSource = ele.Query(name,new Guid(HSFID.Text));
        GridView3.DataBind();
        GridView3.SelectedIndex = -1;
        UpdatePanel4.Update();
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }

    protected void SummitDetail_Click(object sender, EventArgs e)
    {
        int count = 0;
        int count2 = 0;
        foreach (GridViewRow rows in GridView3.Rows)
        {
            if (((CheckBox) rows.Cells[0].FindControl("CheckBox")).Checked)
            {
                int a = me.InsertDetail(new Guid(HSFID.Text),
                    new Guid(GridView3.DataKeys[rows.RowIndex].Value.ToString()),Session["UserName"].ToString());
                count++;
                count2 += a;
            }
        }
        if (count2== count)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('操作成功！')", true);
            Panel4.Visible = false;
            UpdatePanel4.Update();
            GridView2.DataSource = me.QueryDetail(new Guid(HSFID.Text));
            GridView2.DataBind();
            UpdatePanel3.Update();
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...')", true);
            Panel4.Visible = false;
            UpdatePanel4.Update();
            GridView2.DataSource = me.QueryDetail(new Guid(HSFID.Text));
            GridView2.DataBind();
            UpdatePanel3.Update();
        }
    
    }
    protected void CloseAdd_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }
    protected void closeeditdetail_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }
    protected void closedetail_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text.Length>10)
            {
                e.Row.Cells[5].ToolTip = e
                    .Row.Cells[5].Text;
                e.Row.Cells[5].Text = e
                    .Row.Cells[5].Text.Substring(0, 10);
            }
        }
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView3.BottomPagerRow;


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

        GridView3.DataSource = ele.Query("", new Guid(HSFID.Text));
        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
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

        GridView2.DataSource = me.QueryDetail(new Guid(HSFID.Text));
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="del")
        {
                    
        me.DeleteDetai(new Guid(e.CommandArgument.ToString()));
        GridView2.DataSource = me.QueryDetail(new Guid(HSFID.Text));
        GridView2.DataBind();
        UpdatePanel3.Update();
        }

    }
    protected void Search2_Click(object sender, EventArgs e)
    {
        GridView4.DataSource = me.QueryMaterial(TextBox4.Text, TextBox5.Text);
        GridView4.DataBind();
        UpdatePanel6.Update();
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView4.BottomPagerRow;


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

        GridView4.DataSource = me.QueryMaterial(TextBox4.Text, TextBox5.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }

    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {

           int a= me.CodyDetail(new Guid(HSFID.Text),new Guid(e.CommandArgument.ToString()),Session["UserName"].ToString());
            if (a >0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('复制成功！')", true);
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...')", true);
            
            }
        }
        
            GridView2.DataSource = me.QueryDetail(new Guid(HSFID.Text));
            GridView2.DataBind();
            UpdatePanel3.Update();
            Panel6.Visible = false;
            Panel7.Visible = false;
            UpdatePanel6.Update();
        
    }
    protected void closecopydetail_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        Panel7.Visible = false;
        UpdatePanel6.Update();
    }
    protected void reset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";

    }
    protected void reset2_Click(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox5.Text = "";
    }
    protected void CloseCopy_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        Panel7.Visible = false;
        UpdatePanel6.Update();
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text.Length > 18)
            {
                e.Row.Cells[4].ToolTip = e
                    .Row.Cells[4].Text;
                e.Row.Cells[4].Text = e
                    .Row.Cells[4].Text.Substring(0, 18);
            }
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[3].Text.Length > 18)
            {
                e.Row.Cells[3].ToolTip = e
                    .Row.Cells[3].Text;
                e.Row.Cells[3].Text = e
                    .Row.Cells[3].Text.Substring(0, 18);
            }
        }
    }
}