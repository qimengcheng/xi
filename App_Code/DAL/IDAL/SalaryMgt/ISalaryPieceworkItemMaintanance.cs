using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///ISalaryPieceworkItemMaintanance 的摘要说明
/// </summary>
public interface ISalaryPieceworkItemMaintanance
{
    int Insert_SalaryPieceworkItem(SalaryPieceworkItemMaintananceInfo sPIMI);
    int Update_SalaryPieceworkItem(SalaryPieceworkItemMaintananceInfo sPIMI);
    int Delete_SalaryPieceworkItem(Guid ID);
    DataSet SearchByCondition_SalaryPieceworkItem(string Condition);
    DataSet SearchByCondition_QZL_ProType(string Condition);
    IList<SalaryPieceworkItemMaintananceInfo> SearchByID_SalaryPieceworkItem(Guid SPI_ID);
    int Insert_SalaryPieceItemChangeRecord(SalaryPieceworkItemMaintananceInfo sPIMI);
    DataSet SearchSalaryPieceItemChangeRecord(Guid SPI_ID);

}