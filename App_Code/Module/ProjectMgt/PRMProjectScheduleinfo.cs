using System;

/// <summary>
///PRMProjectScheduleinfo 的摘要说明
/// </summary>
public class PRMProjectScheduleinfo
{
    private Guid pRMPS_ID;

   
    private Guid pRMP_ID;

   
    private int pRMPS_Num;

  
    private string pRMPS_ScheduleName;

  
    private int pRMPS_ScheduleTime;


    private string pRMPS_ScheduleContent;

 
    private DateTime pRMPS_ScheduleMakeTime;

 
    private string pRMPS_ScheduleMakeMan;

 
    private string pRMPS_ScheduleFinish;

  
    private string pRMPS_ScheduleRelay;

  
    private int pRMPS_RelayDay;

 
    private string pRMPS_RelayMan;

 
    private DateTime pRMPS_RelayTime;


    private string pRMPS_RelayReason;


    private string pRMPS_WorkOrderNum;


    private string pRMPS_Accessory;


    private string pRMPS_AccNum;


    private string pRMPS_AccName;


    private string pRMPS_ProcessCondition;


    private DateTime pRMPS_ProcessTime;


    private string pRMPS_ProcessMan;

    private string bDOS_Name;

    private Guid bDOS_Code;

  
    private bool bDOS_Isdeleted;


	public PRMProjectScheduleinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public PRMProjectScheduleinfo(Guid _pRMPS_ID, Guid _pRMP_ID, int _pRMPS_Num, string _pRMPS_ScheduleName, int _pRMPS_ScheduleTime, string _pRMPS_ScheduleContent, DateTime _pRMPS_ScheduleMakeTime, string _pRMPS_ScheduleMakeMan, string _pRMPS_ScheduleFinish, string _pRMPS_ScheduleRelay, int _pRMPS_RelayDay, string _pRMPS_RelayMan, DateTime _pRMPS_RelayTime, string _pRMPS_RelayReason, string _pRMPS_WorkOrderNum, string _pRMPS_Accessory, string _pRMPS_AccNum, string _pRMPS_AccName, string _pRMPS_ProcessCondition, DateTime _pRMPS_ProcessTime, string _pRMPS_ProcessMan, string _bDOS_Name, bool _bDOS_Isdeleted, Guid  _bDOS_Code)
    {
        pRMPS_ID = _pRMPS_ID;
        pRMP_ID = _pRMP_ID;
        pRMPS_Num = _pRMPS_Num;
        pRMPS_ScheduleName = _pRMPS_ScheduleName;
        pRMPS_ScheduleTime = _pRMPS_ScheduleTime;
        pRMPS_ScheduleContent = _pRMPS_ScheduleContent;
        pRMPS_ScheduleMakeTime = _pRMPS_ScheduleMakeTime;
        pRMPS_ScheduleMakeMan = _pRMPS_ScheduleMakeMan;
        pRMPS_ScheduleFinish = _pRMPS_ScheduleFinish;
        pRMPS_ScheduleRelay = _pRMPS_ScheduleRelay;
        pRMPS_RelayDay = _pRMPS_RelayDay;
        pRMPS_RelayMan = _pRMPS_RelayMan;
        pRMPS_RelayTime = _pRMPS_RelayTime;
        pRMPS_RelayReason = _pRMPS_RelayReason;
        pRMPS_WorkOrderNum = _pRMPS_WorkOrderNum;
        pRMPS_Accessory = _pRMPS_Accessory;
        pRMPS_AccNum = _pRMPS_AccNum;
        pRMPS_AccName = _pRMPS_AccName;
        pRMPS_ProcessCondition = _pRMPS_ProcessCondition;
        pRMPS_ProcessTime = _pRMPS_ProcessTime;
        pRMPS_ProcessMan = _pRMPS_ProcessMan;
        bDOS_Name=_bDOS_Name;
        bDOS_Isdeleted = _bDOS_Isdeleted;
        bDOS_Code = _bDOS_Code;
    }
 public Guid PRMPS_ID
    {
        get { return pRMPS_ID; }
        set { pRMPS_ID = value; }
    }
 public Guid PRMP_ID
 {
     get { return pRMP_ID; }
     set { pRMP_ID = value; }
 }
 public int PRMPS_Num
 {
     get { return pRMPS_Num; }
     set { pRMPS_Num = value; }
 }
 public string PRMPS_ScheduleName
 {
     get { return pRMPS_ScheduleName; }
     set { pRMPS_ScheduleName = value; }
 }
 public int PRMPS_ScheduleTime
 {
     get { return pRMPS_ScheduleTime; }
     set { pRMPS_ScheduleTime = value; }
 }
 public string PRMPS_ScheduleContent
 {
     get { return pRMPS_ScheduleContent; }
     set { pRMPS_ScheduleContent = value; }
 }
 public DateTime PRMPS_ScheduleMakeTime
 {
     get { return pRMPS_ScheduleMakeTime; }
     set { pRMPS_ScheduleMakeTime = value; }
 }
 public string PRMPS_ScheduleMakeMan
 {
     get { return pRMPS_ScheduleMakeMan; }
     set { pRMPS_ScheduleMakeMan = value; }
 }
 public string PRMPS_ScheduleFinish
 {
     get { return pRMPS_ScheduleFinish; }
     set { pRMPS_ScheduleFinish = value; }
 }
 public string PRMPS_ScheduleRelay
 {
     get { return pRMPS_ScheduleRelay; }
     set { pRMPS_ScheduleRelay = value; }
 }
 public int PRMPS_RelayDay
 {
     get { return pRMPS_RelayDay; }
     set { pRMPS_RelayDay = value; }
 }
 public string PRMPS_RelayMan
 {
     get { return pRMPS_RelayMan; }
     set { pRMPS_RelayMan = value; }
 }
 public DateTime PRMPS_RelayTime
 {
     get { return pRMPS_RelayTime; }
     set { pRMPS_RelayTime = value; }
 }
 public string PRMPS_RelayReason
 {
     get { return pRMPS_RelayReason; }
     set { pRMPS_RelayReason = value; }
 }
 public string PRMPS_WorkOrderNum
 {
     get { return pRMPS_WorkOrderNum; }
     set { pRMPS_WorkOrderNum = value; }
 }
 public string PRMPS_Accessory
 {
     get { return pRMPS_Accessory; }
     set { pRMPS_Accessory = value; }
 }
 public string PRMPS_AccNum
 {
     get { return pRMPS_AccNum; }
     set { pRMPS_AccNum = value; }
 }
 public string PRMPS_AccName
 {
     get { return pRMPS_AccName; }
     set { pRMPS_AccName = value; }
 }
 public string PRMPS_ProcessCondition
 {
     get { return pRMPS_ProcessCondition; }
     set { pRMPS_ProcessCondition = value; }
 }
 public DateTime PRMPS_ProcessTime
 {
     get { return pRMPS_ProcessTime; }
     set { pRMPS_ProcessTime = value; }
 }
 public string PRMPS_ProcessMan
 {
     get { return pRMPS_ProcessMan; }
     set { pRMPS_ProcessMan = value; }
 }
 public string BDOS_Name1
 {
     get { return bDOS_Name; }
     set { bDOS_Name = value; }
 }
 public bool BDOS_Isdeleted1
 {
     get { return bDOS_Isdeleted; }
     set {bDOS_Isdeleted = value; }
 }
 public Guid BDOS_Code1
 {
     get { return bDOS_Code; }
     set { bDOS_Code = value; }
 }
}