using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///ProductionPlanD 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class ProductionPlanD
    {
        public ProductionPlanD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }


        public DataSet S_ProType_PMPDetail(Guid MonthPlanID, Guid PT_ID, string neworold)//判断插入新的产品型号到生产月计划详细表是否重复
        {

            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = PT_ID;
            para[2] = new SqlParameter("@neworold", SqlDbType.Char, 3);
            para[2].Value = neworold;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                           CommandType.StoredProcedure, "Proc_S_ProType_PMPDetail", para);
        }
        public DataSet S_Review(Guid pmpid)
        {

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@pmpid", SqlDbType.UniqueIdentifier);
            para[0].Value = pmpid;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                           CommandType.StoredProcedure, "Proc_S_PMP_Review", para);
        }


        public void Insert_I_ProType_PMPDetail(Guid MonthPlanID, Guid PT_ID, string neworold, string man)//插入新的产品型号到生产月计划详细表
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = PT_ID;
            para[2] = new SqlParameter("@neworold", SqlDbType.Char, 3);
            para[2].Value = neworold;
            para[3] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[3].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProType_PMPDetail", para);
        }
        public DataSet Select_ProType(string condition, string proline)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            if (proline == "0")
            {
                para[0].Value = condition + "and  PS_Name!='模块部新产品'";

            }
            else
            {
                para[0].Value = condition + "and  PS_Name='模块部新产品'";
            }
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProType", para);
        }

        public void U_PMP_State(Guid pmpid)//提交生产月计划
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pmpid;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMP_State", parm);
        }


        public void U_PMP_WIP(Guid SMSMPD_ID, int WIP, int kc, int ck)//批量保存在制品、库存、参考计划 
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = SMSMPD_ID;
            parm[1] = new SqlParameter("@WIP", SqlDbType.Int);
            parm[1].Value = WIP;
            parm[2] = new SqlParameter("@kc", SqlDbType.Int);
            parm[2].Value = kc;
            parm[3] = new SqlParameter("@ck", SqlDbType.Int);
            parm[3].Value = ck;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMP_WIP", parm);
        }

        public void U_PWPDetail_WIP(Guid SMSMPD_ID, int WIP, int kc, int ck)//批量保存生产周计划的 在制品、库存、参考计划 
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = SMSMPD_ID;
            parm[1] = new SqlParameter("@WIP", SqlDbType.Int);
            parm[1].Value = WIP;
            parm[2] = new SqlParameter("@kc", SqlDbType.Int);
            parm[2].Value = kc;
            parm[3] = new SqlParameter("@ck", SqlDbType.Int);
            parm[3].Value = ck;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PWPDetail_WIP", parm);
        }





        public void U_SMSalesMonthPlanDetail_PMP_State(Guid sMSMPM_ID)//提交生产月新增计划
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = sMSMPM_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesMonthPlanDetail_PMP_State", parm);
        }

        public void I_PMPDetail(ProductionPlanInfo productionPlanInfo)//插入生产月详细计划
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = productionPlanInfo.PMP_ID;
            parm[1] = new SqlParameter("@PMPD_ProdType", SqlDbType.VarChar, 60);
            parm[1].Value = productionPlanInfo.PMPD_ProdType;
            parm[2] = new SqlParameter("@PMPD_PSName", SqlDbType.VarChar, 60);
            parm[2].Value = productionPlanInfo.PMPD_PSName;
            parm[3] = new SqlParameter("@PMPD_MPNum", SqlDbType.Int);
            parm[3].Value = productionPlanInfo.PMPD_MPNum;
            parm[4] = new SqlParameter("@PMPD_Note", SqlDbType.VarChar, 100);
            parm[4].Value = productionPlanInfo.PPMPD_Note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPDetail", parm);
        }

        public void U_SMSalesMonthPlanDetail_PMPDetail(ProductionPlanInfo productionPlanInfo)//制定生产月详细计划
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = productionPlanInfo.SMSMPD_ID;
            parm[1] = new SqlParameter("@SMSMPD_PMPNum", SqlDbType.Int);
            parm[1].Value = productionPlanInfo.SMSMPD_PMPNum;
            parm[2] = new SqlParameter("@SMSMPD_PMPNote", SqlDbType.VarChar, 200);
            parm[2].Value = productionPlanInfo.SMSMPD_PMPNote;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesMonthPlanDetail_PMPDetail", parm);
        }


        public DataSet S_PMPDetail(string condition, string linenum)//查看生产某月计划详细
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
            if (linenum == "0")
            {
                para[0].Value = condition + "and  PS_Name!='模块部新产品' and PMP_ProductionLines=0";

            }
            else
            {
                para[0].Value = condition + "and  PS_Name='模块部新产品' and PMP_ProductionLines=1";
            }
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPDetail", para);

        }

        public DataSet S_PMP(int Year, int Month, string State, string sman, string man, DateTime sstime, DateTime setime, DateTime stime, DateTime etime, int linenum)//检索生产月计划主表
        {

            SqlParameter[] para =
            {   
                new SqlParameter("@year", SqlDbType.SmallInt) 
                {Value =Year},
           
                new SqlParameter("@month", SqlDbType.TinyInt)
                {Value =  Month},
            new SqlParameter("@state", SqlDbType.VarChar, 20)
                {Value =  State},
              new SqlParameter("@sstime", SqlDbType.DateTime)
                {Value =sstime},
                new SqlParameter("@setime", SqlDbType.DateTime)
                {Value = setime},
                new SqlParameter("@stime", SqlDbType.DateTime)
                {Value = stime},
                new SqlParameter("@etime", SqlDbType.DateTime)
                {Value =etime},
                new SqlParameter("@sman", SqlDbType.VarChar, 20)
                {Value = sman},
                new SqlParameter("@man", SqlDbType.VarChar, 20)
                {Value = man},
                   new SqlParameter("@linenum", SqlDbType.Int)
                {Value = linenum},
            };
            DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMP", para);
            return ds;

        }
        public void I_PMP(ProductionPlanInfo productionPlanInfo)//插入生产月计划
        {
            SqlParameter[] para =
            {
                new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier) {Value = productionPlanInfo.SMSMPM_ID},
                new SqlParameter("@PMP_Year", SqlDbType.SmallInt) {Value = productionPlanInfo.PMP_Year},
                new SqlParameter("@PMP_Month", SqlDbType.TinyInt)
                {Value = productionPlanInfo.PMP_Month},
                new SqlParameter("@PMP_STime", SqlDbType.Date)
                {Value = productionPlanInfo.PMP_STime},
                new SqlParameter("@PMP_ETime", SqlDbType.Date)
                {Value = productionPlanInfo.PMP_ETime},
                new SqlParameter("@PMP_Man", SqlDbType.VarChar, 20)
                {Value = productionPlanInfo.PMP_Man},
                 new SqlParameter("@line", SqlDbType.Int)
                {Value = productionPlanInfo.Proline}
            };
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMP", para);
        }

        public void U_PMP(ProductionPlanInfo productionPlanInfo)//编辑生产月计划
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = productionPlanInfo.PMP_ID;
            parm[1] = new SqlParameter("@PMP_STime", SqlDbType.Date);
            parm[1].Value = productionPlanInfo.PMP_STime;
            parm[2] = new SqlParameter("@PMP_ETime", SqlDbType.Date);
            parm[2].Value = productionPlanInfo.PMP_ETime;
            parm[3] = new SqlParameter("@PMP_Man", SqlDbType.VarChar, 20);
            parm[3].Value = productionPlanInfo.PMP_Man;


            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMP", parm);
        }

        public void U_PMP_Review(ProductionPlanInfo productionPlanInfo)//审核生产月计划
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@pmpid", SqlDbType.UniqueIdentifier);
            parm[0].Value = productionPlanInfo.PMP_ID;
            parm[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            parm[1].Value = productionPlanInfo.PMP_RMan;
            parm[2] = new SqlParameter("@view", SqlDbType.VarChar, 200);
            parm[2].Value = productionPlanInfo.PMP_RSuggstion;
            parm[3] = new SqlParameter("@result", SqlDbType.VarChar, 20);
            parm[3].Value = productionPlanInfo.PMP_State;
            parm[4] = new SqlParameter("@pmpcid", SqlDbType.UniqueIdentifier);
            parm[4].Value = productionPlanInfo.PMPC_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMP_Review", parm);
        }

        public void U_PMPNewAddDetail_Review(Guid smsmpdid, string man, string suggestion, string result)//审核生产月新增计划
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = smsmpdid;
            parm[1] = new SqlParameter("@SMSMPD_PMPNewRMan", SqlDbType.VarChar, 20);
            parm[1].Value = man;
            parm[2] = new SqlParameter("@SMSMPD_PMPNewRSuggestion", SqlDbType.VarChar, 400);
            parm[2].Value = suggestion;
            parm[3] = new SqlParameter("@SMSMPD_PMPNewResult", SqlDbType.VarChar, 20);
            parm[3].Value = result;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPNewAddDetail_Review", parm);
        }

        public DataSet S_PMPCountersignBasic(string Condition)//检索生产月计划会签基础表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = Condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPCountersignBasic", para);

        }

        public void I_PMPCountersignBasic(string BDOS_Code, int PMPCB_Type)//新增生产月计划会签基础表
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[0].Value = BDOS_Code;
            parm[1] = new SqlParameter("@PMPCB_Type", SqlDbType.Int);
            parm[1].Value = PMPCB_Type;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPCountersignBasic", parm);
        }

        public void D_PMPCountersignBasic(Guid PMPCB_ID)//删除生产月计划会签基础表
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPCB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMPCB_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PMPCountersignBasic", parm);
        }

        public DataSet S_PMPCountersignBasic_BD(string Condition)//检索生产月计划会签基础表待选部门
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = Condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPCountersignBasic_BD", para);

        }


    }
}