using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EquipmentMangementAjax.SQLServer;

public partial class ProductionPlanMgt_PMPCBasic : Page
{
    ProductionPlanL pp = new ProductionPlanL();
    ProductionPlanD ppp=new ProductionPlanD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.QueryString["state"] == null)
            //{
            //    this.label_pagestate.Text = "look";
            //}
            //else
            //{
            //    this.label_pagestate.Text = Request.QueryString["state"];
            //}

            //if (state == "look")
            //{
            //    this.Title = "生产月计划会签部门查看";
            //    GridView_LPT.DataSource = ppp.S_PMPCountersignBasic("and PMPCB_Type = '1'");
            //    GridView_LPT.DataBind();
            //    UpdatePanel_pt.Update();
            //    Button_ChosePT.Visible = false;
            //    Gridiew_VLPT.Columns[0].Visible = false;
            //    CheckBoxAll.Visible = false;
            //    CheckBoxfanxuan.Visible = false;
            //    Btn_deleting.Visible = false;

            //}
            GetCondition1();
        }
    }

    protected string GetCondition1()//用于GridView_LPT绑定
    {
        label_pagestate.Text = Request.QueryString["state"];
        string state = label_pagestate.Text;

        string condition1;
        string temp = "";
        if (state == "scyjhhqbmgl")
        {
            Title = "生产月计划会签维护";
            GridView_LPT.DataSource = ppp.S_PMPCountersignBasic("and PMPCB_Type = '1'");
            GridView_LPT.DataBind();
            UpdatePanel_pt.Update();
        }
        if (state == "sczjhhqbmgl")
        {
            Title = "生产周计划会签维护";
            GridView_LPT.DataSource = ppp.S_PMPCountersignBasic("and PMPCB_Type = '3'");
            GridView_LPT.DataBind();
            UpdatePanel_pt.Update();
        }
        if (state == "mkyjhhqbmgl")
        {
            Title = "模块月计划会签维护";
            GridView_LPT.DataSource = ppp.S_PMPCountersignBasic("and PMPCB_Type = '2'");
            GridView_LPT.DataBind();
            UpdatePanel_pt.Update();
        }
        if (state == "mkzjhhqbmgl")
        {
            Title = "模块周计划会签维护";
            GridView_LPT.DataSource = ppp.S_PMPCountersignBasic("and PMPCB_Type = '4'");
            GridView_LPT.DataBind();
            UpdatePanel_pt.Update();
        }
        condition1 = temp;
        return condition1;
    }

    protected string GetCondition2()//用于GridView_ProType绑定
    {
        label_pagestate.Text = Request.QueryString["state"];
        string state = label_pagestate.Text;

        string condition2;
        string temp = "";
        if (state == "scyjhhqbmgl")
        {
            GridView_ProType.DataSource = ppp.S_PMPCountersignBasic_BD(" PMPCB_Type = '1'");
            GridView_ProType.DataBind();
        }
        if (state == "sczjhhqbmgl")
        {
            GridView_ProType.DataSource = ppp.S_PMPCountersignBasic_BD(" PMPCB_Type = '3'");
            GridView_ProType.DataBind();
        }
        if (state == "mkyjhhqbmgl")
        {
            GridView_ProType.DataSource = ppp.S_PMPCountersignBasic_BD(" PMPCB_Type = '2'");
            GridView_ProType.DataBind();
        }
        if (state == "mkzjhhqbmgl")
        {
            GridView_ProType.DataSource = ppp.S_PMPCountersignBasic_BD(" PMPCB_Type = '4'");
            GridView_ProType.DataBind();
        }
        condition2 = temp;
        return condition2;
    }

    protected void Button_ChosePT_Click(object sender, EventArgs e)
    {
        Panel_Product.Visible = true;
        //GridView_ProType.DataSource = ppp.S_PMPCountersignBasic_BD("and PMPCB_Type = '1'");
        //GridView_ProType.DataBind();
        GetCondition2();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        UpdatePanel_Product.Update();
    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    ppp.D_PMPCountersignBasic(new Guid(GridView_LPT.DataKeys[i].Values["PMPCB_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的会签部门！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }

        //GridView_LPT.DataSource = ppp.S_PMPCountersignBasic();
        //GridView_LPT.DataBind();
        //UpdatePanel_pt.Update();
        GetCondition1();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    //ppp.I_PMPCountersignBasic(GridView_ProType.DataKeys[i].Values["BDOS_Code"].ToString().Trim(),'1');
                    //sum++;
                    label_pagestate.Text = Request.QueryString["state"];
                    string state = label_pagestate.Text;
                    if (state == "scyjhhqbmgl")
                    {
                        ppp.I_PMPCountersignBasic(GridView_ProType.DataKeys[i].Values["BDOS_Code"].ToString().Trim(),1);
                    }
                    if (state == "sczjhhqbmgl")
                    {
                        ppp.I_PMPCountersignBasic(GridView_ProType.DataKeys[i].Values["BDOS_Code"].ToString().Trim(), 3);
                    }
                    if (state == "mkyjhhqbmgl")
                    {
                        ppp.I_PMPCountersignBasic(GridView_ProType.DataKeys[i].Values["BDOS_Code"].ToString().Trim(), 2);
                    }
                    if (state == "mkzjhhqbmgl")
                    {
                        ppp.I_PMPCountersignBasic(GridView_ProType.DataKeys[i].Values["BDOS_Code"].ToString().Trim(), 4);
                    }
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的部门！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);


        }
        //GridView_LPT.DataSource = ppp.S_PMPCountersignBasic();
        //GridView_LPT.DataBind();
        //UpdatePanel_pt.Update();
        GetCondition1();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox2.Checked = false;
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
            if (CheckBoxAll.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxfanxuan.Checked = false;
    }
    protected void Checkfanxuan_CheckedChanged(object sender, EventArgs e)
    {

        for (int i = 0; i <= GridView_LPT.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_LPT.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxAll.Checked = false;
    }
    protected void GridView_LPT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_LPT.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_LPT.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_LPT.PageCount ? GridView_LPT.PageCount - 1 : newPageIndex;
        GridView_LPT.PageIndex = newPageIndex;

        //GridView_LPT.DataSource = ppp.S_PMPCountersignBasic();
        //GridView_LPT.DataBind();
        //UpdatePanel_pt.Update();
        GetCondition1();
       
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_ProType.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_ProType.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;

        //GridView_ProType.DataSource = ppp.S_PMPCountersignBasic_BD();
        //GridView_ProType.DataBind();
        GetCondition2();
        UpdatePanel_Product.Update();


        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
}