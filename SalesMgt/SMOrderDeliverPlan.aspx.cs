using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class SalesMgt_SMOrderDeliverPlan : Page
{
    SMOrderDeliverPlanL dp = new SMOrderDeliverPlanL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label6.Text = " order by c.SMSO_PlaceOrderTime desc";
            TextBox10.Text = DateTime.Now.AddDays(0).ToShortDateString();//默认插入发货计划是当天
            BindDeliverPlan();
            Label8.Text = "";
            BindApply();
        
        }
        if (Request.QueryString["status"] == "SalesPlanLook")//发货计划查看
        {
            Title = "发货计划查看";
            Button8.Visible = true;
          
            UpdatePanel_Shenqing.Update();
            Button4.Visible = false;
            GridView_OrderDeliverPlan.Columns[11].Visible = false;
            GridView_OrderDeliverPlan.Columns[12].Visible = false;
            UpdatePanel1.Update();
            UpdatePanel_OrderDeliverPlan.Update();
        }
        if (Request.QueryString["status"] == "SalesPlanEdit")//发货计划维护
        {
            Title = "发货计划维护";
            Button4.Visible = true;
            Button8.Visible = true;
           
            UpdatePanel_Shenqing.Update();
            GridView_OrderDeliverPlan.Columns[11].Visible = true;
            GridView_OrderDeliverPlan.Columns[12].Visible = true;
            UpdatePanel1.Update();
            UpdatePanel_OrderDeliverPlan.Update();
        }
        if (Request.QueryString["status"] == "SalesPlanApplyEdit")//特殊发货申请查看
        {
            Title = "特殊发货申请查看";
            Button8.Visible = false;
            Panel_Shenqing.Visible = true;
            UpdatePanel_Shenqing.Update();
            Panel_Shenqingbiao.Visible = true;
            UpdatePanel_Shenqingbiao.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel_OrderDeliverPlan.Visible = false;
            UpdatePanel_OrderDeliverPlan.Update();
            GridView_shenqingbiao.Columns[14].Visible = false;
            GridView_shenqingbiao.Columns[15].Visible = false;
            UpdatePanel_Shenqingbiao.Update();
        }
        if (Request.QueryString["status"] == "SalesPlanApplyCheck")//特殊发货申请审核
        {
            Title = "特殊发货申请审核";
            Button8.Visible = false;
            Panel_Shenqing.Visible = true;
            UpdatePanel_Shenqing.Update();
            Panel_Shenqingbiao.Visible = true;
            UpdatePanel_Shenqingbiao.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel_OrderDeliverPlan.Visible = false;
            UpdatePanel_OrderDeliverPlan.Update();
            GridView_shenqingbiao.Columns[15].Visible = true;
            GridView_shenqingbiao.Columns[14].Visible = false;
            UpdatePanel_Shenqingbiao.Update();
           
        }
    }
    #region 发货计划
    //发货计划检索
    protected void SearchDeliverPlan(object sender, EventArgs e)
    {
        if (TextBox9.Text.ToString() == "")
        {
            Label5.Text = "";
        }
        else
        {
            string temp = " and a.SMDP_Time like '%" + TextBox9.Text.ToString().Trim()+"%'";
            Label5.Text = temp;

        }
        BindDeliverPlan();
    }
    //绑定发货表
    protected void BindDeliverPlan()
    {
        GridView_OrderDeliverPlan.DataSource = dp.Select_DeliverPlan(Label5.Text.ToString().Trim());
        GridView_OrderDeliverPlan.DataBind();
        UpdatePanel_OrderDeliverPlan.Update();
    }
    //新建发货计划
    protected void NewDeliverPlan(object sender, EventArgs e)
    {
        Panel_Search.Visible = true;
      
        UpdatePanel_OrderDetail.Update();
        UpdatePanel_Search.Update();
    }
    #endregion
    #region 订单
    //重置
    protected void ClearOrder(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        DropDownList3.SelectedValue = "选择是否";
        DropDownList4.SelectedValue = "选择订单状态";
        DropDownList2.SelectedValue = "选择日期类型";
        DropDownList5.SelectedValue = "选择订单类型";
        DropDownList1.SelectedValue = "选择付款方式";
        UpdatePanel_Search.Update();
    }
    //查看预设提醒的订单--今天到期了还没发货的
    protected void CreateOrdered(object sender, EventArgs e)
    {
        string temp = " and DateAdd(dd,-convert(int,SMSOD_DelAlertTime),convert(date,SMSOD_OrderAdvanceDelTime))<=getdate() ";
        Label6.Text = temp;
        Panel_OrderDetail.Visible = true;
        UpdatePanel_OrderDetail.Update();
        BindOrder();
    }
    //订单检索条件拼接
    protected string GetCondition()
    {
        string conditon;
        string temp = "";
        if (TextBox3.Text.ToString() != "")//客户名称
        {
            temp += " and d.CRMCIF_Name like '%" + TextBox3.Text.ToString() + "%'";
        }
        if (TextBox4.Text.ToString() != "")//公司订单号
        {
            temp += " and c.SMSO_ComOrderNum like '%" + TextBox4.Text.ToString() + "%'";
        }
        if (TextBox5.Text.ToString() != "")//客户订单号
        {
            temp += " and c.SMSO_CusOrderNum like '%" + TextBox5.Text.ToString() + "%'";
        }
        if (TextBox7.Text.ToString() != "")//业务员
        {
            temp += " and c.SMSO_SalesMan like '%" + TextBox7.Text.ToString() + "%'";
        }
        if (TextBox8.Text.ToString() != "")//区域
        {
            temp += " and g.CRMRBI_Name like '%" + TextBox8.Text.ToString() + "%'";
        }
        if (DropDownList4.SelectedValue.ToString() != "选择订单状态")//订单状态
        {
            temp += " and c.SMSO_OrderState like '%" + DropDownList4.SelectedValue.ToString() + "%'";
        }
        if (DropDownList2.SelectedValue.ToString() == "下单日期")//下单日期
        {
            temp += " and c.SMSO_PlaceOrderTime between '" + TextBox1.Text.ToString() + "'and'" + TextBox2.Text.ToString() + "'";
        }
        if (DropDownList2.SelectedValue.ToString() == "交货期")//下单日期
        {
            temp += " and b.SMSOD_OrderDelTime between '" + TextBox1.Text.ToString() + "'and'" + TextBox2.Text.ToString() + "'";
        }
        if (DropDownList2.SelectedValue.ToString() == "预交货期")//下单日期
        {
            temp += " and b.SMSOD_OrderAdvanceDelTime between '" + TextBox1.Text.ToString() + "'and'" + TextBox2.Text.ToString() + "'";
        }
        if (DropDownList5.SelectedValue.ToString() != "选择订单类型")//订单类型
        {
            temp += " and c.SMSO_OrderType like '%" + DropDownList5.SelectedValue.ToString() + "%'";
        }
     
        conditon = temp;
        Label6.Text = conditon;
        return conditon;
        
    }
    //绑定订单表
    protected void BindOrder()
    {
        GridView_OrderDetail.DataSource = dp.Select_DeliverPlan_Order(Label6.Text.ToString());
        GridView_OrderDetail.DataBind();
        UpdatePanel_OrderDetail.Update();
    }
    //检索订单
    protected void SearchOrder(object sender, EventArgs e)
    {
        GetCondition();
        Panel_OrderDetail.Visible = true;
        BindOrder();
    }
    //关闭
    protected void CLoseOrderInsert(object sender, EventArgs e)
    {
        Panel_OrderDetail.Visible = false;
        UpdatePanel_OrderDetail.Update();
    }
    //提交
    protected void ConfirmOrderInsert(object sender, EventArgs e)
    {
        foreach (GridViewRow item in GridView_OrderDetail.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            DateTime time = Convert.ToDateTime(TextBox10.Text.ToString().Trim());
            if (cb.Checked)
            {
                Guid ID = new Guid(GridView_OrderDetail.DataKeys[item.RowIndex]["SMSOD_ID"].ToString());
                dp.Insert_DeliverPlan(ID, time);
            }
           
        }
        BindDeliverPlan();
    }
   
    #endregion
    #region gridview
    //发货计划表
    protected void GridView_OrderDeliverPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_OrderDeliverPlan.BottomPagerRow;


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

        BindDeliverPlan();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_OrderDeliverPlan.PageCount ? GridView_OrderDeliverPlan.PageCount - 1 : newPageIndex;
        GridView_OrderDeliverPlan.PageIndex = newPageIndex;
        GridView_OrderDeliverPlan.DataBind();
    }
    protected void GridView_OrderDeliverPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete2")
        {
            dp.Delete_DeliverPlan(new Guid ( e.CommandArgument.ToString()));
            BindDeliverPlan();
        }
       
    }
    protected void GridView_OrderDeliverPlan_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid id = new Guid(GridView_OrderDeliverPlan.DataKeys[e.RowIndex]["SMDP_ID"].ToString());
        decimal num = Convert.ToDecimal(((TextBox)(GridView_OrderDeliverPlan.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim());
        dp.Update_DeliverPlan(id,num);
        GridView_OrderDeliverPlan.EditIndex = -1;
        BindDeliverPlan();
    }

    protected void GridView_OrderDeliverPlan_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_OrderDeliverPlan.EditIndex = -1;
        BindDeliverPlan();
    }
    protected void GridView_OrderDeliverPlan_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_OrderDeliverPlan.EditIndex = e.NewEditIndex;
        BindDeliverPlan();
    }
    //订单表
    protected void GridView_OrderDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (Convert.ToDecimal(drv.Row["SMCBPM_MaturityLoan"].ToString()) > 0)//有欠款
            {
                e.Row.Cells[14].Enabled = true;
                e.Row.BackColor = Color.Red;
                e.Row.Cells[0].Enabled = false;
                if (drv.Row["SMSOD_AllowSpecDel"].ToString() == "是")
                {
                    e.Row.BackColor = Color.Green;
                    e.Row.Cells[0].Enabled = true;
                }
            }
            else {
                e.Row.Cells[13].Enabled = false;
                e.Row.BackColor = Color.SkyBlue;
                e.Row.Cells[0].Enabled = true;
            }

        }
    }
    protected void GridView_OrderDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_OrderDetail.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_OrderDetail.PageCount ? GridView_OrderDetail.PageCount - 1 : newPageIndex;
        GridView_OrderDetail.PageIndex = newPageIndex;
        GridView_OrderDetail.DataBind();
    }
    protected void GridView_OrderDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Special1")
        {
            Label3.Text = e.CommandArgument.ToString();
            Panel2.Visible = true;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "History")
        { 
            string temp=" and b.SMSOD_ID like '%" + e.CommandArgument.ToString().Trim() + "%'";
            Panel_Shenqingbiao.Visible = true;
            Label8.Text = temp;
            BindApply();
        }
    }
    //申请表
    protected void GridView_shenqingbiao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "checke1")
        {
            Panel_Check.Visible = true;
            label12.Text = e.CommandArgument.ToString().Trim();
            TextBox_AddMan.Text = Session["UserName"].ToString().Trim();
            TextBox_Addtime.Text = DateTime.Now.ToShortDateString();
            UpdatePanel_Check.Update();     
        }
        if (e.CommandName == "delete1")
        {
            dp.Delete_Apply(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            BindApply();
        }

    }
    protected void GridView_shenqingbiao_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_shenqingbiao.BottomPagerRow;


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

        BindApply();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_shenqingbiao.PageCount ? GridView_shenqingbiao.PageCount - 1 : newPageIndex;
        GridView_shenqingbiao.PageIndex = newPageIndex;
        GridView_shenqingbiao.DataBind();
    }
    protected void GridView_shenqingbiao_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_shenqingbiao.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_shenqingbiao.Rows[i].Cells.Count; j++)
            {
                GridView_shenqingbiao.Rows[i].Cells[j].ToolTip = GridView_shenqingbiao.Rows[i].Cells[j].Text;
                if (GridView_shenqingbiao.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_shenqingbiao.Rows[i].Cells[j].Text = GridView_shenqingbiao.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }  
    }
   #endregion
    #region 特殊发货申请
    protected void ConfirmReason(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString().Trim();
        Guid id = new Guid(Label3.Text.ToString().Trim());
        string opinion = TextBox12.Text.ToString().Trim();
        dp.Insert_Apply(id, man, opinion);
        Panel2.Visible = false;
        UpdatePanel2.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交申请成功！')", true);
        Label8.Text = "";
        Panel_Shenqingbiao.Visible = true;
        BindApply();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了新的特殊发货申请，请及时进行审核！";
        string sErr = RTXhelper.Send(remind, "特殊发货申请审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //关闭填写申请原因
    protected void CloseReason(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }

    //关闭申请表
    protected void Closeshenqingbiao(object sender, EventArgs e)
    {
        Panel_Shenqingbiao.Visible = false;
        UpdatePanel_Shenqingbiao.Update();
    }
    //审核通过
    protected void BT_ADD_TKOK_Click(object sender, EventArgs e)
    {
        string result = "审核通过";
        string man = Session["UserName"].ToString().Trim();
        string opinion = TextBox_AddOpinion.Text.ToString().Trim();
        Guid id = new Guid(label12.Text.ToString());
        dp.Update_Apply_Check(id, result, opinion, man);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核通过成功！')", true);
        Panel_Check.Visible = false;
        UpdatePanel_Check.Update();
        BindApply();
        BindOrder();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了你提交的特殊发货申请，请注意！";
        string sErr = RTXhelper.Send(remind, "发货计划维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //驳回
    protected void BT_ADD_TKNotOK_Click(object sender, EventArgs e)
    {
        string result = "审核驳回";
        string man = Session["UserName"].ToString().Trim();
        string opinion = TextBox_AddOpinion.Text.ToString().Trim();
        Guid id = new Guid(label12.Text.ToString());
        if (TextBox_AddOpinion.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核驳回必须填写驳回原因！')", true);
            return;
        }
        dp.Update_Apply_Check(id, result, opinion, man);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核驳回成功！')", true);
        Panel_Check.Visible = false;
        UpdatePanel_Check.Update();
        BindApply();
        BindOrder();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核驳回了你提交的特殊发货申请，请注意！";
        string sErr = RTXhelper.Send(remind, "发货计划维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //关闭审核
    protected void BT_ADD_TKCanel_Click(object sender, EventArgs e)
    {
        Panel_Check.Visible = false;
        UpdatePanel_Check.Update();
    }
    //检索申请
    protected void SearchApply(object sender, EventArgs e)
    {
        Getcondition_Apply();
        BindApply();
    }
    //关闭检索申请
    protected void CloseSearchApply(object sender, EventArgs e)
    {
        Panel_Shenqing.Visible = false;
        UpdatePanel_Shenqing.Update();
    }
    //检索条件获取
    protected string Getcondition_Apply()
    {
        string conditon;
        string temp = "";
        if (TextBox13.Text.ToString() != "")//客户名称
        {
            temp += " and d.CRMCIF_Name like '%" + TextBox13.Text.ToString() + "%'";
        }
        if (TextBox11.Text.ToString() != "")//公司订单号
        {
            temp += " and c.SMSO_ComOrderNum like '%" + TextBox11.Text.ToString() + "%'";
        }
        if (TextBox14.Text.ToString() != "")//yewuyuan
        {
            temp += " and a.SMSDA_ApplyMan like '%" + TextBox14.Text.ToString() + "%'";
        }
        conditon = temp;
        Label8.Text = conditon;
        return conditon;
    }
    //绑定
    protected void BindApply()
    {
        GridView_shenqingbiao.DataSource = dp.Select_SepcialApply(Label8.Text.ToString().Trim());
        GridView_shenqingbiao.DataBind();
        UpdatePanel_Shenqingbiao.Update();
    }
    #endregion


   
}
