using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_IQCSum : Page
{
    IQCSumD iqcSumD = new IQCSumD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!(Session["UserRole"].ToString().Contains("IQC检验汇总表")))
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

    protected void BtnSearchMaterial_Click(object sender, EventArgs e)
    {
        Grid_IQCSum.PageIndex = 0;
        DataBindAll();
    }
    protected void BtnPrintReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/IQCSumPrint.aspx?" + "&InStoreTime=" + TxtInStoreTime.Text.Trim() + "&MaterialName=" + TxtMaterialName.Text.Trim() + "&SpecificationModel=" + TxtSpecificationModel.Text.Trim() + "&BatchNum=" + TxtBatchNumber.Text.Trim() + "&SupplyName=" + TxtSupplyName.Text.Trim() + "&Result=" + TxtIQCResult.Text.Trim());
    }
    protected void BtnResetMaterial_Click(object sender, EventArgs e)
    {
        Grid_IQCSum.PageIndex = 0;
        Clear();
        DataBindAll();
    }

    private void DataBindAll()
    {
        string condition;

        string InStoreTime = TxtInStoreTime.Text.Trim() == "" ? " and 1=1 " : " and convert(varchar(10),IMISM_InStoreTime,23) = '" + TxtInStoreTime.Text.Trim()+"'";
        string MaterialName = TxtMaterialName.Text.Trim() == "" ? " and 1=1 " : " and Name like '%" + TxtMaterialName.Text.Trim() + "%' ";
        string SpecificationModel = TxtSpecificationModel.Text.Trim() == "" ? " and 1=1 " : " and Model like '%" + TxtSpecificationModel.Text.Trim() + "%' ";
        string BatchNum = TxtBatchNumber.Text.Trim() == "" ? " and 1=1 " : " and IMISD_BatchNum like '%" + TxtBatchNumber.Text.Trim() + "%' ";
        string SupplyName = TxtSupplyName.Text.Trim() == "" ? " and 1=1 " : " and PMSI_SupplyName like '%" + TxtSupplyName.Text.Trim() + "%' ";
        string Result = TxtIQCResult.Text.Trim() == "" ? " and 1=1 " : " and IQCDT_Result like '%" + TxtIQCResult.Text.Trim() + "%' ";

        condition = InStoreTime + MaterialName + SpecificationModel + BatchNum + SupplyName + Result;
        Grid_IQCSum.DataSource = iqcSumD.SearchIQCSum(condition);
        Grid_IQCSum.DataBind();
        UpdatePanel_IQCSum.Update();
    }

    private void Clear()
    {
        TxtInStoreTime.Text = "";
        TxtMaterialName.Text = "";
        TxtSpecificationModel.Text = "";
        TxtBatchNumber.Text = "";
        TxtSupplyName.Text = "";
        TxtIQCResult.Text = "";
    }
    protected void Grid_IQCSum_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_IQCSum.BottomPagerRow;


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


        //绑定数据源

        //bindgridview();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_IQCSum.PageCount ? Grid_IQCSum.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        Grid_IQCSum.PageIndex = newPageIndex;

        DataBindAll();
    }
}