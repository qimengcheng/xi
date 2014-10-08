using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.ServiceModel.Dispatcher;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;


public partial class Laputa_MMP : Page
{
    MMPD mp = new MMPD();

    private string state = null;
    static private Guid Salesid;
    static Guid MMPid;
    static DataSet ds = new DataSet();
    static DataTable dt = new DataTable();
    static private int syear = 999;
    static private int smonth = 999;




    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["UserRole"].ToString().Contains("材料月计划制定"))
            {
                GridView1.Columns[11].Visible = false;
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = false;
                if (!Session["UserRole"].ToString().Contains("材料月计划查看"))
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
            int maxyear;
            try
            {
                maxyear = mp.GetYear();
            }
            catch
            {
                maxyear = 2020;

            }
            int year = 2012;
            while (year <= maxyear + 1)
            {
                DropDownList1.Items.Add(year.ToString());
                year++;
            }
            Button4.Attributes.Add("onclick",
                "if (typeof(Page_ClientValidate) == 'function') {if(Page_ClientValidate()){return confirm('确定提交材料月计划吗？提交后不能更改！')}else{return false;}}");



        }
        if (Request.QueryString["state"] == null)
        {
            labelstate.Text = "look";
        }
        else
        {
            labelstate.Text = Request.QueryString["state"];
        }
        if (Request.QueryString["linenum"] == null)
        {
            Linenum.Text = "0";
        }
        else
        {
            Linenum.Text = Request.QueryString["linenum"];
        }
        string pstate = labelstate.Text;
        GridView1.DataSource = mp.Query_MPlan(Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        switch (pstate)
        {
            case "look":
                Title = "材料月计划查看";
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = false;
                GridView1.Columns[14].Visible = false;
                GridView2.Columns[12].Visible = false;
                break;
            case "make":
                Title = "材料月计划制定";
                GridView1.Columns[13].Visible = false;
                break;
            case "audit":
                Title = "材料月计划审核";
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[14].Visible = false;
                break;
            case "mklook":
                Title = "模块材料月计划查看";
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[13].Visible = false;
                GridView1.Columns[14].Visible = false;
                GridView2.Columns[12].Visible = false;
                break;
            case "mkmake":
                Title = "模块材料月计划制定";
                GridView1.Columns[13].Visible = false;
                break;
            case "mkaudit":
                Title = "模块材料月计划审核";
                GridView1.Columns[12].Visible = false;
                GridView1.Columns[14].Visible = false;
                break;
            
    }

}





    #region 表命令
    #region 表1
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {

        GridView1.Columns[0].Visible = false;

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
               GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            if (row.Cells[9].Text == "已建立")
            {

                GridView1.SelectedIndex = row.RowIndex;
                Button4.Visible = false;
                Panel3.Visible = true;
                Guid pmpid = new Guid(e.CommandArgument.ToString());
                Label14.Text = pmpid.ToString();
                GridView2.DataSource = mp.Query_MPlanDetail(pmpid);
                //GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
                GridView2.DataBind();
                Label10.Text = "查看";
                Label11.Text = row.Cells[2].Text;
                Label12.Text = row.Cells[3].Text;

                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                Panel31.Visible = false;
                GridView2.Columns[12].Visible = false;

                GridView2.SelectedIndex = -1;
            }
            else 
            {
                GridView1.SelectedIndex = row.RowIndex;
                Button4.Visible = false;
                Panel3.Visible = true;
                Guid pmpid = new Guid(e.CommandArgument.ToString());
                Label14.Text = pmpid.ToString();
                GridView2.DataSource = mp.Query_MPlanDetailFlash(pmpid);
                //GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
                GridView2.DataBind();
                Label10.Text = "查看";
                Label11.Text = row.Cells[2].Text;
                Label12.Text = row.Cells[3].Text;

                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                Panel31.Visible = false;
                GridView2.Columns[12].Visible = false;

                GridView2.SelectedIndex = -1;
            }







        }
        if (e.CommandName == "Make")
        {

            Panel31.Visible = true;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            if (row.Cells[9].Text == "未建立")
            {
                Label10.Text = "制定";
                Label11.Text = row.Cells[2].Text;
                Label12.Text = row.Cells[3].Text;
                Panel3.Visible = true;
                Salesid = new Guid(e.CommandArgument.ToString());
                Label13.Text = Salesid.ToString();
                Button4.Visible = true;
                TextBox6.Text = "";
                TextBox7.Text = "";
                string add;
                if (Label10.Text == "制定")
                {
                    add = "否";
                }
                else
                {
                    add = "是";
                }
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                int year = int.Parse(Label11.Text);
                int month = int.Parse(Label12.Text);
                string man = Session["UserName"].ToString();
                string makedate = DateTime.Now.ToString("yyyy-MM-dd");
                GridView2.Columns[11].Visible = true;
                GridView2.Columns[10].Visible = true;
                Guid sid = new Guid(Label13.Text);
                Guid pmpid = mp.Insert_PMP(sid, year, month, man, makedate, null, null, add,Convert.ToInt32(Linenum.Text));
                Label14.Text = pmpid.ToString();
                mp.UpdatePlanState(pmpid);

                GridView2.DataSource = mp.Query_MPlanDetail(new Guid(Label14.Text));
                GridView2.DataBind();
                GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
                GridView1.DataBind();
                GridView2.SelectedIndex = -1;
            }
            else
            {
                GridView2.Columns[11].Visible = true;
                GridView2.Columns[12].Visible = true;
                Button4.Visible = false;
                Panel3.Visible = true;
                Guid pmpid = new Guid(row.Cells[1].Text);
                Label14.Text = pmpid.ToString();
                GridView2.DataSource = mp.Query_MPlanDetail(pmpid);
                GridView2.DataBind();
                Label10.Text = "查看";
                Label11.Text = row.Cells[2].Text;
                Label12.Text = row.Cells[3].Text;
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                Panel31.Visible = false;

                Button4.Visible = true;
                Panel31.Visible = true;
              

                GridView2.SelectedIndex = -1;
            }


        }
        if (e.CommandName == "Audit")
        {
            
            GridView2.Columns[8].Visible = false;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            Panel3.Visible = true;
            MMPid = new Guid(e.CommandArgument.ToString());

            GridView2.DataSource = mp.Query_MPlanDetail(MMPid);
            GridView2.DataBind();
            GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
            Panel3.Visible = false;
            Panel32.Visible = false;
            Panel4.Visible = false;
            Panel5.Enabled = false;
            Panel6.Enabled = false;
            Panel7.Enabled = false;
            Button4.Visible = false;
            if (Session["UserRole"].ToString().Contains("材料月计划审核生产部"))
            { Panel5.Enabled = true; }
            if (Session["UserRole"].ToString().Contains("材料月计划审核财务部"))
            { Panel6.Enabled = true; }
            if (Session["UserRole"].ToString().Contains("材料月计划审核副总"))
            {
                Panel7.Enabled = true;
            }
            Panel5.Visible = true;
            Panel6.Visible = true;
            Panel7.Visible = true;
            Label11.Text = row.Cells[2].Text;
            Label12.Text = row.Cells[3].Text;
            PMPAudit au = new PMPAudit();
            au = mp.Query_Audit(MMPid);
            Label1.Text = au.PMP_MPDepSignMan1.ToString();
            Label2.Text = au.PMP_MPDepSignTime1.ToString();
            if (Label2.Text != "")
            {
                Label2.Text = Convert.ToDateTime(Label2.Text).ToString("yyyy-MM-dd HH:mm");
            }

            TextBox3.Text = au.PMP_MPDepSignSuggestion1.ToString();
            Label3.Text = au.PMP_MPDepSignResult1.ToString();
            Label4.Text = au.PMP_MFDepSignMan1.ToString();
            Label5.Text = au.PMP_MFDepSignTime1.ToString();
            if (Label5.Text != "")
            {
                Label5.Text = Convert.ToDateTime(Label5.Text).ToString("yyyy-MM-dd HH:mm");
            }

            Label6.Text = au.PMP_MFDepSignResult1.ToString();
            TextBox4.Text = au.PMP_MFDepSignSuggestion1.ToString();
            Label7.Text = au.PMP_MBossSignMan1.ToString();
            Label8.Text = au.PMP_MBossSignTime1.ToString();
            if (Label8.Text != "")
            {
                Label8.Text = Convert.ToDateTime(Label8.Text).ToString("yyyy-MM-dd HH:mm");
            }
            Label9.Text = au.PMP_MBossSignResult1.ToString();
            TextBox5.Text = au.PMP_MBossSignSuggestion1.ToString();
            if (Label3.Text == "")
            {
                Label3.Text = "尚未会签";
                P1.Visible = true;
                TextBox3.Enabled = true;
            }
            else
            {
                TextBox3.Enabled = false;
                P1.Visible = false;
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
                TextBox4.Enabled = false;
                P2.Visible = false;
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
                TextBox5.Enabled = false;
                P3.Visible = false;
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
        if (e.CommandName == "Bonus")
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            int check = mp.CheckAddAvailable(int.Parse(row.Cells[2].Text), int.Parse(row.Cells[3].Text));
            if (check <1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('现在不需要新增材料月计划,所有生产计划都已分配材料！')", true);
            }
            else
            {


                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                GridView2.SelectedIndex = -1;


                Panel31.Visible = true;

                GridView1.SelectedIndex = -1;

                Label10.Text = "新增";
                Label11.Text = row.Cells[2].Text;
                Label12.Text = row.Cells[3].Text;
                Panel3.Visible = true;
                Salesid = new Guid(e.CommandArgument.ToString());
                GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
                GridView2.Columns[7].Visible = true;
                GridView2.Columns[8].Visible = true;
                Label13.Text = Salesid.ToString();
                Button4.Visible = true;
                TextBox6.Text = "";
                TextBox7.Text = "";
    
                
                string add = "是";
                
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel6.Visible = false;
                Panel7.Visible = false;
                int year = int.Parse(Label11.Text);
                int month = int.Parse(Label12.Text);
                string man = Session["UserName"].ToString();
                string makedate = DateTime.Now.ToString("yyyy-MM-dd");

                Guid sid = new Guid(Label13.Text);
                Guid pmpid = mp.Insert_PMP_add(sid, year, month, man, makedate, null, null, add,Convert.ToInt32(Linenum.Text));
                
                Label14.Text = pmpid.ToString();
                GridView2.DataSource = mp.Query_MPlanDetail(new Guid(Label14.Text));
                GridView2.DataBind();
                GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
                GridView1.DataBind();
                GridView2.SelectedIndex = -1;
                mp.UpdatePlanState_New(pmpid);



            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
           
            if (e.Row.Cells[9].Text == "未建立")
            {
                e.Row.Cells[11].Enabled = false;
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[11].ToolTip = "计划尚未建立";
                e.Row.Cells[13].ToolTip = "计划尚未建立";
                
            }
            else if (e.Row.Cells[9].Text == "审核驳回")
            {
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[13].ToolTip = "已经审核过了";
            }
            else if (e.Row.Cells[9].Text == "已建立")
            {
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[13].ToolTip = "提交后才可以审核";
                
            }

            else
            {
                e.Row.Cells[12].ToolTip = "只有状态为未建立和已建立的时候才可以制定";
                e.Row.Cells[12].Enabled = false;
            }
             if (e.Row.Cells[10].Text == "否")
            {
                e.Row.Cells[14].Enabled = true;
                
            }
             else
             {
                 e.Row.Cells[14].Enabled = false;
                 e.Row.Cells[14].ToolTip = "只能在建好的非新增计划上新增";
             }
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
            Guid mmpid = new Guid(Label14.Text);
            Label17.Text = mid.ToString();
            GridView3.DataSource = mp.Query_MPlanDetail_Type(int.Parse(Label11.Text), int.Parse(Label12.Text), mid,mmpid);
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

            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;









        }
    }


    #endregion
    #region 表3

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    if (e.Row.Cells[9].Text == "0")
        //    {
        //        e.Row.BackColor = Color.FromArgb(100, 201,233,254);
        //        e.Row.Cells[9].ToolTip = "已被其他物料代替";
        //    }
        //}
    }
    #endregion
    #endregion
    #region 按钮事件
    protected void Button1_Click(object sender, EventArgs e)
    {

        syear = Int32.Parse(DropDownList1.SelectedValue.ToString());
        smonth = Int32.Parse(DropDownList2.SelectedValue.ToString());
        state = DropDownList3.SelectedValue.ToString();

        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        GridView1.SelectedIndex = -1;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
        GridView2.DataSource = mp.Query_MPlanDetail(MMPid);


    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        //GridView3.DataSource = mp.Query_Material(name, model);
        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
        DataBind();

    }


    protected void Button15_Click(object sender, EventArgs e)
    {

        Panel32.Visible = false;
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

       
        if (DateTime.Compare(startdate,enddate)>0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('结束日期不能在开始日期之前！')", true);
        }
        else
        {

           
           
            int year = int.Parse(Label11.Text);
            int month = int.Parse(Label12.Text);
            string man = Session["UserName"].ToString();
            string makedate = DateTime.Now.ToString("yyyy-MM-dd");
            Guid pmpid = new Guid(Label14.Text);
            mp.Update_PMP(pmpid, startdate, enddate);
            if (Label10.Text=="制定")
            {
                string err=RTXhelper.Send("ERP系统消息：" + Session["UserRole"] + "于" + DateTime.Now.ToString("F") + "提交了" + year + "年" + month + "月" + "的原始材料月计划,待您审核。", "材料月计划审核");
                if (!string.IsNullOrEmpty(err))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", err, true);
                }
            } 
            if (Label10.Text == "新增")
            {
               string err= RTXhelper.Send("ERP系统消息：" + Session["UserRole"] + "于" + DateTime.Now.ToString("F") + "提交了" + year + "年" + month + "月" + "的新增材料月计划,待您审核。", "材料月计划审核");
               if (!string.IsNullOrEmpty(err))
               {
                   ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", err, true);
               }
            } 
            GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
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
        Guid id = MMPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox3.Text;
        string res = "审核通过";
        string role = "生产部";
        mp.Update_PMPAudit(id, man, time, su, res, role);
        P1.Visible = false;
        TextBox3.Enabled = false;
        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
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
        Guid id = MMPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox3.Text;
        string res = "审核驳回";
        string role = "生产部";
        mp.Update_PMPAudit(id, man, time, su, res, role);
        P1.Visible = false;
        TextBox3.Enabled = false;
        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button11_Click(object sender, EventArgs e)
    {

        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Guid id = MMPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox4.Text;
        string res = "审核通过";
        string role = "财务部";
        mp.Update_PMPAudit(id, man, time, su, res, role);
        P2.Visible = false;
        TextBox4.Enabled = false;
        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
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
        Guid id = MMPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox4.Text;
        string res = "审核驳回";
        string role = "财务部";
        mp.Update_PMPAudit(id, man, time, su, res, role);
        P2.Visible = false;
        TextBox4.Enabled = false;

        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
        GridView1.DataBind();
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核意见提交成功！')", true);
    }
    protected void Button8_Click(object sender, EventArgs e)
    {

        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Guid id = MMPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox5.Text;
        string res = "审核通过";
        string role = "副总";
        mp.Update_PMPAudit(id, man, time, su, res, role);
        P3.Visible = false;
        TextBox5.Enabled = false;

        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
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
        Guid id = MMPid;
        string man = Session["UserName"].ToString();
        DateTime time = new DateTime();
        time = Convert.ToDateTime(DateTime.Now.ToString());

        string su = TextBox5.Text;
        string res = "审核驳回";
        string role = "副总";
        mp.Update_PMPAudit(id, man, time, su, res, role);
        P3.Visible = false;
        TextBox5.Enabled = false;
        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
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
    #region 翻页绑定
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
        GridView1.DataSource = mp.Query_MPlan(syear, smonth, state,Convert.ToInt32(Linenum.Text));
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

        theGrid.DataSource = mp.Query_MPlanDetail(new Guid(Label14.Text));
        theGrid.DataBind();
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

        GridView3.DataSource = mp.Query_MPlanDetail_Type(int.Parse(Label11.Text), int.Parse(Label12.Text), new Guid(Label17.Text), new Guid(Label14.Text));

        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }
    #endregion





    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        if (TextBox8.Text == "" )
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }

        try
        {
            Guid mid = new Guid(Label17.Text);
            Guid pmpid = new Guid(Label14.Text);
            decimal num = decimal.Parse(TextBox8.Text);
            string note = TextBoxNote.Text;
            mp.UpdatePMPDetail(pmpid, mid, num,note);
            Panel32.Visible = false;
            GridView2.DataSource = mp.Query_MPlanDetail(new Guid(Label14.Text));
            GridView2.DataBind();

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('！')", true);

        }

    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[7].Text.Length>10)
            {
                e.Row.Cells[7].ToolTip = e.Row.Cells[7].Text;
                e.Row.Cells[7].Text = e.Row.Cells[7].Text.Substring(0, 10);

            }
        }
    }

   
}