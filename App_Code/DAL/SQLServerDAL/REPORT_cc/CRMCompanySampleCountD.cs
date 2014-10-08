using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// CRMCompanySampleCountD 的摘要说明
/// </summary>
public class CRMCompanySampleCountD
{
    public DataSet SelectCRMCompanySampleCount(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proc_S_CRMCompanySampleCount", para);
    }
    public DataSet SelectCRMCompanySampleCount_Sum(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proc_S_CRMCompanySampleCount_Sum", para);
    }
}