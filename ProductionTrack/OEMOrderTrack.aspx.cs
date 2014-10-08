using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RTXHelper;
using System.Drawing;
public partial class WorkOrderSalary_OEMOrderTrack : Page
{
    ErrorRelevantL erl = new ErrorRelevantL();
    WorkOrderCheckL wcl = new WorkOrderCheckL();
    OEMTrackL ol = new OEMTrackL();
    private OEMTrackDD odd = new OEMTrackDD();
    ProductionProcessD ppd = new ProductionProcessD();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["state"] == null)
            {
                label_pagestate.Text = "look";

            }
            else
            {
                label_pagestate.Text = Request.QueryString["state"];
            }
            string state = label_pagestate.Text;

            if (state == "OEMake")//制定
            {
                Title = "加工订单制定";
                GridView1.Columns[19].Visible = false;
            }
            if (state == "OESign")//会签
            {
                Title = "加工订单会签";
                GridView1.Columns[18].Visible = false;
            }
            if (state == "look")//查看
            {
                Title = "加工订单查看";
                GridView1.Columns[18].Visible = false;
                GridView1.Columns[19].Visible = false;
            }

            databind();
            GridView1.SelectedIndex = -1;
            GridView1.EditIndex = -1;

            //pannel 各种隐藏
            Panel2.Visible = false;
            UpdatePanel2.Update();
            TextBox5.Text = "";
            TextBox7.Text = "";
            TextBox12.Text = "";
            TextBox11.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            //随工单信息pannel隐藏
            Panel4.Visible = false;
            TextBox20.Text = "";
            TextBox21.Text = "";
            label_Order.Text = "";
            UpdatePanel4.Update();

        }

    }
    public void databind_detail()
    {
        GridView3.DataSource = ppd.S_WODetail_Check(new Guid(label_WO_ID.Text.Trim()));
        GridView3.DataBind();
        UpdatePanel5.Update();

    }
    public void databind()
    {
        string condition;
        string SMSO_ComOrderNum = TextBox_order.Text.Trim() == "" ? " and 1=1 " : " and SMSO_ComOrderNum like '%" + TextBox_order.Text.Trim() + "%' ";

        if ((TextBox_orderTime1.Text != "" && TextBox_orderTime2.Text == "") || (TextBox_orderTime1.Text == "" && TextBox_orderTime2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将接单日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string SMSO_PlaceOrderTime = (TextBox_orderTime1.Text.Trim() == "" && TextBox_orderTime2.Text.Trim() == "") ? " and 1=1 " : " and SMSO_PlaceOrderTime between   ' " + TextBox_orderTime1.Text.Trim() + "' and ' " + TextBox_orderTime2.Text.Trim() + "'";
        string SMSOD_ChipBatchNum = TextBox_chip.Text.Trim() == "" ? " and 1=1 " : " and SMSOD_ChipBatchNum like '%" + TextBox_chip.Text.Trim() + "%' ";
        if ((TextBox_planproduction_Time1.Text != "" && TextBox_planproduction_Time2.Text == "") || (TextBox_planproduction_Time1.Text == "" && TextBox_planproduction_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将预计生产日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string OEMOT_PDate = (TextBox_planproduction_Time1.Text.Trim() == "" && TextBox_planproduction_Time2.Text.Trim() == "") ? " and 1=1 " : " and OEMOT_PDate between   ' " + TextBox_planproduction_Time1.Text.Trim() + "' and ' " + TextBox_planproduction_Time2.Text.Trim() + "'";
        string PT_Name = TextBox_pt.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_pt.Text.Trim() + "%' ";

        if ((TextBox_yujijiaohuo_Time1.Text != "" && TextBox_yujijiaohuo_Time2.Text == "") || (TextBox_yujijiaohuo_Time1.Text == "" && TextBox_yujijiaohuo_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将预计交货日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string SMSOD_OrderAdvanceDelTime = (TextBox_yujijiaohuo_Time1.Text.Trim() == "" && TextBox_yujijiaohuo_Time2.Text.Trim() == "") ? " and 1=1 " : " and SMSOD_OrderAdvanceDelTime between   ' " + TextBox_yujijiaohuo_Time1.Text.Trim() + "' and ' " + TextBox_yujijiaohuo_Time2.Text.Trim() + "'";

        if ((TextBox_realproduction_Time1.Text != "" && TextBox_realproduction_Time2.Text == "") || (TextBox_realproduction_Time1.Text == "" && TextBox_realproduction_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将实际生产日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string OEMOT_RPDate = (TextBox_realproduction_Time1.Text.Trim() == "" && TextBox_realproduction_Time2.Text.Trim() == "") ? " and 1=1 " : " and OEMOT_RPDate between   ' " + TextBox_realproduction_Time1.Text.Trim() + "' and ' " + TextBox_realproduction_Time2.Text.Trim() + "'";

        if ((TextBox_shijijiaohuo_Time1.Text != "" && TextBox_shijijiaohuo_Time2.Text == "") || (TextBox_shijijiaohuo_Time1.Text == "" && TextBox_shijijiaohuo_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将实际交货日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string OEMOT_RDeliverytDate = (TextBox_shijijiaohuo_Time1.Text.Trim() == "" && TextBox_shijijiaohuo_Time2.Text.Trim() == "") ? " and 1=1 " : " and OEMOT_RDeliverytDate between   ' " + TextBox_shijijiaohuo_Time1.Text.Trim() + "' and ' " + TextBox_shijijiaohuo_Time2.Text.Trim() + "'";

        condition = SMSO_ComOrderNum + SMSO_PlaceOrderTime + SMSOD_ChipBatchNum + OEMOT_PDate + PT_Name + SMSOD_OrderAdvanceDelTime + OEMOT_RPDate + OEMOT_RDeliverytDate;
        GridView1.DataSource = odd.S_OEMOrderTrack(condition);
        GridView1.DataBind();
        UpdatePanel_WOmain.Update();
        GridView1.SelectedIndex = -1;

    }
    public void databind2()
    {
        string condition;
        string WO_Num = TextBox20.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + TextBox20.Text.Trim() + "%' ";
        string PBC_Name = TextBox21.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox21.Text.Trim() + "%' ";
        string SMSO_ComOrderNum = " and WO_OrderNum = '" + label_Order.Text.Trim() + "' ";
        string WO_ProType = label_WO_ProType.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + label_WO_ProType.Text.Trim() + "%' ";
        condition = WO_Num + PBC_Name + SMSO_ComOrderNum + WO_ProType;
        GridView2.DataSource = erl.S_WorkOrder_Check(condition);
        GridView2.DataBind();
        UpdatePanel4.Update();
    }


    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        databind();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        TextBox_chip.Text = "";
        TextBox_order.Text = "";
        TextBox_orderTime1.Text = "";
        TextBox_orderTime2.Text = "";
        TextBox_planproduction_Time1.Text = "";
        TextBox_planproduction_Time2.Text = "";
        TextBox_pt.Text = "";
        TextBox_realproduction_Time1.Text = "";
        TextBox_realproduction_Time2.Text = "";
        TextBox_shijijiaohuo_Time1.Text = "";
        TextBox_shijijiaohuo_Time2.Text = "";
        TextBox_yujijiaohuo_Time1.Text = "";
        TextBox_yujijiaohuo_Time2.Text = "";
        //pannel 各种隐藏
        Panel2.Visible = false;
        UpdatePanel2.Update();
        TextBox5.Text = "";
        TextBox7.Text = "";
        TextBox12.Text = "";
        TextBox11.Text = "";
        TextBox8.Text = "";
        TextBox3.Text = "";
        //随工单信息pannel隐藏
        Panel4.Visible = false;
        TextBox20.Text = "";
        TextBox21.Text = "";
        label_Order.Text = "";
        UpdatePanel4.Update();

        databind();



    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView1.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView1.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.PageIndex = newPageIndex;

        databind();
        //pannel 各种隐藏
        //pannel 各种隐藏
        Panel2.Visible = false;
        UpdatePanel2.Update();
        TextBox5.Text = "";
        TextBox7.Text = "";
        TextBox12.Text = "";
        TextBox11.Text = "";
        TextBox8.Text = "";
        TextBox3.Text = "";
        //随工单信息pannel隐藏
        Panel4.Visible = false;
        TextBox20.Text = "";
        TextBox21.Text = "";
        label_Order.Text = "";
        UpdatePanel4.Update();

    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MakeOrder")//制定
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_SMSOD_ID.Text = al[0];
            Label_OEMOT_ID.Text = al[1];
            label_CursNum.Text = al[8];
            if (Label_OEMOT_ID.Text.Trim() == "")
            {
                label_makeoredit.Text = "制定";

            }
            else
            {
                label_makeoredit.Text = "编辑";
                TextBox5.Text = al[2];
                TextBox7.Text = al[3];
                TextBox12.Text = al[4];
                TextBox11.Text = al[5];
                TextBox8.Text = al[6];
                TextBox3.Text = al[7];


            }
            Panel2.Visible = true;
            UpdatePanel2.Update();
            //pannel 各种隐藏
            //随工单信息pannel隐藏
            Panel4.Visible = false;
            TextBox20.Text = "";
            TextBox21.Text = "";
            label_Order.Text = "";
            UpdatePanel4.Update();

            Panel3.Visible = false;
            UpdatePanel3.Update();

        }

        if (e.CommandName == "detail")//详细
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_Order.Text = al[0];
            label_WO_ProType.Text = al[1];
            Panel2.Visible = false;
            UpdatePanel2.Update();
            GridView2.SelectedIndex = -1;
            //pannel 各种隐藏
            //随工单信息pannel隐藏
            Panel4.Visible = true;
            TextBox20.Text = "";
            TextBox21.Text = "";
            databind2();
            UpdatePanel4.Update();
            Panel3.Visible = false;
            Panel2.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "sign")//会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label4.Text = al[2];
            Label_OEMOT_ID.Text = al[1];
            label_CursNum.Text = al[2];
            if (Label_OEMOT_ID.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该加工订单跟踪记录尚未制定，待制定后才能会签或查看会签！')", true);
                return;

            }

            string condition = "and OEMOT_ID='" + Label_OEMOT_ID.Text.ToString() + "'";
            DataSet ds = odd.S_OEMOrderTrack_One(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][5].ToString() != "")
                {
                    DropDownList1.SelectedValue = dt.Rows[0][5].ToString();
                }
                else
                {
                    DropDownList1.SelectedValue = "是";
                }
                label13.Text = dt.Rows[0][7].ToString();
                label14.Text = dt.Rows[0][8].ToString();
                TextBox1.Text = dt.Rows[0][6].ToString();
                if (dt.Rows[0][9].ToString() != "")
                {
                    DropDownList6.SelectedValue = dt.Rows[0][9].ToString();
                }
                else
                {
                    DropDownList6.SelectedValue = "是";
                }

                label15.Text = dt.Rows[0][11].ToString();
                label17.Text = dt.Rows[0][12].ToString();
                TextBox2.Text = dt.Rows[0][10].ToString();

                if (dt.Rows[0][13].ToString() != "")
                {
                    DropDownList2.SelectedValue = dt.Rows[0][13].ToString();
                }
                else
                {
                    DropDownList2.SelectedValue = "是";
                }

                label5.Text = dt.Rows[0][15].ToString();
                label6.Text = dt.Rows[0][16].ToString();
                TextBox4.Text = dt.Rows[0][14].ToString();

                if (dt.Rows[0][17].ToString() != "")
                {
                    DropDownList3.SelectedValue = dt.Rows[0][17].ToString();
                }
                else
                {
                    DropDownList3.SelectedValue = "是";
                }

                label7.Text = dt.Rows[0][19].ToString();
                label8.Text = dt.Rows[0][20].ToString();
                TextBox6.Text = dt.Rows[0][18].ToString();

                if (dt.Rows[0][21].ToString() != "")
                {
                    DropDownList4.SelectedValue = dt.Rows[0][21].ToString();
                }
                else
                {
                    DropDownList4.SelectedValue = "是";
                }

                label9.Text = dt.Rows[0][23].ToString();
                label10.Text = dt.Rows[0][24].ToString();
                TextBox9.Text = dt.Rows[0][22].ToString();

                if (dt.Rows[0][25].ToString() != "")
                {
                    DropDownList5.SelectedValue = dt.Rows[0][25].ToString();
                }
                else
                {
                    DropDownList5.SelectedValue = "是";
                }
                //this.DropDownList5.SelectedValue = dt.Rows[0][25].ToString();
                label11.Text = dt.Rows[0][27].ToString();
                label12.Text = dt.Rows[0][28].ToString();
                TextBox10.Text = dt.Rows[0][26].ToString();
            }
            if (Session["Department"].ToString() == "工程部")
            {
                TextBox1.Enabled = true;
                DropDownList1.Enabled = true;
                Button5.Visible = true;
                Button6.Visible = true;
            }
            if (Session["Department"].ToString() == "技术部")
            {
                TextBox2.Enabled = true;
                DropDownList6.Enabled = true;

                Button5.Visible = true;
                Button6.Visible = true;
            }
            if (Session["Department"].ToString() == "品保部")
            {
                TextBox4.Enabled = true;
                DropDownList2.Enabled = true;

                Button5.Visible = true;
                Button6.Visible = true;
            }
            if (Session["Department"].ToString().Contains("生产"))
            {
                TextBox6.Enabled = true;
                DropDownList3.Enabled = true;

                Button5.Visible = true;
                Button6.Visible = true;
            }
            if (Session["Department"].ToString() == "采购部")
            {
                TextBox9.Enabled = true;
                DropDownList4.Enabled = true;
                Button5.Visible = true;
                Button6.Visible = true;
            }
            if (Session["Department"].ToString() == "销售部")
            {
                TextBox10.Enabled = true;
                DropDownList5.Enabled = true;
                Button5.Visible = true;
                Button6.Visible = true;
            }
            //this.Button7.Visible = false;



            Panel3.Visible = true;
            UpdatePanel3.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "Lsign")//查看会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label4.Text = al[2];
            Label_OEMOT_ID.Text = al[1];
            if (Label_OEMOT_ID.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该加工订单跟踪记录尚未制定，待制定后才能会签或查看会签！')", true);
                return;

            }
            string condition = "and OEMOT_ID='" + Label_OEMOT_ID.Text.ToString() + "'";

            DataSet ds = odd.S_OEMOrderTrack_One(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][5].ToString() != "")
                {
                    DropDownList1.SelectedValue = dt.Rows[0][5].ToString();
                }
                else
                {
                    DropDownList1.SelectedValue = "是";
                }
                label13.Text = dt.Rows[0][7].ToString();
                label14.Text = dt.Rows[0][8].ToString();
                TextBox1.Text = dt.Rows[0][6].ToString();
                if (dt.Rows[0][9].ToString() != "")
                {
                    DropDownList6.SelectedValue = dt.Rows[0][9].ToString();
                }
                else
                {
                    DropDownList6.SelectedValue = "是";
                }

                label15.Text = dt.Rows[0][11].ToString();
                label17.Text = dt.Rows[0][12].ToString();
                TextBox2.Text = dt.Rows[0][10].ToString();
                if (dt.Rows[0][13].ToString() != "")
                {
                    DropDownList2.SelectedValue = dt.Rows[0][13].ToString();
                }
                else
                {
                    DropDownList2.SelectedValue = "是";
                }
                DropDownList2.SelectedValue = dt.Rows[0][13].ToString();
                label5.Text = dt.Rows[0][15].ToString();
                label6.Text = dt.Rows[0][16].ToString();
                TextBox4.Text = dt.Rows[0][14].ToString();

                if (dt.Rows[0][17].ToString() != "")
                {
                    DropDownList3.SelectedValue = dt.Rows[0][17].ToString();
                }
                else
                {
                    DropDownList3.SelectedValue = "是";
                }

                label7.Text = dt.Rows[0][19].ToString();
                label8.Text = dt.Rows[0][20].ToString();
                TextBox6.Text = dt.Rows[0][18].ToString();
                if (dt.Rows[0][21].ToString() != "")
                {
                    DropDownList4.SelectedValue = dt.Rows[0][21].ToString();
                }
                else
                {
                    DropDownList4.SelectedValue = "是";
                }

                label9.Text = dt.Rows[0][23].ToString();
                label10.Text = dt.Rows[0][24].ToString();
                TextBox9.Text = dt.Rows[0][22].ToString();
                if (dt.Rows[0][25].ToString() != "")
                {
                    DropDownList5.SelectedValue = dt.Rows[0][25].ToString();
                }
                else
                {
                    DropDownList5.SelectedValue = "是";
                }
                DropDownList5.SelectedValue = dt.Rows[0][25].ToString();
                label11.Text = dt.Rows[0][27].ToString();
                label12.Text = dt.Rows[0][28].ToString();
                TextBox10.Text = dt.Rows[0][26].ToString();
            }
            Button5.Visible = false;
            Button6.Visible = false;
            // this.Button7.Visible = true;
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }
    }
    //提交申请单
    protected void Btn_makeOrder_Click(object sender, EventArgs e)
    {
        try
        {
            if (Label_OEMOT_ID.Text.Trim() == "")
            {

                try
                {
                    odd.I_OEMOrderTrack(new Guid(Label_SMSOD_ID.Text.Trim()), TextBox11.Text.Trim(), Convert.ToDateTime(TextBox5.Text.Trim()), Convert.ToDateTime(TextBox7.Text.Trim() == "" ? "1970-01-01" : TextBox7.Text.Trim()), Convert.ToDateTime(TextBox12.Text.Trim() == "" ? "1970-01-01" : TextBox12.Text.Trim()), TextBox8.Text.Trim(), Convert.ToDateTime(TextBox3.Text.Trim()));
                    label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "制定了" + label_CursNum.Text + "的加工订单表，请会签。";
                    string message = label_RTX.Text;
                    string sErr = RTXhelper.Send(message, "加工订单跟踪会签");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }

            }
            else
            {
                try
                {
                    odd.U_OEMOrderTrack(new Guid(Label_OEMOT_ID.Text.Trim()), TextBox11.Text.Trim(), Convert.ToDateTime(TextBox5.Text.Trim()), Convert.ToDateTime(TextBox7.Text.Trim() == "" ? "1970-01-01" : TextBox7.Text.Trim()), Convert.ToDateTime(TextBox12.Text.Trim() == "" ? "1970-01-01" : TextBox12.Text.Trim()), TextBox8.Text.Trim(), Convert.ToDateTime(TextBox3.Text.Trim()));

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('操作失败，请您再次核对！')", true);
            return;
        }
        Panel2.Visible = false;
        UpdatePanel2.Update();
        TextBox5.Text = "";
        TextBox7.Text = "";
        TextBox12.Text = "";
        TextBox11.Text = "";
        TextBox8.Text = "";
        TextBox3.Text = "";
        //随工单信息pannel隐藏
        Panel4.Visible = false;
        TextBox20.Text = "";
        TextBox21.Text = "";
        label_Order.Text = "";
        UpdatePanel4.Update();
        databind();

    }
    protected void Button_makeOrderCancel_Click(object sender, EventArgs e)
    {
        //pannel 各种隐藏
        Panel2.Visible = false;
        UpdatePanel2.Update();
        TextBox5.Text = "";
        TextBox7.Text = "";
        TextBox12.Text = "";
        TextBox11.Text = "";
        TextBox8.Text = "";
        TextBox3.Text = "";
        //随工单信息pannel隐藏
        Panel4.Visible = false;
        TextBox20.Text = "";
        TextBox21.Text = "";
        label_Order.Text = "";
        UpdatePanel4.Update();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;
                if (GridView1.Rows[i].Cells[j].Text.Length > 7)
                {
                    GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].Text.Substring(0, 7) + "...";
                }


            }
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView2.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView2.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.SelectedIndex = -1;
        databind2();
        //pannel 各种隐藏
        //pannel 各种隐藏
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        TextBox5.Text = "";
        TextBox7.Text = "";
        TextBox12.Text = "";
        TextBox11.Text = "";
        TextBox8.Text = "";
        TextBox3.Text = "";
        Panel5.Visible = false;
        UpdatePanel5.Update();

    }
    protected void Btn_WOTrack_Click(object sender, EventArgs e)
    {
        databind2();
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void Btn_WOTrack_Close_Click(object sender, EventArgs e)
    {
        //随工单信息pannel隐藏
        Panel4.Visible = false;
        TextBox20.Text = "";
        TextBox21.Text = "";
        label_Order.Text = "";
        UpdatePanel4.Update();
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }
    protected void Btn_RetWO_Click(object sender, EventArgs e)
    {
        TextBox20.Text = "";
        TextBox21.Text = "";
        databind2();
    }
    //会签提交
    protected void Btn_Intake(object sender, EventArgs e)
    {
        Guid OEMOT_ID = new Guid(Label_OEMOT_ID.Text.ToString());
        string OEMOT_State = "";
        if (Session["Department"].ToString() == "工程部")
        {
            string OEMOT_EnDepDirec = DropDownList1.SelectedValue;
            string OEMOT_EnDepReason = TextBox1.Text;
            string OEMOT_EnDepMan = Session["UserName"].ToString();

            if (OEMOT_EnDepDirec == "是")
            {
                OEMOT_State = "工程部会签通过";
            }
            else
            {
                OEMOT_State = "工程部会签驳回";
            }
            odd.U_OEMOrderTrack_EnDesign(OEMOT_ID, OEMOT_EnDepDirec, OEMOT_EnDepReason, OEMOT_EnDepMan);
        }
        if (Session["Department"].ToString() == "技术部")
        {
            string OEMOT_TeDepDirec = DropDownList6.SelectedValue;
            string OEMOT_TeDepReason = TextBox2.Text.ToString();
            string OEMOT_TeDepMan = Session["UserName"].ToString();
            if (OEMOT_TeDepDirec == "是")
            {
                OEMOT_State = "技术部会签通过";
            }
            else
            {
                OEMOT_State = "技术部会签驳回";
            }
            odd.U_OEMOrderTrack_TeDesign(OEMOT_ID, OEMOT_TeDepDirec, OEMOT_TeDepReason, OEMOT_TeDepMan);
        }
        if (Session["Department"].ToString() == "品保部")
        {
            string OEMOT_QDepQC = DropDownList2.SelectedValue;
            string OEMOT_QDepReason = TextBox4.Text;
            string OEMOT_QDepMan = Session["UserName"].ToString();
            if (OEMOT_QDepQC == "是")
            {
                OEMOT_State = "品保部会签通过";
            }
            else
            {
                OEMOT_State = "品保部会签驳回";
            }
            odd.U_OEMOrderTrack_QDesign(OEMOT_ID, OEMOT_QDepQC, OEMOT_QDepReason, OEMOT_QDepMan);
        }
        if (Session["Department"].ToString().Contains("生产"))
        {
            string OEMOT_PDepInDate = DropDownList3.SelectedValue;
            string OEMOT_PDepReason = TextBox6.Text;
            string OEMOT_PDepMan = Session["UserName"].ToString();
            if (OEMOT_PDepInDate == "是")
            {
                OEMOT_State = "生产部会签通过";
            }
            else
            {
                OEMOT_State = "生产部会签驳回";
            }
            odd.U_OEMOrderTrack_PDesign(OEMOT_ID, OEMOT_PDepInDate, OEMOT_PDepReason, OEMOT_PDepMan);
        }
        if (Session["Department"].ToString() == "采购部")
        {
            string OEMOT_SupDepM = DropDownList4.SelectedValue;
            string OEMOT_SuDepReason = TextBox9.Text;
            string OEMOT_SuDepMan = Session["UserName"].ToString();
            if (OEMOT_SupDepM == "是")
            {
                OEMOT_State = "采购部会签通过";
            }
            else
            {
                OEMOT_State = "采购部会签驳回";
            }
            odd.U_OEMOrderTrack_SupDesign(OEMOT_ID, OEMOT_SupDepM, OEMOT_SuDepReason, OEMOT_SuDepMan);
        }
        if (Session["Department"].ToString() == "销售部")
        {
            string OEMOT_SalDepSale = DropDownList5.SelectedValue;
            string OEMOT_SalDepReason = TextBox10.Text;
            string OEMOT_SalDepMan = Session["UserName"].ToString();
            if (OEMOT_SalDepSale == "是")
            {
                OEMOT_State = "销售部会签通过";
            }
            else
            {
                OEMOT_State = "销售部会签驳回";
            }
            odd.U_OEMOrderTrack_SalDesign(OEMOT_ID, OEMOT_SalDepSale, OEMOT_SalDepReason, OEMOT_SalDepMan);
        }

        odd.U_OEMOrderTrack_State(OEMOT_ID, OEMOT_State);

        string condition = "and OEMOT_ID='" + Label_OEMOT_ID.Text.ToString() + "'";
        DataSet ds = odd.S_OEMOrderTrack_One(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            try
            {
                DropDownList1.SelectedValue = dt.Rows[0][5].ToString();
            }
            catch (Exception)
            {
                DropDownList1.SelectedIndex = 0;
            }
            try
            {
                DropDownList6.SelectedValue = dt.Rows[0][9].ToString();
            }
            catch (Exception)
            {
                DropDownList6.SelectedIndex = 0;

            }
            try
            {
                DropDownList2.SelectedValue = dt.Rows[0][13].ToString();
            }
            catch (Exception)
            {
                DropDownList2.SelectedIndex = 0;
            }
            try
            {
                DropDownList3.SelectedValue = dt.Rows[0][17].ToString();
            }
            catch (Exception)
            {
                DropDownList3.SelectedIndex = 0;
            }
            try
            {
                DropDownList4.SelectedValue = dt.Rows[0][21].ToString();
            }
            catch (Exception)
            {
                DropDownList4.SelectedIndex = 0;
            }
            try
            {
                DropDownList5.SelectedValue = dt.Rows[0][25].ToString();
            }
            catch (Exception)
            {
                DropDownList5.SelectedIndex = 0;
            }
        }
        if (DropDownList1.SelectedValue == "是" && DropDownList2.SelectedValue == "是" && DropDownList3.SelectedValue == "是" && DropDownList4.SelectedValue == "是" && DropDownList5.SelectedValue == "是" && DropDownList6.SelectedValue == "是")
        {
            OEMOT_State = "会签通过";
            odd.U_OEMOrderTrack_State(OEMOT_ID, OEMOT_State);
            label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "通过了" + label_CursNum.Text + "的加工订单表会签，请查看。";
            string message = label_RTX.Text;
            string sErr = RTXhelper.Send(message, "加工订单跟踪制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        if (DropDownList1.SelectedValue == "否" || DropDownList2.SelectedValue == "否" || DropDownList3.SelectedValue == "否" || DropDownList4.SelectedValue == "否" || DropDownList5.SelectedValue == "否" || DropDownList6.SelectedValue == "否")
        {
            label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + label_CursNum.Text + "的加工订单表，请查看。";
            string message = label_RTX.Text;
            string sErr = RTXhelper.Send(message, "加工订单跟踪制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }

        DropDownList1.SelectedValue = "是";
        DropDownList2.SelectedValue = "是";
        DropDownList3.SelectedValue = "是";
        DropDownList4.SelectedValue = "是";
        DropDownList5.SelectedValue = "是";
        DropDownList6.SelectedValue = "是";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox4.Text = "";
        TextBox6.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        label13.Text = "";
        label14.Text = "";
        label15.Text = "";
        label17.Text = "";
        label5.Text = "";
        label6.Text = "";
        label7.Text = "";
        label8.Text = "";
        label9.Text = "";
        label10.Text = "";
        label11.Text = "";
        label12.Text = "";
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void Button_Meky(object sender, EventArgs e)
    {
        DropDownList1.SelectedValue = "是";
        DropDownList2.SelectedValue = "是";
        DropDownList3.SelectedValue = "是";
        DropDownList4.SelectedValue = "是";
        DropDownList5.SelectedValue = "是";
        DropDownList6.SelectedValue = "是";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox4.Text = "";
        TextBox6.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        label13.Text = "";
        label14.Text = "";
        label15.Text = "";
        label17.Text = "";
        label5.Text = "";
        label6.Text = "";
        label7.Text = "";
        label8.Text = "";
        label9.Text = "";
        label10.Text = "";
        label11.Text = "";
        label12.Text = "";
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void Button_Comen(object sender, EventArgs e)
    {
        DropDownList1.SelectedValue = "是";
        DropDownList2.SelectedValue = "是";
        DropDownList3.SelectedValue = "是";
        DropDownList4.SelectedValue = "是";
        DropDownList5.SelectedValue = "是";
        DropDownList6.SelectedValue = "是";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox4.Text = "";
        TextBox6.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        label13.Text = "";
        label14.Text = "";
        label15.Text = "";
        label17.Text = "";
        label5.Text = "";
        label6.Text = "";
        label7.Text = "";
        label8.Text = "";
        label9.Text = "";
        label10.Text = "";
        label11.Text = "";
        label12.Text = "";
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["OEMOT_State"].ToString().Trim() == "未制定")
            {
                e.Row.Cells[19].Enabled = false;
            }
            if (drv["OEMOT_State"].ToString().Contains("通过"))
            {
                e.Row.Cells[18].Enabled = false;
            }
            if (drv["OEMOT_State"].ToString().Contains("驳回"))
            {
                e.Row.Cells[19].Enabled = false;
            }
            string sg = drv["OEMOT_PInTime"].ToString();
            if (sg != "" && drv["OEMOT_RDeliverytDate"].ToString()=="")
            {
            System.TimeSpan sts = DateTime.Now - Convert.ToDateTime(drv["OEMOT_PInTime"].ToString());
            int days = sts.Days;
            if (days > 3)
            {
                e.Row.BackColor = Color.Red;
            }
            }
        }
    }
    protected void Button_Cancel0_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }
    protected void GridView3_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            for (int j = 0; j < GridView3.Rows[i].Cells.Count; j++)
            {
                if (j != 3)
                {
                    GridView3.Rows[i].Cells[j].ToolTip = GridView3.Rows[i].Cells[j].Text;
                    if (GridView3.Rows[i].Cells[j].Text.Length > 16)
                    {
                        GridView3.Rows[i].Cells[j].Text = GridView3.Rows[i].Cells[j].Text.Substring(0, 16) + "...";
                    }
                }

            }
            GridView3.Rows[i].Cells[3].ToolTip = GridView3.Rows[i].Cells[3].Text;
            if (GridView3.Rows[i].Cells[3].Text.Length > 12)
            {
                GridView3.Rows[i].Cells[3].Text = GridView3.Rows[i].Cells[3].Text.Substring(0, 12) + "...";
            }
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "BasicInfo")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_WO_ID.Text = al[0];
            label_WONum.Text = al[1];
            Panel5.Visible = true;
            databind_detail();


        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if ((Convert.ToDecimal(drv["hgl"].ToString().Trim()) < Convert.ToDecimal(94.5)) && drv["WO_Num"].ToString().Trim().Contains("ES"))
            {
                e.Row.BackColor = Color.Red;
            }
            if ((Convert.ToDecimal(drv["hgl"].ToString().Trim()) < Convert.ToDecimal(95.5)) && drv["WO_Num"].ToString().Trim().Contains("ED"))
            {
                e.Row.BackColor = Color.Red;
            }
          
            if (drv["WO_ProType"].ToString().Trim().Contains("GBPC") && drv["WO_ProType"].ToString().Trim().Contains("W") && (Convert.ToDecimal(drv["hgl"].ToString().Trim()) < Convert.ToDecimal(94)))
            {
                e.Row.BackColor = Color.Red;
            }
        }
    }
    protected void btnDetailExcel_Click(object sender, EventArgs e)
    {
        GridView1.AllowPaging = false;
        GridView1.AllowSorting = false;

        databind();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].ToolTip;
            }
        }
        GridView1.Columns[18].Visible = false;
        GridView1.Columns[19].Visible = false;
        GridView1.Columns[20].Visible = false;
        GridView1.Columns[21].Visible = false;

        ExcelHelper.GridViewToExcel(GridView1, "加工订单跟踪表");

        GridView1.Columns[18].Visible = true;
        GridView1.Columns[19].Visible = true;
        GridView1.Columns[20].Visible = true;
        GridView1.Columns[21].Visible = true;

        string state = label_pagestate.Text;

        if (state == "OEMake")//制定
        {
            Title = "加工订单制定";
            GridView1.Columns[19].Visible = false;
        }
        if (state == "OESign")//会签
        {
            Title = "加工订单会签";
            GridView1.Columns[18].Visible = false;
        }
        if (state == "look")//查看
        {
            Title = "加工订单查看";
            GridView1.Columns[18].Visible = false;
            GridView1.Columns[19].Visible = false;
        }

        databind();
        GridView1.AllowPaging = true;
        GridView1.AllowSorting = true;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}