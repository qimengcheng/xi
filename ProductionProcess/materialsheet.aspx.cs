using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductionProcess_materialsheet : Page
{
    WorkOrderL wol = new WorkOrderL();
    ProductionProcessD pp = new ProductionProcessD();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            Title = "领料单管理";
            Label_woid.Text = Request.QueryString["WO_ID"].ToString();
            TextBox_pnum.Text = Request.QueryString["WO_PNum"].ToString();
            TextBox_level.Text = Request.QueryString["WO_Level"].ToString();
            TextBox_OrderNum.Text = Request.QueryString["SMSO_ComOrderNum"].ToString();
            TextBox_People.Text = Request.QueryString["WO_People"].ToString();
            TextBox_Time.Text = Request.QueryString["WO_Time"].ToString();
            TextBox_WO_Num.Text = Request.QueryString["WO_Num"].ToString();
            TextBox_WO_ProType.Text = Request.QueryString["WO_ProType"].ToString();
            TextBox_WOType.Text = Request.QueryString["WO_Type"].ToString();
            string pt=Request.QueryString["WO_ProType"].ToString();
            decimal snum= Convert.ToDecimal( Request.QueryString["WO_PNum"].ToString());
            GridView_LL.DataSource = wol.s_protype_bom_wo(pt, snum);
            GridView_LL.DataBind();
            UpdatePanel_basic.Update();
          
        }
    }
    protected void Btn_LLD_Click(object sender, EventArgs e)//分工序生成领料单
    {

    }
    protected void GridView_LL_DataBound(object sender, EventArgs e)//领料信息表 鼠标悬停、数据绑定
    {
        for (int i = 0; i < GridView_LL.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_LL.Rows[i].Cells.Count; j++)
            {
                GridView_LL.Rows[i].Cells[j].ToolTip = GridView_LL.Rows[i].Cells[j].Text;
                if (GridView_LL.Rows[i].Cells[j].Text.Length > 10)
                {
                    GridView_LL.Rows[i].Cells[j].Text = GridView_LL.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                }


            }
        }
    }
    protected void GridView_LL_RowCommand(object sender, GridViewCommandEventArgs e)//领料信息表 行命令 查看各领料单详情
    {

    }
    protected void GridView_GXLL_DataBound(object sender, EventArgs e)//分工序领料信息表 鼠标悬停、数据绑定
    {

    }
    protected void GridView_GXLL_RowCommand(object sender, GridViewCommandEventArgs e) //分工序领料信息表 行命令 查看各领料单详情
    {
        if (e.CommandName == "CheckDetail")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_GXLL.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string iMRM_RequisitionID =al[0];
            Label_IMRM_RequisitionID.Text = iMRM_RequisitionID;
            string pbc_name = al[1];
            label_pbcname.Text = al[1];
            decimal pnum=Convert.ToDecimal(TextBox_pnum.Text);
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            GridView_Detail.DataSource = wol.s_protype_bom_wo_craft(TextBox_WO_ProType.Text, pnum, new Guid(iMRM_RequisitionID),pbc_name);
            GridView_Detail.DataBind();
        
            Panel_Detail.Visible = true;
            UpdatePanel_Detail.Update();
        }
    }
    protected void GridView_Detail_DataBound(object sender, EventArgs e)//领料详细表 鼠标悬停、数据绑定
    {
        for (int i = 0; i < GridView_Detail.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Detail.Rows[i].Cells.Count; j++)
            {
                GridView_Detail.Rows[i].Cells[j].ToolTip = GridView_Detail.Rows[i].Cells[j].Text;
                if (GridView_Detail.Rows[i].Cells[j].Text.Length > 8)
                {
                    GridView_Detail.Rows[i].Cells[j].Text = GridView_Detail.Rows[i].Cells[j].Text.Substring(0, 8) + "...";
                }


            }
        }
    }
    protected void GridView_Detail_RowCommand(object sender, GridViewCommandEventArgs e) //领料详细表 行命令 查看各领料单详情
    {

    }
    protected void Button_CloseGXLL_Click(object sender, EventArgs e)
    {
        Panel_GXLL.Visible = false;
        Panel_Detail.Visible = false;
        UpdatePane_GXLL.Update();
        UpdatePanel_Detail.Update();
    }
    protected void Btn_LL_Click(object sender, EventArgs e)//分工站生成领料单
    {
        DataSet ds = wol.S_IMRequisitionMain_WorkOrder(new Guid(Label_woid.Text));
        DataTable dt = ds.Tables[0];
        Panel_GXLL.Visible = true;
         if (dt.Rows.Count == 0)
         {
             string man=Session["UserName"].ToString();
             string dept = Session["Department"].ToString();
             string ptname=TextBox_WO_ProType.Text;
             wol.I_IMRequisitionMain_WorkOrder(new Guid(Label_woid.Text), ptname, man, dept);
             ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('分工序领料单还未生成，现已生成！')", true);
             GridView_GXLL.DataSource = wol.S_IMRequisitionMain_WorkOrder(new Guid(Label_woid.Text));
             GridView_GXLL.DataBind();
             UpdatePane_GXLL.Update();
         }
         if (dt.Rows.Count != 0)
         {
            
             GridView_GXLL.DataSource = wol.S_IMRequisitionMain_WorkOrder(new Guid(Label_woid.Text));
             GridView_GXLL.DataBind();
             UpdatePane_GXLL.Update();
         }
    }
    protected void GridView_Detail_RowEditing(object sender, GridViewEditEventArgs e)//编辑状态
    {
        Guid id= new Guid(GridView_Detail.DataKeys[e.NewEditIndex].Values["IMMBD_MaterialID"].ToString());
        DataSet ds = pp.S_IMRequisitionDetail_IMInventoryMain(id);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('库存中还没有该物料！')", true);
            GridView_Detail.EditIndex = -1;
            GridView_Detail.SelectedIndex = -1;
            return;

        
        }
        GridView_Detail.SelectedIndex = e.NewEditIndex;
        GridView_Detail.EditIndex = e.NewEditIndex;
        decimal pnum = Convert.ToDecimal(TextBox_pnum.Text);
        GridView_Detail.DataSource = wol.s_protype_bom_wo_craft(TextBox_WO_ProType.Text, pnum, new Guid(Label_IMRM_RequisitionID.Text), label_pbcname.Text);
        GridView_Detail.DataBind();
        Panel_Detail.Visible = true;
        UpdatePanel_Detail.Update();
    }
    protected void GridView_Detail_RowUpdating(object sender, GridViewUpdateEventArgs e)//完成编辑
    {
        string id;
        Guid gid;
        if (GridView_Detail.DataKeys[e.RowIndex].Values["IMRD_ID"].ToString() == "")
        {
            id = "00000000-0000-0000-0000-000000000000";
             gid = new Guid(id);

        }
        else 
        {
            gid = new Guid(GridView_Detail.DataKeys[e.RowIndex].Values["IMRD_ID"].ToString());
        }
        DataSet ds = wol.s_imrequisitiondetail_ID_workorder(gid);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            try
            {
                Guid imrd_id = new Guid(GridView_Detail.DataKeys[e.RowIndex].Values["IMRD_ID"].ToString());
                decimal iMRD_ActualNum = ((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[15].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[15].Controls[0])).Text.Trim().ToString());
                wol.U_imrequisitiondetail_workorder(imrd_id, iMRD_ActualNum);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划领用量必须为小数形式')", true);

                return;

            }
        }
        else 
        {
            try
            {
                Guid iMRM_RequisitionID = new Guid(Label_IMRM_RequisitionID.Text);
                Guid iMMBD_MaterialID = new Guid(GridView_Detail.DataKeys[e.RowIndex].Values["IMMBD_MaterialID"].ToString());
                decimal iMRD_StandardNum = GridView_Detail.DataKeys[e.RowIndex].Values["suggestNum"].ToString() == "" ? 0 : Convert.ToDecimal(GridView_Detail.DataKeys[e.RowIndex].Values["suggestNum"].ToString());
                decimal iMRD_ActualNum = ((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[15].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[15].Controls[0])).Text.Trim().ToString());
                wol.I_IMRequisitionDetail_WorkOrder(iMRM_RequisitionID, iMMBD_MaterialID, iMRD_StandardNum, iMRD_ActualNum, TextBox_WO_Num.Text.Trim());

            }
            catch(Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划领用量必须为小数形式')", true);

                return;
            
            }
        }
        GridView_Detail.EditIndex = -1;
        GridView_Detail.SelectedIndex = -1;
        decimal pnum = Convert.ToDecimal(TextBox_pnum.Text);
        GridView_Detail.DataSource = wol.s_protype_bom_wo_craft(TextBox_WO_ProType.Text, pnum, new Guid(Label_IMRM_RequisitionID.Text), label_pbcname.Text);
        GridView_Detail.DataBind();
        Panel_Detail.Visible = true;
        UpdatePanel_Detail.Update();
       
    }
    protected void GridView_Detail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)//取消编辑
    {
        GridView_Detail.EditIndex = -1;
        GridView_Detail.SelectedIndex = -1;
        decimal pnum = Convert.ToDecimal(TextBox_pnum.Text);
        GridView_Detail.DataSource = wol.s_protype_bom_wo_craft(TextBox_WO_ProType.Text, pnum, new Guid(Label_IMRM_RequisitionID.Text), label_pbcname.Text);
        GridView_Detail.DataBind();
        Panel_Detail.Visible = true;
        UpdatePanel_Detail.Update();
    }
    protected void GridView_Detail_RowDataBound(object sender, GridViewRowEventArgs e)//行绑定
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            for (int i = 15; i <= 15; i++)
            {


                curText = (TextBox)e.Row.Cells[i].Controls[0];

                curText.Attributes.Add("style ", "width:100px;");
            }
            for (int i = 1; i <= 15; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/[^\\d.]/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/[^\\d.]/g,'')");



            }
         
        }

        
         
    }
    protected void Button_CloseDetail_Click(object sender, EventArgs e)
    {
   
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        GridView_Detail.EditIndex = 0;
        GridView_Detail.SelectedIndex = 0;
    }
    protected void Btn_Return_Click(object sender, EventArgs e)
    {
        Response.Redirect("../ProductionProcess/WorkOrderCreate.aspx");
    }
}