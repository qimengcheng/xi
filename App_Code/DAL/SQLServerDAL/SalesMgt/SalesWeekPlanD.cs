using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SalesWeekPlanD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalesWeekPlanD : ISalesWeekPlan
    {
        public SalesWeekPlanD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //模糊查询月计划
        public DataSet Select_SalesWeekPlan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalesWeekPlan_Condition", para);

        }

        //新增月计划
        public void Insert_SalesWeekPlan(int year, int week, DateTime start, DateTime end, Guid MonthPlanID)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@SMSWPM_Year", SqlDbType.Int);
            para[0].Value = year;
            para[1] = new SqlParameter("@SMSWPM_Week", SqlDbType.Int);
            para[1].Value = week;
            para[2] = new SqlParameter("@SMSWPM_StartTime", SqlDbType.DateTime);
            para[2].Value = start;
            para[3] = new SqlParameter("@SMSWPM_EndTime", SqlDbType.DateTime);
            para[3].Value = end;
            para[4] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[4].Value = MonthPlanID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMWeekPlanMain", para);
        }
        public DataSet Select_Top5MonthPlanID()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMMonthPlanIDForWeek");

        }
        //绑定会签情况
        public DataSet Select_SalesWeekPlanBindSign(Guid weekid)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = weekid;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalesWeekPlan_BindSign",para);

        }
        //会签通过
        public void Update_SalesWeekPlanSignOK(Guid weekid, string man, string opinion, string department)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = weekid;
            para[1] = new SqlParameter("@Man", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@Opinion", SqlDbType.VarChar,400);
            para[2].Value = opinion;
            para[3] = new SqlParameter("@Department", SqlDbType.VarChar,20);
            para[3].Value = department;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesWeekPlanMain_SignOK", para);
        }
        //会签不通过
        public void Update_SalesWeekPlanSignNotOK(Guid weekid, string man, string opinion, string department)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = weekid;
            para[1] = new SqlParameter("@Man", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@Opinion", SqlDbType.VarChar,400);
            para[2].Value = opinion;
            para[3] = new SqlParameter("@Department", SqlDbType.VarChar,20);
            para[3].Value = department;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesWeekPlanMain_SignNotOK", para);
        }
        //查询销售周计划详细表-condition
        public DataSet Select_SalesWeekPlanDetail_Condition(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesWeekPlanDetail_Condition", para);

        }
        //删除周计划主表
        public void Delete_WeekPlanMain(Guid weekid)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = weekid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesWeekPlanMain", para);
        }
        //删除周计划详细表
        public void Delete_WeekPlanDetail(Guid weekid)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSWPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = weekid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesWeekPlanDetail", para);
        }
        //提交周计划详细的数字
        public void Update_WeekPlanDetail_Num(Guid detailID,Guid weekID,int total,string youxianji,string remark,int day1,int day2,int day3,int day4,int day5,int day6,string way)
        {
            SqlParameter[] para = new SqlParameter[12];
            para[0] = new SqlParameter("@SMSWPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = detailID;
            para[1] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = weekID;
            para[2] = new SqlParameter("@SMSWPD_ThisWeekDelNum", SqlDbType.Int);
            para[2].Value = total;
            para[3] = new SqlParameter("@SMSWPD_Propity", SqlDbType.VarChar,20);
            para[3].Value = youxianji;
            para[4] = new SqlParameter("@SMSWPD_Remark", SqlDbType.VarChar,400);
            para[4].Value = remark;
            para[5] = new SqlParameter("@SMSWPD_Day1Plan", SqlDbType.Int);
            para[5].Value = day1;
            para[6] = new SqlParameter("@SMSWPD_Day2Plan", SqlDbType.Int);
            para[6].Value = day2;
            para[7] = new SqlParameter("@SMSWPD_Day3Plan", SqlDbType.Int);
            para[7].Value = day3;
            para[8] = new SqlParameter("@SMSWPD_Day4Plan", SqlDbType.Int);
            para[8].Value = day4;
            para[9] = new SqlParameter("@SMSWPD_Day5Plan", SqlDbType.Int);
            para[9].Value = day5;
            para[10] = new SqlParameter("@SMSWPD_Day6Plan", SqlDbType.Int);
            para[10].Value = day6;
            para[11] = new SqlParameter("@way", SqlDbType.VarChar, 10);
            para[11].Value = way;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesWeekPlanDetail", para);
        }
        //将产品型号插入周计划详细表
        public void Update_Protype_SalesWeekPlanDetail(Guid weekid,Guid pt)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = weekid;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = pt;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_Protype_SalesWeekPlanDetail", para);
        }
        //新建周计划的时候把对应的订单的产品型号插入
        public void Insert_Protype_WeekPlan(DateTime start,DateTime end)
        { 
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@start", SqlDbType.DateTime);
            para[0].Value = start;
            para[1] = new SqlParameter("@end", SqlDbType.DateTime);
            para[1].Value = end;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_Protype_SalesWeekPlanDetail", para);
        }
        //检查插入的产品型号是否重复，新建周计划的时候
        public DataSet Select_CheckWeekPlanDetail(Guid MonthPlanID,Guid PT_ID)
       {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMSWPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = PT_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_Protype_SalesWeekPlanDetail", para);
       }
    }
}
