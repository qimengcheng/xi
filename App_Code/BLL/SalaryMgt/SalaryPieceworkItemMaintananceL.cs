using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///SalaryPieceworkItemMaintananceL 的摘要说明
/// </summary>
public class SalaryPieceworkItemMaintananceL
{
    private static readonly ISalaryPieceworkItemMaintanance iSPIM = DALFactory.CreateISalaryPieceworkItemMaintanance();
    public int Insert_SalaryPieceworkItem(SalaryPieceworkItemMaintananceInfo sPIMI)
    {
        return iSPIM.Insert_SalaryPieceworkItem(sPIMI);
    }

    public int Update_SalaryPieceworkItem(SalaryPieceworkItemMaintananceInfo sPIMI)
    {
        return iSPIM.Update_SalaryPieceworkItem(sPIMI);
    }

    public int Delete_SalaryPieceworkItem(Guid ID)
    {
        return iSPIM.Delete_SalaryPieceworkItem(ID);
    }

    public DataSet SearchByCondition_SalaryPieceworkItem(string Condition)
    {
        return iSPIM.SearchByCondition_SalaryPieceworkItem(Condition);
    }

    public DataSet SearchByCondition_QZL_ProType(string Condition)
    {
        return iSPIM.SearchByCondition_QZL_ProType(Condition);
    }

    public IList<SalaryPieceworkItemMaintananceInfo> SearchByID_SalaryPieceworkItem(Guid SPI_ID)
    {
        return iSPIM.SearchByID_SalaryPieceworkItem(SPI_ID);
    }

    public int Insert_SalaryPieceItemChangeRecord(SalaryPieceworkItemMaintananceInfo sPIMI)
    {
        return iSPIM.Insert_SalaryPieceItemChangeRecord(sPIMI);
    }//新增计件历史单价

    public DataSet SearchSalaryPieceItemChangeRecord(Guid SPI_ID)
    {
        return iSPIM.SearchSalaryPieceItemChangeRecord(SPI_ID);
    }//
}