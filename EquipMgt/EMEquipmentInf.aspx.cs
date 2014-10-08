using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EquipMgt_EMEquipmentInf : Page
{
    EquipmentInfL equipmentInfL = new EquipmentInfL();
    //EMEquipmentInfInfo eMEquipmentInfInfo = new EMEquipmentInfInfo();
    EquipTypeL equipTypeL = new EquipTypeL();
    PMSupplyInfo_PMSupplyContactL pl = new PMSupplyInfo_PMSupplyContactL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择", "请选择"));
            BindDropDownList1();
            DropDownList3.Items.Insert(0, new ListItem("请选择", "请选择"));
            BindDropDownList3();
            Panel_Search.Visible = true;
            UpdatePanel_Search.Update();
            Panel_InfoItem.Visible = true;
            UpdatePanel_InfoItem.Update();
            string condition = "";
            BindGrid_EquipInfo(condition);

            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "EMInf" && Session["UserRole"].ToString().Contains("设备台账管理"))
                {
                    Title = "设备台账管理";
                }
                if (Lab_Status.Text == "EMLookInf" && Session["UserRole"].ToString().Contains("设备台账查看"))
                {
                    Title = "设备台账查看";
                    Btn_New.Visible = false;
                    Grid_EquipInfo.Columns[14].Visible = false;//编辑
                    Grid_EquipInfo.Columns[15].Visible = false;//删除
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");

            }
        }
    }

    #region 绑定
    //绑定设备台账gridview
    private void BindGrid_EquipInfo(string condition)
    {
        Grid_EquipInfo.DataSource = equipmentInfL.Search_EquipmentInfInfo(condition);
        Grid_EquipInfo.DataBind();
    }
    //DropDownList1下拉表绑定
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        DropDownList1.DataTextField = "ETT_Type";
        DropDownList1.DataValueField = "ETT_Type";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定设备名称和型号gridview
    private void BindGrid_EquipNameModel(string EN_EquipName, string EMT_Type)
    {
        Grid_EquipNameModel.DataSource = equipmentInfL.Search_InsertEquipmentInfInfo(EN_EquipName, EMT_Type);
        Grid_EquipNameModel.DataBind();
    }
    //DropDownList3下拉表绑定
    private void BindDropDownList3()
    {
        DropDownList3.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        DropDownList3.DataTextField = "ETT_Type";
        DropDownList3.DataValueField = "ETT_ID";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("请选择", ""));
    }
    //DropDownList5下拉表绑定
    private void BindDropDownList5()
    {
        DropDownList5.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        DropDownList5.DataTextField = "ETT_Type";
        DropDownList5.DataValueField = "ETT_ID";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
    }
    //Gridview_PMSupply供应商选择
    private void BindGridview_PMSupply(string Condition)
    {
        Gridview_PMSupply.DataSource = pl.SelectPMSupplyInfo(Condition);
        Gridview_PMSupply.DataBind();
    }
    #endregion 绑定

    #region 检索设备台账
    //检索设备台账
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_EquipInfo(condition);
        Panel_InfoItem.Visible = true;
        UpdatePanel_InfoItem.Update();
        UpdatePanel_Search.Update();
        Panel_EditInfo.Visible = false;
        UpdatePanel_EditInfo.Update();
        Panel_searchname.Visible = false;
        Panel_NewInfo.Visible = false;
        UpdatePanel_NewInfo.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (DropDownList1.Text.ToString() != "")
        {
            temp += " and ETT_Type='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (Textname.Text.ToString() != "")
        {
            temp += " and EN_EquipName like '%" + Textname.Text.ToString() + "%'";
        }
        if (Textmodel.Text.ToString() != "")
        {
            temp += " and  EMT_Type like '%" + Textmodel.Text.ToString() + "%'";
        }
        if (Textno.Text.ToString() != "")
        {
            temp += " and  EI_No like '%" + Textno.Text.ToString() + "%'";
        }
        if (TextLocation.Text.ToString() != "")
        {
            temp += " and  EI_Location like '%" + TextLocation.Text.ToString() + "%'";
        }
        if (TextProvidor.Text.ToString() != "")
        {
            temp += " and  EI_Providor like '%" + TextProvidor.Text.ToString() + "%'";
        }
        if (DropDownList2.Text.ToString() != "")
        {
            temp += " and EI_IsToCare='" + DropDownList2.SelectedValue.ToString() + "'";
        }
        else
        {
            DropDownList2.SelectedIndex = 0;
        }
        if (TextAcceptDate.Text.ToString() != "")
        {
            //temp += " and  EI_AcceptDate like '%" + this.TextAcceptDate.Text.ToString() + "%'";
            temp += "and DateDiff(dd,getdate(),EI_AcceptDate)=DateDiff(dd,getdate(),'" + TextAcceptDate.Text.ToString() + "')";
        }
        if (DropDownList7.Text.ToString() != "")
        {
            temp += " and  EI_State='" + DropDownList7.SelectedValue.ToString() + "'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList1();
        Textname.Text = "";
        Textmodel.Text = "";
        Textno.Text = "";
        TextLocation.Text = "";
        TextProvidor.Text = "";
        DropDownList2.SelectedIndex = 0;
        TextAcceptDate.Text = "";
        DropDownList7.SelectedIndex = 0;
        UpdatePanel_Search.Update();
        BindGrid_EquipInfo("");
        UpdatePanel_InfoItem.Update();
        Panel_EditInfo.Visible = false;
        UpdatePanel_EditInfo.Update();
        Panel_searchname.Visible = false;
        Panel_NewInfo.Visible = false;
        UpdatePanel_NewInfo.Update();
    }
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Clear();
        Panel_searchname.Visible = true;
        UpdatePanel_searchname.Visible = true;
        string EN_EquipName = "";
        string EMT_Type = "";
        BindGrid_EquipNameModel(EN_EquipName, EMT_Type);
        Panel_EditInfo.Visible = false;
        UpdatePanel_EditInfo.Update();
        //this.UpdatePanel_searchname.Update();
    }
    //私有清空的方法
    private void Clear()
    {
        Textnameadd.Text = "";
        Textmodeladd.Text = "";
    }
    #endregion 检索设备台账

    #region 设备台账gridview
    protected void Grid_EquipInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_searchname.Visible = false;
        Panel_NewInfo.Visible = false;
        UpdatePanel_NewInfo.Update();
        if (e.CommandName == "Edit_Info")//点击编辑设备台账
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;
            //this.Label_eiid.Text = Convert.ToString(e.CommandArgument);
            //   Clear();
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            //string ETT_ID = al[0];
            //this.DropDownList5.Value = EN_ID;
            //string EN_ID = al[1];
            //this.Label_mid.Text = EMT_ID;
            //string EMT_ID = al[2];
            //this.Label_nname.Text = EN_EquipName;
            string EI_ID = al[0];
            Label_eiid.Text = EI_ID;
            string ETT_Type = al[1];
            BindDropDownList5();
            DropDownList5.Items.FindByText(ETT_Type.ToString().Trim()).Selected = true;
            string EN_EquipName = al[2];
            EditTextname.Text = EN_EquipName;
            string EMT_Type = al[3];
            EditTextmodel.Text = EMT_Type;
            string EI_No = al[4];
            EditTextno.Text = EI_No;
            string EI_Location = al[5];
            EditTextLocation.Text = EI_Location;
            string EI_Providor = al[6];
            EditTextProvidor.Text = EI_Providor;
            string EI_IsToCare = al[7];
            if (EI_IsToCare == "是" || EI_IsToCare == "否")
            {
                DropDownList6.SelectedValue = EI_IsToCare;
            }
            else
            {
                DropDownList6.SelectedIndex = 0;  
            }
            if (al[8] == "")
            {
                EditAcceptDate.Text = "";
            }
            else
            { 
                DateTime EI_AcceptDate = Convert.ToDateTime(al[8].ToString());
                EditAcceptDate.Text = EI_AcceptDate.ToString("yyyy-MM-dd");
            }
            string EI_State = al[9];
            //this.DropDownList8.Items.FindByText(EI_State.ToString().Trim()).Selected = true;
            DropDownList8.SelectedValue = EI_State;

            // BindDropDownList5();
            Panel_EditInfo.Visible = true;
            //AddAcceptDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            UpdatePanel_EditInfo.Update();
        }
        if (e.CommandName == "Delete_Info")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;

            Guid eI_ID = new Guid(Convert.ToString(e.CommandArgument));
            //this.Label_enid.Text = Convert.ToString(eI_ID);
            equipmentInfL.Delete_Proc_D_EquipmentInfInfo(eI_ID);
            BindGrid_EquipInfo("");
            UpdatePanel_InfoItem.Update();
        }
    }

    //Gridview翻页
    protected void Grid_EquipInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipInfo.BottomPagerRow;


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
        string condition = GetCondition();
        BindGrid_EquipInfo(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipInfo.PageCount ? Grid_EquipInfo.PageCount - 1 : newPageIndex;
        Grid_EquipInfo.PageIndex = newPageIndex;
        Grid_EquipInfo.DataBind();
    }

    protected void Grid_EquipInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion

    #region 编辑台账
    protected void BtnOK_EditInfo_Click(object sender, EventArgs e)
    {
        if (EditTextno.Text.ToString() == "" || DropDownList5.SelectedValue.ToString() == "" || EditTextLocation.Text.ToString() == "" || EditTextProvidor.Text.ToString() == "" || EditAcceptDate.Text.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || DropDownList8.SelectedValue.ToString() == "" )
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_EditInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        DataSet ds = equipmentInfL.Search_EquipmentInfInfo("and EI_No = '" + EditTextno.Text + "' and c.EMT_Type='" + EditTextmodel.Text + "'and a.ETT_ID= '" + DropDownList5.SelectedValue.ToString() + "' and EI_Location= '" + EditTextLocation.Text + "'and EI_Providor= '" + EditTextProvidor.Text + "'and EI_IsToCare= '" + DropDownList6.SelectedValue.ToString() + "'and EI_AcceptDate= '" + EditAcceptDate.Text + "'and EI_State='" + DropDownList8.SelectedValue.ToString() + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备台账，不能重名！')", true);
            return;
        }
        Guid ETT_ID = new Guid(DropDownList5.SelectedValue.ToString());
        Guid EI_ID = new Guid(Label_eiid.Text.ToString());
        string EI_No = EditTextno.Text.ToString();
        string EI_Location = EditTextLocation.Text.ToString();
        string EI_Providor = EditTextProvidor.Text.ToString();
        string EI_IsToCare = DropDownList6.SelectedValue.ToString();
        DateTime EI_AcceptDate = Convert.ToDateTime((EditAcceptDate.Text.ToString()));
        string EI_State = DropDownList8.SelectedValue.ToString();
        equipmentInfL.Update_EquipmentInfInfo(ETT_ID, EI_ID, EI_No, EI_Location, EI_Providor, EI_IsToCare, EI_AcceptDate, EI_State);
        BindGrid_EquipInfo("");
        Panel_EditInfo.Visible = false;
        UpdatePanel_EditInfo.Update();
        UpdatePanel_InfoItem.Update();
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    protected void BtnCancel_EditInfo_Click(object sender, EventArgs e)
    {
        if (Panel_EditInfo.Visible)
        {
            Panel_EditInfo.Visible = false;
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
        }
    }
    protected void Button_Supplyedit_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        Label31.Text = "编辑";
        BindGridview_PMSupply("");
        Panel_Supply.Visible = true;
        UpdatePanel_Supply.Update();
    }
    #endregion 编辑台账

    #region 增加台账时，检索名称和型号
    protected void Search_namemodel_Click(object sender, EventArgs e)
    {
        Panel_NewInfo.Visible = false;
        UpdatePanel_NewInfo.Update();
        string EN_EquipName = Textnameadd.Text.ToString();
        string EMT_Type = Textmodeladd.Text.ToString();
        BindGrid_EquipNameModel(EN_EquipName, EMT_Type);
        //this.UpdatePanel_searchname.Update();
    }
    protected void Clear_namemodel_Click(object sender, EventArgs e)
    {
        Panel_NewInfo.Visible = false;
        UpdatePanel_NewInfo.Update();
        Textnameadd.Text = "";
        Textmodeladd.Text = "";
        BindGrid_EquipNameModel("", "");
    }
    protected void Close_namemodel_Click(object sender, EventArgs e)
    {
        Panel_searchname.Visible = false;
        Panel_NewInfo.Visible = false;
        UpdatePanel_NewInfo.Update();
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    #endregion 增加台账时，检索名称和型号

    #region 增加台账时，名称和型号gridview
    protected void Grid_EquipNameModel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_EditInfo.Visible = false;
        UpdatePanel_EditInfo.Update();
        if (e.CommandName == "Add_Info")//点击增加设备台账
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipNameModel.SelectedIndex = row.RowIndex;
            //this.Label_enid.Text = Convert.ToString(e.CommandArgument);
            //string eN_ID = e.CommandArgument.ToString(); 
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            //string EN_ID = al[0];
            //this.Label_nid.Text = EN_ID;
            string EMT_ID = al[1];
            Label_mid.Text = EMT_ID;
            string EN_EquipName = al[2];
            Label_nname.Text = EN_EquipName;
            string EMT_Type = al[3];
            Label_mname.Text = EMT_Type;
            Panel_NewInfo.Visible = true;
            AddTextname.Text = Label_nname.Text;
            AddTextmodel.Text = Label_mname.Text;
            AddAcceptDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BindDropDownList3();
            //DropDownList3.Items.Insert(0, new ListItem("请选择", "请选择"));
            AddTextno.Text = "";
            AddTextLocation.Text = "";
            AddTextProvidor.Text = "";
            DropDownList4.SelectedValue = "";
            //BindDropDownList3();
            UpdatePanel_NewInfo.Update();
        }
    }
    protected void Grid_EquipNameModel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipNameModel.BottomPagerRow;


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
        string EN_EquipName = Textnameadd.Text.ToString();
        string EMT_Type = Textmodeladd.Text.ToString();
        BindGrid_EquipNameModel(EN_EquipName, EMT_Type);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipNameModel.PageCount ? Grid_EquipNameModel.PageCount - 1 : newPageIndex;
        Grid_EquipNameModel.PageIndex = newPageIndex;
        Grid_EquipNameModel.DataBind();
    }
    protected void Grid_EquipNameModel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 增加台账时，名称和型号gridview

    #region 增加台账
    protected void BtnOK_NewInfo_Click(object sender, EventArgs e)
    {
        if (AddTextno.Text.ToString() == "" || DropDownList3.SelectedValue.ToString() == "" || AddTextLocation.Text.ToString() == "" || AddTextProvidor.Text.ToString() == "" || AddAcceptDate.Text.ToString() == "" || DropDownList4.SelectedValue.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        DataSet ds = equipmentInfL.Search_EquipmentInfInfo("and EI_No = '" + AddTextno.Text + "' and d.EMT_ID='" + Label_mid.Text + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该设备台账，不能重名！')", true);
            return;
        }
        Guid eTT_ID = new Guid(DropDownList3.SelectedValue.ToString());
        Guid eMT_ID = new Guid(Label_mid.Text.ToString());
        string eI_No = AddTextno.Text.ToString();
        string eI_Location = AddTextLocation.Text.ToString();
        string eI_Providor = AddTextProvidor.Text.ToString();
        string eI_IsToCare = DropDownList4.SelectedValue.ToString();
        DateTime eI_AcceptDate = Convert.ToDateTime((AddAcceptDate.Text.ToString()));
        equipmentInfL.Insert_EquipmentInfInfo(eTT_ID, eMT_ID, eI_No, eI_Location, eI_Providor, eI_IsToCare, eI_AcceptDate);
        BindGrid_EquipInfo("");
        Panel_NewInfo.Visible = false;
        Panel_searchname.Visible = false;
        UpdatePanel_InfoItem.Update();
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    protected void BtnCancel_NewInfo_Click(object sender, EventArgs e)
    {
        if (Panel_NewInfo.Visible)
        {
            Panel_NewInfo.Visible = false;
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
        }
    }
    protected void Button_Supplynew_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        Label31.Text = "新增";
        BindGridview_PMSupply("");
        Panel_Supply.Visible = true;
        UpdatePanel_Supply.Update();
    }
    #endregion 增加台账

    #region 供应商查询
    protected void Search_Supply_Click(object sender, EventArgs e)
    {
        string condition6 = GetCondition6();
        BindGridview_PMSupply(condition6);
    }
    protected string GetCondition6()
    {
        string condition;
        string temp = "";
        if (TextBox1.Text.ToString() != "")
        {
            temp += " and PMSI_SupplyNum like '%" + TextBox1.Text.ToString() + "%'";
        }
        if (TextBox2.Text.ToString() != "")
        {
            temp += " and PMSI_SupplyName like '%" + TextBox2.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    protected void Clear_Supply_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        BindGridview_PMSupply("");
    }
    protected void Button_CancelSP_Click(object sender, EventArgs e)
    {
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    protected void Button_ComSP_Click(object sender, EventArgs e)
    {
        //this.Gridview_PMSupply.SelectedIndex = -1;
        bool temp = false;
        foreach (GridViewRow item in Gridview_PMSupply.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                string Pname = Gridview_PMSupply.DataKeys[item.RowIndex].Value.ToString();
                temp = true;
                if (Label31.Text =="新增")
                {
                    AddTextProvidor.Text = Pname;
                    UpdatePanel_NewInfo.Update();
                }
                if (Label31.Text == "编辑")
                {
                    EditTextProvidor.Text = Pname;
                    UpdatePanel_EditInfo.Update();
                }
                Panel_Supply.Visible = false;
                UpdatePanel_Supply.Update();
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Supply, GetType(), "aa", "alert('请选择供应商！')", true);
            return;
        }
    }
    //Gridview_PMSupply
    protected void Gridview_PMSupply_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Gridview_PMSupply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_PMSupply.BottomPagerRow;

            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox00");   // refer to the TextBox with the NewPageIndex value
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
        string condition6 = GetCondition6();
        BindGridview_PMSupply(condition6);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PMSupply.PageCount ? Gridview_PMSupply.PageCount - 1 : newPageIndex;
        Gridview_PMSupply.PageIndex = newPageIndex;
        Gridview_PMSupply.DataBind();
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
    #endregion 供应商查询

    
    
}