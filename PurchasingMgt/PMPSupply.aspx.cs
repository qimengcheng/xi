using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class PMP_PMPSupply : Page
{

    PMSupplyInfo_PMSupplyContactL pms = new PMSupplyInfo_PMSupplyContactL();

    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {
            label_pagestate.Text = Request.QueryString["state"];

            string state = label_pagestate.Text;

            if (state == "Look")
            {
                Button8.Visible = false;
                Gridview_SupplyInfo.Columns[7].Visible = false;
                Gridview_SupplyInfo.Columns[8].Visible = false;
                Button2.Visible = false;
                GridView_PMSupplyContact.Columns[9].Visible = false;
                GridView_PMSupplyContact.Columns[10].Visible = false;
                Button8.Enabled = false;
                UpdatePanel_SupplySearch.Update();
                UpdatePanel_SupplyInfo.Update();
                UpdatePanel_PMSupplyContact.Update();
                Title = "供应商信息查看";
            }
            else {
                Title = "供应商信息维护";
            }
            if (!((Session["UserRole"].ToString().Contains("供应商信息查看")) || (Session["UserRole"].ToString().Contains("供应商信息维护"))))
            {
                Response.Redirect("~/Default.aspx");

            }
            DropDownList1.Items.Insert(0, new ListItem("选择供应商类别", "选择供应商类别"));
            UpdatePanel_SupplySearch.Visible = true;
            BindGridView_Supplyinfo("");
            UpdatePanel_SupplyInfo.Update();
            UpdatePanel_PMSupplyContact.Update();
        }
    }
    //执行查找供应商
    private void BindGridView_Supplyinfo(string Condition)
    {
        try
        {
            Gridview_SupplyInfo.DataSource = pms.SelectPMSupplyInfo(Condition);
            Gridview_SupplyInfo.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //执行查找联系方式
    private void BindGridView_SupplyContact_Gridview(string sct)
    {
        try
        {
            Guid id = new Guid(sct);
            GridView_PMSupplyContact.DataSource = pms.SelectPMSupplyContact(id);
            GridView_PMSupplyContact.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        try
        {
            string Condition = GetCondition();
            BindGridView_Supplyinfo(Condition);
            Panel_SupplyInfo.Visible = true;
            UpdatePanel_SupplyInfo.Update();
            Panel_PMSupplyContact.Visible = false;
            UpdatePanel_PMSupplyContact.Update();
            Panel_PMSupplyInfo.Visible = false;
            UpdatePanel_PMSupplyInfo.Update();
            Panel_SupplyContactNew.Visible = false;
            UpdatePanel_SupplyContactNew.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //模糊查找
    protected string GetCondition()
    {
        try
        {
            string Condition;
            string temp = "";

            if (DropDownList1.Text.ToString() != "选择供应商类别")
            {
                temp += " and PMSI_SupplySort='" + DropDownList1.SelectedValue.ToString() + "'";
            }
            if (SupplyName.Text.ToString() != "")
            {
                temp += " and PMSI_SupplyName like '%" + SupplyName.Text.ToString() + "%'";
            }
            if (PMSI_SupplyNum.Text.ToString() != "")
            {
                temp += " and  PMSI_SupplyNum = '" + PMSI_SupplyNum.Text.ToString() + "'";
            }

            Condition = temp;
            labelcodition.Text = Condition;
            return Condition;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        try
        {

            DropDownList1.SelectedValue = "选择供应商类别";
            SupplyName.Text = "";
            PMSI_SupplyNum.Text = "";
            BindGridView_Supplyinfo("");
            UpdatePanel_SupplyInfo.Update();
            UpdatePanel_PMSupplyContact.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //关闭联系方式表
    protected void CanelSupplyContact1(object sender, EventArgs e)
    {
        try
        {
            Panel_PMSupplyContact.Visible = false;
            Panel_SupplyContactNew.Visible = false;
            UpdatePanel_SupplyContactNew.Update();

            UpdatePanel_PMSupplyContact.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //确认联系方式
    protected void ConfirmPMSupplyContact(object sender, EventArgs e)
    {
        try
        {
            if (TextBox_PMSC_Name.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_SupplyContactNew, GetType(), "alert", "alert('请填写姓名！')", true);
                return;
            }
            else
            {
                if (TextBox_PMSC_PhoneNum.Text.ToString() == "" && TextBox_PMSC_TelephoneNum.Text.ToString() == "" && TextBox_PMSC_FaxNum.Text.ToString() == "" && TextBox_PMSC_Email.Text.ToString() == "" && TextBox_PMSC_QQ.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_SupplyContactNew, GetType(), "alert", "alert('请至少填写一种联系方式！')", true);
                    return;
                }
                else
                {
                    string Sname = TextBox_PMSC_Name.Text.ToString();
                    Guid sid;
                    string Sphonenum = TextBox_PMSC_PhoneNum.Text.ToString();
                    string Sposition = TextBox_PMSC_Position.Text.ToString();

                    string telephonenum = TextBox_PMSC_TelephoneNum.Text.ToString();

                    string faxnum = TextBox_PMSC_FaxNum.Text.ToString();

                    string email = TextBox_PMSC_Email.Text.ToString();

                    string QQ = TextBox_PMSC_QQ.Text.ToString();

                    if (label1_PanelSupply.Text == "新建")
                    {

                        DataSet ds = pms.SelectPMSupplyContact_Same(TextBox_PMSC_Name.Text);
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel_SupplyContactNew, GetType(), "alert", "alert('该联系人已存在！')", true);
                            return;
                        }

                        Guid idd = new Guid(label1_BasicID.Text.ToString());
                        pms.InsertPMSupplyContact(idd, Sname, Sposition, telephonenum, Sphonenum, faxnum, email, QQ);

                    }
                    if (label1_PanelSupply.Text == "修改")
                    {
                        sid = new Guid(label1_BasicID.Text.ToString());
                        pms.UpdatePMSupplyContact(sid, Sname, Sposition, telephonenum, Sphonenum, faxnum, email, QQ);
                    }

                    BindGridView_SupplyContact_Gridview(label_supplytypeid.Text);
                    UpdatePanel_PMSupplyContact.Update();
                    Panel_PMSupplyContact.Visible = true;
                    TextBox_PMSC_Name.Text = "";
                    TextBox_PMSC_PhoneNum.Text = "";
                    TextBox_PMSC_Position.Text = "";
                    TextBox_PMSC_TelephoneNum.Text = "";
                    TextBox_PMSC_FaxNum.Text = "";
                    TextBox_PMSC_Email.Text = "";
                    TextBox_PMSC_QQ.Text = "";
                    Panel_SupplyContactNew.Visible = false;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //打开新增供应商表
    protected void Button2_Nw(object sender, EventArgs e)
    {
        try
        {
            Label_Supply.Text = "新增供应商";
            TextBox2.Text = "";
            TextBox1.Text = "";
            TextBox3.Text = "";
            DropDownList3.SelectedValue = "请选择";
            Panel_PMSupplyInfo.Visible = true;
            UpdatePanel_PMSupplyInfo.Visible = true;
            UpdatePanel_PMSupplyInfo.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //新增联系方式
    protected void CreateSupplyContact(object sender, EventArgs e)//
    {
        try
        {
            label1_PanelSupply.Text = "新建";

            Guid ls = new Guid(label_supplytypeid.Text);
            DataSet ds = pms.SelectPMSupply_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_SNum.Text = dt.Rows[0][1].ToString();
                label_SName.Text = dt.Rows[0][0].ToString();
            }
            Label_Change.Text = label_SNum.Text + "   " + label_SName.Text;


            Panel_SupplyContactNew.Visible = true;
            TextBox_PMSC_QQ.Text = "";
            TextBox_PMSC_Email.Text = "";
            TextBox_PMSC_Name.Text = "";
            TextBox_PMSC_Position.Text = "";
            TextBox_PMSC_TelephoneNum.Text = "";
            TextBox_PMSC_PhoneNum.Text = "";
            TextBox_PMSC_FaxNum.Text = "";
            UpdatePanel_SupplyContactNew.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消新增联系方式
    protected void CanelPMSupplyContact(object sender, EventArgs e)
    {
        try
        {
            Panel_SupplyContactNew.Visible = false;
            UpdatePanel_SupplyContactNew.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //分页
    protected void GridView_SupplyInfo_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头
            foreach (TableCell MyHeader in e.Row.Cells) //对每一单元格      
                if (MyHeader.HasControls())
                    if (((LinkButton)MyHeader.Controls[0]).CommandArgument == Gridview_SupplyInfo.SortExpression)
                        //是否为排序列
                        if (Gridview_SupplyInfo.SortDirection == SortDirection.Ascending) //依排序方向加入方向箭头
                            MyHeader.Controls.Add(new LiteralControl("↑"));
                        else
                            MyHeader.Controls.Add(new LiteralControl("↓"));
    }


    protected void Gridview_SupplyInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")//点击查看联系方式
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_SupplyInfo.SelectedIndex = row.RowIndex;

            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Label_SupplyContact_Source.Text = "Gridview数据源";
            string sid = e.CommandArgument.ToString();
            Guid ls = new Guid(sid);
            DataSet ds = pms.SelectPMSupply_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_SNum.Text = dt.Rows[0][1].ToString();
                label_SName.Text = dt.Rows[0][0].ToString();
            }
            Label_SupplyContact_Source.Text = label_SNum.Text + "   " + label_SName.Text;
            Panel_PMSupplyContact.Visible = true;
            BindGridView_SupplyContact_Gridview(sid);
            Panel_PMSupplyContact.Visible = true;
            UpdatePanel_PMSupplyContact.Update();
            label1_BasicID.Text = sid;
        }
        if (e.CommandName == "Edit1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_SupplyInfo.SelectedIndex = row.RowIndex;
            Label_Supply.Text = "编辑供应商";
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid supplyid = new Guid(Convert.ToString(e.CommandArgument));
            DataSet ds = pms.SelectPMSupply_One(supplyid);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                TextBox2.Text = dt.Rows[0][0].ToString();
                DropDownList3.SelectedValue = dt.Rows[0][4].ToString();
                TextBox1.Text = dt.Rows[0][3].ToString();
                TextBox3.Text = dt.Rows[0][5].ToString();
            }
            Panel_PMSupplyInfo.Visible = true;
            UpdatePanel_PMSupplyInfo.Update();
        }
        if (e.CommandName == "Delete1")//删除供应商
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_SupplyInfo.SelectedIndex = row.RowIndex;
            Guid supplyid = new Guid(Convert.ToString(e.CommandArgument));
            pms.DeletePMSupplyInfo(supplyid);
            BindGridView_Supplyinfo("");
            UpdatePanel_SupplyInfo.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_SupplyInfo, GetType(), "alert", "alert('删除成功！')", true);
            return;
        }
    }
    protected void GridView_PMSupplyContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit2") //编辑
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_PMSupplyContact.SelectedIndex = row.RowIndex;

            Panel_SupplyContactNew.Visible = true;
            label1_PanelSupply.Text = "修改";
            UpdatePanel_SupplyContactNew.Update();
            label1_BasicID.Text = e.CommandArgument.ToString();
            Guid id = new Guid(label1_BasicID.Text.ToString());
            DataSet ds = pms.SelectPMSupplyContact_One(id);
            DataTable dt = ds.Tables[0];

            //this.DropDownList2.SelectedItem.Text = dt.Rows[0][0].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox_PMSC_Name.Text = dt.Rows[0][2].ToString();
                TextBox_PMSC_Position.Text = dt.Rows[0][3].ToString();
                TextBox_PMSC_TelephoneNum.Text = dt.Rows[0][4].ToString();
                TextBox_PMSC_PhoneNum.Text = dt.Rows[0][5].ToString();
                TextBox_PMSC_FaxNum.Text = dt.Rows[0][6].ToString();
                TextBox_PMSC_Email.Text = dt.Rows[0][7].ToString();
                TextBox_PMSC_QQ.Text = dt.Rows[0][8].ToString();
                label1_BasicID.Text = e.CommandArgument.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_SupplyContactNew, GetType(), "alert", "alert('没有数据')", true);
                return;
            }


            DataSet dss = pms.SelectPMSupply_One(id);
            DataTable dtt = dss.Tables[0];
            if (dtt.Rows.Count > 0)
            {
                label_SNum.Text = dtt.Rows[0][1].ToString();
                label_SName.Text = dtt.Rows[0][0].ToString();
            }
            Label_Change.Text = label_SNum.Text + "   " + label_SName.Text;
        }
        if (e.CommandName == "Delete2")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_PMSupplyContact.SelectedIndex = row.RowIndex;
            string sid = e.CommandArgument.ToString();
            Guid id = new Guid(sid);
            pms.DeletePMSupplyContact(id);
            // if (this.Label_SupplyContact_Source.Text == "Gridview数据源")
            // {
            //    BindGridView_SupplyContact_Gridview(this.label_supplytypeid.ToString());
            //}
            // if (this.Label_SupplyContact_Source.Text == "模糊查询数据源")
            //  {
            //      BindGridView_Supplyinfo(GetCondition());
            //  }
            // Guid ssd = new Guid(this.label_supplytypeid.Text.ToString());
            //pms.SelectPMSupplyContact(ssd );
            BindGridView_SupplyContact_Gridview(label_supplytypeid.Text.ToString());
            UpdatePanel_PMSupplyContact.Update();
            Panel_PMSupplyContact.Visible = true;
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMSupplyContact, GetType(), "alert", "alert('删除成功！')", true);
            return;
        }
    }
    #region //换页
    protected void Gridview_SupplyInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_SupplyInfo.BottomPagerRow;


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
        string Condition = GetCondition();
        BindGridView_Supplyinfo(Condition);
        Gridview_SupplyInfo.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_SupplyInfo.PageCount ? Gridview_SupplyInfo.PageCount - 1 : newPageIndex;
        Gridview_SupplyInfo.PageIndex = newPageIndex;
        Gridview_SupplyInfo.DataBind();

    }
    protected void GridView_PMSupplyContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_PMSupplyContact.BottomPagerRow;


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
        if (Label_SupplyContact_Source.Text == "Gridview数据源")
        {
            BindGridView_SupplyContact_Gridview(label_supplytypeid.ToString());
        }
        if (Label_SupplyContact_Source.Text == "模糊查询数据源")
        {
            BindGridView_Supplyinfo(GetCondition());
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_PMSupplyContact.PageCount ? GridView_PMSupplyContact.PageCount - 1 : newPageIndex;
        GridView_PMSupplyContact.PageIndex = newPageIndex;
        GridView_PMSupplyContact.DataBind();

    }
    #endregion
    ////更新供应商
    //protected void Gridview_SupplyInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    Guid PMSI_ID = new Guid(Gridview_SupplyInfo.DataKeys[e.RowIndex].Value.ToString());
    //    string PMSI_SupplyName = Convert.ToString(((TextBox)(Gridview_SupplyInfo.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
    //    string PMSI_SupplySort = Convert.ToString(((TextBox)(Gridview_SupplyInfo.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
    //    string PMSI_Remark = Convert.ToString(((TextBox)(Gridview_SupplyInfo.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString());//设置成TextBook
    //    Gridview_SupplyInfo.EditIndex = -1;
    //    BindGridView_Supplyinfo(" ");
    //    pms.UpdatePMSupplyInfo(PMSI_ID, PMSI_SupplyName, PMSI_SupplySort, PMSI_Remark);
    //    BindGridView_Supplyinfo(" ");
    //    this.UpdatePanel_SupplyInfo.Update();
    //    this.Panel_SupplyInfo.Visible = true;
    //    this.UpdatePanel_PMSupplyInfo.Update();
    //}
    ////编辑供应商
    //protected void Gridview_SupplyInfo_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    Gridview_SupplyInfo.EditIndex = e.NewEditIndex;

    //    BindGridView_Supplyinfo(" ");
    //}
    ////取消编辑供应商
    //protected void Gridview_SupplyInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    Gridview_SupplyInfo.EditIndex = -1;
    //    BindGridView_Supplyinfo(" ");
    //}

    //新增供应商确定
    protected void ConfirmSupply(object sender, EventArgs e)
    {
        try
        {
            string Supplyname = "";
            string Supplysort = "";

            if (TextBox2.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMSupplyInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {

                Supplyname = TextBox2.Text.ToString();
            }
            if (DropDownList3.SelectedValue.ToString() == "请选择")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMSupplyInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                Supplysort = DropDownList3.SelectedValue.ToString();
            }
            string Remark = TextBox1.Text.ToString();
            int PaymentTime =Convert.ToInt16(TextBox3.Text.ToString());
            if (Label_Supply.Text == "新增供应商")
            {
                DataSet dss = pms.SelectPMSupply_Same(TextBox2.Text);
                DataTable dtt = dss.Tables[0];
                if (dtt.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMSupplyInfo, GetType(), "alert", "alert('该供应商已存在！')", true);
                    return;
                }
                else
                {
                    pms.InsertPMSupplyInfo(Supplyname, Supplysort, Remark,PaymentTime);
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMSupplyInfo, GetType(), "alert", "alert('新增成功！')", true);
                }
            }
            if (Label_Supply.Text == "编辑供应商")
            {
                Guid PMSI_ID = new Guid(label_supplytypeid.Text.ToString());
                pms.UpdatePMSupplyInfo(PMSI_ID, Supplyname, Supplysort, Remark, PaymentTime);
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMSupplyInfo, GetType(), "alert", "alert('修改成功！')", true);
               
            }
            BindGridView_Supplyinfo("");
            UpdatePanel_SupplyInfo.Update();
            Panel_PMSupplyInfo.Visible = false;
            UpdatePanel_PMSupplyInfo.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消新增供应商
    protected void CanelSupply(object sender, EventArgs e)
    {
        try
        {
            Panel_PMSupplyInfo.Visible = false;
            UpdatePanel_PMSupplyInfo.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void Gridview_SupplyInfo_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_SupplyInfo.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_SupplyInfo.Rows[i].Cells.Count; j++)
            {
                Gridview_SupplyInfo.Rows[i].Cells[j].ToolTip = Gridview_SupplyInfo.Rows[i].Cells[j].Text;
                if (Gridview_SupplyInfo.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_SupplyInfo.Rows[i].Cells[j].Text = Gridview_SupplyInfo.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }


}