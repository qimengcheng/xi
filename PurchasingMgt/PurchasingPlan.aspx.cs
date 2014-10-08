using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class PurchasingMgt_PurchasingPlan : Page
{

    PurchasingPlanL pp = new PurchasingPlanL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList1();
            BindDropDownList11();
            BindDropDownList111();
            BindPlanMain();
            BindOrder();
            BindMatPlan_Add();
            BindMatPlan_Original();
            BindMatPlan_Week();
            #region 权限
            if (Request.QueryString["status"] == "PurchasingPlanLook")//采购计划查看
            {
                Title = "采购计划查看";
                Button6.Visible = false;
                UpdatePanel_Search.Update();
                Gridview_MonthPlan.Columns[9].Visible = false;
                Gridview_MonthPlan.Columns[10].Visible = false;
                Gridview_MonthPlan.Columns[11].Visible = false;
                UpdatePanel_MonthPlan.Update();
                Gridview_DetailPlan.Columns[11].Visible = false;
                Gridview_DetailPlan.Columns[12].Visible = false;
                Gridview_DetailPlan.Columns[13].Visible = false;
                Button31.Visible = false;
                Button2.Visible = false;
                Button33.Visible = false;
                UpdatePanel_Detail.Update();

            }
            if (Request.QueryString["status"] == "PurchasingPlanEdit")//采购计划维护
            {
                Title = "采购计划维护";
                Button6.Visible = true;
                ButtonPro.Visible = true;
                Cbx2_SelectAll.Visible = true;
                Button8.Visible = true;
                CheckBox1.Visible = true;
                UpdatePanel_Search.Update();
                Gridview_MonthPlan.Columns[9].Visible = true;
                Gridview_MonthPlan.Columns[10].Visible = false;
                Gridview_MonthPlan.Columns[11].Visible = true;
                UpdatePanel_MonthPlan.Update();
                Gridview_DetailPlan.Columns[11].Visible = true;
                Gridview_DetailPlan.Columns[12].Visible = true;
                Gridview_DetailPlan.Columns[13].Visible = true;
                Button31.Visible = true;
                Button2.Visible = false;
                Button33.Visible = true;
                UpdatePanel_Detail.Update();

            }
            if (Request.QueryString["status"] == "PurchasingPlanCheck")//采购计划审核
            {
                Title = "采购计划审核";
                Button6.Visible = false;
                UpdatePanel_Search.Update();
                Gridview_MonthPlan.Columns[9].Visible = false;
                Gridview_MonthPlan.Columns[10].Visible = true;
                Gridview_MonthPlan.Columns[11].Visible = false;
                UpdatePanel_MonthPlan.Update();
                Gridview_DetailPlan.Columns[11].Visible = false;
                Gridview_DetailPlan.Columns[12].Visible = false ;
                Gridview_DetailPlan.Columns[13].Visible = false;
                Button31.Visible = false;
                Button2.Visible = false;
                Button33.Visible = false;
                UpdatePanel_Detail.Update();

            }
            if (Request.QueryString["status"] == "PurchasingPlanBuy")//采购计划执行
            {
                Title = "采购计划执行";
                ButtonPro.Visible = true;
                Button8.Visible = true;
                Button17.Visible = true;
                Cbx2_SelectAll.Visible = true;
                CheckBox1.Visible = true;
                CheckBox3.Visible = true;
                Button6.Visible = false;
                UpdatePanel_Search.Update();            
                Gridview_MonthPlan.Columns[9].Visible = false;
                Gridview_MonthPlan.Columns[10].Visible = false;
                Gridview_MonthPlan.Columns[11].Visible = false;
                UpdatePanel_MonthPlan.Update();
                Gridview_DetailPlan.Columns[0].Visible = true;
                Gridview_DetailPlan.Columns[11].Visible = false;
                Gridview_DetailPlan.Columns[12].Visible = false;
                Gridview_DetailPlan.Columns[13].Visible = false;
                Button31.Visible = false;
                Button2.Visible = true;
                Button33.Visible = false;
                UpdatePanel_Detail.Update();
            }
            if (Request.QueryString["status"] == "PurchasingPlanMatBuy")//材料周计划执行
            {
                Title = "材料周计划执行";
                Panel_PMPurchaseOrder.Visible = false;
                UpdatePanel_PMPurchaseOrder.Update();
                Button17.Visible = true;
                CheckBox3.Visible = true;
                Panel_Search.Visible = false;
                UpdatePanel_Search.Update();
                Panel_MonthPlan.Visible = false;
                UpdatePanel_MonthPlan.Update();
                Panel_Choose.Visible = true;
                Button10.Visible = false;
                Button11.Visible = false;
                UpdatePanel_Choose.Update();
                //this.Label6.Text = "6CFEB693-4DE7-49F9-A0C3-2A89A5B990FB";
                BindOrder();
                Panel_PMPurchaseOrder.Visible = false;
                UpdatePanel_PMPurchaseOrder.Update();
            }
            #endregion
        }
    }
    #region 采购计划主表
    protected void BindDropDownList1()//检索
    {
        DropDownList11.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        DropDownList1.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        for (int y = 1; y <= 12; y++)
        {
            DropDownList11.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList1.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    protected void BindDropDownList11()//新增
    {
        DropDownList9.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        DropDownList8.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        for (int y = 1; y <= 12; y++)
        {
            DropDownList9.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList8.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    protected void BindDropDownList111()//材料计划检索
    {
        DropDownList12.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        DropDownList13.Items.Insert(0, new ListItem("选择周次", "选择周次"));
        DropDownList10.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        for (int y = 1; y <= 12; y++)
        {
            DropDownList12.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList10.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        for (int m = 1; m <= 52; m++)
        {
            DropDownList13.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    //检索条件获取
    public string GetCondition_PlanMain()
    {
        string conditon;
        string temp = "";
        if (DropDownList1.SelectedValue != "选择年份")
        {
            temp += " and PMPPM_Year like'%" + DropDownList1.SelectedValue.ToString().Trim() + "%'";
        }
        if (DropDownList11.SelectedValue != "选择月份")
        {
            temp += " and PMPPM_Month like'%" + DropDownList11.SelectedValue.ToString().Trim() + "%'";
        }
        if (DropDownList7.SelectedValue != "选择状态")
        {
            temp += " and PMPPM_State like'%" + DropDownList7.SelectedValue.ToString().Trim() + "%'";
        }
        conditon = temp;
        label19.Text = conditon;
        return conditon;
    }
    //绑定主表
    protected void BindPlanMain()
    {
        Gridview_MonthPlan.DataSource = pp.Select_PlanMain(label19.Text.ToString());
        Gridview_MonthPlan.DataBind();
        UpdatePanel_MonthPlan.Update();
    }
    //
    //检索计划主表
    protected void SearchMonthPlan(object sender, EventArgs e)
    {
        GetCondition_PlanMain();
        BindPlanMain();
    }
    //新建计划主表
    protected void CreateMonthPlan(object sender, EventArgs e)
    {
        Panel6.Visible = true;
        UpdatePanel5.Update();
    }
    #region gridview_MonthPlan
    protected void Gridview_MonthPlan_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_MonthPlan.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_MonthPlan.Rows[i].Cells.Count; j++)
            {
                Gridview_MonthPlan.Rows[i].Cells[j].ToolTip = Gridview_MonthPlan.Rows[i].Cells[j].Text;
                if (Gridview_MonthPlan.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_MonthPlan.Rows[i].Cells[j].Text = Gridview_MonthPlan.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview_MonthPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv.Row["PMPPM_State"].ToString() != "已提交")
            {
                e.Row.Cells[10].Enabled = false;//审核
                
            }//审核
            if (drv.Row["PMPPM_State"].ToString() == "待提交" || drv.Row["PMPPM_State"].ToString() == "已提交")
            {
               
                e.Row.Cells[9].Enabled = true;
                

            }
            else
            {
               
                //e.Row.Cells[8].Enabled = false;
                e.Row.Cells[9].Enabled = false;
            }//编辑删除
            //if (drv.Row["PMPPM_State"].ToString() == "待提交")
            //{
            //    e.Row.Cells[11].Enabled = true;

            //}
            //else {
            //    e.Row.Cells[11].Enabled = false;

            //}
           
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


        BindPlanMain();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_MonthPlan.PageCount ? Gridview_MonthPlan.PageCount - 1 : newPageIndex;
        Gridview_MonthPlan.PageIndex = newPageIndex;
        Gridview_MonthPlan.DataBind();
    }
    protected void Gridview_MonthPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Detail1")
        {
            if(Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[3].Text!="待提交")
            {
            Button31.Visible = false;
            Button33.Visible = false;
            Gridview_DetailPlan.Columns[12].Visible = false;
            Gridview_DetailPlan.Columns[13].Visible = false;
            UpdatePanel_Detail.Update();
            }
            else
            {
                if (Request.QueryString["status"] == "PurchasingPlanEdit")//采购计划维护
                {
                    if (Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[3].Text == "已新建")
                    {

                        Button31.Visible = true;
                        Button33.Visible = true;
                        UpdatePanel_Detail.Update();
                    }
                    
                }
            }
            if (Request.QueryString["status"] == "PurchasingPlanBuy")//采购计划zhixing
            {
                if (Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[3].Text != "审核通过")
                {
                    Button2.Visible = false;
                    UpdatePanel_Detail.Update();
                }
                else
                {
                    Button2.Visible = true;
                    UpdatePanel_Detail.Update();
                }
                
            }
            label53.Text = e.CommandArgument.ToString();
            Panel_Detail.Visible = true;
            BindDetail();
            UpdatePanel_Detail.Update();
        }

        if (e.CommandName == "Delete1")
        {
            Guid id = new Guid(e.CommandArgument.ToString());
            pp.Delete_PlanMain(id);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindPlanMain();

        }
        if (e.CommandName == "Check1")
        {
            Label33.Text = e.CommandArgument.ToString();
            Panel_ADDCheck.Visible = true;
            TextBox_AddMan.Text = Session["UserName"].ToString().Trim();
            TextBox_Addtime.Text = DateTime.Now.ToShortDateString();
            UpdatePanel_ADDCheck.Update();

        }
        if (e.CommandName == "Mat1")
        {
            string state = Gridview_MonthPlan.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            if(state=="审核通过")
            label2.Text = e.CommandArgument.ToString();
            label53.Text = e.CommandArgument.ToString();
            Panel_Choose.Visible = true;
            UpdatePanel_Choose.Update();
        }
    }
    #endregion
    #region 审核
    protected void BindDetail()
    {
        Guid id = new Guid(label53.Text.ToString());
        Gridview_DetailPlan.DataSource = pp.Select_PlanDetail(id);
        Gridview_DetailPlan.DataBind();
        UpdatePanel_Detail.Update();
    }
    //审核通过
    protected void Check_OK(object sender, EventArgs e)
    {
        string result = "审核通过";
        string man = Session["UserName"].ToString().Trim();
        string op = TextBox_AddOpinion.Text.ToString();
        Guid id = new Guid(Label33.Text.ToString());
        pp.Update_PlanMain_Check(id, result, op);
        BindPlanMain();
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过！')", true);


    }
    //审核驳回
    protected void Check_NotOK(object sender, EventArgs e)
    {
        string result = "审核驳回";
        string man = Session["UserName"].ToString().Trim();
        string op = TextBox_AddOpinion.Text.ToString();
        Guid id = new Guid(Label33.Text.ToString());
        if (op == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回时必须填写驳回意见！')", true);
            return;
        }
        pp.Update_PlanMain_Check(id, result, op);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核驳回成功！')", true);
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
        BindPlanMain();
    }
    //关闭审核
    protected void Check_Canel(object sender, EventArgs e)
    {
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
    }
    #endregion
    //确认新建计划
    protected void ConfirmNewPlanMain(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString();
        int year = Convert.ToInt32(DropDownList8.SelectedValue.ToString());
        int month = Convert.ToInt32(DropDownList9.SelectedValue.ToString());
        pp.Insert_PlanMain(year, month, man);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功！')", true);
        Panel6.Visible = false;
        UpdatePanel5.Update();
        BindPlanMain();
    }
    protected void CloseNewPlanMain(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        UpdatePanel5.Update();
    }
    //更新计划数
    protected void UpdateDetailNum(object sender, EventArgs e)
    {

        //提交本页数据
        foreach (GridViewRow item in Gridview_DetailPlan.Rows)
        {
            TextBox tb = item.FindControl("TextBox3") as TextBox;
            decimal num = 0;
            if (tb.Text == "")
            {
                num = 0;
            }
            else
            {
                num = Convert.ToDecimal(tb.Text.ToString());
            }
            Guid id = new Guid(Gridview_DetailPlan.DataKeys[item.RowIndex]["PMPPD_ID"].ToString());
            pp.Insert_ShouhouSort(id, num);//这名字忘记改了。更新数量用

        }
        BindDetail();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已更新本页采购计划数量！')", true);

    }
    //勾选生成采购订单
    protected void Order_MonthPlan(object sender, EventArgs e)
    {
        Label_Way.Text = "Month";
        Panel3.Visible = true;
        Label6.Text = Guid.NewGuid().ToString();
        UpdatePanel3.Update();
        
    }
    //提交采购计划
    protected void TijiaoPlanMain(object sender, EventArgs e)
    {
        Guid id = new Guid(label53.Text.ToString());
        pp.Update_PlanMain_Tijiao(id);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        BindPlanMain();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
    }
    //关闭详细表
    protected void CloseDetail(object sender, EventArgs e)
    {
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
    }
    protected void Gridview_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_DetailPlan.BottomPagerRow;


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


        BindDetail();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_DetailPlan.PageCount ? Gridview_DetailPlan.PageCount - 1 : newPageIndex;
        Gridview_DetailPlan.PageIndex = newPageIndex;
        Gridview_DetailPlan.DataBind();
    }
    protected void Gridview_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Delete2")
        {
            pp.Delete_Plan_Detail(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindDetail();
        }
        if (e.CommandName == "Edit2")
        {
            Panel9.Visible = true;
            label25.Text = e.CommandArgument.ToString();
            TextBox1.Text = Gridview_DetailPlan.Rows[gvr.RowIndex].Cells[10].Text.ToString().Replace("&nbsp;","");
            TextBox5.Text = Gridview_DetailPlan.Rows[gvr.RowIndex].Cells[9].Text.ToString().Replace("&nbsp;", "");
            UpdatePanel8.Update();
        }
        
    }
    //确认编辑详细表
    protected void ConfirmDetailUpdate(object sender, EventArgs e)
    {
        string request = TextBox1.Text.ToString();
        string remark = TextBox5.Text.ToString();
        Guid id = new Guid(label25.Text.ToString());
        pp.Update_PlanDetail_Edit(id, remark, request);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('修改成功！')", true);
        BindDetail();
        Panel9.Visible = false;
        UpdatePanel8.Update();
    }
    protected void CloseDetailUpdate(object sender, EventArgs e)
    {
        Panel9.Visible = false;
        UpdatePanel8.Update();
    }
    protected void Gridview_DetailPlan_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_DetailPlan.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_DetailPlan.Rows[i].Cells.Count; j++)
            {
                Gridview_DetailPlan.Rows[i].Cells[j].ToolTip = Gridview_DetailPlan.Rows[i].Cells[j].Text;
                if (Gridview_DetailPlan.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_DetailPlan.Rows[i].Cells[j].Text = Gridview_DetailPlan.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    #endregion
  
    #region 材料计划
    //材料月计划绑定
    protected void BindMatPlan_Original()
    {
        Gridview_MatMonthOriginal.DataSource = pp.Select_MatPlan_Original(label24.Text.ToString());
        Gridview_MatMonthOriginal.DataBind();
        UpdatePanel_MatMonthOriginal.Update();
    }
    //新增材料月计划绑定
    protected void BindMatPlan_Add()
    {
        Gridview_AdditionPlan.DataSource = pp.Select_MatPlan_Add(label47.Text.ToString());
        Gridview_AdditionPlan.DataBind();
        UpdatePanel_AdditionPlan.Update();
    }
    //材料周计划绑定
    protected void BindMatPlan_Week()
    {
        Gridview_Week.DataSource = pp.Select_MatPlan_Week(label14.Text.ToString());
        Gridview_Week.DataBind();
        UpdatePanel_Week.Update();
    }
    //查看月计划
    protected void SearchMatMonthOriginal(object sender, EventArgs e)
    {
        Panel_MatMonthOriginal.Visible = true;
        GetCondition_MatPlanMonth("Original");
        BindMatPlan_Original();
    }
    //查看希增月计划
    protected void SearchMatMonthAddtion(object sender, EventArgs e)
    {
        Panel_AdditionPlan.Visible = true;
        GetCondition_MatPlanMonth("Add");
        BindMatPlan_Add();
    }
    //查看周计划
    protected void SearchMatWeekOriginal(object sender, EventArgs e)
    {
        Panel_Week.Visible = true;
        GetCondition_MatPlanWeek();
        BindMatPlan_Week();
    }
    public string GetCondition_MatPlanMonth(string way)
    {
        string conditon;
        string temp = "";
        string year = "";
        if (DropDownList10.SelectedValue != "选择年份")
        {
            temp += " and PMP_Year like'%" + DropDownList10.SelectedValue.ToString().Trim() + "%'";
            year += DropDownList10.SelectedValue.ToString().Trim();
        }
        if (DropDownList12.SelectedValue != "选择月份")
        {
            temp += " and PMP_Month like'%" + DropDownList12.SelectedValue.ToString().Trim() + "%'";
            year += "-"+DropDownList12.SelectedValue.ToString().Trim();
        }
        conditon = temp;
        if (way == "Original")
        {
            label24.Text = conditon;
            label46.Text = year;
        }
        else if (way == "Add")
        {
            label47.Text = conditon;
            label48.Text = year;
        }
        return conditon;
    }
    public string GetCondition_MatPlanWeek()
    {
        string conditon;
        string temp = "";
        string year = "";
        if (DropDownList10.SelectedValue != "选择年份")
        {
            temp += " and PWP_Year like'%" + DropDownList10.SelectedValue.ToString().Trim() + "%'";
            year += DropDownList10.SelectedValue.ToString().Trim();
        }
        if (DropDownList12.SelectedValue != "选择月份")
        {
            temp += " and PWP_Month like'%" + DropDownList12.SelectedValue.ToString().Trim() + "%'";
            year +="-"+ DropDownList12.SelectedValue.ToString().Trim();
        }
        if (DropDownList13.SelectedValue != "选择周次")
        {
            temp += " and PWP_SN like'%" + DropDownList13.SelectedValue.ToString().Trim() + "%'";
            year += "-" + DropDownList13.SelectedValue.ToString().Trim();
        }
        conditon = temp;
        label14.Text = conditon;
        label18.Text = year;
        return conditon;
    }

    protected void Gridview_MatMonthOriginal_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_MatMonthOriginal.BottomPagerRow;


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


        BindMatPlan_Original();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_MatMonthOriginal.PageCount ? Gridview_MatMonthOriginal.PageCount - 1 : newPageIndex;
        Gridview_MatMonthOriginal.PageIndex = newPageIndex;
        Gridview_MatMonthOriginal.DataBind();
    }
    protected void Gridview_AdditionPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_AdditionPlan.BottomPagerRow;


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


        BindMatPlan_Add();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_AdditionPlan.PageCount ? Gridview_AdditionPlan.PageCount - 1 : newPageIndex;
        Gridview_AdditionPlan.PageIndex = newPageIndex;
        Gridview_AdditionPlan.DataBind();
    }
    protected void Gridview_Week_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Week.BottomPagerRow;


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
        BindMatPlan_Week();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Week.PageCount ? Gridview_Week.PageCount - 1 : newPageIndex;
        Gridview_Week.PageIndex = newPageIndex;
        Gridview_Week.DataBind();
    }
    //原始月计划
    protected void Plan_MatOriginal(object sender, EventArgs e)
    {
        //提交本页数据
        foreach (GridViewRow item in Gridview_MatMonthOriginal.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            Guid id = new Guid(label2.Text.ToString());
            if (cb.Checked)
            {
                decimal num = Convert.ToDecimal(Gridview_MatMonthOriginal.DataKeys[item.RowIndex]["MMPD_Num"].ToString());
                string note = Gridview_MatMonthOriginal.DataKeys[item.RowIndex]["MMPD_Note"].ToString();
                Guid Mid = new Guid(Gridview_MatMonthOriginal.DataKeys[item.RowIndex]["IMMBD_MaterialID"].ToString());
                pp.Insert_DetailPlan_Mat(id, Mid, num, note);
            }
        }
        Panel_Detail.Visible = true;
        BindDetail();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);

    }
    protected void Close_MatOriginal(object sender, EventArgs e)
    {
        Panel_MatMonthOriginal.Visible = false;
        UpdatePanel_MatMonthOriginal.Update();
    }
    protected void Cbx2_NativeMonthPlan_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= Gridview_MatMonthOriginal.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)Gridview_MatMonthOriginal.Rows[i].FindControl("CheckBox2");
            if (Cbx2_SelectAll.Checked)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
        UpdatePanel_MatMonthOriginal.Update();
    }
    //新增月计划
    protected void Cbx2_ADDMonthPlan_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= Gridview_AdditionPlan.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)Gridview_AdditionPlan.Rows[i].FindControl("CheckBox2");
            if (CheckBox1.Checked)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
        UpdatePanel_AdditionPlan.Update();
    }
    protected void OK_AdditionPlan(object sender, EventArgs e)
    {
        //提交本页数据
        foreach (GridViewRow item in Gridview_MatMonthOriginal.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            Guid id = new Guid(label2.Text.ToString());
            if (cb.Checked)
            {
                decimal num = Convert.ToDecimal(Gridview_AdditionPlan.DataKeys[item.RowIndex]["MMPD_Num"].ToString());
                string note = Gridview_AdditionPlan.DataKeys[item.RowIndex]["MMPD_Note"].ToString();
                Guid Mid = new Guid(Gridview_AdditionPlan.DataKeys[item.RowIndex]["IMMBD_MaterialID"].ToString());
                pp.Insert_DetailPlan_Mat(id, Mid, num, note);
            }
        }
        BindDetail();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);

    }
    protected void Close_AdditionPlan(object sender, EventArgs e)
    {
        Panel_AdditionPlan.Visible = false;
        UpdatePanel_AdditionPlan.Update();
    }
    protected void Close_WeeKPlan(object sender, EventArgs e)
    {
        Panel_Week.Visible = false;
        UpdatePanel_Week.Update();
    }
    protected void Cbx2_WeekPlan_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= Gridview_Week.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)Gridview_Week.Rows[i].FindControl("CheckBox2");
            if (CheckBox3.Checked)
            {
                cbox.Checked = true;
                UpdatePanel_Week.Update();
            }
            else
            {
                cbox.Checked = false;
                UpdatePanel_Week.Update();
            }
        }
        UpdatePanel_Week.Update();
    }
    protected void ButtonMark(object sender, EventArgs e)
    {
        Guid id = new Guid(label_MaterialID.Text.ToString());
        pp.Update_Order_Tijiao(id);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        Panel_PMPurchaseOrderDetail.Visible = false;
        UpdatePanel_PMPurchaseOrderDetail.Update();
        BindOrder();
    }
    protected void ButtonCancel(object sender, EventArgs e)
    {
        Panel_PMPurchaseOrderDetail.Visible = false;
        UpdatePanel_PMPurchaseOrderDetail.Update();
    }
    #endregion
    #region 采购订单
    //选择供应商
    protected void Button_Select3(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        BindSupply();
    }
    //提交订单
    protected void Button_Create(object sender, EventArgs e)
    {
        Guid id = new Guid(Label6.Text.ToString());
        Guid sid = new Guid(pdid.Text.ToString());    
        string payway = DropDownList6.SelectedValue.ToString();
        if (payway == "请选择")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择付款方式！')", true);
            return;
        }
        int paymenttime = 0;
        if (TextBox4.Text == "")
        {
             paymenttime = 0;
        }
        else
        {
             paymenttime = Convert.ToInt32(TextBox4.Text.ToString());
        }
        DateTime arrtime = Convert.ToDateTime(TextBox6.Text.ToString());
        DateTime remindtime = Convert.ToDateTime(TextBox7.Text.ToString());
        string man = Session["UserName"].ToString().Trim();
        pp.Insert_PurchaseOrder(id, sid, payway, paymenttime, arrtime, remindtime, man);
        if (Label_Way.Text == "Month")
        {

            foreach (GridViewRow item in Gridview_DetailPlan.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                if (cb.Checked)
                {
                    Guid pid = new Guid(Gridview_DetailPlan.DataKeys[item.RowIndex]["PMPPD_ID"].ToString());
                    Guid Mid = new Guid(Gridview_DetailPlan.DataKeys[item.RowIndex]["IMMBD_MaterialID"].ToString());
                    decimal num =0;
                    if (Gridview_DetailPlan.Rows[item.RowIndex].Cells[7].Text.ToString().Replace("&nbsp;", "") == "")
                    {
                        num = 0;
                    }
                    else {
                        num = Convert.ToDecimal(Gridview_DetailPlan.Rows[item.RowIndex].Cells[7].Text.ToString().Replace("&nbsp;", ""));
                    }
                    pp.Insert_Material_MonthPlan(id, pid, Mid, num);

                }
            }
        }
        else if (Label_Way.Text == "Week")
        {
            foreach (GridViewRow item in Gridview_Week.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                if (cb.Checked)
                {
                    Guid pid = new Guid(Gridview_Week.DataKeys[item.RowIndex]["MWPD_ID"].ToString());
                    Guid Mid = new Guid(Gridview_Week.DataKeys[item.RowIndex]["IMMBD_MaterialID"].ToString());
                    decimal num = Convert.ToDecimal(Gridview_Week.Rows[item.RowIndex].Cells[5].Text.ToString());
                    pp.Insert_Material_WeekPlan(id, pid, Mid, num);

                }
            }
        }

        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功！')", true);

        Panel_PMPurchaseOrder.Visible = true;
        UpdatePanel_PMPurchaseOrder.Update();
        BindOrder();
    }
    //取消提交
    protected void Button_Reset4(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void Search_Supply(object sender, EventArgs e)
    {
        string temp = " and PMSI_SupplyName like'%" + PurchaseOrderID.Text.ToString().Trim() + "%'";
        LabelSupplyID.Text = temp;
        BindSupply();
    }
    protected void Gridview_PMSupply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview2.BottomPagerRow;


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


        BindSupply();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    protected void Gridview2_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Choose3")
        {
            pdid.Text = e.CommandArgument.ToString();
            TextBox2.Text = Gridview2.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            UpdatePanel3.Update();
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }
    }
    protected void BindSupply()
    {
        Gridview2.DataSource = pp.Select_Supply(LabelSupplyID.Text.ToString());
        Gridview2.DataBind();
        UpdatePanel4.Update();
    }
    //又材料周计划生成采购订单
    protected void WeekToOrder(object sender, EventArgs e)
    {
        Label_Way.Text = "Week";
        Label6.Text = Guid.NewGuid().ToString();
        Panel3.Visible = true;
        UpdatePanel3.Update();

    }
    //绑定订单
    protected void BindOrder()
    {
        string temp = " and PMPO_PurchaseOrderID like'%" + Label6.Text.ToString().Trim() + "%'";
        Gridview3.DataSource = pp.Select_Order_Main(temp);
        Gridview3.DataBind();
        UpdatePanel_PMPurchaseOrder.Update();
    }
    //绑定订单
    protected void BindOrderDetail()
    {

        Gridview1.DataSource = pp.Select_Order_Detail(new Guid(label_MaterialID.Text.ToString()));
        Gridview1.DataBind();
        UpdatePanel_PMPurchaseOrderDetail.Update();
    }
    protected void Gridview3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview3.BottomPagerRow;


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


        BindOrder();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
        Gridview3.PageIndex = newPageIndex;
        Gridview3.DataBind();
    }
    protected void Gridview3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Look1")
        {
            label_MaterialID.Text = e.CommandArgument.ToString();
            Panel_PMPurchaseOrderDetail.Visible = true;
            UpdatePanel_PMPurchaseOrderDetail.Update();
            Gridview1.Columns[9].Visible = false;
            Gridview1.Columns[10].Visible = false;
            Button22.Visible = false;
            Button24.Visible = false;
            BindOrderDetail();

        }
        if (e.CommandName == "Edit1")
        {
            label_MaterialID.Text = e.CommandArgument.ToString();
            Panel_PMPurchaseOrderDetail.Visible = true;
            Gridview1.Columns[9].Visible = true;
            Gridview1.Columns[10].Visible = true;
            Button22.Visible = true;
            Button24.Visible = true;
            BindOrderDetail();
        }
        if (e.CommandName == "Delete2")
        {
            pp.Delete_Order(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindOrder();
        }
    }
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview1.BottomPagerRow;


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


        BindOrderDetail();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Delete1")
        {
            pp.Delete_Order_Detail(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindOrderDetail();
        }
        if (e.CommandName == "Edit1")
        {
            Panel1.Visible = true;
            Label16.Text = Gridview1.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            Label7.Text = e.CommandArgument.ToString();
            TextBox8.Text = Gridview1.DataKeys[gvr.RowIndex]["PMPOD_Price"].ToString();
            TextBox9.Text = Gridview1.DataKeys[gvr.RowIndex]["PMPOD_Num"].ToString();
            TextBox10.Text = Gridview1.DataKeys[gvr.RowIndex]["PMPOD_ProductRequest"].ToString();
            TextBox11.Text = Gridview1.DataKeys[gvr.RowIndex]["PMPOD_Remark"].ToString();
            UpdatePanel1.Update();

        }

    }
    protected void Edit_OrderDetail(object sender, EventArgs e)
    {
        Guid id = new Guid(Label7.Text.ToString());
        if (TextBox9.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写单价！')", true);
            return ;
        }
        decimal num = Convert.ToDecimal(TextBox9.Text.ToString());
        decimal price = Convert.ToDecimal(TextBox8.Text.ToString());
        string request = Convert.ToString(TextBox10.Text.ToString());
        string remark = Convert.ToString(TextBox11.Text.ToString());
        pp.Update_PurchaseOrder_Detail(id, num, price, remark, request);
        BindOrderDetail();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('修改成功！')", true);
        Panel1.Visible = false;
        UpdatePanel1.Update();

    }
    protected void Clsoe_OrderDetail(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
  
    #endregion





    protected void Gridview1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
}