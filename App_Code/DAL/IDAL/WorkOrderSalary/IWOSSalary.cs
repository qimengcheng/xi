using System;
using System.Data;

/// <summary>
///IWOSSalary 的摘要说明
/// </summary>
public interface IWOSSalary
{
    DataSet S_LaborCostSeries(string condition);//检索工价系列
    void D_LaborCostSeries(Guid lCS_ID);//删除工价系列
    DataSet S_LaborCostSeries_panchong(string lCS_Name);//工价系列判重
    void I_LaborCostSeries(string lCS_Name);//工价系列新增
    void U_LaborCostSeries(string lCS_Name, Guid lCS_ID);//工价系列编辑
    DataSet S_LaborCostSeries_ProType(Guid lCS_ID);//工价系列所属产品型号
    void D_LaborCostSeries_ProType(Guid pT_ID);//工价系列删除所属产品型号
    DataSet S_LaborCostSeries_ProType_Condition(string condition);//工价系列显示待选产品型号
    void I_LaborCostSeries_ProType(Guid pT_ID, Guid lCS_ID);//新增工价系列所属产品型号
    DataSet S_WorkingTeam(string condition);//检索班组信息
    void I_WorkingTeam(string wT_People, string wT_Name);//新增班组信息
    void u_WorkingTeam(Guid wT_ID, string wT_People, string wT_Name);//编辑班组信息
    void D_WorkingTeam(Guid wT_ID);//删除班组信息
    DataSet S_WorkTeamDetailList(Guid wT_ID);//检索班组详细信息
    void D_WorkTeamDetailList(Guid wTDL_ID);//删除班组信息
    DataSet S_WorkTeamDetailList_HRDDetail(string condition);//检索待选员工
    void I_WorkTeamDetailList_HRDDetail(Guid wT_ID, Guid hRDD_ID);//添加员工至班组详细表
    DataSet S_WorkTimePiece_ByProDept(string condition);//显示计时计件主表
    DataSet S_OperatorInfo(string condition, string wOD_OutTime);//显示某一天的计件信息
    void D_WorkTimePiece_ByProDept(Guid wTP_ID);//删除计时计件主表
    void I_WorkTimePiece_ByProDept(DateTime wTP_Date);//新增计时计件主表信息
    DataSet S_OTime(string condition, string wOD_OutTime);//显示某一天的生产计时信息
    DataSet S_OTime_OT_NORelated(string condition, string oT_NORelated_Date);//显示某一天的非生产相关计时信息
    DataSet S_WorkTimePiece_ByID(Guid wTP_ID);//通过ID查询计时计件核算表
    void U_WorkTimePiece_PReview(Guid wTP_ID, string wTP_PRMan, string wTP_PSuggestion, string wTP_PieceRState);//计时计件核算表计件审核
    void U_WorkTimePiece_TReview(Guid wTP_ID, string wTP_TRMan, string wTP_TSuggestion, string wTP_TimeRState);//计时计件核算表计件审核
    DataSet S_TimeSalaryDate(string condition);//显示计时提报日期
    void I_TimeSalaryDate(DateTime tSD_Date);//新增计时提报日期
    void D_TimeSalaryDate(Guid tSD_ID);//删除计时提报日期
    DataSet S_TimeSalaryDateDetail(string tSD_ID, string condition);//显示某一天的提报计时项目信息
    DataSet S_TimeSalaryDateDetail_SalaryTimeItem(string tSD_ID, string condition);//显示待添加的提报计时项目信息
    void I_TimeSalaryDateDetail(Guid tSD_ID, Guid sTI_ID, string tSDD_Man);//添加提报计时项目信息
    void D_TimeSalaryDateDetail(Guid tSDD_ID);//删除提报计时项目信息及其详细信息
    DataSet S_TimeSalaryDateDetail_Panduan(Guid tSD_ID);//判断某计时提报日期已经制定了详细信息
    DataSet S_OTime_TimeSalaryDateDetail(string tSDD_ID, string condition);//显示某天计时项目信息的详细信息
    void U_OTime(Guid oT_ID, decimal oT_Time, int oT_Num);//制定计时提报详细信息的计时时间和生产数量
    void D_OTime(Guid oT_ID);//删除计时提报详细信息
    DataSet S_OTime_HRDDetail(string tSDD_ID, string condition);//计时提报待选员工
    void I_OTime_HRDDetail(Guid sTI_ID, Guid tSDD_ID, Guid hRDD_ID);//计时提报添加待选员工
    void U_TimeSalaryDateDetail(Guid tSDD_ID);//提交计时提报详细
    DataSet S_AssemblyPieceDate(string condition);//查看装配计件核算日期
    void I_AssemblyPieceDate(DateTime aPD_Date, string aPD_Man);//新增装配计件核算日期
    void D_AssemblyPieceDate(Guid aPD_ID);//删除装配计件核算日期
    DataSet S_AssemblyTeamMember_Detai(string condition, string lCS_ID, string aPD_ID);//检索装配计件详情
    void D_AssemblyTeamMember_Detail(Guid aTM_ID);//删除装配计件详情
    void U_AssemblyTeamMember_Detail(Guid aTM_ID, decimal aTM_LaborHour);//编辑装配计件详情
    DataSet S_AssemblyPieceDate_Shanchupanduan(Guid aPD_ID);//装配计件删除判断
    void I_AssemblyTeamMember_HRDDetail(Guid hRDD_ID, Guid aPD_ID, Guid lCS_ID);//装配计件添加待选员工
    DataSet S_AssemblyTeamMember_HRDDetail(string aPD_ID, string lCS_ID, string condition);//装配计件待选员工
    DataSet S_OperatorInfo_WorkOrder_ForOne(Guid pBC_ID, string wOD_OutTime, string ptname, Guid HRDD_ID);//显示某人某工序某一天的计件信息的随工单信息
    DataSet S_OTime_WorkOrder_ForOne(Guid sTI_ID, string wOD_OutTime, string ptname, Guid HRDD_ID);//显示某人某工序某一天的计时信息的随工单信息
    void U_OTime_OT_NORelated(Guid oT_ID, decimal oT_Time, int oT_Num);//编辑装配计件详情
    void U_OperatorInfo_shenhexiugai(Guid oI_ID, int oI_ProNum);//修改某一天的生产相关计件信息

}