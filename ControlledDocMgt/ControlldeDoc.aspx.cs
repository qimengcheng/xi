using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class ControlledDocMgt_ControlldeDoc : Page
{
    ControlldeDocL controlldeDocL = new ControlldeDocL();
    BasicCodeL basicCodeL = new BasicCodeL();

    #region 页面权限控制
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
            //BindDropDownList2();
            DropDownList3.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList3();
            //ClosePanel();
            //this.UpdatePanel_upload.Update();

            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "ControlDocIn" && Session["UserRole"].ToString().Contains("受控文件录入"))
                {
                    Title = "受控文件录入（特殊通道）";
                    Grid_App.Columns[16].Visible = false;//审核人
                    Grid_App.Columns[17].Visible = false;//审核时间
                    Grid_App.Columns[19].Visible = false;//审核结果
                    Grid_App.Columns[20].Visible = false;//审批人
                    Grid_App.Columns[21].Visible = false;//审批时间
                    Grid_App.Columns[23].Visible = false;//审批结果
                    Grid_App.Columns[24].Visible = false;//查看详情
                    Grid_App.Columns[25].Visible = false;//编辑
                    Grid_App.Columns[26].Visible = false;//特殊文件编号
                    Grid_App.Columns[27].Visible = false;//主管审核
                    Grid_App.Columns[28].Visible = false;//会签
                    Grid_App.Columns[29].Visible = false;//审批
                    Grid_App.Columns[30].Visible = false;//下载文件
                    Grid_App.Columns[31].Visible = false;//换版申请
                    Grid_App.Columns[32].Visible = false;//删除
                    Grid_App.Columns[33].Visible = true;//更改编号

                    Btn_NewApp.Visible = false;
                    Btn_Specil.Visible = true;
                    string condition = GetCondition3();
                    BindGrid_App(condition);
                }
                if (Lab_Status.Text == "ControlDocApp" && Session["UserRole"].ToString().Contains("受控文件申请"))
                {
                    Title = "受控文件申请";
                    Grid_App.Columns[16].Visible = false;//审核人
                    Grid_App.Columns[17].Visible = false;//审核时间
                    Grid_App.Columns[19].Visible = false;//审核结果
                    Grid_App.Columns[20].Visible = false;//审批人
                    Grid_App.Columns[21].Visible = false;//审批时间
                    Grid_App.Columns[23].Visible = false;//审批结果
                    Grid_App.Columns[24].Visible = false;//查看详情
                    Grid_App.Columns[25].Visible = true;//编辑
                    Grid_App.Columns[26].Visible = false;//特殊文件编号
                    Grid_App.Columns[27].Visible = false;//主管审核
                    Grid_App.Columns[28].Visible = false;//会签
                    Grid_App.Columns[29].Visible = false;//审批
                    Grid_App.Columns[30].Visible = false;//下载文件
                    Grid_App.Columns[31].Visible = true;//换版申请
                    Grid_App.Columns[32].Visible = true;//删除
                    Grid_App.Columns[33].Visible = false;//更改编号

                    //Label39.Visible = true;
                    Btn_NewApp.Visible = true;
                    Btn_Specil.Visible = false;
                    //this.DropDownList4.Items.FindByValue("已提交").Enabled = false;
                    //this.DropDownList4.Items.FindByValue("审核通过").Enabled = false;
                    //this.DropDownList4.Items.FindByValue("会签中").Enabled = false;
                    //this.DropDownList4.Items.FindByValue("会签通过").Enabled = false;
                    //this.DropDownList4.Items.FindByValue("审批通过").Enabled = false;
                    string condition = GetCondition3();
                    BindGrid_App(condition);
                }
                if (Lab_Status.Text == "ControlDocSpecil" && Session["UserRole"].ToString().Contains("分发特殊文件编号"))
                {
                    Title = "分发特殊文件编号";
                    Grid_App.Columns[16].Visible = false;//审核人
                    Grid_App.Columns[17].Visible = false;//审核时间
                    Grid_App.Columns[19].Visible = false;//审核结果
                    Grid_App.Columns[20].Visible = false;//审批人
                    Grid_App.Columns[21].Visible = false;//审批时间
                    Grid_App.Columns[23].Visible = false;//审批结果
                    Grid_App.Columns[24].Visible = false;//查看详情
                    Grid_App.Columns[25].Visible = false;//编辑
                    Grid_App.Columns[26].Visible = true;//特殊文件编号
                    Grid_App.Columns[27].Visible = false;//主管审核
                    Grid_App.Columns[28].Visible = false;//会签
                    Grid_App.Columns[29].Visible = false;//审批
                    Grid_App.Columns[30].Visible = false;//下载文件
                    Grid_App.Columns[31].Visible = false;//换版申请
                    Grid_App.Columns[32].Visible = false;//删除
                    Grid_App.Columns[33].Visible = false;//更改编号

                    Btn_NewApp.Visible = false;
                    Btn_Specil.Visible = false;
                    DropDownList4.Items.FindByValue("待提交").Enabled = false;
                    DropDownList4.Items.FindByValue("审核通过").Enabled = false;
                    DropDownList4.Items.FindByValue("审核驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("会签中").Enabled = false;
                    DropDownList4.Items.FindByValue("会签通过").Enabled = false;
                    DropDownList4.Items.FindByValue("会签驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("审批通过").Enabled = false;
                    DropDownList4.Items.FindByValue("审批驳回").Enabled = false;
                    DropDownList1.Items.FindByValue("第三层次文件").Enabled = false;
                    DropDownList1.Items.FindByValue("质量文件").Enabled = false;
                    DropDownList1.Items.FindByValue("程序文件").Enabled = false;
                    DropDownList1.Items.FindByValue("图纸文件").Enabled = false;
                    DropDownList1.Items.FindByValue("外来文件").Enabled = false;
                    string condition = GetCondition3();
                    BindGrid_App(condition);
                }
                if (Lab_Status.Text == "ControlDocAu" && Session["UserRole"].ToString().Contains("受控文件主管审核"))
                {
                    Title = "受控文件主管审核";
                    Grid_App.Columns[16].Visible = false;//审核人
                    Grid_App.Columns[17].Visible = false;//审核时间
                    Grid_App.Columns[19].Visible = false;//审核结果
                    Grid_App.Columns[20].Visible = false;//审批人
                    Grid_App.Columns[21].Visible = false;//审批时间
                    Grid_App.Columns[23].Visible = false;//审批结果
                    Grid_App.Columns[24].Visible = false;//查看详情
                    Grid_App.Columns[25].Visible = false;//编辑
                    Grid_App.Columns[26].Visible = false;//特殊文件编号
                    Grid_App.Columns[27].Visible = true;//主管审核
                    Grid_App.Columns[28].Visible = false;//会签
                    Grid_App.Columns[29].Visible = false;//审批
                    Grid_App.Columns[30].Visible = false;//下载文件
                    Grid_App.Columns[31].Visible = false;//换版申请
                    Grid_App.Columns[32].Visible = false;//删除
                    Grid_App.Columns[33].Visible = false;//更改编号

                    //Label39.Visible = true;
                    Btn_NewApp.Visible = false;
                    Btn_Specil.Visible = false;
                    DropDownList4.Items.FindByValue("待提交").Enabled = false;
                    DropDownList4.Items.FindByValue("审核通过").Enabled = false;
                    DropDownList4.Items.FindByValue("审核驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("会签中").Enabled = false;
                    DropDownList4.Items.FindByValue("会签通过").Enabled = false;
                    DropDownList4.Items.FindByValue("会签驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("审批通过").Enabled = false;
                    DropDownList4.Items.FindByValue("审批驳回").Enabled = false;
                    string condition = GetCondition3();
                    BindGrid_App(condition);
                }
                if (Lab_Status.Text == "ControlDocSign" && Session["UserRole"].ToString().Contains("受控文件会签"))
                {
                    Title = "受控文件会签";
                    Grid_App.Columns[16].Visible = true;//审核人
                    Grid_App.Columns[17].Visible = true;//审核时间
                    Grid_App.Columns[19].Visible = false;//审核结果
                    Grid_App.Columns[20].Visible = false;//审批人
                    Grid_App.Columns[21].Visible = false;//审批时间
                    Grid_App.Columns[23].Visible = false;//审批结果
                    Grid_App.Columns[24].Visible = false;//查看详情
                    Grid_App.Columns[25].Visible = false;//编辑
                    Grid_App.Columns[26].Visible = false;//特殊文件编号
                    Grid_App.Columns[27].Visible = false;//主管审核
                    Grid_App.Columns[28].Visible = true;//会签
                    Grid_App.Columns[29].Visible = false;//审批
                    Grid_App.Columns[30].Visible = false;//下载文件
                    Grid_App.Columns[31].Visible = false;//换版申请
                    Grid_App.Columns[32].Visible = false;//删除
                    Grid_App.Columns[33].Visible = false;//更改编号

                    //Label39.Visible = true;
                    Btn_NewApp.Visible = false;
                    Btn_Specil.Visible = false;
                    DropDownList4.Items.FindByValue("待提交").Enabled = false;
                    DropDownList4.Items.FindByValue("已提交").Enabled = false;
                    DropDownList4.Items.FindByValue("审核驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("会签通过").Enabled = false;
                    DropDownList4.Items.FindByValue("会签驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("审批通过").Enabled = false;
                    DropDownList4.Items.FindByValue("审批驳回").Enabled = false;
                    string condition = GetCondition3();
                    BindGrid_App(condition);
                }
                if (Lab_Status.Text == "ControlDocApprov" && Session["UserRole"].ToString().Contains("受控文件审批"))
                {
                    Title = "受控文件审批";
                    Grid_App.Columns[16].Visible = true;//审核人
                    Grid_App.Columns[17].Visible = true;//审核时间
                    Grid_App.Columns[19].Visible = false;//审核结果
                    Grid_App.Columns[20].Visible = false;//审批人
                    Grid_App.Columns[21].Visible = false;//审批时间
                    Grid_App.Columns[23].Visible = false;//审批结果
                    Grid_App.Columns[24].Visible = false;//查看详情
                    Grid_App.Columns[25].Visible = false;//编辑
                    Grid_App.Columns[26].Visible = false;//特殊文件编号
                    Grid_App.Columns[27].Visible = false;//主管审核
                    Grid_App.Columns[28].Visible = false;//会签
                    Grid_App.Columns[29].Visible = true;//审批
                    Grid_App.Columns[30].Visible = false;//下载文件
                    Grid_App.Columns[31].Visible = false;//换版申请
                    Grid_App.Columns[32].Visible = false;//删除
                    Grid_App.Columns[33].Visible = false;//更改编号

                    //Label39.Visible = true;
                    Btn_NewApp.Visible = false;
                    Btn_Specil.Visible = false;
                    DropDownList4.Items.FindByValue("待提交").Enabled = false;
                    DropDownList4.Items.FindByValue("已提交").Enabled = false;
                    DropDownList4.Items.FindByValue("审核通过").Enabled = false;
                    DropDownList4.Items.FindByValue("审核驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("会签中").Enabled = false;
                    DropDownList4.Items.FindByValue("会签驳回").Enabled = false;
                    DropDownList4.Items.FindByValue("审批通过").Enabled = false;
                    DropDownList4.Items.FindByValue("审批驳回").Enabled = false;
                    string condition = GetCondition3();
                    BindGrid_App(condition);
                }
                if (Lab_Status.Text == "ControlDocLook" && Session["UserRole"].ToString().Contains("受控文件申请查看"))
                {
                    Title = "受控文件申请查看";
                    Grid_App.Columns[16].Visible = true;//审核人
                    Grid_App.Columns[17].Visible = true;//审核时间
                    Grid_App.Columns[19].Visible = false;//审核结果
                    Grid_App.Columns[20].Visible = true;//审批人
                    Grid_App.Columns[21].Visible = true;//审批时间
                    Grid_App.Columns[23].Visible = false;//审批结果
                    Grid_App.Columns[24].Visible = true;//查看详情
                    Grid_App.Columns[25].Visible = false;//编辑
                    Grid_App.Columns[26].Visible = false;//特殊文件编号
                    Grid_App.Columns[27].Visible = false;//主管审核
                    Grid_App.Columns[28].Visible = false;//会签
                    Grid_App.Columns[29].Visible = false;//审批
                    Grid_App.Columns[30].Visible = false;//下载文件
                    Grid_App.Columns[31].Visible = false;//换版申请
                    Grid_App.Columns[32].Visible = false;//删除
                    Grid_App.Columns[33].Visible = false;//更改编号

                    Btn_NewApp.Visible = false;
                    Btn_Specil.Visible = false;
                    string condition = GetCondition3();
                    BindGrid_App(condition);
                }
                //if (Lab_Status.Text == "ControlDocDown" && Session["UserRole"].ToString().Contains("受控文件下载"))
                //{
                //    Title = "受控文件下载";
                //    Grid_App.Columns[16].Visible = true;//审核人
                //    Grid_App.Columns[17].Visible = true;//审核时间
                //    Grid_App.Columns[19].Visible = false;//审核结果
                //    Grid_App.Columns[20].Visible = true;//审批人
                //    Grid_App.Columns[21].Visible = true;//审批时间
                //    Grid_App.Columns[23].Visible = false;//审批结果
                //    Grid_App.Columns[24].Visible = false;//查看详情
                //    Grid_App.Columns[25].Visible = false;//编辑
                //    Grid_App.Columns[26].Visible = false;//特殊文件编号
                //    Grid_App.Columns[27].Visible = false;//主管审核
                //    Grid_App.Columns[28].Visible = false;//会签
                //    Grid_App.Columns[29].Visible = false;//审批
                //    Grid_App.Columns[30].Visible = false;//下载文件
                //    Grid_App.Columns[31].Visible = false;//换版申请
                //    Grid_App.Columns[32].Visible = false;//删除
                //    Grid_App.Columns[33].Visible = false;//更改编号

                //    Btn_NewApp.Visible = false;
                //    Btn_Specil.Visible = false;
                //    DropDownList4.Items.FindByValue("待提交").Enabled = false;
                //    DropDownList4.Items.FindByValue("已提交").Enabled = false;
                //    DropDownList4.Items.FindByValue("审核通过").Enabled = false;
                //    DropDownList4.Items.FindByValue("审核驳回").Enabled = false;
                //    DropDownList4.Items.FindByValue("会签中").Enabled = false;
                //    DropDownList4.Items.FindByValue("会签通过").Enabled = false;
                //    DropDownList4.Items.FindByValue("会签驳回").Enabled = false;
                //    DropDownList4.Items.FindByValue("审批驳回").Enabled = false;
                //    string condition = GetCondition3();
                //    BindGrid_App(condition);
                //}
                //if (Lab_Status.Text == "ControlDocDownlook" && Session["UserRole"].ToString().Contains("受控文件查阅"))
                //{
                //    Title = "受控文件查阅";
                //    Grid_App.Columns[16].Visible = true;//审核人
                //    Grid_App.Columns[17].Visible = true;//审核时间
                //    Grid_App.Columns[19].Visible = false;//审核结果
                //    Grid_App.Columns[20].Visible = true;//审批人
                //    Grid_App.Columns[21].Visible = true;//审批时间
                //    Grid_App.Columns[23].Visible = false;//审批结果
                //    Grid_App.Columns[24].Visible = false;//查看详情
                //    Grid_App.Columns[25].Visible = false;//编辑
                //    Grid_App.Columns[26].Visible = false;//特殊文件编号
                //    Grid_App.Columns[27].Visible = false;//主管审核
                //    Grid_App.Columns[28].Visible = false;//会签
                //    Grid_App.Columns[29].Visible = false;//审批
                //    Grid_App.Columns[30].Visible = false;//下载文件
                //    Grid_App.Columns[31].Visible = false;//换版申请
                //    Grid_App.Columns[32].Visible = false;//删除
                //    Grid_App.Columns[33].Visible = false;//更改编号

                //    //Label39.Visible = true;
                //    Btn_NewApp.Visible = false;
                //    Btn_Specil.Visible = false;
                //    DropDownList4.Items.FindByValue("待提交").Enabled = false;
                //    DropDownList4.Items.FindByValue("已提交").Enabled = false;
                //    DropDownList4.Items.FindByValue("审核通过").Enabled = false;
                //    DropDownList4.Items.FindByValue("审核驳回").Enabled = false;
                //    DropDownList4.Items.FindByValue("会签中").Enabled = false;
                //    DropDownList4.Items.FindByValue("会签通过").Enabled = false;
                //    DropDownList4.Items.FindByValue("会签驳回").Enabled = false;
                //    DropDownList4.Items.FindByValue("审批驳回").Enabled = false;
                //    string condition = GetCondition3();
                //    BindGrid_App(condition);
                //}
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    protected string GetCondition3()
    {
        string condition;
        string temp = "";
        //if (this.Lab_Status.Text == "ControlDocApp" && Session["UserRole"].ToString().Contains("受控文件申请"))
        //{
        //    temp += " and a.CDA_AppState='待提交' or a.CDA_AppState='审核驳回' or a.CDA_AppState='会签驳回' or a.CDA_AppState='审批驳回' ";
        //}
        if (Lab_Status.Text == "ControlDocIn" && Session["UserRole"].ToString().Contains("受控文件录入"))
        {
            temp += " ";
        }
        if (Lab_Status.Text == "ControlDocApp" && Session["UserRole"].ToString().Contains("受控文件申请"))
        {
            //temp += " ";
            temp += " and a.CDA_AppDep='" + Session["Department"].ToString() + "'";
        }
        if (Lab_Status.Text == "ControlDocSpecil" && Session["UserRole"].ToString().Contains("分发特殊文件编号"))
        {
            temp += " and a.CDA_AppState='已提交' and a.CDA_DocNO is null";
        }
        if (Lab_Status.Text == "ControlDocAu" && Session["UserRole"].ToString().Contains("受控文件主管审核"))
        {
            //temp += " and a.CDA_AppState='已提交' and a.CDA_DocNO is not null";
            temp += " and a.CDA_AppState='已提交' and a.CDA_DocNO is not null and a.CDA_AppDep='" + Session["Department"].ToString() + "'";
        }
        if (Lab_Status.Text == "ControlDocSign" && Session["UserRole"].ToString().Contains("受控文件会签"))
        {
            temp += " and (a.CDA_AppState='审核通过' or a.CDA_AppState='会签中') and CDA_ID in (select CDA_ID from CDAppConSignT where BDOS_Code = '" + Session["Organization"].ToString() + "')";
        }
        if (Lab_Status.Text == "ControlDocApprov" && Session["UserRole"].ToString().Contains("受控文件审批"))
        {
            temp += " and a.CDA_AppState='会签通过'";
        }
        if (Lab_Status.Text == "ControlDocLook" && Session["UserRole"].ToString().Contains("受控文件申请查看"))
        {
            temp += "";
        }
        if (Lab_Status.Text == "ControlDocDown" && Session["UserRole"].ToString().Contains("受控文件下载"))
        {
            temp += " and a.CDA_AppState='审批通过'";
        }
        if (Lab_Status.Text == "ControlDocDownlook" && Session["UserRole"].ToString().Contains("受控文件查阅"))
        {
            temp += " and a.CDA_AppState='审批通过' and CDA_ID in (select CDA_ID from CDDepDistributeDetail where CDDDCT_ID = (select c.CDDDCT_ID from CDDepDistributeCodeT c where c.CDDDCT_Dep='" + Session["Department"].ToString() + "'))";
        }
        condition = temp;
        return condition;
    }
    #endregion 页面权限控制

    #region 绑定
    //绑定Grid_App
    private void BindGrid_App(string condition)
    {
        Grid_App.DataSource = controlldeDocL.Search_ControlledDocApp_APP(condition);
        Grid_App.DataBind();
    }
    //DropDownList3下拉表绑定
    private void BindDropDownList3()
    {
        DropDownList3.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
        DropDownList3.DataTextField = "BDOS_Name";
        DropDownList3.DataValueField = "BDOS_Name";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("请选择", ""));
    }
    //DropDownList5下拉表绑定
    private void BindDropDownList5()
    {
        DropDownList5.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
        DropDownList5.DataTextField = "BDOS_Name";
        DropDownList5.DataValueField = "BDOS_Name";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
    }
    //DropDownList2下拉表绑定
    //private void BindDropDownList2()
    //{
    //    this.DropDownList2.DataSource = controlldeDocL.Search_CDThirdLevelCode_DocType();
    //    this.DropDownList2.DataTextField = "CDTLC_DocType";
    //    this.DropDownList2.DataValueField = "CDTLC_DocType";
    //    this.DropDownList2.DataBind();
    //    this.DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    //}
    //DropDownList7下拉表绑定
    private void BindDropDownList7()
    {
        DropDownList7.DataSource = controlldeDocL.Search_CDThirdLevelCode_DocType();
        DropDownList7.DataTextField = "CDTLC_DocType";
        DropDownList7.DataValueField = "CDTLC_DocType";
        DropDownList7.DataBind();
        DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定Grid_CDDep
    private void BindGrid_CDDep(string condition)
    {
        Grid_CDDep.DataSource = controlldeDocL.Search_CDDepDistributeDetail(condition);
        Grid_CDDep.DataBind();
    }
    //DropDownList8下拉表绑定
    //private void BindDropDownList8()
    //{
    //    this.DropDownList8.DataSource = basicCodeL.Search_BDOrganization_BDdepcode();
    //    this.DropDownList8.DataTextField = "BDOS_Name";
    //    this.DropDownList8.DataValueField = "BDOS_Name";
    //    this.DropDownList8.DataBind();
    //    this.DropDownList8.Items.Insert(0, new ListItem("请选择", ""));
    //}
    //绑定Grid_chooseCDDep
    private void BindGrid_chooseCDDep(string condition)
    {
        Grid_chooseCDDep.DataSource = basicCodeL.Search_CDDepDistributeCodeT(condition);
        Grid_chooseCDDep.DataBind();
    }
    //绑定Grid_CDAppCon
    private void BindGrid_CDAppCon(string condition)
    {
        Grid_CDAppCon.DataSource = controlldeDocL.Search_CDAppConSignT(condition);
        Grid_CDAppCon.DataBind();
    }
    //绑定Grid_chooseCDDep
    private void BindGrid_chooseBDO(string condition)
    {
        Grid_chooseBDO.DataSource = controlldeDocL.Search_BDOrganization_CDAppConSignT(condition);
        Grid_chooseBDO.DataBind();
    }
    #endregion 绑定

    #region 受控文件申请检索
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (this.DropDownList1.SelectedValue.ToString() != "第三层次文件")
    //    {
    //        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    //        BindDropDownList2();
    //        this.DropDownList2.Enabled = false;
    //        this.UpdatePanel_SearchApp.Update();
    //    }
    //    else
    //    {
    //        this.DropDownList2.Enabled = true;
    //        this.UpdatePanel_SearchApp.Update();
    //    }
    //}
    protected void Btn_SearchApp_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_App(condition);
        Panel_App.Visible = true;
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update(); 
        //ClosePanel();
        //this.UpdatePanel_upload.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (TextDocNO.Text.ToString() != "")
        {
            temp += " and CDA_DocNO like '%" + TextDocNO.Text.ToString() + "%'";
        }
        if (TextDocName.Text.ToString() != "")
        {
            temp += " and CDA_DocName like '%" + TextDocName.Text.ToString() + "%'";
        }
        if (TextEditionNO.Text.ToString() != "")
        {
            temp += " and CDA_EditionNO like '%" + TextEditionNO.Text.ToString() + "%'";
        }
        if (TextAppNO.Text.ToString() != "")
        {
            temp += " and CDA_AppNO like '%" + TextAppNO.Text.ToString() + "%'";
        }
        if (DropDownList1.Text.ToString() != "")
        {
            temp += " and CDA_DocType='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (DropDownList2.Text.ToString() != "")
        {
            temp += " and CDA_ChangedType='" + DropDownList2.SelectedValue.ToString() + "'";
        }
        if (TextAppPer.Text.ToString() != "")
        {
            temp += " and CDA_AppPer like '%" + TextAppPer.Text.ToString() + "%'";
        }
        if (TextAppTime.Text.ToString() != "")
        {
            temp += "and DateDiff(dd,getdate(),CDA_AppTime)=DateDiff(dd,getdate(),'" + TextAppTime.Text.ToString() + "')";
            //temp += " and CDA_AppTime ='" + this.TextAppTime.Text.ToString() + "'";
        }
        if (DropDownList3.Text.ToString() != "")
        {
            temp += " and CDA_AppDep='" + DropDownList3.SelectedValue.ToString() + "'";
        }
        if (DropDownList4.Text.ToString() != "")
        {
            temp += " and CDA_AppState='" + DropDownList4.SelectedValue.ToString() + "'";
        }
        if (startime.Text.ToString() != "" && endtime.Text.ToString() != "")
        {
            temp += " and CDA_EffectDate >= '" + startime.Text.Trim() + "' and CDA_EffectDate <= '" + endtime.Text.Trim() + "'";
        }
        if (startime.Text.ToString() != "" && endtime.Text.ToString() == "")
        {
            temp += " and CDA_EffectDate >= '" + startime.Text.Trim() + "'";
        }
        if (startime.Text.ToString() == "" && endtime.Text.ToString() != "")
        {
            temp += " and CDA_EffectDate <= '" + endtime.Text.Trim() + "'";
        }
        if (Lab_Status.Text == "ControlDocApp" && Session["UserRole"].ToString().Contains("受控文件申请"))
        {
            //temp += " ";
            temp += " and a.CDA_AppDep='" + Session["Department"].ToString() + "'";
        }
        if (Lab_Status.Text == "ControlDocSpecil" && Session["UserRole"].ToString().Contains("分发特殊文件编号"))
        {
            temp += " and a.CDA_AppState='已提交' and a.CDA_DocNO is null";
        }
        if (Lab_Status.Text == "ControlDocAu" && Session["UserRole"].ToString().Contains("受控文件主管审核"))
        {
            //temp += " and a.CDA_AppState='已提交' and a.CDA_DocNO is not null";
            temp += " and a.CDA_AppState='已提交' and a.CDA_DocNO is not null and a.CDA_AppDep='" + Session["Department"].ToString() + "'";
        }
        if (Lab_Status.Text == "ControlDocSign" && Session["UserRole"].ToString().Contains("受控文件会签"))
        {
            temp += " and (a.CDA_AppState='审核通过' or a.CDA_AppState='会签中') and CDA_ID in (select CDA_ID from CDAppConSignT where BDOS_Code = '" + Session["Organization"].ToString() + "')";
        }
        if (Lab_Status.Text == "ControlDocApprov" && Session["UserRole"].ToString().Contains("受控文件审批"))
        {
            temp += " and a.CDA_AppState='会签通过'";
        }
        if (Lab_Status.Text == "ControlDocLook" && Session["UserRole"].ToString().Contains("受控文件申请查看"))
        {
            temp += "";
        }
        if (Lab_Status.Text == "ControlDocDown" && Session["UserRole"].ToString().Contains("受控文件下载"))
        {
            temp += " and a.CDA_AppState='审批通过'";
        }
        if (Lab_Status.Text == "ControlDocIn" && Session["UserRole"].ToString().Contains("受控文件录入"))
        {
            temp += " ";
        }
        if (Lab_Status.Text == "ControlDocDownlook" && Session["UserRole"].ToString().Contains("受控文件查阅"))
        {
            temp += " and a.CDA_AppState='审批通过' and CDA_ID in (select CDA_ID from CDDepDistributeDetail where CDDDCT_ID = (select c.CDDDCT_ID from CDDepDistributeCodeT c where c.CDDDCT_Dep='" + Session["Department"].ToString() + "'))";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_ClearApp_Click(object sender, EventArgs e)
    {
        TextDocNO.Text = "";
        TextDocName.Text = "";
        TextEditionNO.Text = "";
        TextAppNO.Text = "";
        DropDownList1.SelectedIndex = 0;
        //DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        //BindDropDownList2();
        DropDownList2.SelectedIndex = 0;
        TextAppPer.Text = "";
        TextAppTime.Text = "";
        DropDownList3.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList3();
        DropDownList4.SelectedIndex = 0;
        string condition = GetCondition3();
        BindGrid_App(condition);
        DropDownList2.Enabled = true;
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //ClosePanel();
        //this.UpdatePanel_upload.Update();
    }
    protected void Btn_NewApp_Click(object sender, EventArgs e)
    {
        Clear();
        Label555.Text = "新增";
        Panel1.Visible = false;
        Panel2.Enabled = true;
        Panel3.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = true;
        Panel8.Visible = false;
        Panel9.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel12.Visible = false;
        Label15.Visible = true;
        Panel15.Visible = false;
        DropDownList7.Visible = true;
        BindDropDownList5();
        string r=Session["Department"].ToString();
        DropDownList5.Text=r;
        DropDownList5.Enabled = false;
        DropDownList6.Enabled = true;
        DropDownList7.Enabled = true;
        DropDownList9.SelectedValue = "";
        newCDA_EditionNO.Enabled = false;
        newCDA_EditionNO.Text ="0";
        //this.newCDA_DocRoute.Enabled = true;
        newCDA_DocName.Enabled = true;
        DropDownList9.Enabled = true;

        BindDropDownList7();
        newCDA_AppPer.Text = Session["UserName"].ToString().Trim();
        newCDA_AppTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //this.newCDA_DocRoute.Enabled = false;
        //this.Btn_Route.Visible = true;
        newCDA_DocRoute.Visible = false;
        FileUpload1.Visible = false;
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //ClosePanel();
        //this.UpdatePanel_upload.Update();
        Panel_New.Visible = true;
        Response.Write("");
        UpdatePanel_New.Update();
    }
    //私有清空的方法
    private void Clear()
    {
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList5();
        DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList7();
        DropDownList6.SelectedIndex = 0;
        newCDA_DocName.Text = "";
        newCDA_EditionNO.Text = "";
        newCDA_DocRoute.Text = "";
        newCDA_AppReason.Text = "";
        newCDA_Remarks.Text = "";
    }
    #endregion 受控文件申请检索

    #region Grid_App相关
    protected void Grid_App_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        if (e.CommandName == "Delete_App")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid CDA_ID = new Guid(al[0]);
            string CDA_DocRoute = al[1];
            if (al[2] != "待提交" && al[2] != "审核驳回" && al[2] != "会签驳回" && al[2] != "审批驳回")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_App, GetType(), "alert", "alert('该状态下不可删除！')", true);
                return;
            }
            if (CDA_DocRoute != "")
            {
                string delfile = Server.MapPath("~/") + CDA_DocRoute;
                File.Delete(delfile);
            }
            controlldeDocL.Delete_ControlledDocApp(CDA_ID);
            string condition = GetCondition3();
            BindGrid_App(condition);
            UpdatePanel_App.Update();
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Edit_App")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string CDA_ID = al[0];
            Label_appid.Text = CDA_ID;
            string CDA_DocNO = al[1];
            newCDA_DocNO.Text = CDA_DocNO;
            string CDA_AppNO = al[2];
            newCDA_AppNO.Text = CDA_AppNO;
            string CDA_DocName = al[3];
            newCDA_DocName.Text = CDA_DocName;
            string CDA_EditionNO = al[4];
            newCDA_EditionNO.Text = CDA_EditionNO;
            string CDA_DocType = al[5];
            DropDownList6.SelectedValue = CDA_DocType;
            string CDA_ChangedType = al[6];
            //BindDropDownList7();
            //if (al[6].ToString() == "")
            //{
            //    this.DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            //    this.DropDownList7.Items.FindByValue("").Selected = true;
            //}
            //else
            //{
            //    this.DropDownList7.Items.FindByText(CDA_ChangedType.ToString().Trim()).Selected = true;
            //}
            DropDownList9.SelectedValue = CDA_ChangedType;
            string CDA_AppPer = al[7];
            newCDA_AppPer.Text = CDA_AppPer;
            DateTime CDA_AppTime = Convert.ToDateTime(al[8].ToString());
            newCDA_AppTime.Text = CDA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AppDep = al[9];
            BindDropDownList5();
            DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;
            string CDA_AppReason = al[10];
            newCDA_AppReason.Text = CDA_AppReason;
            if (al[11] != "待提交" && al[11] != "审核驳回" && al[11] != "会签驳回" && al[11] != "审批驳回")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_App, GetType(), "alert", "alert('该状态下不可编辑，请重提申请！')", true);
                return;
            }
            else
            {
                string CDA_AppState = al[11];
                newCDA_AppState.Text = CDA_AppState;
            }
            string CDA_Remarks = al[12];
            newCDA_Remarks.Text = CDA_Remarks;
            string CDA_DocRoute = al[13];
            newCDA_DocRoute.Text = CDA_DocRoute;
            string CDA_EffectDate = al[14];
            newCDA_EffectDate.Text = CDA_EffectDate;

            //newCDA_DocRoute.Visible = true;
            newCDA_DocRoute.Visible = false;
            FileUpload1.Visible = false;
            newCDA_AppNO.Visible = true;

            newCDA_DocName.Enabled = true;
            newCDA_EditionNO.Enabled = false;
            DropDownList5.Enabled = false;
            DropDownList9.Enabled = true;
            newCDA_EffectDate.Enabled = true;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Panel3.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = true;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel15.Visible = false;
            DropDownList5.Enabled = false;
            DropDownList6.Enabled = false;
            DropDownList7.Enabled = false;
            newCDA_DocRoute.Enabled = false;

            newCDA_DocNO.Enabled = false;
            newCDA_AppNO.Enabled = false;
            Panel2.Enabled = true;
            //this.Btn_Route.Visible = false;
            Btn_CDDep.Visible = true;
            Grid_CDDep.Columns[4].Visible = true;
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Btn_CDAppCon.Visible = true;
            Grid_CDAppCon.Columns[6].Visible = false;
            Grid_CDAppCon.Columns[8].Visible = false;
            Grid_CDAppCon.Columns[9].Visible = true;
            Grid_CDAppCon.Columns[10].Visible = false;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            UpdatePanel_New.Update();
            //ClosePanel();
            //this.UpdatePanel_upload.Update();
        }
        if (e.CommandName == "Specil_Code")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string CDA_ID = al[0];
            Label_appid.Text = CDA_ID;
            string CDA_DocNO = al[1];
            newCDA_DocNO.Text = CDA_DocNO;
            string CDA_AppNO = al[2];
            newCDA_AppNO.Text = CDA_AppNO;
            string CDA_DocName = al[3];
            newCDA_DocName.Text = CDA_DocName;
            string CDA_EditionNO = al[4];
            newCDA_EditionNO.Text = CDA_EditionNO;
            string CDA_DocType = al[5];
            DropDownList6.SelectedValue = CDA_DocType;
            string CDA_ChangedType = al[6];
            //BindDropDownList7();
            //if (al[6].ToString() == "")
            //{
            //    this.DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            //    this.DropDownList7.Items.FindByValue("").Selected = true;
            //}
            //else
            //{
            //    this.DropDownList7.Items.FindByText(CDA_ChangedType.ToString().Trim()).Selected = true;
            //}
            DropDownList9.SelectedValue = CDA_ChangedType;
            string CDA_AppPer = al[7];
            newCDA_AppPer.Text = CDA_AppPer;
            DateTime CDA_AppTime = Convert.ToDateTime(al[8].ToString());
            newCDA_AppTime.Text = CDA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AppDep = al[9];
            BindDropDownList5();
            DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;
            string CDA_AppReason = al[10];
            newCDA_AppReason.Text = CDA_AppReason;
            string CDA_AppState = al[11];
            newCDA_AppState.Text = CDA_AppState;
            string CDA_Remarks = al[12];
            newCDA_Remarks.Text = CDA_Remarks;
            string CDA_DocRoute = al[13];
            newCDA_DocRoute.Text = CDA_DocRoute;
            string CDA_EffectDate = al[14];
            newCDA_EffectDate.Text = CDA_EffectDate;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel3.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = true;
            Panel1.Enabled = true;
            newCDA_DocNO.Enabled = true;
            Panel2.Enabled = false;
            Panel15.Visible = false;
            newCDA_EffectDate.Enabled = false;
            //this.Btn_Route.Visible = false;
            Btn_CDDep.Visible = false;
            Grid_CDDep.Columns[4].Visible = false;
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Btn_CDAppCon.Visible = false;
            Grid_CDAppCon.Columns[6].Visible = false;
            Grid_CDAppCon.Columns[8].Visible = false;
            Grid_CDAppCon.Columns[9].Visible = false;
            Grid_CDAppCon.Columns[10].Visible = false;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Auditor")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string CDA_ID = al[0];
            Label_appid.Text = CDA_ID;
            string CDA_DocNO = al[1];
            newCDA_DocNO.Text = CDA_DocNO;
            string CDA_AppNO = al[2];
            newCDA_AppNO.Text = CDA_AppNO;
            string CDA_DocName = al[3];
            newCDA_DocName.Text = CDA_DocName;
            string CDA_EditionNO = al[4];
            newCDA_EditionNO.Text = CDA_EditionNO;
            string CDA_DocType = al[5];
            DropDownList6.SelectedValue = CDA_DocType;
            
            string CDA_ChangedType = al[6];
            //BindDropDownList7();
            //if (al[6].ToString() == "")
            //{
            //    this.DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            //    this.DropDownList7.Items.FindByValue("").Selected = true;
            //}
            //else
            //{
            //    this.DropDownList7.Items.FindByText(CDA_ChangedType.ToString().Trim()).Selected = true;
            //}
            DropDownList9.SelectedValue = CDA_ChangedType;
            string CDA_AppPer = al[7];
            newCDA_AppPer.Text = CDA_AppPer;
            DateTime CDA_AppTime = Convert.ToDateTime(al[8].ToString());
            newCDA_AppTime.Text = CDA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AppDep = al[9];
            //if (Session["Organization"] != null && Session["Organization"].ToString() != "" && Session["Department"].ToString() == CDA_AppDep)
            //{
            //    BindDropDownList5();
            //    this.DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('对不起，您没有该部门的审核权限！')", true);
            //    return;
            //}
            BindDropDownList5();
            DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;

            string CDA_AppReason = al[10];
            newCDA_AppReason.Text = CDA_AppReason;
            string CDA_AppState = al[11];
            newCDA_AppState.Text = CDA_AppState;
            string CDA_Remarks = al[12];
            newCDA_Remarks.Text = CDA_Remarks;
            string CDA_DocRoute = al[13];
            newCDA_DocRoute.Text = CDA_DocRoute;
            string CDA_EffectDate = al[14];
            newCDA_EffectDate.Text = CDA_EffectDate;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel3.Visible = true;
            Panel5.Visible = true;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = true;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel1.Enabled = false;
            Panel2.Enabled = false;
            newCDA_EffectDate.Enabled = false;
            Panel15.Visible = false;
            //this.Btn_Route.Visible = false;
            newCDA_AppNO.Visible = true;
            Btn_CDDep.Visible = false;
            Grid_CDDep.Columns[4].Visible = false;
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Btn_CDAppCon.Visible = false;
            Grid_CDAppCon.Columns[6].Visible = false;
            Grid_CDAppCon.Columns[8].Visible = false;
            Grid_CDAppCon.Columns[9].Visible = false;
            Grid_CDAppCon.Columns[10].Visible = false;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            newCDA_Auditor.Text = Session["UserName"].ToString().Trim();
            newCDA_AuTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Label26.Visible = false;
            newETA_AuRes.Visible = false;
            Panel5.Enabled = true;
            Panel6.Enabled = true;

            UpdatePanel_New.Update();
        }
        if (e.CommandName == "SignPer")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string CDA_ID = al[0];
            Label_appid.Text = CDA_ID;
            string CDA_DocNO = al[1];
            newCDA_DocNO.Text = CDA_DocNO;
            string CDA_AppNO = al[2];
            newCDA_AppNO.Text = CDA_AppNO;
            string CDA_DocName = al[3];
            newCDA_DocName.Text = CDA_DocName;
            string CDA_EditionNO = al[4];
            newCDA_EditionNO.Text = CDA_EditionNO;
            string CDA_DocType = al[5];
            DropDownList6.SelectedValue = CDA_DocType;
            string CDA_ChangedType = al[6];
            //BindDropDownList7();
            //if (al[6].ToString() == "")
            //{
            //    this.DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            //    this.DropDownList7.Items.FindByValue("").Selected = true;
            //}
            //else
            //{
            //    this.DropDownList7.Items.FindByText(CDA_ChangedType.ToString().Trim()).Selected = true;
            //}
            DropDownList9.SelectedValue = CDA_ChangedType;
            string CDA_AppPer = al[7];
            newCDA_AppPer.Text = CDA_AppPer;
            DateTime CDA_AppTime = Convert.ToDateTime(al[8].ToString());
            newCDA_AppTime.Text = CDA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AppDep = al[9];
            BindDropDownList5();
            DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;
            string CDA_AppReason = al[10];
            newCDA_AppReason.Text = CDA_AppReason;
            string CDA_AppState = al[11];
            newCDA_AppState.Text = CDA_AppState;
            string CDA_Remarks = al[12];
            newCDA_Remarks.Text = CDA_Remarks;
            string CDA_DocRoute = al[13];
            newCDA_DocRoute.Text = CDA_DocRoute;
            string CDA_Auditor = al[14];
            newCDA_Auditor.Text = CDA_Auditor;
            DateTime CDA_AuTime = Convert.ToDateTime(al[15].ToString());
            newCDA_AuTime.Text = CDA_AuTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AuSugg = al[16];
            newCDA_AuSugg.Text = CDA_AuSugg;
            string ETA_AuRes = al[17];
            newETA_AuRes.Text = ETA_AuRes;
            string CDA_EffectDate = al[18];
            newCDA_EffectDate.Text = CDA_EffectDate;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel3.Visible = true;
            Panel5.Visible = true;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = true;
            Panel12.Visible = false;
            Panel1.Enabled = false;
            Panel2.Enabled = false;
            Panel5.Enabled = false;
            newCDA_EffectDate.Enabled = false;
            Panel15.Visible = false;
            //this.Btn_Route.Visible = false;
            newCDA_AppNO.Visible = true;
            Btn_CDDep.Visible = false;
            Grid_CDDep.Columns[4].Visible = false;
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Btn_CDAppCon.Visible = false;
            Grid_CDAppCon.Columns[6].Visible = true;
            Grid_CDAppCon.Columns[8].Visible = true;
            Grid_CDAppCon.Columns[9].Visible = false;
            Grid_CDAppCon.Columns[10].Visible = true;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            Label26.Visible = true;
            newETA_AuRes.Visible = true;
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Approver")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string CDA_ID = al[0];
            Label_appid.Text = CDA_ID;
            string CDA_DocNO = al[1];
            newCDA_DocNO.Text = CDA_DocNO;
            string CDA_AppNO = al[2];
            newCDA_AppNO.Text = CDA_AppNO;
            string CDA_DocName = al[3];
            newCDA_DocName.Text = CDA_DocName;
            string CDA_EditionNO = al[4];
            newCDA_EditionNO.Text = CDA_EditionNO;
            string CDA_DocType = al[5];
            DropDownList6.SelectedValue = CDA_DocType;
            string CDA_ChangedType = al[6];
            //BindDropDownList7();
            //if (al[6].ToString() == "")
            //{
            //    this.DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            //    this.DropDownList7.Items.FindByValue("").Selected = true;
            //}
            //else
            //{
            //    this.DropDownList7.Items.FindByText(CDA_ChangedType.ToString().Trim()).Selected = true;
            //}
            DropDownList9.SelectedValue = CDA_ChangedType;
            string CDA_AppPer = al[7];
            newCDA_AppPer.Text = CDA_AppPer;
            DateTime CDA_AppTime = Convert.ToDateTime(al[8].ToString());
            newCDA_AppTime.Text = CDA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AppDep = al[9];
            BindDropDownList5();
            DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;
            string CDA_AppReason = al[10];
            newCDA_AppReason.Text = CDA_AppReason;
            string CDA_AppState = al[11];
            newCDA_AppState.Text = CDA_AppState;
            string CDA_Remarks = al[12];
            newCDA_Remarks.Text = CDA_Remarks;
            string CDA_DocRoute = al[13];
            newCDA_DocRoute.Text = CDA_DocRoute;
            string CDA_Auditor = al[14];
            newCDA_Auditor.Text = CDA_Auditor;
            DateTime CDA_AuTime = Convert.ToDateTime(al[15].ToString());
            newCDA_AuTime.Text = CDA_AuTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AuSugg = al[16];
            newCDA_AuSugg.Text = CDA_AuSugg;
            string ETA_AuRes = al[17];
            newETA_AuRes.Text = ETA_AuRes;
            string CDA_EffectDate = al[18];
            newCDA_EffectDate.Text = CDA_EffectDate;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel3.Visible = true;
            Panel5.Visible = true;
            Panel6.Visible = true;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = true;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel1.Enabled = false;
            Panel2.Enabled = false;
            newCDA_EffectDate.Enabled = false;
            Panel15.Visible = false;
            //this.Btn_Route.Visible = false;
            newCDA_AppNO.Visible = true;
            Btn_CDDep.Visible = false;
            Grid_CDDep.Columns[4].Visible = false;
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Btn_CDAppCon.Visible = false;
            Grid_CDAppCon.Columns[6].Visible = true;
            Grid_CDAppCon.Columns[8].Visible = true;
            Grid_CDAppCon.Columns[9].Visible = false;
            Grid_CDAppCon.Columns[10].Visible = false;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            Panel6.Enabled = true;
            newCDA_Approver.Text = Session["UserName"].ToString().Trim();
            newCDA_ApprovalT.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Label26.Visible = true;
            newETA_AuRes.Visible = true;
            Label29.Visible = false;
            newCDA_ApprovalRes.Visible = false;
            Panel5.Enabled = false;
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Look_App")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string CDA_ID = al[0];
            Label_appid.Text = CDA_ID;
            string CDA_DocNO = al[1];
            newCDA_DocNO.Text = CDA_DocNO;
            string CDA_AppNO = al[2];
            newCDA_AppNO.Text = CDA_AppNO;
            string CDA_DocName = al[3];
            newCDA_DocName.Text = CDA_DocName;
            string CDA_EditionNO = al[4];
            newCDA_EditionNO.Text = CDA_EditionNO;
            string CDA_DocType = al[5];
            DropDownList6.SelectedValue = CDA_DocType;
            string CDA_ChangedType = al[6];
            //BindDropDownList7();
            //if (al[6].ToString() == "")
            //{
            //    this.DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            //    this.DropDownList7.Items.FindByValue("").Selected = true;
            //}
            //else
            //{
            //    this.DropDownList7.Items.FindByText(CDA_ChangedType.ToString().Trim()).Selected = true;
            //}
            DropDownList9.SelectedValue = CDA_ChangedType;
            string CDA_AppPer = al[7];
            newCDA_AppPer.Text = CDA_AppPer;
            DateTime CDA_AppTime = Convert.ToDateTime(al[8].ToString());
            newCDA_AppTime.Text = CDA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string CDA_AppDep = al[9];
            BindDropDownList5();
            DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;
            string CDA_AppReason = al[10];
            newCDA_AppReason.Text = CDA_AppReason;
            string CDA_AppState = al[11];
            newCDA_AppState.Text = CDA_AppState;
            string CDA_Remarks = al[12];
            newCDA_Remarks.Text = CDA_Remarks;
            string CDA_DocRoute = al[13];
            newCDA_DocRoute.Text = CDA_DocRoute;
            string CDA_Auditor = al[14];
            newCDA_Auditor.Text = CDA_Auditor;
            if (al[15] == "")
            {
                newCDA_AuTime.Text = "";
            }
            else
            {
                DateTime CDA_AuTime = Convert.ToDateTime(al[15].ToString());
                newCDA_AuTime.Text = CDA_AuTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string CDA_AuSugg = al[16];
            newCDA_AuSugg.Text = CDA_AuSugg;
            string ETA_AuRes = al[17];
            newETA_AuRes.Text = ETA_AuRes;
            string CDA_Approver = al[18];
            newCDA_Approver.Text = CDA_Approver;
            if (al[19] == "")
            {
                newCDA_ApprovalT.Text = "";
            }
            else
            {
                DateTime CDA_ApprovalT = Convert.ToDateTime(al[19].ToString());
                newCDA_ApprovalT.Text = CDA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string CDA_ApprovalSugg = al[20];
            newCDA_ApprovalSugg.Text = CDA_ApprovalSugg;
            string CDA_ApprovalRes = al[21];
            newCDA_ApprovalRes.Text = CDA_ApprovalRes;
            string CDA_EffectDate = al[22];
            newCDA_EffectDate.Text = CDA_EffectDate;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel3.Visible = true;
            Panel5.Visible = true;
            Panel6.Visible = true;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = true;
            Panel12.Visible = false;
            Panel1.Enabled = false;
            Panel2.Enabled = false;
            Panel5.Enabled = false;
            Panel6.Enabled = false;
            Panel15.Visible = false;
            newCDA_EffectDate.Enabled = false;
            //this.Btn_Route.Visible = false;
            newCDA_AppNO.Visible = true;
            Btn_CDDep.Visible = false;
            Grid_CDDep.Columns[4].Visible = false;
            Btn_CDAppCon.Visible = false;
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Grid_CDAppCon.Columns[6].Visible = true;
            Grid_CDAppCon.Columns[8].Visible = true;
            Grid_CDAppCon.Columns[9].Visible = false;
            Grid_CDAppCon.Columns[10].Visible = false;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            Label26.Visible = true;
            newETA_AuRes.Visible = true;
            Label29.Visible = true;
            newCDA_ApprovalRes.Visible = true;
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Change_App1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_App.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string CDA_DocName = al[0];
            newCDA_DocName.Text = CDA_DocName;
            string CDA_EditionNO = al[1];
            newCDA_EditionNO.Text = CDA_EditionNO;
            string CDA_DocType = al[2];
            DropDownList6.SelectedValue = CDA_DocType;
            string CDA_AppDep = al[3];
            BindDropDownList5();
            DropDownList5.Items.FindByText(CDA_AppDep.ToString().Trim()).Selected = true;
            if (al[4] == "")
            {
                Label_CDTLC_ID.Text = "";
            }
            else
            { 
                Guid CDTLC_ID=new Guid(al[4]);
                Label_CDTLC_ID.Text = CDTLC_ID.ToString();
            }
            string CDA_DocNO=al[5];
            Label_CDA_DocNO.Text = CDA_DocNO;
            Guid CDA_ID = new Guid (al[6]);

            if (al[7]!= "审批通过")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('原版文件尚未审批通过，不能进行换版申请！')", true);
                return;
            }

            DataSet ds = controlldeDocL.Search_ControlledDocApp_change_newest(CDA_DocNO);
            if (CDA_ID.ToString() != ds.Tables[0].Rows[0]["CDA_ID"].ToString())
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('请在最新版文件上进行换版申请！')", true);
                return;
            }
            DropDownList9.Text = "修改文件";
            Label555.Text = "换版";

            newCDA_DocRoute.Visible = false;
            //FileUpload1.Visible = true;
            FileUpload1.Visible = false;

            newCDA_DocName.Enabled = true;
            newCDA_EditionNO.Enabled = true;
            DropDownList5.Enabled = false;
            newCDA_EffectDate.Enabled = true;

            Panel_New.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            Panel7.Visible = true;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel15.Visible = false;

            DropDownList6.Enabled = false;
            DropDownList5.Enabled = false;
            DropDownList9.Enabled = false;
            newCDA_AppPer.Text = Session["UserName"].ToString().Trim();
            newCDA_AppTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Response.Write("");
            UpdatePanel_New.Update();
            //ClosePanel();
            //this.UpdatePanel_upload.Update();
        }
    }
    //Gridview翻页
    protected void Grid_App_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_App.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox1");   // refer to the TextBox with the NewPageIndex value
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
        string condition = GetCondition();
        BindGrid_App(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_App.PageCount ? Grid_App.PageCount - 1 : newPageIndex;
        Grid_App.PageIndex = newPageIndex;
        Grid_App.DataBind();
    }
    //Gridview行变色
    protected void Grid_App_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion Grid_App相关

    #region 新增受控文件申请
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList6.SelectedValue.ToString() != "第三层次文件")
        {
            DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList7();
            DropDownList7.Enabled = false;
            UpdatePanel_New.Update();
        }
        else
        {
            DropDownList7.Enabled = true;
            UpdatePanel_New.Update();
        }
    }
    //新增保存
    protected void Btn_Savenew_Click(object sender, EventArgs e)
    {
        //#region 上传
        //var extension = Path.GetExtension(FileUpload1.FileName);
        //if (extension == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('标记*的为必填项，请填写完整！')", true);
        //    return;
        //}
        //string fileExrensio = extension.ToLower();//ToLower转化为小写,获得扩展名
        //string UploadURL = Server.MapPath("~/file/");//上传的目录
        //string fullname = FileUpload1.FileName;//上传文件的原名
        //string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
        //if (extension != null)
        //{
        //    if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx" || fileExrensio == ".rar" || fileExrensio == ".zip")//判断文件扩展名
        //    {
        //        try
        //        {
        //            if (!Directory.Exists(UploadURL))//判断文件夹是否已经存在
        //            {
        //                Directory.CreateDirectory(UploadURL);//创建文件夹
        //            }
        //            FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
        //        }
        //        catch
        //        {
        //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('上传失败!')", true);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('不支持此文件格式!')", true);
        //        return;
        //    }
        //}
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('请选择文件!')", true);
        //    return;
        //}

        //string filePath = "file/" + newname + fullname;
        //newCDA_DocRoute.Text = filePath;
        //#endregion 上传

        if (newCDA_DocName.Text.ToString() == "" || newCDA_EditionNO.Text.ToString() == "" || DropDownList5.SelectedValue.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || DropDownList9.SelectedValue.ToString() == ""||newCDA_EffectDate.Text.ToString()=="")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string CDA_DocName=newCDA_DocName.Text.ToString();
        string CDA_EditionNO = newCDA_EditionNO.Text.ToString();
        string CDA_DocType=DropDownList6.SelectedValue.ToString();
        string CDA_ChangedType = DropDownList9.SelectedValue.ToString();
        string CDA_AppPer = newCDA_AppPer.Text.ToString();
        DateTime CDA_AppTime = Convert.ToDateTime(newCDA_AppTime.Text.ToString());
        string CDA_AppDep=DropDownList5.SelectedValue.ToString();
        string CDA_AppReason=newCDA_AppReason.Text.ToString();
        string CDA_AppState="待提交";
        string CDA_Remarks=newCDA_Remarks.Text.ToString();
        //string CDA_DocRoute = newCDA_DocRoute.Text.ToString();
        string CDA_DocRoute = "";
        string CDTLC_DocType = DropDownList7.SelectedValue.ToString();
        DateTime CDA_EffectDate = Convert.ToDateTime(newCDA_EffectDate.Text.ToString());

        if (Label555.Text == "新增")
        {
            if (CDA_DocType == "第三层次文件" && DropDownList7.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请为第三层次文件选择文件类别！')", true);
                return;
            }
            if (CDA_DocType == "第三层次文件")
            {
                DataSet u = basicCodeL.Search_BDOrganization_depcode("and BDOS_Name = '" + CDA_AppDep + "'");
                DataTable rr = u.Tables[0];
                if (rr.Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('文件申请失败，请先申请部门编号！')", true);
                    return;
                }
            }
            DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocName = '" + CDA_DocName + "' and CDA_EditionNO='" + CDA_EditionNO + "' and CDA_ChangedType='" + CDA_ChangedType + "' and CDA_DocType='" + CDA_DocType + "'");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已申请，不能重复！')", true);
                return;
            }
            Guid aa = controlldeDocL.Insert_ControlledDocApp(CDA_DocName, CDA_EditionNO, CDA_DocType, CDA_ChangedType, CDA_AppPer, CDA_AppTime, CDA_AppDep, CDA_AppReason, CDA_AppState, CDA_Remarks, CDA_DocRoute, CDTLC_DocType, CDA_EffectDate);
            string condition = GetCondition3();
            BindGrid_App(condition);
            UpdatePanel_App.Update();
            //this.Panel_New.Visible = false;
            //this.UpdatePanel_New.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择分发岗位和会签部门！')", true);

            //newCDA_DocRoute.Visible = true;
            newCDA_DocRoute.Visible = false;
            FileUpload1.Visible = false;

            Panel_New.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = true;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            DropDownList5.Enabled = false;
            DropDownList6.Enabled = false;
            DropDownList7.Enabled = false;
            newCDA_DocRoute.Enabled = false;

            newCDA_DocNO.Enabled = false;
            newCDA_AppNO.Enabled = false;
            Panel2.Enabled = true;
            //this.Btn_Route.Visible = false;
            Btn_CDDep.Visible = true;
            Grid_CDDep.Columns[4].Visible = true;
            Label_appid.Text = aa.ToString();
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Btn_CDAppCon.Visible = true;
            Grid_CDAppCon.Columns[6].Visible = false;
            Grid_CDAppCon.Columns[8].Visible = false;
            Grid_CDAppCon.Columns[9].Visible = true;
            Grid_CDAppCon.Columns[10].Visible = false;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            UpdatePanel_New.Update();
            //ClosePanel();
            //this.UpdatePanel_upload.Update();
        }
        if (Label555.Text == "换版")
        {
            string CDA_DocNO=Label_CDA_DocNO.Text;
            DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocName = '" + CDA_DocName + "' and CDA_EditionNO='" + CDA_EditionNO + "' and CDA_ChangedType='" + CDA_ChangedType + "' and CDA_DocType='" + CDA_DocType + "'");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已申请，不能重复！')", true);
                return;
            }
            Guid bb = controlldeDocL.Insert_ControlledDocApp_change(CDA_DocNO, CDA_DocName, CDA_EditionNO, CDA_DocType, CDA_ChangedType, CDA_AppPer, CDA_AppTime, CDA_AppDep, CDA_AppReason, CDA_AppState, CDA_Remarks, CDA_DocRoute, CDA_EffectDate);
            string condition = GetCondition3();
            BindGrid_App(condition);
            UpdatePanel_App.Update();
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择分发岗位和会签部门！')", true);

            //newCDA_DocRoute.Visible = true;
            newCDA_DocRoute.Visible = false;
            FileUpload1.Visible = false;

            Panel_New.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = true;
            Label15.Visible = false;
            DropDownList7.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = true;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            DropDownList5.Enabled = false;
            DropDownList6.Enabled = false;
            DropDownList7.Enabled = false;
            newCDA_DocRoute.Enabled = false;

            newCDA_DocNO.Enabled = false;
            newCDA_AppNO.Enabled = false;
            Panel2.Enabled = true;
            //this.Btn_Route.Visible = false;
            Btn_CDDep.Visible = true;
            Grid_CDDep.Columns[4].Visible = true;
            Label_appid.Text = bb.ToString();
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            Btn_CDAppCon.Visible = true;
            Grid_CDAppCon.Columns[6].Visible = false;
            Grid_CDAppCon.Columns[8].Visible = false;
            Grid_CDAppCon.Columns[9].Visible = true;
            Grid_CDAppCon.Columns[10].Visible = false;
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            UpdatePanel_New.Update();
            //ClosePanel();
            //this.UpdatePanel_upload.Update();
        }
    }
    //新增取消
    protected void Btn_Cancelnew_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        //ClosePanel();
        //this.UpdatePanel_upload.Update();
    }
    #endregion 新增受控文件申请

    #region Grid_CDDep及选择分发岗位按钮
    protected void Btn_CDDep_Click(object sender, EventArgs e)
    {
        BindGrid_chooseCDDep("");
        //BindDropDownList8();
        Panel_chooseCDDep.Visible = true;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
    }
    protected void Grid_CDDep_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_CDDep")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_CDDep.SelectedIndex = row.RowIndex;

            Guid CDDDD_ID = new Guid(Convert.ToString(e.CommandArgument));
            controlldeDocL.Delete_CDDepDistributeDetail(CDDDD_ID);
            BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
            UpdatePanel_New.Update();
        }
    }
    //Gridview翻页
    protected void Grid_CDDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_CDDep.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox2");   // refer to the TextBox with the NewPageIndex value
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
        BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_CDDep.PageCount ? Grid_CDDep.PageCount - 1 : newPageIndex;
        Grid_CDDep.PageIndex = newPageIndex;
        Grid_CDDep.DataBind();
    }
    //Gridview行变色
    protected void Grid_CDDep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion Grid_CDDep及选择分发岗位按钮

    #region 选择分发岗位
    //精确搜索
    protected void Search_chooseDep_Click(object sender, EventArgs e)
    {
        string condition1 = GetCondition1();
        BindGrid_chooseCDDep(condition1);
    }
    protected string GetCondition1()
    {
        string condition1;
        string temp = "";
        //if (this.DropDownList8.Text.ToString() != "")
        //{
        //    temp += " and b.BDOS_Name = '" + this.DropDownList8.SelectedValue.ToString() + "'";
        //}
        if (TextchooseDep.Text.ToString() != "")
        {
            temp += " and a.CDDDCT_Dep like  '%" + TextchooseDep.Text.ToString() + "%'";
        }
        condition1 = temp;
        return condition1;
    }
    protected void Clear_chooseDep_Click(object sender, EventArgs e)
    {
        //DropDownList8.Items.Insert(0, new ListItem("请选择", ""));
        //BindDropDownList8();
        TextchooseDep.Text = "";
        BindGrid_chooseCDDep("");
    }
    //选中的行，翻页不消失
    protected ArrayList SelectedItems1
    {
        get
        {
            return (ViewState["mySelectedItems1"] != null) ? (ArrayList)ViewState["mySelectedItems1"] : null;
        }
        set
        {
            ViewState["mySelectedItems1"] = value;
        }
    }
    protected void CollectSelected1()
    {
        ArrayList selectedItems1 = null;
        if (SelectedItems1 == null)
            selectedItems1 = new ArrayList();
        else
            selectedItems1 = SelectedItems1;
        //获取选择的记录
        for (int i = 0; i < Grid_chooseCDDep.Rows.Count; i++)
        {
            CheckBox cb = Grid_chooseCDDep.Rows[i].FindControl("ckb1") as CheckBox;
            string id = Grid_chooseCDDep.DataKeys[i].Values[0].ToString();
            if (selectedItems1.Contains(id) && !cb.Checked)
                selectedItems1.Remove(id);
            if (!selectedItems1.Contains(id) && cb.Checked)
                selectedItems1.Add(id);
        }
        SelectedItems1 = selectedItems1;
    }
    //GridView
    protected void Grid_chooseCDDep_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void Grid_chooseCDDep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_chooseCDDep.BottomPagerRow;

            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox5");   // refer to the TextBox with the NewPageIndex value
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
        CollectSelected1();
        string condition1 = GetCondition1();
        BindGrid_chooseCDDep(condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_chooseCDDep.PageCount ? Grid_chooseCDDep.PageCount - 1 : newPageIndex;
        Grid_chooseCDDep.PageIndex = newPageIndex;
        Grid_chooseCDDep.DataBind();
    }
    protected void Grid_chooseCDDep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //这里的处理是为了回显之前选中的情况
        if (e.Row.RowIndex > -1 && SelectedItems1 != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("ckb1") as CheckBox;
            string id = Grid_chooseCDDep.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems1.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }

    //选择以及提交
    protected void BtnOK_chooseDep_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Grid_chooseCDDep.Rows)
        {
            CheckBox cb = item.FindControl("ckb1") as CheckBox;
            if (cb.Checked)
            {
                Guid CDDDCT_ID = new Guid(Grid_chooseCDDep.DataKeys[item.RowIndex].Value.ToString());
                Guid CDA_ID = new Guid(Label_appid.Text.ToString());
                DataSet ds = controlldeDocL.Search_CDDepDistributeDetail("and a.CDDDCT_ID='" + CDDDCT_ID + "' and a.CDA_ID='" + CDA_ID + "'");
                //if (!(ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的则添加。
                if (!(ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的也不添加。
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_chooseCDDep, GetType(), "aa", "alert('该岗位已选，不能重复选择!')", true);
                    return;
                }
                else
                {
                    controlldeDocL.Insert_CDDepDistributeDetail(CDDDCT_ID, CDA_ID);
                    BindGrid_CDDep(" and a.CDA_ID='" + Label_appid.Text + "'");
                    UpdatePanel_New.Update();
                    UpdatePanel_chooseCDDep.Update();
                }
            }
        }
    }
    protected void BtnCancel_chooseDep_Click(object sender, EventArgs e)
    {
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
    }
    #endregion 选择分发岗位

    #region Grid_CDAppCon及选择会签部门按钮
    protected void Btn_CDAppCon_Click(object sender, EventArgs e)
    {
        BindGrid_chooseBDO("");
        Panel_chooseBDO.Visible = true;
        UpdatePanel_chooseBDO.Update();
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
    }
    protected void Grid_CDAppCon_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_CDAppCon")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_CDAppCon.SelectedIndex = row.RowIndex;

            Guid CDAST_ID = new Guid(Convert.ToString(e.CommandArgument));
            controlldeDocL.Delete_CDAppConSignT(CDAST_ID);
            BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "look_CDAppCon")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_CDAppCon.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string BDOS_Name = al[0];
            Label999.Text = BDOS_Name;
            string CDAST_SignPer = al[1];
            newCDAST_SignPer.Text = CDAST_SignPer;
            if (al[2] == "")
            {
                newCDAST_SignTime.Text = "";
            }
            else
            {
                DateTime CDAST_SignTime = Convert.ToDateTime(al[2]);
                newCDAST_SignTime.Text = CDAST_SignTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string CDAST_SignSugg = al[3];
            newCDAST_SignSugg.Text = CDAST_SignSugg;
            string CDAST_SignRes = al[4];
            newCDAST_SignRes.Text = CDAST_SignRes;

            Panel_Sign.Visible = true;
            Label37.Visible = true;
            newCDAST_SignRes.Visible = true;
            Panel4.Enabled = false;
            Panel13.Visible = false;
            Panel14.Visible = true;
            UpdatePanel_Sign.Update();
        }
        if (e.CommandName == "Sign_CDAppCon")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_CDAppCon.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string BDOS_Name = al[0];
            Label999.Text = BDOS_Name;
            string CDAST_ID = al[1];
            Label_CDASTid.Text = CDAST_ID;
            string BDOS_Code = al[2];
            if (Session["Organization"] != null && Session["Organization"].ToString() != "" && Session["Organization"].ToString() == BDOS_Code)
            {
                Panel_Sign.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('对不起，您没有该部门的会签权限！')", true);
                return;
            }
            Label37.Visible = false;
            newCDAST_SignRes.Visible = false;
            Panel4.Enabled = true;
            Panel13.Visible = true;
            Panel14.Visible = false;
            newCDAST_SignSugg.Text = "";
            newCDAST_SignPer.Text = Session["UserName"].ToString().Trim();
            newCDAST_SignTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            UpdatePanel_Sign.Update();
        }
    }
    //Gridview翻页
    protected void Grid_CDAppCon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_CDAppCon.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox3");   // refer to the TextBox with the NewPageIndex value
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
        BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_CDAppCon.PageCount ? Grid_CDAppCon.PageCount - 1 : newPageIndex;
        Grid_CDAppCon.PageIndex = newPageIndex;
        Grid_CDAppCon.DataBind();
    }
    //Gridview行变色
    protected void Grid_CDAppCon_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion Grid_CDAppCon及选择会签部门按钮

    #region 选择会签部门
    //精确搜索
    protected void Search_chooseBDO_Click(object sender, EventArgs e)
    {
        string condition2 = GetCondition2();
        BindGrid_chooseBDO(condition2);
    }
    protected string GetCondition2()
    {
        string condition2;
        string temp = "";
        if (TextchooseBDO.Text.ToString() != "")
        {
            temp += " and BDOS_Name like '%" + TextchooseBDO.Text.ToString() + "%'";
        }
        condition2 = temp;
        return condition2;
    }
    protected void Clear_chooseBDO_Click(object sender, EventArgs e)
    {
        TextchooseBDO.Text = "";
        BindGrid_chooseBDO("");
    }
    //选中的行，翻页不消失
    protected ArrayList SelectedItems2
    {
        get
        {
            return (ViewState["mySelectedItems2"] != null) ? (ArrayList)ViewState["mySelectedItems2"] : null;
        }
        set
        {
            ViewState["mySelectedItems2"] = value;
        }
    }
    protected void CollectSelected2()
    {
        ArrayList selectedItems2 = null;
        if (SelectedItems2 == null)
            selectedItems2 = new ArrayList();
        else
            selectedItems2 = SelectedItems2;
        //获取选择的记录
        for (int i = 0; i < Grid_chooseBDO.Rows.Count; i++)
        {
            CheckBox cb = Grid_chooseBDO.Rows[i].FindControl("ckb2") as CheckBox;
            string id = Grid_chooseBDO.DataKeys[i].Values[0].ToString();
            if (selectedItems2.Contains(id) && !cb.Checked)
                selectedItems2.Remove(id);
            if (!selectedItems2.Contains(id) && cb.Checked)
                selectedItems2.Add(id);
        }
        SelectedItems2 = selectedItems2;
    }
    //GridView
    protected void Grid_chooseBDO_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void Grid_chooseBDO_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_chooseBDO.BottomPagerRow;

            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox6");   // refer to the TextBox with the NewPageIndex value
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
        CollectSelected2();
        string condition2 = GetCondition2();
        BindGrid_chooseBDO(condition2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_chooseBDO.PageCount ? Grid_chooseBDO.PageCount - 1 : newPageIndex;
        Grid_chooseBDO.PageIndex = newPageIndex;
        Grid_chooseBDO.DataBind();
    }
    protected void Grid_chooseBDO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //这里的处理是为了回显之前选中的情况
        if (e.Row.RowIndex > -1 && SelectedItems2 != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("ckb2") as CheckBox;
            string id = Grid_chooseBDO.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems2.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }

    //选择以及提交
    protected void BtnOK_chooseBDO_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Grid_chooseBDO.Rows)
        {
            CheckBox cb = item.FindControl("ckb2") as CheckBox;
            if (cb.Checked)
            {
                string BDOS_Code = Grid_chooseBDO.DataKeys[item.RowIndex].Value.ToString();
                Guid CDA_ID = new Guid(Label_appid.Text.ToString());
                DataSet ds = controlldeDocL.Search_CDAppConSignT("and a.BDOS_Code='" + BDOS_Code + "' and a.CDA_ID='" + CDA_ID + "'");
                //if (!(ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的则添加。
                if (!(ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的也不添加。
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_chooseBDO, GetType(), "aa", "alert('该部门已选，不能重复选择!')", true);
                    return;
                }
                else
                {
                    controlldeDocL.Insert_CDAppConSignT(BDOS_Code, CDA_ID);
                    BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
                    UpdatePanel_New.Update();
                    UpdatePanel_chooseBDO.Update();
                }
            }
        }
    }
    protected void BtnCancel_chooseBDO_Click(object sender, EventArgs e)
    {
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
    }
    #endregion 选择会签部门

    #region 编辑受控文件（同时选择分发岗位和会签部门）
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        //if (newCDA_DocName.Text.ToString() == "" || newCDA_EditionNO.Text.ToString() == "" || DropDownList5.SelectedValue.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || DropDownList9.SelectedValue.ToString() == "" || newCDA_DocRoute.Text.ToString() == ""||newCDA_EffectDate.Text.ToString()=="")
        if (newCDA_DocName.Text.ToString() == "" || newCDA_EditionNO.Text.ToString() == "" || DropDownList5.SelectedValue.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || DropDownList9.SelectedValue.ToString() == "" || newCDA_EffectDate.Text.ToString() == "")
        {
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
        return;
        }
        Guid CDA_ID=new Guid(Label_appid.Text.ToString());
        string CDA_DocName=newCDA_DocName.Text.ToString();
        string CDA_EditionNO=newCDA_EditionNO.Text.ToString();
        string CDA_AppPer = newCDA_AppPer.Text.ToString();
        DateTime CDA_AppTime = Convert.ToDateTime(newCDA_AppTime.Text.ToString());
        string CDA_AppReason=newCDA_AppReason.Text.ToString();
        string CDA_AppState="待提交";
        string CDA_Remarks=newCDA_Remarks.Text.ToString();
        string CDA_ChangedType = DropDownList9.SelectedValue.ToString();
        DateTime CDA_EffectDate = Convert.ToDateTime(newCDA_EffectDate.Text.ToString());

        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocName = '" + CDA_DocName + "' and CDA_EditionNO='" + CDA_EditionNO + "' and CDA_ID!='" + CDA_ID + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已申请，不能重复！')", true);
            return;
        }
        controlldeDocL.Update_ControlledDocApp(CDA_ID, CDA_DocName, CDA_EditionNO, CDA_AppPer, CDA_AppTime, CDA_AppReason, CDA_AppState, CDA_Remarks, CDA_ChangedType,CDA_EffectDate);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        //if (newCDA_DocName.Text.ToString() == "" || newCDA_EditionNO.Text.ToString() == "" || DropDownList5.SelectedValue.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || DropDownList9.SelectedValue.ToString() == "" || newCDA_DocRoute.Text.ToString() == "" || newCDA_EffectDate.Text.ToString() == "")
        if (newCDA_DocName.Text.ToString() == "" || newCDA_EditionNO.Text.ToString() == "" || DropDownList5.SelectedValue.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || DropDownList9.SelectedValue.ToString() == "" || newCDA_EffectDate.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (Grid_CDDep.Rows.Count <= 0 || Grid_CDAppCon.Rows.Count <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择分发岗位和会签部门后再提交！')", true);
            return;
        }
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());
        string CDA_DocName = newCDA_DocName.Text.ToString();
        string CDA_EditionNO = newCDA_EditionNO.Text.ToString();
        string CDA_AppPer = newCDA_AppPer.Text.ToString();
        DateTime CDA_AppTime = Convert.ToDateTime(newCDA_AppTime.Text.ToString());
        string CDA_AppReason = newCDA_AppReason.Text.ToString();
        string CDA_AppState = "已提交";
        string CDA_Remarks = newCDA_Remarks.Text.ToString();
        string CDA_ChangedType = DropDownList9.SelectedValue.ToString();
        DateTime CDA_EffectDate = Convert.ToDateTime(newCDA_EffectDate.Text.ToString());

        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocName = '" + CDA_DocName + "' and CDA_EditionNO='" + CDA_EditionNO + "' and CDA_ID!='" + CDA_ID + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已申请，不能重复！')", true);
            return;
        }
        controlldeDocL.Update_ControlledDocApp(CDA_ID, CDA_DocName, CDA_EditionNO, CDA_AppPer, CDA_AppTime, CDA_AppReason, CDA_AppState, CDA_Remarks, CDA_ChangedType, CDA_EffectDate);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
        //RTX
        if(DropDownList6.SelectedValue.ToString() == "其他文件")
        {
            //RTX
            string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了文件名称为" + newCDA_DocName.Text + "的文件申请，请分发特殊文件编号。";
            string sErr = RTXhelper.Send(message, "分发特殊文件编号");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }
        }
        else
        {
            //RTX
            string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了文件名称为" + newCDA_DocName.Text + "的文件申请，请分发特殊文件编号。";
            string sErr = RTXhelper.Send(message, "受控文件主管审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }
        }
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
    }
    #endregion 编辑受控文件（同时选择分发岗位和会签部门）

    #region 特殊文件编号
    protected void Btn_Okspecil_Click(object sender, EventArgs e)
    {
        if (newCDA_DocNO.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());
        string CDA_DocNO = newCDA_DocNO.Text.ToString();

        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocNO = '" + CDA_DocNO + "' and CDA_ID!='" + CDA_ID + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已有此受控文件编号，不能重复！')", true);
            return;
        }
        controlldeDocL.Update_ControlledDocApp_specil(CDA_ID, CDA_DocNO);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了文件名称为" + newCDA_DocName.Text + "的文件申请，请分发特殊文件编号。";
        string sErr = RTXhelper.Send(message, "受控文件主管审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Btn_Cancelspecil_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    #endregion 特殊文件编号

    #region 主管审核
    protected void Au_ok_Click(object sender, EventArgs e)
    {
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());
        string CDA_Auditor = newCDA_Auditor.Text.ToString();
        DateTime CDA_AuTime = Convert.ToDateTime(newCDA_AuTime.Text.ToString());
        string CDA_AuSugg = newCDA_AuSugg.Text.ToString();
        string ETA_AuRes = "通过";
        string CDA_AppState = "审核通过";
        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and ETA_AuRes != '' and CDA_ID='" + CDA_ID + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已审核，不能重复！')", true);
            return;
        }
        controlldeDocL.Update_ControlledDocApp_Au(CDA_ID, CDA_Auditor, CDA_AuTime, CDA_AuSugg, ETA_AuRes, CDA_AppState);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        //RTX
        string dep="";
        foreach(GridViewRow q in Grid_CDAppCon.Rows)
        {
            dep+=q.Cells[7].Text.ToString()+",";
        }
        dep = dep.Substring(0,dep.Length-1);
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了文件名称为" + newCDA_DocName.Text + "的文件申请，请会签。";
        string sErr = RTXhelper.SendbyDepAndRole(message,dep,"受控文件会签");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Au_notok_Click(object sender, EventArgs e)
    {
        if (newCDA_AuSugg.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请填写审核意见！')", true);
            return;
        }
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());
        string CDA_Auditor = newCDA_Auditor.Text.ToString();
        DateTime CDA_AuTime = Convert.ToDateTime(newCDA_AuTime.Text.ToString());
        string CDA_AuSugg = newCDA_AuSugg.Text.ToString();
        string ETA_AuRes = "不通过";
        string CDA_AppState = "审核驳回";
        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and ETA_AuRes != '' and CDA_ID='" + CDA_ID + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已审核，不能重复！')", true);
            return;
        }
        controlldeDocL.Update_ControlledDocApp_Au(CDA_ID, CDA_Auditor, CDA_AuTime, CDA_AuSugg, ETA_AuRes, CDA_AppState);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核驳回了文件名称为" + newCDA_DocName.Text + "的文件申请，请重提申请。";
        string sErr = RTXhelper.SendbyUserName(message, newCDA_AppPer.Text);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Au_Cancel_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    #endregion 主管审核

    #region 审批
    protected void Approval_ok_Click(object sender, EventArgs e)
    {
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());
        string CDA_Approver = newCDA_Approver.Text.ToString();
        DateTime CDA_ApprovalT = Convert.ToDateTime(newCDA_ApprovalT.Text.ToString());
        string CDA_ApprovalSugg = newCDA_ApprovalSugg.Text.ToString();
        string CDA_ApprovalRes = "通过";
        string CDA_AppState = "审批通过";
        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_ApprovalRes != '' and CDA_ID='" + CDA_ID + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已审批，不能重复！')", true);
            return;
        }
        controlldeDocL.Update_ControlledDocApp_Approval(CDA_ID, CDA_Approver, CDA_ApprovalT, CDA_ApprovalSugg, CDA_ApprovalRes, CDA_AppState);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批通过了文件名称为" + newCDA_DocName.Text + "的文件申请，请下载并分发。";
        string sErr = RTXhelper.Send(message, "受控文件下载");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Approval_notok_Click(object sender, EventArgs e)
    {
        if (newCDA_ApprovalSugg.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请填写审批意见！')", true);
            return;
        }
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());
        string CDA_Approver = newCDA_Approver.Text.ToString();
        DateTime CDA_ApprovalT = Convert.ToDateTime(newCDA_ApprovalT.Text.ToString());
        string CDA_ApprovalSugg = newCDA_ApprovalSugg.Text.ToString();
        string CDA_ApprovalRes = "不通过";
        string CDA_AppState = "审批驳回";
        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_ApprovalRes != '' and CDA_ID='" + CDA_ID + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已审批，不能重复！')", true);
            return;
        }
        controlldeDocL.Update_ControlledDocApp_Approval(CDA_ID, CDA_Approver, CDA_ApprovalT, CDA_ApprovalSugg, CDA_ApprovalRes, CDA_AppState);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批驳回了文件名称为" + newCDA_DocName.Text + "的文件申请，请重提申请。";
        string sErr = RTXhelper.SendbyUserName(message, newCDA_AppPer.Text);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Approval_Cancel_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    #endregion 审批

    #region 会签
    protected void Look_close_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    protected void Sign_ok_Click(object sender, EventArgs e)
    {
        Guid CDAST_ID = new Guid(Label_CDASTid.Text.ToString());
        string CDAST_SignPer = newCDAST_SignPer.Text.ToString();
        DateTime CDAST_SignTime = Convert.ToDateTime(newCDAST_SignTime.Text.ToString());
        string CDAST_SignSugg = newCDAST_SignSugg.Text.ToString();
        string CDAST_SignRes = "通过";
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());

        controlldeDocL.Update_CDAppConSignT(CDAST_ID, CDAST_SignPer, CDAST_SignTime, CDAST_SignSugg, CDAST_SignRes);
        BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
        UpdatePanel_New.Update();
        controlldeDocL.Update_ControlledDocApp_State(CDA_ID);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //RTX
        DataSet ds = controlldeDocL.Search_CDAppConSignT("and CDA_ID='" + CDA_ID + "' and a.CDAST_SignTime is null");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count == 0)
        {
            string message = "ERP系统消息：相关部门于" + DateTime.Now.ToString("F") + "会签通过了文件名称为" + newCDA_DocName.Text + "的文件申请，请审批。";
            string sErr = RTXhelper.Send(message, "受控文件审批");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }
        }
    }
    protected void Sign_notok_Click(object sender, EventArgs e)
    {
        if (newCDAST_SignSugg.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('请填写会签意见！')", true);
            return;
        }
        Guid CDAST_ID = new Guid(Label_CDASTid.Text.ToString());
        string CDAST_SignPer = newCDAST_SignPer.Text.ToString();
        DateTime CDAST_SignTime = Convert.ToDateTime(newCDAST_SignTime.Text.ToString());
        string CDAST_SignSugg = newCDAST_SignSugg.Text.ToString();
        string CDAST_SignRes = "不通过";
        Guid CDA_ID = new Guid(Label_appid.Text.ToString());

        controlldeDocL.Update_CDAppConSignT(CDAST_ID, CDAST_SignPer, CDAST_SignTime, CDAST_SignSugg, CDAST_SignRes);
        BindGrid_CDAppCon(" and a.CDA_ID='" + Label_appid.Text + "'");
        UpdatePanel_New.Update();
        controlldeDocL.Update_ControlledDocApp_State(CDA_ID);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "会签驳回了文件名称为" + newCDA_DocName.Text + "的文件申请，请重提申请。";
        string sErr = RTXhelper.SendbyUserName(message, newCDA_AppPer.Text);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Sign_Cancel_Click(object sender, EventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    protected void Sign_close_Click(object sender, EventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    #endregion 会签

    //#region 上传文件按钮及文件上传
    //protected void Btn_Route_Click(object sender, EventArgs e)
    //{
    //    ShowPanel();
    //    this.UpdatePanel_upload.Update();
    //}
    //protected void ok_upload_Click(object sender, EventArgs e)
    //{
    //    if (this.FileUpload1.PostedFile.FileName == "")
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "aa", "alert('标记*的为必填项，请填写完整！')", true);
    //        return;
    //    }
    //    string fileExrensio = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
    //    string UploadURL = Server.MapPath("~/file/");//上传的目录
    //    string fullname = FileUpload1.FileName;//上传文件的原名
    //    string newname = System.DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
    //    if (this.FileUpload1.PostedFile.FileName != null)
    //    {
    //        if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx")//判断文件扩展名
    //        {
    //            try
    //            {
    //                if (!System.IO.Directory.Exists(UploadURL))//判断文件夹是否已经存在
    //                {
    //                    System.IO.Directory.CreateDirectory(UploadURL);//创建文件夹
    //                }
    //                FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
    //            }
    //            catch
    //            {
    //                ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, this.GetType(), "aa", "alert('上传失败!')", true);
    //                return;
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, this.GetType(), "aa", "alert('不支持此文件格式!')", true);
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, this.GetType(), "aa", "alert('请选择文件!')", true);
    //        return;
    //    }

    //    string filePath = "file/" + newname + fullname;
    //    this.newCDA_DocRoute.Text = filePath;

    //    ClosePanel();
    //    this.UpdatePanel_upload.Update();
    //}
    //private void ShowPanel()//显示“上传”框
    //{
    //    string script = "document.getElementById('Panel99').style.display='';";
    //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ShowPanel", script, true);
    //}
    //private void ClosePanel()//关闭“上传”框
    //{
    //    string script = "document.getElementById('Panel99').style.display='none';";
    //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ClosePanel", script, true);
    //}
    //protected void cancel_upload_Click(object sender, EventArgs e)
    //{
    //    ClosePanel();
    //    this.UpdatePanel_upload.Update();
    //}
    //#endregion 上传文件按钮及文件上传

    #region 特殊录入通道
    protected void Btn_Specil_Click(object sender, EventArgs e)
    {
        Clear();
        newCDA_AppReason.Text = "ERP系统提示：录入现有的纸质版受控文件。";
        newCDA_Remarks.Text = "ERP系统提示：此版本文件为目前已通过审批且正在使用的受控文件，录入后无需进行审核、会签、审批。";
        newCDA_DocNO.Text = "";
        newCDA_AppNO.Text = "";
        newCDA_DocNO.Enabled = true;
        newCDA_AppNO.Enabled = true;
        Panel1.Visible = true;
        Panel2.Enabled = true;
        Panel3.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        Panel8.Visible = false;
        Panel9.Visible = false;
        Panel10.Visible = false;
        Panel11.Visible = false;
        Panel12.Visible = false;
        Panel15.Visible = true;
        Label15.Visible = true;
        DropDownList7.Visible = true;
        BindDropDownList5();
        DropDownList5.Enabled = true;
        DropDownList6.Enabled = true;
        DropDownList7.Enabled = true;
        DropDownList9.SelectedValue = "";
        newCDA_DocName.Enabled = true;
        newCDA_EditionNO.Enabled = false;
        newCDA_EditionNO.Text = "0";
        DropDownList5.Enabled = true;
        DropDownList9.Enabled = true;
        Label21.Visible = false;
        newCDA_AppState.Visible = false;

        BindDropDownList7();
        newCDA_AppPer.Text = Session["UserName"].ToString().Trim();
        newCDA_AppTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        newCDA_DocRoute.Visible = false;
        FileUpload1.Visible = false;
        Panel_chooseCDDep.Visible = false;
        UpdatePanel_chooseCDDep.Update();
        Panel_chooseBDO.Visible = false;
        UpdatePanel_chooseBDO.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //ClosePanel();
        //this.UpdatePanel_upload.Update();
        Panel_New.Visible = true;
        Response.Write("");
        UpdatePanel_New.Update();
    }

    protected void Btn_SpecilOK_Click(object sender, EventArgs e)
    {
        //#region 上传
        //var extension = Path.GetExtension(FileUpload1.FileName);
        //if (extension == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('标记*的为必填项，请填写完整！')", true);
        //    return;
        //}
        //string fileExrensio = extension.ToLower();//ToLower转化为小写,获得扩展名
        //string UploadURL = Server.MapPath("~/file/");//上传的目录
        //string fullname = FileUpload1.FileName;//上传文件的原名
        //string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
        //if (extension != null)
        //{
        //if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx" || fileExrensio == ".rar" || fileExrensio == ".zip")//判断文件扩展名
        //{
        //try
        //{
        //    if (!Directory.Exists(UploadURL))//判断文件夹是否已经存在
        //    {
        //        Directory.CreateDirectory(UploadURL);//创建文件夹
        //    }
        //    FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
        //}
        //catch
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('上传失败!')", true);
        //    return;
        //}
        //}
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('不支持此文件格式!')", true);
        //    return;
        //}
        //}
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "aa", "alert('请选择文件!')", true);
        //    return;
        //}

        //string filePath = "file/" + newname + fullname;
        //newCDA_DocRoute.Text = filePath;
        //#endregion 上传

        if (newCDA_DocNO.Text==""||newCDA_AppNO.Text==""||newCDA_DocName.Text.ToString() == "" || newCDA_EditionNO.Text.ToString() == "" || DropDownList5.SelectedValue.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || DropDownList9.SelectedValue.ToString() == ""||newCDA_EffectDate.Text.ToString()=="" )
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string CDA_DocNO = newCDA_DocNO.Text.ToString();
        string CDA_DocName=newCDA_DocName.Text.ToString();
        string CDA_EditionNO=newCDA_EditionNO.Text.ToString();
        string CDA_DocType=DropDownList6.SelectedValue.ToString();
        string CDA_ChangedType = DropDownList9.SelectedValue.ToString();
        string CDA_AppPer = newCDA_AppPer.Text.ToString();
        DateTime CDA_AppTime = Convert.ToDateTime(newCDA_AppTime.Text.ToString());
        string CDA_AppDep=DropDownList5.SelectedValue.ToString();
        string CDA_AppReason=newCDA_AppReason.Text.ToString();
        string CDA_AppState="审批通过";
        string CDA_Remarks=newCDA_Remarks.Text.ToString();
        //string CDA_DocRoute = newCDA_DocRoute.Text.ToString();
        string CDA_DocRoute = "";
        string CDTLC_DocType = DropDownList7.SelectedValue.ToString();
        string CDA_AppNO = newCDA_AppNO.Text.ToString();
        DateTime CDA_EffectDate = Convert.ToDateTime(newCDA_EffectDate.Text.ToString());

        if (CDA_DocType == "第三层次文件" && DropDownList7.SelectedValue == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请为第三层次文件选择文件类别！')", true);
            return;
        }
        if (CDA_DocType == "第三层次文件")
        {
            DataSet u = basicCodeL.Search_BDOrganization_depcode("and BDOS_Name = '" + CDA_AppDep + "'");
            DataTable rr = u.Tables[0];
            if (rr.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('文件申请失败，请先申请部门编号！')", true);
                return;
            }
        }
        DataSet ds = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocName = '" + CDA_DocName + "' and CDA_EditionNO='" + CDA_EditionNO + "' and CDA_ChangedType='" + CDA_ChangedType + "' and CDA_DocType='" + CDA_DocType + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该受控文件已申请，不能重复！')", true);
            return;
        }
        DataSet ds1 = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocNO = '" + CDA_DocNO + "'");
        DataTable dt1 = ds1.Tables[0];
        if (dt1.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已有此受控文件编号，不能重复！')", true);
            return;
        }
        DataSet ds2 = controlldeDocL.Search_ControlledDocApp_APP("and CDA_AppNO = '" + CDA_AppNO + "'");
        DataTable dt2 = ds2.Tables[0];
        if (dt2.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已有此申请单号，不能重复！')", true);
            return;
        }
        controlldeDocL.Insert_ControlledDocApp_Specil(CDA_DocNO, CDA_DocName, CDA_EditionNO, CDA_DocType, CDA_ChangedType, CDA_AppPer, CDA_AppTime, CDA_AppDep, CDA_AppReason, CDA_AppState, CDA_Remarks, CDA_DocRoute, CDTLC_DocType, CDA_AppNO, CDA_EffectDate);
        string condition = GetCondition3();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected void Btn_SpecilCancel_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    //显示编辑
    protected void Grid_App_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Grid_App.EditIndex = e.NewEditIndex;
        string condition = GetCondition();
        BindGrid_App(condition);
    }
    //Gridview编辑
    protected void Grid_App_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Guid CDA_ID = new Guid(Grid_App.Rows[e.RowIndex].FindControl("CDA_ID").ToString().Trim());
        Guid CDA_ID = new Guid(Grid_App.DataKeys[e.RowIndex].Value.ToString());
        if (((TextBox)(Grid_App.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('受控文件编号不能为空！')", true);
            return;
        }
        string CDA_DocNO = Convert.ToString(((TextBox)(Grid_App.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim());
        if (((TextBox)(Grid_App.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('申请单号不能为空！')", true);
            return;
        }
        string CDA_AppNO = Convert.ToString(((TextBox)(Grid_App.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim());
        DataSet ds1 = controlldeDocL.Search_ControlledDocApp_APP("and CDA_DocNO = '" + CDA_DocNO + "' and CDA_ID!='" + CDA_ID + "'");
        DataTable dt1 = ds1.Tables[0];
        if (dt1.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已有此受控文件编号，不能重复！')", true);
            return;
        }
        DataSet ds2 = controlldeDocL.Search_ControlledDocApp_APP("and CDA_AppNO = '" + CDA_AppNO + "' and CDA_ID!='" + CDA_ID + "'");
        DataTable dt2 = ds2.Tables[0];
        if (dt2.Rows.Count != 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已有此申请单号，不能重复！')", true);
            return;
        }
        Grid_App.EditIndex = -1;
        controlldeDocL.Update_ControlledDocApp_Specil_No(CDA_ID, CDA_DocNO, CDA_AppNO);
        string condition = GetCondition();
        BindGrid_App(condition);
        UpdatePanel_App.Update();
    }
    //取消编辑
    protected void Grid_App_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_App.EditIndex = -1;
        UpdatePanel_App.Update();
        string condition = GetCondition();
        BindGrid_App(condition);
    }

#endregion 特殊录入通道

}


        
