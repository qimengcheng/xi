using System;
using System.Data;

/// <summary>
///ISalesMonthPlan 的摘要说明
/// </summary>

public interface ISalesMonthPlan
{
    DataSet Select_SalesMonthPlan_Bindgridview();
    DataSet Select_SalesMonthPlan(string condition);
    int Insert_SalesMonthPlan(int year, int month, string man, DateTime start, DateTime end);
    DataSet Select_MonthPlanDetail_FromGridview(Guid MonthPlanID);
    DataSet Select_MonthPlanDetail_FromGridview_Add(Guid MonthPlanID);
    void Update_SMSalesMonthPlanMain_CheckOK(Guid MonthPlanID, string CheckMan, string CheckOpinion);
    void Update_SMSalesMonthPlanMain_SingOK(Guid MonthPlanID, string CheckMan, string CheckOpinion, string Department);
    DataSet Select_SMSalesMonthPlanMain_BindSign(Guid MonthPlanID);
    void Update_SMSalesMonthPlanMain_CheckNotOK(Guid MonthPlanID, string CheckMan, string CheckOpinion);
    void Update_SMSalesMonthPlanMain_SingNotOK(Guid MonthPlanID, string CheckMan, string CheckOpinion, string Department);
    DataSet Select_ProType(string condition);
    void Insert_ProType_MonthPlanDetail(Guid MonthPlanID, Guid PT_ID,string grid);
    DataSet Select_CheckMonthPlanDetail(Guid MonthPlanID, Guid PT_ID);
    void Update_MonthPlanDetail_Main(Guid MonthPlanMainID, Guid MonthPlanDetailID, decimal amount, decimal first, decimal second, decimal third, decimal forth, string request, string remark, string way);
    void Delete_MonthPlanDetail(Guid DetailID);
    void Delete_MonthPlanMain(Guid MainID);
    void Update_MonthPlanDetail_ADD(Guid DetailID,decimal amount,string  request,string man,string remark,string way);
    void Update_MonthPlanDetail_ADD_Check(Guid DetailID,  string opinion, string man,string key);
    void Insert_MonthPlanDetail_Auto(Guid mainID);
    DataSet SelectMonthPlanMainID(int year, int month);
}

