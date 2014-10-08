using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Client_ClientInfo : Page
{
    ClientInfo PCI = new ClientInfo();
    SalesAfterD sad = new SalesAfterD();
    ProTypePrice pt = new ProTypePrice();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
             Binddr();
            if (Request.QueryString["status"] == "ClientInfoSee")//出入库类别查看权限
            {
                Title = "客户信息查看";
                GridView_Client.Columns[7].Visible = false;
                GridView_Client.Columns[8].Visible = false;
                Btn_NewClient.Visible = false;
                Btn_NewClientPhone.Visible = false;
                GridView_ClientPhone.Columns[11].Visible = false;
                GridView_ClientPhone.Columns[10].Visible = false;
                GridView_ClientPhone.Columns[9].Visible = false;
                GridView_ClientLabel.Columns[5].Visible = false;
                GridView_ClientLabel.Columns[6].Visible = false;
                 Button_NewLabel.Visible = false;
                DropDownList_ClientRegion.DataSource = PCI.SList_CRMRegionBasicInfoDrop();
                DropDownList_ClientRegion.DataBind();
                DropDownList_ClientSort.DataSource = PCI.SList_CRMCustomerSortBasicDataDrop();
                DropDownList_ClientSort.DataBind();
                GridView_Client.DataSource = PCI.SList_CRMCustomerInfoBind();
                GridView_Client.DataBind();
                UpdatePanel_ClientInfo.Update();
            }
            else if (Request.QueryString["status"] == "ClientInfoMange")//出入库类别查看权限
            {
                Title = "客户类别维护";
                Button_NewLabel.Visible = true;
                DropDownList_ClientRegion.DataSource = PCI.SList_CRMRegionBasicInfoDrop();
                DropDownList_ClientRegion.DataBind();
                DropDownList_ClientSort.DataSource = PCI.SList_CRMCustomerSortBasicDataDrop();
                DropDownList_ClientSort.DataBind();
                GridView_Client.DataSource = PCI.SList_CRMCustomerInfoBind();
                GridView_Client.DataBind();
                UpdatePanel_ClientInfo.Update();
                GridView_ClientLabel.Columns[5].Visible = true;
                GridView_ClientLabel.Columns[6].Visible = true;


            }

        }



    }
    protected void Binddr()
    {
        DropDownList1.DataSource = pt.Select_SalesMan("");
        DropDownList2.DataSource = pt.Select_SalesMan("");
        DropDownList1.DataTextField = "SMSM_Name";
        DropDownList1.DataValueField = "SMSM_Name";
        DropDownList2.DataTextField = "SMSM_Name";
        DropDownList2.DataValueField = "SMSM_Name";
        DropDownList1.DataBind();
        DropDownList2.DataBind();
    UpdatePanel_NewClient.Update();
    UpdatePanel_ChangeClient.Update();
    }
    #region 客户信息表

    protected void GridView_Client_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Change")
        {
            DropDownList_ChangeClientRegion.DataSource = PCI.SList_CRMRegionBasicInfoDrop();
            DropDownList_ChangeClientRegion.DataBind();
            DropDownList_ChanClientSort.DataSource = PCI.SList_CRMCustomerSortBasicDataDrop();
            DropDownList_ChanClientSort.DataBind();
            
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Client.SelectedIndex = row.RowIndex;
            GridView_Client.SelectedIndex = -1;
            string Client_id = e.CommandArgument.ToString();
            Guid client_id = new Guid(Client_id);
            Session["client_id"] = e.CommandArgument.ToString();
            if (row.Cells[11].Text.ToString() != ""&& row.Cells[11].Text.ToString() != "&nbsp;")
            { 
            DropDownList2.SelectedValue = row.Cells[11].Text.ToString();
            }
            TextBox_ChanClientName.Text = row.Cells[1].Text.Trim().ToString().Replace("&nbsp;","");
            DropDownList_ChanClientSort.Text = row.Cells[2].Text.Trim().ToString().Replace("&nbsp;", "");
            DropDownList_ChangeClientRegion.Text = row.Cells[3].Text.Trim().ToString().Replace("&nbsp;", "");
            TextBox_ChanClientAdress.Text = ((Label)(row.Cells[4].FindControl("Adress1"))).Text.Trim().ToString().Replace("&nbsp;", "");
            //DropDownList_ChanIsLabel.Text = row.Cells[6].Text.Trim().ToString().Replace("&nbsp;", "");

            Panel_ChangeClient.Visible = true;
            UpdatePanel_ChangeClient.Update();

            return;
        }
        else
            if (e.CommandName == "dele")
            {

                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                GridView_Client.SelectedIndex = row.RowIndex;
                GridView_Client.SelectedIndex = -1;
                string Client_id = e.CommandArgument.ToString();
                Guid client_id = new Guid(Client_id);
                PCI.Proc_D_CRMCustomerInfo(client_id);
                string ClientName = TextBox_Clientname1.Text.Trim().ToString();
                string ClientRegion = DropDownList_ClientRegion.Text.Trim().ToString();
                string ClientSort = DropDownList_ClientSort.SelectedValue.Trim().ToString();
                string ClientIslabel = DropDownList_IsLabel.SelectedValue.Trim().ToString();
                if (ClientName.Trim().ToString() == "".ToString()) { ClientName = (string)"123"; }

                if (ClientRegion.Trim().ToString() == (string)"请选择".Trim().ToString()) { ClientRegion = (string)"123"; }

                if (ClientSort == (string)"请选择".Trim().ToString()) { ClientSort = (string)"123"; }

                if (ClientIslabel.Trim().ToString() == (string)"请选择".Trim().ToString()) { ClientIslabel = (string)"123"; }

                GridView_Client.DataSource = PCI.S_SearchClientInfo(ClientName, ClientRegion, ClientSort, ClientIslabel);
                GridView_Client.DataBind();
                UpdatePanel_ClientInfo_Search.Update();
                UpdatePanel_ClientInfo.Update();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功!')", true);
                return;

            }
            else
                if (e.CommandName == "Phone")
                {
                    Label1.Text = e.CommandArgument.ToString();
                    GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                    GridView_Client.SelectedIndex = row.RowIndex;
                    GridView_Client.SelectedIndex = -1;
                    string Client_id = e.CommandArgument.ToString();
                    Guid client_id = new Guid(Client_id);
                    Session["ClientPhoneq_Name"] = row.Cells[1].Text.Trim().ToString();
                    Session["ClientPhoneq_id"] = Client_id;
                    GridView_ClientPhone.DataSource = PCI.SList_CRMCustomerContact(client_id);
                    GridView_ClientPhone.DataBind();
                    Panel_ClientPhone.Visible = true;
                    UpdatePanel_ClientPhone.Update();
                    Panel_NewClientPhone.Visible = false;
                    UpdatePanel_NewClientPhone.Update();
                    

                }
                else
                    if (e.CommandName == "Label")
                    {
                        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                        GridView_Client.SelectedIndex = row.RowIndex;
                        GridView_Client.SelectedIndex = -1;
                        string Client_id = e.CommandArgument.ToString();
                        Guid client_id = new Guid(Client_id);
                        Session["ClientLabel_Name"] = row.Cells[1].Text.Trim().ToString();
                        Session["ClientLabel_id"] = e.CommandArgument.ToString();

                        GridView_ClientLabel.DataSource = PCI.SList_CRMCustomerBinTagDetail(client_id);
                        GridView_ClientLabel.DataBind();


                        Panel_UpdatePanel_ClientLabel.Visible = true;
                        UpdatePanel_ClientLabel.Update();
                        return;
                    }


    }

    protected void GridView_Client_PageIndexChanging(object sender, GridViewPageEventArgs e)//客户信息表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Client.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Client.PageCount ? GridView_Client.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_Client.PageIndex = newPageIndex;
        GridView_Client.PageIndex = newPageIndex;
        if (Label16.Text == "search")
        {
            string ClientName = TextBox_Clientname1.Text.Trim().ToString();
            string ClientRegion = DropDownList_ClientRegion.Text.Trim().ToString();
            string ClientSort = DropDownList_ClientSort.SelectedValue.Trim().ToString();
            string ClientIslabel = DropDownList_IsLabel.SelectedValue.Trim().ToString();
            if (ClientName.Trim().ToString() == "".ToString()) { ClientName = (string)"123"; }

            if (ClientRegion.Trim().ToString() == (string)"请选择".Trim().ToString()) { ClientRegion = (string)"123"; }

            if (ClientSort == (string)"请选择".Trim().ToString()) { ClientSort = (string)"123"; }

            if (ClientIslabel.Trim().ToString() == (string)"请选择".Trim().ToString()) { ClientIslabel = (string)"123"; }

            GridView_Client.DataSource = PCI.S_SearchClientInfo(ClientName, ClientRegion, ClientSort, ClientIslabel);
            GridView_Client.DataBind();
        }
        else
        {
            
            GridView_Client.DataSource = PCI.SList_CRMCustomerInfoBind();
            GridView_Client.DataBind();
        }
      
        UpdatePanel_ClientInfo.Update();
    }  //读取go前textbox，导航到指定页面
    #endregion

    #region 客户联系方式表

    protected void GridView_Phone_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "dele11")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_ClientPhone.SelectedIndex = row.RowIndex;
            string Contact_id = e.CommandArgument.ToString();
            Guid contact_id = new Guid(Contact_id);
            PCI.Proc_D_CRMCustomerContact(contact_id);

            Guid DCRMCIF_ID = new Guid(Session["ClientPhoneq_id"].ToString());
            GridView_ClientPhone.DataSource = PCI.SList_CRMCustomerContact(DCRMCIF_ID);
           GridView_ClientPhone.DataBind();
           UpdatePanel_ClientPhone.Update();
           return;
        }

        else
            if (e.CommandName == "Change")
            {

                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                GridView_ClientPhone.SelectedIndex = row.RowIndex;
                GridView_ClientPhone.SelectedIndex = -1;
                string Contact_id = e.CommandArgument.ToString();
                Guid contact_id = new Guid(Contact_id);
                Session["contact_id"] = e.CommandArgument.ToString();

                TextBox_ChanPhoneName.Text = row.Cells[1].Text.Trim().ToString().Replace("&nbsp;","");
                TextBox_ChanPhonePosition.Text = row.Cells[2].Text.Trim().ToString().Replace("&nbsp;", "");
                TextBox_ChanPhoneCall.Text = row.Cells[3].Text.Trim().ToString().Replace("&nbsp;", "");
                TextBox_ChanPhoneMobile.Text = row.Cells[4].Text.Trim().ToString().Replace("&nbsp;", "");
                TextBox_ChanPhoneFax.Text = row.Cells[5].Text.Trim().ToString().Replace("&nbsp;", "");
                TextBox_ChanPhoneE_Mail.Text = row.Cells[6].Text.Trim().ToString().Replace("&nbsp;", "");
                TextBox_ChanPhoneQQ.Text = row.Cells[7].Text.Trim().ToString().Replace("&nbsp;", "");

                Panel_ChanClientPhone.Visible = true;
                UpdatePanel_ChanClientPhone.Update();
                return;
            }
            else if (e.CommandName == "Important1")
            {
                sad.Update_Important(new Guid(e.CommandArgument.ToString()));
                Guid DCRMCIF_ID = new Guid(Session["ClientPhoneq_id"].ToString());
                GridView_ClientPhone.DataSource = PCI.SList_CRMCustomerContact(DCRMCIF_ID);
                GridView_ClientPhone.DataBind();
                UpdatePanel_ClientPhone.Update();
            }

    }
    protected void GridView_OrderDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv.Row["CRMCC_I"].ToString()=="是")//常用联系人
            {
          
                e.Row.BackColor = Color.Pink;
             
            }

        }
    }
    protected void GridView_Phone_PageIndexChanging(object sender, GridViewPageEventArgs e)//区域信息表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_ClientPhone.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ClientPhone.PageCount ? GridView_ClientPhone.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_ClientPhone.PageIndex = newPageIndex;
        GridView_ClientPhone.PageIndex = newPageIndex;
        //Guid CRMCIF_ID = new Guid(Session["ClientPhone_id"].ToString());
        Guid CRMCIF_ID = new Guid(Label1.Text.ToString());
        GridView_ClientPhone.DataSource = PCI.SList_CRMCustomerContact(CRMCIF_ID);
        GridView_ClientPhone.DataBind();
        UpdatePanel_ClientPhone.Update();
    }  //读取go前textbox，导航到指定页面
    #endregion

    #region 客户标签表

    protected void GridView_ClientLabel_PageIndexChanging(object sender, GridViewPageEventArgs e)//客户信息表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_ClientLabel.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ClientLabel.PageCount ? GridView_ClientLabel.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_ClientLabel.PageIndex = newPageIndex;

        GridView_ClientLabel.PageIndex = newPageIndex;
        GridView_ClientLabel.DataSource = PCI.SList_CRMCustomerBinTagDetail(new Guid(Session["ClientLabel_id"].ToString()));
        GridView_ClientLabel.DataBind();
        UpdatePanel_ClientLabel.Update();
    }  //读取go前textbox，导航到指定页面

    protected void GridView_ClientLabel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "bianji")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_ClientLabel.SelectedIndex = row.RowIndex;
            GridView_ClientLabel.SelectedIndex = -1;
            string Label_id = e.CommandArgument.ToString();
            Guid contact_id = new Guid(Label_id);
            Session["ChangeLabel_id"] = e.CommandArgument.ToString();
            TextBox_ChanLabelName.Text = row.Cells[1].Text.Trim().ToString();
            TextBox_ChanLabelPro.Text = row.Cells[2].Text.Trim().ToString();
            TextBox_ChanLabelWu.Text = row.Cells[3].Text.Trim().ToString();
            TextBox_ChanLabelWuName.Text = row.Cells[4].Text.Trim().ToString();

            Panel_ChangeLabel.Visible = true;
            UpdatePanel_ChangeLabel.Update();



        }

        else
            if (e.CommandName == "shanchu")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                GridView_ClientLabel.SelectedIndex = row.RowIndex;
                string label_id = e.CommandArgument.ToString();
                Guid CRMCBTD_ID = new Guid(label_id);

                PCI.Proc_D_CRMCustomerBinTagDetail(CRMCBTD_ID);
                Guid CRMCIF_ID = new Guid(Session["ClientLabel_id"].ToString());
                GridView_ClientLabel.DataSource = PCI.SList_CRMCustomerBinTagDetail(CRMCIF_ID);
                GridView_ClientLabel.DataBind();
                Panel_UpdatePanel_ClientLabel.Visible = true;
                Panel_ChangeLabel.Visible = false;
                UpdatePanel_ChangeLabel.Update();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功!')", true);
                UpdatePanel_ClientLabel.Update();


            }


    }



    #endregion



    protected void Btn_NewClient_Click(object sender, EventArgs e)
    {
        
        DropDownList_NewClientRegion.DataSource = PCI.SList_CRMRegionBasicInfoDrop();
        DropDownList_NewClientRegion.DataBind();
        DropDownList_NewClientSort.DataSource = PCI.SList_CRMCustomerSortBasicDataDrop();
        DropDownList_NewClientSort.DataBind();
        Panel_NewClient.Visible = true;
        UpdatePanel_NewClient.Update();


    }
    protected void Btn_NewClientOk_Click(object sender, EventArgs e)
    {

        string CRMCIF_Name = TextBox_NewCliengName.Text.Trim().ToString();
        string CRMRBI_Name = DropDownList_NewClientRegion.Text.Trim().ToString();
        string CRMCSBD_Name = DropDownList_NewClientSort.Text.Trim().ToString();
        string CRMCIF_Address = TextBox_NewClientAdress.Text.Trim().ToString();
        string CRMCIF_BinTag = DropDownList_NewIsLabel.Text.Trim().ToString();
        string salesman = DropDownList1.SelectedValue.ToString();
        PCI.I_CRMCustomerInfo(CRMCIF_Name, CRMRBI_Name, CRMCSBD_Name, CRMCIF_Address, CRMCIF_BinTag,salesman);
        GridView_Client.DataSource = PCI.SList_CRMCustomerInfoBind();
        GridView_Client.DataBind();
        UpdatePanel_ClientInfo.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功!')", true);
        Panel_NewClient.Visible = false;
        UpdatePanel_NewClient.Update();
        return;

    }
    protected void Btn_NewClientCancel_Click(object sender, EventArgs e)
    {
        Panel_NewClient.Visible = false;
        UpdatePanel_NewClient.Update();
    }
    protected void Btn_ChanClientCancel_Click(object sender, EventArgs e)
    {
        Panel_ChangeClient.Visible = false;
        UpdatePanel_ChangeClient.Update();
    }
    protected void Btn_ChanClientOk_Click(object sender, EventArgs e)
    {
        Guid CRMCIF_ID = new Guid(Session["client_id"].ToString());
        string CRMCIF_Name = TextBox_ChanClientName.Text.Trim().ToString();
        string CRMRBI_Name = DropDownList_ChangeClientRegion.Text.Trim().ToString();
        string CRMCSBD_Name = DropDownList_ChanClientSort.Text.Trim().ToString();
        string CRMCIF_Address = TextBox_ChanClientAdress.Text.Trim().ToString();
        string CRMCIF_BinTag = DropDownList_ChanIsLabel.Text.Trim().ToString();
        string man = DropDownList2.SelectedValue.ToString();
        PCI.U_CRMCustomerInfo(CRMCIF_ID, CRMCIF_Name, CRMRBI_Name, CRMCSBD_Name, CRMCIF_Address, CRMCIF_BinTag,man);
        GridView_Client.DataSource = PCI.SList_CRMCustomerInfoBind();
        GridView_Client.DataBind();
        UpdatePanel_ClientInfo.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功!')", true);
        Panel_ChangeClient.Visible = false;
        UpdatePanel_ChangeClient.Update();
        return;
        
    }
    protected void Btn_NewClientPhone_Click(object sender, EventArgs e)
    {

        TextBox_NewPhoneName.Text = "";
        TextBox_NewPhonePosition.Text = "";
        TextBox_NewPhoneCall.Text = "";
        TextBox_NewPhoneMobile.Text = "";
        TextBox_NewPhoneFax.Text = "";
        TextBox_NewPhoneE_Mail.Text = "";
        TextBox_NewPhoneQQ.Text = "";
        
        
        Panel_NewClientPhone.Visible = true;
        UpdatePanel_NewClientPhone.Update();


    }
    protected void Btn_NewPhongCancel_Click(object sender, EventArgs e)
    {
        Panel_NewClientPhone.Visible = false;
        UpdatePanel_NewClientPhone.Update();
    }
    protected void Btn_NewPhoneOk_Click(object sender, EventArgs e)
    {
        Guid CRMCIF_ID = new Guid(Session["ClientPhoneq_id"].ToString());
        string CRMCC_Name = TextBox_NewPhoneName.Text.Trim().ToString();
        string CRMCC_Position = TextBox_NewPhonePosition.Text.Trim().ToString();
        string CRMCC_PhoneNum = TextBox_NewPhoneCall.Text.Trim().ToString();
        string CRMCC_TelePhoneNum = TextBox_NewPhoneMobile.Text.Trim().ToString();
        string CRMCC_FaxNum = TextBox_NewPhoneFax.Text.Trim().ToString();
        string CRMCC_Email = TextBox_NewPhoneE_Mail.Text.Trim().ToString();
        string CRMCC_QQ = TextBox_NewPhoneQQ.Text.Trim().ToString();

        PCI.I_CRMCustomerContact(CRMCIF_ID, CRMCC_Name, CRMCC_Position, CRMCC_PhoneNum, CRMCC_TelePhoneNum, CRMCC_FaxNum, CRMCC_Email, CRMCC_QQ);
        GridView_ClientPhone.DataSource = PCI.SList_CRMCustomerContact(CRMCIF_ID);
        GridView_ClientPhone.DataBind();

        Panel_NewClientPhone.Visible = false;
        UpdatePanel_ClientPhone.Update();
        UpdatePanel_NewClientPhone.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功!')", true);
        return;
    }
    protected void Btn_ChanPhoneCancel_Click(object sender, EventArgs e)
    {
        Panel_ChanClientPhone.Visible = false;
        UpdatePanel_ChanClientPhone.Update();
    }
    protected void Btn_ChanPhoneOk_Click(object sender, EventArgs e)
    {
        Guid CRMCC_ID = new Guid(Session["contact_id"].ToString());
        Guid CRMCIF_ID = new Guid(Session["ClientPhoneq_id"].ToString());
        string CRMCC_Name = TextBox_ChanPhoneName.Text.Trim().ToString();
        string CRMCC_Position = TextBox_ChanPhonePosition.Text.Trim().ToString();
        string CRMCC_PhoneNum = TextBox_ChanPhoneCall.Text.Trim().ToString();
        string CRMCC_TelePhoneNum = TextBox_ChanPhoneMobile.Text.Trim().ToString();
        string CRMCC_FaxNum = TextBox_ChanPhoneFax.Text.Trim().ToString();
        string CRMCC_Email = TextBox_ChanPhoneE_Mail.Text.Trim().ToString();
        string CRMCC_QQ = TextBox_ChanPhoneQQ.Text.Trim().ToString();

        PCI.Proc_U_CRMCustomerContact(CRMCC_ID, CRMCIF_ID, CRMCC_Name, CRMCC_Position, CRMCC_PhoneNum, CRMCC_TelePhoneNum, CRMCC_FaxNum, CRMCC_Email, CRMCC_QQ);
        GridView_ClientPhone.DataSource = PCI.SList_CRMCustomerContact(CRMCIF_ID);
        GridView_ClientPhone.DataBind();
        Panel_ChanClientPhone.Visible = false;
        UpdatePanel_ChanClientPhone.Update();
        UpdatePanel_ClientPhone.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功!')", true);
        return;
    }
    protected void Btn_ClientSearchCancel_Click(object sender, EventArgs e)
    {
        DropDownList_ClientRegion.DataSource = PCI.SList_CRMRegionBasicInfoDrop();
        DropDownList_ClientRegion.DataBind();
        DropDownList_ClientSort.DataSource = PCI.SList_CRMCustomerSortBasicDataDrop();
        DropDownList_ClientSort.DataBind();
        GridView_Client.DataSource = PCI.SList_CRMCustomerInfoBind();
        GridView_Client.DataBind();
        UpdatePanel_ClientInfo.Update();
    }
    protected void Btn_ClientSearch_Click(object sender, EventArgs e)
    {
        string ClientName = TextBox_Clientname1.Text.Trim().ToString();
        string ClientRegion = DropDownList_ClientRegion.Text.Trim().ToString();
        string ClientSort = DropDownList_ClientSort.SelectedValue.Trim().ToString();
        string ClientIslabel = DropDownList_IsLabel.SelectedValue.Trim().ToString();
        if (ClientName.Trim().ToString() == "".ToString()) { ClientName = (string)"123";}

        if (ClientRegion.Trim().ToString() == (string)"请选择".Trim().ToString()) { ClientRegion = (string)"123";}

        if (ClientSort == (string)"请选择".Trim().ToString()) { ClientSort = (string)"123"; }

        if (ClientIslabel.Trim().ToString() == (string)"请选择".Trim().ToString()) { ClientIslabel = (string)"123"; }


        Label16.Text = "search";
        GridView_Client.DataSource = PCI.S_SearchClientInfo(ClientName, ClientRegion, ClientSort, ClientIslabel);
        GridView_Client.DataBind();
        UpdatePanel_ClientInfo_Search.Update();
        UpdatePanel_ClientInfo.Update();
     

        



    }
    protected void Button_NewLabel_Click(object sender, EventArgs e)
    {
        Guid CRMCIF_ID = new Guid(Session["ClientLabel_id"].ToString());
        TextBox_LablProduct.Text = "";
        TextBox_LabelNumber.Text = "";
        TextBox_LabelName.Text = "";
        Panel_New_Label.Visible = true;
        UpdatePanel_NewLabel.Update();




    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_New_Label.Visible = false;
        UpdatePanel_NewLabel.Update();
    }
    protected void Btn_NewLabelOk_Click(object sender, EventArgs e)
    {
        Guid CRMCIF_ID = new Guid(Session["ClientLabel_id"].ToString());
        string Label_Product = TextBox_LablProduct.Text.Trim().ToString();
        string Label_Name = TextBox_LabelName.Text.Trim().ToString();
        string Label_Number = TextBox_LabelNumber.Text.Trim().ToString();


        PCI.I_CRMCustomerBinTagDetail(CRMCIF_ID, Label_Product, Label_Name, Label_Number);
        GridView_ClientLabel.DataSource = PCI.SList_CRMCustomerBinTagDetail(CRMCIF_ID);
        GridView_ClientLabel.DataBind();


        Panel_UpdatePanel_ClientLabel.Visible = true;
        Panel_New_Label.Visible=false;
        UpdatePanel_NewLabel.Update();
        UpdatePanel_ClientLabel.Update();


    }
    protected void Btn_CancelChange_Click(object sender, EventArgs e)
    {
        TextBox_ChanLabelName.Text ="";
        TextBox_ChanLabelPro.Text = "";
        TextBox_ChanLabelWu.Text = "";
        TextBox_ChanLabelWuName.Text = "";

        Panel_ChangeLabel.Visible = false;
        UpdatePanel_ChangeLabel.Update();
    }
protected void Btn_SeeLabelCancel_Click(object sender, EventArgs e)
    {
        Panel_UpdatePanel_ClientLabel.Visible = false;
        UpdatePanel_ClientLabel.Update();
    }
    protected void Btn_ChangeLabel_Click(object sender, EventArgs e)
    {
        Guid CRMCBTD_ID = new Guid(Session["ChangeLabel_id"].ToString());
        Guid CRMCIF_ID = new Guid(Session["ClientLabel_id"].ToString());
        string ChanLabelPro = TextBox_ChanLabelPro.Text.Trim().ToString();
        string ChanLabelWu = TextBox_ChanLabelWu.Text.Trim().ToString();
        string ChanLabelWuName = TextBox_ChanLabelWuName.Text.Trim().ToString();

        PCI.Proc_U_CRMCustomerBinTagDetail(CRMCBTD_ID, ChanLabelPro, ChanLabelWu, ChanLabelWuName);
        GridView_ClientLabel.DataSource = PCI.SList_CRMCustomerBinTagDetail(CRMCIF_ID);
        GridView_ClientLabel.DataBind();


        Panel_UpdatePanel_ClientLabel.Visible = true;
        Panel_ChangeLabel.Visible = false;
        UpdatePanel_ChangeLabel.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功!')", true);
        UpdatePanel_ClientLabel.Update();




    }
protected void Btn_NewClientPhoneCancel_Click(object sender, EventArgs e)
    {
        Panel_ClientPhone.Visible = false;
        UpdatePanel_ClientPhone.Update();


    }
}