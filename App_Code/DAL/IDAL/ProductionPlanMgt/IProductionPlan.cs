using System;
using System.Data;

/// <summary>
///IProductionPlan 的摘要说明
/// </summary>
public interface IProductionPlan
{
    DataSet S_PMP(string condition);
    void I_PMP(ProductionPlanInfo productionPlanInfo);//插入生产月计划
    void U_PMP(ProductionPlanInfo productionPlanInfo);//编辑生产月计划
    void U_PMP_Review(ProductionPlanInfo productionPlanInfo);//编辑生产月计划
    DataSet S_PMPDetail(string condition);//查看生产某月计划详细
    void I_PMPDetail(ProductionPlanInfo productionPlanInfo);//插入生产月详细计划
    void U_SMSalesMonthPlanDetail_PMPDetail(ProductionPlanInfo productionPlanInfo);//制定生产月详细计划
    void U_PMP_State(Guid pmpid);//提交生产月计划
    void U_SMSalesMonthPlanDetail_PMP_State(Guid sMSMPM_ID);//提交生产月新增计划
    void Insert_I_ProType_PMPDetail(Guid MonthPlanID, Guid PT_ID, string neworold);//插入新的产品型号到生产月计划详细表
    DataSet S_ProType_PMPDetail(Guid MonthPlanID, Guid PT_ID, string neworold);//判断插入新的产品型号到生产月计划详细表是否重复
    void U_PMPNewAddDetail_Review(Guid smsmpdid, string man, string suggestion, string result);//审核生产月新增计划
    DataSet S_PMPCountersignBasic(string Condition);//检索生产月计划会签基础表
    void I_PMPCountersignBasic(string BDOS_Code, int PMPCB_Type);//新增生产月计划会签基础表
    void D_PMPCountersignBasic(Guid PMPCB_ID);//删除生产月计划会签基础表
    DataSet S_PMPCountersignBasic_BD(string Condition);//检索生产月计划会签基础表待选部门

}