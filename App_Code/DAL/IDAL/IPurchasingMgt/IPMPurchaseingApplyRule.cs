using System;
using System.Data;

/// <summary>
///IPMPurchaseingApplyRule 的摘要说明
/// </summary>

	public interface  IPMPurchaseingApplyRule
	{
		void InsertPMPurchaseingApplyRule(string PMPAR_Man,string PMPAR_Rule);
        DataSet   SelectPMPurchaseingApplyRule(string condition);
        DataSet SelectPMPurchaseingApplyRule_One(string condition);
        int DeletePMPurchaseingApplyRule(Guid PMPAR_ID);
        void UpdatePMPurchaseingApplyRule(Guid PMPAR_ID, string PMPAR_Rule);
	}
