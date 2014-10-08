using System;
using System.Data;

/// <summary>
///ISalesWeekPlan 的摘要说明
/// </summary>
public interface ISalesWeekPlan
{
    //DataSet Select_SalesMonthPlan_Bindgridview();
    DataSet Select_SalesWeekPlan(string condition);
    void Insert_SalesWeekPlan(int year, int week, DateTime start, DateTime end, Guid MonthPlanID);
    DataSet Select_Top5MonthPlanID();
    DataSet Select_SalesWeekPlanBindSign(Guid weekid);
    void Update_SalesWeekPlanSignOK(Guid weekid, string man, string opinion, string department);
    void Update_SalesWeekPlanSignNotOK(Guid weekid, string man, string opinion, string department);
    DataSet Select_SalesWeekPlanDetail_Condition(string condition);
    void Delete_WeekPlanMain(Guid weekid);
    void Delete_WeekPlanDetail(Guid weekid);
    void Update_WeekPlanDetail_Num(Guid detailID, Guid weekID, int total, string youxianji, string remark, int day1, int day2, int day3, int day4, int day5, int day6, string way);
    void Update_Protype_SalesWeekPlanDetail(Guid weekid, Guid pt);
    void Insert_Protype_WeekPlan(DateTime start, DateTime end);
 DataSet Select_CheckWeekPlanDetail(Guid MonthPlanID,Guid PT_ID);
}