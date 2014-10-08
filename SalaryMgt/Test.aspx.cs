
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility; 

public partial class SalaryMgt_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (this.FileUpload.HasFile)
        {
            //DataSet set;
            //// 讀取 Excel 資料流並轉換成 DataTable。 

            //set = ImportDataSetFromExcel(this.FileUpload.FileContent,0);
            //this.GridView2.DataSource = set;
            //this.GridView2.DataBind();
            DataSet ds;
            ds = ImportDataSetFromExcel(this.FileUpload.FileContent, 0);

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
            {
                conn.Open();
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = "dbo.SalaryDetailBivariateTable2";
                        //for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                        //{
                        //    sqlbulkcopy.ColumnMappings.Add(ds.Tables[0].Columns[i].ColumnName, ds.Tables[0].Columns[i].ColumnName);
                        //}
                        sqlbulkcopy.WriteToServer(ds.Tables[0]);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
    public static DataSet ImportDataSetFromExcel(Stream excelFileStream, int headerRowIndex)
    {
        DataSet ds = new DataSet();
        HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
        for (int a = 0, b = workbook.NumberOfSheets; a < b; a++)
        {
            HSSFSheet sheet = workbook.GetSheetAt(a) as HSSFSheet;
            DataTable table = new DataTable();

            HSSFRow headerRow = sheet.GetRow(headerRowIndex) as HSSFRow;
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                if (headerRow.GetCell(i) == null || headerRow.GetCell(i).StringCellValue.Trim() == "")
                {
                    // 如果遇到第一个空列，则不再继续向后读取
                    cellCount = i + 1;
                    break;
                }

                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i) as HSSFRow;
                if (row == null || row.GetCell(0) == null || row.GetCell(0).ToString().Trim() == "")
                {
                    // 如果遇到第一个空行，则不再继续向后读取
                    break;
                }

                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        dataRow[j] = row.GetCell(j).ToString();
                    }
                }

                table.Rows.Add(dataRow);
            }
            ds.Tables.Add(table);
        }

        excelFileStream.Close();
        workbook = null;

        return ds;
    }

    /// <summary>
    /// 由DataTable导出Excel
    /// </summary>
    /// <param name="sourceTable">要导出数据的DataTable</param>
    /// <returns>Excel工作表</returns>
    private static Stream ExportDataTableToExcel(DataTable sourceTable, string sheetName)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        HSSFSheet sheet = workbook.CreateSheet(sheetName) as HSSFSheet;
        HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
        // handling header.
        foreach (DataColumn column in sourceTable.Columns)
            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

        // handling value.
        int rowIndex = 1;

        foreach (DataRow row in sourceTable.Rows)
        {
            HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;

            foreach (DataColumn column in sourceTable.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
            }

            rowIndex++;
        }

        workbook.Write(ms);
        ms.Flush();
        ms.Position = 0;

        sheet = null;
        headerRow = null;
        workbook = null;

        return ms;
    }
    /// <summary>
    /// 由DataTable导出Excel
    /// </summary>
    /// <param name="sourceTable">要导出数据的DataTable</param>
    /// <param name="fileName">指定Excel工作表名称</param>
    /// <returns>Excel工作表</returns>
    public static void ExportDataTableToExcel(DataTable sourceTable, string fileName, string sheetName)
    {
        MemoryStream ms = ExportDataTableToExcel(sourceTable, sheetName) as MemoryStream;
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        HttpContext.Current.Response.End();
        ms.Close();
        ms = null;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dataset;
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
        string abc = "e8d9f604-ab06-4897-967b-e63b1157a79c";
        para[0].Value = new Guid(abc);
        
        dataset = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ForDaoChu_SalaryDetailBivariateTable", para);

        string fileName = "工资表.xls";
        DataTable table = dataset.Tables[0];

        ExportDataTableToExcel(table, fileName, "a");
    }
}