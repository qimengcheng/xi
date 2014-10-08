using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EquipmentMangementAjax.DBUtility;
/// <summary>
/// OrderDeliverD 的摘要说明
/// </summary>
public class OrderDeliverD
{
    public DataSet SelectOrderDeliver(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proc_S_OrderDeliver", para);
    }
    public DataSet SelectOrderDeliver_Sum(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proc_S_OrderDeliver_Sum", para);
    }
    public DataSet SelectKucunDetail(string id)
    {
        SqlParameter para = new SqlParameter("@condition", id);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMIDetailSum", para);
    }
         public DataSet SelectKucunMain(string condition)
    {
        SqlParameter para = new SqlParameter("@condiiton", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMIM_MAT_PT", para);
    }
}