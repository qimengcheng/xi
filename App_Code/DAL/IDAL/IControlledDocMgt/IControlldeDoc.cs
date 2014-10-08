using System;
using System.Data;

/// <summary>
///IControlldeDoc 的摘要说明
/// </summary>
public interface IControlldeDoc
{
    Guid Insert_ControlledDocApp(string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                        string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, string CDTLC_DocType, DateTime CDA_EffectDate);
    void Update_ControlledDocApp(Guid CDA_ID, string CDA_DocName, string CDA_EditionNO, string CDA_AppPer, DateTime CDA_AppTime, string CDA_AppReason,
        string CDA_AppState, string CDA_Remarks, string CDA_ChangedType, DateTime CDA_EffectDate);
    int Delete_ControlledDocApp(Guid CDA_ID);
    DataSet Search_ControlledDocApp_APP(string condition);
    DataSet Search_CDThirdLevelCode_DocType();
    void Insert_CDDepDistributeDetail(Guid CDDDCT_ID, Guid CDA_ID);
    DataSet Search_CDDepDistributeDetail(string condition);
    int Delete_CDDepDistributeDetail(Guid CDDDD_ID);
    DataSet Search_BDOrganization_CDAppConSignT(string condition);
    void Insert_CDAppConSignT(string BDOS_Code, Guid CDA_ID);
    DataSet Search_CDAppConSignT(string condition);
    int Delete_CDAppConSignT(Guid CDAST_ID);
    void Update_ControlledDocApp_specil(Guid CDA_ID, string CDA_DocNO);
    void Update_ControlledDocApp_Au(Guid CDA_ID, string CDA_Auditor, DateTime CDA_AuTime, string CDA_AuSugg, string ETA_AuRes, string CDA_AppState);
    void Update_ControlledDocApp_Approval(Guid CDA_ID, string CDA_Approver, DateTime CDA_ApprovalT, string CDA_ApprovalSugg, string CDA_ApprovalRes, string CDA_AppState);
    void Update_CDAppConSignT(Guid CDAST_ID, string CDAST_SignPer, DateTime CDAST_SignTime, string CDAST_SignSugg, string CDAST_SignRes);
    void Update_ControlledDocApp_State(Guid CDA_ID);
    Guid Insert_ControlledDocApp_change(string CDA_DocNO, string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                            string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, DateTime CDA_EffectDate);
    DataSet Search_ControlledDocApp_change_newest(string CDA_DocNO);
    void Insert_ControlledDocApp_Specil(string CDA_DocNO, string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                        string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, string CDTLC_DocType, string CDA_AppNO, DateTime CDA_EffectDate);
    void Update_ControlledDocApp_Specil_No(Guid CDA_ID, string CDA_DocNO, string CDA_AppNO);
}