using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// TrainingEachMonthAnalysisD 的摘要说明
/// </summary>
public class TrainingEachMonthAnalysisD
{
    public DataSet SelectTrainingEachMonthAnalysis(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_TrainingEachMonthAnalysis", para);
    }
}