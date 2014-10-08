using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class SalesMgt_MCA : Page
{
    
    MCAD mc = new MCAD();
  
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ClosePanel();
            BindMain();
          
           
        }
        #region 权限
        if (Request.QueryString["status"] == "MCALook")//价格账期查看
        {
            Title = "机械维修加工申请查看";
            Button1.Visible = false;
            Button8.Visible = false;
            UpdatePanel4.Update();
            Gridview_JiaZhang.Columns[13].Visible = false;//dcheck
            Gridview_JiaZhang.Columns[14].Visible = false;//price
            Gridview_JiaZhang.Columns[15].Visible = false;//mcheck
            Gridview_JiaZhang.Columns[16].Visible = false;//over
            UpdatePanel_JiaZhang.Update();



        }
        if (Request.QueryString["status"] == "MCAEdit")//价格账期查看
        {
            Title = "机械维修加工申请维护";
            Button1.Visible = false;
            Button8.Visible = true;
            UpdatePanel4.Update();
            Gridview_JiaZhang.Columns[13].Visible = false;//dcheck
            Gridview_JiaZhang.Columns[14].Visible = false;//price
            Gridview_JiaZhang.Columns[15].Visible = false;//mcheck
            Gridview_JiaZhang.Columns[16].Visible = true;//over
            UpdatePanel_JiaZhang.Update();



        }
        if (Request.QueryString["status"] == "MCADCheck")//价格账期查看
        {
            Title = "机械维修加工申请部门审核";
            Button1.Visible = false;
            Button8.Visible = false;
            UpdatePanel4.Update();
            Gridview_JiaZhang.Columns[13].Visible = true;//dcheck
            Gridview_JiaZhang.Columns[14].Visible = false;//price
            Gridview_JiaZhang.Columns[15].Visible = false;//mcheck
            Gridview_JiaZhang.Columns[16].Visible = false;//over
            UpdatePanel_JiaZhang.Update();



        }
        if (Request.QueryString["status"] == "MCAPrice")//价格账期查看
        {
            Title = "机械维修加工申请报价";
            Button1.Visible = true;
            Button8.Visible = false;
            UpdatePanel4.Update();
            Gridview_JiaZhang.Columns[13].Visible = false;//dcheck
            Gridview_JiaZhang.Columns[14].Visible = true;//price
            Gridview_JiaZhang.Columns[15].Visible = false;//mcheck
            Gridview_JiaZhang.Columns[16].Visible = false;//over
            UpdatePanel_JiaZhang.Update();



        }
        if (Request.QueryString["status"] == "MCAMCheck")//价格账期查看
        {
            Title = "机械维修加工申请报价审核";
            Button1.Visible = false;
            Button8.Visible = false;
            UpdatePanel4.Update();
            Gridview_JiaZhang.Columns[13].Visible = false;//dcheck
            Gridview_JiaZhang.Columns[14].Visible = false;//price
            Gridview_JiaZhang.Columns[15].Visible = true;//mcheck
            Gridview_JiaZhang.Columns[16].Visible = false;//over
            UpdatePanel_JiaZhang.Update();



        }
        #endregion
    }
    protected void BindMain()
    {
        Gridview_JiaZhang.DataSource = mc.Select_MCA(label19.Text);
        Gridview_JiaZhang.DataBind();
        UpdatePanel_JiaZhang.Update();
    }
    protected void GetCondition()
    {
        string temp = "";
        if (TextBox13.Text != "")
        {
            temp += " and MCA_ApplyNum like '%" + TextBox13.Text + "%'";
        }
        if (TextBox14.Text != "")
        {
            temp += " and MCA_Product like '%" + TextBox14.Text + "%'";
        }
        if (TextBox17.Text != "")
        {
            temp += " and MCA_Depart like '%" + TextBox17.Text + "%'";
        }
        if (TextBox9.Text != "")
        {
            temp += " and MCA_State like '%" + TextBox9.Text + "%'";
        }
        if (TextBox4.Text != ""&&TextBox8.Text!="")
        {
            temp += " and MCA_Time between '" + TextBox4.Text + "' and '"+TextBox8.Text+"'";
        }
        label19.Text = temp;
    }





    protected void Gridview_JiaZhang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_JiaZhang.BottomPagerRow;


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
        BindMain();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_JiaZhang.PageCount ? Gridview_JiaZhang.PageCount - 1 : newPageIndex;
        Gridview_JiaZhang.PageIndex = newPageIndex;
        Gridview_JiaZhang.DataBind();
    }
    protected void Gridview_JiaZhang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["MCA_State"].ToString().Trim() != "已提交")
            {
                e.Row.Cells[13].Enabled = false;
            }

            if (drv["MCA_State"].ToString().Trim() != "部门审核通过")
            {
                e.Row.Cells[14].Enabled = false;
            }
            if (drv["MCA_State"].ToString().Trim() != "已报价")
            {
              
                e.Row.Cells[15].Enabled = false;
            }
            if (drv["MCA_State"].ToString().Trim() != "报价审核通过")
            {

                e.Row.Cells[16].Enabled = false;
            }
            if (drv["MCA_Upload"].ToString().Trim() == "无")
            {

                e.Row.Cells[11].Enabled = false;
                //e.Row.Cells[11].ForeColor = System.Drawing.Color.HotPink;
               
            }
        }
    }
    protected void SearchApply(object sender, EventArgs e)
    {
        GetCondition();
        BindMain();
    }
    protected void NewApply(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Label7.Text = "新增";
        Panel3.Visible = true;
        Panel2.Visible = false;
        Label11.Text = "Create";
        UpdatePanel1.Update();
        ControlVision();
    }
    protected void ControlVision()
    {
        string con = Label7.Text;
        Panel1.Visible = true;
        UpdatePanel1.Update();
        switch (con)
        {
            case "新增":
                TextBox3.Enabled = true;//product
                TextBox2.Enabled = true;//mount
                TextBox5.Enabled = true;//note
                TextBox_AddOpinion.Enabled = false;//chekc1
                TextBox1.Enabled = false;//price
                TextBox6.Enabled = false;//check2
                TextBox7.Enabled = false;//over
                Panel3.Visible = true;
                Panel2.Visible = false;
                Button2.Visible = true;
                UpdatePanel1.Update();
                break;
                
            case "部门审核":
                TextBox3.Enabled = false;//product
                TextBox2.Enabled = false;//mount
                TextBox5.Enabled = false;//note
                Label12.Text = "D";
                TextBox_AddOpinion.Enabled = true;//chekc1
                Label9.Text = Session["UserName"].ToString();
                Label5.Text = DateTime.Now.ToShortDateString();
                TextBox1.Enabled = false;//price
                TextBox6.Enabled = false;//check2
                TextBox7.Enabled = false;//over
                Panel3.Visible = false;
                Panel2.Visible = true;
                Button2.Visible = true;
                UpdatePanel1.Update();
                break;
               

            case "报价":
                TextBox3.Enabled = false;//product
                TextBox2.Enabled = false;//mount
                TextBox5.Enabled = false;//note
                TextBox_AddOpinion.Enabled = false;//chekc1
            
                TextBox1.Enabled = true;//price
                TextBox6.Enabled = false;//check2
                TextBox7.Enabled = false;//over
                Label11.Text = "Price";
                Panel3.Visible = true;
                Panel2.Visible = false;
                Button2.Visible = true;
                UpdatePanel1.Update();
                break;

            case "报价审核":
               TextBox3.Enabled = false;//product
                TextBox2.Enabled = false;//mount
                TextBox5.Enabled = false;//note
                Label12.Text = "M";
                TextBox_AddOpinion.Enabled = false;//chekc1
                Label10.Text = Session["UserName"].ToString();
                Label6.Text = DateTime.Now.ToShortDateString();
                TextBox1.Enabled = false;//price
                TextBox6.Enabled = true;//check2
                TextBox7.Enabled = false;//over
                Panel3.Visible = false;
                Panel2.Visible = true;
                Button2.Visible = true;
                UpdatePanel1.Update();
                break;

            case "查看":
                  TextBox3.Enabled = false;//product
                TextBox2.Enabled = false;//mount
                TextBox5.Enabled = false;//note
                Label12.Text = "D";
                TextBox_AddOpinion.Enabled = false;//chekc1
          
                TextBox1.Enabled = false;//price
                TextBox6.Enabled = false;//check2
                TextBox7.Enabled = false;//over
                Panel1.Visible = true;
                Panel3.Visible = true;
                Panel2.Visible = false;
                Button2.Visible = false;
                UpdatePanel1.Update();
                break;
               
        }
    }
    protected void NewApplyOK(object sender, EventArgs e)
    {
        if (Label11.Text == "Create") //新建
        {
            string product = TextBox3.Text;
            string note = TextBox5.Text;
            string man = Session["UserName"].ToString();
            string department = Session["Department"].ToString();
            int mount = 0;
            string load = "无";
            string path = "";
            if (CheckBox1.Checked)
            {
                load = "有";
                path = Label15.Text.ToString().Trim();
            }
            if (TextBox2.Text == "" || TextBox3.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('产品名称和数量必须填写！')", true);
                return;
            }
            else
            {
                 mount = Convert.ToInt32(TextBox2.Text);
            }
            mc.Insert_MCA(man, department, product, note, mount, load, path);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了新的机械维修加工申请表，请审核！";
         
            string sErr = RTXhelper.SendbyDepAndRole(remind, department, "机械维修加工申请部门审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            UpdatePanel1.Update();
        }
        if (Label11.Text == "Price") //报价
        {
          Guid id =new Guid( Label3.Text.ToString());
          decimal price = 0;
          if (TextBox1.Text == "")
          {
              price = 0;
          }
          else
          {
              price = Convert.ToDecimal(TextBox1.Text);
          }
          mc.Update_MCA_Price(id, price);
          ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
          ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('提交成功！')", true);
          string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "已报价了编号为："+label8.Text+"的机械维修加工申请表，请审核！";
        
          string sErr = RTXhelper.Send(remind, "机械维修加工申请报价审核");
          if (!string.IsNullOrEmpty(sErr))
          {
              ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
          }
          Panel1.Visible = false;
          Panel2.Visible = false;
          Panel3.Visible = false;
          UpdatePanel1.Update();
        }
        BindMain();
    }
    protected void Gridview_JiaZhang_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));


         if (e.CommandName == "Look1")//点击查看原始月计划详细
         {
             Label7.Text = "查看";
             Label3.Text = e.CommandArgument.ToString();
             UpdatePanel1.Update();
             label8.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[1].Text.ToString();
             UpdatePanel1.Update();
             ControlVision();
             BindDetail();
         }
         if (e.CommandName == "CheckD")
         {
             Label7.Text = "部门审核";
             Label3.Text = e.CommandArgument.ToString();
             Label12.Text = "D";
             UpdatePanel1.Update();
             label8.Text =  Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[1].Text.ToString();
             BindDetail();
             ControlVision();
         }
         if (e.CommandName == "Price1")
         {
             Label7.Text = "报价";
             label8.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[1].Text.ToString();
             Label3.Text = e.CommandArgument.ToString();
             label8.Text = "-" + Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[1].Text.ToString();
             UpdatePanel1.Update();
             BindDetail();
             ControlVision();
         }
         if (e.CommandName == "CheckM") 
         {
             Label7.Text = "报价审核";
             Label12.Text = "M";
             label8.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[1].Text.ToString();
             Label3.Text = e.CommandArgument.ToString();
             Label14.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[7].Text.ToString();
             UpdatePanel1.Update();
             BindDetail();
             ControlVision();
         }
         if (e.CommandName == "Over1")
         {
             label8.Text = Gridview_JiaZhang.Rows[gvr.RowIndex].Cells[1].Text.ToString();
             Label3.Text = e.CommandArgument.ToString();
             string man = Session["UserName"].ToString();
             Guid id = new Guid(e.CommandArgument.ToString());
             mc.Proc_U_MCA_Over(id, man);
             ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('领取成功！')", true);
             BindMain();
             Panel1.Visible = false;
             Panel2.Visible = false;
             Panel3.Visible = false;
             UpdatePanel1.Update();
         }
    }
    protected void BindDetail()
    {
        string str = " and MCA_ID like '%" + Label3.Text.ToString().Trim() + "%'";
        DataSet ds = mc.Select_MCA(str);
        DataTable dt = ds.Tables[0];
        TextBox3.Text = dt.Rows[0][5].ToString();//pt
        TextBox2.Text = dt.Rows[0][8].ToString();//mount
        TextBox5.Text = dt.Rows[0][6].ToString();//mount
        Label9.Text = dt.Rows[0][10].ToString();//dcman
        Label5.Text = dt.Rows[0][11].ToString();//time
        TextBox_AddOpinion.Text = dt.Rows[0][12].ToString();//cdop
        TextBox1.Text = dt.Rows[0][7].ToString();//mount
        Label10.Text = dt.Rows[0][13].ToString();//mount
        Label6.Text = dt.Rows[0][14].ToString();//mount
        TextBox6.Text = dt.Rows[0][15].ToString();//mount
        TextBox7.Text = dt.Rows[0][17].ToString();//mount
        Label1.Text = dt.Rows[0][18].ToString();//mount
        UpdatePanel1.Update();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        int mount = Convert.ToInt32(TextBox2.Text);
        decimal price = Convert.ToDecimal(TextBox1.Text);
        Label2.Text = Convert.ToString(mount * price);
        UpdatePanel1.Update();
    }
    protected void Check_OK(object sender, EventArgs e)
    {
        if (Label12.Text == "D")
        {
            string state = "部门审核通过";
            Guid id = new Guid(Label3.Text.ToString());
            string note = TextBox_AddOpinion.Text;
            string man = Session["UserName"].ToString();
            mc.Update_MCA_DCheck(id, man, state, note);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过成功！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过编号为:" + label8.Text + "的机械维修加工申请表，请填写对应报价信息！";
            string sErr = RTXhelper.Send(remind, "机械维修加工申请报价");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        if (Label12.Text == "M")
        {
            string state = "报价审核通过";
            Guid id = new Guid(Label3.Text.ToString());
            string note = TextBox6.Text;
            string man = Session["UserName"].ToString();
            mc.Update_MCA_MCheck(id, man, state, note);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过成功！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过编号为:" + label8.Text + "的机械维修加工申请表，可以进行加工操作！";
            string sErr = RTXhelper.Send(remind, "机械维修加工申请报价");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        BindMain();
    }
    protected void Check_NotOK(object sender, EventArgs e)
    {
        if (Label12.Text == "D")
        {
            string state = "部门审核驳回";
            Guid id = new Guid(Label3.Text.ToString());
            string note = TextBox_AddOpinion.Text;
            if (note == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回请填写驳回意见！')", true);
                return;
            }
            string man = Session["UserName"].ToString();
            string department = Session["Department"].ToString();
            mc.Update_MCA_DCheck(id, man, state, note);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核驳回成功！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核驳回编号为:" + label8.Text + "的机械维修加工申请表，请知悉！";
            string sErr = RTXhelper.SendbyDepAndRole(remind, department, "机械维修加工申请维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        if (Label12.Text == "M")
        {
            string state = "报价审核驳回";
            Guid id = new Guid(Label3.Text.ToString());
            string note = TextBox6.Text;
            string man = Session["UserName"].ToString();
            if (note == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回必须填写驳回意见！')", true);
                return;
            }
            mc.Update_MCA_MCheck(id, man, state, note);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核驳回成功！')", true);
            string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核驳回编号为:" + label8.Text + "的机械维修加工申请表，请知悉！";
            string sErr = RTXhelper.Send(remind, "机械维修加工申请报价");
            string sErr1 = RTXhelper.SendbyUserName(remind, Label14.Text.ToString().Trim());
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        BindMain();
    }
    protected void Check_Canel(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }
    protected void NewApplyCanel(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ShowPanel();
    }
    #region upload
    private void ShowPanel()//显示上传实验报告框
    {
        string script = "document.getElementById('Panel99').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
    }

    private void ClosePanel()//关闭上传实验报告框
    {
        string script = "document.getElementById('Panel99').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel", script, true);
    }

    protected void cancel_upload_Click(object sender, EventArgs e)
    {
        ClosePanel();
        UpdatePanel_upload.Update();
    }

    protected void ok_upload_Click(object sender, EventArgs e)
    {
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
        if (FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt")//判断文件扩展名
            {
                try
                {
                    if (!Directory.Exists(UploadURL))//判断文件夹是否已经存在
                    {
                        Directory.CreateDirectory(UploadURL);//创建文件夹
                    }
                    FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('上传失败!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('请选择文件!')", true);
            return;
        }

        string filePath = "file/" + newname + fullname;
        Label15.Text = filePath;
        UpdatePanel1.Update();
        ClosePanel();

    }
    #endregion
    protected void Gridview_JiaZhang_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_JiaZhang.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_JiaZhang.Rows[i].Cells.Count; j++)
            {
                Gridview_JiaZhang.Rows[i].Cells[j].ToolTip = Gridview_JiaZhang.Rows[i].Cells[j].Text;
                if (Gridview_JiaZhang.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_JiaZhang.Rows[i].Cells[j].Text = Gridview_JiaZhang.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void RepartTo(object sender, EventArgs e)
    {
        GetCondition();
        Response.Redirect("../REPORT_cc/MCAPrint.aspx?" + "&condition=" + label19.Text.ToString() +  "&start=" + TextBox4.Text.ToString() + "&end=" + TextBox8.Text.ToString());
    }
}