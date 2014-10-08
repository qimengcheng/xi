using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///ISalaryAccountSetMaintanancecs 的摘要说明
/// </summary>
public interface ISalaryAccountSetMaintanancecs
{
    int Insert_SalaryAccountSet(SalaryAccountSetMaintananceInfo ssm);
    int Update_SalaryAccountSet(SalaryAccountSetMaintananceInfo ssm);
    int Delete_SalaryAccountSet(Guid ID);
    DataSet Search_SalaryAccountSet(string Condition);
    int Delete_SalaryAccountSet_HRDDetail(Guid ID);
    int Insert_SalaryAccountSet_HRDDetail(Guid HRDD_ID, Guid SAS_ASID);
    int Insert_SalaryItemTable(SalaryAccountSetMaintananceInfo ssm);
    DataSet Search_SalaryItemTable(string Condition);
    void Update_YanZhengGongShi(Guid guid, string str);
    IList<SalaryAccountSetMaintananceInfo> SearchByID_SalaryItemTable(Guid SIT_ItemID);
    DataSet Search_FromOtherSet_SalaryItemTable(Guid SAS_ASID);
    int Update_SalaryItemTable(SalaryAccountSetMaintananceInfo ssm);
    int Delete_SalaryItemTable(Guid SIT_ItemID);
    DataSet Search_AllSalaryItems_SalaryItemTable(string condition);
    DataSet Search_AllSalaryItems_SalaryItemTable(Guid g1, Guid g2);
}