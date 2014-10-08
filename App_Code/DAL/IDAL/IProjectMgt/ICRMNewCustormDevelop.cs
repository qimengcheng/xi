using System.Data;

/// <summary>
///ICRMNewCustormDevelop 的摘要说明
/// </summary>
public interface ICRMNewCustormDevelop
{
    DataSet SelectCRMNewCustormDevelop(string condition);
    DataSet SelectCRMCustomerInfo_New();
    void InsertCRMNewCustormDevelop(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo);
    void UpdateCRMNewCustormDevelop_Info(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo);
    void UpdateCRMNewCustormDevelop_Schedule(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo);
    void DeleteCRMNewCustormDevelop(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo);

}