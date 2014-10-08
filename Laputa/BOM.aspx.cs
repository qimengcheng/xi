using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Laputa_BOM : Page
{
    BOM bom = new BOM();
   
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {
            if (!Session["UserRole"].ToString().Contains("BOM维护"))
            {
                GridView2.Columns[6].Visible = false;
                GridView2.Columns[8].Visible = false;
                GridView2.Columns[9].Visible = false;
                GridView3.Columns[20].Visible = false;
                GridView3.Columns[15].Visible = false;
                GridView3.Columns[19].Visible = false;
                GridView3.Columns[16].Visible = false;
                GridView3.Columns[17].Visible = false;
                GridView3.Columns[18].Visible = false;
                UpdatePanel2.Update();
                if (!Session["UserRole"].ToString().Contains("BOM查看"))
                {
                    Response.Redirect("~/Default.aspx");

                }
            }

        }
        catch
        {

            Response.Redirect("~/Default.aspx");
        }


        if (!Page.IsPostBack)
        {
            Panel3.Visible = false;
            Panel31.Visible = false;
            Panel4.Visible = false;
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            GridView1.DataSource = bom.Query_ControlledDocApp();
            GridView1.DataBind();
            UpdatePanel1.Update();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
            UpdatePanel8.Update();


        }
        if (Request.QueryString["state"] == null)
        {
            Labelstate.Text = "look";
            Title = "BOM查看";
        }
        else
        {
            Labelstate.Text = Request.QueryString["state"];
        }
        string pstate = Labelstate.Text;
        if (pstate == "look")
        {
            Title = "BOM查看";
            GridView2.Columns[6].Visible = false;
            GridView2.Columns[8].Visible = false;
            GridView2.Columns[9].Visible = false;
            GridView3.Columns[20].Visible = false;
            GridView3.Columns[15].Visible = false;
            GridView3.Columns[19].Visible = false;
            GridView3.Columns[16].Visible = false;
            GridView3.Columns[17].Visible = false;
            GridView3.Columns[18].Visible = false;
            Button21.Visible = false;
            Button31.Visible = false;
            UpdatePanel2.Update();
            UpdatePanel3.Update();
        }
        if (pstate == "manage")
        {
            Title = "BOM维护";
        }



    }


    #region 分页代码
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
        string a1 = TextBox1.Text;
        string a2 = TextBox2.Text;
        string a3 = TextBox3.Text;
        string a4 = TextBox4.Text;
        DateTime a5 = new DateTime();
        DateTime a6 = new DateTime();
        if (TextBox5.Text == "")
        {
            a5 = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        else
        {
            a5 = Convert.ToDateTime(TextBox5.Text);
        }
        if (TextBox6.Text == "")
        {
            a6 = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }
        else
        {
            a6 = Convert.ToDateTime(TextBox6.Text);

        }

        string a7 = TextBox7.Text;
        string a8 = DropDownList1.SelectedValue;
        string a9 = TextBox8.Text;
        string a10 = TextBox9.Text;
        int a11 = CheckBox1.Checked ? 0 : 1;
        GridView1.DataSource = bom.Query_ControlledDocApp(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10,a11);
        GridView1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
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
        GridView2.DataSource = bom.Query_BOM(new Guid(Label1.Text));
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
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
        GridView3.DataSource = bom.Query_BOMDetail(new Guid(Label3.Text));
        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
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
        GridView4.DataSource = bom.Query_PBC(TextBox16.Text);
        GridView4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }
    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView5.BottomPagerRow;


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
        GridView5.DataSource = bom.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView5.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView5.PageCount ? GridView5.PageCount - 1 : newPageIndex;
        GridView5.PageIndex = newPageIndex;
        GridView5.DataBind();
    }
    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView6.BottomPagerRow;


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
        GridView6.DataSource = bom.Query_Unit(TextBox23.Text);
        GridView6.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView6.PageCount ? GridView6.PageCount - 1 : newPageIndex;
        GridView6.PageIndex = newPageIndex;
        GridView6.DataBind();
    }
    #endregion
    #region 表命令
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            if (row.Cells[10].Text!="最新版本")
            {
               
                GridView2.Columns[5].Visible = false;
                GridView2.Columns[7].Visible = false;
                GridView2.Columns[8].Visible = false;
                GridView3.Columns[20].Visible = false;
                GridView3.Columns[15].Visible = false;
                GridView3.Columns[19].Visible = false;
                GridView3.Columns[16].Visible = false;
                GridView3.Columns[17].Visible = false;
                GridView3.Columns[18].Visible = false;
                Button21.Visible = false;
                Button31.Visible = false;
            }
            else
            {
                if (Labelstate.Text == "manage")
                {
                  
                    GridView2.Columns[5].Visible = true;
                    GridView2.Columns[7].Visible = true;
                    GridView2.Columns[8].Visible = true;
                    GridView3.Columns[20].Visible = true;
                    GridView3.Columns[15].Visible = true;
                    GridView3.Columns[19].Visible = true;
                    GridView3.Columns[16].Visible = true;
                    GridView3.Columns[17].Visible = true;
                    GridView3.Columns[18].Visible = true;
                    Button21.Visible = true;
                    Button31.Visible = true;
                    UpdatePanel2.Update();
                    UpdatePanel3.Update();
                }
                
           
            Guid id = new Guid(e.CommandArgument.ToString());
            GridView2.DataSource = bom.Query_BOM(id);
            GridView2.DataBind();
            Panel3.Visible = true;
            Panel31.Visible = false;
            Panel4.Visible = false;
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            Label1.Text = e.CommandArgument.ToString();
            Label2.Text = row.Cells[1].Text;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
            UpdatePanel6.Update();
            GridView2.SelectedIndex = -1;
            }
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            Guid id = new Guid(e.CommandArgument.ToString());
            GridView3.DataSource = bom.Query_BOMDetail(id);
            GridView3.DataBind();
            Label3.Text = id.ToString();
            Label4.Text = row.Cells[1].Text;

            Panel4.Visible = true;
            Panel31.Visible = false;
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel4.Update();
            GridView3.SelectedIndex = -1;
            UpdatePanel3.Update();
            UpdatePanel5.Update();
            UpdatePanel6.Update();
        }
        if (e.CommandName == "Modify")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            Label13.Text = e.CommandArgument.ToString();
            Label12.Text = row.Cells[1].Text;
            TextBox10.Text = Label12.Text;
            DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByText(row.Cells[2].Text));
            Label11.Text = "修改";
            Panel4.Visible = false;
            Panel31.Visible = true;
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel6.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();

        }
        if (e.CommandName == "Delete")
        {
            Guid id = new Guid(e.CommandArgument.ToString());
            bom.Delete_BOM(id);
            Guid BDF = new Guid(Label1.Text);
            GridView2.DataSource = bom.Query_BOM(BDF);
            GridView2.DataBind();
            Panel31.Visible = false;
            Panel4.Visible = false;
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "Copy")
        {
            Guid id = new Guid(e.CommandArgument.ToString());
            Label3.Text = id.ToString();
            Guid BDF = new Guid(Label1.Text);
            GridView2.DataSource = bom.Query_BOM(BDF);
            GridView2.DataBind();
            Panel31.Visible = false;
            Panel4.Visible = false;
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = true;
            GridView7.DataSource = bom.SeachBom(TextBox11.Text);
            GridView7.DataBind();
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }

    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView3.SelectedIndex = row.RowIndex;
            Guid bdid = new Guid(e.CommandArgument.ToString());
            Label32.Text = Label4.Text;
            Label34.Text = row.Cells[12].Text;
            Label35.Text = row.Cells[3].Text;
            Label36.Text = row.Cells[1].Text;
            Label37.Text = row.Cells[2].Text;
            Label38.Text = row.Cells[11].Text;
            Label33.Text = bdid.ToString();
            TextBox14.Text = row.Cells[4].Text;
            TextBox15.Text = row.Cells[5].Text;
            DropDownList3.Items.Clear();
            FuseText.Visible = false;
            DropDownList4.Visible = false;
            SqlDataReader myReader = bom.Query_MUnit(new Guid(Label38.Text));
            UnitCheck.Visible = true;
            while (myReader.Read())
            {
                DropDownList3.Items.Add(new ListItem(myReader["UnitName"].ToString(), myReader["UnitID"].ToString()));//增加Item
            }

            DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList3.Items.FindByText(row.Cells[6].Text));
            TextBox17.Text = row.Cells[9].Text;
            try
            {
                Guid CraID = bom.Query_PBCID(row.Cells[3].Text);
                Label34.Text = CraID.ToString();
                Label35.Text = row.Cells[3].Text;

            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('工序名有重复，请手动选择工序！')", true);

            }

            Label31.Text = "修改";
            Panel41.Visible = true;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel52.Visible = false;
            Panel53.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "AddMate")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView3.SelectedIndex = row.RowIndex;
            Guid bdid = new Guid(e.CommandArgument.ToString());
            Label33.Text = bdid.ToString();
            Label34.Text = row.Cells[12].Text;
            Label35.Text = row.Cells[3].Text;
            Label36.Text = "请选择物料";
            Label37.Text = "请选择物料";
            TextBox14.Text = "";
            TextBox15.Text = "";
            TextBox17.Text = "";
            TextBox21.Text = row.Cells[1].Text;
            FuseText.Visible= true;
            DropDownList4.Visible = true;
            DropDownList4.SelectedIndex = DropDownList4.Items.IndexOf(DropDownList4.Items.FindByText("否"));
            DropDownList4.Enabled = true;
            DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList3.Items.FindByText(row.Cells[6].Text));

            Label31.Text = "新增可替用物料";
            Panel41.Visible = true;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel52.Visible = false;
            Panel53.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "AddFuse")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView3.SelectedIndex = row.RowIndex;
            FuseText.Visible = true;
            DropDownList4.Visible = true;
            DropDownList4.SelectedIndex = DropDownList4.Items.IndexOf(DropDownList4.Items.FindByText("是"));
            DropDownList4.Enabled = false;

            Guid bdid = new Guid(e.CommandArgument.ToString());
            Label33.Text = bdid.ToString();
            Label34.Text = row.Cells[12].Text;
            Label35.Text = row.Cells[3].Text;
            Label36.Text = "请选择物料";
            Label37.Text = "请选择物料";
            TextBox14.Text = "";
            TextBox15.Text = "";
            TextBox17.Text = "";
            TextBox21.Text = row.Cells[1].Text;
            FuseID.Text = row.Cells[14].ToolTip;
            MateID.Text = row.Cells[19].Text;
            DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList3.Items.FindByText(row.Cells[6].Text));

            Label31.Text = "新增组合物料成员";
            
            Panel41.Visible = true;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel52.Visible = false;
            Panel53.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "Delete")
        {
            Guid id = new Guid(e.CommandArgument.ToString());
            bom.Delete_BOMDetail(id);
            Guid BOM_ID = new Guid(Label3.Text);
            GridView3.DataSource = bom.Query_BOMDetail(BOM_ID);
            GridView3.DataBind();
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            UpdatePanel8.Update();
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "AddPercent")
        {
            GridViewRow row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView3.SelectedIndex = row.RowIndex;
            Panel8.Visible = true;
            GridView8.DataSource = bom.Query_MatePercent(new Guid(e.CommandArgument.ToString()));
            GridView8.DataBind();
            Panel41.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel52.Visible = false;
            Panel53.Visible = false;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            UpdatePanel4.Update();
            UpdatePanel8.Update();
        }
        if (e.CommandName == "history")
        {
            GridView10.DataSource = bom.Query_BOMDetailHistory(new Guid(e.CommandArgument.ToString()));
            GridView10.DataBind();
            Panel10.Visible = true;
            UpdatePanel10.Update();
        }

    }


    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Guid id = new Guid(e.CommandArgument.ToString());
            Label34.Text = id.ToString();
            Label35.Text = row.Cells[1].Text;

            Panel51.Visible = false;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();

        }

    }
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Guid id = new Guid(e.CommandArgument.ToString());
            Label38.Text = id.ToString();
            Label36.Text = row.Cells[1].Text;
            Label37.Text = row.Cells[2].Text;
            Panel51.Visible = false;
            Panel52.Visible = false; Panel53.Visible = false;
            UnitCheck.Visible = true;
            DropDownList3.Items.Clear();
            SqlDataReader myReader = bom.Query_MUnit(id);

            while (myReader.Read())
            {
                DropDownList3.Items.Add(new ListItem(myReader["UnitName"].ToString(), myReader["UnitID"].ToString()));//增加Item
            }
            Button39.Visible = true;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
    }
    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Guid id = new Guid(e.CommandArgument.ToString());
            Label534.Text = id.ToString();
            Label533.Text = row.Cells[1].Text;
            Panel51.Visible = false;
            Panel52.Visible = false;
            Panel53.Visible = true;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }




    }
    protected void GridView7_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Guid fromid = new Guid(e.CommandArgument.ToString());
           Guid id=new Guid(Label3.Text);
           string man = Session["UserName"].ToString();
           int a = bom.Copybom(id, fromid,man); 
            if (a>0)
           {

               ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('复制成功.')", true);

           }
            Panel51.Visible = false;
            Panel52.Visible = false;
            Panel53.Visible = false;
            Panel6.Visible = false;

            UpdatePanel4.Update();
            UpdatePanel5.Update();
            UpdatePanel6.Update();

        }
    }
    #endregion
    #region 行数据绑定
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[14].ToolTip = e.Row.Cells[14].Text.ToUpper();
            if (e.Row.Cells[14].Text.Length > 3)
            {
                e.Row.Cells[14].Text = e.Row.Cells[14].Text.Substring(0, 3).ToUpper();

            }
            if (e.Row.Cells[7].Text.Length > 7)
            {
                e.Row.Cells[7].ToolTip = e.Row.Cells[7].Text;
                e.Row.Cells[7].Text = e.Row.Cells[7].Text.Substring(0, 7);

            }
            if (e.Row.Cells[10].Text != e.Row.Cells[2].Text&&e.Row.Cells[10].Text!="无")
            {
                
                e.Row.Cells[16].Text ="";
                e.Row.Cells[16].Enabled = false;
                e.Row.Cells[20].Text = "";
                e.Row.Cells[20].Enabled = false;
                
                e.Row.Cells[16].ToolTip = "请在"+e.Row.Cells[1].Text+e.Row.Cells[10].Text+"上新增";

            }
            if (e.Row.Cells[10].Text == "无")
            {

                e.Row.Cells[17].Text = "";
                e.Row.Cells[17].Enabled = false;
                e.Row.Cells[20].Text = "";
                e.Row.Cells[20].Enabled = false;
                

                e.Row.Cells[17].ToolTip = "只有可替代物料才可以增加组合成员哦";
                e.Row.Cells[20].ToolTip = "只有可替代物料才可以分配比例哦";

            }
            if (e.Row.Cells[13].Text == "否")
            {

                e.Row.Cells[17].Text = "";
                e.Row.Cells[17].Enabled = false;

                e.Row.Cells[17].ToolTip = "只有组合物料才可以增加组合成员哦";

            }
         

              
            
         



        }
    }
    #endregion
    #region 按钮事件
    #region 检索BOM文件

    protected void Button1_Click(object sender, EventArgs e) //点击检索按钮
    {
        string a1 = TextBox1.Text;
        string a2 = TextBox2.Text;
        string a3 = TextBox3.Text;
        string a4 = TextBox4.Text;
        DateTime a5;
        DateTime a6;
        a5 = Convert.ToDateTime(TextBox5.Text == "" ? "1/1/1753 12:00:00 AM" : TextBox5.Text);
        a6 = Convert.ToDateTime(TextBox6.Text == "" ? "12/31/9999 11:59:59 PM" : TextBox6.Text);

        string a7 = TextBox7.Text;
        string a8 = DropDownList1.SelectedValue;
        string a9 = TextBox8.Text;
        string a10 = TextBox9.Text;
        int a11 = CheckBox1.Checked ? 0 : 1;
        GridView1.DataSource = bom.Query_ControlledDocApp(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10,a11);
        GridView1.DataBind();
        Panel3.Visible = false;
        Panel31.Visible = false;
        Panel4.Visible = false;
        Panel41.Visible = false;
        Panel5.Visible = false;
        Panel51.Visible = false;
        Panel6.Visible = false;
        UpdatePanel6.Update();
        UpdatePanel1.Update();
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel5.Update();


    }

    #endregion
    #region 表1按钮
    protected void Button21_Click(object sender, EventArgs e)
    {
        Panel31.Visible = true;
        Label11.Text = "新增";
        Label12.Text = Label2.Text;
        Panel4.Visible = false;
        Panel41.Visible = false;
        Panel5.Visible = false;
        Panel51.Visible = false;
        Panel6.Visible = false;
        UpdatePanel6.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel5.Update();

    }
    protected void Butto22_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel31.Visible = false;
        UpdatePanel3.Update();
    }
    protected void Button23_Click(object sender, EventArgs e)
    {
        if (TextBox10.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (Label11.Text == "新增")
        {
            Guid id = new Guid(Label1.Text);
            try
            {
                int a = bom.Insert_BOM(id, TextBox10.Text, DropDownList2.SelectedItem.Text, Session["UserName"].ToString());
                TextBox10.Text = "";
                Panel31.Visible = false;
                GridView2.DataSource = bom.Query_BOM(new Guid(Label1.Text));
                GridView2.DataBind();
                UpdatePanel3.Update();
                if (a == -1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该BOM,新增失败.')", true);
                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！')", true);
            }

        }
        if (Label11.Text == "修改")
        {
            try
            {
                Guid id = new Guid(Label13.Text);
                bom.Update_BOM(id, TextBox10.Text, DropDownList2.SelectedItem.Text, Session["UserName"].ToString());
                TextBox10.Text = "";
                Panel31.Visible = false;
                GridView2.DataSource = bom.Query_BOM(new Guid(Label1.Text));
                GridView2.DataBind();
                UpdatePanel3.Update();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改失败！')", true);
            }

        }
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        Panel31.Visible = false;
    }
    #endregion
    #region 表2按钮
    protected void Button31_Click(object sender, EventArgs e)
    {
        Label36.Text = "请选择物料";
        Label37.Text = "请选择物料";
        UnitCheck.Visible = false;
        Panel41.Visible = true;
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox17.Text = "";
        FuseText.Visible = false;
        DropDownList4.Visible = false;
        Label35.Text = "请选择工序";
        Guid id = new Guid(Label3.Text);
        GridView3.DataSource = bom.Query_BOMDetail(id);
        GridView3.DataBind();
        Label31.Text = "新增";
        DropDownList3.Items.Clear();
        Label32.Text = Label4.Text;
        Panel4.Visible = true;
        Panel31.Visible = false;
        Panel5.Visible = false;
        Panel51.Visible = false;
        Button39.Visible = false;
        UpdatePanel4.Update();
        UpdatePanel5.Update();
        UpdatePanel3.Update();
        Panel6.Visible = false;
        UpdatePanel6.Update();

    }
    protected void Button32_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel41.Visible = false;
        UpdatePanel4.Update();
    }
    protected void Button33_Click(object sender, EventArgs e)
    {
        GridView4.DataSource = bom.Query_PBC(TextBox16.Text);
        GridView4.DataBind();
        Panel51.Visible = true;
        Panel52.Visible = false; Panel53.Visible = false;
        Panel5.Visible = true;
        UpdatePanel5.Update();
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }
    protected void Button34_Click(object sender, EventArgs e)
    {
        string fuse = DropDownList4.SelectedValue;
        if (TextBox14.Text == "" || TextBox15.Text == "" || TextBox17.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }

        if (Label35.Text == "请选择工序" || Label36.Text == "请选择物料")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('物料或工序还未选择。')", true);

        }
        else
        {
            Guid pid = new Guid(Label34.Text);
            Guid mid = new Guid(Label38.Text);
           
            decimal use = decimal.Parse(TextBox14.Text);
            decimal ruse = decimal.Parse(TextBox15.Text);
            Guid uid = new Guid(DropDownList3.SelectedValue);
            Guid bomid = new Guid(Label3.Text);
            string note = TextBox17.Text;
            if (Label31.Text == "新增")
            {
                //try
                //{
                string man = Session["UserName"].ToString();
                int a = bom.Insert_BOMDetail(bomid, pid, uid, mid, use, ruse, note,man);
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox17.Text = "";
                Label35.Text = "未选择工序";
                if (a == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('增加成功.')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该BOM,新增失败.')", true);

                }
                Panel41.Visible = false;
                GridView3.DataSource = bom.Query_BOMDetail(new Guid(Label3.Text));
                GridView3.DataBind();
                //}
                //catch
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('增加失败')", true);
                //}
            }
            if (Label31.Text == "修改")
            {
                //try
                //{
                FuseText.Visible = false;
                DropDownList4.Visible = false;
                Guid bdid = new Guid(Label33.Text);
                string man = Session["UserName"].ToString();
                bom.Update_BOMDetail(bdid, pid, uid, mid, use, ruse, note,man);
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox17.Text = "";
                Label35.Text = "未选择工序";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功')", true);
                Panel41.Visible = false;
                GridView3.DataSource = bom.Query_BOMDetail(new Guid(Label3.Text));
                GridView3.DataBind();
                UpdatePanel4.Update();
                //}
                //catch
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('修改失败')", true);
                //}
            }
            if (Label31.Text == "新增可替用物料")
            {
                Guid mateid = new Guid(Label33.Text);
                string man = Session["UserName"].ToString();
                int a = bom.Insert_BOMDetailMate(bomid, mateid, pid, uid, mid, use, ruse, note,fuse,Guid.Empty,man);
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox17.Text = "";
                Label35.Text = "未选择工序";
                if (a >0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('增加成功.')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该BOM,新增失败.')", true);

                }
                Panel41.Visible = false;
                GridView3.DataSource = bom.Query_BOMDetail(new Guid(Label3.Text));
                GridView3.DataBind();
                UpdatePanel4.Update();
            }
            if (Label31.Text == "新增组合物料成员")
            {
                //try
                //{
                Guid mateid = new Guid(MateID.Text);
                Guid fuseid = new Guid(FuseID.Text);
                string man = Session["UserName"].ToString();
                int a = bom.Insert_BOMDetailMate(bomid, mateid, pid, uid, mid, use, ruse, note, fuse, fuseid,man);
                TextBox14.Text = "";
                TextBox15.Text = "";
                TextBox17.Text = "";
                Label35.Text = "未选择工序";
                if (a > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('增加成功.')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该BOM,新增失败.')", true);

                }
                Panel41.Visible = false;
                GridView3.DataSource = bom.Query_BOMDetail(new Guid(Label3.Text));
                GridView3.DataBind();
                UpdatePanel4.Update();
                //}
                //catch
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('增加失败')", true);
                //}
            }



        }
    }
    protected void Button35_Click(object sender, EventArgs e)
    {
        Panel41.Visible = false;
        Panel51.Visible = false;
    }

    #endregion
    #region 检索工序
    protected void Button36_Click(object sender, EventArgs e)
    {
        GridView4.DataSource = bom.Query_PBC(TextBox16.Text);
        GridView4.DataBind();
        UpdatePanel4.Update();

    }
    #endregion
    #region 检索物料
    protected void Button531_Click(object sender, EventArgs e)
    {
        GridView6.DataSource = bom.Query_Unit(TextBox23.Text);
        GridView6.DataBind();
        UpdatePanel5.Update();
    }
    #endregion
    #endregion
    #region 删除


    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    protected void TextBox14_TextChanged(object sender, EventArgs e)
    {

    }


    protected void Button38_Click(object sender, EventArgs e)
    {
       
        GridView5.DataSource = bom.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView5.DataBind();
        Panel51.Visible = false;
        Panel5.Visible = true;
        Panel52.Visible = true;
        Panel53.Visible = false;
        Panel6.Visible = false;
        UpdatePanel5.Update();
        UpdatePanel6.Update();
    }


    protected void Button39_Click(object sender, EventArgs e)
    {
        GridView6.DataSource = bom.Query_Unit(TextBox23.Text);
        GridView6.DataBind();
        Label533.Text = "请选择单位";
        TextBox24.Text = "";
        DefaultUnit du = new DefaultUnit();
        du = bom.Query_DefaultUnitID(new Guid(Label38.Text));
        Label531.Text = du.Name;
        Label532.Text = du.Defaultid.ToString();
        Panel53.Visible = true;
        Panel51.Visible = false;
        Panel5.Visible = true;
        Panel52.Visible = false;
        Panel6.Visible = false;
        UpdatePanel5.Update();
        UpdatePanel6.Update();

    }
    protected void TextBox11_TextChanged(object sender, EventArgs e)
    {

    }


    protected void Button532_Click(object sender, EventArgs e)
    {
        if (Label533.Text == "请选择单位")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('还没选择单位呢，请选择单位后再提交！')", true);
        }
        else
        {
            int a = bom.Insert_IMUnitChange(new Guid(Label38.Text), new Guid(Label534.Text), decimal.Parse(TextBox24.Text));
            if (a == -1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该单位啦.')", true);
            }
            else
            {
                DropDownList3.Items.Clear();
                SqlDataReader myReader = bom.Query_MUnit(new Guid(Label38.Text));

                while (myReader.Read())
                {
                    DropDownList3.Items.Add(new ListItem(myReader["UnitName"].ToString(), myReader["UnitID"].ToString()));//增加Item
                }
                Panel53.Visible = false;
                UpdatePanel4.Update();
                UpdatePanel5.Update();
            }
        }


    }
    protected void Button37_Click(object sender, EventArgs e)
    {
        GridView5.DataSource = bom.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView5.DataBind();
        UpdatePanel5.Update();
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        foreach (Control ct in Panel1.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
            {
                TextBox cb = (TextBox)ct;
                cb.Text = "";


            }
        }
        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("所有类型"));
        GridView1.DataSource = bom.Query_ControlledDocApp();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
    protected void SearchBom(object sender, EventArgs e)
    {
        GridView7.DataSource = bom.SeachBom(TextBox11.Text);
        GridView7.DataBind();
        UpdatePanel6.Update();
    }

    protected void ClosePercent_Click(object sender, EventArgs e)
    {
        Panel8.Visible = false;
        UpdatePanel8.Update();
    }
    protected void SummitPercent_Click(object sender, EventArgs e)
    {
        decimal sum = 0;
        foreach (GridViewRow row in GridView8.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {

                TextBox tb = (TextBox)(row.Cells[8].FindControl("bl"));
                try
                {
                    if (tb.Text=="")
                    {
                        tb.Text = "0";
                    }
                    sum += decimal.Parse(tb.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('输入格式不对！')", true);
                }
            }
        }
        if (sum == 1)
            {
                foreach (GridViewRow row in GridView8.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox tb = (TextBox)(row.Cells[8].FindControl("bl"));
                        string man = Session["UserName"].ToString();
                        int a=bom.Update_BOMDetailPercent(new Guid(row.Cells[0].Text), decimal.Parse(tb.Text),man);
                        if (a==1)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('比例分配成功！')",
                                true);
                            Panel8.Visible = false;
                            UpdatePanel8.Update();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('操作失败！')",
                                true);
                            Panel8.Visible = false;
                            UpdatePanel8.Update();
                        }

                    }
                }
            }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('比重加起来不等于1哦！')", true);
        }
        

    }
    protected void UnitCheck_Click(object sender, EventArgs e)
    {
        Panel5.Visible = true;

        Panel54.Visible = true;

        GridView9.DataSource = bom.Query_MAllUnit(new Guid(Label38.Text));
        GridView9.DataBind();
        UpdatePanel5.Update();
    }
    protected void SummitUnitModify_Click(object sender, EventArgs e)
    {
        decimal num = Convert.ToDecimal(TextBox18.Text);

        int a=bom.Update_UnitChange(new Guid(UnitChangeID.Text), num);
        if (a == 1)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功！')",
                true);
            GridView9.DataSource = bom.Query_MAllUnit(new Guid(Label38.Text));
            GridView9.DataBind();
            Panel55.Visible = false;
            GridView3.DataSource = bom.Query_BOMDetail(new Guid(Label3.Text));
            GridView3.DataBind();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('操作失败！')",
                true);
            GridView9.DataSource = bom.Query_MAllUnit(new Guid(Label38.Text));
            GridView9.DataBind();
            Panel55.Visible = false;
            UpdatePanel5.Update();
        }

    }
    protected void GridView9_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Guid id = new Guid(e.CommandArgument.ToString());
            UnitChangeID.Text = id.ToString();
            TextBox11.Text = row.Cells[2].Text;
            Panel51.Visible = false;
            Panel52.Visible = false;
            Panel55.Visible = true;
            Panel53.Visible = false;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
    }

    protected void CloseAddUnit_Click(object sender, EventArgs e)
    {
        Panel53.Visible = false;
        UpdatePanel5.Update();
    }
    protected void CloseUnitCheck_Click(object sender, EventArgs e)
    {
        Panel54.Visible = false;
        UpdatePanel5.Update();
    }
    protected void GridView9_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          
            if (e.Row.Cells[3].Text=="是")
            {
                e.Row.Cells[4].Enabled = false;
                e.Row.Cells[4].Text="";

            }
          
            
        }
    }
    protected void closehistory_Click(object sender, EventArgs e)
    {
        Panel10.Visible = false;
        UpdatePanel10.Update();
    }
}
    