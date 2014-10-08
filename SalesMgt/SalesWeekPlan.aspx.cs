using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class SalesMgt_SalesWeekPlan : Page
{
    SalesWeekPlanL wp = new SalesWeekPlanL();
    SalesMonthPlanL mp = new SalesMonthPlanL();//为了复用选择产品那一块
    ProTypePrice ptp = new ProTypePrice();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            BindDropdownList6();
            BindDropDownlist();
            DropDownList3.Items.Insert(0, new ListItem("选择状态", "选择状态"));
          
            BindWeekPlanMain();
         //   BindWeekDetail();
            DropDownList7.Items.Insert(0, new ListItem("选择周次", "选择周次"));
            DropDownList5.Items.Insert(0, new ListItem("选择年份", "选择年份"));
            DropDownList4.Items.Insert(0, new ListItem("选择对应月计划", "选择对应月计划"));
            UpdatePanel_Search.Update();
            DropDownList2.Items.Insert(0, new ListItem("选择周次", "选择周次"));
            DropDownList1.Items.Insert(0, new ListItem("选择年份", "选择年份"));
            UpdatePanel_NewWeekPlan.Update();
        }
        #region 权限控制
        try
        {
            if (!Session["UserRole"].ToString().Contains("销售周计划"))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }

        ////if (!Session["UserRole"].ToString().Contains("销售周计划"))

        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //if (Session["UserRole"].ToString().Contains("销售周计划查看"))

        if (Request.QueryString["status"] == "SalesWeekPlanLook")
        {
            Title = "销售周计划查看";
            Gridview_WeekPlan.Columns[9].Visible = true;
            UpdatePanel_WeekPlan.Update();
            Button3.Visible = false;
            UpdatePanel_Search.Update();
            Gridview_WeekPlanDetail.Columns[15].Visible = false;
            UpdatePanel_WeekPlanDetail.Update();
        }
        //if (Session["UserRole"].ToString().Contains("销售周计划制定"))
        if (Request.QueryString["status"] == "SalesWeekPlanEdit")
        {
            Title = "销售周计划制定";
            Gridview_WeekPlan.Columns[8].Visible = true;
            Gridview_WeekPlan.Columns[9].Visible = true;
            Gridview_WeekPlan.Columns[11].Visible = true;
            UpdatePanel_WeekPlan.Update();
            Gridview_WeekPlanDetail.Columns[5].Visible = true;
            Gridview_WeekPlanDetail.Columns[10].Visible = true;
            Gridview_WeekPlanDetail.Columns[4].Visible = false;
            Gridview_WeekPlanDetail.Columns[9].Visible = false;
            Gridview_WeekPlanDetail.Columns[11].Visible = false;
            Gridview_WeekPlanDetail.Columns[12].Visible = true;
            Button3.Visible = true;
            UpdatePanel_Search.Update();
            Gridview_Day.Columns[5].Visible = true;
            Gridview_Day.Columns[7].Visible = true;
            Gridview_Day.Columns[9].Visible = true;
            Gridview_Day.Columns[11].Visible = true;
            Gridview_Day.Columns[13].Visible = true;
            Gridview_Day.Columns[15].Visible = true;
            UpdatePanel_WeekPlanDetail.Update();
        }
        //if (Session["UserRole"].ToString().Contains("生产部销售周计划会签权限") || Session["UserRole"].ToString().Contains("工程部销售周计划会签权限") || Session["UserRole"].ToString().Contains("设备部销售周计划会签权限")
        //    || Session["UserRole"].ToString().Contains("品保部销售周计划会签权限") || Session["UserRole"].ToString().Contains("财务部销售周计划会签权限"))
        if (Request.QueryString["status"] == "SalesWeekPlanSign")
        {
            Title = "销售周计划会签";
            Button3.Visible = false;
            UpdatePanel_Search.Update();
            Gridview_WeekPlan.Columns[9].Visible = true;
            Gridview_WeekPlan.Columns[10].Visible = true;
            UpdatePanel_WeekPlan.Update();
        }


        #endregion
    }
    #region 周计划主表
    //查询周计划
    protected void SearchWeekPlan(object sender, EventArgs e)
    {
        label_condition.Text = GetCondition();
        BindWeekPlanMain();
    }
    //获取检索条件
    protected string GetCondition()
    {
        string conditon;
        string temp = "";
        if (DropDownList1.Text.ToString() != "选择年份")
        {
            temp += " and SMSWPM_Year ='" + DropDownList1.SelectedValue.ToString() + "'";

        }
        if (DropDownList2.Text.ToString() != "选择周次")
        {
            temp += " and SMSWPM_Week ='" + DropDownList2.SelectedValue.ToString() + "'";
        }
        if (DropDownList3.Text.ToString() != "选择状态")
        {
            temp += " and SMSWPM_State ='" + DropDownList3.SelectedValue.ToString() + "'";
        }
        if ((TextBox1.Text != "" && TextBox2.Text == "") || (TextBox1.Text == "" && TextBox2.Text != ""))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Search, GetType(), "alert", "alert('请选择完整的时间区域！')", true);

        }
        if ((TextBox3.Text != "" && TextBox2.Text == "") || (TextBox4.Text == "" && TextBox2.Text != ""))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Search, GetType(), "alert", "alert('请选择完整的时间区域！')", true);

        }
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            temp += " and SMSWPM_StartTime between'" + TextBox1.Text.ToString() + "' and '" + TextBox2.Text.ToString() + "'";

        }
        if (TextBox3.Text != "" && TextBox4.Text != "")
        {
            temp += " and SMSWPM_EndTime between'" + TextBox3.Text.ToString() + "' and '" + TextBox4.Text.ToString() + "'";
        }
        temp += "order by SMSWPM_MakeTime desc";
        conditon = temp;
        label_condition.Text = conditon;
        return conditon;
    }
    //模糊查询周计划主表
    protected void BindWeekPlanMain()
    {
        Gridview_WeekPlan.DataSource = wp.Select_SalesWeekPlan(label_condition.Text.ToString());
        Gridview_WeekPlan.DataBind();
        Panel_WeekPlan.Visible = true;
        UpdatePanel_WeekPlan.Update();
    }
    //新增周计划
    protected void CreateWeekPlan(object sender, EventArgs e)
    {
        Panel_NewWeekPlan.Visible = true;
        BindDropDownlist1();
        UpdatePanel_NewWeekPlan.Update();
    }
    //获取新增周计划里面内容
    protected void GetNewWeekPlanContent()
    {
        //alter for abnormal remind
        if (DropDownList5.SelectedValue == "" || DropDownList7.SelectedValue == "" || DropDownList4.SelectedValue == "" || TextBox_Start.Text == "" || TextBox_End.Text=="")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewWeekPlan, GetType(), "alert", "alert('请填写完整的信息，否则无法提交！')", true);
            return;
        }
        if (Convert.ToDateTime(TextBox_Start.Text.ToString())>=Convert.ToDateTime(TextBox_End.Text.ToString()))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewWeekPlan, GetType(), "alert", "alert('请保证结束日期大于起始日期！')", true);
            return;
        }
        int year = Convert.ToInt32(DropDownList5.SelectedValue.ToString());
        int week = Convert.ToInt32(DropDownList7.SelectedValue.ToString());
        Guid MonthPlanID = new Guid(DropDownList4.SelectedValue.ToString());
        DateTime start1 = Convert.ToDateTime(TextBox_Start.Text.ToString());
        TextBox_Start.Text = start1.ToString("yyyy-MM-dd");
        DateTime end1 = Convert.ToDateTime(TextBox_End.Text.ToString());
        TextBox_End.Text = end1.ToString("yyyy-MM-dd");
        wp.Insert_SalesWeekPlan(year, week, start1, end1, MonthPlanID);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('提交成功!')", true);
    }
    //提交新的周计划da
    protected void ConfirmNewWeekPlan(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedValue.ToString() == "选择对应月计划" || DropDownList5.SelectedValue.ToString() == "选择年份" || DropDownList7.SelectedValue.ToString() == "选择周次" ||
            TextBox_Start.Text == "" || TextBox_End.Text == "" || TextBox5.Text == "" || TextBox6.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('请填写所有信息!')", true);
            return;
        }
        GetNewWeekPlanContent();
        label_condition.Text = "order by SMSWPM_MakeTime desc";
        Guid MonthPlanID = new Guid(DropDownList4.SelectedValue.ToString());
        int year = Convert.ToInt32( DropDownList5.SelectedValue.ToString());
        int week = Convert.ToInt32(DropDownList7.SelectedValue.ToString());
        //wp.Insert_SalesWeekPlan(year, week, Convert.ToDateTime(this.TextBox5.Text.ToString()), Convert.ToDateTime(this.TextBox6.Text.ToString()), MonthPlanID);
        BindWeekPlanMain();
        Panel_NewWeekPlan.Visible = false;
        UpdatePanel_NewWeekPlan.Update();
       

    }
    //取消新的周计划
    protected void CloseNewWeekPlan(object sender, EventArgs e)
    {
        Panel_NewWeekPlan.Visible = false;
        UpdatePanel_NewWeekPlan.Update();
    }
    //绑定年月下拉框-Search
    protected void BindDropDownlist()
    {
        //DropDownList2.Items.Insert(0, new ListItem("选择周次", "选择周次"));
        //DropDownList1.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        for (int y = 1; y <= 52; y++)
        {
            DropDownList2.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList1.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    //绑定年月下拉框-NewWeekPlan
    protected void BindDropDownlist1()
    {
        //DropDownList7.Items.Insert(0, new ListItem("选择周次", "选择周次"));
        //DropDownList5.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        //DropDownList4.Items.Insert(0,new ListItem("选择对应月计划","选择对应月计划"));
        for (int y = 1; y <= 52; y++)
        {
            DropDownList7.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList5.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        for(int i=0;i!=3;i++)
        {
            DataSet ds=wp.Select_Top5MonthPlanID();//最新的五个月计划ID
            DataTable dt=ds.Tables[0];
            DropDownList4.Items.Add(new ListItem(dt.Rows[i][1].ToString() + "-" + dt.Rows[i][2].ToString(), dt.Rows[i][0].ToString()));
        }
    }
    //重置按钮
    protected void ClearWeekPlan(object sender, EventArgs e)
    {
        //DropDownList7.Items.Remove("选择周次");
        //this.UpdatePanel_Search.Update();
        BindDropDownlist(); 
        //DropDownList3.Items.Insert(0, new ListItem("选择状态", "选择状态"));
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        DropDownList1.SelectedValue = "选择年份";
        DropDownList2.SelectedValue = "选择周次";
        DropDownList3.SelectedValue = "选择状态";
        UpdatePanel_Search.Update();
    }

    #endregion
    #region 详细表
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
        foreach (GridViewRow item in GridView_ProType.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                Guid weekid = new Guid(label_weekID.Text.ToString());
                Guid PT_ID = new Guid(GridView_ProType.DataKeys[item.RowIndex].Value.ToString());
                DataSet temp = wp.Select_CheckWeekPlanDetail(weekid, PT_ID);
                if (Convert.ToInt32(temp.Tables[0].Rows[0][0].ToString()) != 0)// have a check 
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Product, GetType(), "aa", "alert('重复选择产品型号,无法插入周计划详细表!')", true);
                    return;
                }
                else
                {
                    wp.Update_Protype_SalesWeekPlanDetail(weekid, PT_ID);//应该是insert，名字起错了，好囧！
                   
                }
            }
        }
					 BindWeekDetail();
                    UpdatePanel_WeekPlanDetail.Update();
                    Panel1.Visible = false;
                    Panel_Product.Visible = false;
                    UpdatePanel_Product.Update();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Product, GetType(), "aa", "alert('提交成功!')", true);
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
    //CheckBox相关
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
    //检索产品型号
    protected void SelectProType(object sender, EventArgs e)
    {
        GridView_ProType.DataSource = mp.Select_ProType(GetCondition_ProType());
        GridView_ProType.DataBind();
        UpdatePanel_Product.Visible = true;
        UpdatePanel_Product.Update();
    }
    //新增产品型号
    protected void AddProductModell(object sender, EventArgs e)
    {
        Panel_Product.Visible = true;
        Panel1.Visible = true;
        GridView_ProType.DataSource = mp.Select_ProType("");
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    //提交周计划详细表        
    protected void Save()
    {
        Guid weekid = new Guid(label_weekID.Text.ToString());
        for (int i = 0; i <= Gridview_WeekPlanDetail.Rows.Count - 1; i++)
        {
            Guid detailID = new Guid(Gridview_WeekPlanDetail.DataKeys[i].Value.ToString());//主id
            TextBox cbox = (TextBox)Gridview_WeekPlanDetail.Rows[i].FindControl("TextBox_TotalNum");//总数
            DropDownList drop1 = (DropDownList)Gridview_WeekPlanDetail.Rows[i].FindControl("DropDownList_youxianji");//优先级
            TextBox cbox_beizhu = (TextBox)Gridview_WeekPlanDetail.Rows[i].FindControl("TextBox_beizhu");//备注
            TextBox cbox1 = (TextBox)Gridview_Day.Rows[i].FindControl("TextBox_1");//1
            TextBox cbox2 = (TextBox)Gridview_Day.Rows[i].FindControl("TextBox_2");//2
            TextBox cbox3 = (TextBox)Gridview_Day.Rows[i].FindControl("TextBox_3");//3
            TextBox cbox4 = (TextBox)Gridview_Day.Rows[i].FindControl("TextBox_4");//4
            TextBox cbox5 = (TextBox)Gridview_Day.Rows[i].FindControl("TextBox_5");//5
            TextBox cbox6 = (TextBox)Gridview_Day.Rows[i].FindControl("TextBox_6");//6
            if (cbox.Text == "")
            {
                cbox.Text = Gridview_WeekPlanDetail.Rows[i].Cells[4].Text.ToString().Trim();
            }
            if (drop1.SelectedValue.ToString() == "选择优先级")
            {
                drop1.SelectedValue = "普通";
            }
            if (cbox_beizhu.Text == "")
            {
                cbox_beizhu.Text = Gridview_WeekPlanDetail.Rows[i].Cells[11].Text.ToString().Trim();
            }
            if (cbox1.Text == "")
            {
                cbox1.Text = Gridview_Day.Rows[i].Cells[5].Text.ToString().Trim();
            }
            if (cbox2.Text == "")
            {
                cbox2.Text = Gridview_Day.Rows[i].Cells[7].Text.ToString().Trim();
            }
            if (cbox3.Text == "")
            {
                cbox3.Text = Gridview_Day.Rows[i].Cells[9].Text.ToString().Trim();
            }
            if (cbox4.Text == "")
            {
                cbox4.Text = Gridview_Day.Rows[i].Cells[11].Text.ToString().Trim();
            }
            if (cbox5.Text == "")
            {
                cbox5.Text = Gridview_Day.Rows[i].Cells[13].Text.ToString().Trim();
            }
            if (cbox6.Text == "")
            {
                cbox6.Text = Gridview_Day.Rows[i].Cells[15].Text.ToString().Trim();
            }
            //防止为空
            if (cbox.Text == "")
            {
                cbox.Text = "0";
            }
            if (cbox1.Text == "")
            {
                cbox1.Text = "0";
            }
            if (cbox2.Text == "")
            {
                cbox2.Text = "0";
            }
            if (cbox3.Text == "")
            {
                cbox3.Text = "0";
            }
            if (cbox4.Text == "")
            {
                cbox4.Text = "0";
            }
            if (cbox5.Text == "")
            {
                cbox5.Text = "0";
            }
            if (cbox6.Text == "")
            {
                cbox6.Text = "0";
            }
            int total = Convert.ToInt32(cbox.Text.ToString());
            int day1 = Convert.ToInt32(cbox1.Text.ToString());
            int day2 = Convert.ToInt32(cbox2.Text.ToString());
            int day3 = Convert.ToInt32(cbox3.Text.ToString());
            int day4 = Convert.ToInt32(cbox4.Text.ToString());
            int day5 = Convert.ToInt32(cbox5.Text.ToString());
            int day6 = Convert.ToInt32(cbox6.Text.ToString());
            string beizhu = cbox_beizhu.Text.ToString();
            string youxianji = drop1.SelectedValue.ToString();
            string way = label_way.Text.ToString();
            wp.Update_WeekPlanDetail_Num(detailID, weekid, total, youxianji, beizhu, day1, day2, day3, day4, day5, day6, way);

        }


        Gridview_WeekPlanDetail.Columns[5].Visible = false;
        Gridview_WeekPlanDetail.Columns[10].Visible = false;
        Gridview_WeekPlanDetail.Columns[12].Visible = false;
        Gridview_WeekPlanDetail.Columns[4].Visible = true;
        Gridview_WeekPlanDetail.Columns[9].Visible = true;
        for (int k = 5; k != 17; k += 2)
        {
            Gridview_Day.Columns[k].Visible = false;
        }
        for (int k = 4; k != 16; k += 2)
        {
            Gridview_Day.Columns[k].Visible = true;
        }
        BindWeekDetail();
        UpdatePanel_WeekPlanDetail.Update();
    }
    //绑定详细表和每天的表
    protected void BindWeekDetail()
    {
        string condition= label_detailcondition.Text+Label4.Text ;
        Gridview_WeekPlanDetail.DataSource = wp.Select_SalesWeekPlanDetail_Condition(condition);
        Gridview_Day.DataSource = wp.Select_SalesWeekPlanDetail_Condition(condition);
        Gridview_Day.DataBind();
        Gridview_WeekPlanDetail.DataBind();
    }
    //查看每日计划
    protected void LookEveryDay(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        UpdatePanel_WeekPlanDetail.Update();
    }
    //提交详细
    protected void ConfirmNewWeekPlanDetail(object sender, EventArgs e)
    {
        label_way.Text = "submit";
        Save();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了" + label20.Text.ToString() +"的销售周计划，请会签！";

        string sErr = RTXhelper.Send(remind, "销售周计划会签");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('"+sErr+"')", true);
        }
    }
    //保存周计划详细表
    protected void SaveNewWeekPlanDetail(object sender, EventArgs e)
    {
        label_way.Text = "save";
        Save();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('保存成功！')", true);

    }
    //关闭周计划详细
    protected void CloseWeekPlanDetail(object sender, EventArgs e)
    {
        Panel_WeekPlanDetail.Visible = false;
        UpdatePanel_WeekPlanDetail.Update();
        Panel2.Visible = false;
        UpdatePanel_WeekPlanDetail.Update();
    }
    //保存每天安排量
    protected void SaveDayPlanDetail(object sender, EventArgs e)
    {
        label_way.Text = "save";
        Save();
    }
    //关闭每天安排量
    protected void CloseDayPlanDetail(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel_WeekPlanDetail.Update();
    }
    #endregion
    #region 会签部分


   
    //绑定会签详情
    protected void BindSign()
    {
        DataSet ds = new DataSet();
        ds = wp.Select_SalesWeekPlanBindSign(new Guid(label_weekID.Text.ToString()));
        DataTable dt = ds.Tables[0];
        TB_shengchanyijian.Text = dt.Rows[0][0].ToString();
        label_shegnchanbu.Text = "销售部长" + dt.Rows[0][1].ToString();
        TB_shengchanman.Text = dt.Rows[0][2].ToString();
        TB_shengchantime.Text = dt.Rows[0][3].ToString();


        TB_shebeiyijian.Text = dt.Rows[0][8].ToString();
        label_shebeibu.Text = "生产一部" + dt.Rows[0][9].ToString();
        TB_shebeiman.Text = dt.Rows[0][10].ToString();
        TB_shebeitime.Text = dt.Rows[0][11].ToString();

        TB_pinbaoyijian.Text = dt.Rows[0][12].ToString();
        label_pinbaobu.Text = "生产部" + dt.Rows[0][13].ToString();
        TB_pinbaoman.Text = dt.Rows[0][14].ToString();
        TB_pinbaotime.Text = dt.Rows[0][15].ToString();

   


    }
    //会签-审核通过按钮
    protected void BT_TKOK_Click(object sender, EventArgs e)
    {
            Guid weekid = new Guid(label_weekID.Text.ToString());
            string department = "";
            label_department.Text = Session["Department"].ToString().Trim();
            
            if (Session["UserRole"].ToString().Contains("销售部长销售周计划会签"))
            {
                label_signcondition.Text = TB_shengchanyijian.Text.ToString();
                department = "销售部长";
            }
            if (Session["UserRole"].ToString().Contains("生产一部销售周计划会签"))
            {
                label_signcondition.Text = TB_shebeiyijian.Text.ToString();
                department = "生产一部";
            }
            if (Session["UserRole"].ToString().Contains("生产二部销售周计划会签"))
            {
                label_signcondition.Text = TB_pinbaoyijian.Text.ToString();
                department = "生产二部";
            }
            string opinion = label_signcondition.Text;
            string man = Session["UserName"].ToString().Trim();
            wp.Update_SalesWeekPlanSignOK(weekid,man,opinion,department);
            BindWeekPlanMain();
            UpdatePanel_WeekPlan.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            BindWeekPlanMain();
            UpdatePanel_WeekPlan.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "会签通过了你提交的销售周计划";
            string sErr = RTXhelper.Send(remind, "销售周计划维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
    }
    //会签-审核驳回按钮事件 
    protected void BT_TKNotOK_Click(object sender, EventArgs e)
    {
         
            Guid weekid = new Guid(label_weekID.Text.ToString());
            string department = "";
            string opinion = "";
            if (Session["UserRole"].ToString().Contains("销售部长销售周计划会签"))
            {
                label_signcondition.Text = TB_shengchanyijian.Text.ToString();
                department = "销售部长";
            }
            if (Session["UserRole"].ToString().Contains("生产一部销售周计划会签"))
            {
                label_signcondition.Text = TB_shebeiyijian.Text.ToString();
                department = "生产一部";
            }
            if (Session["UserRole"].ToString().Contains("生产二部销售周计划会签"))
            {
                label_signcondition.Text = TB_pinbaoyijian.Text.ToString();
                department = "生产二部";
            }
            opinion = label_signcondition.Text.ToString();
            if (opinion == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Sign, GetType(), "alert", "alert('必须填写驳回意见！')", true);
                return;
            }
         
            string man = Session["UserName"].ToString().Trim();
            wp.Update_SalesWeekPlanSignNotOK(weekid, man, opinion, department);
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            BindWeekPlanMain();
            UpdatePanel_WeekPlan.Update();
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "驳回了你提交的销售周计划，请重新维护对应周计划！";
            string sErr = RTXhelper.Send(remind, "销售周计划维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }

    }
    //关闭会签栏
    public void BT_TKCanel_Click(object sender, EventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    #endregion
    #region Gridview相关操作
    //WeekMain
    protected void Gridview_WeekPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_WeekPlan.BottomPagerRow;


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
        BindWeekPlanMain();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_WeekPlan.PageCount ? Gridview_WeekPlan.PageCount - 1 : newPageIndex;
        Gridview_WeekPlan.PageIndex = newPageIndex;
        Gridview_WeekPlan.DataBind();
    }
    protected void Gridview_WeekPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sign1")//会签
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label22.Text = Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年第" + Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "周的";
            Guid iid = new Guid(e.CommandArgument.ToString());
            label_weekID.Text = e.CommandArgument.ToString();
            label_department.Text = Session["Department"].ToString().Trim();
            BindSign();
            if (Session["UserRole"].ToString().Contains("销售部长销售周计划会签"))
            {
                TB_shengchanman.Text = Session["UserName"].ToString().Trim();
                TB_shengchantime.Text = DateTime.Now.ToShortDateString();
                TB_shengchanyijian.Enabled = true;
                UpdatePanel_Sign.Update();
            }
          
            if (Session["UserRole"].ToString().Contains("生产一部销售周计划会签"))
            {
                TB_shebeiman.Text = Session["UserName"].ToString().Trim();
                TB_shebeitime.Text = DateTime.Now.ToShortDateString();
                TB_shebeiyijian.Enabled = true;
                UpdatePanel_Sign.Update();
            }
            if (Session["UserRole"].ToString().Contains("生产二部销售周计划会签"))
            {
                TB_pinbaoman.Text = Session["UserName"].ToString().Trim();
                TB_pinbaotime.Text = DateTime.Now.ToShortDateString();
                TB_pinbaoyijian.Enabled = true;
                UpdatePanel_Sign.Update();
            }
            if (Session["UserRole"].ToString().Contains("销售周计划会签查看"))
            {
                BT_TKNotOK.Visible = false;
                BT_TKOK.Visible = false;
            }
            else
            {
                BT_TKNotOK.Visible = true;
                BT_TKOK.Visible = true;
            }
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();


        }
        if (e.CommandName == "Edit1")//编辑
        { 
            //少了textbox列的出现和绑定
            string condition = " and a.SMSWPM_ID = '" + e.CommandArgument.ToString() + "'";
            label_detailcondition.Text = condition;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label20.Text = Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年第" + Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString()+"周的";
            label21.Text = Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年第" + Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "周的";
            label_weekID.Text = e.CommandArgument.ToString();
            Panel_WeekPlanDetail.Visible = true;
            Panel2.Visible = true;
            Button15.Visible = true;
            Button6.Visible = true;
            Button7.Visible = true;
            Button12.Visible = true;
            Gridview_WeekPlanDetail.Columns[5].Visible = true;
            Gridview_WeekPlanDetail.Columns[10].Visible = true;
            Gridview_WeekPlanDetail.Columns[4].Visible = false;
            //for (int i = 0; i <= this.Gridview_WeekPlanDetail.Rows.Count - 1; i++)
            //{
            //    DropDownList drop1 = (DropDownList)Gridview_WeekPlanDetail.Rows[i].FindControl("DropDownList_youxianji");//优先级
            //    string key = this.Gridview_WeekPlanDetail.DataKeys[gvr.RowIndex]["SMSWPD_Propity"].ToString();
            //    if (key == "" || key == "选择优先级")
            //    {
            //        drop1.SelectedValue = "选择优先级";
            //    }
            //    else
            //    {
            //        drop1.SelectedValue = key;
            //    }
            //}
            Gridview_WeekPlanDetail.Columns[9].Visible = false;
            Gridview_WeekPlanDetail.Columns[11].Visible = false;
            Gridview_WeekPlanDetail.Columns[12].Visible = true;
            Button3.Visible = true;
            UpdatePanel_Search.Update();
            Gridview_Day.Columns[5].Visible = true;
            Gridview_Day.Columns[7].Visible = true;  
            Gridview_Day.Columns[9].Visible = true;
            Gridview_Day.Columns[11].Visible = true;
            Gridview_Day.Columns[13].Visible = true;
            Gridview_Day.Columns[15].Visible = true;
            Gridview_Day.Columns[4].Visible = false;
            Gridview_Day.Columns[6].Visible = false;
            Gridview_Day.Columns[8].Visible = false;
            Gridview_Day.Columns[10].Visible = false;
            Gridview_Day.Columns[12].Visible = false;
            Gridview_Day.Columns[14].Visible = false;
            UpdatePanel_WeekPlanDetail.Update();
            //this.Gridview_WeekPlan.Columns[12].Visible = false;
            for (int i = 5; i != 17; i += 2)
            {
                Gridview_Day.Columns[i].Visible = true;
            }
            //for (int i = 0; i <= this.Gridview_WeekPlanDetail.Rows.Count - 1; i++)
            //{
            //    DropDownList drop1 = (DropDownList)Gridview_WeekPlanDetail.Rows[i].FindControl("DropDownList_youxianji");//优先级
            //    drop1.Items.Insert(0, new ListItem("选择优先级", "选择优先级"));
           
            BindWeekDetail();
            UpdatePanel_WeekPlanDetail.Update();
        }
        if (e.CommandName == "Look1")//查看
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label20.Text = Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年第" + Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "周的";
            label21.Text = Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "年第" + Gridview_WeekPlan.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "周的";
            Gridview_WeekPlanDetail.Columns[5].Visible = false;
            Gridview_WeekPlanDetail.Columns[10].Visible = false;
            Gridview_WeekPlanDetail.Columns[4].Visible = true;
            Gridview_WeekPlanDetail.Columns[9].Visible = true;
            Gridview_WeekPlanDetail.Columns[11].Visible = true;
            Gridview_WeekPlanDetail.Columns[12].Visible = false ;
            Button3.Visible = false;
            UpdatePanel_Search.Update();
            Gridview_Day.Columns[5].Visible = false;
            Gridview_Day.Columns[7].Visible = false;
            Gridview_Day.Columns[9].Visible = false;
            Gridview_Day.Columns[11].Visible = false;
            Gridview_Day.Columns[13].Visible = false;
            Gridview_Day.Columns[15].Visible = false;
            Gridview_Day.Columns[4].Visible = true;
            Gridview_Day.Columns[6].Visible = true;
            Gridview_Day.Columns[8].Visible = true;
            Gridview_Day.Columns[10].Visible = true;
            Gridview_Day.Columns[12].Visible = true;
            Gridview_Day.Columns[14].Visible = true;
            UpdatePanel_WeekPlanDetail.Update();
            label_weekID.Text = e.CommandArgument.ToString();
            Panel_WeekPlanDetail.Visible = true;
            Button15.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            Button12.Visible = false;
            string condition = " and a.SMSWPM_ID = '" + e.CommandArgument.ToString() + "'";
            label_detailcondition.Text = condition;
            Gridview_WeekPlanDetail.DataSource = wp.Select_SalesWeekPlanDetail_Condition(condition);
            Gridview_Day.DataSource = wp.Select_SalesWeekPlanDetail_Condition(condition);
            Gridview_Day.DataBind();
            Gridview_WeekPlanDetail.DataBind();
            UpdatePanel_WeekPlanDetail.Update();
        }
        if (e.CommandName == "Delete1")//删除
        {
            wp.Delete_WeekPlanMain(new Guid(e.CommandArgument.ToString()));
            BindWeekPlanMain();
            UpdatePanel_WeekPlan.Update();
        }
    }
    protected void Gridview_WeekPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)//有数据了
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            //if (drv["SMSWPM_State"].ToString().Trim() != "已提交")
            //{
            //    e.Row.Cells[11].Enabled = false;
            //    e.Row.Cells[8].Enabled = false;
            //}
            if (drv["SMSWPM_State"].ToString().Trim() == "已提交")
            {
                e.Row.Cells[11].Enabled = false;
                
            }
            if (drv["SMSWPM_State"].ToString().Trim() == "已新建" || drv["SMSWPM_State"].ToString().Trim() == "已提交")
            {

                e.Row.Cells[8].Enabled = true;
            }
            else
            {
                e.Row.Cells[8].Enabled = false;
            
            }
            //if (drv["SMSWPM_State"].ToString().Trim() == "已新建")
            //{
            //    e.Row.Cells[10].Enabled = false;
            //}
            if (drv["SMSWPM_State"].ToString().Trim() != "会签中" && drv["SMSWPM_State"].ToString().Trim() != "已提交" && !(Session["UserRole"].ToString().Contains("销售周计划会签查看")))
            {
                e.Row.Cells[10].Enabled = false;
            }
            else {
                e.Row.Cells[10].Enabled = true;
            }
            if (drv["SMSWPM_State"].ToString().Trim() == "已新建")
            {
                e.Row.Cells[11].Enabled = true;
            }
            else
            {
                e.Row.Cells[11].Enabled = false;
            }
        }
    }
    protected void Gridview_WeekPlan_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_WeekPlan.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_WeekPlan.Rows[i].Cells.Count; j++)
            {
                Gridview_WeekPlan.Rows[i].Cells[j].ToolTip = Gridview_WeekPlan.Rows[i].Cells[j].Text;
                if (Gridview_WeekPlan.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_WeekPlan.Rows[i].Cells[j].Text = Gridview_WeekPlan.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        } 
    }
    //WeekPlanDetail
    protected void Gridview_WeekPlanDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_WeekPlanDetail.BottomPagerRow;


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
        BindWeekDetail();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_WeekPlanDetail.PageCount ? Gridview_WeekPlanDetail.PageCount - 1 : newPageIndex;
        Gridview_WeekPlanDetail.PageIndex = newPageIndex;
        Gridview_WeekPlanDetail.DataBind();
    }
    protected void Gridview_WeekPlanDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete2")//shanchu
        {
            wp.Delete_WeekPlanDetail(new Guid(e.CommandArgument.ToString()));
            Gridview_WeekPlanDetail.DataSource = wp.Select_SalesWeekPlanDetail_Condition(label_detailcondition.Text.ToString());
            Gridview_WeekPlanDetail.DataBind();
            Gridview_Day.DataSource = wp.Select_SalesWeekPlanDetail_Condition(label_detailcondition.Text.ToString());
            Gridview_Day.DataBind();
            UpdatePanel_WeekPlanDetail.Update();
        }
        if (e.CommandName == "Look2")
        {
            Panel2.Visible = true;
            UpdatePanel_WeekPlanDetail.Update();
        }
    }

    protected void Gridview_WeekPlanDetail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_WeekPlanDetail.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_WeekPlanDetail.Rows[i].Cells.Count; j++)
            {
                Gridview_WeekPlanDetail.Rows[i].Cells[j].ToolTip = Gridview_WeekPlanDetail.Rows[i].Cells[j].Text;
                if (Gridview_WeekPlanDetail.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_WeekPlanDetail.Rows[i].Cells[j].Text = Gridview_WeekPlanDetail.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }  
    }

    //Protype
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
    #endregion



    protected void Gridview_Day_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        //new add for checkbox

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Day.BottomPagerRow;

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

        BindWeekDetail();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Day.PageCount ? Gridview_Day.PageCount - 1 : newPageIndex;
        //RemeberOldValues();
        Gridview_Day.PageIndex = newPageIndex;
        Gridview_Day.DataBind();
    }
    protected void CloseProType(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Gridview_WeekPlanDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Row.DataItem;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //mount 月计划总量 mount1 投产数
            int mount1 = 0, mount;
            float rate;
            if (drv["mount1"] != DBNull.Value)
            {
                mount1 = Convert.ToInt32(Convert.ToInt32(drv["mount1"]) / 0.8);
            }
            if (drv["mount"] != DBNull.Value&&!drv["mount"].Equals(0))
            {
                mount = Convert.ToInt32(drv["mount"]);
                rate = mount1 / mount;
                if (rate >= 1)
                {
                    e.Row.BackColor = Color.Pink;
                }
            }
            if (drv["mount"].Equals(0))
            {

                e.Row.BackColor = Color.Pink;
            }

        }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label4.Text = "";
        string str;
        if (DropDownList6.SelectedValue == "选择系列")
        {
           str= "";
        }
        else
        {
            str= " and PS_Name like '%" + DropDownList6.SelectedValue.ToString() + "%'";
          
        }
        Label4.Text = str;
        BindWeekDetail();
       
    }
    protected void BindDropdownList6()
    {
        DropDownList6.DataSource = ptp.Select_PS();
        DropDownList6.DataValueField = "PS_Name";
        DropDownList6.DataTextField = "PS_Name";
        DropDownList6.DataBind();
        UpdatePanel_WeekPlanDetail.Update();
        DropDownList6.Items.Insert(0,new ListItem( "选择系列", "选择系列"));
    }
}