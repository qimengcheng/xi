using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///HRFilesMgtD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class HRFilesMgtD : IHRFilesMgt
    {
        public HRFilesMgtD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_HRPost(HRFilesMgtInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPost",
                     new SqlParameter("@HRP_ID", hr.HRP_ID), new SqlParameter("@BDOS_Code", hr.BDOS_Code),
                     new SqlParameter("@HRP_Post", hr.HRP_Post), new SqlParameter("@HRP_IsDeleted", hr.HRP_IsDeleted));

        }

        public int Update_HRPost(HRFilesMgtInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPost",
                new SqlParameter("@HRP_ID", hr.HRP_ID), new SqlParameter("@BDOS_Code", hr.BDOS_Code),
                     new SqlParameter("@HRP_Post", hr.HRP_Post));

        }
        public void Delete_HRPost(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HRPost",
                new SqlParameter("@HRP_ID", ID));
        }
        public DataSet Search_HRPost(string BDOS_Name, string HRP_Post)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPost", new SqlParameter("@BDOS_Name", BDOS_Name),
                new SqlParameter("@HRP_Post", HRP_Post));
        }
        public DataSet Search_HRPost()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPostForAll");
        }
        //对组织机构中部门的检索
        public DataSet Search_NETrainingItem_BDOrganizationSheet()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_BDOrganizationSheet");
        }

        //编辑新员工培训项目时，根据主键 检索

        public IList<HRFilesMgtInfo> SearchByID_HRPost_BDOrganizationSheet(Guid HRP_ID)
        {
            SqlParameter para = new SqlParameter("@HRP_ID", HRP_ID);
            IList<HRFilesMgtInfo> hRFilesMgtInfo = new List<HRFilesMgtInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByID_HRPost", para);
            while (sdr.Read())
            {
                hRFilesMgtInfo.Add(new HRFilesMgtInfo(sdr["BDOS_Name"] == DBNull.Value ? "" : sdr["BDOS_Name"].ToString(),
                   sdr["BDOS_Code"] == DBNull.Value ? "" : sdr["BDOS_Code"].ToString(),
                   sdr["HRP_Post"] == DBNull.Value ? "" : sdr["HRP_Post"].ToString()));

            }
            return hRFilesMgtInfo;
        }


    }
}