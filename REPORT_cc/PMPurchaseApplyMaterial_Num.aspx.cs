using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_PMPurchaseApplyMaterial_Num : Page
{
    PRMProjectScheduleL prl = new PRMProjectScheduleL();
    private static PMPurchaseApplyMaterial_DepartmentD pd = new PMPurchaseApplyMaterial_DepartmentD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "采购申请部门申请情况汇总";

            foreach (Control ct in Panel_OASearch.Controls)
            {
                if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBoxList"))
                {
                    CheckBoxList cb = (CheckBoxList)ct;
                    cb.DataSource = pd.SelectPMPMaterial("").Tables[0];
                    cb.DataTextField = "IMMT_MaterialType";//绑定的字段名
                    cb.DataValueField = "IMMT_MaterialType";//绑定的值
                    cb.DataBind();
                }
            }
            GetConditionn();
            Bind_DDLMark(DDLMark);
            Panel_OASearch.Visible = true;
            UpdatePanel_OASearch.Update();
        }
    }
    //申请 部门
    private void Bind_DDLMark(DropDownList DDLMark)
    {
        this.DDLMark.DataSource = prl.SelectPRMP_Organization("").Tables[0].DefaultView;
        DDLMark.DataTextField = "BDOS_Name";
        DDLMark.DataValueField = "BDOS_Name";
        DDLMark.DataBind();
        DDLMark.Items.Insert(0, new ListItem("请选择", ""));
    }
//检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGridview_OAInfo(condition);
        Panel_OAInfo.Visible = true;
        UpdatePanel_OAInfo.Update();
    }
    protected string GetCondition()
    {
        string condition = "";
        if (TextBox1.Text != "")
        {
            condition += "and IMMaterialBasicData.IMMBD_MaterialName like'%" + TextBox1.Text.ToString() + "%'";
        }
        if(DDLMark.SelectedValue!="")
        {
            condition += "and PMPAM_Department='"+DDLMark.SelectedValue+"'";
        }
        if (TextBox_SPTime2.Text != "")
        {
            if (TextBox_SPTime3.Text != "")
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(TextBox_SPTime2.Text.ToString()) + "'" + "and PMPAM_ApplyTime<='" + Convert.ToDateTime(TextBox_SPTime3.Text.ToString()) + "'";
            }
            else
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(TextBox_SPTime2.Text.ToString()) + "'";
            }
        }
        else if (TextBox_SPTime2.Text == "" && TextBox_SPTime3.Text != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择开始时间！')", true);
        }
        if (TextBox2.Text != "")
        {
            condition += "and IMMaterialBasicData.IMMBD_SpecificationModel='" + TextBox2.Text.ToString() + "'";
        }
        int a = 0;
        foreach (Control ct in Panel_OASearch.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBoxList"))
            {
                CheckBoxList cb = (CheckBoxList)ct;
                foreach (ListItem items in cb.Items)
                {
                    if (items.Selected)
                    {
                        a++;
                        if (a == 1)
                        {
                            label_Type.Text = "IMMaterialType.IMMT_MaterialType='" + items.Value + "'";
                        }
                        if (a > 1)
                        {
                            label_Type.Text += " or IMMaterialType.IMMT_MaterialType='" + items.Value + "'";

                        }
                    }
                }

                if (a > 0)
                {
                    condition += "and (" + label_Type.Text + ")";
                }

                //this.label_CB.Text = cb.Items.Cast<ListItem>().Where(listItem => listItem.Selected == true).Aggregate<ListItem, string>(null, (current, listItem) => current + (listItem.Value)) + "'";
                //if (this.label_CB.Text != ",")
                //{

                //    this.label_Type.Text = "and IMMaterialType.IMMT_MaterialType='" + cb.Items.Cast<ListItem>().Where(listItem => listItem.Selected == true).Aggregate<ListItem, string>(null, (current, listItem) => current + (listItem.Value)) + "or IMMaterialType.IMMT_MaterialType='" + "'";
                //    condition += this.label_Type.Text;

                //}
            }
        }
        return condition;
    }
    protected string GetConditionn()
    {
        string condition = "";
        if (TextBox1.Text != "")
        {
            condition += "and IMMBD_MaterialName like'%" + TextBox1.Text.ToString() + "%'";
        }
        if (DDLMark.SelectedValue != "")
        {
            condition += "and PMPAM_Department='" + DDLMark.SelectedValue + "'";
        }
        if (TextBox_SPTime2.Text != "")
        {
            if (TextBox_SPTime3.Text != "")
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(TextBox_SPTime2.Text.ToString()) + "'" + "and PMPAM_ApplyTime<='" + Convert.ToDateTime(TextBox_SPTime3.Text.ToString()) + "'";
            }
            else
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(TextBox_SPTime2.Text.ToString()) + "'";
            }
        }
        else if (TextBox_SPTime2.Text == "" && TextBox_SPTime3.Text != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择开始时间！')", true);
        }
        if (TextBox2.Text != "")
        {
            condition += "and IMMBD_SpecificationModel='" + TextBox2.Text.ToString() + "'";
        }
        int a = 0;
        foreach (Control ct in Panel_OASearch.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBoxList"))
            {
                CheckBoxList cb = (CheckBoxList)ct;
                foreach (ListItem items in cb.Items)
                {
                    if (items.Selected)
                    {
                        a++;
                        if (a == 1)
                        {
                            label_Typee.Text = "IMMT_MaterialType='" + items.Value + "'";
                        }
                        if (a > 1)
                        {
                            label_Typee.Text += " or IMMT_MaterialType='" + items.Value + "'";

                        }
                    }
                }

                if (a > 0)
                {
                    condition += "and (" + label_Typee.Text + ")";
                }

                //this.label_CB.Text = cb.Items.Cast<ListItem>().Where(listItem => listItem.Selected == true).Aggregate<ListItem, string>(null, (current, listItem) => current + (listItem.Value)) + "'";
                //if (this.label_CB.Text != ",")
                //{

                //    this.label_Type.Text = "and IMMaterialType.IMMT_MaterialType='" + cb.Items.Cast<ListItem>().Where(listItem => listItem.Selected == true).Aggregate<ListItem, string>(null, (current, listItem) => current + (listItem.Value)) + "or IMMaterialType.IMMT_MaterialType='" + "'";
                //    condition += this.label_Type.Text;

                //}
            }
        }
        return condition;
    }
    private void BindGridview_OAInfo(string condition)
    {
        Gridview_OAInfo.DataSource = pd.SelectPMPurchaseApplyMaterial_Department(condition);
        Gridview_OAInfo.DataBind();
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox_SPTime2.Text = "";
        TextBox_SPTime3.Text = "";
        foreach (Control ct in Panel_OASearch.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBoxList"))
            {
                CheckBoxList cb = (CheckBoxList)ct;
                 cb.DataSource = pd.SelectPMPMaterial("").Tables[0];
                cb.DataTextField = "IMMT_MaterialType";//绑定的字段名
                cb.DataValueField = "IMMT_MaterialType";//绑定的值
                cb.DataBind();
            }
        }
        Panel_OASearch.Visible = true;
        Panel_OAInfo.Visible = false;
        UpdatePanel_OAInfo.Update();
    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_OAInfo.Visible = false;
    }
    //打印报表
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/PMPurchaseApplyMaterial_NumPrint.aspx?" + "&IMMBD_MaterialName=" + TextBox1.Text + "&PMPAM_ApplyTime1=" + TextBox_SPTime2.Text + "&PMPAM_ApplyTime2=" + TextBox_SPTime3.Text + "&IMMBD_SpecificationModel=" + TextBox2.Text + "&IMMT_MaterialType=" + label_Type.Text + "&PMPAM_Department" + DDLMark.SelectedValue.ToString() + "&IMMT_MaterialTypee=" + label_Typee.Text);
    }
    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string condition = GetConditionn();
        DataSet ds = pd.SelectPMPurchaseApplyMaterial_Department_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        { 
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计数量";
            
                e.Row.Cells[5].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[6].Text = dt.Rows[0][1].ToString();
         
        }
        }
        
        
    }
}