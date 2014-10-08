using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProductionBasicInfo_PBProType : Page
{
    ProSeriesInfo_ProTypeInfo pplinfo = new ProSeriesInfo_ProTypeInfo();
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    SalesMonthPlanL mp = new SalesMonthPlanL();
    WorkOrderL wol = new WorkOrderL();
    WorkOrderInfo woinfo = new WorkOrderInfo();
    IPSD ip = new IPSD();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

            if (state == "specialmake")
            {
                Panel_Search.Visible = false;
                UpdatePanel_Search.Update();
                Button_Add.Visible = false;
                Button_returnspecial.Visible = true;

            }
            if (state == "speciallook")
            {
                Panel_Search.Visible = false;
                UpdatePanel_Search.Update();
                Button_Add.Visible = false;
                GridView2.Columns[14].Visible = false;
                GridView2.Columns[15].Visible = false;
                Txt_parameter.Enabled = false;
                Txt_PassRate.Enabled = false;
                TextBox_Note.Enabled = false;
                Btn_I_parameter.Visible = false;
                Btn_U_parameter.Visible = false;
                Button_returnspecial.Visible = true;
            }
            if (state == "look")
            {
                Title = "产品型号查看";
                GridView2.Columns[14].Visible = false;
                GridView2.Columns[15].Visible = false;

                Button_Add.Visible = false;
                Txt_parameter.Enabled = false;
                Txt_PassRate.Enabled = false;
                TextBox_Note.Enabled = false;

                Btn_I_parameter.Visible = false;
                Btn_U_parameter.Visible = false;

            }
            if (state == "manage")
            {
                Title = "产品型号管理";
            }


            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("产品型号查看")) || (Session["UserRole"].ToString().Contains("产品型号维护"))))
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("产品型号维护"))
                    {


                        Title = "产品型号查看";
                        GridView2.Columns[12].Visible = false;
                        GridView2.Columns[13].Visible = false;

                        Button_Add.Visible = false;
                        Txt_parameter.Enabled = false;
                        Txt_PassRate.Enabled = false;
                        TextBox_Note.Enabled = false;

                        Btn_I_parameter.Visible = false;
                        Btn_U_parameter.Visible = false;

                    }
                    if (state == "specialmake")
                    {
                        if (Request.QueryString["PT_ID"] == null)
                        {
                            ptid.Text = "00000000-0000-0000-0000-000000000000";

                        }
                        else
                        {
                            ptid.Text = Request.QueryString["PT_ID"];

                        }
                        GridView2.DataSource = ppl.S_ProType_new(" and PT_ID='" + ptid.Text + "'");
                        GridView2.DataBind();
                    }
                    if (state == "speciallook")
                    {

                        if (Request.QueryString["PT_ID"] == null)
                        {
                            ptid.Text = "00000000-0000-0000-0000-000000000000";

                        }
                        else
                        {
                            ptid.Text = Request.QueryString["PT_ID"];

                        }
                        GridView2.DataSource = ppl.S_ProType_new(" and PT_ID='" + ptid.Text + "'");
                        GridView2.DataBind();

                    }
                    if (state != "speciallook" && state != "specialmake")
                    {
                        GridView2.DataSource = ppl.S_ProType_new("");
                        GridView2.DataBind();
                    }



                    DropDownList01.DataSource = ppl.S_PTCB_Detail("", "1");
                    DropDownList01.DataTextField = "PTCB_Detail";
                    DropDownList01.DataValueField = "PTCB_Code";
                    DropDownList01.DataBind();
                    DropDownList01.Items.Insert(0, new ListItem(" ", " "));

                    DropDownList01.ToolTip = DropDownList01.SelectedValue.ToString();
                    DropDownList02.DataSource = ppl.S_PTCB_Detail("", "2");
                    DropDownList02.DataTextField = "PTCB_Detail";
                    DropDownList02.DataValueField = "PTCB_Code";
                    DropDownList02.DataBind();
                    DropDownList02.Items.Insert(0, new ListItem("  ", "  "));
                    DropDownList02.ToolTip = DropDownList02.SelectedValue.ToString();

                    DropDownList03.DataSource = ppl.S_PTCB_Detail("", "3");
                    DropDownList03.DataTextField = "PTCB_Detail";
                    DropDownList03.DataValueField = "PTCB_Code";
                    DropDownList03.DataBind();
                    DropDownList03.Items.Insert(0, new ListItem("  ", "  "));
                    DropDownList03.ToolTip = DropDownList03.SelectedValue.ToString();

                    DropDownList04.DataSource = ppl.S_PTCB_Detail("", "4");
                    DropDownList04.DataTextField = "PTCB_Detail";
                    DropDownList04.DataValueField = "PTCB_Code";
                    DropDownList04.DataBind();
                    DropDownList04.Items.Insert(0, new ListItem("  ", "  "));
                    DropDownList04.ToolTip = DropDownList04.SelectedValue.ToString();

                    DropDownList05.DataSource = ppl.S_PTCB_Detail("", "5");
                    DropDownList05.DataTextField = "PTCB_Detail";
                    DropDownList05.DataValueField = "PTCB_Code";
                    DropDownList05.DataBind();
                    DropDownList05.Items.Insert(0, new ListItem(" ", " "));
                    DropDownList05.ToolTip = DropDownList05.SelectedValue.ToString();

                    DropDownList06.DataSource = ppl.S_PTCB_Detail("", "6");
                    DropDownList06.DataTextField = "PTCB_Detail";
                    DropDownList06.DataValueField = "PTCB_Code";
                    DropDownList06.DataBind();
                    DropDownList06.Items.Insert(0, new ListItem("  ", "  "));
                    DropDownList06.ToolTip = DropDownList06.SelectedValue.ToString();

                    DropDownList07.DataSource = ppl.S_PTCB_Detail("", "7");
                    DropDownList07.DataTextField = "PTCB_Detail";
                    DropDownList07.DataValueField = "PTCB_Code";
                    DropDownList07.DataBind();
                    DropDownList07.Items.Insert(0, new ListItem(" ", " "));
                    DropDownList07.ToolTip = DropDownList07.SelectedValue.ToString();

                    DropDownList08.DataSource = ppl.S_PTCB_Detail("", "8");
                    DropDownList08.DataTextField = "PTCB_Detail";
                    DropDownList08.DataValueField = "PTCB_Code";
                    DropDownList08.DataBind();
                    DropDownList08.Items.Insert(0, new ListItem(" ", " "));
                    DropDownList08.ToolTip = DropDownList08.SelectedValue.ToString();

                    DropDownList09.DataSource = ppl.S_PTCB_Detail("", "9");
                    DropDownList09.DataTextField = "PTCB_Detail";
                    DropDownList09.DataValueField = "PTCB_Code";
                    DropDownList09.DataBind();
                    DropDownList09.Items.Insert(0, new ListItem(" ", " "));
                    DropDownList09.ToolTip = DropDownList09.SelectedValue.ToString();

                    DropDownList10.DataSource = ppl.S_PTCB_Detail("", "10");
                    DropDownList10.DataTextField = "PTCB_Detail";
                    DropDownList10.DataValueField = "PTCB_Code";
                    DropDownList10.DataBind();
                    DropDownList10.Items.Insert(0, new ListItem(" ", " "));
                    DropDownList10.ToolTip = DropDownList10.SelectedValue.ToString();

                    DropDownList11.DataSource = ppl.S_PTCB_Detail("", "11");
                    DropDownList11.DataTextField = "PTCB_Detail";
                    DropDownList11.DataValueField = "PTCB_Code";
                    DropDownList11.DataBind();
                    DropDownList11.Items.Insert(0, new ListItem("  ", "  "));
                    DropDownList11.ToolTip = DropDownList11.SelectedValue.ToString();
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                    Response.Redirect("~/Default.aspx");

                }



            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    public void databind1()
    {
        string condition;
        string PS_Name = Txt_search.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + Txt_search.Text.Trim() + "%' ";
        string PT_Name = Txt_search0.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + Txt_search0.Text.Trim() + "%' ";
        string BOM_Name = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and BOM_Name like '%" + TextBox1.Text.Trim() + "%' ";
        string PR_Name = TextBox2.Text.Trim() == "" ? " and 1=1 " : " and PR_Name like '%" + TextBox2.Text.Trim() + "%' ";
        string PT_Special = DropDownList1.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and PT_Special like '%" + DropDownList1.SelectedItem.Text.Trim() + "%' ";
        string PT_Man = Txt_search1.Text.Trim() == "" ? " and 1=1 " : " and PT_Man like '%" + Txt_search1.Text.Trim() + "%' ";
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将随工单生成时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string PT_Time = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and PT_Time between   ' " + TextBox_WO_Time1.Text.Trim() + "' and ' " + TextBox_WO_Time2.Text.Trim() + "'";
        condition = PS_Name + PT_Name + BOM_Name + PR_Name + PT_Special + PT_Man + PT_Time;
        GridView2.DataSource = ppl.S_ProType_new(condition);
        GridView2.DataBind();
        UpdatePanel_PT.Update();
    }

    public void databind2()
    {
        string condition;
        string PS_Name = TextBox5.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + TextBox5.Text.Trim() + "%' ";
        string PT_Name = TextBox6.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox6.Text.Trim() + "%' ";
        condition = PS_Name + PT_Name + " and PT_Parameters is not null and rtrim(ltrim(PT_Parameters))!=''";
        GridView1.DataSource = ppl.S_ProType_new(condition);
        GridView1.DataBind();
        UpdatePanel1.Update();
    }



    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                if (j != 2)
                {
                    GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                    if (GridView2.Rows[i].Cells[j].Text.Length > 7)
                    {
                        GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 7) + "...";
                    }
                }

            }
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        //绑定数据源
        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        // specify the NewPageIndex
        GridView2.PageIndex = newPageIndex;
        databind1();

        GridView2.SelectedIndex = -1;

        //panel 隐藏
        Panel_AddPT.Visible = false;
        UpdatePanel_AddPT.Update();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        databind1();
        GridView2.PageIndex = 0;
        GridView2.SelectedIndex = -1;

        //panel 隐藏
        Panel_AddPT.Visible = false;
        UpdatePanel_AddPT.Update();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
    }

    protected void Button_Add_Click(object sender, EventArgs e)
    {
        Panel_AddPT.Visible = true;

        Label_submitState.Text = "新增";
        DropDownList2.DataSource = ppl.SList_ProSeries();
        DropDownList2.DataTextField = "PS_Name";
        DropDownList2.DataValueField = "PS_ID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

        DropDownList_BOM.DataSource = ppl.S_BOM_Name();
        DropDownList_BOM.DataTextField = "BOM_Name";
        DropDownList_BOM.DataValueField = "BOM_ID";
        DropDownList_BOM.DataBind();
        DropDownList_BOM.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

        DropDownList_PR.DataSource = ppl.S_PR_Name();
        DropDownList_PR.DataTextField = "PR_Name";
        DropDownList_PR.DataValueField = "PR_ID";
        DropDownList_PR.DataBind();
        DropDownList_PR.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));


        GridViewips.Visible = false;
        cscs.Visible = false;
        DropDownList12.DataSource = ip.S_IPSMain("");//测试参数类别
        DropDownList12.DataTextField = "IPSM_ID";
        DropDownList12.DataValueField = "IPSM_Type";
        DropDownList12.DataBind();
        DropDownList12.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

        DropDownList13.DataSource = ip.S_IPSDetail(new Guid(DropDownList12.SelectedValue.ToString().Trim()));//测试参数类别详细
        DropDownList13.DataTextField = "IPSD_ID";
        DropDownList13.DataValueField = "IPSD_Type";
        DropDownList13.DataBind();
        DropDownList13.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));


        DropDownList01.SelectedIndex = 0;
        DropDownList02.SelectedIndex = 0;
        DropDownList03.SelectedIndex = 0;
        DropDownList04.SelectedIndex = 0;
        DropDownList05.SelectedIndex = 0;
        DropDownList06.SelectedIndex = 0;
        DropDownList07.SelectedIndex = 0;
        DropDownList08.SelectedIndex = 0;
        DropDownList09.SelectedIndex = 0;
        DropDownList10.SelectedIndex = 0;
        DropDownList11.SelectedIndex = 0;

        Txt_PT.Text = "";
        DropDownList2.SelectedIndex = 0;
        DropDownList_BOM.SelectedIndex = 0;
        DropDownList_PR.SelectedIndex = 0;
        DropDownList_Special.SelectedIndex = 0;
        TextBox4.Text = "";
        TextBox3.Text = "";
        UpdatePanel_AddPT.Update();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
    }
    protected void Btn_CancelPT_Click(object sender, EventArgs e)
    {

        Panel_AddPT.Visible = false;
        UpdatePanel_AddPT.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        Txt_search.Text = "";
        Txt_search0.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        DropDownList1.SelectedIndex = 0;
        Txt_search1.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        databind1();

        GridView2.PageIndex = 0;
        GridView2.SelectedIndex = -1;

        //panel 隐藏
        Panel_AddPT.Visible = false;
        UpdatePanel_AddPT.Update();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
    }
    protected void Btn_AddPTSubmit_Click(object sender, EventArgs e)
    {
        if (Txt_PT.Text == "" || DropDownList2.SelectedIndex == 0 || DropDownList_BOM.SelectedIndex == 0 || DropDownList_PR.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('*项目必须输入完整，请再次核对！')", true);
            return;
        }
        string code = DropDownList01.SelectedValue.ToString().Trim() +
          DropDownList02.SelectedValue.ToString().Trim() +
          DropDownList03.SelectedValue.ToString().Trim() +
          DropDownList04.SelectedValue.ToString().Trim() +
          DropDownList05.SelectedValue.ToString().Trim() +
          DropDownList06.SelectedValue.ToString().Trim() +
          DropDownList07.SelectedValue.ToString().Trim() +
          DropDownList08.SelectedValue.ToString().Trim() +
          DropDownList09.SelectedValue.ToString().Trim() +
          DropDownList10.SelectedValue.ToString().Trim() +
          DropDownList11.SelectedValue.ToString().Trim();
        if (code.Trim() != "")
        {
            if (code.Trim().Length != 19)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('产品编码可以不选择，但如要选择则必须将每一位编码选择完！请核对是否有为空的值！')", true);
                return;
            }
        }
        string pt_name = "PT_Name ='" + Txt_PT.Text.Trim() + "'";
        DataSet ds = ppl.S_ProSeries_ProType(pt_name);
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;

        string PT_Code = "PT_Code ='" + code.Trim() + "'";
        DataSet ds2 = ppl.S_ProSeries_ProType(PT_Code);
        DataTable dt2 = ds2.Tables[0];
        DataView dv2 = ds2.Tables[0].DefaultView;

        if (Label_submitState.Text == "编辑")
        {
            if (dt.Rows.Count != 0 && Label_ptname.Text != Txt_PT.Text)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产品型号名称，不能重名！')", true);
                return;
            }
            if (dt2.Rows.Count != 0 && Label_code.Text != code)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产品编码，不能重复！')", true);
                return;
            }
        }
        if (Label_submitState.Text == "新增")
        {
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产品型号名称，不能重名！')", true);
                return;
            }
            if (dt2.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该产品编码，不能重复！')", true);
                return;
            }
        }
        //if (this.DropDownList_BOM.SelectedValue == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请选择BOM（物料清单）！')", true);
        //    return;
        //}
        //if (this.DropDownList_PR.SelectedValue == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请选择工艺路线！')", true);
        //    return;
        //}
        pplinfo.PS_ID = new Guid(DropDownList2.SelectedValue.ToString().Trim());
        pplinfo.PT_Name = Txt_PT.Text.Trim();
        pplinfo.PT_Special = DropDownList_Special.SelectedItem.Text.Trim();
        pplinfo.BOM_ID = new Guid(DropDownList_BOM.SelectedValue);
        pplinfo.PR_ID = new Guid(DropDownList_PR.SelectedValue);
        pplinfo.PT_Man = Session["UserName"].ToString();
        pplinfo.PT_Note = TextBox4.Text.Trim();

        if (Label_submitState.Text == "新增")
        {
            ppl.I_ProType_new(pplinfo, TextBox3.Text.Trim(), code);
            Txt_PT.Text = "";
            DropDownList_PR.SelectedIndex = -1;
            DropDownList_BOM.SelectedIndex = -1;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您已添加成功！')", true);
            GridView2.SelectedIndex = -1;
        }
        if (Label_submitState.Text == "编辑")
        {
            pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
            //DataSet ds0 = ppl.S_ProType_WorkOrder(this.Label_ptname.Text.Trim());
            //DataTable dt0 = ds0.Tables[0];
            //if (dt0.Rows.Count != 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('随工单中已有该产品型号信息，如需修改其它名字只能另外新增一条，不能修改名称！')", true);
            //    return;
            //}

            ppl.U_ProType_new(pplinfo, TextBox3.Text.Trim(), code);
            Txt_PT.Text = "";
            DropDownList_PR.SelectedIndex = -1;
            DropDownList_BOM.SelectedIndex = -1;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您已修改成功！')", true);
            GridView2.SelectedIndex = -1;
        }

        databind1();

        Panel_AddPT.Visible = false;
    }
    protected void GridView_bom_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_bom.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_bom.Rows[i].Cells.Count; j++)
            {
                GridView_bom.Rows[i].Cells[j].ToolTip = GridView_bom.Rows[i].Cells[j].Text;
                if (GridView_bom.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_bom.Rows[i].Cells[j].Text = GridView_bom.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void GridView_Pr_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Batch_Num")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Pr.SelectedIndex = row.RowIndex;

            string[] a = e.CommandArgument.ToString().Split(new char[] { ',' });
            string pbcid = a[0];
            Label_PBCID.Text = pbcid;
            Panel_CheckParameter.Visible = true;
            UpdatePanel_CheckParameter.Update();
            Guid guid_id = new Guid(pbcid);
            DataSet ds = ppl.S_ProProcessParameter(new Guid(Label_PT_ID.Text.Trim()), guid_id);
            DataTable dt = ds.Tables[0];
            DataView dv = ds.Tables[0].DefaultView;
            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您尚未制定工艺参数或合格率标准，请先输入相关参数并制定！您将看到参考的工艺参数和合格率标准')", true);

                DataSet ds2 = ppl.S_PBCraftInfo(new Guid(Label_PBCID.Text));
                DataTable dt2 = ds2.Tables[0];
                DataView dv2 = ds2.Tables[0].DefaultView;
                foreach (DataRowView datav in dv2)
                {
                    Txt_parameter.Text = datav["PBC_Parameter"].ToString().Trim();
                    Txt_PassRate.Text = datav["PBC_PassRate"].ToString().Trim();

                }
                // this.Txt_parameter.Text = "";
                // this.Txt_PassRate.Text = "";
                TextBox_Note.Text = "";
                if (!Session["UserRole"].ToString().Contains("产品基础信息维护"))
                {
                    Panel_CheckParameter.Visible = false;
                    UpdatePanel_CheckParameter.Update();
                }
                return;
            }

            foreach (DataRowView datav in dv)
            {
                Txt_parameter.Text = datav["PPP_Parameter"].ToString().Trim();
                Txt_PassRate.Text = datav["PPP_PassRate"].ToString().Trim();
                TextBox_Note.Text = datav["PPP_Note"].ToString().Trim();

            }
            Label_PT2.Text = Label_PT.Text + " " + a[1] + " ";



        }
    }

    protected void GridView_Pr_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Pr.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Pr.Rows[i].Cells.Count; j++)
            {
                GridView_Pr.Rows[i].Cells[j].ToolTip = GridView_Pr.Rows[i].Cells[j].Text;
                if (GridView_Pr.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_Pr.Rows[i].Cells[j].Text = GridView_Pr.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void Btn_Close_ChooseBatch0_Click(object sender, EventArgs e)
    {
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
    }
    protected void Btn_I_parameter_Click(object sender, EventArgs e)
    {
        try
        { decimal a = Convert.ToDecimal(Txt_PassRate.Text); }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合格率标准必须是小数形式')", true);
            return;
        }


        if (Convert.ToDecimal(Txt_PassRate.Text) > 1 || Convert.ToDecimal(Txt_PassRate.Text) < 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合格率标准应该是0至1之间的小数形式')", true);
            return;
        }
        DataSet ds = ppl.S_ProProcessParameter(new Guid(Label_PT_ID.Text.Trim()), new Guid(Label_PBCID.Text.Trim()));
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('已经制定过了工艺参数或合格率标准，您只能修改')", true);
            //return;
            pplinfo.PPP_Parameter = Txt_parameter.Text;
            pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
            pplinfo.PBC_ID = new Guid(Label_PBCID.Text.Trim());
            pplinfo.PPP_Note = TextBox_Note.Text;
            pplinfo.PPP_PassRate = Convert.ToDecimal(Txt_PassRate.Text);
            ppl.U_ProProcessParameter(pplinfo);


        }
        else
        {
            pplinfo.PPP_Parameter = Txt_parameter.Text;
            pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
            pplinfo.PBC_ID = new Guid(Label_PBCID.Text.Trim());
            pplinfo.PPP_Note = TextBox_Note.Text;
            pplinfo.PPP_PassRate = Convert.ToDecimal(Txt_PassRate.Text);
            ppl.I_ProProcessParameter(pplinfo);

        }
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功')", true);
        GridView_Pr.SelectedIndex = -1;
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        Txt_parameter.Text = "";
        Txt_PassRate.Text = "";
        TextBox_Note.Text = "";
    }
    protected void Button_Close_CheckParameter_Click(object sender, EventArgs e)
    {
        Panel_CheckParameter.Visible = false;
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        Txt_parameter.Text = "";
        Txt_PassRate.Text = "";
        GridView_Pr.SelectedIndex = -1;
    }
    protected void Btn_U_parameter_Click(object sender, EventArgs e)
    {
        DataSet ds = ppl.S_ProProcessParameter(new Guid(Label_PT_ID.Text.Trim()), new Guid(Label_PBCID.Text.Trim()));
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改失败！您尚未制定工艺参数或合格率标准，您需要先制定！')", true);
            return;
        }
        if (Convert.ToDecimal(Txt_PassRate.Text) > 1 || Convert.ToDecimal(Txt_PassRate.Text) <= 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('合格率标准应该是0至1之间的小数形式')", true);
            return;
        }
        pplinfo.PPP_Parameter = Txt_parameter.Text;
        pplinfo.PT_ID = new Guid(Label_PT_ID.Text.Trim());
        pplinfo.PBC_ID = new Guid(Label_PBCID.Text.Trim());
        pplinfo.PPP_Note = TextBox_Note.Text;
        pplinfo.PPP_PassRate = Convert.ToDecimal(Txt_PassRate.Text);
        ppl.U_ProProcessParameter(pplinfo);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功')", true);
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
        Txt_parameter.Text = "";
        Txt_PassRate.Text = "";
        TextBox_Note.Text = "";
    }
    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check_Parameter")
        {
            //GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            //GridView2.SelectedIndex = row.RowIndex;

            ////无关信息隐藏

            //this.Panel_AddPS.Visible = false;
            //this.Panel_AddPT.Visible = false;
            //this.Panel_CheckParameter.Visible = false;


            //this.UpdatePanel_AddPS.Update();
            //this.UpdatePanel_AddPT.Update();
            //this.UpdatePanel_CheckParameter.Update();



            //GridView_Parameter.SelectedIndex = -1;

            //string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            //string prid = al[0];
            //this.Label_PRID.Text = prid;
            //string ptname = al[1];
            //string ptid = al[2];
            //this.Label_PTP.Text = ptname;
            //this.Label_PT_ID.Text = ptid;
            //Panel_Parameter.Visible = true;
            //if (prid == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('该产品尚未制定工艺路线！')", true);
            //    return;
            //}
            //Guid guid_id = new Guid(prid);
            //this.GridView_Parameter.DataSource = ppl.S_ProType_ProcessRoute(guid_id);
            //this.GridView_Parameter.DataBind();
            //UpdatePanel_Parameter.Update();

        }
        if (e.CommandName == "Delete_PT")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;




            //panel 隐藏
            Panel_AddPT.Visible = false;
            UpdatePanel_AddPT.Update();
            Panel_basic.Visible = false;
            UpdatePanel_basic.Update();
            Panel_CheckParameter.Visible = false;
            UpdatePanel_CheckParameter.Update();
            //如果随工单中有该产品型号信息，需要做一个判断。
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ptname = al[1].Trim();
            DataSet ds = ppl.S_ProType_WorkOrder(ptname);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('随工单中已有该产品型号信息了，不能再删除！')", true);
                return;
            }

            Guid guid_id = new Guid(al[0].Trim());
            ppl.D_ProType(guid_id);
            databind1();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            //无关信息隐藏

            GridView2.PageIndex = 0;
            GridView2.SelectedIndex = -1;
        }
        if (e.CommandName == "Edit123")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            //无关信息隐藏

            //panel 隐藏
            Panel_AddPT.Visible = true;

            Panel_basic.Visible = false;
            UpdatePanel_basic.Update();
            Panel_CheckParameter.Visible = false;
            UpdatePanel_CheckParameter.Update();

            GridViewips.Visible = true;
            cscs.Visible = true;




            DropDownList2.DataSource = ppl.SList_ProSeries();
            DropDownList2.DataTextField = "PS_Name";
            DropDownList2.DataValueField = "PS_ID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

            DropDownList_BOM.DataSource = ppl.S_BOM_Name();
            DropDownList_BOM.DataTextField = "BOM_Name";
            DropDownList_BOM.DataValueField = "BOM_ID";
            DropDownList_BOM.DataBind();
            DropDownList_BOM.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

            DropDownList_PR.DataSource = ppl.S_PR_Name();
            DropDownList_PR.DataTextField = "PR_Name";
            DropDownList_PR.DataValueField = "PR_ID";
            DropDownList_PR.DataBind();
            DropDownList_PR.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

            //DropDownList01.DataSource = ppl.S_PTCB_Detail("", "1");
            //DropDownList01.DataTextField = "PTCB_Code";
            //DropDownList01.DataValueField = "PTCB_Detail";
            //DropDownList01.DataBind();
            //DropDownList01.ToolTip = DropDownList01.SelectedValue.ToString();
            //DropDownList01.Items.Insert(0, new ListItem(" ", " "));

            //DropDownList02.DataSource = ppl.S_PTCB_Detail("", "2");
            //DropDownList02.DataTextField = "PTCB_Code";
            //DropDownList02.DataValueField = "PTCB_Detail";
            //DropDownList02.DataBind();
            //DropDownList02.ToolTip = DropDownList02.SelectedValue.ToString();
            //DropDownList02.Items.Insert(0, new ListItem("  ", "  "));

            //DropDownList03.DataSource = ppl.S_PTCB_Detail("", "3");
            //DropDownList03.DataTextField = "PTCB_Code";
            //DropDownList03.DataValueField = "PTCB_Detail";
            //DropDownList03.DataBind();
            //DropDownList03.ToolTip = DropDownList03.SelectedValue.ToString();
            //DropDownList03.Items.Insert(0, new ListItem("  ", "  "));

            //DropDownList04.DataSource = ppl.S_PTCB_Detail("", "4");
            //DropDownList04.DataTextField = "PTCB_Code";
            //DropDownList04.DataValueField = "PTCB_Detail";
            //DropDownList04.DataBind();
            //DropDownList04.ToolTip = DropDownList04.SelectedValue.ToString();
            //DropDownList04.Items.Insert(0, new ListItem("  ", "  "));

            //DropDownList05.DataSource = ppl.S_PTCB_Detail("", "5");
            //DropDownList05.DataTextField = "PTCB_Code";
            //DropDownList05.DataValueField = "PTCB_Detail";
            //DropDownList05.DataBind();
            //DropDownList05.ToolTip = DropDownList05.SelectedValue.ToString();
            //DropDownList05.Items.Insert(0, new ListItem(" ", " "));

            //DropDownList06.DataSource = ppl.S_PTCB_Detail("", "6");
            //DropDownList06.DataTextField = "PTCB_Code";
            //DropDownList06.DataValueField = "PTCB_Detail";
            //DropDownList06.DataBind();
            //DropDownList06.ToolTip = DropDownList06.SelectedValue.ToString();
            //DropDownList06.Items.Insert(0, new ListItem("  ", "  "));

            //DropDownList07.DataSource = ppl.S_PTCB_Detail("", "7");
            //DropDownList07.DataTextField = "PTCB_Code";
            //DropDownList07.DataValueField = "PTCB_Detail";
            //DropDownList07.DataBind();
            //DropDownList07.ToolTip = DropDownList07.SelectedValue.ToString();
            //DropDownList07.Items.Insert(0, new ListItem(" ", " "));

            //DropDownList08.DataSource = ppl.S_PTCB_Detail("", "8");
            //DropDownList08.DataTextField = "PTCB_Code";
            //DropDownList08.DataValueField = "PTCB_Detail";
            //DropDownList08.DataBind();
            //DropDownList08.ToolTip = DropDownList08.SelectedValue.ToString();
            //DropDownList08.Items.Insert(0, new ListItem(" ", " "));

            //DropDownList09.DataSource = ppl.S_PTCB_Detail("", "9");
            //DropDownList09.DataTextField = "PTCB_Code";
            //DropDownList09.DataValueField = "PTCB_Detail";
            //DropDownList09.DataBind();
            //DropDownList09.ToolTip = DropDownList09.SelectedValue.ToString();
            //DropDownList09.Items.Insert(0, new ListItem(" ", " "));

            //DropDownList10.DataSource = ppl.S_PTCB_Detail("", "10");
            //DropDownList10.DataTextField = "PTCB_Code";
            //DropDownList10.DataValueField = "PTCB_Detail";
            //DropDownList10.DataBind();
            //DropDownList10.ToolTip = DropDownList10.SelectedValue.ToString();
            //DropDownList10.Items.Insert(0, new ListItem(" ", " "));

            //DropDownList11.DataSource = ppl.S_PTCB_Detail("", "11");
            //DropDownList11.DataTextField = "PTCB_Code";
            //DropDownList11.DataValueField = "PTCB_Detail";
            //DropDownList11.DataBind();
            //DropDownList11.ToolTip = DropDownList11.SelectedValue.ToString();
            //DropDownList11.Items.Insert(0, new ListItem("  ", "  "));


            string[] a = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ptname = a[0];
            string ptspecial = a[1];
            string prid = a[2];
            string bomid = a[3];
            Label_PT_ID.Text = a[4];
            TextBox4.Text = a[9];
            Txt_PT.Text = ptname;
            Label_ptname.Text = ptname;

            DropDownList12.DataSource = ip.S_IPSMain(" ");//测试参数类别
            DropDownList12.DataTextField = "IPSM_Type";
            DropDownList12.DataValueField = "IPSM_ID";
            DropDownList12.DataBind();
            DropDownList12.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

            DropDownList13.DataSource = ip.S_IPSDetail(new Guid(DropDownList12.SelectedValue.ToString().Trim()));//测试参数类别详细
            DropDownList13.DataTextField = "IPSD_Type";
            DropDownList13.DataValueField = "IPSD_ID";
            DropDownList13.DataBind();
            DropDownList13.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));

            GridViewips.DataSource = ip.S_ProTypeIPS(new Guid(a[4].Trim()));
            GridViewips.DataBind();



            DataSet ds0 = ppl.S_ProType_WorkOrder(Label_ptname.Text.Trim());
            DataTable dt0 = ds0.Tables[0];
            if (dt0.Rows.Count != 0)
            {
                Txt_PT.Enabled = false;

            }
            else
            {
                Txt_PT.Enabled = true;
            }


            DropDownList_Special.SelectedValue = ptspecial;
            if (prid.ToString().Trim() == "")
            {
                DropDownList_PR.SelectedIndex = 0;
            }
            else
            {
                DropDownList_PR.Items.FindByValue(prid.ToString().Trim()).Selected = true;
            }
            if (bomid.ToString().Trim() == "")
            {
                DropDownList_BOM.SelectedIndex = 0;
            }
            else
            {
                DropDownList_BOM.Items.FindByValue(bomid.ToString().Trim()).Selected = true;
            }
            if (a[5].ToString().Trim() == "")
            {
                DropDownList2.SelectedIndex = 0;
            }
            else
            {
                DropDownList2.Items.FindByText(a[5].ToString().Trim()).Selected = true;
            }
            TextBox3.Text = a[7].Trim();
            Label_code.Text = a[8].Trim();

            if (a[8].Trim() == "")
            {
                a[8] = "                   ";
                DropDownList01.SelectedIndex = 0;
                DropDownList02.SelectedIndex = 0;
                DropDownList03.SelectedIndex = 0;
                DropDownList04.SelectedIndex = 0;
                DropDownList05.SelectedIndex = 0;
                DropDownList06.SelectedIndex = 0;
                DropDownList07.SelectedIndex = 0;
                DropDownList08.SelectedIndex = 0;
                DropDownList09.SelectedIndex = 0;
                DropDownList10.SelectedIndex = 0;
                DropDownList11.SelectedIndex = 0;
            }
            if (a[8].Substring(0, 1).Trim() != "")
            {
                DropDownList01.SelectedIndex = DropDownList01.Items.IndexOf(DropDownList01.Items.FindByValue(a[8].Substring(0, 1).Trim()));
                //  DropDownList01.Items.FindByText(a[8].Substring(0, 1).Trim()).Selected = true;
            }
            if (a[8].Substring(1, 2).Trim() != "")
            {
                DropDownList02.SelectedIndex = DropDownList02.Items.IndexOf(DropDownList02.Items.FindByValue(a[8].Substring(1, 2).Trim()));

                //  DropDownList02.Items.FindByText(a[8].Substring(1, 2).ToString()).Selected=true;
            }
            if (a[8].Substring(3, 3).Trim() != "")
            {
                DropDownList03.SelectedIndex = DropDownList03.Items.IndexOf(DropDownList03.Items.FindByValue(a[8].Substring(3, 3).Trim()));

                // DropDownList03.Items.FindByText(a[8].Substring(3, 3).Trim()).Selected = true;
            }
            if (a[8].Substring(6, 3).Trim() != "")
            {
                DropDownList04.SelectedIndex = DropDownList04.Items.IndexOf(DropDownList04.Items.FindByValue(a[8].Substring(6, 3).Trim()));

                // DropDownList04.Items.FindByText(a[8].Substring(6, 3).Trim()).Selected = true;
            }
            if (a[8].Substring(9, 1).Trim() != "")
            {
                DropDownList05.SelectedIndex = DropDownList05.Items.IndexOf(DropDownList05.Items.FindByValue(a[8].Substring(9, 1).Trim()));

                //DropDownList05.Items.FindByText(a[8].Substring(9, 1).Trim()).Selected = true;
            }
            if (a[8].Substring(10, 2).Trim() != "")
            {
                DropDownList06.SelectedIndex = DropDownList06.Items.IndexOf(DropDownList06.Items.FindByValue(a[8].Substring(10, 2).Trim()));

                //   DropDownList06.Items.FindByText(a[8].Substring(10, 2).Trim()).Selected = true;
            }
            if (a[8].Substring(12, 2).Trim() != "")
            {
                DropDownList07.SelectedIndex = DropDownList07.Items.IndexOf(DropDownList07.Items.FindByValue(a[8].Substring(12, 2).Trim()));

                // DropDownList07.Items.FindByText(a[8].Substring(12, 2).Trim()).Selected = true;
            }
            if (a[8].Substring(14, 1).Trim() != "")
            {
                DropDownList08.SelectedIndex = DropDownList08.Items.IndexOf(DropDownList08.Items.FindByValue(a[8].Substring(14, 1).Trim()));

                //DropDownList08.Items.FindByText(a[8].Substring(14, 1).Trim()).Selected = true;
            }
            if (a[8].Substring(15, 1).Trim() != "")
            {
                DropDownList09.SelectedIndex = DropDownList09.Items.IndexOf(DropDownList09.Items.FindByValue(a[8].Substring(15, 1).Trim()));

                //DropDownList09.Items.FindByText(a[8].Substring(15, 1).Trim()).Selected = true;
            }
            if (a[8].Substring(16, 1).Trim() != "")
            {
                DropDownList10.SelectedIndex = DropDownList10.Items.IndexOf(DropDownList10.Items.FindByValue(a[8].Substring(16, 1).Trim()));

                //DropDownList10.Items.FindByText(a[8].Substring(16, 1).Trim()).Selected = true;
            }
            if (a[8].Substring(17, 2).Trim() != "")
            {
                DropDownList11.SelectedIndex = DropDownList11.Items.IndexOf(DropDownList11.Items.FindByValue(a[8].Substring(17, 2).Trim()));

                //DropDownList11.Items.FindByText(a[8].Substring(17, 2).Trim()).Selected = true;
            }
            Label_submitState.Text = "编辑";
            Panel_AddPT.Visible = true;
            UpdatePanel_AddPT.Update();


        }
        if (e.CommandName == "Check_Parameter")//查看产品基础信息，包括BOM、工艺路线等
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            Label_Type.Text = "";
            Label_Material.Visible = true;
            GridView_bom.Visible = true;
            Label_TestParameter.Visible = true;
            TextBox_TestParameter.Visible = true;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_WOID.Text = al[0];
            string ptname = al[1];
            Label_PT_ID.Text = al[2];
            //if (al[2].Trim() == "检验")
            //{
            //    this.GridView_Pr.DataSource = wol.S_WO_ProType_ProcessRoute(ptname, 1);
            //    this.GridView_Pr.DataBind();
            //    //  this.GridView_Pr.Columns[2].Visible = false;
            //    Label20.Text = "以下为检验随工单的工艺路线，与常规产品路线不同，蓝色表示需要认证的工序，认证合格后才能进行非蓝色工序";
            //}
            // else
            //  {
            GridView_Pr.DataSource = wol.S_WO_ProType_ProcessRoute(ptname, 0);
            GridView_Pr.DataBind();
            GridView_Pr.Columns[3].Visible = false;
            GridView_Pr.Columns[4].Visible = false;
            Label20.Text = "";
            //  }
            Label_PT.Text = ptname;

            GridView_bom.DataSource = wol.S_ProType_BOM(ptname);
            GridView_bom.DataBind();

            DataSet ds1 = wol.S_ProType_TestParameter(ptname);
            DataView dv1 = ds1.Tables[0].DefaultView;
            foreach (DataRowView datav in dv1)
            {
                TextBox_TestParameter.Text = datav["PT_Parameters"].ToString().Trim();
            }
            UpdatePanel_basic.Update();

            //无关信息隐藏

            Panel_basic.Visible = true;
            Panel_AddPT.Visible = false;
            UpdatePanel_AddPT.Update();
            Panel_CheckParameter.Visible = false;
            UpdatePanel_CheckParameter.Update();

        }
        if (e.CommandName == "Check_RZ")//查看产品基础信息，包括BOM、工艺路线等
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            Label_Type.Text = "检验";
            Label_Material.Visible = false;
            GridView_bom.Visible = false;
            Label_TestParameter.Visible = false;
            TextBox_TestParameter.Visible = false;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_WOID.Text = al[0];
            string ptname = al[1];
            Label_PT_ID.Text = al[2];
            //if (al[2].Trim() == "检验")
            //{
            GridView_Pr.DataSource = wol.S_WO_ProType_ProcessRoute(ptname, 1);
            GridView_Pr.DataBind();

            Label20.Text = "以下为检验随工单的工艺路线，与常规产品路线不同，蓝色表示需要认证的工序，认证合格后才能进行非蓝色工序";
            //}
            // else
            //  {
            //this.GridView_Pr.DataSource = wol.S_WO_ProType_ProcessRoute(ptname, 0);
            //this.GridView_Pr.DataBind();
            //this.GridView_Pr.Columns[3].Visible = false;
            //this.GridView_Pr.Columns[4].Visible = false;
            //Label20.Text = "";
            //  }
            Label_PT.Text = ptname;

            GridView_bom.DataSource = wol.S_ProType_BOM(ptname);
            GridView_bom.DataBind();

            DataSet ds1 = wol.S_ProType_TestParameter(ptname);
            DataView dv1 = ds1.Tables[0].DefaultView;
            foreach (DataRowView datav in dv1)
            {
                TextBox_TestParameter.Text = datav["PT_Parameters"].ToString().Trim();
            }
            UpdatePanel_basic.Update();

            //无关信息隐藏

            Panel_basic.Visible = true;
            Panel_AddPT.Visible = false;
            UpdatePanel_AddPT.Update();
            Panel_CheckParameter.Visible = false;
            UpdatePanel_CheckParameter.Update();

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
                    e.Row.BackColor = Color.SkyBlue;

                }
            }
        }
    }


    protected void DropDownList01_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList01.ToolTip = DropDownList01.SelectedValue.ToString();
    }
    protected void DropDownList02_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList02.ToolTip = DropDownList02.SelectedValue.ToString();
    }
    protected void DropDownList03_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList03.ToolTip = DropDownList03.SelectedValue.ToString();
    }
    protected void DropDownList04_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList04.ToolTip = DropDownList04.SelectedValue.ToString();
    }
    protected void DropDownList05_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList05.ToolTip = DropDownList05.SelectedValue.ToString();
    }
    protected void DropDownList06_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList06.ToolTip = DropDownList06.SelectedValue.ToString();
    }
    protected void DropDownList07_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList07.ToolTip = DropDownList07.SelectedValue.ToString();
    }
    protected void DropDownList08_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList08.ToolTip = DropDownList08.SelectedValue.ToString();

    }
    protected void DropDownList09_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList09.ToolTip = DropDownList09.SelectedValue.ToString();
    }
    protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList10.ToolTip = DropDownList10.SelectedValue.ToString();
    }
    protected void DropDownList11_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList11.ToolTip = DropDownList11.SelectedValue.ToString();

    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList13.DataSource = ip.S_IPSDetail(new Guid(DropDownList12.SelectedValue.ToString().Trim()));//测试参数类别详细
        DropDownList13.DataTextField = "IPSD_Type";
        DropDownList13.DataValueField = "IPSD_ID";
        DropDownList13.DataBind();
        DropDownList13.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
    }
    protected void Btn_Add0_Click(object sender, EventArgs e)
    {
        if ((DropDownList12.SelectedIndex == 0 || DropDownList13.SelectedIndex == 0))
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请把产品测试参数的2个下拉框选择完再点击添加！')", true);
            return;

        }

        ip.I_ProTypeIPS(new Guid(Label_PT_ID.Text.Trim()), new Guid(DropDownList12.SelectedValue.ToString().Trim()), new Guid(DropDownList13.SelectedValue.ToString().Trim()));
        GridViewips.DataSource = ip.S_ProTypeIPS(new Guid(Label_PT_ID.Text.Trim()));
        GridViewips.DataBind();
        DataSet ds2 = ip.S_ProTypeIPS(new Guid(Label_PT_ID.Text.Trim()));
        DataTable dt2 = ds2.Tables[0];
        DataView dv2 = ds2.Tables[0].DefaultView;
        foreach (DataRowView datav in dv2)
        {
            TextBox3.Text = datav["ips"].ToString().Trim();

        }
        DropDownList12.DataSource = ip.S_IPSMain(" ");//测试参数类别
        DropDownList12.DataTextField = "IPSM_Type";
        DropDownList12.DataValueField = "IPSM_ID";
        DropDownList12.DataBind();
        DropDownList12.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
        DropDownList13.DataSource = ip.S_IPSDetail(new Guid(DropDownList12.SelectedValue.ToString().Trim()));//测试参数类别详细
        DropDownList13.DataTextField = "IPSD_Type";
        DropDownList13.DataValueField = "IPSD_ID";
        DropDownList13.DataBind();
        DropDownList13.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
        databind1();
    }
    protected void GridViewips_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_PTIPS")
        {
            try
            {
                // this.Lab_State.Text = "Delete1";
                string id = e.CommandArgument.ToString();
                Guid guid_id = new Guid(id);
                ip.D_ProTypeIPS(guid_id);
                GridViewips.DataSource = ip.S_ProTypeIPS(new Guid(Label_PT_ID.Text.Trim()));
                GridViewips.DataBind();
                DataSet ds2 = ip.S_ProTypeIPS(new Guid(Label_PT_ID.Text.Trim()));
                DataTable dt2 = ds2.Tables[0];
                DataView dv2 = ds2.Tables[0].DefaultView;
                foreach (DataRowView datav in dv2)
                {
                    TextBox3.Text = datav["ips"].ToString().Trim();

                }
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    TextBox3.Text = "";
                }
                DropDownList12.DataSource = ip.S_IPSMain("");//测试参数类别
                DropDownList12.DataTextField = "IPSM_Type";
                DropDownList12.DataValueField = "IPSM_ID";
                DropDownList12.DataBind();
                DropDownList12.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
                DropDownList13.DataSource = ip.S_IPSDetail(new Guid(DropDownList12.SelectedValue.ToString().Trim()));//测试参数类别详细
                DropDownList13.DataTextField = "IPSD_Type";
                DropDownList13.DataValueField = "IPSD_ID";
                DropDownList13.DataBind();
                DropDownList13.Items.Insert(0, new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
                databind1();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该测试类别已有详细项目信息或产品型号已引用该测试类别，无法删除，请另外新建！')", true);

            }
        }
    }
    protected void Btn_copy_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        TextBox5.Text = "";
        TextBox6.Text = "";
        databind2();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;
                if (GridView1.Rows[i].Cells[j].Text.Length > 80)
                {
                    GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].Text.Substring(0, 80) + "...";
                }


            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        //绑定数据源
        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        // specify the NewPageIndex
        GridView1.PageIndex = newPageIndex;
        databind2();

        GridView1.SelectedIndex = -1;

        //panel 隐藏

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select1")
        {
            try
            {
                string id = e.CommandArgument.ToString();

                ip.Copy_IPSMain(new Guid(id), new Guid(Label_PT_ID.Text.Trim()));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('复制成功！')", true);
                UpdatePanel_AddPT.Update();
                Panel1.Visible = false;
                UpdatePanel1.Update();
                databind1();
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('复制失败！')", true);

            }
            GridViewips.DataSource = ip.S_ProTypeIPS(new Guid(Label_PT_ID.Text.Trim()));
            GridViewips.DataBind();
            DataSet ds2 = ip.S_ProTypeIPS(new Guid(Label_PT_ID.Text.Trim()));
            DataTable dt2 = ds2.Tables[0];
            DataView dv2 = ds2.Tables[0].DefaultView;
            foreach (DataRowView datav in dv2)
            {
                TextBox3.Text = datav["ips"].ToString().Trim();

            }
        }
    }
    protected void Btn_qx_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Btn_Search1_Click(object sender, EventArgs e)
    {
        databind2();
    }
    protected void Button_return(object sender, EventArgs e)
    {
        if (label_pagestate.Text.Trim() == "specialmake")
        {
            Response.Redirect("../CraftMgt/ProSpecial.aspx?state=make");
        }
        if (label_pagestate.Text.Trim() == "speciallook")
        {
            Response.Redirect("../CraftMgt/ProSpecial.aspx?state=look");
        }
    }
}