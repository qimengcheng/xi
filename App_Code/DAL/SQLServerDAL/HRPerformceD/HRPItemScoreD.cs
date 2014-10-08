using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///HRPItemScoreD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class HRPItemScoreD:IHRPItemScore
    {
        public HRPItemScoreD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet Search_HRDDetail_HRPerformAssessType(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformAssessType_HRDDetail_HRPItemScore", para);
        }
        public int Insert_HRPItemScore(HRPItemScoreInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPItemScore",
                new SqlParameter("@HRPIS_ItemID", hr.HRPIS_ItemID), new SqlParameter("@HRPI_ItemID", hr.HRPI_ItemID),
                new SqlParameter("@HRPD_ID", hr.HRPD_ID), new SqlParameter("@HRPIS_ItemScore", hr.HRPIS_ItemScore),
                new SqlParameter("@HRPIS_ItemFScore", hr.HRPIS_ItemFScore));
        }
        public DataSet Search_HRPerformceItem_HRPerformAssessType_HRPerformceDetail(string condition,Guid ID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            para[1] = new SqlParameter("@HRPD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = ID;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceItem_HRPerformAssessType_HRPerformceDetail", para);
        }

        public int Update_HRPItemScore_CHECK(HRPItemScoreInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPItemScore_CHECK",
                    new SqlParameter("@HRPIS_ItemID", hr.HRPIS_ItemID), new SqlParameter("@HRPIS_ItemFScore", hr.HRPIS_ItemFScore));

        }

        public DataSet Search_HRPItemScore_HRPerformceDetail(Guid HRPD_ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@HRPD_ID", HRPD_ID);
            para[0].Value = HRPD_ID;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPItemScore_HRPerformceDetail", para);
        }

        //添加年份和月份中的查询
        public DataSet Search_HRDDetail_HRPerformAssessType_Year(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceDetail_Year", para);
        }
        
    }
}