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

public partial class ProductionPlanMgt_PPMProMonthPlan : Page
{
    ProductionPlanInfo ppi = new ProductionPlanInfo();
   ProductionPlanD ppp = new ProductionPlanD();
   WSD ws = new WSD();

    protected void Page_Load(object sender, EventArgs e)
    {
        label_GridPageState.Text = "默认数据源";
        if (Request.QueryString["state"] == null)
        {
            label_pagestate.Text = "lookl";
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
        if (state == "lookl")
        {
            if (Proline.Text == "0")
            {
                this.Title = "生产月计划查看";
            }
            else
            {
                this.Title = "模块生产月计划查看";
            }

            GridView_D.Columns[9].Visible = true;
            GridView_D.Columns[13].Visible = true;
            GridView_D.Columns[10].Visible = false;
            GridView_D.Columns[14].Visible = false;
            Button_Save.Visible = false;
            GridView2.Columns[11].Visible = false;
            Button_Subold.Visible = false;
            Button_addpt.Visible = false;
            Button_Subnew.Visible = false;
            Button_addpt2.Visible = false;
            BT_TKOK.Visible = false;
            BT_TKNotOK.Visible = false;
            GridView_New.Columns[11].Visible = false;
            TB_shengchanyijian.Enabled = false;

            btnDetailReset0.Visible = false;//一键复制参考计划至投产计划
        }
        if (state == "manage")
        {
            if (Proline.Text == "0")
            {
                this.Title = "生产月计划管理";
            }
            else
            {
                this.Title = "模块生产计划管理";
            }
            GridView_D.Columns[9].Visible = false;
            GridView_D.Columns[13].Visible = false;
            GridView_D.Columns[10].Visible = true;
            GridView_D.Columns[14].Visible = true;
            BT_TKOK.Visible = false;
            BT_TKNotOK.Visible = false;
            TB_shengchanyijian.Enabled = false;
        }
        if (state == "review")
        {
            if (Proline.Text == "0")
            {
                this.Title = "生产月计划审核";
            }
            else
            {
                this.Title = "模块生产计划审核";
            }
            GridView_D.Columns[9].Visible = true;
            GridView_D.Columns[13].Visible = true;
            GridView_D.Columns[10].Visible = false;
            GridView_D.Columns[14].Visible = false;
            Button_Save.Visible = false;
            GridView2.Columns[11].Visible = false;
            Button_Subold.Visible = false;
            Button_addpt.Visible = false;
            Button_Subnew.Visible = false;
            Button_addpt2.Visible = false;
            GridView_New.Columns[11].Visible = false;

            btnDetailReset0.Visible = false;//一键复制参考计划至投产计划
        }
        if (!IsPostBack)
        {
            Panel2.Visible = false;
            UpdatePanel2.Update();
            DateTime tnow = DateTime.Now;
            for (int m= 1; m <= 12; m++)
            {
                DropDownList_Month.Items.Add(new ListItem(m.ToString(), m.ToString()));
            }
            DropDownList_Month.Items.Insert(0, new ListItem("所有月份", "255"));
            for (int y = 2012; y <= DateTime.Now.Year+1; y++)
            {
                DropDownList_Year.Items.Add(new ListItem(y.ToString(), y.ToString()));
            }
            DropDownList_Year.Items.Insert(0, new ListItem("所有年份", "255"));
           
            string SMSMPM_Year = DropDownList_Year.SelectedValue;
            string SMSMPM_Month = DropDownList_Month.SelectedValue;
            string PMP_State = DropDownList_PState.SelectedValue;
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
            if (TextBox_SPTime1.Text != "")
            {
                stime = Convert.ToDateTime(TextBox_PPTime1.Text);
            }
            else
            {
                stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            if (TextBox_SPTime2.Text != "")
            {
                etime = Convert.ToDateTime(TextBox_PPTime2.Text);
            }
            else
            {
                etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
            }
            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();
            UpdatePanel_PPMain.Update();
        }


    }

    public void dataBind()
    {

        string SMSMPM_Year = DropDownList_Year.SelectedValue;
        string SMSMPM_Month = DropDownList_Month.SelectedValue;
        string PMP_State = DropDownList_PState.SelectedValue;
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

        GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
        GridView2.DataBind();
        UpdatePanel_PPMain.Update();
    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        label_GridPageState.Text = "检索数据源";
        dataBind();
        //无关页面隐藏
        Panel_D.Visible = false;
        Panel_New.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_D.Update();
        UpdatePanel_New.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();

        GridView2.EditIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_New.EditIndex = -1;
        GridView_ProType.EditIndex = -1;
        GridView2.SelectedIndex = -1;
        GridView_D.SelectedIndex = -1;
        GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;

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
        //无关页面隐藏
        Panel_D.Visible = false;
        Panel_New.Visible = false;

        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_D.Update();
        UpdatePanel_New.Update();

        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();

        GridView2.EditIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_New.EditIndex = -1;
        GridView_ProType.EditIndex = -1;
        GridView2.SelectedIndex = -1;
        GridView_D.SelectedIndex = -1;
        GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;

        DropDownList_Year.SelectedIndex = 0;
        DropDownList_Month.SelectedIndex = 0;
        DropDownList_PState.SelectedIndex = 0;

       dataBind();
        UpdatePanel_PPMain.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        clear();


    }
    protected void Button_Add_Click(object sender, EventArgs e)
    {

    }
   
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView2.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView2.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;


       
     
            dataBind();
     
        //绑定数据源

        //bindgridview1();
        //newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        //newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;

        //// specify the NewPageIndex
        //GridView2.PageIndex = newPageIndex;
        //this.GridView2.PageIndex = newPageIndex;
        //this.GridView2.DataBind();

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Review")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            //无关页面隐藏
            Panel_D.Visible = false;
            Panel_New.Visible = false;

            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
           
            //   this.Panel_Sign.Visible = false;
            UpdatePanel_D.Update();
            UpdatePanel_New.Update();

            UpdatePanel_Product.Update();
            //    this.UpdatePanel_Sign.Update();

            //  GridView2.EditIndex = -1;
            GridView_D.EditIndex = -1;
            GridView_New.EditIndex = -1;
            GridView_ProType.EditIndex = -1;
            //  GridView2.SelectedIndex = -1;
            GridView_D.SelectedIndex = -1;
            GridView_New.SelectedIndex = -1;
            GridView_ProType.SelectedIndex = -1;


            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_year.Text = al[1] + "年";
            Label_Month.Text = al[2] + "月 ";
            Label_PMPID.Text = al[0];
            label_PMPState.Text = al[3];
            string condition = " and PMP_ID='" + Label_PMPID.Text + "'";
            if (Label_PMPID.Text == "")
            {

              
               
                TB_shengchanyijian.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该生产月计划尚未制定！您无法审核！')", true);
                return;
            }
            else
            {
                string SMSMPM_Year = DropDownList_Year.SelectedValue;
                string SMSMPM_Month = DropDownList_Month.SelectedValue;
                string PMP_State = DropDownList_PState.SelectedValue;
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
                if (TextBox_SPTime1.Text != "")
                {
                    stime = Convert.ToDateTime(TextBox_PPTime1.Text);
                }
                else
                {
                    stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                }
                if (TextBox_SPTime2.Text != "")
                {
                    etime = Convert.ToDateTime(TextBox_PPTime2.Text);
                }
                else
                {
                    etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
                }

                DataSet ds = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
                DataView dv = ds.Tables[0].DefaultView;

                foreach (DataRowView datav in dv)
                {

                  
                    string a = datav["PMP_RTime"].ToString();
                    if (a == "")
                    {
                        //    this.TB_shengchantime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        //  this.TB_shengchanman.Text = Session["UserName"].ToString();
             
                       

                    }
                    else
                    {
                        DateTime d = Convert.ToDateTime(a);
                   
                    }
                    //    this.TB_shengchantime.Text = datav["PMP_RTime"].ToString();

                    TB_shengchanyijian.Text = datav["PMP_RSuggstion"].ToString();
                }
                GridView1.DataSource = ppp.S_Review(new Guid(Label_PMPID.Text));
                GridView1.DataBind();
                Panel2.Visible = true;
                UpdatePanel2.Update();
            }
        }

        if (e.CommandName == "Detail")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            //无关页面隐藏
            //  this.Panel_D.Visible = false;
            Panel_New.Visible = false;

            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            Panel_Sign.Visible = false;
            //  this.UpdatePanel_D.Update();
            UpdatePanel_New.Update();

            UpdatePanel_Product.Update();
            UpdatePanel_Sign.Update();

            
            GridView2.EditIndex = -1;
            //   GridView_D.EditIndex = -1;
            GridView_New.EditIndex = -1;
            GridView_ProType.EditIndex = -1;
            //  GridView2.SelectedIndex = -1;
            GridView_D.SelectedIndex = -1;
            GridView_New.SelectedIndex = -1;
            GridView_ProType.SelectedIndex = -1;

            txtSeries.Text = "";
            txtType.Text = "";
            string[] a = e.CommandArgument.ToString().Split(new char[] { ',' });
            Lable_PMPID2.Text = a[0];
            if (Lable_PMPID2.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该生产月计划尚未制定！')", true);
                return;
            }
            string id = a[1];
            label_PMPState.Text = a[2];
            if (this.label_pagestate.Text =="manage")
            {
                if (label_PMPState.Text.Trim() != "已建立" && label_PMPState.Text.Trim() != "审核驳回")
                {
                    btnDetailReset0.Visible = false;
                    Button_Subold.Visible = false;
                    Button_Save.Visible = false;
                    Button_addpt.Visible = false;
                }
                else
                {
                    btnDetailReset0.Visible = true;
                    Button_Subold.Visible = true;
                    Button_Save.Visible = true;
                    Button_addpt.Visible = true;
                
                }
            }

            Panel_D.Visible = true;
            Label_SMSMPM_ID.Text = id;
            string condition;
            condition = " and SMSMPM_ID='" + id + "'" + " and SMSMPD_New ='否'";
            Label_time1.Text = a[3] + "年" + a[4] + "月";
            label_Condition.Text = condition;
            GridView_D.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
            GridView_D.DataBind();
            UpdatePanel_D.Update();
        }
        if (e.CommandName == "AddPlan")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            //无关页面隐藏
            Panel_D.Visible = false;
            //  this.Panel_New.Visible = false;

            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            Panel_Sign.Visible = false;
            UpdatePanel_D.Update();
            //  this.UpdatePanel_New.Update();

            UpdatePanel_Product.Update();
            UpdatePanel_Sign.Update();

            // GridView2.EditIndex = -1;
            GridView_D.EditIndex = -1;
            GridView_New.EditIndex = -1;
            GridView_ProType.EditIndex = -1;
            //  GridView2.SelectedIndex = -1;
            GridView_D.SelectedIndex = -1;
            GridView_New.SelectedIndex = -1;
            GridView_ProType.SelectedIndex = -1;


            string[] a = e.CommandArgument.ToString().Split(new char[] { ',' });
            Lable_PMPID2.Text = a[0];
            if (Lable_PMPID2.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该生产月计划尚未制定！')", true);
                return;
            }
            string id = a[1];
            Label_time2.Text = a[2] + "年" + a[3] + "月";
            Panel_New.Visible = true;
            Label_SMSMPM_ID.Text = id;
            string condition = " and SMSMPM_ID='" + id + "'" + "  and SMSMPD_New ='是' ";
            GridView_New.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
            GridView_New.DataBind();
            UpdatePanel_New.Update();

        }
    }
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Gridview2_Editing(object sender, GridViewEditEventArgs e)
    {

        GridView2.EditIndex = e.NewEditIndex;
        GridView2.SelectedIndex = e.NewEditIndex;
        GridView_D.SelectedIndex = -1;
        GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;
        if (GridView2.Rows[e.NewEditIndex].Cells[4].Text == "已提交" || GridView2.Rows[e.NewEditIndex].Cells[4].Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView2.SelectedIndex = -1;
            GridView2.EditIndex = -1;

            if (label_GridPageState.Text == "默认数据源")
            {
                string SMSMPM_Year = DropDownList_Year.SelectedValue;
                string SMSMPM_Month = DropDownList_Month.SelectedValue;
                string PMP_State = DropDownList_PState.SelectedValue;
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
                if (TextBox_SPTime1.Text != "")
                {
                    stime = Convert.ToDateTime(TextBox_PPTime1.Text);
                }
                else
                {
                    stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                }
                if (TextBox_SPTime2.Text != "")
                {
                    etime = Convert.ToDateTime(TextBox_PPTime2.Text);
                }
                else
                {
                    etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
                }

                GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
                GridView2.DataBind();
                UpdatePanel_PPMain.Update();
            }
            if (label_GridPageState.Text == "检索数据源")
            {
                dataBind();
            }
            return;
        }
        //无关页面隐藏
        Panel_D.Visible = false;
        Panel_New.Visible = false;

        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_D.Update();
        UpdatePanel_New.Update();

        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();



        if (label_GridPageState.Text == "默认数据源")
        {
            string SMSMPM_Year = DropDownList_Year.SelectedValue;
            string SMSMPM_Month = DropDownList_Month.SelectedValue;
            string PMP_State = DropDownList_PState.SelectedValue;
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
            if (TextBox_SPTime1.Text != "")
            {
                stime = Convert.ToDateTime(TextBox_PPTime1.Text);
            }
            else
            {
                stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            if (TextBox_SPTime2.Text != "")
            {
                etime = Convert.ToDateTime(TextBox_PPTime2.Text);
            }
            else
            {
                etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
            }

            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();
            UpdatePanel_PPMain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }


    }
    protected void Gridview2_Updating(object sender, GridViewUpdateEventArgs e)
    {
        string SMSMPM_Year = DropDownList_Year.SelectedValue;
        string SMSMPM_Month = DropDownList_Month.SelectedValue;
        string PMP_State = DropDownList_PState.SelectedValue;
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
        if (TextBox_SPTime1.Text != "")
        {
            stime = Convert.ToDateTime(TextBox_PPTime1.Text);
        }
        else
        {
            stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        if (TextBox_SPTime2.Text != "")
        {
            etime = Convert.ToDateTime(TextBox_PPTime2.Text);
        }
        else
        {
            etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }

        string pmid;
        if (GridView2.DataKeys[e.RowIndex].Values["PMP_ID"].ToString() == "")
        {

            pmid = "00000000-0000-0000-0000-000000000000";

        }
        else
        {
            pmid = GridView2.DataKeys[e.RowIndex].Values["PMP_ID"].ToString();
        }
        string condition = " and PMP_ID='" + pmid + "'";
        if (GridView2.Rows[e.RowIndex].Cells[4].Text == "已提交" || GridView2.Rows[e.RowIndex].Cells[4].Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView2.SelectedIndex = -1;
            GridView2.EditIndex = -1;

            if (label_GridPageState.Text == "默认数据源")
            {
                

                GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
                GridView2.DataBind();
                UpdatePanel_PPMain.Update();
            }
            if (label_GridPageState.Text == "检索数据源")
            {
                dataBind();
            }
            return;
        }

        DateTime date1 = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].Cells[7].Controls[1])).Text.Trim());
        DateTime date2 = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].Cells[8].Controls[1])).Text.Trim());
        if (date1 > date2)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划开始时间不能晚于计划结束时间！请再次核对！')", true);
            return;
        }
        
        if (GridView2.DataKeys[e.RowIndex].Values["PMP_ID"].ToString()=="")
        {
            ppi.SMSMPM_ID = new Guid(GridView2.DataKeys[e.RowIndex].Values["SMSMPM_ID"].ToString());
         

            ppi.PMP_Year = Convert.ToInt16(GridView2.Rows[e.RowIndex].Cells[2].Text.Trim());
            ppi.PMP_Month = Convert.ToInt16(GridView2.Rows[e.RowIndex].Cells[3].Text.Trim());
            ppi.PMP_STime = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].Cells[7].Controls[1])).Text.Trim());
            ppi.PMP_ETime = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].Cells[8].Controls[1])).Text.Trim());
            ppi.PMP_Man = Session["UserName"].ToString();
            ppi.Proline = Convert.ToInt32(Proline.Text);
            ppp.I_PMP(ppi);
        }
        else
        {
            ppi.PMP_ID = new Guid(GridView2.DataKeys[e.RowIndex].Values["PMP_ID"].ToString());
            ppi.PMP_STime = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].Cells[7].Controls[1])).Text.Trim());
            ppi.PMP_ETime = Convert.ToDateTime(((TextBox)(GridView2.Rows[e.RowIndex].Cells[8].Controls[1])).Text.Trim());
            ppi.PMP_Man = Session["UserName"].ToString();
             ppi.Proline = Convert.ToInt32(Proline.Text);
            ppp.U_PMP(ppi);
        }
        GridView2.EditIndex = -1;

        if (label_GridPageState.Text == "默认数据源")
        {
            string con = " and 1=1";
            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();
            UpdatePanel_PPMain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }

        GridView2.DataBind();
        UpdatePanel_PPMain.Update();

        //this.GridView2.EditIndex = -1;
    }
    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void Gridview2_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView2.SelectedIndex = -1;
        GridView2.EditIndex = -1;
        //无关页面隐藏
        Panel_D.Visible = false;
        Panel_New.Visible = false;

        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_D.Update();
        UpdatePanel_New.Update();

        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();

        GridView2.EditIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_New.EditIndex = -1;
        GridView_ProType.EditIndex = -1;
        GridView2.SelectedIndex = -1;
        GridView_D.SelectedIndex = -1;
        GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;

        if (label_GridPageState.Text == "默认数据源")
        {
            string SMSMPM_Year = DropDownList_Year.SelectedValue;
            string SMSMPM_Month = DropDownList_Month.SelectedValue;
            string PMP_State = DropDownList_PState.SelectedValue;
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
            if (TextBox_SPTime1.Text != "")
            {
                stime = Convert.ToDateTime(TextBox_PPTime1.Text);
            }
            else
            {
                stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            if (TextBox_SPTime2.Text != "")
            {
                etime = Convert.ToDateTime(TextBox_PPTime2.Text);
            }
            else
            {
                etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
            }
            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();
            UpdatePanel_PPMain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
    }
    protected void BT_TKOK_Click(object sender, EventArgs e)
    {
       
        ppi.PMP_State = "审核通过";
        ppi.PMP_RMan = Session["UserName"].ToString();
        ppi.PMP_ID = new Guid(Label_PMPID.Text.Trim());
        ppi.PMP_RSuggstion = TB_shengchanyijian.Text.Trim();
        ppi.PMPC_ID = new Guid(PMPCID.Text);
        ppp.U_PMP_Review(ppi);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核完成！审核结果：通过！')", true);
        GridView2.DataBind();
        Panel_Sign.Visible = false;
        if (label_GridPageState.Text == "默认数据源")
        {
            string SMSMPM_Year = DropDownList_Year.SelectedValue;
            string SMSMPM_Month = DropDownList_Month.SelectedValue;
            string PMP_State = DropDownList_PState.SelectedValue;
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
            if (TextBox_SPTime1.Text != "")
            {
                stime = Convert.ToDateTime(TextBox_PPTime1.Text);
            }
            else
            {
                stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            if (TextBox_SPTime2.Text != "")
            {
                etime = Convert.ToDateTime(TextBox_PPTime2.Text);
            }
            else
            {
                etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
            }
            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();
            UpdatePanel_PPMain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
        UpdatePanel_PPMain.Update();
        UpdatePanel_Sign.Update();
        GridView1.DataSource = ppp.S_Review(new Guid(Label_PMPID.Text));
        GridView1.DataBind();
        UpdatePanel2.Update();

    }
    protected void BT_TKNotOK_Click(object sender, EventArgs e)
    {
        ppi.PMP_State = "审核驳回";
        ppi.PMP_RMan = Session["UserName"].ToString();
        ppi.PMP_ID = new Guid(Label_PMPID.Text.Trim());
        ppi.PMP_RSuggstion = TB_shengchanyijian.Text.Trim();
        ppi.PMPC_ID = new Guid(PMPCID.Text);
        if (TB_shengchanyijian.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('驳回审核时必须填写审核意见！')", true);
            return;
        }
        ppp.U_PMP_Review(ppi);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核完成！审核结果：驳回！')", true);
        Panel_Sign.Visible = false;
        if (label_GridPageState.Text == "默认数据源")
        {
            string SMSMPM_Year = DropDownList_Year.SelectedValue;
            string SMSMPM_Month = DropDownList_Month.SelectedValue;
            string PMP_State = DropDownList_PState.SelectedValue;
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
            if (TextBox_SPTime1.Text != "")
            {
                stime = Convert.ToDateTime(TextBox_PPTime1.Text);
            }
            else
            {
                stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            if (TextBox_SPTime2.Text != "")
            {
                etime = Convert.ToDateTime(TextBox_PPTime2.Text);
            }
            else
            {
                etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
            }
            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();
            GridView1.DataSource = ppp.S_Review(new Guid(Label_PMPID.Text));
            GridView1.DataBind();
            UpdatePanel2.Update();
            UpdatePanel_PPMain.Update();
            
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            dataBind();
        }
        UpdatePanel_PPMain.Update();
        UpdatePanel_Sign.Update();
        GridView1.DataSource = ppp.S_Review(new Guid(Label_PMPID.Text));
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
    protected void BT_TKCanel_Click(object sender, EventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    protected void GridView_D_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_D_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //无关页面隐藏
        // this.Panel_D.Visible = false;
        Panel_New.Visible = false;

        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        //  this.UpdatePanel_D.Update();
        UpdatePanel_New.Update();

        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();

        //  GridView2.EditIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_New.EditIndex = -1;
        GridView_ProType.EditIndex = -1;
        //  GridView2.SelectedIndex = -1;
        GridView_D.SelectedIndex = -1;
        GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;

        string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='否' ";
        GridView_D.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
        GridView_D.DataBind();
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
        GridView_D.EditIndex = e.NewEditIndex;
        if (label_PMPState.Text == "已提交" || label_PMPState.Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView_D.SelectedIndex = -1;
            GridView_D.EditIndex = -1;

            string condition1 = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='否' ";
            GridView_D.DataSource = ppp.S_PMPDetail(condition1, Proline.Text);
            GridView_D.DataBind();
            UpdatePanel_D.Update();
            return;
        }
        //无关页面隐藏
        // this.Panel_D.Visible = false;
        // this.Panel_New.Visible = false;

        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        //   this.UpdatePanel_D.Update();
        // this.UpdatePanel_New.Update();

        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();

        //  GridView2.EditIndex = -1;
        //  GridView_D.EditIndex = -1;
        GridView_New.EditIndex = -1;
        GridView_ProType.EditIndex = -1;
        //   GridView2.SelectedIndex = -1;
        //    GridView_D.SelectedIndex = -1;
        GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;

        string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='否' ";
        GridView_D.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
        GridView_D.DataBind();
        UpdatePanel_D.Update();
    }

    protected void GridView_D_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void Btn_Close_Detail_Click(object sender, EventArgs e)
    {
        GridView_D.SelectedIndex = -1;
        GridView_D.EditIndex = -1;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        UpdatePanel_Product.Update();
        Panel_D.Visible = false;
        txtSeries.Text = "";
        txtType.Text = "";
        Label_searchCondition.Text = "";
        UpdatePanel_D.Update();
    }
    protected void GridView_New_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_New_CancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_New.EditIndex = -1;
        //无关页面隐藏
        Panel_D.Visible = false;
        // this.Panel_New.Visible = false;

        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_D.Update();
        //    this.UpdatePanel_New.Update();

        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();

        // GridView2.EditIndex = -1;
        GridView_D.EditIndex = -1;
        GridView_New.EditIndex = -1;
        GridView_ProType.EditIndex = -1;
        // GridView2.SelectedIndex = -1;
        GridView_D.SelectedIndex = -1;
        GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;
        string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='是' ";
        GridView_New.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
        GridView_New.DataBind();
    }
    protected void GridView_New_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Review")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_New.SelectedIndex = row.RowIndex;

            //无关页面隐藏
            Panel_D.Visible = false;
            // this.Panel_New.Visible = false;
            //  
            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            Panel_Sign.Visible = false;
            UpdatePanel_D.Update();
            UpdatePanel_New.Update();
            //  
            UpdatePanel_Product.Update();
            UpdatePanel_Sign.Update();

            // GridView2.EditIndex = -1;
            GridView_D.EditIndex = -1;
            //  GridView_New.EditIndex = -1;
            GridView_ProType.EditIndex = -1;
            //  GridView2.SelectedIndex = -1;
            GridView_D.SelectedIndex = -1;
            //   GridView_New.SelectedIndex = -1;
            GridView_ProType.SelectedIndex = -1;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_Result.Text = al[2];

            //if (a != "已提交")
            //{

            //    this.TextBox_NewMan.Text = "";
            //    this.TextBox_NewTime.Text = "";
            //    this.TextBox_Yijian.Text = "";
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('只能审核已提交状态的计划！')", true);
            //    return;
            //}
            //else
            //{


            //}
        }
    }
    protected void GridView_New_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_New_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {

            for (int i = 8; i <= 8; i++)
            {



                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");
            }
            ((TextBox)e.Row.Cells[10].Controls[0]).Attributes.Add("MaxLength", "100");

        }
    }
    protected void GridView_New_Editing(object sender, GridViewEditEventArgs e)
    {
        if (GridView_New.Rows[e.NewEditIndex].Cells[4].Text == "已提交" || GridView_New.Rows[e.NewEditIndex].Cells[4].Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月新增计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView_New.SelectedIndex = -1;
            GridView_New.EditIndex = -1;
            string condition1 = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + "  and SMSMPD_New ='是' ";
            GridView_New.DataSource = ppp.S_PMPDetail(condition1, Proline.Text);
            GridView_New.DataBind();
            GridView_New.DataBind();
            return;
        }
        GridView_New.EditIndex = e.NewEditIndex;

        //无关页面隐藏
        //  this.Panel_D.Visible = false;
        //  this.Panel_New.Visible = false;

        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Sign.Visible = false;
        //  this.UpdatePanel_D.Update();
        //  this.UpdatePanel_New.Update();

        UpdatePanel_Product.Update();
        UpdatePanel_Sign.Update();

        // GridView2.EditIndex = -1;
        GridView_D.EditIndex = -1;
        // GridView_New.EditIndex = -1;
        GridView_ProType.EditIndex = -1;
        //  GridView2.SelectedIndex = -1;
        GridView_D.SelectedIndex = -1;
        //    GridView_New.SelectedIndex = -1;
        GridView_ProType.SelectedIndex = -1;

        string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='是' ";
        GridView_New.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
        GridView_New.DataBind();
        UpdatePanel_New.Update();
    }
    protected void GridView_New_Updating(object sender, GridViewUpdateEventArgs e)
    {
        if (GridView_New.Rows[e.RowIndex].Cells[4].Text == "已提交" || GridView_New.Rows[e.RowIndex].Cells[4].Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月新增计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView_New.SelectedIndex = -1;
            GridView_New.EditIndex = -1;
            string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + "  and SMSMPD_New ='是' ";
            GridView_New.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
            GridView_New.DataBind();
            GridView_New.DataBind();
            return;
        }
        ppi.SMSMPD_ID = new Guid(GridView_New.DataKeys[e.RowIndex].Values["SMSMPD_ID"].ToString());
        try
        {
            ppi.SMSMPD_PMPNum = ((TextBox)(GridView_New.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_New.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('投产计划必须为整数形式！')", true);
            return;
        }
        ppi.SMSMPD_PMPNote = Convert.ToString(((TextBox)(GridView_New.Rows[e.RowIndex].Cells[10].Controls[0])).Text.Trim());
        ppp.U_SMSalesMonthPlanDetail_PMPDetail(ppi);
        GridView_New.EditIndex = -1;
        string condition2 = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='是' ";
        GridView_New.DataSource = ppp.S_PMPDetail(condition2, Proline.Text);
        GridView_New.DataBind();
        UpdatePanel_New.Update();

    }
    protected void GridView_New_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void Btn_Close_New_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        GridView_New.SelectedIndex = -1;
        GridView_New.EditIndex = -1;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        UpdatePanel_Product.Update();

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

    protected void ButtonProType_Click(object sender, EventArgs e) //产品型号提交按钮
    {
        string neworold = Label_PT_NewOrOld.Text.Trim();
        foreach (GridViewRow item in GridView_ProType.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {

                Guid monthplanID = new Guid(Label_SMSMPM_ID.Text);
                Guid PT_ID = new Guid(GridView_ProType.DataKeys[item.RowIndex].Value.ToString());
                DataSet ds = ppp.S_ProType_PMPDetail(monthplanID, PT_ID, neworold);
                if (neworold == "old")
                {
                    if (ds.Tables[0].Rows.Count != 0)// have a check
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_Product, GetType(), "alert", "alert('重复选择产品型号,无法添加!')", true);
                        return;
                    }
                }


                ppp.Insert_I_ProType_PMPDetail(monthplanID, PT_ID, neworold,Session["UserName"].ToString());

                //绑定月新增计划Grid
                string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text + "'" + "  and SMSMPD_New ='是' ";
                GridView_New.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
                GridView_New.DataBind();
                UpdatePanel_New.Update();
                //绑定月详细计划Grid
                string condition2 = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text + "'" + " and SMSMPD_New ='否' ";
                GridView_D.DataSource = ppp.S_PMPDetail(condition2, Proline.Text);
                GridView_D.DataBind();
                UpdatePanel_D.Update();

            }
        }
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
        if (Label_PT_NewOrOld.Text == "old")
        {
            if (Proline.Text == "0")
            {
                GridView_ProType.DataSource = ppp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from SMSalesMonthPlanDetail where SMSMPM_ID='" + Label_SMSMPM_ID.Text + "' and  PS_Name!='模块部新产品' and SMSMPD_New='否') " + GetCondition_ProType(), Proline.Text);
            }
            else
            {
                GridView_ProType.DataSource = ppp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from SMSalesMonthPlanDetail where SMSMPM_ID='" + Label_SMSMPM_ID.Text + "' and  PS_Name='模块部新产品' and SMSMPD_New='否') " + GetCondition_ProType(), Proline.Text);
            }

        }
        else
        {
            GridView_ProType.DataSource = ppp.Select_ProType(GetCondition_ProType(),Proline.Text);
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
        if (Label_PT_NewOrOld.Text == "old")
        {
            if (Proline.Text == "0")
            {
                GridView_ProType.DataSource = ppp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from SMSalesMonthPlanDetail where SMSMPM_ID='" + Label_SMSMPM_ID.Text + "' and   PS_Name!='模块部新产品' and SMSMPD_New='否') " + GetCondition_ProType(), Proline.Text);
            }
            else
            {
                GridView_ProType.DataSource = ppp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from SMSalesMonthPlanDetail where SMSMPM_ID='" + Label_SMSMPM_ID.Text + "' and   PS_Name='模块部新产品' and SMSMPD_New='否') " + GetCondition_ProType(), Proline.Text);   
            }

        }
        else
        {
            GridView_ProType.DataSource = ppp.Select_ProType(GetCondition_ProType(),Proline.Text);
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

    //新增产品型号
    protected void AddProductModell(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        if (label_PMPState.Text == "已提交" || label_PMPState.Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            return;
        }
        Label_PT_NewOrOld.Text = "old";
        Label_newold.Text = "添加型号至当月原计划";
        Panel_Product.Visible = true;
        Panel_Product_Search.Visible = true;
        if (Proline.Text == "0")
        {
            GridView_ProType.DataSource = ppp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from SMSalesMonthPlanDetail where SMSMPM_ID='" + Label_SMSMPM_ID.Text + "' and  PS_Name!='模块部新产品' and SMSMPD_New='否') " + GetCondition_ProType(), Proline.Text);
        }
        else
        {
            GridView_ProType.DataSource = ppp.Select_ProType("and  ProType.PT_ID not in (select PT_ID  from SMSalesMonthPlanDetail where SMSMPM_ID='" + Label_SMSMPM_ID.Text + "' and  PS_Name='模块部新产品' and SMSMPD_New='否') " + GetCondition_ProType(), Proline.Text);
        }
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    protected void AddProductModell_New(object sender, EventArgs e)
    {
        
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Label_PT_NewOrOld.Text = "new";
        Label_newold.Text = "添加型号至当月新增计划";
        Panel_Product.Visible = true;
        Panel_Product_Search.Visible = true;
        GridView_ProType.DataSource = ppp.Select_ProType("",Proline.Text);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
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
    //获取或设置选项中的集合
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

    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Product_Search.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

    }

    protected void Button_Subold_click(object sender, EventArgs e)//提交原生产月计划
    {
        if (label_PMPState.Text == "已提交" || label_PMPState.Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            return;
        }
        try
        {
            Guid pmpid = new Guid(Lable_PMPID2.Text.Trim());
            ppp.U_PMP_State(pmpid);



            Guid SMSMPD_ID;
            string a, b, c;
            for (int i = 0; i <= this.GridView_D.Rows.Count - 1; i++)
            {   int wip;
                int kc;
                int ck;
                SMSMPD_ID = new Guid(GridView_D.DataKeys[i].Values["SMSMPD_ID"].ToString());
                a = GridView_D.DataKeys[i].Values["WIP"].ToString();
                b = GridView_D.DataKeys[i].Values["TotalNum"].ToString();
                c = GridView_D.DataKeys[i].Values["PMPNumRef"].ToString();
                wip = Convert.ToInt32(a);
                kc = Convert.ToInt32(b);
                ck = Convert.ToInt32(c);
                try
                {
                    ppp.U_PMP_WIP(SMSMPD_ID,wip,kc,ck);
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('保存在制品数量、库存、参考投产计划失败！')", true);
                    return;
                }
            }



            string SMSMPM_Year = DropDownList_Year.SelectedValue;
            string SMSMPM_Month = DropDownList_Month.SelectedValue;
            string PMP_State = DropDownList_PState.SelectedValue;
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
            if (TextBox_SPTime1.Text != "")
            {
                stime = Convert.ToDateTime(TextBox_PPTime1.Text);
            }
            else
            {
                stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            if (TextBox_SPTime2.Text != "")
            {
                etime = Convert.ToDateTime(TextBox_PPTime2.Text);
            }
            else
            {
                etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
            }
            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            UpdatePanel_PPMain.Update();
            Panel_D.Visible = false;
            UpdatePanel_D.Update();
            GridView_D.SelectedIndex = -1;
            GridView_D.EditIndex = -1;
            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            UpdatePanel_Product.Update();
            string message = "ERP系统消息： " + Session["UserName"] + " 于 " + DateTime.Now.ToString("F") + " 提交了 " + Label_time1.Text + " 的初始生产月计划，请审核。";
            string sErr = RTXhelper.Send(message, "生产月计划审核");
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


    protected void Button_NewCancel_Click(object sender, EventArgs e)
    {

    }
    protected void Button_NewNotOk_Click(object sender, EventArgs e)
    {
        if (Label_Result.Text != "已提交")
        {


            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('只能审核已提交状态的计划！')", true);

            return;
        }

        //绑定月新增计划Grid
        string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text + "'" + "  and SMSMPD_New ='是' ";
        GridView_New.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
        GridView_New.DataBind();
        UpdatePanel_New.Update();
    }
    protected void Button_NewOK_Click(object sender, EventArgs e)
    {
        if (Label_Result.Text != "已提交")
        {


        }

        string result = "审核通过";

        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核完成！审核结果：通过！')", true);

        //绑定月新增计划Grid
        string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text + "'" + "  and SMSMPD_New ='是' ";
        GridView_New.DataSource = ppp.S_PMPDetail(condition,Proline.Text);
        GridView_New.DataBind();
        UpdatePanel_New.Update();
    }
    protected void Button_Subnew_click(object sender, EventArgs e)
    {
        try
        {
            Guid sMSMPM_ID = new Guid(Label_SMSMPM_ID.Text.Trim());
            ppp.U_SMSalesMonthPlanDetail_PMP_State(sMSMPM_ID);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);
            string condition2 = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='是' ";
            GridView_New.DataSource = ppp.S_PMPDetail(condition2, Proline.Text);
            GridView_New.DataBind();

            UpdatePanel_New.Update();
            string SMSMPM_Year = DropDownList_Year.SelectedValue;
            string SMSMPM_Month = DropDownList_Month.SelectedValue;
            string PMP_State = DropDownList_PState.SelectedValue;
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
            if (TextBox_SPTime1.Text != "")
            {
                stime = Convert.ToDateTime(TextBox_PPTime1.Text);
            }
            else
            {
                stime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            if (TextBox_SPTime2.Text != "")
            {
                etime = Convert.ToDateTime(TextBox_PPTime2.Text);
            }
            else
            {
                etime = Convert.ToDateTime("12/31/9999 11:59:59 PM");
            }
            GridView2.DataSource = ppp.S_PMP(Convert.ToInt32(SMSMPM_Year),Convert.ToInt32(SMSMPM_Month),PMP_State,sman,man,sstime,setime,stime,etime,Convert.ToInt32(Proline.Text));
            GridView2.DataBind();

            GridView_New.SelectedIndex = -1;
            GridView_New.EditIndex = -1;

            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            UpdatePanel_Product.Update();

            // this.Panel_New.Visible = false;
            UpdatePanel_New.Update();
            UpdatePanel_PPMain.Update();
            string message = "ERP系统消息： " + Session["UserName"] + " 于 " + DateTime.Now.ToString("F") + " 提交了 " + Label_time2.Text + " 的新增生产月计划，请审核。";
            string sErr = RTXhelper.Send(message, "生产月计划审核");
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
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }

    }
    protected void GridView_D_DataBound(object sender, EventArgs e)//鼠标悬停
    {
        for (int i = 0; i < GridView_D.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_D.Rows[i].Cells.Count; j++)
            {
                GridView_D.Rows[i].Cells[j].ToolTip = GridView_D.Rows[i].Cells[j].Text;
                if (GridView_D.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_D.Rows[i].Cells[j].Text = GridView_D.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                }
            }
        }
    }
    protected void GridView_New_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_New.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_New.Rows[i].Cells.Count; j++)
            {
                GridView_New.Rows[i].Cells[j].ToolTip = GridView_New.Rows[i].Cells[j].Text;
                if (GridView_New.Rows[i].Cells[j].Text.Length > 8)
                {
                    GridView_New.Rows[i].Cells[j].Text = GridView_New.Rows[i].Cells[j].Text.Substring(0, 8) + "...";
                }


            }
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        GridView1.SelectedIndex = row.RowIndex;
        PMPCID.Text = e.CommandArgument.ToString();
        Panel_Sign.Visible = true;
        UpdatePanel_Sign.Update();
      
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        throw new NotImplementedException();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[1].Text != Session["Department"].ToString())
            {
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[6].ToolTip = "您不属于该部门,不能会签别的部门！";

            }
            if (e.Row.Cells[4].Text == "审核通过" || e.Row.Cells[4].Text == "审核驳回")
            {
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[6].ToolTip = "已经审核过";
            }
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[4].Text == "未建立" || e.Row.Cells[4].Text == "已建立")
            {
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[13].ToolTip = "提交以后才能审核";

            }
            if (e.Row.Cells[4].Text == "未建立" )
            {
                e.Row.Cells[12].Enabled = false;
                e.Row.Cells[12].ToolTip = "还未建立";
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[13].ToolTip = "提交以后才能审核";
                e.Row.Cells[14].Enabled = false;
                e.Row.Cells[14].ToolTip = "还未建立";

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
        GridView_D.DataSource = ppp.S_PMPDetail(condition, Proline.Text);
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
            GridView_D.DataSource = ppp.S_PMPDetail(label_Condition.Text, Proline.Text);
        else
            GridView_D.DataSource = ppp.S_PMPDetail(Label_searchCondition.Text, Proline.Text);
        this.GridView_D.DataBind();
        ExcelHelper.GridViewToExcel(GridView_D, Label_time1.Text+"生产月计划详细表");
        GridView_D.AllowSorting = true;
    }
    protected void btnDetailReset_Click(object sender, EventArgs e)
    {
        txtSeries.Text = "";
        txtType.Text = "";
        Label_searchCondition.Text = "";
        GridView_D.DataSource = ppp.S_PMPDetail(label_Condition.Text, Proline.Text);
        GridView_D.DataBind();
        UpdatePanel_D.Update();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Button_Save_Click(object sender, EventArgs e)
    {
        if (label_PMPState.Text == "已提交" || label_PMPState.Text == "审核通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('月计划已提交或审核通过时，您不能再进行修改和变动！')", true);
            GridView_D.SelectedIndex = -1;
            GridView_D.EditIndex = -1;
            string condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='否' ";
            GridView_D.DataSource = ppp.S_PMPDetail(condition, Proline.Text);
            GridView_D.DataBind();
            UpdatePanel_D.Update();
            return;
        }
        for (int i = 0; i <= this.GridView_D.Rows.Count - 1; i++)
        {
            ppi.SMSMPD_ID = new Guid(GridView_D.DataKeys[i].Values["SMSMPD_ID"].ToString());

            try
            {
                ppi.SMSMPD_PMPNum = ((TextBox)(GridView_D.Rows[i].FindControl("txtPlan"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_D.Rows[i].FindControl("txtPlan"))).Text.Trim());
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('投产计划必须为整数形式！')", true);
                return;
            }
            ppi.SMSMPD_PMPNote = Convert.ToString(((TextBox)(GridView_D.Rows[i].FindControl("txtNote"))).Text.Trim());
            ppp.U_SMSalesMonthPlanDetail_PMPDetail(ppi);
        }
        GridView_D.EditIndex = -1;
        string condition2 = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim() + "'" + " and SMSMPD_New ='否' ";
        GridView_D.Columns[9].Visible = true;
        GridView_D.Columns[13].Visible = true;
        GridView_D.Columns[10].Visible = false;
        GridView_D.Columns[14].Visible = false;
        GridView_D.DataSource = ppp.S_PMPDetail(condition2, Proline.Text);
        GridView_D.DataBind();
        UpdatePanel_D.Update();
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('保存成功!')", true);
    }
    protected void btnDetailReset0_Click(object sender, EventArgs e)//一键复制参考计划
    {
        string condition;
        string Series = this.txtSeries.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + this.txtSeries.Text.Trim() + "%'";
        string Name = this.txtType.Text.Trim() == "" ? " and 1=1 " : " and PT_Name  like '%" + this.txtType.Text.Trim() + "%'";
        condition = " and SMSMPM_ID='" + Label_SMSMPM_ID.Text.Trim()+ "'" + " and SMSMPD_New ='否'" + Series + Name;
        ws.U_PMPDetail_YiJian(condition, Proline.Text);


        GridView_D.PageIndex = 0;
        string condition1;
        string Series1 = this.txtSeries.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + this.txtSeries.Text.Trim() + "%'";
        string Name1 = this.txtType.Text.Trim() == "" ? " and 1=1 " : " and PT_Name  like '%" + this.txtType.Text.Trim() + "%'";
        condition1 = label_Condition.Text + Series1 + Name1;
        Label_searchCondition.Text = condition1;
        GridView_D.DataSource = ppp.S_PMPDetail(condition1, Proline.Text);
        GridView_D.DataBind();
        UpdatePanel_D.Update();
    }
}