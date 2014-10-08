using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductionProcess_SMSCWOPrint : Page
{
    private readonly WorkOrderPrintD wo = new WorkOrderPrintD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["WO_Num"] == null)
        {
            wonum3.Text = "";
            Label21.Text = "";
        }
        else
        {
            wonum3.Text = "*" + Request.QueryString["WO_Num"] + "*";
            Label21.Text = Request.QueryString["WO_Num"];
        }
        if (Request.QueryString["WO_Type"] == null)
        {
            Label_WO_Type.Text = "正常";
        }
        else
        {
            Label_WO_Type.Text = Request.QueryString["WO_Type"];
        }

        if (Request.QueryString["SMSO_CusOrderNum"] == null) //订单号
        {
            Label23.Text = "";
        }
        else
        {
            Label23.Text = Request.QueryString["SMSO_CusOrderNum"];
        }

        if (Request.QueryString["SMSO_PlaceOrderTime"] == null) //订单日期
        {
            Label27.Text = "";
        }
        else
        {
            Label27.Text = Request.QueryString["SMSO_PlaceOrderTime"];
        }

        if (Request.QueryString["WO_SN"] == null) //周期码
        {
            Label24.Text = "";
        }
        else
        {
            Label24.Text = Request.QueryString["WO_SN"];
        }
        if (Request.QueryString["CB"] == null) //芯片批号
        {
            Label30.Text = "";
        }
        else
        {
            Label30.Text = Request.QueryString["CB"];
        }

        if (Request.QueryString["PS"] == null) //芯片批号
        {
            Label2.Text = "";
        }
        else
        {
            Label2.Text = Request.QueryString["PS"];
        }

        if (Request.QueryString["WO_ProType"].Contains("桥壳"))
        {
           GridView2.RowStyle.Font.Size = 15;
           GridView2.RowStyle.Height = 70;
           GridView2.RowStyle.Font.Bold = true;
           GridView2.HeaderStyle.Font.Size = 15;
           GridView3.RowStyle.Font.Size = 15;
           GridView3.RowStyle.Height = 70;
           GridView3.HeaderStyle.Font.Size = 15;
           GridViewBatchNum.RowStyle.Font.Size = 15;
           GridViewBatchNum.RowStyle.Height = 70;
           GridViewBatchNum.HeaderStyle.Font.Size = 15;
        }
        Title = "随工单打印";
        int rz = 0;
        if (Label_WO_Type.Text.Trim() == "检验" || Label_WO_Type.Text.Trim() == "样品")
        {
            rz = 1;
            Label20.Text = "以下为品保部随工单的工艺路线，与常规产品路线不同";
        }
        else
        {
            rz = 0;
        }

        GridView2.DataSource = wo.Query_PBCraftInfo(Label21.Text.Trim(), rz);
        GridView2.DataBind();


        var dtTable = new DataTable();

        var dc = new DataColumn();

        dc = dtTable.Columns.Add("ID", Type.GetType("System.Int32"));
        DataRow drRow = dtTable.NewRow();
        drRow["ID"] = 0;
        dtTable.Rows.Add(drRow);
        GridView3.DataSource = dtTable;
        GridView3.DataBind();
        DataSet ds = wo.Query_PrintInfo(Label21.Text.Trim());

        DataSet dsImage = wo.Query_Image(Request.QueryString["WO_ProType"]);
        if (dsImage.Tables[0].Rows.Count > 0)
            TempImage.ImageUrl = dsImage.Tables[0].Rows[0]["TmpUpload_ImgUrl"].ToString();
        else
            TempImage.ImageUrl = "";
        #region 批号表

        SqlDataReader reader = wo.Query_BatchNum(Label21.Text.Trim());
        var dt = new DataTable();
        while (reader.Read())
        {
            var dc2 = new DataColumn();
            dc2.ColumnName = reader["BatchClass"].ToString();
            if (!dc2.ColumnName.Contains("料管") && !dc2.ColumnName.Contains("外箱") && !dc2.ColumnName.Contains("内盒") && !dc2.ColumnName.Contains("海绵"))
            {
                dt.Columns.Add(dc2);
            }
        }
        DataRow dr = dt.NewRow();
        for (int i = 0; i < dr.ItemArray.Length; i++)
        {
            if (dt.Columns[i].ColumnName=="芯片批号")
            {
                dr[i] = Label30.Text;
            }
            else
            {
                   dr[i] = " ";
            }
         
        }
        dt.Rows.Add(dr);
        var ds2 = new DataSet();
        ds2.Tables.Add(dt);

        GridViewBatchNum.DataSource = ds2;
        GridViewBatchNum.DataBind();

        #endregion

        try
        {
            Label13.Text = ds.Tables[0].Rows[0]["PT_Parameters"].ToString();
        }
        catch
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('没有相关随工单！')", true);
        }
        try
        {
            Label3.Text = Session["UserName"].ToString();
        }
        catch
        {
            Response.Redirect("~/Default.aspx");
        }
        Label26.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        TextBox1.Text = ds.Tables[0].Rows[0]["WO_Note"].ToString();
        Label31.Text = ds.Tables[0].Rows[0]["WO_PrintWord"].ToString();
        Label32.Text = ds.Tables[0].Rows[0]["WO_PNum"].ToString();
        Label22.Text = ds.Tables[0].Rows[0]["WO_ProType"].ToString();
        Label13.Text = ds.Tables[0].Rows[0]["WO_PT_Code"].ToString();
        //Label29.Text = ds.Tables[0].Rows[0]["WO_PT_ChipType"].ToString();
        Label30.Text = ds.Tables[0].Rows[0]["WO_PrintWord"].ToString();
        Label1.Text = ds.Tables[0].Rows[0]["PT_Parameters"].ToString() == ""
            ? "    ": ds.Tables[0].Rows[0]["PT_Parameters"].ToString();
        TextBox1.ReadOnly = true;
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Label_WO_Type.Text.Trim() == "检验" || Label_WO_Type.Text.Trim() == "样品")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var drv = (DataRowView) e.Row.DataItem;
                if (drv["PRD_RenZhengOrder"].ToString().Trim() != "")
                {
                    e.Row.BackColor = Color.SkyBlue;
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SqlDataReader reader = wo.Query_BBT2(new Guid(e.Row.Cells[13].Text), Label21.Text.Trim());
            var dt = new DataTable();
            while (reader.Read())
            {
                var dc = new DataColumn();
                dc.ColumnName = reader["BPT_Name"].ToString();
                dt.Columns.Add(dc);
            }
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dr.ItemArray.Length; i++) dr[i] = " ";
            dt.Rows.Add(dr);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            var gv = e.Row.Cells[11].FindControl("gridviewc") as GridView;
            gv.DataSource = ds;
            gv.DataBind();
            if (Request.QueryString["WO_ProType"].Contains("桥壳"))
            {
                gv.RowStyle.Height = 42;
                gv.RowStyle.Font.Size = 15;
                gv.HeaderStyle.Font.Size = 15;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductionProcess/WorkOrderCreate.aspx");
    }
}