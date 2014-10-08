using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;
public partial class SalesMgt_SalesReturn : Page
{
    SalesReturnD sr = new SalesReturnD();
    SalesReturnReasonD srr = new SalesReturnReasonD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFahuoDan();
            BindTuihuodan();
            BindDropdownlist2();
        }
        #region 权限
        if (Request.QueryString["status"] == "SalesLook")//销售退货查看
        {
            Title = "销售退货查看";
            Panel2.Visible = true;
            UpdatePanel1.Update();
            Panel3.Visible = true;
            UpdatePanel2.Update();
            Gridview_Return.Columns[15].Visible = false;
            Gridview_Return.Columns[14].Visible = false;
            UpdatePanel2.Update();
        }
        if (Request.QueryString["status"] == "SalesResult")//销售退货处理结果维护
        {
            Title = "销售退货处理结果维护";
            Panel2.Visible = true;
            UpdatePanel1.Update();
            Panel3.Visible = true;
            UpdatePanel2.Update();
            Gridview_Return.Columns[14].Visible = true;
            Gridview_Return.Columns[15].Visible = false;
            UpdatePanel2.Update();
        }
        if (Request.QueryString["status"] == "SalesMangement")//销售收货退货管理
        {
            Title = "销售收货退货管理";
            Panel2.Visible = true;
            UpdatePanel1.Update();
            Panel3.Visible = true;
            UpdatePanel2.Update();
            Gridview_Return.Columns[14].Visible = false;
            Gridview_Return.Columns[15].Visible = false;
            UpdatePanel2.Update();
            Panel_OrderDeliverSearch.Visible = true;
            Panel_OrderDeliver.Visible = true;
            UpdatePanel_OrderDeliverSearch.Update();
            UpdatePanel_OrderDeliver.Update();
        }


        #endregion
    }
    protected void BindDropdownlist2()
    {
        DropDownList2.DataSource = srr.Select_Reason("");
      
        DropDownList2.DataTextField = "SMRR_Name";
        DropDownList2.DataValueField = "SMRR_ID";
        DropDownList2.DataBind();
        UpdatePanel_Tuihuanhuo.Update();
    }
    #region 发货单
    //检索发货单
    protected void SearchOrderDeliver(object sender, EventArgs e)
    {
        GetCondition_Fahuodan();
        BindFahuoDan();
    }
    //绑定发货单
    protected void BindFahuoDan()
    {
        Gridview_OrderDeliver.DataSource = sr.Select_Fahuodan(label11.Text.ToString().Trim());
        Gridview_OrderDeliver.DataBind();
        UpdatePanel_OrderDeliver.Update();
    }
    //获取检索发货单条件
    public string GetCondition_Fahuodan()
    {
        string conditon;
        string temp = "";
        if (TextBox1.Text != "")
        {
            temp += " and PT_Name like'%" + TextBox1.Text.ToString().Trim() + "%'";
        }
        if (TextBox2.Text != "")
        {
            temp += " and IMOHM_OutHouseNum like'%" + TextBox2.Text.ToString().Trim() + "%'";
        }
        if (TextBox3.Text != "")
        {
            temp += " and SMSO_ComOrderNum like'%" + TextBox3.Text.ToString().Trim() + "%'";
        }
        if (TextBox4.Text != "")
        {
            temp += " and CRMCIF_Name like'%" + TextBox4.Text.ToString().Trim() + "%'";
        }
        if (TextBox5.Text != "")
        {
            temp += " and IMOHM_TakeAwayMakeSureTime like'%" + TextBox5.Text.ToString().Trim() + "%'";
        }
        conditon = temp;
        label11.Text = conditon;
        return conditon;
    }
    #endregion
    #region 退货单
    //绑定退货单
    protected void BindTuihuodan()
    {
        Gridview_Return.DataSource = sr.Select_Tuihuodan(label8.Text.ToString().Trim());
        Gridview_Return.DataBind();
        UpdatePanel2.Update();
    }
    //检索退货单
    protected void SearchReturn(object sender, EventArgs e)
    {
        GetCondition_Tuihuodan();
        BindTuihuodan();
    }
    //获取检索发货单条件
    public string GetCondition_Tuihuodan()
    {
        string conditon;
        string temp = "";
        if (TextBox8.Text != "")
        {
            temp += " and PT_Name like'%" + TextBox8.Text.ToString().Trim() + "%'";
        }
        if (TextBox9.Text != "")
        {
            temp += " and SMRC_ReturnOrderNum like'%" + TextBox9.Text.ToString().Trim() + "%'";
        }
        if (TextBox10.Text != "")
        {
            temp += " and CRMCIF_Name like'%" + TextBox10.Text.ToString().Trim() + "%'";
        }
        if (TextBox11.Text != ""&&TextBox12.Text!="")
        {
            temp += " and SMRC_MakeTime between'%" + TextBox11.Text.ToString().Trim() + "%' and '" + TextBox12.Text.ToString().Trim();
        }
        conditon = temp;
        label8.Text = conditon;
        return conditon;
    }
         //提交处理结果
        protected void ComfirmChuli(object sender, EventArgs e)
        {
            string man = Session["UserName"].ToString().Trim();
            string result = TextBox14.Text.ToString().Trim();
            Guid id =new Guid (label17.Text.ToString());
            sr.Update_Tuihuodan_Chuli(result, man, id);
            Panel4.Visible = false;
            UpdatePanel3.Update();
            TextBox14.Text = "";
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
            BindTuihuodan();
        }
        //关闭处理结果
        protected void CloseChuli(object sender, EventArgs e)
        {
            Panel4.Visible = false;
            UpdatePanel3.Update();
        }
        //提交退货
        protected void ComfirmTuihuanhuo(object sender, EventArgs e)
        {
            if (label18.Text == "退货")
            {
                Guid id = new Guid(label3.Text.ToString().Trim());
                string man = Session["UserName"].ToString().Trim();
                int num = Convert.ToInt32(TextBox6.Text.ToString());
                string reason = TextBox7.Text.ToString().Trim();
                Guid ReasonID = new Guid(DropDownList2.SelectedValue.ToString());
                sr.Update_Fahuodan_Tuihuo(id, man, num, reason,ReasonID);
                BindFahuoDan();
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已生成退货单！')", true);
                TextBox6.Text = "";
                TextBox7.Text = "";
                Panel1.Visible = false;
                UpdatePanel_Tuihuanhuo.Update();
                string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了" + label12.Text.ToString()+ "的退货单，请注意及时进行后续处理！";
                string sErr = RTXhelper.Send(remind, "销售退货处理结果维护");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }

            }
            else if (label18.Text == "换货")
            {
                Guid id = new Guid(label3.Text.ToString().Trim());
                string man = Session["UserName"].ToString().Trim();
                int num = Convert.ToInt32(TextBox6.Text.ToString());
                string reason = TextBox7.Text.ToString().Trim();
                sr.Update_Fahuodan_Huanhuo(id, man, num, reason);
                BindFahuoDan();
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已生成换货单！')", true);
                TextBox6.Text = "";
                TextBox7.Text = "";
                Panel1.Visible = false;
                UpdatePanel_Tuihuanhuo.Update();
            }
        }
        //取消退货
        protected void CloseTuihuanhuo(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            TextBox6.Text = "";
            TextBox7.Text = "";
            UpdatePanel_Tuihuanhuo.Update();
        }
    #endregion
    #region Gridview
    //发货单
    protected void Gridview_OrderDeliver_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_OrderDeliver.BottomPagerRow;


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

        BindFahuoDan();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_OrderDeliver.PageCount ? Gridview_OrderDeliver.PageCount - 1 : newPageIndex;
        Gridview_OrderDeliver.PageIndex = newPageIndex;
        Gridview_OrderDeliver.DataBind();
    }
    protected void Gridview_OrderDeliver_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Confirm1")//确认收货
        {
            Guid id =new Guid ( e.CommandArgument.ToString());
            sr.Update_Fahuodan_Queren(id);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('确认收货成功！')", true);
            BindFahuoDan();

        }
        if (e.CommandName == "Tui1")//退货
        {
            Panel1.Visible = true;
            label3.Text = e.CommandArgument.ToString();
            label18.Text = "退货";
            label12.Text=Gridview_OrderDeliver.Rows[gvr.RowIndex].Cells[2].Text.ToString().Trim()+"-"+Gridview_OrderDeliver.Rows[gvr.RowIndex].Cells[3].Text.ToString().Trim();
            UpdatePanel_Tuihuanhuo.Update();
            
        }
        if (e.CommandName == "Huan1")//换货
        {
            Panel1.Visible = true;
            label3.Text = e.CommandArgument.ToString();
            label18.Text = "换货";
            label12.Text=Gridview_OrderDeliver.Rows[gvr.RowIndex].Cells[2].Text.ToString().Trim()+"-"+Gridview_OrderDeliver.Rows[gvr.RowIndex].Cells[3].Text.ToString().Trim();
            UpdatePanel_Tuihuanhuo.Update();
        }
        
    }
    //退货单
    protected void Gridview_Return_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Return.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Return.Rows[i].Cells.Count; j++)
            {
                Gridview_Return.Rows[i].Cells[j].ToolTip = Gridview_Return.Rows[i].Cells[j].Text;
                if (Gridview_Return.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_Return.Rows[i].Cells[j].Text = Gridview_Return.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        } 
    }
    protected void Gridview_Return_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Return.BottomPagerRow;


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

        BindTuihuodan();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Return.PageCount ? Gridview_Return.PageCount - 1 : newPageIndex;
        Gridview_Return.PageIndex = newPageIndex;
        Gridview_Return.DataBind();
    }
    protected void Gridview_Return_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Result1")
        {
            Panel4.Visible = true;
            label17.Text = e.CommandArgument.ToString();
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Delete1")
        {
            Guid id =new Guid( e.CommandArgument.ToString());
            sr.Delete_Tuihuodan(id);
            BindTuihuodan();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);

        }
    }
    #endregion
    
}