using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class REPORT_cc_ExpTest : System.Web.UI.Page
{
    SpareD sd = new SpareD();
    BasicCodeL basicCodeL = new BasicCodeL();
    ExpTestL expTestL = new ExpTestL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList1();
            DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList2();
            try
            {
                if (!((Session["UserRole"].ToString().Contains("实验数据统计表"))))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    //绑定
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_ExpTest_Statistical(condition);
        Grid_Detail.DataBind();
    }
    private void BindDropDownList1()
    {
        this.DropDownList1.DataSource = expTestL.Search_ExpSampleType_GridView("");
        this.DropDownList1.DataTextField = "EST_SampleType";
        this.DropDownList1.DataValueField = "EST_SampleType";
        this.DropDownList1.DataBind();
        this.DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    private void BindDropDownList2()
    {
        this.DropDownList2.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
        this.DropDownList2.DataTextField = "BDOS_Name";
        this.DropDownList2.DataValueField = "BDOS_Name";
        this.DropDownList2.DataBind();
        this.DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
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
        if (this.TextProIdentify.Text.ToString() != "")
        {
            temp += " and a.ETA_ProIdentify like '%" + TextProIdentify.Text.Trim() + "%'";
        }
        if (this.DropDownList1.SelectedValue.ToString() != "")
        {
            temp += " and c.EST_SampleType = '" + this.DropDownList1.SelectedValue.ToString() + "'";
        }
        if (this.DropDownList2.SelectedValue.ToString() != "")
        {
            temp += " and a.ETA_AppDep = '" + this.DropDownList2.SelectedValue.ToString() + "'";
        }
        if (this.DropDownList3.SelectedValue.ToString() != "")
        {
            temp += " and a.ETA_EmergDegree = '" + this.DropDownList3.SelectedValue.ToString() + "'";
        }
        if (this.TextExpItem.Text.ToString() != "")
        {
            temp += " and d.EI_ExpItem like '%" + TextExpItem.Text.Trim() + "%'";
        }
        if (this.DropDownList4.SelectedValue.ToString() != "")
        {
            temp += " and b.EIR_ItemRes = '" + this.DropDownList4.SelectedValue.ToString() + "'";
        }
        //上次版本生效时间
        if (this.startime.Text.ToString() != "" && this.endtime.Text.ToString() != "")
        {
            temp += " and a.ETA_AppTime >= '" + startime.Text.Trim() + "' and a.ETA_AppTime <= '" + endtime.Text.Trim() + "'";
        }
        if (this.startime.Text.ToString() != "" && this.endtime.Text.ToString() == "")
        {
            temp += " and a.ETA_AppTime >= '" + startime.Text.Trim() + "'";
        }
        if (this.startime.Text.ToString() == "" && this.endtime.Text.ToString() != "")
        {
            temp += " and a.ETA_AppTime <= '" + endtime.Text.Trim() + "'";
        }
        if (this.startime.Text.ToString() == "" && this.endtime.Text.ToString() == "")
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
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList2();
        DropDownList2.SelectedValue = "";
        TextProIdentify.Text = "";
        DropDownList3.SelectedValue = "";
        TextExpItem.Text = "";
        DropDownList4.SelectedValue = "";
        startime.Text = "";
        endtime.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/ExpTestPrint.aspx?" + "&ETA_ProIdentify=" + TextProIdentify.Text
            + "&EST_SampleType=" + this.DropDownList1.SelectedValue.ToString() + "&ETA_AppDep=" + this.DropDownList2.SelectedValue.ToString()
            + "&ETA_EmergDegree=" + this.DropDownList3.SelectedValue.ToString() + "&EI_ExpItem=" + TextExpItem.Text 
            + "&EIR_ItemRes=" + this.DropDownList4.SelectedValue.ToString() + "&startime=" + startime.Text + "&endtime=" + endtime.Text);
    }
    //Grid_Detail翻页
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Detail.BottomPagerRow;


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
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }
    //Grid_Detail悬浮框显示
    protected void Grid_Detail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Detail.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Detail.Rows[i].Cells.Count; j++)
            {
                Grid_Detail.Rows[i].Cells[j].ToolTip = Grid_Detail.Rows[i].Cells[j].Text;
                if (Grid_Detail.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Detail.Rows[i].Cells[j].Text = Grid_Detail.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }


}