using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PMPurchaseingApplyRuleD 的摘要说明
/// </summary>
///
namespace EquipmentMangementAjax.SQLServer
{
    public class PMPurchaseingApplyRuleD : IPMPurchaseingApplyRule
    {
        public PMPurchaseingApplyRuleD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public void InsertPMPurchaseingApplyRule(  string PMPAR_Man, string PMPAR_Rule)
        {
            SqlParameter[] parm = new SqlParameter[2];
          
            
            parm[0] = new SqlParameter("@PMPAR_Man", SqlDbType.VarChar,20);
            parm[0].Value = PMPAR_Man;
            parm[1] = new SqlParameter("@PMPAR_Rule", SqlDbType.VarChar,400);
            parm[1].Value = PMPAR_Rule;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_I_PMPurchaseingApplyRule", parm);
        }
        public DataSet SelectPMPurchaseingApplyRule(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPurchaseingApplyRule", parm);
        }
        public DataSet SelectPMPurchaseingApplyRule_One(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPurchaseingApplyRule_One", parm);
        }
        public int DeletePMPurchaseingApplyRule(Guid PMPAR_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPAR_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMPAR_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_D_PMPurchaseingApplyRule", parm);
        }
        public void UpdatePMPurchaseingApplyRule(Guid PMPAR_ID, string PMPAR_Rule)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PMPAR_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMPAR_ID;
            parm[1] = new SqlParameter("@PMPAR_Rule", SqlDbType.VarChar, 400);
            parm[1].Value = PMPAR_Rule;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_U_PMPurchaseingApplyRule", parm);
        }
    }
}