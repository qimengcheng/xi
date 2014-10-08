using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ProductionProcess_WorkOrderCreate : System.Web.UI.Page
{
    SalesMonthPlanL mp = new SalesMonthPlanL();
    WorkOrderL wol = new WorkOrderL();
    WorkOrderInfo woinfo = new WorkOrderInfo();
    ProductionProcessD ppd = new ProductionProcessD();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.label_GridPageState.Text = "默认数据源";

        if (!IsPostBack)
        {
            this.Title = "随工单生成";
            string condition = " and 1=1";
            this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
            this.GridView_WOmain.DataBind();
        }
    }

    public void databind_PT()
    {
        string condition;
        string PS_Name = this.TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + this.TextBox_Series.Text.Trim() + "%' ";
        string PT_Name = this.TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + this.TextBox_ProductName.Text.Trim() + "%' ";
        string PT_Code = this.TextBox_ProductName0.Text.Trim() == "" ? " and 1=1 " : " and PT_Code like '%" + this.TextBox_ProductName0.Text.Trim() + "%' ";
        string PT_CodeMeanning = this.TextBox_ProductName1.Text.Trim() == "" ? " and 1=1 " : " and PT_CodeMeanning like '%" + this.TextBox_ProductName1.Text.Trim() + "%' ";
        condition = PS_Name + PT_Name + PT_CodeMeanning + PT_Code;
        GridView_ProType.DataSource = ppd.S_ProType_For_WorkOrder(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    
    }

    public void databind()
    {
        string condition;
        string WO_Type = this.DropDownList_WO_Type.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Type like '%" + this.DropDownList_WO_Type.SelectedItem.Text.Trim() + "%' ";
        string WO_People = this.TextBox_WO_People.Text.Trim() == "" ? " and 1=1 " : " and WO_People like '%" + this.TextBox_WO_People.Text.Trim() + "%' ";
        if ((this.TextBox_WO_Time1.Text != "" && this.TextBox_WO_Time2.Text == "") || (this.TextBox_WO_Time1.Text == "" && this.TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请将随工单生成时间检索范围输入完整，请您再次核对！')", true);
            return;
        }

        string WO_Time = (this.TextBox_WO_Time1.Text.Trim() == "" && this.TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and WO_Time between   ' " + this.TextBox_WO_Time1.Text.Trim() + "' and ' " + this.TextBox_WO_Time2.Text.Trim() + "'";
        string WO_Num = this.TextBox_WO_Num.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + this.TextBox_WO_Num.Text.Trim() + "%' ";
        string SMSO_ComOrderNum = this.TextBox_OrderNum.Text.Trim() == "" ? " and 1=1 " : " and SMSO_ComOrderNum like '%" + this.TextBox_OrderNum.Text.Trim() + "%' ";
        string WO_ProType = this.TextBox_WO_ProType.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + this.TextBox_WO_ProType.Text.Trim() + "%' ";
        string WO_ChipNum = this.TextBox_chipnum.Text.Trim() == "" ? " and 1=1 " : " and WO_PT_ChipType like '%" + this.TextBox_chipnum.Text.Trim() + "%' ";
       // string WO_Level = this.DropDownList_level.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Level like '%" + this.DropDownList_level.SelectedItem.Text.Trim() + "%' ";
        string WO_State = this.DropDownList_WoState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_State like '%" + this.DropDownList_WoState.SelectedItem.Text.Trim() + "%' ";
        string WO_SN = this.TextBox_WOSN.Text.Trim() == "" ? " and 1=1 " : " and WO_SN like '%" + this.TextBox_WOSN.Text.Trim() + "%' ";
        condition = WO_Type + WO_People + WO_Time + WO_Num + SMSO_ComOrderNum + WO_ProType + WO_ChipNum  + WO_State + WO_SN;
        this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
        this.GridView_WOmain.DataBind();
        this.UpdatePanel_WOmain.Update();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
    }


    protected void Btn_Search_Click(object sender, EventArgs e)//检索按钮事件
    {
        databind();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)//重置按钮事件
    {
        //this.DropDownList_level.SelectedIndex = 0;
        this.DropDownList_WO_Type.SelectedIndex = 0;
        this.DropDownList_WoState.SelectedIndex = 0;
        this.TextBox_chipnum.Text = "";
        this.TextBox_OrderNum.Text = "";
        this.TextBox_WO_Num.Text = "";
        this.TextBox_WO_People.Text = "";
        this.TextBox_WO_ProType.Text = "";
        this.TextBox_WO_Time1.Text = "";
        this.TextBox_WO_Time2.Text = "";
        this.TextBox_WOSN.Text = "";

        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();


        string condition = " and 1=1";
        this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
        this.GridView_WOmain.DataBind();
        this.UpdatePanel_WOmain.Update();

    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)//随工单主表分页
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
        this.GridView_WOmain.PageIndex = newPageIndex;



        databind();


        this.TextBox_Series.Text = "";
        this.TextBox_ProductName.Text = "";
        this.Panel_Product_Search.Visible = false;
        this.Panel_Product.Visible = false;
        this.UpdatePanel_Product.Update();

        TextBox_ComOrderNum.Text = "";
        TextBox_CustOrder.Text = "";
        Panel_SelectOrder.Visible = false;
        UpdatePanel_SelectOrder.Update();

        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        TextBox_MBatch.Text = "";
        Panel_MBatch.Visible = false;
        UpdatePanel_MBatch.Update();
        Panel_Batch.Visible = false;
        UpdatePanel_Batch.Update();

    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)//随工单主表行命令
    {

        if (e.CommandName == "BasicInfo")//查看产品基础信息，包括BOM、工艺路线等
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            GridView_WOmain.SelectedIndex = -1;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            this.Label_WOID.Text = al[0];
            string ptname = al[1];
            Label_Type.Text = al[2];
            if (al[2].Trim() == "检验")
            {
                this.GridView_Pr.DataSource = wol.S_WO_ProType_ProcessRoute(ptname, 1);
                this.GridView_Pr.DataBind();
                //  this.GridView_Pr.Columns[2].Visible = false;
                Label20.Text = "以下为检验随工单的工艺路线，与常规产品路线不同，蓝色表示需要认证的工序，认证合格后才能进行非蓝色工序";
            }
            else
            {
                this.GridView_Pr.DataSource = wol.S_WO_ProType_ProcessRoute(ptname, 0);
                this.GridView_Pr.DataBind();
                this.GridView_Pr.Columns[3].Visible = false;
                this.GridView_Pr.Columns[4].Visible = false;
                Label20.Text = "";
            }
            this.Label_PT.Text = ptname;
            Panel_basic.Visible = true;
            this.GridView_bom.DataSource = wol.S_ProType_BOM(ptname);
            this.GridView_bom.DataBind();

            DataSet ds1 = wol.S_ProType_TestParameter(ptname);
            DataView dv1 = ds1.Tables[0].DefaultView;
            foreach (DataRowView datav in dv1)
            {
                this.TextBox_TestParameter.Text = datav["PT_Parameters"].ToString().Trim();
            }
            UpdatePanel_basic.Update();
            //无关信息隐藏
            this.TextBox_Series.Text = "";
            this.TextBox_ProductName.Text = "";
            this.Panel_Product_Search.Visible = false;
            this.Panel_Product.Visible = false;
            this.UpdatePanel_Product.Update();
            Panel_MBatch.Visible = false;
            UpdatePanel_MBatch.Update();
            Panel_Batch.Visible = false;
            UpdatePanel_Batch.Update();
        }

        if (e.CommandName == "Deleted")//删除主表
        {
            try
            {
                wol.D_WorkOrder(new Guid(e.CommandArgument.ToString().Trim()));
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单失败，原因可能是由于已经制定了该随工单更进一步的信息！')", true);
                return;
            }
        //    this.DropDownList_level.SelectedIndex = 0;
            this.DropDownList_WO_Type.SelectedIndex = 0;
            this.DropDownList_WoState.SelectedIndex = 0;
            this.TextBox_chipnum.Text = "";
            this.TextBox_OrderNum.Text = "";
            this.TextBox_WO_Num.Text = "";
            this.TextBox_WO_People.Text = "";
            this.TextBox_WO_ProType.Text = "";
            this.TextBox_WO_Time1.Text = "";
            this.TextBox_WO_Time2.Text = "";
            this.TextBox_WOSN.Text = "";

            Panel_basic.Visible = false;
            UpdatePanel_basic.Update();
            Panel_MBatch.Visible = false;
            UpdatePanel_MBatch.Update();
            Panel_Batch.Visible = false;
            UpdatePanel_Batch.Update();

            string condition = " and 1=1";
            this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
            this.GridView_WOmain.DataBind();
            this.UpdatePanel_WOmain.Update();


        }

        if (e.CommandName == "materialsheet")//查看产品基础信息，包括BOM、工艺路线等
        {

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Response.Redirect("./materialsheet.aspx?WO_ID=" + al[0] + "&WO_Num=" + al[1] + "&SMSO_ComOrderNum=" + al[2]
                + "&WO_ProType=" + al[3] + "&WO_PNum=" + al[4] + "&WO_Level=" + al[5] + "&WO_Type=" + al[6] + "&WO_People=" + al[7]
                + "&WO_Time=" + al[8]);
        }
        if (e.CommandName == "editWorkWorder")//修改主表
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            this.Label_EditWOID.Text = al[0];
            this.TextBox_EditNum.Text = al[1];
            this.Label_EditWONum.Text = al[1];
            this.Label_EditPTID.Text = al[6];
            this.Label_EditOrderNum.Text = al[7];
            this.TextBox_EditProType.Text = al[2];
            this.TextBox_EditOrderNum.Text = al[3];
            this.TextBox_EditNote.Text = al[4];
            this.TextBox_EditSN.Text = al[5];
            this.Panel_EditWorkOrder.Visible = true;
            this.UpdatePanel_EditWorkOrder.Update();
        }
        if (e.CommandName == "printpreview")//打印
        {
            
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            //if (al[5].Contains("SMSC"))
            //{
            Response.Redirect("../ProductionProcess/SMSCWOPrint.aspx?" + "&WO_Num=" + al[1] + "&WO_Type=" + al[2] + "&SMSO_CusOrderNum=" + al[3] + "&SMSO_PlaceOrderTime=" + al[4] + "&WO_SN=" + al[6] + "&CB=" + al[7] + "&PS=" + al[5] + "&WO_ProType=" + al[8]
                    );
            //}
            //else 
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('系统试用阶段仅支持SMSC系统产品的打印！')", true);
            //}
        }
    }
    protected void GridView_WOmain_Sorting(object sender, GridViewSortEventArgs e)//随工单主表排序相关
    {

    }
    protected void GridView_WOmain_DataBound(object sender, EventArgs e)//随工单主表数据绑定 
    {
        for (int i = 0; i < GridView_WOmain.Rows.Count; i++) //鼠标悬停样式
        {
            for (int j = 0; j < GridView_WOmain.Rows[i].Cells.Count; j++)
            {
                GridView_WOmain.Rows[i].Cells[j].ToolTip = GridView_WOmain.Rows[i].Cells[j].Text;
                if (GridView_WOmain.Rows[i].Cells[j].Text.Length > 12)
                {
                    GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].Text.Substring(0,12) + "...";
                }


            }
        }
    }

   


    protected void SelectProType(object sender, EventArgs e)//绑定产品型号表，查询结果
    {
        databind_PT();
    }

    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)//产品型号表分页
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        //new add for checkbox

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView_ProType.BottomPagerRow;

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
        newPageIndex = newPageIndex >= this.GridView_ProType.PageCount ? this.GridView_ProType.PageCount - 1 : newPageIndex;
        //RemeberOldValues();
        this.GridView_ProType.PageIndex = newPageIndex;
        databind_PT();
        //RePopulateValues();
    }
    //从当前页收集选中项的情况
   
    
    protected void GridView_ProType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void GridView_ProType_RowCommand(object sender, GridViewCommandEventArgs e)//产品型号表linkbutton
    {
        if (e.CommandName == "SelectPT")//选择产品型号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_ProType.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ptname = al[1];

            if (Panel_AddWorkOrder.Visible == true)
            {
                Label_PTID.Text = al[0];
                Label_PTCodeMeaning.Text = al[2];
                Label_ChipType.Text = al[3];
                Label_PS.Text = al[4];
                this.TextBox_AddPT.Text = ptname;
                UpdatePanel_AddWorkOrder.Update();
            }
            if (Panel_EditWorkOrder.Visible == true)
            {
                Label_EditPTID.Text = al[0];
                Label_EditPS.Text = al[4];
                this.TextBox_EditProType.Text = ptname;
                UpdatePanel_EditWorkOrder.Update();
            }
            Panel_Product.Visible = false;
            Panel_Product_Search.Visible = false;
            Panel_WOmain.Visible = true;
            UpdatePanel_WOmain.Update();
            string condition = " and 1=1";
            this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
            this.GridView_WOmain.DataBind();
            UpdatePanel_Product.Update();

        }
    }


    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)//随工单主表行绑定事件
    {

    }
    #region 产品基础信息查看
    //bom信息查看
    protected void GridView_bom_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView_bom_RowCommand(object sender, GridViewCommandEventArgs e)//BOM查看批号
    {
        if (e.CommandName == "Batch_Num")//查看批号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_bom.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid iMMBD_MaterialID = new Guid(al[1]);
            this.Label_iMMBD_MaterialID.Text = al[1];
            Guid woid = new Guid(this.Label_WOID.Text.Trim());
            Panel_Batch.Visible = true;
            Panel_MBatch.Visible = false;
            UpdatePanel_MBatch.Update();
            GridView_Batch.DataSource = wol.S_WOMBatchNum(iMMBD_MaterialID, woid);
            GridView_Batch.DataBind();
            UpdatePanel_Batch.Update();




        }
    }
    protected void GridView_bom_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_bom_DataBound(object sender, EventArgs e)//产品基础信息，BOM表鼠标悬停
    {
        for (int i = 0; i < GridView_bom.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_bom.Rows[i].Cells.Count; j++)
            {
                GridView_bom.Rows[i].Cells[j].ToolTip = GridView_bom.Rows[i].Cells[j].Text;
                if (GridView_bom.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_bom.Rows[i].Cells[j].Text = GridView_bom.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_bom_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[14].ToolTip = e.Row.Cells[14].Text.ToUpper();
            if (e.Row.Cells[14].Text.Length > 3)
            {
                e.Row.Cells[14].Text = e.Row.Cells[14].Text.Substring(0, 3).ToUpper();

            }
            if (e.Row.Cells[7].Text.Length > 6)
            {
                e.Row.Cells[7].ToolTip = e.Row.Cells[7].Text;
                e.Row.Cells[7].Text = e.Row.Cells[7].Text.Substring(0, 6);

            }
      

            }
         
          








        
    }
    //产品工艺路线信息查看
    protected void GridView_Pr_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void GridView_Pr_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void GridView_Pr_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_Pr_DataBound(object sender, EventArgs e)//产品基础信息，工艺路线鼠标悬停
    {
        for (int i = 0; i < GridView_Pr.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Pr.Rows[i].Cells.Count; j++)
            {
                GridView_Pr.Rows[i].Cells[j].ToolTip = GridView_Pr.Rows[i].Cells[j].Text;
                if (GridView_Pr.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Pr.Rows[i].Cells[j].Text = GridView_Pr.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_Pr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Label_Type.Text.Trim() == "检验")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                if (drv["PRD_RenZhengOrder"].ToString().Trim() != "")
                {
                    e.Row.BackColor = System.Drawing.Color.SkyBlue;

                }
            }
        }
    }

    #endregion





    protected void Btn_SelectPT_Click(object sender, EventArgs e)//选择产品型号
    {
        if (TextBox_AddPT.Text.Trim() == "")
        {
            Label_PS.Text = "";
            Panel_Product.Visible = true;
            Panel_Product_Search.Visible = true;
          
            Panel_basic.Visible = false;
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            TextBox_ProductName0.Text = "";
            TextBox_ProductName1.Text = "";
        
            this.Panel_Product.Visible = true;
            this.Panel_Product_Search.Visible = true;
            databind_PT();
            UpdatePanel_WOmain.Update();
            UpdatePanel_basic.Update();
        }
        else
        {
            Label_PS.Text = "";
            Panel_Product.Visible = true;
            Panel_Product_Search.Visible = true;

            Panel_basic.Visible = false;
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            TextBox_ProductName0.Text = "";
            TextBox_ProductName1.Text = "";

            this.Panel_Product.Visible = true;
            this.Panel_Product_Search.Visible = true;
            databind_PT();
            UpdatePanel_WOmain.Update();
            UpdatePanel_basic.Update();

            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('产品型号已选择，请勿重复选择！')", true);
            //return;
        
        }
    }

    protected void Btn_SelectProType_Click(object sender, EventArgs e)
    {
            Label_PS.Text = "";
            Panel_Product.Visible = true;
            Panel_Product_Search.Visible = true;

            Panel_basic.Visible = false;
            TextBox_Series.Text = "";
            TextBox_ProductName.Text = "";
            TextBox_ProductName0.Text = "";
            TextBox_ProductName1.Text = "";

            this.Panel_Product.Visible = true;
            this.Panel_Product_Search.Visible = true;
            databind_PT();
            UpdatePanel_WOmain.Update();
            UpdatePanel_basic.Update();
    }


    protected void Btn_Close_PT_Click(object sender, EventArgs e)
    {
        this.TextBox_Series.Text = "";
        this.TextBox_ProductName.Text = "";
        this.Panel_Product_Search.Visible = false;
        this.Panel_Product.Visible = false;
        this.UpdatePanel_Product.Update();
    }
    protected void Btn_Submit_Add_Click(object sender, EventArgs e)//新增随工单按钮
    {
        if (TextBox_AddPT.Text.Trim() == "" || TextBox_Add_PNum.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请核对必填项*！')", true);
            return;
        }
        if (Label_PS.Text.Contains("SMSC"))
        {

            if (TextBox_Add_SN.Text.Trim() == "" || TextBox_Add_Order.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('SMSC随工单必须填写周期码和订单号，请再次核对！')", true);
                return;
            
            }
        }
        try
        {

            if (Label_AddOrderNum.Text.Trim() == "")
            {
                Label_AddOrderNum.Text = "00000000-0000-0000-0000-000000000000";
            }
            woinfo.SMSO_ID = new Guid(Label_AddOrderNum.Text.Trim());
            woinfo.WO_Note = TextBox_AddNote.Text.Trim();
            woinfo.WO_People = Session["UserName"].ToString();
            woinfo.WO_PNum = Convert.ToInt32(TextBox_Add_PNum.Text.Trim());
            woinfo.WO_ProType = TextBox_AddPT.Text.Trim();
            woinfo.WO_Type = this.DropDownList_Add_WO_Type.SelectedItem.Text.Trim();
            woinfo.WO_OrderNum = TextBox_Add_Order.Text.Trim();
            int fd=Convert.ToInt32(DropDownList4.SelectedValue.ToString());
            string printcode=DropDownList5.SelectedValue.ToString().Trim()+DropDownList6.SelectedValue.ToString().Trim();
            if (Label_PS.Text.Contains("SMSC"))
            {
                ppd.I_WorkOrder_NEW(woinfo, DropDownList1.SelectedValue.ToString().Trim(), DropDownList_Add_WO_Type.SelectedValue.ToString().Trim(), new Guid(Label_PTID.Text.Trim()), printcode, DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(), fd, Label_PTCodeMeaning.Text.Trim(), Label_ChipType.Text.Trim(), TextBox_Add_SN.Text.Trim(), 1);
            }
            else
            {
                ppd.I_WorkOrder_NEW(woinfo, DropDownList1.SelectedValue.ToString().Trim(), DropDownList_Add_WO_Type.SelectedValue.ToString().Trim(), new Guid(Label_PTID.Text.Trim()), printcode, DropDownList2.SelectedValue.ToString().Trim(), DropDownList3.SelectedValue.ToString().Trim(), fd, Label_PTCodeMeaning.Text.Trim(), Label_ChipType.Text.Trim(), TextBox_Add_SN.Text.Trim(), 0);

            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单新增成功！')", true);
            string condition = " and 1=1";
            this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
            this.GridView_WOmain.DataBind();
            this.UpdatePanel_WOmain.Update();
            Panel_AddWorkOrder.Visible = false;
            UpdatePanel_AddWorkOrder.Update();
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单新增失败！')", true);
            return;
        }

    }
    protected void Button_CancelAdd_Click(object sender, EventArgs e)
    {
        Panel_AddWorkOrder.Visible = false;
        UpdatePanel_AddWorkOrder.Update();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        this.Panel_Product_Search.Visible = false;
        this.Panel_Product.Visible = false;
        this.UpdatePanel_Product.Update();
    }
    protected void Btn_AddWO_Click(object sender, EventArgs e)
    {
        string firstday="26";
        Label_OT.Text = "";
        DataSet ds = ppd.S_WorkOrder_WO_Time();
        DataView dv = ds.Tables[0].DefaultView;
        if (ds.Tables[0].Rows.Count == 0)
        {
            firstday = "26";
        }
        foreach (DataRowView datav in dv)
        {

            firstday = datav["WO_FirstDay"].ToString().Trim() == "" ? "26" : datav["WO_FirstDay"].ToString().Trim();
        }
        DropDownList4.SelectedValue = firstday;
        DropDownList2.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 0;

        DropDownList_Add_WO_Type.SelectedIndex = 0;
        TextBox_AddPT.Text = "";
        TextBox_Add_PNum.Text = "";
        TextBox_Add_Order.Text = "";
        TextBox_Add_SN.Text = "";
        TextBox_AddNote.Text = "";
        DropDownList1.SelectedIndex = 0;
        Panel_AddWorkOrder.Visible = true;
        UpdatePanel_AddWorkOrder.Update();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        this.Panel_Product_Search.Visible = false;
        this.Panel_Product.Visible = false;
        this.UpdatePanel_Product.Update();

        //无关隐藏

        this.TextBox_Series.Text = "";
        this.TextBox_ProductName.Text = "";
        this.Panel_Product_Search.Visible = false;
        this.Panel_Product.Visible = false;
        this.UpdatePanel_Product.Update();

        TextBox_ComOrderNum.Text = "";
        TextBox_CustOrder.Text = "";
        Panel_SelectOrder.Visible = false;
        UpdatePanel_SelectOrder.Update();

        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        TextBox_MBatch.Text = "";
        Panel_MBatch.Visible = false;
        UpdatePanel_MBatch.Update();
        Panel_Batch.Visible = false;
        UpdatePanel_Batch.Update();
    }
    protected void Btn_SelectOrder_Click(object sender, EventArgs e)//新增随工单时，选择订单号
    {
        Panel_basic.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_SelectOrder.Visible = true;

        string condition;
        string ComOrderNum = this.TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + this.TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = this.TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + this.TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        this.GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        this.GridView_Order.DataBind();

        UpdatePanel_basic.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_SelectOrder.Update();

    }

    protected void Button_SelectOrderNum_Click(object sender, EventArgs e)
    {
        Panel_basic.Visible = false;
        Panel_Product.Visible = false;
        Panel_Product_Search.Visible = false;
        Panel_SelectOrder.Visible = true;

        string condition;
        string ComOrderNum = this.TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + this.TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = this.TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + this.TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        this.GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        this.GridView_Order.DataBind();

        UpdatePanel_basic.Update();
        UpdatePanel_Product.Update();
        UpdatePanel_SelectOrder.Update();
    }
    protected void Button_SearchOrder_Click(object sender, EventArgs e)//检索订单号
    {
        string condition;
        string ComOrderNum = this.TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + this.TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = this.TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + this.TextBox_CustOrder.Text.Trim() + "%' ";
        string OEMOT_SNum = this.TextBox_ComOrderNum0.Text.Trim() == "" ? " and 1=1 " : "and OEMOT_SNum like '%" + this.TextBox_ComOrderNum0.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder + OEMOT_SNum;
        this.GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        this.GridView_Order.DataBind();
        this.UpdatePanel_SelectOrder.Update();
    }
    protected void Btn_Close_SearchOrder_Click(object sender, EventArgs e)//关闭检索订单页面
    {
        TextBox_ComOrderNum.Text = "";
        TextBox_CustOrder.Text = "";
        Panel_SelectOrder.Visible = false;
        UpdatePanel_SelectOrder.Update();
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
        this.GridView_Order.PageIndex = newPageIndex;
        string condition;
        string ComOrderNum = this.TextBox_ComOrderNum.Text.Trim() == "" ? " and 1=1 " : "and SMSO_ComOrderNum like '%" + this.TextBox_ComOrderNum.Text.Trim() + "%' ";
        string CustOrder = this.TextBox_CustOrder.Text.Trim() == "" ? " and 1=1 " : "and SMSO_CusOrderNum like '%" + this.TextBox_CustOrder.Text.Trim() + "%' ";
        condition = ComOrderNum + CustOrder;
        this.GridView_Order.DataSource = wol.S_WO_SMSalesOrder(condition);
        this.GridView_Order.DataBind();
        this.UpdatePanel_SelectOrder.Update();




    }
    protected void GridView_Order_RowCommand(object sender, GridViewCommandEventArgs e)//订单号表链接按钮事件
    {
        if (e.CommandName == "Select_Order")//选择订单号
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Order.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            if (Panel_AddWorkOrder.Visible == true)
            {
                Label_AddOrderNum.Text = al[0];
                TextBox_Add_Order.Text = al[1];//客户订单号
                Label_OT.Text = al[3];
                TextBox_Add_SN.Text = GridView_Order.DataKeys[row.RowIndex].Values["OEMOT_SNum"].ToString();
                UpdatePanel_AddWorkOrder.Update();
            }
            if (Panel_EditWorkOrder.Visible == true)
            {
                Label_EditOrderNum.Text = al[0];
                TextBox_EditOrderNum.Text = al[1];//客户订单号
                TextBox_EditSN.Text = GridView_Order.DataKeys[row.RowIndex].Values["OEMOT_SNum"].ToString();
                UpdatePanel_EditWorkOrder.Update();
            }
            Panel_SelectOrder.Visible = false;
            UpdatePanel_SelectOrder.Update();

        }
    }
    protected void GridView_Order_RowDataBound(object sender, GridViewRowEventArgs e)//订单号表行绑定
    {

    }
    protected void Button_ChooseBatch_Click(object sender, EventArgs e)
    {
        TextBox_MBatch.Text = "";
        Panel_MBatch.Visible = true;
        GridView_BasicBatch.DataSource = wol.S_WOMBatchNum_IMInventoryDetail(" and c.IMMBD_MaterialID='" + this.Label_iMMBD_MaterialID.Text + "' and IMID_BatchNum not in ( select WOMBN_BN from WOMBatchNum d where d.WO_ID='" + this.Label_WOID.Text + "' and d.IMMBD_MaterialID ='" + this.Label_iMMBD_MaterialID.Text + "')");
        GridView_BasicBatch.DataBind();
        UpdatePanel_MBatch.Update();
    }
    protected void Btn_Close_ChooseBatch_Click(object sender, EventArgs e)
    {
        Panel_Batch.Visible = false;
        Panel_MBatch.Visible = false;
        UpdatePanel_Batch.Update();
        UpdatePanel_MBatch.Update();

    }
    protected void Btn_Close_ChooseMBatch_Click(object sender, EventArgs e)
    {
        TextBox_MBatch.Text = "";
        Panel_MBatch.Visible = false;
        UpdatePanel_MBatch.Update();
    }
    protected void Button_SearchBatch_Click(object sender, EventArgs e)
    {
        string condition = this.TextBox_MBatch.Text.Trim() == "" ? " and 1=1 " : " and IMID_BatchNum like '%" + this.TextBox_MBatch.Text.Trim() + "%' ";
        GridView_BasicBatch.DataSource = wol.S_WOMBatchNum_IMInventoryDetail(" and c.IMMBD_MaterialID='" + this.Label_iMMBD_MaterialID.Text + "' and IMID_BatchNum not in ( select WOMBN_BN from WOMBatchNum d where d.WO_ID='" + this.Label_WOID.Text + "' and d.IMMBD_MaterialID ='" + this.Label_iMMBD_MaterialID.Text + "')"+ condition);
        GridView_BasicBatch.DataBind();
        UpdatePanel_MBatch.Update();
    }
    protected void GridView_Batch_PageIndexChanging(object sender, GridViewPageEventArgs e)//随工单的批号表翻页
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Batch.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Batch.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Batch.PageCount ? GridView_Batch.PageCount - 1 : newPageIndex;
        GridView_Batch.PageIndex = newPageIndex;
        this.GridView_Batch.PageIndex = newPageIndex;

        GridView_Batch.DataSource = wol.S_WOMBatchNum(new Guid(this.Label_iMMBD_MaterialID.Text), new Guid(this.Label_WOID.Text));
        GridView_Batch.DataBind();
        UpdatePanel_Batch.Update();

    }
    protected void GridView_Batch_RowCommand(object sender, GridViewCommandEventArgs e) //材料批号信息表操作
    {
        if (e.CommandName == "deleteBatch")//删除材料批号
        {
            //try
            //{
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            //  GridView_BasicBatch.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string wOMBN_ID = al[0];
            wol.D_WOMBatchNum(new Guid(wOMBN_ID));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
            GridView_Batch.DataSource = wol.S_WOMBatchNum(new Guid(this.Label_iMMBD_MaterialID.Text), new Guid(this.Label_WOID.Text));
            GridView_Batch.DataBind();
            UpdatePanel_Batch.Update();
            //}
            //catch (Exception)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！')", true);
            //    return;
            //}
        }
    }
    protected void GridView_Batch_RowDataBound(object sender, GridViewRowEventArgs e)//批号信息表行绑定
    {

    }
    protected void GridView_Batch_DataBound(object sender, EventArgs e)//批号表鼠标悬停
    {

    }
    protected void GridView_BasicBatch_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView_BasicBatch_RowCommand(object sender, GridViewCommandEventArgs e)//选择库存中的批号至随工单批号表
    {
        if (e.CommandName == "ChoseBatchToWO")//选择订单号
        {
            try
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                //  GridView_BasicBatch.SelectedIndex = row.RowIndex;
                string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
                string iMID_BatchNum = al[1];
                wol.I_WOMBatchNum(new Guid(this.Label_iMMBD_MaterialID.Text), new Guid(this.Label_WOID.Text), iMID_BatchNum);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('批号添加成功！')", true);
                Panel_MBatch.Visible = false;
                UpdatePanel_MBatch.Update();
                GridView_Batch.DataSource = wol.S_WOMBatchNum(new Guid(this.Label_iMMBD_MaterialID.Text), new Guid(this.Label_WOID.Text));
                GridView_Batch.DataBind();
                UpdatePanel_Batch.Update();
                databind();

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('批号添加失败！')", true);
                return;
            }
        }
    }
    protected void GridView_BasicBatch_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_Batch_BasicBatch_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_BasicBatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_BasicBatch.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_BasicBatch.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_BasicBatch.PageCount ? GridView_BasicBatch.PageCount - 1 : newPageIndex;
        GridView_BasicBatch.PageIndex = newPageIndex;

        string condition = this.TextBox_MBatch.Text.Trim() == "" ? " and 1=1 " : " and IMID_BatchNum like '%" + this.TextBox_MBatch.Text.Trim() + "%' ";
        GridView_BasicBatch.DataSource = wol.S_WOMBatchNum_IMInventoryDetail(" and c.IMMBD_MaterialID='" + this.Label_iMMBD_MaterialID.Text + "' and IMID_BatchNum not in ( select WOMBN_BN from WOMBatchNum d where d.WO_ID='" + this.Label_WOID.Text + "' and d.IMMBD_MaterialID ='" + this.Label_iMMBD_MaterialID.Text + "')" + condition);
        GridView_BasicBatch.DataBind();
        UpdatePanel_MBatch.Update();
    }
    protected void Btn_Close_ChooseBatch0_Click(object sender, EventArgs e)
    {
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        TextBox_MBatch.Text = "";
        Panel_MBatch.Visible = false;
        UpdatePanel_MBatch.Update();
        Panel_Batch.Visible = false;
        UpdatePanel_Batch.Update();
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
    protected void Button15_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        TextBox_ProductName0.Text = "";
        TextBox_ProductName1.Text = "";
        databind_PT();
    }

    protected void Button_EditSubmit_Click(object sender, EventArgs e)
    {
        if (TextBox_EditProType.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请核对必填项*！')", true);
            return;
        }
        if (TextBox_EditNum.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单号不能为空！')", true);
            return;
        }
        if (Label_EditPS.Text.Contains("SMSC"))
        {

            if (TextBox_EditSN.Text.Trim() == "" || TextBox_EditOrderNum.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('SMSC随工单必须填写周期码和订单号，请再次核对！')", true);
                return;
            }
        }

        if (TextBox_EditNum.Text.Trim() == Label_EditWONum.Text)
        {

            try
            {
                editWorkOrder();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单修改失败！')", true);
                return;
            }
            
        }
        else
        {
            try
            {
                string WO_Num = " and WO_Num = '" + this.TextBox_EditNum.Text.Trim() + "' ";
                if (ppd.S_WorkOrderCheck(WO_Num))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('存在同名的随工单号，请重新输入！')", true);
                    return;
                }
                editWorkOrder();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单修改失败！')", true);
                return;
            }

        }
    }

    private void editWorkOrder()
    {
        if (Label_EditOrderNum.Text.Trim() == "")
        {
            Label_EditOrderNum.Text = "00000000-0000-0000-0000-000000000000";
        }
        woinfo.SMSO_ID = new Guid(this.Label_EditOrderNum.Text.Trim());
        Guid PT_ID = new Guid(this.Label_EditPTID.Text.Trim());
        woinfo.WO_Note = TextBox_EditNote.Text.Trim();
        woinfo.WO_People = Session["UserName"].ToString();
        woinfo.WO_ProType = TextBox_EditProType.Text.Trim();
        woinfo.WO_Num = this.TextBox_EditNum.Text.Trim();
        woinfo.WO_OrderNum = TextBox_EditOrderNum.Text.Trim();
        woinfo.WO_SN = TextBox_EditSN.Text.Trim();
        woinfo.WO_ID = new Guid(this.Label_EditWOID.Text.Trim());
        woinfo.WO_Time = DateTime.Now;
        ppd.WorkOrder_Edit(woinfo,PT_ID);
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单修改成功！')", true);
        string condition = " and 1=1";
        this.GridView_WOmain.PageIndex = 0;
        this.GridView_WOmain.DataSource = wol.S_WorkOrder(condition);
        this.GridView_WOmain.DataBind();
        
        this.UpdatePanel_WOmain.Update();
        Panel_EditWorkOrder.Visible = false;
        UpdatePanel_EditWorkOrder.Update();
    }

    protected void Button_EditCancel_Click(object sender, EventArgs e)
    {
        Panel_EditWorkOrder.Visible = false;
        UpdatePanel_EditWorkOrder.Update();
    }
}