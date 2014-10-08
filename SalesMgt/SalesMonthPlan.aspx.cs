using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class SalesMgt_SalesMonthPlan : Page
{
    SalesMonthPlanL mp = new SalesMonthPlanL();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
          
            label_mainsource.Text = "default";
            Panel_Search.Visible = true;
            Panel_MonthPlan.Visible = true;
            BindGridview_MonthPlan_Default();
            BindDropDownlist();
            DropDownList5.Items.Insert(0, new ListItem("选择状态", ""));
            UpdatePanel_Search.Update();
            UpdatePanel_MonthPlan.Update();
            BindDropDownlist2();

            //string iid="37932F6E-1FDE-4FAA-9BE7-9154F0394074";
            //this.Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(new Guid(iid));
            //this.Gridview_MonthPlanDetail.DataBind();
            //this.Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(iid));
            //this.Gridview_MonthPlanDetailAdd.DataBind();
        }
        #region 权限控制
        try
        {
            if (!((Session["UserRole"].ToString().Contains("销售月计划查看")) || (Session["UserRole"].ToString().Contains("销售月计划制定")) ||
          (Session["UserRole"].ToString().Contains("销售月计划会签")) || (Session["UserRole"].ToString().Contains("销售月计划审核")) || (Session["UserRole"].ToString().Contains("新增销售月计划审核"))))
            {
                Response.Redirect("~/Default.aspx");

            }
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }
        //销售月计划制定/查看 会签5 审核1 新增审核权限

        //if (Session["UserRole"].ToString().Contains("销售月计划查看"))
        if (Request.QueryString["status"] == "SalesMonthPlanLook")
        {
            Title = "销售月计划查看";
           
            Gridview_MonthPlan.Columns[6].Visible = true;
            Gridview_MonthPlan.Columns[7].Visible = true;
            UpdatePanel_MonthPlan.Update();
            Gridview_MonthPlanDetail.Columns[6].Visible = true;
            Gridview_MonthPlanDetail.Columns[7].Visible = true;
            UpdatePanel_MonthPlan.Update();
            Button2.Visible = false;
            UpdatePanel_Search.Update();
            Button8.Visible = false;
            Button15.Visible = false;
            Button10.Visible = false;
            Gridview_MonthPlanDetail.Columns[10].Visible = false;
            Gridview_MonthPlanDetail.Columns[11].Visible = false;
            UpdatePanel_MonthPlanDetail.Update();
            Button11.Visible = false;
            Button16.Visible = false;
            Button13.Visible = false;
            Gridview_MonthPlanDetailAdd.Columns[10].Visible = false;
            Gridview_MonthPlanDetailAdd.Columns[11].Visible = false;
            Gridview_MonthPlanDetailAdd.Columns[12].Visible = false;
            UpdatePanel_MonthPlanDetail_Add.Update();
        }
        //if (Session["UserRole"].ToString().Contains("SalesMonthPlanEdit"))
        if (Request.QueryString["status"] == "SalesMonthPlanEdit")
        {
            Title = "销售月计划维护";
            for (int i = 6; i != 10; i++)
            {
                Gridview_MonthPlan.Columns[i].Visible = true;
            }
            Gridview_MonthPlan.Columns[13].Visible = true;
            UpdatePanel_MonthPlan.Update();
            Button2.Visible = true;
            UpdatePanel_Search.Update();
            //this.Gridview_MonthPlanDetail.Columns[11].Visible = true;
            //this.Gridview_MonthPlanDetail.Columns[10].Visible = true;
            //this.Gridview_MonthPlanDetailAdd.Columns[15].Visible = true;
            //this.Gridview_MonthPlanDetailAdd.Columns[10].Visible = true;
            //this.Gridview_MonthPlanDetailAdd.Columns[11].Visible = true;
            //this.Gridview_MonthPlanDetailAdd.Columns[13].Visible = true;
            //this.Gridview_MonthPlanDetailAdd.Columns[14].Visible = true;
            //this.Button8.Visible = true;
            //this.Button15.Visible = true;
            //this.Button10.Visible = true;
            //this.Button11.Visible = true;
            //this.Button16.Visible = true;
            //this.Button13.Visible = true;
            UpdatePanel_MonthPlanDetail.Update();
            UpdatePanel_MonthPlanDetail_Add.Update();
            UpdatePanel_MonthPlan.Update();
        }
        //if (Session["UserRole"].ToString().Contains("销售月计划会签"))
        if (Request.QueryString["status"] == "SalesMonthPlanSign")
        {
            Title = "销售月计划会签";
            Gridview_MonthPlan.Columns[6].Visible = true;
            Gridview_MonthPlan.Columns[7].Visible = true;
            Gridview_MonthPlan.Columns[10].Visible = true;
            Button2.Visible = false;
            UpdatePanel_Search.Update();
            UpdatePanel_MonthPlan.Update();
        }
        //if (Session["UserRole"].ToString().Contains("销售月计划审核"))
        if (Request.QueryString["status"] == "SalesMonthPlanCheck")
        {
            Title = "销售月计划审核";
            Gridview_MonthPlan.Columns[6].Visible = true;
            Gridview_MonthPlan.Columns[7].Visible = true;
            Gridview_MonthPlan.Columns[11].Visible = true;
            Button2.Visible = false;
            UpdatePanel_Search.Update();
            UpdatePanel_MonthPlan.Update();
        }
        //if (Session["UserRole"].ToString().Contains("新增销售月计划审核"))
        if (Request.QueryString["status"] == "SalesMonthPlanCheckNew")
        {
            Title = "新增销售月计划审核";
            Button2.Visible = false;
            Gridview_MonthPlan.Columns[6].Visible = true;
            Gridview_MonthPlan.Columns[7].Visible = true;
            UpdatePanel_MonthPlan.Update();
            Gridview_MonthPlanDetailAdd.Columns[15].Visible = true;
            UpdatePanel_MonthPlanDetail_Add.Update();
        }
        #endregion
    }
    #region 月计划主表和详细表
    //绑定年月下拉框
    protected void BindDropDownlist()
    {
        DropDownList4.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        DropDownList1.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        for (int y = 1; y <= 12; y++)
        {
            DropDownList4.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList1.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    //绑定年月下拉框2
    protected void BindDropDownlist2()
    {
        DropDownList2.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        DropDownList3.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        for (int y = 1; y <= 12; y++)
        {
            DropDownList3.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList2.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    //默认绑定月计划表
    protected void BindGridview_MonthPlan_Default()
    {
        Gridview_MonthPlan.DataSource = mp.Select_SalesMonthPlan_Bindgridview();
        Gridview_MonthPlan.DataBind();
    }
    //模糊查询绑定月计划主表
    protected void BindGridview_MonthPlan_Search()
    {
        label_mainsource.Text = "search";
        Gridview_MonthPlan.DataSource = mp.Select_SalesMonthPlan(label_condition.Text.ToString());
        Gridview_MonthPlan.DataBind();
    }
    //绑定月计划主表
    protected void BindGridview_MonthPlan()
    {
        if (label_mainsource.Text == "search")
        {
            BindGridview_MonthPlan_Search();
        }
        if (label_mainsource.Text == "default")
        {
            BindGridview_MonthPlan_Default();
        }
    }
    //点击检索按钮
    protected void SearchMonthPlan(object sender, EventArgs e)
    {
        label_condition.Text = GetCodition();
        label_mainsource.Text = "search";
        BindGridview_MonthPlan_Search();
        UpdatePanel_MonthPlan.Update();
        Panel_MonthPlanDetail.Visible = false;
        UpdatePanel_MonthPlanDetail.Update();
        Panel_MonthPlanDetail_Add.Visible = false;
        UpdatePanel_MonthPlanDetail_Add.Update();
        


    }
    //检索条件获得
    protected string GetCodition()
    {
        string conditon;
        string temp = "";
        if (DropDownList1.Text.ToString() != "选择年份")
        {
            temp += " and SMSMPM_Year like'" + DropDownList1.SelectedValue.ToString() + "'";

        }
        if (DropDownList4.Text.ToString() != "选择月份")
        {
            temp += " and SMSMPM_Month like'" + DropDownList4.SelectedValue.ToString() + "'";
        }
        if (DropDownList5.Text.ToString() != "")
        {
            temp += " and SMSMPM_State ='" + DropDownList5.SelectedValue.ToString() + "'";
        }

        conditon = temp;
        label_condition.Text = conditon;
        return conditon;
    }
    //新建月计划
    protected void CreateMonthPlan(object sender, EventArgs e)
    {
        
        DropDownList2.SelectedValue = DateTime.Now.Year.ToString();
        DropDownList3.SelectedValue = DateTime.Now.AddMonths(1).Month.ToString();
        Panel_NewMonthPlan.Visible = true;
        MakeMan.Text = Session["UserName"].ToString();
        UpdatePanel_NewMonthPlan.Update();


    }
    //新建月计划提交
    protected void NewMonthPlan(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue.ToString() == "选择年份")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewMonthPlan, GetType(), "alert", "alert('请选择年份！')", true);
            return;
        }

        if (DropDownList3.SelectedValue.ToString() == "选择月份")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewMonthPlan, GetType(), "alert", "alert('请选择月份！')", true);
            return;
        }
        int year = Convert.ToInt32(DropDownList2.SelectedValue.ToString());
        int month = Convert.ToInt32(DropDownList3.SelectedValue.ToString());
        string man = MakeMan.Text.ToString();
        if (TextBox1.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewMonthPlan, GetType(), "alert", "alert('请填写第一周开始时间！')", true);
            return;
        }
        if (TextBox2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewMonthPlan, GetType(), "alert", "alert('请填写第一周结束时间！')", true);
            return;
        }
        DateTime start = Convert.ToDateTime(TextBox1.Text.ToString());
        DateTime end = Convert.ToDateTime(TextBox2.Text.ToString());
        if (start >= end)
        {

            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewMonthPlan, GetType(), "alert", "alert('请确认开始时间小于结束时间！')", true);
            return;
        }
        int rep=mp.Insert_SalesMonthPlan(year, month, man, start, end);
       
        if (rep != 0)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewMonthPlan, GetType(), "alert", "alert('不可以重复新建相同年月份的计划！')", true);
            return;
        }
        else
        {
  
            //BindGridview_MonthPlan_Default();
            BindGridview_MonthPlan();
            DataSet ds = mp.SelectMonthPlanMainID(year, month);
            mp.Insert_MonthPlanDetail_Auto(new Guid(ds.Tables[0].Rows[0][0].ToString()));
            Panel_NewMonthPlan.Visible = false;
            UpdatePanel_MonthPlan.Update();
            UpdatePanel_NewMonthPlan.Update();
            //BindGridview_MonthPlan();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewMonthPlan, GetType(), "alert", "alert('请点击“编辑详细”开始填写月计划详细内容！')", true);
        }
    }
    //新建月计划关闭
    protected void CloseMonthPlan(object sender, EventArgs e)
    {
        Panel_NewMonthPlan.Visible = false;
        UpdatePanel_NewMonthPlan.Update();
    }
    //显示初始月计划详细-button
    protected void OriginalMonthPlanDetail(object sender, EventArgs e)
    {
        //this.Panel_ControlButton.Visible = true;
        Panel_MonthPlanDetail.Visible = true;
        Panel_MonthPlanDetail_Add.Visible =false ;
        UpdatePanel_MonthPlanDetail.Update();
        //this.UpdatePanel_MonthPlanDetail_Button.Update();
        UpdatePanel_MonthPlanDetail_Add.Update();
    }
    //显示新增月计划详细-button
    protected void AddMonthPlanDetail(object sender, EventArgs e)
    {
        //this.Panel_ControlButton.Visible = true;
        Panel_MonthPlanDetail.Visible = false;
        Panel_MonthPlanDetail_Add.Visible = true;
        UpdatePanel_MonthPlanDetail.Update();
        //this.UpdatePanel_MonthPlanDetail_Button.Update();
        UpdatePanel_MonthPlanDetail_Add.Update();
    }
    //显示全部月计划详细-button
    protected void AllMonthPlanDetail(object sender, EventArgs e)
    {
        //this.Panel_ControlButton.Visible = true;
        Panel_MonthPlanDetail.Visible = true;
        Panel_MonthPlanDetail_Add.Visible = true;
        UpdatePanel_MonthPlanDetail.Update();
        //this.UpdatePanel_MonthPlanDetail_Button.Update();
        UpdatePanel_MonthPlanDetail_Add.Update();
        
    }
    #endregion

    #region 新建-编辑月计划详细
    //提交月计划详细
    protected void NewMonthPlanDetail(object sender, EventArgs e)
    {
        label_way.Text = "submit";
        
        string way = label_way.Text.ToString();
        //第几周的安排量和产品要求我先不做，先都default
        int first = 0;
        int second = 0;
        int third = 0;
        int forth = 0;
        //string request = "";
        Guid mainID=new Guid ( label_mainid.Text.ToString());
        for (int i = 0; i <= Gridview_MonthPlanDetail.Rows.Count - 1; i++)
        {
            string temp1 = Gridview_MonthPlanDetail.DataKeys[i].Value.ToString();
            Guid detailID = new Guid(temp1);
            decimal plan;
            //string temp = this.Gridview_MonthPlanDetail.Rows[i].Cells[0].Text.ToString();
            //Guid  detailID=new Guid(this.Gridview_MonthPlanDetail.Rows[i].Cells[0].Text.ToString());
            //failure reason:the unvisiable rows and cells cannot be reach
            TextBox cbox1 = (TextBox)Gridview_MonthPlanDetail.Rows[i].FindControl("TextBox5");
            TextBox cbox2 = (TextBox)Gridview_MonthPlanDetail.Rows[i].FindControl("TextBox6");
            TextBox cbox = (TextBox)Gridview_MonthPlanDetail.Rows[i].FindControl("TextBox3");
            if (cbox.Text == "")
            {
                cbox.Text =  Gridview_MonthPlanDetail.Rows[i].Cells[6].Text.ToString().Trim();
                plan = 0;
            }
            else
            {
                plan = Convert.ToDecimal(cbox.Text.ToString());
            }
            if (cbox1.Text == "")
            {
                cbox1.Text = Gridview_MonthPlanDetail.Rows[i].Cells[8].Text.ToString().Trim();
            }
            if (cbox2.Text == "")
            {
                cbox2.Text = Gridview_MonthPlanDetail.Rows[i].Cells[10].Text.ToString().Trim();
            }
            if (cbox1.Text == "&nbsp;")
            {
                cbox1.Text = "";
            }
            if (cbox2.Text == "&nbsp;")
            {
                cbox2.Text = "";
            }
            string request = cbox1.Text.ToString();
            string remark = cbox2.Text.ToString();
            mp.Update_MonthPlanDetail_Main(mainID,detailID,plan,first,second ,third,forth,request,remark,way);
        }
        Save();
        Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(mainID);
        Gridview_MonthPlanDetail.DataBind();
        UpdatePanel_Product.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('提交成功!')", true);

        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了下月的初始销售月计划，请会签！";
        string sErr = RTXhelper.Send(remind, "销售月计划会签");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        Panel_MonthPlanDetail.Visible = false;
        UpdatePanel_MonthPlanDetail.Update();
        BindGridview_MonthPlan();
    }
    //保存月计划详细
    protected void Save()
    {
        label_way.Text = "save";
        string way = label_way.Text.ToString();
        //第几周的安排量和产品要求我先不做，先都default
        int first = 0;
        int second = 0;
        int third = 0;
        int forth = 0;
        Guid mainID = new Guid(label_mainid.Text.ToString());
        for (int i = 0; i <= Gridview_MonthPlanDetail.Rows.Count - 1; i++)
        {
            Guid detailID = new Guid(Gridview_MonthPlanDetail.DataKeys[i].Value.ToString());
            TextBox cbox = (TextBox)Gridview_MonthPlanDetail.Rows[i].FindControl("TextBox3");
            TextBox cbox1 = (TextBox)Gridview_MonthPlanDetail.Rows[i].FindControl("TextBox5");
            TextBox cbox2 = (TextBox)Gridview_MonthPlanDetail.Rows[i].FindControl("TextBox6");
            decimal planamount;
            if (cbox.Text == "")
            {
                cbox.Text = Gridview_MonthPlanDetail.Rows[i].Cells[6].Text.ToString().Trim();
                planamount = 0;
            }
            else
            {
                //int plan = Convert.ToInt32(cbox.Text.ToString());
                 planamount = Convert.ToDecimal(Convert.ToDecimal(cbox.Text.ToString()));
            }
            if (cbox1.Text == "")
            {
                cbox1.Text = Gridview_MonthPlanDetail.Rows[i].Cells[8].Text.ToString().Trim();
            }
            if (cbox2.Text == "")
            {
                cbox2.Text = Gridview_MonthPlanDetail.Rows[i].Cells[10].Text.ToString().Trim();
            }
            if (cbox1.Text == "&nbsp;")
            {
                cbox1.Text = "";
            }
            if (cbox2.Text == "&nbsp;")
            {
                cbox2.Text = "";
            }
            string request = cbox1.Text.ToString();
            string remark = cbox2.Text.ToString();
            mp.Update_MonthPlanDetail_Main(mainID, detailID, planamount, first, second, third, forth, request, remark, way);
        }
        Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(mainID);
        Gridview_MonthPlanDetail.DataBind();
        UpdatePanel_Product.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('保存成功!')", true);

    }//为了在翻页的时候保存一次，把这个东西单独拿出来
    protected void SaveMonthPlanDetail(object sender, EventArgs e)
    {
        Save();
        Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(new Guid(label_mainid.Text.ToString()));
        Gridview_MonthPlanDetail.DataBind();
        UpdatePanel_Product.Update();
        
        //this.label_way.Text = "save";
        //string way = this.label_way.Text.ToString();
        ////第几周的安排量和产品要求我先不做，先都default
        //int first = 0;
        //int second = 0;
        //int third = 0;
        //int forth = 0;
        //string request = "";
        //Guid mainID = new Guid(this.label_mainid.Text.ToString());
        //for (int i = 0; i <= this.Gridview_MonthPlanDetail.Rows.Count - 1; i++)
        //{
        //    Guid detailID = new Guid(this.Gridview_MonthPlanDetail.Rows[i].Cells[0].Text.ToString());
        //    TextBox cbox = (TextBox)Gridview_MonthPlanDetail.Rows[i].FindControl("TextBox3");
        //    int plan = Convert.ToInt32(cbox.Text.ToString());
        //    mp.Update_MonthPlanDetail_Main(mainID, detailID, plan, first, second, third, forth, request, way);
        //}
        //this.Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(mainID);
        //this.Gridview_MonthPlanDetail.DataBind();
        //this.UpdatePanel_Product.Update();
    }
    //取消提交月计划详细
    protected void CloseMonthPlanDetail(object sender, EventArgs e)
    {
        Panel_MonthPlanDetail.Visible = false;
        UpdatePanel_MonthPlanDetail.Update();
    }
    //提交月计划详细
    protected void NewMonthPlanDetail_Add(object sender, EventArgs e)
    {
        label_wayadd.Text = "submit";
        SaveAdd();
        Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(label_mainid.Text.ToString()));
        Gridview_MonthPlanDetailAdd.DataBind();
        UpdatePanel_ADDCheck.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('提交成功!')", true);
        //string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + System.DateTime.Now.ToString("F") + "提交了本月的新增销售月计划，请审核！";
        //string sErr = RTXhelper.Send(remind, "新增销售月计划审核");
        //if (!string.IsNullOrEmpty(sErr))
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('" + sErr + "')", true);
        //}
    }
    //保存月计划详细
    protected void SaveAdd()
    {
        string way = label_wayadd.Text.ToString();
        string man = Session["UserName"].ToString();
        for (int i = 0; i <= Gridview_MonthPlanDetailAdd.Rows.Count - 1; i++)
        {
            Guid detailID = new Guid(Gridview_MonthPlanDetailAdd.DataKeys[i].Value.ToString());
            TextBox cbox = (TextBox)Gridview_MonthPlanDetailAdd.Rows[i].FindControl("TextBox4");
            TextBox cbox1 = (TextBox)Gridview_MonthPlanDetailAdd.Rows[i].FindControl("TextBox7");
            TextBox cbox2 = (TextBox)Gridview_MonthPlanDetailAdd.Rows[i].FindControl("TextBox8");
            if (cbox.Text == "")
            {
                cbox.Text = Gridview_MonthPlanDetailAdd.Rows[i].Cells[6].Text.ToString().Trim();
            }
            if (cbox1.Text == "")
            {
                cbox1.Text = Gridview_MonthPlanDetailAdd.Rows[i].Cells[8].Text.ToString().Trim();
            }
            if (cbox2.Text == "")
            {
                cbox2.Text = Gridview_MonthPlanDetailAdd.Rows[i].Cells[10].Text.ToString().Trim();
            }
            if (cbox1.Text == "&nbsp;")
            {
                cbox1.Text = "";
            }
            if (cbox2.Text == "&nbsp;")
            {
                cbox2.Text = "";
            }
            decimal plan;
            if (cbox.Text != ""&&cbox.Text!="&nbsp;")
            {
                plan = Convert.ToDecimal(cbox.Text.ToString());
            }
            else
            {
                plan = 0;
            }
            string request = cbox1.Text.ToString().Replace("&nbsp;", "");
            string remark = cbox2.Text.ToString().Replace("&nbsp;", "");
            mp.Update_MonthPlanDetail_ADD(detailID, plan, request, man, remark,way);
        }
    }
    //保存新增的月计划详细
    protected void SaveMonthPlanDetail_Add(object sender, EventArgs e)
    {
        label_wayadd.Text = "save";
        SaveAdd();
        Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(label_mainid.Text.ToString()));
        Gridview_MonthPlanDetailAdd.DataBind();
        UpdatePanel_ADDCheck.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('保存成功!')", true);

    }
    //取消提交月计划详细
    protected void CloseMonthPlanDetail_Add(object sender, EventArgs e)
    {
        Panel_MonthPlanDetail_Add.Visible = false;
        UpdatePanel_MonthPlanDetail_Add.Update();
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
    }
    //新增产品型号
    protected void AddProductModell(object sender, EventArgs e)
    {
        label_grid.Text = "old";
        Panel_Product.Visible = true;
        Panel1.Visible = true;
        GridView_ProType.DataSource = mp.Select_ProType("");
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    protected void AddProductModell1(object sender, EventArgs e)
    {
        label_grid.Text = "new";
        Panel_Product.Visible = true;
        Panel1.Visible = true;
        GridView_ProType.DataSource = mp.Select_ProType("");
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    //绑定产品型号表，查询结果
    protected  void SelectProType(object sender,EventArgs e)
    {
        GridView_ProType.DataSource = mp.Select_ProType(GetCondition_ProType());
        GridView_ProType.DataBind();
        UpdatePanel_Product.Visible = true;
        UpdatePanel_Product.Update();
    }
    //产品型号字符串拼接
    protected string GetCondition_ProType()
    {
        string conditon;
        string temp = "";
        if (TextBox_ProductName.Text.ToString() != "")
        {
            temp += " and PT_Name like '%" + TextBox_ProductName.Text.ToString() + "%'";

        }
        if (TextBox_Series.Text.ToString() != "")
        {
            temp += " and Ps_Name like '%" + TextBox_Series.Text.ToString() + "%'";
        }
        conditon = temp;
        return conditon;
    }
    //全选按钮
    protected void Cbx2_SelectAll_CheckedChanged(object sender, EventArgs e)
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
    //产品型号表提交按钮
    protected void ButtonProType_Click(object sender, EventArgs e)
    {
        string grid = label_grid.Text.ToString().Trim();
        foreach (GridViewRow item in GridView_ProType.Rows)
        {
            //HtmlInputRadioButton cb = item.FindControl("PT_Select") as HtmlInputRadioButton;
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                Guid monthplanID = new Guid(label_mainid.Text.ToString());
                Guid PT_ID = new Guid(GridView_ProType.DataKeys[item.RowIndex].Value.ToString());
                DataSet temp = mp.Select_CheckMonthPlanDetail(monthplanID, PT_ID);
                if (grid == "old")
                {
                    if (Convert.ToInt32(temp.Tables[0].Rows[0][0].ToString()) != 0)// have a check 
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_Product, GetType(), "aa", "alert('重复选择产品型号,无法插入月计划详细表!')", true);
                    }
                    else
                    {
                        mp.Insert_ProType_MonthPlanDetail(monthplanID, PT_ID, grid);
                        Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(monthplanID);
                        Gridview_MonthPlanDetail.DataBind();
                        Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(monthplanID);
                        Gridview_MonthPlanDetailAdd.DataBind();
                        UpdatePanel_MonthPlanDetail.Update();
                        UpdatePanel_MonthPlanDetail_Add.Update();
                        Panel1.Visible = false;
                        Panel_Product.Visible = false;
                        UpdatePanel_Product.Update();
                    }
                }
                else
                {
                    mp.Insert_ProType_MonthPlanDetail(monthplanID, PT_ID, grid);
                    Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(monthplanID);
                    Gridview_MonthPlanDetail.DataBind();
                    Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(monthplanID);
                    Gridview_MonthPlanDetailAdd.DataBind();
                    UpdatePanel_MonthPlanDetail.Update();
                    UpdatePanel_MonthPlanDetail_Add.Update();
                    Panel1.Visible = false;
                    Panel_Product.Visible = false;
                    UpdatePanel_Product.Update();
                }
            }
        }
        Panel1.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    #region 分页保存前面的内容 checkbox
    ////保存Checkbox的值
    //private void RemeberOldValues()
    //{
        
    //    ArrayList ProtypeIDlist = new ArrayList();
    //    //int index = -1;
    //    string index = "";
    //    foreach (GridViewRow row in GridView_ProType.Rows)
    //    {
    //        //index = (int)GridView_ProType.DataKeys[row.RowIndex].Value;
    //        index = Convert.ToString(GridView_ProType.DataKeys[row.RowIndex].Value);
    //        bool result = ((CheckBox)row.FindControl("CheckBox2")).Checked;

    //        //check inthe session
    //        if (Session["PT_ID"] != null)
    //        {
    //            ProtypeIDlist = (ArrayList)Session["PT_ID"];
    //        }
    //        if (result)
    //        {
    //            if (!ProtypeIDlist.Contains(index))
    //            {
    //                ProtypeIDlist.Add(index);
    //            }
    //            else
    //            {
    //                ProtypeIDlist.Remove(index);
    //            }
    //            //包含就加进去，不包含就那出来
    //            if (ProtypeIDlist != null && ProtypeIDlist.Count > 0)
    //            {
    //                Session["PT_ID"] = ProtypeIDlist;
    //            }

    //        }
    //    }
    //}
    ////还原Checkbox状态
    //private void RePopulateValues()
    //{
    //    ArrayList ProtypeList = (ArrayList)Session["PT_ID"];
    //    if (ProtypeList != null && ProtypeList.Count > 0)
    //    {
    //        foreach (GridViewRow row in GridView_ProType.Rows)
    //        {
    //            string index = Convert.ToString(GridView_ProType.DataKeys[row.RowIndex].Value);
    //            if (ProtypeList.Contains(index))
    //            {
    //                CheckBox cb = (CheckBox)row.FindControl("CheckBox2");
    //                cb.Checked = true;
    //            }
    //        }
    //    }
    //}
    ////分页上要去调用这两个东西


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



    #endregion



    #endregion

    #region 会签审核部分
    //控制哪些是可以填写的,会签权限
    protected void ControlVision()
    {
        //if (Session["UserRole"].ToString().Contains("生产部销售月计划会签权限"))
        //{
        //    this.TB_shengchanman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_shengchanyijian.Enabled = true;
        //    this.UpdatePanel_Sign.Update();
        //}
        //if (Session["UserRole"].ToString().Contains("工程部销售月计划会签权限"))
        //{
        //    this.TB_gongchengman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_gongchengyijian.Enabled = true;
        //    this.UpdatePanel_Sign.Update();
        //}
        //if (Session["UserRole"].ToString().Contains("设备部销售月计划会签权限"))
        //{
        //    this.TB_shebeiman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_shebeiyijian.Enabled = true;
        //    this.UpdatePanel_Sign.Update();
        //}
        //if (Session["UserRole"].ToString().Contains("品保部销售月计划会签权限"))
        //{
        //    this.TB_pinbaoman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_pinbaoyijian.Enabled = true;
        //    this.UpdatePanel_Sign.Update();
        //}
        //if (Session["UserRole"].ToString().Contains("财务部销售月计划会签权限"))
        //{
        //    this.TB_caiwuman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_caiwuyijian.Enabled = true;
        //    this.UpdatePanel_Sign.Update();
        //}
        //if (Session["UserRole"].ToString().Contains("销售月计划审核"))
        //{
        //    this.TB_lingdao.Text = Session["UserName"].ToString().Trim();
        //    this.TB_lingdaoyijian.Enabled = true;
        //    this.UpdatePanel_Sign.Update();
        //}
        
    
    }
    //获取用户部门，然后更新department的便签值,对应会签部门显示对应人和时间
    protected void Department()
    {
        //this.label_department.Text = Session["Department"].ToString().Trim();
        //if (this.label_department.Text == "生产部")
        //{
        //    this.TB_shengchanman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_shengchantime.Text = Convert.ToString(System.DateTime.Now);
        //}
        //if (this.label_department.Text == "工程部")
        //{
        //    this.TB_gongchengman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_gongchengtime.Text = Convert.ToString(System.DateTime.Now);
        //}
        //if (this.label_department.Text == "设备部")
        //{
        //    this.TB_shebeiman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_shebeitime.Text = Convert.ToString(System.DateTime.Now);
        //}
        //if (this.label_department.Text == "品保部")
        //{
        //    this.TB_pinbaoman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_pinbaotime.Text = Convert.ToString(System.DateTime.Now);
        //}
        //if (this.label_department.Text == "财务部")
        //{
        //    this.TB_caiwuman.Text = Session["UserName"].ToString().Trim();
        //    this.TB_caiwutime.Text = Convert.ToString(System.DateTime.Now);
        //}
    }
    //获取用户新添的会签信息，会签意见
    protected string  SignCondition()
    {
        //this.label_department.Text = Session["Department"].ToString().Trim();
        //if (this.label_department.Text == "生产部")
        //{
        //    this.label_signcondition.Text = this.TB_shengchanyijian.Text.ToString();
        //}
        //if (this.label_department.Text == "工程部")
        //{
        //    this.label_signcondition.Text = this.TB_gongchengyijian.Text.ToString();
        //}
        //if (this.label_department.Text == "设备部")
        //{
        //    this.label_signcondition.Text = this.TB_shebeiyijian.Text.ToString();
        //}
        //if (this.label_department.Text == "品保部")
        //{
        //    this.label_signcondition.Text = this.TB_pinbaoyijian.Text.ToString();
        //}
        //if (this.label_department.Text == "财务部")
        //{
        //    this.label_signcondition.Text = this.TB_caiwuyijian.Text.ToString();
        //}
        //string opinion = this.label_signcondition.Text.ToString();
        //return opinion;
        return "";
    }
    //绑定会签详情
    protected void BindSign()
    {
        DataSet ds = new DataSet();
        ds=mp.Select_SMSalesMonthPlanMain_BindSign(new Guid(label_mainid.Text.ToString()));
        DataTable dt = ds.Tables[0];
        TB_shengchanyijian.Text = dt.Rows[0][0].ToString();
        label_shegnchanbu.Text="销售部部长"+dt.Rows[0][1].ToString();
        TB_shengchanman.Text=dt.Rows[0][2].ToString();
        TB_shengchantime.Text=dt.Rows[0][3].ToString();

        TB_gongchengyijian.Text = dt.Rows[0][4].ToString();
        label_gongchengbu.Text ="销售主管经理" + dt.Rows[0][5].ToString();
        TB_gongchengman.Text = dt.Rows[0][6].ToString();
        TB_gongchengtime.Text = dt.Rows[0][7].ToString();

        TB_shebeiyijian.Text = dt.Rows[0][8].ToString();
        label_shebeibu.Text = "生产一部" + dt.Rows[0][9].ToString();
        TB_shebeiman.Text = dt.Rows[0][10].ToString();
        TB_shebeitime.Text = dt.Rows[0][11].ToString();

        TB_pinbaoyijian.Text = dt.Rows[0][12].ToString();
        label_pinbaobu.Text = "生产二部" + dt.Rows[0][13].ToString();
        TB_pinbaoman.Text = dt.Rows[0][14].ToString();
        TB_pinbaotime.Text = dt.Rows[0][15].ToString();

        //this.TB_caiwuyijian.Text = dt.Rows[0][16].ToString();
        //this.label_caiwubu.Text = "财务部" + dt.Rows[0][17].ToString();
        //this.TB_caiwuman.Text = dt.Rows[0][18].ToString();
        //this.TB_caiwutime.Text = dt.Rows[0][19].ToString();

        TB_lingdaoyijian.Text = dt.Rows[0][16].ToString();
        label_lingdao.Text = "领导" + dt.Rows[0][17].ToString();
        TB_lingdao.Text = dt.Rows[0][18].ToString();
        TB_lingdaotime.Text = dt.Rows[0][19].ToString();

        Panel_Sign.Visible = true;
        UpdatePanel_Sign.Update();
        

    }
    //会签-审核通过按钮
    protected void BT_TKOK_Click(object sender, EventArgs e)
    {
        if (label_CheckOrSign.Text== "check")//主管审核通过
        {
            string opinion= TB_lingdaoyijian.Text.ToString();
            Guid mainid = new Guid( label_mainid.Text.ToString());
            string man = Session["UserName"].ToString().Trim();
            mp.Update_SMSalesMonthPlanMain_CheckOK(mainid, man, opinion);
            BindGridview_MonthPlan();
            UpdatePanel_MonthPlan.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了您提交的初始销售月计划！";
            string sErr = RTXhelper.Send(remind, "销售月计划维护");
            string sErr1 = RTXhelper.Send(remind, "生产月计划管理");
            string sErr2 = RTXhelper.Send(remind, "模块生产月计划管理");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
            if (!string.IsNullOrEmpty(sErr1))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr1 + "')", true);
            }
            if (!string.IsNullOrEmpty(sErr2))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr2 + "')", true);
            }

        }
        else if(label_CheckOrSign.Text=="sign")//部长审核通过
        {
            Guid mainid = new Guid(label_mainid.Text.ToString());
            string department="";
            string opinion = "";
            if (Session["UserRole"].ToString().Contains("销售部部长销售月计划会签"))
            { 
               department ="部长";
               opinion = TB_shengchanyijian.Text.ToString();
            }
            if (Session["UserRole"].ToString().Contains("销售主管经理销售月计划会签"))
            {
                 department = "主管";
                 opinion = TB_gongchengyijian.Text.ToString();
            }
            if (Session["UserRole"].ToString().Contains("生产一部销售月计划会签"))
            {
                department = "生产一部";
                opinion = TB_shebeiyijian.Text.ToString();
            }
            if (Session["UserRole"].ToString().Contains("生产二部销售月计划会签"))
            {
                department = "生产二部";
                opinion = TB_pinbaoyijian.Text.ToString();
            }  
            string man =Session["UserName"].ToString().Trim();
            mp.Update_SMSalesMonthPlanMain_SingOK(mainid, man, opinion, department);
            DataSet ds = mp.Select_SalesMonthPlan(" and SMSMPM_ID like'" + mainid + "'");
            DataTable dt = ds.Tables[0];
            string state = dt.Rows[0][3].ToString();
            if (state == "已会签待审核")
            {
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "会签通过了最新的初始销售月计划，请进行审核！";
            string sErr = RTXhelper.Send(remind, "销售月计划审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
            }
            BindGridview_MonthPlan();
            UpdatePanel_MonthPlan.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('会签通过！')", true);

            }
        }
   //会签-审核驳回按钮事件 
    protected void BT_TKNotOK_Click(object sender, EventArgs e)
    {
        
        if (label_CheckOrSign.Text == "check")//shen he
        {
            if (TB_lingdaoyijian.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Sign, GetType(), "alert", "alert('必须填写驳回意见！')", true);
                return;
            }
            string opinion = TB_lingdaoyijian.Text.ToString();
            Guid mainid = new Guid(label_mainid.Text.ToString());
            string man = Session["UserName"].ToString().Trim();
            mp.Update_SMSalesMonthPlanMain_CheckNotOK(mainid, man, opinion);
            BindGridview_MonthPlan();
            UpdatePanel_Sign.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回成功！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "驳回您提交的初始销售月计划，请进行更改！";
            string sErr = RTXhelper.Send(remind, "销售月计划维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        else if (label_CheckOrSign.Text == "sign")//hui qian
        {
            //Department();
            Guid mainid = new Guid(label_mainid.Text.ToString());
            string department = "";
            string opinion = "";
            if (Session["UserRole"].ToString().Contains("销售部部长销售月计划会签"))
            {
                department = "部长";
                opinion = TB_shengchanyijian.Text.ToString();
            }
            if (Session["UserRole"].ToString().Contains("销售主管经理销售月计划会签"))
            {
                department = "主管";
                opinion = TB_gongchengyijian.Text.ToString();
            }  
            if (opinion == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Sign, GetType(), "alert", "alert('必须填写驳回意见！')", true);
                return;
            }
            string man = Session["UserName"].ToString().Trim();
            mp.Update_SMSalesMonthPlanMain_SingNotOK(mainid, man, opinion, department);
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            BindGridview_MonthPlan();
            UpdatePanel_MonthPlan.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('会签驳回！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "驳回您提交的初始销售月计划，请进行更改！";
            string sErr = RTXhelper.Send(remind, "销售月计划维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }   

    }
    //关闭会签栏
    public void BT_TKCanel_Click(object sender,EventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    //新增会签-审核通过按钮
    protected void AddCheck()
    {
        string key = label_key.Text.ToString();
        Guid detailID = new Guid(label_detailID.Text.ToString());
        string man = TextBox_AddMan.Text.ToString();
        string opinion = TextBox_AddOpinion.Text.ToString();
        mp.Update_MonthPlanDetail_ADD_Check(detailID,opinion,man,key);
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
        Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(label_mainid.Text.ToString()));
        Gridview_MonthPlanDetailAdd.DataBind();
        UpdatePanel_ADDCheck.Update();
        BindGridview_MonthPlan();
    }
    protected void BT_ADD_TKOK_Click(object sender, EventArgs e)
    {
        label_key.Text = "ok";
        TextBox_AddOpinion.Text = "";
        AddCheck();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "通过了您提交的新增销售月计划";
        string sErr = RTXhelper.Send(remind, "销售月计划维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //新增会签-审核驳回按钮事件 
    protected void BT_ADD_TKNotOK_Click(object sender, EventArgs e)
    {

        label_key.Text = "nok";
        TextBox_AddOpinion.Text = "";
        AddCheck();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "驳回您提交的新增销售月计划，请进行更改！";
        string sErr = RTXhelper.Send(remind, "销售月计划维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        

    }
    //新增关闭会签栏
    public void BT_ADD_TKCanel_Click(object sender, EventArgs e)
    {
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
    }


    #endregion

    #region 各种gridview操作
    //monthplan

    protected void GridView_MonthPlan_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头
            foreach (TableCell MyHeader in e.Row.Cells) //对每一单元格      
                if (MyHeader.HasControls())
                    if (((LinkButton)MyHeader.Controls[0]).CommandArgument == Gridview_MonthPlan.SortExpression)
                        //是否为排序列
                        if (Gridview_MonthPlan.SortDirection == SortDirection.Ascending) //依排序方向加入方向箭头
                            MyHeader.Controls.Add(new LiteralControl("↑"));
                        else
                            MyHeader.Controls.Add(new LiteralControl("↓"));
    }
    protected void Gridview_MonthPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["SMSMPM_State"].ToString().Trim() != "已新建" && drv["SMSMPM_State"].ToString().Trim() != "会签驳回" && drv["SMSMPM_State"].ToString().Trim() != "审核驳回")
            {
                e.Row.Cells[8].Enabled = false;
            }
            if (drv["SMSMPM_State"].ToString().Trim() != "会签中" && drv["SMSMPM_State"].ToString().Trim() != "已会签待审核" && !(Session["UserRole"].ToString().Contains("销售月计划会签查看")))
            {
                e.Row.Cells[11].Enabled = false;
            }
            //if (drv["SMSMPM_State"].ToString().Trim() == "已提交" || drv["SMSMPM_State"].ToString().Trim() == "会签中" || drv["SMSMPM_State"].ToString().Trim() == "会签驳回")
            //{
            //    e.Row.Cells[10].Enabled = true;
            //}
            //else
            //{
            //    e.Row.Cells[10].Enabled = false;
            //}
            if (drv["SMSMPM_State"].ToString().Trim() != "已新建")
            {
                e.Row.Cells[13].Enabled = false;
            }
            else
            {
                e.Row.Cells[13].Enabled = true;
            }
        }
    }

    //根据条件控制gridview每列的显示
    protected void Gridview_MonthPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
         

        if (e.CommandName == "Look1")//点击查看原始月计划详细
        {

           
            label20.Text = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年" + Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "月的";

            //this.label_mainid.Text = Convert.ToString(gvr.RowIndex);
            label_mainid.Text = Convert.ToString(e.CommandArgument);
            string iid = e.CommandArgument.ToString();
            //this.Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(new Guid(iid));
            //this.Gridview_MonthPlanDetail.DataBind();
           
            //隐藏填空列
            Gridview_MonthPlanDetail.Columns[8].Visible = false;
            Gridview_MonthPlanDetail.Columns[10].Visible = false;
            Gridview_MonthPlanDetail.Columns[12].Visible = false;
            //原始查看列
            Gridview_MonthPlanDetail.Columns[7].Visible = true;
            Gridview_MonthPlanDetail.Columns[9].Visible = true ;
            Gridview_MonthPlanDetail.Columns[11].Visible = true ;
            Panel_MonthPlanDetail.Visible = true;
            Button8.Visible = false;
            Button10.Visible = false;
            Button15.Visible = false;
            Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(new Guid(label_mainid.Text.ToString()));
            Gridview_MonthPlanDetail.DataBind();
            UpdatePanel_MonthPlanDetail.Update();
        }
        if (e.CommandName == "Look2")//点击查看新增月计划详细
        {

            
            label21.Text = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年" + Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "月的";

            //this.label_mainid.Text = Convert.ToString(gvr.RowIndex);
            label_mainid.Text = Convert.ToString(e.CommandArgument);
            string iid = e.CommandArgument.ToString();
            Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(iid));
            Gridview_MonthPlanDetailAdd.DataBind();
            //隐藏填空列
            Gridview_MonthPlanDetailAdd.Columns[8].Visible = false;
            Gridview_MonthPlanDetailAdd.Columns[10].Visible = false;
            Gridview_MonthPlanDetailAdd.Columns[12].Visible = false;
            //原始查看列
            Gridview_MonthPlanDetailAdd.Columns[7].Visible = true;
            Gridview_MonthPlanDetailAdd.Columns[9].Visible = true;
            Gridview_MonthPlanDetailAdd.Columns[11].Visible = true;
            Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(iid));
            Gridview_MonthPlanDetailAdd.DataBind();
            Panel_MonthPlanDetail_Add.Visible = true;
            Button13.Visible = false;
            Button11.Visible = false;
            Button16.Visible = false;
            UpdatePanel_MonthPlanDetail_Add.Update();
        }
        if (e.CommandName == "Sign1")//点击会签，记录一下，安排一下权限问题
        {
            label22.Text = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年" + Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "月的销售月计划";
            label_mainid.Text = Convert.ToString(e.CommandArgument);
            label_CheckOrSign.Text = "sign";//判断是会签
            string state = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            label_department.Text = Session["Department"].ToString().Trim();
            BindSign(); 
            if (state == "审核通过" || state == "审核驳回")
            {
                BT_TKOK.Visible = false;
                BT_TKNotOK.Visible = false;
                UpdatePanel_Sign.Update();
            }
            if ((state == "已提交"||state=="会签中")&& (Session["UserRole"].ToString().Contains("销售月计划会签")))
            {
                if (Session["UserRole"].ToString().Contains("销售月计划会签查看"))
                {
                    BT_TKOK.Visible = false;
                    BT_TKNotOK.Visible = false;
                    UpdatePanel_Sign.Update();
                    BT_TKOK.Visible = false;
                    BT_TKNotOK.Visible = false;
                    UpdatePanel_Sign.Update();
                }
                if (Session["UserRole"].ToString().Contains("销售部部长销售月计划会签"))
                {
                    TB_shengchanyijian.Enabled = true;
                    TB_shengchanman.Text = Session["UserName"].ToString();
                    TB_shengchantime.Text = DateTime.Now.ToString();
                    UpdatePanel_Sign.Update();
                    BT_TKOK.Visible = true;
                    BT_TKNotOK.Visible = true;
                    UpdatePanel_Sign.Update();
                }
                if (Session["UserRole"].ToString().Contains("销售主管经理销售月计划会签"))
                {
                    TB_gongchengyijian.Enabled = true;
                    TB_gongchengman.Text = Session["UserName"].ToString();
                    TB_gongchengtime.Text = DateTime.Now.ToString();
                    UpdatePanel_Sign.Update();
                    BT_TKOK.Visible = true;
                    BT_TKNotOK.Visible = true;
                    UpdatePanel_Sign.Update();
                }
                if (Session["UserRole"].ToString().Contains("生产一部销售月计划会签"))
                {
                    TB_shebeiyijian.Enabled = true;
                    TB_shebeiman.Text = Session["UserName"].ToString();
                    TB_shebeitime.Text = DateTime.Now.ToString();
                    UpdatePanel_Sign.Update();
                    BT_TKOK.Visible = true;
                    BT_TKNotOK.Visible = true;
                    UpdatePanel_Sign.Update();
                }
                if (Session["UserRole"].ToString().Contains("生产二部销售月计划会签"))
                {
                    TB_pinbaoyijian.Enabled = true;
                    TB_pinbaoman.Text = Session["UserName"].ToString();
                    TB_pinbaotime.Text = DateTime.Now.ToString();
                    UpdatePanel_Sign.Update();
                    BT_TKOK.Visible = true;
                    BT_TKNotOK.Visible = true;
                    UpdatePanel_Sign.Update();
                }
              
                //else
                //{
                //    BT_TKOK.Visible = true;
                //    BT_TKNotOK.Visible = true;
                //    UpdatePanel_Sign.Update();
                //}
            }
            
            Panel_Sign.Visible = true;
                
            TB_lingdaoyijian.Enabled = false;
            UpdatePanel_Sign.Update();
        }
        if (e.CommandName == "Check1")//点击审核
        {
            string state = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            label_department.Text = Session["Department"].ToString().Trim();
            label22.Text = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年" + Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "月的销售月计划";
            label_mainid.Text = Convert.ToString(e.CommandArgument);
            BindSign();
            label_CheckOrSign.Text = "check";
            Panel_Sign.Visible = true;
            TB_lingdao.Text = Session["UserName"].ToString().Trim();
            TB_lingdaotime.Text = Convert.ToString(DateTime.Now);
            if (state == "已会签待审核")
            {
                BT_TKOK.Visible = true;
                BT_TKNotOK.Visible = true;
                TB_lingdaoyijian.Enabled = true;
                UpdatePanel_Sign.Update();
            }
            else
            {
                BT_TKOK.Visible = false;
                BT_TKNotOK.Visible = false;
                TB_lingdaoyijian.Enabled = false;
                UpdatePanel_Sign.Update();
            }
            ControlVision();
            UpdatePanel_Sign.Update();
        }
        if (e.CommandName == "Edit1")//编辑详细
        {
            
            label20.Text = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年" + Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "月的";
            label_mainid.Text = e.CommandArgument.ToString();
            Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(new Guid(label_mainid.Text.ToString()));
            Gridview_MonthPlanDetail.DataBind();
            //隐藏填空列
            Gridview_MonthPlanDetail.Columns[8].Visible = true;
            Gridview_MonthPlanDetail.Columns[10].Visible = true;
            Gridview_MonthPlanDetail.Columns[12].Visible = true;
            Gridview_MonthPlanDetail.Columns[13].Visible = true;
            //原始查看列
            Gridview_MonthPlanDetail.Columns[7].Visible = false;
            Gridview_MonthPlanDetail.Columns[9].Visible = false;
            Gridview_MonthPlanDetail.Columns[11].Visible = false;
            Button8.Visible = true;
            Button10.Visible = true;
            Button15.Visible = true;
            Panel_MonthPlanDetail.Visible = true;
            UpdatePanel_MonthPlanDetail.Update();
        }
        if (e.CommandName == "Add1")//新增详细
        {
            
            label21.Text = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年" + Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "月的";
            label_mainid.Text = e.CommandArgument.ToString();
            Panel_MonthPlanDetail_Add.Visible = true;
            label_mainid.Text = Convert.ToString(e.CommandArgument);
            string iid = e.CommandArgument.ToString();
            Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(iid));
            Gridview_MonthPlanDetailAdd.DataBind();
            //隐藏填空列
            Gridview_MonthPlanDetailAdd.Columns[8].Visible = true;
            Gridview_MonthPlanDetailAdd.Columns[10].Visible = true;
            Gridview_MonthPlanDetailAdd.Columns[12].Visible = true;
            Gridview_MonthPlanDetailAdd.Columns[14].Visible = true;
            
            //原始查看列
            Gridview_MonthPlanDetailAdd.Columns[7].Visible = false;
            Gridview_MonthPlanDetailAdd.Columns[9].Visible = false;
            Gridview_MonthPlanDetailAdd.Columns[11].Visible = false;
            Button13.Visible = true;
            Button11.Visible = true;
            Button16.Visible = true;
            UpdatePanel_MonthPlanDetail_Add.Update();            
        }
        if (e.CommandName == "Delete1")//删除
        {
            mp.Delete_MonthPlanMain(new Guid(e.CommandArgument.ToString()));
            BindGridview_MonthPlan();
            UpdatePanel_MonthPlan.Update();
        }



    }
    protected void Gridview_MonthPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_MonthPlan.BottomPagerRow;


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

        BindGridview_MonthPlan();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_MonthPlan.PageCount ? Gridview_MonthPlan.PageCount - 1 : newPageIndex;
        Gridview_MonthPlan.PageIndex = newPageIndex;
        Gridview_MonthPlan.DataBind();

    }

    //MonthPlanDetailOriginal


    protected void Gridview_MonthPlanDetail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_MonthPlanDetail.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_MonthPlanDetail.Rows[i].Cells.Count; j++)
            {
                Gridview_MonthPlanDetail.Rows[i].Cells[j].ToolTip = Gridview_MonthPlanDetail.Rows[i].Cells[j].Text;
                if (Gridview_MonthPlanDetail.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_MonthPlanDetail.Rows[i].Cells[j].Text = Gridview_MonthPlanDetail.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        } 
    }
    protected void Gridview_MonthPlanDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete2")//删除
        {
            Guid iid = new Guid(e.CommandArgument.ToString());
            mp.Delete_MonthPlanDetail(iid);
            Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(new Guid(label_mainid.Text.ToString()));
            Gridview_MonthPlanDetail.DataBind();
            UpdatePanel_MonthPlanDetail.Update();
        }
        if (e.CommandName == "Edit2")//编辑
        {
            Gridview_MonthPlanDetail.Columns[7].Visible = true;
            Gridview_MonthPlanDetail.Columns[9].Visible = true;
            Gridview_MonthPlanDetail.Columns[11].Visible = true;
            UpdatePanel_MonthPlanDetail.Update();
        }
    }
    protected void Gridview_MonthPlanDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_MonthPlanDetail.BottomPagerRow;


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
        Guid iid = new Guid(label_mainid.Text.ToString());
        Gridview_MonthPlanDetail.DataSource = mp.Select_MonthPlanDetail_FromGridview(iid);
        Gridview_MonthPlanDetail.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_MonthPlanDetail.PageCount ? Gridview_MonthPlanDetail.PageCount - 1 : newPageIndex;
        Gridview_MonthPlanDetail.PageIndex = newPageIndex;
        Gridview_MonthPlanDetail.DataBind();
        

    }
    
    
    //MonthPlanDetailAdd
    protected void Gridview_MonthPlanDetailAdd_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_MonthPlanDetailAdd.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_MonthPlanDetailAdd.Rows[i].Cells.Count; j++)
            {
                Gridview_MonthPlanDetailAdd.Rows[i].Cells[j].ToolTip = Gridview_MonthPlanDetailAdd.Rows[i].Cells[j].Text;
                if (Gridview_MonthPlanDetailAdd.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_MonthPlanDetailAdd.Rows[i].Cells[j].Text = Gridview_MonthPlanDetailAdd.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        } 
    }
    protected void Gridview_MonthPlanDetail_Add_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete3")//删除
        { 
             Guid iid=new Guid(e.CommandArgument.ToString());
             mp.Delete_MonthPlanDetail(iid);
             Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(label_mainid.Text.ToString()));
             Gridview_MonthPlanDetailAdd.DataBind();
             UpdatePanel_MonthPlanDetail_Add.Update();
        }
        if (e.CommandName == "Check3")//shenhe
        {
            Guid iid = new Guid(e.CommandArgument.ToString());
            label_detailID.Text = e.CommandArgument.ToString();
            Panel_ADDCheck.Visible = true;
            TextBox_AddMan.Text = Session["UserName"].ToString().Trim();
            TextBox_Addtime.Text = DateTime.Now.ToShortDateString();
            UpdatePanel_ADDCheck.Update();

        }
        if (e.CommandName == "Edit3")
        { 
            Gridview_MonthPlanDetailAdd.Columns[7].Visible = true;
            Gridview_MonthPlanDetailAdd.Columns[9].Visible = true;
            Gridview_MonthPlanDetailAdd.Columns[11].Visible = true;
            UpdatePanel_MonthPlanDetail.Update();
        }
    }
    protected void Gridview_MonthPlanDetail_Add_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_MonthPlanDetailAdd.BottomPagerRow;


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

        Gridview_MonthPlanDetailAdd.DataSource = mp.Select_MonthPlanDetail_FromGridview_Add(new Guid(label_mainid.Text.ToString()));
        Gridview_MonthPlanDetailAdd.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_MonthPlanDetailAdd.PageCount ? Gridview_MonthPlanDetailAdd.PageCount - 1 : newPageIndex;
        Gridview_MonthPlanDetailAdd.PageIndex = newPageIndex;
        Gridview_MonthPlanDetailAdd.DataBind();

    }

    //ProType
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

        GridView_ProType.DataSource = mp.Select_ProType(GetCondition_ProType());
        CollectSelected();
        GridView_ProType.DataBind();  
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        //RemeberOldValues();
        GridView_ProType.PageIndex = newPageIndex;
        GridView_ProType.DataBind();
        //RePopulateValues();

        
    }
    protected void GridView_ProType_RowDataBound(object sender, GridViewRowEventArgs e)
   {
        //这里的处理是为了回显之前选中的情况
       if (e.Row.RowIndex > -1 && SelectedItems!=null)
        {
           //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("CheckBox2") as CheckBox;
            string id = GridView_ProType.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if(SelectedItems.Contains(id))
               cb.Checked = true;
            else
               cb.Checked = false;
        }
    }
    #endregion
    protected void CloseProType(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Gridview_MonthPlanDetailAdd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["checkresult"].ToString().Trim() == "审核通过" || drv["checkresult"].ToString().Trim() == "审核驳回")
            {
                e.Row.Cells[15].Enabled = false;
                e.Row.Cells[14].Enabled = false;
                e.Row.Cells[8].Enabled = false;
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[12].Enabled = false;
            }
  

            else
            {
                e.Row.Cells[15].Enabled = true;
                e.Row.Cells[14].Enabled = true;
                e.Row.Cells[8].Enabled = true;
                e.Row.Cells[10].Enabled = true;
                e.Row.Cells[12].Enabled = true;
            }

        }
    }
}