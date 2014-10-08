using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
/// SalaryEachMonthAnalysisD 的摘要说明
/// </summary>
public class SalaryEachMonthAnalysisD
{
    public DataSet SelectSalaryEachMonthAnalysis(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalaryEachMonthAnalysis", para);
    }
}