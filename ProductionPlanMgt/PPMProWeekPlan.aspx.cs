using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EquipmentMangementAjax.SQLServer;
using RTXHelper;
public partial class ProductionPlanMgt_PPMProWeekPlan : Page
{
    WSD ws = new WSD();
    SalesMonthPlanD mp = new SalesMonthPlanD();
    ProductionWeekPlanD pwpl = new ProductionWeekPlanD();
    ProductionWeekPlanInfo pwpi = new ProductionWeekPlanInfo();
    ProductionPlanD ppp = new ProductionPlanD();
    protected void Page_Load(object sender, EventArgs e)
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
        if (Request.QueryString["linenum"] == null)
        {
            Proline.Text = "0";
        }
        else
        {
            Proline.Text = Request.QueryString["linenum"];
        }
        if (state == "look")
        {
            this.Title = "生产周计划查看";
            GridView_WeekMain.Columns[12].Visible = false;
            Button_Subold.Visible = false;
            GridView_Day.Columns[13].Visible = false;
            Button_addpt.Visible = false;
            BT_TKOK.Visible = false;
            BT_TKNotOK.Visible = false;
            TB_shengchanyijian.Enabled = false;
            GridView_D.Columns[12].Visible = true;
            GridView_D.Columns[16].Visible = true;
            GridView_D.Columns[13].Visible = false;
            GridView_D.Columns[17].Visible = false;
            Button_Save.Visible = false;
            GridView_Day.Columns[6].Visible = true;
            GridView_Day.Columns[8].Visible = true;
            GridView_Day.Columns[10].Visible = true;
            GridView_Day.Columns[12].Visible = true;
            GridView_Day.Columns[14].Visible = true;
            GridView_Day.Columns[16].Visible = true;
            GridView_Day.Columns[18].Visible = true;
            GridView_Day.Columns[7].Visible = false;
            GridView_Day.Columns[9].Visible = false;
            GridView_Day.Columns[11].Visible = false;
            GridView_Day.Columns[13].Visible = false;
            GridView_Day.Columns[15].Visible = false;
            GridView_Day.Columns[17].Visible = false;
            GridView_Day.Columns[19].Visible = false;
            Button_SaveDay.Visible = false;

            btnDetailReset0.Visible = false;//一键复制
            DropDownList1.Visible = false;//选择时间
            DropDownList2.Visible = false;//选择时间
            btnDetailResetDay0.Visible = false;//选择时间
            btnDetailResetDay1.Visible = false;//选择时间

        }
        if (state == "manage")
        {
            this.Title = "生产周计划管理";
            BT_TKOK.Visible = false;
            BT_TKNotOK.Visible = false;
            TB_shengchanyijian.Enabled = false;
            GridView_D.Columns[12].Visible = false;
            GridView_D.Columns[16].Visible = false;
            GridView_D.Columns[13].Visible = true;
            GridView_D.Columns[17].Visible = true;

            GridView_Day.Columns[6].Visible = false;
            GridView_Day.Columns[8].Visible = false;
            GridView_Day.Columns[10].Visible = false;
            GridView_Day.Columns[12].Visible = false;
            GridView_Day.Columns[14].Visible = false;
            GridView_Day.Columns[16].Visible = false;
            GridView_Day.Columns[18].Visible = false;
            GridView_Day.Columns[7].Visible = true;
            GridView_Day.Columns[9].Visible = true;
            GridView_Day.Columns[11].Visible = true;
            GridView_Day.Columns[13].Visible = true;
            GridView_Day.Columns[15].Visible = true;
            GridView_Day.Columns[17].Visible = true;
            GridView_Day.Columns[19].Visible = true;
        }
        if (state == "review")
        {
            this.Title = "生产周计划审核";
            GridView_WeekMain.Columns[12].Visible = false;
            Button_Subold.Visible = false;
            GridView_Day.Columns[13].Visible = false;
            Button_addpt.Visible = false;
            GridView_D.Columns[12].Visible = true;
            GridView_D.Columns[16].Visible = true;
            GridView_D.Columns[13].Visible = false;
            GridView_D.Columns[17].Visible = false;
            Button_Save.Visible = false;
            GridView_Day.Columns[6].Visible = true;
            GridView_Day.Columns[8].Visible = true;
            GridView_Day.Columns[10].Visible = true;
            GridView_Day.Columns[12].Visible = true;
            GridView_Day.Columns[14].Visible = true;
            GridView_Day.Columns[16].Visible = true;
            GridView_Day.Columns[18].Visible = true;
            GridView_Day.Columns[7].Visible = false;
            GridView_Day.Columns[9].Visible = false;
            GridView_Day.Columns[11].Visible = false;
            GridView_Day.Columns[13].Visible = false;
            GridView_Day.Columns[15].Visible = false;
            GridView_Day.Columns[17].Visible = false;
            GridView_Day.Columns[19].Visible = false;
            Button_SaveDay.Visible = false;

            btnDetailReset0.Visible = false;//一键复制
            DropDownList1.Visible = false;//选择时间
            DropDownList2.Visible = false;//选择时间
            btnDetailResetDay0.Visible = false;//选择时间
            btnDetailResetDay1.Visible = false;//选择时间
        }

        if (!IsPostBack)
        {
            label_GridPageState.Text = "默认数据源";
            DateTime tnow = DateTime.Now;
            for (int m = 1; m <= 12; m++)
            {
                DropDownList_Month.Items.Add(new ListItem(m.ToString(), m.ToString()));
            }
            DropDownList_Month.Items.Insert(0, new ListItem("所有月份", "255"));
            for (int y = 2014; y <= DateTime.Now.Year + 1; y++)
            {
                DropDownList_Year.Items.Add(new ListItem(y.ToString(), y.ToString()));
            }
            DropDownList_Year.Items.Insert(0, new ListItem("所有年份", "255"));
            for (int w = 1; w <= 53; w++)
            {
                DropDownList_Week.Items.Add(new ListItem(w.ToString(), w.ToString()));
            }
            DropDownList_Week.Items.Insert(0, new ListItem("所有周次", "255"));


            DropDownList_PState.Items.Insert(0, new ListItem("所有状态", "所有状态"));

            dataBind();
        }

    }


    public void dataBind()
    {
        string Year = DropDownList_Year.SelectedValue;
        string Month = DropDownList_Month.SelectedValue;
        string Week = DropDownList_Week.SelectedValue;
        string State = DropDownList_PState.SelectedValue;
        string man = TextBox_PPMan.Text;
        string sman = TextBox_SPman.Text;
        DateTime sstime = new DateTime();
        DateTime setime = new DateTime();
        if (TextBox_SPTime1.Text != "")
        {
            sstime = Convert.ToDateTime(TextBox_SPTime1.Text);
        }
        else
        {
            sstime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        if (TextBox_SPTime2.Text != "")
        {
            setime = Convert.ToDateTime(TextBox_SPTime2.Text);
        }
        else
        {
            setime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }
        DateTime stime = new DateTime();
        DateTime etime = new DateTime();
        if (TextBox_PPTime1.Text != "")
        {
            stime = Convert.ToDateTime(TextBox_PPTime1.Text);
        }
        else
        {
            stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        if (TextBox_PPTime2.Text != "")
        {
            etime = Convert.ToDateTime(TextBox_PPTime2.Text);
        }
        else
        {
            etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }

        GridView_WeekMain.DataSource = pwpl.S_PWP(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Week), State, sman, man, sstime, setime, stime, etime, Convert.ToInt32(Proline.Text));
        GridView_WeekMain.DataBind();
        UpdatePanel_PPMain.Update();
    }
    public void clear()
    {
        TextBox_PPMan.Text = "";
        TextBox_PPTime1.Text = "";
        TextBox_PPTime2.Text = "";
        TextBox_SPman.Text = "";
        TextBox_SPTime1.Text = "";
        TextBox_SPTime2.Text = "";
        label_GridPageState.Text = "默认数据源";
        string condition = " and 1=1";

        //无关部分隐藏
        Panel_D.Visible = false;
        Panel_Day.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_series.Visible = false;
        Panel_Sign.Visible = false;
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_Day.SelectedIndex = -1;
        GridView_Day.EditIndex = -1;
        GridView_WeekMain.SelectedIndex = -1;
        GridView_WeekMain.EditIndex = -1;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_series.Update();
        UpdatePanel_Sign.Update();


        DropDownList_Year.SelectedIndex = 0;
        DropDownList_Month.SelectedIndex = 0;
        DropDownList_Week.SelectedIndex = 0;
        DropDownList_PState.SelectedIndex = 0;

        dataBind();
        UpdatePanel_PPMain.Update();
    }

    public void databinde_detail()
    {
        DateTime d1 = Convert.ToDateTime(Label_T1.Text.Trim());
        DateTime d2 = Convert.ToDateTime(Label_T2.Text.Trim());
        TimeSpan ts = d2 - d1;
        int n = ts.Days;
        DropDownList2.Items.Clear();
        for (int i = 0; i <= n || i < 7; i++)
        {
            DropDownList2.Items.Add(new ListItem(d1.AddDays(i).ToString("yyyy-MM-dd"), d1.AddDays(i).ToString("yyyy-MM-dd")));

        }

        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
        label_Condition.Text = condition;
        DataSet ds2 = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        if (ds2.Tables[0].Rows.Count != 0)
        {
            GridView_Day.Columns[6].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT1"].ToString() == "" ? "第1天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT1"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[7].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT1"].ToString() == "" ? "第1天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT1"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[8].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT2"].ToString() == "" ? "第2天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT2"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[9].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT2"].ToString() == "" ? "第2天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT2"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[10].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT3"].ToString() == "" ? "第3天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT3"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[11].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT3"].ToString() == "" ? "第3天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT3"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[12].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT4"].ToString() == "" ? "第4天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT4"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[13].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT4"].ToString() == "" ? "第4天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT4"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[14].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT5"].ToString() == "" ? "第5天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT5"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[15].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT5"].ToString() == "" ? "第5天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT5"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[16].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT6"].ToString() == "" ? "第6天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT6"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[17].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT6"].ToString() == "" ? "第6天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT6"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[18].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT7"].ToString() == "" ? "第7天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT7"].ToString()).ToString(" MM-dd ");
            GridView_Day.Columns[19].HeaderText = ds2.Tables[0].Rows[0]["PWPD_DT7"].ToString() == "" ? "第7天计划" : Convert.ToDateTime(ds2.Tables[0].Rows[0]["PWPD_DT7"].ToString()).ToString(" MM-dd ");

        } GridView_Day.DataBind();
        
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
    
    }
    protected void GridView_WeekMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView_WeekMain.SelectedIndex = -1;
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_WeekMain.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_WeekMain.PageCount ? GridView_WeekMain.PageCount - 1 : newPageIndex;
        GridView_WeekMain.PageIndex = newPageIndex;
        GridView_WeekMain.PageIndex = newPageIndex;


        if (label_GridPageState.Text == "默认数据源")
        {
            dataBind();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
    }
    protected void GridView_WeekMain_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //无关部分隐藏
        Panel_D.Visible = false;
        Panel_Day.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_series.Visible = false;
        Panel_Sign.Visible = false;
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_Day.SelectedIndex = -1;
        GridView_Day.EditIndex = -1;
        GridView_WeekMain.SelectedIndex = -1;
        GridView_WeekMain.EditIndex = -1;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_series.Update();
        UpdatePanel_Sign.Update();

        //
        if (label_GridPageState.Text == "默认数据源")
        {
            dataBind();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
        GridView_WeekMain.DataBind();
    }
    protected void GridView_WeekMain_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_WeekMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[5].Text == "未建立" || e.Row.Cells[5].Text == "已建立")
            {
                e.Row.Cells[14].Enabled = false;
                e.Row.Cells[14].ToolTip = "提交以后才能审核哦.";

            }
            if (e.Row.Cells[5].Text == "未建立")
            {
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[13].ToolTip = "要先制定哦.";

            }
        }
    }
    protected void GridView_WeekMain_Editing(object sender, GridViewEditEventArgs e)
    {
        GridView_WeekMain.EditIndex = e.NewEditIndex;
        GridView_WeekMain.SelectedIndex = e.NewEditIndex;
        //无关部分隐藏
        if (GridView_WeekMain.Rows[e.NewEditIndex].Cells[5].Text == "已提交" || GridView_WeekMain.Rows[e.NewEditIndex].Cells[5].Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView_WeekMain.SelectedIndex = -1;
            GridView_WeekMain.EditIndex = -1;
            if (label_GridPageState.Text == "默认数据源")
            {
                dataBind();
            }
            if (label_GridPageState.Text == "检索数据源")
            {
                dataBind();
            }
            return;
        }

        Panel_D.Visible = false;
        Panel_Day.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_series.Visible = false;
        Panel_Sign.Visible = false;
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_Day.SelectedIndex = -1;
        GridView_Day.EditIndex = -1;
        //   GridView_WeekMain.SelectedIndex = -1;
        //   GridView_WeekMain.EditIndex = -1;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_series.Update();
        UpdatePanel_Sign.Update();


        if (label_GridPageState.Text == "默认数据源")
        {
            dataBind();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
        // GridView_WeekMain.DataBind();
        UpdatePanel_PPMain.Update();
    }
    protected void GridView_WeekMain_Updating(object sender, GridViewUpdateEventArgs e)
    {
        string pwid;
        if (GridView_WeekMain.DataKeys[e.RowIndex].Values["PWP_ID"].ToString() == "")
        {

            pwid = "00000000-0000-0000-0000-000000000000";

        }
        else
        {
            pwid = GridView_WeekMain.DataKeys[e.RowIndex].Values["PWP_ID"].ToString();
        }
        string condition = " and PWP_ID='" + pwid + "'";
        if (GridView_WeekMain.Rows[e.RowIndex].Cells[5].Text == "已提交" || GridView_WeekMain.Rows[e.RowIndex].Cells[5].Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView_WeekMain.SelectedIndex = -1;
            GridView_WeekMain.EditIndex = -1;
            if (label_GridPageState.Text == "默认数据源")
            {
                dataBind();
            }
            if (label_GridPageState.Text == "检索数据源")
            {
                dataBind();
            }
            return;
        }

        DateTime date1 = Convert.ToDateTime(((TextBox)(GridView_WeekMain.Rows[e.RowIndex].Cells[8].Controls[1])).Text.Trim());
        DateTime date2 = Convert.ToDateTime(((TextBox)(GridView_WeekMain.Rows[e.RowIndex].Cells[9].Controls[1])).Text.Trim());
        if (date1 > date2)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划开始时间不能晚于计划结束时间！请再次核对！')", true);
            return;
        }


        if (GridView_WeekMain.DataKeys[e.RowIndex].Values["PWP_ID"].ToString() == "")
        {


            pwpi.SMSWPM_ID = new Guid(GridView_WeekMain.DataKeys[e.RowIndex].Values["SMSWPM_ID"].ToString());

            pwpi.PWP_Year = Convert.ToInt16(GridView_WeekMain.Rows[e.RowIndex].Cells[2].Text.Trim());
            pwpi.PWP_Month = Convert.ToInt16(GridView_WeekMain.Rows[e.RowIndex].Cells[3].Text.Trim());
            pwpi.PWP_STime = Convert.ToDateTime(((TextBox)(GridView_WeekMain.Rows[e.RowIndex].Cells[8].Controls[1])).Text.Trim());
            pwpi.PWP_ETime = Convert.ToDateTime(((TextBox)(GridView_WeekMain.Rows[e.RowIndex].Cells[9].Controls[1])).Text.Trim());
            pwpi.PWP_Man = Session["UserName"].ToString();
            pwpi.Linenum = Convert.ToInt32(Proline.Text);
            pwpl.I_PWP(pwpi);
        }
        else
        {
            pwpi.PWP_ID = new Guid(GridView_WeekMain.DataKeys[e.RowIndex].Values["PWP_ID"].ToString());
            pwpi.PWP_STime = Convert.ToDateTime(((TextBox)(GridView_WeekMain.Rows[e.RowIndex].Cells[8].Controls[1])).Text.Trim());
            pwpi.PWP_ETime = Convert.ToDateTime(((TextBox)(GridView_WeekMain.Rows[e.RowIndex].Cells[9].Controls[1])).Text.Trim());
            pwpi.PWP_Man = Session["UserName"].ToString();
            pwpl.U_PWP(pwpi);
        }
        GridView_WeekMain.EditIndex = -1;

        if (label_GridPageState.Text == "默认数据源")
        {
            dataBind();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }

        GridView_WeekMain.DataBind();
        UpdatePanel_PPMain.Update();
    }
    protected void GridView_WeekMain_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_WeekMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Review")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WeekMain.SelectedIndex = row.RowIndex;
            GridView_WeekMain.EditIndex = -1;

            if (label_GridPageState.Text == "默认数据源")
            {
                dataBind();
            }
            if (label_GridPageState.Text == "检索数据源")
            {
                dataBind();
            }
            GridView_WeekMain.DataBind();

            UpdatePanel_PPMain.Update();
            //无关部分隐藏
            Panel_D.Visible = false;
            Panel_Day.Visible = false;
            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            Panel_series.Visible = false;
            //   Panel_Sign.Visible = false;
            GridView_D.SelectedIndex = -1;
            GridView_D.EditIndex = -1;
            GridView_Day.SelectedIndex = -1;
            GridView_Day.EditIndex = -1;
            //  GridView_WeekMain.SelectedIndex = -1;
            //   GridView_WeekMain.EditIndex = -1;
            UpdatePanel_D.Update();
            UpdatePanel_Day.Update();
            UpdatePanel_Product.Update();
            UpdatePanel_series.Update();
            //   UpdatePanel_Sign.Update();



            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_year.Text = al[3] + "年";
            Label_Month.Text = al[4] + "月 ";
            Label_PWPID.Text = al[0];
            Label_week.Text = " 第" + al[5] + "周次 ";
            label_pwpstate.Text = al[2];

            dataBind();
            GridView1.DataSource = pwpl.S_Review(new Guid(Label_PWPID.Text));
            GridView1.DataBind();
            Panel2.Visible = true;
            UpdatePanel2.Update();

        }
        if (e.CommandName == "Detail")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WeekMain.SelectedIndex = row.RowIndex;
            GridView_WeekMain.EditIndex = -1;
            if (label_GridPageState.Text == "默认数据源")
            {
                dataBind();
            }
            if (label_GridPageState.Text == "检索数据源")
            {
                dataBind();
            }
            GridView_WeekMain.DataBind();

            this.Label_T1.Text = Convert.ToDateTime(GridView_WeekMain.DataKeys[row.RowIndex].Values["PWP_STime"].ToString()).ToString("yyyy-MM-dd");
            this.Label_T2.Text = Convert.ToDateTime(GridView_WeekMain.DataKeys[row.RowIndex].Values["PWP_ETime"].ToString()).ToString("yyyy-MM-dd");

            UpdatePanel_PPMain.Update();
            //无关部分隐藏
            //  Panel_D.Visible = false;
            //  Panel_Day.Visible = false;
            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            Panel_series.Visible = false;
            Panel_Sign.Visible = false;
            //   GridView_D.SelectedIndex = -1;
            //   GridView_D.EditIndex = -1;
            //   GridView_Day.SelectedIndex = -1;
            //     GridView_Day.EditIndex = -1;
            //   GridView_WeekMain.SelectedIndex = -1;
            //   GridView_WeekMain.EditIndex = -1;
            //   UpdatePanel_D.Update();
            //  UpdatePanel_Day.Update();
            UpdatePanel_Product.Update();
            UpdatePanel_series.Update();
            UpdatePanel_Sign.Update();

            


            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string smswpmid = al[0];
            label_pwpid_Detail.Text = al[1];
            Label_pwpdetailstate.Text = al[2];
            if (this.label_pagestate.Text == "manage")
            {
                if (Label_pwpdetailstate.Text.Trim() != "已建立" && Label_pwpdetailstate.Text.Trim() != "审核驳回")
                {
                    btnDetailReset0.Visible = false;
                    Button_Subold.Visible = false;
                    Button_Save.Visible = false;
                    Button_addpt.Visible = false;

                    Button_SaveDay.Visible = false;
                    DropDownList1.Visible = false;
                    DropDownList2.Visible = false;
                    btnDetailResetDay0.Visible = false;
                    btnDetailResetDay1.Visible = false;
                }
                else
                {
                    btnDetailReset0.Visible = true;
                    Button_Subold.Visible = true;
                    Button_Save.Visible = true;
                    Button_addpt.Visible = true;


                    Button_SaveDay.Visible = true;
                    DropDownList1.Visible = true;
                    DropDownList2.Visible = true;
                    btnDetailResetDay0.Visible = true;
                    btnDetailResetDay1.Visible = true;

                }
            }



            Label_time1.Text = al[3] + "年" + al[4] + "月" + "第" + al[5] + "周次";
            Label_Time2.Text = al[3] + "年" + al[4] + "月" + "第" + al[5] + "周的";
            label_smswpmid.Text = smswpmid;

            databinde_detail();
        }
    }
    protected void GridView_D_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_D_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView_D_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_D_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {

            for (int i = 9; i <= 9; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");





            }
            ((TextBox)e.Row.Cells[12].Controls[0]).Attributes.Add("MaxLength", "100");
        }
    }
    protected void GridView_D_Editing(object sender, GridViewEditEventArgs e)
    {
        if (Label_pwpdetailstate.Text != "已建立" && Label_pwpdetailstate.Text != "审核驳回")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('只能制定‘已建立’和‘审核驳回’状态的计划！')", true);
            return;
        }

        GridView_D.EditIndex = e.NewEditIndex;
        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";

        //无关部分隐藏
        //   Panel_D.Visible = false;
        //    Panel_Day.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_series.Visible = false;
        Panel_Sign.Visible = false;
        //    GridView_D.SelectedIndex = -1;
        //    GridView_D.EditIndex = -1;
        //  GridView_Day.SelectedIndex = -1;
        //   GridView_Day.EditIndex = -1;
        //   GridView_WeekMain.SelectedIndex = -1;
        //    GridView_WeekMain.EditIndex = -1;
        //  UpdatePanel_D.Update();
        //   UpdatePanel_Day.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_series.Update();
        UpdatePanel_Sign.Update();


        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_PPMain.Update();
    }
    protected void GridView_D_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_PPMain.Update();

    }
    protected void GridView_D_Updating(object sender, GridViewUpdateEventArgs e)
    {

        Guid pwpdid = new Guid(GridView_D.DataKeys[e.RowIndex].Values["PWPD_ID"].ToString());
        string note = ((TextBox)(GridView_D.Rows[e.RowIndex].Cells[11].Controls[0])).Text.Trim();
        try
        {
            int plannum = ((TextBox)(GridView_D.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_D.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim());
            pwpl.U_PWPDetail(pwpdid, plannum, note);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周投产计划应是整数形式，请您再次核对！')", true);
            return;
        }
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_PPMain.Update();



    }
    protected void GridView_D_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_Day_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_Day_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView_Day_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_Day_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            for (int i = 6; i <= 12; i++)
            {


                curText = (TextBox)e.Row.Cells[i].Controls[0];

                curText.Attributes.Add("style ", "width:60px;");
            }
            for (int i = 6; i <= 11; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");



            }
            ((TextBox)e.Row.Cells[12].Controls[0]).Attributes.Add("MaxLength", "100");
        }
    }
    protected void GridView_Day_Editing(object sender, GridViewEditEventArgs e)
    {
        if (Label_pwpdetailstate.Text != "已建立" && Label_pwpdetailstate.Text != "审核驳回")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('只能制定‘已建立’和‘审核驳回’状态的计划！')", true);
            return;
        }
        GridView_Day.EditIndex = e.NewEditIndex;

        //无关部分隐藏
        //   Panel_D.Visible = false;
        //    Panel_Day.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_series.Visible = false;
        Panel_Sign.Visible = false;
        ////   GridView_D.SelectedIndex = -1;
        //   GridView_D.EditIndex = -1;
        //   GridView_Day.SelectedIndex = -1;
        //    GridView_Day.EditIndex = -1;
        // GridView_WeekMain.SelectedIndex = -1;
        //  GridView_WeekMain.EditIndex = -1;
        //  UpdatePanel_D.Update();
        //   UpdatePanel_Day.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_series.Update();
        UpdatePanel_Sign.Update();

        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_PPMain.Update();
    }
    protected void GridView_Day_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_Day_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Day.SelectedIndex = -1;
        GridView_Day.EditIndex = -1;
        //无关部分隐藏
        //  Panel_D.Visible = false;
        //  Panel_Day.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_series.Visible = false;
        Panel_Sign.Visible = false;
        //   GridView_D.SelectedIndex = -1;
        //   GridView_D.EditIndex = -1;
        //   GridView_Day.SelectedIndex = -1;
        //    GridView_Day.EditIndex = -1;
        //   GridView_WeekMain.SelectedIndex = -1;
        //    GridView_WeekMain.EditIndex = -1;
        //   UpdatePanel_D.Update();
        //   UpdatePanel_Day.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_series.Update();
        UpdatePanel_Sign.Update();

        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_PPMain.Update();
    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        label_GridPageState.Text = "检索数据源";
        dataBind();
        //无关部分隐藏
        Panel_D.Visible = false;
        Panel_Day.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_series.Visible = false;
        Panel_Sign.Visible = false;
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_Day.SelectedIndex = -1;
        GridView_Day.EditIndex = -1;
        GridView_WeekMain.SelectedIndex = -1;
        GridView_WeekMain.EditIndex = -1;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_series.Update();
        UpdatePanel_Sign.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void BT_TKOK_Click(object sender, EventArgs e)
    {
        if (label_pwpstate.Text == "审核通过" || label_pwpstate.Text == "审核驳回")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周计划已审核，您不能再进行修改和变动！')", true);
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            return;
        }
        pwpi.PWP_State = "审核通过";
        pwpi.PWP_RMan = Session["UserName"].ToString();
        pwpi.PWP_ID = new Guid(Label_PWPID.Text);
        pwpi.PWP_Suggstion = TB_shengchanyijian.Text.Trim();
        pwpi.PWPCID = new Guid(PWPCID.Text);
        pwpl.U_PWP_Review(pwpi);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核完成！审核结果：通过！')", true);
        GridView_WeekMain.DataBind();
        Panel_Sign.Visible = false;
        if (label_GridPageState.Text == "默认数据源")
        {
            dataBind();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
        GridView1.DataSource = pwpl.S_Review(new Guid(Label_PWPID.Text));
        GridView1.DataBind();
        UpdatePanel2.Update();

        UpdatePanel_PPMain.Update();
        UpdatePanel_Sign.Update();
    }
    protected void BT_TKNotOK_Click(object sender, EventArgs e)
    {
        if (label_pwpstate.Text == "审核通过" || label_pwpstate.Text == "审核驳回")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周计划已审核，您不能再进行修改和变动！')", true);
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            return;
        }
        pwpi.PWP_State = "审核驳回";
        pwpi.PWP_RMan = Session["UserName"].ToString();
        pwpi.PWP_ID = new Guid(Label_PWPID.Text.Trim());
        pwpi.PWP_Suggstion = TB_shengchanyijian.Text.Trim();
        pwpi.PWPCID = new Guid(PWPCID.Text);
        if (TB_shengchanyijian.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('驳回审核时必须填写审核意见！')", true);
            return;
        }
        pwpl.U_PWP_Review(pwpi);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核完成！审核结果：驳回！')", true);
        GridView_WeekMain.DataBind();
        Panel_Sign.Visible = false;
        if (label_GridPageState.Text == "默认数据源")
        {
            dataBind();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
        GridView1.DataSource = pwpl.S_Review(new Guid(Label_PWPID.Text));
        GridView1.DataBind();
        UpdatePanel2.Update();
        UpdatePanel_PPMain.Update();
        UpdatePanel_Sign.Update();
    }
    protected void BT_TKCanel_Click(object sender, EventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    protected void GridView_series_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_series_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView_series_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_series_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string a = drv["warn"].ToString().Trim();
            if (a=="是")
            {
                e.Row.BackColor = System.Drawing.Color.Pink;


            }
        }
    }
    protected void GridView_series_Editing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView_series_Updating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView_series_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_series_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void Button_Subold_click(object sender, EventArgs e)
    {
        try
        {
            if (Label_pwpdetailstate.Text != "已建立" && Label_pwpdetailstate.Text != "审核驳回")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('只能提交‘已建立’和‘审核驳回’状态的计划！')", true);
                return;
            }
            Guid pwpid = new Guid(label_pwpid_Detail.Text);
            pwpl.U_PWP_State(pwpid);

            Guid SMSMPD_ID;
            string a, b, c;
            for (int i = 0; i <= this.GridView_D.Rows.Count - 1; i++)
            {
                int wip;
                int kc;
                int ck;
                SMSMPD_ID = new Guid(GridView_D.DataKeys[i].Values["PWPD_ID"].ToString());
                a = GridView_D.DataKeys[i].Values["WIP"].ToString();
                b = GridView_D.DataKeys[i].Values["TotalNum"].ToString();
                c = GridView_D.DataKeys[i].Values["PWPNumRef"].ToString();
                wip = Convert.ToInt32(a);
                kc = Convert.ToInt32(b);
                ck = Convert.ToInt32(c);
                try
                {
                    ppp.U_PWPDetail_WIP(SMSMPD_ID, wip, kc, ck);
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('保存在制品数量、库存、参考投产计划失败！')", true);
                    return;
                }
            }


            if (label_GridPageState.Text == "默认数据源")
            {
                dataBind();
            }
            if (label_GridPageState.Text == "检索数据源")
            {
                dataBind();
            }
            UpdatePanel_PPMain.Update();
            //无关部分隐藏
            Panel_D.Visible = false;
            Panel_Day.Visible = false;
            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            Panel_series.Visible = false;
            Panel_Sign.Visible = false;
            GridView_D.SelectedIndex = -1;
            GridView_D.EditIndex = -1;
            GridView_Day.SelectedIndex = -1;
            GridView_Day.EditIndex = -1;
            //   GridView_WeekMain.SelectedIndex = -1;
            //    GridView_WeekMain.EditIndex = -1;
            //   UpdatePanel_D.Update();
            //   UpdatePanel_Day.Update();
            UpdatePanel_Product.Update();
            UpdatePanel_series.Update();
            UpdatePanel_Sign.Update();
            UpdatePanel_Day.Update();
            string message = "ERP系统消息： " + Session["UserName"] + " 于 " + DateTime.Now.ToString("F") + " 提交了 " + Label_time1.Text + " 的新增生产周计划，请审核。";
            string sErr = RTXhelper.Send(message, "生产周计划审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败！')", true);
            return;
        }

    }
    protected void Btn_Close_New_Click(object sender, EventArgs e)
    {
        Label_searchConditionDay.Text = "";
        txtSeriesDay.Text = "";
        txtTypeDay.Text = "";
        Panel_Day.Visible = false;
        UpdatePanel_Day.Update();
    }
    protected void AddProductModell(object sender, EventArgs e)
    {
        if (Label_pwpdetailstate.Text == "已提交" || Label_pwpdetailstate.Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            return;
        }
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        // this.Label_PT_NewOrOld.Text = "old";
        Panel_Product.Visible = true;
        Panel_Product_Search.Visible = true;

        if (Proline.Text == "0")
        {
            GridView_ProType.DataSource = mp.Select_ProType("and  ProType.PT_ID not in (select PT_ID from PWPDetail where SMSWPM_ID='" + label_smswpmid.Text + "' and  PS_Name!='模块部新产品'  ) " + GetCondition_ProType() + "and  PS_Name!='模块部新产品'");
        }
        else
        {
            GridView_ProType.DataSource = mp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from PWPDetail where SMSWPM_ID='" + label_smswpmid.Text + "' and  PS_Name='模块部新产品' ) " + GetCondition_ProType() + "and  PS_Name='模块部新产品'");
        }

        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    protected void Btn_Close_Detail_Click(object sender, EventArgs e)
    {
        Panel_D.Visible = false;
        Panel_series.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Day.Visible = false;
        txtSeries.Text = "";
        txtType.Text = "";
        txtSeriesDay.Text = "";
        txtTypeDay.Text = "";
        Label_searchConditionDay.Text = "";
        Label_searchCondition.Text = "";
        UpdatePanel_Product.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_series.Update();
        UpdatePanel_D.Update();
    }
    //产品型号字符串拼接
    protected string GetCondition_ProType()
    {
        string conditon;
        string temp = "";
        if (TextBox_ProductName.Text != "")
        {
            temp += " and PT_Name like '%" + TextBox_ProductName.Text + "%'";

        }
        if (TextBox_Series.Text != "")
        {
            temp += " and Ps_Name like '%" + TextBox_Series.Text + "%'";
        }
        conditon = temp;
        return conditon;
    }

    //绑定产品型号表，查询结果
    protected void SelectProType(object sender, EventArgs e)
    {
        if (Proline.Text == "0")
        {
            GridView_ProType.DataSource = mp.Select_ProType("and  ProType.PT_ID not in (select PT_ID from PWPDetail where SMSWPM_ID='" + label_smswpmid.Text + "' and  PS_Name!='模块部新产品'  ) " + GetCondition_ProType() + "and  PS_Name!='模块部新产品'");
        }
        else
        {
            GridView_ProType.DataSource = mp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from PWPDetail where SMSWPM_ID='" + label_smswpmid.Text + "' and  PS_Name='模块部新产品' ) " + GetCondition_ProType() + "and  PS_Name='模块部新产品'");
        }
        GridView_ProType.DataBind();
        UpdatePanel_Product.Visible = true;
        UpdatePanel_Product.Update();
    }
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        //new add for checkbox

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_ProType.BottomPagerRow;

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
        //正常直接跳到这里
        {
            newPageIndex = e.NewPageIndex;
        }

        if (Proline.Text == "0")
        {
            GridView_ProType.DataSource = mp.Select_ProType("and  ProType.PT_ID not in (select PT_ID from PWPDetail where SMSWPM_ID='" + label_smswpmid.Text + "' and  PS_Name!='模块部新产品'  ) " + GetCondition_ProType() + "and  PS_Name!='模块部新产品'");
        }
        else
        {
            GridView_ProType.DataSource = mp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from PWPDetail where SMSWPM_ID='" + label_smswpmid.Text + "' and  PS_Name='模块部新产品' ) " + GetCondition_ProType() + "and  PS_Name='模块部新产品'");
        }
        CollectSelected();
        GridView_ProType.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        //RemeberOldValues();
        GridView_ProType.PageIndex = newPageIndex;
        GridView_ProType.DataBind();
        //RePopulateValues();
    }
    protected void Cbx2_SelectAll_CheckedChanged(object sender, EventArgs e)//全选按钮
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (Cbx2_SelectAll.Checked)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
        UpdatePanel_Product.Update();
    }
    protected ArrayList SelectedItems
    {
        get
        {
            return (ViewState["mySelectedItems"] != null) ? (ArrayList)ViewState["mySelectedItems"] : null;
        }
        set
        {
            ViewState["mySelectedItems"] = value;
        }
    }
    //从当前页收集选中项的情况
    protected void CollectSelected()
    {
        ArrayList selectedItems = null;
        if (SelectedItems == null)
            selectedItems = new ArrayList();
        else
            selectedItems = SelectedItems;
        //获取选择的记录
        for (int i = 0; i < GridView_ProType.Rows.Count; i++)
        {
            //string id = this.GridView_ProType.Rows[i].Cells[1].Text;
            CheckBox cb = GridView_ProType.Rows[i].FindControl("CheckBox2") as CheckBox;
            string id = GridView_ProType.DataKeys[i].Values[0].ToString();
            if (selectedItems.Contains(id) && !cb.Checked)
                selectedItems.Remove(id);
            if (!selectedItems.Contains(id) && cb.Checked)
                selectedItems.Add(id);
        }
        SelectedItems = selectedItems;
    }
    protected void GridView_ProType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //这里的处理是为了回显之前选中的情况
        if (e.Row.RowIndex > -1 && SelectedItems != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("CheckBox2") as CheckBox;
            string id = GridView_ProType.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }
    protected void ButtonProType_Click(object sender, EventArgs e)
    {
        string neworold = Label_PT_NewOrOld.Text.Trim();
        foreach (GridViewRow item in GridView_ProType.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {

                Guid smswpmid = new Guid(label_smswpmid.Text);
                Guid PT_ID = new Guid(GridView_ProType.DataKeys[item.RowIndex].Value.ToString());
                DataSet ds = pwpl.S_ProType_PWPDetail(smswpmid, PT_ID);
                if (ds.Tables[0].Rows.Count != 0)// have a check
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Product, GetType(), "alert", "alert('重复选择产品型号,无法添加!')", true);
                    return;
                }
                else
                {
                    if (Label_pwpdetailstate.Text == "已建立" || Label_pwpdetailstate.Text == "审核驳回")
                    {



                        pwpl.I_ProType_PWPDetail(smswpmid, PT_ID, new Guid(label_pwpid_Detail.Text));
                        //绑定
                        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
                        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
                        GridView_D.DataBind();
                        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
                        GridView_Day.DataBind();
                        Panel_D.Visible = true;
                        Panel_Day.Visible = true;
                        UpdatePanel_D.Update();
                        UpdatePanel_Day.Update();
                        UpdatePanel_PPMain.Update();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('只有在生产周计划为已建立或审核驳回情况下才能增加产品型号！')", true);
                    }
                }
            }
        }
    }
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Product_Search.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_checkProSeries_click(object sender, EventArgs e)
    {
        Guid smswpmid = new Guid(label_smswpmid.Text);
        Panel_series.Visible = true;
        GridView_series.DataSource = pwpl.S_PWPDetail_ProSeriesNum(smswpmid);
        GridView_series.DataBind();
        UpdatePanel_series.Update();
    }
    protected void Button_series_Click(object sender, EventArgs e)
    {
        Panel_series.Visible = false;
        UpdatePanel_series.Update();
    }
    protected void GridView_D_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_D.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_D.Rows[i].Cells.Count; j++)
            {
                GridView_D.Rows[i].Cells[j].ToolTip = GridView_D.Rows[i].Cells[j].Text;
                if (GridView_D.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_D.Rows[i].Cells[j].Text = GridView_D.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_Day_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Day.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Day.Rows[i].Cells.Count; j++)
            {
                GridView_Day.Rows[i].Cells[j].ToolTip = GridView_Day.Rows[i].Cells[j].Text;
                if (GridView_Day.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Day.Rows[i].Cells[j].Text = GridView_Day.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_WeekMain_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_WeekMain.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_WeekMain.Rows[i].Cells.Count; j++)
            {
                GridView_WeekMain.Rows[i].Cells[j].ToolTip = GridView_WeekMain.Rows[i].Cells[j].Text;
                if (GridView_WeekMain.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_WeekMain.Rows[i].Cells[j].Text = GridView_WeekMain.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        GridView1.SelectedIndex = row.RowIndex;
        PWPCID.Text = e.CommandArgument.ToString();
        Panel_Sign.Visible = true;
        UpdatePanel_Sign.Update();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[1].Text != Session["Department"].ToString())
            {
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[6].ToolTip = "您不是该部门的,不能会签别的部门的啦.";

            }
            if (e.Row.Cells[4].Text == "审核通过" || e.Row.Cells[4].Text == "审核驳回")
            {
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[6].ToolTip = "已经审核过啦.";
            }
        }
    }
    protected void CloseAudit_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void btnDetailSearch_Click(object sender, EventArgs e)
    {
        GridView_D.PageIndex = 0;
        string condition;
        string Series = this.txtSeries.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + this.txtSeries.Text.Trim() + "%'";
        string Name = this.txtType.Text.Trim() == "" ? " and 1=1 " : " and PT_Name  like '%" + this.txtType.Text.Trim() + "%'";
        condition = label_Condition.Text + Series + Name;
        Label_searchCondition.Text = condition;
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        UpdatePanel_D.Update();
    }
    protected void btnDetailExcel_Click(object sender, EventArgs e)
    {
        GridView_D.AllowPaging = false;
        GridView_D.AllowSorting = false;
        GridView_D.Columns[9].Visible = true;
        GridView_D.Columns[13].Visible = true;
        GridView_D.Columns[10].Visible = false;
        GridView_D.Columns[14].Visible = false;
        if (Label_searchCondition.Text == "")
            GridView_D.DataSource = pwpl.S_PWPDetail(label_Condition.Text, Proline.Text);
        else
            GridView_D.DataSource = pwpl.S_PWPDetail(Label_searchCondition.Text, Proline.Text);
        this.GridView_D.DataBind();
        ExcelHelper.GridViewToExcel(GridView_D, Label_time1.Text + "生产周计划详细表");
        GridView_D.AllowSorting = true;
    }
    protected void btnDetailReset_Click(object sender, EventArgs e)
    {
        txtSeries.Text = "";
        txtType.Text = "";
        Label_searchCondition.Text = "";
        GridView_D.DataSource = pwpl.S_PWPDetail(label_Condition.Text, Proline.Text);
        GridView_D.DataBind();
        UpdatePanel_D.Update();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnDetailSearchDay_Click(object sender, EventArgs e)
    {
        GridView_Day.PageIndex = 0;
        string condition;
        string Series = this.txtSeriesDay.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + this.txtSeriesDay.Text.Trim() + "%'";
        string Name = this.txtTypeDay.Text.Trim() == "" ? " and 1=1 " : " and PT_Name  like '%" + this.txtTypeDay.Text.Trim() + "%'";
        condition = label_Condition.Text + Series + Name;
        Label_searchConditionDay.Text = condition;
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        UpdatePanel_Day.Update();
    }
    protected void btnDetailExcelDay_Click(object sender, EventArgs e)
    {
        GridView_Day.AllowPaging = false;
        GridView_Day.AllowSorting = false;
        GridView_Day.Columns[6].Visible = true;
        GridView_Day.Columns[8].Visible = true;
        GridView_Day.Columns[10].Visible = true;
        GridView_Day.Columns[12].Visible = true;
        GridView_Day.Columns[14].Visible = true;
        GridView_Day.Columns[16].Visible = true;
        GridView_Day.Columns[18].Visible = true;
        GridView_Day.Columns[7].Visible = false;
        GridView_Day.Columns[9].Visible = false;
        GridView_Day.Columns[11].Visible = false;
        GridView_Day.Columns[13].Visible = false;
        GridView_Day.Columns[15].Visible = false;
        GridView_Day.Columns[17].Visible = false;
        GridView_Day.Columns[19].Visible = false;
        if (Label_searchConditionDay.Text == "")
            GridView_Day.DataSource = pwpl.S_PWPDetail(label_Condition.Text, Proline.Text);
        else
            GridView_Day.DataSource = pwpl.S_PWPDetail(Label_searchConditionDay.Text, Proline.Text);
        this.GridView_Day.DataBind();
        GridView_Day.Enabled = false;
        ExcelHelper.GridViewToExcel(GridView_Day, Label_time1.Text + "天计划详细表");
        GridView_Day.Enabled = true;
        GridView_Day.AllowSorting = true;

    }
    protected void btnDetailResetDay_Click(object sender, EventArgs e)
    {
        txtSeriesDay.Text = "";
        txtTypeDay.Text = "";
        Label_searchConditionDay.Text = "";
        GridView_Day.DataSource = pwpl.S_PWPDetail(label_Condition.Text, Proline.Text);
        GridView_Day.DataBind();
        UpdatePanel_Day.Update();
    }
    protected void Button_Save_Click(object sender, EventArgs e)
    {
        if (Label_pwpdetailstate.Text != "已建立" && Label_pwpdetailstate.Text != "审核驳回")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('只能制定‘已建立’和‘审核驳回’状态的计划！')", true);
            GridView_D.SelectedIndex = -1;
            GridView_D.EditIndex = -1;
            string condition1 = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
            GridView_D.DataSource = pwpl.S_PWPDetail(condition1, Proline.Text);
            GridView_D.DataBind();
            GridView_Day.DataSource = pwpl.S_PWPDetail(condition1, Proline.Text);
            GridView_Day.DataBind();
            Panel_D.Visible = true;
            Panel_Day.Visible = true;
            UpdatePanel_D.Update();
            UpdatePanel_Day.Update();
            UpdatePanel_PPMain.Update();
            return;
        }
        for (int i = 0; i <= this.GridView_D.Rows.Count - 1; i++)
        {
            Guid pwpdid = new Guid(GridView_D.DataKeys[i].Values["PWPD_ID"].ToString());
            string note = Convert.ToString(((TextBox)(GridView_D.Rows[i].FindControl("txtNote"))).Text.Trim());
            try
            {
                int plannum = ((TextBox)(GridView_D.Rows[i].FindControl("txtPlan"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_D.Rows[i].FindControl("txtPlan"))).Text.Trim());
                pwpl.U_PWPDetail(pwpdid, plannum, note);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周投产计划应是整数形式，请您再次核对！')", true);
                return;
            }
        }
        GridView_D.Columns[9].Visible = true;
        GridView_D.Columns[13].Visible = true;
        GridView_D.Columns[10].Visible = false;
        GridView_D.Columns[14].Visible = false;
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();
        UpdatePanel_PPMain.Update();

    }
    protected void Button_SaveDay_Click(object sender, EventArgs e)
    {
        if (Label_pwpdetailstate.Text != "已建立" && Label_pwpdetailstate.Text != "审核驳回")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('只能制定‘已建立’和‘审核驳回’状态的计划！')", true);
            GridView_D.SelectedIndex = -1;
            GridView_D.EditIndex = -1;
            string condition1 = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
            GridView_D.DataSource = pwpl.S_PWPDetail(condition1, Proline.Text);
            GridView_D.DataBind();
            GridView_Day.DataSource = pwpl.S_PWPDetail(condition1, Proline.Text);
            GridView_Day.DataBind();
            Panel_D.Visible = true;
            Panel_Day.Visible = true;
            UpdatePanel_D.Update();
            UpdatePanel_Day.Update();
            UpdatePanel_PPMain.Update();
            return;
        }
        for (int i = 0; i <= this.GridView_D.Rows.Count - 1; i++)
        {
            Guid pwpdid = new Guid(GridView_Day.DataKeys[i].Values["PWPD_ID"].ToString());
            string note = Convert.ToString(((TextBox)(GridView_Day.Rows[i].FindControl("txtNoteDay"))).Text.Trim());
            try
            {
                int n1 = ((TextBox)(GridView_Day.Rows[i].FindControl("txtD1"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Day.Rows[i].FindControl("txtD1"))).Text.Trim());
                int n2 = ((TextBox)(GridView_Day.Rows[i].FindControl("txtD2"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Day.Rows[i].FindControl("txtD2"))).Text.Trim());
                int n3 = ((TextBox)(GridView_Day.Rows[i].FindControl("txtD3"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Day.Rows[i].FindControl("txtD3"))).Text.Trim());
                int n4 = ((TextBox)(GridView_Day.Rows[i].FindControl("txtD4"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Day.Rows[i].FindControl("txtD4"))).Text.Trim());
                int n5 = ((TextBox)(GridView_Day.Rows[i].FindControl("txtD5"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Day.Rows[i].FindControl("txtD5"))).Text.Trim());
                int n6 = ((TextBox)(GridView_Day.Rows[i].FindControl("txtD6"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Day.Rows[i].FindControl("txtD6"))).Text.Trim());
                pwpl.U_PWPDetail_Day(pwpdid, n1, n2, n3, n4, n5, n6, note);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('天计划数量应是整数形式，请您再次核对！')", true);
                return;
            }
        }
        GridView_Day.SelectedIndex = -1;
        GridView_Day.EditIndex = -1;
        string condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'";
        GridView_Day.Columns[6].Visible = true;
        GridView_Day.Columns[8].Visible = true;
        GridView_Day.Columns[10].Visible = true;
        GridView_Day.Columns[12].Visible = true;
        GridView_Day.Columns[14].Visible = true;
        GridView_Day.Columns[16].Visible = true;
        GridView_Day.Columns[18].Visible = true;
        GridView_Day.Columns[7].Visible = false;
        GridView_Day.Columns[9].Visible = false;
        GridView_Day.Columns[11].Visible = false;
        GridView_Day.Columns[13].Visible = false;
        GridView_Day.Columns[15].Visible = false;
        GridView_Day.Columns[17].Visible = false;
        GridView_Day.Columns[19].Visible = false;
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        Panel_D.Visible = true;
        Panel_Day.Visible = true;
        UpdatePanel_Day.Update();
        UpdatePanel_PPMain.Update();
    }
    protected void btnDetailReset0_Click(object sender, EventArgs e)//一键复制
    {
        string condition;
        string Series = this.txtSeries.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + this.txtSeries.Text.Trim() + "%'";
        string Name = this.txtType.Text.Trim() == "" ? " and 1=1 " : " and PT_Name  like '%" + this.txtType.Text.Trim() + "%'";
        condition = " and PWP_ID='" + label_pwpid_Detail.Text + "'"  + Series + Name;
        ws.U_PWPDetail_YiJian(condition, Proline.Text);


        GridView_D.PageIndex = 0;
        GridView_Day.PageIndex = 0;

        string condition1;
        string Series1 = this.txtSeries.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + this.txtSeries.Text.Trim() + "%'";
        string Name1 = this.txtType.Text.Trim() == "" ? " and 1=1 " : " and PT_Name  like '%" + this.txtType.Text.Trim() + "%'";
        condition1 = label_Condition.Text + Series1 + Name1;
        Label_searchCondition.Text = condition1;
        GridView_D.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_D.DataBind();
        GridView_Day.DataSource = pwpl.S_PWPDetail(condition, Proline.Text);
        GridView_Day.DataBind();
        UpdatePanel_D.Update();
        UpdatePanel_Day.Update();


    }
    protected void btnDetailResetDay0_Click(object sender, EventArgs e)//制定日期
    {
        try
        {
            ws.U_PWPDetail_Date(label_pwpid_Detail.Text.Trim(), DropDownList1.SelectedValue.ToString().Trim(), DropDownList2.SelectedItem.Text.Trim());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定成功！')", true);
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
            return;
        }
        databinde_detail();
    }
    protected void btnDetailResetDay1_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < DropDownList2.Items.Count && i < 7; i++)
            {
                ws.U_PWPDetail_Date(label_pwpid_Detail.Text.Trim(), DropDownList1.Items[i].Value.ToString().Trim(), DropDownList2.Items[i].Text.Trim());
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定成功！')", true);
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
            return;
        }
        databinde_detail();
    }
}
