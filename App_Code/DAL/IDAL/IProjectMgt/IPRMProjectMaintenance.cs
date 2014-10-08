using System.Data;

/// <summary>
///IPRMProjectMaintenance 的摘要说明
/// </summary>
public interface  IPRMProjectMaintenance
{
    DataSet SelectPRMProject_Maintenance(string condition);
    DataSet SelectPRMProject(PRMProjectinfo pRMProjectinfo);
    void InsertPRMProject_Postpone(PRMProjectinfo pRMProjectinfo);
    void InsertPRMProject_Schedule(PRMProjectinfo pRMProjectinfo);
    DataSet SelectPRMProject_Schedule(PRMProjectinfo pRMProjectinfo);
    DataSet SelectPRMProject_WOrder_One(string condition);
    void InsertPRMPS_Accessory(PRMProjectinfo pRMProjectinfo);
    DataSet SelectPRMProject_WOrder_Protect(string condition);
}