﻿using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class InventoryMgt_IMInStore : Page
{
     IMInStoreMainD ins = new IMInStoreMainD();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            GetCondition_Suigongdan();
            label_condition.Text = " order by a.IMISM_InStoreTime desc";
            BindInStoreMain();
            //Panel_InstoreDetail.Visible = true;
            //BindInStoreDetail();
            DropDownList7.DataSource = ins.Select_MatType();
            DropDownList7.DataTextField = "IMMt_MaterialType";
            DropDownList7.DataValueField = "IMMt_MaterialTypeID";
            DropDownList7.DataBind();
            //三个检索条件默认置空用于表格初始化
            label38.Text = "";
            label44.Text = "";
           

   

        }
        #region 权限
        if (Request.QueryString["status"] == "INSLook")//入库单查看
        {
            Panel1.Visible = false;
            UpdatePanel5.Update();
            Button2.Visible = false;
            UpdatePanel_Search.Update();
            Gridview_INStoreMain.Columns[12].Visible = false;
            Gridview_INStoreMain.Columns[13].Visible = false;
            Gridview_INStoreMain.Columns[14].Visible = false;
            UpdatePanel_InStoreMain.Update();

        }
        //其余权限控制在BindDropdownList()里面

        #endregion

    }
    #region 主表
    //private string ChineseGallery()
    //{
    //    System.IO.StringWriter writer = new System.IO.StringWriter(); //提供一个可以写的文本区域
    //    HtmlTextWriter buffer = new HtmlTextWriter(writer); //让htmlWriter操作这个区域，我们就可以获得这个区域里的内容
    //    base.Render(buffer); //先让页面画一遍，让我们得到初始的页面html代码
    //    string html = writer.ToString(); //找到这段代码，我们来处理它，把英文变成汉字
    //    html = html.Replace("&amp;nbsp;", "&nbsp;");
    //    return html;
    //}

    //protected override void Render(HtmlTextWriter writer)
    //{
    //    writer.Write(this.ChineseGallery());
    //}

    //绑定主表函数
    protected void BindInStoreMain()
    {
        Gridview_INStoreMain.DataSource = ins.Select_InStoreMain(label_condition.Text.ToString());
        Gridview_INStoreMain.DataBind();
        UpdatePanel_InStoreMain.Update();
    }
    //检索条件获得
    protected string GetCodition()
    {
        string conditon;
        string temp = "";
        if ((TextBox5.Text.ToString() == "" && TextBox6.Text.ToString() != "")|| (TextBox5.Text.ToString() != "" && TextBox6.Text.ToString() == ""))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Search, GetType(), "alert", "alert('请填写完整时间段！')", true);
            
        }
        if (TextBox5.Text != "" && TextBox6.Text != "")
        {
            if (Convert.ToDateTime(TextBox5.Text.ToString()) >= Convert.ToDateTime(TextBox6.Text.ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Search, GetType(), "alert", "alert('请保证起始时间小于结束时间！')", true);
            }
        }
        if (TextBox1.Text.ToString() != "")
        {
            temp += " and a.IMISM_InStoreNum like'%" + TextBox1.Text.ToString() + "%'";
        }
        if (TextBox11.Text.ToString() != "")
        {
            temp += " and c.IMS_StoreName like'%" + TextBox11.Text.ToString() + "%'";
        }
        if (TextBox2.Text.ToString() != "")
        {
            temp += " and b.IMSSBD_Name like'%" + TextBox2.Text.ToString() + "%'";
        }
        if (DropDownList1.SelectedValue.ToString() != "选择状态")
        {
            temp += " and a.IMISM_InStoreState like'" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (TextBox3.Text.ToString() != "")
        {
            temp += " and a.IMISM_InStoreCompany like'%" + TextBox3.Text.ToString() + "%'";
        }
        if (TextBox4.Text.ToString() != "")
        {
            temp += " and a.IMISM_ResponMan like'%" + TextBox4.Text.ToString() + "%'";
        }
        if (TextBox5.Text.ToString() != ""&&TextBox6.Text.ToString()!="")
        {
            temp += " and a.IMISM_InStoreTime between'" + TextBox5.Text.ToString() + "'and'"+TextBox6.Text.ToString()+"'";
        }
        temp += "order by a.IMISM_InStoreTime desc";
        conditon = temp;
        label_condition.Text = conditon;
        return conditon;
    }
    //检索主表
    protected void SearchInStoreMain(object sender, EventArgs e)
    {
        GetCodition();
        BindInStoreMain();
    }
    //建立入库单
    protected void CreateInStoreMain(object sender, EventArgs e)
    {
        Panel_NewInStoreMain.Visible = true;
        BindDropdownList();
        DropDownList3.Items.Insert(0, new ListItem("选择入库类别", "选择入库类别"));
        DropDownList4.Items.Insert(0, new ListItem("选择入库库房", "选择入库库房"));     
        UpdatePanel_NewInStoreMain.Update();
    }
    //查询详细表
    protected void SearchInStoreDetail(object sender, EventArgs e)
    {
        GetCodition1();   
        BindInStoreDetail();
        UpdatePanel_InstoreDetail.Visible = true;
        UpdatePanel_InstoreDetail.Update();
        Panel_SearchDetail.Visible = false;
        UpdatePanel_SearchDetail.Update();
        Label13.Text = "检索的";
    }
    //close search-detail
    protected void ColseInStoreDetail(object sender, EventArgs e)
    {
        Panel_SearchDetail.Visible = false;
        UpdatePanel_SearchDetail.Update();
    }
    //open search-detail
    protected void OpenInstoreDetail(object sender, EventArgs e)
    {
        Panel_SearchDetail.Visible = true;
        UpdatePanel_SearchDetail.Update();
    }
    //提交新增入库单主表
    protected void ConfirmNewInStoreMain(object sender, EventArgs e)
    {
        Guid sortID;
        Guid storeID;
        string man = Session["UserName"].ToString().Trim();
        string department;
        string responman;
        //
        if (DropDownList3.SelectedValue == "选择入库类别")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewInStoreMain, GetType(), "alert", "alert('必须选择入库类别！')", true);
            return;
        }
        else
        {
            sortID = new Guid(DropDownList3.SelectedValue.ToString());
        }
        //
        if (DropDownList4.SelectedValue == "选择入库库房")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewInStoreMain, GetType(), "alert", "alert('必须选择入库库房！')", true);
            return;
        }
        else
        {
            storeID = new Guid(DropDownList4.SelectedValue.ToString());
        }
        //
        if (TextBox12.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewInStoreMain, GetType(), "alert", "alert('缺省“来源单位”会造成信息不完整，请填写！')", true);
            return;
        }
        else {
            department = TextBox12.Text.ToString().Trim();
        }
        
        //
        if (TextBox13.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewInStoreMain, GetType(), "alert", "alert('缺省“责任人”会造成信息不完整，请填写！')", true);
            return;
        }
        else {
            responman = TextBox13.Text.ToString().Trim();
        }
        ins.Insert_IMInStoreMain(sortID, storeID, department, man, responman);
        BindInStoreMain();
        ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewInStoreMain, GetType(), "alert", "alert('新建入库单成功，请根据入库类别填写具体内容！')", true);
        ClearNewInStroeMain();
        Panel_NewInStoreMain.Visible = false;
        Panel_InstoreDetail.Visible = false;
        UpdatePanel_InstoreDetail.Update();
        UpdatePanel_NewInStoreMain.Update();

    }
    //取消新增入库单主表
    protected void ClearNewInStroeMain()
    {
        TextBox12.Text = "";
        TextBox13.Text = "";
        DropDownList3.SelectedValue = "选择入库类别";
        DropDownList4.SelectedValue = "选择入库库房";
    }
    protected void CanelNewInStoreMain(object sender, EventArgs e)
    {
        Panel_NewInStoreMain.Visible = false;
        ClearNewInStroeMain();
        UpdatePanel_NewInStoreMain.Update();
    }
    //根据权限去绑定入库类别和入库库房
    protected void BindDropdownList()
    {
        string temp = "";
        if (Request.QueryString["status"] == "PurINS")//采购入库
        {
            temp = " and IMSSBD_Name like '采购入库'";

        }
        if (Request.QueryString["status"] == "PTINS")//成品入库
        {

            temp = " and IMSSBD_Name like '成品入库'";

        }
        if (Request.QueryString["status"] == "REINS")//退货入库
        {
            temp = " and IMSSBD_Name like '退货入库'";

        }
        if (Request.QueryString["status"] == "OtherINS")//其他入库
        {

            temp = " and IMSSBD_Name not like '采购入库' and IMSSBD_Name not like '成品入库' and IMSSBD_Name not like '退货入库'";
        }
        //这里应该是插这个人的权限，入库类别通过权限，入库库房通过库房表中的责任人
        
            //入库类别
            DropDownList3.DataSource = ins.Select_IMInStoreSort(temp);
            DropDownList3.DataTextField = "IMSSBD_Name";
            DropDownList3.DataValueField = "IMSSBD_ID";
            DropDownList3.DataBind();
         
            //入库库房
            string man = Session["UserName"].ToString().Trim();
            string depart = Session["Department"].ToString().Trim();
            DropDownList4.DataSource = ins.Select_Store(depart, man);
            DropDownList4.DataTextField = "IMS_StoreName";
            DropDownList4.DataValueField = "IMS_StoreID";
            DropDownList4.DataBind();
        
    }
    #endregion
    #region 详细表
    //绑定详细表
    protected void BindInStoreDetail()
    {
        Gridviewl_InstoreDetail.DataSource = ins.Select_InStoreDelete(label_conditiondetail.Text.ToString().Trim());
        Gridviewl_InstoreDetail.DataBind();
        Panel_InstoreDetail.Visible = true;
        UpdatePanel_InstoreDetail.Update();
    }
    //检索条件获得
    protected string GetCodition1()
    {
        string conditon;
        string temp = "";
        if (TextBox7.Text.ToString() != "")
        {
            temp += " and Name like'%" + TextBox7.Text.ToString() + "%'";
        }
        if (TextBox8.Text.ToString() != "")
        {
            temp += " and Model like'%" + TextBox8.Text.ToString() + "%'";
        }
        if (TextBox9.Text.ToString() != "")
        {
            temp += " and IMISD_BatchNum like'%" + TextBox9.Text.ToString() + "%'";
        }
        if (DropDownList2.SelectedValue.ToString() != "选择是否")
        {
            temp += " and IMIDS_DownLevel like'%" + DropDownList2.SelectedValue.ToString() + "%'";
        }
        conditon = temp;
        label_conditiondetail.Text = conditon;
        return conditon;
    }
    //新增来源
    protected void NewSource(object sender, EventArgs e)
    {
        //label34 
        string sort = Label34.Text.ToString().Trim();
        Label_NEW_OLD.Text = "新增";
        Label29.Text = "入库单详细";
        int sential = 1;
        switch (sort )
        {
            case "采购入库":
                Panel4.Visible = true;
                Panel5.Visible = true;
                Gridview_Pur.DataSource = ins.Select_Purchase(label38.Text.ToString());
                Gridview_Pur.DataBind();
                Panel5.Visible = true;
                UpdatePanel1.Update();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_InstoreDetail, GetType(), "alert", "alert('请选择对应的采购订单！')", true);
                sential = 0;
                break;
            case "退货入库":
                Panel7.Visible = true;
                Panel6.Visible = true;
                UpdatePanel2.Update();
                sential = 0;
                Gridview_Return.DataSource = ins.Select_Return(label44.Text.ToString().Trim());
                Gridview_Return.DataBind();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_InstoreDetail, GetType(), "alert", "alert('请选择对应的退货单！')", true);
                break;
            case "成品入库":
                Panel8.Visible = true;
                Panel9.Visible = true;
                UpdatePanel3.Update();
                Gridview2.DataSource = ins.Select_Suigongdan(label48.Text.ToString());
                Gridview2.DataBind();
                UpdatePanel3.Update();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_InstoreDetail, GetType(), "alert", "alert('请选择对应的随工单！')", true);
                sential = 0;
                break;

        }
        if (sential == 1)
        {
            Clear1();
            Panel_NewDetail.Visible = true;
            Button21.Enabled = true;
            UpdatePanel_NewDetail.Update();
        }
    }
    //关闭
    protected void CloseDetail(object sender, EventArgs e)
    {
        Panel_InstoreDetail.Visible = false;
        UpdatePanel_InstoreDetail.Update();
    }
    //提交
    protected void ConfirmDetail(object sender, EventArgs e)
    {
        try
        {
            //要对datatable的每一行数据进行遍历，而不是对gridview的每一页进行遍历
            DataSet ds = ins.Select_InStoreDelete(label_conditiondetail.Text.ToString().Trim());
            DataTable dt = ds.Tables[0];//入库详细表
            Gridviewl_InstoreDetail.DataSource = ds;
            Gridviewl_InstoreDetail.DataBind();
            UpdatePanel_InstoreDetail.Update();
            string sort = Label34.Text.ToString().Trim();
            Guid Mid = new Guid(Label53.Text.ToString());
            switch (sort)
            {
                case "采购入库":
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Guid ID = new Guid(dr["IMISD_ID"].ToString());
                            ins.Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum(ID);
                        }
                    int ouput=ins.Update_IMInstroeDetail_PMPurchaseOrderDetail_ActualNum(new Guid(Label43.Text.ToString().Trim()));
                    if (ouput == 1)
                    {
                        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交的新入库单有物料需要进行检验，请及时进行后续操作！";
                        string sErr = RTXhelper.Send(remind, "进料检验维护");
                        if (!string.IsNullOrEmpty(sErr))
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                        }
                    
                    }
                    }
                    BindInStoreDetail();
                    BindInStoreMain();
                    Panel_InstoreDetail.Visible = false;
                    UpdatePanel_InstoreDetail.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
                    break;
                case "退货入库":
                    ins.Update_IMInstroeDetail_State_Detail(Mid);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Guid ID = new Guid(dr["IMISD_ID"].ToString());
                            ins.Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum_Two(ID);
                        }     
                    }
                    BindInStoreDetail();
                    BindInStoreMain();
                    Panel_InstoreDetail.Visible = false;
                    UpdatePanel_InstoreDetail.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
                    break;

                case "成品入库":
                    ins.Update_IMInstroeDetail_State_Detail(Mid);
                    ins.Update_IMInstroeMain_WorkOrder(Mid);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Guid ID = new Guid(dr["IMISD_ID"].ToString());
                            ins.Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum_Two(ID);
                        }     
                    }
                
                    BindInStoreDetail();
                    BindInStoreMain();
                    Panel_InstoreDetail.Visible = false;
                    UpdatePanel_InstoreDetail.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
                    break;

                case "冲账入库":
                    //ins.Update_IMInstroeDetail_State_Detail(Mid);
                    //ins.Update_IMInstroeMain_WorkOrder(Mid);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Guid ID = new Guid(dr["IMISD_ID"].ToString());
                            ins.Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum_Two(ID);
                        }
                    }
                    BindInStoreDetail();
                    BindInStoreMain();
                    Panel_InstoreDetail.Visible = false;
                    UpdatePanel_InstoreDetail.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
                    break;
                default:
                    ins.Update_IMInstroeDetail_State_Detail(Mid);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Guid ID = new Guid(dr["IMISD_ID"].ToString());
                            ins.Update_IMInstroeDetail_PMPurchaseOrderDetail_ChangeNum_Two(ID);
                        }     
                    }
                    BindInStoreDetail();
                    BindInStoreMain();
                    Panel_InstoreDetail.Visible = false;
                    UpdatePanel_InstoreDetail.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
                    break;

            }
        }
        catch (Exception)
        {
            
            throw;
        }
       
       
    }
    #endregion
    #region 物料新增，筛选物料和pt
    //新增详细的提交按钮
    protected void ConfirmNewInStoreDetail(object sender, EventArgs e)
    {
        try
        {


            decimal arrnum, perweight, totalweight;
            string model = Label_NEW_OLD.Text.ToString();
            int sort = Convert.ToInt32(Label55.Text.ToString());
            Guid Mid = new Guid(Label54.Text.ToString());
            Guid MainID = new Guid(Label56.Text.ToString());
            string batch = TextBox17.Text.ToString();
            string level = TextBox18.Text.ToString();
            decimal shouldnum;
            if (TextBox21.Text == "")
            {
                 shouldnum = 0;
            }
            else
            {
                 shouldnum = Convert.ToDecimal(TextBox21.Text.ToString());
            }
            Guid Did;
            if (Label57.Text == "")
            {
                Did = Guid.NewGuid();
            }
            else
            {
                Did = new Guid(Label57.Text.ToString());
            }
            if (TextBox22.Text.ToString()=="")
            {
                 arrnum = 0;
            }
            else
            {
                arrnum = Convert.ToDecimal(TextBox22.Text.ToString());
            
            }

            if (TextBox23.Text.ToString() == "")
            {
                 perweight = 0;
            }
            else
            {
                perweight = Convert.ToDecimal(TextBox23.Text.ToString());
            }

            if (TextBox24.Text.ToString() == "")
            {
                 totalweight = 0;
            }
            else
            {
                totalweight = Convert.ToDecimal(TextBox24.Text.ToString());
            }
            if (DropDownList6.SelectedValue.ToString() == "选择预入库区域")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择预入库区域！')", true);
                return;
            }
            Guid areaID = new Guid(DropDownList6.SelectedValue.ToString());
            switch (model)
            {

                case "编辑":
                    ins.Update_InStoreDetail(Did, batch, level, shouldnum, arrnum, perweight, totalweight, areaID);
                    BindInStoreDetail();
                    BindInStoreMain();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新增成功！')", true);
                    Panel_NewDetail.Visible = false;
                    UpdatePanel_NewDetail.Update();
                    break;
                case "新增":
                    ins.Insert_InStoreDetail(MainID, sort, Mid, batch, level, shouldnum, arrnum, perweight, totalweight, areaID);
                    BindInStoreDetail();
                    BindInStoreMain();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('编辑成功！')", true);
                    Panel_NewDetail.Visible = false;
                    UpdatePanel_NewDetail.Update();
                    break;
            }
        }
        catch (Exception)
        {
            
            throw;
        }
        
    }
    //新增详细的取消按钮
    protected void CanelNewInStoreDetail(object sender, EventArgs e)
    {
        Panel_NewDetail.Visible = false;
        UpdatePanel_NewDetail.Update();
    }
    //清空编辑栏
    public void Clear1()
    {
        TextBox15.Text = "";
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox18.Text = "";
        TextBox19.Text = "";
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox22.Text = "";
        TextBox23.Text = "";
        TextBox24.Text = "";
        TextBox25.Text = "";
        TextBox26.Text = "";
        DropDownList5.SelectedValue = "否";
        BindDropDownList6();
        UpdatePanel_NewDetail.Update();      
    }
    //提交物料
    protected void InsertMaterial(object sender, EventArgs e)
    {
        Clear1();
        foreach (GridViewRow item in Gridview_MatType.Rows)
        {
            RadioButton cb = item.FindControl("RadioButton1") as RadioButton;
            if (cb.Checked)
            {
                Label55.Text = "1";
                Label54.Text = Gridview_MatType.DataKeys[item.RowIndex].Value.ToString();
                Guid MaterialID = new Guid(Gridview_MatType.DataKeys[item.RowIndex].Value.ToString());
                string name = Gridview_MatType.Rows[item.RowIndex].Cells[4].Text.ToString();
                string model = Gridview_MatType.Rows[item.RowIndex].Cells[5].Text.ToString();
                //string unit = this.Gridview_MatType.Rows[item.RowIndex].Cells[7].Text.ToString();
                TextBox15.Text = name;
                TextBox16.Text = model;
                //this.TextBox19.Text = unit;
                Label54.Text = Gridview_MatType.DataKeys[item.RowIndex].Value.ToString();
                label_mattype.Text = Convert.ToString(MaterialID);
                Panel_MatType.Visible = false;
                Panel2.Visible = false;
                UpdatePanel_MatType.Update();
            }
        }
    }
    //物料检索
    protected void SelectMatBasicData(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Gridview_MatType.DataSource = ins.Select_InStoreDetail_MaterialBasic(GetConditionMat());
        Gridview_MatType.DataBind();
        UpdatePanel_MatType.Update();
    }
    //关闭物料检索
    protected void ColseMaterialBasicSearch(object sender, EventArgs e)
    {
        Panel_MatType.Visible = false;
        Panel2.Visible = false;
        UpdatePanel_MatType.Update();
    }
    //关闭物料表
    protected void CanelMaterial(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel_MatType.Update();
    }
    //检索产品
    protected void SelectPT(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        if(TextBox10.Text!="")
        {
            label33.Text="and PT_Name like '%"+TextBox10.Text.ToString().Trim()+"%'";
        }
        Gridview_PT.DataSource = ins.Select_InStoreDetail(label33.Text.ToString());
        Gridview_PT.DataBind();
        UpdatePanel_PT.Update();
    }
    //关闭产品检索
    protected void ColsePT(object sender, EventArgs e)
    {
        Panel_PT.Visible = false;
        Panel3.Visible = false;
        UpdatePanel_PT.Update();
    }
    //提交产品
    protected void InsertPT(object sender, EventArgs e)
    {
        Clear1();
        foreach (GridViewRow item in Gridview_PT.Rows)
        {
            RadioButton cb = item.FindControl("RadioButton2") as RadioButton;
            if (cb.Checked)
            {
                Label55.Text = "0";
                Guid MaterialID = new Guid(Gridview_PT.DataKeys[item.RowIndex].Value.ToString());
                Label54.Text = Gridview_PT.DataKeys[item.RowIndex].Value.ToString();
                string name = Gridview_PT.Rows[item.RowIndex].Cells[3].Text.ToString();
                TextBox15.Text = name;
                Label37.Text = Convert.ToString(MaterialID);
                Panel_PT.Visible = false;
                Panel3.Visible = false;
                UpdatePanel_PT.Update();
            }
        }
    }
    //关闭产品表
    protected void CanelPTl(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel_PT.Update();
    }
    //用户去选是新增哪种物料
    protected void SelectType(object sender, EventArgs e)
    {
        Panel_MatType.Visible = true;
        UpdatePanel_MatType.Update();
        DropDownList7.Items.Insert(0, new ListItem("选择类别", "选择类别"));
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel2.Visible = true;
        Gridview_MatType.DataSource = ins.Select_InStoreDetail_MaterialBasic(GetConditionMat());
        Gridview_MatType.DataBind();
        UpdatePanel_MatType.Update();
        
    }
    //用户去选是新增哪种物料
    protected void SelectType1(object sender, EventArgs e)
    {
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_MatType.Visible = false;
        UpdatePanel_MatType.Update();
        Panel3.Visible = true;
        if (TextBox10.Text != "")
        {
            label33.Text = "and PT_Name like '%" + TextBox10.Text.ToString().Trim() + "%'";
        }
        Gridview_PT.DataSource = ins.Select_InStoreDetail(label33.Text.ToString());
        Gridview_PT.DataBind();
        UpdatePanel_PT.Update();
    }
    //基本物料打开
    protected void Submit_AddNewPK_Click1(object sender, EventArgs e)
    {
        string sort = DropDownList8.SelectedValue;
        switch (sort)
        {
            case "基础物料":
                Panel_MatType.Visible = true;
                UpdatePanel_MatType.Update();
                DropDownList7.Items.Insert(0, new ListItem("选择类别", "选择类别"));
                Panel_PT.Visible = false;
                UpdatePanel_PT.Update();
                break;

            case "公司产品":
                Panel_PT.Visible = true;
                UpdatePanel_PT.Update();
                Panel_MatType.Visible = false;
                UpdatePanel_MatType.Update();
                break;
        }

    }
    //物料检索条件获取
    public string GetConditionMat()
    {
        string conditon;
        string temp = "";
        if (DropDownList7.SelectedValue != "选择类别")
        {
            temp += " and a.IMMt_MaterialTypeID like'%" + DropDownList7.SelectedValue.ToString() + "%'";
        }
        if (MatName.Text.ToString() != "")
        {
            temp += " and a.IMMBD_MaterialName like'%" + MatName.Text.ToString() + "%'";
        }
        if (Model.Text.ToString() != "")
        {
            temp += " and a.IMMBD_SpecificationModel like'%" + Model.Text.ToString() + "%'";
        }
        conditon = temp;
        label_mattype.Text = conditon;
        return conditon;
    }

    #endregion
    #region Gridview
    //INStoreMain
    protected void Gridview_INStoreMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_INStoreMain.BottomPagerRow;


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

        BindInStoreMain();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_INStoreMain.PageCount ? Gridview_INStoreMain.PageCount - 1 : newPageIndex;
        Gridview_INStoreMain.PageIndex = newPageIndex;
        Gridview_INStoreMain.DataBind();

    }
    protected void Gridview_INStoreMain_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview_INStoreMain.EditIndex = -1;
        BindInStoreMain();
    }
    protected void Gridview_INStoreMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Guid id=new Guid (Gridview_INStoreMain.DataKeys[e.RowIndex].Value.ToString());
        ins.Delete_InStoreMain(id);
        BindInStoreMain();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
        
    }
    protected void Gridview_INStoreMain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview_INStoreMain.EditIndex = e.NewEditIndex;
        BindInStoreMain();
    }
    protected void Gridview_INStoreMain_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid id = new Guid(Gridview_INStoreMain.DataKeys[e.RowIndex].Value.ToString());
        string company = Convert.ToString(((TextBox)(Gridview_INStoreMain.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString());
        string man = Convert.ToString(((TextBox)(Gridview_INStoreMain.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim().ToString());
        ins.Update_InStoreMain(id, company, man);
        Gridview_INStoreMain.EditIndex = -1;
        BindInStoreMain();
    }
    protected void Gridview_INStoreMain_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
      
        if (e.CommandName == "Look1")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label_conditiondetail.Text = " and IMISM_ID ='" + e.CommandArgument.ToString() + "'";
            Label13.Text = Gridview_INStoreMain.Rows[gvr.RowIndex].Cells[3].Text.ToString()+"的";
            Button8.Visible = false;
            Button10.Visible = false;
            Gridviewl_InstoreDetail.Columns[17].Visible = false;
            Gridviewl_InstoreDetail.Columns[18].Visible = false;
            Label53.Text = e.CommandArgument.ToString();
            Label56.Text = e.CommandArgument.ToString();
            BindInStoreDetail();
        }
        if (e.CommandName == "Edit1")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Label53.Text=e.CommandArgument.ToString();
            //GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Label43.Text = Gridview_INStoreMain.DataKeys[gvr.RowIndex]["IMISM_ID"].ToString();
            label_conditiondetail.Text = " and IMISM_ID ='" + e.CommandArgument.ToString() + "'";
            Label13.Text = Gridview_INStoreMain.Rows[gvr.RowIndex].Cells[3].Text.ToString() + "的";
            Label34.Text = Gridview_INStoreMain.Rows[gvr.RowIndex].Cells[4].Text.ToString();
            Label56.Text = e.CommandArgument.ToString();
            Button8.Visible = true;
            Button10.Visible = true;
            Gridviewl_InstoreDetail.Columns[17].Visible = true;
            Gridviewl_InstoreDetail.Columns[18].Visible = true;
            label_kufang.Text = Gridview_INStoreMain.DataKeys[gvr.RowIndex]["IMS_StoreID"].ToString();
            BindInStoreDetail();
            TextBox20.Text = Gridview_INStoreMain.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            UpdatePanel_NewDetail.Update();


        }
        if (e.CommandName == "PrintDetail")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Response.Redirect("../InventoryMgt/InPrint.aspx?IMISM_ID=" + al[0] + "&IMISM_InStoreNum=" + al[1]+ "&IMSSBD_Name=" + al[2] + "&IMS_StoreName=" + al[3]+ "&IMISM_InStoreCompany=" + al[4] + "&IMISM_ResponMan=" + al[5]+ "&IMISM_InStoreTime=" + al[6]+ "&IMISM_MakeMan=" + al[7]
                );
        }
        if (e.CommandName == "SendRTX1")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string name1 = Gridview_INStoreMain.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了入库单号为" + name1 + "的入库单，该入库单有物料需要进行检验，请及时进行后续操作！";
            string sErr = RTXhelper.Send(remind, "进料检验维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
    }
    protected void BindDropDownList6()
    {
        DropDownList6.DataSource = ins.Select_Area(new Guid(label_kufang.Text.ToString()));
        DropDownList6.DataTextField = "IMSA_AreaName";
        DropDownList6.DataValueField = "IMSA_AreaID";
        DropDownList6.DataBind();
        DropDownList6.Items.Insert(0, new ListItem("选择预入库区域", "选择预入库区域"));
    }
    protected void Gridview_INStoreMain_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_INStoreMain.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_INStoreMain.Rows[i].Cells.Count; j++)
            {
                Gridview_INStoreMain.Rows[i].Cells[j].ToolTip = Gridview_INStoreMain.Rows[i].Cells[j].Text;
                if (Gridview_INStoreMain.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_INStoreMain.Rows[i].Cells[j].Text = Gridview_INStoreMain.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview_INStoreMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv.Row["IMISM_InStoreState"].ToString().Trim()!= "待提交" )
            {
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[14].Enabled = false;
                e.Row.Cells[12].Enabled = false;
            }
            //if (drv.Row["IMISM_InStoreState"].ToString().Trim() != "合格入库")
            //{
            //    e.Row.Cells[15].Enabled = false;


            //}
            //else {
            //    e.Row.Cells[15].Enabled = true;
            //}
            //if (Request.QueryString["status"] == "PurINS")//采购入库
            //{
            //    if (drv.Row["IMSSBD_Name"].ToString().Trim() != "采购入库")
            //    {
            //        e.Row.Cells[13].Enabled = false;
            //        e.Row.Cells[14].Enabled = false;
            //        e.Row.Cells[12].Enabled = false;
            //    }

            //}
            //if (Request.QueryString["status"] == "PTINS")//成品入库
            //{
            //    if (drv.Row["IMSSBD_Name"].ToString().Trim() != "成品入库")
            //    {
            //        e.Row.Cells[13].Enabled = false;
            //        e.Row.Cells[14].Enabled = false;
            //        e.Row.Cells[12].Enabled = false;
            //    }

            //}
            //if (Request.QueryString["status"] == "REINS")//退货入库
            //{
            //    if (drv.Row["IMSSBD_Name"].ToString().Trim() != "退货入库")
            //    {
            //        e.Row.Cells[13].Enabled = false;
            //        e.Row.Cells[14].Enabled = false;
            //        e.Row.Cells[12].Enabled = false;
            //    }

            //}
            //if (Request.QueryString["status"] == "OtherINS")//其他入库
            //{

            //    if (drv.Row["IMSSBD_Name"].ToString().Trim() != "采购入库" || drv.Row["IMSSBD_Name"].ToString().Trim() != "成品入库" || drv.Row["IMSSBD_Name"].ToString().Trim() != "退货入库")
            //    {
            //        e.Row.Cells[13].Enabled = true;
            //        e.Row.Cells[14].Enabled = true;
            //        e.Row.Cells[12].Enabled = true;
            //    }
            //}

        }
    }
    //INStoreDetail
    protected void Gridviewl_InstoreDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DataRowView drv = (DataRowView)e.Row.DataItem;
        //    if (drv.Row["IMISM_InStoreState"].ToString() == "已完成" || drv.Row["IMISM_InStoreState"].ToString() == "待检验")
        //    {
        //        e.Row.Cells[12].Enabled = false;
        //        e.Row.Cells[11].Enabled = false;
        //        e.Row.Cells[10].Enabled = false;
        //    }
            
        //}
    }
    protected void Gridviewl_InstoreDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit2")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Label57.Text = e.CommandArgument.ToString();
            if(Gridviewl_InstoreDetail.DataKeys[gvr.RowIndex]["PT_ID"].ToString()=="")//sort=1 wuliao
            {
                Label55.Text = "1";
                Label54.Text = Gridviewl_InstoreDetail.DataKeys[gvr.RowIndex]["IMMBD_MaterialID"].ToString();
            }
            else if (Gridviewl_InstoreDetail.DataKeys[gvr.RowIndex]["IMMBD_MaterialID"].ToString() =="")//sort=0
            {
                Label55.Text = "0";
                Label54.Text = Gridviewl_InstoreDetail.DataKeys[gvr.RowIndex]["PT_ID"].ToString();
            }
            Label_NEW_OLD.Text = "编辑";
            Button21.Enabled = false;
            Panel_NewDetail.Visible = true;
            Label29.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            BindDropDownList6();
            UpdatePanel_NewDetail.Update();
            TextBox15.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim().Replace("&nbsp;","");
            TextBox16.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[5].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox17.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[6].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox18.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[7].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox19.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[8].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox21.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[9].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox22.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[10].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox23.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[11].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox24.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[12].Text.ToString().Trim().Replace("&nbsp;", "");
            if (Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[13].Text.ToString().Trim() == "&nbsp;")
            {
                BindDropDownList6();     
                DropDownList6.SelectedValue = "选择预入库区域";
                
                //ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_InstoreDetail, this.GetType(), "alert", "alert('缺省“责任人”会造成信息不完整，请填写！')", true);
            }
            else
            {
                BindDropDownList6();
                DropDownList6.SelectedValue = Gridviewl_InstoreDetail.DataKeys[gvr.RowIndex]["IMSA_AreaID"].ToString().Trim();
            }//预入库区域下拉框为空判断
            TextBox25.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[14].Text.ToString().Trim().Replace("&nbsp;", "");
            if (Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[15].Text.ToString().Trim() == "&nbsp;")
            {
                DropDownList5.Items.Insert(0, new ListItem("选择是否降档", "选择是否降档"));
                DropDownList5.SelectedValue = "选择是否降档";
            }
            else
            {
                DropDownList5.SelectedValue = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[15].Text.ToString().Trim();
            }
            TextBox26.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[16].Text.ToString().Trim().Replace("&nbsp;", "");
            UpdatePanel_NewDetail.Update();
        }
        if (e.CommandName == "Delete2")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            string sort = Label34.Text.ToString().Trim();
            //不同的入库方式删除还不一样
            switch (sort)
            {
                    case "退货入库":
                    {
                        Guid id = new Guid(Gridviewl_InstoreDetail.DataKeys[gvr.RowIndex]["IMISD_ID"].ToString());
                        ins.Delete_IMInStoreDetail_Return(id);
                        BindInStoreDetail();
                        UpdatePanel_InstoreDetail.Update();
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_InstoreDetail, GetType(), "alert", "alert('删除成功！')", true);
                        break;
                    }
                    default:
                    {
                        Guid id = new Guid(Gridviewl_InstoreDetail.DataKeys[gvr.RowIndex]["IMISD_ID"].ToString());
                        ins.Delete_IMInStoreDetail(id);
                        BindInStoreDetail();
                        UpdatePanel_InstoreDetail.Update();
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_InstoreDetail, GetType(), "alert", "alert('删除成功！')", true);
                        break;
                    }

            }
        }
        if (e.CommandName == "Chou")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label14.Text = e.CommandArgument.ToString();
            Label60.Text = Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[4].Text + "-" + Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[5].Text + "-" + Gridviewl_InstoreDetail.Rows[gvr.RowIndex].Cells[6].Text;
            Panel10.Visible = true;
            UpdatePanel4.Update();
        }
    }
    protected void Gridviewl_InstoreDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridviewl_InstoreDetail.BottomPagerRow;


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

        BindInStoreDetail();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridviewl_InstoreDetail.PageCount ? Gridviewl_InstoreDetail.PageCount - 1 : newPageIndex;
        Gridviewl_InstoreDetail.PageIndex = newPageIndex;
        Gridviewl_InstoreDetail.DataBind();
    }
    protected void Gridviewl_InstoreDetail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridviewl_InstoreDetail.Rows.Count; i++)
        {
            for (int j = 0; j < Gridviewl_InstoreDetail.Rows[i].Cells.Count; j++)
            {
                Gridviewl_InstoreDetail.Rows[i].Cells[j].ToolTip = Gridviewl_InstoreDetail.Rows[i].Cells[j].Text;
                if (Gridviewl_InstoreDetail.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridviewl_InstoreDetail.Rows[i].Cells[j].Text = Gridviewl_InstoreDetail.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
                //Gridviewl_InstoreDetail.Rows[i].Cells[j].Text = Gridviewl_InstoreDetail.Rows[i].Cells[j].Text.ToString().Trim();

            }
        }
        
    }
    //Mat
    protected void Gridview_MatTypeID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_MatType.BottomPagerRow;


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

        Gridview_MatType.DataSource = ins.Select_InStoreDetail_MaterialBasic(GetConditionMat());
        Gridview_MatType.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_MatType.PageCount ? Gridview_MatType.PageCount - 1 : newPageIndex;
        Gridview_MatType.PageIndex = newPageIndex;
        Gridview_MatType.DataBind();
    }
    protected void Gridview_MatType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //给每个RadioButton1绑定setRadio事件
        try
        {

            ((RadioButton)e.Row.FindControl("RadioButton1")).Attributes.Add("onclick", "setRadio(this)");

        }

        catch (Exception)
        { }

    }
    protected void Gridview_PT_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //给每个RadioButton1绑定setRadio事件
        try
        {

            ((RadioButton)e.Row.FindControl("RadioButton2")).Attributes.Add("onclick", "setRadio1(this)");

        }

        catch (Exception)
        { }
    }
    //pt
    protected void Gridview_PTID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_PT.BottomPagerRow;


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

        Gridview_PT.DataSource = ins.Select_InStoreDetail(label33.Text.ToString());
        Gridview_PT.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PT.PageCount ? Gridview_PT.PageCount - 1 : newPageIndex;
        Gridview_PT.PageIndex = newPageIndex;
        Gridview_PT.DataBind();
    }
    //Pur
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

        Gridview_Pur.DataSource = ins.Select_Purchase(label38.Text.ToString());
        Gridview_Pur.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Pur.PageCount ? Gridview_Pur.PageCount - 1 : newPageIndex;
        Gridview_Pur.PageIndex = newPageIndex;
        Gridview_Pur.DataBind();
    }
    //Return
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

        Gridview_Return.DataSource = ins.Select_Return(label44.Text.ToString());
        Gridview_Return.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Return.PageCount ? Gridview_Return.PageCount - 1 : newPageIndex;
        Gridview_Return.PageIndex = newPageIndex;
        Gridview_Return.DataBind();
    }
    //随工单
    protected void Gridview_Suigongdan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview2.BottomPagerRow;


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

        Gridview2.DataSource = ins.Select_Suigongdan(label48.Text.ToString());
        Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    #endregion
    #region 来源-采购订单，退货单，随工单
    #region 采购
    //检索采购订单
    protected void SelectPur(object sender, EventArgs e)
    {
        GetCondition_Pur();
        Gridview_Pur.DataSource = ins.Select_Purchase(label38.Text.ToString());
        Gridview_Pur.DataBind();
        Panel5.Visible = true;
        UpdatePanel1.Update();
    }
    protected string GetCondition_Pur()
    {
        string conditon;
        string temp = "";
        if (TextBox28.Text.ToString() != "")
        {
            temp += " and b.PMPO_PurchaseOrderNum like'%" + TextBox28.Text.ToString() + "%'";
        }
        if (TextBox14.Text.ToString() != "")
        {
            temp += " and c.PMSI_SupplyName like'%" + TextBox14.Text.ToString() + "%'";
        }
        if (TextBox27.Text.ToString() != "")
        {
            temp += " and d.IMMBD_MaterialName like'%" + TextBox27.Text.ToString() + "%'";
        }
        temp += " order by b.PMPO_MakeTime ";
        conditon = temp;
        label38.Text = conditon;
        return conditon;
    }
    //关闭检索采购订单
    protected void ColsePur(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel5.Visible = false;
        UpdatePanel1.Update();
    }
    //提交选择的采购订单
    protected void InsertPurchase(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gridview_Pur.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                Guid PurchaseDetailID = new Guid(Gridview_Pur.DataKeys[item.RowIndex]["PMPOD_PurchaseDetailID"].ToString());
                Guid IMISM_ID = new Guid(Label43.Text.ToString().Trim());
                ins.Insert_IMInStoreDetail_Purchase(PurchaseDetailID, IMISM_ID);
                BindInStoreDetail();
                UpdatePanel_InstoreDetail.Update();
                
            }
        }
        Panel4.Visible = false;
        Panel5.Visible = false;
        UpdatePanel1.Update();
    }
    //取消提交采购订单
    protected void CanelPurchase(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel1.Update();
    }
    #endregion
    #region 退货
    //检索退货单
    protected void SelectReturn(object sender, EventArgs e)
    {
        GetCondition_Return();
        Gridview_Return.DataSource = ins.Select_Return(label44.Text.ToString().Trim());
        Gridview_Return.DataBind();
        Panel7.Visible = true;
        UpdatePanel2.Update();
    }
    //获取检索条件
    protected string GetCondition_Return()
    {
        string conditon;
        string temp = "";
        if (TextBox29.Text.ToString() != "")
        {
            temp += " and a.SMRC_ReturnOrderNum like'%" + TextBox29.Text.ToString() + "%'";
        }
        if (TextBox30.Text.ToString() != "")
        {
            temp += " and d.CRMCIF_Name like'%" + TextBox30.Text.ToString() + "%'";
        }
        if (TextBox31.Text.ToString() != "")
        {
            temp += " and b.PT_Name like'%" + TextBox31.Text.ToString() + "%'";
        }
        temp += "order by a.SMRC_MakeTime desc";
        conditon = temp;
        label44.Text = conditon;
        return conditon;
    }
    //关闭退货检索
    protected void ColseReturn(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        Panel7.Visible = false;
        UpdatePanel2.Update();
    }
    //插入退货
    protected void InsertReturn(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gridview_Return.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                Guid SMRC_ID = new Guid(Gridview_Return.DataKeys[item.RowIndex]["SMRC_ID"].ToString());
                Guid IMISM_ID = new Guid(Label43.Text.ToString().Trim());
                ins.Insert_IMInStoreDetail_Return(SMRC_ID, IMISM_ID);
                BindInStoreDetail();
                UpdatePanel_InstoreDetail.Update();

            }
        }
        Panel6.Visible = false;
        Panel7.Visible = false;
        UpdatePanel2.Update();
    }
    //关闭退货列表
    protected void CanelReturnD(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        UpdatePanel2.Update();
    }
    #endregion
    #region 随工单
    //检索随工单
    protected void SelectSuigongdan(object sender, EventArgs e)
    {
        GetCondition_Suigongdan();
        Gridview2.DataSource = ins.Select_Suigongdan(label48.Text.ToString());
        Gridview2.DataBind();
        Panel9.Visible = true;
        UpdatePanel3.Update();
    }
    //获取检索条件
    protected string GetCondition_Suigongdan()
    {
        string conditon;
        string temp = "";
        if (TextBox32.Text.ToString() != "")
        {
            temp += " and a.WO_Num like'%" + TextBox32.Text.ToString() + "%'";
        }
        if (TextBox33.Text.ToString() != "")
        {
            temp += " and a.WO_ProType like'%" + TextBox33.Text.ToString() + "%'";
        }
       
            temp += " and a.WO_State like'%待入库%'";
       
        conditon = temp;
        label48.Text = conditon;
        return conditon;
    }
    //关闭随工单
    protected void ColseSuigongdan(object sender, EventArgs e)
    {
        Panel8.Visible = false;
        Panel9.Visible = false;
        UpdatePanel3.Update();
    }
    //插入随工单
    protected void InsertSuigongdan(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gridview2.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                Guid SMRC_ID = new Guid(Gridview2.DataKeys[item.RowIndex]["WO_ID"].ToString());
                Guid IMISM_ID = new Guid(Label43.Text.ToString().Trim());
                ins.Insert_IMInStoreDetail_Suigongdan(SMRC_ID, IMISM_ID);
                BindInStoreDetail();
                UpdatePanel3.Update();

            }
        }
        Panel8.Visible = false;
        Panel9.Visible = false;
        BindInStoreDetail();
        UpdatePanel3.Update();
    }
    //关闭随工单列表
    protected void CanelSuigongdanD(object sender, EventArgs e)
    {
        Panel9.Visible = false;
        UpdatePanel3.Update();
    }
    #endregion
    #endregion



    protected void InsertChoujian(object sender, EventArgs e)
    {
        if (TextBox35.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_InstoreDetail, GetType(), "alert", "alert('请填写抽检数量！')", true);
            return;
        }
        else
        {
            Guid id = new Guid(label14.Text.ToString());
            decimal num = Convert.ToDecimal(TextBox35.Text.ToString());
            ins.Update_Choujian(id, num);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_InstoreDetail, GetType(), "alert", "alert('填写成功！')", true);
            Panel10.Visible = false;
            UpdatePanel4.Update();
            BindInStoreDetail();
        }
    }
    protected void ColseChoujian(object sender, EventArgs e)
    {
        Panel10.Visible = false;
        UpdatePanel4.Update();
    }
}

