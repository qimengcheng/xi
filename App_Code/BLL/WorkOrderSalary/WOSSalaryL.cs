using System;
using System.Data;
/// <summary>
///WOSSalaryL 的摘要说明
/// </summary>
public class WOSSalaryL
{
    private static readonly IWOSSalary wos = DALFactory.CreateWOSSalary();
    public WOSSalaryL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet S_LaborCostSeries(string condition)//检索工价系列
    {
        return wos.S_LaborCostSeries(condition);
    }
    public void D_LaborCostSeries(Guid lCS_ID)//删除工价系列
    {
        wos.D_LaborCostSeries(lCS_ID);
    }
    public DataSet S_LaborCostSeries_panchong(string lCS_Name)//工价系列判重
    {
        return wos.S_LaborCostSeries_panchong(lCS_Name);
    }
    public void I_LaborCostSeries(string lCS_Name)//工价系列新增
    {
        wos.I_LaborCostSeries(lCS_Name);
    }
    public void U_LaborCostSeries(string lCS_Name, Guid lCS_ID)//工价系列编辑
    {

        wos.U_LaborCostSeries(lCS_Name, lCS_ID);
    }
    public DataSet S_LaborCostSeries_ProType(Guid lCS_ID)//工价系列所属产品型号
    {
        return wos.S_LaborCostSeries_ProType(lCS_ID);
    }
    public void D_LaborCostSeries_ProType(Guid pT_ID)//工价系列删除所属产品型号
    {
        wos.D_LaborCostSeries_ProType(pT_ID);
    }
    public DataSet S_LaborCostSeries_ProType_Condition(string condition)//工价系列显示待选产品型号
    {
        return wos.S_LaborCostSeries_ProType_Condition(condition);
    }
    public void I_LaborCostSeries_ProType(Guid pT_ID, Guid lCS_ID)//新增工价系列所属产品型号
    {
        wos.I_LaborCostSeries_ProType(pT_ID, lCS_ID);
    }
    public DataSet S_WorkingTeam(string condition)//检索班组信息
    {
        return wos.S_WorkingTeam(condition);
    }
    public void I_WorkingTeam(string wT_People, string wT_Name)//新增班组信息
    {
        wos.I_WorkingTeam(wT_People, wT_Name);
    }
    public void u_WorkingTeam(Guid wT_ID, string wT_People, string wT_Name)//编辑班组信息
    {
        wos.u_WorkingTeam(wT_ID, wT_People, wT_Name);
    }
    public void D_WorkingTeam(Guid wT_ID)//删除班组信息
    {
        wos.D_WorkingTeam(wT_ID);

    }
    public DataSet S_WorkTeamDetailList(Guid wT_ID)//检索班组详细信息
    {
        return wos.S_WorkTeamDetailList(wT_ID);
    }
    public void D_WorkTeamDetailList(Guid wTDL_ID)//删除班组信息
    {
        wos.D_WorkTeamDetailList(wTDL_ID);
    }
    public DataSet S_WorkTeamDetailList_HRDDetail(string condition)//检索待选员工
    {
        return wos.S_WorkTeamDetailList_HRDDetail(condition);
    }
    public void I_WorkTeamDetailList_HRDDetail(Guid wT_ID, Guid hRDD_ID)//添加员工至班组详细表
    {
        wos.I_WorkTeamDetailList_HRDDetail(wT_ID, hRDD_ID);
    }
    public DataSet S_WorkTimePiece_ByProDept(string condition)//显示计时计件主表
    {
        return wos.S_WorkTimePiece_ByProDept(condition);
    }

    public DataSet S_OperatorInfo(string condition, string wOD_OutTime)//显示某一天的计件信息
    {
        return wos.S_OperatorInfo(condition, wOD_OutTime);
    }
    public void D_WorkTimePiece_ByProDept(Guid wTP_ID)//删除计时计件主表
    {
        wos.D_WorkTimePiece_ByProDept(wTP_ID);
    }
    public void I_WorkTimePiece_ByProDept(DateTime wTP_Date)//新增计时计件主表信息
    {
        wos.I_WorkTimePiece_ByProDept(wTP_Date);
    }
    public DataSet S_OTime(string condition, string wOD_OutTime)//显示某一天的生产计时信息
    {
        return wos.S_OTime(condition, wOD_OutTime);
    }
    public DataSet S_OTime_OT_NORelated(string condition, string oT_NORelated_Date)//显示某一天的非生产相关计时信息
    {
        return wos.S_OTime_OT_NORelated(condition, oT_NORelated_Date);
    }
    public DataSet S_WorkTimePiece_ByID(Guid wTP_ID)//通过ID查询计时计件核算表
    {
        return wos.S_WorkTimePiece_ByID(wTP_ID);
    }
    public void U_WorkTimePiece_PReview(Guid wTP_ID, string wTP_PRMan, string wTP_PSuggestion, string wTP_PieceRState)//计时计件核算表计件审核
    {
        wos.U_WorkTimePiece_PReview(wTP_ID, wTP_PRMan, wTP_PSuggestion, wTP_PieceRState);
    }
    public void U_WorkTimePiece_TReview(Guid wTP_ID, string wTP_TRMan, string wTP_TSuggestion, string wTP_TimeRState)//计时计件核算表计件审核
    {
        wos.U_WorkTimePiece_TReview(wTP_ID, wTP_TRMan, wTP_TSuggestion, wTP_TimeRState);
    }

    public DataSet S_TimeSalaryDate(string condition)//显示计时提报日期
    {
        return wos.S_TimeSalaryDate(condition);
    }
    public void I_TimeSalaryDate(DateTime tSD_Date)//新增计时提报日期
    {
        wos.I_TimeSalaryDate(tSD_Date);
    }
    public void D_TimeSalaryDate(Guid tSD_ID)//删除计时提报日期
    {
        wos.D_TimeSalaryDate(tSD_ID);
    }
    public DataSet S_TimeSalaryDateDetail(string tSD_ID, string condition)//显示某一天的提报计时项目信息
    {
        return wos.S_TimeSalaryDateDetail(tSD_ID, condition);
    }
    public DataSet S_TimeSalaryDateDetail_SalaryTimeItem(string tSD_ID, string condition)//显示待添加的提报计时项目信息
    {
        return wos.S_TimeSalaryDateDetail_SalaryTimeItem(tSD_ID, condition);
    }
    public void I_TimeSalaryDateDetail(Guid tSD_ID, Guid sTI_ID, string tSDD_Man)//添加提报计时项目信息
    {
        wos.I_TimeSalaryDateDetail(tSD_ID, sTI_ID, tSDD_Man);
    }
    public void D_TimeSalaryDateDetail(Guid tSDD_ID)//删除提报计时项目信息及其详细信息
    {
        wos.D_TimeSalaryDateDetail(tSDD_ID);
    }
    public DataSet S_TimeSalaryDateDetail_Panduan(Guid tSD_ID)//判断某计时提报日期已经制定了详细信息
    {
        return wos.S_TimeSalaryDateDetail_Panduan(tSD_ID);
    }
    public DataSet S_OTime_TimeSalaryDateDetail(string tSDD_ID, string condition)//显示某天计时项目信息的详细信息
    {
        return wos.S_OTime_TimeSalaryDateDetail(tSDD_ID, condition);
    }
    public void U_OTime(Guid oT_ID, decimal oT_Time, int oT_Num)//制定计时提报详细信息的计时时间和生产数量
    {
        wos.U_OTime(oT_ID, oT_Time, oT_Num);
    }
    public void D_OTime(Guid oT_ID)//删除计时提报详细信息
    {
        wos.D_OTime(oT_ID);
    }
    public DataSet S_OTime_HRDDetail(string tSDD_ID, string condition)//计时提报待选员工
    {
        return wos.S_OTime_HRDDetail(tSDD_ID, condition);
    }
    public void I_OTime_HRDDetail(Guid sTI_ID, Guid tSDD_ID, Guid hRDD_ID)//计时提报添加待选员工
    {
        wos.I_OTime_HRDDetail(sTI_ID, tSDD_ID, hRDD_ID);
    }
    public void U_TimeSalaryDateDetail(Guid tSDD_ID)//提交计时提报详细
    {
        wos.U_TimeSalaryDateDetail(tSDD_ID);
    }
    public DataSet S_AssemblyPieceDate(string condition)//查看装配计件核算日期
    {
        return wos.S_AssemblyPieceDate(condition);
    }
    public void I_AssemblyPieceDate(DateTime aPD_Date, string aPD_Man)//新增装配计件核算日期
    {
        wos.I_AssemblyPieceDate(aPD_Date, aPD_Man);
    }
    public void D_AssemblyPieceDate(Guid aPD_ID)//删除装配计件核算日期
    {
        wos.D_AssemblyPieceDate(aPD_ID);
    }
    public DataSet S_AssemblyTeamMember_Detai(string condition, string lCS_ID, string aPD_ID)//检索装配计件详情
    {
        return wos.S_AssemblyTeamMember_Detai(condition, lCS_ID, aPD_ID);
    }
    public void D_AssemblyTeamMember_Detail(Guid aTM_ID)//删除装配计件详情
    {
        wos.D_AssemblyTeamMember_Detail(aTM_ID);
    }
    public void U_AssemblyTeamMember_Detail(Guid aTM_ID, decimal aTM_LaborHour)//编辑装配计件详情
    {

        wos.U_AssemblyTeamMember_Detail(aTM_ID, aTM_LaborHour);
    }
    public DataSet S_AssemblyPieceDate_Shanchupanduan(Guid aPD_ID)//装配计件删除判断

    {
        return wos.S_AssemblyPieceDate_Shanchupanduan(aPD_ID);
    }
    public void I_AssemblyTeamMember_HRDDetail(Guid hRDD_ID, Guid aPD_ID, Guid lCS_ID)//装配计件添加待选员工
    {
        wos.I_AssemblyTeamMember_HRDDetail(hRDD_ID, aPD_ID, lCS_ID);
    }
    public DataSet S_AssemblyTeamMember_HRDDetail(string aPD_ID, string lCS_ID, string condition)//装配计件待选员工

    {
        return wos.S_AssemblyTeamMember_HRDDetail(aPD_ID, lCS_ID, condition);
    }
    public DataSet S_OperatorInfo_WorkOrder_ForOne(Guid pBC_ID, string wOD_OutTime, string ptname, Guid HRDD_ID)//显示某人某工序某一天的计件信息的随工单信息

    {
        return wos.S_OperatorInfo_WorkOrder_ForOne(pBC_ID, wOD_OutTime,ptname,HRDD_ID);
    }
    public DataSet S_OTime_WorkOrder_ForOne(Guid sTI_ID, string wOD_OutTime, string ptname, Guid HRDD_ID)//显示某人某工序某一天的计时信息的随工单信息

    {
        return wos.S_OTime_WorkOrder_ForOne(sTI_ID, wOD_OutTime, ptname, HRDD_ID);
    }
    public void U_OTime_OT_NORelated(Guid oT_ID, decimal oT_Time, int oT_Num)//编辑装配计件详情
    {
         wos.U_OTime_OT_NORelated(oT_ID, oT_Time, oT_Num);
    }
    public void U_OperatorInfo_shenhexiugai(Guid oI_ID, int oI_ProNum)//修改某一天的生产相关计件信息
    {
        wos.U_OperatorInfo_shenhexiugai(oI_ID, oI_ProNum);
    }

}