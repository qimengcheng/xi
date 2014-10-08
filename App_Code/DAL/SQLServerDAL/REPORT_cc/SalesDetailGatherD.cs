using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
/// SalesDetailGatherD 的摘要说明
/// </summary>
public class SalesDetailGatherD
{
    public DataSet SelectSalesDetailGather(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalesDetailGather", para);
    }
    public DataSet SelectSalesDetailGather_Total(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalesDetailGather_Total", para);
    }
}