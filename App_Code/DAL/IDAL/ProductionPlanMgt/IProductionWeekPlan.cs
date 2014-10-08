using System;
using System.Data;

/// <summary>
///IProductionWeekPlan 的摘要说明
/// </summary>
public interface IProductionWeekPlan
{
    DataSet S_PWP(string condition);//检索生产周计划主表
    void I_PWP(ProductionWeekPlanInfo productionweekPlanInfo);//插入生产周计划
    void U_PWP(ProductionWeekPlanInfo productionweekPlanInfo);
    void U_PWP_Review(ProductionWeekPlanInfo productionWeekPlanInfo);//审核生产周计划
    DataSet S_PWPDetail(string condition);//检索生产周计划信息表
    void U_PWPDetail(Guid pWPD_ID, int pWPD_Plan, string pWPD_Note);//制定生产周详细计划
    void U_PWPDetail_Day(Guid pWPD_ID, int pWPD_D1, int pWPD_D2, int pWPD_D3, int pWPD_D4, int pWPD_D5, int pWPD_D6, string pWPD_Note);//制定生产周详细计划
    void U_PWP_State(Guid pwpid);//编辑生产周计划状态
    void I_ProType_PWPDetail(Guid sMSWPM_ID, Guid pT_ID, Guid pWP_ID);//插入新的产品型号到生产周计划详细表
    DataSet S_ProType_PWPDetail(Guid smswpmid, Guid ptid);//检查插入生产周计划的产品型号是否重复
    DataSet S_PWPDetail_ProSeriesNum(Guid sMSWPM_ID);//检索计划中产品系列数量
}