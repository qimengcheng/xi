using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProductionProcess_WorkOrderCheck : System.Web.UI.Page
{
    WOSSalaryL wosl = new WOSSalaryL();
    ErrorRelevantL erl = new ErrorRelevantL();
    WorkOrderCheckL wcl = new WorkOrderCheckL();
    ProductionProcessD ppd = new ProductionProcessD();
    CSD cs = new CSD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.label_GridPageState.Text = "默认数据源";

        if (!IsPostBack)
        {
            if (Request.QueryString["state"] == null)
            {

                this.Title = "在制品查看";
                //制定权限各种隐藏
                Button3.Visible = false;
                GridView_People.Columns[0].Visible = false;
                t1.Visible = false;
                Panel_Product.Visible = false;
                UpdatePanel_Product.Update();
                Button16.Visible = false;
                GridView_Time.Columns[0].Visible = false;
                t2.Visible = false;
                fg1.Visible = false;
                Label6.Visible = false;
                DropDownList8.Visible = false;
                DropDownList9.Visible = false;
                Button21.Visible = false;
                Label7.Visible = false;
                Label9.Visible = false;

                GridView_WOmain.Columns[16].Visible = false;
                jjlx.Visible = false;

                GridView1.Columns[16].Visible = false;
                GridView1.Columns[17].Visible = false;
                GridView1.Columns[18].Visible = false;

                GridView_People.Columns[6].Visible = false;
                GridView_Time.Columns[5].Visible = false;
            }
            else
            {
                this.Title = "在制品维护";

            }
            string condition = " and 1=1";
            try
            {
                if (Request.QueryString["WO_Type"].ToString() == "检验")
                {
                    condition = " and WO_Type='检验' ";
                    DropDownList_WO_Type.SelectedIndex = 3;
                    DropDownList_WO_Type.Enabled = false;
                }
            }
            catch (Exception)
            {
                condition = " and 1=1";
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
            label_Condition.Text = condition;
            this.GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
            this.GridView_WOmain.DataBind();
            this.UpdatePanel_WOmain.Update();




        }
    }
    public void databind_shebei()
    {

        GridView5.DataSource = wcl.S_WorkOrderDetail_Equipment(new Guid(this.label_SheBeiwoid.Text.Trim()));
        GridView5.DataBind();
        UpdatePanel5.Update();

    }

    public void databind_jjlx()
    {

        DataSet ds_jjlx = cs.CS_S_SalaryPieceworkItem_PBCraftInfo(new Guid(label_PBC_ID_P.Text.Trim()), label_WONum.Text.Trim());
        DataTable dt = ds_jjlx.Tables[0];

        DataRow dr = dt.NewRow();
        DataRow dr2 = dt.NewRow();
        dr["计件类型"] = "请选择";
        dr["SPI_ID"] = "00000000-0000-0000-0000-000000000001";

        dr2["计件类型"] = "不计计件工资";
        dr2["SPI_ID"] = "00000000-0000-0000-0000-000000000000";
        dt.Rows.InsertAt(dr, 0);
        dt.Rows.InsertAt(dr2, 1);
        DropDownList12.DataSource = dt;
        DropDownList12.DataValueField = "SPI_ID";
        DropDownList12.DataTextField = "计件类型";
        DropDownList12.DataBind();

    }

    public DataTable GetDs2()
    {


        DataSet ds_jjlx = cs.CS_S_SalaryPieceworkItem_PBCraftInfo(new Guid(label_PBC_ID_P.Text.Trim()), label_WONum.Text.Trim());
        DataTable dt = ds_jjlx.Tables[0];
        DataRow dr = dt.NewRow();
        dr["SPI_ID"] = "00000000-0000-0000-0000-000000000000";
        dr["计件类型"] = "不计计件工资";
        dt.Rows.InsertAt(dr, 0);
        return dt;
    }
    public void databind()
    {
        string condition;
        string WO_Type = "";
        try
        {
            if (Request.QueryString["WO_Type"].ToString() == "检验")
            {
                WO_Type = " and WO_Type='检验' ";
                DropDownList_WO_Type.SelectedIndex = 3;
                DropDownList_WO_Type.Enabled = false;
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
        condition = WO_Type + WO_Time + WO_Num + pbcname + SMSO_ComOrderNum + WO_ProType + WO_State + WO_SN + error + otime + gx + pihao;
        Label_searchCondition.Text = condition;
        this.GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        this.GridView_WOmain.DataBind();
        this.UpdatePanel_WOmain.Update();

    }

    public void databind_pihao()
    {
        string condition;
        string IMMBD_MaterialName = this.TextBox3.Text.Trim() == "" ? " and 1=1 " : "and IMMBD_MaterialName like '%" + this.TextBox3.Text.Trim() + "%' ";
        string IMID_BatchNum = this.TextBox2.Text.Trim() == "" ? " and 1=1 " : "and IMID_BatchNum like '%" + this.TextBox2.Text.Trim() + "%' ";
        string IMMBD_SpecificationModel = this.TextBox1.Text.Trim() == "" ? " and 1=1 " : "and IMMBD_SpecificationModel like '%" + this.TextBox1.Text.Trim() + "%' ";
        condition = IMMBD_MaterialName + IMID_BatchNum + IMMBD_SpecificationModel;
        GridView4.DataSource = cs.CS_S_WOMBatchNum_IMInventoryDetail_NEW2(condition, this.label_WONum.Text.Trim());
        GridView4.DataBind();
        UpdatePanel4.Update();

    }

    public void databind_detail()
    {
        GridView1.DataSource = ppd.S_WODetail_Check(new Guid(label_WO_ID.Text.Trim()));
        GridView1.DataBind();
        UpdatePanel1.Update();

    }
    public void databind_people()
    {
        Guid wodid = new Guid(label_People_WODID.Text.Trim());
        GridView_People.DataSource = wcl.S_WorkOrderDetail_OperatorInfo(wodid);
        GridView_People.DataBind();
        UpdatePanel_People.Update();
    }

    public void databind_dxpeople()
    {
        string condition;
        string HRDD_StaffNO = this.TextBox_Series.Text.Trim() == "" ? " and 1=1 " : "and HRDD_StaffNO like '%" + this.TextBox_Series.Text.Trim() + "%' ";
        string EquipName = this.TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : "and HRDD_Name like '%" + this.TextBox_ProductName.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + EquipName + " and HRDD_StaffNO not in (select HRDD_StaffNO from OperatorInfo a inner join HRDDetail b on a.HRDD_ID=b.HRDD_ID and  WOD_ID = (SELECT WOD_ID   FROM   WODetail c INNER JOIN WorkOrder d ON c.WO_ID = d.WO_ID WHERE  WOD_WOState LIKE '%工序已开启%' AND WO_Num ='" + this.label_WONum.Text.Trim() + "' AND PBC_ID = (SELECT PBC_ID FROM   PBCraftInfo WHERE  PBC_Name = '" + this.label_PBCName.Text.Trim() + "'))" + " AND OI_Deleted=0" + " )";
        if (DropDownList5.SelectedIndex == 0)
        {

            DataSet ds1 = cs.CS_S_HRDDetail_people(condition);
            GridView_ProType.DataSource = ds1;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();
        }
        else
        {


            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList5.SelectedValue.ToString().Trim() + "' " + condition);
            GridView_ProType.DataSource = ds3;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();

        }
    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        GridView_WOmain.SelectedIndex = -1;
        databind();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        this.label_GridPageState.Text = "检索数据源";
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        //panel 各种隐藏

        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();

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
                DropDownList_WO_Type.SelectedIndex = 3;
                DropDownList_WO_Type.Enabled = false;

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
        label_Condition.Text = condition;
        Label_searchCondition.Text = "";
        this.GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        this.GridView_WOmain.DataBind();

        this.UpdatePanel_WOmain.Update();

        GridView_WOmain.SelectedIndex = -1;
    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)//随工单表翻页
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


        //if (this.label_GridPageState.Text == "默认数据源")
        //{
        //    string condition = " and 1=1";
        //    try
        //    {
        //        if (Request.QueryString["WO_Type"].ToString() == "检验")
        //        {   condition = " and WO_Type='检验' ";
        //            DropDownList_WO_Type.SelectedIndex = 3;
        //            DropDownList_WO_Type.Enabled=false;

        //        }
        //        else
        //        {
        //            condition = " and 1=1";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        condition = " and 1=1";
        //    }
        //    this.GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        //    this.GridView_WOmain.DataBind();
        //    this.UpdatePanel_WOmain.Update();
        //}
        //if (this.label_GridPageState.Text == "检索数据源")
        //{
        databind();
        // }

        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

        GridView_WOmain.SelectedIndex = -1;

        //不良品信息
        Panel7.Visible = false;
        UpdatePanel7.Update();
        //设备信息
        Panel5.Visible = false;
        Panel6.Visible = false;
        UpdatePanel6.Update();
        UpdatePanel5.Update();
        //批号信息隐藏
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();
        //人员信息各种隐藏
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)//随工单表行命令
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
            Panel_People.Visible = false;
            UpdatePanel_People.Update();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();

            DropDownList8.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList8.DataTextField = "PBC_Name";
            DropDownList8.DataValueField = "PBC_ID";
            DropDownList8.DataBind();
            //  DropDownList8.Items.Insert(0, new ListItem("请选择", ""));

            DropDownList9.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 0);
            DropDownList9.DataTextField = "PBC_Name";
            DropDownList9.DataValueField = "WOD_ID";
            DropDownList9.DataBind();
            //   DropDownList9.Items.Insert(0, new ListItem("请选择", ""));

            DropDownList11.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 1);
            DropDownList11.DataTextField = "PBC_Name";
            DropDownList11.DataValueField = "WOD_ID";
            DropDownList11.DataBind();
            //  DropDownList11.Items.Insert(0, new ListItem("请选择", ""));

            //不良品信息
            Panel7.Visible = false;
            UpdatePanel7.Update();
            //设备信息
            Panel5.Visible = false;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            //批号信息隐藏
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel4.Visible = false;
            UpdatePanel4.Update();
            //人员信息各种隐藏
            Panel_People.Visible = false;
            UpdatePanel_People.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();

            UpdatePanel3.Update();



        }

        if (e.CommandName == "ph")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_WO_ID.Text = al[0];
            label_WONum.Text = al[1];

            DataSet ds2 = cs.CS_S_WOMBatchNum(this.label_WONum.Text.Trim());

            GridView3.DataSource = ds2.Tables[0].DefaultView;
            GridView3.DataBind();
            CheckBox7.Checked = false;
            CheckBox8.Checked = false;


            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel3.Visible = true;
            Panel4.Visible = false;
            UpdatePanel4.Update();
            Panel5.Visible = false;
            UpdatePanel5.Update();
            Panel6.Visible = false;
            UpdatePanel6.Update();
            Panel7.Visible = false;
            UpdatePanel7.Update();

            //人员信息各种隐藏
            Panel_People.Visible = false;
            UpdatePanel_People.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();

            UpdatePanel3.Update();

        }
    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_WOmain_Sorting(object sender, GridViewSortEventArgs e)//排序
    {

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

    protected void GridView_People_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "checktime")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_People.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_OIID.Text = al[0];

            Guid oiid;
            if (al[0].Trim() != "")
            {
                oiid = new Guid(al[0]);
            }
            else
            {
                oiid = new Guid("00000000-0000-0000-0000-000000000000");

            }
            GridView_Time.SelectedIndex = -1;
            GridView_Time.DataSource = wcl.S_WorkOrderDetail_OTime(oiid);
            GridView_Time.DataBind();


            //panel 各种隐藏


            Panel_People.Visible = true;
            UpdatePanel_People.Update();
            Panel_Time.Visible = true;
            UpdatePanel_Time.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
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
        if (e.CommandName == "zyy")//
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_People_WODID.Text = al[0];
            label_PBCName.Text = al[1];
            label_PBC_ID_P.Text = al[2];
            Panel_People.Visible = true;
            databind_people();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            GridView_People.SelectedIndex = -1;
            databind_jjlx();
            CheckBoxfanxuan.Checked = false;
            CheckBoxAll.Checked = false;
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();


            //不良品信息
            Panel7.Visible = false;
            UpdatePanel7.Update();
            //设备信息
            Panel5.Visible = false;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            //批号信息隐藏
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel4.Visible = false;
            UpdatePanel4.Update();
            ////人员信息各种隐藏
            //Panel_People.Visible = false;
            //UpdatePanel_People.Update();
            //Panel_Product.Visible = false;
            //UpdatePanel_Product.Update();
            //Panel_Time.Visible = false;
            //UpdatePanel_Time.Update();
            //Panel2.Visible = false;
            //UpdatePanel2.Update();
        }



        if (e.CommandName == "sb")//
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_SheBeiwoid.Text = al[0];
            label_SheBeipbcname.Text = al[2];
            label_shebeipbcid.Text = al[1];
            CheckBox11.Checked = false;
            CheckBox12.Checked = false;
            databind_shebei();

            //不良品信息
            Panel7.Visible = false;
            UpdatePanel7.Update();
            //设备信息
            Panel5.Visible = true;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            //批号信息隐藏
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel4.Visible = false;
            UpdatePanel4.Update();
            //人员信息各种隐藏
            Panel_People.Visible = false;
            UpdatePanel_People.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();


        }

        if (e.CommandName == "blp")//
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            this.label_bad_WODID.Text = al[0];
            this.label_bad_PBCID.Text = al[1];

            DataSet ds_BadProduct = cs.CS_S_WorkOrderDetail_BadProduct2(new Guid(this.label_bad_WODID.Text.Trim()), new Guid(this.label_bad_PBCID.Text.Trim()));

            GridView6.DataSource = ds_BadProduct.Tables[0].DefaultView;
            GridView6.DataBind();


            //不良品信息
            Panel7.Visible = true;
            UpdatePanel7.Update();
            //设备信息
            Panel5.Visible = false;
            Panel6.Visible = false;
            UpdatePanel6.Update();
            UpdatePanel5.Update();
            //批号信息隐藏
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel4.Visible = false;
            UpdatePanel4.Update();
            //人员信息各种隐藏
            Panel_People.Visible = false;
            UpdatePanel_People.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();


        }
    }
    protected void Button_Cancel0_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
    }

    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_People.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_People.Rows[i].FindControl("CheckBox1");
            if (CheckBoxAll.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxfanxuan.Checked = false;
    }
    protected void Checkfanxuan_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_People.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_People.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxAll.Checked = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {


        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        DataSet ds = cs.CS_S_WorkingTeam_Name();
        DataTable dt = ds.Tables[0];
        DataRow dr = dt.NewRow();
        dr["WT_Name"] = "--选择所有--";
        dt.Rows.InsertAt(dr, 0);
        this.DropDownList5.DataSource = dt;
        this.DropDownList5.DataValueField = "WT_ID";
        this.DropDownList5.DataTextField = "WT_Name";
        DropDownList5.DataBind();

        if (DropDownList5.Items.Count != 0)
        {
            try
            {
                for (int i = 0; i < DropDownList5.Items.Count; i++)
                {


                    if (DropDownList5.Items[i].Text.Contains(this.label_PBCName.Text.Trim()))
                    {
                        DropDownList5.SelectedIndex = i;
                        break;
                    }
                }
            }

            catch (Exception)
            {
                this.DropDownList5.SelectedIndex = 1;
            }
        }

        else
        {
            this.DropDownList5.SelectedIndex = 0;
        }

        if (DropDownList5.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and HRDD_StaffNO not in (select HRDD_StaffNO from OperatorInfo a inner join HRDDetail b on a.HRDD_ID=b.HRDD_ID and  WOD_ID ='" + label_People_WODID.Text.Trim() + "' AND OI_Deleted=0" + ")");
            GridView_ProType.DataSource = ds2;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList5.SelectedValue.ToString().Trim() + "'" + " and HRDD_StaffNO not in (select HRDD_StaffNO from OperatorInfo a inner join HRDDetail b on a.HRDD_ID=b.HRDD_ID and  WOD_ID ='" + label_People_WODID.Text.Trim() + "' AND OI_Deleted=0" + ")");
            GridView_ProType.DataSource = ds3;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();

        }

        Panel_Product.Visible = true;
        UpdatePanel_Product.Update();
    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_People.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_People.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        cs.CS_D_OperatorInfo(new Guid(GridView_People.DataKeys[i].Values["OI_ID"].ToString().Trim()));
                        sum++;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('所选人员中，有人员填写了计时信息，请先删除改员工的计时信息再删除该人员！')", true);
                        break;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('您没选择任何要删除的记录！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }

        databind_people();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        CheckBoxAll.Checked = false;
        Checkfanxuan2.Checked = false;

    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox2.Checked = false;
    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        Guid id = new Guid(GridView_ProType.DataKeys[i].Values["HRDD_ID"].ToString().Trim());
                        cs.Cs_I_WorkOrderDetail_OperatorInfo_New(new Guid(label_People_WODID.Text.Trim()), id);
                        sum++;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！')", true);
                        break;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('您没选择任何要添加的记录！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);


        }

        databind_people();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
    }
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void SelectProType(object sender, EventArgs e)
    {
        databind_dxpeople();
    }
    protected void Button15_Click(object sender, EventArgs e)//重置
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        if (DropDownList5.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and HRDD_StaffNO not in (select HRDD_StaffNO from OperatorInfo a inner join HRDDetail b on a.HRDD_ID=b.HRDD_ID and  WOD_ID ='" + label_People_WODID.Text.Trim() + "' AND OI_Deleted=0" + ")");
            GridView_ProType.DataSource = ds2;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList5.SelectedValue.ToString().Trim() + "'" + " and HRDD_StaffNO not in (select HRDD_StaffNO from OperatorInfo a inner join HRDDetail b on a.HRDD_ID=b.HRDD_ID and  WOD_ID ='" + label_People_WODID.Text.Trim() + "' AND OI_Deleted=0" + ")");
            GridView_ProType.DataSource = ds3;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();

        }
    }
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_ProType.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_ProType.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;

        databind_dxpeople();




        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and HRDD_StaffNO not in (select HRDD_StaffNO from OperatorInfo a inner join HRDDetail b on a.HRDD_ID=b.HRDD_ID and  WOD_ID ='" + label_People_WODID.Text.Trim() + "' AND OI_Deleted=0" + ")");
            GridView_ProType.DataSource = ds2;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList5.SelectedValue.ToString().Trim() + "'" + " and HRDD_StaffNO not in (select HRDD_StaffNO from OperatorInfo a inner join HRDDetail b on a.HRDD_ID=b.HRDD_ID and  WOD_ID ='" + label_People_WODID.Text.Trim() + "' AND OI_Deleted=0" + ")");
            GridView_ProType.DataSource = ds3;
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();

        }
    }
    protected void GridView_People_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_People.EditIndex = e.NewEditIndex;

        string value1 = ((Label)GridView_People.Rows[e.NewEditIndex].FindControl("lbl1")).Text;
        databind_people();
        DropDownList d1 = (DropDownList)GridView_People.Rows[e.NewEditIndex].FindControl("Dltype1111111111");

        for (int i = 0; i < d1.Items.Count; i++)
        {
            if (d1.Items[i].Text == value1)
            {
                d1.SelectedIndex = i;
                break;

            }

        }


        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void GridView_People_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_People.EditIndex = -1;
        databind_people();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
    }
    protected void GridView_People_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int i = 0;
            Guid id = new Guid(GridView_People.DataKeys[e.RowIndex].Values["OI_ID"].ToString().Trim());
            string num = Convert.ToString(((TextBox)(GridView_People.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim().ToString());
            string type = ((DropDownList)GridView_People.Rows[e.RowIndex].FindControl("Dltype1111111111")).SelectedItem.Text.Trim();
            Guid pieceid = new Guid(((DropDownList)GridView_People.Rows[e.RowIndex].FindControl("Dltype1111111111")).SelectedValue.ToString().Trim());
            try
            {
                i = Convert.ToInt32(num.Trim());
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('计件数必须是整数形式！')", true);
            }
            cs.CS_U_OperatorInfo_new2(id, i, type, pieceid);



        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('编辑失败！')", true);
        }
        GridView_People.EditIndex = -1;
        databind_people();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void CheckBoxAll3_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_Time.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_Time.Rows[i].FindControl("CheckBox2");
            if (CheckBox3.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox4.Checked = false;
    }
    protected void Checkfanxuan3_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_Time.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_Time.Rows[i].FindControl("CheckBox2");
            if (CheckBox4.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox3.Checked = false;
    }
    protected void Button4_Click(object sender, EventArgs e)//删除计时项目
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_Time.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_Time.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        cs.CS_D_WODetail_OTime(new Guid(GridView_Time.DataKeys[i].Values["OT_ID"].ToString().Trim()));
                        sum++;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！')", true);
                        return;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('您没选择任何要删除的记录！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }
        GridView_Time.SelectedIndex = -1;
        GridView_Time.DataSource = wcl.S_WorkOrderDetail_OTime(new Guid(label_OIID.Text.Trim()));
        GridView_Time.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel_Time.Update();

    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;

        string condition;
        condition = " and PBC_ID=(select PBC_ID from PBCraftInfo where PBC_Name='" + this.label_PBCName.Text.Trim() + "' and PBC_Deleted=0)" + "and STI_ID not in (select STI_ID from dbo.OTime where OI_ID='" + this.label_OIID.Text.Trim() + "')";
        GridView2.DataSource = cs.CS_S_SalaryTimeItem_PBC_CraftInfo(condition);
        GridView2.DataBind();
        UpdatePanel2.Update();
    }
    protected void Button7_Click(object sender, EventArgs e)//添加计时项目
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        Guid id = new Guid(GridView2.DataKeys[i].Values["STI_ID"].ToString().Trim());
                        cs.CS_I_WorkOrderDetail_OTime(new Guid(this.label_OIID.Text.Trim()), id);
                        sum++;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！')", true);
                        break;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('您没选择任何要添加的记录！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);
        }

        GridView_Time.SelectedIndex = -1;
        GridView_Time.DataSource = wcl.S_WorkOrderDetail_OTime(new Guid(label_OIID.Text.Trim()));
        GridView_Time.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel_Time.Update();

    }
    protected void CheckBoxAll5_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");
            if (CheckBox5.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox6.Checked = false;

    }
    protected void Checkfanxuan6_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");
            if (CheckBox6.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox5.Checked = false;
    }
    protected void GridView_Time_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_Time.EditIndex = e.NewEditIndex;
        GridView_Time.SelectedIndex = -1;
        GridView_Time.DataSource = wcl.S_WorkOrderDetail_OTime(new Guid(label_OIID.Text.Trim()));
        GridView_Time.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel_Time.Update();
    }
    protected void GridView_Time_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid OT_ID = new Guid(GridView_Time.DataKeys[e.RowIndex].Values["OT_ID"].ToString());
        try
        {

            decimal t = ((TextBox)(GridView_Time.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView_Time.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
            int n = ((TextBox)(GridView_Time.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Time.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString());
            wosl.U_OTime_OT_NORelated(OT_ID, t, n);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
            return;
        }
        GridView_Time.SelectedIndex = -1;
        GridView_Time.EditIndex = -1;
        GridView_Time.DataSource = wcl.S_WorkOrderDetail_OTime(new Guid(label_OIID.Text.Trim()));
        GridView_Time.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel_Time.Update();
    }
    protected void GridView_Time_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Time.EditIndex = -1;
        GridView_Time.SelectedIndex = -1;
        GridView_Time.DataSource = wcl.S_WorkOrderDetail_OTime(new Guid(label_OIID.Text.Trim()));
        GridView_Time.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel_Time.Update();
    }
    protected void Button5_Click(object sender, EventArgs e)//添加批号
    {
        TextBox3.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        Panel4.Visible = true;
        UpdatePanel4.Update();
        databind_pihao();
    }
    protected void Button8_Click(object sender, EventArgs e)//关闭批号信息
    {
        Panel3.Visible = false;
        Panel4.Visible = false;
        UpdatePanel3.Update();
        UpdatePanel4.Update();
    }
    protected void CheckBoxAll7_CheckedChanged(object sender, EventArgs e)//批号信息全选
    {
        for (int i = 0; i <= GridView3.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView3.Rows[i].FindControl("CheckBox1");
            if (CheckBox7.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox8.Checked = false;
    }
    protected void Checkfanxuan8_CheckedChanged(object sender, EventArgs e)//批号信息反选
    {
        for (int i = 0; i <= GridView3.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView3.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox7.Checked = false;
    }
    protected void Btn9_Click(object sender, EventArgs e)//删除批号
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView3.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView3.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        cs.CS_D_WODetail_WOMBatchNum(new Guid(GridView3.DataKeys[i].Values["WOMBN_ID"].ToString().Trim()));
                        sum++;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！')", true);
                        break;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('您没选择任何要删除的记录！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }

        DataSet ds2 = cs.CS_S_WOMBatchNum(this.label_WONum.Text.Trim());
        GridView3.DataSource = ds2.Tables[0].DefaultView;
        GridView3.DataBind();
        UpdatePanel3.Update();
    }
    protected void Button10_Click(object sender, EventArgs e)//检索批号
    {
        databind_pihao();
    }
    protected void Button11_Click(object sender, EventArgs e)//重置检索批号
    {
        TextBox3.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        databind_pihao();
        GridView4.PageIndex = 0;

    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView4.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView4.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        databind_pihao();


    }
    protected void CheckBoxAll9_CheckedChanged(object sender, EventArgs e)//全选待选的批号
    {
        for (int i = 0; i <= GridView4.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView4.Rows[i].FindControl("CheckBox2");
            if (CheckBox9.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox10.Checked = false;
    }
    protected void Checkfanxuan10_CheckedChanged(object sender, EventArgs e)//反选待选的批号
    {
        for (int i = 0; i <= GridView4.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView4.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox9.Checked = false;
    }
    protected void Button12_Click(object sender, EventArgs e)//添加待选的批号
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView4.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView4.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        string wWOMBN_BN = GridView4.DataKeys[i].Values["物料批号"].ToString().Trim();
                        Guid iMMBD_MaterialID = new Guid(GridView4.DataKeys[i].Values["物料ID"].ToString().Trim());
                        string wonum = this.label_WONum.Text.Trim();
                        cs.CS_I_WorkOrderDetail_WOMBatchNum(iMMBD_MaterialID, wonum, wWOMBN_BN);
                        sum++;

                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！')", true);
                        break;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('您没选择任何要添加的记录！请您再核对！')", true);
                return;
            }

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);


        }

        DataSet ds2 = cs.CS_S_WOMBatchNum(this.label_WONum.Text.Trim());
        GridView3.DataSource = ds2.Tables[0].DefaultView;
        GridView3.DataBind();
        UpdatePanel3.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();

    }
    protected void Btn13_Click(object sender, EventArgs e)//关闭待选的批号
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }
    protected void Button17_Click(object sender, EventArgs e)//添加设备
    {
        Panel6.Visible = true;
        DataSet ds = cs.Cs_S_WODetail_EquipmentInf_New2(this.label_SheBeipbcname.Text.Trim(), 0, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));
        this.DropDownList6.DataSource = ds.Tables[0].DefaultView;
        this.DropDownList6.DataValueField = "EI_ID";
        this.DropDownList6.DataTextField = "EI_No";
        DropDownList6.DataBind();
        DataSet ds2 = cs.Cs_S_WODetail_EquipmentInf_New2(label_SheBeipbcname.Text.Trim(), 1, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));

        DataTable dt2 = ds2.Tables[0];
        DataRow dr2 = dt2.NewRow();
        dr2["EI_ID"] = "00000000-0000-0000-0000-000000000000";
        dr2["EI_No"] = "请选择";
        dt2.Rows.InsertAt(dr2, 0);
        this.DropDownList7.DataSource = dt2;
        this.DropDownList7.DataValueField = "EI_ID";
        this.DropDownList7.DataTextField = "EI_No";
        DropDownList7.DataBind();
        UpdatePanel6.Update();
    }
    protected void Button18_Click(object sender, EventArgs e)//关闭设备信息
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }
    protected void CheckBoxAll11_CheckedChanged(object sender, EventArgs e)//全选设备
    {
        for (int i = 0; i <= GridView5.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView5.Rows[i].FindControl("CheckBox1");
            if (CheckBox11.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox12.Checked = false;
    }
    protected void Checkfanxuan12_CheckedChanged(object sender, EventArgs e)//删除设备
    {
        for (int i = 0; i <= GridView5.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView5.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox11.Checked = false;
    }
    protected void Btn19_Click(object sender, EventArgs e)//确定删除设备
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView5.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView5.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        cs.CS_D_WODetail_Equipment(new Guid(GridView5.DataKeys[i].Values["WOE_ID"].ToString().Trim()));
                        sum++;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！')", true);
                        break;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('您没选择任何要删除的记录！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }

        databind_shebei();
        databind_detail();
        Panel5.Visible = false;
        UpdatePanel5.Update();
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)//选择本工序设备
    {
        if (RadioButton1.Checked == true)
        {
            DataSet ds = cs.Cs_S_WODetail_EquipmentInf_New2(this.label_SheBeipbcname.Text.Trim(), 0, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));
            this.DropDownList6.DataSource = ds.Tables[0].DefaultView;
            this.DropDownList6.DataValueField = "EI_ID";
            this.DropDownList6.DataTextField = "EI_No";
            DropDownList6.DataBind();
            DataSet ds2 = cs.Cs_S_WODetail_EquipmentInf_New2(label_SheBeipbcname.Text.Trim(), 1, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));

            DataTable dt2 = ds2.Tables[0];
            DataRow dr2 = dt2.NewRow();
            dr2["EI_ID"] = "00000000-0000-0000-0000-000000000000";
            dr2["EI_No"] = "请选择";
            dt2.Rows.InsertAt(dr2, 0);
            this.DropDownList7.DataSource = dt2;
            this.DropDownList7.DataValueField = "EI_ID";
            this.DropDownList7.DataTextField = "EI_No";
            DropDownList7.DataBind();
            RadioButton2.Checked = false;

        }

        if (RadioButton1.Checked == false)
        {
            DataSet ds = cs.Cs_S_WODetail_EquipmentInf_New2(this.label_SheBeipbcname.Text.Trim(), 0, 1, new Guid(this.label_SheBeiwoid.Text.Trim()));
            this.DropDownList6.DataSource = ds.Tables[0].DefaultView;
            this.DropDownList6.DataValueField = "EI_ID";
            this.DropDownList6.DataTextField = "EI_No";
            DropDownList6.DataBind();
            DataSet ds2 = cs.Cs_S_WODetail_EquipmentInf_New2(label_SheBeipbcname.Text.Trim(), 1, 1, new Guid(this.label_SheBeiwoid.Text.Trim()));

            DataTable dt2 = ds2.Tables[0];
            DataRow dr2 = dt2.NewRow();
            dr2["EI_ID"] = "00000000-0000-0000-0000-000000000000";
            dr2["EI_No"] = "请选择";
            dt2.Rows.InsertAt(dr2, 0);
            this.DropDownList7.DataSource = dt2;
            this.DropDownList7.DataValueField = "EI_ID";
            this.DropDownList7.DataTextField = "EI_No";
            DropDownList7.DataBind();
            RadioButton2.Checked = true;
        }

    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)//选择所有设备
    {
        if (RadioButton2.Checked == false)
        {
            RadioButton1.Checked = true;
            DataSet ds = cs.Cs_S_WODetail_EquipmentInf_New2(this.label_SheBeipbcname.Text.Trim(), 0, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));
            this.DropDownList6.DataSource = ds.Tables[0].DefaultView;
            this.DropDownList6.DataValueField = "EI_ID";
            this.DropDownList6.DataTextField = "EI_No";
            DropDownList6.DataBind();
            DataSet ds2 = cs.Cs_S_WODetail_EquipmentInf_New2(label_SheBeipbcname.Text.Trim(), 1, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));

            DataTable dt2 = ds2.Tables[0];
            DataRow dr2 = dt2.NewRow();
            dr2["EI_ID"] = "00000000-0000-0000-0000-000000000000";
            dr2["EI_No"] = "请选择";
            dt2.Rows.InsertAt(dr2, 0);
            this.DropDownList7.DataSource = dt2;
            this.DropDownList7.DataValueField = "EI_ID";
            this.DropDownList7.DataTextField = "EI_No";
            DropDownList7.DataBind();


        }

        if (RadioButton2.Checked == true)
        {
            RadioButton1.Checked = false;
            DataSet ds = cs.Cs_S_WODetail_EquipmentInf_New2(this.label_SheBeipbcname.Text.Trim(), 0, 1, new Guid(this.label_SheBeiwoid.Text.Trim()));
            this.DropDownList6.DataSource = ds.Tables[0].DefaultView;
            this.DropDownList6.DataValueField = "EI_ID";
            this.DropDownList6.DataTextField = "EI_No";
            DropDownList6.DataBind();
            DataSet ds2 = cs.Cs_S_WODetail_EquipmentInf_New2(label_SheBeipbcname.Text.Trim(), 1, 1, new Guid(this.label_SheBeiwoid.Text.Trim()));

            DataTable dt2 = ds2.Tables[0];
            DataRow dr2 = dt2.NewRow();
            dr2["EI_ID"] = "00000000-0000-0000-0000-000000000000";
            dr2["EI_No"] = "请选择";
            dt2.Rows.InsertAt(dr2, 0);
            this.DropDownList7.DataSource = dt2;
            this.DropDownList7.DataValueField = "EI_ID";
            this.DropDownList7.DataTextField = "EI_No";
            DropDownList7.DataBind();

        }
    }
    protected void Button20_Click(object sender, EventArgs e)//添加设备
    {
        try
        {
            cs.Cs_I_WorkOrderDetail_Equipment_new2(new Guid(this.DropDownList6.SelectedValue.ToString().Trim()), new Guid(DropDownList7.SelectedValue.ToString().Trim()), new Guid(this.label_SheBeiwoid.Text.Trim()));
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！')", true);
            return;
        }
        databind_shebei();
        Panel6.Visible = true;
        RadioButton1.Checked = true;
        RadioButton2.Checked = false;
        DataSet ds = cs.Cs_S_WODetail_EquipmentInf_New2(this.label_SheBeipbcname.Text.Trim(), 0, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));
        this.DropDownList6.DataSource = ds.Tables[0].DefaultView;
        this.DropDownList6.DataValueField = "EI_ID";
        this.DropDownList6.DataTextField = "EI_No";
        DropDownList6.DataBind();
        DataSet ds2 = cs.Cs_S_WODetail_EquipmentInf_New2(label_SheBeipbcname.Text.Trim(), 1, 0, new Guid(this.label_SheBeiwoid.Text.Trim()));

        DataTable dt2 = ds2.Tables[0];
        DataRow dr2 = dt2.NewRow();
        dr2["EI_ID"] = "00000000-0000-0000-0000-000000000000";
        dr2["EI_No"] = "请选择";
        dt2.Rows.InsertAt(dr2, 0);
        this.DropDownList7.DataSource = dt2;
        this.DropDownList7.DataValueField = "EI_ID";
        this.DropDownList7.DataTextField = "EI_No";
        DropDownList7.DataBind();
        UpdatePanel6.Update();

        databind_detail();
    }
    protected void Button23_Click(object sender, EventArgs e)//取消添加设备
    {
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }
    protected void Button22_Click(object sender, EventArgs e)//关闭不良品信息
    {
        Panel7.Visible = false;
        UpdatePanel7.Update();
    }
    protected void GridView6_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView6.EditIndex = e.NewEditIndex;
        GridView6.SelectedIndex = -1;

        DataSet ds_BadProduct = cs.CS_S_WorkOrderDetail_BadProduct2(new Guid(this.label_bad_WODID.Text.Trim()), new Guid(this.label_bad_PBCID.Text.Trim()));

        GridView6.DataSource = ds_BadProduct.Tables[0].DefaultView;
        GridView6.DataBind();


        //不良品信息
        Panel7.Visible = true;
        UpdatePanel7.Update();
    }
    protected void GridView6_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView6.EditIndex = -1;


        DataSet ds_BadProduct = cs.CS_S_WorkOrderDetail_BadProduct2(new Guid(this.label_bad_WODID.Text.Trim()), new Guid(this.label_bad_PBCID.Text.Trim()));

        GridView6.DataSource = ds_BadProduct.Tables[0].DefaultView;
        GridView6.DataBind();


        //不良品信息
        Panel7.Visible = true;
        UpdatePanel7.Update();
    }
    protected void GridView6_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            DataSet ds = cs.CS_S_WOBadPro_panchong2(GridView6.Rows[e.RowIndex].Cells[1].Text.Trim(), new Guid(label_bad_WODID.Text.Trim()));
            if (ds.Tables[0].Rows.Count != 0)// have a check 是编辑
            {
                string num = Convert.ToString(((TextBox)(GridView6.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
                string Shuoming = Convert.ToString(((TextBox)(GridView6.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
                int i = Convert.ToInt32(num);
                cs.CS_U_WOBadPro_CZ(new Guid(GridView6.DataKeys[e.RowIndex].Values["WOBP_ID"].ToString().Trim()), i,Shuoming);
            }
            else //是新增
            {
                string num123 = Convert.ToString(((TextBox)(GridView6.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
                int i123 = Convert.ToInt32(num123);
                string Shuoming123 = Convert.ToString(((TextBox)(GridView6.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
                cs.CS_I_WOBadPro_cz2(new Guid(label_bad_WODID.Text.Trim()), GridView6.Rows[e.RowIndex].Cells[1].Text.Trim(), i123, Shuoming123);

            }





        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('不良品数量应为整数形式！')", true);
        }

        DataSet ds_BadProduct = cs.CS_S_WorkOrderDetail_BadProduct2(new Guid(this.label_bad_WODID.Text.Trim()), new Guid(this.label_bad_PBCID.Text.Trim()));
        GridView6.EditIndex = -1;
        GridView6.DataSource = ds_BadProduct.Tables[0].DefaultView;
        GridView6.DataBind();


        //不良品信息
        Panel7.Visible = true;
        UpdatePanel7.Update();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        databind_detail();
        //不良品信息
        Panel7.Visible = false;
        UpdatePanel7.Update();
        //设备信息
        Panel5.Visible = false;
        Panel6.Visible = false;
        UpdatePanel6.Update();
        UpdatePanel5.Update();
        //批号信息隐藏
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();
        //人员信息各种隐藏
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        databind_detail();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {


            string num = Convert.ToString(((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim().ToString());
            string woclass = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString();
            string order = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
            int i = Convert.ToInt32(num);
            int orderint = Convert.ToInt32(order);
            cs.Cs_Proc_U_WorkOrderDetail_Basic_NEW2(new Guid(GridView1.DataKeys[e.RowIndex].Values["WOD_ID"].ToString().Trim()), i, woclass, orderint);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('顺序、投入数量应为整数形式！')", true);
        }
        GridView1.EditIndex = -1;
        databind_detail();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            for (int i = 1; i <= 9; i++)
            {
                if (i == 1 || i == 4 || i == 8)
                {
                    curText = (TextBox)e.Row.Cells[i].Controls[0];
                    curText.Attributes.Add("style ", "width:60px;");
                }
                if (i == 1 || i == 8)
                {
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");
                }
            }

        }
    }
    protected void Button21_Click(object sender, EventArgs e)//添加工序
    {
        try
        {
            ppd.U_WOError_I_PBC_Normal(new Guid(label_WO_ID.Text.Trim()), new Guid(DropDownList9.SelectedValue.ToString().Trim()), new Guid(DropDownList8.SelectedValue.ToString().Trim()));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加成功！')", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('添加失败！')", true);

        }

        DropDownList9.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 0);
        DropDownList9.DataTextField = "PBC_Name";
        DropDownList9.DataValueField = "WOD_ID";
        DropDownList9.DataBind();
        //   DropDownList9.Items.Insert(0, new ListItem("请选择", ""));

        DropDownList11.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 1);
        DropDownList11.DataTextField = "PBC_Name";
        DropDownList11.DataValueField = "WOD_ID";
        DropDownList11.DataBind();
        databind_detail();
    }
    protected void btn24_Click(object sender, EventArgs e)//删除工序
    {
        try
        {
            ppd.U_WOError_D_PBC_Normal(new Guid(DropDownList11.SelectedValue.ToString().Trim()));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！')", true);

        }
        DropDownList9.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 0);
        DropDownList9.DataTextField = "PBC_Name";
        DropDownList9.DataValueField = "WOD_ID";
        DropDownList9.DataBind();
        //   DropDownList9.Items.Insert(0, new ListItem("请选择", ""));

        DropDownList11.DataSource = ppd.S_WODetail_Check_ForPBC(new Guid(label_WO_ID.Text.Trim()), 1);
        DropDownList11.DataTextField = "PBC_Name";
        DropDownList11.DataValueField = "WOD_ID";
        DropDownList11.DataBind();
        databind_detail();

    }
    protected void btnDetailExcel_Click(object sender, EventArgs e)
    {
        GridView_WOmain.AllowPaging = false;
        GridView_WOmain.AllowSorting = false;
        if (Label_searchCondition.Text == "")
            GridView_WOmain.DataSource = erl.S_WorkOrder_Check(label_Condition.Text);
        else
            GridView_WOmain.DataSource = erl.S_WorkOrder_Check(Label_searchCondition.Text);
        this.GridView_WOmain.DataBind();
        for (int i = 0; i < GridView_WOmain.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_WOmain.Rows[i].Cells.Count; j++)
            {
                GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].ToolTip;
            }
        }
        GridView_WOmain.Columns[17].Visible = false;
        GridView_WOmain.Columns[18].Visible = false;
        ExcelHelper.GridViewToExcel(GridView_WOmain, "随工单信息表");
        GridView_WOmain.Columns[17].Visible = true;
        GridView_WOmain.Columns[18].Visible = true;
        this.GridView_WOmain.DataBind();
        GridView_WOmain.AllowPaging = true;
        GridView_WOmain.AllowSorting = true;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)//批量选择
    {

        if (DropDownList12.SelectedIndex != 0)
        {
            if (DropDownList12.SelectedIndex == 1)
            {
                cs.CS_U_OperatorInfo_PieceItem_ID(new Guid(label_People_WODID.Text.Trim()), "不计计件工资", new Guid("00000000-0000-0000-0000-000000000000"));
                databind_people();
            }
            else
            {

                cs.CS_U_OperatorInfo_PieceItem_ID(new Guid(label_People_WODID.Text.Trim()), this.DropDownList12.SelectedItem.Text.Trim(), new Guid(DropDownList12.SelectedValue.ToString().Trim()));
                databind_people();
            }
        }

    }
}