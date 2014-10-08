using System;

/// <summary>
///PRMProjectinfo 的摘要说明
/// </summary>
public class PRMProjectinfo
{
    private Guid pRMP_ID;
    private string pRMP_ProjectNum;

   
    private Guid cRMOS_ID;


    private Guid pT_ID;

    private string pT_Name;

 
    private string pRMP_ProjectName;


    private string pRMP_ProductMode;

   
    private string pRMP_ProjectType;


    private string pRMP_Sample;

 
    private string pRMP_ImproveAim;


    private string pRMP_ImproveRequest;

 
    private string pRMP_ProjectStates;


    private string pRMP_DesignMangCheckResult;

 
    private string pRMP_DesignMangCheckOpinion;
    private string pRMP_DesignMangName;

  


    private DateTime pRMP_DesignMangCheckTime;

 
    private string pRMP_GeneralMangCheckResult;

   
    private string pRMP_GeneralMangCheckOpinion;
    private string pRMP_GeneralMangName;

 
    private DateTime pRMP_GeneralMangCheckTime;


    private string pRMP_ResponDepart;
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
    private Guid pRMPS_ID;

    private bool bDOS_Isdeleted;

    private string wO_Num;
    private string wO_ProType;
    private DateTime wO_Time;
    private string pRMPS_AccessoryPath;



    private string pRMP_ReDepartCheckOpinion;

    public string PRMP_ReDepartCheckOpinion
    {
        get { return pRMP_ReDepartCheckOpinion; }
        set { pRMP_ReDepartCheckOpinion = value; }
    }
    private DateTime pRMP_ReDepartCheckTime;

    public DateTime PRMP_ReDepartCheckTime
    {
        get { return pRMP_ReDepartCheckTime; }
        set { pRMP_ReDepartCheckTime = value; }
    }
    private string pRMP_ReDepartCheckMan;

    public string PRMP_ReDepartCheckMan
    {
        get { return pRMP_ReDepartCheckMan; }
        set { pRMP_ReDepartCheckMan = value; }
    }
    private string pRMP_ReDepartCheckResult;

    public string PRMP_ReDepartCheckResult
    {
        get { return pRMP_ReDepartCheckResult; }
        set { pRMP_ReDepartCheckResult = value; }
    }
    private string pRMP_CFOCheckResult;

    public string PRMP_CFOCheckResult
    {
        get { return pRMP_CFOCheckResult; }
        set { pRMP_CFOCheckResult = value; }
    }
    private string pRMP_CFOCheckOpinion;

    public string PRMP_CFOCheckOpinion
    {
        get { return pRMP_CFOCheckOpinion; }
        set { pRMP_CFOCheckOpinion = value; }
    }
    private DateTime pRMP_CFOCheckTime;

    public DateTime PRMP_CFOCheckTime
    {
        get { return pRMP_CFOCheckTime; }
        set { pRMP_CFOCheckTime = value; }
    }
    private string pRMP_CFOCheckName;

    public string PRMP_CFOCheckName
    {
        get { return pRMP_CFOCheckName; }
        set { pRMP_CFOCheckName = value; }
    }


private Guid pRMPA_ID;

public Guid PRMPA_ID
{
    get { return pRMPA_ID; }
    set { pRMPA_ID = value; }
}
private string pRMPA_Accessory;

public string PRMPA_Accessory
{
    get { return pRMPA_Accessory; }
    set { pRMPA_Accessory = value; }
}
private string pRMPA_AccNum;

public string PRMPA_AccNum
{
    get { return pRMPA_AccNum; }
    set { pRMPA_AccNum = value; }
}
private string pRMPA_AccName;

public string PRMPA_AccName
{
    get { return pRMPA_AccName; }
    set { pRMPA_AccName = value; }
}
private string pRMPA_AccPath;

public string PRMPA_AccPath
{
    get { return pRMPA_AccPath; }
    set { pRMPA_AccPath = value; }
}
private string pRMPA_AccState;

public string PRMPA_AccState
{
    get { return pRMPA_AccState; }
    set { pRMPA_AccState = value; }
}

private Guid pRMPC_ID;

public Guid PRMPC_ID
{
    get { return pRMPC_ID; }
    set { pRMPC_ID = value; }
}
private string pRMPC_SignPartment;

public string PRMPC_SignPartment
{
    get { return pRMPC_SignPartment; }
    set { pRMPC_SignPartment = value; }
}
private string pRMPC_SignResult;

public string PRMPC_SignResult
{
    get { return pRMPC_SignResult; }
    set { pRMPC_SignResult = value; }
}
private string pRMPC_SignOpinion;

public string PRMPC_SignOpinion
{
    get { return pRMPC_SignOpinion; }
    set { pRMPC_SignOpinion = value; }
}
private string pRMPC_SignMan;

public string PRMPC_SignMan
{
    get { return pRMPC_SignMan; }
    set { pRMPC_SignMan = value; }
}
private DateTime pRMPC_SignTime;

public DateTime PRMPC_SignTime
{
    get { return pRMPC_SignTime; }
    set { pRMPC_SignTime = value; }
}

private Guid pRMPD_ID;

public Guid PRMPD_ID
{
    get { return pRMPD_ID; }
    set { pRMPD_ID = value; }
}

private string pRMP_DesignMangCheckSate;

public string PRMP_DesignMangCheckSate
{
    get { return pRMP_DesignMangCheckSate; }
    set { pRMP_DesignMangCheckSate = value; }
}
private string pRMP_SupplyDepartment;

public string PRMP_SupplyDepartment
{
    get { return pRMP_SupplyDepartment; }
    set { pRMP_SupplyDepartment = value; }
}








	public PRMProjectinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public PRMProjectinfo(string _pRMP_ProjectNum, DateTime _wO_Time, string _wO_ProType, string _wO_Num, Guid _pRMP_ID, Guid _cRMOS_ID, Guid _pT_ID, string _pRMP_ProjectName, string _pRMP_ProductMode, string _pRMP_ProjectType, string _pRMP_Sample, string _pRMP_ImproveAim, string _pRMP_ImproveRequest, string _pRMP_ProjectStates, string _pRMP_DesignMangCheckResult, string _pRMP_DesignMangCheckOpinion, DateTime _pRMP_DesignMangCheckTime, string _pRMP_GeneralMangCheckResult, string _pRMP_GeneralMangCheckOpinion, DateTime _pRMP_GeneralMangCheckTime, string _pRMP_ResponDepart, Guid _pRMPS_ID, int _pRMPS_Num, string _pRMPS_ScheduleName, int _pRMPS_ScheduleTime, string _pRMPS_ScheduleContent, DateTime _pRMPS_ScheduleMakeTime, string _pRMPS_ScheduleMakeMan, string _pRMPS_ScheduleFinish, string _pRMPS_ScheduleRelay, int _pRMPS_RelayDay, string _pRMPS_RelayMan, DateTime _pRMPS_RelayTime, string _pRMPS_RelayReason, string _pRMPS_WorkOrderNum, string _pRMPS_Accessory, string _pRMPS_AccNum, string _pRMPS_AccName, string _pRMPS_ProcessCondition, DateTime _pRMPS_ProcessTime, string _pRMPS_ProcessMan, string _bDOS_Name, bool _bDOS_Isdeleted, Guid _bDOS_Code, string _pRMPS_AccessoryPath)
    {
        pRMP_ProjectNum = _pRMP_ProjectNum;
        wO_Time = _wO_Time;
        wO_ProType = _wO_ProType;
        wO_Num = _wO_Num;
        pRMP_ID = _pRMP_ID;
        cRMOS_ID = _cRMOS_ID;
        pT_ID = _pT_ID;
        pRMP_ProjectName = _pRMP_ProjectName;
        pRMP_ProductMode = _pRMP_ProductMode;
        pRMP_ProjectType = _pRMP_ProjectType;
        pRMP_Sample = _pRMP_Sample;
        pRMP_ImproveAim = _pRMP_ImproveAim;
        pRMP_ImproveRequest = _pRMP_ImproveRequest;
        pRMP_ProjectStates = _pRMP_ProjectStates;
        pRMP_DesignMangCheckResult = _pRMP_DesignMangCheckResult;
        pRMP_DesignMangCheckOpinion = _pRMP_DesignMangCheckOpinion;
        pRMP_DesignMangCheckTime = _pRMP_DesignMangCheckTime;
        pRMP_GeneralMangCheckResult = _pRMP_GeneralMangCheckResult;
        pRMP_GeneralMangCheckOpinion = _pRMP_GeneralMangCheckOpinion;
        pRMP_GeneralMangCheckTime = _pRMP_GeneralMangCheckTime;
        pRMP_ResponDepart = _pRMP_ResponDepart;
        pRMPS_ID = _pRMPS_ID;
       
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
        pRMPS_AccessoryPath = _pRMPS_AccessoryPath;


    }

  
 public Guid PRMPS_ID
    {
        get { return pRMPS_ID; }
        set { pRMPS_ID = value; }
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
    public Guid PRMP_ID
    {
        get { return pRMP_ID; }
        set { pRMP_ID = value; }
    }
    public Guid CRMOS_ID
    {
        get { return cRMOS_ID; }
        set { cRMOS_ID = value; }
    }
    public Guid PT_ID
    {
        get { return pT_ID; }
        set { pT_ID = value; }
    }
    public string PRMP_ProjectName
    {
        get { return pRMP_ProjectName; }
        set { pRMP_ProjectName = value; }
    }
    public string PRMP_ProductMode
    {
        get { return pRMP_ProductMode; }
        set { pRMP_ProductMode = value; }
    }
    public string PRMP_ProjectType
    {
        get { return pRMP_ProjectType; }
        set { pRMP_ProjectType = value; }
    }
    public string PRMP_Sample
    {
        get { return pRMP_Sample; }
        set { pRMP_Sample = value; }
    }
    public string PRMP_ImproveAim
    {
        get { return pRMP_ImproveAim; }
        set { pRMP_ImproveAim = value; }
    }
    public string PRMP_ImproveRequest
    {
        get { return pRMP_ImproveRequest; }
        set { pRMP_ImproveRequest = value; }
    }
    public string PRMP_ProjectStates
    {
        get { return pRMP_ProjectStates; }
        set { pRMP_ProjectStates = value; }
    }
    public string PRMP_DesignMangCheckResult
    {
        get { return pRMP_DesignMangCheckResult; }
        set { pRMP_DesignMangCheckResult = value; }
    }
    public string PRMP_DesignMangCheckOpinion
    {
        get { return pRMP_DesignMangCheckOpinion; }
        set { pRMP_DesignMangCheckOpinion = value; }
    }
    public DateTime PRMP_DesignMangCheckTime
    {
        get { return pRMP_DesignMangCheckTime; }
        set { pRMP_DesignMangCheckTime = value; }
    }
    public string PRMP_GeneralMangCheckResult
    {
        get { return pRMP_GeneralMangCheckResult; }
        set { pRMP_GeneralMangCheckResult = value; }
    }
    public string PRMP_GeneralMangCheckOpinion
    {
        get { return pRMP_GeneralMangCheckOpinion; }
        set { pRMP_GeneralMangCheckOpinion = value; }
    }
    public DateTime PRMP_GeneralMangCheckTime
    {
        get { return pRMP_GeneralMangCheckTime; }
        set { pRMP_GeneralMangCheckTime = value; }
    }
    public string PRMP_ResponDepart
    {
        get { return pRMP_ResponDepart; }
        set { pRMP_ResponDepart = value; }
    }
    public string PRMPS_AccessoryPath
    {
        get { return pRMPS_AccessoryPath; }
        set { pRMPS_AccessoryPath = value; }
    }
    public string PRMP_ProjectNum
    {
        get { return pRMP_ProjectNum; }
        set { pRMP_ProjectNum = value; }
    }
    public string PRMP_DesignMangName
    {
        get { return pRMP_DesignMangName; }
        set { pRMP_DesignMangName = value; }
    }
    public string PRMP_GeneralMangName
    {
        get { return pRMP_GeneralMangName; }
        set { pRMP_GeneralMangName = value; }
    }

    public string PT_Name
    {
        get { return pT_Name; }
        set { pT_Name = value; }
    }
}