using EquipmentMangementAjax.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// InOutStoreSum 的摘要说明
/// </summary>
public class InOutStoreSum
{
	public InOutStoreSum()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet SearchInOutStoreSum(int year)
    {
        SqlParameter[] parameters = new SqlParameter[1];
        parameters[0] = new SqlParameter("@year", SqlDbType.SmallInt);
        parameters[0].Value = year;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_S_InOutStoreSumSearch", parameters);
    }
}