using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
/// <summary>
/// OrderReturnD 的摘要说明
/// </summary>
public class OrderReturnD
{
    public DataSet SelectOrderReturn(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_OrderReturn", para);
    }
    public DataSet SelectOrderReturn_Sum(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proc_S_OrderReturn_Sum", para);
    }
}