using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;
/// <summary>
///HRPItemD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class HRPItemD : IHRPItem
    {
        public HRPItemD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_HRPerformceItem(HRPItemInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPerformceItem",
                new SqlParameter("@HRPI_ItemID", hr.HRPI_ItemID), new SqlParameter("@HRPAT_ID", hr.HRPAT_ID),
                new SqlParameter("@HRPI_Items", hr.HRPI_Items), new SqlParameter("@HRPI_Contents", hr.HRPI_Contents),
                new SqlParameter("@HRPI_StanScore", hr.HRPI_StanScore), new SqlParameter("@HRPI_AssStandard", hr.HRPI_AssStandard),
                new SqlParameter("@HRPI_Remarks", hr.HRPI_Remarks), new SqlParameter("@HRPI_IsDeleted", hr.HRPI_IsDeleted));
        }
        public void Delete_HRPerformceItem(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HRPerformceItem",
            new SqlParameter("@HRPI_ItemID", ID));
        }
        public DataSet Search_HRPerformceItem(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceItem", para);
        }
        public int Update_HRPerformceItem(HRPItemInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformceItem",
                new SqlParameter("@HRPI_ItemID", hr.HRPI_ItemID), new SqlParameter("@HRPAT_ID", hr.HRPAT_ID),
                new SqlParameter("@HRPI_Items", hr.HRPI_Items), new SqlParameter("@HRPI_Contents", hr.HRPI_Contents),
                new SqlParameter("@HRPI_StanScore", hr.HRPI_StanScore), new SqlParameter("@HRPI_AssStandard", hr.HRPI_AssStandard),
                new SqlParameter("@HRPI_Remarks", hr.HRPI_Remarks));
        }

        //编辑考核项目时，根据主键 检索

        public IList<HRPItemInfo> SearchByID_HRPItem(Guid HRPI_ItemID)
        {
            SqlParameter para = new SqlParameter("@HRPI_ItemID", HRPI_ItemID);
            IList<HRPItemInfo> hRPItemInfo = new List<HRPItemInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByID_HRPItem", para);
            while (sdr.Read())
            {
                hRPItemInfo.Add(new HRPItemInfo(sdr["HRPI_Items"] == DBNull.Value ? "" : sdr["HRPI_Items"].ToString(),
                   sdr["HRPI_Contents"] == DBNull.Value ? "" : sdr["HRPI_Contents"].ToString(),
                   sdr["HRPI_StanScore"] == DBNull.Value ? "" : sdr["HRPI_StanScore"].ToString(),
                   sdr["HRPI_AssStandard"] == DBNull.Value ? "" : sdr["HRPI_AssStandard"].ToString(),
                   sdr["HRPI_Remarks"] == DBNull.Value ? "" : sdr["HRPI_Remarks"].ToString()));

            }
            return hRPItemInfo;
        }

        public DataSet Search_HRPerformceItem_HRPerformAssessType(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceItem_HRPerformAssessType", para);
        }
         

    }
}