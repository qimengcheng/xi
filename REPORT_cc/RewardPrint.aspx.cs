using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_RewardPrint : System.Web.UI.Page
{
    HRDDetailL hRDDetailL = new HRDDetailL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        
        //绑定
        string HRDD_StaffNO = Request.QueryString["HRDD_StaffNO"];
        string HRDD_Name = Request.QueryString["HRDD_Name"];
        string HRET_EmpType = Request.QueryString["HRET_EmpType"];
        string BDOS_Name = Request.QueryString["BDOS_Name"];
        string HRP_Post = Request.QueryString["HRP_Post"];
        string HRRewards_Type = Request.QueryString["HRRewards_Type"];
        string HRRewards_Time1 = Request.QueryString["HRRewards_Time1"];
        string HRRewards_Time2 = Request.QueryString["HRRewards_Time2"];
        string HRRewards_Money = Request.QueryString["HRRewards_Money"];
        string HRRewards_OkTime1 = Request.QueryString["HRRewards_OkTime1"];
        string HRRewards_OkTime2 = Request.QueryString["HRRewards_OkTime2"];
        string HRRewards_Agree = Request.QueryString["HRRewards_Agree"];
        string HRRewards_Content = Request.QueryString["HRRewards_Content"];

        string condition = "";
        condition = HRDD_StaffNO == "" ? "" : " and HRDD_StaffNO like '%" + HRDD_StaffNO + "%'";
        condition += HRDD_Name == "" ? "" : " and HRDD_Name like '%" + HRDD_Name + "%'";
        condition += BDOS_Name == "" ? "" : " and b.BDOS_Code ='" + BDOS_Name + "'";
        condition += HRP_Post == "" ? "" : " and a.HRP_ID ='" + HRP_Post + "'";
        condition += HRET_EmpType == "" ? "" : " and a.HRET_ID ='" + HRET_EmpType + "'";
        condition += HRRewards_Type == "" ? "" : " and HRRewards_Type ='" + HRRewards_Type + "'";
        condition += HRRewards_Money == "" ? "" : " and HRRewards_Money = '" + HRRewards_Money + "'";
        condition += HRRewards_Agree == "" ? "" : " and HRRewards_Agree like '%" + HRRewards_Agree + "%'";
        condition += HRRewards_Content == "" ? "" : " and HRRewards_Content like '%" + HRRewards_Content + "%'";
        condition += HRRewards_Time1 == "" ? "" : " and HRRewards_Time >= '" + HRRewards_Time1 + "'";
        condition += HRRewards_Time2 == "" ? "" : " and HRRewards_Time <= '" + HRRewards_Time2 + "'";
        condition += HRRewards_OkTime1 == "" ? "" : " and HRRewards_OkTime >= '" + HRRewards_OkTime1 + "'";
        condition += HRRewards_OkTime2 == "" ? "" : " and HRRewards_OkTime <= '" + HRRewards_OkTime2 + "'";

        try
        {
            Grid_Detail.DataSource = hRDDetailL.Search_HRDDetail_Type_Post_Senior(condition);
            Grid_Detail.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HRFilesMgt/HRDDetailMgt.aspx?status=Reward");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //ExcelHelper.GridViewToExcel(Grid_Detail, "人员奖惩表");
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=" + "人员奖惩表.xls");
        Response.Charset = "utf-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.ContentType = "application/vnd.ms-excel";
        string strStyle = "<style>td{mso-number-format:\"\\@\";}</style>";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        stringWrite.WriteLine(strStyle);
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        Grid_Detail.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}