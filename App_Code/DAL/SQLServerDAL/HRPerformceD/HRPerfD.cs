using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///HRPerfD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class HRPerfD:IHRPtype
    {
        public HRPerfD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_HRPerformAssessType(HRPtypeInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPerformAssessType_HRPAT_PType",
                new SqlParameter("@HRPAT_ID", hr.HRPAT_ID), new SqlParameter("@HRPAT_PType", hr.HRPAT_PType),
                new SqlParameter("@HRPAT_APerson",hr.HRPAT_APerson),new SqlParameter("@HRPAT_CPerson",hr.HRPAT_CPerson),
                new SqlParameter("@HRPAT_IsDeleted", hr.HRPAT_IsDeleted), new SqlParameter("@HRPAT_M_State", hr.HRPAT_M_State));
        }
        public void Delete_HRPerformAssessType(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HRPerformAssessType_HRDDetail_All",
                new SqlParameter("@HRPAT_ID", ID));
        }
        public DataSet Search_HRPerformAssessType(string HRPAT_Type)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformAssessType", new SqlParameter("@HRPAT_PType", HRPAT_Type));
        }
        //编辑考核类型时，根据主键 检索

        public IList<HRPtypeInfo> SearchByID_HRPerformAssessType(Guid HRPAT_ID)
        {
            SqlParameter para = new SqlParameter("@HRPAT_ID", HRPAT_ID);
            IList<HRPtypeInfo> hRPtypeInfo = new List<HRPtypeInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformAssessType_ByID", para);
            while (sdr.Read())
            {
                hRPtypeInfo.Add(new HRPtypeInfo(sdr["HRPAT_PType"] == DBNull.Value ? "" : sdr["HRPAT_PType"].ToString(),
                   sdr["HRPAT_APerson"] == DBNull.Value ? "" : sdr["HRPAT_APerson"].ToString(),
                   sdr["HRPAT_CPerson"] == DBNull.Value ? "" : sdr["HRPAT_CPerson"].ToString(),
                   sdr["HRPAT_M_State"] == DBNull.Value ? "" : sdr["HRPAT_M_State"].ToString()));

            }
            return hRPtypeInfo;
        }

        public int Update_HRPerformAssessType(HRPtypeInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformAssessType",
                new SqlParameter("@HRPAT_ID", hr.HRPAT_ID), new SqlParameter("@HRPAT_PType", hr.HRPAT_PType));

        }

        public int Update_HRPerformAssessType_Person(HRPtypeInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformAssessType_Person",
                new SqlParameter("@HRPAT_ID", hr.HRPAT_ID), new SqlParameter("@HRPAT_PType", hr.HRPAT_PType),
                new SqlParameter("@HRPAT_APerson", hr.HRPAT_APerson), new SqlParameter("@HRPAT_CPerson", hr.HRPAT_CPerson),
                new SqlParameter("@HRPAT_M_State", hr.HRPAT_M_State));

        }//更新考核类型的考核人和审核人
        public void Delete_HRPerformAssessType_HRDDetail(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HRPerformAssessType_HRDDetail",
                new SqlParameter("@HRDD_ID", ID));
        }//删除考核类型下的员工
        public int Insert_HRPerformAssessType_HRDDetail(Guid HRDD_ID, Guid HRPAT_ID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPerformAssessType_HRDDetail",
                new SqlParameter("@HRDD_ID", HRDD_ID), new SqlParameter("@HRPAT_ID", HRPAT_ID));
        }//新增考核类型下的员工
    }
}