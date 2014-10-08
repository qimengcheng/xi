using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Laputa_DefectProduct : Page
{
    DefectProduct dp = new DefectProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "问题产品"; 

        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem("所有原因", "所有原因"));//增加Item
            SqlDataReader myReader = dp.Query_DefectReason();
            while (myReader.Read())
            {
                DropDownList1.Items.Add(new ListItem(myReader["PO_Name"].ToString(), myReader["PO_ID"].ToString()));//增加Item
            }
            GridView1.DataSource = dp.Query_DefectProduct();
            GridView1.DataBind();
            UpdatePanel2.Update();
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            Panel14.Visible = false;
            Panel15.Visible = false;
            try
            {
                if (!Session["UserRole"].ToString().Contains("问题产品管理"))
                {
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[16].Visible = false;
                    GridView1.Columns[17].Visible = false;
                    AddDefectProduct.Visible = false;

                    if (!Session["UserRole"].ToString().Contains("问题产品审核"))
                    {
                        GridView1.Columns[15].Visible = false;
                      
                    }
                    else if (!Session["UserRole"].ToString().Contains("问题产品跟踪"))
                    {
                        GridView1.Columns[14].Visible = false;
                    }
                    else if (!Session["UserRole"].ToString().Contains("问题产品"))
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                    
                }

            }
            catch
            {

                Response.Redirect("~/Default.aspx");
            }
            if (Request.QueryString["state"] == null)
            {
                state.Text = "look";
            }
            else
            {
                state.Text = Request.QueryString["state"];
            }
            string pstate = state.Text;
            if (pstate == "look")
            {
                Title = "问题产品查看";

                GridView1.Columns[10].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[14].Visible = false;
                GridView1.Columns[15].Visible = false;
                GridView1.Columns[16].Visible = false;
                GridView1.Columns[17].Visible = false;
                AddDefectProduct.Visible = false;



            }
            if (pstate == "track")
            {
                Title = "问题产品跟踪";

                GridView1.Columns[10].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[15].Visible = false;
                GridView1.Columns[16].Visible = false;
                GridView1.Columns[17].Visible = false;
                AddDefectProduct.Visible = false;



            }
            if (pstate == "audit")
            {
                Title = "问题产品审核";
                GridView1.Columns[10].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[14].Visible = false;
                GridView1.Columns[16].Visible = false;
                GridView1.Columns[17].Visible = false;
                AddDefectProduct.Visible = false;



            }
            if (pstate == "manage")
            {
                Title = "问题产品管理";
                GridView1.Columns[14].Visible = false;
                GridView1.Columns[15].Visible = false;



            }
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string type = TextBox1.Text;
        string cra = TextBox2.Text;
        string people = TextBox3.Text;
        DateTime a5 = new DateTime();
        DateTime a6 = new DateTime();
        if (TextBox5.Text == "")
        {
            a5 = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        else
        {
            try
            {
                a5 = Convert.ToDateTime(TextBox5.Text);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('时间格式错误！')", true);
            }
        }
        if (TextBox6.Text == "")
        {
            a6 = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }
        else
        {
            try
            {
                a6 = Convert.ToDateTime(TextBox6.Text);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('时间格式错误！')", true);
            }

        }

        string res = DropDownList1.SelectedItem.Text;
        string state = DropDownList2.SelectedItem.Text;
        if (GridView1 != null)
        {
            GridView1.DataSource = dp.Query_DefectProduct(type, cra, people, a5, a6, state, res);
            GridView1.DataBind();
        }
        Panel2.Visible = true;
        GridView1.Enabled = true;
        GridView1.SelectedIndex = -1;
        UpdatePanel2.Update();
        Panel2.Visible = true;

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
        string type = TextBox1.Text;
        string cra = TextBox2.Text;
        string people = TextBox3.Text;
        DateTime a5 = new DateTime();
        DateTime a6 = new DateTime();
        if (TextBox5.Text == "")
        {
            a5 = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        else
        {
            try
            {
                a5 = Convert.ToDateTime(TextBox5.Text);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('时间格式错误！')", true);
            }
        }
        if (TextBox6.Text == "")
        {
            a6 = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }
        else
        {
            try
            {
                a6 = Convert.ToDateTime(TextBox6.Text);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('时间格式错误！')", true);
            }

        }

        string res = DropDownList1.SelectedItem.Text;
        string state = DropDownList2.SelectedItem.Text;
        if (GridView1 != null)
        {
            GridView1.DataSource = dp.Query_DefectProduct(type, cra, people, a5, a6, state, res);
            GridView1.DataBind();
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "setorder")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            GridView1.SelectedIndex = row.RowIndex;
            PPID.Text = e.CommandArgument.ToString();
            Panel9.Visible = true;
            Panel10.Visible = true;

            GridView4.DataSource = dp.Query_ConnectedWorkOrder(new Guid(PPID.Text));
            GridView4.DataBind();
            GridView5.DataSource = dp.Query_WorkOrder(TextBox20.Text);
            GridView5.DataBind();
            UpdatePanel9.Update();
            UpdatePanel10.Update();


        }

        if (e.CommandName == "getorder")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            PPID.Text = e.CommandArgument.ToString();
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel12.Visible = true;
            GridView9.DataSource = dp.Query_ConnectedWorkOrder(new Guid(PPID.Text));
            GridView9.DataBind();
            UpdatePanel12.Update();
            UpdatePanel10.Update();
            UpdatePanel9.Update();


        }
        if (e.CommandName == "setview")
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            PPID.Text = e.CommandArgument.ToString();
            DropDownList3.Items.Clear();

            SqlDataReader myReader = dp.Query_CapableDep(new Guid(PPID.Text));

            SqlDataReader myReader2 = dp.Query_CapableDepDone(new Guid(PPID.Text));


            while (myReader.Read())
            {
                string a = myReader["BDOS_Name"].ToString();

                if (Session["Department"].ToString().Contains(myReader["BDOS_Name"].ToString()))
                {
                    DropDownList3.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["PPDS_ID"].ToString()));//增加Item
                }
            }




            while (myReader2.Read())
            {

                ListItem li = DropDownList3.Items.FindByText(myReader2["BDOS_Name"].ToString());
                DropDownList3.Items.Remove(li);

            }
            if (DropDownList3.Items.Count > 0)
            {
                Panel11.Visible = true;
                UpdatePanel11.Update();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('处理意见已填写或您没有相应的权限！')", true);
            }


        }
        if (e.CommandName == "getview")
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            PPID.Text = e.CommandArgument.ToString();
            GridView10.DataSource = dp.GetAuditSuggest(new Guid(PPID.Text));
            GridView10.DataBind();
            Panel15.Visible = true;
            UpdatePanel15.Update();
        }
        if (e.CommandName == "track")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            PPID.Text = e.CommandArgument.ToString();

            Panel13.Visible = true;
            Panel14.Visible = false;
            Panel15.Visible = false;

            UpdatePanel13.Update();
            UpdatePanel14.Update();
            UpdatePanel15.Update();

        }
        if (e.CommandName == "audit")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            PPID.Text = e.CommandArgument.ToString();
            GridView8.DataSource = dp.GetAuditSuggest(new Guid(PPID.Text));
            GridView8.DataBind();
            Panel14.Visible = true;
            UpdatePanel14.Update();
        }
        if (e.CommandName == "mod")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            switchlabel.Text = "修改";
            PPID.Text = e.CommandArgument.ToString();
            Panel3.Visible = true;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "del")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            PPID.Text = e.CommandArgument.ToString();
            dp.Delete_DefectProduct(new Guid(PPID.Text));
            GridView1.DataSource = dp.Query_DefectProduct();

            GridView1.DataBind();
            Panel4.Visible = false;
            Panel10.Visible = false;
            Panel14.Visible = false;
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel10.Update();
            UpdatePanel14.Update();
        }


    }

    protected void Button6_Click(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void SearchType_Click(object sender, EventArgs e)
    {
        string name = TextBox21.Text;
        GridView2.DataSource = dp.Query_ProType(name);
        GridView2.DataBind();
        UpdatePanel4.Update();

    }
    protected void SearchCra_Click(object sender, EventArgs e)
    {
        string name = TextBox24.Text;
        GridView7.DataSource = dp.Query_DefectType(name);
        GridView7.DataBind();
        UpdatePanel7.Update();
    }
    protected void ChooseDepartment_Click(object sender, EventArgs e)
    {
        Panel6.Visible = true;
        GridView3.DataSource = dp.Query_BDOS("%");
        GridView3.DataBind();
        Label27.Text = "未选择";
        depid.Text = "depid";
        UpdatePanel6.Update();
    }
    protected void ChooseType_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        GridView2.DataSource = dp.Query_ProType("%");
        GridView2.DataBind();
        UpdatePanel4.Update();
    }
    protected void ChooseCra_Click(object sender, EventArgs e)
    {
        Panel5.Visible = true;
        GridView6.DataSource = dp.Query_PBC("%");
        GridView6.DataBind();
        UpdatePanel5.Update();
    }
    protected void ChooseDefectType_Click(object sender, EventArgs e)
    {
        Panel7.Visible = true;
        GridView7.DataSource = dp.Query_DefectType("%");
        GridView7.DataBind();
        UpdatePanel7.Update();
    }
    protected void AddDefectType_Click(object sender, EventArgs e)
    {
        Panel8.Visible = true;
        UpdatePanel8.Update();
        TextBox31.Text = "";
    }
    protected void ChooseWorkOrder_Click(object sender, EventArgs e)
    {
        if (TextBox9.Text==""||TextBox11.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (Label1.Text != "未选择" && Label3.Text != "未选择" && Label5.Text != "未选择" && Label27.Text != "未选择")
        {
            var num = Decimal.Parse(TextBox9.Text);
            var description = TextBox11.Text;
            var type = new Guid(typeid.Text);
            var cra = new Guid(craid.Text);
            var po = new Guid(poid.Text);
            var dep = depid.Text;
            if (switchlabel.Text == "新增")
            {

                try
                {
                    var ppidGuid = dp.Insert_DefectProduct(type, cra, po, dep, num, description,
                        Session["UserName"].ToString());
                    Panel9.Visible = true;
                    Panel10.Visible = true;
                    Panel3.Visible = false;
                    string[] depart = dep.Split(',');
                    foreach (string s in depart)
                    {
                        dp.Insert_DefectDep(ppidGuid, s);

                    }
                    PPID.Text = ppidGuid.ToString();
                    Panel9.Visible = true;
                    Panel10.Visible = true;
                    GridView5.DataSource = dp.Query_WorkOrder(TextBox20.Text);
                    GridView5.DataBind();
                    UpdatePanel9.Update();
                    UpdatePanel10.Update();
                    GridView1.Enabled = false;
                }
                catch (Exception exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！')", true);
                }
            }

            else
            {
                try
                {
                    Guid pp = new Guid(PPID.Text);
                    dp.Update_DefectProduct(pp, type, cra, po, dep, num, description,
                        Session["UserName"].ToString());
                    Panel9.Visible = true;
                    Panel10.Visible = true;
                    Panel3.Visible = false;
                    string[] depart = dep.Split(',');
                    int a = dp.ClearDefectDep(pp);
                    foreach (string s in depart)
                    {
                        dp.Insert_DefectDep(pp, s);

                    }
                    PPID.Text = pp.ToString();
                    Panel9.Visible = true;
                    Panel10.Visible = true;
                    GridView5.DataSource = dp.Query_WorkOrder(TextBox20.Text);
                    GridView5.DataBind();
                    UpdatePanel9.Update();
                    UpdatePanel10.Update();
                    GridView1.Enabled = false;
                }
                catch (Exception exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('更新失败！')", true);
                }
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('还有未选择的项目呢！')", true);
        }

    }
    protected void CloseSearchType_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
    }
    protected void CloseSearchDefectType_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
    }
    protected void SearchDepartment_Click(object sender, EventArgs e)
    {
        string name = TextBox8.Text;
        GridView3.DataSource = dp.Query_BDOS(name);
        GridView3.DataBind();
        UpdatePanel6.Update();
    }
    protected void CloseSearchCra_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
    }
    protected void CloseSearchDepartment_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
    }

    protected void CloseAddDefectProduct_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel2.Visible = true;
        GridView1.DataSource = dp.Query_DefectProduct();
        GridView1.DataBind();
        UpdatePanel2.Update();
        UpdatePanel3.Update();

    }
    protected void CloseAddDefectType_Click(object sender, EventArgs e)
    {
        Panel8.Visible = false;
    }
    protected void CloseWorkOrder_Click(object sender, EventArgs e)
    {
        Panel10.Visible = false;
    }

    protected void CloseProcessSuggestion_Click(object sender, EventArgs e)
    {
        Panel11.Visible = false;
        UpdatePanel11.Update();
    }
    protected void AddDefectTypeSummit_Click(object sender, EventArgs e)
    {
        string po = TextBox31.Text;
        dp.Insert_Defecttype(po);
        Panel8.Visible = false;
        GridView7.DataSource = dp.Query_DefectType("%");
        GridView7.DataBind();
        UpdatePanel7.Update();
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
        GridView2.DataSource = dp.Query_ProType(TextBox21.Text);
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;



            Label1.Text = row.Cells[1].Text;
            typeid.Text = e.CommandArgument.ToString();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }
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
        GridView6.DataSource = dp.Query_PBC(TextBox18.Text);
        GridView6.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView6.PageCount ? GridView6.PageCount - 1 : newPageIndex;
        GridView6.PageIndex = newPageIndex;
        GridView6.DataBind();

    }
    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;



            Label3.Text = row.Cells[1].Text;
            craid.Text = e.CommandArgument.ToString();
            Panel5.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel5.Update();
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
        GridView3.DataSource = dp.Query_DefectType(TextBox24.Text);
        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Label27.Text = row.Cells[1].Text;
            depid.Text = e.CommandArgument.ToString();
            Panel6.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel6.Update();
        }
    }
    protected void GridView7_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView7.BottomPagerRow;


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
        GridView7.DataSource = dp.Query_DefectType(TextBox24.Text);
        GridView7.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView7.PageCount ? GridView7.PageCount - 1 : newPageIndex;
        GridView7.PageIndex = newPageIndex;
        GridView7.DataBind();
    }
    protected void GridView7_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Label5.Text = row.Cells[1].Text;
            poid.Text = e.CommandArgument.ToString();
            Panel7.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel7.Update();
        }
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
        GridView4.DataSource = dp.Query_ConnectedWorkOrder(new Guid(PPID.Text));
        GridView4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }
    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "shanchu")
        {
            Guid wo = new Guid(e.CommandArgument.ToString());
            int a = dp.Delete_WorkOrder(wo);
            GridView4.DataSource = dp.Query_ConnectedWorkOrder(new Guid(PPID.Text));
            GridView4.DataBind();
            UpdatePanel9.Update();
        }
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
        GridView5.DataSource = dp.Query_WorkOrder(TextBox20.Text);
        GridView5.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView5.PageCount ? GridView5.PageCount - 1 : newPageIndex;
        GridView5.PageIndex = newPageIndex;
        GridView5.DataBind();
    }
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            Guid wo = new Guid(e.CommandArgument.ToString());
            Guid pp = new Guid(PPID.Text);
            dp.Insert_WorkOrder(wo, pp);
            GridView4.DataSource = dp.Query_ConnectedWorkOrder(new Guid(PPID.Text));
            GridView4.DataBind();
            UpdatePanel9.Update();
            UpdatePanel10.Update();
        }



    }
    protected void GridView8_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView8.BottomPagerRow;


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
        GridView8.DataSource = dp.GetAuditSuggest(new Guid(PPID.Text));
        GridView8.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView8.PageCount ? GridView8.PageCount - 1 : newPageIndex;
        GridView8.PageIndex = newPageIndex;
        GridView8.DataBind();
    }
    protected void GridView8_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void SearhCra_Click(object sender, EventArgs e)
    {
        string name = TextBox18.Text;
        GridView6.DataSource = dp.Query_PBC(name);
        GridView6.DataBind();
        UpdatePanel5.Update();
    }
    protected void SearchWorkOrder_Click(object sender, EventArgs e)
    {
        string name = TextBox20.Text;
        GridView5.DataSource = dp.Query_WorkOrder(name);
        GridView5.DataBind();
        UpdatePanel10.Update();
    }
    protected void AddDefectProduct_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        Label1.Text = "未选择";
        Label3.Text = "未选择";
        Label5.Text = "未选择";
        Label27.Text = "未选择";
        switchlabel.Text = "新增";
        TextBox11.Text = "";

        Panel2.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel3.Update();
    }
    protected void SummitWorkOrder_Click(object sender, EventArgs e)
    {
        int a = dp.Update_State_Setup(new Guid(PPID.Text));
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert",
            a == 1 ? "alert('提交成功！')" : "alert('提交失败!')", true);
        Panel9.Visible = false;
        Panel10.Visible = false;
        GridView1.DataSource = dp.Query_DefectProduct(new Guid(PPID.Text));
        GridView1.DataBind();
        Panel2.Visible = true;
        UpdatePanel2.Update();
        UpdatePanel9.Update();
        UpdatePanel10.Update();
        GridView1.Enabled = true;

    }

    protected void SummitResault_Click(object sender, EventArgs e)
    {
        Guid ppGuid = new Guid(PPID.Text);
        string result = TextBox7.Text;
        dp.Insert_Result(ppGuid, result);
        Panel13.Visible = false;
        GridView1.DataSource = dp.Query_DefectProduct(ppGuid);
        GridView1.DataBind();
        TextBox7.Text = "";
        UpdatePanel13.Update();
        UpdatePanel2.Update();
        UpdatePanel3.Update();
    }



    protected void SummitView_Click(object sender, EventArgs e)
    {
        Guid ppds = new Guid(DropDownList3.SelectedValue);
        string view = TextBox12.Text;
        int a = dp.Update_DepView(ppds, Session["UserName"].ToString(), view);
        if (a > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败！')", true);
        }
        Panel11.Visible = false;
        UpdatePanel11.Update();
        Panel11.Dispose();
        GridView1.DataSource = dp.Query_DefectProduct();
        GridView1.DataBind();
        UpdatePanel2.Update();


    }

    protected void SummitDepartment_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow myrow in GridView3.Rows)
        {
            CheckBox cb = (CheckBox)myrow.Cells[0].FindControl("CheckBox1");

            if (cb.Checked)
            {
                if (Label27.Text == "未选择")
                {
                    Label27.Text = myrow.Cells[2].Text;
                    UpdatePanel3.Update();
                }
                else
                {
                    Label27.Text += "," + myrow.Cells[2].Text;
                    UpdatePanel3.Update();
                }
                if (depid.Text == "depid")
                {
                    depid.Text = myrow.Cells[1].Text;
                    UpdatePanel3.Update();
                }
                else
                {
                    depid.Text += "," + myrow.Cells[1].Text;
                    UpdatePanel3.Update();
                }

            }
            GridView3.Dispose();

            Panel6.Visible = false;
        }


    }
    protected void resetchoose_Click(object sender, EventArgs e)
    {
        Label27.Text = "未选择";
        depid.Text = "depid";
        GridView3.Dispose();
        UpdatePanel6.Update();
        UpdatePanel3.Update();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.Cells[5].Text)
                {
                    case "等待选择相关随工单":

                        e.Row.Cells[12].Enabled = false;
                        e.Row.Cells[13].Enabled = false;
                        e.Row.Cells[14].Enabled = false;
                        e.Row.Cells[15].Enabled = false;
                        e.Row.Cells[12].ToolTip = "所有相关部门都填写意见后才可以填写处理意见";
                        e.Row.Cells[13].ToolTip = "填写处理意见之后才可以查看";
                        e.Row.Cells[14].ToolTip = "处理中时才可以填写跟踪结果";
                        e.Row.Cells[15].Enabled = false;
                        break;
                    case "审核驳回":
                        e.Row.Cells[10].Enabled = false;
                        e.Row.Cells[11].Enabled = true;
                        e.Row.Cells[12].Enabled = false;
                        e.Row.Cells[13].Enabled = false;
                        e.Row.Cells[15].Enabled = false;
                        e.Row.Cells[14].Enabled = false;
                        break;
                    case "审核通过":
                        e.Row.Cells[10].Enabled = false;
                        e.Row.Cells[11].Enabled = true;
                        e.Row.Cells[12].Enabled = false;
                        e.Row.Cells[14].Enabled = false;
                        e.Row.Cells[15].Enabled = false;
                        e.Row.Cells[16].Enabled = false;
                        e.Row.Cells[17].Enabled = false;
                        break;

               
                    case "等待填写处理意见":
                        e.Row.Cells[10].Enabled = false;
                        e.Row.Cells[14].Enabled = false;
                        e.Row.Cells[15].Enabled = false;
                        e.Row.Cells[16].Enabled = false;
                        e.Row.Cells[17].Enabled = false;
                        e.Row.Cells[14].ToolTip = "处理中时才可以填写跟踪结果";
                        e.Row.Cells[15].ToolTip = "跟踪结果填写后才可以审核";
                        e.Row.Cells[16].ToolTip = "提交前才可以编辑";
                        e.Row.Cells[17].ToolTip = "提交前和审核驳回才可以删除";
                        break;
                    case "等待填写跟踪结果":
                        e.Row.Cells[10].Enabled = false;
                        e.Row.Cells[12].Enabled = false;
                        e.Row.Cells[15].Enabled = false;
                        e.Row.Cells[16].Enabled = false;
                        e.Row.Cells[17].Enabled = false;
                        e.Row.Cells[12].ToolTip = "等待填写处理意见时才可以填写处理意见";
                        e.Row.Cells[15].ToolTip = "跟踪结果填写后才可以审核";
                        e.Row.Cells[16].ToolTip = "提交前才可以编辑";
                        e.Row.Cells[17].ToolTip = "提交前和审核驳回才可以删除";
                        break;
                    case "等待审核":
                        e.Row.Cells[10].Enabled = false;
                        e.Row.Cells[12].Enabled = false;
                        e.Row.Cells[14].Enabled = false;
                        e.Row.Cells[16].Enabled = false;
                        e.Row.Cells[17].Enabled = false;
                        e.Row.Cells[12].ToolTip = "等待填写处理意见时才可以填写处理意见";
                        e.Row.Cells[14].ToolTip = "跟踪结果已经填写";
                        e.Row.Cells[16].ToolTip = "提交前才可以编辑";
                        e.Row.Cells[17].ToolTip = "提交前和审核驳回才可以删除";
                        break;
                    default:
                        e.Row.Cells[10].Enabled = false;

                        break;
                }

                switch (e.Row.Cells[8].Text)
                {


                    case "&nbsp;":
                        e.Row.Cells[14].Enabled = true;
                        break;
                    default:
                        e.Row.Cells[14].Enabled = false;
                        break;
                }
                if (e.Row.Cells[8].Text.Length > 10)
                {
                    e.Row.Cells[8].ToolTip = e.Row.Cells[8].Text;
                    e.Row.Cells[8].Text = e.Row.Cells[8].Text.Substring(1, 10);

                }
                if (e.Row.Cells[4].Text.Length > 10)
                {
                    e.Row.Cells[4].ToolTip = e.Row.Cells[4].Text;
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text.Substring(1, 10);

                }
                if (!Session["UserRole"].ToString().Contains("问题产品审核"))
                {
                    e.Row.Cells[14].Visible = false;
                }
                if (!Session["UserRole"].ToString().Contains("问题产品跟踪"))
                {
                    e.Row.Cells[13].Visible = false;
                }
            }
        }
        catch   
        {
            Response.Redirect("/Default.aspx");
        }

    }



    protected void SummitAuditPass_Click(object sender, EventArgs e)
    {
        dp.Update_State_AuditPass(new Guid(PPID.Text));
        Panel14.Visible = false;
        UpdatePanel14.Update();
        GridView1.DataSource = dp.Query_DefectProduct(new Guid(PPID.Text));
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
    protected void CloseAudit_Click(object sender, EventArgs e)
    {
        Panel14.Visible = false;
        UpdatePanel14.Update();
    }
    protected void SummitAuditReject_Click(object sender, EventArgs e)
    {
        dp.Update_State_AuditReject(new Guid(PPID.Text));
        Panel14.Visible = false;
        UpdatePanel14.Update();
        GridView1.DataSource = dp.Query_DefectProduct(new Guid(PPID.Text));
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void CloseLookView_Click(object sender, EventArgs e)
    {
        Panel15.Visible = false;
        UpdatePanel15.Update();
    }
    protected void CloseWorkOrderView_Click(object sender, EventArgs e)
    {
        Panel12.Visible = false;
        UpdatePanel12.Update();
    }
    protected void GridView10_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView10.BottomPagerRow;


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
        GridView10.DataSource = dp.GetAuditSuggest(new Guid(PPID.Text));
        GridView10.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView10.PageCount ? GridView10.PageCount - 1 : newPageIndex;
        GridView10.PageIndex = newPageIndex;
        GridView10.DataBind();
    }
    protected void GridView9_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView9.BottomPagerRow;


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
        GridView9.DataSource = dp.Query_ConnectedWorkOrder(new Guid(PPID.Text));
        GridView9.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView9.PageCount ? GridView9.PageCount - 1 : newPageIndex;
        GridView9.PageIndex = newPageIndex;
        GridView9.DataBind();
    }
    protected void CloseTrack_Click(object sender, EventArgs e)
    {
        Panel13.Visible = false;

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
        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("所有原因"));
        DropDownList1.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList1.Items.FindByText("所有类型"));
        GridView1.DataSource = dp.Query_DefectProduct();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
}