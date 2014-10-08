using System;
using System.Data;



public interface ISalaryTimeDayCalculate
{
    int Insert_SalaryTimePerDayWage(SalaryTimeDayCalculateInfo sTIMI);
    DataSet SearchWaitingForCalculate_WorkTimePiece(string Condition);
    DataSet SearchForShenHe_WithOtherTables_WODetail(DateTime ForShenHe_Date);
    DataSet SearchForShenHeLookDetail_WithOtherTables_WODetail(string Condition);
    int Update_ForShenHe_WorkTimePiece(SalaryTimeDayCalculateInfo sTIMI);
    DataSet SearchWOError_Rework_PBCraft();

    DataSet SearchPieceWaitingForCalculate_WorkTimePiece(string Condition);
    int Insert_SalaryPieceworkPerDayWage(SalaryTimeDayCalculateInfo sTIMI);
    DataSet SearchPieceNotIn(Guid WTP_ID);
    DataSet SearchForShenHePiece_WithOtherTables_WODetail(DateTime ForShenHe_Date);
    DataSet SearchForShenHeLookDetailPiece_WithOtherTables_WODetail(string Condition);
    int Update_ForShenHePiece_WorkTimePiece(SalaryTimeDayCalculateInfo sTIMI);
    int Update_WorkTimePieceRenShiShenHe(SalaryTimeDayCalculateInfo sTIMI);
    int Update_PieceRenShiShenHe(SalaryTimeDayCalculateInfo sTIMI);
    
}
