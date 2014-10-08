using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

/// <summary>
///SalaryTimeDayCalculateD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalaryTimeDayCalculateD : ISalaryTimeDayCalculate
    {
        public SalaryTimeDayCalculateD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 计时计算与审核
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataSet SearchWaitingForCalculate_WorkTimePiece(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_WaitingForCalculate_WorkTimePiece", new SqlParameter("@condition", Condition));
        }//薪资管理，薪资计时日计算，检索信息,需要进行计时工资日计算的日期

        public int Insert_SalaryTimePerDayWage(SalaryTimeDayCalculateInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryTimePerDayWage",
                new SqlParameter("@WTP_ID", sTIMI.WTP_ID));
        }//薪资管理，薪资计时日计算，计算当前日期的日工资

        public DataSet SearchForShenHe_WithOtherTables_WODetail(DateTime ForShenHe_Date)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForShenHe_WithOtherTables_WODetail", new SqlParameter("@ForShenHe_Date", ForShenHe_Date));
        }//薪资管理，薪资计时日审核，检索信息,需要进行计时工资日审核的日期（linkbutton查看当日明细）

        public DataSet SearchForShenHeLookDetail_WithOtherTables_WODetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForShenHeLookDetail_WithOtherTables_WODetail", new SqlParameter("@condition", Condition));
        }//薪资管理，薪资计时日审核，检索信息,需要进行计时工资日审核的信息详情（linkbutton查看详情）

        public int Update_WorkTimePieceRenShiShenHe(SalaryTimeDayCalculateInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WorkTimePieceRenShiShenHe",
                new SqlParameter("@WTP_ID", sTIMI.WTP_ID), new SqlParameter("@PT_Auditor", sTIMI.PT_Auditor),
                new SqlParameter("@PT_AuSugg", sTIMI.PT_AuSugg), new SqlParameter("@PT_AuRes", sTIMI.PT_AuRes));
        }//薪资管理，薪资计时日审核，人事审核

        public int Update_ForShenHe_WorkTimePiece(SalaryTimeDayCalculateInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForShenHe_WorkTimePiece",
                new SqlParameter("@WTP_ID", sTIMI.WTP_ID), new SqlParameter("@STSA_Auditor", sTIMI.STSA_Auditor),
                new SqlParameter("@STSA_AuSugg", sTIMI.STSA_AuSugg), new SqlParameter("@STSA_AuRes", sTIMI.STSA_AuRes));

        }//薪资管理，薪资计时日审核，审核


        public DataSet SearchWOError_Rework_PBCraft()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_WOError_Rework_PBCraft");
        }//薪资管理，薪资计时日计算，绑定工序，存储过程源于YZG
        //Proc_S_WOError_Rework_PBCraft



        /// <summary>
        /// 计件计算与审核
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>

        public DataSet SearchPieceWaitingForCalculate_WorkTimePiece(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_PieceWaitingForCalculate_WorkTimePiece", new SqlParameter("@condition", Condition));
        }//薪资管理，薪资计件日计算，检索信息,需要进行计件工资日计算的日期


        public int Insert_SalaryPieceworkPerDayWage(SalaryTimeDayCalculateInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryPieceworkPerDayWage",
                new SqlParameter("@WTP_ID", sTIMI.WTP_ID));
        }//薪资管理，薪资计件日计算，计算当前日期的计件日工资

        public DataSet SearchPieceNotIn(Guid WTP_ID)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_PieceNotIn", new SqlParameter("@WTP_ID", WTP_ID));
        }//薪资管理，薪资计件日计算，检索--检索出所有没有指定计件单价的计件项目

        public DataSet SearchForShenHePiece_WithOtherTables_WODetail(DateTime ForShenHe_Date)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForShenHePiece_WithOtherTables_WODetail", new SqlParameter("@ForShenHe_Date", ForShenHe_Date));
        }//薪资管理，薪资计件日审核，检索信息,需要进行计件工资日审核的日期（linkbutton查看当日明细）

        public DataSet SearchForShenHeLookDetailPiece_WithOtherTables_WODetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForShenHeLookDetailPiece_WithOtherTables_WODetail", new SqlParameter("@condition", Condition));
        }//薪资管理，薪资计件日审核，检索信息,需要进行计件工资日审核的信息详情（linkbutton查看详情）

        public int Update_ForShenHePiece_WorkTimePiece(SalaryTimeDayCalculateInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForShenHePiece_WorkTimePiece",
                new SqlParameter("@WTP_ID", sTIMI.WTP_ID), new SqlParameter("@SPSA_Auditor", sTIMI.SPSA_Auditor),
                new SqlParameter("@SPSA_AuSugg", sTIMI.SPSA_AuSugg), new SqlParameter("@SPSA_AuRes", sTIMI.SPSA_AuRes));

        }//薪资管理，薪资计件日审核，审核，录入审核信息

        public int Update_PieceRenShiShenHe(SalaryTimeDayCalculateInfo sTIMI)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PieceRenShiShenHe",
                new SqlParameter("@WTP_ID", sTIMI.WTP_ID), new SqlParameter("@PP_Auditor", sTIMI.PP_Auditor),
                new SqlParameter("@PP_AuSugg", sTIMI.PP_AuSugg), new SqlParameter("@PP_AuRes", sTIMI.PP_AuRes));
        }//薪资管理，薪资计件日审核，人事审核
    }
}