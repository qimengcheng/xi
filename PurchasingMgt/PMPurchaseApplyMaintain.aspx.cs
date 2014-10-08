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

public partial class ProjectManagement_PMPurchaseApplyMaintain : System.Web.UI.Page
{
    OfficeAppianceD od = new OfficeAppianceD();
    PMPurchaseOrderL pl = new PMPurchaseOrderL();
    PMSupplyMaterialL pll = new PMSupplyMaterialL();
    PMPurchaseOrderinfo PMPurchaseOrderinfo = new PMPurchaseOrderinfo();
    PRMProjectScheduleL prl = new PRMProjectScheduleL();
    PMSupplyInfo_PMSupplyContactL ppl = new PMSupplyInfo_PMSupplyContactL();
    PMPaymentBillL pd = new PMPaymentBillL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!((Session["UserRole"].ToString().Contains("采购申请物料查看")) || (Session["UserRole"].ToString().Contains("采购申请单价填写")) || (Session["UserRole"].ToString().Contains("采购申请执行维护"))))
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!IsPostBack)
        {
            this.Title = "采购申请执行";
            //this.PanelApplyDetailSummary.Visible = true;
            //BindGridview1("");
            //this.UpdatePanelApplyDetailSummary.Update();
            if (Session["UserRole"].ToString().Contains("采购申请物料查看"))
            {
                this.label_Look.Text = "查看物料";
                this.Panel3.Visible = false;
                this.Panel_SupplySearch.Visible = true;
                this.Gridview1.Columns[0].Visible = false;
                this.Gridview1.Columns[11].Visible = false;//单价
                string Condition = GetCondition();
                BindGridview1(Condition);
                this.Button13.Visible = false;
                this.Button14.Visible = false;
                this.Button22.Visible = false;
                this.Button21.Visible = false;
                this.PanelApplyDetailSummary.Visible = true;
                this.UpdatePanelApplyDetailSummary.Update();
                this.Panel_PMPurchaseOrder.Visible = false;
                this.UpdatePanel_PMPurchaseOrder.Update();
            }
            //else
            //{
            //    this.PanelApplyDetailSummary.Visible = false;
            //    this.UpdatePanelApplyDetailSummary.Update();
            //    this.Panel_PMPurchaseOrder.Visible = true;
            //    this.Panel3.Visible = true;
            //    this.Panel_SupplySearch.Visible = false;
            //    BindGridview6();
            //    this.UpdatePanel_PMPurchaseOrder.Update();
            //}
            if (Session["UserRole"].ToString().Contains("采购申请单价填写"))
            {
                this.Gridview6.Columns[17].Visible = false;
                this.Gridview6.Columns[18].Visible = false;
                this.Gridview6.Columns[19].Visible = false;
                this.Gridview1.Columns[0].Visible = false;
                this.Gridview1.Columns[9].Visible = false;
                this.Button13.Visible = false;
                this.Button21.Visible = false;
                this.Panel3.Visible = true;
                this.Panel_SupplySearch.Visible = false;
                this.Button14.Visible = false;
                BindGridview6();
                this.PanelApplyDetailSummary.Visible = false;
                this.UpdatePanelApplyDetailSummary.Update();
                this.Panel_PMPurchaseOrder.Visible = true;
                this.UpdatePanel_PMPurchaseOrder.Update();
                this.Panel_PMPurchaseOrderDetail.Visible = false;
                this.UpdatePanel_PMPurchaseOrderDetail.Update();
            }
            if (Session["UserRole"].ToString().Contains("采购申请执行维护"))
            {

                this.Gridview6.Columns[17].Visible = true;
                this.Gridview6.Columns[18].Visible = true;
                this.Gridview6.Columns[19].Visible = true;
                this.Gridview1.Columns[0].Visible = true;
                this.Gridview1.Columns[9].Visible = true;
                this.Button13.Visible = true;
                this.Button21.Visible = true;
                this.Button14.Visible = true;
                this.Panel3.Visible = true;
                this.Panel_SupplySearch.Visible = false;
                this.Gridview1.Columns[11].Visible = false;
                BindGridview6();
                this.PanelApplyDetailSummary.Visible = false;
                this.UpdatePanelApplyDetailSummary.Update();
                this.Panel_PMPurchaseOrder.Visible = true;
                this.UpdatePanel_PMPurchaseOrder.Update();
            }
        }
    }
    //绑定申请单内容汇总查询结果表
    private void BindGridview1(string Condition)
    {
        this.Gridview1.DataSource = pl.SelectPMPurchaseApplySummary(Condition);
        this.Gridview1.DataBind();
    }

    //选择物料
    protected void Button_Select1(object sender, EventArgs e)
    {
        this.Panel_Material.Visible = true;
        BindGridview5("");
        this.UpdatePanel_Material.Update();
    }
    //绑定物料表
    private void BindGridview5(string condition)
    {
        this.Gridview5.DataSource = pll.SelectPMPurchaseSMaterial(condition);
        this.Gridview5.DataBind();
    }
    protected void Gridview5_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge1(this)");
            }
        }
    }
    #region  //检索
    protected void Button_Sh1(object sender, EventArgs e)
    {
        string Condition = GetCondition();
        BindGridview1(Condition);
        this.PanelApplyDetailSummary.Visible = true;
        this.UpdatePanelApplyDetailSummary.Update();
       
        this.Panel1.Visible = false;
        this.UpdatePanel1.Update();
        this.Panel_Organization.Visible = false;
        this.UpdatePanel_Organization.Update();
        this.Panel_PMPurchaseApplyMain.Visible = false;
        this.UpdatePanel_PMPurchaseApplyMain.Update();
        this.Panel_ApplyDetail.Visible = false;
        this.UpdatePanel_ApplyDetail.Update();
        //this.Panel_PMPurchaseOrder.Visible = false;
        //this.UpdatePanel_PMPurchaseOrder.Update();
        this.Panel_PMPurchaseOrderDetail.Visible = false;
        this.UpdatePanel_PMPurchaseOrderDetail.Update();
        this.Panel2.Visible = false;
        this.UpdatePanel2.Update();
        this.Panel_Supply.Visible = false;
        this.UpdatePanel_Supply.Update();
    }
    protected string GetCondition()
    {
        string Condition;
        string item = "";
        if (this.TextBox2.Text != "")
        {
            item += " and IMMBD_MaterialName like '%" + this.TextBox2.Text.ToString() + "%'";
        }
        if (this.DropDownList2.SelectedValue.ToString() != "")
        {
            item += " and IMMT_MaterialType='" + this.DropDownList2.SelectedValue.ToString() + "'";
        }
        if (this.TextBox1.Text != "")
        {
            item += " and IMMBD_SpecificationModel like '%" + this.TextBox1.Text.ToString() + "%'";
        }
        if(this.DropDownList3.SelectedValue!="请选择")
        {
            item += " and PMPAM_EmergencyPur='" + this.DropDownList3.SelectedValue.ToString() + "'";
        }
        Condition = item;
        this.labelcodition.Text = Condition;
        return Condition;
    }
    #endregion
    //重置
    protected void Button_Reset(object sender, EventArgs e)
    {
        BindGridview1("");
        this.UpdatePanelApplyDetailSummary.Update();
        this.TextBox2.Text = "";
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList2();
        this.TextBox1.Text = "";
        this.DropDownList3.SelectedValue = "请选择";
    }
    //提交物料
    protected void Button_Com1(object sender, EventArgs e)
    {
        string Pname;
        bool temp = false;

        foreach (GridViewRow item in Gridview5.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                Pname = this.Gridview5.Rows[item.RowIndex].Cells[1].Text.ToString();
                temp = true;
                this.TextBox2.Text = Pname;
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Material, this.GetType(), "aa", "alert('请选择物料')", true);
            return;
        }
        else
        {
            this.Panel_Material.Visible = false;
            this.UpdatePanel_Material.Update();
            this.UpdatePanel_SupplySearch.Update();
        }
    }
    //取消物料选择
    protected void Button_Cancel1(object sender, EventArgs e)
    {
        this.Panel_Material.Visible = false;
        this.UpdatePanel_Material.Update();
    }
    #region//采购申请单详细表
    private void BindGridview3(PMPurchaseOrderinfo PMPurchaseOrderinfo)
    {
        this.Gridview3.DataSource = pl.SelectPMPurchaseApplyDetail_Material(PMPurchaseOrderinfo);
        this.Gridview3.DataBind();
        this.label_PD.Text = "物料";
    }
    private void BindGridview3_Apply(PMPurchaseOrderinfo PMPurchaseOrderinfo)
    {
        this.Gridview3.DataSource = pl.SelectPMPurchaseApplyDetail_Apply(PMPurchaseOrderinfo);
        this.Gridview3.DataBind();
        this.label_PD.Text = "申请单";
    }
    #endregion
    //根据物料执行采购申请，生成采购订单
    protected void Button_Com2(object sender, EventArgs e)
    {

        bool temp = false;
        decimal Ln = 0;
        decimal No = 0;
        decimal No1 = 0;

       
            foreach (GridViewRow item in Gridview1.Rows)
            {
                CheckBox rb = item.FindControl("CheckMarkup") as CheckBox;

                if (rb.Checked)
                {
                    if (this.Gridview1.Rows[item.RowIndex].Cells[8].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanelApplyDetailSummary, this.GetType(), "aa", "alert('物料单价未填写！')", true);
                        return;
                    }
                    else
                    {
                        this.label_IMMBD_MaterialID.Text = this.Gridview1.DataKeys[item.RowIndex]["IMMBD_MaterialID"].ToString();
                        this.label_IMUC_ID.Text = this.Gridview1.DataKeys[item.RowIndex]["IMUC_ID"].ToString();
                        No += (Convert.ToDecimal(this.Gridview1.Rows[item.RowIndex].Cells[5].Text.ToString())) * (Convert.ToDecimal(this.Gridview1.Rows[item.RowIndex].Cells[8].Text.ToString()));//所有总额
                        No1 = (Convert.ToDecimal(this.Gridview1.Rows[item.RowIndex].Cells[5].Text.ToString())) * (Convert.ToDecimal(this.Gridview1.Rows[item.RowIndex].Cells[8].Text.ToString()));//总额
                        Ln += Convert.ToDecimal(this.Gridview1.Rows[item.RowIndex].Cells[5].Text.ToString());//总数
                        this.label_NumOne.Text = this.Gridview1.Rows[item.RowIndex].Cells[8].Text.ToString();//单价
                        temp = true;
                        PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(label_IMMBD_MaterialID.Text);
                        PMPurchaseOrderinfo.IMUC_ID = new Guid(label_IMUC_ID.Text);
                        BindGridview3(PMPurchaseOrderinfo);
                        Gridview3_BL();
                        this.UpdatePanel_ApplyDetail.Update();
                        PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text);
                        PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_IMMBD_MaterialID.Text.ToString());
                        PMPurchaseOrderinfo.PMPOD_ProductRequest = this.label_ProductRequest.Text.ToString();
                        PMPurchaseOrderinfo.PMPOD_TotalMoney = No1;
                        PMPurchaseOrderinfo.PMPOD_Num = Convert.ToDecimal(this.Gridview1.Rows[item.RowIndex].Cells[5].Text.ToString());
                        PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
                        PMPurchaseOrderinfo.PMPOD_Price = Convert.ToDecimal(this.label_NumOne.Text);

                        pl.InsertPMPurchaseOrderDetail(PMPurchaseOrderinfo);//生成采购订单详细表
                        pl.UpdatePMPurchaseApplyDetail(PMPurchaseOrderinfo);//绑定采购订单和采购申请详细表
                    }
                }

            }
            //this.label_Number.Text = Convert.ToString(Ln);//总数

            this.label_Money.Text = Convert.ToString(No);//总额
            this.UpdatePanel_PMPurchaseOrder.Update();
            if (!temp)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanelApplyDetailSummary, this.GetType(), "aa", "alert('请选择物料')", true);
                return;
            }
            else
            {
                BindGridview1("");
                this.UpdatePanelApplyDetailSummary.Update();
                this.label_ProductRequest.Text = "";
                PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text);
                BindGridview4(PMPurchaseOrderinfo);
                this.Panel_PMPurchaseOrderDetail.Visible = true;
                this.UpdatePanel_PMPurchaseOrderDetail.Update();
            }
       
    }
    private void BindDropDownList2()
    {
        this.DropDownList2.DataSource = od.SelectIMMaterialType().Tables[0].DefaultView;
        DropDownList2.DataTextField = "IMMT_MaterialType";
        DropDownList2.DataValueField = "IMMT_MaterialType";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    }
    //采购订单制定
    protected void Gridview6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Makey")//制定
        {
          GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
          Gridview6.SelectedIndex = row.RowIndex;
          this.label_PMPurchaseOrderID.Text = this.Gridview6.DataKeys[row.RowIndex].Value.ToString();
          BindGridview1("");
           BindDropDownList2();
           this.Button22.Visible = false;
           this.Button13.Visible = true;
           this.Button14.Visible = true;
           this.Gridview1.Columns[0].Visible = true;//
           this.Gridview1.Columns[11].Visible = false;//单价
           PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text.ToString());
           BindGridview4(PMPurchaseOrderinfo);
           this.Panel_PMPurchaseOrderDetail.Visible = true;
           this.UpdatePanel_PMPurchaseOrderDetail.Update();
            this.Panel_SupplySearch.Visible = true;
            this.PanelApplyDetailSummary.Visible = true;
            this.UpdatePanel_SupplySearch.Update();
            this.UpdatePanelApplyDetailSummary.Update();
            this.label_Look.Text = "";
          
        }
        if (e.CommandName == "Moky")//编辑
        {
            Guid PMSI_ID;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview6.SelectedIndex = row.RowIndex;
            this.Label6.Text = this.Gridview6.Rows[row.RowIndex].Cells[2].Text.ToString() + "  " + "采购订单编辑"; 
            this.label_PMPurchaseOrderID.Text = this.Gridview6.DataKeys[row.RowIndex].Value.ToString();
            string　　condition="and PMPO_PurchaseOrderID='"+this.label_PMPurchaseOrderID.Text.ToString()+"'";
            DataSet ds = pd.SelectPMPurchaseOrder(condition);
            DataTable dt = ds.Tables[0];
            if(dt.Rows.Count>0)
            {
            this.DropDownList1.SelectedValue=dt.Rows[0][7].ToString();
            this.TextBox5.Text = dt.Rows[0][9].ToString();
            this.TextBox6.Text = dt.Rows[0][8].ToString();
            this.TextBox7.Text = dt.Rows[0][6].ToString();
            this.TextBox11.Text = dt.Rows[0][19].ToString();
            PMSI_ID = new Guid( dt.Rows[0][1].ToString());
            this.label_SupplyID.Text = dt.Rows[0][1].ToString();
            DataSet dss = ppl.SelectPMSupply_One(PMSI_ID);
            DataTable dtt = dss.Tables[0];
            if (dtt.Rows.Count > 0)
            { 
            this.TextBox4.Text=dtt.Rows[0][0].ToString();
            }
            }
            if (this.DropDownList1.SelectedValue == "预付款" || this.DropDownList1.SelectedValue == "现金预付款")
            {
                this.Label21.Visible = true;
                this.TextBox11.Visible = true;
            }
            else
            {
                this.Label21.Visible = false;
                this.TextBox11.Visible = false;
            }
            this.Panel2.Visible = true;
            this.UpdatePanel2.Update();
        }
        if (e.CommandName == "btnDelete")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview6.SelectedIndex = row.RowIndex;
            PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(e.CommandArgument.ToString());
           pl.UpdatePMPAD_Purchase(PMPurchaseOrderinfo);
            pl.DeletePMPurchaseOrder(PMPurchaseOrderinfo);
            
            BindGridview1("");
            this.UpdatePanelApplyDetailSummary.Update();
            BindGridview6();
            this.UpdatePanel_PMPurchaseOrder.Update();
        }
    }
    private void Gridview4_BL()
    {
        Decimal ddl = 0;
        for (int i = 0; i < Gridview4.Rows.Count; i++)
        {
            ddl += (Convert.ToDecimal(this.Gridview4.Rows[i].Cells[2].Text.ToString())) * (Convert.ToDecimal(this.Gridview4.Rows[i].Cells[3].Text.ToString()));
        }
        this.label_Money.Text = Convert.ToString(ddl);
    }
    //绑定采购订单表
    private void BindGridview6()
    {
        this.Gridview6.DataSource = pl.SelectPMPurchaseOrder();
        this.Gridview6.DataBind();
    }
    private void BindGridview6_Search(string condition)
    {
        this.Gridview6.DataSource = pl.SelectPMPurchaseOrderMain(condition);
        this.Gridview6.DataBind();
    }
    //显示对应采购订单的采购订单详细表
    private void BindGridview4(PMPurchaseOrderinfo PMPurchaseOrderinfo)
    {
        this.Gridview4.DataSource = pl.SelectPMPurchaseOrderDetail(PMPurchaseOrderinfo);
        this.Gridview4.DataBind();
    }
    #region//单价
    //更新单价
    protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.Gridview1.DataKeys[e.RowIndex]["IMMBD_MaterialID"].ToString());
        PMPurchaseOrderinfo.IMUC_ID = new Guid(this.Gridview1.DataKeys[e.RowIndex]["IMUC_ID"].ToString());
        PMPurchaseOrderinfo.PMPAD_Price = Convert.ToDecimal(((TextBox)(Gridview1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim().ToString());//设置成TextBook
        Gridview1.EditIndex = -1;
        //BindGridview1("");
        pl.InsertPMPurchaseApplyDetailPrice(PMPurchaseOrderinfo);
        string condition = GetCondition();
        BindGridview1(condition);
        this.UpdatePanelApplyDetailSummary.Update();
        this.PanelApplyDetailSummary.Visible = true;
    }
    //编辑单价
    protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview1.EditIndex = e.NewEditIndex;
        string condition = GetCondition();
        BindGridview1(condition);
    }
    //取消编辑单价
    protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview1.EditIndex = -1;
        string condition = GetCondition();
        BindGridview1(condition);
    }
    #endregion
    //取消根据物料执行采购申请
    protected void Button_Cancel2(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gridview1.Rows)
        {
            CheckBox rb = item.FindControl("CheckMarkup") as CheckBox;

            if (rb.Checked)
            {
                rb.Checked = false;
            }
        }
        this.PanelApplyDetailSummary.Visible = false;
        this.UpdatePanelApplyDetailSummary.Update();
        this.Panel_SupplySearch.Visible = false;
        this.UpdatePanel_SupplySearch.Update();
        this.Panel_ApplyDetail.Visible = false;
        this.UpdatePanel_ApplyDetail.Update();
        this.Panel_PMPurchaseOrderDetail.Visible = false;
        this.UpdatePanel_PMPurchaseOrderDetail.Update();
    }
    //申请单内容汇总查询结果
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.Panel1.Visible = true;
            this.UpdatePanel1.Update();
            if (this.label_Look.Text == "查看物料")
            {
                this.Button5.Visible = false;
                this.Gridview2.Columns[0].Visible = false;
                this.Gridview3.Columns[9].Visible = false;
            }
            else
            {
                this.Gridview2.Columns[0].Visible = true;
                this.Gridview3.Columns[9].Visible = true;
                this.Button5.Visible =true;
             }
            
            this.label_Num.Text = e.CommandArgument.ToString();//IMMBD_MaterialID
            this.label_IMUC_ID.Text = this.Gridview1.DataKeys[row.RowIndex]["IMUC_ID"].ToString();
            this.label_NumOne.Text = this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[8].Text.ToString();
            this.label_IMMBD_MaterialID.Text = e.CommandArgument.ToString();
            PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(e.CommandArgument.ToString());
            PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text.ToString());
            BindGridview2("and PMPurchaseApplyDetail.IMUC_ID='" + label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + label_Num.Text.ToString() + "'");
            //string condition;
            //condition = " and IMMBD_MaterialID='" + new Guid(e.CommandArgument.ToString()) + "'" + "and IMUC_ID='" + new Guid(this.label_IMUC_ID.Text.ToString())+"'";
            //MaterialTitle(condition);  
            this.label_Apply.Text = this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString() + "  " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[4].Text.ToString() + "  " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[6].Text.ToString();
            this.label5.Text = this.label_Apply.Text.ToString();
            this.Panel1.Visible = true;
            this.UpdatePanel1.Update();
            this.Panel_PMPurchaseApplyMain.Visible = true;
            this.UpdatePanel_PMPurchaseApplyMain.Update();
        }
    }
    //采购申请单
    private void BindGridview2(string condition)
    {
        this.Gridview2.DataSource = pl.SelectPMPurchaseApply_Material(condition);
        this.Gridview2.DataBind();
    }

    //选择部门
    protected void Button_Select2(object sender, EventArgs e)
    {
        this.Panel_Organization.Visible = true;
        BindGridView_Organization("");
        this.UpdatePanel_Organization.Update();
    }
    //部门
    private void BindGridView_Organization(string condition)
    {
        this.Gridview_Organization.DataSource = prl.SelectPRMP_Organization(condition);
        this.Gridview_Organization.DataBind();
    }
    //提交部门
    protected void Button_Com6(object sender, EventArgs e)
    {
        string Pname;
        bool temp = false;

        foreach (GridViewRow item in Gridview_Organization.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                Pname = this.Gridview_Organization.DataKeys[item.RowIndex].Value.ToString();
                temp = true;

                this.TextBox3.Text = Pname;


            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Organization, this.GetType(), "aa", "alert('请选择部门')", true);
        }
        else
        {
            this.Panel_Organization.Visible = false;
            this.UpdatePanel_Organization.Update();
            this.UpdatePanel1.Update();
        }
    }
    //检索申请单
    protected void Button_Sh2(object sender, EventArgs e)
    {
        string condition = Getcondition();
        //PMPurchaseOrderinfo.IMMBD_MaterialID=new Guid(this.label_Num.Text);
        //PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
        BindGridview2(condition);
        this.Panel_PMPurchaseApplyMain.Visible = true;
        this.UpdatePanel_PMPurchaseApplyMain.Update();
    }
    //检索采购申请单
    protected string Getcondition()
    {
        string condition;
        string item = "and PMPurchaseApplyDetail.IMUC_ID='" + this.label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + this.label_Num.Text.ToString() + "'";
        if (this.TextBox3.Text != "")
        {
            item += "and PMPurchaseApplyDetail.IMUC_ID='" + this.label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + this.label_Num.Text.ToString() + "'" + "and PMPAM_Department='" + this.TextBox3.Text.ToString() + "'";
        }
        if (this.TextBox10.Text != "")
        {
            item += "and PMPurchaseApplyDetail.IMUC_ID='" + this.label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + this.label_Num.Text.ToString() + "'" + " and PMPAM_ApplyMan='" + this.TextBox10.Text.ToString() + "'";
        }
        if (this.SupplyID.Text != "")
        {
            item += "and PMPurchaseApplyDetail.IMUC_ID='" + this.label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + this.label_Num.Text.ToString() + "'" + "and PMPAM_ApplyNum= '" + this.SupplyID.Text.ToString() + "'";
        }
        if (this.TextBox_SPTime2.Text.ToString() != "" && this.TextBox_SPTime3.Text.ToString() != "")
        {
            item += "and PMPurchaseApplyDetail.IMUC_ID='" + this.label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + this.label_Num.Text.ToString() + "'" + "and PMPAM_ApplyTime>='" + this.TextBox_SPTime2.Text.ToString() + "' and PMPAM_ApplyTime<='" + this.TextBox_SPTime3.Text.ToString() + "'";
        }
        if (this.TextBox_SPTime2.Text.ToString() != "")
        {
            item += "and PMPurchaseApplyDetail.IMUC_ID='" + this.label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + this.label_Num.Text.ToString() + "'" + "and PMPAM_ApplyTime>='" + this.TextBox_SPTime2.Text.ToString() + "'";
        }
        condition = item;
        this.labelcodition.Text = condition;
        return condition;
    }
    //重置
    protected void Button_Reset1(object sender, EventArgs e)
    {
        this.TextBox3.Text = "";
        this.TextBox10.Text = "";
        this.SupplyID.Text = "";
        this.TextBox_SPTime2.Text = "";
        this.TextBox_SPTime3.Text = "";
        this.UpdatePanel1.Update();
    }
    //采购申请单取消
    protected void Button_Cancel3(object sender, EventArgs e)
    {
        this.TextBox3.Text = "";
        this.TextBox10.Text = "";
        this.SupplyID.Text = "";
        this.TextBox_SPTime2.Text = "";
        this.TextBox_SPTime3.Text = "";
        this.UpdatePanel1.Update();
        this.Panel1.Visible = false;
        this.UpdatePanel1.Update();
        this.Panel_PMPurchaseApplyMain.Visible = false;
        this.UpdatePanel_PMPurchaseApplyMain.Update();
        this.Panel_ApplyDetail.Visible = false;
        this.UpdatePanel_ApplyDetail.Update();
    }

    //执行采购申请单
    protected void Button_Com3(object sender, EventArgs e)
    {
        bool temp = false;
        decimal Dc = 0;
        decimal Dm = 0;
        string St = "";
        //foreach (GridViewRow item in Gridview2.Rows)
        //{
        //    CheckBox rb = item.FindControl("CheckBox1") as CheckBox;
        //    if (rb.Checked)
        //    {
        //        temp = true;
        //    }
        //}
        //if(temp)
        //{
        //PMPurchaseOrderinfo.PMPO_MakeMan = Session["UserName"].ToString();
        //PMPurchaseOrderinfo.PMPO_State = "未制定";
        //pl.InsertPMPurchaseOrder(PMPurchaseOrderinfo);
        //this.Panel_PMPurchaseOrder.Visible = true;
        //BindGridview6();
        //this.label_PMPurchaseOrderID.Text = this.Gridview6.Rows[0].Cells[0].Text.ToString();//不精确
        //this.UpdatePanel_PMPurchaseOrder.Update();
        //}
        //DataSet dss = pl.SelectPMPurchaseOrder(PMPurchaseOrderinfo);
        //DataTable dtt = dss.Tables[0];
        //if (dtt.Rows.Count > 0)
        //{
        //    this.label_PMPurchaseOrderID.Text = dtt.Rows[0][0].ToString();
        //}
        foreach (GridViewRow item in Gridview2.Rows)
        {
            CheckBox rb = item.FindControl("CheckBox1") as CheckBox;
            if (rb.Checked)
            {
                if (this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[8].Text.ToString().Trim().Replace("&nbsp;", "") == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('物料单价未填写！')", true);
                    return;
                }
                else
                {
                    PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text);
                    PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_Num.Text);
                    PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
                    PMPurchaseOrderinfo.PMPAM_ID = new Guid(this.Gridview2.DataKeys[item.RowIndex].Value.ToString());
                    this.label_PMPAMID.Text = this.Gridview2.DataKeys[item.RowIndex].Value.ToString();
                    this.label_Int.Text = Convert.ToString(item.RowIndex);
                    BindGridview3_Apply(PMPurchaseOrderinfo);
                    Gridview3_BL();
                    pl.UpdatePMPurchaseApplyDetail_One(PMPurchaseOrderinfo);
                    Dc += Convert.ToDecimal(this.label_ZS.Text.ToString());//总数
                    Dm += (Convert.ToDecimal(this.label_ZS.Text)) * (Convert.ToDecimal(this.label_NumOne.Text));//总额
                    St = this.label_ProductRequest.Text;//特性
                    temp = true;



                    PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_Num.Text);
                    PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
                    PMPurchaseOrderinfo.PMPOD_Num = Dc;
                    PMPurchaseOrderinfo.PMPOD_TotalMoney = Dm;
                    this.label_Money.Text = Convert.ToString(Dm);
                    PMPurchaseOrderinfo.PMPOD_ProductRequest = St;
                    PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text);

                    PMPurchaseOrderinfo.PMPOD_Price = Convert.ToDecimal(this.label_NumOne.Text);
                    pl.InsertPMPurchaseOrderDetail(PMPurchaseOrderinfo);//生成采购订单详细表
                }
            }
        }
       
        this.label_ProductRequest.Text = "";
        St = "";
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Material, this.GetType(), "aa", "alert('请选择申请单')", true);
            return;
        }
        else
        {
            BindGridview1("");
            this.UpdatePanelApplyDetailSummary.Update();
            this.Panel1.Visible = false;
            this.UpdatePanel1.Update();
            this.Panel_PMPurchaseApplyMain.Visible = false;
            this.UpdatePanel_PMPurchaseApplyMain.Update();
            this.Panel_ApplyDetail.Visible = false;
            this.UpdatePanel_ApplyDetail.Update();
            PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text.ToString());
            BindGridview4(PMPurchaseOrderinfo);


            this.Panel_PMPurchaseOrderDetail.Visible = true;
            this.UpdatePanel_PMPurchaseOrderDetail.Update();
        }
    }
    //采购申请单
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check1")//查看
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_Num.Text);
            PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
            PMPurchaseOrderinfo.PMPAM_ID = new Guid(e.CommandArgument.ToString());
            this.label_PMPAMID.Text = e.CommandArgument.ToString();
            BindGridview3_Apply(PMPurchaseOrderinfo);
            this.Panel_ApplyDetail.Visible = true;
            this.UpdatePanel_ApplyDetail.Update();
            this.label1.Text = this.Gridview2.Rows[Gridview2.SelectedIndex].Cells[2].Text.ToString() + "  " + this.Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() + "  " + this.Gridview2.Rows[Gridview2.SelectedIndex].Cells[4].Text.ToString();
        }
       
    }
    //关闭
    protected void Button_CS(object sender, EventArgs e)
    {
        this.Panel_ApplyDetail.Visible = false;
        this.UpdatePanel_ApplyDetail.Update();
    }
    //选择供应商
    protected void Button_Select3(object sender, EventArgs e)
    {
        BindGridview_PMSupply("");
        this.Label_ISupply.Text = "新增";
        this.Panel_Supply.Visible = true;
        this.UpdatePanel_Supply.Update();
    }
    //供应商
    private void BindGridview_PMSupply(string Condition)
    {
        try
        {
            this.Gridview_PMSupply.DataSource = ppl.SelectPMSupplyInfo(Condition);
            this.Gridview_PMSupply.DataBind();
        }
        catch (Exception)
        {
            throw;

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
                Pname = this.Gridview_PMSupply.DataKeys[item.RowIndex]["PMSI_SupplyName"].ToString();
                temp = true;
                if(this.Label_ISupply.Text=="新增")
                {
                 this.TextBox4.Text = Pname;
                }
                if(this.Label_ISupply.Text=="检索")
                {
                    this.TextBox12.Text = Pname;
                }
                this.label_SupplyID.Text = this.Gridview_PMSupply.DataKeys[item.RowIndex]["PMSI_ID"].ToString().Trim();
                this.TextBox6.Text = this.Gridview_PMSupply.Rows[item.RowIndex].Cells[4].Text.ToString().Trim().Replace("&nbsp;", "0");
            }
        }

        //if (temp)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.GetType(), "alert", "alert('提交成功！')", true);
        //    return;
        //}
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Supply, this.GetType(), "aa", "alert('请选择供应商')", true);
            return;
        }
        else
        {
            this.UpdatePanel3.Update();
            this.UpdatePanel2.Update();
            this.Panel_Supply.Visible = false;
            this.UpdatePanel_Supply.Update();
        }
    }
    //取消选择供应商
    protected void Button_Cancel5(object sender, EventArgs e)
    {
        this.Panel_Supply.Visible = false;
        this.UpdatePanel_Supply.Update();
    }
    //生成采购订单
    protected void Button_Create(object sender, EventArgs e)
    {
        if (this.TextBox4.Text != "")
        {
            PMPurchaseOrderinfo.PMSI_ID = new Guid(this.label_SupplyID.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.DropDownList1.SelectedValue != "请选择")
        {
        
            PMPurchaseOrderinfo.PMPO_PayWay = this.DropDownList1.SelectedValue.ToString();
            if (this.DropDownList1.SelectedValue == "预付款" || this.DropDownList1.SelectedValue == "现金预付款")
            {
                PMPurchaseOrderinfo.PMPO_AdvancePayNum = Convert.ToDecimal(this.TextBox11.Text);
            }
            else
            {
                PMPurchaseOrderinfo.PMPO_AdvancePayNum = Convert.ToDecimal("0");
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox5.Text != "")
        {
            PMPurchaseOrderinfo.PMPO_TotalMoney = Convert.ToDecimal(this.TextBox5.Text.ToString());
        }
        if (this.TextBox6.Text != "")
        {
            PMPurchaseOrderinfo.PMPO_PaymentTime = Convert.ToUInt16(this.TextBox6.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox7.Text != "")
        {
            PMPurchaseOrderinfo.PMPO_PlanArrTime = Convert.ToDateTime(this.TextBox7.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
       
        PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text.ToString());
        PMPurchaseOrderinfo.PMPO_State = "已提交";
        PMPurchaseOrderinfo.PMPO_ResidueMoney = Convert.ToDecimal(this.TextBox5.Text.ToString());
        //PMPurchaseOrderinfo.PMPO_Num = Convert.ToDecimal(this.label_Number.Text);
        pl.UpdatePMPurchaseOrder(PMPurchaseOrderinfo);
        //pl.UpdatePMPAD_Purchase(PMPurchaseOrderinfo);
        this.TextBox4.Text = "";
        this.DropDownList1.SelectedValue = "请选择";
        this.TextBox6.Text = "";
        this.TextBox7.Text = "";
        this.TextBox11.Text = "";
        //this.Panel_PMPurchaseOrderDetail.Visible = false;
        this.UpdatePanel_PMPurchaseOrderDetail.Update();
        this.UpdatePanel_PMPurchaseOrder.Update();
        this.Panel2.Visible = false;
        this.UpdatePanel2.Update();
        BindGridview1("");
        this.UpdatePanelApplyDetailSummary.Update();
        BindGridview6();
        this.UpdatePanel_PMPurchaseOrder.Update();
        this.Panel_PMPurchaseOrderDetail.Visible = false;
        this.UpdatePanel_PMPurchaseOrderDetail.Update();
        this.Panel_ApplyDetail.Visible = false;
        this.UpdatePanel_ApplyDetail.Update();
        this.Panel_PMPurchaseApplyMain.Visible = false;
        this.UpdatePanel_PMPurchaseApplyMain.Update();
        this.PanelApplyDetailSummary.Visible = false;
        this.UpdatePanelApplyDetailSummary.Update();
        this.Panel_SupplySearch.Visible = false;
        this.UpdatePanel_SupplySearch.Update();
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.GetType(), "alert", "alert('提交成功！')", true);
        return;
   

    }
    #region//换页
    protected void Gridview5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview5.BottomPagerRow;


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
        string condition = GetCondition_Material();
        BindGridview5(condition);
        this.Gridview5.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview5.PageCount ? this.Gridview5.PageCount - 1 : newPageIndex;
        this.Gridview5.PageIndex = newPageIndex;
        this.Gridview5.DataBind();
    }

    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview1.BottomPagerRow;


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
        string Condition = GetCondition();
        BindGridview1(Condition);
       
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview1.PageCount ? this.Gridview1.PageCount - 1 : newPageIndex;
        this.Gridview1.PageIndex = newPageIndex;
        this.Gridview1.DataBind();
    }

    protected void Gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview2.BottomPagerRow;


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
        //PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_Num.Text);
        //PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
        string condition = Getcondition();
        BindGridview2(condition);

        this.Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview2.PageCount ? this.Gridview2.PageCount - 1 : newPageIndex;
        this.Gridview2.PageIndex = newPageIndex;
        this.Gridview2.DataBind();
    }
    protected void Gridview_Organization_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview_Organization.BottomPagerRow;


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
        BindGridView_Organization("");
        this.Gridview_Organization.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview_Organization.PageCount ? this.Gridview_Organization.PageCount - 1 : newPageIndex;
        this.Gridview_Organization.PageIndex = newPageIndex;
        this.Gridview_Organization.DataBind();
    }

    protected void Gridview3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview3.BottomPagerRow;


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
        if (this.label_PD.Text == "物料")
        {
            PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_Num.Text);
            PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
            BindGridview3(PMPurchaseOrderinfo);
        }
        if (this.label_PD.Text == "申请单")
        {
            PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_Num.Text);
            PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
            PMPurchaseOrderinfo.PMPAM_ID = new Guid(this.label_PMPAMID.Text);
            BindGridview3_Apply(PMPurchaseOrderinfo);
        }
        this.Gridview3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview3.PageCount ? this.Gridview3.PageCount - 1 : newPageIndex;
        this.Gridview3.PageIndex = newPageIndex;
        this.Gridview3.DataBind();
    }
    protected void Gridview4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview4.BottomPagerRow;


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
        PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(this.label_PMPurchaseOrderID.Text);
        BindGridview4(PMPurchaseOrderinfo);
        this.Gridview4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview4.PageCount ? this.Gridview4.PageCount - 1 : newPageIndex;
        this.Gridview4.PageIndex = newPageIndex;
        this.Gridview4.DataBind();
    }
    protected void Gridview_PMSupply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview_PMSupply.BottomPagerRow;


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
        this.Gridview_PMSupply.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview_PMSupply.PageCount ? this.Gridview_PMSupply.PageCount - 1 : newPageIndex;
        this.Gridview_PMSupply.PageIndex = newPageIndex;
        this.Gridview_PMSupply.DataBind();
    }

    protected void Gridview6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview6.BottomPagerRow;


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
        BindGridview6();
        this.Gridview6.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview6.PageCount ? this.Gridview6.PageCount - 1 : newPageIndex;
        this.Gridview6.PageIndex = newPageIndex;
        this.Gridview6.DataBind();
    }
    #endregion
    //遍历
    private void Gridview3_BL()
    {
        for (int i = 0; i < Gridview3.Rows.Count; i++)
        {

            if (this.label_PD.Text == "物料")
            {
                if (Gridview3.Rows[i].Cells[5].Text.ToString().Trim() != "")
                {
                    this.label_ProductRequest.Text += Gridview3.Rows[i].Cells[3].Text.ToString().Trim() + ":" + Gridview3.Rows[i].Cells[5].Text.ToString().Trim() + ";";
                }
            }
            if (this.label_PD.Text == "申请单")
            {
                if (Gridview3.Rows[i].Cells[3].Text.ToString().Trim() != "")
                {
                    decimal Num = 0;
                    Num += Convert.ToDecimal(Gridview3.Rows[i].Cells[3].Text.ToString());
                    this.label_ZS.Text = Convert.ToString(Num);
                }
                if (Gridview3.Rows[i].Cells[5].Text.ToString().Trim() != "")
                {
                    this.label_ProductRequest.Text += Gridview3.Rows[i].Cells[3].Text.ToString().Trim() + ":" + Gridview3.Rows[i].Cells[5].Text.ToString().Trim() + ";";
                }
            }
        }

    }
    #region//悬浮框
    protected void Gridview3_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview3.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview3.Rows[i].Cells.Count; j++)
            {
                Gridview3.Rows[i].Cells[j].ToolTip = Gridview3.Rows[i].Cells[j].Text;
                if (Gridview3.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview3.Rows[i].Cells[j].Text = Gridview3.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }


    protected void Gridview4_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview4.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview4.Rows[i].Cells.Count; j++)
            {
                Gridview4.Rows[i].Cells[j].ToolTip = Gridview4.Rows[i].Cells[j].Text;
                if (Gridview4.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview4.Rows[i].Cells[j].Text = Gridview4.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    #endregion
    //取消采购订单制定
    protected void Button_Reset4(object sender, EventArgs e)
    {
        //this.Panel_PMPurchaseOrderDetail.Visible = false;
        //this.UpdatePanel_PMPurchaseOrderDetail.Update();
        this.Panel2.Visible = false;
        this.Panel_PMPurchaseOrderDetail.Visible = false;
        this.TextBox4.Text = "";
        this.DropDownList1.SelectedValue = "请选择";
        this.TextBox5.Text = "";
        this.TextBox6.Text = "";
        this.TextBox7.Text = "";
        this.TextBox11.Text = "";
        this.UpdatePanel2.Update();
        this.UpdatePanel_PMPurchaseOrderDetail.Update();
    }
    //取消部门选择
    protected void Button_Cancel6(object sender, EventArgs e)
    {
        this.Panel_Organization.Visible = false;
        this.UpdatePanel_Organization.Update();
    }
    protected void Gridview_Organization_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge2(this)");
            }
        }
    }
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

    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    CheckBox rb = (CheckBox)e.Row.FindControl("CheckMarkup");
        //    if (rb.Checked)
        //    {
        //        rb.Attributes.Add("onclick", this.label_IsChecked.Text="true");
        //    }
        // }
    }

    //查看采购订单
    protected void Button_Ring(object sender, EventArgs e)
    {
        BindGridview6();
        this.Panel_PMPurchaseOrder.Visible = true;
        this.UpdatePanel_PMPurchaseOrder.Update();
    }
    //关闭采购订单
    //protected void Button_selin(object sender, EventArgs e)
    //{
    //    this.Panel_PMPurchaseOrder.Visible = false;
    //    this.UpdatePanel_PMPurchaseOrder.Update();
    //}
    protected void Gridview6_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMPO_State"].ToString().Trim() == "已提交")
            {
                e.Row.Cells[17].Enabled = false;
            }
            if (drv["PMPO_State"].ToString().Trim() == "已提交")
            {
                e.Row.Cells[18].Enabled = true;
               
            }
            else
            {
                e.Row.Cells[18].Enabled = false;
                
            }
            if (drv["PMPO_State"].ToString().Trim() == "已提交" || drv["PMPO_State"].ToString().Trim() == "未制定")
            {
                e.Row.Cells[19].Enabled = true;
            }
            else
            {
                e.Row.Cells[19].Enabled = false;
            }
            }
    }
    //检索供应商
    protected void Button1_KiMi(object sender, EventArgs e)
    {
        string condition = GetCondition_Supply();
        BindGridview_PMSupply(condition);
        this.UpdatePanel_Supply.Update();
    }
    protected string GetCondition_Supply()
    {
        string condition;
        string item = "";
        if (this.TextBox8.Text != "")
        {
            item += " and PMSI_SupplyNum='" + this.TextBox8.Text + "'";
        }
        if (this.TextBox9.Text != "")
        {
            item += " and PMSI_SupplyName like'%" + this.TextBox9.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索供应商
    protected void Button_CoMi(object sender, EventArgs e)
    {
        this.TextBox8.Text = "";
        this.TextBox9.Text = "";
        BindGridview_PMSupply("");
        this.UpdatePanel_Supply.Update();
    }
    protected void Button1_KiM(object sender, EventArgs e)
    {
        string condition = GetCondition_Material();
        BindGridview5(condition);
        this.UpdatePanel_Material.Update();
    }
    protected string GetCondition_Material()
    {
        string item = "";
        string condition;
        if (this.TextBox16.Text != "")
        {
            item += "and IMMBD_MaterialName  like '%" + this.TextBox16.Text.ToString() + "%'";
        }
        
        condition = item;
        return condition;
    }
    protected void Button_CoM(object sender, EventArgs e)
    {
        this.TextBox16.Text = "";
        BindGridview5("");
        this.UpdatePanel_Material.Update();
    }
    //付款方式--预付款情况
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DropDownList1.SelectedValue == "预付款" || this.DropDownList1.SelectedValue == "现金预付款")
        {
            this.Label21.Visible = true;
            this.TextBox11.Visible = true;
            this.Label24.Visible = true;
            this.UpdatePanel2.Update();
        }
        else
        {
            this.Label21.Visible = false ;
            this.TextBox11.Visible = false ;
            this.Label24.Visible = false ;
            this.UpdatePanel2.Update();
        }
    }
    //勾选物料以后提交采购订单
    protected void Button_Comi(object sender, EventArgs e)
    {

        this.label4.Text = this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[2].Text.ToString() + "  " + "采购订单内容";
        this.Label6.Text = this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[2].Text.ToString() + "  " + "采购订单制定";
        this.Panel_PMPurchaseOrderDetail.Visible = true;
        this.UpdatePanel_PMPurchaseOrderDetail.Update();
        Gridview4_BL();
        this.Panel2.Visible = true;
        this.TextBox5.Text = this.label_Money.Text;
        this.UpdatePanel2.Update();

    }
    //检索采购订单
    protected void Button_ShDD(object sender, EventArgs e)
    {
        string condition = GetConditionn();
        if (this.TextBox15.Text == "")
        {
            BindGridview6_Search(condition);
        }else
            if (this.TextBox15.Text != "")
            {
                string conditionn = "and IMMaterialBasicData.IMMBD_MaterialName='" +this.TextBox15.Text+"'"+ condition;
                this.Gridview6.DataSource = pl.SelectPMPurchaseOrderMain_Material(conditionn);
                this.Gridview6.DataBind();
            }
        this.UpdatePanel_PMPurchaseOrder.Update();
    }
    protected string GetConditionn()
    {
        string condition;
        string item = "";
        if (this.DropDownList4.SelectedValue != "请选择")
        {
            item += " and PMPO_State='" + this.DropDownList4.SelectedValue.ToString() + "'";
        }
        if (this.PurchaseOrderID.Text != "")
        {
            item += "and PMPO_PurchaseOrderNum='" + this.PurchaseOrderID.Text.ToString() + "'";
        }
       
        if (this.TextBox12.Text != "")
        {
            item += "and PMPurchaseOrder.PMSI_ID='" + this.label_SupplyID.Text.ToString() + "'";
        }
        if (this.TextBox13.Text.ToString() != "" && this.TextBox14.Text.ToString() != "")
        {
            item += "and PMPO_MakeTime>='" + this.TextBox13.Text.ToString() + "' and PMPO_MakeTime<='" + this.TextBox14.Text.ToString() + "'";
        }
        if (this.TextBox13.Text.ToString() != "")
        {
            item += "and PMPO_MakeTime>='" + this.TextBox13.Text.ToString() + "'";
        }
        condition = item;
        this.labelcondition.Text = condition;
        return condition;
    }
    //检索时选择供应商
    protected void Button_SSupply(object sender, EventArgs e)
    {
        BindGridview_PMSupply("");
        this.Label_ISupply.Text = "检索";
        this.Panel_Supply.Visible = true;
        this.UpdatePanel_Supply.Update();
    }
   
    protected void Button_SR(object sender, EventArgs e)
    {
        BindGridview6();
        this.DropDownList4.SelectedValue = "请选择";
        this.PurchaseOrderID.Text = "";
        this.TextBox12.Text = "";
        this.TextBox13.Text = "";
        this.TextBox14.Text = "";
        this.TextBox15.Text = "";
        this.UpdatePanel3.Update();
        this.UpdatePanel_PMPurchaseOrder.Update();

    }
    //新增采购订单
    protected void Button_SRing(object sender, EventArgs e)
    {
        PMPurchaseOrderinfo.PMPO_MakeMan = Session["UserName"].ToString();
        PMPurchaseOrderinfo.PMPO_State = "未制定";
        pl.InsertPMPurchaseOrder(PMPurchaseOrderinfo);//生成采购订单
        this.Panel_PMPurchaseOrder.Visible = true;
        BindGridview6();
        this.UpdatePanel_PMPurchaseOrder.Update();
    }
    //查看物料
    protected void Button_Material(object sender, EventArgs e)
    {
        //string Condition = GetCondition();
        BindGridview1("");
        this.Gridview1.Columns[0].Visible = false;
        this.Button22.Visible = true;
        this.Button13.Visible = false;
        this.Button14.Visible = false;
        this.Panel_SupplySearch.Visible = true;
        this.UpdatePanel_SupplySearch.Update();
        this.Gridview1.Columns[10].Visible = false;
        if (Session["UserRole"].ToString().Contains("采购申请单价填写"))
        {
            this.Gridview1.Columns[11].Visible = true;//单价
        }
        else
        {
            this.Gridview1.Columns[11].Visible = false;//单价
        }
        this.PanelApplyDetailSummary.Visible = true;
        this.UpdatePanelApplyDetailSummary.Update();
        this.label_Look.Text = "查看物料";
    }
    protected void Button_Cancel22(object sender, EventArgs e)
    {
        this.TextBox2.Text = "";
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList2();
        this.TextBox1.Text = "";
        this.DropDownList3.SelectedValue = "请选择";

        this.label_Look.Text = "";
        this.PanelApplyDetailSummary.Visible = false;
        this.UpdatePanelApplyDetailSummary.Update();
        this.Panel_SupplySearch.Visible = false;
        this.UpdatePanel_SupplySearch.Update();
        this.Panel_ApplyDetail.Visible = false;
        this.UpdatePanel_ApplyDetail.Update();
    }
    protected void Gridview3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deletecg")//删除已审核通过而未采购的申请单
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            Guid PMPAD_ID = new Guid(e.CommandArgument.ToString());
            od.DeletePMPurchaseApplyMain_Caigou(PMPAD_ID);

            PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_IMMBD_MaterialID.Text);
            PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text.ToString());
            BindGridview2("and PMPurchaseApplyDetail.IMUC_ID='" + label_IMUC_ID.Text.ToString() + "'" + "and IMMaterialBasicData.IMMBD_MaterialID='" + label_Num.Text.ToString() + "'");
            this.UpdatePanel_PMPurchaseApplyMain.Update();

            PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(this.label_Num.Text);
            PMPurchaseOrderinfo.IMUC_ID = new Guid(this.label_IMUC_ID.Text);
            PMPurchaseOrderinfo.PMPAM_ID = new Guid(e.CommandArgument.ToString());
            this.label_PMPAMID.Text = e.CommandArgument.ToString();
            BindGridview3_Apply(PMPurchaseOrderinfo);
            this.Panel_ApplyDetail.Visible = true;
            this.UpdatePanel_ApplyDetail.Update();

            string Condition = GetCondition();
            BindGridview1(Condition);
            this.UpdatePanelApplyDetailSummary.Update();


            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('删除成功！')", true);
            return;
        }
    }
}