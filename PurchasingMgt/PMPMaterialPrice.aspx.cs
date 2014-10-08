using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_PMPMaterialPrice : Page
{
    PMPurchaseingApplyRuleinfo PMPurchaseingApplyRuleinfo = new PMPurchaseingApplyRuleinfo();
    PurchasingPlanL pl = new PurchasingPlanL();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
          string state = Request.QueryString["state"];
            if (state == "Chip")
            {
                Title = "芯片价格录入";
                label_Title.Text = "芯片价格录入";
            }
            if (state == "Other")
            {
                Title = "原材料价格录入";
                label_Title.Text = "原材料价格录入";
            }
            BindDropDownList1();
            Panel_SupplySearch.Visible = true;
        }
    }
    protected void BindDropDownList1()
    {
        DropDownList11.Items.Insert(0, new ListItem("选择月份", "选择月份"));
        DropDownList1.Items.Insert(0, new ListItem("选择年份", "选择年份"));
        for (int y = 1; y <= 12; y++)
        {
            DropDownList11.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }

        for (int m = 2013; m <= 2023; m++)
        {
            DropDownList1.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
    }
    //检索条件获取
    public string GetCondition()
    {
        string conditon;
        string temp = "";
        if (DropDownList1.SelectedValue != "选择年份")
        {
            temp += " and b.PMP_Year like'%" + DropDownList1.SelectedValue.ToString().Trim() + "%'";
        }
        if (DropDownList11.SelectedValue != "选择月份")
        {
            temp += " and b.PMP_Month like'%" + DropDownList11.SelectedValue.ToString().Trim() + "%'";
        }
        conditon = temp;
        return conditon;
    }
    private void BindGriview1(string condition)
    {
        Gridview1.DataSource = pl.SelectIMMaterial_Price_PurchasePlan(condition);
        Gridview1.DataBind();
        int i = 0;
        foreach (GridViewRow item in Gridview1.Rows)
        {
            if (item.Cells[4].Text.ToString() == "&nbsp;")
            {
                i = i + 1;
            }
        }
        labelcodition.Text = Convert.ToString(i);
        label_IMMBD_MaterialID.Text = "剩余" + labelcodition.Text + "种物料没有填写价格！";
    }
    //检索
    protected void Button_Sh1(object sender, EventArgs e)
    {
        if (label_Title.Text=="芯片价格录入")
        {
            string condition = GetCondition() + " and  a.IMMBD_MaterialName='" + "芯片" + "'";
            BindGriview1(condition);
        }
        if (label_Title.Text== "原材料价格录入")
       {
           string condition = GetCondition() + " and  a.IMMBD_MaterialName !='" + "芯片" + "'";
           BindGriview1(condition);
       }
        PanelApplyDetailSummary.Visible = true;
        UpdatePanelApplyDetailSummary.Update();
    }
    //重置
    protected void Button_Reset(object sender, EventArgs e)
    {
        DropDownList1.SelectedValue = "选择年份";
        DropDownList11.SelectedValue = "选择月份";
    }
    //提交
    protected void Button_Com2(object sender, EventArgs e)
    {
        int i = 0;
        foreach (GridViewRow item in Gridview1.Rows)
        {
            TextBox TBox = item.FindControl("TextBox3") as TextBox;
        if(TBox.Text!="")
        {
            PMPurchaseingApplyRuleinfo.IMMBD_MaterialID = new Guid(Gridview1.DataKeys[item.RowIndex].Value.ToString());
            PMPurchaseingApplyRuleinfo.IMMBD_Price = Convert.ToDecimal(TBox.Text.ToString());
            pl.UpdatePMPMaterial_Price(PMPurchaseingApplyRuleinfo);
        }
        TBox.Text = "";
        }
            foreach (GridViewRow item in Gridview1.Rows)
             {
               TextBox TBox = item.FindControl("TextBox3") as TextBox;
               if (TBox.Text.ToString() == "")
               {
                   i = i + 1;
               }
             }
        if(i==Gridview1.Rows.Count)
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请填写物料价格！')", true);
            return;
        }

           if (label_Title.Text == "芯片价格录入")
           {
               string condition = GetCondition() + " and  a.IMMBD_MaterialName='" + "芯片" + "'";
               BindGriview1(condition);
           }
           if (label_Title.Text == "原材料价格录入")
           {
               string condition = GetCondition() + " and  a.IMMBD_MaterialName !='" + "芯片" + "'";
               BindGriview1(condition);
           }
           
           //this.labelcodition.Text = Convert.ToString(i);
           //this.label_IMMBD_MaterialID.Text = "剩余" + this.labelcodition.Text + "种物料没有填写价格！";

        UpdatePanelApplyDetailSummary.Update();
    }
    //重置
    protected void Button_Cancel2(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gridview1.Rows)
        {
            TextBox TBox = item.FindControl("TextBox3") as TextBox;
            TBox.Text = "";
        }
        UpdatePanelApplyDetailSummary.Update();
    }
    protected void Gridview1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        if (Title == "芯片价格录入")
        {
            string condition = GetCondition() + " and IMMaterialBasicData.IMMBD_MaterialName='" + "芯片" + "'";
            BindGriview1(condition);
        }
        if (Title == "原材料价格录入")
        {
            string condition = GetCondition() + " and IMMaterialBasicData.IMMBD_MaterialName !='" + "芯片" + "'";
            BindGriview1(condition);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
}