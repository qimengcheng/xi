using System;
using System.Data;

/// <summary>
///IErrorRelevant 的摘要说明
/// </summary>
public interface IErrorRelevant
{
    DataSet S_WorkOrder_Check(string condition);//随工单查看
    DataSet S_WorkOrderDetail_ErrorCheck(Guid wOD_ID);//查看随工单详细的异常信息
    DataSet S_WOError(Guid wOE_ID);//查看详细的异常信息
    void U__WOError_MQC(Guid woeid, string wOE_MQCPeople, string wOE_QCResult);//编辑异常材料检验信息
    void U_WOError_Deal(Guid woeid, string wOE_DealMan, string wOE_ReaAnalysis, string wOE_ProDeal, string wOE_LongTimeMeasure);//编辑异常材料处理信息
    void U_WOError_Track(Guid woeid, string wOE_TrackMan, string wOE_TrackResult);//编辑异常跟踪信息
    void U_WOError_Review(Guid woeid, string wOE_ReviewMan, string wOE_ReviewSuggestion, string wOE_RResult);//编辑异常审核信息
    void U_WOError_Done(Guid woeid, string wOE_DoneMan, string wOE_QCResult, string wOE_DoneResult, string wOE_State);//编辑异常结案信息
    void U_WOError_Rework(Guid woeid, Guid pBC_ID, string wOE_ReworkAppMan, Guid rWO_ID, DateTime wOE_ReWorkDate, int wOE_ReworkNum, string wOE_ReworkDetail);//编辑异常返工信息
    DataSet S_WOError_Rework_ReWorkOption();//返工信息待选返工选项
    DataSet S_WOError_Rework_PBCraft();//返工信息待选工序

}