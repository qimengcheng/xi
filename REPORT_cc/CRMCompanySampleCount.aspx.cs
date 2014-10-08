using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_CRMCompanySampleCount : Page
{
    CRMCompanySampleCountD cd = new CRMCompanySampleCountD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "每月样品统计";
        Panel_OASearch.Visible = true;
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        Panel_OAInfo.Visible = true;
        DataSet ds = cd.SelectCRMCompanySampleCount_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            label_Num.Text = dt.Rows[0][0].ToString();
        }
        
    }
    private void BindGridview_OAInfo(string condition)
    {
        Gridview_OAInfo.DataSource = cd.SelectCRMCompanySampleCount(condition);
        Gridview_OAInfo.DataBind();
    }
    private string Getcondition()
    {
        string condition="";
        if (TextBox1.Text != "")
        { 
        condition+=" and PT_Name like '%"+TextBox1.Text+"%'";
        }
        if(TextBox2.Text!="")
        {
        condition+=" and CRMCS_MakeMan like '%"+TextBox2.Text+"%'";
        }
        if(TextBox3.Text!="")
        {
        condition+=" and Client_Name like '%"+TextBox3.Text+"%'";
        }
        if (TextBox_SPTime2.Text != "" && TextBox_SPTime3.Text != "")
        {
            condition += " and CRMCSS_Time>='" + TextBox_SPTime2.Text + "' and CRMCSS_Time<='" + TextBox_SPTime3.Text + "'";
        }
        if (TextBox_SPTime2.Text != "" && TextBox_SPTime3.Text == "")
        {
            condition += " and CRMCSS_Time>='" + TextBox_SPTime2.Text + "'";
        }
        if (TextBox_SPTime2.Text == "" && TextBox_SPTime3.Text != "")
        {
            condition += " and CRMCSS_Time<='" + TextBox_SPTime3.Text + "'";
        }
        return condition;
   
        
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        TextBox_SPTime2.Text = "";
        TextBox_SPTime3.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/CRMCompanySampleCountPrint.aspx?" + "&Time1=" + TextBox_SPTime2.Text + "&Time2=" + TextBox_SPTime3.Text + "&Getcondition()=" + Getcondition());
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计数量";
                e.Row.Cells[3].Text = label_Num.Text.ToString();
        }
    }
}