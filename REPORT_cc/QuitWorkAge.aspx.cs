using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_QuitWorkAge : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    HRDDetailL hRDDetailL = new HRDDetailL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.textyear.Text = DateTime.Now.ToString("yyyy");
            Bind_DdlDep(DdlSDep);
            Bind_DdlSPost("");
            try
            {
                if (!((Session["UserRole"].ToString().Contains("人员流失工龄年报表"))))
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

    #region 绑定
    private void BindGrid_Detail(string year,string condition)
    {
        Grid_Detail.DataSource = sd.S_QuitWorkAge(year, condition);
        Grid_Detail.DataBind();
    }
    private void Bind_DdlDep(DropDownList ddl)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail_BDOrganizationSheet().Tables[0].DefaultView;
        ddl.DataTextField = "BDOS_Name";
        ddl.DataValueField = "BDOS_Code";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }
    private void Bind_DdlSPost(string BDOS_Code)
    {
        DdlSPost.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        DdlSPost.DataTextField = "HRP_Post";
        DdlSPost.DataValueField = "HRP_Post";
        DdlSPost.DataBind();
        DdlSPost.Items.Insert(0, new ListItem("请选择", ""));
    }
    #endregion 绑定

    #region 统计
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        string year = textyear.Text.Trim().ToString();
        string condition = "";
        if (DdlSDep.SelectedValue != "")
        {
            condition += "and a.部门 like '%" + DdlSDep.SelectedItem.ToString()+ "%'";
            if (DdlSPost.SelectedValue!="")
            {
                condition += "and a.岗位 like '%" + DdlSPost.SelectedValue.ToString() + "%'";
            }
        }
        BindGrid_Detail(year,condition);
        UpdatePanel_Grid.Update();
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        textyear.Text = "";
        DdlSDep.SelectedValue = "";
        DdlSPost.SelectedValue = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/QuitWorkAgePrint.aspx?" + "&Year=" + textyear.Text.ToString().Trim() + "&dep=" + DdlSDep.SelectedItem.ToString().Trim() + "&post=" + DdlSPost.SelectedValue.ToString().Trim());
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
        string year = textyear.Text.Trim().ToString();
        string condition = "";
        if (DdlSDep.SelectedValue != "")
        {
            condition += "and a.部门 like '%" + DdlSDep.Text.ToString() + "%'";
        }
        if (DdlSPost.SelectedValue != "")
        {
            condition += "and a.岗位 like '%" + DdlSPost.Text.ToString() + "%'";
        }
        BindGrid_Detail(year, condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }
    //Grid_Detail多表头合并
    protected void Grid_Detail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //判断创建的行是否为表头行
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //获取表头所在行的所有单元格
            TableCellCollection tcHeader = e.Row.Cells;
            //清除自动生成的表头
            tcHeader.Clear();

            //第一行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[0].RowSpan = 2;
            tcHeader[0].Text = "序号";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].RowSpan = 2;
            tcHeader[1].Text = "部门";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "岗位";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].ColumnSpan = 7;
            tcHeader[3].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 7;
            tcHeader[4].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 7;
            tcHeader[5].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 7;
            tcHeader[6].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].ColumnSpan = 7;
            tcHeader[7].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].ColumnSpan = 7;
            tcHeader[8].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].ColumnSpan = 7;
            tcHeader[9].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].ColumnSpan = 7;
            tcHeader[10].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].ColumnSpan = 7;
            tcHeader[11].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].ColumnSpan = 7;
            tcHeader[12].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].ColumnSpan = 7;
            tcHeader[13].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].ColumnSpan = 7;
            tcHeader[14].Text = "十二月</th></tr><tr>";

            //第二行表头
            int i;
            for (i = 15; i <= 98; )
            {
                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "试用期内";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "三至六月";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "六月至一年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "一至二年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "二至五年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "五至十年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "十年以上";
                i += 1;
            }
        }
    }
    #endregion 统计

    protected void DdlSDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlSPost(DdlSDep.SelectedValue.ToString());
    }

}