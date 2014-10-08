using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_WIP_CWTJ : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    SalaryTimeItemMaintananceL sTIML = new SalaryTimeItemMaintananceL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid_Detail0("");
            try
            {
                if (!((Session["UserRole"].ToString().Contains("财务部在制品统计表"))))
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

    #region 绑定
    private void BindGrid_Detail0(string condition)
    {
        Grid_Detail0.DataSource = sd.S_WIP_CWTJ_CWPC_cc(condition);
        Grid_Detail0.DataBind();
    }
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_WIP_CWTJ_CWPCD_cc(condition);
        Grid_Detail.DataBind();
    }
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = sTIML.SearchCraftForDdl_SalaryTimeItem();
        DropDownList1.DataTextField = "PBC_Name";
        DropDownList1.DataValueField = "PBC_Name";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    protected void BindDropDownList2()
    {
        DropDownList2.DataSource = ppl.S_ProMainSeries("");
        DropDownList2.DataTextField = "PMS_Name";
        DropDownList2.DataValueField = "PMS_Name";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    }
    #endregion 绑定

    #region 统计数据维护
    protected void BtnSearch0_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        string condition0 = GetCondition0();
        BindGrid_Detail0(condition0);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition0()
    {
        string condition0;
        string temp = "";
        if (TextBox1.Text.ToString() != "")
        {
            temp += " and CWPC_Man like '%" + TextBox1.Text.ToString() + "%'";
        }
        //统计时间
        if (startime.Text.ToString() != "" && endtime.Text.ToString() != "")
        {
            temp += " and CWPC_Time >= '" + startime.Text.Trim() + "' and CWPC_Time <= '" + endtime.Text.Trim() + "'";
        }
        if (startime.Text.ToString() != "" && endtime.Text.ToString() == "")
        {
            temp += " and CWPC_Time >= '" + startime.Text.Trim() + "'";
        }
        if (startime.Text.ToString() == "" && endtime.Text.ToString() != "")
        {
            temp += " and CWPC_Time <= '" + endtime.Text.Trim() + "'";
        }
        if (startime.Text.ToString() == "" && endtime.Text.ToString() == "")
        {
            temp += "";
        }
        condition0 = temp;
        return condition0;
    }
    protected void BtnReset0_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        startime.Text = "";
        endtime.Text = "";
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        BindGrid_Detail0("");
        UpdatePanel_Grid.Update();
    }
    protected void BtnNew0_Click(object sender, EventArgs e)
    {
        Panel_NewCDDep.Visible = true;
        UpdatePanel_NewCDDep.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void BtnCancel_NewCDDep_Click(object sender, EventArgs e)
    {
        string CWPC_Man = Session["UserName"].ToString();
        string CWPC_Note = newCDdep.Text.ToString();
        sd.Insert_WIP_CWTJ(CWPC_Man, CWPC_Note);
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
        BindGrid_Detail0("");
        UpdatePanel_Grid.Update();
    }
    protected void BtnClose0_Click(object sender, EventArgs e)
    {
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
    }
    //Grid_Detail0翻页
    protected void Grid_Detail0_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Detail0.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox0");   // refer to the TextBox with the NewPageIndex value
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
        Grid_Detail0.EditIndex = -1;
        string condition0 = GetCondition0();
        BindGrid_Detail0(condition0);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail0.PageCount ? Grid_Detail0.PageCount - 1 : newPageIndex;
        Grid_Detail0.PageIndex = newPageIndex;
        Grid_Detail0.PageIndex = newPageIndex;
        Grid_Detail0.DataBind();
    }
    //Grid_Detail0相关
    protected void Grid_Detail0_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Grid_Detail0.EditIndex = -1;
        Grid_Detail0.SelectedIndex = -1;
        if (e.CommandName == "Look")//详情
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail0.SelectedIndex = row.RowIndex;

            Guid CWPC_ID = new Guid(Convert.ToString(e.CommandArgument));
            Label777.Text = CWPC_ID.ToString();
            BindGrid_Detail("and CWPC_ID='" + Label777.Text + "'");
            Panel1.Visible = true;
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList1();
            DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList2();
            UpdatePanel1.Update();
            Panel_NewCDDep.Visible = false;
            UpdatePanel_NewCDDep.Update();
        }
        if (e.CommandName == "Delete00")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail0.SelectedIndex = row.RowIndex;

            Guid CWPC_ID = new Guid(Convert.ToString(e.CommandArgument));
            sd.Delete_WIP_CWTJ_CWPC_cc(CWPC_ID);
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel_NewCDDep.Visible = false;
            UpdatePanel_NewCDDep.Update();
            BindGrid_Detail0("");
            UpdatePanel_Grid.Update();
        }
    }
    //显示编辑
    protected void Grid_Detail0_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
        Grid_Detail0.EditIndex = e.NewEditIndex;
        string condition0 = GetCondition0();
        BindGrid_Detail0(condition0);
    }
    //Gridview编辑
    protected void Grid_Detail0_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid CWPC_ID = new Guid(Grid_Detail0.DataKeys[e.RowIndex].Value.ToString());
        string CWPC_Note = Convert.ToString(((TextBox)(Grid_Detail0.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim());
        Grid_Detail0.EditIndex = -1;
        sd.Update_WIP_CWTJ_CWPC_cc(CWPC_ID, CWPC_Note);
        BindGrid_Detail0("");
        UpdatePanel_Grid.Update();
    }
    //取消编辑
    protected void Grid_Detail0_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_Detail0.EditIndex = -1;
        BindGrid_Detail0("");
        UpdatePanel_Grid.Update();
    }
    #endregion 统计数据维护

    #region 统计
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Panel_NewCDDep.Visible = false;
        UpdatePanel_NewCDDep.Update();
        string condition1 = GetCondition1();
        BindGrid_Detail(condition1);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition1()
    {
        string condition1;
        string temp = "";
        if (DropDownList1.SelectedValue.ToString() != "")
        {
            temp += " and CWPCD_BCGX = '" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (DropDownList2.SelectedValue.ToString() != "")
        {
            temp += " and CWPCD_DXH = '" + DropDownList2.SelectedValue.ToString() + "'";
        }
        temp += "and CWPC_ID='" + Label777.Text + "'";
        condition1 = temp;
        return condition1;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedValue = "";
        DropDownList2.SelectedValue = "";
        string condition1 = GetCondition1();
        BindGrid_Detail(condition1);
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/WIP_CWTJPrint.aspx?" + "&condition=" + GetCondition1().ToString());
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox2");   // refer to the TextBox with the NewPageIndex value
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
        string condition1 = GetCondition1();
        BindGrid_Detail(condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }
    //关闭按钮
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    #endregion 统计



}