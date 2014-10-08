using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProductionProcess_WorkOrderDivided : Page
{
    WorkOrderL wol = new WorkOrderL();
    WOSSalaryL wosl = new WOSSalaryL();
    ErrorRelevantL erl = new ErrorRelevantL();
    WorkOrderCheckL wcl = new WorkOrderCheckL();
    ProductionProcessD ppd = new ProductionProcessD();
    CSD cs = new CSD();
    WorkOrderInfo wo = new WorkOrderInfo();
    WSD ws = new WSD();
    protected void Page_Load(object sender, EventArgs e)
    {
        label_GridPageState.Text = "默认数据源";

        string state = "";
        if (!IsPostBack)
        {
            if (Request.QueryString["state"] == null)
            {
                Response.Redirect("~/Default.aspx");

            }
            else
            {
                state = Request.QueryString["state"];
            }

            if (state == "devide")
            {
                Title = "随工单分单";
                GridView_WOmain.Columns[0].Visible = false;
                GridView_WOmain.Columns[1].Visible = false;
                CheckBoxAll.Visible = false;
                CheckBoxfanxuan.Visible = false;
                Btn_deleting.Visible = false;
            }
            if (state == "combine")
            {
                Title = "随工单合单";
                GridView1.Columns[15].Visible = false;
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

            //this.Title = "随工单分单";
            string condition = " and 1=1";
            GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();

        }
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
                DropDownList_WO_Type.SelectedIndex = 4;
            }
            else
            {
                WO_Type = DropDownList_WO_Type.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Type like '%" + DropDownList_WO_Type.SelectedItem.Text.Trim() + "%' ";
            }
        }
        catch (Exception)
        {
            WO_Type = DropDownList_WO_Type.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Type like '%" + DropDownList_WO_Type.SelectedItem.Text.Trim() + "%' ";
        }
        //string WO_People = this.TextBox_WO_People.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_People like '%" + this.TextBox_WO_People.Text.Trim() + "%' ";
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        if ((DropDownList3.SelectedValue.ToString() != "" && DropDownList4.SelectedValue.ToString() == "") || (DropDownList3.SelectedValue.ToString().Trim() == "" && DropDownList4.SelectedValue.ToString().Trim() != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将工序检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string gx = " and 1=1 ";
        string WO_Time = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and WOD_StaTime between   ' " + TextBox_WO_Time1.Text.Trim() + "' and ' " + TextBox_WO_Time2.Text.Trim() + "'";
        string WO_Num = TextBox_wonum.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + TextBox_wonum.Text.Trim() + "%' ";
        string pbcname = TextBox_PBC.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_PBC.Text.Trim() + "%' ";
        string SMSO_ComOrderNum = TextBox_OrderNum.Text.Trim() == "" ? " and 1=1 " : " and SMSO_ComOrderNum like '%" + TextBox_OrderNum.Text.Trim() + "%' ";
        string WO_ProType = TextBox_pt.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + TextBox_pt.Text.Trim() + "%' ";
        string WO_State = DropDownList_WoState.SelectedItem.Text.Trim() == "请选择" ? " and WO_State!='已被合单' " : " and WO_State like '%" + DropDownList_WoState.SelectedItem.Text.Trim() + "%'    ";
        string WO_SN = TextBox_WOSN.Text.Trim() == "" ? " and 1=1 " : " and WO_SN like '%" + TextBox_WOSN.Text.Trim() + "%' ";
        string error = DropDownList1.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WOD_Error like '%" + DropDownList1.SelectedItem.Text.Trim() + "%' ";
        string otime = DropDownList2.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WOD_OverTime like '%" + DropDownList2.SelectedItem.Text.Trim() + "%' ";
        string pihao = TextBox_WOSN0.Text.Trim() == "" ? " and 1=1 " : " and pihao like '%" + TextBox_WOSN0.Text.Trim() + "%' ";
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
        GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }

    public void databind_detail()
    {
        GridView1.DataSource = ppd.S_WODetail_Check(new Guid(label_WO_ID.Text.Trim()));
        GridView1.DataBind();
        UpdatePanel1.Update();

    }

    public void databind_PT()
    {
        string condition;
        string PS_Name = TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + TextBox_Series.Text.Trim() + "%' ";
        string PT_Name = TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_ProductName.Text.Trim() + "%' ";
        string PT_Code = TextBox_ProductName0.Text.Trim() == "" ? " and 1=1 " : " and PT_Code like '%" + TextBox_ProductName0.Text.Trim() + "%' ";
        string PT_CodeMeanning = TextBox_ProductName1.Text.Trim() == "" ? " and 1=1 " : " and PT_CodeMeanning like '%" + TextBox_ProductName1.Text.Trim() + "%' ";
        condition = PS_Name + PT_Name + PT_CodeMeanning + PT_Code;
        GridView_ProType.DataSource = ppd.S_ProType_For_WorkOrder(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();

    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Panel_Divide.Visible = false;
        UpdatePanel_Divide.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        databind();
        label_GridPageState.Text = "检索数据源";
    }

    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        //panel 各种隐藏



        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        TextBox_WOSN0.Text = "";
        DropDownList3.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;

        DropDownList_WO_Type.SelectedIndex = 0;
        DropDownList_WoState.SelectedIndex = 0;
        TextBox_OrderNum.Text = "";
        TextBox_wonum.Text = "";
        TextBox_PBC.Text = "";
        TextBox_pt.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        TextBox_WOSN.Text = "";
        GridView_WOmain.PageIndex = 0;
        databind();
        GridView_WOmain.SelectedIndex = -1;


        Panel_Divide.Visible = false;
        UpdatePanel_Divide.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
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
        databind();
        GridView_WOmain.SelectedIndex = -1;

        //分单页面
        Panel_Divide.Visible = false;
        UpdatePanel_Divide.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();

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
            label_PType.Text = al[2];
            label_PTypeID.Text = al[3];
            GridView1.SelectedIndex = -1;
            Panel1.Visible = true;
            databind_detail();




            //不良品信息分单页面隐藏
            Panel_Divide.Visible = false;
            UpdatePanel_Divide.Update();

        }

    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if (drv["WOD_OverTime"].ToString().Trim() == "是")
            {
                e.Row.BackColor = Color.LightYellow;

            }

            if (drv["WOD_Error"].ToString().Trim() == "是")
            {
                e.Row.BackColor = Color.Pink;

            }
        }
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
                if (j != 2 && j != 8)
                {
                    GridView_WOmain.Rows[i].Cells[j].ToolTip = GridView_WOmain.Rows[i].Cells[j].Text;
                    if (GridView_WOmain.Rows[i].Cells[j].Text.Length > 10)
                    {
                        GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                    }
                }

            }
        }
    }
    protected void Btn_Dividing_Click(object sender, EventArgs e)//分单
    {
        int yuannum = 0; int fenchu_n = 0;
        try
        {
            yuannum = Convert.ToInt32(Label_yuannum.Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('原单数量初始化失败！')", true);
            return;
        }
        try
        {
            fenchu_n = Convert.ToInt32(TextBox_InputNum.Text.Trim()); Convert.ToInt32(TextBox_InputNum.Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('分出数量请填整数！')", true);
            return;
        }
        if (fenchu_n > yuannum)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('分出数量不得大于原有数量！')", true);
            return;
        }
        try
        {

            wo.WO_ID = new Guid(Labe_WOID.Text.Trim());
            wo.SMSO_ID = new Guid(Label_AddOrderNum.Text.Trim());
            wo.WO_Num = TextBox_WOMotherNum.Text.Trim();
            wo.WO_ProType = TextBox_WOMotherNum0.Text.Trim();
            wo.WO_OrderNum = TextBox_WOMotherNum1.Text.Trim();
            wo.WO_People = Session["UserName"].ToString().Trim();
            wo.WO_Note = Label_Note.Text + "  " + TextBox4.Text;
            ppd.I_WorkOrder_Devide_NEW(wo, new Guid(Label_PTID.Text.Trim()), TextBox_WOMotherNum2.Text.Trim(), fenchu_n, new Guid(Label_WODID.Text.Trim()), yuannum);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('分单成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('分单失败！')", true);
            return;
        }


        databind();


        //分单表绑定


        Panel_Divide.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        Panel_SelectOrder.Visible = false;
        UpdatePanel_SelectOrder.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        UpdatePanel_Divide.Update();

    }
    protected void Button_CloseDividing_Click(object sender, EventArgs e)//取消
    {

        TextBox_WOMotherNum.Text = "";
        TextBox_InputNum.Text = "";
        DropDownList1.SelectedIndex = 0;
        Panel_Divide.Visible = false;
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
        for (int m = 0; m < GridView1.Rows.Count; m++)
        {

            //if (((GridView1.Rows[m].Cells[8].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[m].Cells[8].ToolTip.ToString().Trim() == ""))) && (!(GridView1.Rows[m].Cells[3].Text.Contains("QC"))) && GridView1.Rows[m].Cells[6].Text.Trim() == "&nbsp;" || GridView1.Rows[m].Cells[6].Text.Trim() == "")
            //{
            //    LinkButton x = GridView1.Rows[m].FindControl("Dividing") as LinkButton;
            //    x.ForeColor = Color.Black;
            //    x.Enabled = true;
            //    break;

            //}



            //6是开始时间 开始时间不为空 而完工时间为空  工序已开启 当前工序分单
            //if (((GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() != "&nbsp;" && (GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() != "")))&&((GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == ""))) && (!(GridView1.Rows[m].Cells[3].Text.Contains("QC"))))
            if (((GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() != "&nbsp;" && (GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() != "")))&&((GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == ""))))
            {
                LinkButton x = GridView1.Rows[m].FindControl("Dividing") as LinkButton;
                x.ForeColor = Color.Black;
                x.Enabled = true;
                break;

            }
            //开始时间为空、完工时间也为空
          //  if (((GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() == ""))) && ((GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == ""))) && (!(GridView1.Rows[m].Cells[3].Text.Contains("QC"))))
            if (((GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[m].Cells[6].ToolTip.ToString().Trim() == ""))) && ((GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[m].Cells[7].ToolTip.ToString().Trim() == ""))))
            {
                LinkButton x = GridView1.Rows[m].FindControl("Dividing") as LinkButton;
                x.ForeColor = Color.Black;
                x.Enabled = true;
                break;

            }


        }




    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)//报警变色
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if (drv["WOD_OverTime"].ToString().Trim() == "是")
            {
                e.Row.BackColor = Color.LightYellow;

            }

            if (drv["WOD_Error"].ToString().Trim() == "是")
            {
                e.Row.BackColor = Color.Pink;


            }


        }

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
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //分单

        if (e.CommandName == "Dividing")//
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Labe_WOID.Text = label_WO_ID.Text;
            Label_WODID.Text = al[0];
            label_PBCDivide.Text = al[1];
            label_WONum0.Text = label_WONum.Text;
            TextBox_WOMotherNum.Text = label_WONum.Text;

            TextBox_WOMotherNum0.Text = label_PType.Text;
            Label_PTID.Text = label_PTypeID.Text;
            TextBox4.Text = "";
            TextBox_InputNum.Text = "";

            DropDownList1.SelectedIndex = 0;
            Panel_Divide.Visible = true;
            UpdatePanel_Divide.Update();

            for (int i = 0; i < GridView1.Rows.Count && GridView1.Rows[i].Cells[6].Text.Trim() != "&nbsp;" && GridView1.Rows[i].Cells[6].Text.Trim() != ""; i++)
            {

                if (GridView1.Rows[i].Cells[6].Text.Trim() != "" && GridView1.Rows[i].Cells[3].Text.Contains("压塑") && (!(GridView1.Rows[i].Cells[3].Text.Contains("QC"))) && (!(GridView1.Rows[i].Cells[3].Text.Contains("&"))))
                {
                    Label_Note.Text = Label_Note.Text + "压塑设备：" + (GridView1.Rows[i].Cells[5].ToolTip.ToString() == "&nbsp;" ? "未选择" : GridView1.Rows[i].Cells[5].ToolTip.ToString()) + " 压塑进站时间:" + GridView1.Rows[i].Cells[6].ToolTip.ToString()
                        + " 压塑出站时间:" + (GridView1.Rows[i].Cells[7].ToolTip.ToString() == "&nbsp;" ? "未出站" : GridView1.Rows[i].Cells[7].ToolTip.ToString());
                }
                if (GridView1.Rows[i].Cells[6].Text.Trim() != "" && GridView1.Rows[i].Cells[3].Text.Contains("浇灌") && (!(GridView1.Rows[i].Cells[3].Text.Contains("QC"))) && (!(GridView1.Rows[i].Cells[3].Text.Contains("&"))))
                {
                    Label_Note.Text = Label_Note.Text + "浇灌设备：" + (GridView1.Rows[i].Cells[5].ToolTip.ToString() == "&nbsp;" ? "未选择" : GridView1.Rows[i].Cells[5].ToolTip.ToString()) + " 浇灌进站时间:" + GridView1.Rows[i].Cells[6].ToolTip.ToString()
                        + " 浇灌出站时间:" + (GridView1.Rows[i].Cells[7].ToolTip.ToString() == "&nbsp;" ? "未出站" : GridView1.Rows[i].Cells[7].ToolTip.ToString());
                }
                if (GridView1.Rows[i].Cells[6].Text.Trim() != "" && GridView1.Rows[i].Cells[3].Text.Contains("固化") && (!(GridView1.Rows[i].Cells[3].Text.Contains("QC"))) && (!(GridView1.Rows[i].Cells[3].Text.Contains("&"))))
                {
                    Label_Note.Text = Label_Note.Text + "固化设备：" + (GridView1.Rows[i].Cells[5].ToolTip.ToString() == "&nbsp;" ? "未选择" : GridView1.Rows[i].Cells[5].ToolTip.ToString()) + " 固化进站时间:" + GridView1.Rows[i].Cells[6].ToolTip.ToString()
                        + " 固化出站时间:" + (GridView1.Rows[i].Cells[7].ToolTip.ToString() == "&nbsp;" ? "未出站" : GridView1.Rows[i].Cells[7].ToolTip.ToString());
                }


            }
            int sum = 0;
          
            for (int m = 0; m < GridView1.Rows.Count&&(GridView1.Rows[m].Cells[8].ToolTip.ToString().Trim() != "&nbsp;" && (GridView1.Rows[m].Cells[8].ToolTip.ToString().Trim() != "")) && (!(GridView1.Rows[m].Cells[3].Text.Contains("QC"))); m++)
            {
                {
                    sum++;
                }

            }
            //if (sum == 0)
            //{
            //    Label_yuannum.Text = "0";
            //}
            //else
            //{

            //    for (int i = 0; i < GridView1.Rows.Count && GridView1.Rows[i].Cells[8].Text.Trim() != "&nbsp;" && GridView1.Rows[i].Cells[8].Text.Trim() != "" && (!(GridView1.Rows[i].Cells[3].Text.Contains("QC"))); i++)
            //    {


            //        if ((GridView1.Rows[i].Cells[9].ToolTip.ToString().Trim() == "&nbsp;" || (GridView1.Rows[i].Cells[9].ToolTip.ToString().Trim() == "")))
            //        {
            //            Label_yuannum.Text = (GridView1.Rows[i].Cells[8].ToolTip.ToString().Trim());
            //        }
            //        else
            //        {
            //            Label_yuannum.Text = (GridView1.Rows[i].Cells[9].ToolTip.ToString().Trim());
            //        }


            //    }
            //}

            DataSet ds0 = ws.S_HeDanNum(new Guid(Labe_WOID.Text.Trim()));
            Label_yuannum.Text = ds0.Tables[0].Rows[0]["num"].ToString();
      
        }
    }
    protected void Button_Cancel0_Click(object sender, EventArgs e)//关闭详细表
    {
        Panel_Divide.Visible = false;
        UpdatePanel_Divide.Update();


        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Btn_Search0_Click(object sender, EventArgs e)//选产品型号
    {
        // Label_PS.Text = "";
        Panel_Product.Visible = true;
        Panel_Product_Search.Visible = true;
        Panel_SelectOrder.Visible = false;
        UpdatePanel_SelectOrder.Update();
        //  Panel_basic.Visible = false;
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        TextBox_ProductName0.Text = "";
        TextBox_ProductName1.Text = "";

        Panel_Product.Visible = true;
        Panel_Product_Search.Visible = true;
        databind_PT();


    }
    protected void GridView_ProType_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_ProType.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_ProType.Rows[i].Cells.Count; j++)
            {
                GridView_ProType.Rows[i].Cells[j].ToolTip = GridView_ProType.Rows[i].Cells[j].Text;
                if (GridView_ProType.Rows[i].Cells[j].Text.Length > 25)
                {
                    GridView_ProType.Rows[i].Cells[j].Text = GridView_ProType.Rows[i].Cells[j].Text.Substring(0, 25) + "...";
                }


            }
        }
    }
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        //new add for checkbox

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_ProType.BottomPagerRow;

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
        //正常直接跳到这里
        {
            newPageIndex = e.NewPageIndex;
        }


        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        //RemeberOldValues();
        GridView_ProType.PageIndex = newPageIndex;
        databind_PT();
        //RePopulateValues();
    }
    //从当前页收集选中项的情况
    protected void GridView_ProType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SelectPT")//选择产品型号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_ProType.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ptname = al[1];
            Label_PTID.Text = al[0];
            TextBox_WOMotherNum0.Text = ptname;

            UpdatePanel_Divide.Update();
            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
        }
    }

    protected void GridView_ProType_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void SelectProType(object sender, EventArgs e)
    {
        databind_PT();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        TextBox_ProductName0.Text = "";
        TextBox_ProductName1.Text = "";
        databind_PT();
    }
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Product_Search.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        databind_detail();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        databind_detail();
    }
    protected void Btn_Search1_Click(object sender, EventArgs e)
    {
        Panel_SelectOrder.Visible = true;
        UpdatePanel_SelectOrder.Update();

        Panel_Product_Search.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();

        TextBox_CustOrder.Text = "";
        TextBox_ComOrderNum.Text = "";
        string condition;
        string ComOrderNum = TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        GridView_Order.DataBind();
    }
    protected void Button_SearchOrder_Click(object sender, EventArgs e)
    {

        string condition;
        string ComOrderNum = TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        GridView_Order.DataBind();
    }
    protected void Btn_Close_SearchOrder_Click(object sender, EventArgs e)
    {
        Panel_SelectOrder.Visible = false;
        UpdatePanel_SelectOrder.Update();
    }
    protected void GridView_Order_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select_Order")//选择订单号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Order.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_AddOrderNum.Text = al[0];
            TextBox_WOMotherNum1.Text = al[1];//客户订单号
            // Label_OT.Text = al[3];
            UpdatePanel_Divide.Update();

            Panel_SelectOrder.Visible = false;
            UpdatePanel_SelectOrder.Update();

        }
    }
    protected void GridView_Order_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Order.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Order.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Order.PageCount ? GridView_Order.PageCount - 1 : newPageIndex;
        GridView_Order.PageIndex = newPageIndex;
        GridView_Order.PageIndex = newPageIndex;
        string condition;
        string ComOrderNum = TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        GridView_Order.DataBind();
        UpdatePanel_SelectOrder.Update();
    }
    protected void GridView_Order_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Button16_Click(object sender, EventArgs e)//回删随工单
    {
        TextBox8.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox1.Text = "";
        label_hedanxinghao.Text = "";
        DropDownList5.SelectedIndex = 0;
    }
    protected void Button1_Click(object sender, EventArgs e) //关闭合单
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
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
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
       //label_Hedangongxu.Text = "";
       //TextBox9.Text = "";
      //  TextBox8.Text = "";
       //TextBox5.Text = "";
       // TextBox6.Text = "";
        //TextBox1.Text = "";
       // DropDownList8.SelectedIndex = 0;
       
        string ptname = "";
        int sum = 0;
        int pnum = 0;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == true)
            {
                if (label_hedanxinghao.Text.Trim() == "")
                {
                    ptname = GridView_WOmain.DataKeys[i].Values["WO_ProType"].ToString().Trim();
                    label_hedanxinghao.Text = ptname;
                    WO_PT_ID.Text = GridView_WOmain.DataKeys[i].Values["WO_PT_ID"].ToString().Trim();
                }
                else
                {
                    if (label_hedanxinghao.Text.Trim() != GridView_WOmain.DataKeys[i].Values["WO_ProType"].ToString().Trim())
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合单的产品型号必须一致！，请您再核对！')", true);
                      //  label_hedanxinghao.Text = "";
                        return;
                    }
                }



                if (TextBox8.Text.Trim() == "")
                {
                    TextBox8.Text = GridView_WOmain.DataKeys[i].Values["WO_Num"].ToString().Trim();
                }
                else
                {
                    string[] a;
                    if (TextBox8.Text.Contains(","))
                    {
                        a = TextBox8.Text.Trim().Split(new char[] { ',' });
                        int id = Array.IndexOf(a, GridView_WOmain.DataKeys[i].Values["WO_Num"].ToString().Trim()); // 这里的1就是你要查找的值
                        if (id == -1)
                        {
                            TextBox8.Text = TextBox8.Text + "," + GridView_WOmain.DataKeys[i].Values["WO_Num"].ToString().Trim();
                        }
                    }
                    else
                    {
                        if (TextBox8.Text != GridView_WOmain.DataKeys[i].Values["WO_Num"].ToString().Trim())
                        {
                            TextBox8.Text = TextBox8.Text + "," + GridView_WOmain.DataKeys[i].Values["WO_Num"].ToString().Trim();
                        }
                    }

                }
                if (GridView_WOmain.DataKeys[i].Values["WO_State"].ToString().Trim() == "已被合单")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('选择的随工单中不能含有已被合单的随工单！请您再核对！')", true);

                    return;
                }
                if (GridView_WOmain.DataKeys[i].Values["WOD_QNum"].ToString().Trim() != "")
                {
                    pnum = pnum + Convert.ToInt32(GridView_WOmain.DataKeys[i].Values["WOD_QNum"].ToString().Trim());
                }
                

                sum++;
            }
        }
        if (sum == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要合单的随工单！，请您再核对！')", true);
            return;
        }
        DataSet ds = ppd.S_WorkOrder_CombiningNum(TextBox8.Text.Trim());
        TextBox5.Text = ds.Tables[0].Rows[0]["num"].ToString();
        DropDownList9.DataSource = erl.S_WOError_Rework_PBCraft();
        DropDownList9.DataTextField = "PBC_Name";
        DropDownList9.DataValueField = "PBC_ID";
        DropDownList9.DataBind();
        DropDownList9.SelectedIndex = 0;

        Panel2.Visible = true;
      //  TextBox5.Text = pnum.ToString();
        UpdatePanel2.Update();
    }
    protected void Button_Cancel1_Click(object sender, EventArgs e)//提交合单
    {
        if (TextBox8.Text.Trim() == "" || TextBox6.Text.Trim() == "" || TextBox1.Text.Trim() == "" || TextBox9.Text.Trim() == ""||label_Hedangongxu.Text.Trim()=="")
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标为*的项目为必填项！，请您再核对！')", true);
            return;
        }
        else
        {
            ppd.I_WorkOrder_Combine_NEW(TextBox8.Text.Trim(), label_hedanxinghao.Text.Trim(), Session["UserName"].ToString(), new Guid(WO_PT_ID.Text.Trim()), TextBox6.Text.Trim(), Convert.ToInt32(TextBox5.Text.Trim()), DropDownList5.SelectedValue.ToString().Trim(), TextBox1.Text.Trim(), Convert.ToInt32(DropDownList8.SelectedValue.ToString().Trim()),label_Hedangongxu.Text.Trim());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合单成功!')", true);
            label_hedanxinghao.Text = "";
            label_Hedangongxu.Text = "";
            TextBox9.Text = "";
            TextBox8.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox1.Text = "";
            DropDownList8.SelectedIndex = 0;
            Panel2.Visible = false;
            UpdatePanel2.Update();
            databind();
        }

    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        TextBox9.Text = "";
        label_Hedangongxu.Text = "";
        UpdatePanel2.Update();
    }
    protected void Button18_Click(object sender, EventArgs e)//添加合单工序
    {
        if (TextBox9.Text.Trim() == "")
        { 
            TextBox9.Text =DropDownList9.SelectedItem.Text.Trim(); 
        }
        else
        {
            TextBox9.Text = TextBox9.Text + "," + DropDownList9.SelectedItem.Text.Trim();
        }
        if (label_Hedangongxu.Text.Trim() == "")
        {
            label_Hedangongxu.Text = DropDownList9.SelectedValue.ToString().Trim();
        }
        else
        {
            label_Hedangongxu.Text = label_Hedangongxu.Text + "," + DropDownList9.SelectedValue.ToString().Trim();
        }
    }
    protected void Button_Cancel12_Click(object sender, EventArgs e)
    {
        label_hedanxinghao.Text = "";
        label_Hedangongxu.Text = "";
        TextBox9.Text = "";
        TextBox8.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox1.Text = "";
        DropDownList8.SelectedIndex = 0;
        Panel2.Visible = false;
        UpdatePanel2.Update();
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
}