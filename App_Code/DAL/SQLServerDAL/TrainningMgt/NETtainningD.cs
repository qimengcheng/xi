using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;




/// <summary>
///NETtainningD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class NETtainningD : INETtainning
    {
        public NETtainningD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //新增新员工培训项目的DAL函数
        public int Insert_NETrainingItem(NETtainningInfo nETtainningInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_NETrainingItem",
                     new SqlParameter("@NETI_ID", nETtainningInfo.NETI_ID), new SqlParameter("@BDOS_Code", nETtainningInfo.BDOS_Code),
                     new SqlParameter("@NETI_TraningCourse", nETtainningInfo.NETI_TraningCourse), new SqlParameter("@NETI_TraningType", nETtainningInfo.NETI_TraningType),
                     new SqlParameter("@NETI_CreditHours", nETtainningInfo.NETI_CreditHours), new SqlParameter("@NETI_IsDeleted", nETtainningInfo.NETI_IsDeleted));

        }
        //编辑新员工培训项目
        public int Update_NETrainingItem(NETtainningInfo nETtainningInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_NETrainingItem",
                new SqlParameter("@NETI_ID", nETtainningInfo.NETI_ID), new SqlParameter("@BDOS_Code", nETtainningInfo.BDOS_Code),
                     new SqlParameter("@NETI_TraningCourse", nETtainningInfo.NETI_TraningCourse), new SqlParameter("@NETI_TraningType", nETtainningInfo.NETI_TraningType),
                     new SqlParameter("@NETI_CreditHours", nETtainningInfo.NETI_CreditHours));

        }
        //假删除新员工培训项目
        public bool Delete_NETrainingItem(Guid _NETI_ID)
        {
            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_NETrainingItem",
                new SqlParameter("@NETI_ID", _NETI_ID)) > 0)
                return true;
            else
                return false;

        }
        //对新员工培训项目进行的模糊检索
        public DataSet Search_NETrainingItem(string _BDOS_Name, string _NETI_TraningCourse, string _NETI_TraningType)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_NETrainingItem", new SqlParameter("@BDOS_Name", _BDOS_Name),
                new SqlParameter("@NETI_TraningCourse", _NETI_TraningCourse), new SqlParameter("@NETI_TraningType", _NETI_TraningType));
        }

        //页面加载时的默认检索
        public DataSet Search_NETrainingItem()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_NETrainingItem_BDOrganizationSheet");
        }
        //对组织机构中部门的检索
        public DataSet Search_NETrainingItem_BDOrganizationSheet()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_BDOrganizationSheet");
        }
        //编辑新员工培训项目时，根据主键 检索

        public IList<NETtainningInfo> SearchByID_NETrainingItem_BDOrganizationSheet(Guid NETI_ID)
        {
            SqlParameter para = new SqlParameter("@NETI_ID", NETI_ID);
            IList<NETtainningInfo> nETtainningInfo = new List<NETtainningInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByID_BDOrganizationSheet", para);
            while (sdr.Read())
            {
                nETtainningInfo.Add(new NETtainningInfo(sdr["BDOS_Name"] == DBNull.Value ? "" : sdr["BDOS_Name"].ToString(),
                   sdr["BDOS_Code"] == DBNull.Value ? "" : sdr["BDOS_Code"].ToString(),
                   sdr["NETI_TraningCourse"] == DBNull.Value ? "" : sdr["NETI_TraningCourse"].ToString(),
                   sdr["NETI_TraningType"] == DBNull.Value ? "" : sdr["NETI_TraningType"].ToString(),
                   sdr["NETI_CreditHours"] == DBNull.Value ? 0 : (decimal)sdr["NETI_CreditHours"]));

            }
            return nETtainningInfo;
        }
    }
}