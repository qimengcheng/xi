using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SalesOrderPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        //下单时间
        if (Request.QueryString["TextBox6"] == null || Request.QueryString["TextBox6"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["TextBox6"];
        }
        if (Request.QueryString["TextBox7"] == null || Request.QueryString["TextBox7"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["TextBox7"];
        }
        //交货时间
        if (Request.QueryString["TextBox8"] == null || Request.QueryString["TextBox8"] == "")
        {
            Label9.Text = "始";
        }
        else
        {
            Label9.Text = Request.QueryString["TextBox8"];
        }
        if (Request.QueryString["TextBox9"] == null || Request.QueryString["TextBox9"] == "")
        {
            Label11.Text = "今";
        }
        else
        {
            Label11.Text = Request.QueryString["TextBox9"];
        }
        //绑定
        string CRMCIF_Name = Request.QueryString["CRMCIF_Name"];
        string SMSO_ComOrderNum = Request.QueryString["SMSO_ComOrderNum"];
        string SMSO_CusOrderNum = Request.QueryString["SMSO_CusOrderNum"];
        string PT_Name = Request.QueryString["PT_Name"];
        string SMSOD_DelCondition = Request.QueryString["SMSOD_DelCondition"];
        string TextBox6 = Request.QueryString["TextBox6"];
        string TextBox7 = Request.QueryString["TextBox7"];
        string TextBox8 = Request.QueryString["TextBox8"];
        string TextBox9 = Request.QueryString["TextBox9"];

        string condition = "";
        string temp = "";
        if (CRMCIF_Name != "")
        {
            temp += " and CRMCIF_Name like '%" + CRMCIF_Name + "%'";
        }
        if (SMSO_ComOrderNum != "")
        {
            temp += " and SMSO_ComOrderNum like '%" + SMSO_ComOrderNum + "%'";
        }
        if (SMSO_CusOrderNum != "")
        {
            temp += " and SMSO_CusOrderNum like '%" + SMSO_CusOrderNum + "%'";
        }
        if (PT_Name != "")
        {
            temp += " and PT_Name like '%" + PT_Name + "%'";
        }
        if (SMSOD_DelCondition != "")
        {
            temp += " and SMSOD_DelCondition like '%" + SMSOD_DelCondition + "%'";
        }
        //下单时间
        if (TextBox6 != "" && TextBox7 != "")
        {
            temp += " and SMSO_PlaceOrderTime >= '" + TextBox6 + "' and SMSO_PlaceOrderTime <= '" + TextBox7 + "'";
        }
        if (TextBox6 != "" && TextBox7 == "")
        {
            temp += " and SMSO_PlaceOrderTime >= '" + TextBox6 + "'";
        }
        if (TextBox6 == "" && TextBox7 != "")
        {
            temp += " and SMSO_PlaceOrderTime <= '" + TextBox7 + "'";
        }
        if (TextBox6 == "" && TextBox7 == "")
        {
            temp += "";
        }
        //交货时间
        if (TextBox8 != "" && TextBox9 != "")
        {
            temp += " and SMOD_Time >= '" + TextBox8 + "' and SMOD_Time <= '" + TextBox9 + "'";
        }
        if (TextBox8 != "" && TextBox9 == "")
        {
            temp += " and SMOD_Time >= '" + TextBox8 + "'";
        }
        if (TextBox8 == "" && TextBox9 != "")
        {
            temp += " and SMOD_Time <= '" + TextBox9 + "'";
        }
        if (TextBox8 == "" && TextBox9 == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_SalesOrderFinish(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SalesOrder.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "订单完成情况统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}