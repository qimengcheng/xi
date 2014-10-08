using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_RightTimeSM : System.Web.UI.Page
{
    RightTimeSMD rd = new RightTimeSMD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "订单库存在制品一览表";
            this.label1.Text = "";
            Getcondition();
        }

    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        this.label_Title.Text = "订单库存在制品一览表";
        this.Panel_OAInfo.Visible = true;
        this.label1.Text = "";
    }
    protected string Getcondition()
    {
        string condition = "";
        if(this.TextBox6.Text!="")
        {
            condition += "and PT_Name like '%"+this.TextBox6.Text+"%'";
        }
        if (this.TextBox3.Text != "")
        {
            condition += "and PT_Note like '%" + this.TextBox3.Text + "%'";
        }
        return condition;
    }
    private void BindGridview_OAInfo(string condition)
    {
        this.Gridview_OAInfo.DataSource = rd.SelectRightTimeSM(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button3_Reset(object sender, EventArgs e)
    {
        
        this.TextBox3.Text = "";
      
        this.TextBox6.Text = "";
       
        this.Panel_OAInfo.Visible = false;
        this.Panel1.Visible = false;

    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;

    }
    //打印报表
    protected void Button2_Click1(object sender, EventArgs e)
    {
        string name = "";
        int num = 0;
        if (this.label1.Text == "物料详细表")
        {
            name = this.Gridview_OAInfo.Rows[Gridview_OAInfo.SelectedIndex].Cells[1].Text;
           num = Convert.ToInt32(Convert.ToDecimal(this.Gridview_OAInfo.Rows[Gridview_OAInfo.SelectedIndex].Cells[5].Text));
        }

        Response.Redirect("../REPORT_cc/RightTimeSMPrint.aspx?" + "&Getcondition()=" + Getcondition() + "&name=" + name + "&num" + num);
   
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }

    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Gridview_OAInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Niguo")//详细
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_OAInfo.SelectedIndex = row.RowIndex;
            string name = e.CommandArgument.ToString();
            this.label1.Text = "物料详细表";
            int num = Convert .ToInt32(Convert.ToDecimal(this.Gridview_OAInfo.Rows[row.RowIndex].Cells[5].Text.ToString()));
            this.Gridview1.DataSource = rd.SelectRightTimeMaterial(name,num);
            this.Gridview1.DataBind();
            this.Panel1.Visible = true;
        }
    }
    protected void ButtonClose(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
    }
}