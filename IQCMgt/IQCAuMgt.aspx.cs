using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class IQCMgt_IQCAuMgt : Page
{
    IQCBasicDataD iQCBasicDataL = new IQCBasicDataD();
    IQCBasicDataInfo iQCBasicDataInfo = new IQCBasicDataInfo();
     string state="";
    static Guid id_IMISD = new Guid();//存储入库明细id用于显示查询
    static Guid id_IQCDT_ID = new Guid();//存储检验明细id用于显示查询
    static Guid id_IMMBD_MaterialID = new Guid();//存储物料id用于显示查询
    static Guid id_IQCIT_ID = new Guid();
    #region 页面加载
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {

        string cond1 = Label30.Text.ToString();
        if (!Page.IsPostBack)
        {

            if (state == "")
            {
                Grid_Material.Columns[14].Visible = true;
                Grid_Material.Columns[15].Visible = false;
                Label7.Text = "待审核物料信息表";
            }
            else if (state == "all")
            {
                Grid_Material.Columns[14].Visible = false;
                Grid_Material.Columns[15].Visible = true;
                Label7.Text = "历史检验信息表";
            }
            //BindGrid1(cond1);
            string Role = Request.QueryString["state"].ToString();
            if (Role == "IQCAuMgt" && Session["UserRole"].ToString().Contains("进料检验审核"))
            {
                Title = "进料检验审核";
                cond1 = " and DT.IQCDT_Result='待审核' ";
                Label30.Text = cond1;
                state = "";
                Label7.Text = "待审核物料信息表";
                Grid_Material.Columns[15].Visible =true ;
                Grid_Material.Columns[16].Visible = false;
                BindGrid1(cond1);
            }
            else if (Role == "IQCAuMgtReview" && Session["UserRole"].ToString().Contains("进料检验结果查看"))
            {
                Title = "检验结果查看";
                cond1 = " and DT.IQCDT_Result is not null ";
                Label30.Text = cond1;
                state = "all";
                Label26.Visible = false;
                Ddl_Au.Visible = false;
                Label7.Text = "历史检验信息表";
                Grid_Material.Columns[15].Visible = false;
                Grid_Material.Columns[16].Visible = true;
                if (Session["UserRole"].ToString().Contains("进料检验维护"))
                {
                    Grid_Material.Columns[18].Visible = true;
                }
                else
                {
                    Grid_Material.Columns[18].Visible = false;
                }
                BindGrid1(cond1);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    #endregion

    #region 物料检索栏
    //检索栏检索按钮
    protected void BtnSearchMaterial_Click(object sender, EventArgs e)
    {
        string cond1 = Label30.Text  ;
        if (TextBox1.Text != "")
        {
            cond1 = cond1 + " AND IMMBD_SpecificationModel like '%' + LTRIM(RTRIM('" + TextBox1.Text + "')) + '%' ";
        }
        if (TxtMaterialName.Text != "")
        {
            cond1 = cond1 + " AND IMMBD_MaterialName like '%' + LTRIM(RTRIM('" + TxtMaterialName.Text + "')) + '%' ";
        }
        if (TxtMaterialCode.Text != "")
        {
            cond1 = cond1 + " AND IMISD_BatchNum  like '%"+ TxtMaterialCode.Text.ToString().Trim()+"%'" ;
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
        if (CheckBox1.Checked == true)
        {
            cond1 += " and DT.IQCDT_AResult='驳回'";
        }
        //if (Request.QueryString["state"].ToString() == "IQCAuMgtReview")
        //{
        //    state = "all";
        //    Label7.Text = "历史检验信息表";
        //    cond1 = cond1 + " and DT.IQCDT_Result is not null ";
        //}
        //else if (Request.QueryString["state"].ToString() == "IQCAuMgt")
        //{
        //    if (Ddl_Au.SelectedValue == "0")
        //    {
        //        state = "";
        //        cond1 = cond1 + " and DT.IQCDT_Result='待审核' ";
        //        Label7.Text = "待审核物料信息表";
        //    }
        //    else if (Ddl_Au.SelectedValue == "1")
        //    {
        //        state = "all";
        //        Label7.Text = "历史检验信息表";
        //    }
        //}
        //if (state == "")
        //{
        //    Grid_Material.Columns[14].Visible = true;
        //    Grid_Material.Columns[15].Visible = false;
        //}
        //else if (state == "all")
        //{
        //    Grid_Material.Columns[14].Visible = false;
        //    Grid_Material.Columns[15].Visible = true;
        //}
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
        //Ddl_Au.SelectedValue = "0";
        if (Request.QueryString["state"].ToString() == "IQCAuMgtReview")
        {
            state = "all";
            Label7.Text = "历史检验信息表";
               Label30.Text = " and DT.IQCDT_Result is not null ";
            Grid_Material.Columns[14].Visible =false ;
            Grid_Material.Columns[15].Visible = true;
        }
        else if (Request.QueryString["state"].ToString() == "IQCAuMgt")
        {
            if (Ddl_Au.SelectedValue == "0")
            {
                state = "";
                  Label30.Text =" and DT.IQCDT_Result='待审核' ";
                Label7.Text = "待审核物料信息表";
                Grid_Material.Columns[14].Visible = true;
                Grid_Material.Columns[15].Visible = false;
            }
            else if (Ddl_Au.SelectedValue == "1")
            {
                state = "all";
                   Label30.Text = "";
                Label7.Text = "历史检验信息表";
                Grid_Material.Columns[14].Visible =false ;
                Grid_Material.Columns[15].Visible = true;
            }
                //state = "";
                //cond1 = " and DT.IQCDT_Result='待审核' ";
                //Label7.Text = "待审核物料信息表";
                //Grid_Material.Columns[14].Visible = true;
                //Grid_Material.Columns[15].Visible = false;
        }
        BindGrid1(   Label30.Text );
        UpdatePanel_SearchMaterial.Update();
        UpdatePanel_GridMaterial.Update();
    }

    #endregion

    #region 物料表Grid1
    //操作Gridview的命令行
    protected void Grid_Material_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //查看检验结果
        if (e.CommandName == "View_CertDetail")
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Txt_CheckResult.Enabled = false;
            Txt_CheckSug.Enabled = false;
            TextBox2.Enabled = false;
            Grid_Material.SelectedIndex = row.RowIndex;
            Panel_NewExpApp.Visible = true;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string cond = " and DT.IMISD_ID='" + al[0] + "'";
            id_IMISD = new Guid(al[0]);
            Label32.Text = al[0];
            id_IMMBD_MaterialID = new Guid(al[2]);
            LblExpApp.Text = al[1] + " 检验结果";
            IQCBasicDataInfo IQC = iQCBasicDataL.Search_IMInStoreDetail_ViewAu(cond)[0];//超出索引？？？？原来此处grid略有不同
            TxtNewMaterialType.Text = IQC.IMMT_MaterialType;
            TxtNewMaterialName.Text = IQC.IMMBD_MaterialName;
            TxtNewMode.Text = IQC.IMMBD_SpecificationModel;
            TxtNewMaterialCode.Text = IQC.IMMBD_MaterialCode;
            TxtNewSupplyName.Text = IQC.PMSI_SupplyName;
            TxtActualNum.Text = Convert.ToString(IQC.IMIDS_ActualArrNum);
            TxtNewUnit.Text = IQC.UnitName;
            TxtNewArrivalTime.Text = Convert.ToString(IQC.IMISM_InStoreTime);
            TextBox2.Text = IQC.OP;
            Guid guid = new Guid(al[3]);
            IQCBasicDataInfo iqc = iQCBasicDataL.Search_IQCDetailTable(guid)[0];
            TxtNewNum.Text =Convert.ToString( iqc.IQCDT_Input);
            TxtTestPerson.Text = iqc.IQCDT_TestPer;
            Txt_CheckTime.Text =Convert.ToString( iqc.IQCDT_TestTime);
            Txt_CheckResult.SelectedValue = Grid_Material.DataKeys[row.RowIndex]["IQCDT_ProResult"].ToString();
            Txt_CheckSug.Text = iqc.IQCDT_Description;
            Grid_ETTestItem.DataSource = iQCBasicDataL.Search_IQCItemsTable(IQC.IMMBD_MaterialID);
            Grid_ETTestItem.DataBind();
            GridView2.DataSource = iQCBasicDataL.Search_WorkOrder(id_IMISD);
            GridView2.DataBind();
            UpdatePanel_NewExpApp.Update();
        }
        //审核
        if (e.CommandName == "New_Test")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Label33.Text = Grid_Material.Rows[row.RowIndex].Cells[8].ToString();
            Label37.Text = Grid_Material.Rows[row.RowIndex].Cells[8].ToString(); 
            Ddl_IsShengChan.Enabled = true;
            Label28.Visible = false;
            Ddl_IsShengChan.SelectedValue = "2";
            Ddl_IsShengChan.Enabled = false;
            DropDownList_Add_level.Enabled = true;
            Txt_AuTime.Enabled = true;
            Ddl_AuRe.Enabled = true;
            Txt_AuAug.Enabled = true;
            Txt_Jiangdang.Enabled = true;
            Button_Submit_Add.Visible = true;
            Panel_AddWorkOrder.Visible = true;
            Label3.Visible = false;
            Txt_AuTime.Visible = false;
            Label25.Visible = false;
            Txt_AuPer.Visible = false;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Lbl_Check.Text = al[1] + " 检验结果审核";
            id_IMISD = new Guid(al[0]);
            id_IMMBD_MaterialID = new Guid(al[2]);
            id_IQCDT_ID = new Guid(al[3]);
            Txt_AuPer.Text = "";
            Txt_AuAug.Text = "";
            Txt_Jiangdang.Text = "";
            Ddl_AuRe.SelectedValue = Grid_Material.DataKeys[row.RowIndex]["IQCDT_ProResult"].ToString(); 
            UpdatePanel_AddWorkOrder.Update();
        }
        //审核查看
        if (e.CommandName == "View_Au")
        {
            Label25.Visible = true;
            Txt_AuPer.Visible = true;
            Txt_AuPer.Enabled = false;
            Txt_AuTime.Enabled = false;
            Ddl_IsShengChan.Enabled = false;
            DropDownList_Add_level.Enabled = false;
            Ddl_AuRe.Enabled = false;
            Txt_AuAug.Enabled = false;
            Txt_Jiangdang.Enabled = false;
            Button_Submit_Add.Visible = false;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            id_IMISD = new Guid(al[0]);
            id_IMMBD_MaterialID = new Guid(al[2]);
            id_IQCDT_ID = new Guid(al[3]);
            IQCBasicDataInfo iqc = new IQCBasicDataInfo();
            try
            {
                 iqc = iQCBasicDataL.Search_IQCDetailTable_Au(id_IQCDT_ID)[0];
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该项尚未审核或不需要审核！')", true);
                return;
            }
            if (iqc.IQCDT_Auditor != "")
            {
                Panel_AddWorkOrder.Visible = true;
                Label3.Visible = true;
                Txt_AuTime.Visible = true;
                Lbl_Check.Text = al[1] + " 审核查看";
                Txt_AuPer.Text = iqc.IQCDT_Auditor;
                Txt_AuTime.Text = Convert.ToString(iqc.IQCDT_ATime);
                Txt_AuAug.Text = iqc.IQCDT_ASugg;
                Txt_Jiangdang.Text = iqc.IQCDT_DownDetail;
                BindDdl_AuRe(iqc.IQCDT_AResult, iqc.IQCDT_DownDetail);
                BindDdl_IsShengChan(iqc.WO_IsShengchan);
                UpdatePanel_AddWorkOrder.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该项尚未审核或不需要审核！')", true);
                return;
            }
        }
        if (e.CommandName == "Rin")
        {
           
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Material.SelectedIndex = row.RowIndex;
            if(Grid_Material.Rows[row.RowIndex].Cells[17].Text.ToString().Trim()!="驳回")
            {
             ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('此检验单没有被驳回，不需要重新录入检验结果！')", true);
             return;
            }
            Panel_NewExpApp.Visible = true;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string cond = " and DT.IMISD_ID='" + al[0] + "'";
            id_IMISD = new Guid(al[0]);
            Label32.Text = al[0];
           id_IMMBD_MaterialID = new Guid(al[2]);
            LblExpApp.Text = al[1] + " 检验结果";
            Label36.Text = al[3];
            IQCBasicDataInfo IQC = iQCBasicDataL.Search_IMInStoreDetail_ViewAu(cond)[0];//超出索引？？？？原来此处grid略有不同
            TxtNewMaterialType.Text = IQC.IMMT_MaterialType;
            TxtNewMaterialName.Text = IQC.IMMBD_MaterialName;
            TxtNewMode.Text = IQC.IMMBD_SpecificationModel;
            TxtNewMaterialCode.Text = IQC.IMMBD_MaterialCode;
            TxtNewSupplyName.Text = IQC.PMSI_SupplyName;
            TxtActualNum.Text = Convert.ToString(IQC.IMIDS_ActualArrNum);
            TxtNewUnit.Text = IQC.UnitName;
            TxtNewArrivalTime.Text = Convert.ToString(IQC.IMISM_InStoreTime);
            TextBox2.Text = IQC.OP;
            Guid guid = new Guid(al[3]);
            IQCBasicDataInfo iqc = iQCBasicDataL.Search_IQCDetailTable(guid)[0];
            TxtNewNum.Text = Convert.ToString(iqc.IQCDT_Input);
            TxtTestPerson.Text = iqc.IQCDT_TestPer;
            Txt_CheckTime.Text = Convert.ToString(iqc.IQCDT_TestTime);
            Txt_CheckResult.Text = Grid_Material.DataKeys[row.RowIndex]["IQCDT_ProResult"].ToString();
            Txt_CheckSug.Text = iqc.IQCDT_Description;
            Grid_ETTestItem.DataSource = iQCBasicDataL.Search_IQCItemsTable(IQC.IMMBD_MaterialID);
            Grid_ETTestItem.DataBind();
            GridView2.DataSource = iQCBasicDataL.Search_WorkOrder(id_IMISD);
            GridView2.DataBind();
            Txt_CheckSug.Enabled = true;
            TextBox2.Enabled = true;
            Txt_CheckResult.Enabled = true;
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
        //if (state == "")
        //{
        //    Label7.Text = "待审核物料信息表";
        //    Grid_Material.Columns[14].Visible = true;
        //    Grid_Material.Columns[15].Visible = false;
        //}
        //else if (state == "all")
        //{
        //    Label7.Text = "历史检验信息表";
        //    Grid_Material.Columns[14].Visible = false;
        //    Grid_Material.Columns[15].Visible = true;
        //}
        BindGrid1(   Label30.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Material.PageCount ? Grid_Material.PageCount - 1 : newPageIndex;
        Grid_Material.PageIndex = newPageIndex;
        Grid_Material.DataBind();
    }
    #endregion

    #region 审核栏
    //提交按钮
    protected void Btn_Submit_Add_Click(object sender, EventArgs e)
    {
        IQCBasicDataInfo IQC = new IQCBasicDataInfo();
        IQC.IMISD_ID = id_IMISD;
        IQC.IMMBD_MaterialID = id_IMMBD_MaterialID;
        IQC.IQCDT_ID = id_IQCDT_ID;
        IQC.IQCDT_Auditor = Session["UserName"].ToString();
        if (Ddl_AuRe.SelectedItem.ToString() == "请选择")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else
        {            
            if(Ddl_AuRe.SelectedItem.ToString()=="降档")
            {
                if(Txt_Jiangdang.Text.Trim()=="")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
            }
            IQC.IQCDT_DownDetail = Txt_Jiangdang.Text.Trim();
            IQC.IMIDS_QA=Ddl_AuRe.SelectedItem.ToString();
            IQC.IQCDT_Result=Ddl_AuRe.SelectedItem.ToString();
            IQC.IQCDT_AResult =Ddl_AuRe.SelectedItem.ToString();
        }
        IQC.IQCDT_ASugg = Txt_AuAug.Text.Trim();

        //if (this.Ddl_IsShengChan.SelectedItem.ToString() == "请选择")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
        //    return;
        //}
        //else
        //{
            IQCBasicDataInfo iqc = new IQCBasicDataInfo();
            //if (Ddl_IsShengChan.SelectedItem.ToString() == "是")
            //    iqc.State = "1";
            //else if (Ddl_IsShengChan.SelectedItem.ToString() == "否")
            iqc.State = "2";
            iqc.IQCDT_ID = id_IQCDT_ID;
            iqc.WO_Level = DropDownList_Add_level.SelectedItem.ToString();
            try
            {
                iQCBasicDataL.Update_WorkOrder_IQC(iqc);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;
            }
        //}
        try
        {
            if (iQCBasicDataL.Update_IMInStoreDetail_IQCAU(IQC) <= 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
            return;
        }
        BindGrid1(   Label30.Text );
        UpdatePanel_GridMaterial.Update();
        Panel_AddWorkOrder.Visible = false;
        UpdatePanel_AddWorkOrder.Update();
    }

    //关闭按钮
    protected void Button_CancelAdd_Click(object sender, EventArgs e)
    {
        Panel_AddWorkOrder.Visible = false;
        UpdatePanel_AddWorkOrder.Update();
    }

    #endregion

    #region 检验项目表Grid
    //操作Gridview的命令行
    protected void Grid_ETTestItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edit_ItemAmount")
        {
            Panel_Standard.Visible = true;
            id_IQCIT_ID = new Guid(e.CommandArgument.ToString());
            Grid_Standard.DataSource = iQCBasicDataL.Search_IQCStandardTable_Grid(id_IQCIT_ID, id_IMISD);
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

    #region 检验标准栏
    
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
        Grid_Standard.DataSource = iQCBasicDataL.Search_IQCStandardTable_Grid(id_IQCIT_ID, id_IMISD);
        Grid_Standard.DataBind();
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

        Grid_Material.DataSource = iQCBasicDataL.Search_IMInStoreDetail_Au(Condition);
        Grid_Material.DataBind();
    }

    //审核栏下拉框控制
    private void BindDdl_AuRe(string cond1,string cond2)
    {
        Label5.Visible = false;
        Label24.Visible = false;
        Txt_Jiangdang.Visible = false;
        Label28.Visible = false;
        if (cond1 == "合格")
            Ddl_AuRe.SelectedValue = cond1;
        else if (cond1 == "降档")
        {
            Ddl_AuRe.SelectedValue = cond1;
            Txt_Jiangdang.Text = cond2;
            Label5.Visible = true;
            Label24.Visible = true;
            Txt_Jiangdang.Visible = true;
            Label28.Visible = true;
        }
        else if (cond1 == "不合格")
            Ddl_AuRe.SelectedValue = cond1;
        else if (cond1 == "让步接收")
            Ddl_AuRe.SelectedValue = cond1;
        else if (cond1 == "二次检验")
            Ddl_AuRe.SelectedValue = cond1;
        else
            Ddl_AuRe.SelectedValue = cond1;
    }

    //审核栏下拉框控制
    private void BindDdl_IsShengChan(Int32 WO_IsShengchan)
    {
        Label11.Visible = false;
        DropDownList_Add_level.Visible = false;
        if (WO_IsShengchan == 0)
            Ddl_IsShengChan.SelectedValue = "2";
        else if (WO_IsShengchan == 1)
        {
            Ddl_IsShengChan.SelectedValue = "1";
            Label11.Visible = true;
            DropDownList_Add_level.Visible = true;
        }
        else if (WO_IsShengchan == 2)
            Ddl_IsShengChan.SelectedValue = "0";
    }
    #endregion

    //两个关闭是按钮，一行数据上青天；
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        Panel_Standard.Visible = false;
        UpdatePanel_Standard.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
    }
    protected void Btn_Close2_Click(object sender, EventArgs e)
    {
        Panel_Standard.Visible = false;
        UpdatePanel_Standard.Update();

    }
    protected void Ddl_AuRe_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_AuRe.SelectedValue == "降档")
        {
            Label5.Visible = true;
            Label24.Visible = true;
            Txt_Jiangdang.Visible = true;
            Label28.Visible = true;
        }
        else
        {
            Label5.Visible = false;
            Label24.Visible = false;
            Txt_Jiangdang.Visible = false;
            Label28.Visible = false;
        }
    }

    protected void Ddl_IsShengChan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_IsShengChan.SelectedItem.ToString() == "是")
        {
            Label11.Visible = true;
            DropDownList_Add_level.Visible = true;
        }
        else
        {
            Label11.Visible = false;
            DropDownList_Add_level.Visible = false;
        }
        UpdatePanel_AddWorkOrder.Update();
    }
    //驳回
    protected void Btn_Submit_Refuse_Click(object sender, EventArgs e)
    {
        Guid id = id_IQCDT_ID;
        string op = Txt_AuAug.Text;
        iQCBasicDataL.Update_IQCDT_Refuse(id, op);
        BindGrid1(Label30.Text);
        UpdatePanel_GridMaterial.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('驳回成功，并已通知检验员！')", true);
        Panel_AddWorkOrder.Visible = false;
        UpdatePanel_AddWorkOrder.Update();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "驳回了批号为："+Label37.Text.ToString() +"的入库检验单，请在进料检验查看页面中重新录入检验结果！";
        string sErr = RTXhelper.Send(remind, "进料检验维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void BtnSubmit1_Click(object sender, EventArgs e)
    {
        Guid id = new Guid(Label36.Text.ToString());
        string result = Txt_CheckResult.SelectedValue.ToString();
        string op = Txt_CheckSug.Text;
        string op1 = TextBox2.Text;
        iQCBasicDataL.Update_IQCDT_Result(id, result, op, op1);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了新的入库检验单，请及时进行审核！";
        string sErr = RTXhelper.Send(remind, "进料检验审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        BindGrid1(Label30.Text);
        UpdatePanel_GridMaterial.Update();
    }
}

