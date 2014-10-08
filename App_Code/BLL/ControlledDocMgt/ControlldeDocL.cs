using System;
using System.Data;

/// <summary>
///ControlldeDocL 的摘要说明
/// </summary>
public class ControlldeDocL
{
    private static readonly IControlldeDoc equipm = DALFactory.CreateControlldeDoc();
	public ControlldeDocL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public Guid Insert_ControlledDocApp(string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                            string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, string CDTLC_DocType, DateTime CDA_EffectDate)
    {
        return equipm.Insert_ControlledDocApp(CDA_DocName, CDA_EditionNO, CDA_DocType, CDA_ChangedType, CDA_AppPer, CDA_AppTime, CDA_AppDep, CDA_AppReason, CDA_AppState, CDA_Remarks, CDA_DocRoute, CDTLC_DocType,  CDA_EffectDate);
         
    }
    public void Update_ControlledDocApp(Guid CDA_ID, string CDA_DocName, string CDA_EditionNO, string CDA_AppPer, DateTime CDA_AppTime, string CDA_AppReason,
                                       string CDA_AppState, string CDA_Remarks, string CDA_ChangedType, DateTime CDA_EffectDate)
    {
        equipm.Update_ControlledDocApp(CDA_ID, CDA_DocName, CDA_EditionNO, CDA_AppPer, CDA_AppTime, CDA_AppReason,CDA_AppState, CDA_Remarks, CDA_ChangedType, CDA_EffectDate);
    }
    public int Delete_ControlledDocApp(Guid CDA_ID)
    {
        return equipm.Delete_ControlledDocApp(CDA_ID);
    }
    public DataSet Search_ControlledDocApp_APP(string condition)
    {
        return equipm.Search_ControlledDocApp_APP(condition);
    }
    public DataSet Search_CDThirdLevelCode_DocType()
    {
        return equipm.Search_CDThirdLevelCode_DocType();
    }
    public void Insert_CDDepDistributeDetail(Guid CDDDCT_ID, Guid CDA_ID)
    {
        equipm.Insert_CDDepDistributeDetail(CDDDCT_ID, CDA_ID);
    }
    public DataSet Search_CDDepDistributeDetail(string condition)
    {
        return equipm.Search_CDDepDistributeDetail(condition);
    }
    public int Delete_CDDepDistributeDetail(Guid CDDDD_ID)
    {
        return equipm.Delete_CDDepDistributeDetail(CDDDD_ID);
    }
    public DataSet Search_BDOrganization_CDAppConSignT(string condition)
    { 
        return equipm.Search_BDOrganization_CDAppConSignT( condition);
    }
    public void Insert_CDAppConSignT(string BDOS_Code, Guid CDA_ID)
    {
        equipm.Insert_CDAppConSignT(BDOS_Code, CDA_ID);
    }
    public DataSet Search_CDAppConSignT(string condition)
    {
        return equipm.Search_CDAppConSignT(condition);
    }
    public int Delete_CDAppConSignT(Guid CDAST_ID)
    {
        return equipm.Delete_CDAppConSignT(CDAST_ID);
    }
    public void Update_ControlledDocApp_specil(Guid CDA_ID, string CDA_DocNO)
    {
        equipm.Update_ControlledDocApp_specil(CDA_ID, CDA_DocNO);
    }
    public void Update_ControlledDocApp_Au(Guid CDA_ID, string CDA_Auditor, DateTime CDA_AuTime, string CDA_AuSugg, string ETA_AuRes, string CDA_AppState)
    { 
        equipm.Update_ControlledDocApp_Au( CDA_ID, CDA_Auditor, CDA_AuTime, CDA_AuSugg, ETA_AuRes, CDA_AppState);
    }
    public void Update_ControlledDocApp_Approval(Guid CDA_ID, string CDA_Approver, DateTime CDA_ApprovalT, string CDA_ApprovalSugg, string CDA_ApprovalRes, string CDA_AppState)
    { 
        equipm.Update_ControlledDocApp_Approval( CDA_ID, CDA_Approver, CDA_ApprovalT, CDA_ApprovalSugg, CDA_ApprovalRes, CDA_AppState);
    }
    public void Update_CDAppConSignT(Guid CDAST_ID, string CDAST_SignPer, DateTime CDAST_SignTime, string CDAST_SignSugg, string CDAST_SignRes)
    { 
        equipm.Update_CDAppConSignT(CDAST_ID, CDAST_SignPer, CDAST_SignTime, CDAST_SignSugg, CDAST_SignRes);
    }
    public void Update_ControlledDocApp_State(Guid CDA_ID)
    {
        equipm.Update_ControlledDocApp_State(CDA_ID);
    }
    public Guid Insert_ControlledDocApp_change(string CDA_DocNO, string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                            string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, DateTime CDA_EffectDate)
    {
        return equipm.Insert_ControlledDocApp_change(CDA_DocNO,CDA_DocName,CDA_EditionNO,CDA_DocType,CDA_ChangedType,CDA_AppPer,CDA_AppTime,CDA_AppDep,CDA_AppReason,CDA_AppState,CDA_Remarks,CDA_DocRoute, CDA_EffectDate);
    }
    public DataSet Search_ControlledDocApp_change_newest(string CDA_DocNO)
    {
        return equipm.Search_ControlledDocApp_change_newest(CDA_DocNO);
    }
    //增加受控文件申请--特殊通道
    public void Insert_ControlledDocApp_Specil(string CDA_DocNO, string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                        string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, string CDTLC_DocType, string CDA_AppNO, DateTime CDA_EffectDate)
    {
        equipm.Insert_ControlledDocApp_Specil(CDA_DocNO, CDA_DocName, CDA_EditionNO, CDA_DocType, CDA_ChangedType, CDA_AppPer, CDA_AppTime,
                                        CDA_AppDep, CDA_AppReason, CDA_AppState, CDA_Remarks, CDA_DocRoute, CDTLC_DocType, CDA_AppNO, CDA_EffectDate);
    }
    public void Update_ControlledDocApp_Specil_No(Guid CDA_ID, string CDA_DocNO, string CDA_AppNO)
    {
        equipm.Update_ControlledDocApp_Specil_No( CDA_ID, CDA_DocNO, CDA_AppNO);
    }
}