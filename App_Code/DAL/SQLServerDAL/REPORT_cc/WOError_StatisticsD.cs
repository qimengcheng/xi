using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
/// WOError_StatisticsD 的摘要说明
/// </summary>
public class WOError_StatisticsD
{
    public DataSet SelectWOError_Statistics(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_WOError_Statistics", para);
    }
}