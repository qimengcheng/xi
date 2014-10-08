using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RTXHelper;
public partial class ProductionProcess_ErrorNew : System.Web.UI.Page
{
    WOSSalaryL wosl = new WOSSalaryL();
    ErrorRelevantL erl = new ErrorRelevantL();
    WorkOrderCheckL wcl = new WorkOrderCheckL();
    ProductionProcessD ppd = new ProductionProcessD();
    CSD cs = new CSD();
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             
            if (Request.QueryString["state"] == null)
            {
                this.label_pagestate.Text = "look";
            }
            else
            {
                this.label_pagestate.Text = Request.QueryString["state"];
            }
            string state = this.label_pagestate.Text;
            if (state == "look")
            {
                this.Title = "异常查看";
                GridView1.Columns[15].Visible = false;
                GridView_Error.Columns[14].Visible = false;
                GridView_Error.Columns[15].Visible = false;
                GridView_Error.Columns[13].Visible = false;
                DropDownList1.SelectedIndex = 1;
                DropDownList1.Enabled = false;
                GridView_Error.Columns[16].Visible = false;//生产会签
                GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                 
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;
            }
            if (state == "ycsb")
            {
                this.Title = "异常申报";
                GridView_Error.Columns[13].Visible = false;
                GridView_Error.Columns[14].Visible = false;
                GridView_Error.Columns[15].Visible = false;

                GridView_Error.Columns[16].Visible = false;//生产会签
                GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;
            }
            if (state == "pbyccl")
            {
                this.Title = "品保异常处理";
                GridView1.Columns[15].Visible = false;
                GridView_Error.Columns[14].Visible = false;
                GridView_Error.Columns[15].Visible = false;

                GridView_Error.Columns[16].Visible = false;//生产会签
                GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;

            }
            if (state == "gcyccl")
            {
                this.Title = "工程异常处理";
                GridView1.Columns[15].Visible = false;
                GridView_Error.Columns[13].Visible = false;
                GridView_Error.Columns[15].Visible = false;

                GridView_Error.Columns[16].Visible = false;//生产会签
                GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = true;
                fg2.Visible = true;
                fg3.Visible = true;
            }
            if (state == "scyccl")
            {
                this.Title = "生产异常处理";
                GridView1.Columns[15].Visible = false;
                GridView_Error.Columns[13].Visible = false;
                GridView_Error.Columns[14].Visible = false;

                GridView_Error.Columns[16].Visible = false;//生产会签
                GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;
            }

            if (state == "scychq")
            {
                this.Title = "生产异常会签";
                GridView1.Columns[15].Visible = false;//异常申报按钮
                GridView_Error.Columns[13].Visible = false;//品保
                GridView_Error.Columns[14].Visible = false;//工程
                GridView_Error.Columns[15].Visible = false;//生产
                GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;
            }

            if (state == "pbychq")
            {
                this.Title = "品保异常会签";
                GridView1.Columns[15].Visible = false;//异常申报按钮
                GridView_Error.Columns[13].Visible = false;//品保
                GridView_Error.Columns[14].Visible = false;//工程
                GridView_Error.Columns[15].Visible = false;//生产
                GridView_Error.Columns[16].Visible = false;
               // GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;
            }

            if (state == "gcychq")
            {
                this.Title = "品保异常会签";
                GridView1.Columns[15].Visible = false;//异常申报按钮
                GridView_Error.Columns[13].Visible = false;//品保
                GridView_Error.Columns[14].Visible = false;//工程
                GridView_Error.Columns[15].Visible = false;//生产
                GridView_Error.Columns[16].Visible = false;//生产异常会签
                GridView_Error.Columns[17].Visible = false;//品保
               // GridView_Error.Columns[18].Visible = false;//工程
                GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;
            }

            if (state == "zdbmgz")
            {
                this.Title = "主导部门跟踪";
                GridView1.Columns[15].Visible = false;//异常申报按钮
                GridView_Error.Columns[13].Visible = false;//品保
                GridView_Error.Columns[14].Visible = false;//工程
                GridView_Error.Columns[15].Visible = false;//生产
                GridView_Error.Columns[16].Visible = false;//生产异常会签
                GridView_Error.Columns[17].Visible = false;//品保
                GridView_Error.Columns[18].Visible = false;//工程
                //GridView_Error.Columns[19].Visible = false;//跟踪
                databind();
                fg1.Visible = false;
                fg2.Visible = false;
                fg3.Visible = false;
            }

            DropDownList3.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList3.DataTextField = "PBC_Name";
            DropDownList3.DataValueField = "PBC_ID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("请选择", ""));

            DropDownList4.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList4.DataTextField = "PBC_Name";
            DropDownList4.DataValueField = "PBC_ID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("请选择", ""));
        }
    }


    public void databind()
    {
        string bm = " and 1=1";
        if (this.label_pagestate.Text == "pbyccl")
        {
            bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name like '%材料%')";
        }
        if (this.label_pagestate.Text == "scyccl")
        {
            bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name like '%人%')";
        }
        if (this.label_pagestate.Text == "gcyccl")
        {
            bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name not like '%人%'  and d.EPO_Name not like '%材料%')";
        }
        if (this.label_pagestate.Text == "pbychq")
        {
            bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name not like '%人%'  and d.EPO_Name not like '%材料%')";
        }
        if (this.label_pagestate.Text == "scychq")
        {
            bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name not like '%人%'  and d.EPO_Name not like '%材料%')";
        }
        if (this.label_pagestate.Text == "gcychq")
        {
            bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name like '%人%')";
        }
        if (this.label_pagestate.Text == "zdbmgz")
        {
            string d = Session["Department"].ToString();
            if (d.Contains("生产") || d.Contains("模块")||d.Contains("配套"))
            {
                bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name like '%人%')";

            }
            if (d.Contains("工程"))
            {
                bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name not like '%人%'  and d.EPO_Name not like '%材料%')";

            }
            if (d.Contains("品保"))
            {
                bm = " and WO_ID in (select b.WO_ID  from WODetail b inner join WOError a on b.WOD_Error='是' and a.WOD_ID=b.WOD_ID inner join ErrorPhenomenonOptionDetail c on a.EPOD_ID=c.EPOD_ID inner join ErrorPhenomenonOption d on c.EPO_ID=d.EPO_ID and d.EPO_Name like '%材料%')";

            }
        }
        string condition;
        string WO_Type = "";
        try
        {
            if (Request.QueryString["WO_Type"].ToString() == "检验")
            {
                WO_Type = " and WO_Type='检验' ";
                DropDownList_WO_Type.SelectedIndex = 4;
            }
            else
            {
                WO_Type = this.DropDownList_WO_Type.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Type like '%" + this.DropDownList_WO_Type.SelectedItem.Text.Trim() + "%' ";
            }
        }
        catch (Exception)
        {
            WO_Type = this.DropDownList_WO_Type.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Type like '%" + this.DropDownList_WO_Type.SelectedItem.Text.Trim() + "%' ";
        }
        //string WO_People = this.TextBox_WO_People.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_People like '%" + this.TextBox_WO_People.Text.Trim() + "%' ";
        if ((this.TextBox_WO_Time1.Text != "" && this.TextBox_WO_Time2.Text == "") || (this.TextBox_WO_Time1.Text == "" && this.TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        if ((this.DropDownList3.SelectedValue.ToString() != "" && this.DropDownList4.SelectedValue.ToString() == "") || (this.DropDownList3.SelectedValue.ToString().Trim() == "" && this.DropDownList4.SelectedValue.ToString().Trim() != ""))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请将工序检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string gx = " and 1=1 ";
        string WO_Time = (this.TextBox_WO_Time1.Text.Trim() == "" && this.TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and WOD_StaTime between   ' " + this.TextBox_WO_Time1.Text.Trim() + "' and ' " + this.TextBox_WO_Time2.Text.Trim() + "'";
        string WO_Num = this.TextBox_wonum.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + this.TextBox_wonum.Text.Trim() + "%' ";
        string pbcname = this.TextBox_PBC.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + this.TextBox_PBC.Text.Trim() + "%' ";
        string SMSO_ComOrderNum = this.TextBox_OrderNum.Text.Trim() == "" ? " and 1=1 " : " and SMSO_ComOrderNum like '%" + this.TextBox_OrderNum.Text.Trim() + "%' ";
        string WO_ProType = this.TextBox_pt.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + this.TextBox_pt.Text.Trim() + "%' ";
        string WO_State = this.DropDownList_WoState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_State like '%" + this.DropDownList_WoState.SelectedItem.Text.Trim() + "%' ";
        string WO_SN = this.TextBox_WOSN.Text.Trim() == "" ? " and 1=1 " : " and WO_SN like '%" + this.TextBox_WOSN.Text.Trim() + "%' ";
        string error = this.DropDownList1.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WOD_Error like '%" + this.DropDownList1.SelectedItem.Text.Trim() + "%' ";
        string otime = this.DropDownList2.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WOD_OverTime like '%" + this.DropDownList2.SelectedItem.Text.Trim() + "%' ";
        string pihao = this.TextBox_WOSN0.Text.Trim() == "" ? " and 1=1 " : " and pihao like '%" + this.TextBox_WOSN0.Text.Trim() + "%' ";
        if (DropDownList3.SelectedValue.ToString().Trim() == "" && DropDownList4.SelectedValue.ToString().Trim() == "")
        {
            gx = " and 1=1 ";
        }
        else
        {
            gx = " and '" + DropDownList3.SelectedValue.ToString().Trim() + "' in (select PBC_ID from WODetail where WO_ID=t.WO_ID and WOD_InTime is not null) " + "  and ( '"
                + DropDownList4.SelectedValue.ToString().Trim() + "' in (select top 1 PBC_ID from WODetail where WO_ID=t.WO_ID and WOD_InTime is not null order by WOD_InTime desc) or '"
                + DropDownList4.SelectedValue.ToString().Trim() + "' not in (select PBC_ID from WODetail where WO_ID=t.WO_ID and WOD_InTime is not null ) ) ";

        }
        condition = WO_Type + WO_Time + WO_Num + pbcname + SMSO_ComOrderNum + WO_ProType + WO_State + WO_SN + error + otime + gx + pihao+bm;
        this.GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        this.GridView_WOmain.DataBind();
        this.UpdatePanel_WOmain.Update();

    }

    public void databind_detail()
    {
        GridView1.DataSource = ppd.S_WODetail_Check(new Guid(label_WO_ID.Text.Trim()));
        GridView1.DataBind();
        UpdatePanel1.Update();

    }

    public void databind_errorlist()
    {
        GridView_Error.DataSource = ppd.S_WOError_new(new Guid(label_wodid.Text.Trim()));
        GridView_Error.DataBind();
        UpdatePanel_ErrorList.Update();
    }
    protected void Btn_Search_Click(object sender, EventArgs e)//主表检索
    {
        GridView_WOmain.SelectedIndex = -1;
        databind();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        TextBox_WOSN0.Text = "";
        DropDownList3.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;

        this.DropDownList_WO_Type.SelectedIndex = 0;
        this.DropDownList_WoState.SelectedIndex = 0;
        this.TextBox_OrderNum.Text = "";
        this.TextBox_wonum.Text = "";
        this.TextBox_PBC.Text = "";
        this.TextBox_pt.Text = "";
        this.TextBox_WO_Time1.Text = "";
        this.TextBox_WO_Time2.Text = "";
        this.TextBox_WOSN.Text = "";
        string condition = " and 1=1";
        try
        {
            if (Request.QueryString["WO_Type"].ToString() == "检验")
            {
                condition = " and WO_Type='检验' ";
            }
            else
            {
                condition = " and 1=1";
            }
        }
        catch (Exception)
        {
            condition = " and 1=1";
        }
        GridView_WOmain.PageIndex = 0;
        this.GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        this.GridView_WOmain.DataBind();
        this.UpdatePanel_WOmain.Update();
        GridView_WOmain.SelectedIndex = -1;
    }
    protected void GridView_WOmain_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_WOmain.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_WOmain.Rows[i].Cells.Count; j++)
            {
                GridView_WOmain.Rows[i].Cells[j].ToolTip = GridView_WOmain.Rows[i].Cells[j].Text;
                if (GridView_WOmain.Rows[i].Cells[j].Text.Length > 10)
                {
                    GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                }


            }
        }
    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_WOmain.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_WOmain.PageCount ? GridView_WOmain.PageCount - 1 : newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;
        this.GridView_WOmain.PageIndex = newPageIndex;
        databind();
        this.Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();

        Panel_ErrorList.Visible = false;
        UpdatePanel_ErrorList.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "BasicInfo")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_WO_ID.Text = al[0];
            label_WONum.Text = al[1];
            GridView1.SelectedIndex = -1;
            Panel1.Visible = true;
            databind_detail();

            Panel_NewProjectInfo.Visible = false;
            UpdatePanel_NewProjectInfo.Update();

            Panel_ErrorList.Visible = false;
            UpdatePanel_ErrorList.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();

        }
    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if (drv["WOD_OverTime"].ToString().Trim() == "是")
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;

            }
           
            if (drv["WOD_Error"].ToString().Trim() == "是")
            {
                e.Row.BackColor = System.Drawing.Color.Pink;

            }
        }
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                if (j != 3)
                {
                    GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;
                    if (GridView1.Rows[i].Cells[j].Text.Length > 16)
                    {
                        GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].Text.Substring(0, 16) + "...";
                    }
                }

            }
            GridView1.Rows[i].Cells[3].ToolTip = GridView1.Rows[i].Cells[3].Text;
            if (GridView1.Rows[i].Cells[3].Text.Length > 12)
            {
                GridView1.Rows[i].Cells[3].Text = GridView1.Rows[i].Cells[3].Text.Substring(0, 12) + "...";
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ycsb")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });

            this.label_applywodid.Text = al[0];
            label_ApplyPBC.Text = al[1];
            Panel_NewProjectInfo.Visible = true;
            label_Change.Text = "申报";
            DropDownList5.DataSource = cs.CS_Proc_S_ErrorPhenomenonOption_EPO_Name();
            DropDownList5.DataTextField = "EPO_Name";
            DropDownList5.DataValueField = "EPO_ID";
            DropDownList5.DataBind();
            DropDownList7.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList7.DataTextField = "PBC_Name";
            DropDownList7.DataValueField = "PBC_ID";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            for (int i = 0; i < DropDownList7.Items.Count; i++)
            {
                if (DropDownList7.Items[i].Text.Trim() == label_ApplyPBC.Text.Trim())
                {
                    DropDownList7.SelectedIndex = i;
                    break;
                }

            }

            if (DropDownList5.Items.Count != 0)
            {
                string condition;
                condition = " and PBC_Name = '" + this.DropDownList7.SelectedItem.Text.Trim() + "'";
                DropDownList6.DataSource = ppl.S_ErrorPhenomenonOptionDetail(DropDownList5.SelectedValue.ToString().Trim(), condition);
                DropDownList6.DataTextField = "EPOD_Name";
                DropDownList6.DataValueField = "EPOD_ID";
                DropDownList6.DataBind();
                DropDownList6.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
            }
            DropDownList5.SelectedIndex = 0;
            DropDownList6.SelectedIndex = 0;
            TextBox4.Text = "";
           
            Label29.Text = Session["UserName"].ToString();
            Label30.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            Label1.Text = Session["Department"].ToString();
            this.label_ApplyWO.Text = label_WONum.Text;
           

          
            DropDownList5.Enabled = true;
            DropDownList7.Enabled = true;
            DropDownList6.Enabled = true;
            TextBox4.Enabled = true;
            Button6.Visible = true;
            Button7.Visible = true;
            UpdatePanel_NewProjectInfo.Update();


            Panel_ErrorList.Visible = false;
            UpdatePanel_ErrorList.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "ycck")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            this.label_wodid.Text = al[0];
            label_PBCForList.Text = al[1];
            GridView_Error.DataSource = ppd.S_WOError_new(new Guid(label_wodid.Text.Trim()));
            GridView_Error.DataBind();
            Panel_ErrorList.Visible=true;
            UpdatePanel_ErrorList.Update();
            Panel_NewProjectInfo.Visible=false;
            UpdatePanel_NewProjectInfo.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
        }
    }
    protected void ConfirmProject(object sender, EventArgs e)
    {

    }
    protected void CanelProject(object sender, EventArgs e)
    {
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
    }
    protected void Button_Cancel0_Click(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();

        Panel_ErrorList.Visible = false;
        UpdatePanel_ErrorList.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
   
    }
    protected void GridView_Error_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "schq")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            label4.Text = label_WONum.Text.Trim() ;
            label6.Text = label_PBCForList.Text;

            pbtg.Visible = false;
            pbbh.Visible = false;
            gctg.Visible = false;
            gcbh.Visible = false;
            sctg.Visible = true;
            scbh.Visible = true;
            TextBox2.Enabled = true;
            TextBox7.Enabled = false;
            TextBox8.Enabled = false;

            Label_WOEID.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_ID"].ToString().Trim();
            Label15.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQMan"].ToString().Trim();//生产会签人
            Label17.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQTime"].ToString().Trim(); //生产会签时间
            Label18.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQDept"].ToString().Trim(); //生产会签部门
            label51.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQResult"].ToString().Trim(); //生产会签结果
            TextBox2.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQSuggestion"].ToString().Trim(); //生产会签意见
            Label41.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQMan"].ToString().Trim(); //品保会签人
            Label42.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQtime"].ToString().Trim(); //品保会签时间
            label52.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQResult"].ToString().Trim();  //品保会签结果
            TextBox7.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQSuggestion"].ToString().Trim();  //品保会签意见
            Label46.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQMan"].ToString().Trim(); //工程会签人
            Label47.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQtime"].ToString().Trim(); //工程会签时间
            label53.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQResult"].ToString().Trim(); //工程会签结果
            TextBox8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQSuggestion"].ToString().Trim(); //工程会签意见
            Panel3.Visible = true;
            gcbh.Visible = false;
            //gc
            UpdatePanel3.Update();
         
        }

        if (e.CommandName == "pbhq")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            label4.Text = label_WONum.Text.Trim();
            label6.Text = label_PBCForList.Text;



            pbtg.Visible = true;
            pbbh.Visible = true;
            gctg.Visible = false;
            gcbh.Visible = false;
            sctg.Visible = false;
            scbh.Visible = false;
            TextBox2.Enabled = false;
            TextBox7.Enabled = true;
            TextBox8.Enabled = false;
            Label_WOEID.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_ID"].ToString().Trim();
            Label15.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQMan"].ToString().Trim();//生产会签人
            Label17.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQTime"].ToString().Trim(); //生产会签时间
            Label18.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQDept"].ToString().Trim(); //生产会签部门
            label51.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQResult"].ToString().Trim(); //生产会签结果
            TextBox2.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQSuggestion"].ToString().Trim(); //生产会签意见
            Label41.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQMan"].ToString().Trim(); //品保会签人
            Label42.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQtime"].ToString().Trim(); //品保会签时间
            label52.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQResult"].ToString().Trim();  //品保会签结果
            TextBox7.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQSuggestion"].ToString().Trim();  //品保会签意见
            Label46.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQMan"].ToString().Trim(); //工程会签人
            Label47.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQtime"].ToString().Trim(); //工程会签时间
            label53.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQResult"].ToString().Trim(); //工程会签结果
            TextBox8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQSuggestion"].ToString().Trim(); //工程会签意见


            Panel3.Visible = true;

            UpdatePanel3.Update();
        }

        if (e.CommandName == "gchq")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            label4.Text = label_WONum.Text.Trim();
            label6.Text = label_PBCForList.Text;

            pbtg.Visible = false;
            pbbh.Visible = false;
            gctg.Visible = true;
            gcbh.Visible = true;
            sctg.Visible = false;
            scbh.Visible = false;
            TextBox2.Enabled = false;
            TextBox7.Enabled = false;
            TextBox8.Enabled = true;

            Label_WOEID.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_ID"].ToString().Trim();
            Label15.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQMan"].ToString().Trim();//生产会签人
            Label17.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQTime"].ToString().Trim(); //生产会签时间
            Label18.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQDept"].ToString().Trim(); //生产会签部门
            label51.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQResult"].ToString().Trim(); //生产会签结果
            TextBox2.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQSuggestion"].ToString().Trim(); //生产会签意见
            Label41.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQMan"].ToString().Trim(); //品保会签人
            Label42.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQtime"].ToString().Trim(); //品保会签时间
            label52.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQResult"].ToString().Trim();  //品保会签结果
            TextBox7.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQSuggestion"].ToString().Trim();  //品保会签意见
            Label46.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQMan"].ToString().Trim(); //工程会签人
            Label47.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQtime"].ToString().Trim(); //工程会签时间
            label53.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQResult"].ToString().Trim(); //工程会签结果
            TextBox8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQSuggestion"].ToString().Trim(); //工程会签意见


            Panel3.Visible = true;

            UpdatePanel3.Update();
        }

        if (e.CommandName == "gzja")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            label7.Text = label_WONum.Text;
            label13.Text= label_PBCForList.Text;

            Panel_NewProjectInfo.Visible = false;
            UpdatePanel_NewProjectInfo.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel4.Visible = true;
            label_WOE_ID_GZJA.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_ID"].ToString().Trim();//异常ID
            Label24.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_TrackMan"].ToString().Trim();//跟踪人
            Label54.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_TrackResult"].ToString().Trim(); //跟踪时间
            TextBox3.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_TrackSuggestion"].ToString().Trim(); //跟踪部门
            Label26.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_TrackDep"].ToString().Trim(); //跟踪结果
            Label25.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_TrackTime"].ToString().Trim(); //跟踪意见
           

            Panel3.Visible = false;

            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }

        if (e.CommandName == "pbyccl")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });

            Panel_NewProjectInfo.Visible = true;
            DropDownList5.Enabled = false;
            DropDownList7.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox4.Enabled = false;
            Button6.Visible = false;
            Button7.Visible = false;
            UpdatePanel_NewProjectInfo.Update();


            DropDownList5.DataSource = cs.CS_Proc_S_ErrorPhenomenonOption_EPO_Name();
            DropDownList5.DataTextField = "EPO_Name";
            DropDownList5.DataValueField = "EPO_ID";
            DropDownList5.DataBind();
            DropDownList7.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList7.DataTextField = "PBC_Name";
            DropDownList7.DataValueField = "PBC_ID";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            for (int i = 0; i < DropDownList7.Items.Count; i++)
            {
                if (DropDownList7.Items[i].Text.Trim() == label_PBCForList.Text.Trim())
                {
                    DropDownList7.SelectedIndex = i;
                    break;
                }

            }
            for (int i = 0; i < DropDownList5.Items.Count; i++)
            {
                if (DropDownList5.Items[i].Text.Trim() == al[1].Trim())
                {
                    DropDownList5.SelectedIndex = i;
                    break;
                }

            }
            if (DropDownList5.Items.Count != 0)
            {
                string condition;
                condition = " ";
                DropDownList6.DataSource = ppl.S_ErrorPhenomenonOptionDetail(DropDownList5.SelectedValue.ToString().Trim(), condition);
                DropDownList6.DataTextField = "EPOD_Name";
                DropDownList6.DataValueField = "EPOD_ID";
                DropDownList6.DataBind();
               // DropDownList6.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
            }

           
            for (int i = 0; i < DropDownList6.Items.Count; i++)
            {
                if (DropDownList6.Items[i].Text.Trim() == al[2].Trim())
                {
                    DropDownList6.SelectedIndex = i;
                    break;
                }

            }


          
            TextBox4.Text = al[6];
            Label29.Text = al[3];
            Label30.Text = al[5];
            Label1.Text = al[4];

            label_ApplyWO.Text = label_WONum.Text;
            label_ApplyPBC.Text = label_PBCForList.Text;
            label_Change.Text = "申报";

            Panel_NewProjectInfo.Visible = true;
            DropDownList5.Enabled = false;
            DropDownList7.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox4.Enabled = false;
            Button6.Visible = false;
            Button7.Visible = false;
            UpdatePanel_NewProjectInfo.Update();

           
            this.Label_ChuLiWOE_ID.Text= al[0];
            label3.Text = label_PBCForList.Text;
            label2.Text = label_WONum.Text;
            label31.Text = "品保部";
            if (al[7].Trim() == "")
            {
                Label8.Text = Session["UserName"].ToString();
                Label9.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Label10.Text = Session["Department"].ToString();
                TextBox1.Text = "";
            }
            else
            {
                Label8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_DealMan"].ToString().Trim();
                Label9.Text = al[7];
                Label10.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Dep"].ToString().Trim();
                TextBox1.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Measure"].ToString().Trim();
            }
            Panel2.Visible = true;
            UpdatePanel2.Update();
        }

        if (e.CommandName == "gcyccl")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });

            Panel_NewProjectInfo.Visible = true;
            DropDownList5.Enabled = false;
            DropDownList7.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox4.Enabled = false;
            Button6.Visible = false;
            Button7.Visible = false;
            UpdatePanel_NewProjectInfo.Update();

            DropDownList5.DataSource = cs.CS_Proc_S_ErrorPhenomenonOption_EPO_Name();
            DropDownList5.DataTextField = "EPO_Name";
            DropDownList5.DataValueField = "EPO_ID";
            DropDownList5.DataBind();
            DropDownList7.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList7.DataTextField = "PBC_Name";
            DropDownList7.DataValueField = "PBC_ID";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            for (int i = 0; i < DropDownList7.Items.Count; i++)
            {
                if (DropDownList7.Items[i].Text.Trim() == label_PBCForList.Text.Trim())
                {
                    DropDownList7.SelectedIndex = i;
                    break;
                }

            }
            for (int i = 0; i < DropDownList5.Items.Count; i++)
            {
                if (DropDownList5.Items[i].Text.Trim() == al[1].Trim())
                {
                    DropDownList5.SelectedIndex = i;
                    break;
                }

            }
            if (DropDownList5.Items.Count != 0)
            {
                string condition;
                condition = " ";
                DropDownList6.DataSource = ppl.S_ErrorPhenomenonOptionDetail(DropDownList5.SelectedValue.ToString().Trim(), condition);
                DropDownList6.DataTextField = "EPOD_Name";
                DropDownList6.DataValueField = "EPOD_ID";
                DropDownList6.DataBind();
            //    DropDownList6.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
            }

            
            for (int i = 0; i < DropDownList6.Items.Count; i++)
            {
                if (DropDownList6.Items[i].Text.Trim() == al[2].Trim())
                {
                    DropDownList6.SelectedIndex = i;
                    break;
                }

            }





            TextBox4.Text = al[6];
            Label29.Text = al[3];
            Label30.Text=al[5];
            Label1.Text=al[4];

            DropDownList8.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList8.DataTextField = "PBC_Name";
            DropDownList8.DataValueField = "PBC_ID";
            DropDownList8.DataBind();
          //  DropDownList8.Items.Insert(0, new ListItem("请选择", ""));

            DropDownList9.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()),0);
            DropDownList9.DataTextField = "PBC_Name";
            DropDownList9.DataValueField = "WOD_ID";
            DropDownList9.DataBind();
         //   DropDownList9.Items.Insert(0, new ListItem("请选择", ""));

            DropDownList11.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()),1);
            DropDownList11.DataTextField = "PBC_Name";
            DropDownList11.DataValueField = "WOD_ID";
            DropDownList11.DataBind();
          //  DropDownList11.Items.Insert(0, new ListItem("请选择", ""));
            

            label_ApplyWO.Text = label_WONum.Text;
            label_ApplyPBC.Text = label_PBCForList.Text;
            label_Change.Text = "申报";

            this.Label_ChuLiWOE_ID.Text = al[0];
            label3.Text = label_PBCForList.Text;
            label2.Text = label_WONum.Text;
            label31.Text = "工程部";

            if (al[7].Trim() == "")
            {
                Label8.Text = Session["UserName"].ToString();
                Label9.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Label10.Text = Session["Department"].ToString();
                TextBox1.Text = "";
            }
            else
            {
                Label8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_DealMan"].ToString().Trim();
                Label9.Text = al[7];
                Label10.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Dep"].ToString().Trim();
                TextBox1.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Measure"].ToString().Trim();
            }
            DataSet ds = ppd.S_WOError_I_PBC(new Guid(this.Label_ChuLiWOE_ID.Text.Trim()));
            DataView dv = ds.Tables[0].DefaultView;
            foreach (DataRowView datav in dv)
            {
                TextBox5.Text = datav["WOE_PBCNote"].ToString().Trim();
            }
            Panel2.Visible = true;
            UpdatePanel2.Update();

        }

        if (e.CommandName == "scyccl")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });

            Panel_NewProjectInfo.Visible = true;
            DropDownList5.Enabled = false;
            DropDownList7.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox4.Enabled = false;
            Button6.Visible = false;
            Button7.Visible = false;
           

            UpdatePanel_NewProjectInfo.Update();


            DropDownList5.DataSource = cs.CS_Proc_S_ErrorPhenomenonOption_EPO_Name();
            DropDownList5.DataTextField = "EPO_Name";
            DropDownList5.DataValueField = "EPO_ID";
            DropDownList5.DataBind();
            DropDownList7.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList7.DataTextField = "PBC_Name";
            DropDownList7.DataValueField = "PBC_ID";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            for (int i = 0; i < DropDownList7.Items.Count; i++)
            {
                if (DropDownList7.Items[i].Text.Trim() == label_PBCForList.Text.Trim())
                {
                    DropDownList7.SelectedIndex = i;
                    break;
                }

            }
            for (int i = 0; i < DropDownList5.Items.Count; i++)
            {
                if (DropDownList5.Items[i].Text.Trim() == al[1].Trim())
                {
                    DropDownList5.SelectedIndex = i;
                    break;
                }

            }
            if (DropDownList5.Items.Count != 0)
            {
                string condition;
                condition = " ";
                DropDownList6.DataSource = ppl.S_ErrorPhenomenonOptionDetail(DropDownList5.SelectedValue.ToString().Trim(), condition);
                DropDownList6.DataTextField = "EPOD_Name";
                DropDownList6.DataValueField = "EPOD_ID";
                DropDownList6.DataBind();
             //   DropDownList6.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
            }

           
            for (int i = 0; i < DropDownList6.Items.Count; i++)
            {
                if (DropDownList6.Items[i].Text.Trim() == al[2].Trim())
                {
                    DropDownList6.SelectedIndex = i;
                    break;
                }

            }





            TextBox4.Text = al[6];
            Label29.Text = al[3];
            Label30.Text = al[5];
            Label1.Text = al[4];

            label_ApplyWO.Text = label_WONum.Text;
            label_ApplyPBC.Text = label_PBCForList.Text;
            label_Change.Text = "申报";

            Panel_NewProjectInfo.Visible = true;
            DropDownList5.Enabled = false;
            DropDownList7.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox4.Enabled = false;
            Button6.Visible = false;
            Button7.Visible = false;
            UpdatePanel_NewProjectInfo.Update();


            this.Label_ChuLiWOE_ID.Text = al[0];
            label3.Text = label_PBCForList.Text;
            label2.Text = label_WONum.Text;
            label31.Text = "生产部";

            if (al[7].Trim() == "")
            {
                Label8.Text = Session["UserName"].ToString();
                Label9.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Label10.Text = Session["Department"].ToString();
                TextBox1.Text = "";
            }
            else
            {
                Label8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_DealMan"].ToString().Trim();
                Label9.Text = al[7];
                Label10.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Dep"].ToString().Trim();
                TextBox1.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Measure"].ToString().Trim();
            }

            Panel2.Visible = true;
            UpdatePanel2.Update();

        }

        if (e.CommandName == "ckyc")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });

            Panel_NewProjectInfo.Visible = true;
            DropDownList5.Enabled = false;
            DropDownList7.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox4.Enabled = false;
            Button6.Visible = false;
            Button7.Visible = false;
            label7.Text = label_WONum.Text;
            label13.Text = label_PBCForList.Text;
            label4.Text = label_WONum.Text.Trim();
            label6.Text = label_PBCForList.Text;
            TextBox1.Enabled = false;
            Button1.Visible = false;
            TextBox2.Enabled = false;
            sctg.Visible = false;
            scbh.Visible = false;
            TextBox7.Enabled = false;
            pbtg.Visible = false;
            pbbh.Visible = false;
            TextBox8.Enabled = false;
            gctg.Visible = false;
            gcbh.Visible = false;
            TextBox3.Enabled = false;
            Button3.Visible = false;
            Button4.Visible = false;

            UpdatePanel_NewProjectInfo.Update();

            Label15.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQMan"].ToString().Trim();//生产会签人
            Label17.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQTime"].ToString().Trim(); //生产会签时间
            Label18.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQDept"].ToString().Trim(); //生产会签部门
            label51.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQResult"].ToString().Trim(); //生产会签结果
            TextBox2.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_SCHQSuggestion"].ToString().Trim(); //生产会签意见
            Label41.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQMan"].ToString().Trim(); //品保会签人
            Label42.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQtime"].ToString().Trim(); //品保会签时间
            label52.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQResult"].ToString().Trim();  //品保会签结果
            TextBox7.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_PBHQSuggestion"].ToString().Trim();  //品保会签意见
            Label46.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQMan"].ToString().Trim(); //工程会签人
            Label47.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQtime"].ToString().Trim(); //工程会签时间
            label53.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQResult"].ToString().Trim(); //工程会签结果
            TextBox8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_GCHQSuggestion"].ToString().Trim(); //工程会签意见


            DropDownList5.DataSource = cs.CS_Proc_S_ErrorPhenomenonOption_EPO_Name();
            DropDownList5.DataTextField = "EPO_Name";
            DropDownList5.DataValueField = "EPO_ID";
            DropDownList5.DataBind();
            DropDownList7.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList7.DataTextField = "PBC_Name";
            DropDownList7.DataValueField = "PBC_ID";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            for (int i = 0; i < DropDownList7.Items.Count; i++)
            {
                if (DropDownList7.Items[i].Text.Trim() == label_PBCForList.Text.Trim())
                {
                    DropDownList7.SelectedIndex = i;
                    break;
                }

            }
            for (int i = 0; i < DropDownList5.Items.Count; i++)
            {
                if (DropDownList5.Items[i].Text.Trim() == al[1].Trim())
                {
                    DropDownList5.SelectedIndex = i;
                    break;
                }

            }
            if (DropDownList5.Items.Count != 0)
            {
                string condition;
                condition = " ";
                DropDownList6.DataSource = ppl.S_ErrorPhenomenonOptionDetail(DropDownList5.SelectedValue.ToString().Trim(), condition);
                DropDownList6.DataTextField = "EPOD_Name";
                DropDownList6.DataValueField = "EPOD_ID";
                DropDownList6.DataBind();
                //   DropDownList6.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
            }


            for (int i = 0; i < DropDownList6.Items.Count; i++)
            {
                if (DropDownList6.Items[i].Text.Trim() == al[2].Trim())
                {
                    DropDownList6.SelectedIndex = i;
                    break;
                }

            }





            TextBox4.Text = al[6];
            Label29.Text = al[3];
            Label30.Text = al[5];
            Label1.Text = al[4];

            label_ApplyWO.Text = label_WONum.Text;
            label_ApplyPBC.Text = label_PBCForList.Text;
            label_Change.Text = "申报";

            Panel_NewProjectInfo.Visible = true;
            DropDownList5.Enabled = false;
            DropDownList7.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox4.Enabled = false;
            Button6.Visible = false;
            Button7.Visible = false;
            UpdatePanel_NewProjectInfo.Update();


            this.Label_ChuLiWOE_ID.Text = al[0];
            label3.Text = label_PBCForList.Text;
            label2.Text = label_WONum.Text;
            label31.Text = "";

            //if (al[7].Trim() == "")
            //{
            //    Label8.Text = Session["UserName"].ToString();
            //    Label9.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //    Label10.Text = Session["Department"].ToString();
            //    TextBox1.Text = "";
            //}
            //else
            //{
                Label8.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_DealMan"].ToString().Trim();
                Label9.Text = al[7];
                Label10.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Dep"].ToString().Trim();
                TextBox1.Text = GridView_Error.DataKeys[row.RowIndex].Values["WOE_Measure"].ToString().Trim();
            //}

            Panel2.Visible = true;
            UpdatePanel2.Update();
            Panel3.Visible = true;
            UpdatePanel3.Update();
            Panel4.Visible = true;
            UpdatePanel4.Update();

        }
    }
    protected void GridView_Error_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Error.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Error.Rows[i].Cells.Count; j++)
            {
                GridView_Error.Rows[i].Cells[j].ToolTip = GridView_Error.Rows[i].Cells[j].Text;
                if (GridView_Error.Rows[i].Cells[j].Text.Length >16)
                {
                    GridView_Error.Rows[i].Cells[j].Text = GridView_Error.Rows[i].Cells[j].Text.Substring(0, 16) + "...";
                }


            }
        }
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
       

        if (DropDownList5.Items.Count != 0)
        {
            string condition;
            condition = " and PBC_Name = '" + this.DropDownList7.SelectedItem.Text.Trim() + "'";
            DropDownList6.DataSource = ppl.S_ErrorPhenomenonOptionDetail(DropDownList5.SelectedValue.ToString().Trim(), condition);
            DropDownList6.DataTextField = "EPOD_Name";
            DropDownList6.DataValueField = "EPOD_ID";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
        }
    }



    protected void ConfirmProject_Click(object sender, EventArgs e) //提交异常
    {
        if (DropDownList6.SelectedIndex == 0)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请选择异常原因所属详细项目，若没有详细项目请通知责任部门添加！')", true);
            return;
        }
        try
        {
            ppd.CS_I__WOError_apply_NEW(new Guid(DropDownList6.SelectedValue.ToString().Trim()), TextBox4.Text.Trim(), Label29.Text.Trim(), new Guid(label_applywodid.Text.Trim()), Label1.Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('提交失败！')", true);
            return;
        }
        string sErr="";
        string message = "ERP系统信息：" + Session["Department"].ToString()+"的" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了随工单 " + label_ApplyWO.Text + " " + label_ApplyPBC.Text + " 工序的异常信息，请处理！";
        string type = DropDownList5.SelectedItem.Text;
        if (type.Contains("人"))
        {
            sErr = RTXhelper.Send(message, "生产异常处理");
        }
        if (type.Contains("材料"))
        {
            sErr = RTXhelper.Send(message, "品保异常处理");
        }
        if ((!type.Contains("材料")) && (!type.Contains("人")))
        {
            sErr = RTXhelper.Send(message, "工程异常处理");
        }

        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        GridView_Error.DataSource = ppd.S_WOError_new(new Guid(label_applywodid.Text.Trim()));
        GridView_Error.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('提交成功！')", true);
        databind_detail();
        Panel_ErrorList.Visible = true;
        UpdatePanel_ErrorList.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
       // databind_errorlist();
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
       

        if (DropDownList5.Items.Count != 0)
        {
            string condition;
            condition = " and PBC_Name = '" + this.DropDownList7.SelectedItem.Text.Trim() + "'";
            DropDownList6.DataSource = ppl.S_ErrorPhenomenonOptionDetail(DropDownList5.SelectedValue.ToString().Trim(), condition);
            DropDownList6.DataTextField = "EPOD_Name";
            DropDownList6.DataValueField = "EPOD_ID";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
        }
    }
    protected void Button_Cancel1_Click(object sender, EventArgs e)
    {
        Panel_ErrorList.Visible = false;
        UpdatePanel_ErrorList.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
           
            if (drv["WOD_OverTime"].ToString().Trim() == "是")
            {
                e.Row.BackColor = System.Drawing.Color.LightYellow;

            }
            //if (drv["WOD_Error"].ToString().Trim() == "否")
            //{
            //    e.Row.Cells[16].Enabled = false;

            //}
            if (drv["WOD_Error"].ToString().Trim() == "是")
            {
                e.Row.BackColor = System.Drawing.Color.Pink;

            }
        }
    }
    protected void btn1_Click(object sender, EventArgs e)//提交异常处理意见
    {
        try {

            ppd.U_WOError_Deal_NEW(new Guid(Label_ChuLiWOE_ID.Text.Trim()), Label8.Text.Trim(), Label10.Text.Trim(), TextBox1.Text.Trim());
        }

        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('提交失败！')", true);
            return;
        }

        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label2.Text + " " + label3.Text + " 工序的异常信息进行了处理，请您会签！";
        string type = label31.Text;
        if (type.Contains("生产"))
        {
            sErr = RTXhelper.Send(message, "工程异常会签");
        }
        if (type.Contains("工程"))
        {
            sErr = RTXhelper.Send(message, "生产异常会签");
            sErr = RTXhelper.Send(message, "品保异常会签");
        }
        if (type.Contains("品保"))
        {
            message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label2.Text + " " + label3.Text + " 工序的异常信息进行了处理，请工程部知晓！";
            sErr = RTXhelper.Send(message, "工程异常会签");
            sErr = RTXhelper.Send(message, "主导部门跟踪");
        }

        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        databind_errorlist();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
    }
    protected void btn8_Click(object sender, EventArgs e)//添加工序
    {
        
       // UpdatePanel2.Update();
    }
    protected void btn9_Click(object sender, EventArgs e)//删除工序
    {
        try
        {
            ppd.U_WOError_D_PBC(new Guid(DropDownList11.SelectedValue.ToString().Trim()),new Guid(Label_ChuLiWOE_ID.Text.Trim()), Session["UserName"].ToString().Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！')", true);
            return;
        }

        DataSet ds = ppd.S_WOError_I_PBC(new Guid(this.Label_ChuLiWOE_ID.Text.Trim()));
        DataView dv = ds.Tables[0].DefaultView;
        foreach (DataRowView datav in dv)
        {
            TextBox5.Text = datav["WOE_PBCNote"].ToString().Trim();
        }
        DropDownList8.DataSource = erl.S_WOError_Rework_PBCraft();
        DropDownList8.DataTextField = "PBC_Name";
        DropDownList8.DataValueField = "PBC_ID";
        DropDownList8.DataBind();
        //DropDownList8.Items.Insert(0, new ListItem("请选择", ""));

        DropDownList9.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 0);
        DropDownList9.DataTextField = "PBC_Name";
        DropDownList9.DataValueField = "WOD_ID";
        DropDownList9.DataBind();
        // DropDownList9.Items.Insert(0, new ListItem("请选择", ""));

        DropDownList11.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 1);
        DropDownList11.DataTextField = "PBC_Name";
        DropDownList11.DataValueField = "WOD_ID";
        DropDownList11.DataBind();
        // DropDownList11.Items.Insert(0, new ListItem("请选择", ""));
        databind_detail();
        databind_errorlist();
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
            ppd.U_WOError_I_PBC(new Guid(label_WO_ID.Text.Trim()), new Guid(DropDownList9.SelectedValue.ToString().Trim()), new Guid(DropDownList8.SelectedValue.ToString().Trim()), new Guid(Label_ChuLiWOE_ID.Text.Trim()), Session["UserName"].ToString().Trim(), Convert.ToInt32(DropDownList10.SelectedValue.ToString().Trim()));
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！')", true);
            return;
        }
        DataSet ds = ppd.S_WOError_I_PBC(new Guid(this.Label_ChuLiWOE_ID.Text.Trim()));
        DataView dv = ds.Tables[0].DefaultView;
        foreach (DataRowView datav in dv)
        {
            TextBox5.Text = datav["WOE_PBCNote"].ToString().Trim();
        }
        DropDownList8.DataSource = erl.S_WOError_Rework_PBCraft();
        DropDownList8.DataTextField = "PBC_Name";
        DropDownList8.DataValueField = "PBC_ID";
        DropDownList8.DataBind();
        //DropDownList8.Items.Insert(0, new ListItem("请选择", ""));

        DropDownList9.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 0);
        DropDownList9.DataTextField = "PBC_Name";
        DropDownList9.DataValueField = "WOD_ID";
        DropDownList9.DataBind();
       // DropDownList9.Items.Insert(0, new ListItem("请选择", ""));

        DropDownList11.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 1);
        DropDownList11.DataTextField = "PBC_Name";
        DropDownList11.DataValueField = "WOD_ID";
        DropDownList11.DataBind();
       // DropDownList11.Items.Insert(0, new ListItem("请选择", ""));
        databind_detail();
        databind_errorlist();
    }
    protected void Button17_Click(object sender, EventArgs e)//关闭会签pannel

    {

        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void sctg_Click(object sender, EventArgs e)//生产通过
    {
        try
        {
            ppd.U_WOError_HQ(new Guid(Label_WOEID.Text.Trim()), "生产", Session["UserName"].ToString(), "通过", TextBox2.Text.Trim(), Session["Department"].ToString());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签成功！')", true);
  
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签失败！')", true);
            return;
        }
        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label4.Text + " " + label6.Text + " 工序的异常信息进行了会签，会签结果为：通过";
        string type = label31.Text;
        
        sErr = RTXhelper.Send(message, "工程异常处理");
       // sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        Panel3.Visible = false;
        UpdatePanel3.Update();
        databind_detail();
        databind_errorlist();
    }
    protected void scbh_Click(object sender, EventArgs e)//生产驳回
    {
        try
        {
            ppd.U_WOError_HQ(new Guid(Label_WOEID.Text.Trim()), "生产", Session["UserName"].ToString(), "不通过", TextBox2.Text.Trim(), Session["Department"].ToString());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签成功！')", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签失败！')", true);
            return;
        }

        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label4.Text + " " + label6.Text + " 工序的异常信息进行了会签，会签结果为：不通过";
        string type = label31.Text;

        sErr = RTXhelper.Send(message, "工程异常处理");
        //sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        Panel3.Visible = false;
        UpdatePanel3.Update();
        databind_detail();
        databind_errorlist();
    }
    protected void pbtg_Click(object sender, EventArgs e)//品保通过
    {
        try
        {
            ppd.U_WOError_HQ(new Guid(Label_WOEID.Text.Trim()), "品保", Session["UserName"].ToString(), "通过", TextBox7.Text.Trim(), Session["Department"].ToString());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签成功！')", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签失败！')", true);
            return;
        }
        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label4.Text + " " + label6.Text + " 工序的异常信息进行了会签，会签结果为：通过";
       //string type = label31.Text;

        sErr = RTXhelper.Send(message, "工程异常处理");
        //sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        Panel3.Visible = false;
        UpdatePanel3.Update();
        databind_detail();
        databind_errorlist();
    }
    protected void pbbh_Click(object sender, EventArgs e)//品保驳回
    {
        try
        {
            ppd.U_WOError_HQ(new Guid(Label_WOEID.Text.Trim()), "品保", Session["UserName"].ToString(), "不通过", TextBox7.Text.Trim(), Session["Department"].ToString());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签成功！')", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签失败！')", true);
            return;
        }
        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label4.Text + " " + label6.Text + " 工序的异常信息进行了会签，会签结果为：不通过";
        //string type = label31.Text;

        sErr = RTXhelper.Send(message, "工程异常处理");
        //sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        Panel3.Visible = false;
        UpdatePanel3.Update();
        databind_detail();
        databind_errorlist();
    }
    protected void gctg_Click(object sender, EventArgs e)//工程通过
    {
        try
        {
            ppd.U_WOError_HQ(new Guid(Label_WOEID.Text.Trim()), "工程", Session["UserName"].ToString(), "通过", TextBox8.Text.Trim(), Session["Department"].ToString());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签成功！')", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签失败！')", true);
            return;
        }
        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label4.Text + " " + label6.Text + " 工序的异常信息进行了会签，会签结果为：通过";
        //string type = label31.Text;

        sErr = RTXhelper.Send(message, "生产异常处理");
        //sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        Panel3.Visible=false;
        UpdatePanel3.Update();
        databind_detail();
        databind_errorlist();
    }
    protected void gcbh_Click(object sender, EventArgs e)//工程驳回
    {
        try
        {
            ppd.U_WOError_HQ(new Guid(Label_WOEID.Text.Trim()), "工程", Session["UserName"].ToString(), "不通过", TextBox8.Text.Trim(), Session["Department"].ToString());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签成功！')", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('会签失败！')", true);
            return;
        }
        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label4.Text + " " + label6.Text + " 工序的异常信息进行了会签，会签结果为：不通过";
        //string type = label31.Text;

        sErr = RTXhelper.Send(message, "生产异常处理");
        //sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        Panel3.Visible = false;
        UpdatePanel3.Update();
        databind_detail();
        databind_errorlist();
    }
    protected void Button18_Click(object sender, EventArgs e)//关闭跟踪
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }
    protected void Button4_Click(object sender, EventArgs e)//结案不通过
    {
        try
        {
            ppd.U_WOError_GZJA(new Guid(label_WOE_ID_GZJA.Text.Trim()), Session["UserName"].ToString().Trim(), "不通过", TextBox8.Text.Trim(), Session["Department"].ToString().Trim());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('跟踪结案成功！')", true);
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('跟踪结案失败！')", true);
            return;
        }
        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label7.Text + " " + label13.Text + " 工序的异常信息进行了跟踪结案，跟踪结案结果为：不通过";
        //string type = label31.Text;

        sErr = RTXhelper.Send(message, "异常申报");
        //sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        Panel4.Visible = false;
        UpdatePanel4.Update();
        databind_detail();
        databind_errorlist();
    }
    protected void Button3_Click(object sender, EventArgs e)//结案通过
    {
        try
        {
            ppd.U_WOError_GZJA(new Guid(label_WOE_ID_GZJA.Text.Trim()),Session["UserName"].ToString().Trim(),"通过",TextBox8.Text.Trim(),Session["Department"].ToString().Trim());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('跟踪结案成功！')", true);
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('跟踪结案失败！')", true);
            return;
        }
        string sErr = "";
        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "已经对随工单 " + label7.Text + " " + label13.Text + " 工序的异常信息进行了跟踪结案，跟踪结案结果为：通过";
        //string type = label31.Text;

        sErr = RTXhelper.Send(message, "异常申报");
        //sErr = RTXhelper.Send(message, "主导部门跟踪");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }

        Panel4.Visible = false;
        UpdatePanel4.Update();
        databind_detail();
        databind_errorlist();

    }
    protected void GridView_Error_RowDataBound(object sender, GridViewRowEventArgs e)//有的不用会签
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["EPO_Name"].ToString().Trim().Contains("人"))
            {
                e.Row.Cells[16].Enabled = false;
                e.Row.Cells[16].ForeColor = System.Drawing.Color.Gray;
                e.Row.Cells[17].Enabled = false;
                e.Row.Cells[17].ForeColor = System.Drawing.Color.Gray;
                e.Row.Cells[18].Enabled = true;
                LinkButton pb = e.Row.FindControl("pbyccl") as LinkButton;
                LinkButton gcyccl = e.Row.FindControl("gcyccl") as LinkButton;
                LinkButton scyccl = e.Row.FindControl("scyccl") as LinkButton;
                LinkButton gchq = e.Row.FindControl("gchq") as LinkButton;
                LinkButton gzja = e.Row.FindControl("gzja") as LinkButton;
                
                pb.Enabled = false;
                gcyccl.Enabled = false;
                scyccl.Enabled = true;
                scyccl.ForeColor = System.Drawing.Color.Black;
                if (drv["WOE_State"].ToString().Trim() == "已处理")
                {
                    gchq.ForeColor = System.Drawing.Color.Black;
                    gchq.Enabled = true;
                }
                else
                {
                    gchq.ForeColor = System.Drawing.Color.Gray;
                    gchq.Enabled = false;
                }
                if (drv["WOE_State"].ToString().Trim() == "会签通过")
                {
                    gzja.Enabled = true;
                    gzja.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    gzja.Enabled = false;
                    gzja.ForeColor = System.Drawing.Color.Gray;
                }
            }
            if ((!drv["EPO_Name"].ToString().Trim().Contains("材料")) && (!drv["EPO_Name"].ToString().Trim().Contains("人")))
            {
                //e.Row.Cells[16].Enabled = false;
                //e.Row.Cells[16].ForeColor = System.Drawing.Color.Gray;
                //e.Row.Cells[17].Enabled = false;
                //e.Row.Cells[17].ForeColor = System.Drawing.Color.Gray;
                LinkButton schq = e.Row.FindControl("schq") as LinkButton;
                LinkButton pbhq = e.Row.FindControl("pbhq") as LinkButton;
                LinkButton gzja = e.Row.FindControl("gzja") as LinkButton;
                if (drv["WOE_State"].ToString().Trim() == "已处理")
                {
                    pbhq.ForeColor = System.Drawing.Color.Black;
                    pbhq.Enabled=true;
                    schq.ForeColor = System.Drawing.Color.Black;
                    schq.Enabled = true;
                }
                else
                {
                    pbhq.ForeColor = System.Drawing.Color.Gray;
                    pbhq.Enabled = false;
                    schq.ForeColor = System.Drawing.Color.Gray;
                    schq.Enabled = false;
                }


                e.Row.Cells[18].Enabled = false;
                e.Row.Cells[18].ForeColor = System.Drawing.Color.Gray;
                LinkButton pb = e.Row.FindControl("pbyccl") as LinkButton;
                LinkButton gcyccl = e.Row.FindControl("gcyccl") as LinkButton;
                LinkButton scyccl = e.Row.FindControl("scyccl") as LinkButton;


                pb.Enabled = false;
                gcyccl.Enabled = true;
                scyccl.Enabled = false;
                gcyccl.ForeColor = System.Drawing.Color.Black;

                if (drv["WOE_State"].ToString().Trim() == "会签通过")
                {
                    gzja.Enabled = true;
                    gzja.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    gzja.Enabled = false;
                    gzja.ForeColor = System.Drawing.Color.Gray;
                }
            }
            if (drv["EPO_Name"].ToString().Trim().Contains("材料"))
            {
                LinkButton gzja = e.Row.FindControl("gzja") as LinkButton;
                e.Row.Cells[16].Enabled = false;
                e.Row.Cells[16].ForeColor = System.Drawing.Color.Gray;
                e.Row.Cells[17].Enabled = false;
                e.Row.Cells[17].ForeColor = System.Drawing.Color.Gray;
                e.Row.Cells[18].Enabled = false;
                e.Row.Cells[18].ForeColor = System.Drawing.Color.Gray;

                LinkButton pb = e.Row.FindControl("pbyccl") as LinkButton;
                LinkButton gcyccl = e.Row.FindControl("gcyccl") as LinkButton;
                LinkButton scyccl = e.Row.FindControl("scyccl") as LinkButton;
                pb.Enabled = true;
                pb.ForeColor = System.Drawing.Color.Black;
                gcyccl.Enabled = false;
                scyccl.Enabled = false;

                if (drv["WOE_State"].ToString().Trim() == "已处理")
                {
                    gzja.Enabled = true;
                    gzja.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    gzja.Enabled = false;
                    gzja.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }
    }
}