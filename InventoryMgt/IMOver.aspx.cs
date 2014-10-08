using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class InventoryMgt_IMOver : Page
{
    IMOverL or = new IMOverL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string temp = "";
            string department = Session["Department"].ToString().Trim();
            temp += " and d.IMS_ResponDepart like '%" + department + "%'";
            label11.Text = temp;
            BindKucun();
            BindKufang();
            BindKufang1();
            BindApply();
         
        }
        #region 权限
        if (Request.QueryString["status"] == "BaofeiApply")
        {
            Title = "报废申请";
            Panel_KucunSearch.Visible = true;
            UpdatePanel_KucunSearch.Update();
            Panel_Kucun.Visible = true;
            UpdatePanel_Kucun.Update();
        }
        if (Request.QueryString["status"] == "BaofeiAnalysis")
        {
            Title = "报废申请分析";
            Panel_SearchApply.Visible = true;
            UpdatePanel_SearchApply.Update();
            Panel_ApplyMain.Visible = true;
            Gridview_Apply.Columns[14].Visible = true;

        }
        if (Request.QueryString["status"] == "BaofeiCheck")
        {
            Title = "报废审核";
            Panel_SearchApply.Visible = true;
            UpdatePanel_SearchApply.Update();
            Panel_ApplyMain.Visible = true;
            Gridview_Apply.Columns[15].Visible = true;

            UpdatePanel_ApplyMain.Update();
        }
        if (Request.QueryString["status"] == "BaofeiZhixing")
        {
            Title = "报废执行";
            Panel_SearchApply.Visible = true;
            UpdatePanel_SearchApply.Update();
            Panel_ApplyMain.Visible = true;
            Gridview_Apply.Columns[16].Visible = true;
            UpdatePanel_ApplyMain.Update();
        }
        if (Request.QueryString["status"] == "BaofeiLook")
        {
            Title = "报废查看";
            Panel_SearchApply.Visible = true;
            UpdatePanel_SearchApply.Update();
            Panel_ApplyMain.Visible = true;

            UpdatePanel_ApplyMain.Update();
        }
        #endregion

    }
    #region 库存查询
    //绑定下拉库房
    protected void BindKufang()
    {     
        DropDownList1.DataSource = or.Select_Kufang_DropdownList(Session["Department"].ToString().Trim(), Session["UserName"].ToString().Trim());
        DropDownList1.DataTextField = "IMS_StoreName";
        DropDownList1.DataValueField = "IMS_StoreID";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("选择库房", "选择库房"));
    }
    //检索库存
    protected void SearchKucun(object sender, EventArgs e)
    {
        GetCondition_Kucun();
        BindKucun();
    }
    //绑定库存表
    protected void BindKucun()
    {
        Gridview_Kucun.DataSource = or.Select_Kucun(label11.Text.ToString().Trim());
        Gridview_Kucun.DataBind();
        UpdatePanel_Kucun.Update();
    }
    //库存检索条件获得
    public string GetCondition_Kucun()
    {
        string conditon;
        string temp = "";
        if (TextBox1.Text != "")
        {
            temp += " and c.IMMBD_MaterialName like'%" + TextBox1.Text.ToString().Trim() + "%'";
        }
        if (TextBox2.Text.ToString() != "")
        {
            temp += " and c.IMMBD_SpecificationModel like'%" + TextBox2.Text.ToString().Trim() + "%'";
        }
        if (TextBox3.Text.ToString() != "")
        {
            temp += " and a.IMID_BatchNum like'%" + TextBox3.Text.ToString().Trim() + "%'";
        }
        if (TextBox4.Text.ToString() != "")
        {
            temp += " and c.IMMBD_MaterialCode like'%" + TextBox4.Text.ToString().Trim() + "%'";
        }
        if (TextBox7.Text.ToString() != "")
        {
            temp += " and a.IMID_DelayDay like'%" + TextBox7.Text.ToString().Trim() + "%'";
        }
        if (TextBox5.Text.ToString() != "" && TextBox6.Text.ToString() != "")
        {
            DateTime d1 = Convert.ToDateTime(TextBox5.Text.ToString().Trim());
            DateTime d2 = Convert.ToDateTime(TextBox6.Text.ToString().Trim());
            if (d2 <= d1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请确保起始时间小于结束时间！')", true);
            }
            else
            {
                temp += " and a.IMID_InHouseTime between'" + Convert.ToString(d1) + "' and '" + Convert.ToString(d2) + "'";
            }

        }
        if (DropDownList1.SelectedValue != "选择库房")
        {
            temp += " and d.IMS_StoreID like'%" + DropDownList1.SelectedValue.ToString() + "%'";

        }
        string department = Session["Department"].ToString().Trim();
        temp += " and  d.IMS_ResponDepart like '%" + department + "%'";
        conditon = temp;
        label11.Text = conditon;
        return conditon;
    }
    //超期库存查看
    protected void ChaoqiKucun(object sender, EventArgs e)
    {
        string temp = "";
        string department = Session["Department"].ToString().Trim();
        temp += " and  d.IMS_ResponDepart like '%" + department + "%' AND DATEADD(DAY,CONVERT(int,(ISNULL(a.IMID_DelayDay,0)+isnull(c.IMMBD_StorageDay,0))),a.IMID_InHouseTime)<GETDATE()";
        label11.Text = temp;
        BindKucun();
    }
    #endregion
    #region Gridview_Kucun

    protected void Gridview_Kucun_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Kucun.BottomPagerRow;


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

        BindKucun();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Kucun.PageCount ? Gridview_Kucun.PageCount - 1 : newPageIndex;
        Gridview_Kucun.PageIndex = newPageIndex;
        Gridview_Kucun.DataBind();
    }
    protected void Gridview_Kucun_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Apply")
        {
            label10.Text = e.CommandArgument.ToString();
            Panel_Apply.Visible = true;
            UpdatePanel_Apply.Update();
            TB_shengchanman.Text = Session["UserName"].ToString().Trim();
            TB_shengchantime.Text = DateTime.Now.ToShortDateString();
        }
    }
    #endregion
    #region 提出报废申请
    //提交申请
    protected void ConfirmApply(object sender, EventArgs e)
    {
        Guid id = new Guid(label10.Text.ToString().Trim());
        string man = Session["UserName"].ToString().Trim();
        string reason = TB_lingdaoyijian.Text.ToString().Trim();
        or.Insert_Apply(id, man, reason);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        Panel_Apply.Visible = false;
        UpdatePanel_Apply.Update();
        label17.Text = "";
        BindApply();
    }
    //关闭申请
    protected void CloseApply(object sender, EventArgs e)
    {
        Panel_Apply.Visible = false;
        TB_lingdaoyijian.Text = "";
        UpdatePanel_Apply.Update();
    }
    #endregion
    #region 报废申请处理
    //绑定下拉库房
    protected void BindKufang1()
    {
        DropDownList2.DataSource = or.Select_Kufang_DropdownList(Session["Department"].ToString().Trim(), Session["UserName"].ToString().Trim());
        DropDownList2.DataTextField = "IMS_StoreName";
        DropDownList2.DataValueField = "IMS_StoreID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("选择库房", "选择库房"));
    }
    //申请检索条件获得
    public string GetCondition_Apply()
    {
        string conditon;
        string temp = "";
        if (TextBox8.Text != "")
        {
            temp += " and d.IMMBD_MaterialName like'%" + TextBox8.Text.ToString().Trim() + "%'";
        }
        if (TextBox9.Text.ToString() != "")
        {
            temp += " and d.IMMBD_SpecificationModel like'%" + TextBox9.Text.ToString().Trim() + "%'";
        }
        if (TextBox10.Text.ToString() != "")
        {
            temp += " and b.IMID_BatchNum like'%" + TextBox10.Text.ToString().Trim() + "%'";
        }
        if (TextBox11.Text.ToString() != "")
        {
            temp += " and a.IMMS_ApplyMan like'%" + TextBox11.Text.ToString().Trim() + "%'";
        }
       
        if (TextBox13.Text.ToString() != "" && TextBox14.Text.ToString() != "")
        {
            DateTime d1 = Convert.ToDateTime(TextBox13.Text.ToString().Trim());
            DateTime d2 = Convert.ToDateTime(TextBox14.Text.ToString().Trim());
            if (d2 <= d1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请确保起始时间小于结束时间！')", true);
            }
            else
            {
                temp += " and a.IMMS_ApplyTime between'" + Convert.ToString(d1) + "' and '" + Convert.ToString(d2) + "'";
            }

        }
        if (DropDownList3.SelectedValue != "选择状态")
        {
            temp += " and a.IMMS_State like'%" + DropDownList3.SelectedValue.ToString() + "%'";

        }
        if (DropDownList2.SelectedValue != "选择库房")
        {
            temp += " and f.IMS_StoreID like'%" + DropDownList1.SelectedValue.ToString() + "%'";

        }
    
        conditon = temp;
        label17.Text = conditon;
        return conditon;
    }
    //检索申请
    protected void SearchApply(object sender, EventArgs e)
    {
        GetCondition_Apply();
        BindApply();
    }
    
    //待分析的
    protected void LookFApply(object sender, EventArgs e)
    {
        label17.Text = "and a.IMMS_State like '%待分析%'";
        BindApply();
    }
    //待审核的
    protected void LookSApply(object sender, EventArgs e)
    {
        label17.Text = "and a.IMMS_State like '%待审核%'";
        BindApply();
    }
    //绑定申请表
    protected void BindApply()
    {
        Gridview_Apply.DataSource = or.Select_Apply(label17.Text.ToString());
        Gridview_Apply.DataBind();
        UpdatePanel_ApplyMain.Update();
    }
    #endregion
    #region 报废申请Gridview
    protected void Gridview_Apply_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv.Row["IMMS_State"].ToString() == "待分析")
            {
                e.Row.Cells[14].Enabled = true;
                e.Row.Cells[15].Enabled = false;
                e.Row.Cells[16].Enabled = false;
               
            }
            else  if (drv.Row["IMMS_State"].ToString() == "待审核")
            {
                e.Row.Cells[15].Enabled = true;
                e.Row.Cells[14].Enabled = false;
                e.Row.Cells[16].Enabled = false;

            }
            else if (drv.Row["IMMS_State"].ToString() == "审核通过")
            {
                e.Row.Cells[16].Enabled = true;
                e.Row.Cells[15].Enabled = false;
                e.Row.Cells[14].Enabled = false;

            }
            else {
                e.Row.Cells[14].Enabled = false;
                e.Row.Cells[16].Enabled = false;
                e.Row.Cells[15].Enabled = false;

            }

        }
    }
    protected void Gridview_Apply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Apply.BottomPagerRow;


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

        BindApply();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Apply.PageCount ? Gridview_Apply.PageCount - 1 : newPageIndex;
        Gridview_Apply.PageIndex = newPageIndex;
        Gridview_Apply.DataBind();
    }
    protected void Gridview_Apply_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Fenxi")
        {
            label18.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[1].Text.ToString().Trim() + "-" + Gridview_Apply.Rows[gvr.RowIndex].Cells[2].Text.ToString().Trim();
            label19.Text = e.CommandArgument.ToString();
            Panel1.Visible = true;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "Shenhe")
        {
            label20.Text = Gridview_Apply.Rows[gvr.RowIndex].Cells[1].Text.ToString().Trim() + "-" + Gridview_Apply.Rows[gvr.RowIndex].Cells[2].Text.ToString().Trim();
            label21.Text = e.CommandArgument.ToString();
            Panel2.Visible = true;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "Zhixing")
        {
            Guid id = new Guid(e.CommandArgument.ToString());
            or.Update_Apply_Zhixing(id);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('执行成功，相应库存已扣除！')", true);
            BindApply();
            
        }
    }
    protected void Gridview_Apply_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Apply.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Apply.Rows[i].Cells.Count; j++)
            {
                Gridview_Apply.Rows[i].Cells[j].ToolTip = Gridview_Apply.Rows[i].Cells[j].Text;
                if (Gridview_Apply.Rows[i].Cells[j].Text.Length > 10)
                {
                    Gridview_Apply.Rows[i].Cells[j].Text = Gridview_Apply.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                }
                //Gridviewl_InstoreDetail.Rows[i].Cells[j].Text = Gridviewl_InstoreDetail.Rows[i].Cells[j].Text.ToString().Trim();

            }
        }
    }
    #endregion


    //提交分析
    protected void ConfirmFenxi(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString().Trim();
        string re = TextBox16.Text.ToString().Trim();
        Guid id = new Guid(label19.Text.ToString());
        or.Update_Apply(id, re, man);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        Panel1.Visible = false;
        UpdatePanel1.Update();
        BindApply();
    }
    protected void CloseFenxi(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        TextBox16.Text = "";
        UpdatePanel1.Update();
        
    }
    //审核通过
    protected void CheckOK(object sender, EventArgs e)
    {
        string result = "审核通过";
        string man = Session["UserName"].ToString().Trim();
        Guid id = new Guid(label21.Text.ToString());
        string opinion=TextBox19.Text.ToString().Trim();
        or.Update_Apply_Check(id, result, man, opinion);
        Panel2.Visible = false;
        UpdatePanel2.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已审核通过！')", true);

    }
    //审核驳回
    protected void CheckNotOK(object sender, EventArgs e)
    {
        if (TextBox19.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核驳回必须填写驳回意见！')", true);
            return;
        }
        string result = "审核驳回";
        string man = Session["UserName"].ToString().Trim();
        Guid id = new Guid(label21.Text.ToString());
        string opinion = TextBox19.Text.ToString().Trim();
        or.Update_Apply_Check(id, result, man, opinion);
        Panel2.Visible = false;
        UpdatePanel2.Update();
        BindApply();
        UpdatePanel_Apply.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已审核驳回！')", true);
    }
    //关闭审核
    protected void CloseCheck(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
}