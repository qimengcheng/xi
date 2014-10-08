using System;
using System.Data;

/// <summary>
///PRMProjectL 的摘要说明
/// </summary>
public class PRMProjectL
{
    private static readonly IPRMProject PRMP = DALFactory.CreatePRMProject();
	public PRMProjectL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPRMProject(string condition)
    {
       return  PRMP.SelectPRMProject(condition);

    }
    public DataSet SelectPRMProject_One(Guid PRMP_ID)
         {
            return PRMP.SelectPRMProject_One( PRMP_ID);
          }
    public DataSet SelectPRMP_DesignMangCheckOpinion(Guid PRMP_ID)
    {
        return PRMP.SelectPRMP_DesignMangCheckOpinion(PRMP_ID);
    }
    public void InsertPRMProject(string PRMP_ProductMode, string PRMP_ProjectType, string PRMP_Sample, string PRMP_ProjectName, string PRMP_ImproveAim, string PRMP_ImproveRequest, string PRMPA_Accessory, string PRMPA_AccNum, string PRMPA_AccPath, string PRMPA_AccState, string PRMPA_AccName, string PRMP_SupplyDepartment)
    {
        PRMP.InsertPRMProject(PRMP_ProductMode, PRMP_ProjectType, PRMP_Sample, PRMP_ProjectName, PRMP_ImproveAim, PRMP_ImproveRequest, PRMPA_Accessory, PRMPA_AccNum, PRMPA_AccPath, PRMPA_AccState, PRMPA_AccName, PRMP_SupplyDepartment);
    }
    public void InsertPRMP_GeneralMangCheckOpinion(Guid PRMP_ID, string PRMP_GeneralMangCheckResult,string PRMP_GeneralMangCheckOpinion, string PRMP_ProjectStates, string PRMP_GeneralMangName)
    {
        PRMP.InsertPRMP_GeneralMangCheckOpinion(PRMP_ID, PRMP_GeneralMangCheckResult, PRMP_GeneralMangCheckOpinion,PRMP_ProjectStates, PRMP_GeneralMangName);
    
    }
    public void InsertPRMP_DesignMangCheckOpinion(Guid PRMP_ID, string PRMPD_DesignMangCheckResult, string PRMPD_DesignMangCheckOpinion, string PRMPD_DesignMangCheckSate, string PRMPD_DesignMangName)
    {
        PRMP.InsertPRMP_DesignMangCheckOpinion(PRMP_ID, PRMPD_DesignMangCheckResult, PRMPD_DesignMangCheckOpinion, PRMPD_DesignMangCheckSate, PRMPD_DesignMangName);
    }
    public void InsertPRMP_ResponDepart(Guid PRMP_ID, string PRMP_ResponDepart)
    {
        PRMP.InsertPRMP_ResponDepart(PRMP_ID, PRMP_ResponDepart);
    }
    public void UpdatePRMP_ProjectStates(Guid PRMP_ID, string PRMP_ProjectStates)
    {
        PRMP.UpdatePRMP_ProjectStates(PRMP_ID, PRMP_ProjectStates);
    }
    public void UpdatePRMProject(Guid PRMP_ID, string PRMP_ProductMode, string PRMP_ProjectType, string PRMP_Sample, string PRMP_ProjectName, string PRMP_ImproveAim, string PRMP_ImproveRequest, string PRMPA_Accessory, string PRMPA_AccNum, string PRMPA_AccPath, string PRMPA_AccState, string PRMPA_AccName)
    {
        PRMP.UpdatePRMProject( PRMP_ID, PRMP_ProductMode, PRMP_ProjectType,  PRMP_Sample, PRMP_ProjectName,PRMP_ImproveAim, PRMP_ImproveRequest, PRMPA_Accessory, PRMPA_AccNum, PRMPA_AccPath, PRMPA_AccState,PRMPA_AccName);
    }
    public DataSet SelectPRMProductMode(string condition)
    {
        return PRMP.SelectPRMProductMode(condition);
    }
    public DataSet SelectProjectCheck(string Condition)
    {
        return PRMP.SelectProjectCheck(Condition);
    }
    public void DeleteProject(Guid PRMP_ID)
    {
        PRMP.DeleteProject(PRMP_ID);
    }
    public void UpdatePRMProjectCFOCheck(PRMProjectinfo pRMProjectinfo)
    { 
    PRMP.UpdatePRMProjectCFOCheck(pRMProjectinfo);
    }
    public void UpdatePRMProjectResponDepart(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.UpdatePRMProjectResponDepart(pRMProjectinfo);
    }
    public void UpdatePRMProjectCountersign(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.UpdatePRMProjectCountersign(pRMProjectinfo);
    }
    public void InsertPRMProjectCountersign(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.InsertPRMProjectCountersign(pRMProjectinfo);
    }
    public void UpdatePRMProjectAccessory(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.UpdatePRMProjectAccessory(pRMProjectinfo);
    }
    public DataSet SelectPRMProjectAccessory(string condition)
    {
        return PRMP.SelectPRMProjectAccessory(condition);
    }
    public void DeletePRMProjectAccessory(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.DeletePRMProjectAccessory(pRMProjectinfo);
    }
    public void InsertPRMProjectAccessory(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.InsertPRMProjectAccessory(pRMProjectinfo);
    }
    public DataSet SelectPRMProjectCountersign(string condition)
    {
        return PRMP.SelectPRMProjectCountersign(condition);
    }
    public void DeletePRMProjectCountersign(PRMProjectinfo pRMProjectinfo)
    {
        PRMP.DeletePRMProjectCountersign(pRMProjectinfo);
    }
}