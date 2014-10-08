using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class SalesMgt_SalesOrder : Page
{
    SalesOrderL so = new SalesOrderL();
    SalesMonthPlanL mp = new SalesMonthPlanL();
    ProTypePrice ptp = new ProTypePrice();
    IMOutStoreD outm = new IMOutStoreD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            label_condition.Text = " order by SMSO_PlaceOrderTime desc";
            BindSalesOrder();
            //this.label_source.Text = "search";
            //this.label_condition1.Text = "";
            //BindSalesOrderDetail();
           

        }
        #region 权限
        try
        {
            if (!((Session["UserRole"].ToString().Contains("销售订单查看")) || (Session["UserRole"].ToString().Contains("销售订单维护"))))
            {
                Response.Redirect("~/Default.aspx");

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }

        //if (Session["UserRole"].ToString().Contains("销售订单查看"))
        if (Request.QueryString["status"] == "SalesOrderLook")
        {
            Title = "销售订单查看";
            Button2.Visible = false;
            Button6.Visible = false;
            UpdatePanel_Search.Update();
            GridView_Order.Columns[13].Visible = false;
            GridView_Order.Columns[15].Visible = false;
            UpdatePanel_Order.Update();
            GridView_OrderDetail.Columns[17].Visible = true;
            GridView_OrderDetail.Columns[16].Visible = true;
            Button15.Visible = false;
            UpdatePanel_OrderDetail.Update();

        }
        //if (Session["UserRole"].ToString().Contains("销售订单维护"))
        if (Request.QueryString["status"] == "SalesOrderEdit")
        {
            Title = "销售订单维护";
            Button2.Visible = true;
            //Button6.Visible = true;
            UpdatePanel_Search.Update();
            GridView_Order.Columns[13].Visible = true;
            GridView_Order.Columns[15].Visible = true;
            UpdatePanel_Order.Update();
            GridView_OrderDetail.Columns[20].Visible = true;
            GridView_OrderDetail.Columns[21].Visible = true;
            GridView_OrderDetail.Columns[23].Visible = true;
            GridView_OrderDetail.Columns[16].Visible = true;
            GridView_OrderDetail.Columns[17].Visible = true;
            GridView_OrderDetail.Columns[18].Visible = true;
            GridView_OrderDetail.Columns[19].Visible = true;
            Button15.Visible = true;
            UpdatePanel_OrderDetail.Update();

        }

        #endregion
        
    }

    #region 订单主表
    //检索订单
    protected void SearchOrder(object sender, EventArgs e)
    {
        Panel_OrderDetail.Visible = true;
        label_source.Text = "search";
        GetCondition();
        GetCondition_Detail();
        BindSalesOrder();
        Button6.Visible = false;
        Button15.Visible = false;
        BindSalesOrderDetail();

    }
    //BindSalesOrder
    protected void BindSalesOrder()
    {
        GridView_Order.DataSource = so.Select_SalesOrder(label_condition.Text.ToString());
        GridView_Order.DataBind();
        UpdatePanel_Order.Update();
    }
  
    //BindSalesOrderDetail
    protected void BindSalesOrderDetail()
    {
        string source = label_source.Text.ToString();
        switch (source)
        {
            case "search":
                {
                    GridView_OrderDetail.DataSource = so.Select_SalesOrderDetail(label_condition1.Text.ToString());
                    GridView_OrderDetail.DataBind();
                    UpdatePanel_OrderDetail.Update();
                    break;
                }
            case "gridview":
                {
                    GridView_OrderDetail.DataSource = so.Select_SalesOrderDetail_Gridview(new Guid(label_OrderID.Text.ToString()));
                    GridView_OrderDetail.DataBind();
                    UpdatePanel_OrderDetail.Update();
                    break;
                }
        }
    }
    //检索条件拼接
    protected string GetCondition()
    {
        string conditon;
        string temp = "";
        if (TextBox3.Text.ToString() != "")//客户名称
        {
            temp += " and b.CRMCIF_Name like '%" + TextBox3.Text.ToString() + "%'";

        }
        if (TextBox4.Text.ToString() != "")//公司订单号
        {
            temp += " and a.SMSO_ComOrderNum like '%" + TextBox4.Text.ToString() + "%'";
        }
        if (TextBox5.Text.ToString() != "")//客户订单号
        {
            temp += " and a.SMSO_CusOrderNum like '%" + TextBox5.Text.ToString() + "%'";
        }
        if (TextBox7.Text.ToString() != "")//业务员
        {
            temp += " and a.SMSO_SalesMan like '%" + TextBox7.Text.ToString() + "%'";
        }
        if (TextBox8.Text.ToString() != "")//区域
        {
            temp += " and c.CRMRBI_Name like '%" + TextBox8.Text.ToString() + "%'";
        }
        if (DropDownList4.SelectedValue.ToString() != "选择订单状态")//订单状态
        {
            temp += " and a.SMSO_OrderState like '%" + DropDownList4.SelectedValue.ToString() + "%'";
        }
        if (DropDownList2.SelectedValue.ToString() == "下单日期")//下单日期
        {
            temp += " and a.SMSO_PlaceOrderTime between '" + TextBox1.Text.ToString() + "'and'" + TextBox2.Text.ToString() + "'";
        }
        if (DropDownList5.SelectedValue.ToString() != "选择订单类型")//订单类型
        {
            temp += " and a.SMSO_OrderType like '%" + DropDownList5.SelectedValue.ToString() + "%'";
        }
        temp += " order by SMSO_PlaceOrderTime desc";
        conditon = temp;
        label_condition.Text = conditon;
        return conditon;
        
    }
    protected string GetCondition_Detail()
    {
        string conditon;
        string temp = "";
        if (TextBox6.Text.ToString() != "")//产品型号
        {
            temp += " and b.PT_Name like '%" + TextBox6.Text.ToString() + "%'";

        }
        if (DropDownList3.SelectedValue.ToString() != "选择是否")//特殊产品
        {
            temp += " and a.SMSOD_SpecialProduct like '%" + DropDownList3.SelectedValue.ToString() + "%'";
        }
        if (DropDownList2.SelectedValue.ToString() == "交货期")//交货期
        {
            temp += " and a.SMSOD_OrderDelTime between '" + TextBox1.Text.ToString() + "'and'" + TextBox2.Text.ToString() + "'";
        }
        if (DropDownList2.SelectedValue.ToString() == "预交货期")//预交货期
        {
            temp += " and a.SMSOD_OrderAdvanceDelTime between '" + TextBox1.Text.ToString() + "'and'" + TextBox2.Text.ToString() + "'";
        }
        if (DropDownList5.SelectedValue.ToString() != "选择付款方式")//付款方式
        {
            temp += " and a.SMSOD_PayMethon like '%" + DropDownList5.SelectedValue.ToString() + "%'";
        }
        temp += "order by PS_Name,PT_Name";
        conditon = temp;
        label_condition1.Text = conditon;
        return conditon;
    }
    //重置检索栏
    protected void ClearOrder(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        DropDownList3.SelectedValue = "选择是否";
        DropDownList4.SelectedValue = "选择订单状态";
        DropDownList2.SelectedValue = "选择日期类型";
        TextBox1.Text="";
        TextBox2.Text="";
        DropDownList5.SelectedValue = "选择订单类型";
        DropDownList1.SelectedValue = "选择付款方式";
        UpdatePanel_Search.Update();
    }
    //新建订单
    protected void CreateOrdered(object sender, EventArgs e)
    {
        Panel_NewOrder.Visible = true;
        UpdatePanel_NewOrder.Update();
    }
    #endregion

    #region 订单详细表
    //提交订单详细
    protected void NewOrderDetail(object sender, EventArgs e)
    {
        DataSet ds = ptp.Select_SalesOrderPrice(new Guid(label_OrderID.Text.ToString()));
        DataTable dt = ds.Tables[0];
        int ii =Convert.ToInt32( dt.Rows[0][0].ToString());
        if (ii != 0)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_OrderDetail, GetType(), "alert", "alert('此订单有部分详细还未有单价，无法提交！')", true);
            return;
        }
       int i=so.Update_SalesOrderState_ConfirmNew(new Guid(label_OrderID.Text.ToString()));
      if (i == 1)
      {
          ScriptManager.RegisterClientScriptBlock(UpdatePanel_OrderDetail, GetType(), "alert", "alert('还未建立对应客户的回款开票信息，请建立后重试！')", true);
          return;
      }
      else
      {
          BindSalesOrder();
          ScriptManager.RegisterClientScriptBlock(UpdatePanel_OrderDetail, GetType(), "alert", "alert('提交新增订单详细成功！')", true);
      }
      Panel_OrderDetail.Visible = false;
      UpdatePanel_OrderDetail.Update();
    }
    //关闭订单详细
    protected void CloseOrderDetail(object sender, EventArgs e)
    {
        Panel_OrderDetail.Visible = false;
        UpdatePanel_OrderDetail.Update();
    }
    //新增产品型号
    protected void NewProductType(object sender, EventArgs e)
    {
        //this.Panel_Product.Visible = true;
        Panel2.Visible = true;
        Panel_Product.Visible = true;
        Panel1.Visible = true;
        GridView_ProType.DataSource = mp.Select_ProType("");
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
        UpdatePanel_Product.Update();
    }
    //关闭预交货期修改历史
    protected void CloseHistory(object sender, EventArgs e)
    {
        Panel_AdvanceDel.Visible = false;
        UpdatePanel_AdvanceDel.Update();
    }
    

    #endregion
    #region 新增订单和产品
    //查找客户
    protected void SelectCustom(object sender, EventArgs e)
    {
        Panel_Customer.Visible = true;
        Panel1.Visible = true;
        GridView_Custom.DataSource = so.Select_Custom(GetCondition_Custom());
        GridView_Custom.DataBind();
        UpdatePanel_Customer.Update();
    }
    //客户检索
    protected string GetCondition_Custom()
    {
        string conditon;
        string temp = "";
        if (TextBox12.Text.ToString() != "")//客户名称
        {
            temp += " and a.CRMCIF_Name like '%" + TextBox12.Text.ToString() + "%'";

        }
        if (TextBox14.Text.ToString() != "")//区域
        {
            temp += " and b.CRMRBI_Name like '%" + TextBox14.Text.ToString() + "%'";

        }
        conditon = temp;
        return conditon;
    }
    //检索客户
    protected void SearchCustom(object sender, EventArgs e)
    {
        Panel_Customer.Visible = true;
        GridView_Custom.DataSource = so.Select_Custom(GetCondition_Custom());
        GridView_Custom.DataBind();
        UpdatePanel_Customer.Update();
    }
    //新增客户取消
    protected void CustomNotOK(object sender, EventArgs e)
    {
        Panel_Customer.Visible = false;
        Panel1.Visible = false;
        UpdatePanel_Customer.Update();
    }
    //新增客户确认
    protected void CustomOK(object sender, EventArgs e)
    {
        foreach (GridViewRow item in GridView_Custom.Rows)
        {
            RadioButton cb = item.FindControl("RadioButton1") as RadioButton;
            if (cb.Checked)
            {
                //Guid Custom_ID = new Guid(this.GridView_Custom.DataKeys[item.RowIndex].Value.ToString());
                label_CustomID.Text = GridView_Custom.DataKeys[item.RowIndex].Value.ToString();
                TextBox9.Text = GridView_Custom.Rows[item.RowIndex].Cells[2].Text.ToString();
                UpdatePanel_NewOrder.Update();
            }
        }
        Panel1.Visible = false;
        Panel_Customer.Visible = false;
        UpdatePanel_Customer.Update();
        BindSalesOrder();
    }
    ////查找产品型号
    //protected void SelectProduct(object sender, EventArgs e)
    //{
    //    this.Panel_Product.Visible = true;
    //    this.UpdatePanel_Product.Update();
    //}
    //确认新增订单
    protected void ConfirmNewOrder(object sender, EventArgs e)
    {
        if (DropDownList6.SelectedValue == "选择订单类型")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择订单类型！')", true);
            return;
        }
        string customorder = TextBox10.Text.ToString();
        string salseman = TextBox11.Text.ToString();
        Guid cifID = new Guid(label_CustomID.Text.ToString());
        string type = DropDownList6.SelectedValue.ToString();
        string detailcir = TextBox13.Text.ToString();
        string inputpep = Session["UserName"].ToString();
        so.Insert_SalesOrder(customorder, salseman, cifID, type, detailcir, inputpep);
        ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewOrder, GetType(), "alert", "alert('新建订单成功，请点击编辑填写订单详细内容！')", true);
        BindSalesOrder();
        Panel_NewOrder.Visible = false;
        UpdatePanel_NewOrder.Update();

    }
    //取消新增订单
    protected void CanelNewOrder(object sender, EventArgs e)
    {
        Panel_NewOrder.Visible = false;
        UpdatePanel_NewOrder.Update();
    }
    //全选按钮
    protected void Cbx2_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (Cbx2_SelectAll.Checked)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
        UpdatePanel_Product.Update();
    }
    //产品型号表提交按钮
    protected void ButtonProType_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in GridView_ProType.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                Guid OrderID = new Guid(label_OrderID.Text.ToString());
                Guid PT_ID = new Guid(GridView_ProType.DataKeys[item.RowIndex].Value.ToString());
                so.Insert_SalesOrder(PT_ID, OrderID);
                BindSalesOrderDetail();
                Panel_Product.Visible = false;
                Panel1.Visible = false;
                UpdatePanel_Product.Update();
            }
        }
        Panel_Product.Visible = false;
        Panel2.Visible = false;
        UpdatePanel_Product.Update();
    }
    //产品型号字符串拼接
    protected string GetCondition_ProType()
    {
        string conditon;
        string temp = "";
        if (TextBox_ProductName.Text.ToString() != "")
        {
            temp += " and PT_Name like '%" + TextBox_ProductName.Text.ToString() + "%'";

        }
        if (TextBox_Series.Text.ToString() != "")
        {
            temp += " and Ps_Name like '%" + TextBox_Series.Text.ToString() + "%'";
        }
        conditon = temp;
        return conditon;
    }
    //CheckBox相关
    protected ArrayList SelectedItems
    {
        get
        {
            return (ViewState["mySelectedItems"] != null) ? (ArrayList)ViewState["mySelectedItems"] : null;
        }
        set
        {
            ViewState["mySelectedItems"] = value;
        }
    }
    //从当前页收集选中项的情况
    protected void CollectSelected()
    {
        ArrayList selectedItems = null;
        if (SelectedItems == null)
            selectedItems = new ArrayList();
        else
            selectedItems = SelectedItems;
        //获取选择的记录
        for (int i = 0; i < GridView_ProType.Rows.Count; i++)
        {
            //string id = this.GridView_ProType.Rows[i].Cells[1].Text;
            CheckBox cb = GridView_ProType.Rows[i].FindControl("CheckBox2") as CheckBox;
            string id = GridView_ProType.DataKeys[i].Values[0].ToString();
            if (selectedItems.Contains(id) && !cb.Checked)
                selectedItems.Remove(id);
            if (!selectedItems.Contains(id) && cb.Checked)
                selectedItems.Add(id);
        }
        SelectedItems = selectedItems;
    }
    //检索产品型号
    protected void SelectProType(object sender, EventArgs e)
    {
        GridView_ProType.DataSource = mp.Select_ProType(GetCondition_ProType());
        GridView_ProType.DataBind();
        UpdatePanel_Product.Visible = true;
        UpdatePanel_Product.Update();
    }
    protected void SelectProType1(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    #endregion
    #region gridview各种操作
    //SalesOrder
    protected void GridView_Order_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Order.BottomPagerRow;


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

        BindSalesOrder();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Order.PageCount ? GridView_Order.PageCount - 1 : newPageIndex;
        GridView_Order.PageIndex = newPageIndex;
        GridView_Order.DataBind();

    }
    protected void GridView_Order_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
         GridView_Order.EditIndex = -1;
         BindSalesOrder();
    }
    protected void GridView_Order_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")//bianji
        {
            label_OrderID.Text = e.CommandArgument.ToString();
            label_source.Text = "gridview";
            Panel_OrderDetail.Visible = true;
            Button6.Visible = true;
            GridView_OrderDetail.Columns[17].Visible = true;
            GridView_OrderDetail.Columns[16].Visible = true;
            BindSalesOrderDetail();
        }//好像没这个了。用command去了
        if (e.CommandName == "Look1")//chakan
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label_OrderID.Text = e.CommandArgument.ToString();
            label_source.Text = "gridview";
            Panel_OrderDetail.Visible = true;
         string state=  GridView_Order.Rows[gvr.RowIndex].Cells[7].Text;
         if (state != "已新建"||(Request.QueryString["status"] != "SalesOrderEdit"))
         {
             Button15.Visible = false;
             Button6.Visible = false;

         }
         else

         {
             Button15.Visible = true;
             Button6.Visible = true;
         }
            GridView_OrderDetail.Columns[17].Visible = true;
            GridView_OrderDetail.Columns[16].Visible = true;
            BindSalesOrderDetail();

        }
        if (e.CommandName == "Delete1")//shanchu
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string state = GridView_Order.Rows[gvr.RowIndex].Cells[7].Text;
            if (state != "已新建")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('此状态下不可以删除！')", true);
                return;
            }
            else
            {
                so.Delete_SalseOrder(new Guid(e.CommandArgument.ToString()));
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
                BindSalesOrder();
            }

        }
    }
    protected void GridView_Order_RowEditing(object sender, GridViewEditEventArgs e)
    {   
        GridView_Order.EditIndex = e.NewEditIndex;
        BindSalesOrder();
    }
    protected void GridView_Order_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid orderid = new Guid(GridView_Order.DataKeys[e.RowIndex].Value.ToString());
        //string titleName = ((TextBox)(this.GridView_Order.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
        string cusordernum = Convert.ToString(((TextBox)(GridView_Order.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
        string comment = Convert.ToString(((TextBox)(GridView_Order.Rows[e.RowIndex].Cells[12].Controls[0])).Text.Trim().ToString());
        string type = Convert.ToString(((DropDownList)(GridView_Order.Rows[e.RowIndex].Cells[6].Controls[1])).SelectedValue);
        if (type == "选择订单类型")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Order, GetType(), "alert", "alert('必须选择订单类型！')", true);
            return;
        }
        GridView_Order.EditIndex = -1;
        //this.GridView_Order.DataSource = so.Select_SalesOrder(this.label_condition.Text.ToString());
        //this.GridView_Order.DataBind();
        so.Update_SalesOrder(orderid, cusordernum, comment, type);
        GridView_Order.DataSource = so.Select_SalesOrder(label_condition.Text.ToString());
        GridView_Order.DataBind();
        UpdatePanel_Order.Update();
    }//必须写在IFPostback里面，要不页面保存不了！！！
    protected void GridView_Order_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Order.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Order.Rows[i].Cells.Count; j++)
            {
                GridView_Order.Rows[i].Cells[j].ToolTip = GridView_Order.Rows[i].Cells[j].Text;
                if (GridView_Order.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Order.Rows[i].Cells[j].Text = GridView_Order.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }  
    }
    protected void GridView_Order_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //这里注意Row的RowState属性的枚举 
        //if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        //{
            //DropDownList dd = (DropDownList)e.Row.FindControl("DropDownList15");
            //if (e.Row.Cells[7].Text != "")
            //{
            //    dd.SelectedValue = e.Row.Cells[7].Text.ToString();
            //}
            //string[] colorArray = Enum.GetNames(typeof(System.Drawing.KnownColor));
            //foreach (string color in colorArray)
            //{
            //    ListItem item = new ListItem(color, color);
            //    item.Attributes.Add("style", "background-color:" + color);
            //    dd.Items.Add(item);
            //}

        //} 
    }
    //SalesOrderDetail
    protected void GridView_OrderDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_OrderDetail.BottomPagerRow;


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

        BindSalesOrderDetail();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_OrderDetail.PageCount ? GridView_OrderDetail.PageCount - 1 : newPageIndex;
        GridView_OrderDetail.PageIndex = newPageIndex;
        GridView_OrderDetail.DataBind();
    }
    protected void GridView_OrderDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_OrderDetail.EditIndex = -1;
        BindSalesOrderDetail();
    }
    protected void GridView_OrderDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete2")//shanchu
        {
           so.Delete_SalseOrderDetail(new Guid(e.CommandArgument.ToString()));
           BindSalesOrderDetail();
        }
        if (e.CommandName == "History")//查看修改历史
        {
            Panel_AdvanceDel.Visible = true;
            label_History.Text = e.CommandArgument.ToString();
            GridView_AdvanceDel.DataSource = so.Select_DelChangeHistory(new Guid(e.CommandArgument.ToString()));
            GridView_AdvanceDel.DataBind();
            UpdatePanel_AdvanceDel.Update();
            
        }
        if (e.CommandName == "Over1")
        {
            Guid id = new Guid(e.CommandArgument.ToString());
            string man = Session["UserName"].ToString();
            ptp.Update_Order_ADel(id, man);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('订单完结成功！')", true);
            BindSalesOrderDetail();

            
        }
        if (e.CommandName == "OutM")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Panel_OutD.Visible = true;
            label21.Text = GridView_OrderDetail.Rows[gvr.RowIndex].Cells[1].Text.ToString() + GridView_OrderDetail.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            label26.Text = e.CommandArgument.ToString();
            Gridview_OutD.DataSource = outm.Select_IMOuthouseDetail(" and a.SMSOD_ID like'%"+e.CommandArgument.ToString()+"%'");
            Gridview_OutD.DataBind();
            UpdatePanel_OutD.Update();

                //UpdatePanel_OutD.Update();
        }
    }
    protected void GridView_OrderDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
                  GridView_OrderDetail.EditIndex = e.NewEditIndex;
                  BindSalesOrderDetail();
    }
    protected void GridView_OrderDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       
        int time = 0;
        Guid detailID = new Guid(GridView_OrderDetail.DataKeys[e.RowIndex]["SMSOD_ID"].ToString());
        if (((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[3].Controls[1])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_OrderDetail, GetType(), "alert", "alert('必须填写订单数量！')", true);
            return;

        }
        if (((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[11].Controls[1])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_OrderDetail, GetType(), "alert", "alert('必须填写预交货期！')", true);
            return;
            
        }
        if (((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[10].Controls[1])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_OrderDetail, GetType(), "alert", "alert('必须填写交货期！')", true);
            return;

        }
        if (((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[13].Controls[0])).Text.Trim().ToString() == "")
        {
            time = 0;
        }
        else 
        {
            time = Convert.ToInt32(((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[13].Controls[0])).Text.Trim().ToString());
        }
        int mount =Convert.ToInt32( Convert.ToDecimal(((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[3].Controls[1])).Text.Trim().ToString()));
        DateTime adtime = Convert.ToDateTime(((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[11].Controls[1])).Text.Trim().ToString());
        DateTime deltime = Convert.ToDateTime(((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[10].Controls[1])).Text.Trim().ToString());
        string batch = Convert.ToString(((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[17].Controls[0])).Text.Trim().ToString());
        string pro = Convert.ToString(((TextBox)(GridView_OrderDetail.Rows[e.RowIndex].Cells[18].Controls[0])).Text.Trim().ToString());
        string method = Convert.ToString(((DropDownList)(GridView_OrderDetail.Rows[e.RowIndex].Cells[8].Controls[1])).SelectedValue);
        string special = Convert.ToString(((DropDownList)(GridView_OrderDetail.Rows[e.RowIndex].Cells[9].Controls[1])).SelectedValue);
        DateTime aaa = Convert.ToDateTime(GridView_OrderDetail.DataKeys[e.RowIndex]["SMSOD_OrderAdvanceDelTime"].ToString());
        //DateTime aa = Convert.ToDateTime(this.GridView_OrderDetail.Rows[e.RowIndex].Cells[21].Text.Trim().ToString());
        //判断是否需要插入修改历史
        if (adtime!=aaa)
        {
            string man = Session["UserName"].ToString();
            DateTime changetime = DateTime.Now;
            so.Insert_SMDelTimeChangeHistory(detailID, adtime, man, changetime);
            //this.GridView_AdvanceDel.DataSource = so.Select_DelChangeHistory(new Guid(this.label_History.Text.ToString()));
            //this.GridView_AdvanceDel.DataBind();
            //this.UpdatePanel_AdvanceDel.Update();

        }
        so.Update_SalesOrderDetail(detailID, adtime, time, batch, pro, special, method, deltime,mount);
        GridView_OrderDetail.EditIndex = -1;
        //有个绑定……，没有用处
        BindSalesOrderDetail();
    }
    protected void GridView_OrderDetail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_OrderDetail.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_OrderDetail.Rows[i].Cells.Count; j++)
            {
                GridView_OrderDetail.Rows[i].Cells[j].ToolTip = GridView_OrderDetail.Rows[i].Cells[j].Text;
                if (GridView_OrderDetail.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_OrderDetail.Rows[i].Cells[j].Text = GridView_OrderDetail.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }  
    }
    //Custom
    protected void GridView_Custom_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Custom.BottomPagerRow;


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

        GridView_Custom.DataSource = so.Select_Custom(GetCondition_Custom());
        GridView_Custom.DataBind();
        UpdatePanel_Customer.Update();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Custom.PageCount ? GridView_Custom.PageCount - 1 : newPageIndex;
        GridView_Custom.PageIndex = newPageIndex;
        GridView_Custom.DataBind();
    }

    //Protype
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

        GridView_ProType.DataSource = mp.Select_ProType(GetCondition_ProType());
        CollectSelected();
        GridView_ProType.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        //RemeberOldValues();
        GridView_ProType.PageIndex = newPageIndex;
        GridView_ProType.DataBind();
        //RePopulateValues();


    }
    protected void GridView_ProType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //这里的处理是为了回显之前选中的情况
        if (e.Row.RowIndex > -1 && SelectedItems != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("CheckBox2") as CheckBox;
            string id = GridView_ProType.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }

    //History
    protected void GridView_AdvanceDel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_AdvanceDel.BottomPagerRow;


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

        GridView_AdvanceDel.DataSource = so.Select_DelChangeHistory(new Guid(label_History.Text.ToString()));
        GridView_AdvanceDel.DataBind();
        UpdatePanel_AdvanceDel.Update();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_AdvanceDel.PageCount ? GridView_AdvanceDel.PageCount - 1 : newPageIndex;
        GridView_AdvanceDel.PageIndex = newPageIndex;
        GridView_AdvanceDel.DataBind();
    }
    #endregion

    protected void Gridview_OutD_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_OutD.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_OutD.Rows[i].Cells.Count; j++)
            {
                Gridview_OutD.Rows[i].Cells[j].ToolTip = Gridview_OutD.Rows[i].Cells[j].Text;
                if (Gridview_OutD.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_OutD.Rows[i].Cells[j].Text = Gridview_OutD.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }





    protected void CloseOutD(object sender, EventArgs e)
    {
        Panel_OutD.Visible = false;
        UpdatePanel_OutD.Update();
    }
}
