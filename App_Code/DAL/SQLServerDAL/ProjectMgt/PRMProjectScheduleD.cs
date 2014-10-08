using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PRMProjectScheduleD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PRMProjectScheduleD : IPRMProjectSchedule
    {
        public PRMProjectScheduleD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
  

        public DataSet SelectPRMP_Organization(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_PRMP_Organization",parm);
        }
        public void InsertPRMProjectSchedule(Guid PRMP_ID, string PRMPS_ScheduleName, int PRMPS_ScheduleTime, string PRMPS_ScheduleContent,string PRMPS_ScheduleMakeMan,int PRMPS_Num)
        {
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMP_ID;
            parm[1] = new SqlParameter("@PRMPS_ScheduleName", SqlDbType.VarChar, 200);
            parm[1].Value = PRMPS_ScheduleName;
            parm[2] = new SqlParameter("@PRMPS_ScheduleTime", SqlDbType.Int);
            parm[2].Value = PRMPS_ScheduleTime;
            parm[3] = new SqlParameter("@PRMPS_ScheduleContent", SqlDbType.VarChar, 400);
            parm[3].Value = PRMPS_ScheduleContent;
            
            parm[4] = new SqlParameter("@PRMPS_ScheduleMakeMan", SqlDbType.VarChar, 100);
            parm[4].Value = PRMPS_ScheduleMakeMan;
            parm[5] = new SqlParameter("@PRMPS_Num", SqlDbType.Int );
            parm[5].Value = PRMPS_Num;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_I_PRMProjectSchedule", parm);
        }
        public DataSet  SelectPRMProjectSchedule(Guid PRMP_ID )
        {
            SqlParameter parm = new SqlParameter("@PRMP_ID", PRMP_ID);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProjectSchedule", parm);
        }
        public DataSet SelectPRMProjectSchedule_One(Guid PRMPS_ID)
        {
            SqlParameter parm = new SqlParameter("@PRMPS_ID", PRMPS_ID);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProjectSchedule_One", parm);
        }

        public void  DelectPRMProjectSchedule(Guid PRMPS_ID)
        {
            SqlParameter parm = new SqlParameter("@PRMPS_ID", PRMPS_ID);
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_PRMProjectSchedule", parm);
        }
        public void UpdatePRMProjectSchedule(Guid PRMPS_ID, string PRMPS_ScheduleName, int PRMPS_ScheduleTime, string PRMPS_ScheduleContent, string PRMPS_ProcessMan)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@PRMPS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMPS_ID;
            parm[1] = new SqlParameter("@PRMPS_ScheduleName", SqlDbType.VarChar, 200);
            parm[1].Value = PRMPS_ScheduleName;
            parm[2] = new SqlParameter("@PRMPS_ScheduleTime", SqlDbType.Int);
            parm[2].Value = PRMPS_ScheduleTime;
            parm[3] = new SqlParameter("@PRMPS_ScheduleContent", SqlDbType.VarChar, 400);
            parm[3].Value = PRMPS_ScheduleContent;
            
            parm[4] = new SqlParameter("@PRMPS_ProcessMan", SqlDbType.VarChar, 20);
            parm[4].Value = PRMPS_ProcessMan;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_U_PRMProjectSchedule", parm);
        }
        public DataSet SelectPRMProject_Schedule_One(string condition)
        {
            SqlParameter parm = new SqlParameter("@condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProject_Schedule_One", parm);
        }
    }
}