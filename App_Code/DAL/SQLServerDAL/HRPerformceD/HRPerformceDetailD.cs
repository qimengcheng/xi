using System;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///HRPerformceDetailD 的摘要说明
/// </summary>
/// 
namespace EquipmentMangementAjax.SQLServer
{
    public class HRPerformceDetailD : IHRPerformceDetail
    {
        public HRPerformceDetailD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public int Insert_HRPerformceDetail(HRPerformceDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPerformceDetail",
                    new SqlParameter("@HRPD_ID", hr.HRPD_ID), new SqlParameter("@HRDD_ID", hr.HRDD_ID),
                    new SqlParameter("@HRPYear_ID", hr.HRPYear_ID),
                    new SqlParameter("@HRPD_APerson", hr.HRPD_APerson), new SqlParameter("@HRPD_Atime", hr.HRPD_Atime),                   
                    new SqlParameter("@HRPD_FinalScore", hr.HRPD_FinalScore), new SqlParameter("@HRPD_Year", hr.HRPD_Year),
                    new SqlParameter("@HRPD_Month", hr.HRPD_Month), 
                    new SqlParameter("@HRPD_State", hr.HRPD_State),
                    new SqlParameter("@HRPD_AState",hr.HRPD_AState));
        }
        public int Insert_HRPerformceDetail_HRDD_ID(Guid HRDD_ID, string HRPD_APerson, DateTime HRPD_Atime)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPerformceDetail_HRDD_ID",
                     new SqlParameter("@HRDD_ID",HRDD_ID),
                     new SqlParameter("@HRPD_APerson",HRPD_APerson), new SqlParameter("@HRPD_Atime",HRPD_Atime));
        }

        public DataSet Search_HRPerformAssessType_HRDDetail_HRPerformceDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformAssessType_HRDDetail_HRPerformceDetail", para);
        }

        public int Update_HRPerformceDetail(HRPerformceDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformceDetail",
                    new SqlParameter("@HRPD_ID", hr.HRPD_ID), new SqlParameter("@HRDD_ID", hr.HRDD_ID),
                    new SqlParameter("@HRPD_APerson", hr.HRPD_APerson), new SqlParameter("@HRPD_Atime", hr.HRPD_Atime),
                    
                    new SqlParameter("@HRPD_FinalScore", hr.HRPD_FinalScore), new SqlParameter("@HRPD_Year", hr.HRPD_Year),
                    new SqlParameter("@HRPD_Month", hr.HRPD_Month), 
                    new SqlParameter("@HRPD_State", hr.HRPD_State),
                    new SqlParameter("@HRPD_AState",hr.HRPD_AState));

        }

        public int Update_HRPerformceDetail_CHECK(HRPerformceDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformceDetail_CHECK",
                    new SqlParameter("@HRPD_ID", hr.HRPD_ID), new SqlParameter("@HRPD_Auditor", hr.HRPD_Auditor),
                    new SqlParameter("@HRPD_AuTime", hr.HRPD_AuTime), new SqlParameter("@HRPD_C_FinalScore", hr.HRPD_C_FinalScore),
                    new SqlParameter("@HRPD_State", hr.HRPD_State));

        }

        public DataSet Search_HRDDetail_HRPerformceDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceDetail", para);
        }

        public DataSet Search_HRPerformceDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceYear", para);
        }
    }
}