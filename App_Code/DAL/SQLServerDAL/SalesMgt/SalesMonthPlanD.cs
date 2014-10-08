    using System;
using System.Data;
    using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SalesMonthPlanD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalesMonthPlanD:ISalesMonthPlan
    {
        public SalesMonthPlanD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //默认绑定销售月计划主表
        public DataSet Select_SalesMonthPlan_Bindgridview()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalseMonthPlan_Bindgridview");

        }

        //模糊查询月计划
        public DataSet Select_SalesMonthPlan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
            para[0].Value = condition ;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesMonthPlan", para);

        }

        //新增月计划
        public int Insert_SalesMonthPlan(int year,int month,string man,DateTime start,DateTime end)
        {
            SqlParameter[] para = new SqlParameter[6];
            para[1] = new SqlParameter("@SMSMPM_Year", SqlDbType.Int);
            para[1].Value = year;
            para[2] = new SqlParameter("@SMSMPM_Month", SqlDbType.Int);
            para[2].Value = month;
            para[3] = new SqlParameter("@SMSMPM_MakeMan", SqlDbType.VarChar, 20);
            para[3].Value = man;
            para[4] = new SqlParameter("@SMSMPM_FirstStratDate", SqlDbType.DateTime);
            para[4].Value = start;
            para[5] = new SqlParameter("@SMSMPM_FirstEndDate", SqlDbType.DateTime);
            para[5].Value = end;
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            int repeat = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSalesMonthPlan", para);
            return repeat;
            
        }

        //通过Gridview点选去查看月计划详细-原始
        public DataSet Select_MonthPlanDetail_FromGridview(Guid MonthPlanID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMMonthPlanDetail_FromGridview_Original", para);

        }
        //通过Gridview点选去查看月计划详细-新增
        public DataSet Select_MonthPlanDetail_FromGridview_Add(Guid MonthPlanID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMMonthPlanDetail_FromGridview_Add", para);

        }
        //审核通过
        public void Update_SMSalesMonthPlanMain_CheckOK(Guid MonthPlanID, string CheckMan, string CheckOpinion)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@SMSMPM_CheckMan", SqlDbType.VarChar,20);
            para[1].Value = CheckMan;
            para[2] = new SqlParameter("@SMSMPM_CheckOpinion", SqlDbType.VarChar, 400);
            para[2].Value = CheckOpinion;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesMonthPlanMain_CheckOK", para);
        }
        //会签通过
        public void Update_SMSalesMonthPlanMain_SingOK(Guid MonthPlanID, string CheckMan, string CheckOpinion,string Department)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@Man", SqlDbType.VarChar, 20);
            para[1].Value = CheckMan;
            para[2] = new SqlParameter("@Opinion", SqlDbType.VarChar, 400);
            para[2].Value = CheckOpinion;
            para[3] = new SqlParameter("@Department", SqlDbType.VarChar, 20);
            para[3].Value = Department;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesMonthPlanMain_SignOK", para);
        }
        //绑定会签详情
        public DataSet Select_SMSalesMonthPlanMain_BindSign(Guid MonthPlanID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesMonthPlanMain_BindSign", para);

        }
        //审核不通过
        public void Update_SMSalesMonthPlanMain_CheckNotOK(Guid MonthPlanID, string CheckMan, string CheckOpinion)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@SMSMPM_CheckMan", SqlDbType.VarChar, 20);
            para[1].Value = CheckMan;
            para[2] = new SqlParameter("@SMSMPM_CheckOpinion", SqlDbType.VarChar, 400);
            para[2].Value = CheckOpinion;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesMonthPlanMain_CheckNotOK", para);
        }
        //会签不通过
        public void Update_SMSalesMonthPlanMain_SingNotOK(Guid MonthPlanID, string CheckMan, string CheckOpinion, string Department)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@Man", SqlDbType.VarChar, 20);
            para[1].Value = CheckMan;
            para[2] = new SqlParameter("@Opinion", SqlDbType.VarChar, 400);
            para[2].Value = CheckOpinion;
            para[3] = new SqlParameter("@Department", SqlDbType.VarChar, 20);
            para[3].Value = Department;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesMonthPlanMain_SignNotOK", para);
        }
        //查找产品型号，模糊查询的
        public DataSet Select_ProType(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,1000);
            para[0].Value = condition ;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProType", para);
        }
        //插入新的产品型号到销售月计划详细表
        public void Insert_ProType_MonthPlanDetail(Guid MonthPlanID, Guid PT_ID,string grid)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = PT_ID;
            para[2] = new SqlParameter("@new", SqlDbType.Char,3);
            para[2].Value = grid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ProType_SalesMonthPlanDetail", para);
        }
        //检查插入的产品型号是否重复，新建月计划的时候
        public DataSet Select_CheckMonthPlanDetail(Guid MonthPlanID,Guid PT_ID)
       {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanID;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = PT_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProType_SalesMonthPlanDetail", para);
       }
        //更新月计划详细表（submit和save两种，用way区别）
        public void Update_MonthPlanDetail_Main(Guid MonthPlanMainID, Guid MonthPlanDetailID, decimal amount, decimal first, decimal second, decimal third, decimal forth, string request,string remark, string way)
        {
            SqlParameter[] para = new SqlParameter[10];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MonthPlanMainID;
            para[1] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = MonthPlanDetailID;
            para[2] = new SqlParameter("@SMSMPD_PlanAmount", SqlDbType.Decimal,18);
            para[2].Value = amount;
            para[3] = new SqlParameter("@SMSMPD_FirstWeek", SqlDbType.Decimal, 18);
            para[3].Value = first;
            para[4] = new SqlParameter("@SMSMPD_SecondWeek", SqlDbType.Decimal, 18);
            para[4].Value = second;
            para[5] = new SqlParameter("@SMSMPD_ThirdWeek", SqlDbType.Decimal, 18);
            para[5].Value = third;
            para[6] = new SqlParameter("@SMSMPD_ForthWeek", SqlDbType.Decimal, 18);
            para[6].Value = forth;
            para[7] = new SqlParameter("@SMSMPD_ProductRequst", SqlDbType.VarChar,400);
            para[7].Value = request;
            para[8] = new SqlParameter("@SMSMPD_Remark", SqlDbType.VarChar, 400);
            para[8].Value = remark;
            para[9] = new SqlParameter("@way", SqlDbType.VarChar,10);
            para[9].Value = way;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_MonthPlanDetail_Main", para);
        }
        //删除月计划详细
        public void Delete_MonthPlanDetail(Guid DetailID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = DetailID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_Delete_MonthPlanDetail", para);
        }
        //删除月计划主表
        public void Delete_MonthPlanMain(Guid MainID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = MainID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_Delete_MonthPlanMain", para);
        }
        //月计划详细新增提交
        public void Update_MonthPlanDetail_ADD(Guid DetailID,decimal amount,string  request,string man,string remark,string way)
        {
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = DetailID;
            para[1] = new SqlParameter("@SMSMPD_PlanAmount", SqlDbType.Decimal);
            para[1].Value = amount;
            para[2] = new SqlParameter("@SMSMPD_ProductRequst", SqlDbType.VarChar,400);
            para[2].Value = request;
            para[3] = new SqlParameter("@SMSMPD_NewMakeMan", SqlDbType.VarChar ,20);
            para[3].Value = man;
            para[4] = new SqlParameter("@SMSMPD_Remark", SqlDbType.VarChar, 400);
            para[4].Value = remark;
            para[5] = new SqlParameter("@way", SqlDbType.VarChar, 10);
            para[5].Value = way;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_MonthPlanDetail_Add", para);
        }
        //审核新增月计划详细
        public void Update_MonthPlanDetail_ADD_Check(Guid DetailID, string opinion, string man, string key)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSMPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = DetailID;
            para[1] = new SqlParameter("@SMSMPD_NewCheckOpinion", SqlDbType.VarChar, 400);
            para[1].Value = opinion;
            para[2] = new SqlParameter("@SMSMPD_NewCheckMan", SqlDbType.VarChar, 20);
            para[2].Value = man;
            para[3] = new SqlParameter("@key", SqlDbType.VarChar,10);
            para[3].Value = key;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_Update_MonthPlanDetail_Add_Check", para);
        
        }
        //自动插入上个月的产品
        public void Insert_MonthPlanDetail_Auto(Guid mainID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSMPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = mainID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalesMonthPlanDetail_Auto", para);
        }
        //获得刚刚新建的月计划的MainID
        public DataSet SelectMonthPlanMainID(int year,int month)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMSMPM_Year", SqlDbType.Int);
            para[0].Value = year;
            para[1] = new SqlParameter("@SMSMPM_Month", SqlDbType.Int);
            para[1].Value = month;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMNewMonthPlanID", para);

        }
    }

}