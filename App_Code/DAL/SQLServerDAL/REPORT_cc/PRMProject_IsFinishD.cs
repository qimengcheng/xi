using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// PRMProject_IsFinishD 的摘要说明
/// </summary>
public class PRMProject_IsFinishD
{
    public DataSet SelectPRMProject_IsFinish(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PRMProject_IsFinish", para);
    }
}