using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///ProductionWeekPlanD 的摘要说明
/// </summary>
/// 

namespace EquipmentMangementAjax.SQLServer
{
    public class ProductionWeekPlanD
    {
        public ProductionWeekPlanD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet S_PWPDetail_ProSeriesNum(Guid sMSWPM_ID) //检索计划中产品系列数量
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = sMSWPM_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PWPDetail_ProSeriesNum", para);

        }

        public DataSet S_PWP(string condition) //检索生产周计划主表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PWP", para);

        }

        public DataSet S_ProType_PWPDetail(Guid smswpmid, Guid ptid) //检查插入生产周计划的产品型号是否重复
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMSWPM_ID ", SqlDbType.UniqueIdentifier);
            para[0].Value = smswpmid;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = ptid;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProType_PWPDetail", para);

        }

        public DataSet S_PWPDetail(string condition,string linenum) //检索生产周计划信息表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            if (linenum== "0")
            {
                para[0].Value = condition + "and  PS_Name!='模块部新产品'";

            }
            else
            {
                para[0].Value = condition + "and  PS_Name='模块部新产品'";
            }
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PWPDetail", para);

        }

        public void I_PWP(ProductionWeekPlanInfo productionweekPlanInfo) //插入生产周计划
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = productionweekPlanInfo.SMSWPM_ID;
            parm[1] = new SqlParameter("@PWP_Year", SqlDbType.SmallInt);
            parm[1].Value = productionweekPlanInfo.PWP_Year;
            parm[2] = new SqlParameter("@PWP_Month", SqlDbType.TinyInt);
            parm[2].Value = productionweekPlanInfo.PWP_Month;
            parm[3] = new SqlParameter("@PWP_STime", SqlDbType.Date);
            parm[3].Value = productionweekPlanInfo.PWP_STime;
            parm[4] = new SqlParameter("@PWP_ETime", SqlDbType.Date);
            parm[4].Value = productionweekPlanInfo.PWP_ETime;
            parm[5] = new SqlParameter("@PWP_Man", SqlDbType.VarChar, 20);
            parm[5].Value = productionweekPlanInfo.PWP_Man;
            parm[6] = new SqlParameter("@linenum", SqlDbType.Int);
            parm[6].Value = productionweekPlanInfo.Linenum;
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_I_PWP", parm);
        }
        public DataSet S_Review(Guid pwpid)
        {

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@pwpid", SqlDbType.UniqueIdentifier);
            para[0].Value = pwpid;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                           CommandType.StoredProcedure, "Proc_S_PWP_Review", para);
        }
        public int U_PWP(ProductionWeekPlanInfo productionweekPlanInfo) //编辑生产周计划
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PWP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = productionweekPlanInfo.PWP_ID;
            parm[1] = new SqlParameter("@PWP_STime", SqlDbType.Date);
            parm[1].Value = productionweekPlanInfo.PWP_STime;
            parm[2] = new SqlParameter("@PWP_ETime", SqlDbType.Date);
            parm[2].Value = productionweekPlanInfo.PWP_ETime;
            parm[3] = new SqlParameter("@PWP_Man", SqlDbType.VarChar, 20);
            parm[3].Value = productionweekPlanInfo.PWP_Man;
           int a
            =SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_U_PWP", parm);
            return a;
        }

        public void U_PWP_State(Guid pwpid) //编辑生产周计划状态
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PWP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pwpid;
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_U_PWP_State", parm);
        }

        public void U_PWP_Review(ProductionWeekPlanInfo productionWeekPlanInfo) //审核生产周计划
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@pwpid", SqlDbType.UniqueIdentifier);
            parm[0].Value = productionWeekPlanInfo.PWP_ID;
            parm[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            parm[1].Value = productionWeekPlanInfo.PWP_RMan;
            parm[2] = new SqlParameter("@view", SqlDbType.VarChar, 400);
            parm[2].Value = productionWeekPlanInfo.PWP_Suggstion;
            parm[3] = new SqlParameter("@result", SqlDbType.VarChar, 20);
            parm[3].Value = productionWeekPlanInfo.PWP_State;
            parm[4] = new SqlParameter("@pwpcid", SqlDbType.UniqueIdentifier);
            parm[4].Value = productionWeekPlanInfo.PWPCID;

            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_U_PWP_Review", parm);
        }

        public void U_PWPDetail(Guid pWPD_ID, int pWPD_Plan, string pWPD_Note) //制定生产周详细计划
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@PWPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pWPD_ID;
            parm[1] = new SqlParameter("@PWPD_Plan", SqlDbType.Int);
            parm[1].Value = pWPD_Plan;
            parm[2] = new SqlParameter("@PWPD_Note ", SqlDbType.VarChar, 100);
            parm[2].Value = pWPD_Note;
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_U_PWPDetail", parm);
        }

        public void U_PWPDetail_Day(Guid pWPD_ID, int pWPD_D1, int pWPD_D2, int pWPD_D3, int pWPD_D4, int pWPD_D5,
            int pWPD_D6, string pWPD_Note) //制定生产周详细天计划
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@PWPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pWPD_ID;
            parm[1] = new SqlParameter("@PWPD_D1", SqlDbType.Int);
            parm[1].Value = pWPD_D1;
            parm[2] = new SqlParameter("@PWPD_D2", SqlDbType.Int);
            parm[2].Value = pWPD_D2;
            parm[3] = new SqlParameter("@PWPD_D3", SqlDbType.Int);
            parm[3].Value = pWPD_D3;
            parm[4] = new SqlParameter("@PWPD_D4", SqlDbType.Int);
            parm[4].Value = pWPD_D4;
            parm[5] = new SqlParameter("@PWPD_D5", SqlDbType.Int);
            parm[5].Value = pWPD_D5;
            parm[6] = new SqlParameter("@PWPD_D6", SqlDbType.Int);
            parm[6].Value = pWPD_D6;
            parm[7] = new SqlParameter("@PWPD_Note ", SqlDbType.VarChar, 100);
            parm[7].Value = pWPD_Note;
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_U_PWPDetail_Day", parm);
        }

        public void I_ProType_PWPDetail(Guid sMSWPM_ID, Guid pT_ID, Guid pWP_ID) //插入新的产品型号到生产周计划详细表
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = sMSWPM_ID;
            parm[1] = new SqlParameter("@pT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pT_ID;
            parm[2] = new SqlParameter("@PWP_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = pWP_ID;
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_I_ProType_PWPDetail", parm);
        }

        public DataSet S_PWP(int Year, int Month, int Week, string State, string sman, string man, DateTime sstime,
            DateTime setime, DateTime stime, DateTime etime, int linenum)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@year", SqlDbType.SmallInt)
                {Value = Year},

                new SqlParameter("@month", SqlDbType.TinyInt)
                {Value = Month},
                new SqlParameter("@week", SqlDbType.TinyInt)
                {Value = Week},
                new SqlParameter("@state", SqlDbType.VarChar, 20)
                {Value = State},
                new SqlParameter("@sstime", SqlDbType.DateTime)
                {Value = sstime},
                new SqlParameter("@setime", SqlDbType.DateTime)
                {Value = setime},
                new SqlParameter("@stime", SqlDbType.DateTime)
                {Value = stime},
                new SqlParameter("@etime", SqlDbType.DateTime)
                {Value = etime},
                new SqlParameter("@sman", SqlDbType.VarChar, 20)
                {Value = sman},
                new SqlParameter("@man", SqlDbType.VarChar, 20)
                {Value = man},
                new SqlParameter("@linenum", SqlDbType.Int)
                {Value = linenum},
            };
            DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_PWP", para);
            return ds;
        }
    }
}