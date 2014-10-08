using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// TimeDetailSumD 的摘要说明
/// </summary>
public class TimeDetailSumD
{
	public TimeDetailSumD()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SearchTimeDetailSum(int year)
    {
        SqlParameter[] parameters = new SqlParameter[1];
        parameters[0] = new SqlParameter("@year", SqlDbType.SmallInt);
        parameters[0].Value = year;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_S_YearTimeTotalIn12Months", parameters);
    }
}