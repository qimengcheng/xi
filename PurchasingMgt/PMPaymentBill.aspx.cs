using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProjectManagement_PMPaymentBill : Page
{
    PMPaymentBillinfo PMPaymentBillinfo = new PMPaymentBillinfo();
    PMPaymentBillL ppb = new PMPaymentBillL();
    PMSupplyInfo_PMSupplyContactL ppl = new PMSupplyInfo_PMSupplyContactL();
    PMPurchaseOrderL pl = new PMPurchaseOrderL();
    PMPurchaseOrderinfo PMPurchaseOrderinfo = new PMPurchaseOrderinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
       
            
            
        if (!(Session["UserRole"].ToString().Contains("采购付款")))
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!IsPostBack)
        {
            Title = "采购付款";
            BindGridview1("");
            foreach (GridViewRow item in Gridview1.Rows)
            {
                PMPaymentBillinfo.PMPB_ID = new Guid(Gridview1.DataKeys[item.RowIndex]["PMPB_ID"].ToString());
                PMPaymentBillinfo.PMSI_ID = new Guid(Gridview1.DataKeys[item.RowIndex]["PMSI_ID"].ToString());
                ppb.UpdatePMPaymentBill(PMPaymentBillinfo);
            }
            BindGridview1("");
            UpdatePanel_PayBill.Update();
        }
    }
  
    //采购付款开票表
    private void BindGridview1(string condition)
    {
        Gridview1.DataSource = ppb.SelectPMPaymentBill(condition);
        Gridview1.DataBind();
    }
    //供应商查询表
    private void BindGridview_PMSupply(string condition)
    {
        Gridview_PMSupply.DataSource = ppl.SelectPMSupplyInfo(condition);
        Gridview_PMSupply.DataBind();
    }
    //检索时选择供应商
    protected void Button_SSearch(object sender, EventArgs e)
    {
        label_Supply.Text = "检索";
        BindGridview_PMSupply("");
        Panel_Supply.Visible = true;
        UpdatePanel_Supply.Update();
    }
    #region //检索
    protected void Button_Sh2(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview1(condition);
        UpdatePanel_PayBill.Update();
        Panel_NewPayBill.Visible = false;
        UpdatePanel_NewPayBill.Update();
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
     
        Panel_Pay.Visible = false;
        UpdatePanel_Pay.Update();

        Panel_NewPay.Visible = false;
        UpdatePanel_NewPay.Update();
    }
    protected string Getcondition()
    {
        string condition;
        string item = "";
        if (TextBox_Factory.Text != "")
        {
            item += "and PMPaymentBill.PMSI_ID='" + label_SupplyID.Text + "'";
        }
        if (TextBox1.Text != "")
        {
            item += "and PMPB_TotalDebt>='" + TextBox1.Text + "'";
        }
        if (TextBox2.Text != "")
        {
            item += "and PMPB_Due>='" + TextBox2.Text + "'";
        }
        condition = item;
        labelcondition.Text = condition;
        return condition;
    }
    #endregion
    //新增
    protected void Button_New(object sender, EventArgs e)
    {
        Panel_NewPayBill.Visible = true;
        UpdatePanel_NewPayBill.Update();
    }
    //新增时选择供应商
    protected void Button_rady(object sender, EventArgs e)
    {
        label_Supply.Text = "新增";
        BindGridview_PMSupply("");
        Panel_Supply.Visible = true;
        UpdatePanel_Supply.Update();
    }

    //提交新增
    protected void Button_Rocky(object sender, EventArgs e)
    {
        string condition = "and PMPaymentBill.PMSI_ID='" + label_SupplyID.Text.ToString() + "'";
        DataSet ds = ppb.SelectPMPaymentBill(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewPayBill, GetType(), "aa", "alert('该供应商已存在！')", true);
            return;
        }
        else
        {
            PMPaymentBillinfo.PMSI_ID = new Guid(label_SupplyID.Text.ToString());
            PMPaymentBillinfo.PMPB_Due = 0;//应付款
            PMPaymentBillinfo.PMPB_TotalDebt = 0;//总欠款
            PMPaymentBillinfo.PMPB_TotalBill = 0;//开票总额
            PMPaymentBillinfo.PMPB_TotalPaided = 0;//已付款
            ppb.InsertPMPaymentBill(PMPaymentBillinfo);
            
            BindGridview1("");
            foreach (GridViewRow item in Gridview1.Rows)
            {
                PMPaymentBillinfo.PMPB_ID = new Guid(Gridview1.DataKeys[item.RowIndex]["PMPB_ID"].ToString());
                PMPaymentBillinfo.PMSI_ID = new Guid(Gridview1.DataKeys[item.RowIndex]["PMSI_ID"].ToString());
                ppb.UpdatePMPaymentBill(PMPaymentBillinfo);
            }
            BindGridview1("");
            UpdatePanel_PayBill.Update();
            TextBox6.Text = "";
            Panel_NewPayBill.Visible = false;
            UpdatePanel_NewPayBill.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewPayBill, GetType(), "aa", "alert('新增成功！')", true);
            return;
        }
    }
    //提交供应商
    protected void Button_ComSP(object sender, EventArgs e)
    {
        string Pname;
        bool temp = false;
        foreach (GridViewRow item in Gridview_PMSupply.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;
            if (rb.Checked)
            {
                label_SupplyID.Text = Gridview_PMSupply.DataKeys[item.RowIndex].Value.ToString();
                Pname = Gridview_PMSupply.Rows[item.RowIndex].Cells[3].Text.ToString();
                temp = true;
                if (label_Supply.Text == "检索")
                {
                    TextBox_Factory.Text = Pname;
                    UpdatePanel_SPayBillSearch.Update();
                }
                if (label_Supply.Text == "新增")
                {
                    TextBox6.Text = Pname;
                    UpdatePanel_NewPayBill.Update();
                    //PMPaymentBillinfo.PMSI_ID = new Guid(this.LabelSupplyID.Text.ToString());
                    //BindGridview7_Pay(PMPaymentBillinfo);
                    //Gridview7_BL();//总额
                }
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewPayBill, GetType(), "aa", "alert('请选择供应商')", true);
            return;
        }
        else
        {
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
        }
    }
    //private void Gridview7_BL()
    //{
    //    Decimal TotalMoney = 0;
    //    for (int i = 0; i < Gridview7.Rows.Count; i++)
    //    {
    //        TotalMoney += Convert.ToDecimal(this.Gridview7.Rows[i].Cells[11].Text.ToString());
    //    }
    //    this.label_TotalMoney.Text = Convert.ToString(TotalMoney);
    //}
    //重置
    protected void Button_Reset1(object sender, EventArgs e)
    {
        BindGridview1("");
        UpdatePanel_PayBill.Update();
        TextBox_Factory.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        UpdatePanel_SPayBillSearch.Update();
    }
    //取消新增
    protected void Button_Tim(object sender, EventArgs e)
    {
        TextBox6.Text = "";
        Panel_NewPayBill.Visible = false;
        UpdatePanel_NewPayBill.Update();
    }
    //取消选择供应商
    protected void Button_Cancel5(object sender, EventArgs e)
    {
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    //相应供应商的采购付款详细表
    private void BindGridview2(PMPaymentBillinfo PMPaymentBillinfo)
    {
        Gridview2.DataSource = ppb.SelectPMPaymentIDetail(PMPaymentBillinfo);
        Gridview2.DataBind();
    }
    ////没有结款的采购订单
    //private void BindGridview5(PMPaymentBillinfo PMPaymentBillinfo)
    //{
    //    this.Gridview5.DataSource = ppb.SelectPMPurchaseOrder_NBill(PMPaymentBillinfo);
    //    this.Gridview5.DataBind();
    //}
    //供应商付款开票表
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        if (e.CommandName == "Paid")//付款详细
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            PMPaymentBillinfo.PMPB_ID = new Guid(e.CommandArgument.ToString());
            label_PayBillID.Text = e.CommandArgument.ToString();
            label_SupplyID.Text = Gridview1.DataKeys[row.RowIndex]["PMSI_ID"].ToString();
            BindGridview2(PMPaymentBillinfo);
            label5.Text = Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString();
            Panel_Pay.Visible = true;
            UpdatePanel_Pay.Update();
        }
        //if (e.CommandName == "Payment")//付款
        //{
        //    GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        //    Gridview1.SelectedIndex = row.RowIndex;
        //    this.label_SupplyID.Text = this.Gridview1.DataKeys[row.RowIndex]["PMSI_ID"].ToString();
        //    this.label_PayBillID.Text = e.CommandArgument.ToString();
        //    this.label7.Text = this.Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString();
        //    this.label_Pay.Text = "新增";
        //    this.TextBox3.Enabled = true;
        //    PMPaymentBillinfo.PMSI_ID = new Guid(this.label_SupplyID.Text.ToString());
        //    BindGridview5(PMPaymentBillinfo);
        //    this.Panel_NewPay.Visible = true;
        //    this.UpdatePanel_NewPay.Update();
        //}
       
        
    }

    //采购订单详细表
    private void BindGridview2(PMPurchaseOrderinfo PMPurchaseOrderinfo)
    {
        Gridview2.DataSource = pl.SelectPMPurchaseOrderDetail_look(PMPurchaseOrderinfo);
        Gridview2.DataBind();
    }
   
    //关闭付款详细表
    protected void Button_CPay(object sender, EventArgs e)
    {
        Panel_Pay.Visible = false;
        UpdatePanel_Pay.Update();
    }
    //付款详细表
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Morise")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_PayID.Text = e.CommandArgument.ToString();
            label_Pay.Text = "修改";
            TextBox3.Enabled = false;
            TextBox3.Text = Gridview2.Rows[row.RowIndex].Cells[1].Text.ToString();
            label_PayMoney.Text = TextBox3.Text;
            DropDownList1.SelectedValue = Gridview2.Rows[row.RowIndex].Cells[2].Text.ToString();
            TextBox5.Text = Gridview2.Rows[row.RowIndex].Cells[3].Text.ToString();
            //PMPaymentBillinfo.PMSI_ID = new Guid(this.label_SupplyID.Text.ToString());
            //BindGridview5(PMPaymentBillinfo);
            Panel_NewPay.Visible = true;
            UpdatePanel_NewPay.Update();
        }
    }
    //提交付款
    protected void Button_Kity(object sender, EventArgs e)
    {
        if (TextBox3.Text != "")
        {
            PMPaymentBillinfo.PMPD_Pay = Convert.ToDecimal(TextBox3.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewPay, GetType(), "alert", "alert('请填写付款金额！')", true);
            return;
        }
        if (DropDownList1.SelectedValue != "请选择")
        {
            PMPaymentBillinfo.PMPD_PayWay = DropDownList1.SelectedValue.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewPay, GetType(), "alert", "alert('请选择付款方式！')", true);
            return;
        }
        if (TextBox5.Text != "")
        {
            PMPaymentBillinfo.PMPD_PayTime = Convert.ToDateTime(TextBox5.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewPay, GetType(), "alert", "alert('请填写付款日期！')", true);
            return;
        }


        bool temp = false;
        Decimal dl = 0;

        Decimal dml = Convert.ToDecimal(TextBox3.Text.ToString());
        //foreach (GridViewRow item in Gridview5.Rows)
        //{
            //CheckBox rb = item.FindControl("CheckBoxMarry") as CheckBox;
            //if (rb.Checked)
            //{
                dl = Convert.ToDecimal(Gridview7.Rows[Gridview7.SelectedIndex].Cells[6].Text.ToString());
                temp = true;

                if (dml == dl)//金额相等
                {
                    label_PurchaseOrderID.Text = Gridview7.DataKeys[Gridview7.SelectedIndex].Value.ToString();
                    PMPaymentBillinfo.PMPO_PurchaseOrderID = new Guid(label_PurchaseOrderID.Text);
                    PMPaymentBillinfo.PMPO_AlreadyPay = "是";
                    PMPaymentBillinfo.PMPO_ResidueMoney = 0;
                    ppb.UpdatePMPO_AlreadyPay(PMPaymentBillinfo);
                }
                if (dml < dl)//付款金额小于勾选订单的剩余付款
                {
                    label_PurchaseOrderID.Text = Gridview7.DataKeys[Gridview7.SelectedIndex].Value.ToString();
                    PMPaymentBillinfo.PMPO_PurchaseOrderID = new Guid(label_PurchaseOrderID.Text);
                    PMPaymentBillinfo.PMPO_AlreadyPay = "否";
                    PMPaymentBillinfo.PMPO_ResidueMoney = dl - dml;
                    ppb.UpdatePMPO_AlreadyPay(PMPaymentBillinfo);
                }
                if (dml > dl)//付款金额大于采购订单的剩余付款
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('付款金额大于采购订单剩余付款金额！')", true);
                    return;
                }
                //dml = dml - dl;
            //}
        //}
        string stg="and PMPO_PurchaseOrderID='"+new Guid(Gridview7.DataKeys[Gridview7.SelectedIndex].Value.ToString())+"'";
        DataSet dss = ppb.SelectPMPurchaseOrder(stg);
        DataTable dtt = dss.Tables[0];
        if(dtt.Rows.Count>0)
        {
            label_SupplyID.Text = dtt.Rows[0][1].ToString();
        }
        string condition = "and PMPaymentBill.PMSI_ID='" + new Guid(label_SupplyID.Text) + "'";
                DataSet ds = ppb.SelectPMPaymentBill(condition);
                DataTable dt = ds.Tables[0];
        if(dt.Rows.Count>0)
        {
            label_PayBillID.Text = dt.Rows[0][0].ToString();
        }

        PMPaymentBillinfo.PMPB_ID = new Guid(label_PayBillID.Text);
        if (label_Pay.Text == "新增")
        {
            //if (!temp)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_NewPay, this.GetType(), "aa", "alert('请选择采购订单')", true);
            //    return;
            //}
            //else
            //{
                ppb.UpdatePMPaymentBill_Payment(PMPaymentBillinfo);
                PMPaymentBillinfo.PMPD_Man = Session["UserName"].ToString();
                ppb.InsertPMPaymentIDetail(PMPaymentBillinfo);
            //}
        }
        if (label_Pay.Text == "修改")
        {
            PMPaymentBillinfo.PMPD_ID = new Guid(label_PayID.Text);
           
            PMPaymentBillinfo.PMPB_ID = new Guid(label_PayBillID.Text);
            BindGridview2(PMPaymentBillinfo);
            UpdatePanel_Pay.Update();
            PMPaymentBillinfo.PMPD_Pay = Convert.ToDecimal(Convert.ToDecimal(TextBox3.Text.ToString()) - Convert.ToDecimal(label_PayMoney.Text));
            ppb.UpdatePMPaymentIDetail(PMPaymentBillinfo);
        }

        TextBox3.Text = "";
        DropDownList1.SelectedValue = "请选择";
        TextBox5.Text = "";
        Panel_NewPay.Visible = false;
        UpdatePanel_NewPay.Update();
        BindGridview1("");
        UpdatePanel_PayBill.Update();
        BindGridview7("");
        UpdatePanel3.Update();
    }
    //取消付款
    protected void Button_Sena(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        DropDownList1.SelectedValue = "请选择";
        TextBox5.Text = "";
        Panel_NewPay.Visible = false;
        UpdatePanel_NewPay.Update();
    }

    #region//换页
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
        string condition = Getcondition();
        BindGridview1(condition);
        Gridview1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }

    protected void Gridview_PMSupply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_PMSupply.BottomPagerRow;


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
        BindGridview_PMSupply("");
       
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PMSupply.PageCount ? Gridview_PMSupply.PageCount - 1 : newPageIndex;
        Gridview_PMSupply.PageIndex = newPageIndex;
        Gridview_PMSupply.DataBind();
    }
    protected void Gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        PMPaymentBillinfo.PMPB_ID = new Guid(label_PayBillID.Text);
        BindGridview2(PMPaymentBillinfo);
        Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }

    protected void Gridview7_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview7.BottomPagerRow;


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
       
        BindGridview7("");
        Gridview7.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview7.PageCount ? Gridview7.PageCount - 1 : newPageIndex;
        Gridview7.PageIndex = newPageIndex;
        Gridview7.DataBind();
    }
    #endregion
    //互斥
    protected void Gridview_PMSupply_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge(this)");
            }
        }
    }

    protected void Gridview_PMSupply_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge(this)");
            }

        }
    }

    //检索供应商
    protected void Button1_KiMi(object sender, EventArgs e)
    {
        string condition = GetCondition_Supply();
        BindGridview_PMSupply(condition);
        UpdatePanel_Supply.Update();
    }
    protected string GetCondition_Supply()
    {
        string condition;
        string item = "";
        if (TextBox4.Text != "")
        {
            item += " and PMSI_SupplyNum='" + TextBox4.Text + "'";
        }
        if (TextBox9.Text != "")
        {
            item += " and PMSI_SupplyName like'%" + TextBox9.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索供应商
    protected void Button_CoMi(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox9.Text = "";
        BindGridview_PMSupply("");
        UpdatePanel_Supply.Update();
    }
    protected void Gridview1_DataBound(object sender, EventArgs e)
    {
         for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void  Gridview_PMSupply_DataBound(object sender, EventArgs e)
{
         for (int i = 0; i < Gridview_PMSupply.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_PMSupply.Rows[i].Cells.Count; j++)
            {
                Gridview_PMSupply.Rows[i].Cells[j].ToolTip = Gridview_PMSupply.Rows[i].Cells[j].Text;
                if (Gridview_PMSupply.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_PMSupply.Rows[i].Cells[j].Text = Gridview_PMSupply.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }

    protected void Gridview2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview2.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview2.Rows[i].Cells.Count; j++)
            {
                Gridview2.Rows[i].Cells[j].ToolTip = Gridview2.Rows[i].Cells[j].Text;
                if (Gridview2.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview2.Rows[i].Cells[j].Text = Gridview2.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }

    protected void Gridview7_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview7.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview7.Rows[i].Cells.Count; j++)
            {
                Gridview7.Rows[i].Cells[j].ToolTip = Gridview7.Rows[i].Cells[j].Text;
                if (Gridview7.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview7.Rows[i].Cells[j].Text = Gridview7.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    //付款
    protected void Button_Pay(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        UpdatePanel2.Update();

        BindGridview7("");

        Panel3.Visible = true;
        UpdatePanel3.Update();
    }
    //采购订单表
    private void BindGridview7(string condition)
    {
        Gridview7.DataSource = ppb.SelectPMPurchaseOrder(condition);
        Gridview7.DataBind();
    }

    protected void Button_Search(object sender, EventArgs e)
    {
         string condition="";
        if(TextBox11.Text!="")
        {
            condition += " and PMPO_PurchaseOrderNum='" + TextBox11.Text.ToString() + "'"; 
        }
        BindGridview7(condition);
        Panel3.Visible = true;
        UpdatePanel3.Update();
    }
    protected void Button_Cl(object sender, EventArgs e)
    {
        TextBox11.Text = "";
        Panel2.Visible = false ;
        UpdatePanel2.Update();
        Panel3.Visible = false ;
        UpdatePanel3.Update();
    }
    protected void Gridview7_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Foin")//付款
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview7.SelectedIndex = row.RowIndex;
            label_PurchaseOrderID.Text = e.CommandArgument.ToString();
            label7.Text = Gridview7.Rows[row.RowIndex].Cells[1].Text.ToString() +"付款";
            Panel_NewPay.Visible = true;
            UpdatePanel_NewPay.Update();
        }
    }
    protected void Button_Ret(object sender, EventArgs e)
    {
        TextBox11.Text = "";
        BindGridview7("");
        Panel3.Visible = true;
        UpdatePanel3.Update();

    }
}