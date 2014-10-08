using System;
using System.Web.UI;

public partial class PurchasingMgt_PRMProject_IsFinish : Page
{
    PRMProject_IsFinishD pd = new PRMProject_IsFinishD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "如期完成的项目汇总";
            Getcondition();
        }
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        label_Title.Text = "共" + Gridview_OAInfo.Rows.Count + "个项目";
        Panel_OAInfo.Visible = true;
    }
    private void BindGridview_OAInfo(string condition)
    {
        Gridview_OAInfo.DataSource = pd.SelectPRMProject_IsFinish(condition);
        Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition = "";
        if(TextBox1.Text !="")
        {
            condition += "and PRMP_ProjectNum='"+TextBox1.Text+"'";
        }
        if(TextBox_SPTime2.Text!="")
        {
            condition += "and PRMP_ProjectName like '%" + TextBox_SPTime2.Text + "%'";
        }
        if(TextBox2.Text!="")
        {
            condition+="and PRMP_ProjectType like'%"+TextBox2.Text+"%'";
        }
        if(DropDownList4.SelectedValue=="是")
        {
         condition+="and PRMP_ProjectStates='"+"已完成"+"'";
        }
        else//否
        {
        condition+="and dateadd(D,ProjectPTime,ProjectSTime)<=GETDATE() and PRMP_ProjectStates !='"+"已完成"+"'";
        }
        if(TextBox3.Text!=""&&TextBox_SPTime3.Text!="")
        {
        condition +="and dateadd(D,ProjectPTime,ProjectSTime)>="+TextBox3.Text+"'"+"and dateadd(D,ProjectPTime,ProjectSTime)<="+TextBox_SPTime3.Text+"'";
        }
        if (TextBox3.Text == "" && TextBox_SPTime3.Text != "")
        {
            condition +="and dateadd(D,ProjectPTime,ProjectSTime)<=" + TextBox_SPTime3.Text + "'";
        }
        if (TextBox3.Text != "" && TextBox_SPTime3.Text == "")
        {
            condition += "and dateadd(D,ProjectPTime,ProjectSTime)>=" + TextBox3.Text + "'";
        }
        return condition;
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox_SPTime2.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox_SPTime3.Text = "";
        DropDownList4.SelectedValue="是";
        Panel_OASearch.Visible = true;
        Panel_OAInfo.Visible = false;

    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/PRMProject_IsFinishPrint.aspx?" + "&ProjectPlTime1=" + TextBox3.Text + "&ProjectPlTime2=" + TextBox_SPTime3.Text+"&Getcondition()="+Getcondition());
    }
}