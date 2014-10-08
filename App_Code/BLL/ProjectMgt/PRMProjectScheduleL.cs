using System;
using System.Data;

/// <summary>
///PRMProjectScheduleL 的摘要说明
/// </summary>
public class PRMProjectScheduleL
{
    private static readonly IPRMProjectSchedule PRMP = DALFactory.CreatePRMProjectSchedule();

	public PRMProjectScheduleL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
  
    public DataSet SelectPRMP_Organization(string condition)
    {
        return PRMP.SelectPRMP_Organization(condition);
    }
    public void InsertPRMProjectSchedule(Guid PRMP_ID, string PRMPS_ScheduleName, int PRMPS_ScheduleTime, string PRMPS_ScheduleContent, string PRMPS_ScheduleMakeMan, int PRMPS_Num)
    {
        PRMP.InsertPRMProjectSchedule(PRMP_ID, PRMPS_ScheduleName, PRMPS_ScheduleTime, PRMPS_ScheduleContent, PRMPS_ScheduleMakeMan, PRMPS_Num);
 
    }
    public DataSet SelectPRMProjectSchedule(Guid PRMP_ID)
    {
       return PRMP.SelectPRMProjectSchedule(PRMP_ID);
    }
    public DataSet SelectPRMProjectSchedule_One(Guid PRMPS_ID)
    {
        return PRMP.SelectPRMProjectSchedule_One(PRMPS_ID);
    }

    public void DelectPRMProjectSchedule(Guid PRMPS_ID)
    {
         PRMP.DelectPRMProjectSchedule(PRMPS_ID);
    }
    public void UpdatePRMProjectSchedule(Guid PRMPS_ID, string PRMPS_ScheduleName, int PRMPS_ScheduleTime, string PRMPS_ScheduleContent, string PRMPS_ProcessMan)
    {
        PRMP.UpdatePRMProjectSchedule(PRMPS_ID, PRMPS_ScheduleName, PRMPS_ScheduleTime, PRMPS_ScheduleContent,PRMPS_ProcessMan);

    }
    public DataSet SelectPRMProject_Schedule_One(string condition)
    {
        return PRMP.SelectPRMProject_Schedule_One(condition);
    
    }
}