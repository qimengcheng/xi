using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// PMPurchaseApplyMaterial_DepartmentD 的摘要说明
/// </summary>
public class PMPurchaseApplyMaterial_DepartmentD
{
    public DataSet SelectPMPurchaseApplyMaterial_Department(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchaseApplyMaterial_Department", para);
    }
    public DataSet SelectPMPurchaseApplyMaterial_Num(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchaseApplyMaterial_Num", para);
    }
    public DataSet SelectPMPMaterial(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPMaterial", para);
    }
    public DataSet SelectPMPurchaseApplyMaterial_Department_Sum(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchaseApplyMaterial_Department_Sum", para);
    }
}