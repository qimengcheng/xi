using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///CRMNewCustormDevelopD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class CRMNewCustormDevelopD : ICRMNewCustormDevelop
    {
        public CRMNewCustormDevelopD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查找新客户开发表
        public DataSet SelectCRMNewCustormDevelop(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMNewCustormDevelop", parm);
        }
        //查找客户信息表
        public DataSet SelectCRMCustomerInfo_New()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomerInfo_New");
        }
        //新客户开发表,增加新客户信息
        public void InsertCRMNewCustormDevelop(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
        {
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cRMNewCustormDevelopinfo.CRMCIF_ID;
            parm[1] = new SqlParameter("@CRMNCD_Man", SqlDbType.VarChar,20);
            parm[1].Value = cRMNewCustormDevelopinfo.CRMNCD_Man;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_CRMNewCustormDevelop", parm);
        }
        //修改新客户开发表,新客户信息
        public void UpdateCRMNewCustormDevelop_Info(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
        {
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cRMNewCustormDevelopinfo.CRMCIF_ID;
            parm[1] = new SqlParameter("@CRMNCD_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = cRMNewCustormDevelopinfo.CRMNCD_ID;

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_CRMNewCustormDevelop_Info", parm);
        }
        //新客户开发表,填写开发进度(未完)
        public void UpdateCRMNewCustormDevelop_Schedule(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
        {
            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@CRMNCD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cRMNewCustormDevelopinfo.CRMNCD_ID;
            parm[1] = new SqlParameter("@CRMNCD_DevelopState", SqlDbType.VarChar,60);
            parm[1].Value = cRMNewCustormDevelopinfo.CRMNCD_DevelopState;
            parm[2] = new SqlParameter("@CRMNCD_DetailCondition", SqlDbType.VarChar,200);
            parm[2].Value = cRMNewCustormDevelopinfo.CRMNCD_DetailCondition;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_CRMNewCustormDevelop_Schedule", parm);
        }
        //新客户开发表,删除新客户
        public void DeleteCRMNewCustormDevelop(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@CRMNCD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = cRMNewCustormDevelopinfo.CRMNCD_ID;

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_D_CRMNewCustormDevelop", parm);
        }
    }
}