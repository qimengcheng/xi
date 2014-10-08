using System.Data;

/// <summary>
///CRMNewCustormDevelopL 的摘要说明
/// </summary>
public class CRMNewCustormDevelopL
{
    private static readonly ICRMNewCustormDevelop PMP = DALFactory.CreateCRMNewCustormDevelop();
	public CRMNewCustormDevelopL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectCRMNewCustormDevelop(string condition)
    {
        return PMP.SelectCRMNewCustormDevelop(condition);
    }
    public DataSet SelectCRMCustomerInfo_New()
    {
        return PMP.SelectCRMCustomerInfo_New();
    }
    public void InsertCRMNewCustormDevelop(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
    {
        PMP.InsertCRMNewCustormDevelop(cRMNewCustormDevelopinfo);
    }
    public void UpdateCRMNewCustormDevelop_Info(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
    {
        PMP.UpdateCRMNewCustormDevelop_Info(cRMNewCustormDevelopinfo);
    }
    public void UpdateCRMNewCustormDevelop_Schedule(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
    {
        PMP.UpdateCRMNewCustormDevelop_Schedule(cRMNewCustormDevelopinfo);
    }
    public void DeleteCRMNewCustormDevelop(CRMNewCustormDevelopinfo cRMNewCustormDevelopinfo)
    {
        PMP.DeleteCRMNewCustormDevelop(cRMNewCustormDevelopinfo);
    }
}