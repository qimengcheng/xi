using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///SalaryTimeDayCalculateL 的摘要说明
/// </summary>
public class SalaryTimeDayCalculateL
{
    private static readonly ISalaryTimeDayCalculate iSTIM = DALFactory.CreateISalaryTimeDayCalculate();
	public SalaryTimeDayCalculateL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 计时日工资计算与审核
    /// </summary>
    /// <param name="Condition"></param>
    /// <returns></returns>
    public DataSet SearchWaitingForCalculate_WorkTimePiece(string Condition)
    {
        return iSTIM.SearchWaitingForCalculate_WorkTimePiece(Condition);
    }//薪资管理，薪资计时日计算，检索信息,需要进行计时工资日计算的日期

    public int Insert_SalaryTimePerDayWage(SalaryTimeDayCalculateInfo sTIMI)
    {
        return iSTIM.Insert_SalaryTimePerDayWage(sTIMI);
    }//薪资管理，薪资计时日计算，计算当前日期的日工资

    public DataSet SearchForShenHe_WithOtherTables_WODetail(DateTime ForShenHe_Date)
    {
        return iSTIM.SearchForShenHe_WithOtherTables_WODetail(ForShenHe_Date);
    }//薪资管理，薪资计时日审核，检索信息,需要进行计时工资日审核的日期（linkbutton查看当日明细）

    public DataSet SearchForShenHeLookDetail_WithOtherTables_WODetail(string Condition)
    {
        return iSTIM.SearchForShenHeLookDetail_WithOtherTables_WODetail(Condition);
    }//薪资管理，薪资计时日审核，检索信息,需要进行计时工资日审核的信息详情（linkbutton查看详情）

    public int Update_ForShenHe_WorkTimePiece(SalaryTimeDayCalculateInfo sTIMI)
    {
        return iSTIM.Update_ForShenHe_WorkTimePiece(sTIMI);

    }//薪资管理，薪资计时日审核，审核

    public int Update_WorkTimePieceRenShiShenHe(SalaryTimeDayCalculateInfo sTIMI)
    {
        return iSTIM.Update_WorkTimePieceRenShiShenHe(sTIMI);
    }//薪资管理，薪资计时日审核，人事审核

    public DataSet SearchWOError_Rework_PBCraft()
    {
        return iSTIM.SearchWOError_Rework_PBCraft();
    }//薪资管理，薪资计时日计算，绑定工序，存储过程源于YZG

    /// <summary>
    /// 计件日工资计算与审核
    /// </summary>
    /// <param name="Condition"></param>
    /// <returns></returns>
    public DataSet SearchPieceWaitingForCalculate_WorkTimePiece(string Condition)
    {
        return iSTIM.SearchPieceWaitingForCalculate_WorkTimePiece(Condition);
    }//薪资管理，薪资计件日计算，检索信息,需要进行计件工资日计算的日期


    public int Insert_SalaryPieceworkPerDayWage(SalaryTimeDayCalculateInfo sTIMI)
    {
        return iSTIM.Insert_SalaryPieceworkPerDayWage(sTIMI);
    }//薪资管理，薪资计件日计算，计算当前日期的计件日工资

    public DataSet SearchPieceNotIn(Guid WTP_ID)
    {
        return iSTIM.SearchPieceNotIn(WTP_ID);
    }//薪资管理，薪资计件日计算，检索--检索出所有没有指定计件单价的计件项目

    public DataSet SearchForShenHePiece_WithOtherTables_WODetail(DateTime ForShenHe_Date)
    {
        return iSTIM.SearchForShenHePiece_WithOtherTables_WODetail(ForShenHe_Date);
    }//薪资管理，薪资计件日审核，检索信息,需要进行计件工资日审核的日期（linkbutton查看当日明细）

    public DataSet SearchForShenHeLookDetailPiece_WithOtherTables_WODetail(string Condition)
    {
        return iSTIM.SearchForShenHeLookDetailPiece_WithOtherTables_WODetail(Condition);
    }//薪资管理，薪资计件日审核，检索信息,需要进行计件工资日审核的信息详情（linkbutton查看详情）

    public int Update_ForShenHePiece_WorkTimePiece(SalaryTimeDayCalculateInfo sTIMI)
    {
        return iSTIM.Update_ForShenHePiece_WorkTimePiece(sTIMI);

    }//薪资管理，薪资计件日审核，审核，录入审核信息

    public int Update_PieceRenShiShenHe(SalaryTimeDayCalculateInfo sTIMI)
    {
        return iSTIM.Update_PieceRenShiShenHe(sTIMI);
    }//薪资管理，薪资计件日审核，人事审核
}