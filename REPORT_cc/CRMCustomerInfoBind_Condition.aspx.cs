using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class PurchasingMgt_CRMCustomerInfoBind_Condition : System.Web.UI.Page
{
    CRMCustomerInfoBind_ConditionD cd = new CRMCustomerInfoBind_ConditionD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "客户档案汇总表";
        this.Panel_OASearch.Visible = true;
        Getcondition();
    }
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview_OAInfo(condition);
        this.Panel_OAInfo.Visible = true;
    }
    private void BindGridview_OAInfo(string condition)
    {

        this.Gridview_OAInfo.DataSource = cd.SelectCRMCustomerInfoBind_Condition(condition);
        this.Gridview_OAInfo.DataBind();
       
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.TextBox1.Text != "")
        {
            condition += "and CRMRBI_Name like'%" + this.TextBox1.Text + "%'";
        }
        if (this.TextBox2.Text != "")
        {
            condition += "and CRMCSBD_Name like'%" + this.TextBox2.Text + "%'";
        }
        if (this.TextBox3.Text != "")
        {
            condition = "and CRMCIF_Name like'%" + this.TextBox3.Text + "%'";
        }
        if (this.TextBox4.Text != "")
        {
            condition = "and CRMCIF_SalesMan like'%" + this.TextBox4.Text + "%'";
        }
        return condition;
    }

    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {

        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        this.TextBox3.Text = "";
        this.TextBox4.Text = "";
        this.Panel_OAInfo.Visible = false;
    }
 protected void Button2_Click(object sender, EventArgs e)
    {
        this.Panel_OAInfo.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../PurchasingMgt/CRMCustomerInfoBind_ConditionPrint.aspx?" + "&Getcondition()=" + Getcondition());
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var gv = e.Row.Cells[6].FindControl("GridView3") as GridView;
            gv.DataSource = cd.SelectCRMCustomerContact(new Guid(e.Row.Cells[0].Text));
            gv.DataBind();
            }
           

        }
    }

