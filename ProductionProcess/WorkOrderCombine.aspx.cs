using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductionProcess_WorkOrderCombine : Page
{
    ErrorRelevantL erl = new ErrorRelevantL();
    WorkOrderCheckL wcl = new WorkOrderCheckL();
    protected void Page_Load(object sender, EventArgs e)
    {
        label_GridPageState.Text = "默认数据源";

        if (!IsPostBack)
        {
            string condition = " and 1=1";
            GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();

        }
    }

    public void databind()
    {
        string condition;
        string WO_Type = DropDownList_WO_Type.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Type like '%" + DropDownList_WO_Type.SelectedItem.Text.Trim() + "%' ";
        //string WO_People = this.TextBox_WO_People.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_People like '%" + this.TextBox_WO_People.Text.Trim() + "%' ";
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }

        string WO_Time = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and WOD_StaTime between   ' " + TextBox_WO_Time1.Text.Trim() + "' and ' " + TextBox_WO_Time2.Text.Trim() + "'";
        string WO_Num = TextBox_wonum.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + TextBox_wonum.Text.Trim() + "%' ";
        string pbcname = TextBox_PBC.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_PBC.Text.Trim() + "%' ";
        string SMSO_ComOrderNum = TextBox_OrderNum.Text.Trim() == "" ? " and 1=1 " : " and SMSO_ComOrderNum like '%" + TextBox_OrderNum.Text.Trim() + "%' ";
        string WO_ProType = TextBox_pt.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + TextBox_pt.Text.Trim() + "%' ";
        string WO_ChipNum = TextBox_chipnum.Text.Trim() == "" ? " and 1=1 " : " and WO_ChipNum like '%" + TextBox_chipnum.Text.Trim() + "%' ";
        string WO_Level = DropDownList_level.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Level like '%" + DropDownList_level.SelectedItem.Text.Trim() + "%' ";
        string WO_State = DropDownList_WoState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_State like '%" + DropDownList_WoState.SelectedItem.Text.Trim() + "%' ";
        string WO_SN = TextBox_WOSN.Text.Trim() == "" ? " and 1=1 " : " and WO_SN like '%" + TextBox_WOSN.Text.Trim() + "%' ";
        condition = WO_Type + WO_Time + WO_Num + pbcname + SMSO_ComOrderNum + WO_ProType + WO_ChipNum + WO_Level + WO_State + WO_SN;
        GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Panel_Combine.Visible = false;
        UpdatePanel_Combine.Update();
        DropDownList1.SelectedIndex = 0;
        TextBox_PT_Combine.Text = "";
        TextBox_ChipNum_Conbine.Text = "";
        TextBox_Newwonum.Text = "";
        databind();
        label_GridPageState.Text = "检索数据源";
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        Panel_Combine.Visible = false;
        UpdatePanel_Combine.Update();
        DropDownList1.SelectedIndex = 0;
        TextBox_PT_Combine.Text = "";
        TextBox_ChipNum_Conbine.Text = "";
        TextBox_Newwonum.Text = "";
        DropDownList_level.SelectedIndex = 0;
        DropDownList_WO_Type.SelectedIndex = 0;
        DropDownList_WoState.SelectedIndex = 0;
        TextBox_chipnum.Text = "";
        TextBox_OrderNum.Text = "";
        TextBox_wonum.Text = "";
        TextBox_PBC.Text = "";
        TextBox_pt.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        TextBox_WOSN.Text = "";
        string condition = " and 1=1";
        GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

        GridView_WOmain.SelectedIndex = -1;
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
        GridView_WOmain.PageIndex = newPageIndex;


        if (label_GridPageState.Text == "默认数据源")
        {
            string condition = " and 1=1";
            GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            databind();
        }
        Panel_Combine.Visible = false;
        UpdatePanel_Combine.Update();
        DropDownList1.SelectedIndex = 0;
        TextBox_PT_Combine.Text = "";
        TextBox_ChipNum_Conbine.Text = "";
        TextBox_Newwonum.Text = "";
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_WOmain_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_WOmain_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_WOmain.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_WOmain.Rows[i].Cells.Count; j++)
            {
                GridView_WOmain.Rows[i].Cells[j].ToolTip = GridView_WOmain.Rows[i].Cells[j].Text;
                if (GridView_WOmain.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox1");
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
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox1");
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



    protected void Btn_Combing_Click(object sender, EventArgs e)
    {
        string woid = "";
        string subwonum = "";
        string ptname = "";
        string ordernum = "";
        int sum = 0;
        string chipnum = "";
        int pnum = 0;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == true)
            {
                DropDownList_level_Combine.SelectedValue = GridView_WOmain.DataKeys[i].Values["WO_Level"].ToString().Trim();

                if (woid.Trim() == "")
                {
                    woid = GridView_WOmain.DataKeys[i].Values["WO_ID"].ToString().Trim();
                }
                else
                {
                    woid = woid + "," + GridView_WOmain.DataKeys[i].Values["WO_ID"].ToString().Trim();
                }



                if (GridView_WOmain.DataKeys[i].Values["WO_State"].ToString().Trim() == "已被分单" || GridView_WOmain.DataKeys[i].Values["WO_State"].ToString().Trim() == "已被合单")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('选择的随工单中不能含有已被分单或已被合单的随工单！请您再核对！')", true);
                    return;
                }
                if (GridView_WOmain.DataKeys[i].Values["WO_PNum"].ToString().Trim() == "")
                {

                }
                else
                {
                    pnum = pnum + Convert.ToInt32(GridView_WOmain.DataKeys[i].Values["WO_PNum"].ToString().Trim());
                }
                if (subwonum.Trim() == "")
                {
                    subwonum = GridView_WOmain.DataKeys[i].Values["WO_Num"].ToString().Trim();
                }
                else
                {
                    subwonum = subwonum + "," + GridView_WOmain.DataKeys[i].Values["WO_Num"].ToString().Trim();
                }

                if (ordernum.Trim() == "")
                {
                    ordernum = GridView_WOmain.DataKeys[i].Values["WO_OrderNum"].ToString().Trim();
                }
                else
                {
                    ordernum = ordernum + "," + GridView_WOmain.DataKeys[i].Values["WO_OrderNum"].ToString().Trim();
                }



                if (ptname.Trim() == "")
                {
                    ptname = GridView_WOmain.DataKeys[i].Values["WO_ProType"].ToString().Trim();
                }
                else
                {
                    if (ptname != GridView_WOmain.DataKeys[i].Values["WO_ProType"].ToString().Trim())
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合单的产品型号必须一致！，请您再核对！')", true);
                        return;
                    }
                }
                if (chipnum.Trim() == "")
                {
                    chipnum = GridView_WOmain.DataKeys[i].Values["WO_ChipNum"].ToString().Trim();
                }
                else
                {
                    if (chipnum != GridView_WOmain.DataKeys[i].Values["WO_ChipNum"].ToString().Trim())
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合单的芯片代码必须一致！，请您再核对！')", true);
                        return;
                    }
                }
                sum++;
            }

        }
        if (sum == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要合单的随工单！，请您再核对！')", true);
            Panel_Combine.Visible = false;
            UpdatePanel_Combine.Update();
            return;
        }
        Labe_WOID.Text = woid.Trim();
        TextBox_PNum_Conbine.Text = pnum.ToString().Trim();
        Label17.Text = subwonum;
        TextBox_WoNumChecked.Text = subwonum;
        TextBox_PT_Combine.Text = ptname;
        TextBox_ChipNum_Conbine.Text = chipnum;
        TextBox_OrderCombine.Text = ordernum;
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        Panel_Combine.Visible = true;
        UpdatePanel_Combine.Update();

    }

    protected void Button_CloseCombing_Click(object sender, EventArgs e)
    {
        Panel_Combine.Visible = false;
        DropDownList1.SelectedIndex = 0;
        TextBox_PT_Combine.Text = "";
        TextBox_ChipNum_Conbine.Text = "";
        TextBox_Newwonum.Text = "";
        UpdatePanel_Combine.Update();
    }
    protected void Btn_CombingConfirm_Click(object sender, EventArgs e)
    {
        int num = 0;
        string wonum = TextBox_Newwonum.Text.Trim();
        string fatherwonum = TextBox_WoNumChecked.Text.Trim();
        string pt = TextBox_PT_Combine.Text.Trim();
        string ordernum = TextBox_OrderCombine.Text.Trim();
        string sn = TextBox_SN_Combine.Text.Trim();
        string level = DropDownList_level_Combine.SelectedItem.Text;
        string chipnum = TextBox_ChipNum_Conbine.Text.Trim();
        string idstring = Labe_WOID.Text.Trim();
        if (TextBox_SN_Combine.Text.Trim() == "")
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('周期码不能为空！')", true);
            return;
        }

        try
        {
            num = Convert.ToInt32(TextBox_PNum_Conbine.Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划数量不能为空且为整数形式！')", true);
            return;
        }
        string note = TextBox_Note_Combine.Text.Trim();
        string people = Session["UserName"].ToString().Trim();
        try
        {
            wcl.I_WorkOrder_Combine(wonum, fatherwonum, pt, ordernum, sn, level, chipnum, num, note, people, idstring);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合单成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合单失败！')", true);
            return;
        }
        if (label_GridPageState.Text == "默认数据源")
        {
            string condition = " and 1=1";
            GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            databind();
        }
        Panel_Combine.Visible = false;
        UpdatePanel_Combine.Update();
    }
}