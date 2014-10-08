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
using RTXHelper;


public partial class ProjectManagement_PMEquipment : System.Web.UI.Page
{
    PMSupplyInfo_PMSupplyContactL pml = new PMSupplyInfo_PMSupplyContactL();
    PRMProjectScheduleL prl = new PRMProjectScheduleL();
    PMEquipmentL pl = new PMEquipmentL();
    PMEquipmentinfo PMEquipmentinfo = new PMEquipmentinfo();
    EquipNameModelL EL = new EquipNameModelL();
    PMSupplyMaterialL pll = new PMSupplyMaterialL();
    PMSupplyCertificL pc = new PMSupplyCertificL();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.label_pagestate.Text = Request.QueryString["state"];
        string state = this.label_pagestate.Text;
        if (state == "Make")
        {
            this.Title = "设备采购申请制定";
            this.Button3.Visible = true;
            this.Gridview1.Columns[13].Visible = false;
            this.Gridview1.Columns[14].Visible = false;
            this.Gridview1.Columns[15].Visible = false;
            this.Gridview1.Columns[16].Visible = false;
            //this.Gridview1.Columns[16].Visible = false;
            this.Gridview1.Columns[23].Visible = false;
        }
        if (state == "ESupplyCheck")
        {
            this.Title = "设备采购申请审核";
            this.Button3.Visible = false;
            this.Gridview1.Columns[12].Visible = false;
            this.Gridview1.Columns[14].Visible = false;
            this.Gridview1.Columns[15].Visible = false;
            this.Gridview1.Columns[16].Visible = false;
            this.Gridview1.Columns[19].Visible = false;
            this.Gridview1.Columns[23].Visible = false;
            this.Gridview1.Columns[21].Visible = false;
            this.Gridview1.Columns[22].Visible = false;
        }
        if (state == "ESupplyPurchase")
        {
            this.Title = "设备采购";
            this.Button3.Visible = false;
            this.Gridview1.Columns[12].Visible = false;
            this.Gridview1.Columns[13].Visible = false;
            this.Gridview1.Columns[15].Visible = false;
            this.Gridview1.Columns[16].Visible = false;
            //this.Gridview1.Columns[16].Visible = false;
            this.Gridview1.Columns[18].Visible = false;
            this.Gridview1.Columns[19].Visible = false;
            this.Gridview1.Columns[21].Visible = false;
            this.Gridview1.Columns[22].Visible = false;
            this.Gridview1.Columns[23].Visible = true;
        }
        if (state == "ESupplyTest")
        {
            this.Title = "设备采购调试";
            this.Button3.Visible = false;
            this.Gridview1.Columns[12].Visible = false;
            this.Gridview1.Columns[13].Visible = false;
            this.Gridview1.Columns[14].Visible = false;
            this.Gridview1.Columns[16].Visible = false;
            //this.Gridview1.Columns[17].Visible = false;
            this.Gridview1.Columns[19].Visible = false;
            this.Gridview1.Columns[18].Visible = false;
            this.Gridview1.Columns[23].Visible = false;
            this.Gridview1.Columns[21].Visible = false;
            this.Gridview1.Columns[22].Visible = false;
        }
        if (state == "EAcceptCheck")
        {
            this.Title = "设备采购验收审核";
            this.Button3.Visible = false;
            this.Gridview1.Columns[12].Visible = false;
            this.Gridview1.Columns[13].Visible = false;
            this.Gridview1.Columns[15].Visible = false;
            this.Gridview1.Columns[14].Visible = false;
            this.Gridview1.Columns[18].Visible = false;
            this.Gridview1.Columns[23].Visible = false;
            this.Gridview1.Columns[21].Visible = false;
            this.Gridview1.Columns[22].Visible = false;
        }
        if (!(Session["UserRole"].ToString().Contains("采购设备申请制定") || Session["UserRole"].ToString().Contains("设备采购调试") || Session["UserRole"].ToString().Contains("设备采购验收审核") || Session["UserRole"].ToString().Contains("采购设备申请审核") || Session["UserRole"].ToString().Contains("设备采购制定") || Session["UserRole"].ToString().Contains("技术副总设备采购审核")||Session["UserRole"].ToString().Contains("总经理设备采购审核")))
        {
            Response.Redirect("~/Default.aspx");
        }

        if (!IsPostBack)
        {
            BindGridview1("");
            this.UpdatePanel_PMEquipmentApply.Update();
        }
    }
    //绑定设备采购申请单表
    private void BindGridview1(string Condition)
    {
        this.Gridview1.DataSource = pl.SelectPMEquipmentApply(Condition);
        this.Gridview1.DataBind();
    }
    #region//检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string Condition = GetCondition();
        BindGridview1(Condition);
        this.UpdatePanel_PMEquipmentApply.Update();
        this.Panel_New.Visible = false;
        this.UpdatePanel_New.Update();
        this.Panel16.Visible = false;
        this.UpdatePanel8.Update();
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
       
        this.Panel1.Visible = false;
        this.UpdatePanel3.Update();
        this.Panel9.Visible = false;
        this.UpdatePanel4.Update();
        this.Panel11.Visible = false;
        this.UpdatePanel5.Update();
        this.Panel_Supply.Visible = false;
        this.UpdatePanel_Supply.Update();
        this.Panel17.Visible = false;
        this.UpdatePanel9.Update();
        this.Panel12.Visible = false;
        this.UpdatePanel6.Update();
        this.Panel18.Visible = false;
        
        
        this.Panel_EquipmentCost.Visible = false;
        this.UpdatePanel_EquipmentCost.Update();
    }
    //获取检索条件
    protected string GetCondition()
    {
        string Condition;
        string item = "";
        if (this.EquipmentName.Text != "")
        {
            item += "and IMMBD_MaterialName like'%" + this.EquipmentName.Text.ToString() + "%'";
        }
        if (this.TextBox1.Text != "")
        {
            item += "and PMEA_Model like'%" + this.TextBox1.Text.ToString() + "%'";
        }
        if (this.TextBox2.Text != "")
        {
            item += "and PMEA_EquipmentApplyNum='" + this.TextBox2.Text.ToString() + "'";
        }
        if (this.Depart.Text != "")
        {
            item += "and PMEA_ApplyDepert like'%" + this.Depart.Text.ToString() + "%'";
        }
        if (this.TextBox_SPTime2.Text != "" && this.TextBox_SPTime3.Text != "")
        {
            item += "and PMEA_NeedTime>='" + this.TextBox_SPTime2.Text.ToString() + "'" + "and PMEA_NeedTime<='" + this.TextBox_SPTime3.Text.ToString() + "'";
        }
        if (this.TextBox_SPTime2.Text != "" && this.TextBox_SPTime3.Text == "")
        {
            item += "and PMEA_NeedTime>='" + this.TextBox_SPTime2.Text.ToString() + "'";
        }
        if (this.DropDownList2.SelectedValue != "请选择")
        {
            item += "and PMEA_ApplyState='" + this.DropDownList2.SelectedValue.ToString() + "'";
        }
        Condition = item;
        this.label_QA.Text = Condition;
        return Condition;
    }
    #endregion
    //新增
    protected void Button3_New(object sender, EventArgs e)
    {
        this.DDLMark.SelectedValue = Session["Department"].ToString();
        Bind_DDLMark(this.DDLMark);
        this.label7.Text = "新增设备采购申请";

        this.Panel_New.Visible = true;
        this.UpdatePanel_New.Update();
    }
    //重置
    protected void Button2_Reset(object sender, EventArgs e)
    {
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
        this.EquipmentName.Text = "";
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        this.Depart.Text = "";
        this.TextBox_SPTime2.Text = "";
        this.TextBox_SPTime3.Text = "";
        this.DropDownList2.SelectedValue = "请选择";
        this.UpdatePanel_PMEquipmentSearch.Update();
    }
    //绑定设备采购验收表
    private void BindGridview3(PMEquipmentinfo PMEquipmentinfo)
    {
        this.Gridview3.DataSource = pl.SelectPMEquipmentCheckAccept(PMEquipmentinfo);
        this.Gridview3.DataBind();
    }
    //设备采购申请表的编辑、申请审核、采购、调试、验收审核、财务
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Niguo")//编辑
        {
           
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            if (this.Session["Department"].ToString() == this.Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString())
            {
                Bind_DDLMark(this.DDLMark);
                this.label_PMEA_ID.Text = e.CommandArgument.ToString();
                //PMEquipmentinfo.PMEA_ID = new Guid(e.CommandArgument.ToString());
                string condition = "";
                condition = "and PMEA_ID='" + this.label_PMEA_ID.Text.ToString() + "'";
                DataSet ds = pl.SelectPMEquipmentApply(condition);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.label_Material.Text = dt.Rows[0][3].ToString();
                    this.TextBox3.Text = dt.Rows[0][44].ToString();
                    this.TextBox4.Text = dt.Rows[0][7].ToString();
                    this.TextBox5.Text = dt.Rows[0][8].ToString();
                    this.DDLMark.Text = dt.Rows[0][4].ToString();
                    this.TextBox7.Text = dt.Rows[0][10].ToString();
                    this.TextBox6.Text = dt.Rows[0][9].ToString();
                    this.TextBox8.Text = dt.Rows[0][11].ToString();
                    this.TextBox9.Text = dt.Rows[0][12].ToString();

                }
                this.label7.Text = "修改设备采购申请";
                this.Panel_New.Visible = true;
                this.UpdatePanel_New.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('抱歉，你没有此权限！')", true);
                return;
            }
        }
        if (e.CommandName == "Delete1")//申请审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.Gridview6.Columns[8].Visible = false;//删除
            this.label_PMEA_ID.Text = e.CommandArgument.ToString();

            if (this.Session["UserRole"].ToString().Contains("采购设备申请审核") && (this.Gridview1.Rows[row.RowIndex].Cells[11].Text == "提交申请制定" || this.Gridview1.Rows[row.RowIndex].Cells[11].Text == "部门部长审核通过"))
            {
                this.label_Selected.Text = "设备采购申请审核";
                this.label_Selected.Visible = true;
                PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                PMEquipmentinfo.PMEAC_State = "申请审核";
                BindGridview6(PMEquipmentinfo);
                this.Gridview6.Columns[7].Visible = true;
                this.Panel_Sign.Visible = true;
                this.UpdatePanel_Sign.Update();
            }
            else
             if (Session["UserRole"].ToString().Contains("技术副总设备采购审核") && this.Gridview1.Rows[row.RowIndex].Cells[11].Text == "相关部门审核通过")
                {

                    this.Panel1.Visible = true;
                    this.Panel6.Visible = true;
                    this.Button23.Visible = false;
                    this.TextBox10.Enabled = true;
                    this.label36.Visible = false;
                    this.Label37.Visible = false;
                    this.label38.Visible = false;
                    this.label39.Visible = false;
                    this.label47.Text = this.label_Department.Text.ToString() + "部长审核";
                    this.UpdatePanel3.Update();
                }
            else 
               if (Session["UserRole"].ToString().Contains("总经理设备采购审核") && this.Gridview1.Rows[row.RowIndex].Cells[11].Text == "技术副总审核通过")
                {
                    this.label43.Visible = false;
                    this.label45.Visible = false;
                    this.Label44.Visible = false;
                    this.label46.Visible = false;


                    this.Panel1.Visible = true;
                    this.Panel6.Visible = false;
                    this.Panel9.Visible = true;
                    this.Panel10.Visible = true;
                    this.Button12.Visible = true;
                    this.Button13.Visible = true;
                    this.Button14.Visible = true;
                    this.Button33.Visible = false;
                    this.Label37.Visible = true;

                    this.TextBox10.Enabled = false;
                    this.label47.Text = this.label_Department.Text.ToString() + "部长审核";
                    string condition;
                    condition = "and PMEA_ID='" + this.label_PMEA_ID.Text.ToString() + "'";
                    DataSet ds = pl.SelectPMEquipmentApply(condition);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        this.label36.Text = dt.Rows[0][28].ToString();
                        this.label38.Text = dt.Rows[0][39].ToString();
                        this.label39.Text = dt.Rows[0][30].ToString();
                        this.TextBox10.Text = dt.Rows[0][29].ToString();
                    }
                    this.UpdatePanel4.Update();
                    this.UpdatePanel3.Update();
                    this.UpdatePanel1.Update();
                }
            else 
                 if (this.Session["UserRole"].ToString().Contains("设备采购财务总监审核") && this.Gridview1.Rows[row.RowIndex].Cells[11].Text.ToString() == "总经理审核通过" && this.Gridview1.Rows[row.RowIndex].Cells[10].Text.ToString() != "&nbsp;")
                {
                    this.label47.Text = "财务总监审核";
                    this.label18.Visible = true;
                    this.label19.Visible = true;
                    this.label20.Visible = true;
                    this.label21.Visible = true;
                    this.label_EquipmentName.Text = this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString();
                    this.label_EquipmentNum.Text = this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[5].Text.ToString().Trim().Replace("&nbsp;", "0");
                    this.label_EquipmentPrice.Text = this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[10].Text.ToString().Trim().Replace("&nbsp;", "0");
                    this.label_EquipmentMoney.Text = Convert.ToString(Convert.ToDecimal(this.label_EquipmentPrice.Text.ToString()) * Convert.ToDecimal(this.label_EquipmentNum.Text.ToString()));
                    this.label_EquipmentMoney.Visible = true;
                    this.label_EquipmentName.Visible = true;
                    this.label_EquipmentNum.Visible = true;
                    this.label_EquipmentPrice.Visible = true;
                    this.TextBox14.Enabled = true;
                    this.Panel7.Visible = true;
                    this.Panel8.Visible = true;
                    this.UpdatePanel1.Update();

                }
                 else
                 {
                     ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('抱歉，还没进入你负责的环节！')", true);
                     return;
                 }
            
        }
        if (e.CommandName == "Approve")//采购
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.label_PMEA_ID.Text = e.CommandArgument.ToString();
            this.label_Material.Text = this.Gridview1.DataKeys[row.RowIndex]["IMMBD_MaterialID"].ToString();
            string condition;
            condition = "and PMEA_ID='" + this.label_PMEA_ID.Text.ToString() + "'";
            DataSet ds = pl.SelectPMEquipmentApply(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.label62.Text = dt.Rows[0][2].ToString() + "  " + dt.Rows[0][44].ToString() + "  " + dt.Rows[0][4].ToString();
                this.TextBox17.Text = dt.Rows[0][41].ToString();
            }
            string ccondition = " and IMMaterialBasicData.IMMBD_MaterialID='" + this.Gridview1.DataKeys[row.RowIndex]["IMMBD_MaterialID"].ToString() + "'";
            DataSet dst = pll.SelectPMPurchaseSMaterial(ccondition);
            DataTable ddt = dst.Tables[0];
            if(ddt.Rows.Count>0)
            {
                this.label_Unit.Text = ddt.Rows[0][1].ToString();
            }
            this.Panel11.Visible = true;
            this.UpdatePanel5.Update();
        }
        if (e.CommandName == "Coutersign")//调试
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
           
                this.label_PMEA_ID.Text = e.CommandArgument.ToString();
                string condition;
                condition = "and PMEA_ID='" + this.label_PMEA_ID.Text.ToString() + "'";
                DataSet ds = pl.SelectPMEquipmentApply(condition);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.label_Fiona.Text = "新建调试";
                    this.label65.Text = dt.Rows[0][2].ToString() + "  " + dt.Rows[0][44].ToString() + "  " + dt.Rows[0][46].ToString();
                    this.label17.Text = dt.Rows[0][2].ToString() + "  " + dt.Rows[0][44].ToString() + "  " + dt.Rows[0][4].ToString();
                    this.TextBoxDDL3.Text = dt.Rows[0][4].ToString();
                    PMEquipmentinfo.PMPO_PurchaseOrderID = new Guid(dt.Rows[0][1].ToString());
                    if (this.Gridview1.Rows[row.RowIndex].Cells[11].Text == "已调试")
                    {

                        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
                        DataSet dst = pl.SelectPMEquipmentCheckAccept(PMEquipmentinfo);
                        DataTable dts = dst.Tables[0];
                        if (dts.Rows.Count > 0)
                        {
                            this.label_Fiona.Text = "修改调试";
                            this.TextBox24.Text = dts.Rows[0][8].ToString();
                            this.TextBox28.Text = dts.Rows[0][2].ToString();
                            this.TextBox29.Text = dts.Rows[0][3].ToString();
                            this.TextBox25.Text = dts.Rows[0][5].ToString();
                            this.TextBox26.Text = dts.Rows[0][6].ToString();
                            this.TextBox27.Text = dts.Rows[0][4].ToString();
                            this.TextBox30.Text = dts.Rows[0][7].ToString();
                        }
                    }
                }
                DataSet dss = pl.SelectPMESupply(PMEquipmentinfo);
                DataTable dtt = dss.Tables[0];
                if (dtt.Rows.Count > 0)
                {
                    this.TextBox23.Text = dtt.Rows[0][1].ToString();
                }

                this.Panel12.Visible = true;
                this.UpdatePanel6.Update();
                PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
                BindGridview3(PMEquipmentinfo);
                this.Panel17.Visible = false;
                this.UpdatePanel9.Update();
                
            }
    
        
        if (e.CommandName == "Check1")//验收审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.Button31.Visible = false;
            this.label_PMEA_ID.Text = e.CommandArgument.ToString();
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
            BindGridview3(PMEquipmentinfo);
            this.label_Selected.Visible = true;
            this.label_Selected.Text = "设备采购申请验收审核";
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "验收审核";
            BindGridview6(PMEquipmentinfo);
            this.Gridview6.Columns[7].Visible = true;
            this.Panel_Sign.Visible = true;
            this.UpdatePanel_Sign.Update();

            string condition;
            condition = "and PMEA_ID='" + this.label_PMEA_ID.Text.ToString() + "'";
            DataSet ds = pl.SelectPMEquipmentApply(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //this.label81.Text = dt.Rows[0][2].ToString() + "  " + dt.Rows[0][44].ToString() + "  " + dt.Rows[0][4].ToString();
                this.label17.Text = dt.Rows[0][2].ToString() + "  " + dt.Rows[0][45].ToString() + "  " + dt.Rows[0][4].ToString();
            }
            //this.Panel13.Visible = true;
            //this.Panel14.Visible = true;
            //this.UpdatePanel7.Update();
            this.Button34.Visible = false;
            this.Panel14.Visible = true;
            this.Panel17.Visible = true;
            this.Markup.Checked = false;
            this.CheckBox1.Checked = false;
            this.CheckBox2.Checked = false;
            this.CheckBox3.Checked = false;
            this.UpdatePanel9.Update();
        }
        if (e.CommandName == "Check2")//财务
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.label_PMEA_ID.Text = e.CommandArgument.ToString();
            PMEquipmentinfo.IMMBD_MaterialID = new Guid(this.Gridview1.DataKeys[row.RowIndex]["IMMBD_MaterialID"].ToString());
            this.label_Material.Text = this.Gridview1.DataKeys[row.RowIndex]["IMMBD_MaterialID"].ToString();
            this.Label_EC.Text = this.Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString() + "   " + this.Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString() + "   " + this.Gridview1.Rows[row.RowIndex].Cells[4].Text.ToString();
            BindGridview4(PMEquipmentinfo);
            this.Panel_EquipmentCost.Visible = true;
            this.UpdatePanel_EquipmentCost.Update();
        }
        if (e.CommandName == "Clear")//查看申请审核意见
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.label_PMEA_ID.Text = e.CommandArgument.ToString();
            Button43.Visible = true;
            this.label_Selected.Text = "设备采购申请审核";
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "申请审核";
            BindGridview6(PMEquipmentinfo);
            this.Gridview6.Columns[7].Visible = false;//审核
            this.Gridview6.Columns[8].Visible = false;//删除
            this.Panel_Sign.Visible = true;
            this.UpdatePanel_Sign.Update();


            this.TextBox10.Enabled = false;
            this.TextBox11.Enabled = false;

            this.Panel1.Visible = true;
            this.Panel6.Visible = false;
            this.Panel9.Visible = true;
            this.Panel10.Visible = true;
            this.Button12.Visible = false;
            this.Button13.Visible = false;
            this.Button14.Visible = false;
            this.Button33.Visible = true;
            this.Label37.Visible = true;
            
            this.label43.Visible = true;
            this.Label44.Visible = true;
            this.label45.Visible = true;
            this.label46.Visible = true;
            this.label47.Text = this.label_Department.Text.ToString() + "部长审核";
            string condition;
            condition = "and PMEA_ID='" + this.label_PMEA_ID.Text.ToString() + "'";
            DataSet ds = pl.SelectPMEquipmentApply(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.label48.Text = dt.Rows[0][13].ToString();
                this.label51.Text = dt.Rows[0][34].ToString();
                this.label52.Text = dt.Rows[0][15].ToString();
                this.TextBox14.Text = dt.Rows[0][14].ToString();
                this.label36.Text = dt.Rows[0][28].ToString();
                this.label38.Text = dt.Rows[0][39].ToString();
                this.label39.Text = dt.Rows[0][30].ToString();
                this.TextBox10.Text = dt.Rows[0][29].ToString();

                this.label43.Text = dt.Rows[0][31].ToString();
                this.label45.Text = dt.Rows[0][40].ToString();
                this.label46.Text = dt.Rows[0][33].ToString();
                this.TextBox11.Text = dt.Rows[0][32].ToString();
            }
            this.UpdatePanel4.Update();
            this.UpdatePanel3.Update();
           
            this.UpdatePanel1.Update();
        }
        if (e.CommandName == "Leo")//查看验收审核意见
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.label_PMEA_ID.Text = e.CommandArgument.ToString();
            //PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
            //BindGridview3(PMEquipmentinfo);
            this.label_Selected.Text = "设备采购申请验收审核";
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "验收审核";
            BindGridview6(PMEquipmentinfo);
            this.Gridview6.Columns[7].Visible = false;
            this.Panel_Sign.Visible = true;
            this.UpdatePanel_Sign.Update();
            string condition;
            condition = "and PMEA_ID='" + this.label_PMEA_ID.Text.ToString() + "'";
            DataSet ds = pl.SelectPMEquipmentApply(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //this.label81.Text = dt.Rows[0][2].ToString() + "  " + dt.Rows[0][44].ToString() + "  " + dt.Rows[0][4].ToString();
                this.label17.Text = dt.Rows[0][2].ToString() + "  " + dt.Rows[0][44].ToString() + "  " + dt.Rows[0][4].ToString();
            }
            //this.Panel13.Visible = true;
            //this.Panel14.Visible = true;
            //this.UpdatePanel7.Update();
            this.Button34.Visible = true;
            this.Panel14.Visible = false;
            this.Panel17.Visible = false;
            this.Markup.Checked = true;
            this.CheckBox1.Checked = true;
            this.CheckBox2.Checked = true;
            this.CheckBox3.Checked = true;
            this.UpdatePanel9.Update();
        }
        if (e.CommandName == "Ausaa" || e.CommandName == "Alsaa")//选择审核部门或者选择验收部门
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.Gridview6.Columns[7].Visible = false;//审核
            //this.Gridview6.Columns[6].Visible = false;//查看
            this.Gridview6.Columns[8].Visible = true;//删除
            this.label_PMEA_ID.Text = e.CommandArgument.ToString();
            if (this.Session["Department"].ToString() == this.Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString())
            {
                BindGridview5("");
                this.Panel_Org.Visible = true;
                this.UpdatePanel_Org.Update();
                if (e.CommandName == "Ausaa")
                {
                    this.label_SelectPart.Text = "选择审核部门";
                    PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                    PMEquipmentinfo.PMEAC_State = "申请审核";
                    BindGridview6(PMEquipmentinfo);
                }
                else
                {
                    this.label_SelectPart.Text = "选择验收部门";
                    PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                    PMEquipmentinfo.PMEAC_State = "验收审核";
                    BindGridview6(PMEquipmentinfo);
                }
                this.Panel_Sign.Visible = true;
                this.UpdatePanel_Sign.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('抱歉，你没有此权限！')", true);
                return;
            }

        }
    }
    //审核表
    private void BindGridview6(PMEquipmentinfo pMEquipmentinfo)
    {
        this.Gridview6.DataSource = pl.SelectPMEquipmentApplyCountersign(pMEquipmentinfo);
        this.Gridview6.DataBind();
    }
    //选择部门
    private void BindGridview5(string condition)
    {
        this.Gridview5.DataSource = pc.SelectPMSCAC_Organization(condition);
        this.Gridview5.DataBind();
    }
    private void BindGridview4(PMEquipmentinfo pMEquipmentinfo)
    {
        this.Gridview4.DataSource = pl.SelectEquipment_Cost(pMEquipmentinfo);
        this.Gridview4.DataBind();
    }
    //申请 部门
    private void Bind_DDLMark(DropDownList DDLMark)
    {
        this.DDLMark.DataSource = prl.SelectPRMP_Organization("").Tables[0].DefaultView;
        DDLMark.DataTextField = "BDOS_Name";
        DDLMark.DataValueField = "BDOS_Name";
        DDLMark.DataBind();
        DDLMark.Items.Insert(0, new ListItem("请选择", ""));
    }

    //绑定DropDownList—DDLMark
    //protected void DDLMark_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Bind_DDLMark(this.DDLMark);
    //}
    //提交设备采购申请制定
    protected void Button_Rocky(object sender, EventArgs e)
    {
        if (this.TextBox3.Text != "")
        {
            PMEquipmentinfo.IMMBD_MaterialID = new Guid(this.label_Material.Text.ToString());
            PMEquipmentinfo.PMEA_Model = this.TextBox4.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.DDLMark.DataTextField != "请选择")
        {
            PMEquipmentinfo.PMEA_ApplyDepert = this.DDLMark.Text;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox5.Text != "")
        {
            PMEquipmentinfo.PMEA_Num = Convert.ToDecimal(this.TextBox5.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox7.Text != "")
        {
            PMEquipmentinfo.PMEA_NeedTime = Convert.ToDateTime(this.TextBox7.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox6.Text != "")
        {
            PMEquipmentinfo.PMEA_InstallLocation = this.TextBox6.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox8.Text != "")
        {
            PMEquipmentinfo.PMEA_BuyReason = this.TextBox8.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox9.Text != "")
        {
            PMEquipmentinfo.PMEA_TechRequire = this.TextBox9.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.label7.Text.ToString() == "修改设备采购申请")
        {

            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
            pl.UpdatePMEquipmentApply(PMEquipmentinfo);
            BindGridview1("");
            this.UpdatePanel_PMEquipmentApply.Update();
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.DDLMark.DataTextField = "请选择";
            this.TextBox7.Text = "";
            this.TextBox6.Text = "";
            this.TextBox8.Text = "";
            this.TextBox9.Text = "";
            this.Panel_New.Visible = false;
            this.UpdatePanel_New.Update();
        }

        if (this.label7.Text.ToString() == "新增设备采购申请")
        {
            PMEquipmentinfo.PMEAC_SignPartment = Session["Department"].ToString();
            PMEquipmentinfo.PMEAC_State = "申请审核";
            pl.InsertPMEquipmentApply(PMEquipmentinfo);
            BindGridview1("");
            this.UpdatePanel_PMEquipmentApply.Update();
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.DDLMark.DataTextField = "请选择";
            this.TextBox7.Text = "";
            this.TextBox6.Text = "";
            this.TextBox8.Text = "";
            this.TextBox9.Text = "";
            this.Panel_New.Visible = false;
            this.UpdatePanel_New.Update();

            //PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            //PMEquipmentinfo.PMEAC_SignPartment =Session["Department"].ToString();
            //PMEquipmentinfo.PMEAC_State = "申请审核";
            //pl.InsertPMEquipmentApplyCountersign(PMEquipmentinfo);//生成本部门的审核

            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('提交成功，请选择审核部门和验收审核部门！')", true);
         
            //string dep = this.Gridview1.Rows[this.Gridview1.SelectedIndex].Cells[3].Text.ToString();
            //this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + this.TextBox3.Text.ToString() + "的采购申请单，请审核。";
            //string message = label_RTX.Text;
            //string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购设备申请审核");
            //if (!string.IsNullOrEmpty(sErr))
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            //}  
        }
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
    }
    //绑定物料表
    private void BindGridview2(string condition)
    {
        this.Gridview2.DataSource = EL.Search_EquipModelTable_IMMaterialBasicData(condition);
        this.Gridview2.DataBind();
    }
    //选择物料
    protected void Button_Material(object sender, EventArgs e)
    {
        BindGridview2("");
        this.Panel16.Visible = true;
        this.UpdatePanel8.Update();
    }
    //取消提交设备采购申请单
    protected void Button_Mel(object sender, EventArgs e)
    {
        this.TextBox3.Text = "";
        this.TextBox4.Text = "";
        this.TextBox5.Text = "";
        this.DDLMark.DataTextField = "请选择";
        this.TextBox7.Text = "";
        this.TextBox6.Text = "";
        this.TextBox8.Text = "";
        this.TextBox9.Text = "";
        this.Panel_New.Visible = false;
        this.UpdatePanel_New.Update();
    }
    //提交物料
    protected void Button_ComSP(object sender, EventArgs e)
    {
        string Pname;
        bool temp = false;
        foreach (GridViewRow item in Gridview2.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                Pname = this.Gridview2.Rows[item.RowIndex].Cells[2].Text.ToString();
                temp = true;
                this.TextBox3.Text = Pname;
                this.TextBox4.Text = this.Gridview2.Rows[item.RowIndex].Cells[3].Text.ToString();
                this.label_Material.Text = this.Gridview2.DataKeys[item.RowIndex].Value.ToString();
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel8, this.GetType(), "aa", "alert('请选择物料')", true);
        }
        else
        {
            this.Panel16.Visible = false;
            this.UpdatePanel8.Update();
            this.UpdatePanel_New.Update();
        }
    }
    #region//互斥
    protected void Gridview_Material_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge(this)");
            }

        }
    }
    protected void Gridview_PMSupply_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge(this)");
            }

        }
    }
    #endregion
    //取消提交物料
    protected void Button_CancelSP(object sender, EventArgs e)
    {
        this.Panel16.Visible = false;
        this.UpdatePanel8.Update();
    }
    //申请部门部长审核通过
    protected void Button_Riol(object sender, EventArgs e)
    {
        if (this.TextBox14.Text != "")
        {
            if (this.label47.Text == "财务总监审核")
            {
                PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
                PMEquipmentinfo.PMEAC_SignPartment = "财务总监";
                PMEquipmentinfo.PMEAC_State = "申请审核";
                pl.InsertPMEquipmentApplyCountersign(PMEquipmentinfo);
                DataSet ds = pl.SelectPMEquipmentApplyCountersign(PMEquipmentinfo);
                DataTable dt = ds.Tables[0];
                if(dt.Rows.Count>0)
                {
                    PMEquipmentinfo.PMEAC_ID = new Guid(dt.Rows[0][0].ToString());
                    PMEquipmentinfo.PMEAC_SignResult = "通过";
                    PMEquipmentinfo.PMEAC_SignOpinion = this.TextBox14.Text.ToString();
                    PMEquipmentinfo.PMEAC_SignMan = Session["UserName"].ToString().Trim();
                    pl.UpdatePMEquipmentApplyCountersign(PMEquipmentinfo);
                    
                    PMEquipmentinfo.PMEA_ApplyState = "财务总监审核通过";
                    pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);
                    this.label_RTX1.Text = "ERP系统信息：" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "财务总监审核通过，请查看。";
                   string message = label_RTX1.Text;
                      string sErr=RTXhelper.Send(message, "设备采购制定");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }

                }
            }
            else
            {
                PMEquipmentinfo.PMEAC_ID = new Guid(this.label_PMEAC_ID.Text.ToString());
                PMEquipmentinfo.PMEAC_SignResult = "通过";
                PMEquipmentinfo.PMEAC_SignOpinion = this.TextBox14.Text.ToString();
                PMEquipmentinfo.PMEAC_SignMan = Session["UserName"].ToString().Trim();
                pl.UpdatePMEquipmentApplyCountersign(PMEquipmentinfo);
                if (this.label_Selected.Text == "设备采购申请验收审核")
                {
                    PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                    PMEquipmentinfo.PMEAC_State = "验收审核";
                }
                if (this.label_Selected.Text == "设备采购申请审核")
                {
                    PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                    PMEquipmentinfo.PMEAC_State = "申请审核";
                }
                int nt = 0;
                BindGridview6(PMEquipmentinfo);
                this.UpdatePanel_Sign.Update();
                
                for (int i = 0; i < this.Gridview6.Rows.Count; i++)
                {
                    if (this.Gridview6.Rows[i].Cells[2].Text == "通过")
                    {
                        nt = nt + 1;
                    }
                }
                if (Session["Department"].ToString() == this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString())
                {
                    PMEquipmentinfo.PMEA_ApplyState = "部门部长审核通过";
                    PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                    pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);
                     

                    string dep = "";
                    foreach (GridViewRow q in Gridview6.Rows)
                    {
                        dep += q.Cells[1].Text.ToString() + ",";
                    }
                    dep = dep.Substring(0, dep.Length - 1);
                    if(dep!=this.Gridview1.Rows[this.Gridview1.SelectedIndex].Cells[3].Text.ToString())
                    {
                        this.label_RTX1.Text = "ERP系统信息：" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "部门部长审核通过，请查看。";
                        string message = label_RTX1.Text;
                        string sErr=RTXhelper.SendbyDepAndRole(message,dep, "采购设备申请审核");
                            if (!string.IsNullOrEmpty(sErr))
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                            }
                    }
                }
                else
                {
                    if (nt == this.Gridview6.Rows.Count)
                    {
                        PMEquipmentinfo.PMEA_ApplyState = "相关部门审核通过";
                        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                        pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);
                        this.label_RTX1.Text = "ERP系统信息：" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "部门部长审核通过，请审核。";
                         string message = label_RTX1.Text;
                         string sErr=RTXhelper.Send(message, "技术副总设备采购审核");
                        if (!string.IsNullOrEmpty(sErr))
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                        }
                    }
                    if (0 < nt && nt < this.Gridview6.Rows.Count)
                    {
                        PMEquipmentinfo.PMEA_ApplyState = "相关部门审核中";
                        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                        pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);
                    }
                }
            }

            this.label18.Visible = false;
            this.label19.Visible = false;
            this.label20.Visible = false;
            this.label21.Visible = false;
            this.label_EquipmentMoney.Visible = false;
            this.label_EquipmentName.Visible = false;
            this.label_EquipmentNum.Visible = false;
            this.label_EquipmentPrice.Visible = false;

            this.label48.Visible = false;
            this.Label49.Visible = false;
            this.label51.Visible = false;
            this.label52.Visible = false;
            this.Button22.Visible = false;

            this.TextBox14.Text = "";
            this.Panel7.Visible = false;
            this.Panel8.Visible = false;
            this.UpdatePanel1.Update();
            BindGridview1("");
            this.UpdatePanel_PMEquipmentApply.Update();

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
    }
    //申请部门部长审核驳回
    protected void Button_Dule(object sender, EventArgs e)
    {
        if (this.TextBox14.Text != "")
        {
            if (this.label47.Text == "财务总监审核")
            {
                PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
                PMEquipmentinfo.PMEAC_SignPartment = "财务总监";
                PMEquipmentinfo.PMEAC_State = "财务总监审核";
                pl.InsertPMEquipmentApplyCountersign(PMEquipmentinfo);
                DataSet ds = pl.SelectPMEquipmentApplyCountersign(PMEquipmentinfo);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    PMEquipmentinfo.PMEAC_ID = new Guid(dt.Rows[0][0].ToString());
                    PMEquipmentinfo.PMEAC_SignResult = "驳回";
                    PMEquipmentinfo.PMEAC_SignOpinion = this.TextBox14.Text.ToString();
                    PMEquipmentinfo.PMEAC_SignMan = Session["UserName"].ToString().Trim();
                    pl.UpdatePMEquipmentApplyCountersign(PMEquipmentinfo);

                    PMEquipmentinfo.PMEA_ApplyState = "财务总监审核驳回";
                    pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);
                   
                    this.label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单，请查看。";
                    string dep = this.Gridview1.Rows[this.Gridview1.SelectedIndex].Cells[3].Text.ToString();
                    string message = label_RTX_P.Text;
                    string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购设备申请制定");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                   
                }

            }
            else
            {
                PMEquipmentinfo.PMEAC_ID = new Guid(this.label_PMEAC_ID.Text.ToString());
                PMEquipmentinfo.PMEAC_SignResult = "驳回";
                PMEquipmentinfo.PMEAC_SignOpinion = this.TextBox14.Text.ToString();
                PMEquipmentinfo.PMEAC_SignMan = Session["UserName"].ToString().Trim();
                PMEquipmentinfo.PMEA_ApplyState = "部门部长审核驳回";
                PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                pl.UpdatePMEquipmentApplyCountersign(PMEquipmentinfo);
                pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);

                BindGridview1("");
                this.UpdatePanel_PMEquipmentApply.Update();
                this.label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单，请查看。";
                string dep = this.Gridview1.Rows[this.Gridview1.SelectedIndex].Cells[3].Text.ToString();
                string message = label_RTX_P.Text;
                string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购设备申请制定");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }
            this.label18.Visible = false;
            this.label19.Visible = false;
            this.label20.Visible = false;
            this.label21.Visible = false;
            this.label_EquipmentMoney.Visible = false;
            this.label_EquipmentName.Visible = false;
            this.label_EquipmentNum.Visible = false;
            this.label_EquipmentPrice.Visible = false;

            this.label48.Visible = false;
            this.Label49.Visible = false;
            this.label51.Visible = false;
            this.label52.Visible = false;
            this.Button22.Visible = false;

            this.TextBox14.Text = "";
            this.Panel7.Visible = false;
            this.Panel8.Visible = false;
            this.UpdatePanel1.Update();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
    }
    //取消申请部门部长审核
    protected void Button_Duck(object sender, EventArgs e)
    {
        this.label18.Visible = false;
        this.label19.Visible = false;
        this.label20.Visible = false;
        this.label21.Visible = false;
        this.label_EquipmentMoney.Visible = false;
        this.label_EquipmentName.Visible = false;
        this.label_EquipmentNum.Visible = false;
        this.label_EquipmentPrice.Visible = false;

        this.label48.Visible = false;
        this.Label49.Visible = false;
        this.label51.Visible = false;
        this.label52.Visible = false;
        this.Button22.Visible = false;
        this.Panel8.Visible = false;
        this.TextBox14.Text = "";
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
        this.Panel6.Visible = false;
    }
   
  
    //技术副总审核通过
    protected void Button_Han(object sender, EventArgs e)
    {
        if (this.TextBox10.Text != "")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
            PMEquipmentinfo.PMEA_DMCheckOpinion = this.TextBox10.Text.ToString();
            PMEquipmentinfo.PMEA_DMCheckMan = Session["UserName"].ToString();
            PMEquipmentinfo.PMEA_DMCheckResult = "通过";
            PMEquipmentinfo.PMEA_ApplyState = "技术副总审核通过";
            pl.UpdatePMEA_DMCheck(PMEquipmentinfo);
            this.label_RTX3.Text = "ERP系统信息：" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "技术副总审核通过，请审核。";
            string message = label_RTX3.Text;
              string sErr=RTXhelper.Send(message, "总经理设备采购审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
             return;
        }
        this.TextBox10.Text = "";
        this.Panel1.Visible = false;
        this.Panel6.Visible = false;
        this.UpdatePanel3.Update();
       
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
    }
    //技术副总审核驳回
    protected void Button_Truse(object sender, EventArgs e)
    {
        if (this.TextBox10.Text != "")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
            PMEquipmentinfo.PMEA_DMCheckOpinion = this.TextBox10.Text.ToString();
            PMEquipmentinfo.PMEA_DMCheckMan = Session["UserName"].ToString();
            PMEquipmentinfo.PMEA_DMCheckResult = "驳回";
            PMEquipmentinfo.PMEA_ApplyState = "技术副总审核驳回";
            pl.UpdatePMEA_DMCheck(PMEquipmentinfo);
            this.label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单，请查看。";
            string dep = this.Gridview1.Rows[this.Gridview1.SelectedIndex].Cells[3].Text.ToString();
            string message = label_RTX_P.Text;
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购设备申请制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        this.TextBox10.Text = "";
        this.Panel1.Visible = false;
        this.Panel6.Visible = false;
        this.UpdatePanel3.Update();
        
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
    }
    //取消技术副总审核
    protected void Button_Truly(object sender, EventArgs e)
    {
        this.TextBox10.Text = "";
        this.label36.Visible = false;
        this.Label37.Visible = false;
        this.label38.Visible = false;
        this.label39.Visible = false;
        this.Button23.Visible = false;
        this.Panel1.Visible = false;
        this.Panel6.Visible = false;
        this.UpdatePanel3.Update();
        this.Panel_Sign.Visible = false;
        this.UpdatePanel_Sign.Update();
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
    }
    //总经理审核通过
    protected void Button_Meky(object sender, EventArgs e)
    {
        if (this.TextBox11.Text != "")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
            PMEquipmentinfo.PMEA_GMCheckOpinion = this.TextBox11.Text.ToString();
            PMEquipmentinfo.PMEA_GMCheckMan = Session["UserName"].ToString();
            PMEquipmentinfo.PMEA_GMCheckResult = "通过";
            PMEquipmentinfo.PMEA_ApplyState = "总经理审核通过";
            pl.UpdatePMEA_GMCheck(PMEquipmentinfo);
            this.label_RTX4.Text = "ERP系统信息：" + this.Gridview1.Rows[Gridview1.SelectedIndex ].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "总经理审核通过，请填写设备单价。";
             string message = label_RTX4.Text;
             string sErr=RTXhelper.Send(message, "设备采购制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        this.TextBox11.Text = "";
        this.Panel9.Visible = false;
        this.Panel10.Visible = false;
        this.UpdatePanel4.Update();
        this.Panel1.Visible = false;
        this.Panel6.Visible = false;
        this.UpdatePanel3.Update();
         
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
    }
    //总经理审核驳回
    protected void Button_Melory(object sender, EventArgs e)
    {
        if (this.TextBox11.Text != "")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
            PMEquipmentinfo.PMEA_GMCheckOpinion = this.TextBox11.Text.ToString();
            PMEquipmentinfo.PMEA_GMCheckMan = Session["UserName"].ToString();
            PMEquipmentinfo.PMEA_GMCheckResult = "驳回";
            PMEquipmentinfo.PMEA_ApplyState = "总经理审核驳回";
            pl.UpdatePMEA_GMCheck(PMEquipmentinfo);
            this.label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单，请查看。";
            string dep = this.Gridview1.Rows[this.Gridview1.SelectedIndex].Cells[3].Text.ToString();
            string message = label_RTX_P.Text;
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购设备申请制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        this.TextBox11.Text = "";
        this.Panel9.Visible = false;
        this.Panel10.Visible = false;
        this.UpdatePanel4.Update();
        this.Panel1.Visible = false;
        this.Panel6.Visible = false;
        this.UpdatePanel3.Update();
        
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
    }
    //总经理审核取消
    protected void Button_Meco(object sender, EventArgs e)
    {
        this.TextBox11.Text = "";
        this.Panel9.Visible = false;
        this.Panel10.Visible = false;
        this.UpdatePanel4.Update();
        this.Panel1.Visible = false;
        this.Panel6.Visible = false;
        this.UpdatePanel3.Update();
        this.Panel_Sign.Visible = false;
        this.UpdatePanel_Sign.Update();
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();
    }
    //绑定供应商列表
    private void BindGridview_PMSupply(string Condition)
    {
        try
        {
            this.Gridview_PMSupply.DataSource = pml.SelectPMSupplyInfo(Condition);
            this.Gridview_PMSupply.DataBind();
        }
        catch (Exception)
        {
            throw;

        }
    }
    //选择供应商
    protected void Button_Supply(object sender, EventArgs e)
    {
        BindGridview_PMSupply("");
        this.Panel_Supply.Visible = true;
        this.UpdatePanel_Supply.Update();
    }
    //提交采购订单
    protected void Button_Neo(object sender, EventArgs e)
    {
        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
        if (this.TextBox16.Text != "")
        {
            PMEquipmentinfo.PMSI_ID = new Guid(this.label_SupplyID.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox17.Text != "")
        {
            PMEquipmentinfo.PMPOD_Price = Convert.ToDecimal(this.TextBox17.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.DropDownList1.SelectedValue != "请选择")
        {
            PMEquipmentinfo.PMPO_PayWay = this.DropDownList1.SelectedValue.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox19.Text != "")
        {
            PMEquipmentinfo.PMPO_PaymentTime = Convert.ToInt16(this.TextBox19.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox20.Text != "")
        {
            PMEquipmentinfo.PMPO_PlanArrTime = Convert.ToDateTime(this.TextBox20.Text);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox21.Text != "")
        {
            PMEquipmentinfo.PMPO_PayRemindTime = Convert.ToDateTime(this.TextBox21.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox18.Text != "")
        {
            PMEquipmentinfo.PMPO_Num = Convert.ToDecimal(this.TextBox18.Text.ToString());
            PMEquipmentinfo.PMPOD_Num = Convert.ToDecimal(this.TextBox18.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox22.Text != "")
        {
            PMEquipmentinfo.PMPOD_Remark = this.TextBox22.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
             return;
        }
        PMEquipmentinfo.IMMBD_MaterialID = new Guid(this.label_Material.Text.ToString());
        PMEquipmentinfo.PMPO_MakeMan = Session["UserName"].ToString();
        PMEquipmentinfo.PMPO_TotalMoney = PMEquipmentinfo.PMPO_Num * PMEquipmentinfo.PMPOD_Price;
        PMEquipmentinfo.PMPOD_TotalMoney = PMEquipmentinfo.PMPO_Num * PMEquipmentinfo.PMPOD_Price;
        PMEquipmentinfo.PMPO_State = "已提交";
        PMEquipmentinfo.PMEA_ApplyState = "已提交采购订单";
        PMEquipmentinfo.IMUC_ID = new Guid(this.label_Unit.Text.ToString());
        pl.InsertPMPurchaseOrder_Equipment(PMEquipmentinfo);
        this.TextBox16.Text = "";
        this.TextBox17.Text = "";
        this.DropDownList1.SelectedValue = "请选择";
        this.TextBox19.Text = "";
        this.TextBox20.Text = "";
        this.TextBox21.Text = "";
        this.TextBox18.Text = "";
        this.TextBox22.Text = "";
        this.Panel11.Visible = false;
        this.UpdatePanel5.Update();
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
        this.label_RTX5.Text = "ERP系统信息：" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "进行采购，可进行调试。";
       string message = label_RTX5.Text;
          string sErr=RTXhelper.Send(message, "设备采购调试");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
       
    }

    //调试
    protected void Button_Lisa(object sender, EventArgs e)
    {
        if (this.TextBox24.Text != "")
        {
            PMEquipmentinfo.PMECA_OnDebugTime = this.TextBox24.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel6, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox28.Text != "")
        {
            PMEquipmentinfo.PMECA_MainTechnologyPara = this.TextBox28.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel6, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox29.Text != "")
        {
            PMEquipmentinfo.PMECA_AddOn = this.TextBox29.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel6, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox25.Text != "")
        {
            PMEquipmentinfo.PMECA_MECheck = this.TextBox25.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel6, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox26.Text != "")
        {
            PMEquipmentinfo.PMECA_NullDebugInfo = this.TextBox26.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel6, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox27.Text != "")
        {
            PMEquipmentinfo.PMECA_OnDebugInfo = this.TextBox27.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel6, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (this.TextBox30.Text != "")
        {
            PMEquipmentinfo.PMECA_DebugConclusion = this.TextBox30.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel6, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
        PMEquipmentinfo.PMEA_ApplyState = "已调试";
        if(this.label_Fiona.Text=="新建调试")
        {
        pl.InsertPMEquipmentCheckAccept(PMEquipmentinfo);
        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
        PMEquipmentinfo.PMEAC_State = "验收审核";
        BindGridview6(PMEquipmentinfo);
        string dep = "";
        foreach (GridViewRow q in Gridview6.Rows)
        {
            dep += q.Cells[1].Text.ToString() + ",";
        }
        dep = dep.Substring(0, dep.Length - 1);
        this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "调试了" + this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[2].Text.ToString() + "请审核。";
        string message = label_RTX.Text;
          string sErr=RTXhelper.SendbyDepAndRole(message, dep, "设备采购验收审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }  
        }
        if (this.label_Fiona.Text == "修改调试")
        {
            pl.UpdatePMEquipmentCheckAccept(PMEquipmentinfo);
        }
        this.TextBox24.Text = "";
        this.TextBox28.Text = "";
        this.TextBox29.Text = "";
        this.TextBox25.Text = "";
        this.TextBox26.Text = "";
        this.TextBox27.Text = "";
        this.TextBox30.Text = "";
        this.Panel12.Visible = false;
        this.UpdatePanel6.Update();
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();


    }
    //取消调试
    protected void Button_Bos(object sender, EventArgs e)
    {
        this.TextBox24.Text = "";
        this.TextBox28.Text = "";
        this.TextBox29.Text = "";
        this.TextBox25.Text = "";
        this.TextBox26.Text = "";
        this.TextBox27.Text = "";
    this.TextBox30.Text = "";
        this.Panel12.Visible = false;
        this.UpdatePanel6.Update();
    }
    //验收审核通过
    protected void Button_Pasen(object sender, EventArgs e)
    {
        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
        PMEquipmentinfo.PMEAC_ID = new Guid(this.label_PMEAC_ID.Text.ToString());
        if (this.label_Selected.Text == "设备采购申请验收审核")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "验收审核";
        }
        if (this.label_Selected.Text == "设备采购申请审核")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "申请审核";
        }
        BindGridview6(PMEquipmentinfo);
        this.UpdatePanel_Sign.Update();
         if (this.Markup.Checked && this.CheckBox1.Checked && this.CheckBox2.Checked && this.CheckBox3.Checked)
            {
            if (this.TextBox31.Text != "")
            {

                PMEquipmentinfo.PMEAC_SignOpinion = this.TextBox31.Text.ToString();
                PMEquipmentinfo.PMEAC_SignMan = Session["UserName"].ToString();
                PMEquipmentinfo.PMEAC_SignResult = "通过";
                pl.UpdatePMEquipmentApplyCountersign(PMEquipmentinfo);
                int nt = 0;
                for (int i = 0; i < this.Gridview6.Rows.Count; i++)
                {
                    if (this.Gridview6.Rows[i].Cells[2].Text == "通过")
                    {
                        nt = nt + 1;
                    }
                }
                if (nt == this.Gridview6.Rows.Count)
                {
                    PMEquipmentinfo.PMEA_ApplyState = "相关部门验收审核通过";
                    this.label_RTX7.Text = "ERP系统信息：" + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "已完成验收。";
                    string message = label_RTX7.Text;
                     string sErr=RTXhelper.Send(message, "设备台账管理");
                     string sErr1 = RTXhelper.Send(message, "设备采购制定");
                    if (!(string.IsNullOrEmpty(sErr)||string.IsNullOrEmpty(sErr1)))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                }
                else
                {
                    PMEquipmentinfo.PMEA_ApplyState = "相关部门验收审核中";
                }
                pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);
            }
            else 
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel7, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }

           

            this.Markup.Checked = false;
            this.CheckBox1.Checked = false;
            this.CheckBox2.Checked = false;
            this.CheckBox3.Checked = false;
            this.Panel_Sign.Visible = false;
            this.UpdatePanel_Sign.Update();
            this.Panel18.Visible = false;
            this.Panel14.Visible = false;
            this.UpdatePanel7.Update();
            this.Panel17.Visible = false;
            this.UpdatePanel9.Update();
            BindGridview1("");
            this.UpdatePanel_PMEquipmentApply.Update();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel7, this.GetType(), "alert", "alert('请核对并勾选信息！')", true);
            return;
        }
    }
  
    //验收审核驳回
    protected void Button_Bobo(object sender, EventArgs e)
    {
        if (this.label_Selected.Text == "设备采购申请验收审核")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "验收审核";
        }
        if (this.label_Selected.Text == "设备采购申请审核")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "申请审核";
        }
        BindGridview6(PMEquipmentinfo);
        this.UpdatePanel_Sign.Update();
        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
        PMEquipmentinfo.PMEAC_ID = new Guid(this.label_PMEAC_ID.Text.ToString());
        if (this.TextBox31.Text != "")
        {
           
                PMEquipmentinfo.PMEAC_SignOpinion = this.TextBox31.Text.ToString();
                PMEquipmentinfo.PMEAC_SignMan = Session["UserName"].ToString();
                PMEquipmentinfo.PMEAC_SignResult = "通过";
                pl.UpdatePMEquipmentApplyCountersign(PMEquipmentinfo);
                PMEquipmentinfo.PMEA_ApplyState = "相关部门验收审核驳回";
                pl.UpdatePMEquipmentApply_State(PMEquipmentinfo);
                this.label_RTX_P.Text = "ERP系统信息："+Session["UserName"].ToString()+"于"+DateTime .Now +"验收审核驳回了"+ this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单，请查看。";
                string dep = this.Gridview1.Rows[this.Gridview1.SelectedIndex].Cells[3].Text.ToString();
                string message = label_RTX_P.Text;
                string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购设备申请制定");
                string sErr1 = RTXhelper.Send(message, "设备采购制定");
                if (!(string.IsNullOrEmpty(sErr) || string.IsNullOrEmpty(sErr1)))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel7, this.GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        this.Panel_Sign.Visible = false;
        this.UpdatePanel_Sign.Update();
            this.Markup.Checked = false;
            this.CheckBox1.Checked = false;
            this.CheckBox2.Checked = false;
            this.CheckBox3.Checked = false;
            this.Panel18.Visible = false;
            this.Panel14.Visible = false;
            this.UpdatePanel7.Update();
            this.Panel17.Visible = false;
            this.UpdatePanel9.Update();
            BindGridview1("");
            this.UpdatePanel_PMEquipmentApply.Update();
       
    }
    //验收审核取消
    protected void Button_Cali(object sender, EventArgs e)
    {

        this.Button19.Visible = true;
        this.Button20.Visible = true;
        this.Button21.Visible = true;
        this.Button34.Visible = true;
        this.TextBox31.Text = ""; 
        this.Markup.Checked = false;
        this.CheckBox1.Checked = false;
        this.CheckBox2.Checked = false;
        this.CheckBox3.Checked = false;
        this.Panel18.Visible = false;
        this.Button34.Visible = false;
        this.Panel14.Visible = false;
        this.UpdatePanel7.Update();
    }
    #region//换页
    protected void Gridview5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview5.BottomPagerRow;


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
        string condition = GetCondition_Org();
        BindGridview5(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview5.PageCount ? this.Gridview5.PageCount - 1 : newPageIndex;
        this.Gridview5.PageIndex = newPageIndex;
        this.Gridview5.DataBind();
    }
    protected void Gridview_6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview6.BottomPagerRow;


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
        if (this.label_Selected.Text == "设备采购申请验收审核")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "验收审核";
        }
        if (this.label_Selected.Text == "设备采购申请审核")
        {
            PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
            PMEquipmentinfo.PMEAC_State = "申请审核";
        }
        BindGridview6(PMEquipmentinfo);
        this.Gridview6.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview6.PageCount ? this.Gridview6.PageCount - 1 : newPageIndex;
        this.Gridview6.PageIndex = newPageIndex;
        this.Gridview6.DataBind();
    }
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview1.BottomPagerRow;


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
        string Condition = GetCondition();
        BindGridview1(Condition);
        this.Gridview1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview1.PageCount ? this.Gridview1.PageCount - 1 : newPageIndex;
        this.Gridview1.PageIndex = newPageIndex;
        this.Gridview1.DataBind();
    }

    protected void Gridview_Material_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview2.BottomPagerRow;


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
        string conditionn = GetConditionn();
        BindGridview2(conditionn);
        this.Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview2.PageCount ? this.Gridview2.PageCount - 1 : newPageIndex;
        this.Gridview2.PageIndex = newPageIndex;
        this.Gridview2.DataBind();
    }

    protected void Gridview_PMSupply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview_PMSupply.BottomPagerRow;


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
        BindGridview_PMSupply("");
        this.Gridview_PMSupply.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview_PMSupply.PageCount ? this.Gridview_PMSupply.PageCount - 1 : newPageIndex;
        this.Gridview_PMSupply.PageIndex = newPageIndex;
        this.Gridview_PMSupply.DataBind();

    }

    protected void Gridview3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview3.BottomPagerRow;


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
        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text.ToString());
        BindGridview3(PMEquipmentinfo);
        this.Gridview3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview3.PageCount ? this.Gridview3.PageCount - 1 : newPageIndex;
        this.Gridview3.PageIndex = newPageIndex;
        this.Gridview3.DataBind();
    }

    protected void Gridview4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview4.BottomPagerRow;


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
        PMEquipmentinfo.IMMBD_MaterialID = new Guid(this.label_Material.Text.ToString());
        BindGridview4(PMEquipmentinfo);
        this.Gridview4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview4.PageCount ? this.Gridview4.PageCount - 1 : newPageIndex;
        this.Gridview4.PageIndex = newPageIndex;
        this.Gridview4.DataBind();
    }
    #endregion
    #region//悬浮
    protected void Gridview1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview2.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview2.Rows[i].Cells.Count; j++)
            {
                Gridview2.Rows[i].Cells[j].ToolTip = Gridview2.Rows[i].Cells[j].Text;
                if (Gridview2.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview2.Rows[i].Cells[j].Text = Gridview2.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Gridview_PMSupply_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_PMSupply.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_PMSupply.Rows[i].Cells.Count; j++)
            {
                Gridview_PMSupply.Rows[i].Cells[j].ToolTip = Gridview_PMSupply.Rows[i].Cells[j].Text;
                if (Gridview_PMSupply.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_PMSupply.Rows[i].Cells[j].Text = Gridview_PMSupply.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Gridview3_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview3.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview3.Rows[i].Cells.Count; j++)
            {
                Gridview3.Rows[i].Cells[j].ToolTip = Gridview3.Rows[i].Cells[j].Text;
                if (Gridview3.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview3.Rows[i].Cells[j].Text = Gridview3.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    #endregion
    //绑定供应商
    protected void Button_ComSPP(object sender, EventArgs e)
    {
        string Pname;
        bool temp = false;
        foreach (GridViewRow item in Gridview_PMSupply.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            { 
                Pname = this.Gridview_PMSupply.Rows[item.RowIndex].Cells[3].Text.ToString();
                temp = true;
                this.TextBox16.Text = Pname;
                this.label_SupplyID.Text = this.Gridview_PMSupply.DataKeys[item.RowIndex].Value.ToString();
                this.TextBox19.Text = this.Gridview_PMSupply.Rows[item.RowIndex].Cells[4].Text.ToString();
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_Supply, this.GetType(), "aa", "alert('请选择物料')", true);
        }
        else
        {
            this.Panel_Supply.Visible = false;
            this.UpdatePanel_Supply.Update();
            this.UpdatePanel5.Update();
        }
    }
    //取消选择供应商
    protected void Button_CancelSPP(object sender, EventArgs e)
    {
        this.Panel_Supply.Visible = false;
        this.UpdatePanel_Supply.Update();
    }
    //关闭
    protected void Button_CS(object sender, EventArgs e)
    {

        this.Panel18.Visible = false;

        this.Panel14.Visible = false;
        this.UpdatePanel7.Update();
        this.Panel17.Visible = false;
        this.UpdatePanel9.Update();
    }
    //关闭历史费用查看
    protected void ButtonCClose(object sender, EventArgs e)
    {
        this.Panel_EquipmentCost.Visible = false;
        this.UpdatePanel_EquipmentCost.Update();
    }

    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMEA_ApplyState"].ToString().Trim() == "提交申请制定" || drv["PMEA_ApplyState"].ToString().Trim().Contains("审核驳回"))
            {
                e.Row.Cells[12].Enabled = true;//编辑
                e.Row.Cells[13].Enabled = true;//申请审核
                e.Row.Cells[21].Enabled = true;//选择审核部门
                e.Row.Cells[22].Enabled = true;//选择验收审核部门
                
            }
            else
            {
                e.Row.Cells[12].Enabled = false;//编辑
                e.Row.Cells[13].Enabled =false;//申请审核
                e.Row.Cells[21].Enabled = false;//选择审核部门
                e.Row.Cells[22].Enabled = false;//选择验收审核部门
            }
            if (drv["PMEA_ApplyState"].ToString().Trim() == "总经理审核通过" || drv["PMEA_ApplyState"].ToString().Trim() == "财务总监审核驳回")
            {
                e.Row.Cells[23].Enabled = true;//单价
            }
            else
            {
                e.Row.Cells[23].Enabled = false;//单价
            }
            if (drv["PMEA_ApplyState"].ToString().Trim() == "提交申请制定" || drv["PMEA_ApplyState"].ToString().Trim() == "部门部长审核通过" || drv["PMEA_ApplyState"].ToString().Trim() == "相关部门审核中" || drv["PMEA_ApplyState"].ToString().Trim() == "相关部门审核通过" || drv["PMEA_ApplyState"].ToString().Trim() == "技术副总审核通过" || drv["PMEA_ApplyState"].ToString().Trim() == "总经理审核通过")
            {
                e.Row.Cells[13].Enabled = true;//申请审核
            }
            //if (drv["PMEA_ApplyState"].ToString().Trim() == "已提交采购订单")
            //{
            //    e.Row.Cells[13].Enabled = false;
            //}
            if (drv["PMEA_ApplyState"].ToString().Trim() == "财务总监审核通过" )//|| drv["PMEA_ApplyState"].ToString().Trim() == "已提交采购订单"
            {
                e.Row.Cells[14].Enabled = true;//采购
            }
            else
            {
                e.Row.Cells[14].Enabled = false;
            }
            if (drv["PMEA_ApplyState"].ToString().Trim() == "已提交采购订单" || drv["PMEA_ApplyState"].ToString().Trim() == "已调试")
            {
                e.Row.Cells[15].Enabled = true;//调试
            }
            else
            {
                e.Row.Cells[15].Enabled = false;
            }
            if (drv["PMEA_ApplyState"].ToString().Trim() == "已调试" || drv["PMEA_ApplyState"].ToString().Trim() == "相关部门验收审核中" )
            {
                e.Row.Cells[16].Enabled = true;//验收审核 
            }
            else
            {
                e.Row.Cells[16].Enabled = false;
              
            }
            if (drv["PMEA_ApplyState"].ToString().Trim() == "提交申请制定")
            {
                e.Row.Cells[21].Enabled = true;
                e.Row.Cells[22].Enabled = true;
            }
            else
            {
                e.Row.Cells[21].Enabled = false;
                e.Row.Cells[22].Enabled = false;
            }
        }
    }
    //关闭查看申请审核意见
    protected void ButtonM(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
        Button43.Visible = false;
        this.Panel7.Visible = false;
        this.Panel9.Visible = false;
        this.Panel10.Visible = false;
        this.UpdatePanel4.Update();
        this.UpdatePanel3.Update();
        this.Panel_Sign.Visible = false;
        this.UpdatePanel_Sign.Update();
        this.UpdatePanel1.Update();
    }
    //关闭查看验收审核意见
    protected void ButtonL(object sender, EventArgs e)
    {
        this.Button19.Visible = true;
        this.Button20.Visible = true;
        this.Button21.Visible = true;
        this.Button34.Visible = true;
        this.TextBox31.Text = ""; 
        this.Markup.Checked = false;
        this.CheckBox1.Checked = false;
        this.CheckBox2.Checked = false;
        this.CheckBox3.Checked = false;
        this.Panel18.Visible = false;
        this.Panel14.Visible = false;
        this.Button34.Visible = false;
        this.UpdatePanel7.Update();
       
    }
    //检索供应商
    protected void Button1_KiMi(object sender, EventArgs e)
    {
        string condition = GetCondition_Supply();
        BindGridview_PMSupply(condition);
        this.UpdatePanel_Supply.Update();
    }
    protected string GetCondition_Supply()
    {
        string condition;
        string item = "";
        if (this.TextBox36.Text != "")
        {
            item += " and PMSI_SupplyNum='" + this.TextBox36.Text + "'";
        }
        if (this.TextBox37.Text != "")
        {
            item += " and PMSI_SupplyName like'%" + this.TextBox37.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索供应商
    protected void Button_CoMi(object sender, EventArgs e)
    {
        this.TextBox36.Text = "";
        this.TextBox37.Text = "";
        BindGridview_PMSupply("");
        this.UpdatePanel_Supply.Update();
    }
    protected void Button3_Raco(object sender, EventArgs e)
    {
            //取消生成采购订单
 
        TextBox16.Text = "";
        this.TextBox17.Text = "";
        this.DropDownList1.SelectedValue = "请选择";
        this.TextBox19.Text = "";
        this.TextBox20.Text = "";
        this.TextBox21.Text = "";
        this.TextBox18.Text = "";
        this.TextBox22.Text = "";
        this.Panel11.Visible = false;
        this.UpdatePanel5.Update();
    }

    protected void Button1_KiM1(object sender, EventArgs e)
    {
        string conditionn = GetConditionn();
        BindGridview2(conditionn);
        this.UpdatePanel8.Update();
    }
    protected string GetConditionn()
    {
        string item = "";
        string condition;
        if (this.TextBox38.Text != "")
        {
            item += "and IMMBD_MaterialName  like '%" + this.TextBox38.Text.ToString() + "%'";
        }
        if (this.TextBox39.Text != "")
        {
            item += "and IMMBD_SpecificationModel like '%" + this.TextBox39.Text.ToString() + "%'";
        }
        condition = item;
        return condition;
    }
    protected void Button_CoM1(object sender, EventArgs e)
    {
        this.TextBox38.Text = "";
        this.TextBox39.Text = "";
        BindGridview2("");
    }
    protected void Button1_Kil(object sender, EventArgs e)
    {
        string condition = GetCondition_Org();
        BindGridview5(condition);
        this.UpdatePanel_Org.Update();
    }
    protected string GetCondition_Org()
    {
        string item = "";
        string condition;
        if (this.TextBox22.Text != "")
        {
            item += "and BDOS_Name like'%" + this.TextBox22.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索部门
    protected void Button_CoMl(object sender, EventArgs e)
    {
        this.TextBox40.Text = "";
        BindGridview5("");
        this.UpdatePanel_Org.Update();
    }
    //提交勾选的部门
    protected void Button_ComSPPP(object sender, EventArgs e)
    {
        bool temp = false;
        this.Gridview6.Columns[8].Visible = true;//删除
        foreach (GridViewRow item in Gridview5.Rows)
        {
            CheckBox rb = item.FindControl("CheckMarkup") as CheckBox;
            if (rb.Checked)
            {

                if (this.label_SelectPart.Text == "选择审核部门")
                {
                    string condition = "and PMEA_ID='" + this.label_PMEA_ID.Text + "'" + "and PMEAC_State='" + "申请审核" + "'" + "and PMEAC_SignPartment='" + this.Gridview5.Rows[item.RowIndex].Cells[2].Text.ToString()+"'";
                    DataSet ds = pl.SelectPMEquipmentApplyCountersign_Same(condition);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_Org, this.GetType(), "aa", "alert('审核部门不能重复！')", true);
                        return;
                    }
                    else
                    {
                        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                        PMEquipmentinfo.PMEAC_SignPartment = this.Gridview5.Rows[item.RowIndex].Cells[2].Text.ToString();
                        PMEquipmentinfo.PMEAC_State = "申请审核";
                        pl.InsertPMEquipmentApplyCountersign(PMEquipmentinfo);
                        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                        PMEquipmentinfo.PMEAC_State = "申请审核";
                        BindGridview6(PMEquipmentinfo);
                        this.Panel_Sign.Visible = true;
                        this.UpdatePanel_Sign.Update();
                        //string dep = "";
                        //foreach (GridViewRow q in Gridview6.Rows)
                        //{
                        //    dep += q.Cells[1].Text.ToString() + ",";
                        //}
                        //dep = dep.Substring(0, dep.Length - 1);
                        //this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[2].Text.ToString() + "的采购申请单，请审核。";
                        //string message = label_RTX.Text;
                        //  string sErr= RTXhelper.SendbyDepAndRole(message, dep, "设备采购申请审核");
                        //if (!string.IsNullOrEmpty(sErr))
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                        //}
                    }
                }
                else if (this.label_SelectPart.Text == "选择验收部门")
                {
                    string condition = "and PMEA_ID='" + this.label_PMEA_ID.Text + "'" + "and PMEAC_State='" + "验收审核" + "'" + "and PMEAC_SignPartment='" + this.Gridview5.Rows[item.RowIndex].Cells[2].Text.ToString() + "'";
                    DataSet ds = pl.SelectPMEquipmentApplyCountersign_Same(condition);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_Org, this.GetType(), "aa", "alert('审核部门不能重复！')", true);
                        return;
                    }
                    else
                    {
                        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                        PMEquipmentinfo.PMEAC_SignPartment = this.Gridview5.Rows[item.RowIndex].Cells[2].Text.ToString();
                        PMEquipmentinfo.PMEAC_State = "验收审核";
                        pl.InsertPMEquipmentApplyCountersign(PMEquipmentinfo);
                        temp = true;
                        PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                        PMEquipmentinfo.PMEAC_State = "验收审核";
                        BindGridview6(PMEquipmentinfo);
                        this.Panel_Sign.Visible = true;
                        this.UpdatePanel_Sign.Update();
                      //  string dep = "";
                      //  foreach (GridViewRow q in Gridview6.Rows)
                      //  {
                      //      dep += q.Cells[1].Text.ToString() + ",";
                      //  }
                      //  dep = dep.Substring(0, dep.Length - 1);
                      //  this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[2].Text.ToString() + "的验收报告，请审核。";
                      //string message = label_RTX.Text;
                      //    string sErr=RTXhelper.SendbyDepAndRole(message, dep, "设备采购申请验收审核");
                      //  if (!string.IsNullOrEmpty(sErr))
                      //  {
                      //      ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                      //  }
                    }
                }
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Org, this.GetType(), "aa", "alert('请选择部门')", true);
            return;
        }
        else
        {
            //this.TextBox22.Text = this.Label_Org.Text.ToString();
            //this.UpdatePanel_Spl_New.Update();
            this.Panel_Org.Visible = false;
            this.UpdatePanel_Org.Update();
        }
    }
    //关闭部门查询
    protected void Button_CancelSPPP(object sender, EventArgs e)
    {

        this.Panel_Org.Visible = false;
        this.UpdatePanel_Org.Update();
    }
    //审核表
    protected void Gridview6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Myloo")//查看审核
        {
         GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview6.SelectedIndex = row.RowIndex;
            this.label_PMEAC_ID.Text = e.CommandArgument.ToString();
            this.Label49.Visible = true;
            this.Button4.Visible = false;
            this.Button7.Visible = false;
            this.Button8.Visible = false;
            this.Panel8.Visible = true;
            this.Button22.Visible = true;
           
            
            if(this.label_Selected.Text == "设备采购申请审核")
            {
                this.label47.Text = this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[1].Text.ToString() + "审核";
                PMEquipmentinfo.PMEAC_ID = new Guid(this.label_PMEAC_ID.Text.ToString());
                PMEquipmentinfo.PMEAC_State = "申请审核";
                DataSet ds = pl.SelectPMEquipmentApplyCountersign_One(PMEquipmentinfo);
                DataTable dt = ds.Tables[0];
                if(dt.Rows.Count>0)
                {
                    this.label_Department.Text = dt.Rows[0][2].ToString();
                    this.label48.Text = dt.Rows[0][3].ToString();
                    this.label51.Text = dt.Rows[0][5].ToString();
                    this.label52.Text = dt.Rows[0][6].ToString();
                    this.TextBox14.Text = dt.Rows[0][4].ToString(); 
                }
                this.label48.Visible = true;
                this.label51.Visible = true;
                this.label52.Visible = true;
                this.TextBox14.Enabled = false;
                this.Panel7.Visible = true;
                this.UpdatePanel1.Update();
            }
            if (this.label_Selected.Text == "设备采购申请验收审核")
            {
                this.label47.Text = this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[1].Text.ToString()+"审核";
                PMEquipmentinfo.PMEAC_ID = new Guid(this.label_PMEAC_ID.Text.ToString());
                PMEquipmentinfo.PMEAC_State = "验收审核";
                DataSet ds = pl.SelectPMEquipmentApplyCountersign_One(PMEquipmentinfo);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.label_Department.Text = dt.Rows[0][2].ToString();
                    this.label81.Text = dt.Rows[0][2].ToString() + "验收审核";
                    this.label86.Text = dt.Rows[0][3].ToString();
                    this.label99.Text = dt.Rows[0][5].ToString();
                    this.label100.Text = dt.Rows[0][6].ToString();
                    this.TextBox31.Text = dt.Rows[0][4].ToString();
                }
                this.Button34.Visible = true;
                this.label86.Visible = true;
                this.Label98.Visible = true;
                this.label99.Visible = true;
                this.label100.Visible = true;
                this.TextBox31.Enabled = false;
                this.Markup.Checked = true;
                this.CheckBox1.Checked = true;
                this.CheckBox2.Checked = true;
                this.CheckBox3.Checked = true;
                this.Button19.Visible = false;
                this.Button20.Visible = false;
                this.Button21.Visible = false;
                this.Panel14.Visible = true;
                this.Panel18.Visible = true;
                this.UpdatePanel7.Update();
                 
            }
           
        }
        if (e.CommandName == "Mylloo")//审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview6.SelectedIndex = row.RowIndex;
            this.label_PMEAC_ID.Text = e.CommandArgument.ToString();
            
            
            if(this.label_Selected.Text == "设备采购申请审核")
            {
            if (Session["Department"].ToString() == this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[1].Text.ToString())
        {
            this.label47.Text = Session["Department"].ToString() + "审核";
            this.Panel7.Visible = true;
            this.Button4.Visible = true;
            this.Button7.Visible = true;
            this.Button8.Visible = true;
            this.Panel8.Visible = true;
            this.TextBox14.Enabled = true;
            this.label48.Visible = false;
            this.label51.Visible = false;
            this.label52.Visible = false;
            
            this.UpdatePanel1.Update();
        }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('你没有此权限！')", true);
                return;
            }
            }
            if (this.label_Selected.Text == "设备采购申请验收审核")
            {
                if (Session["Department"].ToString() == this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[1].Text.ToString())
                {
                    this.label81.Text = Session["Department"].ToString() + "审核";
                    this.label86.Visible = false;
                    this.Label98.Visible = false;
                    this.label99.Visible = false;
                    this.label100.Visible = false;
                    this.TextBox31.Enabled = true;

                    this.Panel18.Visible = true;
                    this.Panel14.Visible = true;
                    this.UpdatePanel7.Update();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('你没有此权限！')", true);
                    return;
                }
            
            }
        }
        if (e.CommandName == "Miko")//删除会签部门
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview6.SelectedIndex = row.RowIndex;
            this.label_PMEAC_ID.Text = e.CommandArgument.ToString();
            PMEquipmentinfo.PMEAC_ID = new Guid(this.label_PMEAC_ID.Text.ToString());
            pl.DeletePMEquipmentApplyCountersign(PMEquipmentinfo);
            if (this.label_Selected.Text == "设备采购申请审核")
            {
                PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                PMEquipmentinfo.PMEAC_State = "申请审核";
            }
            if (this.label_Selected.Text == "设备采购申请验收审核")
            {
                PMEquipmentinfo.PMEA_ID = new Guid(this.label_PMEA_ID.Text);
                PMEquipmentinfo.PMEAC_State = "验收审核";
            }
            BindGridview6(PMEquipmentinfo);
            this.Panel_Sign.Visible = true;
            this.UpdatePanel_Sign.Update();
        }
    }
    protected void ButtonLo(object sender, EventArgs e)
    {


        this.label18.Visible = false;
        this.label19.Visible = false;
        this.label20.Visible = false;
        this.label21.Visible = false;
        this.label_EquipmentMoney.Visible = false;
        this.label_EquipmentName.Visible = false;
        this.label_EquipmentNum.Visible = false;
        this.label_EquipmentPrice.Visible = false;

        this.label48.Visible  = false;
        this.Label49.Visible = false;
        this.label51.Visible = false;
        this.label52.Visible = false;
        this.Button22.Visible = false;
       
        this.TextBox14.Text = "";
        this.Panel7.Visible =false;
        this.UpdatePanel1.Update();
        this.Panel6.Visible = false;
    }

//关闭审核表
    protected void Button_Ccl(object sender, EventArgs e)
    {
        this.Panel_Org.Visible = false;
        this.UpdatePanel_Org.Update();
        this.Panel_Sign.Visible = false;
        this.UpdatePanel_Sign.Update();
        this.Panel17.Visible = false;
        this.UpdatePanel9.Update();
    }
    protected void Buttonli(object sender, EventArgs e)
    {
        this.TextBox10.Text = "";
        this.label36.Visible = false;
        this.Label37.Visible = false;
        this.label38.Visible = false;
        this.label39.Visible = false;
        this.Button23.Visible = false;
        this.Panel1.Visible = false;
        this.Panel6.Visible = false;
        this.UpdatePanel3.Update();
        this.Panel_Sign.Visible = false;
        this.UpdatePanel_Sign.Update();
        this.Panel7.Visible = false;
        this.UpdatePanel1.Update();

    }
    #region//单价
    //更新单价
    protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        PMEquipmentinfo.PMEA_ID = new Guid(Gridview1.DataKeys[e.RowIndex]["PMEA_ID"].ToString());

        PMEquipmentinfo.PMEA_EquipmentPrice = Convert.ToDecimal(((TextBox)(Gridview1.Rows[e.RowIndex].Cells[10].Controls[0])).Text.Trim().ToString());//设置成TextBook
        Gridview1.EditIndex = -1;
        //BindGridview1("");
        pl.UpdatePMEquipmentPrice(PMEquipmentinfo);
        BindGridview1("");
        this.UpdatePanel_PMEquipmentApply.Update();
        this.Panel_PMEquipmentApply.Visible = true;
        this.label_RTX1.Text = "ERP系统信息：" + this.Gridview1.Rows[e.RowIndex].Cells[2].Text.ToString() + "的采购申请单于" + DateTime.Now + "填写设备单价，请查看。";
        string message = label_RTX1.Text;
           string sErr=RTXhelper.Send(message, "设备采购财务总监审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //编辑单价
    protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridview1.EditIndex = e.NewEditIndex;

        BindGridview1("");
    }
    //取消编辑单价
    protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridview1.EditIndex = -1;
        BindGridview1("");
    }
    #endregion


    protected void Gridview6_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMEAC_SignResult"].ToString().Trim() != "")
            {
                e.Row.Cells[8].Enabled = false;
            }
        }
    }
}