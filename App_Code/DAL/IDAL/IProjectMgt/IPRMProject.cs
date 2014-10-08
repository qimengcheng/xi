using System;
using System.Data;

/// <summary>
///IPRMProject 的摘要说明
/// </summary>
public interface  IPRMProject
{
    DataSet SelectPRMProject(string condition);
    DataSet SelectPRMProject_One(Guid PRMP_ID);
    DataSet SelectPRMP_DesignMangCheckOpinion(Guid PRMP_ID);
    void InsertPRMP_ResponDepart(Guid PRMP_ID, string PRMP_ResponDepart);
    void InsertPRMProject(string PRMP_ProductMode, string PRMP_ProjectType, string PRMP_Sample, string PRMP_ProjectName, string PRMP_ImproveAim, string PRMP_ImproveRequest, string PRMPA_Accessory, string PRMPA_AccNum, string PRMPA_AccPath, string PRMPA_AccState, string PRMPA_AccName, string PRMP_SupplyDepartment);
    void InsertPRMP_GeneralMangCheckOpinion(Guid PRMP_ID, string PRMP_GeneralMangCheckResult,string PRMP_GeneralMangCheckOpinion, string PRMP_ProjectStates, string PRMP_GeneralMangName);
    void InsertPRMP_DesignMangCheckOpinion(Guid PRMP_ID, string PRMPD_DesignMangCheckResult, string PRMPD_DesignMangCheckOpinion, string PRMPD_DesignMangCheckSate, string PRMPD_DesignMangName);
    void UpdatePRMP_ProjectStates(Guid PRMP_ID, string PRMP_ProjectStates);
    void UpdatePRMProject(Guid PRMP_ID, string PRMP_ProductMode, string PRMP_ProjectType, string PRMP_Sample, string PRMP_ProjectName, string PRMP_ImproveAim, string PRMP_ImproveRequest, string PRMPA_Accessory, string PRMPA_AccNum, string PRMPA_AccPath, string PRMPA_AccState, string PRMPA_AccName);
    DataSet SelectPRMProductMode(string condition);
    DataSet SelectProjectCheck(string Condition);
    void DeleteProject(Guid PRMP_ID);
    void UpdatePRMProjectCFOCheck(PRMProjectinfo pRMProjectinfo);
    void UpdatePRMProjectResponDepart(PRMProjectinfo pRMProjectinfo);
    void UpdatePRMProjectCountersign(PRMProjectinfo pRMProjectinfo);
    void InsertPRMProjectCountersign(PRMProjectinfo pRMProjectinfo);
    void UpdatePRMProjectAccessory(PRMProjectinfo pRMProjectinfo);
    DataSet SelectPRMProjectAccessory(string condition);
    void DeletePRMProjectAccessory(PRMProjectinfo pRMProjectinfo);
    void InsertPRMProjectAccessory(PRMProjectinfo pRMProjectinfo);
    DataSet SelectPRMProjectCountersign(string condition);
    void DeletePRMProjectCountersign(PRMProjectinfo pRMProjectinfo);
}