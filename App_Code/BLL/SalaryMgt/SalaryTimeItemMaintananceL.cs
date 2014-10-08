using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///SalaryTimeItemMaintananceL 的摘要说明
/// </summary>
public class SalaryTimeItemMaintananceL
{
    private static readonly ISalaryTimeItemMaintanance iSTIM = DALFactory.CreateISalaryTimeItemMaintanance();
	public SalaryTimeItemMaintananceL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_SalaryTimeItem(SalaryTimeItemMaintananceInfo sTIMI)
    {
        return iSTIM.Insert_SalaryTimeItem(sTIMI);
    }

    public int Insert_SalaryTimeItemRecord(SalaryTimeItemChangeRecordInfo STIML)
    {
        return iSTIM.Insert_SalaryTimeItemRecord(STIML);
    }
    public int Update_SalaryTimeItem(SalaryTimeItemMaintananceInfo sTIMI)
    {
        return iSTIM.Update_SalaryTimeItem(sTIMI);
    }
    public DataSet Search_SalaryTimeItemHistory(Guid ID)
    {
        return iSTIM.Search_SalaryTimeItemHistory(ID);
    }
    public int Delete_SalaryTimeItem(Guid ID)
    {
        return iSTIM.Delete_SalaryTimeItem(ID);
    }

    public DataSet SearchByCondition_SalaryTimeItem(string Condition)
    {
        return iSTIM.SearchByCondition_SalaryTimeItem(Condition);
    }

    public IList<SalaryTimeItemMaintananceInfo> SearchByID_SalaryTimeItem(Guid STI_ID)
    {
        return iSTIM.SearchByID_SalaryTimeItem(STI_ID);
    }
    public DataSet SearchCraftForDdl_SalaryTimeItem()
    {
        return iSTIM.SearchCraftForDdl_SalaryTimeItem();
    }
}