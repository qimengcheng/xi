using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class ProductionBasicInfo_ProSpecial :Page
{
    private ProSpecialD psd = new ProSpecialD();
    PMSupplyCertificL pc = new PMSupplyCertificL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ClosePanel();
            if (Request.QueryString["state"] == null)
            {
                label_pagestate.Text = "look";
            }
            else
            {
                label_pagestate.Text = Request.QueryString["state"];
            }
            string state = label_pagestate.Text;
            if (state == "look")
            {
                Title = "特殊产品查看";
                Button3.Visible = false;//新增特殊产品按钮
                Gridview2.Columns[8].Visible = false;
                Gridview2.Columns[9].Visible = false;
                Gridview2.Columns[10].Visible = false;
                Gridview2.Columns[11].Visible = false;
                Gridview2.Columns[12].Visible = false;
                Gridview2.Columns[15].Visible = false;
                Gridview4.Columns[7].Visible = false;
                Gridview4.Columns[8].Visible = false;
          
            }
            if (state == "make")
            {
                Title = "特殊产品制定";
                Button3.Visible = false;//新增特殊产品按钮
                Gridview2.Columns[8].Visible = false;
                Gridview2.Columns[9].Visible = false;
                Gridview2.Columns[10].Visible = false;
                Gridview2.Columns[11].Visible = true;
                Gridview2.Columns[12].Visible = false;

                Gridview4.Columns[7].Visible = false;
                Gridview4.Columns[8].Visible = false;
          
            }
            if (state == "apply")
            {
                Title = "特殊产品申请";
                Button3.Visible = true;//新增特殊产品按钮
                Gridview2.Columns[8].Visible = true;
                Gridview2.Columns[9].Visible = true;
                Gridview2.Columns[10].Visible = true;
                Gridview2.Columns[11].Visible = false;
                Gridview2.Columns[12].Visible = false;
                Gridview2.Columns[15].Visible = false;
                Gridview4.Columns[7].Visible = false;
                Gridview4.Columns[8].Visible = true;
            }
            if (state == "cs")
            {
                Title = "特殊产品会签";

                Button3.Visible = false;//新增特殊产品按钮
                Gridview2.Columns[8].Visible = false;
                Gridview2.Columns[9].Visible = false;
                Gridview2.Columns[10].Visible = false;
                Gridview2.Columns[11].Visible = false;
                Gridview2.Columns[12].Visible = true;
                Gridview2.Columns[13].Visible = false;
                Gridview4.Columns[7].Visible = true;
                Gridview4.Columns[8].Visible = false;
                Gridview2.Columns[15].Visible = false;
            }
            BindGriview2("");
            Panel_Preserve.Visible=true;
            UpdatePanel_Preserve.Update();
        }
        
    }
    private void BindGriview2(string condition)
    {
        Gridview2.DataSource = psd.SelectProType_Special(condition);
        Gridview2.DataBind();
    }
    //检索
    protected void Button_Sh1(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGriview2(condition);
        Panel_Preserve.Visible = true;
        UpdatePanel_Preserve.Update();
    }
   protected string Getcondition()
    {
        string condition="";
       if(Mory.Text!="")
       {
           condition += "and PT_SpecialCode='" + Mory.Text+"'";
       }
       if(TextBox1.Text!="")
       {
       condition+="and PT_SpecialTypeMan like'%"+TextBox1.Text+"%'";
       }
       if(TextBox_SPTime2.Text!="")
       {
       condition+="and PT_SpecialTypeTime='"+TextBox_SPTime2.Text+"'";
       }
       return condition;
    }
    //重置
   protected void Button_Reset(object sender, EventArgs e)
   {
       Mory.Text = "";
       TextBox1.Text = "";
       TextBox_SPTime2.Text = "";
       BindGriview2("");
       Panel_Preserve.Visible = true;
       UpdatePanel_Preserve.Update();
   }
   //新增特殊产品申请单
   protected void Button_New(object sender, EventArgs e)
   {
       label_Change.Text = "新增特殊产品申请单";
       Panel_NewProjectInfo.Visible = true;
       UpdatePanel_NewProjectInfo.Update();
   }

   protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
   {
       if(e.CommandName=="Edit1")//编辑
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           label_PT_ID.Text = e.CommandArgument.ToString();
           string condition="and PT_ID='"+new Guid(label_PT_ID.Text )+"'";
           DataSet ds=psd.SelectProType_Special(condition);
           DataTable dt=ds.Tables[0];
           if(dt.Rows.Count>0)
           {
            label_Change.Text =dt.Rows[0][28].ToString()+"申请单修改";
            TextBox4.Text = dt.Rows[0][12].ToString();
            TextBox2.Text = dt.Rows[0][19].ToString();
           }
           Panel_NewProjectInfo.Visible = true;
           UpdatePanel_NewProjectInfo.Update();
       }

       if (e.CommandName == "Cancel1")//删除
       {
           try
           {
               GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
               Gridview2.SelectedIndex = row.RowIndex;
               label_PT_ID.Text = e.CommandArgument.ToString();
               psd.DeleteProType_Special(new Guid(label_PT_ID.Text));
               BindGriview2("");
               UpdatePanel_Preserve.Update();
           }
           catch (Exception)
           {
               ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已经选择了会签部门或制定了下一步信息，无法删除只能修改！')", true);
               return;
           }
       }
       if(e.CommandName=="SelectDept")//选择会签部门
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           label_PT_ID.Text = e.CommandArgument.ToString();
           BindGridview3("");
           Panel_Org.Visible = true;
           UpdatePanel_Org.Update();
       }
       if(e.CommandName=="Design")//会签
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           label_PT_ID.Text = e.CommandArgument.ToString();
           string condition = "and PT_ID='"+new Guid(label_PT_ID.Text)+"'";
           BindGridview4(condition);
           Gridview4.Columns[8].Visible = false;
           Gridview4.Columns[7].Visible = true;
           Panel_Sign.Visible = true;
           UpdatePanel_Sign.Update();
       }
       if(e.CommandName=="Look")//查看会签
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           label_PT_ID.Text = e.CommandArgument.ToString();
           string condition = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
           BindGridview4(condition);
           //this.Gridview4.Columns[7].Visible = false;
           //this.Gridview4.Columns[8].Visible = true;
           Panel_Sign.Visible = true;
           UpdatePanel_Sign.Update();
       }
       if(e.CommandName=="Make")//制作
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           label_PT_ID.Text = e.CommandArgument.ToString();
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Response.Redirect("../ProductionBasicInfo/PBProType.aspx?state=specialmake&PT_ID=" + new Guid(label_PT_ID.Text));
       }
       if (e.CommandName == "Lookinfo")//查看基础数据
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           label_PT_ID.Text = e.CommandArgument.ToString();
           string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
           Response.Redirect("../ProductionBasicInfo/PBProType.aspx?state=speciallook&PT_ID=" + new Guid(label_PT_ID.Text));
       }
       if (e.CommandName == "MAcc")//制定时上传附件
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           label_Acc.Text = "制定";
           label_PT_ID.Text = e.CommandArgument.ToString();
           ShowPanel();
           UpdatePanel4.Update();
       }
       if (e.CommandName == "printpreview")//打印报表
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview2.SelectedIndex = row.RowIndex;
           try
           {
               Response.Redirect("../REPORT_cc/ProSpecialPrint.aspx?" + "&PT_ID=" + Gridview2.DataKeys[row.RowIndex].Values["PT_ID"].ToString());
           }
           catch (Exception)
           {
               
               throw;
           }
           
       }
   }
   protected void BindGridview4(string condition)
   {
       Gridview4.DataSource = psd.SelectPTCountersign(condition);
       Gridview4.DataBind();
   }
   //部门查询
   private void BindGridview3(string condition)
   {
       Gridview3.DataSource = pc.SelectPMSCAC_Organization(condition);
       Gridview3.DataBind();
   }
   //检索部门
   protected void Button1_Kil(object sender, EventArgs e)
   {
       string condition = GetCondition_Org();
       BindGridview3(condition);
       UpdatePanel_Org.Update();
   }
   protected string GetCondition_Org()
   {
       string item = "";
       string condition;
       if (TextBox22.Text != "")
       {
           item += "and BDOS_Name like'%" + TextBox22.Text + "%'";
       }
       condition = item;
       return condition;
   }
   //重置检索部门
   protected void Button_CoMl(object sender, EventArgs e)
   {
       TextBox22.Text = "";
       BindGridview3("");
       UpdatePanel_Org.Update();
   }
    //提交申请单
   protected void ConfirmProject(object sender, EventArgs e)
   {
       string SNeed="";
       string Note="";
        if(TextBox4.Text!="")
        {
            SNeed = TextBox4.Text.ToString();
        }
       if(TextBox2.Text!="")
       {
           Note = TextBox2.Text.ToString();
       }
       if (label_Change.Text == "新增特殊产品申请单")
       {
          int p=psd.InsertProType_Special(SNeed, Note, Session["UserName"].ToString(),label_AccNum.Text,label_AccName.Text,Label_FilePath.Text);
          if (p > 0)
          {
              ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('提交成功,请选择会签部门！')", true);
          }
          else
          {
              ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('提交失败！')", true);
              return;
          }
       }
       else
       {
           psd.UpdateProType_Special(new Guid(label_PT_ID.Text.ToString()), SNeed, Note, label_AccNum.Text, label_AccName.Text, Label_FilePath.Text);
           
       }
       string condition=Getcondition();
       BindGriview2(condition);
       UpdatePanel_Preserve.Update();
       TextBox2.Text = "";
       TextBox4.Text="";

       Panel_NewProjectInfo.Visible = false;
       UpdatePanel_NewProjectInfo.Update();
   }
    //关闭提交申请单
   protected void CanelProject(object sender, EventArgs e)
   {
       TextBox2.Text = "";
       TextBox4.Text = "";
       Panel_NewProjectInfo.Visible = false;
       UpdatePanel_NewProjectInfo.Update();
   }
    //提交选择会签部门
   protected void Button_ComSPP(object sender, EventArgs e)
   {
       bool temp = false;
       string Dep = "";

       foreach (GridViewRow item in Gridview3.Rows)
       {
           CheckBox rb = item.FindControl("CheckMarkup") as CheckBox;
           if (rb.Checked)
           {
                Dep = Gridview3.Rows[item.RowIndex].Cells[2].Text.ToString();
               string condition="and PT_ID='"+label_PT_ID.Text.ToString()+"'"+"and PTC_Dep='"+Dep+"'";
               DataSet ds=psd.SelectPTCountersign(condition);
               DataTable dt=ds.Tables[0];
               if (dt.Rows.Count > 0)
               {
                   ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('会签部门不能重复！')", true);
                   return;
               }
               else
               {
                   int p = psd.InsertPTCountersign(new Guid(label_PT_ID.Text.ToString()), Dep);
                   temp = true;
               }
           }
       }
       if (!temp)
       {
           ScriptManager.RegisterClientScriptBlock(UpdatePanel_Org, GetType(), "aa", "alert('请选择部门')", true);
           return;
       }
       else
       {
           ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('提交成功！')", true);
           Panel_Org.Visible = false;
           UpdatePanel_Org.Update();
           //string dep = "";
           //foreach (GridViewRow q in Gridview4.Rows)
           //{
           //    dep += q.Cells[1].Text.ToString() + ",";
           //}
           //dep = dep.Substring(0, dep.Length - 1);
           
               label_RTX.Text = "ERP系统信息："+Session["UserRole"].ToString()+"于" +DateTime.Now+"提交了"+ Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].ToString() + "的特殊产品申请单";
               string message = label_RTX.Text;
               string sErr = RTXhelper.Send(message, "特殊产品申请制定");
               if (!string.IsNullOrEmpty(sErr))
               {
                   ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
               }
           
       }
   }
    //关闭选择部门
   protected void Button_CancelSPP(object sender, EventArgs e)
   {
       TextBox22.Text = "";
       Panel_Org.Visible = false;
       UpdatePanel_Org.Update();
   }
    //会签表
   protected void Gridview4_RowCommand(object sender, GridViewCommandEventArgs e)
   {
       if (e.CommandName == "Myloo")//查看
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview4.SelectedIndex = row.RowIndex;
           string condition = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
           DataSet ds = psd.SelectProType_Special(condition);
           DataTable dt = ds.Tables[0];
           label_PTC_ID.Text = e.CommandArgument.ToString();
           string conditionn = "and PTC_ID='" + label_PTC_ID.Text + "'";
           DataSet dss = psd.SelectPTCountersign(conditionn);
           DataTable dtt = dss.Tables[0];
           if (dtt.Rows.Count > 0)
           {
               label40.Text = dt.Rows[0][28].ToString() + dtt.Rows[0][6].ToString() + "会签";
               label41.Text = dtt.Rows[0][4].ToString();
               label43.Text = dtt.Rows[0][2].ToString();
               label44.Text = dtt.Rows[0][3].ToString();
               TextBox15.Text = dtt.Rows[0][5].ToString();
           }
           label41.Visible = true;
           Label42.Visible = true;
           label43.Visible = true;
           label44.Visible = true;
           TextBox15.Enabled = false;
           Button22.Visible = false;
           Button23.Visible = false;
           Button24.Visible = false;
           Button30.Visible = true;
           Panel2.Visible = true;
           Panel4.Visible = true;
           UpdatePanel2.Update();
       }
       if (e.CommandName == "Mylloo")//会签
       {
          
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview4.SelectedIndex = row.RowIndex;
           string condition = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
           DataSet ds = psd.SelectProType_Special(condition);
           DataTable dt = ds.Tables[0];
           label_PTC_ID.Text = e.CommandArgument.ToString();
           string conditionn = "and PTC_ID='" + label_PTC_ID.Text + "'";
           DataSet dss = psd.SelectPTCountersign(conditionn);
           DataTable dtt = dss.Tables[0];
           if (dtt.Rows.Count > 0)
           {
               label40.Text = dt.Rows[0][28].ToString() + dtt.Rows[0][6].ToString() + "会签";

           }
             if(dtt.Rows[0][6].ToString()==Session["Department"].ToString())
          {
           label41.Visible = false;
           Label42.Visible = false;
           label43.Visible = false;
           label44.Visible = false;
           TextBox15.Enabled = true;
           Button22.Visible = true;
           Button23.Visible = true;
           Button24.Visible = true;
           Button30.Visible = false;
           Panel2.Visible = true;
           Panel4.Visible = true;
           UpdatePanel2.Update();
           }
           else 
           {
               ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('抱歉，你没有此权限！')", true);
               return;
           }
       }
       if (e.CommandName == "Miko")//删除
       {
           GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
           Gridview4.SelectedIndex = row.RowIndex;
           label_PTC_ID.Text = e.CommandArgument.ToString();

           psd.DeletePTCountersign(new Guid(label_PTC_ID.Text));
           string condition = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
           BindGridview4(condition);
           Panel_Sign.Visible = true;
           UpdatePanel_Sign.Update();
       }
   }
    //通过
   protected void ButtonPass(object sender, EventArgs e)
   {
       Guid  PTC_ID;
       string PTC_Man = "";
       string PTC_State = "";
       string PTC_Suggestion = "";

    if(TextBox15.Text!="")
    {
        PTC_Suggestion = TextBox15.Text.ToString();
    }
    PTC_ID = new Guid(label_PTC_ID.Text.ToString());
    PTC_Man = Session["UserName"].ToString();
    PTC_State = "通过";
    
    psd.UpdatePTCountersign(PTC_ID,PTC_Man,PTC_State,PTC_Suggestion);
    string conditionnn = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
    BindGridview4(conditionnn);
       int i = 0;
            foreach(GridViewRow item in Gridview4.Rows)
            {
            if(item.Cells[2].Text=="通过")
            {
                i = i + 1;
            }
            if (item.Cells[2].Text == "驳回")
                {
                    i = -1;
                }
            }
            if (i == Gridview4.Rows.Count)
            {
                psd.UpdatePTCSate(new Guid(label_PT_ID.Text.ToString()), "会签通过");
            }
            if (i < Gridview4.Rows.Count && i != -1)
               {
                   psd.UpdatePTCSate(new Guid(label_PT_ID.Text.ToString()), "会签中");
               }
            string condition = Getcondition();
            BindGriview2(condition);
            string conditionn = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
            BindGridview4(conditionn);
            UpdatePanel_Sign.Update();
            UpdatePanel_Preserve.Update();
    TextBox15.Text = "";
    Panel4.Visible = false;
    Panel2.Visible = false;
    UpdatePanel2.Update();
   }
    //驳回
   protected void ButtonUnpass(object sender, EventArgs e)
   {
       Guid PTC_ID;
       string PTC_Man = "";
       string PTC_State = "";
       string PTC_Suggestion = "";

       if (TextBox15.Text != "")
       {
           PTC_Suggestion = TextBox15.Text.ToString();
       }
       PTC_ID = new Guid(label_PTC_ID.Text.ToString());
       PTC_Man = Session["UserName"].ToString();
       PTC_State = "驳回";
       psd.UpdatePTCountersign(PTC_ID, PTC_Man, PTC_State, PTC_Suggestion);
       
       psd.UpdatePTCSate(new Guid(label_PT_ID.Text.ToString()), "会签驳回");

       string condition = Getcondition();
       BindGriview2(condition);
       string conditionn = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
       BindGridview4(conditionn);
       UpdatePanel_Sign.Update();
       UpdatePanel_Preserve.Update();
       TextBox15.Text = "";
       Panel4.Visible = false;
       Panel2.Visible = false;
       UpdatePanel2.Update();
   }
    //关闭
   protected void ButtonClose(object sender, EventArgs e)
   {
       TextBox15.Text = "";
       Panel2.Visible = false;
       Panel4.Visible = false;
       UpdatePanel2.Update();
   }
   protected void Button_CClose(object sender, EventArgs e)
   {
       TextBox15.Text = "";
       Panel2.Visible = false;
       Panel4.Visible = false;
       UpdatePanel2.Update();
   }

   #region//悬浮框
   protected void Gridview2_DataBound(object sender, EventArgs e)
   {
       for (int i = 0; i < Gridview2.Rows.Count; i++)
       {
           for (int j = 0; j < Gridview2.Rows[i].Cells.Count; j++)
           {
               Gridview2.Rows[i].Cells[j].ToolTip = Gridview2.Rows[i].Cells[j].Text;
               if (Gridview2.Rows[i].Cells[j].Text.Length > 10)
               {
                   Gridview2.Rows[i].Cells[j].Text = Gridview2.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
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
   protected void Gridview4_DataBound(object sender, EventArgs e)
   {
       for (int i = 0; i < Gridview4.Rows.Count; i++)
       {
           for (int j = 0; j < Gridview4.Rows[i].Cells.Count; j++)
           {
               Gridview4.Rows[i].Cells[j].ToolTip = Gridview4.Rows[i].Cells[j].Text;
               if (Gridview4.Rows[i].Cells[j].Text.Length > 15)
               {
                   Gridview4.Rows[i].Cells[j].Text = Gridview4.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
               }
           }
       }
   }
   #endregion
   #region
   protected void Gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
       string condition =Getcondition();
       BindGriview2(condition);

       newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
       newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
       Gridview2.PageIndex = newPageIndex;
       Gridview2.DataBind();
   }

   protected void Gridview3_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {

       GridView theGrid = sender as GridView;  // refer to the GridView
       int newPageIndex = 0;

       if (-2 == e.NewPageIndex)
       {
           TextBox txtNewPageIndex = null;
           GridViewRow pagerRow = Gridview3.BottomPagerRow;


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
       BindGridview3(condition);

       newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
       newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
       Gridview3.PageIndex = newPageIndex;
       Gridview3.DataBind();
   }
   protected void Gridview_4_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {

       GridView theGrid = sender as GridView;  // refer to the GridView
       int newPageIndex = 0;

       if (-2 == e.NewPageIndex)
       {
           TextBox txtNewPageIndex = null;
           GridViewRow pagerRow = Gridview4.BottomPagerRow;


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
       string condition = "and PT_ID='" + new Guid(label_PT_ID.Text) + "'";
       BindGridview4(condition);
       newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
       newPageIndex = newPageIndex >= Gridview4.PageCount ? Gridview4.PageCount - 1 : newPageIndex;
       Gridview4.PageIndex = newPageIndex;
       Gridview4.DataBind();
   }
   #endregion
   protected void Button_Ccl(object sender, EventArgs e)
   {
       Panel_Sign.Visible = false;
       UpdatePanel_Sign.Update();
   }
   protected void Gridview4_RowDataBound(object sender, GridViewRowEventArgs e)
   {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {

           DataRowView drv = (DataRowView)e.Row.DataItem;
           if (drv["PTC_State"].ToString().Trim() != "")
           {
               e.Row.Cells[8].Enabled = false;

           }
       }
   }

  
 private void ShowPanel()//显示上传实验报告框
    {
        string script = "document.getElementById('Div1').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
        //this.TextBox18.Text = this.label_AccNum.Text;
        //this.TextBox19.Text = this.label_AccName.Text;
        UpdatePanel4.Update();
    }

    private void ClosePanel()//关闭上传实验报告框
    {
        string script = "document.getElementById('Div1').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel", script, true);
    }
    protected void Button_Aline(object sender, EventArgs e)
    {
        //this.label_Acc.Text="申请";
            ShowPanel();
        UpdatePanel4.Update();

    }

    protected void Button1_Fox(object sender, EventArgs e)
    {
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名

        if (FileUpload1.PostedFile.FileName != "" || FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx" || fileExrensio == ".zip" || fileExrensio == ".rar" || fileExrensio == ".bmp" || fileExrensio == ".jpg" || fileExrensio == ".gif")//判断文件扩展名
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
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "aa", "alert('上传失败!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
            string filePath = "file/" + newname + fullname;
            //if (this.LabelQ_SaveDirectory.Text == "申请")
            //{
                label_AccNum.Text = TextBox18.Text.ToString();
                label_AccName.Text = TextBox19.Text.ToString();
                Label_FilePath.Text = filePath;//相对路径
            //}
            if (label_Acc.Text == "制定")
            {
                Guid PT_ID = new Guid(label_PT_ID.Text.ToString());
                psd.UpdateProType_MAcc(PT_ID,label_AccNum.Text,label_AccName.Text,Label_FilePath.Text);
            }
            TextBox18.Text = "";
            TextBox19.Text = "";
            ClosePanel();
            UpdatePanel4.Update();
        }
    }
    //关闭上传附件
    protected void Button1_Emi(object sender, EventArgs e)
    {
        TextBox18.Text = "";
        TextBox19.Text = "";
        ClosePanel();
        UpdatePanel4.Update();
    }
    protected void Gridview2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PT_SAccPath"].ToString().Trim() == "")
            {
                e.Row.Cells[16].Enabled = false;//查看申请附件

            }
            if (drv["PT_MAccPath"].ToString().Trim() == "")
            {
                e.Row.Cells[17].Enabled = false;//查看制定附件

            }
            if (drv["PT_CSate"].ToString().Trim() == "已提交")
            {
                e.Row.Cells[8].Enabled = false;//编辑
                e.Row.Cells[9].Enabled = false;//删除
                //e.Row.Cells[11].Enabled = false;//制定
               // e.Row.Cells[12].Enabled = false;//会签
                //e.Row.Cells[15].Enabled = false;//上传附件
                e.Row.Cells[10].Enabled = false;//选择会签部门
            }
            if (drv["PT_CSate"].ToString().Trim() == "已制定")
            {
                e.Row.Cells[15].Enabled = false;//上传附件
                e.Row.Cells[8].Enabled = false;//编辑
                e.Row.Cells[9].Enabled = false;//删除
              //  e.Row.Cells[10].Enabled = false;//选择会签部门
              //  e.Row.Cells[12].Enabled = false;//会签
            }
            if (drv["PT_CSate"].ToString().Trim() == "会签中" || drv["PT_CSate"].ToString().Trim() == "会签通过")
            {
                e.Row.Cells[8].Enabled = false;//编辑
                e.Row.Cells[9].Enabled = false;//删除
                e.Row.Cells[10].Enabled = false;//选择会签部门
                e.Row.Cells[11].Enabled = false;//制定
                e.Row.Cells[15].Enabled = false;//上传附件
            }
            if (drv["PT_CSate"].ToString().Trim() == "会签驳回")
            {
                e.Row.Cells[8].Enabled = false;//编辑
                e.Row.Cells[9].Enabled = false;//删除
                e.Row.Cells[10].Enabled = false;//选择会签部门
                //e.Row.Cells[11].Enabled = false;//制定
                //e.Row.Cells[15].Enabled = false;//上传附件
                e.Row.Cells[12].Enabled = false;//会签
            }
        }
    }

}