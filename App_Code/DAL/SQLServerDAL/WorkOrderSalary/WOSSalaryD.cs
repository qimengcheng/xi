using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///WOSSalaryD 的摘要说明
/// </summary>
///
namespace EquipmentMangementAjax.SQLServer
{
    public class WOSSalaryD : IWOSSalary
    {
        public WOSSalaryD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet S_LaborCostSeries(string condition)//检索工价系列
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_LaborCostSeries", para);

        }

        public void D_LaborCostSeries(Guid lCS_ID)//删除工价系列
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = lCS_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_LaborCostSeries", para);
        }
        public DataSet S_LaborCostSeries_panchong(string lCS_Name)//工价系列判重
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LCS_Name", SqlDbType.VarChar, 60);
            para[0].Value = lCS_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_LaborCostSeries_panchong", para);

        }

        public void I_LaborCostSeries(string lCS_Name)//工价系列新增
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LCS_Name", SqlDbType.VarChar, 60);
            para[0].Value = lCS_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_LaborCostSeries", para);

        }

        public void U_LaborCostSeries(string lCS_Name, Guid lCS_ID)//工价系列编辑
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@LCS_Name", SqlDbType.VarChar, 60);
            para[0].Value = lCS_Name;
            para[1] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = lCS_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_LaborCostSeries", para);

        }
        public DataSet S_LaborCostSeries_ProType(Guid lCS_ID)//工价系列所属产品型号
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = lCS_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_LaborCostSeries_ProType", para);
        }

        public void D_LaborCostSeries_ProType(Guid pT_ID)//工价系列删除所属产品型号
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_LaborCostSeries_ProType", para);
        }


        public DataSet S_LaborCostSeries_ProType_Condition(string condition)//工价系列显示待选产品型号
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_LaborCostSeries_ProType_Condition", para);

        }


        public void I_LaborCostSeries_ProType(Guid pT_ID, Guid lCS_ID)//新增工价系列所属产品型号
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pT_ID;
            para[1] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = lCS_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_LaborCostSeries_ProType", para);

        }


        public DataSet S_WorkingTeam(string condition)//检索班组信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkingTeam", para);

        }

        public void I_WorkingTeam(string wT_People, string wT_Name)//新增班组信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@WT_People", SqlDbType.VarChar, 20);
            para[0].Value = wT_People;
            para[1] = new SqlParameter("@WT_Name", SqlDbType.VarChar, 60);
            para[1].Value = wT_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_WorkingTeam", para);

        }


        public void u_WorkingTeam(Guid wT_ID, string wT_People, string wT_Name)//编辑班组信息
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@WT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wT_ID;
            para[1] = new SqlParameter("@WT_People", SqlDbType.VarChar, 20);
            para[1].Value = wT_People;
            para[2] = new SqlParameter("@WT_Name", SqlDbType.VarChar, 60);
            para[2].Value = wT_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_u_WorkingTeam", para);

        }

        public void D_WorkingTeam(Guid wT_ID)//删除班组信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_WorkingTeam", para);

        }


        public DataSet S_WorkTeamDetailList(Guid wT_ID)//检索班组详细信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wT_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_WorkTeamDetailList", para);
        }

        public void D_WorkTeamDetailList(Guid wTDL_ID)//删除班组信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WTDL_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wTDL_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_WorkTeamDetailList", para);

        }
        public DataSet S_WorkTeamDetailList_HRDDetail(string condition)//检索待选员工
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkTeamDetailList_HRDDetail", para);

        }
        public void I_WorkTeamDetailList_HRDDetail(Guid wT_ID, Guid hRDD_ID)//添加员工至班组详细表
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@WT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wT_ID;
            para[1] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = hRDD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_WorkTeamDetailList_HRDDetail", para);

        }

        public DataSet S_WorkTimePiece_ByProDept(string condition)//显示计时计件主表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkTimePiece_ByProDept", para);

        }

        public DataSet S_OperatorInfo(string condition, string wOD_OutTime)//显示某一天的计件信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            para[1] = new SqlParameter("@WOD_OutTime", SqlDbType.VarChar, 50);
            para[1].Value = wOD_OutTime;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OperatorInfo", para);

        }


        public void D_WorkTimePiece_ByProDept(Guid wTP_ID)//删除计时计件主表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WTP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wTP_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_WorkTimePiece_ByProDept", para);

        }

        public void I_WorkTimePiece_ByProDept(DateTime wTP_Date)//新增计时计件主表信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WTP_Date", SqlDbType.Date);
            para[0].Value = wTP_Date;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_WorkTimePiece_ByProDept", para);

        }

        public DataSet S_OTime(string condition, string wOD_OutTime)//显示某一天的生产计时信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            para[1] = new SqlParameter("@WOD_OutTime", SqlDbType.VarChar, 50);
            para[1].Value = wOD_OutTime;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OTime", para);

        }

        public DataSet S_OTime_OT_NORelated(string condition, string oT_NORelated_Date)//显示某一天的非生产相关计时信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            para[1] = new SqlParameter("@OT_NORelated_Date", SqlDbType.VarChar, 50);
            para[1].Value = oT_NORelated_Date;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OTime_OT_NORelated", para);

        }

        public DataSet S_WorkTimePiece_ByID(Guid wTP_ID)//通过ID查询计时计件核算表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WTP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wTP_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkTimePiece_ByID", para);

        }

        public void U_WorkTimePiece_PReview(Guid wTP_ID, string wTP_PRMan, string wTP_PSuggestion, string wTP_PieceRState)//计时计件核算表计件审核
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@WTP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wTP_ID;
            para[1] = new SqlParameter("@WTP_PRMan", SqlDbType.VarChar, 20);
            para[1].Value = wTP_PRMan;
            para[2] = new SqlParameter("@WTP_PSuggestion", SqlDbType.VarChar, 400);
            para[2].Value = wTP_PSuggestion;
            para[3] = new SqlParameter("@WTP_PieceRState", SqlDbType.VarChar, 20);
            para[3].Value = wTP_PieceRState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_WorkTimePiece_PReview", para);

        }

        public void U_WorkTimePiece_TReview(Guid wTP_ID, string wTP_TRMan, string wTP_TSuggestion, string wTP_TimeRState)//计时计件核算表计件审核
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@WTP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wTP_ID;
            para[1] = new SqlParameter("@WTP_TRMan", SqlDbType.VarChar, 20);
            para[1].Value = wTP_TRMan;
            para[2] = new SqlParameter("@WTP_TSuggestion", SqlDbType.VarChar, 400);
            para[2].Value = wTP_TSuggestion;
            para[3] = new SqlParameter("@WTP_TimeRState", SqlDbType.VarChar, 20);
            para[3].Value = wTP_TimeRState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_WorkTimePiece_TReview", para);

        }

        public DataSet S_TimeSalaryDate(string condition)//显示计时提报日期
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@comdition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_TimeSalaryDate", para);

        }

        public void I_TimeSalaryDate(DateTime tSD_Date)//新增计时提报日期
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@TSD_Date", SqlDbType.Date);
            para[0].Value = tSD_Date;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_TimeSalaryDate", para);

        }

        public void D_TimeSalaryDate(Guid tSD_ID)//删除计时提报日期
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@TSD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = tSD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_TimeSalaryDate", para);

        }
        public DataSet S_TimeSalaryDateDetail(string tSD_ID, string condition)//显示某一天的提报计时项目信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@TSD_ID", SqlDbType.VarChar, 100);
            para[0].Value = tSD_ID;
            para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_TimeSalaryDateDetail", para);

        }

        public DataSet S_TimeSalaryDateDetail_SalaryTimeItem(string tSD_ID, string condition)//显示待添加的提报计时项目信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@TSD_ID", SqlDbType.VarChar, 100);
            para[0].Value = tSD_ID;
            para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_TimeSalaryDateDetail_SalaryTimeItem", para);

        }

        public void I_TimeSalaryDateDetail(Guid tSD_ID, Guid sTI_ID, string tSDD_Man)//添加提报计时项目信息
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@TSD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = tSD_ID;
            para[1] = new SqlParameter("@STI_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = sTI_ID;
            para[2] = new SqlParameter("@TSDD_Man", SqlDbType.VarChar, 20);
            para[2].Value = tSDD_Man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_TimeSalaryDateDetail", para);

        }

        public void D_TimeSalaryDateDetail(Guid tSDD_ID)//删除提报计时项目信息及其详细信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@TSDD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = tSDD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_TimeSalaryDateDetail", para);

        }

        public DataSet S_TimeSalaryDateDetail_Panduan(Guid tSD_ID)//判断某计时提报日期已经制定了详细信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@TSD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = tSD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_TimeSalaryDateDetail_Panduan", para);

        }

        public DataSet S_OTime_TimeSalaryDateDetail(string tSDD_ID, string condition)//显示某天计时项目信息的详细信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@TSDD_ID", SqlDbType.VarChar, 100);
            para[0].Value = tSDD_ID;
            para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OTime_TimeSalaryDateDetail", para);

        }
        public void U_OTime(Guid oT_ID, decimal oT_Time, int oT_Num)//制定计时提报详细信息的计时时间和生产数量
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@OT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = oT_ID;
            para[1] = new SqlParameter("@OT_Time", SqlDbType.Decimal);
            para[1].Value = oT_Time;
            para[2] = new SqlParameter("@OT_Num", SqlDbType.Int);
            para[2].Value = oT_Num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_OTime", para);

        }

        public void D_OTime(Guid oT_ID)//删除计时提报详细信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@OT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = oT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_OTime", para);

        }

        public DataSet S_OTime_HRDDetail(string tSDD_ID, string condition)//计时提报待选员工
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@TSDD_ID", SqlDbType.VarChar, 100);
            para[0].Value = tSDD_ID;
            para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OTime_HRDDetail", para);

        }

        public void I_OTime_HRDDetail(Guid sTI_ID, Guid tSDD_ID, Guid hRDD_ID)//计时提报添加待选员工
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@STI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = sTI_ID;
            para[1] = new SqlParameter("@TSDD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = tSDD_ID;
            para[2] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[2].Value = hRDD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_OTime_HRDDetail", para);

        }

        public void U_TimeSalaryDateDetail(Guid tSDD_ID)//提交计时提报详细
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@TSDD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = tSDD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_TimeSalaryDateDetail", para);

        }

        public DataSet S_AssemblyPieceDate(string condition)//查看装配计件核算日期
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_AssemblyPieceDate", para);

        }

        public void I_AssemblyPieceDate(DateTime aPD_Date, string aPD_Man)//新增装配计件核算日期
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@APD_Date", SqlDbType.Date);
            para[0].Value = aPD_Date;
            para[1] = new SqlParameter("@APD_Man", SqlDbType.VarChar, 20);
            para[1].Value = aPD_Man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_AssemblyPieceDate", para);

        }
        public void D_AssemblyPieceDate(Guid aPD_ID)//删除装配计件核算日期
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@APD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = aPD_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_AssemblyPieceDate", para);

        }

        public DataSet S_AssemblyTeamMember_Detai(string condition, string lCS_ID, string aPD_ID)//检索装配计件详情
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            para[1] = new SqlParameter("@LCS_ID", SqlDbType.VarChar, 100);
            para[1].Value = lCS_ID;
            para[2] = new SqlParameter("@APD_ID", SqlDbType.VarChar, 100);
            para[2].Value = aPD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_AssemblyTeamMember_Detail", para);

        }

        public void D_AssemblyTeamMember_Detail(Guid aTM_ID)//删除装配计件详情
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@ATM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = aTM_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_AssemblyTeamMember_Detail", para);

        }


        public void U_AssemblyTeamMember_Detail(Guid aTM_ID, decimal aTM_LaborHour)//编辑装配计件详情
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@ATM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = aTM_ID;
            para[1] = new SqlParameter("@ATM_LaborHour", SqlDbType.Decimal);
            para[1].Value = aTM_LaborHour;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_AssemblyTeamMember_Detail", para);

        }
        public DataSet S_AssemblyPieceDate_Shanchupanduan(Guid aPD_ID)//装配计件删除判断
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@APD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = aPD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_AssemblyPieceDate_Shanchupanduan", para);

        }
        public void I_AssemblyTeamMember_HRDDetail(Guid hRDD_ID, Guid aPD_ID, Guid lCS_ID)//装配计件添加待选员工
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = hRDD_ID;
            para[1] = new SqlParameter("@APD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = aPD_ID;
            para[2] = new SqlParameter("@LCS_ID", SqlDbType.UniqueIdentifier);
            para[2].Value = lCS_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_AssemblyTeamMember_HRDDetail", para);

        }
        public DataSet S_AssemblyTeamMember_HRDDetail(string aPD_ID, string lCS_ID, string condition)//装配计件待选员工
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@APD_ID", SqlDbType.VarChar, 100);
            para[0].Value = aPD_ID;
            para[1] = new SqlParameter("@LCS_ID", SqlDbType.VarChar, 100);
            para[1].Value = lCS_ID;
            para[2] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[2].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_AssemblyTeamMember_HRDDetail", para);

        }

        public DataSet S_OperatorInfo_WorkOrder_ForOne(Guid pBC_ID, string wOD_OutTime, string ptname, Guid HRDD_ID)//显示某人某工序某一天的计件信息的随工单信息
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pBC_ID;
            para[1] = new SqlParameter("@WOD_OutTime", SqlDbType.VarChar,50);
            para[1].Value = wOD_OutTime;
            para[2] = new SqlParameter("@ptname", SqlDbType.VarChar, 50);
            para[2].Value = ptname;
            para[3] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[3].Value = HRDD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OperatorInfo_WorkOrder_ForOne", para);

        }

        public DataSet S_OTime_WorkOrder_ForOne(Guid sTI_ID, string wOD_OutTime, string ptname, Guid HRDD_ID)//显示某人某工序某一天的计时信息的随工单信息
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@STI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = sTI_ID;
            para[1] = new SqlParameter("@WOD_OutTime", SqlDbType.VarChar, 50);
            para[1].Value = wOD_OutTime;
            para[2] = new SqlParameter("@ptname", SqlDbType.VarChar, 50);
            para[2].Value = ptname;
            para[3] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            para[3].Value = HRDD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_OTime_WorkOrder_ForOne", para);

        }

        public void U_OTime_OT_NORelated(Guid oT_ID, decimal oT_Time, int oT_Num)//编辑装配计件详情
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@OT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = oT_ID;
            para[1] = new SqlParameter("@OT_Time", SqlDbType.Decimal);
            para[1].Value = oT_Time;
            para[2] = new SqlParameter("@OT_Num", SqlDbType.Int);
            para[2].Value = oT_Num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_OTime_OT_NORelated", para);

        }
        public void U_OperatorInfo_shenhexiugai(Guid oI_ID, int oI_ProNum)//修改某一天的生产相关计件信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@OI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = oI_ID;
            para[1] = new SqlParameter("@OI_ProNum", SqlDbType.Int);
            para[1].Value = oI_ProNum;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_OperatorInfo_shenhexiugai", para);

        }
    }
}