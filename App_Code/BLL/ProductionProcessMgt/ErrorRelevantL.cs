using System;
using System.Data;
/// <summary>
///ErrorRelevantL 的摘要说明
/// </summary>
public class ErrorRelevantL
{
    private static readonly IErrorRelevant ier = DALFactory.CreateErrorRelevant();
    public ErrorRelevantL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet S_WorkOrder_Check(string condition)//随工单查看
    {
        return ier.S_WorkOrder_Check(condition);

    }

    public DataSet S_WorkOrderDetail_ErrorCheck(Guid wOD_ID)//查看随工单详细的异常信息
    {
        return ier.S_WorkOrderDetail_ErrorCheck(wOD_ID);
    }
    public DataSet S_WOError(Guid wOE_ID)//查看详细的异常信息
    {
        return ier.S_WOError(wOE_ID);
    }
    public void U__WOError_MQC(Guid woeid, string wOE_MQCPeople, string wOE_QCResult)//编辑异常材料检验信息
    {

        ier.U__WOError_MQC(woeid, wOE_MQCPeople, wOE_QCResult);
    }

    public void U_WOError_Deal(Guid woeid, string wOE_DealMan, string wOE_ReaAnalysis, string wOE_ProDeal, string wOE_LongTimeMeasure)//编辑异常材料处理信息
    {
        ier.U_WOError_Deal(woeid, wOE_DealMan, wOE_ReaAnalysis, wOE_ProDeal, wOE_LongTimeMeasure);
    }
    public void U_WOError_Track(Guid woeid, string wOE_TrackMan, string wOE_TrackResult)//编辑异常跟踪信息
    {

        ier.U_WOError_Track(woeid, wOE_TrackMan, wOE_TrackResult);
    }

    public void U_WOError_Review(Guid woeid, string wOE_ReviewMan, string wOE_ReviewSuggestion, string wOE_RResult)//编辑异常审核信息
    {
        ier.U_WOError_Review(woeid, wOE_ReviewMan, wOE_ReviewSuggestion, wOE_RResult);
    }
    public void U_WOError_Done(Guid woeid, string wOE_DoneMan, string wOE_QCResult, string wOE_DoneResult, string wOE_State)//编辑异常结案信息
    {
        ier.U_WOError_Done(woeid, wOE_DoneMan, wOE_QCResult, wOE_DoneResult, wOE_State);
    }
    public void U_WOError_Rework(Guid woeid, Guid pBC_ID, string wOE_ReworkAppMan, Guid rWO_ID, DateTime wOE_ReWorkDate, int wOE_ReworkNum, string wOE_ReworkDetail)//编辑异常返工信息
    {
        ier.U_WOError_Rework(woeid, pBC_ID, wOE_ReworkAppMan, rWO_ID, wOE_ReWorkDate, wOE_ReworkNum,wOE_ReworkDetail);
    }
    public DataSet S_WOError_Rework_PBCraft()//返工信息待选工序

    {
        return ier.S_WOError_Rework_PBCraft();
    }
    public DataSet S_WOError_Rework_ReWorkOption()//返工信息待选返工选项
    {
        return ier.S_WOError_Rework_ReWorkOption();
    }
}