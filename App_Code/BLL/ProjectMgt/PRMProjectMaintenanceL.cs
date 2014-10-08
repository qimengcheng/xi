using System.Data;

/// <summary>
///PRMProjectMaintenanceL 的摘要说明
/// </summary>
public class PRMProjectMaintenanceL
{
    private static readonly IPRMProjectMaintenance PRMP = DALFactory.CreatePRMProjectMaintenance();
	public PRMProjectMaintenanceL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPRMProject_Maintenance(string condition)
    {
        return PRMP.SelectPRMProject_Maintenance(condition);
    }
    public DataSet SelectPRMProject(PRMProjectinfo pRMProjectinfo)
    {
        return PRMP.SelectPRMProject(pRMProjectinfo);
    }
    public void InsertPRMProject_Postpone(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.InsertPRMProject_Postpone(pRMProjectinfo);
    }
    public void InsertPRMProject_Schedule(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.InsertPRMProject_Schedule(pRMProjectinfo);
    }

    public DataSet SelectPRMProject_Schedule(PRMProjectinfo pRMProjectinfo)
    {
        return PRMP.SelectPRMProject_Schedule(pRMProjectinfo);
    }
    public DataSet SelectPRMProject_WOrder_One(string condition)
    {
        return PRMP.SelectPRMProject_WOrder_One(condition);
    }
    public void InsertPRMPS_Accessory(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.InsertPRMPS_Accessory(pRMProjectinfo);
    }
    public DataSet SelectPRMProject_WOrder_Protect(string condition)
    {
        return PRMP.SelectPRMProject_WOrder_Protect(condition);
    }
}