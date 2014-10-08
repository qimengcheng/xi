using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///ISalaryTimeItemMaintanance 的摘要说明
/// </summary>
public interface ISalaryTimeItemMaintanance
{
    int Insert_SalaryTimeItem(SalaryTimeItemMaintananceInfo sTIMI);
    int Insert_SalaryTimeItemRecord(SalaryTimeItemChangeRecordInfo sTIMI);
    int Update_SalaryTimeItem(SalaryTimeItemMaintananceInfo sTIMI);
    int Delete_SalaryTimeItem(Guid ID);
    DataSet SearchByCondition_SalaryTimeItem(string Condition);
    DataSet Search_SalaryTimeItemHistory(Guid ID);
    IList<SalaryTimeItemMaintananceInfo> SearchByID_SalaryTimeItem(Guid STI_ID);
    DataSet SearchCraftForDdl_SalaryTimeItem();
}