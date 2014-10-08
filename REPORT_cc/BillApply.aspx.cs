using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_BillApply : System.Web.UI.Page
{
    BillApplyD bd = new BillApplyD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "开票申请汇总表";
        this.Panel_OASearch.Visible = true;
        Getcondition();
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        this.label_Title.Text = "开票申请汇总表";
        BindGridview_OAInfo(condition);
        BindGriview1("");
        this.Panel_OAInfo.Visible = true;
        this.UpdatePanel2.Update();
        this.Panel1.Visible = true;
        this.UpdatePanel1.Update();
        
    }
    private void BindGridview_OAInfo(string condition)
    {
        this.Gridview_OAInfo.DataSource = bd.SelectBillApply(condition);
        this.Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.TextBox4.Text != "")
        {
            condition += "and SMSOD_MCode like'%" + this.TextBox4.Text + "%'";
        }
        if (this.TextBox3.Text != "")
        {
            condition += "and CRMCIF_Name like'%" + this.TextBox3.Text + "%'";
        }
        if (this.TextBox1.Text != "")
        {
            condition += "and PT_Name like'%" + this.TextBox1.Text + "%'";
        }
        return condition;
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        this.TextBox3.Text = "";
        this.TextBox4.Text = "";
    
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        bool temp = false;
        foreach (GridViewRow item in Gridview_OAInfo.Rows)
        {
            CheckBox cb = item.FindControl("CheckMarkup") as CheckBox;
            if(cb.Checked)
            {
                Guid gd = new Guid(this.Gridview_OAInfo.DataKeys[item.RowIndex].Value.ToString());
                bd.UpdateBillApply(gd);
                temp=true;
            }

        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('请选择开票申请单')", true);
            return;
        }
        else
        {
            string condition = Getcondition();
            BindGridview_OAInfo(condition);
            BindGriview1("");
            this.Panel1.Visible = true;
            this.UpdatePanel1.Update();
            this.UpdatePanel2.Update();
        }
    }
    private void BindGriview1(string condition)
    {
        this.Gridview1.DataSource = bd.SelectBillApply_Biaoji(condition);
        this.Gridview1.DataBind();
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../PurchasingMgt/BillApplyPrint.aspx?" + "&Getcondition()=" + Getcondition());
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    //全部删除
    protected void Button_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gridview1.Rows)
        {
            Guid gd = new Guid(this.Gridview1.DataKeys[item.RowIndex].Value.ToString());
            bd.UpdateBillApply_Delete(gd);
            this.Panel1.Visible = false;
            this.UpdatePanel1.Update();
        }
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        this.UpdatePanel2.Update();
    }
}