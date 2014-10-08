using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Collections;

/// <summary>
///IPMSupplyMaterial 的摘要说明
/// </summary>
public interface IPMSupplyMaterial
{
	DataSet SelectPMPurchaseingApplyRule();
    DataSet SelectPMPurchaseingApply(string condition);
    void InsertPMPurchaseingApply(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    DataSet SelectPMPurchaseSMaterial(string condition);
    DataSet SelectPMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void DeletePMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPurchaseApplySate(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPAM_AppDepartMang(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPAM_CFECheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPAM_CFOCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    DataSet SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void InsertPMPurchaseingApplyMain(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    DataSet SelectPMPurchaseApplyOne(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void DeletePMPurchaseApplyMain(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPAM_EmergencyPur(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPAM_DeptMangCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPAM_DesignMangCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    void UpdatePMPAM_PersonalCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
    DataSet SelectPMPurchaseApplyDetail_LB(string condition);
    void UpdatePMPurchaseingApplyMain_ID(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);
}