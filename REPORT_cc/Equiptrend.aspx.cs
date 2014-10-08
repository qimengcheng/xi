using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class REPORT_cc_Equiptrend : System.Web.UI.Page
{
    SpareD sd = new SpareD();
    EquipNameModelL equipNameModelL = new EquipNameModelL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.textyear.Text = DateTime.Now.ToString("yyyy");
            try
            {
                if (!((Session["UserRole"].ToString().Contains("设备维修率和停机率统计表"))))
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
    private void BindGrid_EquipName(string condition)
    {
        this.Grid_EquipName.DataSource = equipNameModelL.Search_EquipNameInfo(condition);
        this.Grid_EquipName.DataBind();
    }
    private void BindGridView1(string condition)
    {
        this.GridView1.DataSource = equipNameModelL.Search_EquipNameInfo(condition);
        this.GridView1.DataBind();
    }
    private void BindGrid_Detail(string condition, string year)
    {
        Grid_Detail.DataSource = sd.S_Equiptrend(condition, year);
        Grid_Detail.DataBind();
    }
    #endregion 绑定

    #region 统计数据维护
    //打开统计数据维护
    protected void Senior_DetailOPEN_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = false;
        this.UpdatePanel_Grid.Update();
        Senior_DetailOPEN.Visible = false;
        Senior_DetailCLOSE.Visible = true;
        Panel1.Visible = true;
        UpdatePanel1.Update();
        BindGridView1(" and EN_OperationTime is not null and EN_Limit is not null and EN_OperationTime!=-1 and EN_Limit!=-1");
        UpdatePanel_Search.Update();
        panelGraph.Visible = false;
        UpdatepanelGraph.Update();
    }
    //关闭统计数据维护
    protected void Senior_DetailCLOSE_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        this.UpdatePanel1.Update();
        Panel_Name.Visible = false;
        this.UpdatePanel_Name.Update();
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        panelGraph.Visible = false;
        UpdatepanelGraph.Update();
    }
    //选择统计设备按钮
    protected void New_name_Click(object sender, EventArgs e)
    {
        Panel_Name.Visible = true;
        BindGrid_EquipName(" and (EN_OperationTime is null or EN_OperationTime=-1) and (EN_Limit is null or EN_Limit=-1)");
        UpdatePanel_Name.Update();
    }
    //GridView1相关
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_Name.Visible = false;
        this.UpdatePanel_Name.Update();
        if (e.CommandName == "Delete_Name")//取消统计
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            Grid_EquipName.EditIndex = -1;
            Guid EN_ID = new Guid(Convert.ToString(e.CommandArgument));
            sd.Update_EquipmentName_Statistics(EN_ID, -1, -1);
            BindGrid_EquipName(" and (EN_OperationTime is null or EN_OperationTime=-1) and (EN_Limit is null or EN_Limit=-1)");
            UpdatePanel_Name.Update();
            BindGridView1(" and EN_OperationTime is not null and EN_Limit is not null and EN_OperationTime!=-1 and EN_Limit!=-1");
            UpdatePanel_Search.Update();
        }
    }
    //GridView1显示编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_Name.Visible = false;
        this.UpdatePanel_Name.Update();
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView1(" and EN_OperationTime is not null and EN_Limit is not null and EN_OperationTime!=-1 and EN_Limit!=-1");
    }
    //GridView1编辑
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid EN_ID = new Guid(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //待操作时间
        if (((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('待操作总时间不能为空！')", true);
            return;
        }
        int m1;
        if (!(Int32.TryParse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text, out m1)))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('待操作总时间必须为整数！')", true);
            return;
        }
        int EN_OperationTime = m1;
        //控制限
        if (((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('控制限不能为空！')", true);
            return;
        }
        float m2;
        if (!(float.TryParse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text, out m2)))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('控制限必须为数字！')", true);
            return;
        }
        float EN_Limit = m2;

        GridView1.EditIndex = -1;
        sd.Update_EquipmentName_Statistics(EN_ID, EN_OperationTime, EN_Limit);
        BindGridView1(" and EN_OperationTime is not null and EN_Limit is not null and EN_OperationTime!=-1 and EN_Limit!=-1");
        this.UpdatePanel1.Update();
    }
    //GridView1取消编辑
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView1(" and EN_OperationTime is not null and EN_Limit is not null and EN_OperationTime!=-1 and EN_Limit!=-1");
        this.UpdatePanel1.Update();
    }
    //GridView1翻页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox1");   // refer to the TextBox with the NewPageIndex value
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
        GridView1.EditIndex = -1;
        BindGridView1(" and EN_OperationTime is not null and EN_Limit is not null and EN_OperationTime!=-1 and EN_Limit!=-1");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView1.PageCount ? this.GridView1.PageCount - 1 : newPageIndex;
        this.GridView1.PageIndex = newPageIndex;
        this.GridView1.PageIndex = newPageIndex;
        this.GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    //关闭按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
    }
    //Grid_EquipName相关
    protected void Grid_EquipName_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.SelectedIndex = -1;
        if (e.CommandName == "Choose_Item")//选择
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipName.SelectedIndex = row.RowIndex;
            Guid EN_ID = new Guid(Convert.ToString(e.CommandArgument));
            sd.Update_EquipmentName_Statistics(EN_ID, 624, 5);
            BindGridView1(" and EN_OperationTime is not null and EN_Limit is not null and EN_OperationTime!=-1 and EN_Limit!=-1");
            UpdatePanel1.Update();
            BindGrid_EquipName(" and (EN_OperationTime is null or EN_OperationTime=-1) and (EN_Limit is null or EN_Limit=-1)");
            UpdatePanel_Name.Update();
        }
    }
    //Grid_EquipName翻页
    protected void Grid_EquipName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_EquipName.BottomPagerRow;


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
        Grid_EquipName.EditIndex = -1;
        BindGrid_EquipName(" and (EN_OperationTime is null or EN_OperationTime=-1) and (EN_Limit is null or EN_Limit=-1)");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_EquipName.PageCount ? this.Grid_EquipName.PageCount - 1 : newPageIndex;
        this.Grid_EquipName.PageIndex = newPageIndex;
        this.Grid_EquipName.PageIndex = newPageIndex;
        this.Grid_EquipName.DataBind();
    }
    protected void Grid_EquipName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 统计数据维护

    #region 统计
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        panelGraph.Visible = false;
        UpdatepanelGraph.Update();
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4 )
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        string condition = GetCondition();
        string year = textyear.Text.Trim().ToString();
        BindGrid_Detail(condition, year);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (this.textname.Text.ToString() != "")
        {
            temp += " and EN_EquipName like '%" + this.textname.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        textname.Text = "";
        UpdatePanel_Grid.Update();
        panelGraph.Visible = false;
        UpdatepanelGraph.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_Name.Visible = false;
        UpdatePanel_Name.Update();
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/EquiptrendPrint.aspx?" + "&Year=" + textyear.Text.ToString().Trim() + "&EN_EquipName=" + textname.Text.ToString());
    }
    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Gra")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;

            //panelGraph.Visible = true;
            //DataSet ds = sd.S_Equiptrend("and EN_EquipName='" + e.CommandArgument + "'",textyear.Text.Trim());
            //ds.Tables[0].Select();
            //Chart1.DataSource = ds.Tables[0].Select();
            //Chart1.Titles[0].Text = e.CommandArgument + "维修率和停机率趋势图";

            ////设置图表Y轴对应项
            //Chart1.Series[0].YValueMembers = "出站数";
            //Chart1.Series[1].YValueMembers = "合格率";

            ////设置图表X轴对应项
            //Chart1.Series[0].XValueMember = "月份";
            //Chart1.Series[1].XValueMember = "月份";

            //Chart1.Series[1].Points.AddXY("一月","Grid_Detail.Rows[row.RowIndex].Cells[1].Text.ToString()");//试试
            //绑定数据
            //Chart1.DataBind();

            //Create a DataTable as the data source of the Chart control
            DataTable dt = new DataTable();

            //Add three columns to the DataTable
            dt.Columns.Add("Date");
            dt.Columns.Add("Volume1");
            dt.Columns.Add("Volume2");

            DataRow dr;
            dr = dt.NewRow();
            dr["Date"] = "一月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[3].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[4].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "二月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[5].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[6].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "三月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[7].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[8].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "四月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[9].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[10].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "五月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[11].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[12].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "六月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[13].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[14].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "七月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[15].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[16].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "八月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[17].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[18].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "九月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[19].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[20].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "十月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[21].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[22].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "十一月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[23].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[24].Text.ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "十二月";
            dr["Volume1"] = Grid_Detail.Rows[row.RowIndex].Cells[25].Text.ToString();
            dr["Volume2"] = Grid_Detail.Rows[row.RowIndex].Cells[26].Text.ToString();
            dt.Rows.Add(dr);

            //设置图表的数据源
            Chart1.DataSource = dt;
            Chart1.Titles[0].Text = e.CommandArgument + "—维修率和停机率趋势图";

            //设置图表Y轴对应项
            Chart1.Series[0].YValueMembers = "Volume1";
            Chart1.Series[1].YValueMembers = "Volume2";

            //设置图表X轴对应项
            Chart1.Series[0].XValueMember = "Date";
            Chart1.Series[1].XValueMember = "Date";

            //绑定数据
            Chart1.DataBind();

            panelGraph.Visible = true;
            UpdatepanelGraph.Update();
        }
    }
    protected void Chart1_Load(object sender, EventArgs e)
    {
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
        string year = textyear.Text.Trim().ToString();
        BindGrid_Detail(condition, year);
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
            tcHeader[0].Text = "";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].RowSpan = 2;
            tcHeader[1].Text = "序号";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "设备名称";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].ColumnSpan = 2;
            tcHeader[3].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 2;
            tcHeader[4].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 2;
            tcHeader[5].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 2;
            tcHeader[6].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].ColumnSpan = 2;
            tcHeader[7].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].ColumnSpan = 2;
            tcHeader[8].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].ColumnSpan = 2;
            tcHeader[9].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].ColumnSpan = 2;
            tcHeader[10].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].ColumnSpan = 2;
            tcHeader[11].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].ColumnSpan = 2;
            tcHeader[12].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].ColumnSpan = 2;
            tcHeader[13].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].ColumnSpan = 2;
            tcHeader[14].Text = "十二月</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[15].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[16].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[17].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[18].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[19].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[20].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[21].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[22].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[23].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[24].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[25].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[26].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[27].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[28].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[29].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[30].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[31].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[32].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[33].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[34].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[35].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[36].Text = "停机率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[37].Text = "维修率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[38].Text = "停机率</th></tr><tr>";
        }
    }
    #endregion 统计


}