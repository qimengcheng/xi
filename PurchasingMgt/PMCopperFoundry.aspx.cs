using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProjectManagement_PMCopperFoundry : Page
{
    PMCopperFoundryL pf = new PMCopperFoundryL();
    PMSupplyInfo_PMSupplyContactL pl = new PMSupplyInfo_PMSupplyContactL();
    PMCopperFoundryinfo PMCopperFoundryinfo = new PMCopperFoundryinfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "铜材代工";
        if (!((Session["UserRole"].ToString().Contains("铜材代工"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (!IsPostBack)
        {
            
            BindGridview1("");
            UpdatePanel_Copper.Update();
        }
    }
    private void BindGridview1(string condition)
    {
        Gridview1.DataSource = pf.SelectPMCopperFoundry(condition);
        Gridview1.DataBind();
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGridview1(condition);
        UpdatePanel_Copper.Update();
        Panel_CopperNew.Visible = false;
        UpdatePanel_CopperNew.Update();
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
        Panel_CopperIn.Visible = false;
        UpdatePanel_CopperIn.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_CopperInNew.Visible = false;
        UpdatePanel_CopperInNew.Update();
        Panel_CopperReturn.Visible = false;
        UpdatePane_CopperReturn.Update();
        Panel_CopperPrice.Visible = false;
        UpdatePanel_CopperPrice.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string item = "";
        if (TextBox_Factory.Text != "")
        {
            item += " and PMSI_SupplyName like '%" + TextBox_Factory.Text + "%'";
        }
        if (TextBox1.Text != "")
        {
            item += " and PMSI_SupplyNum='" + TextBox1.Text + "'";
        }
        if (TextBox2.Text != "")
        {
            item += " and PMCF_MaterialName like '%" + TextBox2.Text + "%'";
        }
        if (TextBox_Time1.Text != "")
        {
            item += "and PMCF_Time>='" + TextBox_Time1.Text + "'";

        }
        if (TextBox_Time2.Text != "" && TextBox_Time1.Text != "")
        {
            item += "and PMCF_Time>='" + TextBox_Time1.Text + "'" + "and PMCF_Time<='" + TextBox_Time2.Text + "'";
        }
        condition = item;
        label_QA.Text = condition;
        return condition;
    }
    //新增
    protected void Button3_New(object sender, EventArgs e)
    {
        Panel_CopperNew.Visible = true;
        label_New.Text = "新增铜材代工表";
        UpdatePanel_CopperNew.Update();
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        BindGridview1("");
        UpdatePanel_Copper.Update();
        TextBox_Factory.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox_Time1.Text = "";
        TextBox_Time2.Text = "";
        UpdatePanel_CopperFoundrySearch.Update();
    }
    //正料表绑定
    private void BindGridview2(PMCopperFoundryinfo PMCopperFoundryinfo)
    {
        Gridview2.DataSource = pf.SelectPMCopperIn(PMCopperFoundryinfo);
        Gridview2.DataBind();
    }
    //退料表绑定
    private void BindGridview3(PMCopperFoundryinfo PMCopperFoundryinfo)
    {
        Gridview3.DataSource = pf.SelectPMCopperReturn(PMCopperFoundryinfo);
        Gridview3.DataBind();
    }
    //加工价格表绑定
    private void BindGridview4(PMCopperFoundryinfo PMCopperFoundryinfo)
    {
        Gridview4.DataSource = pf.SelectPMCopperProcess(PMCopperFoundryinfo);
        Gridview4.DataBind();
    }
    //铜材代工表的修改、正料、退料、加工
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Mody")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_CopperID.Text = e.CommandArgument.ToString();
            label_New.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString();
            TextBox4.Text = Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString();
            TextBox3.Text = Gridview1.Rows[row.RowIndex].Cells[4].Text.ToString();
            TextBox5.Text = Gridview1.Rows[row.RowIndex].Cells[5].Text.ToString();
            TextBox6.Text = Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString();
            label_SupplyID.Text = Gridview1.Rows[row.RowIndex].Cells[12].Text.ToString();
            Panel_CopperNew.Visible = true;
            UpdatePanel_CopperNew.Update();
        }
        if (e.CommandName == "CopperIn")//正料
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_CopperID.Text = e.CommandArgument.ToString();
            PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
            BindGridview2(PMCopperFoundryinfo);
            label13.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString();
            Panel_CopperIn.Visible = true;
            UpdatePanel_CopperIn.Update();
        }
        if (e.CommandName == "Return")//退料
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_CopperID.Text = e.CommandArgument.ToString();
            label22.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString();
            PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
            BindGridview3(PMCopperFoundryinfo);
            Panel1.Visible = true;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "ADD")//加工
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label27.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString();
            label_CopperID.Text = e.CommandArgument.ToString();
            PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
            BindGridview4(PMCopperFoundryinfo);
            Panel2.Visible = true;
            UpdatePanel2.Update();
        }
    }
    //绑定供应商列表
    private void BindGridview_PMSupply(string Condition)
    {
        try
        {
            Gridview_PMSupply.DataSource = pl.SelectPMSupplyInfo(Condition);
            Gridview_PMSupply.DataBind();
        }
        catch (Exception)
        {
            throw;

        }
    }
    //选择供应商
    protected void Button_SupplySearch(object sender, EventArgs e)
    {
        BindGridview_PMSupply("");
        Panel_Supply.Visible = true;
        UpdatePanel_Supply.Update();
    }
    //提交铜材代工表
    protected void Button1_Com1(object sender, EventArgs e)
    {
        if (TextBox4.Text != "")
        {
            PMCopperFoundryinfo.PMCF_MaterialName = TextBox4.Text;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox3.Text != "")
        {
            PMCopperFoundryinfo.PMCF_ReturnTotalNum = Convert.ToDecimal(TextBox3.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox5.Text != "")
        {
            PMCopperFoundryinfo.PMCF_InTotalNum = Convert.ToDecimal(TextBox5.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox6.Text != "")
        {
            PMCopperFoundryinfo.PMSI_ID = new Guid(label_SupplyID.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (label_New.Text == "新增铜材代工表")
        {
            pf.InsertPMCopperFoundry(PMCopperFoundryinfo);
        }
        else
        {
            PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
            pf.UpdatePMCopperFoundry(PMCopperFoundryinfo);
        }
        TextBox4.Text = "";
        TextBox3.Text = "";
        TextBox6.Text = "";
        TextBox5.Text = "";
        Panel_CopperNew.Visible = false;
        UpdatePanel_CopperNew.Update();
        BindGridview1("");
        UpdatePanel_Copper.Update();
    }
    //取消填写铜材代工
    protected void Button_Cancel(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox3.Text = "";
        TextBox6.Text = "";
        TextBox5.Text = "";
        Panel_CopperNew.Visible = false;
        UpdatePanel_CopperNew.Update();
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
                Pname = Gridview_PMSupply.Rows[item.RowIndex].Cells[3].Text.ToString();
                temp = true;
                label_SupplyID.Text = Gridview_PMSupply.DataKeys[item.RowIndex].Value.ToString();
                TextBox6.Text = Pname;
                UpdatePanel_CopperNew.Update();
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Supply, GetType(), "aa", "alert('请选择供应商')", true);
            return;
        }
        else
        {
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
        }
    }
    //取消供应商查询
    protected void Button_CancelSP(object sender, EventArgs e)
    {
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    //新增铜材正料
    protected void Button_lio(object sender, EventArgs e)
    {
        TextBox7.Enabled = true;
        TextBox8.Enabled = true;
        TextBox22.Enabled = true;
        Panel_CopperInNew.Visible = true;
        label_CopperIn.Text = "新增";
        UpdatePanel_CopperInNew.Update();
    }
    //取消新增铜材正料
    protected void Button_CRocky(object sender, EventArgs e)
    {
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox10.Text = "";
        TextBox22.Text = "";
        DropDownList4.SelectedValue = "请选择";
        Panel_CopperInNew.Visible = false;
        UpdatePanel_CopperInNew.Update();
    }
    //取消铜材正料
    protected void Button_Clio(object sender, EventArgs e)
    {
        Panel_CopperIn.Visible = false;
        UpdatePanel_CopperIn.Update();
        Panel_CopperInNew.Visible = false;
        UpdatePanel_CopperInNew.Update();
    }
    //铜材正料--修改、删除
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Merry")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_CopperIn.Text = "修改";
            label_CopperInID.Text = e.CommandArgument.ToString();
            TextBox7.Text = Gridview2.Rows[Gridview2.SelectedIndex].Cells[2].Text.ToString();
            TextBox8.Text = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
            TextBox9.Text = Gridview2.Rows[Gridview2.SelectedIndex].Cells[4].Text.ToString();
            TextBox11.Text = Gridview2.Rows[Gridview2.SelectedIndex].Cells[5].Text.ToString();
            TextBox12.Text = Gridview2.Rows[Gridview2.SelectedIndex].Cells[7].Text.ToString();
            DropDownList4.SelectedValue = Gridview2.Rows[Gridview2.SelectedIndex].Cells[9].Text.ToString();
            TextBox10.Text = Gridview2.Rows[Gridview2.SelectedIndex].Cells[8].Text.ToString();
            TextBox22.Text = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            TextBox7.Enabled = false;
            TextBox8.Enabled = false;
            TextBox22.Enabled = false;
            Panel_CopperInNew.Visible = true;
            UpdatePanel_CopperInNew.Update();
        }
        if (e.CommandName == "Denol")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_CopperInID.Text = e.CommandArgument.ToString();
            PMCopperFoundryinfo.PMCI_ID = new Guid(e.CommandArgument.ToString());
            PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
            PMCopperFoundryinfo.PMCI_ExpendNum = Convert.ToDecimal(Gridview2.Rows[Gridview2.SelectedIndex].Cells[6].Text.ToString());
            pf.DeletePMCopperIn(PMCopperFoundryinfo);
            BindGridview2(PMCopperFoundryinfo);
            BindGridview1("");
            UpdatePanel_Copper.Update();
            Panel_CopperIn.Visible = true;
            UpdatePanel_CopperIn.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperIn, GetType(), "aa", "alert('删除成功！')", true);
            return;
        }
    }
    //新增退料
    protected void Button_NewZy(object sender, EventArgs e)
    {
        TextBox13.Enabled = true;
        TextBox14.Enabled = true;
        label_CopperRT.Text = "新增";
        Panel_CopperReturn.Visible = true;
        UpdatePane_CopperReturn.Update();
    }
    //取消退料
    protected void Button_CNewZy(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_CopperReturn.Visible = false;
        UpdatePane_CopperReturn.Update();
    }
    //退料表--删除、修改
    protected void Gridview3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Mole")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview3.SelectedIndex = row.RowIndex;
            label_CopperRT.Text = "修改";
            label_CopperReturnID.Text = e.CommandArgument.ToString();
            Panel_CopperReturn.Visible = true;
            TextBox13.Text = Gridview3.Rows[Gridview3.SelectedIndex].Cells[1].Text.ToString();
            TextBox14.Text = Gridview3.Rows[Gridview3.SelectedIndex].Cells[2].Text.ToString();
            TextBox18.Text = Gridview3.Rows[Gridview3.SelectedIndex].Cells[5].Text.ToString();
            TextBox13.Enabled = false;
            TextBox14.Enabled = false;
            UpdatePane_CopperReturn.Update();
            
        }
        if (e.CommandName == "Dani")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview3.SelectedIndex = row.RowIndex;
            label_CopperReturnID.Text = e.CommandArgument.ToString();
            PMCopperFoundryinfo.PMCR_ID = new Guid(e.CommandArgument.ToString());
            PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
            PMCopperFoundryinfo.PMCR_NetNum = Convert.ToDecimal(Gridview3.Rows[Gridview3.SelectedIndex].Cells[4].Text.ToString());
            pf.DeletePMCopperReturn(PMCopperFoundryinfo);
            BindGridview3(PMCopperFoundryinfo);
            BindGridview1("");
            UpdatePanel_Copper.Update();
            Panel1.Visible = true;
            UpdatePanel1.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, GetType(), "aa", "alert('删除成功！')", true);
            return;

        }
    }
    //新增铜材加工价格
    protected void Button_Price(object sender, EventArgs e)
    {
        label_CopperPrice.Text = "新增";
        Panel_CopperPrice.Visible = true;
        UpdatePanel_CopperPrice.Update();
    }
    //取消铜材加工
    protected void Button_CPrice(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_CopperPrice.Visible = false;
        UpdatePanel_CopperPrice.Update();
    }
    //铜材加工价格表--修改、删除
    protected void Gridview4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Cody")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            label_CopperPriceID.Text = e.CommandArgument.ToString();
            label_CopperPrice.Text = "修改";
            TextBox16.Text = Gridview4.Rows[Gridview4.SelectedIndex].Cells[1].Text.ToString();
            TextBox17.Text = Gridview4.Rows[Gridview4.SelectedIndex].Cells[2].Text.ToString();
            TextBox19.Text = Gridview4.Rows[Gridview4.SelectedIndex].Cells[3].Text.ToString();
            TextBox20.Text = Gridview4.Rows[Gridview4.SelectedIndex].Cells[4].Text.ToString();
            TextBox21.Text = Gridview4.Rows[Gridview4.SelectedIndex].Cells[5].Text.ToString();
            TextBox15.Text = Gridview4.Rows[Gridview4.SelectedIndex].Cells[8].Text.ToString();
            DropDownList1.SelectedValue = Gridview4.Rows[Gridview4.SelectedIndex].Cells[7].Text.ToString();
            Panel_CopperPrice.Visible = true;
            UpdatePanel_CopperPrice.Update();
        }
        if (e.CommandName == "Boly")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            label_CopperPriceID.Text = e.CommandArgument.ToString();
            PMCopperFoundryinfo.PMCP_ID = new Guid(e.CommandArgument.ToString());
            pf.DeletePMCopperProcess(PMCopperFoundryinfo);
            PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
            BindGridview4(PMCopperFoundryinfo);
            Panel2.Visible = true;
            UpdatePanel2.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel2, GetType(), "aa", "alert('删除成功！')", true);
            return;
        }
    }
    //提交正料
    protected void Button_Rocky(object sender, EventArgs e)
    {
        if (TextBox7.Text != "")
        {
            PMCopperFoundryinfo.PMCI_ProductNum = Convert.ToDecimal(TextBox7.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox8.Text != "")
        {
            PMCopperFoundryinfo.PMCI_ProPrice = Convert.ToDecimal(TextBox8.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox9.Text != "")
        {
            PMCopperFoundryinfo.PMCI_BillTotalPrice = Convert.ToDecimal(TextBox9.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox11.Text != "")
        {
            PMCopperFoundryinfo.PMCI_AccountRate = Convert.ToDecimal(TextBox11.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox12.Text != "")
        {
            PMCopperFoundryinfo.PMCI_BillNum = TextBox12.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (DropDownList4.SelectedValue != "请选择")
        {
            PMCopperFoundryinfo.PMCI_Pay = DropDownList4.SelectedValue.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox10.Text != "")
        {
            PMCopperFoundryinfo.PMCI_Remark = TextBox10.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox22.Text != "")
        {
            PMCopperFoundryinfo.PMCI_Model = TextBox22.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperInNew, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text.ToString());
        if (label_CopperIn.Text == "新增")
        {
            pf.InsertPMCopperIn(PMCopperFoundryinfo);
        }
        if (label_CopperIn.Text == "修改")
        {
            PMCopperFoundryinfo.PMCI_ID = new Guid(label_CopperInID.Text.ToString());
            pf.UpdatePMCopperIn(PMCopperFoundryinfo);
        }
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox10.Text = "";
        TextBox22.Text = "";
        DropDownList4.SelectedValue = "请选择";
        Panel_CopperInNew.Visible = false;
        UpdatePanel_CopperInNew.Update();
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
        BindGridview2(PMCopperFoundryinfo);
        UpdatePanel_CopperIn.Update();
        BindGridview1("");
        UpdatePanel_Copper.Update();
    }
    //提交退料
    protected void Button_Rois(object sender, EventArgs e)
    {
        if (TextBox13.Text != "")
        {
            PMCopperFoundryinfo.PMCR_Num = Convert.ToDecimal(TextBox13.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePane_CopperReturn, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox14.Text != "")
        {
            PMCopperFoundryinfo.PMCR_DeductRate = Convert.ToDecimal(TextBox14.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePane_CopperReturn, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox18.Text != "")
        {
            PMCopperFoundryinfo.PMCR_Remark = TextBox18.Text;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePane_CopperReturn, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text.ToString());
        if (label_CopperRT.Text == "新增")
        {
            pf.InsertPMCopperReturn(PMCopperFoundryinfo);
        }
        if (label_CopperRT.Text == "修改")
        {
            PMCopperFoundryinfo.PMCR_ID = new Guid(label_CopperReturnID.Text);
            pf.UpdatePMCopperReturn(PMCopperFoundryinfo);
        }
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox18.Text = "";
        Panel_CopperReturn.Visible = false;
        UpdatePane_CopperReturn.Update();
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
        BindGridview3(PMCopperFoundryinfo);
        UpdatePanel1.Update();
        BindGridview1("");
        UpdatePanel_Copper.Update();
    }
    //取消填写退料
    protected void Button_CRois(object sender, EventArgs e)
    {
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox18.Text = "";
        Panel_CopperReturn.Visible = false;
        UpdatePane_CopperReturn.Update();
    }
    //提交加工价格
    protected void Button_Meky(object sender, EventArgs e)
    {
        if (TextBox16.Text != "")
        {
            PMCopperFoundryinfo.PMCP_CopperPrice = Convert.ToDecimal(TextBox16.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperPrice, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox17.Text != "")
        {
            PMCopperFoundryinfo.PMCP_CopperDiscountRate = Convert.ToDecimal(TextBox17.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperPrice, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox19.Text != "")
        {
            PMCopperFoundryinfo.PMCP_ZnPrice = Convert.ToDecimal(TextBox19.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperPrice, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox20.Text != "")
        {
            PMCopperFoundryinfo.PMCP_ZnDiscountRate = Convert.ToDecimal(TextBox20.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperPrice, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox21.Text != "")
        {
            PMCopperFoundryinfo.PMCP_ProcessCost = Convert.ToDecimal(TextBox21.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperPrice, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox15.Text != "")
        {
            PMCopperFoundryinfo.PMCP_AccountRate = Convert.ToDecimal(TextBox15.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperPrice, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (DropDownList1.SelectedValue != "请选择")
        {
            PMCopperFoundryinfo.PMCP_NowPrice = DropDownList1.SelectedValue.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_CopperPrice, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
        if (label_CopperPrice.Text == "新增")
        {
            PMCopperFoundryinfo.PMCP_MakeMan = Session["UserName"].ToString();
            pf.InsertPMCopperProcess(PMCopperFoundryinfo);
        }
        if (label_CopperPrice.Text == "修改")
        {
            PMCopperFoundryinfo.PMCP_ID = new Guid(label_CopperPriceID.Text);
            pf.UpdatePMCopperProcess(PMCopperFoundryinfo);
        }
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox19.Text = "";
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox15.Text = "";
        DropDownList1.SelectedValue = "请选择";
        Panel_CopperPrice.Visible = false;
        UpdatePanel_CopperPrice.Update();
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
        BindGridview4(PMCopperFoundryinfo);
        UpdatePanel2.Update();
    }
    //取消加工价格
    protected void Button_CMeky(object sender, EventArgs e)
    {
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox19.Text = "";
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox15.Text = "";
        DropDownList1.SelectedValue = "请选择";
        Panel_CopperPrice.Visible = false;
        UpdatePanel_CopperPrice.Update();
    }
    #region//换页
    protected void Gridview_Project_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        string Condition = GetCondition();
        BindGridview1(Condition);
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
        Gridview_PMSupply.DataBind();
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
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
        BindGridview2(PMCopperFoundryinfo);
        Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
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
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
        BindGridview3(PMCopperFoundryinfo);
        Gridview3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
        Gridview3.PageIndex = newPageIndex;
        Gridview3.DataBind();
    }
    protected void Gridview4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview4.BottomPagerRow;


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
        PMCopperFoundryinfo.PMCF_ID = new Guid(label_CopperID.Text);
        BindGridview4(PMCopperFoundryinfo);
        Gridview4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview4.PageCount ? Gridview4.PageCount - 1 : newPageIndex;
        Gridview4.PageIndex = newPageIndex;
        Gridview4.DataBind();
    }
    #endregion
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
        if (TextBox23.Text != "")
        {
            item += " and PMSI_SupplyNum='" + TextBox23.Text + "'";
        }
        if (TextBox24.Text != "")
        {
            item += " and PMSI_SupplyName like'%" + TextBox24.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索供应商
    protected void Button_CoMi(object sender, EventArgs e)
    {
        TextBox23.Text = "";
        TextBox24.Text = "";
        BindGridview_PMSupply("");
        UpdatePanel_Supply.Update();
    }
}