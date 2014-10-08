using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
/// <summary>
///PMSupplyMaterialL 的摘要说明
/// </summary>
public class PMSupplyMaterialL
{
    private static readonly IPMSupplyMaterial PRMP = DALFactory.CreatePMSupplyMaterial();
	public PMSupplyMaterialL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPMPurchaseingApplyRule()
    { 
    return PRMP.SelectPMPurchaseingApplyRule();
    }
    public DataSet SelectPMPurchaseingApply(string condition)
    { 
    return PRMP.SelectPMPurchaseingApply(condition);
    }
    public void InsertPMPurchaseingApply(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.InsertPMPurchaseingApply(pMPurchaseingApplyRuleinfo);
    }
    public DataSet SelectPMPurchaseSMaterial( string condition)
    {
        return PRMP.SelectPMPurchaseSMaterial(condition);
    }
    public DataSet SelectPMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        return PRMP.SelectPMPurchaseApplyDetail(pMPurchaseingApplyRuleinfo);
    }
    public void DeletePMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.DeletePMPurchaseApplyDetail(pMPurchaseingApplyRuleinfo);
    }
    public void UpdatePMPurchaseApplySate(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.UpdatePMPurchaseApplySate(pMPurchaseingApplyRuleinfo);
    }
    public void UpdatePMPAM_AppDepartMang(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    { 
   PRMP.UpdatePMPAM_AppDepartMang(pMPurchaseingApplyRuleinfo);
    }
    public void UpdatePMPAM_CFECheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.UpdatePMPAM_CFECheck(pMPurchaseingApplyRuleinfo);
    }
    public void UpdatePMPAM_CFOCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    { 
    PRMP.UpdatePMPAM_CFOCheck(pMPurchaseingApplyRuleinfo);
    }
    public DataSet SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    { 
    return PRMP.SelectPMPAM_CheckOpinion(pMPurchaseingApplyRuleinfo);
    }
    public void InsertPMPurchaseingApplyMain(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.InsertPMPurchaseingApplyMain(pMPurchaseingApplyRuleinfo);
    }
    public DataSet SelectPMPurchaseApplyOne(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        return PRMP.SelectPMPurchaseApplyOne(pMPurchaseingApplyRuleinfo);
    }
    public void DeletePMPurchaseApplyMain(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.DeletePMPurchaseApplyMain(pMPurchaseingApplyRuleinfo);
    }
    public void UpdatePMPAM_EmergencyPur(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.UpdatePMPAM_EmergencyPur(pMPurchaseingApplyRuleinfo);
    }

    public void UpdatePMPAM_DesignMangCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.UpdatePMPAM_DesignMangCheck(pMPurchaseingApplyRuleinfo);
    }
    public void UpdatePMPAM_DeptMangCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.UpdatePMPAM_DeptMangCheck(pMPurchaseingApplyRuleinfo);
    }
    public void UpdatePMPAM_PersonalCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.UpdatePMPAM_PersonalCheck(pMPurchaseingApplyRuleinfo);
    }
    public DataSet SelectPMPurchaseApplyDetail_LB(string condition)
    {
       return PRMP.SelectPMPurchaseApplyDetail_LB(condition);
    }
    public void UpdatePMPurchaseingApplyMain_ID(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        PRMP.UpdatePMPurchaseingApplyMain_ID(pMPurchaseingApplyRuleinfo);
    }
}