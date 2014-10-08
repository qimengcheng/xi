using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventoryMgt_IMDiaobo : Page
{
    IMDiaoboL db = new IMDiaoboL();
    IMOutStoreD outs = new IMOutStoreD();
    IMOverL or = new IMOverL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindKufang_in();
            BindKufang_in1();
            BindKufang_out();
            BindKufang_out1();
            BindDiaoboMain();
            Panel_KucunSearch.Visible = true;
            Panel_DiaoboMain.Visible = true;
           
        }
        #region 权限
        if (Request.QueryString["status"] == "DiaoboLook")//
        {
            Title = "调拨查看";
            Button3.Visible = false;

        }
        if (Request.QueryString["status"] == "DiaoboOut")//
        {
            Title = "调出管理";
            Button3.Visible = true;
            Gridview_DiaoboMain.Columns[10].Visible = true;

        }
        if (Request.QueryString["status"] == "DiaoboLIn")//
        {
            Title = "调入管理";
            Button3.Visible = false;
            Gridview_DiaoboMain.Columns[11].Visible = true;
        }
        #endregion
    }
    #region 调拨主表
    //绑定调出仓库
    protected void BindKufang_out()
    {
        DropDownList2.DataSource = or.Select_Kufang_DropdownList(Session["Department"].ToString().Trim(), Session["UserName"].ToString().Trim());
        DropDownList2.DataTextField = "IMS_StoreName";
        DropDownList2.DataValueField = "IMS_StoreID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("选择库房", "选择库房"));
    }
    //绑定调入仓库
    protected void BindKufang_in()
    {
        DropDownList3.DataSource = db.Select_IMStoreALL();
        DropDownList3.DataTextField = "IMS_StoreName";
        DropDownList3.DataValueField = "IMS_StoreID";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("选择库房", "选择库房"));
    }
    //绑定调出仓库1
    protected void BindKufang_out1()
    {
        DropDownList4.DataSource = or.Select_Kufang_DropdownList(Session["Department"].ToString().Trim(), Session["UserName"].ToString().Trim());
        DropDownList4.DataTextField = "IMS_StoreName";
        DropDownList4.DataValueField = "IMS_StoreID";
        DropDownList4.DataBind();
       
    }
    //绑定调入仓库1
    protected void BindKufang_in1()
    {
        DropDownList5.DataSource = db.Select_IMStoreALL();
        DropDownList5.DataTextField = "IMS_StoreName";
        DropDownList5.DataValueField = "IMS_StoreID";
        DropDownList5.DataBind();
       
    }
    //调拨检索条件获得
    public string GetCondition_Diaobo()
    {
        string conditon;
        string temp = "";
        if (TextBox1.Text != "")
        {
            temp += " and IMA_AllotNum like'%" + TextBox1.Text.ToString().Trim() + "%'";
        }
        if (DropDownList2.SelectedValue != "选择库房")
        {
            temp += " and IMA_OutHouse like'%" + DropDownList2.SelectedValue.ToString() + "%'";
        }
        if (DropDownList3.SelectedValue != "选择库房")
        {
            temp += " and IMA_InHouse like'%" + DropDownList3.SelectedValue.ToString() + "%'";
        }
        if (DropDownList1.SelectedValue != "选择时间")
        {
            if (DropDownList1.SelectedValue == "调出时间")
            {
                temp += " and IMA_OutHouseTime between'" + TextBox5.Text.ToString().Trim() + "' and '"+TextBox6.Text.ToString().Trim()+"'";
            }
            if (DropDownList1.SelectedValue == "调入时间")
            {
                temp += " and IMA_InHouseTime between'" + TextBox5.Text.ToString().Trim() + "' and '" + TextBox6.Text.ToString().Trim() + "'";
            }
        }
        conditon = temp;
        label11.Text = conditon;
        return conditon;
    }
    //检索调拨单
    protected void SearchDiaoboMain(object sender, EventArgs e)
    {
        GetCondition_Diaobo();
        BindDiaoboMain();
    }
    //绑定调拨主表
    protected void BindDiaoboMain()
    {
        Gridview_DiaoboMain.DataSource = db.Select_Allot(label11.Text.ToString().Trim());
        Gridview_DiaoboMain.DataBind();
        UpdatePanel_DiaoboMain.Update();
    }
    //新建调拨单
    protected void NewDiaoboMain(object sender, EventArgs e)
    {
        Panel_NewDiaoboMain.Visible = true;
        UpdatePanel_NewDiaoboMain.Update();
    }
    //提交新建的领料单
    protected void ConfirmNewDiaoboMain(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString().Trim();  
        Guid outid = new Guid(DropDownList4.SelectedValue.ToString());
        Guid inid = new Guid(DropDownList5.SelectedValue.ToString());
        db.Insert_Allot(outid, inid, man);
        BindDiaoboMain();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功，请点击编辑详细进行后续操作！')", true);
        Panel_NewDiaoboMain.Visible = false;
        UpdatePanel_NewDiaoboMain.Update();
    }
    //取消新建的领料单
    protected void CloseNewDiaoboMain(object sender, EventArgs e)
    {
        Panel_NewDiaoboMain.Visible = false;
        UpdatePanel_NewDiaoboMain.Update();
    }
    #endregion
    #region 库存主表gridview
    protected void Gridview_Kucun_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_DiaoboMain.BottomPagerRow;


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

        BindDiaoboMain();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_DiaoboMain.PageCount ? Gridview_DiaoboMain.PageCount - 1 : newPageIndex;
        Gridview_DiaoboMain.PageIndex = newPageIndex;
        Gridview_DiaoboMain.DataBind();
    }
    protected void Gridview_Kucun_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Look1")
        {
           
            label6.Text = e.CommandArgument.ToString();
            label14.Text = Gridview_DiaoboMain.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            label7.Text = Gridview_DiaoboMain.DataKeys[gvr.RowIndex]["IMA_InHouse"].ToString();
            label8.Text = Gridview_DiaoboMain.DataKeys[gvr.RowIndex]["IMA_OutHouse"].ToString();
            Panel1.Visible = true;
Gridview1.Columns[8].Visible = false;
            BindDiaoboD();
            Button8.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
            Button11.Visible = false;
            UpdatePanel1.Update(); 
           
        }
        if (e.CommandName == "Edit1")
        {
            label6.Text = e.CommandArgument.ToString();
            Guid id = new Guid(label6.Text.ToString());
            label14.Text = Gridview_DiaoboMain.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            label7.Text = Gridview_DiaoboMain.DataKeys[gvr.RowIndex]["IMA_InHouse"].ToString();
            label8.Text = Gridview_DiaoboMain.DataKeys[gvr.RowIndex]["IMA_OutHouse"].ToString();
            Panel1.Visible = true;
            BindDiaoboD();
            Button8.Visible = true;
            Button5.Visible = false;
            Button6.Visible = false;
            Button11.Visible = true;
            Gridview1.Columns[8].Visible = false;
            UpdatePanel1.Update(); 
           
        }
        if (e.CommandName == "Edit2")
        {
            label6.Text = e.CommandArgument.ToString();
            Guid id = new Guid(label6.Text.ToString());
            label14.Text = Gridview_DiaoboMain.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            label7.Text = Gridview_DiaoboMain.DataKeys[gvr.RowIndex]["IMA_InHouse"].ToString();
            label8.Text = Gridview_DiaoboMain.DataKeys[gvr.RowIndex]["IMA_OutHouse"].ToString();
            Panel1.Visible = true;
            BindDiaoboD();
            Button8.Visible = false;
            Button5.Visible = true;
            Button6.Visible = true;
            Button11.Visible = false;
            Gridview1.Columns[8].Visible = true;
            UpdatePanel1.Update();

        }
    }
    #endregion
    #region 调拨详细表
    //绑定gridview里面的下拉框库房区域
    protected void BindDropdownlist8()
    {
        Guid id = new Guid(label7.Text.ToString());
        DropDownList8.DataSource = db.Select_Area(id);
        DropDownList8.DataTextField = "IMSA_AreaName";
        DropDownList8.DataValueField = "IMSA_AreaID";
        DropDownList8.DataBind();
    }
    //bangding
    protected void BindDiaoboDetail()
    {
        Gridview1.DataSource = db.Select_AllotDetail(new Guid (label6.Text.ToString().Trim()));
        Gridview1.DataBind();
        UpdatePanel1.Update();
    }
    //绑定调拨详细表
    protected void BindDiaoboD()
    {
        Guid id = new Guid(label6.Text.ToString());
        Gridview1.DataSource = db.Select_AllotDetail(id);
        Gridview1.DataBind();
        UpdatePanel1.Update();
    }
    //提交调拨单
    protected void BaocunDiaoboMain(object sender, EventArgs e)
    {
        Guid id = new Guid(label6.Text.ToString());
        db.Update_Allot(id);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        Panel1.Visible = false;
        UpdatePanel1.Update();
        BindDiaoboMain();
            
    }
    //正常接受
    protected void DiaoboMainOK(object sender, EventArgs e)
    {
       
            string state = "正常接收";
            Guid id = new Guid(label6.Text.ToString());
            string man = Session["UserName"].ToString().Trim();
            db.Update_Allot_IMID(id);//更新库存
            db.Update_Allot_Yichang(id, man, state);//只更新状态
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('调拨完成！')", true);
            BindDiaoboMain();
            Panel1.Visible = false;
            UpdatePanel1.Update();
       

    }
    //异常拒收
    protected void DiaoboMainNotOK(object sender, EventArgs e)
    {
        string state = "异常拒收";
        Guid id = new Guid(label6.Text.ToString());
        string man = Session["UserName"].ToString().Trim();
        db.Update_Allot_Yichang(id, man, state);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已通知调拨库房！')", true);
        BindDiaoboMain();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    //关闭
    protected void CloseDiaoboMain(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel_kucun.Visible = false;
        Panel_KucunD.Visible = false;
        UpdatePanel1.Update();
        UpdatePanel_KucunD.Update();

    }
    #endregion
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview1.BottomPagerRow;


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

        BindDiaoboD();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Dian")
        {
            label15.Text = e.CommandArgument.ToString();
            Panel2.Visible = true;
            BindDropdownlist8();
            UpdatePanel2.Update();
            
        }
    }
    #region 库存
    //库存物料单检索条件获得
    public string GetCondition_Kucun()
    {
        string conditon;
        string temp = "";
        if (TextBox3.Text != "")
        {
            temp += " and Name like'%" + TextBox3.Text.ToString() + "%'";
        }
        if (TextBox4.Text != "")
        {
            temp += " and Model like'%" + TextBox4.Text.ToString() + "%'";
        }
        temp += " and IMS_StoreID like'%" + label8.Text.ToString() + "%'";
        conditon = temp;
        label38.Text = conditon;
        return conditon;
    }
    //绑定库存表
    protected void BindPur()
    {
        GetCondition_Kucun();     
        Gridview_Pur.DataSource = db.Select_IMIM_Pubian(label38.Text.ToString().Trim());
        Gridview_Pur.DataBind();
        UpdatePanel1.Update();

    }
    //关闭物料检索
    protected void ColseMat(object sender, EventArgs e)
    {
        Panel_kucun.Visible = false;
        Panel_KucunD.Visible = false;
        UpdatePanel1.Update();
        UpdatePanel_KucunD.Update();
    }
    //物料检索
    protected void SelectMat(object sender, EventArgs e)
    {
        BindPur();
    }
    //库存主表
    protected void Gridview_Pur_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Pur.BottomPagerRow;


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

        BindPur();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Pur.PageCount ? Gridview_Pur.PageCount - 1 : newPageIndex;
        Gridview_Pur.PageIndex = newPageIndex;
        Gridview_Pur.DataBind();
    }
    protected void Gridview_Pur_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        
        if (e.CommandName == "Choose5")
        {

            label27.Text = e.CommandArgument.ToString();
            label28.Text = Gridview_Pur.Rows[gvr.RowIndex].Cells[4].Text.ToString() + "-" + Gridview_Pur.Rows[gvr.RowIndex].Cells[5].Text.ToString();
            Panel_KucunD.Visible = true;
            BindKucunD();
            UpdatePanel_KucunD.Update();
        }
        
    }
    //库存详细表
    protected void Gridview_Kucun_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Kucun.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Kucun.Rows[i].Cells.Count; j++)
            {
                Gridview_Kucun.Rows[i].Cells[j].ToolTip = Gridview_Kucun.Rows[i].Cells[j].Text;
                if (Gridview_Kucun.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_Kucun.Rows[i].Cells[j].Text = Gridview_Kucun.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview_KucunD_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        BindKucunD();
        Gridview_Kucun.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Kucun.PageCount ? Gridview_Kucun.PageCount - 1 : newPageIndex;
        Gridview_Kucun.PageIndex = newPageIndex;
        Gridview_Kucun.DataBind();
    }
    protected void Gridview_Kucun_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (GridViewRow item in Gridview_Kucun.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                TextBox tb = item.FindControl("TextBox8") as TextBox;
                if (cb.Checked)
                {
                    tb.Enabled = true;
                    UpdatePanel_KucunD.Update();
                }
            }
        }
    }
    //绑定库存详细表
    protected void BindKucunD()
    {
       
            string temp;
            temp = " and a.IMIM_ID like'%" + label27.Text.ToString() + "%'";
            temp += " and d.IMS_StoreID like'%" + label8.Text.ToString() + "%'";
            Gridview_Kucun.DataSource = outs.Select_IMInventoryDetail(temp);
            Gridview_Kucun.DataBind();
            UpdatePanel_KucunD.Update();
      

    }
    #endregion
    //新增物料
    protected void NewWuliao(object sender, EventArgs e)
    {
        Panel_kucun.Visible = true;
        BindPur();
        UpdatePanel3.Update();
    }
    protected void ConfirmStoreD(object sender, EventArgs e)
    {
        Guid DMid = new Guid(label6.Text.ToString());

            foreach (GridViewRow item in Gridview_Kucun.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                TextBox tb = item.FindControl("TextBox8") as TextBox;
                if (cb.Checked)
                {
                  decimal num= Convert.ToDecimal(tb.Text.ToString());
                  Guid DetailID = new Guid(Gridview_Kucun.DataKeys[item.RowIndex]["IMID_ID"].ToString());
                 db.Insert_AllotDetail(DMid, DetailID, num);
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
            BindDiaoboD();
    }
    protected void CloseStoreD(object sender, EventArgs e)
    {
        Panel_KucunD.Visible = false;
        UpdatePanel_KucunD.Update();
    }
    //清点确认
    protected void ConfirmQingdian(object sender, EventArgs e)
    {
        decimal num = Convert.ToDecimal(TextBox2.Text.ToString());
        Guid id = new Guid(DropDownList8.SelectedValue.ToString());
        Guid iid = new Guid(label15.Text.ToString());
        db.Update_AllotDetail(iid, num, id);
        db.Update_AllotDetail(id, num,id);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        Panel2.Visible = false;
        UpdatePanel2.Update();
        BindDiaoboD();
    }
    //清点关闭
    protected void CloseQingdian(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void Gridview_DiaoboMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv.Row["IMA_AllotState"].ToString().Trim() == "待提交")
            {
                e.Row.Cells[10].Enabled = true;

            }
            else {
                e.Row.Cells[10].Enabled = false;
            }
            if (drv.Row["IMA_AllotState"].ToString().Trim() == "已提交")
            {
                e.Row.Cells[11].Enabled = true;

            }
            else
            {
                e.Row.Cells[11].Enabled = false;
            }
        }
    }
}