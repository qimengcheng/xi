using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_WMP : Page
{
    WMPD wp = new WMPD();
    static private Guid Salesid;
    static Guid MWPid;
    private string name;
    private string model;
    static private int year;
    static private int month;
                
    
   

    protected void Page_Load(object sender, EventArgs e)
    {
       

        try
        {
            if (!Session["UserRole"].ToString().Contains("材料周计划制定"))
            {
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = false;
                if (!Session["UserRole"].ToString().Contains("材料周计划查看"))
                {
                    Response.Redirect("~/Default.aspx");

                }
            }
        }
        catch 
        {
            
           Response.Redirect("~/Default.aspx");
        }
       

        if(!Page.IsPostBack)
        {
            int maxyear;
            try
            {
                maxyear = wp.GetYear();
            }
            catch
            {
                maxyear = 2020;

            }
            int year = 2012;
            while (year <= maxyear+1)
            {
                DropDownList1.Items.Add(year.ToString());
                year++;
            }
            syear.Text = DropDownList1.SelectedValue;
            smonth.Text = DropDownList2.SelectedValue;
            sweek.Text = DropDownList3.SelectedValue;
            sstate.Text = DropDownList4.SelectedValue;
            Button4.Attributes.Add("onclick", "if (typeof(Page_ClientValidate) == 'function') {if(Page_ClientValidate()){return confirm('确定提交材料周计划吗？提交后不能更改！')}else{return false;}}");
            
       
        }
        if (Request.QueryString["linenum"] == null)
        {
            Linenum.Text = "0";
        }
        else
        {
            Linenum.Text = Request.QueryString["linenum"];
        }
        if (Request.QueryString["state"] == null)
        {
            Labelstate.Text = "look";
        }
        else
        {
            Labelstate.Text = Request.QueryString["state"];
        }
        string pstate = Labelstate.Text;
        if (pstate == "look")
        {
            Title = "材料周计划查看";

            GridView1.Columns[12].Visible = false;
            GridView1.Columns[11].Visible = false;
     
        }
        if (pstate == "make")
        {
            Title = "材料周计划制定";

            GridView1.Columns[12].Visible = false;
        }
        if (pstate == "audit")
        {
            Title = "材料周计划审核";

            GridView1.Columns[11].Visible = false;

        }
        GridView1.DataSource = wp.Query_WPlan(Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
    }

    #region 表命令
        #region 表1
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            Button4.Visible = false;
            Panel3.Visible = true;
            Guid pmpid = new Guid(e.CommandArgument.ToString());
            Label14.Text = pmpid.ToString();
            if (row.Cells[9].Text=="已建立")
            {
                GridView2.DataSource = wp.Query_WPlanDetail(pmpid);
            GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = wp.Query_WPlanDetailFlash(pmpid);
            GridView2.DataBind();
            }
            
            Label10.Text = "查看";
            Label11.Text = row.Cells[2].Text;
            Label12.Text = row.Cells[3].Text;
            Labelweek.Text = row.Cells[4].Text;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel31.Visible = false;
            GridView2.Columns[12].Visible = false;


            GridView2.SelectedIndex = -1;






        }
        if (e.CommandName == "Make")
        {

            TextBox6.Enabled = true;
            TextBox7.Enabled = true;
            Panel31.Visible = true;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            if (row.Cells[9].Text == "未建立")
            {
                Label10.Text = "制定";
                Label11.Text = row.Cells[2].Text;
                Label12.Text = row.Cells[3].Text;
                Labelweek.Text = row.Cells[4].Text;
                Panel3.Visible = true;
                Salesid = new Guid(e.CommandArgument.ToString());
               
                Label13.Text = Salesid.ToString();
                Button4.Visible = false;
                TextBox6.Text = "";
                TextBox7.Text = "";
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                int year = int.Parse(Label11.Text);
                int month = int.Parse(Label12.Text);
                string man = Session["UserName"].ToString();
                string makedate = DateTime.Now.ToString("yyyy-MM-dd");
                GridView2.Columns[12].Visible = true;
                Guid sid = new Guid(Label13.Text);
                Guid mwpid = wp.Insert_PWP(sid, year, month, man, makedate, null, null,Convert.ToInt32(Linenum.Text));
                Label14.Text = mwpid.ToString();
                wp.UpdatePlanState(mwpid);
                GridView2.DataSource = wp.Query_WPlanDetail(new Guid(Label14.Text));
                GridView2.DataBind();
                GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text,Convert.ToInt32(Linenum.Text));
                GridView1.DataBind();
                GridView2.SelectedIndex = -1;
            }
            else
            {
                Button4.Visible = false;
                Panel3.Visible = true;
                Guid pwpid = new Guid(row.Cells[1].Text);
                Label14.Text = pwpid.ToString();
                GridView2.DataSource = wp.Query_WPlanDetail(pwpid);
                GridView2.DataBind();
                Label10.Text = "查看";
                Label11.Text = row.Cells[2].Text;
                Label12.Text = row.Cells[3].Text;
                Labelweek.Text = row.Cells[4].Text;
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;

                Button4.Visible = false;
                Panel31.Visible = true;
                GridView2.Columns[9].Visible = true;
                GridView2.SelectedIndex = -1;
            }
        }
        if (e.CommandName == "Audit")
        {
            GridView2.Columns[12].Visible = false;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            MWPid = new Guid(e.CommandArgument.ToString());

            GridView2.DataSource = wp.Query_WPlanDetail(MWPid);
            GridView2.DataBind();
            GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text, Convert.ToInt32(Linenum.Text));
            Panel4.Visible = false;
            Panel5.Enabled = false;
            Panel6.Enabled = false;
            Panel7.Enabled = false;
            Panel31.Visible = false;
            Panel32.Visible = false;
            Panel3.Visible = false;

            Button4.Visible = false;
            if (Session["UserRole"].ToString().Contains("材料周计划审核生产部"))
            { Panel5.Enabled = true; }
            if (Session["UserRole"].ToString().Contains("材料周计划审核财务部"))
            { Panel6.Enabled = true; }
            if (Session["UserRole"].ToString().Contains("材料周计划审核副总"))
            {
                Panel7.Enabled = true;
            }
            Panel5.Visible = true;
            Panel6.Visible = true;
            Panel7.Visible = true;
            year = int.Parse(row.Cells[2].Text);
            month = int.Parse(row.Cells[3].Text);
            PWPAudit au = new PWPAudit();
            au = wp.Query_Audit(MWPid);
            Label1.Text = au.PWP_MPDepSignMan1;
            Label2.Text = au.PWP_MPDepSignTime1;
            if (Label2.Text != "")
            {
                Label2.Text = Convert.ToDateTime(Label2.Text).ToString("yyyy-MM-dd HH:mm");
            }

            TextBox3.Text = au.PWP_MPDepSignSuggestion1;
            Label3.Text = au.PWP_MPDepSignResult1;
            Label4.Text = au.PWP_MFDepSignMan1;
            Label5.Text = au.PWP_MFDepSignTime1;
            if (Label5.Text != "")
            {
                Label5.Text = Convert.ToDateTime(Label5.Text).ToString("yyyy-MM-dd HH:mm");
            }

            Label6.Text = au.PWP_MFDepSignResult1;
            TextBox4.Text = au.PWP_MFDepSignSuggestion1;
            Label7.Text = au.PWP_MBossSignMan1;
            Label8.Text = au.PWP_MBossSignTime1;
            if (Label8.Text != "")
            {
                Label8.Text = Convert.ToDateTime(Label8.Text).ToString("yyyy-MM-dd HH:mm");
            }
            Label9.Text = au.PWP_MBossSignResult1;
            TextBox5.Text = au.PWP_MBossSignSuggestion1;
            if (Label3.Text == "")
            {
                Label3.Text = "尚未会签";
                P1.Visible = true;
                TextBox3.Enabled = true;
            }
            else
            {
                P1.Visible = false;
                TextBox3.Enabled = false;
            }
            if (Label3.Text == "审核驳回")
            {
                Label3.ForeColor = Color.FromName("#f64a80");

            }
            if (Label3.Text == "审核通过")
            {
                Label3.ForeColor = Color.FromName("#34b2e1");

            }

            if (Label6.Text == "")
            {
                Label6.Text = "尚未会签";
                P2.Visible = true;
                TextBox4.Enabled = true;
            }
            else
            {
                P2.Visible = false;
                TextBox4.Enabled = false;
            }
            if (Label6.Text == "审核驳回")
            {
                Label6.ForeColor = Color.FromName("#f64a80");

            }
            if (Label6.Text == "审核通过")
            {
                Label6.ForeColor = Color.FromName("#34b2e1");

            }
            if (Label9.Text == "")
            {
                Label9.Text = "尚未会签";
                P3.Visible = true;
                TextBox5.Enabled = true;
            }
            else
            {
                P3.Visible = false;
                TextBox5.Enabled = false;
            }
            if (Label9.Text == "审核驳回")
            {
                Label9.ForeColor = Color.FromName("#f64a80");

            }
            if (Label9.Text == "审核通过")
            {
                Label9.ForeColor = Color.FromName("#34b2e1");

            }
        }

    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {

        GridView1.Columns[0].Visible = false;




    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string a = e.Row.Cells[8].Text;
            if (e.Row.Cells[9].Text == "未建立")
            {
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[12].Enabled = false;
            }
            else if (e.Row.Cells[9].Text == "已建立")
            {
                e.Row.Cells[12].Enabled = false;
            }
            else if (e.Row.Cells[9].Text == "审核驳回")
            {
                e.Row.Cells[11].Enabled = true;
            }
            else
            { 
                e.Row.Cells[11].Enabled = false; 
            }
        }
        catch
        {


        }

    }

        #endregion
        #region 表2

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Source")
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            Panel32.Visible = false;
            Guid mid = new Guid(e.CommandArgument.ToString());
            Label17.Text = mid.ToString();
            Guid mwpid = new Guid(Label14.Text);
            
            GridView3.DataSource = wp.Query_WPlanDetail_Type(int.Parse(Label11.Text), int.Parse(Label12.Text), int.Parse(Labelweek.Text), mid,mwpid);
            GridView3.DataBind();
            Label30.Text = row.Cells[1].Text;
            Label31.Text = row.Cells[2].Text;

            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;


        }
        if (e.CommandName == "Modify")
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            Panel32.Visible = true;
            Guid mid = new Guid(e.CommandArgument.ToString());
            Label17.Text = mid.ToString();

            Label20.Text = row.Cells[1].Text;
            Label21.Text = row.Cells[2].Text;
            Label22.Text = row.Cells[3].Text;
            TextBox8.Text = "";
            TextBoxNote.Text = "";
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
        }
    }
    #endregion
        #region 表3
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    #endregion
    #endregion
    #region 按钮事件
    protected void Button1_Click(object sender, EventArgs e)
    {

        syear.Text = DropDownList1.SelectedValue;
        smonth.Text = DropDownList2.SelectedValue;
        sweek.Text = DropDownList3.SelectedValue;
        sstate.Text = DropDownList4.SelectedValue;

        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text,Convert.ToInt32(Linenum.Text));
        DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text, Convert.ToInt32(Linenum.Text));
        GridView2.DataSource = wp.Query_WPlanDetail(MWPid);


    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        GridView3.DataSource = wp.Query_Material(name, model);
        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text,Convert.ToInt32(Linenum.Text));
        DataBind();

    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        if (TextBox8.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }

        Guid mid = new Guid(Label17.Text);
        Guid pmpid = new Guid(Label14.Text);
        decimal num = decimal.Parse(TextBox8.Text);
        string note = TextBoxNote.Text;
        wp.UpdatePWPDetail(pmpid, mid, num,note);
        Panel32.Visible = false;
        GridView2.DataSource = wp.Query_WPlanDetail(new Guid(Label14.Text));
        GridView2.DataBind();
    }

    protected void Button15_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView3.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView3.Rows[i].FindControl("CheckBox1");


            cbox.Checked = false;




        }

    }



    protected void Button16_Click(object sender, EventArgs e)
    {


    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox6.Text == "" || TextBox7.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        DateTime startdate = Convert.ToDateTime(TextBox6.Text);
        DateTime enddate = Convert.ToDateTime(TextBox7.Text);

        if (DateTime.Compare(startdate, enddate) > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('结束日期不能在开始日期之前！')", true);
        }
        else
        {
            int year = int.Parse(Label11.Text);
            int month = int.Parse(Label12.Text);
            string man = Session["UserName"].ToString();
            string makedate = DateTime.Now.ToString("yyyy-MM-dd");

            Guid mwpid = new Guid(Label14.Text);
            wp.Update_MWP(mwpid, startdate, enddate);
            
            GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text),
                sstate.Text, Convert.ToInt32(Linenum.Text));
            GridView1.DataBind();
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

    }

    protected void Button17_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Guid id = MWPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox3.Text;
        string res = "审核通过";
        string role = "生产部";
        wp.Update_PWPAudit(id, man, time, su, res, role);
        P1.Visible = false;
        TextBox3.Enabled = false;
        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text,Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('驳回时意见不能为空！')", true);
            return;
        }
        Guid id = MWPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox3.Text;
        string res = "审核驳回";
        string role = "生产部";
        wp.Update_PWPAudit(id, man, time, su, res, role);
        P1.Visible = false;
        TextBox3.Enabled = false;
        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text,Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Guid id = MWPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox4.Text;
        string res = "审核通过";
        string role = "财务部";
        wp.Update_PWPAudit(id, man, time, su, res, role);
        P2.Visible = false;
        TextBox4.Enabled = false;
        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text, Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('驳回时意见不能为空！')", true);
            return;
        }
        Guid id = MWPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox4.Text;
        string res = "审核驳回";
        string role = "财务部";
        wp.Update_PWPAudit(id, man, time, su, res, role);
        P2.Visible = false;
        TextBox4.Enabled = false;

        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text, Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Guid id = MWPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox5.Text;
        string res = "审核通过";
        string role = "副总";
        wp.Update_PWPAudit(id, man, time, su, res, role);
        P3.Visible = false;
        TextBox5.Enabled = false;

        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text, Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('驳回时意见不能为空！')", true);
            return;
        }
        Guid id = MWPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());
        string su = TextBox5.Text;
        string res = "审核驳回";
        string role = "副总";
        wp.Update_PWPAudit(id, man, time, su, res, role);
        P3.Visible = false;
        TextBox5.Enabled = false;
        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text, Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;

    }
    #endregion
    #region 分页绑定
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        GridView1.DataSource = wp.Query_WPlan(int.Parse(syear.Text), int.Parse(smonth.Text), int.Parse(sweek.Text), sstate.Text, Convert.ToInt32(Linenum.Text));
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
            GridViewRow pagerRow = theGrid.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp2");   // refer to the TextBox with the NewPageIndex value
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
        if (TextBox6.Text!="")
        {
            DateTime bg=Convert.ToDateTime(TextBox6.Text);
            theGrid.DataSource = wp.Query_WPlanDetail(new Guid(Label14.Text),bg);
            theGrid.DataBind();
        }
        else
        {
            theGrid.DataSource = wp.Query_WPlanDetail(new Guid(Label14.Text));
        theGrid.DataBind();
        }
       
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();

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

        GridView3.DataSource = wp.Query_Material(name, model);

        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }
    #endregion   
    


    
    

  
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    if (e.Row.Cells[10].Text == "0")
        //    {
        //        e.Row.BackColor = Color.FromArgb(100, 201, 233, 254);
        //        e.Row.Cells[10].ToolTip = "已被其他物料代替";
        //    }
        //}
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[7].Text.Length > 10)
            {
                e.Row.Cells[7].ToolTip = e.Row.Cells[7].Text;
                e.Row.Cells[7].Text = e.Row.Cells[7].Text.Substring(0, 10);

            }
        }
    }
    protected void Button15_Click1(object sender, EventArgs e)
    {
        if (TextBox6.Text == "" || TextBox7.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        DateTime startdate = Convert.ToDateTime(TextBox6.Text);
        DateTime enddate = Convert.ToDateTime(TextBox7.Text);

        if (DateTime.Compare(startdate, enddate) > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('结束日期不能在开始日期之前！')", true);
        }
        else
        {
            TextBox6.Enabled = false;
            TextBox7.Enabled = false;
            Button4.Visible = true;
            GridView2.DataSource = wp.Query_WPlanDetail(new Guid(Label14.Text),startdate);
            GridView2.DataBind();
        }
    }
}