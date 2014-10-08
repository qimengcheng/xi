using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using RTXHelper;


public partial class InventoryMgt_IMOutStore : Page
{
    IMOutStoreD outs = new IMOutStoreD();
    SMOrderDeliverPlanL dp = new SMOrderDeliverPlanL();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            string man = Session["UserName"].ToString();
            outs.Delete_IMRD_SUM(man);
            label_lingliaocondition.Text = "";
            BindLingliaoM();
            UpdatePanel_lingliaoMain.Update();
            BindDropdownlist3();
            label_lingliaocondition.Text = "";
            Label12.Text = "0";
            BindDropdownlist4();
            UpdatePanel_OutStore.Update();
            Button33.Visible = false;
                //为了测试，将所有的Panel都关掉
                //领料单
                Panel_LingliaoSearch.Visible = false;
                UpdatePanel_LingliaoSearch.Update();
                Panel_lingliaoMain.Visible = false;
                Panel_lingliaoD.Visible = false;
                UpdatePanel_lingliaoMain.Update();
                UpdatePanel_LingliaoD.Update();
                //kucun
                Panel_kucun.Visible = false;
                Panel_KucunD.Visible = false;
                UpdatePanel_KucunD.Update();
                UpdatePanel1.Update();
                //出库单
                Panel_OutStore.Visible = false;
                Panel_OutD.Visible = false;
                UpdatePanel_OutStore.Update();
                UpdatePanel_OutD.Update();
                //测试，未来权限控制就是从这里
            label13.Text = "";
            BindDropdownlist4();
            BindOutM();
            UpdatePanel_OutStore.Update();
            //BindDropList9();
            UpdatePanel_XiaoshouOut.Update();
            //新建出库表时，库房的下拉框出有一部分的权限控制
            BindPur();
        }
        #region 权限控制
        if (Request.QueryString["status"] == "LingliaoLook")//领料单查看权限
        {
            Title = "领料单查看";
            Panel_LingliaoSearch.Visible = true;
            Panel_lingliaoMain.Visible = true;
            Button1.Visible = false;//新建领料单
            Button4.Visible = false;//生成出库单
            Gridview_lingliaoMain.Columns[0].Visible = true;//checkbox
            Gridview_lingliaoMain.Columns[11].Visible = true;//look
            Gridview_lingliaoMain.Columns[15].Visible = true;//lookcheck
            UpdatePanel_LingliaoSearch.Update();
            UpdatePanel_lingliaoMain.Update();
            UpdatePanel_LingliaoD.Update();
        }
        if (Request.QueryString["status"] == "LingliaoEdit")//领料单维护权限
        {
            Title = "领料单维护";
            Panel_LingliaoSearch.Visible = true;
            Panel_lingliaoMain.Visible = true;
            Button1.Visible = true;//新建领料单
            Button4.Visible = false;//生成出库单
            Gridview_lingliaoMain.Columns[0].Visible = true;//checkbox
            Gridview_lingliaoMain.Columns[11].Visible = true;//look
            Gridview_lingliaoMain.Columns[12].Visible = true;//look
            Gridview_lingliaoMain.Columns[13].Visible = true;//look
            Gridview_lingliaoMain.Columns[15].Visible = true;//lookcheck
            UpdatePanel_LingliaoSearch.Update();
            UpdatePanel_lingliaoMain.Update();
            UpdatePanel_LingliaoD.Update();
        }
        if (Request.QueryString["status"] == "LingliaoCheck")//领料单审核权限
        {
            Title = "领料单审核";
            Panel_LingliaoSearch.Visible = true;
            Panel_lingliaoMain.Visible = true;
            Button1.Visible = false;//新建领料单
            Button4.Visible = false;//生成出库单
            Gridview_lingliaoMain.Columns[0].Visible = true;//checkbox
            Gridview_lingliaoMain.Columns[11].Visible = true;//look
            Gridview_lingliaoMain.Columns[14].Visible = true;//look
            Gridview_lingliaoMain.Columns[15].Visible = true;//lookcheck
            UpdatePanel_LingliaoSearch.Update();
            UpdatePanel_lingliaoMain.Update();
            UpdatePanel_LingliaoD.Update();
        }
        if (Request.QueryString["status"] == "OutLook")//出库单查看权限
        {
            Title = "出库单查看";
            Panel_OutStore.Visible = true;//new outmain
            Button15.Visible = false;//new outmain
            Button18.Visible = false;//kucun search
            Button19.Visible = false;//confirm outD
            Gridview_OutM.Columns[13].Visible = false;
            Gridview_OutM.Columns[14].Visible = false;
            Gridview_OutM.Columns[15].Visible = true;
            UpdatePanel_OutStore.Update();
            UpdatePanel_OutD.Update();
        }
        if (Request.QueryString["status"] == "OutEdit")//出库单维护权限
        {
            Title = "出库单维护";
            Panel_OutStore.Visible = true;//new outmain
            Button15.Visible = true;//new outmain
            Button18.Visible = true;//kucun search
            Button19.Visible = true;//confirm outD
            Gridview_OutM.Columns[13].Visible = true;
            Gridview_OutM.Columns[14].Visible = true;
            Gridview_OutM.Columns[15].Visible = true;
            UpdatePanel_OutStore.Update();
            UpdatePanel_OutD.Update();
        }
        if (Request.QueryString["status"] == "InventoryLook")//库存查看权限
        {
            Title = "库存查看";
            Panel_kucun.Visible = true;
            Gridview_Pur.Columns[0].Visible = false;
            Gridview_Pur.Columns[11].Visible = false;
            Gridview_Kucun.Columns[0].Visible = false;
            Button20.Visible = false;
            Button24.Visible = false;
            UpdatePanel_KucunD.Update();
            UpdatePanel1.Update();
        }
        if (Request.QueryString["status"] == "Pandian")//库存盘点权限
        {
            Title = "库存盘点维护";
            Panel_kucun.Visible = true;
            Gridview_Pur.Columns[0].Visible = false;
            Gridview_Pur.Columns[11].Visible = false;
            Gridview_Pur.Columns[12].Visible = true;
            Gridview_Pur.Columns[13].Visible = true;
            Gridview_Kucun.Columns[0].Visible = false;
            Button20.Visible = false;
            Button24.Visible = false;
            UpdatePanel_KucunD.Update();
            UpdatePanel1.Update();
        }
        if (Request.QueryString["status"] == "PandianLook")//库存盘点查看权限
        {

            Title = "库存盘点查看";
            Panel_kucun.Visible = true;
            Gridview_Pur.Columns[0].Visible = false;
            Gridview_Pur.Columns[11].Visible = false;
            Gridview_Pur.Columns[12].Visible = false;
            Gridview_Pur.Columns[13].Visible = true;
            Gridview_Kucun.Columns[0].Visible = false;
            Button20.Visible = false;
            Button24.Visible = false;
            UpdatePanel_KucunD.Update();
            UpdatePanel1.Update();
        }
        if (Request.QueryString["status"] == "SalesOut")//销售出库权限
        {
            //this.Panel4.Visible = true;
            //this.GridView_OrderDeliverPlan.Columns[13].Visible = true;
            //UpdatePanel5.Update();
            //this.Panel_OrderDeliverPlan.Visible = true;
            //this.Label44.Text = "";
            //BindDeliverPlan(); 
            Title = "销售出库";
            Panel_OutStore.Visible = true;//new outmain
            Button15.Visible = true;//new outmain
            Button18.Visible = true;//kucun search
            Button19.Visible = true;//confirm outD
            Gridview_OutM.Columns[13].Visible = true;
            Gridview_OutM.Columns[14].Visible = true;
            Gridview_OutM.Columns[15].Visible = true;

            UpdatePanel_OutStore.Update();
            UpdatePanel_OutD.Update();
        }
        if (Request.QueryString["status"] == "LingliaoOut")//领料出库权限
        {
            //this.Panel4.Visible = true;
            //this.GridView_OrderDeliverPlan.Columns[13].Visible = true;
            //UpdatePanel5.Update();
            //this.Panel_OrderDeliverPlan.Visible = true;
            //this.Label44.Text = "";
            //BindDeliverPlan(); 
            Title = "领料出库";
            Panel_OutStore.Visible = true;//new outmain
            Button15.Visible = true;//new outmain
            Button18.Visible = true;//kucun search
            Button19.Visible = true;//confirm outD
            Gridview_OutM.Columns[13].Visible = true;
            Gridview_OutM.Columns[14].Visible = true;
            Gridview_OutM.Columns[15].Visible = true;
            UpdatePanel_OutStore.Update();
            UpdatePanel_OutD.Update();
        }
        #endregion
        
    }
    protected void BindDropdownlist3()
    {
        DropDownList3.DataSource = outs.Select_IMStore();
        DropDownList3.DataTextField = "IMS_StoreName";
        DropDownList3.DataValueField = "IMS_StoreID";
        DropDownList3.DataBind();
    }
    #region 领料单主表
    //新建领料单
    protected void NewhLingliao(object sender, EventArgs e)
    {
        TextBox2.Text = Session["UserName"].ToString();
        TextBox7.Text = Session["Department"].ToString();
        Panel_NewLingliao.Visible = true;
        UpdatePanel_NewLingliao.Update();
    }
    //检索领料单
    protected void SearchLingliao(object sender, EventArgs e)
    {
        GetCondition_Lingliao();
        BindLingliaoM();
    }
    //加入汇总表
    protected void InsertLingliao(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString().Trim();
        foreach (GridViewRow item in Gridview_lingliaoMain.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {
               Guid ID = new Guid(Gridview_lingliaoMain.DataKeys[item.RowIndex]["IMRM_RequisitionID"].ToString());
               outs.Insert_IMRD_SUM(ID, man);
               int j =Convert.ToInt32( Label12.Text.ToString());
               Label12.Text = Convert.ToString(j + 1);
            }
        }
    }
    //查看汇总结果
    protected void SumLingliao(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Gridview1.DataSource = outs.Select_IMRD_SUM(Session["UserName"].ToString().Trim());
        Gridview1.DataBind();
        UpdatePanel2.Update();    
    }
    //领料单生成出库单
    protected void ConventhLingliao(object sender, EventArgs e)
    {
        Gridview1.Columns[5].Visible = true; 
        UpdatePanel2.Update();
       
    }
    //领料单检索条件获得
    public string GetCondition_Lingliao()
    {
        string conditon;
        string temp = "";
        if (TextBox1.Text != "")
        {
            temp += " and a.IMRM_RequisitionNum like'%" + TextBox1.Text.ToString() + "%'";
        }
        if (TextBox11.Text.ToString() != "")
        {
            temp += " and a.IMRM_Man like'%" + TextBox11.Text.ToString() + "%'";
        }
        if ((TextBox5.Text.ToString() == "" && TextBox6.Text.ToString() != "" )|| (TextBox6.Text.ToString() == ""&&TextBox5.Text.ToString() != ""))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写完整的时间段！')", true);
           
        }
        if (TextBox5.Text.ToString() != "" && TextBox6.Text.ToString() != "")
        {
            DateTime d1 = Convert.ToDateTime(TextBox5.Text.ToString().Trim());
            DateTime d2 = Convert.ToDateTime(TextBox6.Text.ToString().Trim());
            if (d2 <= d1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请确保起始时间小于结束时间！')", true);
            }
            else
            {
                temp += " and a.IMRM_RequisitionTime between'" + Convert.ToString(d1) + "' and '"+Convert.ToString(d2)+"'";
            }
            
        }
        if (DropDownList2.SelectedValue != "选择状态")
        {
            temp += " and a.IMRM_RequisitionState like'%" + DropDownList2.SelectedValue.ToString() + "%'";

        }
        if (TextBox26.Text != "")
        {
            temp += " and a.IMRM_Depart like'%" + TextBox26.Text.ToString() + "%'";

        }
        conditon = temp;
        label_lingliaocondition.Text = conditon;
        return conditon;
    }
    //绑定领料单主表
    protected void BindLingliaoM()
    {
        Gridview_lingliaoMain.DataSource = outs.Select_lingliaoMain(label_lingliaocondition.Text.ToString());
        Gridview_lingliaoMain.DataBind();
        UpdatePanel_lingliaoMain.Update();    
    }
    //清空领料单检索条件
    protected void Clear_lingliao_search()
    {
        TextBox1.Text = "";
        TextBox11.Text = "";
        DropDownList2.SelectedValue = "选择状态";
        TextBox5.Text = "";
        TextBox6.Text = "";
        UpdatePanel_LingliaoSearch.Update();
        
    }
    #endregion 
    #region 新建领料单及审核
    //确认新建领料单
    protected void NewhLingliaoMain(object sender, EventArgs e)
    {
        string man = TextBox2.Text.ToString();
        string depart = TextBox7.Text.ToString();
        Guid id = new Guid(DropDownList3.SelectedValue.ToString());
        outs.Insert_LingliaoMain(man,id,depart);
        Panel_NewLingliao.Visible = false;
        UpdatePanel_NewLingliao.Update();
        BindLingliaoM();
        UpdatePanel_lingliaoMain.Update();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功，请在领料单主表点击编辑继续操作。')", true);


    }
    //取消新建领料单
    protected void CanelhLingliaoMain(object sender, EventArgs e)
    {
        Panel_NewLingliao.Visible = false;
        TextBox2.Text = "";
        TextBox7.Text = "";
        UpdatePanel_NewLingliao.Update();
    }
    //审核通过
    protected void BT_TKOK_Click(object sender, EventArgs e)
    {
        Guid id = new Guid(label10.Text.ToString());
        string result = "审核通过";
        string op = TB_lingdaoyijian.Text.ToString();
        outs.Update_LingliaoMain_Check(id, result, op);
        BindLingliaoM();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已审核通过')", true);
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    //审核不通过
    protected void BT_TKNotOK_Click(object sender, EventArgs e)
    {
        Guid id = new Guid(label10.Text.ToString());
        string result = "审核驳回";
        string op = TB_lingdaoyijian.Text.ToString();
        outs.Update_LingliaoMain_Check(id, result, op);
        BindLingliaoM();
        if (op == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核驳回时请填写意见')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('已审核驳回')", true);
        }
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    //审核取消
    protected void BT_TKCanel_Click(object sender, EventArgs e)
    {
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    #endregion
    #region 库存物料检索
    //选择物料按钮
    protected void SelectKucun(object sender, EventArgs e)
    {
        Panel_kucun.Visible = true;
        label_SourceSort.Text = "领料";
        Button24.Visible = true;
        Gridview_Pur.Columns[0].Visible = true;
        Gridview_Pur.Columns[10].Visible = false;
        Gridview_Pur.Columns[11].Visible = false;
        label1.Text = "基础物料";
        BindPur();
        UpdatePanel1.Update();

    }
    //绑定库存表
    protected void BindPur()
    {
        GetCondition_Kucun();
        //this.label1.Text = "公司产品";
        if (label1.Text == "基础物料")
        {
            Gridview_Pur.DataSource = outs.Select_IMIM_Mat(label38.Text.ToString().Trim());

        }
        if (label1.Text == "公司产品")
        {
            Gridview_Pur.DataSource = outs.Select_IMIM_PT(label38.Text.ToString().Trim());

        }
        //this.Gridview_Pur.DataSource = outs.Select_IMInventoryMain(this.label38.Text.ToString().Trim());
        Gridview_Pur.DataBind();
        UpdatePanel1.Update();
        
    }
    //关闭物料检索
    protected void ColseMat(object sender, EventArgs e)
    {
        Panel_kucun.Visible = false;
        Panel_KucunD.Visible = false;
        UpdatePanel1.Update();
        UpdatePanel_KucunD.Update();
    }
    //物料检索
    protected void SelectMat(object sender, EventArgs e)
    {
        BindPur();
    }
    //规格型号框动态
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "基础物料")
        {
            TextBox4.Enabled = true;
        }
        else if (DropDownList1.SelectedValue == "公司产品")
        {
            TextBox4.Enabled = false;
        }
        UpdatePanel1.Update();
    }
    //库存物料单检索条件获得
    public string GetCondition_Kucun()
    {
        string conditon;
        string temp = "";
        string sort=DropDownList1.SelectedValue.ToString();
        label1.Text = sort;
        if (sort == "基础物料")
        {
            if (TextBox3.Text != "")
            {
                temp += " and b.IMMBD_MaterialName like'%" + TextBox3.Text.ToString().Trim() + "%'";
            }
            if (TextBox4.Text.ToString() != "")
            {
                temp += " and b.IMMBD_SpecificationModel like'%" + TextBox4.Text.ToString().Trim() + "%'";
            }
        }
        else if (sort == "公司产品")
        {
            if (TextBox3.Text != "")
            {
                temp += " and b.PT_Name like'%" + TextBox3.Text.ToString().Trim() + "%'";
            }
        }
        //if ((this.TextBox5.Text.ToString() == "" && this.TextBox6.Text.ToString() != "") || (this.TextBox6.Text.ToString() == "" && this.TextBox5.Text.ToString() != ""))
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_LingliaoSearch, this.GetType(), "alert", "alert('请填写完整的时间段！')", true);

        //}
        conditon = temp;
        label38.Text = conditon;
        return conditon;
    }
 
    #endregion
    #region 库存详细表
    //绑定库存详细表
    protected void BindKucunD()
    {
        string sort = label49.Text.ToString().Trim();
        if (sort == "领料出库")
        {
            string temp;
            temp = " and a.IMIM_ID like'%" + label55.Text.ToString() + "%'";
            temp += " and d.IMS_StoreID like'%" + label53.Text.ToString() + "%'";
            Gridview_Kucun.DataSource = outs.Select_IMInventoryDetail(temp);
            Gridview_Kucun.DataBind();
            UpdatePanel_KucunD.Update();
        }
        else
        {
            string id = label27.Text.ToString();
            string temp = "";
            temp += " and a.IMIM_ID like'%" + id + "%'";
            Gridview_Kucun.DataSource = outs.Select_IMInventoryDetail(temp);
            Gridview_Kucun.DataBind();
            UpdatePanel_KucunD.Update();
        }
     
    }
    //关闭库存详细表
    protected void CloseStoreD(object sender, EventArgs e)
    {
        Panel_KucunD.Visible = false;
        UpdatePanel_KucunD.Update();
    }
    //确认库存详细表的插入
    protected void ConfirmStoreD(object sender, EventArgs e)
    {
        string sort = label54.Text.ToString();
        if (label54.Text == "领料出库")
        {
            foreach (GridViewRow item in Gridview_Kucun.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                if (cb.Checked)
                {
                    Guid ID = new Guid(Gridview_Kucun.DataKeys[item.RowIndex]["IMID_ID"].ToString());
                    TextBox tb = item.FindControl("TextBox8") as TextBox;
                    if (tb.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('还有选中的物料未填写出库数量！')", true);
                        return;
                    }
                    decimal num = Convert.ToDecimal(tb.Text.ToString());
                    Guid outID = new Guid(label26.Text.ToString());
                    string man = Session["UserName"].ToString().Trim();
                    DataSet ds = outs.Select_SameBatchNum(ID, outID);
                    DataTable dt = ds.Tables[0];
                    int Alertnum = Convert.ToInt32(dt.Rows[0][0].ToString());
                    if (Alertnum == 0)
                    {
                        outs.Insert_IMOutD_Lingliao(ID, outID, num, man);
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('插入成功！')", true);
                        UpdatePanel_OutD.Update();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('相同批号物料不可以重复插入，插入失败！')", true);
                        return;
                    }
                   
                }
            }
        }
        else
        {
            foreach (GridViewRow item in Gridview_Kucun.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                if (cb.Checked)
                {
                    Guid ID = new Guid(Gridview_Kucun.DataKeys[item.RowIndex]["IMID_ID"].ToString());
                    TextBox tb = item.FindControl("TextBox8") as TextBox;
                    if (tb.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('还有选中的物料未填写出库数量！')", true);
                        return;
                    }
                    decimal num = Convert.ToDecimal(tb.Text.ToString());
                    Guid outID = new Guid(label26.Text.ToString());
                    DataSet ds = outs.Select_SameBatchNum(ID, outID);
                    DataTable dt = ds.Tables[0];
                    int Alertnum = Convert.ToInt32(dt.Rows[0][0].ToString());
                    if (Alertnum == 0)
                    {
                        outs.Insert_IMOutD_Yiban(ID, outID, num);
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('插入成功！')", true);
                        UpdatePanel_OutD.Update();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('相同批号物料不可以重复插入，插入失败！')", true);
                        return;
                    }
                  
                }
            }
        }
        BindOutD();
        label54.Text = "";
    }
    #endregion
    #region 领料单详细表
    //插入领料单详细
    protected void InsertIMIM(object sender, EventArgs e)
    {
        string sort = label_SourceSort.Text.ToString().Trim();
        if (sort == "领料")
        {
            foreach (GridViewRow item in Gridview_Pur.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                if (cb.Checked)
                {
                    Guid IMIM_ID = new Guid(Gridview_Pur.DataKeys[item.RowIndex]["IMIM_ID"].ToString());
                    Guid ID = new Guid(label2.Text.ToString().Trim());
                    outs.Insert_LingliaoDetail(ID, IMIM_ID);
                    BindLingliaoD();
                }
            }
        }
        
    }
    //取消
    protected void CanelIMIM(object sender, EventArgs e)
    {
        //this.Panel_kucun.Visible = false;
        //this.Panel5.Visible = false;
        UpdatePanel1.Update();
    }
    //绑定领料单详细表
    protected void BindLingliaoD()
    {
        if (label2.Text == "")
        {
            Gridview_LingliaoD.DataSource = outs.Select_IMRequisitionDetail("");
           
        }
        else
        {
            string temp = " and a.IMRM_RequisitionID like'%" + label2.Text.ToString() + "%'";
            Gridview_LingliaoD.DataSource = outs.Select_IMRequisitionDetail(temp);
        }
         Gridview_LingliaoD.DataBind();
         UpdatePanel_LingliaoD.Update();
    }
    //领料单详细提交
    protected void ConfirmLingliaoD(object sender, EventArgs e)
    {
        Guid id = new Guid(label2.Text.ToString());
        outs.Update_LingliaoDetail(id);
        Panel_lingliaoD.Visible = false;
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功')", true);
        BindLingliaoM();
        string depart=Session["Department"].ToString();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了新的领料单请进行审核！";
        string sErr = RTXhelper.SendbyDepAndRole(remind,depart,"领料单审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        UpdatePanel_LingliaoD.Update();
    
        Panel_kucun.Visible = false;
        Panel_KucunD.Visible = false;
        UpdatePanel1.Update();
        UpdatePanel_KucunD.Update();

      
    }
    //领料单详细关闭
    protected void CanelLingliaoD(object sender, EventArgs e)
    {
        Panel_lingliaoD.Visible = false;
        UpdatePanel_LingliaoD.Update();
    }
    #endregion
    #region 领料单汇总
    //关闭领料单详细汇总
    protected void CanelLingliaoSum(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
   
    //汇总清零
    protected void ZeroLingliaoSum(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString();
        outs.Delete_IMRD_SUM(man);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('当前汇总已清零成功')", true);
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Label12.Text = "0";
        UpdatePanel_lingliaoMain.Update();
    }
    #endregion
    #region 出库单主表
    //检索出库单主表
    protected void SelectOutM(object sender, EventArgs e)
    {
        GetCondition_OutM();
        BindOutM();
        UpdatePanel_OutStore.Update();

    }
    //绑定出库单主表
    protected void BindOutM()
    {
        Gridview_OutM.DataSource = outs.Select_IMOutM(label13.Text.ToString());
        Gridview_OutM.DataBind();
        UpdatePanel_OutStore.Update();
    }
    //重置
    protected void ColseOutM(object sender, EventArgs e)
    {
        Clear_OutM();
    }
    //清空检索条件
    protected void Clear_OutM()
    {
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        UpdatePanel_OutStore.Update();
    }
    //领料单检索条件获得
    public string GetCondition_OutM()
    {
        string conditon;
        string temp = "";
        if (TextBox8.Text != "")
        {
            temp += " and a.IMOHM_OutHouseNum like'%" + TextBox8.Text.ToString() + "%'";
        }
        if (TextBox13.Text.ToString() != "")
        {
            temp += " and a.IMOHM_TakeAwayMan like'%" + TextBox13.Text.ToString() + "%'";
        }
        if (TextBox9.Text.ToString() != "")
        {
            temp += " and a.IMOHM_OutHouseCompany like'%" + TextBox9.Text.ToString() + "%'";
        }
        if ((TextBox10.Text.ToString() == "" && TextBox12.Text.ToString() != "") || (TextBox12.Text.ToString() == "" && TextBox10.Text.ToString() != ""))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写完整的时间段！')", true);
            
        }
        if (TextBox10.Text.ToString() != "" && TextBox12.Text.ToString() != "")
        {
            DateTime d1 = Convert.ToDateTime(TextBox10.Text.ToString().Trim());
            DateTime d2 = Convert.ToDateTime(TextBox12.Text.ToString().Trim());
            if (d2 <= d1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请确保起始时间小于结束时间！')", true);
               
            }
            else
            {
                temp += " and a.IMOHM_TakeAwayMakeSureTime between'" + Convert.ToString(d1) + "' and '" + Convert.ToString(d2) + "'";
            }

        }
        if (DropDownList4.SelectedValue != "")
        {
            temp += " and a.IMSSBD_ID like'%" + DropDownList4.SelectedValue.ToString() + "%'";

        }
        if (DropDownList5.SelectedValue != "选择状态")
        {
            temp += " and a.IMOHM_State like'%" + DropDownList5.SelectedValue.ToString() + "%'";

        }
        conditon = temp;
        label13.Text = conditon;
        return conditon;
    }
    //绑定出库类型下拉框
    protected void BindDropdownlist4()
    {
        DropDownList4.DataSource = outs.Select_IMOuthouseSort("");
        DropDownList4.DataTextField = "IMSSBD_Name";
        DropDownList4.DataValueField = "IMSSBD_ID";
        DropDownList4.DataBind();

    }
    //新增出库单按钮
    protected void NewOutM(object sender, EventArgs e)
    {
        //if (Request.QueryString["status"] == "SalesOut")//销售出库权限
        //{
        //    this.Panel_XiaoshouOut.Visible = true;
        //    //BindDropList9();
        //    this.UpdatePanel_XiaoshouOut.Update();
        //}
        //else   if (Request.QueryString["status"] == "LingliaoOut")//领料出库
        //{
        //    this.Label45.Text = "LingliaoOut";
        //    this.Panel_NewOutM.Visible = true;
        //    BindDropdownlist6();
        //    BindDropdownlist7();
        //    this.UpdatePanel_NewOutM.Update();
        //}
        //else
        //{
            Panel_NewOutM.Visible = true;
            Label45.Text = "OtherOut";
            BindDropdownlist6();
            BindDropdownlist7();
            UpdatePanel_NewOutM.Update();
        //}
    }
    //绑定出库类型下拉框
    protected void BindDropdownlist6()
    {
        string temp;
        if (Request.QueryString["status"] == "SalesOut")//销售出库权限
        {
            DropDownList6.DataSource = outs.Select_IMOuthouseSort(" and IMSSBD_Name  like '销售出库' ");
        }
        else if (Request.QueryString["status"] == "LingliaoOut")//领料出库
        {
            DropDownList6.DataSource = outs.Select_IMOuthouseSort(" and IMSSBD_Name  like '领料出库' ");
        }
        else
        {
            DropDownList6.DataSource = outs.Select_IMOuthouseSort(" and IMSSBD_Name not like '销售出库' and IMSSBD_Name not like '领料出库' ");
        }
        DropDownList6.DataTextField = "IMSSBD_Name";
        DropDownList6.DataValueField = "IMSSBD_ID";
        DropDownList6.DataBind();

    }
    //绑定出库库房
    protected void BindDropdownlist7()
    {
        try
        {
            string depart = Session["Department"].ToString();
            string man = Session["UserName"].ToString().Trim();
            DropDownList7.DataSource = outs.Select_Store(depart, man);
            DropDownList7.DataTextField = "IMS_StoreName";
            DropDownList7.DataValueField = "IMS_StoreID";
            DropDownList7.DataBind();
        }
        catch (Exception)
        {

            throw;
        }

    }
    //取消新建出库单栏
    protected void CanelNewOutM(object sender, EventArgs e)
    {
        Panel_NewOutM.Visible = false;
        UpdatePanel_NewOutM.Update();
    }
    //确认新增的出库单主表
    protected void ConfirmNewOutM(object sender, EventArgs e)
    {
        try
        {
            if (TextBox14.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('必须填写出库对象！')", true);
                return;

            }
            Guid sortID = new Guid(DropDownList6.SelectedValue.ToString());
            Guid SotoreID = new Guid(DropDownList7.SelectedValue.ToString());
            string man = Session["UserName"].ToString();
            string company = TextBox14.Text.ToString().Trim();
            outs.Insert_OutM(sortID, SotoreID, man, company);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功，请在主表选择后续操作！')", true);
            BindOutM();
            Panel_NewOutM.Visible = false;
            UpdatePanel_OutStore.Update();

        }
        catch (Exception)
        {

            throw;
        }

    }
    //用户确认出库
    protected void ConfirmMan(object sender, EventArgs e)
    {
        User us = new User();
        string sort=label_Sort.Text.ToString();
        string password = us.EncodingPassword(TextBox17.Text);
        IList<UMUserInfoInfo> IUmuiInfo = us.Select_UMUserInfo("and UMUI_UserID='" + TextBox16.Text + "' and UMUI_Password='" + password + "'");
        if (IUmuiInfo.Count > 0)
        {
            //}
          
                    string man = TextBox16.Text.ToString();
                    Guid id = new Guid(Label31.Text.ToString());
                    outs.Update_IMOutM_IMIM(id, man);
                    BindOutM();
                    UpdatePanel_OutStore.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('确认成功,销售出库请继续填写物流信息！')", true);
                    Panel1.Visible = false;
                    UpdatePanel3.Update();
                    switch (sort)
                    {
                        case "销售出库":
                            {
                                Label46.Text = Label31.Text.ToString();
                                outs.Insert_SMOrderDeliver_SalesOut(new Guid(Label31.Text.ToString()));
                                Panel_XiaoshouOut.Visible = true;
                                UpdatePanel_XiaoshouOut.Update();
                                break;
                            }


                        //case "领料出库":
                        //    {

                        //        break;
                        //    }
                        //default:
                        //    {

                        //        break;
                        //    }
                    }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('用户名或密码错误！')", true);
            return;
        }
        BindOutM();
        
    }
    //用户取消确认出库
    protected void CanelMan(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel3.Update();
    }
    #endregion 
    #region 出库单详细表
    //绑定详细表
    protected void BindOutD()
    {
        string id = label26.Text.ToString();
        string temp = "";
         temp += " and a.IMOHM_ID like'%" + id + "%'";
         Gridview_OutD.DataSource = outs.Select_IMOuthouseDetail(temp);
         Gridview_OutD.DataBind();
         UpdatePanel_OutD.Update();
    }
    //打开库存检索
    protected void KucunSearch(object sender, EventArgs e)
    {
        string sort = label_Sort.Text.ToString();
        string man = Session["UserName"].ToString();
        outs.Delete_IMRD_SUM(man);
        switch (sort)
        {
            case "销售出库":
                {
                    Panel4.Visible = true; 
                    TextBox20.Text = DateTime.Now.ToShortDateString();
                    UpdatePanel5.Update();
                    Panel_OrderDeliverPlan.Visible = true;                   
                    UpdatePanel_OrderDeliverPlan.Update();
                    BindDeliverPlan();
                }
                break;

            case "领料出库":
                {
                    label_lingliaocondition.Text = " and IMRM_RequisitionState like '已审核' ";
                    Gridview_lingliaoMain.Columns[11].Visible = true;
                    BindLingliaoM();
                    Button1.Visible = false;
                    DropDownList2.SelectedValue = "已审核";
                    DropDownList2.Enabled = false;
                    Panel_LingliaoSearch.Visible = true;
                    UpdatePanel_LingliaoSearch.Update();
                    Panel_lingliaoMain.Visible = true;
                    Gridview_lingliaoMain.Columns[0].Visible = true;
                    UpdatePanel_lingliaoMain.Update();
                }
                break;
            default:
                {
                    Panel_kucun.Visible = true;
                    label_SourceSort.Text = "出库";
                    Button24.Visible = false;
                    Gridview_Pur.Columns[0].Visible = false;
                    Gridview_Pur.Columns[10].Visible = true;
                    Gridview_Pur.Columns[11].Visible = true;
                    label_OutHouseMID.Text = label26.Text.ToString();
                    UpdatePanel1.Update();
                    break;
                }
                
        }
      
    }
    //提交出库单详细表
    protected void ConfirmOutD(object sender, EventArgs e)
    {
           outs.Update_IMOutM(new Guid(label26.Text.ToString().Trim()));
           ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('出库单明细添加完毕，请点击确认出库按钮进行出库！')", true);
           Panel_OutD.Visible = false;
           UpdatePanel_OutD.Update();
           BindOutM();
  
    }
    //关闭出库单详细
    protected void CloseOutD(object sender, EventArgs e)
    {
        Panel_OutD.Visible = false;
        UpdatePanel_OutD.Update();
    }
    #endregion
    #region gridview
    //领料单
    protected void Gridview_lingliaoMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string man = Session["UserName"].ToString();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv.Row["IMRM_RequisitionState"].ToString() != "待提交")
            {
                e.Row.Cells[12].Enabled = false;
                e.Row.Cells[13].Enabled = false;


            }
            else
            {
                if (drv.Row["IMRM_Man"].ToString() != man)
                {
                    e.Row.Cells[12].Enabled = false;
                    e.Row.Cells[13].Enabled = false;


                }
                else
                {
                    e.Row.Cells[12].Enabled = true;
                    e.Row.Cells[13].Enabled = true;
                }
            }
            if (drv.Row["IMRM_RequisitionState"].ToString() == "已审核")
            {
                e.Row.Cells[14].Enabled = false;

            }
          

        }
    }
    protected void Gridview_lingliaoMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_lingliaoMain.BottomPagerRow;


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

        BindLingliaoM();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_lingliaoMain.PageCount ? Gridview_lingliaoMain.PageCount - 1 : newPageIndex;
        Gridview_lingliaoMain.PageIndex = newPageIndex;
        Gridview_lingliaoMain.DataBind();
    }
    protected void Gridview_lingliaoMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")
        {
             GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label2.Text = e.CommandArgument.ToString();
            label11.Text = Gridview_lingliaoMain.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            Panel_lingliaoD.Visible = true;
            Button5.Visible = false;
            Button6.Visible = true;
            Button10.Visible = false;
            Gridview_LingliaoD.Columns[10].Visible = false;
            Gridview_LingliaoD.Columns[11].Visible = false;
            BindLingliaoD();
            UpdatePanel_LingliaoD.Update();

        }
        if (e.CommandName == "Delete1")
        {
            outs.Delete_lingliaoMain(new Guid(e.CommandArgument.ToString()));
            BindLingliaoM();
            UpdatePanel_lingliaoMain.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
        }
        if (e.CommandName == "Edit1")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label2.Text = e.CommandArgument.ToString();
            label11.Text = Gridview_lingliaoMain.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            Panel_lingliaoD.Visible = true;
            Gridview_LingliaoD.Columns[10].Visible = true;
            Gridview_LingliaoD.Columns[11].Visible = true;
            BindLingliaoD();
            Button5.Visible = true;
            Button6.Visible = true;
            Button10.Visible = true;
            UpdatePanel_LingliaoD.Update();      
        }
        if (e.CommandName == "Check1")
        {
            label10.Text = e.CommandArgument.ToString();
            TB_shengchanman.Text = Session["UserName"].ToString();
            TB_shengchantime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TB_lingdaoyijian.Text = "";
            Panel_Sign.Visible = true;
            TB_lingdaoyijian.Enabled = true;
            BT_TKOK.Visible = true;
            BT_TKNotOK.Visible = true;
            UpdatePanel_Sign.Update();
        }
        if (e.CommandName == "Check1_Look")
        {
            string result = e.CommandArgument.ToString();
            DataSet ds = outs.Select_IMRequisitionMain_CheckResult(new Guid(result));
            DataTable dt = ds.Tables[0];
            Panel_Sign.Visible = true;
            TB_lingdaoyijian.Enabled = false;
            BT_TKOK.Visible = false;
            BT_TKNotOK.Visible = false;
            label10.Text = e.CommandArgument.ToString();
            TB_shengchanman.Text = "";
            TB_lingdaoyijian.Text=dt.Rows[0][1].ToString();
            TB_shengchantime.Text=dt.Rows[0][2].ToString();
            UpdatePanel_Sign.Update();

        }
    }
    //库存主表
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

        BindPur();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Pur.PageCount ? Gridview_Pur.PageCount - 1 : newPageIndex;
        Gridview_Pur.PageIndex = newPageIndex;
        Gridview_Pur.DataBind();
    }
    protected void Gridview_Pur_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Look5")
        {
            
            label27.Text = e.CommandArgument.ToString();
            label28.Text = Gridview_Pur.Rows[gvr.RowIndex].Cells[4].Text.ToString() + "-" + Gridview_Pur.Rows[gvr.RowIndex].Cells[5].Text.ToString();
            Panel_KucunD.Visible = true;
            BindKucunD();
            Gridview_Kucun.Columns[11].Visible = false;
            UpdatePanel_KucunD.Update();
        }
        if (e.CommandName == "Choose5")
        {
            
            label27.Text = e.CommandArgument.ToString();
            label28.Text = Gridview_Pur.Rows[gvr.RowIndex].Cells[4].Text.ToString() + "-" + Gridview_Pur.Rows[gvr.RowIndex].Cells[5].Text.ToString();
            Panel_KucunD.Visible = true;
            BindKucunD();
            Gridview_Kucun.Columns[11].Visible = true;
            UpdatePanel_KucunD.Update();
        }
        if (e.CommandName == "Pandian5")
        {
            Panel5.Visible = true;
            UpdatePanel4.Update();
            Guid id = new Guid(e.CommandArgument.ToString());
            string man = Session["UserName"].ToString().Trim();
            outs.Insert_Pandian(id, man);
            string temp = " and IMIM_ID like'%" + e.CommandArgument.ToString() + "%'";
            label39.Text = temp;
            label43.Visible = true;
            GridviewPandian.Columns[11].Visible = true;
            GridviewPandian.Columns[10].Visible = true;
            BindPandian();
        }
        if (e.CommandName == "LookPandian5")
        {
            Panel5.Visible = true;
            string temp = " and IMIM_ID like'%" + e.CommandArgument.ToString() + "%'";
            label39.Text = temp;
            label43.Visible = true;
            GridviewPandian.Columns[11].Visible = false;
            GridviewPandian.Columns[10].Visible = false;
            BindPandian();
        }
    }
    //库存详细表
    protected void Gridview_Kucun_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Kucun.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Kucun.Rows[i].Cells.Count; j++)
            {
                Gridview_Kucun.Rows[i].Cells[j].ToolTip = Gridview_Kucun.Rows[i].Cells[j].Text;
                if (Gridview_Kucun.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_Kucun.Rows[i].Cells[j].Text = Gridview_Kucun.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview_KucunD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Kucun.BottomPagerRow;


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

        BindKucunD();
        Gridview_Kucun.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Kucun.PageCount ? Gridview_Kucun.PageCount - 1 : newPageIndex;
        Gridview_Kucun.PageIndex = newPageIndex;
        Gridview_Kucun.DataBind();
    }
    protected void Gridview_Kucun_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (GridViewRow item in Gridview_Kucun.Rows)
            {
                CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
                TextBox tb = item.FindControl("TextBox8") as TextBox;
                if (cb.Checked)
                {                    
                    tb.Enabled = true;
                    UpdatePanel_KucunD.Update();
                }
            }
        }
    }
    //领料单详细表
    protected void Gridview_LingliaoD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_LingliaoD.BottomPagerRow;


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

        BindLingliaoD();
        Gridview_LingliaoD.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_LingliaoD.PageCount ? Gridview_LingliaoD.PageCount - 1 : newPageIndex;
        Gridview_LingliaoD.PageIndex = newPageIndex;
        Gridview_LingliaoD.DataBind();
    }
    protected void Gridview_LingliaoD_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview_LingliaoD.EditIndex = -1;
        BindLingliaoD();
    }
    protected void Gridview_LingliaoD_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Guid id = new Guid(Gridview_LingliaoD.DataKeys[e.RowIndex].Value.ToString());
        outs.Delete_LingliaoD(id);
        BindLingliaoD();
        UpdatePanel_LingliaoD.Update();
    }
    protected void Gridview_LingliaoD_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview_LingliaoD.EditIndex = e.NewEditIndex;
        BindLingliaoD();
    }
    protected void Gridview_LingliaoD_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid id = new Guid(Gridview_LingliaoD.DataKeys[e.RowIndex].Value.ToString());
        decimal num = Convert.ToDecimal(((TextBox)(Gridview_LingliaoD.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString());
        string remark = Convert.ToString(((TextBox)(Gridview_LingliaoD.Rows[e.RowIndex].Cells[9].Controls[0])).Text.Trim().ToString());
        outs.Update_LingliaoD(id, num, remark);
        Gridview_LingliaoD.EditIndex = -1;
        BindLingliaoD();
    }
    protected void Gridview_LingliaoD_DataBound(object sender, EventArgs e)
    {

        for (int i = 0; i < Gridview_LingliaoD.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_LingliaoD.Rows[i].Cells.Count; j++)
            {
                Gridview_LingliaoD.Rows[i].Cells[j].ToolTip = Gridview_LingliaoD.Rows[i].Cells[j].Text;
                if (Gridview_LingliaoD.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_LingliaoD.Rows[i].Cells[j].Text = Gridview_LingliaoD.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    //领料单汇总表
    protected void Gridview_LingliaoSum_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview1.BottomPagerRow;


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

        Gridview1.DataSource = outs.Select_IMRD_SUM(Session["UserName"].ToString().Trim());
        Gridview1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    //出库单主表
    protected void Gridview_OutM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_OutM.BottomPagerRow;


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

        BindOutM();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_OutM.PageCount ? Gridview_OutM.PageCount - 1 : newPageIndex;
        Gridview_OutM.PageIndex = newPageIndex;
        Gridview_OutM.DataBind();
    }
    protected void Gridview_OutM_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
      
        string sort = label_Sort.Text.ToString();
        if (e.CommandName == "Look2")
        {
            label_Sort.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            Button18.Visible = false;
            Button19.Visible = false;
            UpdatePanel_OutD.Update();
            label26.Text = e.CommandArgument.ToString();
            label21.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[3].Text.ToString().Trim();
            Panel_OutD.Visible = true;
            UpdatePanel_OutD.Update();
            BindOutD();
            Gridview_OutD.Columns[11].Visible = false;
            UpdatePanel_OutD.Update();        
        }
        if (e.CommandName == "Edit2")
        {
            label_Sort.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            Button18.Visible = true;
            Button19.Visible = true;
            UpdatePanel_OutD.Update();
            label26.Text = e.CommandArgument.ToString();
            Gridview_OutD.Columns[11].Visible = true;
            
            label21.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[3].Text.ToString().Trim();
            label53.Text = Gridview_OutM.DataKeys[gvr.RowIndex]["IMS_StoreID"].ToString().Trim();
            Panel_OutD.Visible = true;
            UpdatePanel_OutD.Update();
            BindOutD();
            
            
            //if (this.Gridview_OutM.Rows[gvr.RowIndex].Cells[7].Text.ToString().Trim() == "待提交")
            //{
            //    this.Gridview_OutD.Columns[11].Visible = true;
            //    this.UpdatePanel_OutD.Update();
            //}
            switch (sort){
                case "销售出库":
                    {
                        if (Request.QueryString["status"] == "SalesOut")//销售出库权限
                        {
                            Label47.Text = e.CommandArgument.ToString();//出库主表ID
                            GridView_OrderDeliverPlan.Columns[0].Visible = false ;
                            BindDeliverPlan();

                            
                        }
                        break;
                    }


                case "领料出库":
                    {
                        if (Request.QueryString["status"] == "LingliaoOut")//领料出库权限
                        {
                            
                        }
                    break;
                    }
                default:
                {
                    Panel_OutD.Visible = true;
                    UpdatePanel_OutD.Update();
                    break;
                }
                
            }
        }
        if (e.CommandName == "PrintDetail")
        {
            label_Sort.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Response.Redirect("../InventoryMgt/OutPrint.aspx?IMOHM_ID=" + al[0] + "&IMSSBD_Name=" + al[1] + "&IMS_StoreName=" + al[2] + "&IMOHM_OutHouseCompany=" + al[3] + "&IMOHM_MakeMan=" + al[4] + "&IMOHM_OuthouseTime=" + al[5] + "&IMOHM_TakeAwayMan=" + al[6] + "&IMOHM_TakeAwayMakeSureTime=" + al[7] + "&IMOHM_OutHouseNum=" + al[8]
                );
        }
        if (e.CommandName == "Delete2")
        {
            label_Sort.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            outs.Delete_OutM(new Guid(e.CommandArgument.ToString()));
            BindOutM();
            UpdatePanel_OutD.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);

        }
        if (e.CommandName == "Out2")
        {
            label_Sort.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            Label31.Text = e.CommandArgument.ToString();
            Panel1.Visible = true;
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Model2")
        {
            label_Sort.Text = Gridview_OutM.Rows[gvr.RowIndex].Cells[4].Text.ToString().Trim();
            Label46.Text = e.CommandArgument.ToString();
            Panel_XiaoshouOut.Visible = true;
            UpdatePanel_XiaoshouOut.Update();
        }
    }
    protected void Gridview_OutM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv.Row["IMOHM_State"].ToString() != "待提交")
            {
                e.Row.Cells[13].Enabled = false;
                e.Row.Cells[14].Enabled = false;
            }
            if (drv.Row["IMOHM_State"].ToString() != "待确认")
            {
                e.Row.Cells[15].Enabled = false;
            }
            if (drv.Row["IMOHM_State"].ToString() != "已完成")
            {
                e.Row.Cells[16].Enabled = false;
            }
            if (drv.Row["IMOHM_State"].ToString() != "已确认")
            {
                e.Row.Cells[17].Enabled = true;
            }
            else {
                e.Row.Cells[17].Enabled = false;
            }
        }
    }
    //出库单详细表
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
    protected void Gridview_OutD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_OutD.BottomPagerRow;


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

        BindOutD();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_OutD.PageCount ? Gridview_OutD.PageCount - 1 : newPageIndex;
        Gridview_OutD.PageIndex = newPageIndex;
        Gridview_OutD.DataBind();
    }
    protected void Gridview_OutD_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete3")
        {
            outs.Delete_OutD(new Guid(e.CommandArgument.ToString()));
            BindOutD();
            UpdatePanel_OutD.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindDeliverPlan();
        }
    }
    //盘点表
    protected void Gridview_Pandian_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridviewPandian.BottomPagerRow;


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

        BindPandian();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridviewPandian.PageCount ? GridviewPandian.PageCount - 1 : newPageIndex;
        GridviewPandian.PageIndex = newPageIndex;
        GridviewPandian.DataBind();
    }
    protected void Gridview_Pandian_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete6")
        {
            outs.Delete_Pandian(new Guid(e.CommandArgument.ToString().Trim()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindPandian();
        }
    }
    protected void GridviewPandian_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid id = new Guid(GridviewPandian.DataKeys[e.RowIndex].Value.ToString());
        decimal num = Convert.ToDecimal(((TextBox)(GridviewPandian.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString());
        outs.Update_Pandian(id, num);
        GridviewPandian.EditIndex = -1;
        BindPandian();
    }
    protected void GridviewPandian_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridviewPandian.EditIndex = -1;
        BindPandian();
    }
    protected void GridviewPandian_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridviewPandian.EditIndex = e.NewEditIndex;
        BindPandian();
    }
    protected void GridviewPandian_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            string man = Session["UserName"].ToString().Trim();
            if (drv.Row["IMC_ActualTotalNum"].ToString() != "")
            {
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[11].Enabled = false;
            }
            if (drv.Row["IMC_CountMan"].ToString() != man)
            {
                e.Row.Cells[10].Enabled = false; 
                e.Row.Cells[11].Enabled = false;
            }
            if (drv.Row["IMC_CountResult"].ToString() == "盘亏")
            {
                e.Row.Cells[5].ForeColor = Color.Red;
            }
            if (drv.Row["IMC_CountResult"].ToString() == "盘盈")
            {
                e.Row.Cells[5].ForeColor = Color.Green;
            }


        }
    }
    //发货计划
    protected void GridView_OrderDeliverPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_OrderDeliverPlan.BottomPagerRow;


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

        BindDeliverPlan();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_OrderDeliverPlan.PageCount ? GridView_OrderDeliverPlan.PageCount - 1 : newPageIndex;
        GridView_OrderDeliverPlan.PageIndex = newPageIndex;
        GridView_OrderDeliverPlan.DataBind();
    }
    //销售出库的库存详细表
    protected void GridView_OrderDeliverPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select2")
        {
            label49.Text = "销售出库";
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label56.Text = GridView_OrderDeliverPlan.Rows[gvr.RowIndex].Cells[9].Text.ToString().Trim();
            Guid id = new Guid(GridView_OrderDeliverPlan.DataKeys[gvr.RowIndex]["SMSOD_ID"].ToString().Trim());
            string man = Session["UserName"].ToString().Trim();
            string ptid = GridView_OrderDeliverPlan.DataKeys[gvr.RowIndex]["PT_ID"].ToString();
            label55.Text = ptid;
            label48.Text = Convert.ToString(id);
            Panel_XiaoshouKucun.Visible = true;
            BindXiaoshouKucun();
            //outs.Insert_SalesOut_Deliver(id, man); 最后提交整个销售订单再插入发货表
         
        }
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select1")
        {
            label49.Text = "领料出库";
            label54.Text = "领料出库";
            label55.Text = e.CommandArgument.ToString();
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            label28.Text = Gridview1.Rows[gvr.RowIndex].Cells[1].Text.ToString().Trim() +"-"+ Gridview1.Rows[gvr.RowIndex].Cells[2].Text.ToString().Trim();
            string man = Session["UserName"].ToString().Trim();
            Panel_KucunD.Visible = true;
            UpdatePanel_KucunD.Update();
            BindKucunD();
        }
    }
    protected void Gridview_KucunD1_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        BindXiaoshouKucun();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    #endregion
    #region 盘点
    //检索盘点
    protected void SelectPandian(object sender, EventArgs e)
    {
        GetCondition_Pandian();
        BindPandian();

    }
    //盘点关闭
    protected void ColsePandian(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel5.Visible = false;
        UpdatePanel4.Update();
    }
    //关闭表格
    protected void ColsePandianD(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel4.Update();
    }
    //绑定盘点表
    protected void BindPandian()
    {
        string condition=label39.Text.ToString();
        GridviewPandian.DataSource = outs.Select_Pandian(condition);
        GridviewPandian.DataBind();
        UpdatePanel4.Update();
        
    }
    //领料单检索条件获得
    public string GetCondition_Pandian()
    {
        string conditon;
        string temp = "";
        if (TextBox18.Text != "")
        {
            temp += " and IMC_Year like'%" + TextBox18.Text.ToString().Trim() + "%'";
        }
        if (TextBox19.Text.ToString() != "")
        {
            temp += " and IMC_Month like'%" + TextBox19.Text.ToString().Trim() + "%'";
        }
        if (TextBox15.Text.ToString() != "")
        {
            temp += " and IMC_Week like'%" + TextBox15.Text.ToString().Trim() + "%'";
        }
        if (DropDownList10.SelectedValue != "选择结果")
        {
            temp += " and IMC_CountResult like'%" + DropDownList10.SelectedValue.ToString() + "%'";

        }
        conditon = temp;
        label39.Text = conditon;
        return conditon;
    }
    #endregion
    #region 发货计划-销售出库
    //发货计划检索
    protected void SearchDeliverPlan(object sender, EventArgs e)
    {
        string temp = "";
        if (this.TextBox20.Text.ToString() != "")
        {
            temp += " and a.SMDP_Time =convert(smalldatetime, '" + this.TextBox20.Text.ToString() + "')";

        }
         if (TextBox22.Text.ToString() != "")
        {
            temp += " and d.CRMCIF_Name like '%" + TextBox22.Text.ToString() + "%'";
        }
         temp += " and a.SMSOD_ID not in (SELECT IMOutHouseDetail.SMSOD_ID from IMOutHouseDetail where IMOutHouseDetail.IMOHM_ID LIKE '"+label26.Text.ToString().Trim()+"')";
        Label44.Text = temp;
        BindDeliverPlan();
    }
    //绑定发货表
    protected void BindDeliverPlan()
    {
        GridView_OrderDeliverPlan.DataSource = dp.Select_DeliverPlan(Label44.Text.ToString().Trim());
        GridView_OrderDeliverPlan.DataBind();
        UpdatePanel_OrderDeliverPlan.Update();
    }
    #endregion
    #region 销售出库
    //销售出库主表确认
    protected void ConfirmXiaoshou(object sender, EventArgs e)
    {
        string model = TextBox24.Text.ToString().Trim();
        string modelnum = TextBox23.Text.ToString().Trim();
        Guid id = new Guid(Label46.Text.ToString());
        outs.Update_SMOrderDeliver_SalesOut(id, model, modelnum);
        BindOutM();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
       // string temp = " and d.CRMCIF_Name like '%" + this.TextBox21.Text.ToString() + "%'";
        //this.Label44.Text = temp;
        //BindDeliverPlan();
        //Guid SotoreID = new Guid(this.DropDownList7.SelectedValue.ToString());
        //string man = Session["UserName"].ToString();
        //string company = this.TextBox14.Text.ToString().Trim();
        
        //outs.Delete_SalesOut_Temp(man);
        //outs.Insert_SalesOut_Main(SotoreID, man, company, model, modelnum);
        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('生成成功，请在发货计划选择具体库存！')", true);
        Panel_XiaoshouOut.Visible = false;
        UpdatePanel_XiaoshouOut.Update();
       
    }
    //销售出库主表取消
    protected void CanelXiaoshou(object sender, EventArgs e)
    {
        Panel_XiaoshouOut.Visible = false;
        UpdatePanel_XiaoshouOut.Update();
    }
    //选择对应库存
    protected void NewSalseOutMain(object sender, EventArgs e)
    {
        
        foreach (GridViewRow item in GridView_OrderDeliverPlan.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                
            }
        }
    }  
   
    //关闭库存详细表
    protected void CloseStoreD1(object sender, EventArgs e)
    {
        Panel_XiaoshouKucun.Visible = false;
        UpdatePanel_XiaoshouKucun.Update();
    }
    //绑定销售库存详细表
    protected void BindXiaoshouKucun()
    {
        string sort=label49.Text.ToString().Trim();
        if (sort == "销售出库")
        {
            string temp = "";
            temp += " and b.PT_ID like'%" + label55.Text.ToString() + "%'";
            temp += " and d.IMS_StoreID like'%" + label53.Text.ToString() + "%'";
            //temp += " and d.IMS_StoreID like'%405EC6AE-920D-4DB6-8EC2-B6682AA191A5%'";
            Gridview2.DataSource = outs.Select_Xiashoukucun(temp);
            Gridview2.DataBind();
            UpdatePanel_XiaoshouKucun.Update();
        }
        
    }
    //库存详细表确认,插入库存数据到出库详细表
    protected void ConfirmStoreD1(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString().Trim();
        Guid Mid = new Guid(label26.Text.ToString());
        foreach (GridViewRow item in Gridview2.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox2") as CheckBox;
            if (cb.Checked)
            {
                Guid ID = new Guid(Gridview2.DataKeys[item.RowIndex]["IMID_ID"].ToString());
                TextBox tb = item.FindControl("TextBox8") as TextBox;
                if (tb.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('还有选中的物料未填写出库数量！')", true);
                    return;
                }
                decimal num = Convert.ToDecimal(tb.Text.ToString());            
                Guid smsodID = new Guid(label48.Text.ToString());
                DataSet ds = outs.Select_SameBatchNum(ID, Mid);
                DataTable dt = ds.Tables[0];
                //int Alertnum = Convert.ToInt32(dt.Rows[0][0].ToString());
                //if (Alertnum == 0)
                //{
                    outs.Insert_IMOutD_Xiaoshou(ID, man, num, smsodID, Mid);
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
                
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('相同批号物料不可以重复插入，插入失败！')", true);
                //    return;
                //}
              
            }
        }
        BindOutD();
        Panel_XiaoshouKucun.Visible = false;
        UpdatePanel_XiaoshouKucun.Update();

    }
    //全选
    protected void Cbx2_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        {
            for (int i = 0; i <= GridView_OrderDeliverPlan.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView_OrderDeliverPlan.Rows[i].FindControl("CheckBox2");
                if (Cbx2_SelectAll.Checked)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
            UpdatePanel_OrderDeliverPlan.Update();
        }
    }
    //发货计划里的提交
    protected void ConfirmSalseOutDetail(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString().Trim();
        outs.Update_IMOutHouseMain_Xiaoshou(man);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
        Button33.Visible = false;
        UpdatePanel_OrderDeliverPlan.Update();
        BindDeliverPlan();

    }
    //绑定droplist9
    //protected void BindDropList9()
    //{
    //    string depart = Session["Department"].ToString();
    //    string man = Session["UserName"].ToString().Trim();
    //    this.DropDownList9.DataSource = outs.Select_Store(depart, man);
    //    this.DropDownList9.DataTextField = "IMS_StoreName";
    //    this.DropDownList9.DataValueField = "IMS_StoreID";
    //    this.DropDownList9.DataBind();
    //}

    //关闭
    protected void CloseDeliverPlan(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel5.Update();
        Panel_OrderDeliverPlan.Visible = false;
        UpdatePanel_OrderDeliverPlan.Update();
    }


    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (sender as TextBox);
        GridViewRow gvr = ((GridViewRow)(tb.Parent.Parent));
        decimal num = Convert.ToDecimal(Gridview_Kucun.Rows[gvr.RowIndex].Cells[5].Text);
        decimal num1;
        if (tb.Text == "")
        {
            num1 = 0;
        }
        else
        {
            num1 = Convert.ToDecimal(tb.Text);
        }
        if (num1 > num)
        {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('出库数量不可以大于库存数量！')", true);
                return;    
        }
    }
    protected void TextBox8_TextChanged1(object sender, EventArgs e)
    {
       //TextBox tb = (sender as TextBox);
       // GridViewRow gvr = ((GridViewRow)(tb.Parent.Parent));
       // decimal num = Convert.ToDecimal(Gridview_Kucun.Rows[gvr.RowIndex].Cells[5].Text);
       // decimal num1;
       // if (tb.Text == "")
       // {
       //     num1 = 0;
       // }
       // else
       // {
       //     num1 = Convert.ToDecimal(tb.Text);
       // }
       // if (num1 > num)
       // {
       //         ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('出库数量不可以大于库存数量！')", true);
       //         return;    
       // }
    }
    protected void Select_BatchNum(object sender, EventArgs e)
    {
        string sort = label49.Text.ToString().Trim(); 
        string temp;
        if (sort == "领料出库")
        {
          
            temp = " and a.IMIM_ID like'%" + label55.Text.ToString() + "%'";
            temp += " and d.IMS_StoreID like'%" + label53.Text.ToString() + "%'";
           
        }
        else
        {
            string id = label27.Text.ToString();
            temp = " and a.IMIM_ID like'%" + id + "%'";
            
        }
        if (TextBox21.Text != "")
        {
            temp += " and a.IMID_BatchNum like '%" + TextBox21.Text + "%'";
        }
        Gridview_Kucun.DataSource = outs.Select_IMInventoryDetail(temp);
        Gridview_Kucun.DataBind();
        UpdatePanel_KucunD.Update();
    }
    protected void Select_BatchNum1(object sender, EventArgs e)
    {
        string temp = "";
        temp += " and b.PT_ID like'%" + label55.Text.ToString() + "%'";
        temp += " and d.IMS_StoreID like'%" + label53.Text.ToString() + "%'";
        if (TextBox21.Text != "")
        {
            temp += " and a.IMID_BatchNum like '%" + TextBox25.Text + "%'";
        }
        //temp += " and d.IMS_StoreID like'%405EC6AE-920D-4DB6-8EC2-B6682AA191A5%'";
        Gridview2.DataSource = outs.Select_Xiashoukucun(temp);
        Gridview2.DataBind();
        UpdatePanel_XiaoshouKucun.Update();
    }
}
    #endregion
  


