using System;
using System.Data;

/// <summary>
///SalesWeekPlanL 的摘要说明
/// </summary>
public class SalesWeekPlanL
{
    private static readonly ISalesWeekPlan wp=DALFactory.WeekPlan();
	public SalesWeekPlanL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Select_SalesWeekPlan(string condition)
    {
        return wp.Select_SalesWeekPlan(condition);
    }
    public void Insert_SalesWeekPlan(int year, int week, DateTime start, DateTime end, Guid MonthPlanID)
    {
        wp.Insert_SalesWeekPlan(year, week, start, end, MonthPlanID);
    }
    public DataSet Select_Top5MonthPlanID()
    {
        return wp.Select_Top5MonthPlanID();
    }
    public DataSet Select_SalesWeekPlanBindSign(Guid weekid)
    {
        return wp.Select_SalesWeekPlanBindSign(weekid);
    }
    public void Update_SalesWeekPlanSignOK(Guid weekid, string man, string opinion, string department)
    {
        wp.Update_SalesWeekPlanSignOK(weekid, man, opinion, department);
    }
    public void Update_SalesWeekPlanSignNotOK(Guid weekid, string man, string opinion, string department)
    {
        wp.Update_SalesWeekPlanSignNotOK(weekid, man, opinion, department);
    }
    public DataSet Select_SalesWeekPlanDetail_Condition(string condition)
    {
        return wp.Select_SalesWeekPlanDetail_Condition(condition);
    }
     public void Delete_WeekPlanMain(Guid weekid)
   {
               wp.Delete_WeekPlanMain(weekid);
   }
     public void Delete_WeekPlanDetail(Guid weekid)
     {
        wp.Delete_WeekPlanDetail(weekid);
     }
     public void Update_WeekPlanDetail_Num(Guid detailID, Guid weekID, int total, string youxianji, string remark, int day1, int day2, int day3, int day4, int day5, int day6, string way)
     {
         wp.Update_WeekPlanDetail_Num(detailID, weekID, total, youxianji, remark, day1, day2, day3, day4, day5, day6, way);
     }
     public void Update_Protype_SalesWeekPlanDetail(Guid weekid, Guid pt)
     {
         wp.Update_Protype_SalesWeekPlanDetail(weekid, pt);
     }
     public void Insert_Protype_WeekPlan(DateTime start, DateTime end)
     {
         wp.Insert_Protype_WeekPlan(start, end);
     }
     public DataSet Select_CheckWeekPlanDetail(Guid MonthPlanID,Guid PT_ID)
     {
        return wp.Select_CheckWeekPlanDetail(MonthPlanID,PT_ID);

     }
}

