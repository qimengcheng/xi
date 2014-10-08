using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_ControlledDocAppHandout : Page
{
    SpareD sd = new SpareD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindGrid_Detail("");
            try
            {
                if (!((Session["UserRole"].ToString().Contains("受控文件分发一览表"))))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    //绑定
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_ControlledDocAppHandout_Print(condition);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_Detail(condition);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (textdep.Text.ToString() != "")
        {
            temp += " and AllDep like '%" + textdep.Text.ToString() + "%'";
        }
        if (textno.Text.ToString() != "")
        {
            temp += " and CDA_DocNO like '%" + textno.Text.Trim() + "%'";
        }
        if (textname.Text.ToString() != "")
        {
            temp += " and CDA_DocName like '%" + textname.Text.Trim() + "%'";
        }
        if (texteditno.Text.ToString() != "")
        {
            temp += " and CDA_EditionNO = '" + texteditno.Text.Trim() + "'";
        }
        //生效时间
        if (laststar.Text.ToString() != "" && lastend.Text.ToString() != "")
        {
            temp += " and CDA_EffectDate >= '" + laststar.Text.Trim() + "' and CDA_EffectDate <= '" + lastend.Text.Trim() + "'";
        }
        if (laststar.Text.ToString() != "" && lastend.Text.ToString() == "")
        {
            temp += " and CDA_EffectDate >= '" + laststar.Text.Trim() + "'";
        }
        if (laststar.Text.ToString() == "" && lastend.Text.ToString() != "")
        {
            temp += " and CDA_EffectDate <= '" + lastend.Text.Trim() + "'";
        }
        if (laststar.Text.ToString() == "" && lastend.Text.ToString() == "")
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        textdep.Text = "";
        textno.Text = "";
        textname.Text = "";
        texteditno.Text = "";
        laststar.Text = "";
        lastend.Text = "";
        //BindGrid_Detail("");
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/ControlledDocAppHandoutPrint.aspx?" + "&CDA_AppDep=" + textdep.Text.ToString() + "&CDA_DocNO=" + textno.Text + "&CDA_DocName=" + textname.Text + "&CDA_EditionNO=" + texteditno.Text + "&laststar=" + laststar.Text + "&lastend=" + lastend.Text );
    }
    //Grid_Detail翻页
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Detail.BottomPagerRow;


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
        BindGrid_Detail(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }



}