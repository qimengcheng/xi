using System;
using System.Data;

///PMPurchaseingApplyRuleL 的摘要说明
/// </summary>
public class PMPurchaseingApplyRuleL
{
    private static readonly IPMPurchaseingApplyRule Supply = DALFactory.CreatePMPurchaseingApplyRule();
	public PMPurchaseingApplyRuleL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public void InsertPMPurchaseingApplyRule(  string PMPAR_Man, string PMPAR_Rule)
    {
        Supply.InsertPMPurchaseingApplyRule(  PMPAR_Man, PMPAR_Rule);
    }
    public DataSet SelectPMPurchaseingApplyRule(string condition)
    {
        return Supply.SelectPMPurchaseingApplyRule(condition);
    }
    public DataSet SelectPMPurchaseingApplyRule_One(string condition)
    {
        return Supply.SelectPMPurchaseingApplyRule_One(condition);
    }
    public int DeletePMPurchaseingApplyRule(Guid PMPAR_ID)
    { 
        return Supply.DeletePMPurchaseingApplyRule( PMPAR_ID);
    }
    public void UpdatePMPurchaseingApplyRule(Guid PMPAR_ID, string PMPAR_Rule)
    {
        Supply.UpdatePMPurchaseingApplyRule(PMPAR_ID, PMPAR_Rule);
    }
}