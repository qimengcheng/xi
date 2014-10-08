using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class ProductionBasicInfo_TemplateUpload : System.Web.UI.Page
{
    TemplateUploadD upload = new TemplateUploadD();
    TempUploadInfo tempInfo = new TempUploadInfo();
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            try
            {
                if (!(Session["UserRole"].ToString().Contains("模板管理")))
                {
                    Response.Redirect("~/Default.aspx");

                }
                else
                {
                    Label_Grid1_State.Text = "默认数据源";
                    GridView1.DataSource = upload.SList_TemplateUpload();
                    GridView1.DataBind();
                    UpdatePanel_Temp.Update();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");

            }

            Label_Grid1_State.Text = "默认数据源";
            GridView1.DataSource = upload.SList_TemplateUpload();
            GridView1.DataBind();
            UpdatePanel_Temp.Update();
        }
    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Label_Grid1_State.Text = "模糊搜索数据源";
        Label_Search.Text = Txt_search.Text.Trim();
        if (Txt_search.Text != "")
        {
            GridView1.DataSource = upload.S_TemplateUpload(Txt_search.Text.Trim());
            GridView1.DataBind();
            UpdatePanel_Temp.Update();
        }
        else
        {
            Label_Grid1_State.Text = "默认数据源";
            GridView1.DataSource = upload.SList_TemplateUpload();
            GridView1.DataBind();
            UpdatePanel_Temp.Update();
        }
    }


    protected void Button_SearchReset_Click(object sender, EventArgs e)
    {
        Label_Grid1_State.Text = "默认数据源";
        Txt_search.Text = "";
        GridView1.DataSource = upload.SList_TemplateUpload();
        GridView1.DataBind();
        UpdatePanel_Temp.Update();
        UpdatePanel_Search.Update();

        GridView1.SelectedIndex = -1;

        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }


    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        PanelAdd.Visible = true;
        UpdatePanel1.Update();       
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        Label_Grid1_State.Text = "默认数据源";
        Boolean fileOk = false;
        DataSet ds = upload.S_TemplatUpload_Name(txt_Tmp.Text);
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('系统中已有该模板名称，不能重名！')", true);
            return;
        }
        if (txt_Tmp.Text != "")
        {
            if (this.ImgFileUpload.HasFile)
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(ImgFileUpload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);
                if(fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (ImgFileUpload.PostedFile.ContentLength < 8192000)
                    {
                        string filepath = "/TemplateUpload/";
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        string virpath = filepath + ImgFileUpload.FileName;
                        string mappath = Server.MapPath(virpath);
                        System.IO.FileInfo fi = new System.IO.FileInfo(mappath);
                        if (fi.Exists)
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('存在同名文件，请修改后上传!')", true);
                            return;
                        }
                        ImgFileUpload.SaveAs(mappath);
                        tempInfo.TmpUpload_Name = txt_Tmp.Text.Trim();
                        tempInfo.TmpUpload_ImgUrl = virpath;
                        tempInfo.TmpUpload_Person = Session["UserName"].ToString();
                        tempInfo.TmpUpload_Time = DateTime.Now;
                        upload.I_TemplatUpload(tempInfo);

                        GridView1.DataSource = upload.SList_TemplateUpload();
                        GridView1.DataBind();
                        txt_Tmp.Text = "";
                        UpdatePanel_Temp.Update();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('模板新增成功!')", true);
                        PanelAdd.Visible = false;
                        UpdatePanel1.Update();
                    }
                
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('文件大小超出8M！请重新选择！')", true);
                        return;
                    }
            }   
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('上传文件类型有误！')", true);
                return;
            }
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('没有上传文件！')", true);
                return;
            }

        }

        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('模板名称不能为空！')", true);
            return;
        }
    }


    /// <summary>
    /// 验证是否指定的图片格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public bool IsImage(string str)
    {
        bool isimage = false;
        string thestr = str.ToLower();
        //限定只能上传jpg和gif图片
        string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
        //对上传的文件的类型进行一个个匹对
        for (int i = 0; i < allowExtension.Length; i++)
        {
            if (thestr == allowExtension[i])
            {
                isimage = true;
                break;
            }
        }
        return isimage;
    }

    protected void BtnAddClose_Click(object sender, EventArgs e)
    {
        txt_Tmp.Text = "";
        PanelAdd.Visible = false;
        UpdatePanel1.Update();
    }


    protected void BtnAddReset_Click(object sender, EventArgs e)
    {
        txt_Tmp.Text = "";
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete1")
        {      
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            GridView1.SelectedIndex = -1;
            string id = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_ID"].ToString();
            Guid guid_id = new Guid(id);
            string imgUrl = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_ImgUrl"].ToString();            
            int i = upload.D_TemplatUpload(guid_id);
            if (i > 0)
            {
                System.IO.File.Delete(Server.MapPath(imgUrl));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('模板删除成功!')", true);
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('模板删除失败!')", true);
            }
            GridView1.DataSource = upload.SList_TemplateUpload();
            GridView1.DataBind();
            UpdatePanel_Temp.Update();
            PanelAdd.Visible = false;
            PanelEdit.Visible = false;
            PanelShowImage.Visible = false;
            UpdatePanel_ShowImage.Update();
            UpdatePanel1.Update();
            //无关信息隐藏
            //Panel10.Visible = false;
            //UpdatePanel_AddTmp.Update();

        }
        if (e.CommandName == "CheckProType")
        {
            Panel_PT.Visible = true;
            GridView2.SelectedIndex = -1;

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            string id = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_ID"].ToString();
            Label_TmpID.Text = id;
            databind();
            //无关信息隐藏
           // Panel10.Visible = false;
           // UpdatePanel_AddTmp.Update();
            Panel_Product.Visible = false;
            UpdatePanel_Product.Update();
        }
        if (e.CommandName == "EditTemplate")
        {
          
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            TextBox_Edit.Text = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_Name"].ToString();
            Label_ImgUrl.Text = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_ImgUrl"].ToString();
            Label_EditTmpID.Text = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_ID"].ToString();
            PanelEdit.Visible = true;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "CheckImage")
        {
           
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            Label_ImgName.Text = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_Name"].ToString();
            Label_ShowImgUrl.Text = GridView1.DataKeys[row.RowIndex].Values["TmpUpload_ImgUrl"].ToString();
            TempImage.ImageUrl = Label_ShowImgUrl.Text.ToString();
            PanelShowImage.Visible = true;
            UpdatePanel_ShowImage.Update();
        }    
    }

    public void databind()
    {
        string condition;
        string TmpUpload_ID = " TmpUpload_ID='" + Label_TmpID.Text.Trim() + "'";
        string PT_Name = Txt_PT_Search.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + Txt_PT_Search.Text.Trim() + "%' ";
        string PT_Code = Txt_PT_Search0.Text.Trim() == "" ? " and 1=1 " : " and PT_Code like '%" + Txt_PT_Search0.Text.Trim() + "%' ";
        condition = TmpUpload_ID + PT_Name + PT_Code;
        GridView2.DataSource = upload.S_TemplatUpload_ProType(condition);
        GridView2.DataBind();
        UpdatePanel_PT.Update();
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


        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            GridView1.DataSource = upload.S_TemplateUpload(Txt_search.Text.Trim());
            GridView1.DataBind();
        }
        if (Label_Grid1_State.Text == "默认数据源")
        {
            GridView1.DataSource = upload.SList_TemplateUpload();
            GridView1.DataBind();
        } //绑定数据源

        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView1.PageIndex = newPageIndex;

        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();

        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
    }

    protected void Btn_SubmitEdit_Click(object sender, EventArgs e)
    {
        Label_Grid1_State.Text = "默认数据源";
        Boolean fileOk = false;
        if (TextBox_Edit.Text != "")
        {
            if (this.FileUploadEdit.HasFile)
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(FileUploadEdit.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);
                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (FileUploadEdit.PostedFile.ContentLength < 8192000)
                    {
                        string name = Label_ImgUrl.Text;
                        string mapname = Server.MapPath(name);
                        System.IO.File.Delete(mapname);
                        string filepath = "/TemplateUpload/";
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        string virpath = filepath + FileUploadEdit.FileName;
                        string mappath = Server.MapPath(virpath);
                        System.IO.FileInfo fi = new System.IO.FileInfo(mappath);
                        if (fi.Exists)
                        {
                            ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('存在同名文件，请修改后上传!')", true);
                            return;
                        }
                        FileUploadEdit.SaveAs(mappath);
                        tempInfo.TmpUpload_ID = new Guid(Label_EditTmpID.Text.ToString());
                        tempInfo.TmpUpload_Name = TextBox_Edit.Text.Trim();
                        tempInfo.TmpUpload_ImgUrl = virpath;
                        tempInfo.TmpUpload_Person = Session["UserName"].ToString();
                        tempInfo.TmpUpload_Time = DateTime.Now;
                        upload.U_TemplatUpload(tempInfo);
                        GridView1.DataSource = upload.SList_TemplateUpload();
                        GridView1.DataBind();
                        TextBox_Edit.Text = "";
                        UpdatePanel_Temp.Update();
                        ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('模板上传且修改成功!')", true);
                        PanelEdit.Visible = false;
                        UpdatePanel1.Update();
                        PanelShowImage.Visible = false;
                        UpdatePanel_ShowImage.Update();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('文件大小超出8M！请重新选择！')", true);
                        return;
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('上传文件类型有误！')", true);
                    return;
                }
            }
            else
            {
                tempInfo.TmpUpload_ID = new Guid(Label_EditTmpID.Text.ToString());
                tempInfo.TmpUpload_Name = TextBox_Edit.Text.Trim();
                tempInfo.TmpUpload_ImgUrl = Label_ImgUrl.Text;
                tempInfo.TmpUpload_Person = Session["UserName"].ToString();
                tempInfo.TmpUpload_Time = DateTime.Now;
                upload.U_TemplatUpload(tempInfo);

                GridView1.DataSource = upload.SList_TemplateUpload();
                GridView1.DataBind();
                TextBox_Edit.Text = "";
                UpdatePanel_Temp.Update();
                ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(Page), "alert", "alert('模板修改成功!')", true);
                PanelEdit.Visible = false;
                UpdatePanel1.Update();
                PanelShowImage.Visible = false;
                UpdatePanel_ShowImage.Update();
            }


        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('模板名称不能为空！')", true);
            return;
        }
    }
    
    protected void Btn_EditClose_Click(object sender, EventArgs e)
    {
        PanelEdit.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Btn_SearchPT_Click(object sender, EventArgs e)
    {
        databind();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Button_CancelPT_Click(object sender, EventArgs e)
    {
        Txt_PT_Search.Text = "";
        Txt_PT_Search0.Text = "";
        databind();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void Btn_AddPT_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        databind2();
        Panel_Product.Visible = true;
        UpdatePanel_Product.Update();
    }

    private void databind2()
    {
        string condition;

        string PT_Name = TextBox_Series.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TextBox_Series.Text.Trim() + "%' ";
        string PT_Code = TextBox_ProductName.Text.Trim() == "" ? " and 1=1 " : " and PT_Code like '%" + TextBox_ProductName.Text.Trim() + "%' ";
        condition = PT_Name + PT_Code;
        GridView_ProType.DataSource = upload.S_TemplatUpload_ForChose(condition);
        GridView_ProType.DataBind();
        UpdatePanel_Product.Update();
    }
    protected void Button_ProTypeSearch_Click(object sender, EventArgs e)
    {
        databind2();
        GridView_ProType.SelectedIndex = -1;
    }
            
    protected void  Button_SearchProTypeReset_Click(object sender, EventArgs e)
    {
        TextBox_Series.Text = "";
        TextBox_ProductName.Text = "";
        databind2();
    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
                if (CheckBox.Checked == true)
                {
                    upload.U_TemplatUpload_AddTemp(new Guid(Label_TmpID.Text.Trim()), new Guid(GridView_ProType.DataKeys[i].Values["PT_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的产品型号！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);
        }
        TextBox_ProductName.Text = "";
        TextBox_Series.Text = "";
        databind();
        GridView2.PageIndex = 0;
        GridView2.SelectedIndex = -1;
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
            if (CheckBoxAll.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxfanxuan.Checked = false;
    }
    protected void Checkfanxuan_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxAll.Checked = false;
    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView2.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    upload.D_TemplatUpload_ProType(new Guid(GridView2.DataKeys[i].Values["PT_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的产品型号！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }

        databind();
        //Panel10.Visible = false;
       // UpdatePanel_AddTmp.Update();
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void Button_CloseS_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Panel_PT.Visible = false;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        UpdatePanel_Temp.Update();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_ProType.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_ProType.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox2.Checked = false;
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView2.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView2.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;

        databind();
        //Panel10.Visible = false;
       // UpdatePanel_AddTmp.Update();
        Panel_PT.Visible = true;
        UpdatePanel_PT.Update();
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void GridView_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_ProType.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_ProType.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_ProType.PageCount ? GridView_ProType.PageCount - 1 : newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;
        GridView_ProType.PageIndex = newPageIndex;

        databind2();
    }
    protected void Button_ClosePT_Click(object sender, EventArgs e)
    {
        Panel_Product.Visible = false;
        UpdatePanel_Product.Update();
    }
    protected void ButtonCloseImg_Click(object sender, EventArgs e)
    {
        PanelShowImage.Visible = false;
        UpdatePanel_ShowImage.Update();
    }

}