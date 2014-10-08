using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_ControlledDocApp : Page
{
    SpareD sd = new SpareD();
    BasicCodeL basicCodeL = new BasicCodeL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindGrid_Detail("");
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList1();
            try
            {
                if (!((Session["UserRole"].ToString().Contains("各部门受控文件一览表"))))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    //绑定
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_ControlledDocApp_Print(condition);
        Grid_Detail.DataBind();
    }
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
        DropDownList1.DataTextField = "BDOS_Name";
        DropDownList1.DataValueField = "BDOS_Name";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_Detail(condition);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (DropDownList1.SelectedValue.ToString() != "")
        {
            temp += " and a.CDA_AppDep = '" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (textno.Text.ToString() != "")
        {
            temp += " and a.CDA_DocNO like '%" + textno.Text.Trim() + "%'";
        }
        if (textname.Text.ToString() != "")
        {
            temp += " and a.CDA_DocName like '%" + textname.Text.Trim() + "%'";
        }
        //上次版本生效时间
        if (laststar.Text.ToString() != "" && lastend.Text.ToString() != "")
        {
            temp += " and b.CDA_EffectDate >= '" + laststar.Text.Trim() + "' and b.CDA_EffectDate <= '" + lastend.Text.Trim() + "'";
        }
        if (laststar.Text.ToString() != "" && lastend.Text.ToString() == "")
        {
            temp += " and b.CDA_EffectDate >= '" + laststar.Text.Trim() + "'";
        }
        if (laststar.Text.ToString() == "" && lastend.Text.ToString() != "")
        {
            temp += " and b.CDA_EffectDate <= '" + lastend.Text.Trim() + "'";
        }
        if (laststar.Text.ToString() == "" && lastend.Text.ToString() == "")
        {
            temp += "";
        }
        //最新版本生效时间
        if (neweststar.Text.ToString() != "" && newestend.Text.ToString() != "")
        {
            temp += " and a.CDA_EffectDate >= '" + neweststar.Text.Trim() + "' and a.CDA_EffectDate <= '" + newestend.Text.Trim() + "'";
        }
        if (neweststar.Text.ToString() != "" && newestend.Text.ToString() == "")
        {
            temp += " and a.CDA_EffectDate >= '" + neweststar.Text.Trim() + "'";
        }
        if (neweststar.Text.ToString() == "" && newestend.Text.ToString() != "")
        {
            temp += " and a.CDA_EffectDate <= '" + newestend.Text.Trim() + "'";
        }
        if (neweststar.Text.ToString() == "" && newestend.Text.ToString() == "")
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList1();
        DropDownList1.SelectedValue = "";
        textno.Text = "";
        textname.Text = "";
        laststar.Text = "";
        lastend.Text = "";
        neweststar.Text = "";
        newestend.Text = "";
        //BindGrid_Detail("");
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/ControlledDocAppPrint.aspx?" + "&CDA_AppDep=" + DropDownList1.SelectedValue.ToString() + "&CDA_DocNO=" + textno.Text + "&CDA_DocName=" + textname.Text + "&laststar=" + laststar.Text + "&lastend=" + lastend.Text + "&neweststar=" + neweststar.Text + "&newestend=" + newestend.Text);
    }
    //Grid_Detail翻页
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Detail.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        string condition = GetCondition();
        BindGrid_Detail(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }


}