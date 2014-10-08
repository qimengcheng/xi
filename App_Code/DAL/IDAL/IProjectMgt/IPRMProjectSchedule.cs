using System;
using System.Data;

/// <summary>
///IPRMProjectSchedule 的摘要说明
/// </summary>
public  interface  IPRMProjectSchedule
{
   
    DataSet SelectPRMP_Organization(string condition);
    DataSet SelectPRMProjectSchedule_One(Guid PRMPS_ID);
     void  DelectPRMProjectSchedule(Guid PRMPS_ID);
     void InsertPRMProjectSchedule(Guid PRMP_ID, string PRMPS_ScheduleName, int PRMPS_ScheduleTime, string PRMPS_ScheduleContent, string PRMPS_ScheduleMakeMan, int PRMPS_Num);
   DataSet SelectPRMProjectSchedule(Guid PRMP_ID );
   void UpdatePRMProjectSchedule(Guid PRMPS_ID, string PRMPS_ScheduleName, int PRMPS_ScheduleTime, string PRMPS_ScheduleContent,string PRMPS_ProcessMan);
   DataSet SelectPRMProject_Schedule_One(string condition);     
}