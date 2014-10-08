using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///HRDDetailD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class HRDDetailD : IHRDDetail
    {
        public HRDDetailD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_HRDDetail(HRDDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRDDetail",
                     new SqlParameter("@HRDD_ID", hr.HRDD_ID), new SqlParameter("@HRP_ID ", hr.HRP_ID),
                     new SqlParameter("@HRET_ID ", hr.HRET_ID),
                     new SqlParameter("@HRDD_Name", hr.HRDD_Name), new SqlParameter("@HRDD_Registration ", hr.HRDD_Registration),
                     new SqlParameter("@HRDD_BasicWage", hr.HRDD_BasicWage), new SqlParameter("@HRDD_FullTimeWage ", hr.HRDD_FullTimeWage),
                     new SqlParameter("@HRDD_PerformWage", hr.HRDD_PerformWage), new SqlParameter("@HRDD_OverTimeWage ", hr.HRDD_OverTimeWage),
                     new SqlParameter("@HRDD_ConverseDate", hr.HRDD_ConverseDate), new SqlParameter("@HRDD_ContactSDate ", hr.HRDD_ContactSDate),
                     new SqlParameter("@HRDD_ContactEDate", hr.HRDD_ContactEDate), new SqlParameter("@HRDD_Worklength ", hr.HRDD_Worklength),
                     new SqlParameter("@HRDD_EntryDate", hr.HRDD_EntryDate), new SqlParameter("@HRDD_IDCard  ", hr.HRDD_IDCard),
                     new SqlParameter("@HRDD_Nationality", hr.HRDD_Nationality), new SqlParameter("@HRDD_IsMarried ", hr.HRDD_IsMarried),
                     new SqlParameter("@HRDD_EduBackg", hr.HRDD_EduBackg), new SqlParameter("@HRDD_Major ", hr.HRDD_Major),
                     new SqlParameter("@HRDD_GSchool", hr.HRDD_GSchool), new SqlParameter("@HRDD_HAddress ", hr.HRDD_HAddress),
                     new SqlParameter("@HRDD_Tel", hr.HRDD_Tel), new SqlParameter("@HRDD_HasSocial ", hr.HRDD_HasSocial),
                     new SqlParameter("@HRDD_HasAccumulation", hr.HRDD_HasAccumulation), new SqlParameter("@HRDD_CertificateComplete ", hr.HRDD_CertificateComplete),
                     new SqlParameter("@HRDD_EmergencyPer ", hr.HRDD_EmergencyPer), new SqlParameter("@HRDD_EmergencyNo ", hr.HRDD_EmergencyNo),
                     new SqlParameter("@HRDD_IsDeleted", hr.HRDD_IsDeleted));

        }
        public int Update_HRDDetail(HRDDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRDDetail",
                     new SqlParameter("@HRDD_ID", hr.HRDD_ID), new SqlParameter("@HRP_ID ", hr.HRP_ID),
                     new SqlParameter("@HRDD_StaffNO ", hr.HRDD_StaffNO), new SqlParameter("@HRET_ID ", hr.HRET_ID),
                     new SqlParameter("@HRDD_Name", hr.HRDD_Name), new SqlParameter("@HRDD_Registration ", hr.HRDD_Registration),
                     new SqlParameter("@HRDD_BasicWage", hr.HRDD_BasicWage), new SqlParameter("@HRDD_FullTimeWage ", hr.HRDD_FullTimeWage),
                     new SqlParameter("@HRDD_PerformWage", hr.HRDD_PerformWage), new SqlParameter("@HRDD_OverTimeWage ", hr.HRDD_OverTimeWage),
                     new SqlParameter("@HRDD_ConverseDate", hr.HRDD_ConverseDate), new SqlParameter("@HRDD_ContactSDate ", hr.HRDD_ContactSDate),
                     new SqlParameter("@HRDD_ContactEDate", hr.HRDD_ContactEDate), new SqlParameter("@HRDD_Worklength ", hr.HRDD_Worklength),
                     new SqlParameter("@HRDD_EntryDate", hr.HRDD_EntryDate), new SqlParameter("@HRDD_IDCard  ", hr.HRDD_IDCard),
                     new SqlParameter("@HRDD_Nationality", hr.HRDD_Nationality), new SqlParameter("@HRDD_IsMarried ", hr.HRDD_IsMarried),
                     new SqlParameter("@HRDD_EduBackg", hr.HRDD_EduBackg), new SqlParameter("@HRDD_Major ", hr.HRDD_Major),
                     new SqlParameter("@HRDD_GSchool", hr.HRDD_GSchool), new SqlParameter("@HRDD_HAddress ", hr.HRDD_HAddress),
                     new SqlParameter("@HRDD_Tel", hr.HRDD_Tel), new SqlParameter("@HRDD_HasSocial ", hr.HRDD_HasSocial),
                     new SqlParameter("@HRDD_HasAccumulation", hr.HRDD_HasAccumulation), new SqlParameter("@HRDD_CertificateComplete ", hr.HRDD_CertificateComplete),
                     new SqlParameter("@HRDD_EmergencyPer ", hr.HRDD_EmergencyPer), new SqlParameter("@HRDD_EmergencyNo ", hr.HRDD_EmergencyNo));
        }
        public void Delete_HRDDetail(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HRDDetail", para);
        }
        public DataSet Search_HRDDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRDDetail_Type_Post", para);
        }
        public DataSet SearchByID_HRDDetail_Type_Post(Guid HRDD_ID)
        {
            SqlParameter para = new SqlParameter("@HRDD_ID", HRDD_ID);
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByID_HRDDetail_Type_Post", para);
            
        }
        public DataSet SearchDdl_HRDDetail_BDOrganizationSheet()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_BDOrganizationSheet");
        }
        public DataSet SearchDdl_HRDDetail(string BDOS_Code)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SForDdlist_HRPost", new SqlParameter("@BDOS_Code", BDOS_Code));
        }
        public DataSet SearchDdl_HRDDetail_HREmployeeType()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SForDdlist_HREmployeeType");
        }
        public IList<HRDDetailInfo> SearchByIDPart_HRDDetail(Guid HRDD_ID)
        {
            SqlParameter para = new SqlParameter("@HRDD_ID", HRDD_ID);
            IList<HRDDetailInfo> hRDDetailInfo = new List<HRDDetailInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByIDPart_HRDDetail", para);
            while (sdr.Read())
            {
                hRDDetailInfo.Add(new HRDDetailInfo( new Guid(sdr["HRP_ID"].ToString()),
                   sdr["BDOS_Code"] == DBNull.Value ? "" : sdr["BDOS_Code"].ToString(),
                   sdr["HRDD_StaffNO"] == DBNull.Value ? "" : sdr["HRDD_StaffNO"].ToString(),
                   sdr["HRDD_Name"] == DBNull.Value ? "" : sdr["HRDD_Name"].ToString()));

            }
            return hRDDetailInfo;
        }
        public int Insert_HRPersonnelChangesRecord(HRDDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPersonnelChangesRecord",
                     new SqlParameter("@HRPCR_ID ", hr.HRPCR_ID), new SqlParameter("@HRDD_ID", hr.HRDD_ID),
                     new SqlParameter("@HRPCR_FormerDep ", hr.HRPCR_FormerDep), new SqlParameter("@HRPCR_FormerPost ", hr.HRPCR_FormerPost),
                     new SqlParameter("@HRPCR_Dep", hr.HRPCR_Dep), new SqlParameter("@HRPCR_Post ", hr.HRPCR_Post),
                     new SqlParameter("@HRPCR_Administrator", hr.HRPCR_Administrator),new SqlParameter("@HRPCR_Remarks", hr.HRPCR_Remarks),
                     new SqlParameter("@HRP_ID", hr.HRP_ID));

        }
        public DataSet Search_HRPersonnelChangesRecord(Guid HRDD_ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = HRDD_ID;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPersonnelChangesRecord", para);
        }

        public IList<HRDDetailInfo> SearchByIDPartForSalary_HRDDetail(Guid HRDD_ID)
        {
            SqlParameter para = new SqlParameter("@HRDD_ID", HRDD_ID);
            IList<HRDDetailInfo> hRDDetailInfo = new List<HRDDetailInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByIDPartForSalary_HRDDetail", para);
            while (sdr.Read())
            {
                hRDDetailInfo.Add(new HRDDetailInfo(
                   sdr["HRDD_StaffNO"] == DBNull.Value ? "" : sdr["HRDD_StaffNO"].ToString(),
                   sdr["HRDD_Name"] == DBNull.Value ? "" : sdr["HRDD_Name"].ToString(),
                   sdr["HRDD_BasicWage"] == DBNull.Value ? 0 : (decimal)sdr["HRDD_BasicWage"],
                   sdr["HRDD_FullTimeWage"] == DBNull.Value ? 0 : (decimal)sdr["HRDD_FullTimeWage"],
                   sdr["HRDD_PerformWage"] == DBNull.Value ? 0 : (decimal)sdr["HRDD_PerformWage"],
                   sdr["HRDD_OverTimeWage"] == DBNull.Value ? 0 : (decimal)sdr["HRDD_OverTimeWage"]));

            }
            return hRDDetailInfo;
        }
        public int Insert_HRSalaryRecord(HRDDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRSalaryRecord",
                     new SqlParameter("@HRSR_ID ", hr.HRSR_ID), new SqlParameter("@HRDD_ID", hr.HRDD_ID),
                     new SqlParameter("@HRSR_AdjBasicWage ", hr.HRSR_AdjBasicWage), new SqlParameter("@HRSR_AdjFTWage", hr.HRSR_AdjFTWage),
                     new SqlParameter("@HRSR_AdjPWage", hr.HRSR_AdjPWage), new SqlParameter("@HRSR_AdjOTWage ", hr.HRSR_AdjOTWage),
                     new SqlParameter("@HRSR_ChargePer", hr.HRSR_ChargePer), new SqlParameter("@HRSR_Reason", hr.HRSR_Reason),
                     new SqlParameter("@HRSR_BasicWage", hr.HRSR_BasicWage), new SqlParameter("@HRSR_PWage ", hr.HRSR_PWage),
                     new SqlParameter("@HRSR_FTWage", hr.HRSR_FTWage), new SqlParameter("@HRSR_OTWage", hr.HRSR_OTWage));

        }

        public DataSet Search_HRSalaryRecord(Guid HRDD_ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = HRDD_ID;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRSalaryRecord", para);
        }

        //离职相关
        public int Update_HRDDetail_Quit(HRDDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRDDetail_Quit",
                     new SqlParameter("@HRDD_ID", hr.HRDD_ID), new SqlParameter("@HRP_ID ", hr.HRP_ID),
                     new SqlParameter("@HRDD_StaffNO ", hr.HRDD_StaffNO), new SqlParameter("@HRET_ID ", hr.HRET_ID),
                     new SqlParameter("@HRDD_Name", hr.HRDD_Name), new SqlParameter("@HRDD_Registration ", hr.HRDD_Registration),
                     new SqlParameter("@HRDD_BasicWage", hr.HRDD_BasicWage), new SqlParameter("@HRDD_FullTimeWage ", hr.HRDD_FullTimeWage),
                     new SqlParameter("@HRDD_PerformWage", hr.HRDD_PerformWage), new SqlParameter("@HRDD_OverTimeWage ", hr.HRDD_OverTimeWage),
                     new SqlParameter("@HRDD_ConverseDate", hr.HRDD_ConverseDate), new SqlParameter("@HRDD_ContactSDate ", hr.HRDD_ContactSDate),
                     new SqlParameter("@HRDD_ContactEDate", hr.HRDD_ContactEDate), new SqlParameter("@HRDD_Worklength ", hr.HRDD_Worklength),
                     new SqlParameter("@HRDD_EntryDate", hr.HRDD_EntryDate), new SqlParameter("@HRDD_IDCard  ", hr.HRDD_IDCard),
                     new SqlParameter("@HRDD_Nationality", hr.HRDD_Nationality), new SqlParameter("@HRDD_IsMarried ", hr.HRDD_IsMarried),
                     new SqlParameter("@HRDD_EduBackg", hr.HRDD_EduBackg), new SqlParameter("@HRDD_Major ", hr.HRDD_Major),
                     new SqlParameter("@HRDD_GSchool", hr.HRDD_GSchool), new SqlParameter("@HRDD_HAddress ", hr.HRDD_HAddress),
                     new SqlParameter("@HRDD_Tel", hr.HRDD_Tel), new SqlParameter("@HRDD_HasSocial ", hr.HRDD_HasSocial),
                     new SqlParameter("@HRDD_HasAccumulation", hr.HRDD_HasAccumulation), new SqlParameter("@HRDD_CertificateComplete ", hr.HRDD_CertificateComplete),
                     new SqlParameter("@HRDD_EmergencyPer ", hr.HRDD_EmergencyPer), new SqlParameter("@HRDD_EmergencyNo ", hr.HRDD_EmergencyNo),
            new SqlParameter("@HRDD_EState", hr.HRDD_EState), new SqlParameter("@HRDD_IsDeleted", hr.HRDD_IsDeleted),
            new SqlParameter("@HRDD_QuitTime", hr.HRDD_QuitTime), new SqlParameter("@HRDD_QuitRes", hr.HRDD_QuitRes),
            new SqlParameter("@HRDD_QuitMan", hr.HRDD_QuitMan));
          
        }
        public void Delete_HRDDetail_Quit(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HRDDetail_Quit", para);
        }
        public DataSet Search_HRDDetail_Quit(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRDDetail_Type_Post_Quit", para);
        }
        public DataSet SearchByID_HRDDetail_Type_Post_Quit(Guid HRDD_ID)
        {
            SqlParameter para = new SqlParameter("@HRDD_ID", HRDD_ID);
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_SByID_HRDDetail_Type_Post_Quit", para);

        }
        //增加人员的奖惩
        public int Insert_HRRewardsPublishment(HRDDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRRewardsPublishment",
                     new SqlParameter("@HRDD_ID", hr.HRDD_ID), new SqlParameter("@HRRewards_Type ", hr.HRRewards_Type),
                     new SqlParameter("@HRRewards_Time ", hr.HRRewards_Time), new SqlParameter("@HRRewards_Content ", hr.HRRewards_Content),
                     new SqlParameter("@HRRewards_Note", hr.HRRewards_Note), new SqlParameter("@HRRewards_Money ", hr.HRRewards_Money),
                     new SqlParameter("@HRRewards_Agree ", hr.HRRewards_Agree), new SqlParameter("@HRRewards_OkTime ", hr.HRRewards_OkTime));
        }

        // 修改人员的奖惩
        public int Update_HRRewardsPublishment(HRDDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRRewardsPublishment",
                     new SqlParameter("@HRRewards_ID", hr.HRRewards_ID), new SqlParameter("@HRRewards_Type ", hr.HRRewards_Type),
                     new SqlParameter("@HRRewards_Time ", hr.HRRewards_Time), new SqlParameter("@HRRewards_Content ", hr.HRRewards_Content),
                     new SqlParameter("@HRRewards_Note", hr.HRRewards_Note), new SqlParameter("@HRRewards_Money ", hr.HRRewards_Money),
                     new SqlParameter("@HRRewards_Agree ", hr.HRRewards_Agree), new SqlParameter("@HRRewards_OkTime ", hr.HRRewards_OkTime));
        }

        //删除人员的奖惩
        public void Delete_HRRewardsPublishment(Guid HRRewards_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@HRRewards_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = HRRewards_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HRRewardsPublishment", parm);
        }

        //查询人员的奖惩
        public DataSet Search_HRRewardsPublishment(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_HRRewardsPublishment", parm);
        }
        //一键更新在职员工的工龄
        public int Update_HRDDetail_Worklength()
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRDDetail_Worklength");
        }
        //人员奖惩管理，高级检索奖惩信息
        public DataSet Search_HRDDetail_Type_Post_Senior(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRDDetail_Type_Post_Senior", para);
        }
    }
}