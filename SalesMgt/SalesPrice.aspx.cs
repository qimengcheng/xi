using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class SalesMgt_SalesPrice : Page
{
    
    SalesAfterD st = new SalesAfterD();
    SalesPriceD sp = new SalesPriceD();
    ProTypePrice pt1 = new ProTypePrice();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            
            BindJiageZhangqi();
            BindApply();
            BindPT();
           
        }
        #region 权限
        if (Request.QueryString["status"] == "SalesPriceLook")//价格账期查看
        {
            Title = "价格账期查看";
            Button8.Visible = false;

            Gridview_JiaZhang.Columns[10].Visible = false;
            Gridview_JiaZhang.Columns[9].Visible = false;
            UpdatePanel_JiaZhang.Update();


        }
        if (Request.QueryString["status"] == "SalesPriceEdit")//价格账期维护
        {
            Title = "价格账期维护";
            Button8.Visible = true;
            Gridview_JiaZhang.Columns[10].Visible = true;
            Gridview_JiaZhang.Columns[9].Visible = true;
            UpdatePanel_JiaZhang.Update();


        }
        if (Request.QueryString["status"] == "SalesPriceApplyEdit")//价格账期申请维护
        {
            //Title = "价格账期申请维护";
         
            //Button26.Visible = false;
            //Button8.Visible = false;
            //Panel5.Visible = true;
            //UpdatePanel4.Update();
            //Panel__JiaZhang.Visible = true;
            //UpdatePanel_JiaZhang.Update();
            //Panel_Apply.Visible = true;
            //UpdatePanel_Apply.Update();
            //Panel4.Visible = true;
            //UpdatePanel3.Update();
            //Gridview_JiaZhang.Columns[9].Visible = true;
            //Gridview_JiaZhang.Columns[10].Visible = false;
            //UpdatePanel_JiaZhang.Update();
            ////Gridview_Apply.Columns[12].Visible = true;
            ////Gridview_Apply.Columns[13].Visible = false;
            ////Gridview_Apply.Columns[14].Visible = true;
            //UpdatePanel_Apply.Update();
            //Panel5.Visible = false;
            //UpdatePanel4.Update();
            //Panel__JiaZhang.Visible = false;
            //UpdatePanel_JiaZhang.Update();
            Title = "价格账期申请审批";
            label24.Text = " and CRMCPCA_State like'%待审批%'";
            BindApply();
            Panel5.Visible = false;
            UpdatePanel4.Update();
            Panel__JiaZhang.Visible = false;
            UpdatePanel_JiaZhang.Update();
            Gridview_Apply.Columns[15].Visible = false;
            Gridview_Apply.Columns[16].Visible = true;
            //Gridview_Apply.Columns[14].Visible = false;
            UpdatePanel_Apply.Update();
            Panel4.Visible = true;
            UpdatePanel3.Update();
            Panel_Apply.Visible = true;
            UpdatePanel_Apply.Update();
        }
        if (Request.QueryString["status"] == "SalesPriceApplyLook")//价格账期申请查看
        {
            Button26.Visible = false;
            UpdatePanel3.Update();
            Title = "价格账期申请查看";
            Panel5.Visible = false;
            UpdatePanel4.Update();
            Panel__JiaZhang.Visible = false;
            UpdatePanel_JiaZhang.Update();
            Gridview_Apply.Columns[15].Visible = false;
            Gridview_Apply.Columns[16].Visible = false;
            UpdatePanel_Apply.Update();
            Panel4.Visible = true;
            UpdatePanel3.Update();
            Panel_Apply.Visible = true;
            UpdatePanel_Apply.Update();

        }
        if (Request.QueryString["status"] == "SalesPriceApplyCheck")//价格账期申请审核
        {
            Title = "价格账期申请审核";
            label24.Text = " and CRMCPCA_State like'%已提交%'";
            BindApply();
            Panel5.Visible = false;
            UpdatePanel4.Update();
            Panel__JiaZhang.Visible = false;
            UpdatePanel_JiaZhang.Update();
            Gridview_Apply.Columns[15].Visible = true;
            Gridview_Apply.Columns[16].Visible = false;
            //Gridview_Apply.Columns[14].Visible = false;
            UpdatePanel_Apply.Update();
            Panel4.Visible = true;
            UpdatePanel3.Update();
            Panel_Apply.Visible = true;
            UpdatePanel_Apply.Update();
        }

        #endregion
    }
    #region 价格账期主表
    //绑定价格账期表
    protected void BindJiageZhangqi()
    {
        Gridview_JiaZhang.DataSource = sp.Select_JiageZhangqi(label19.Text.ToString());
        Gridview_JiaZhang.DataBind();
        UpdatePanel_JiaZhang.Update();
    }
    //
    public string GetCondition_JiaZhang()
    {
        string conditon;
        string temp = "";
        if (TextBox13.Text != "")
        {
            temp += " and CRMCIF_Name like'%" + TextBox13.Text.ToString().Trim() + "%'";
        }
        if (TextBox14.Text != "")
        {
            temp += " and PT_Name like'%" + TextBox14.Text.ToString().Trim() + "%'";
        }
        if (TextBox17.Text != "")
        {
            temp += " and CRMCPM_PaymentDay like'%" + TextBox17.Text.ToString().Trim() + "%'";
        }
        conditon = temp;
        label19.Text = conditon;
        return conditon;
    }
    //检索价格账期
    protected void SearchJiaZhang(object sender, EventArgs e)
    {
        GetCondition_JiaZhang();
        BindJiageZhangqi();
    }
    //新建价格账期
    protected void NewJiaZhang(object sender, EventArgs e)
    {
        Panel_NewJiazhagn.Visible = true;
        UpdatePanel_NewJiazhagn.Update();
    }
    protected void Gridview_JiaZhang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_JiaZhang.BottomPagerRow;


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
        BindJiageZhangqi();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_JiaZhang.PageCount ? Gridview_JiaZhang.PageCount - 1 : newPageIndex;
        Gridview_JiaZhang.PageIndex = newPageIndex;
        Gridview_JiaZhang.DataBind();
    }
    protected void Gridview_JiaZhang_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Apply1")
        {
            Label3.Text = e.CommandArgument.ToString();
            Panel1.Visible = true;
            UpdatePanel1.Update();
            Label7.Text = "修改";
            TextBox4.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[5].Text.ToString();
            TextBox3.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[6].Text.ToString();
            label8.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "-" + Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[3].Text.ToString(); ;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "Delete1")
        { 
            sp.Delete_JiageZhangqi(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindJiageZhangqi();
        }
        if (e.CommandName == "ChangeHistory")
        {
            Panel2.Visible = true;
            label9.Text = e.CommandArgument.ToString();
            BindChangeHistory();
        }
    }
    //确认提交新价格账期
    protected void ConfirmNewJiaZhang(object sender, EventArgs e)
    {
        if (label35.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择客户！')", true);
            return;
        }
        if (label44.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择产品型号！')", true);
            return;
        }
        if (TextBox20.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写账期！')", true);
            return;
        }
        if (TextBox2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写单价！')", true);
            return;
        }
        
        Guid cID = new Guid(label35.Text.ToString());
        Guid pID = new Guid(label44.Text.ToString());
        DataSet ds= pt1.Select_SameCustomPTPrice(cID, pID);
        DataTable dt = ds.Tables[0];
        int count111=Convert.ToInt32( dt.Rows[0][0].ToString());
        if(count111!=0)
        {
          ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('不可以重复新建同一客户的同一产品的价格账期！')", true);
            return;
        }
        int day = Convert.ToInt32(TextBox20.Text.ToString());
        decimal price = Convert.ToDecimal(TextBox2.Text.ToString());
        string man = Session["UserName"].ToString().Trim();
        sp.Update_TousuSort(cID, pID, price, day, man);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        Panel_NewJiazhagn.Visible = false;
        UpdatePanel_NewJiazhagn.Update();
        BindJiageZhangqi();
    }
    //关闭新价格账期
    protected void CloseNewJiaZhang(object sender, EventArgs e)
    {
        Panel_NewJiazhagn.Visible = false;
        UpdatePanel_NewJiazhagn.Update();

    }
    #endregion
    #region 客户
    //open选择客户
    protected void SearchCustom1(object sender, EventArgs e)
    {
        Panel1_SearchCus.Visible = true;
        UpdatePanel_SearchCus.Update();
        Panel1_Custom.Visible = true;
        Gridview2.DataSource = st.Select_Kehu("");
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
    }
    //检索客户
    protected void SearchCustomer(object sender, EventArgs e)
    {
        if (TextBox6.Text != "")
        {
            label41.Text = " and CRMCIF_Name like'%" + TextBox6.Text.ToString().Trim() + "%'";
        }
        Gridview2.DataSource = st.Select_Kehu(label41.Text.ToString());
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
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
            label35.Text = id;
            TextBox16.Text = Gridview2.Rows[gvr.RowIndex].Cells[1].Text.ToString().Trim().Replace("&nbsp;", "");
            UpdatePanel_NewJiazhagn.Update();
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


        Gridview2.DataSource = st.Select_Kehu(label41.Text.ToString());
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    #endregion
    #region 产品
    //open选择产品
    protected void SearchPT(object sender, EventArgs e)
    {
        Panel11.Visible = true;
        UpdatePanel10.Update();
        if (TextBox12.Text != "")
        { 
            string temp=" and PT_Name like '%"+TextBox12.Text.ToString()+"%'";
             label16.Text=temp;
        }
        else{
            label16.Text="";
        }
        Panel_PT.Visible = true;
        BindPT();

    }
    protected void SearchPT1(object sender, EventArgs e)
    {
       
        if (TextBox12.Text != "")
        {
            string temp = " and PT_Name like '%" + TextBox12.Text.ToString() + "%'";
            label16.Text = temp;
        }
        else
        {
            label16.Text = "";
        }
        Panel_PT.Visible = true;
        BindPT();

    }
    protected void ClosePT(object sender, EventArgs e)
    {
        Panel11.Visible = false;
        UpdatePanel10.Update();
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
    }
    //绑定产品
    protected void BindPT()
    {
        Gridview_PT.DataSource = sp.Select_PT(label16.Text.ToString());
        Gridview_PT.DataBind();
        UpdatePanel_PT.Update();
    }
    protected void Gridview_PT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_PT.BottomPagerRow;


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
        BindPT();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PT.PageCount ? Gridview_PT.PageCount - 1 : newPageIndex;
        Gridview_PT.PageIndex = newPageIndex;
        Gridview_PT.DataBind();
    }
    protected void Gridview_PT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Check2")
        {
            string id = e.CommandArgument.ToString();
            label44.Text = id;
            TextBox1.Text = Gridview_PT.Rows[gvr.RowIndex].Cells[1].Text.ToString().Trim().Replace("&nbsp;", "");
            UpdatePanel_NewJiazhagn.Update();
            Panel11.Visible = false;
            Panel_PT.Visible = false;
            UpdatePanel10.Update();
            UpdatePanel_PT.Update();
        }
    }
    #endregion
    #region 申请
    //
    protected void NewApplyOK(object sender, EventArgs e)
    {
        Guid id = new Guid(Label3.Text.ToString());  
        if (TextBox3.Text == ""||TextBox4.Text=="")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('必须填写价格和账期！')", true);
            return;
        }
        decimal price = Convert.ToDecimal(TextBox4.Text.ToString().Trim());
        int day = Convert.ToInt32(TextBox3.Text.ToString().Trim());
        string man = Session["UserName"].ToString().Trim();
        string reason = TextBox5.Text.ToString();
        if (Label7.Text == "修改")
        {
           
            //int ds = Convert.ToInt32( sp.Update_CRMCustormerPaymentMain(id, price, day, man, reason));
            //if (ds == 1)//审核修改
            //{
                sp.Insert_Apply(id, price, day, man, reason);
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('系统已经为你自动提交价格账期修改申请单,如果低于产品底价将需要总经理审批，如果不低于产品底价，只需要部门主管审核即可！')", true);
                string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了" + label8.Text.ToString() + "的价格账期修改申请！";
                string sErr = RTXhelper.Send(remind, "价格账期申请审核");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
               
            //}

            //else if (ds == 0)//直接修改
            //{
            //  //Update_CRMCustormerPaymentMain
            //    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('修改成功')", true);

            //}
            BindApply();
            Panel1.Visible = false;
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            UpdatePanel1.Update();
        }
        //else if(Label7.Text=="编辑")
        //{
        //   sp.Update_Apply(id, price, day, reason);
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('修改成功')", true);
        //}
        if (label9.Text != "")
        {
            BindChangeHistory();
        }
        BindJiageZhangqi();
    }
    protected void BindChangeHistory()
    {

        Gridview1.DataSource = sp.Select_Histor(new Guid(label9.Text));
        Gridview1.DataBind();
        UpdatePanel2.Update();
    }
    protected void CloseHistory(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void NewApplyCanel(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        UpdatePanel1.Update();
    }
    public string GetCondition_Apply()
    {
        string conditon;
        string temp = "";
        if (TextBox28.Text != "")
        {
            temp += " and CRMCIF_Name like'%" + TextBox28.Text.ToString().Trim() + "%'";
        }
        if (TextBox29.Text != "")
        {
            temp += " and PT_Name like'%" + TextBox29.Text.ToString().Trim() + "%'";
        }
        if (TextBox30.Text != "")
        {
            temp += " and CRMCPCA_ApplyManName like'%" + TextBox30.Text.ToString().Trim() + "%'";
        }
        if (DropDownList1.SelectedValue != "选择状态")
        {
            temp += " and CRMCPCA_State like'%" + DropDownList1.SelectedValue.Trim() + "%'";
        }
        conditon = temp;
        label24.Text = conditon;
        return conditon;
    }
    //band
    protected void BindApply()
    {
        Gridview_Apply.DataSource = sp.Select_Apply(label24.Text.ToString());
        Gridview_Apply.DataBind();
        UpdatePanel_Apply.Update();
    }
    //
    protected void SearchApply(object sender, EventArgs e)
    {
        GetCondition_Apply();
        BindApply();

    }
    protected void CloseApply(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel_Apply.Visible = false;
        UpdatePanel_Apply.Update();

    }
    protected void Gridview_Apply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Apply.BottomPagerRow;


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
        newPageIndex = newPageIndex >= Gridview_Apply.PageCount ? Gridview_Apply.PageCount - 1 : newPageIndex;
        Gridview_Apply.PageIndex = newPageIndex;
        Gridview_Apply.DataBind();
    }
    protected void Gridview_Apply_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Edit2")
        {
            Label7.Text = "编辑";
            Panel1.Visible = true;
            TextBox4.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            TextBox3.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[4].Text.ToString();
            TextBox5.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[5].Text.ToString();
            label8.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[1].Text.ToString() + "-" + Gridview_Apply.Rows[gvr.RowIndex].Cells[2].Text.ToString(); ;
            UpdatePanel1.Update();
  
        }
        if (e.CommandName == "Check2")
        {
            TextBox_AddMan.Text = Session["UserName"].ToString().Trim();
            TextBox_Addtime.Text = DateTime.Now.ToShortDateString();
            Panel_ADDCheck.Visible = true;
            Label33.Text = e.CommandArgument.ToString();
            Label11.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[1].Text.ToString() +" 客户关于："+ Gridview_Apply.Rows[gvr.RowIndex].Cells[2].Text.ToString()+"的价格账期修改申请";
            UpdatePanel_ADDCheck.Update();
        }
        if (e.CommandName == "Delete2")
        {
            sp.Delete_Apply(new Guid(e.CommandArgument.ToString()));
            BindApply();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);

        }
        if (e.CommandName == "shenpi")
        {
            Label13.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[1].Text.ToString() + " 客户关于：" + Gridview_Apply.Rows[gvr.RowIndex].Cells[2].Text.ToString() + "的价格账期修改申请";
            Label10.Text = e.CommandArgument.ToString();
            TextBox7.Text = Session["UserName"].ToString();
            TextBox8.Text = DateTime.Now.ToShortDateString();
            Panel3.Visible = true;
            UpdatePanel5.Update();

        }

    }
    protected void Gridview_Apply_DataBound(object sender, EventArgs e)
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
    protected void Gridview_Apply_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["CRMCPCA_State"].ToString().Trim() != "已提交" )
            {
                e.Row.Cells[12].Enabled = false;
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[14].Enabled = false;
            }
            if (drv["CRMCPCA_ApplyManName"].ToString().Trim() != Session["UserName"].ToString().Trim())
            {
                e.Row.Cells[12].Enabled = false;
                e.Row.Cells[14].Enabled = false;
            }
        }
    }
    protected void  Gridview_JiaZhang_DataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < Gridview_JiaZhang.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_JiaZhang.Rows[i].Cells.Count; j++)
            {
                Gridview_JiaZhang.Rows[i].Cells[j].ToolTip = Gridview_JiaZhang.Rows[i].Cells[j].Text;
                if (Gridview_JiaZhang.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_JiaZhang.Rows[i].Cells[j].Text = Gridview_JiaZhang.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    #endregion
    #region Chekc
        protected void  Check_OK(object sender, EventArgs e)
    {
        string man=Session["UserName"].ToString().Trim();
        string result="审核通过";
        string op=TextBox_AddOpinion.Text.ToString();
        Guid id=new Guid(Label33.Text.ToString());
      int count= sp.Update_Apply_Check(id,result,op,man);
      if (count == 0)//待审批
      {
          ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过，因为价格低于产品底价所以还需总经理审批！')", true);
          string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了" + Label11.Text.ToString() + "的价格账期修改申请，请你对状态为 待审批 的申请进行审批！";
          string sErr = RTXhelper.Send(remind, "价格账期申请审批");
          if (!string.IsNullOrEmpty(sErr))
          {
              ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
          }
      }
      else
      {
          ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过,价格账期已经修改！')", true);
          string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了" + Label11.Text.ToString() + "的价格账期修改申请，相关客户价格账期已经修改成功！";
          string sErr = RTXhelper.Send(remind, "价格账期维护");
          if (!string.IsNullOrEmpty(sErr))
          {
              ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
          }
      }
        Panel_ADDCheck.Visible=false;
        UpdatePanel_ADDCheck.Update();
        BindApply();
    }
    protected void  Check_NotOK(object sender, EventArgs e)
    {
        if(TextBox_AddOpinion.Text=="")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回时必须填写意见！')", true);
            return;
        }
         string man=Session["UserName"].ToString().Trim();
        string result="审核驳回";
        string op=TextBox_AddOpinion.Text.ToString();
        Guid id=new Guid(Label33.Text.ToString());
        sp.Update_Apply_Check(id,result,op,man);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已审核驳回！')", true);
        Panel_ADDCheck.Visible=false;
        UpdatePanel_ADDCheck.Update();
        BindApply();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核驳回了" + Label11.Text.ToString() + "的价格账期修改申请，请知悉！";
        string sErr = RTXhelper.Send(remind, "价格账期维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void  Check_Canel(object sender, EventArgs e)
    {
        Panel_ADDCheck.Visible=false;
        UpdatePanel_ADDCheck.Update();
    }
    #endregion





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
        BindChangeHistory();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    protected void Gridview1_DataBound(object sender, GridViewRowEventArgs e)
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
    protected void Check_OK1(object sender, EventArgs e)
    {
        Guid id = new Guid(Label10.Text.ToString());
        string man = Session["UserName"].ToString();
        string op = TextBox9.Text.ToString();
        string result = "审批通过";
        sp.Update_Apply_C(id, result, op, man);
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批通过了" +Label13.Text.ToString() + "的价格账期修改申请！";
        string sErr = RTXhelper.Send(remind, "价格账期维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        Panel3.Visible = false;
        UpdatePanel5.Update();
        BindApply();
    }
    protected void Check_NotOK1(object sender, EventArgs e)
    {
        if (TextBox9.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回时必须填写驳回意见！')", true);
            return;
        }
        Guid id = new Guid(Label10.Text.ToString());
        string man = Session["UserName"].ToString();
        string op = TextBox9.Text.ToString();
        string result = "审批驳回";
        sp.Update_Apply_C(id, result, op, man);
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批驳回了" + Label13.Text.ToString() + "的价格账期修改申请！";
        string sErr = RTXhelper.Send(remind, "价格账期申请维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        Panel3.Visible = false;
        UpdatePanel5.Update();
        BindApply();
    }
    protected void Check_Canel1(object sender, EventArgs e)
    {
        TextBox9.Text = "";
        Panel3.Visible = false;
        UpdatePanel5.Update();
    }
    protected void Gridview_JiaZhang_DataBound1(object sender, EventArgs e)
    {

        for (int i = 0; i < Gridview_JiaZhang.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_JiaZhang.Rows[i].Cells.Count; j++)
            {
                Gridview_JiaZhang.Rows[i].Cells[j].ToolTip = Gridview_JiaZhang.Rows[i].Cells[j].Text;
                if (Gridview_JiaZhang.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_JiaZhang.Rows[i].Cells[j].Text = Gridview_JiaZhang.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview1_DataBound1(object sender, EventArgs e)
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