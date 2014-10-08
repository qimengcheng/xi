using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProjectManagement_PMPurchaseOrder : Page
{
    PMPurchaseOrderL pl = new PMPurchaseOrderL();
    PMSupplyMaterialL pll = new PMSupplyMaterialL();
    PMEquipmentL plll = new PMEquipmentL();
    PMSupplyInfo_PMSupplyContactL ppl = new PMSupplyInfo_PMSupplyContactL();
    PMPurchaseOrderinfo PMPurchaseOrderinfo = new PMPurchaseOrderinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "采购订单";
        if (!(Session["UserRole"].ToString().Contains("采购订单制定")))
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!IsPostBack)
        {
            BindGridview3("");
            UpdatePanel_PMPurchaseOrder.Update();
        }
    }
    #region //检索
    //绑定采购订单表
    private void BindGridview3(string condition)
    {
        Gridview3.DataSource = pl.SelectPMPurchaseOrderMain(condition);
        Gridview3.DataBind();
    }
    //选择供应商
    protected void Button_Select2(object sender, EventArgs e)
    {
        labelSupplySelect.Text = "检索";
        BindGridview2("");
        Panel4.Visible = true;
        UpdatePanel4.Update();
    }
    //绑定供应商
    private void BindGridview2(string Condition)
    {
        Gridview2.DataSource = ppl.SelectPMSupplyInfo(Condition);
        Gridview2.DataBind();
    }

    protected void Button_Sh2(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGridview3(condition);
        UpdatePanel_PMPurchaseOrder.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_Material.Visible = false;
        UpdatePanel_Material.Update();
        Panel_PMPurchaseOrderDetail.Visible = false;
        UpdatePanel_PMPurchaseOrderDetail.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string item = "";
        if (DropDownList4.SelectedValue != "请选择")
        {
            item += " and PMPO_State='" + DropDownList4.SelectedValue.ToString() + "'";
        }
        if (DropDownList3.SelectedValue != "请选择")
        {
            item += " and PMPO_AlreadyPay='" + DropDownList3.SelectedValue.ToString() + "'";
        }
        if (PurchaseOrderID.Text != "")
        {
            item += "and PMPO_PurchaseOrderNum='" + PurchaseOrderID.Text.ToString() + "'";
        }
        if (DropDownList1.SelectedValue != "请选择")
        {
            item += " and PMPO_PayWay='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (DropDownList2.SelectedValue != "请选择")
        {
            item += " and PMPO_ArriverCondition='" + DropDownList2.SelectedValue.ToString() + "'";
        }
        if (TextBox3.Text != "")
        {
            item += "and PMPurchaseOrder.PMSI_ID='" + LabelSupplyID.Text.ToString() + "'";
        }
        if (TextBox_SPTime2.Text.ToString() != "" && TextBox_SPTime3.Text.ToString() != "")
        {
            item += "and PMPO_MakeTime>='" + TextBox_SPTime2.Text.ToString() + "' and PMPO_MakeTime<='" + TextBox_SPTime3.Text.ToString() + "'";
        }
        if (TextBox_SPTime2.Text.ToString() != "")
        {
            item += "and PMPO_MakeTime>='" + TextBox_SPTime2.Text.ToString() + "'";
        }
        condition = item;
        labelcondition.Text = condition;
        return condition;
    }
    #endregion
    //重置
    protected void Button_Reset1(object sender, EventArgs e)
    {
        BindGridview3("");
        UpdatePanel_PMPurchaseOrder.Update();
        DropDownList4.SelectedValue = "请选择";
        DropDownList3.SelectedValue = "请选择";
        PurchaseOrderID.Text = "";
        DropDownList1.SelectedValue = "请选择";
        DropDownList2.SelectedValue = "请选择";
        TextBox3.Text = "";
        TextBox_SPTime2.Text = "";
        TextBox_SPTime3.Text = "";
        UpdatePanel1.Update();
    }
    //新增
    protected void Button_New(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        UpdatePanel3.Update();
    }
    //新增时选择供应商
    protected void Button_Select3(object sender, EventArgs e)
    {
        labelSupplySelect.Text = "新增";
        BindGridview2("");
        Panel4.Visible = true;
        UpdatePanel4.Update();
    }
    //制定详细表
    protected void Button_Create(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            PMPurchaseOrderinfo.PMSI_ID = new Guid(LabelSupplyID.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel3, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (DropDownList6.SelectedValue != "请选择")
        {
            PMPurchaseOrderinfo.PMPO_PayWay = DropDownList6.SelectedValue.ToString();
            if (DropDownList6.SelectedValue == "预付款" || DropDownList6.SelectedValue == "现金预付款")
            {
                PMPurchaseOrderinfo.PMPO_AdvancePayNum = Convert.ToDecimal(TextBox14.Text);
            }
            else
            {
                PMPurchaseOrderinfo.PMPO_AdvancePayNum= Convert.ToDecimal("0");
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel3, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox2.Text != "")
        {
            PMPurchaseOrderinfo.PMPO_PaymentTime = Convert.ToInt32(TextBox2.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel3, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox5.Text != "")
        {
            PMPurchaseOrderinfo.PMPO_PlanArrTime = Convert.ToDateTime(TextBox5.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel3, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        PMPurchaseOrderinfo.PMPO_MakeMan = Session["UserName"].ToString();
        //PMPurchaseOrderinfo.PMPO_MakeTime=DateTime.Now;

        //this.Label_MakeTime.Text
        PMPurchaseOrderinfo.PMPO_State = "未制定";
        pl.InsertPMPurchaseOrderMain(PMPurchaseOrderinfo);
        BindGridview3("");
        UpdatePanel_PMPurchaseOrder.Update();
        TextBox1.Text = "";
        DropDownList6.SelectedValue = "请选择";
        TextBox2.Text = "";
        TextBox5.Text = "";
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    //取消新增采购订单
    protected void Button_Reset4(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        DropDownList6.SelectedValue = "请选择";
        TextBox2.Text = "";
        TextBox5.Text = "";
        Panel3.Visible = false;
        UpdatePanel3.Update();

    }
    //提交供应商
    protected void Button_ComSP(object sender, EventArgs e)
    {

        string Pname;
        bool temp = false;
        foreach (GridViewRow item in Gridview2.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;
            if (rb.Checked)
            {
                LabelSupplyID.Text = Gridview2.DataKeys[item.RowIndex]["PMSI_ID"].ToString();
                Pname = Gridview2.DataKeys[item.RowIndex]["PMSI_SupplyName"].ToString();
                temp = true;
                if (labelSupplySelect.Text == "检索")
                {
                    TextBox3.Text = Pname;
                    UpdatePanel1.Update();
                }
                if (labelSupplySelect.Text == "新增")
                {
                    TextBox1.Text = Pname;
                    TextBox2.Text = Gridview2.Rows[item.RowIndex].Cells[4].Text.ToString().Trim().Replace("&nbsp;", "0");
                    UpdatePanel3.Update();
                }
            }

        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "aa", "alert('请选择供应商')", true);
        }
        else
        {
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }
    }
    //取消选择供应商
    protected void Button_Cancel5(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }

    //供应商
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
    //选择物料
    protected void Button_SelectM(object sender, EventArgs e)
    {
        //string condition="and PMSI_ID='"+this.Gridview3.Rows[Gridview3.SelectedIndex].Cells[1].ToString()+"'";
        BindGridview5("");
        Panel_Material.Visible = true;
        UpdatePanel_Material.Update();
    }
    //绑定物料表
    private void BindGridview5(string condition)
    {
        Gridview5.DataSource = pll.SelectPMPurchaseSMaterial(condition);
        Gridview5.DataBind();
    }
    //提交物料
    protected void Button_Com1(object sender, EventArgs e)
    {
        bool temp = false;
        foreach (GridViewRow item in Gridview5.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;
            if (rb.Checked)
            {
                TextBox4.Text = Gridview5.Rows[item.RowIndex].Cells[1].Text.ToString();
                label_MaterialID.Text = Gridview5.DataKeys[item.RowIndex]["IMMBD_MaterialID"].ToString();
                TextBox8.Text = Gridview5.Rows[item.RowIndex].Cells[4].Text.ToString();
                TextBox9.Text = Gridview5.Rows[item.RowIndex].Cells[2].Text.ToString();
                label_IMUC_ID.Text = Gridview5.DataKeys[item.RowIndex]["IMUC_ID"].ToString();
                temp = true;
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Material, GetType(), "aa", "alert('请选择物料')", true);
            return;
        }
        else
        {
            UpdatePanel2.Update();
            Panel_Material.Visible = false;
            UpdatePanel_Material.Update();
        }
    }
    //取消选择物料
    protected void Button_Cancel1(object sender, EventArgs e)
    {
        Panel_Material.Visible = false;
        UpdatePanel_Material.Update();
    }
    //提交新增采购订单详细表
    protected void Button_Comfirm(object sender, EventArgs e)
    {
        if (labelMark.Text == "新增")
        {

            PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(labelPurchaseOrderID.Text);
            if (TextBox4.Text != "")
            {
                PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(label_MaterialID.Text);
                PMPurchaseOrderinfo.IMUC_ID = new Guid(label_IMUC_ID.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox6.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_Num = Convert.ToDecimal(TextBox6.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }

            if (TextBox10.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_Price = Convert.ToDecimal(TextBox10.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox11.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_ProductRequest = TextBox11.Text;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox12.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_Remark = TextBox12.Text;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            PMPurchaseOrderinfo.PMPOD_TotalMoney = (Convert.ToDecimal(TextBox6.Text)) * (Convert.ToDecimal(TextBox10.Text));

            pl.InsertPMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo);
            BindGridview1(PMPurchaseOrderinfo);
            Gridview1_BL();

            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox6.Text = "";

            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            UpdatePanel2.Update();
        }
        if (labelMark.Text == "修改")
        {

            PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(labelPurchaseOrderID.Text);
            if (TextBox4.Text != "")
            {
                PMPurchaseOrderinfo.IMMBD_MaterialID = new Guid(label_MaterialID.Text);
                PMPurchaseOrderinfo.IMUC_ID = new Guid(label_IMUC_ID.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('请选择物料！')", true);
                return;
            }
            if (TextBox6.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_Num = Convert.ToDecimal(TextBox6.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('请填写数量！')", true);
                return;
            }

            if (TextBox10.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_Price = Convert.ToDecimal(TextBox10.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('请填写单价！')", true);
                return;
            }
            if (TextBox11.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_ProductRequest = TextBox11.Text;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('请填写产品要求！')", true);
                return;
            }
            if (TextBox12.Text != "")
            {
                PMPurchaseOrderinfo.PMPOD_Remark = TextBox12.Text;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('请填写备注！')", true);
                return;
            }
            PMPurchaseOrderinfo.PMPOD_TotalMoney = (Convert.ToDecimal(TextBox6.Text)) * (Convert.ToDecimal(TextBox10.Text));
            PMPurchaseOrderinfo.PMPOD_PurchaseDetailID = new Guid(Label_MakeTime.Text);
            pl.UpdatePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo);
            BindGridview1(PMPurchaseOrderinfo);
            Gridview1_BL();
            Panel_PMPurchaseOrderDetail.Visible = true;
            UpdatePanel_PMPurchaseOrderDetail.Update();
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox6.Text = "";

            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";

        }
        UpdatePanel_PMPurchaseOrderDetail.Update();
    }
    //绑定采购订单详细表
    private void BindGridview1(PMPurchaseOrderinfo pMPurchaseOrderinfo)
    {
        Gridview1.DataSource = pl.SelectPMPurchaseOrderDetail_look(pMPurchaseOrderinfo);
        Gridview1.DataBind();
    }
    //提交所有采购订单详细表
    protected void ButtonMark(object sender, EventArgs e)
    {
        Gridview1_BL();
        PMPurchaseOrderinfo.PMPO_TotalMoney = Convert.ToDecimal(label_ActuallNum.Text.ToString());
        PMPurchaseOrderinfo.PMPO_ResidueMoney = Convert.ToDecimal(label_ActuallNum.Text.ToString());
        //PMPurchaseOrderinfo.PMPO_Num = Convert.ToDecimal(this.label_ZS.Text.ToString());
        PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(labelPurchaseOrderID.Text);
        PMPurchaseOrderinfo.PMPO_State = "已提交";
        pl.UpdatePMPurchaseOrder_State(PMPurchaseOrderinfo);
        BindGridview3("");
        UpdatePanel_PMPurchaseOrder.Update();
        Panel_PMPurchaseOrderDetail.Visible = false;
        UpdatePanel_PMPurchaseOrderDetail.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMPurchaseOrderDetail, GetType(), "aa", "alert('提交成功！')", true);
        return;
    }
    //取消新增采购订单详细表
    protected void Button_Reset5(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox6.Text = "";

        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";

        UpdatePanel2.Update();

    }
    //关闭
    protected void ButtonClose(object sender, EventArgs e)
    {
        Panel_PMPurchaseOrderDetail.Visible = false;
        UpdatePanel_PMPurchaseOrderDetail.Update();
    }
    //取消新增的订单的详细表
    protected void ButtonCancel(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox6.Text = "";

        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_PMPurchaseOrderDetail.Visible = false;
        UpdatePanel_PMPurchaseOrderDetail.Update();

    }
    //采购订单表
    protected void Gridview3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check1")//查看
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview3.SelectedIndex = row.RowIndex;
            PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(e.CommandArgument.ToString());
            labelPurchaseOrderID.Text = e.CommandArgument.ToString();
            BindGridview1(PMPurchaseOrderinfo);
            label5.Text = Gridview3.Rows[Gridview3.SelectedIndex].Cells[2].Text.ToString() + "  " + Gridview3.Rows[Gridview3.SelectedIndex].Cells[3].Text.ToString();
            Button14.Visible = false;
            Button11.Visible = true;
            Button17.Visible = false;
            Gridview1.Columns[9].Visible = false;
            Gridview1.Columns[10].Visible = false;
            Panel_PMPurchaseOrderDetail.Visible = true;
            UpdatePanel_PMPurchaseOrderDetail.Update();
        }
        if (e.CommandName == "Makey")//制定详细表
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview3.SelectedIndex = row.RowIndex;
            PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(e.CommandArgument.ToString());
            labelPurchaseOrderID.Text = e.CommandArgument.ToString();
            BindGridview1(PMPurchaseOrderinfo);

            label5.Text = Gridview3.Rows[Gridview3.SelectedIndex].Cells[2].Text.ToString() + "  " + Gridview3.Rows[Gridview3.SelectedIndex].Cells[3].Text.ToString();
            labelMark.Text = "新增";
            Label6.Text = "新增订单详细表";
            Panel2.Visible = true;
            UpdatePanel2.Update();
            Button11.Visible = false;
            Button14.Visible = true;
            Button17.Visible = true;
            Gridview1.Columns[9].Visible = true;
            Gridview1.Columns[10].Visible = true;
            Panel_PMPurchaseOrderDetail.Visible = true;
            UpdatePanel_PMPurchaseOrderDetail.Update();

        }
    }
    //物料
    protected void Gridview5_RowDataBound(object sender, GridViewRowEventArgs e)
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
    //采购订单详细表
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ButtonChange")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            labelMark.Text = "修改";
            Label_MakeTime.Text = e.CommandArgument.ToString();//详细表ID
            TextBox4.Text = Gridview1.Rows[Gridview1.SelectedIndex].Cells[1].Text.ToString();
            TextBox9.Text = Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString();
            TextBox10.Text = Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString();
            TextBox8.Text = Gridview1.Rows[Gridview1.SelectedIndex].Cells[5].Text.ToString();
            TextBox6.Text = Gridview1.Rows[Gridview1.SelectedIndex].Cells[4].Text.ToString();
            TextBox11.Text = Gridview1.Rows[Gridview1.SelectedIndex].Cells[6].Text.ToString();
            TextBox12.Text = Gridview1.Rows[Gridview1.SelectedIndex].Cells[7].Text.ToString();
            label_MaterialID.Text = Gridview1.DataKeys[Gridview1.SelectedIndex]["IMMBD_MaterialID"].ToString();
            label_IMUC_ID.Text = Gridview1.DataKeys[Gridview1.SelectedIndex]["IMUC_ID"].ToString();
            Label6.Text = label5.Text;
            Panel2.Visible = true;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "ButtonDelete")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            PMPurchaseOrderinfo.PMPOD_PurchaseDetailID = new Guid(e.CommandArgument.ToString());
            pl.DeletePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo);
            PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(labelPurchaseOrderID.Text);
            BindGridview1(PMPurchaseOrderinfo);
            Panel_PMPurchaseOrderDetail.Visible = true;
            UpdatePanel_PMPurchaseOrderDetail.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMPurchaseOrderDetail, GetType(), "aa", "alert('删除成功！')", true);
            return;
        }
    }
    #region//换页
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
        string condition = GetCondition();
        BindGridview3(condition);
        Gridview3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
        Gridview3.PageIndex = newPageIndex;
        Gridview3.DataBind();
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
        BindGridview2("");
        Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }

    protected void Gridview5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview5.BottomPagerRow;


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
        Gridview5.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview5.PageCount ? Gridview5.PageCount - 1 : newPageIndex;
        Gridview5.PageIndex = newPageIndex;
        Gridview5.DataBind();
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
        PMPurchaseOrderinfo.PMPO_PurchaseOrderID = new Guid(labelPurchaseOrderID.Text);
        BindGridview1(PMPurchaseOrderinfo);
        Gridview1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    #endregion
    //采购订单表
    protected void Gridview3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMPO_State"].ToString().Trim() == "已提交")
            {
                e.Row.Cells[19].Enabled = false;
            }
        }
    }
    //遍历
    private void Gridview1_BL()
    {
        decimal Num = 0;
        decimal ActuallNum = 0;
        decimal TotalNum = 0;
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            if (Gridview1.Rows[i].Cells[4].Text.ToString().Trim() != "")
            {

                Num += Convert.ToDecimal(Gridview1.Rows[i].Cells[4].Text.ToString());

            }
            if (Gridview1.Rows[i].Cells[13].Text.ToString().Trim() != "")
            {

                ActuallNum += Convert.ToDecimal(Gridview1.Rows[i].Cells[13].Text.ToString().Trim());

            }
        }
        label_ZS.Text = Convert.ToString(Num);
        label_ActuallNum.Text = Convert.ToString(ActuallNum);//总额
    }

    //检索供应商
    protected void Button1_KiMi(object sender, EventArgs e)
    {
        string condition = GetCondition_Supply();
        BindGridview2(condition);
        UpdatePanel4.Update();
    }
    protected string GetCondition_Supply()
    {
        string condition;
        string item = "";
        if (TextBox7.Text != "")
        {
            item += " and PMSI_SupplyNum='" + TextBox7.Text + "'";
        }
        if (TextBox13.Text != "")
        {
            item += " and PMSI_SupplyName like'%" + TextBox13.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索供应商
    protected void Button_CoMi(object sender, EventArgs e)
    {
        TextBox7.Text = "";
        TextBox13.Text = "";
        BindGridview2("");
        UpdatePanel4.Update();
    }
    protected void Button1_KiM(object sender, EventArgs e)
    {
        string condition = GetCondition_Material();
        BindGridview5(condition);
        UpdatePanel_Material.Update();
    }
    protected string GetCondition_Material()
    {
        string item = "";
        string condition;
        if (TextBox16.Text != "")
        {
            item += "and IMMBD_MaterialName  like '%" + TextBox16.Text.ToString() + "%'";
        }
        if (TextBox17.Text != "")
        {
            item += "and IMMBD_SpecificationModel like '%" + TextBox17.Text.ToString() + "%'";
        }
        condition = item;
        return condition;
    }
    protected void Button_CoM(object sender, EventArgs e)
    {
        TextBox16.Text = "";
        TextBox17.Text = "";
        BindGridview5("");
        UpdatePanel_Material.Update();
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
         //付款方式--预付款情况
        if (DropDownList6.SelectedValue == "预付款" || DropDownList6.SelectedValue == "现金预付款")
        {
            Label27.Visible = true;
            TextBox14.Visible = true;
            Label35.Visible = true;
            UpdatePanel3.Update();
        }
        else
        {
            Label27.Visible = false ;
            TextBox14.Visible = false ;
            Label35.Visible = false ;
            UpdatePanel3.Update();
        }
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
}