using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// IQCSumD 的摘要说明
/// </summary>
public class IQCSumD
{
	public IQCSumD()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public DataSet SearchIQCSum(string condition)
    {
        SqlParameter[] parameters = new SqlParameter[1];
        parameters[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
        parameters[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_S_IQCSumReport", parameters);
    }

}