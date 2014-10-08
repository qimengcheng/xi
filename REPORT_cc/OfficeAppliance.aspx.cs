using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class PurchasingMgt_OfficeAppliance : Page
{
    OfficeAppianceD od = new OfficeAppianceD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Title = "办公用品申请汇总";
            
        }

    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        Decimal dl = 0;
        string condition = "";
        if (TextBox_SPTime2.Text != "" && TextBox_SPTime3.Text == "")
         {
         condition += "and PMPAM_ApplyTime >='" + TextBox_SPTime2.Text + "'";
          }
        if (TextBox_SPTime2.Text == "" && TextBox_SPTime3.Text != "")
        {
            condition += "and PMPAM_ApplyTime <='" + TextBox_SPTime3.Text + "'";
        }
        if (TextBox_SPTime2.Text != "" && TextBox_SPTime3.Text != "")
        {
            condition += "and PMPAM_ApplyTime >='" + TextBox_SPTime2.Text + "'" + "and PMPAM_ApplyTime <='" + TextBox_SPTime3.Text + "'";
        }
       
          BindGridview_OAInfo(condition);
          label_Title.Text = "办公用品申请汇总表";
     
          //  foreach(GridViewRow item in Gridview_OAInfo.Rows)
          //  {
          //   dl+=Convert.ToDecimal(this.Gridview_OAInfo.Rows[item.RowIndex].Cells[4].Text);
          //  }
          //this.label_Num.Text = Convert.ToString(dl);
        
          Panel_OAInfo.Visible = true;
        
        }
    
    private void BindGridview_OAInfo(string condition)
    {
        Gridview_OAInfo.DataSource = od.SelectOfficeAppliance(condition);
        Gridview_OAInfo.DataBind();
    }
    protected void Button3_Reset(object sender, EventArgs e)
    {
        TextBox_SPTime2.Text = "";
        TextBox_SPTime3.Text = "";
      
    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_OAInfo.Visible = false;
    
    }
    //打印报表
    protected void Button2_Click1(object sender, EventArgs e)
    {

        Response.Redirect("../REPORT_cc/OfficeAppliancePrint.aspx?" + "&PMPAM_ApplyTime1=" + TextBox_SPTime2.Text + "&PMPAM_ApplyTime2=" + TextBox_SPTime3.Text);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }

    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string condition = "";
        if (TextBox_SPTime2.Text != "" && TextBox_SPTime3.Text == "")
        {
            condition += "and PMPAM_ApplyTime >='" + TextBox_SPTime2.Text + "'";
        }
        if (TextBox_SPTime2.Text == "" && TextBox_SPTime3.Text != "")
        {
            condition += "and PMPAM_ApplyTime <='" + TextBox_SPTime3.Text + "'";
        }
        if (TextBox_SPTime2.Text != "" && TextBox_SPTime3.Text != "")
        {
            condition += "and PMPAM_ApplyTime >='" + TextBox_SPTime2.Text + "'" + "and PMPAM_ApplyTime <='" + TextBox_SPTime3.Text + "'";
        }
        DataSet ds = od.SelectOfficeAppliance_Sum(condition);
        DataTable dt = ds.Tables[0];
        if(dt.Rows.Count>0)
        {
            label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计数量";
            if (TextBox_SPTime2.Text != "" || TextBox_SPTime3.Text != "")
            {
                e.Row.Cells[4].Text = label_Num.Text.ToString();
            }
        }
    }

}