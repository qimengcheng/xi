using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_QuitInfo : System.Web.UI.Page
{
    QuitInfoD qd = new QuitInfoD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "离职日报表";
        }

    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        this.label_Title.Text = "离职日报表";
        this.Panel_OAInfo.Visible = true;

    }
    protected string Getcondition()
    {
        string condition = "";
        if (this.TextBox1.Text != "")
        {
            condition += "and HRDD_StaffNO='"+this.TextBox1.Text+"'";
        }
        if(this.TextBox2.Text!="")
        {
            condition += "and HRDD_Name like'%"+this.TextBox2.Text+"%'";
        }
        if (this.TextBox3.Text != "")
        {
            condition += "and BDOS_Name like'%" + this.TextBox3.Text + "%'";
        }
        if (this.TextBox4.Text != "")
        {
            condition += "and HRP_Post like'%" + this.TextBox4.Text + "%'";
        }
        if (this.TextBox5.Text != "")
        {
            condition += "and HRDD_QuitRes like'%" + this.TextBox5.Text + "%'";
        }
        if (this.TextBox6.Text != "")
        {
            condition += "and HRDD_QuitMan like'%" + this.TextBox6.Text + "%'";
        }
        //离职
        if (this.TextBox_SPTime2.Text != "" && this.TextBox_SPTime3.Text == "")
        {
            condition += "and HRDD_QuitTime >='" + this.TextBox_SPTime2.Text + "'";
        }
        if (this.TextBox_SPTime2.Text == "" && this.TextBox_SPTime3.Text != "")
        {
            condition += "and HRDD_QuitTime <='" + this.TextBox_SPTime3.Text + "'";
        }
        if (this.TextBox_SPTime2.Text != "" && this.TextBox_SPTime3.Text != "")
        {
            condition += "and HRDD_QuitTime >='" + this.TextBox_SPTime2.Text + "'" + "and HRDD_QuitTime <='" + this.TextBox_SPTime3.Text + "'";
        }
        //入职
        if (this.TextBox7.Text != "" && this.TextBox8.Text == "")
        {
            condition += "and HRDD_EntryDate >='" + this.TextBox7.Text + "'";
        }
        if (this.TextBox7.Text == "" && this.TextBox8.Text != "")
        {
            condition += "and HRDD_EntryDate <='" + this.TextBox8.Text + "'";
        }
        if (this.TextBox7.Text != "" && this.TextBox8.Text != "")
        {
            condition += "and HRDD_EntryDate >='" + this.TextBox7.Text + "'" + "and HRDD_EntryDate <='" + this.TextBox8.Text + "'";
        }
        return condition;
    }
    private void BindGridview_OAInfo(string condition)
    {
        this.Gridview_OAInfo.DataSource = qd.SelectQuitInfo(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        this.TextBox3.Text = "";
        this.TextBox4.Text = "";
        this.TextBox5.Text = "";
        this.TextBox6.Text = "";
        this.TextBox7.Text = "";
        this.TextBox8.Text = "";
        this.TextBox_SPTime2.Text = "";
        this.TextBox_SPTime3.Text = "";
        this.Panel_OAInfo.Visible = false;

    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;

    }
    //打印报表
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/QuitInfoPrint.aspx?" + "&Getcondition()=" + Getcondition());
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }

    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }

}