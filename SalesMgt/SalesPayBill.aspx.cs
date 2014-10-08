using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesMgt_SalesPayBill : Page
{
    
    SalesAfterD st = new SalesAfterD();
    SalesPayBillD sp = new SalesPayBillD();
    SalesPriceD sprice = new SalesPriceD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            label19.Text = "";
            Gridview_Main.Columns[13].Visible = false;
            Gridview_Main.Columns[14].Visible = false;
            Gridview_Main.Columns[15].Visible = false;
            Gridview_Main.Columns[16].Visible = false;
            Gridview_Main.Columns[17].Visible = false;
            UpdatePanel_Main.Update();
        //要开票的     label19.Text = " and SMOD_BillOver='否'";

      //      要付款的
               // label19.Text=" and isnull(totalmoney,0)>isnull(SMOD_PayMoney,0)"
            
        }
        //#region 权限
        //if (Request.QueryString["status"] == "SalesPayBillLook")//销售回款开票查看
        //{
        //    this.Title = "销售回款开票查看";
        //    this.Button1.Visible = false;
        //    this.Button3.Visible = false;
        //    this.Button5.Visible = false;
        //    this.UpdatePanel_SearchMain.Update();


        //}
        //if (Request.QueryString["status"] == "SalesPayBillEdit")//销售回款开票维护
        //{
        //    this.Title = "销售回款开票维护";
        //    this.Button1.Visible = true;
        //    this.Button3.Visible = true;
        //    this.Button5.Visible = true;
        //    this.UpdatePanel_SearchMain.Update();

        //    this.UpdatePanel_Main.Update();
        //    this.Gridview_Apply.Columns[5].Visible = true;
        //    this.Gridview_Apply.Columns[6].Visible = true;
        //    this.UpdatePanel_Pay.Update();
        //    this.Gridview_Bill.Columns[10].Visible = true;
        //    this.Gridview_Bill.Columns[11].Visible = true;
        //    this.UpdatePanel_Bill.Update();

        //}
        //if (Request.QueryString["status"] == "SalesPayBillAdmin")//客户金额维护(总表)
        //{
        //    this.Title = "客户金额维护(总表)";
        //    this.Gridview_Main.Columns[8].Visible = true;
        //    this.UpdatePanel_Main.Update();
        //    this.Button1.Visible = true;
        //    this.Button3.Visible = true;
        //    this.Button5.Visible = true;
        //    this.UpdatePanel_SearchMain.Update();
        //    this.Gridview_Main.Columns[9].Visible = true;
        //    this.UpdatePanel_Main.Update();
        //    this.Gridview_Apply.Columns[5].Visible = true;
        //    this.Gridview_Apply.Columns[6].Visible = true;
        //    this.UpdatePanel_Pay.Update();
        //    this.Gridview_Bill.Columns[10].Visible = true;
        //    this.Gridview_Bill.Columns[11].Visible = true;
        //    this.UpdatePanel_Bill.Update();
        //}

        //#endregion
    }

    
    #region 发货单
    //绑定价格账期表
    protected void BindMain()
    {
        Gridview_Main.DataSource = sp.Select_Main(label19.Text.ToString());
        Gridview_Main.DataBind();
        UpdatePanel_Main.Update();
    }
    //
    public string GetCondition_Main()
    {
        string conditon;
        string temp = "";
        if (TextBox13.Text != "")
        {
            temp += " and CRMCIF_Name like'%" + TextBox13.Text.ToString().Trim() + "%'";
        }
        if (TextBox14.Text != "")
        {
            temp += " and SMCBPM_TotalLoan >'" + TextBox14.Text.ToString().Trim() + "'";
        }
        if (TextBox17.Text != "")
        {
            temp += " and SMCBPM_MaturityLoan >'" + TextBox17.Text.ToString().Trim() + "'";
        }
        if (CheckBox3.Checked)
        {

            temp += "and SMOD_BillOver='否' or SMOD_BillOver is null";
        }
       
        if (CheckBox4.Checked)
        {
            temp += "and isnull(totalmoney,0)>isnull(SMOD_PayMoney,0)";
        }
        conditon = temp;
        label19.Text += conditon;
        return conditon;
    }
   
    protected void Gridview_Main_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Main.BottomPagerRow;


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
        BindDeliver();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Main.PageCount ? Gridview_Main.PageCount - 1 : newPageIndex;
        Gridview_Main.PageIndex = newPageIndex;
        Gridview_Main.DataBind();
    }
    protected void Gridview_Main_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Bill")
        {
            Panel_Bill.Visible = true;
            label31.Text = Gridview_Main.Rows[gvr.RowIndex].Cells[1].Text.ToString()+Gridview_Main.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            Gridview_Bill.DataSource = sp.Select_Bill(new Guid(e.CommandArgument.ToString()));
            Gridview_Bill.DataBind();
            UpdatePanel_Bill.Update();
        }
        if (e.CommandName == "Pay")
        {
            Panel_Pay.Visible = true;
            label30.Text = Gridview_Main.Rows[gvr.RowIndex].Cells[1].Text.ToString() + Gridview_Main.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            Gridview_Apply.DataSource = sp.Select_Pay(new Guid(e.CommandArgument.ToString()));
            Gridview_Apply.DataBind();
            UpdatePanel_Pay.Update();

        }
       
    }
 
   
    #endregion

   
    protected void Gridview_Bill_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Bill.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Bill.Rows[i].Cells.Count; j++)
            {
                Gridview_Bill.Rows[i].Cells[j].ToolTip = Gridview_Bill.Rows[i].Cells[j].Text;
                if (Gridview_Bill.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_Bill.Rows[i].Cells[j].Text = Gridview_Bill.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview_Apply_DataBound1(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Apply.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Apply.Rows[i].Cells.Count; j++)
            {
                Gridview_Apply.Rows[i].Cells[j].ToolTip = Gridview_Apply.Rows[i].Cells[j].Text;
                if (Gridview_Apply.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_Apply.Rows[i].Cells[j].Text = Gridview_Apply.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    //检索
    protected void SearchDeliver(object sender, EventArgs e)
    {
        string condition = "";
        if (TextBox13.Text != "")
        {
            condition += " and CRMCIF_Name like '%" + TextBox13.Text.ToString() + "%'";

        }
        if ((TextBox14.Text != "" && TextBox17.Text == "") || (TextBox17.Text != "" && TextBox14.Text == ""))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写正确时间段！')", true);
            return;
        }
        if (TextBox14.Text != "" && TextBox17.Text != "")
        {
            condition += " and SMOD_Time between '" + TextBox14.Text + "' and '" + TextBox17.Text + "'";
        }
        if (CheckBox3.Checked)
        {

            condition += " and SMOD_BillOver='否' or SMOD_BillOver is null";
        }

        if (CheckBox4.Checked)
        {
            condition += " and isnull(totalmoney,0)>isnull(SMOD_PayMoney,0)";
        }
        label19.Text = condition;
        label37.Text = TextBox13.Text;
        BindDeliver();
    }
    //
    protected void BindDeliver()
    {
        string condition = label19.Text.ToString();
        Gridview_Main.DataSource = sp.Select_Main(condition);
        Gridview_Main.DataBind();
        UpdatePanel_Main.Update();
    }
    //精简
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox5.Checked = false;
        Gridview_Main.Columns[2].Visible = false;
        Gridview_Main.Columns[4].Visible = false;
        Gridview_Main.Columns[8].Visible = false;
        Gridview_Main.Columns[10].Visible = false;
        Gridview_Main.Columns[11].Visible = false;
        Gridview_Main.Columns[12].Visible = false;
        UpdatePanel_Main.Update();
    }
    //完整

    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Gridview_Main.Columns[2].Visible = true;
        Gridview_Main.Columns[4].Visible = true;
        Gridview_Main.Columns[8].Visible = true;
        Gridview_Main.Columns[10].Visible = true;
        Gridview_Main.Columns[11].Visible = true;
        Gridview_Main.Columns[12].Visible = true;
        UpdatePanel_Main.Update();
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox6.Checked == true)
        {
            Gridview_Main.Columns[13].Visible = true;
            Gridview_Main.Columns[14].Visible = true;
            Gridview_Main.Columns[15].Visible = true;
            Gridview_Main.Columns[16].Visible = true;
            Gridview_Main.Columns[17].Visible = true;
        }
        else
        {
            Gridview_Main.Columns[13].Visible = false;
            Gridview_Main.Columns[14].Visible = false;
            Gridview_Main.Columns[15].Visible = false;
            Gridview_Main.Columns[16].Visible = false;
            Gridview_Main.Columns[17].Visible = false;
        }
        UpdatePanel_Main.Update();
    }

    //选择客户按钮
    protected void SearchCustom_Pay(object sender, EventArgs e)
    {
        Panel1_Custom.Visible = true;
        Panel1_SearchCus.Visible = true;
        BindCustom();
        UpdatePanel_Custom.Update();
        UpdatePanel_SearchCus.Update();
    }
    //提交回款
    protected void ConfirmNewPay(object sender, EventArgs e)
    {
        if (label44.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择客户！')", true);
            return;
        
        }
        Guid id = new Guid(label44.Text.ToString());
        if (TextBox2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写回款金额！')", true);
            return;
        }
        decimal money=Convert.ToDecimal( TextBox2.Text.ToString());
     decimal output= sp.Insert_Pay(id, money, TextBox4.Text, Session["UserName"].ToString());
     if (output == 0)
     {
         ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('系统自动付款完成！')", true);
     }
     else
     {
         ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert","alert('系统自动付款完成后，付款后有" + Convert.ToString(output) + "剩余，系统不会记录付款后多余款项，请知悉')", true);
     }
     BindDeliver();
     Panel1.Visible = false;
     UpdatePanel1.Update();
    }
    //关闭提交回款
    protected void CloseNewPay(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        TextBox16.Text = "";
        TextBox2.Text = "";
        TextBox4.Text = "";
        UpdatePanel1.Update();
    }
    #region 客户
   
    //绑定客户
    protected void BindCustom()
    {
        Gridview2.DataSource = st.Select_Kehu(label6.Text.ToString());
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
    }
    //检索客户
    protected void SearchCustomer(object sender, EventArgs e)
    {

        label6.Text = " and CRMCIF_Name like'%" + TextBox6.Text.ToString().Trim() + "%'";

        BindCustom();
    }
    //取消检索客户
    protected void CloseSearchCustomer(object sender, EventArgs e)
    {
        Panel1_SearchCus.Visible = false;
        UpdatePanel_SearchCus.Update();
        Panel1_Custom.Visible = false;
        UpdatePanel_Custom.Update();
    }
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Check2")
        {
            string id = e.CommandArgument.ToString();
            label44.Text = id;
            TextBox16.Text = Gridview2.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            UpdatePanel1.Update();
            Panel1_Custom.Visible = false;
            Panel1_SearchCus.Visible = false;
            UpdatePanel_SearchCus.Update();
            UpdatePanel_Custom.Update();
        }

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


        BindCustom();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    #endregion

    protected void ResetDeliver(object sender, EventArgs e)
    {
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox17.Text = "";
        UpdatePanel_SearchMain.Update();
    }
    protected void ConfirmBill(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString();
        foreach (GridViewRow item in Gridview_Main.Rows)
        {
            //HtmlInputRadioButton cb = item.FindControl("PT_Select") as HtmlInputRadioButton;
            TextBox TPrice = item.FindControl("TextBox3") as TextBox;
            TextBox TMount = item.FindControl("TextBox4") as TextBox;
            TextBox TNum = item.FindControl("TextBox5") as TextBox;
            TextBox TRemark = item.FindControl("TextBox6") as TextBox;
            CheckBox cb = item.FindControl("CheckBox1") as CheckBox;
            string bit;
            if (cb.Checked)
            {
                bit = "是";
            }
            else
            {
                bit = "否";
            }
            if(TPrice.Text!=""&&TNum.Text!=""&&TMount.Text!=""&&TPrice.Text!="&nbsp;"&&TNum.Text!="&nbsp;"&&TMount.Text!="&nbsp;")
            {
                decimal price = Convert.ToDecimal(TPrice.Text);
                decimal mount = Convert.ToDecimal(TMount.Text);
                string num = TNum.Text;
                string remark = TRemark.Text;
                Guid id = new Guid(Gridview_Main.DataKeys[item.RowIndex]["SMOD_ID"].ToString());
                sp.Insert_Bill(id, price, mount, num, remark, man, bit);
            }
        }
        BindDeliver();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('本页填写条件符合要求的发货单已开票成功！')", true);
      
    }
    protected void ResetBill(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gridview_Main.Rows)
        {
            //HtmlInputRadioButton cb = item.FindControl("PT_Select") as HtmlInputRadioButton;
            TextBox TPrice = item.FindControl("TextBox3") as TextBox;
            TextBox TMount = item.FindControl("TextBox4") as TextBox;
            TextBox TNum = item.FindControl("TextBox5") as TextBox;
            TextBox TRemark = item.FindControl("TextBox6") as TextBox;
            CheckBox cb = item.FindControl("CheckBox1") as CheckBox;

            TPrice.Text = "";
            TMount.Text = "";
            TNum.Text = "";
            TRemark.Text = "";
            cb.Checked = false;
           
        }
        UpdatePanel_Main.Update();
    }
    protected void CloseBillDetail(object sender, EventArgs e)
    {
        Panel_Bill.Visible = false;
        UpdatePanel_Bill.Update();
    }
    protected void ClosePayDetail(object sender, EventArgs e)
    {
        Panel_Pay.Visible = false;
        UpdatePanel_Pay.Update();
    }
    protected void OpenNewPay(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        UpdatePanel1.Update();
        BindCustom();
    }
    protected void Gridview_Main_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Main.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Main.Rows[i].Cells.Count; j++)
            {
                Gridview_Main.Rows[i].Cells[j].ToolTip = Gridview_Main.Rows[i].Cells[j].Text;
                if (Gridview_Main.Rows[i].Cells[j].Text.Length > 10)
                {
                    Gridview_Main.Rows[i].Cells[j].Text = Gridview_Main.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                }
            }
        }
    }
}