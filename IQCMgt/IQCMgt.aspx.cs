using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class IQCMgt_IQCMgt : Page
{
    IQCBasicDataD iQCBasicDataL = new IQCBasicDataD();
    WorkOrderInfo woinfo = new WorkOrderInfo();
    WorkOrderL wol = new WorkOrderL();
    IQCBasicDataInfo iQCBasicDataInfo = new IQCBasicDataInfo();
    ProductionProcessD ppd = new ProductionProcessD();
    ProTypePrice ppd1 = new ProTypePrice();
    WorkOrderCheckL wcl = new WorkOrderCheckL();
    ErrorRelevantL erl = new ErrorRelevantL();
    //private static string cond1 = "",PS="",PT="";
    static Guid id2 = new Guid();//id2存储入库明细表id用于新增认证信息
    static Guid idT = new Guid();//idT存储入库明细表id用于新增检验单时查询信息
    static Guid id_IMISD = new Guid();//存储入库明细id用于新增
    static Guid id_IMMBD_MaterialID = new Guid();//存储物料id用于新增
    static Guid id_IQCIT_ID = new Guid();//存储项目行命令关联id
    #region 页面加载
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        string cond1 = cond1l.Text;
        if (!Page.IsPostBack)
        {
            BindGrid1(cond1);
            //if (!(Session["UserRole"].ToString().Contains("进料检验维护")))
            //{
            //    Response.Redirect("~/Default.aspx");
            //}
        
        }
        Title = "待检物料检验";
    }
    #endregion

    #region 物料检索栏
    //检索栏检索按钮
    protected void BtnSearchMaterial_Click(object sender, EventArgs e)
    {
        
        string cond1="";
        if (TextBox1.Text!="")
        {
            cond1 = cond1 + " AND IMISD_BatchNum like '%" + TextBox1.Text.ToString().Trim() + "%' ";
        }
        if (TxtMaterialName.Text != "")
        {
            cond1 = cond1 + " AND IMMBD_MaterialName like '%' + LTRIM(RTRIM('" + TxtMaterialName.Text + "')) + '%' ";
        }
        if (TxtMaterialCode.Text != "")
        {
            cond1 = cond1 + " AND IMMBD_SpecificationModel like '%' + LTRIM(RTRIM('" + TxtMaterialCode.Text + "')) + '%' ";
        }
        if (TxtSupplyName.Text != "")
        {
            cond1 = cond1 + " AND PMSI_SupplyName like '%' + LTRIM(RTRIM('" + TxtSupplyName.Text + "')) + '%' ";
        }
        if (TxtArriveTime1.Text == "" && TxtArriveTime2.Text != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择时间范围！')", true);
            return;
        }
        else if (TxtArriveTime1.Text != "" && TxtArriveTime2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择时间范围！')", true);
            return;
        }
        else if (TxtArriveTime1.Text != "" && TxtArriveTime2.Text != "")
        {
            cond1 = cond1 + " AND IMISM_InStoreTime BETWEEN '" + TxtArriveTime1.Text + "' AND '" + TxtArriveTime2.Text + "' ";
        }
        cond1l.Text = cond1;
        BindGrid1(cond1);
        UpdatePanel_GridMaterial.Update();
    }

    //重置
    protected void BtnResetMaterial_Click(object sender, EventArgs e)
    {
        TxtMaterialName.Text = "";
        TxtMaterialCode.Text = "";
        TxtSupplyName.Text = "";
        TxtArriveTime1.Text = "";
        TxtArriveTime2.Text = "";
      string   cond1 = "";
        BindGrid1(cond1);
        UpdatePanel_SearchMaterial.Update();
        UpdatePanel_GridMaterial.Update();
    }

    #endregion

    #region 物料表Grid1
    //操作Gridview的命令行
    protected void Grid_Material_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "New_CertMessage")
        {
            Label28.Text = e.CommandArgument.ToString();
            
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Label29.Text = "入库单号：" + Grid_Material.Rows[gvr.RowIndex].Cells[2].Text.ToString().Trim() + "  检验物料：" + Grid_Material.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim() + Grid_Material.Rows[gvr.RowIndex].Cells[6].Text.ToString().Trim() + "  批号：" + Grid_Material.Rows[gvr.RowIndex].Cells[7].Text.ToString().Trim() + "  供货单位：" + Grid_Material.Rows[gvr.RowIndex].Cells[8].Text.ToString().Trim() + "  于" + Grid_Material.Rows[gvr.RowIndex].Cells[11].Text.ToString().Trim() + "入库，共" + Grid_Material.Rows[gvr.RowIndex].Cells[9].Text.ToString().Trim() + Grid_Material.Rows[gvr.RowIndex].Cells[10].Text.ToString().Trim();
            id2 = new Guid(e.CommandArgument.ToString());
            Panel_AddWorkOrder.Visible = true;
            TextBox_AddPT.Text = "";
            TextBox_Add_PNum.Text = "";
            //TextBox_Add_ChipNum.Text = "";
            TextBox_AddNote.Text = "";
            UpdatePanel_AddWorkOrder.Update();
        }
        if (e.CommandName == "View_CertDetail")
        {
            //string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            //Response.Redirect("../ProductionProcess/WorkOrderCheck.aspx?WO_Type=检验");
            //Response.Write("<script>window.open(\''../ProductionProcess/WorkOrderCheck.aspx?IMISD_ID=" + al[0] + "\'')</script>");
            //Response.Write("<script>window.open(\''../ProductionProcess/WorkOrderCheck.aspx?IMISD_ID="+al[0]+"\'',\''_blank\'')</script>");
            label_GridPageState.Text = e.CommandArgument.ToString();
            Panel_WOmain.Visible = true;
            databind_main();
        }
        if (e.CommandName == "New_Test")
        {
          
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            Panel_NewExpApp.Visible =true;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string cond = " and IMISD_ID='"+al[0]+"'";
            Label31.Text =Convert.ToString( Guid.NewGuid());
            Label32.Text = al[0];
            Label33.Text = al[2];
            UpdatePanel_NewExpApp.Update();
          
            id_IMISD = new Guid(al[0]);
            id_IMMBD_MaterialID = new Guid(al[2]);
            LblExpApp.Text = "新增 "+al[1]+" 检验单";
            try
            {
                Guid id1 = new Guid(al[0]);
                Guid id2 = new Guid(al[2]);
                iQCBasicDataL.Insert_IQCDetailTable(id1, id2);
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('检验单新增失败！')", true);
                return;
            }
            string cond1 = " and DT.IMISD_ID='" + al[0] + "' and DT.IQCDT_Result='待审核' "; 
            //IQCBasicDataInfo IQC1 = iQCBasicDataL.Search_IMInStoreDetail_ViewAu(cond1)[0];
            DataSet ds = iQCBasicDataL.Search_IMInStoreDetail_Au(cond1);
            DataTable dt = ds.Tables[0];
            if ( dt.Rows.Count!= 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该物料检验单正在审核，不能继续检验！')", true);
                return; 
            }
            IQCBasicDataInfo IQC = iQCBasicDataL.Search_IMInStoreDetail_New(cond)[0];
            TxtNewMaterialType.Text = IQC.IMMT_MaterialType;
            TxtNewMaterialName.Text = IQC.IMMBD_MaterialName;
            TxtNewMode.Text = IQC.IMMBD_SpecificationModel;
            TxtNewMaterialCode.Text = IQC.IMMBD_MaterialCode;
            TxtNewSupplyName.Text = IQC.PMSI_SupplyName;
            TxtActualNum.Text =Convert.ToString( IQC.IMIDS_ActualArrNum);
            TxtNewUnit.Text = IQC.UnitName;
            TxtNewArrivalTime.Text =Convert.ToString( IQC.IMISM_InStoreTime);
            Grid_ETTestItem.DataSource = iQCBasicDataL.Search_IQCItemsTable(IQC.IMMBD_MaterialID);
            Grid_ETTestItem.DataBind();
            Guid id = new Guid(Label32.Text.ToString());
            GridView2.DataSource = iQCBasicDataL.Search_WorkOrder(id);
            GridView2.DataBind();
            //GridView2.Visible = true;
            //BindQAItem();
            UpdatePanel_NewExpApp.Update();
        }
    }

    //悬浮框显示
    protected void Grid_Material_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Material.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Material.Rows[i].Cells.Count; j++)
            {
                Grid_Material.Rows[i].Cells[j].ToolTip = Grid_Material.Rows[i].Cells[j].Text;
                if (Grid_Material.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Material.Rows[i].Cells[j].Text = Grid_Material.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_Material_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Material.BottomPagerRow;


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
        BindGrid1(cond1l.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Material.PageCount ? Grid_Material.PageCount - 1 : newPageIndex;
        Grid_Material.PageIndex = newPageIndex;
        Grid_Material.DataBind();
    }
    #endregion

    #region 新增认证信息栏

    protected void Btn_Submit_Add_Click(object sender, EventArgs e)//新增随工单按钮
    {
        if (TextBox_AddPT.Text.Trim() == "" || TextBox_Add_PNum.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请核对必填项*！')", true);
            return;
        }
        if (Label_PS.Text.Contains("SMSC"))
        {

            if (TextBox_Add_SN.Text.Trim() == "" || TextBox_Add_Order.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('SMSC随工单必须填写周期码和订单号，请再次核对！')", true);
                return;

            }
        }
        try
        {

            if (Label_AddOrderNum.Text.Trim() == "")
            {
                Label_AddOrderNum.Text = "00000000-0000-0000-0000-000000000000";
            }
            Guid InID = new Guid(Label28.Text.ToString());
            woinfo.SMSO_ID = new Guid(Label_AddOrderNum.Text.Trim());
           
            woinfo.WO_People = Session["UserName"].ToString();
            woinfo.WO_PNum = Convert.ToInt32(TextBox_Add_PNum.Text.Trim());
            woinfo.WO_ProType = TextBox_AddPT.Text.Trim();
            woinfo.WO_Type = DropDownList_Add_WO_Type.SelectedItem.Text.Trim();
            woinfo.WO_OrderNum = TextBox_Add_Order.Text.Trim();
            woinfo.WO_Note = Label29.Text.ToString().Trim() + TextBox_AddNote.Text.Trim(); ;
            int fd = Convert.ToInt32(DropDownList4.SelectedValue.ToString());
            string printcode = DropDownList5.SelectedValue.ToString().Trim() + DropDownList6.SelectedValue.ToString().Trim();
            if (Label_PS.Text.Contains("SMSC"))
            {
                ppd1.I_WorkOrder_NEW(woinfo, DropDownList1.SelectedValue.ToString().Trim(), DropDownList_Add_WO_Type.SelectedValue.ToString().Trim(), new Guid(Label_PTID.Text.Trim()), printcode, DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(), fd, Label_PTCodeMeaning.Text.Trim(), Label_ChipType.Text.Trim(), TextBox_Add_SN.Text.Trim(), 1,InID);
            }
            else
            {
                ppd1.I_WorkOrder_NEW(woinfo, DropDownList1.SelectedValue.ToString().Trim(), DropDownList_Add_WO_Type.SelectedValue.ToString().Trim(), new Guid(Label_PTID.Text.Trim()), printcode, DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(), fd, Label_PTCodeMeaning.Text.Trim(), Label_ChipType.Text.Trim(), TextBox_Add_SN.Text.Trim(), 0,InID);

            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('随工单新增成功！')", true);
            //string condition = " and 1=1";
            //this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
            //this.GridView_WOmain.DataBind();
            //this.UpdatePanel_WOmain.Update();
            Panel_AddWorkOrder.Visible = false;
            UpdatePanel_AddWorkOrder.Update();
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('随工单新增失败！')", true);
            return;
        }

    }
    protected void Btn_SelectOrder_Click(object sender, EventArgs e)//新增随工单时，选择订单号
    {
       
        Panel_Product_Search.Visible = false;
        Panel_SelectOrder.Visible = true;

        string condition;
        string ComOrderNum = TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        GridView_Order.DataBind();

     
        UpdatePanel_Product.Update();
        UpdatePanel_SelectOrder.Update();

    }
    protected void Button_CancelAdd_Click(object sender, EventArgs e)
    {
        Panel_AddWorkOrder.Visible = false;
        UpdatePanel_AddWorkOrder.Update();
        Panel_Product_Search.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void GridView_Order_PageIndexChanging(object sender, GridViewPageEventArgs e)//订单号表翻页
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
    protected void GridView_Order_RowCommand(object sender, GridViewCommandEventArgs e)//订单号表链接按钮事件
    {
        if (e.CommandName == "Select_Order")//选择订单号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Order.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_AddOrderNum.Text = al[0];
            TextBox_Add_Order.Text = al[1];//客户订单号
            Label_OT.Text = al[3];
            UpdatePanel_AddWorkOrder.Update();
            Panel_SelectOrder.Visible = false;
            UpdatePanel_SelectOrder.Update();

        }
    }
    protected void GridView_Order_RowDataBound(object sender, GridViewRowEventArgs e)//订单号表行绑定
    {

    }
    //选择产品型号
    protected void Btn_SelectPT_Click(object sender, EventArgs e)
    {
        Panel_Product_Search.Visible = true;
       
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        GridView_ProType.DataSource = iQCBasicDataL.Search_ProType_RZ("", "");
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    protected void Button_SearchOrder_Click(object sender, EventArgs e)//检索订单号
    {
        string condition;
        string ComOrderNum = TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        GridView_Order.DataBind();
        UpdatePanel_SelectOrder.Update();
    }
    protected void Btn_Close_SearchOrder_Click(object sender, EventArgs e)//关闭检索订单页面
    {
        TextBox_ComOrderNum.Text = "";
        TextBox_CustOrder.Text = "";
        Panel_SelectOrder.Visible = false;
        UpdatePanel_SelectOrder.Update();
    }
    

    //检索栏检索按钮
    protected void SelectProType(object sender, EventArgs e)
    {
            string PS = TextBox_Series.Text;
           string  PT = TextBox_ProductName.Text;
            GridView_ProType.DataSource = iQCBasicDataL.Search_ProType_RZ(PS, PT);
            GridView_ProType.DataBind();
            UpdatePanel_Product.Update();
       
    }

    //检索栏重置
    protected void Reset1(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        PSl.Text = "";
        PTl.Text = "";
        GridView_ProType.DataSource = iQCBasicDataL.Search_ProType_RZ(PSl.Text, PTl.Text);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }

    //关闭
    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        Panel_Product_Search.Visible = false;
        UpdatePanel_Product.Update();
    }

    //操作Gridview的命令行
    protected void GridView_ProType_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "SelectPT")//选择产品型号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_ProType.SelectedIndex = row.RowIndex;
            Label_PS.Text = GridView_ProType.Rows[row.RowIndex].Cells[1].Text.ToString();
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ptname = al[1];
            Label_PTID.Text = al[0];
            TextBox_AddPT.Text = ptname;
            UpdatePanel_AddWorkOrder.Update();
            Panel_Product_Search.Visible = false;
            UpdatePanel_Product.Update();

        }

    }

    //悬浮框显示
    protected void GridView_ProType_RowDataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_ProType.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_ProType.Rows[i].Cells.Count; j++)
            {
                GridView_ProType.Rows[i].Cells[j].ToolTip = GridView_ProType.Rows[i].Cells[j].Text;
                if (GridView_ProType.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_ProType.Rows[i].Cells[j].Text = GridView_ProType.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

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
        {
            newPageIndex = e.NewPageIndex;
        }
        GridView_ProType.DataSource = iQCBasicDataL.Search_ProType_RZ(PSl.Text, PTl.Text);
        GridView_ProType.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;
        GridView_ProType.DataBind();
    }
    #endregion

    #region 检验结果录入栏
    //检验合格按钮
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        IQCBasicDataInfo IQC = new IQCBasicDataInfo();
        IQC.IMISD_ID = id_IMISD;
        IQC.IMMBD_MaterialID = id_IMMBD_MaterialID;
        IQC.IMIDS_QA = "合格";
        IQC.IQCDT_Result = "合格";
        if (TxtNewNum.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else
        {
            int  m1;
            if (int.TryParse(TxtNewNum.Text.Trim(), out m1))
                IQC.IQCDT_Input = m1;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('投入数请输入整数！')", true);
                return;
            }
        }
        IQC.IQCDT_TestPer = Session["UserName"].ToString();
        IQC.IQCDT_Description = TxtNewNote.Text.Trim();
        string op = TextBox2.Text;
        IQC.State = "1";
        try
        {
            if (iQCBasicDataL.Update_IMInStoreDetail_IQC(IQC,op) <= 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请确认每项检验均已完成！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('录入成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('录入失败！')", true);
            return;
        }
        TxtNewNum.Text = "";
        TxtNewNote.Text = "";
        Panel_Standard.Visible = false;
        UpdatePanel_Standard.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
    }

    //待审核按钮
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        IQCBasicDataInfo IQC = new IQCBasicDataInfo();
        IQC.IMISD_ID = id_IMISD;
        IQC.IMMBD_MaterialID = id_IMMBD_MaterialID;
        IQC.IMIDS_QA = "";
        IQC.IQCDT_Result = "待审核";
        string op = TextBox2.Text;
        if (TxtNewNum.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else
        {
            int m1;
            if (int.TryParse(TxtNewNum.Text.Trim(), out m1))
                IQC.IQCDT_Input = m1;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('投入数请输入整数！')", true);
                return;
            }
        }
        IQC.IQCDT_TestPer = Session["UserName"].ToString();
        IQC.IQCDT_Description = TxtNewNote.Text.Trim();
        IQC.State = "0";
        try
        {
            if (iQCBasicDataL.Update_IMInStoreDetail_IQC(IQC,op) <= 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('有检验项目没有录入结果！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('录入成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('有检验项目没有录入结果！')", true);
            return;
        }
        TxtNewNum.Text = "";
        TxtNewNote.Text = "";
        Panel_Standard.Visible = false;
        UpdatePanel_Standard.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
    }


    //取消按钮
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        TxtNewNum.Text = "";
        TxtNewNote.Text = "";
        Panel_Standard.Visible = false;
        UpdatePanel_Standard.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
    }

    #region 检验项目表Grid
    //操作Gridview的命令行
    protected void Grid_ETTestItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edit_ItemAmount")
        {
            Panel_Standard.Visible = true;
            id_IQCIT_ID=new Guid(e.CommandArgument.ToString());
            Grid_Standard.DataSource = iQCBasicDataL.Search_IQCStandardTable_Grid(id_IQCIT_ID,id_IMISD);
            Grid_Standard.DataBind();
            UpdatePanel_Standard.Update();
        }
    }

    //悬浮框显示
    protected void Grid_ETTestItem_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ETTestItem.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_ETTestItem.Rows[i].Cells.Count; j++)
            {
                Grid_ETTestItem.Rows[i].Cells[j].ToolTip = Grid_ETTestItem.Rows[i].Cells[j].Text;
                if (Grid_ETTestItem.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_ETTestItem.Rows[i].Cells[j].Text = Grid_ETTestItem.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_ETTestItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ETTestItem.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ETTestItem.PageCount ? Grid_ETTestItem.PageCount - 1 : newPageIndex;
        Grid_ETTestItem.PageIndex = newPageIndex;
        Grid_ETTestItem.DataBind();
    }
    #endregion

    #endregion

    #region 检验标准栏
    //编辑
    protected void Grid_Standard_Editing(object sender, GridViewEditEventArgs e)
    {
        Grid_Standard.EditIndex = e.NewEditIndex;
        Grid_Standard.DataSource = iQCBasicDataL.Search_IQCStandardTable_Grid(id_IQCIT_ID, id_IMISD);
        Grid_Standard.DataBind();
        UpdatePanel_Standard.Update();
    }

    //更新
    protected void Grid_Standard_Updating(object sender, GridViewUpdateEventArgs e)
    {
        //string iid = Grid_Standard.DataKeys[e.RowIndex].Value.ToString();
        Guid id = new Guid(Grid_Standard.DataKeys[e.RowIndex].Value.ToString());//iqct
        Guid id1 = new Guid(Label31.Text.ToString());
        Guid inid = new Guid(Label32.Text.ToString());
        //Guid id = new Guid();
            string QCSV_Value = ((TextBox)(Grid_Standard.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString();
            string QCSV_Result = ((TextBox)(Grid_Standard.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString();
            try
            {
                iQCBasicDataL.Insert_IQCStandardValue(id1, QCSV_Value, QCSV_Result,id);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('录入失败！')", true);
                return;
            }
            Grid_Standard.SelectedIndex = -1;
            Grid_Standard.EditIndex = -1;
            Grid_Standard.DataSource = iQCBasicDataL.Search_IQCStandardTable_Grid(id_IQCIT_ID, id_IMISD);
            Grid_Standard.DataBind();
            UpdatePanel_Standard.Update();

    }

    //取消
    protected void Grid_Standard_CancelingEdit(object sender, GridViewCancelEditEventArgs e)//取消编辑
    {
        Grid_Standard.SelectedIndex = -1;
        Grid_Standard.EditIndex = -1;
        Grid_Standard.DataSource = iQCBasicDataL.Search_IQCStandardTable_Grid(id_IQCIT_ID, id_IMISD);
        Grid_Standard.DataBind();
        UpdatePanel_Standard.Update();
    }

    //输入控制
    protected void Grid_Standard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            ((TextBox)e.Row.Cells[3].Controls[0]).Attributes.Add("MaxLength", "50");
            ((TextBox)e.Row.Cells[4].Controls[0]).Attributes.Add("MaxLength", "5");
        }
    }

    //悬浮框显示
    protected void Grid_Standard_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Standard.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Standard.Rows[i].Cells.Count; j++)
            {
                Grid_Standard.Rows[i].Cells[j].ToolTip = Grid_Standard.Rows[i].Cells[j].Text;
                if (Grid_Standard.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Standard.Rows[i].Cells[j].Text = Grid_Standard.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }

    }


    //翻页
    protected void Grid_Standard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Standard.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Standard.PageCount ? Grid_Standard.PageCount - 1 : newPageIndex;
        Grid_Standard.PageIndex = newPageIndex;
        Grid_Standard.DataBind();
    }

    //关闭按钮
    protected void Btn_Close_Click(object sender, EventArgs e)
    {
        Panel_Standard.Visible = false;
        UpdatePanel_Standard.Update();
    }
    #endregion

    #region 私有调用函数
    //绑定认证产品型号Gridview1
    private void BindGrid1(string Condition)
    {

        Grid_Material.DataSource = iQCBasicDataL.Search_IMInStoreDetail_IQC(Condition);
        Grid_Material.DataBind();
    }
    #endregion
    //提交
    protected void BtnTijiao_Click(object sender, EventArgs e)
    {
        IQCBasicDataInfo IQC = new IQCBasicDataInfo();
        IQC.IMISD_ID = id_IMISD;
        IQC.IMMBD_MaterialID = id_IMMBD_MaterialID;
        IQC.IMIDS_QA = "";
        IQC.IQCDT_Result = "待审核";
        if (TxtNewNum.Text == "" || Ddl_AuRe.SelectedValue=="请选择")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;

        }
        else
        {
            if (TxtActualNum.Text != "" && TxtNewNum.Text!="")
            {
                decimal come = Convert.ToDecimal(TxtActualNum.Text.ToString());
                decimal chou = Convert.ToDecimal(TxtNewNum.Text.ToString());
                if (chou > come)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('抽检数量大于到货数量，此操作违法，请注意单位！')", true);
                    return;
                }
            }
        }
        //else
        //{
        //    int m1;
        //    if (int.TryParse(TxtNewNum.Text.Trim(), out m1))
        //        IQC.IQCDT_Input = m1;
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('投入数请输入整数！')", true);
        //        return;
        //    }
        //}
        IQC.IQCDT_Input = Convert.ToDecimal(TxtNewNum.Text.ToString());
        IQC.IQCDT_TestPer = Session["UserName"].ToString();
        IQC.IQCDT_Description = TxtNewNote.Text.Trim();
        IQC.State = Ddl_AuRe.SelectedValue.ToString();
         Guid id =new Guid( Label31.Text);
         Guid inID = new Guid(Label32.Text.ToString());
         Guid immaterialID = new Guid(Label33.Text);
         string op = TextBox2.Text;
        try
        {
            if (iQCBasicDataL.Update_IMInStoreDetail_IQC(IQC,op) <= 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('有检验项目没有录入结果！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('录入成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('有检验项目没有录入结果！')", true);
            return;
        }
       
        TxtNewNum.Text = "";
        TxtNewNote.Text = "";
        Panel_Standard.Visible = false;
        UpdatePanel_Standard.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了新的入库检验单，请及时进行审核！";
        string sErr = RTXhelper.Send(remind, "进料检验审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    #region 随工单查看
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
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
           
        }

    }
  
    protected void Button_Cancel0_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
     
    }
    protected void Button_Cancel10_Click(object sender, EventArgs e)
    {
        Panel_WOmain.Visible = false;
        UpdatePanel_WOmain.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();

    }
    public void databind_detail()
    {
        GridView1.DataSource = ppd.S_WODetail_Check(new Guid(label_WO_ID.Text.Trim()));
        GridView1.DataBind();
        UpdatePanel1.Update();

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
    protected void databind_main()
    {
        string condition=" and IMISD_ID like '%"+ label_GridPageState.Text.ToString().Trim()+"%'";
        GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();
    }
    #endregion
    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}
    //protected void Excel1(object sender, EventArgs e)
    //{
    //    ExcelHelper.GridViewToExcel(GridView_ProType); 
    //}
    protected void BindWorkOrder()
    {
        GridView2.DataSource = iQCBasicDataL.Search_WorkOrder(new Guid(Label32.Text.ToString()));
        GridView2.DataBind();
        UpdatePanel_NewExpApp.Update();
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    //获取要在gridview中显示的字段的sql
    //public string getListSql(string tbName)
    //{
    //    string sqlStr = "";
    //    string temp = "";
    //    DataSet ds = common.RunQuery("select * from tb_listfield where cname='" + tbName + "' order by cindex");
    //    if (ds.Tables.Count > 0)
    //    {
    //        foreach (DataRow row in ds.Tables[0].Rows)
    //        {
    //            temp += row["cfield"].ToString() + ",";
    //        }
    //    }
    //    if (temp != "")
    //    {
    //        temp = temp.Substring(0, temp.Length - 1);//去掉最后一个逗号
    //        sqlStr = "select " + temp + " from " + tbName;
    //    }
    //    return sqlStr;
    //}
    //public void setBind(string sql, string tbName)
    //{

    //    DataTable dt = getDataTable(sql); //获得数据源
    //    string headerText = "";
    //    var gv = e.Row.Cells[11].FindControl("gridviewc") as GridView;
    //    gvshow.DataSource = dt;//设置数据源
    //    //遍历数据源所有的列，并绑定到gridview
    //    for (int i = 0; i < dt.Columns.Count; i++)
    //    {
    //        BoundField bc = new BoundField();
    //        bc.DataField = dt.Columns[i].ColumnName.ToString();

    //        headerText = dt.Columns[i].Caption.ToString();
    //        //替换表头文字
    //        DataSet hDs = common.RunQuery("select top 1 * from tb_listfield where cname='" + tbName + "' and cfield='" + headerText + "'");
    //        if (hDs.Tables.Count > 0)
    //        {
    //            if (hDs.Tables[0].Rows.Count > 0)
    //            {
    //                headerText = hDs.Tables[0].Rows[0]["cheadertext"].ToString();
    //            }
    //        }
    //        bc.HeaderText = headerText;
    //        bc.ItemStyle.HorizontalAlign = HorizontalAlign.Center;//居中对齐
    //        gvshow.Columns.Add(bc);
    //    }
    //    //添加编辑列
    //    CommandField cf = new CommandField();//命令字段
    //    cf.ButtonType = ButtonType.Link;//超链接样式的按钮
    //    cf.ShowEditButton = true;//显示编辑按钮
    //    cf.CausesValidation = false;//引发数据验证为false
    //    cf.HeaderText = "编辑";
    //    cf.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
    //    gvshow.Columns.Add(cf);//添加编辑按钮到gridview

    //    //添加删除列
    //    CommandField cf2 = new CommandField();
    //    cf2.ButtonType = ButtonType.Link;
    //    cf2.ShowDeleteButton = true;//显示删除按钮
    //    cf2.CausesValidation = false;
    //    cf2.HeaderText = "删除";
    //    cf2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
    //    gvshow.Columns.Add(cf2);
    //    //添加包复选框的模板列
    //    TemplateField tf = new TemplateField();
    //    tf.ItemTemplate = new MyTemplate("", DataControlRowType.DataRow);
    //    //tf.HeaderText = "选择";
    //    tf.HeaderTemplate = new MyTemplate("", DataControlRowType.Header);
    //    tf.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
    //    gvshow.Columns.Add(tf);


    //    gvshow.DataBind();
    //    form1.Controls.Add(gvshow);
    //}
    protected void BindQAItem()
    { 
       Guid id =new Guid( Label32.Text.ToString());
       GridView2.DataSource = iQCBasicDataL.Search_WorkOrder(id);
       GridView2.DataBind();
       UpdatePanel_NewExpApp.Update();
    }
}