using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///SalaryAccountSetMaintananceL 的摘要说明
/// </summary>
public class SalaryAccountSetMaintananceL
{
    private static readonly ISalaryAccountSetMaintanancecs iSSM = DALFactory.CreateISalaryAccountSetMaintanancecs();
	public SalaryAccountSetMaintananceL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_SalaryAccountSet(SalaryAccountSetMaintananceInfo ssm)
    {
        return iSSM.Insert_SalaryAccountSet(ssm);
    }
    public int Update_SalaryAccountSet(SalaryAccountSetMaintananceInfo ssm)
    {
        return iSSM.Update_SalaryAccountSet(ssm);
    }
    public int Delete_SalaryAccountSet(Guid ID)
    {
        return iSSM.Delete_SalaryAccountSet(ID);
    }
    public DataSet Search_SalaryAccountSet(string Condition)
    {
        return iSSM.Search_SalaryAccountSet(Condition);
    }
    public int Delete_SalaryAccountSet_HRDDetail(Guid ID)
    {
        return iSSM.Delete_SalaryAccountSet_HRDDetail(ID);
    }
    public int Insert_SalaryAccountSet_HRDDetail(Guid HRDD_ID, Guid SAS_ASID)
    {
        return iSSM.Insert_SalaryAccountSet_HRDDetail(HRDD_ID,SAS_ASID);
    }
    public int Insert_SalaryItemTable(SalaryAccountSetMaintananceInfo ssm)
    {
        return iSSM.Insert_SalaryItemTable(ssm);
    }
    public DataSet Search_SalaryItemTable(string Condition)
    {
        return iSSM.Search_SalaryItemTable(Condition);
    }

    public void Update_YanZhengGongShi(Guid guid, string str)
    {
        iSSM.Update_YanZhengGongShi(guid,str);
    }//薪资管理，薪资账套维护，维护工资项目，校验公式的格式
    public IList<SalaryAccountSetMaintananceInfo> SearchByID_SalaryItemTable(Guid SIT_ItemID)
    {
        return iSSM.SearchByID_SalaryItemTable(SIT_ItemID);
    }
    public DataSet Search_FromOtherSet_SalaryItemTable(Guid SAS_ASID)
    {
        return iSSM.Search_FromOtherSet_SalaryItemTable(SAS_ASID);
    }
    public int Delete_SalaryItemTable(Guid SIT_ItemID)
    {
        return iSSM.Delete_SalaryItemTable(SIT_ItemID);
    }
    public int Update_SalaryItemTable(SalaryAccountSetMaintananceInfo ssm)
    {
        return iSSM.Update_SalaryItemTable(ssm);
    }
    public DataSet Search_AllSalaryItems_SalaryItemTable(string condition)
    {
        return iSSM.Search_AllSalaryItems_SalaryItemTable(condition);
    }
    public DataSet Search_AllSalaryItems_SalaryItemTable(Guid g1, Guid g2)
    {
        return iSSM.Search_AllSalaryItems_SalaryItemTable(g1,g2);
    }
}