using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class WorkOrderSalary_JiJianShenHeNoZp : System.Web.UI.Page
{
    WSD ws = new WSD();
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
            if (state.Trim() == "look")
            {
                this.Title = "非装配计件项目审核查看";
                pbtg.Visible = false;
                pbbh.Visible = false;
                TextBox7.Enabled = false;
                GridView_WOmain.Columns[0].Visible = false;
                t123.Visible = false;
            }
            if (state.Trim() == "sh")
            {
                this.Title = "非装配计件项目财务审核";
            }
            if (state.Trim() == "zpsh")
            {
                this.Title = "装配计件项目财务审核";
                TextBox_tibaoren.Text = "装配";
                TextBox_tibaoren.Enabled = false;
            }
            if (state.Trim() == "zplook")
            {
                this.Title = "装配计件项目审核查看";
                TextBox_tibaoren.Text = "装配";
                TextBox_tibaoren.Enabled = false;
                pbtg.Visible = false;
                pbbh.Visible = false;
                TextBox7.Enabled = false;
                GridView_WOmain.Columns[0].Visible = false;
                t123.Visible = false;
            }
            databind_zhubiao();
        }

    }

    public void databind_zhubiao()
    {
        //string bm;
        string condition;
        // if(label_pagestate.Text.Trim()=="cs")
        // {

        //  }

        string STI_Name = TextBox_xiangmu.Text.Trim() == "" ? " and 1=1 " : " and (isnull(SPS_Name,'')+ isnull(SPI_Name,'')) like '%" + TextBox_xiangmu.Text.Trim() + "%' ";
        string PBC_Name = TextBox_tibaoren.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_tibaoren.Text.Trim() + "%' ";
        string PA_RMan = TextBox_chushengren.Text.Trim() == "" ? " and 1=1 " : " and PA_RMan like '%" + TextBox_chushengren.Text.Trim() + "%' ";
        string PA_State = DropDownList1.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and isnull(PA_State,'财务待审') like '%" + DropDownList1.SelectedItem.Text.Trim() + "%' ";
      
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将所属日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string PA_Date = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and t1.d1 between   '" + TextBox_WO_Time1.Text.Trim() + "' and '" + TextBox_WO_Time2.Text.Trim() + "'";


        if ((TextBox_tibaoshijian1.Text != "" && TextBox_tibaoshijian2.Text == "") || (TextBox_tibaoshijian1.Text == "" && TextBox_tibaoshijian2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将审核时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string PA_RTime = (TextBox_tibaoshijian1.Text.Trim() == "" && TextBox_tibaoshijian2.Text.Trim() == "") ? " and 1=1 " : " and PA_RTime between   '" + TextBox_tibaoshijian1.Text.Trim() + "' and '" + TextBox_tibaoshijian2.Text.Trim() + "'";

        if (!label_pagestate.Text.Contains("zp"))
        {
            condition = STI_Name + PBC_Name + PA_RMan + PA_State + PA_Date + PA_RTime;
            GridView_WOmain.DataSource = ws.S_JJXMSH(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();
        }
        else
        {

            condition = STI_Name  + PA_RMan + PA_State + PA_Date + PA_RTime;
            GridView_WOmain.DataSource = ws.S_JJXMSH_ZP(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();
        }
    }

    public void databind_detail()
    {
        string condition;
        string WO_Num = TextBox8.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + TextBox8.Text.Trim() + "%' ";
        string HRDD_StaffNO = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox1.Text.Trim() + "%' ";
        string HRDD_Name = TextBox2.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox2.Text.Trim() + "%' ";
        condition = WO_Num + HRDD_StaffNO + HRDD_Name;

        if (!label_pagestate.Text.Contains("zp"))
        {
            GridView1.DataSource = ws.S_JJXMSH_Detail(Label_SPI_ID.Text.Trim(), label_Date.Text.Trim(), condition);
        }
        else
        {
            GridView1.Columns[1].Visible = false;
            GridView1.DataSource = ws.S_JJXMSH_Detail_ZP(Label_SPI_ID.Text.Trim(), label_Date.Text.Trim(), condition);

        }
        GridView1.DataBind();
        UpdatePanel1.Update();
    }

    public void clear()
    {

        TextBox_xiangmu.Text = "";
        if (!label_pagestate.Text.Contains("zp"))
        {
            TextBox_tibaoren.Text = "";
        }
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextBox_chushengren.Text = "";
        TextBox_tibaoshijian1.Text = "";
        TextBox_tibaoshijian2.Text = "";
    }



    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)//批量审核
    {
        int sum = 0;
        Label13.Visible = true;
        Label14.Visible = true;
       // Panel1.Visible = true;
      //  Panel3.Visible = true;
        pl0.Visible = false;
       // UpdatePanel1.Update();
        TextBox7.Text = "";
        Label_type.Text = "1";
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == true)
            {
                if (Label14.Text.Trim() == "")
                {
                    Label14.Text = GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["SPI_Name"].ToString().Trim();
                    Label_PLID.Text = GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["PieceItem_ID"].ToString().Trim();
                }
                else
                {
                    string[] a;
                    if (Label14.Text.Contains(","))
                    {
                        a = Label14.Text.Trim().Split(new char[] { ',' });
                        int id = Array.IndexOf(a, (GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["SPI_Name"].ToString().Trim())); // 这里的1就是你要查找的值
                        if (id == -1)
                        {
                            Label14.Text = Label14.Text + "," + GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["SPI_Name"].ToString().Trim();
                            Label_PLID.Text = Label_PLID.Text + "," + GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["PieceItem_ID"].ToString().Trim();
                        }
                    }
                    else
                    {
                        if (Label14.Text != GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["SPI_Name"].ToString().Trim())
                        {
                            Label14.Text = Label14.Text + "," + GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["SPI_Name"].ToString().Trim();
                            Label_PLID.Text = Label_PLID.Text + "," + GridView_WOmain.DataKeys[i].Values["d1"].ToString().Trim() + GridView_WOmain.DataKeys[i].Values["PieceItem_ID"].ToString().Trim();
                        }
                    }

                }
                

                sum++;
            }
        }
        if (sum == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要合单的随工单！请您再核对！')", true);
            return;
        }
        TextBox7.Enabled = true;
        Panel1.Visible = false;
        pbbh.Visible = true;
        pbtg.Visible = true;
        Panel3.Visible = true;
        UpdatePanel1.Update();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
            {
                if (CheckBox2.Checked == true)
                {
                    CheckBox.Checked = true;
                }
                else
                {
                    CheckBox.Checked = false;
                }
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
         
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
            {
                if (CheckBox.Checked == false)
                {
                    CheckBox.Checked = true;
                }
                else
                {
                    CheckBox.Checked = false;
                }
            }
        
        }
        CheckBox2.Checked = false;
    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
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
        databind_zhubiao();
        //Panel_NewProjectInfo.Visible = false;
        //UpdatePanel_NewProjectInfo.Update();
        //Panel_AddProject.Visible = false;
        //UpdatePanel_AddProject.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail12")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Label14.Text = "";
            Label_PLID.Text = "";
            Label_type.Text = "";
            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;
            if (this.label_pagestate.Text.Contains("sh"))
            {
                if (GridView_WOmain.DataKeys[row.RowIndex].Values["PA_State"].ToString().Trim() != "财务待审")
                {
                    TextBox7.Enabled = false;
                    pbtg.Visible = false;
                    pbbh.Visible = false;
                }
                else
                {
                    TextBox7.Enabled = true;
                    pbtg.Visible = true;
                    pbbh.Visible = true;
                }
            }
            for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
                if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
                {
                    
                        CheckBox.Checked = false;
                    
                }
            }
            pl0.Visible = true;
            Label_SPI_Name.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["SPI_Name"].ToString();
            Label_SPI_ID.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["PieceItem_ID"].ToString();
            label_Date.Text=GridView_WOmain.DataKeys[row.RowIndex].Values["d1"].ToString();
            TextBox8.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label41.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["PA_RMan"].ToString();
            Label42.Text = (GridView_WOmain.DataKeys[row.RowIndex].Values["PA_RTime"].ToString() == "&nbsp;" || GridView_WOmain.DataKeys[row.RowIndex].Values["PA_RTime"].ToString().Trim() == "") ? "" : Convert.ToDateTime(GridView_WOmain.DataKeys[row.RowIndex].Values["PA_RTime"].ToString().Trim()).ToString("yy-MM-dd HH:mm");//人事审核时间;
            label52.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["PA_RResult"].ToString();
            TextBox7.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["PA_Suggestion"].ToString();
            Label21.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["PA_ID"].ToString();
            Label_type.Text = "0";

            Panel1.Visible = true;
            Panel3.Visible = true;
            databind_detail();
           
        }
    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if (drv["PA_State"].ToString().Trim() == "财务待审")
            {
                e.Row.Cells[0].Enabled = true;


            }
            else
            {
                e.Row.Cells[0].Enabled = false;
            }
        }
    }
    protected void Btn_Search_Click(object sender, EventArgs e)//检索
    {
        databind_zhubiao();

    }
    protected void Button_Cancel_Click(object sender, EventArgs e)//取消检索
    {
        clear();
        databind_zhubiao();
        Label14.Text = "";
        Label_PLID.Text = "";
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }
    protected void GridView_WOmain_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_WOmain.Rows.Count; i++) //鼠标悬停样式
        {
            for (int j = 0; j < GridView_WOmain.Rows[i].Cells.Count; j++)
            {
                GridView_WOmain.Rows[i].Cells[j].ToolTip = GridView_WOmain.Rows[i].Cells[j].Text;
                if (GridView_WOmain.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)//检索Detail
    {
        databind_detail();
    }
    protected void Button2_Click(object sender, EventArgs e)//重置Detail
    {
        TextBox8.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        databind_detail();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        Label14.Text = "";
        Label_PLID.Text = "";
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
       
    }
    protected void GridView_AddProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        databind_detail();
        Label14.Text = "";
        Label_PLID.Text = "";
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }
    protected void GridView_AddProject_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Button_AddPeople_close0_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        Label14.Text = "";
        Label_PLID.Text = "";
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }
    protected void pbtg_Click(object sender, EventArgs e)
    {
        if (Label_type.Text.Trim() == "0")
        {
            try
            {

                if (Label21.Text.Trim() == "")
                {
                    ws.I_PieceAudi(new Guid(Label_SPI_ID.Text.Trim()), Convert.ToDateTime(label_Date.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过");
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                }
                else
                {

                    ws.U_PieceAudit(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过");
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }

        }
        else
        {
           string [] a = Label_PLID.Text.Trim().Split(new char[] { ',' });
           try
           {
               for (int i = 0; i < a.Length; i++)
               {
                   ws.I_PieceAudit_Piliang(new Guid(a[i].Remove(0, 10).Trim()), Convert.ToDateTime(a[i].Substring(0, 10).Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过");
              
               }
               ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
               //string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核通过了计件项目： " + Label14.Text + " ！";

               //string ms = "";
               //try
               //{
               //    ms = RTXhelper.Send(message, "计件补录制定");
               //}
               //catch (Exception)
               //{
               //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
               //    return;
               //}
           }
           catch (Exception)
           {

               ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
               return;
           }

        
        }
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        Label14.Text = "";
        Label_PLID.Text = "";
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        databind_zhubiao();
    }
    protected void pbbh_Click(object sender, EventArgs e)
    {
        if (Label_type.Text.Trim() == "0")
        {
            try
            {

                if (Label21.Text.Trim() == "")
                {
                    ws.I_PieceAudi(new Guid(Label_SPI_ID.Text.Trim()), Convert.ToDateTime(label_Date.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "不通过");
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                }
                else
                {

                    ws.U_PieceAudit(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "不通过");
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }

        }
        else
        {
            string[] a = Label_PLID.Text.Trim().Split(new char[] { ',' });
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    ws.I_PieceAudit_Piliang(new Guid(a[i].Remove(0, 10).Trim()), Convert.ToDateTime(a[i].Substring(0, 10).Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "不通过");

                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                //string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核通过了计件项目： " + Label14.Text + " ！";

                //string ms = "";
                //try
                //{
                //    ms = RTXhelper.Send(message, "计件补录制定");
                //}
                //catch (Exception)
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                //    return;
                //}
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;
            }


        }
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        Label14.Text = "";
        Label_PLID.Text = "";
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        databind_zhubiao();
    }
}