using System;

/// <summary>
///ExpTestAppInfo 的摘要说明
/// </summary>
public class ExpTestAppInfo
{
	public ExpTestAppInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public ExpTestAppInfo(string _eST_SampleType, Guid _eST_SampleTypeID, string _eTA_ExpAppNO, string _eTA_ProIdentify,
        int _eTA_SamNum,string _eTA_Units,string _eTA_AppPer,DateTime _eTA_AppTime,string _bDOS_Code,string _eTA_AppStatus,
        string _eTA_EmergDegree,string _eTA_Remaks,string _eTA_Auditor,DateTime _eTA_AuTime,string _eTA_AuSugg,
        string _eTA_AuRes,string _eTA_AckPer,DateTime _eTA_AckTime,DateTime _eTA_EstimateT,string _eTA_ExpPer,DateTime _eTA_ActFinishT,
        string _eTA_ExpRes,string _eTA_ResInstruction,string _eTA_Approver,DateTime _eTA_ApprovalT,string _eTA_ApprovalSugg,
        string _eTA_ApprovalRes)
    {
        eST_SampleType = _eST_SampleType;
        eST_SampleTypeID = _eST_SampleTypeID;
        eTA_ExpAppNO=_eTA_ExpAppNO;
        eTA_ProIdentify=_eTA_ProIdentify;
        eTA_SamNum=_eTA_SamNum;
        eTA_Units=_eTA_Units;
        eTA_AppPer=_eTA_AppPer;
        eTA_AppTime=_eTA_AppTime;
        bDOS_Code = _bDOS_Code;
        eTA_AppStatus=_eTA_AppStatus;
        eTA_EmergDegree=_eTA_EmergDegree;
        eTA_Remaks=_eTA_Remaks;
        eTA_Auditor=_eTA_Auditor;
        eTA_AuTime=_eTA_AuTime;
        eTA_AuSugg=_eTA_AuSugg;
        eTA_AuRes=_eTA_AuRes;
        eTA_AckPer=_eTA_AckPer;
        eTA_AckTime=_eTA_AckTime;
        eTA_EstimateT=_eTA_EstimateT;
        eTA_ExpPer=_eTA_ExpPer;
        eTA_ActFinishT=_eTA_ActFinishT;
        eTA_ExpRes=_eTA_ExpRes;
        eTA_ResInstruction=_eTA_ResInstruction;
        eTA_Approver = _eTA_Approver;
        eTA_ApprovalT=_eTA_ApprovalT;
        eTA_ApprovalSugg=_eTA_ApprovalSugg;
        eTA_ApprovalRes=_eTA_ApprovalRes;
    }

    //查询主表ID    
    public ExpTestAppInfo(Guid _eTA_ExpID)
    {
        eTA_ExpID = _eTA_ExpID;
    }

    //检索栏检索条件
    public ExpTestAppInfo(string _eTA_ProIdentify,DateTime _eTA_AppTime1,DateTime _eTA_AppTime2,
       string _eTA_AppStatus, string _eTA_EmergDegree)
    {
        eTA_ProIdentify = _eTA_ProIdentify;
        eTA_AppTime1 = _eTA_AppTime1;
        eTA_AppTime2 = _eTA_AppTime2;
        eTA_AppStatus = _eTA_AppStatus;
        eTA_EmergDegree = _eTA_EmergDegree;

    }

    //存储根据实验项目结果ID检索的信息
    public ExpTestAppInfo(Guid _eIR_ResDetailID, Guid _eI_ExpItemID, int _eIR_ItemAmount, int _eIR_ItemAcceptance, string _eIR_ItemRes, string _eIR_Remaks)
    {
        eIR_ResDetailID = _eIR_ResDetailID;
        eI_ExpItemID = _eI_ExpItemID;
        eIR_ItemAmount = _eIR_ItemAmount;
        eIR_ItemAcceptance = _eIR_ItemAcceptance;
        eIR_ItemRes = _eIR_ItemRes;
        eIR_Remaks = _eIR_Remaks;
    }

    //申请页面GridView编辑弹窗
    public ExpTestAppInfo(string _eST_SampleType, string _eTA_ProIdentify,
        int _eTA_SamNum, string _eTA_Units, string _eTA_AppPer, string _eTA_AppDep,
        string _eTA_EmergDegree, string _eTA_Remaks, string _bDOS_Code, Guid _eST_SampleTypeID, string _eTA_AppStatus)
    {
        eST_SampleType = _eST_SampleType;
        eTA_ProIdentify = _eTA_ProIdentify;
        eTA_SamNum = _eTA_SamNum;
        eTA_Units = _eTA_Units;
        eTA_AppPer = _eTA_AppPer;
        eTA_AppDep = _eTA_AppDep;
        eTA_EmergDegree = _eTA_EmergDegree;
        eTA_Remaks = _eTA_Remaks;
        bDOS_Code = _bDOS_Code;
        eST_SampleTypeID = _eST_SampleTypeID;
        eTA_AppStatus = _eTA_AppStatus;
    }

    string condition;

    public string Condition
    {
        get { return condition; }
        set { condition = value; }
    }

    private string bDOS_Code;

    public string BDOS_Code
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
    }

    private Guid eIR_ResDetailID;

    public Guid EIR_ResDetailID
    {
        get { return eIR_ResDetailID; }
        set { eIR_ResDetailID = value; }
    }
    private Guid eI_ExpItemID;

    public Guid EI_ExpItemID
    {
        get { return eI_ExpItemID; }
        set { eI_ExpItemID = value; }
    }
    private int eIR_ItemAmount;

    public int EIR_ItemAmount
    {
        get { return eIR_ItemAmount; }
        set { eIR_ItemAmount = value; }
    }
    private int eIR_ItemAcceptance;

    public int EIR_ItemAcceptance
    {
        get { return eIR_ItemAcceptance; }
        set { eIR_ItemAcceptance = value; }
    }
    private string eIR_ItemRes;

    public string EIR_ItemRes
    {
        get { return eIR_ItemRes; }
        set { eIR_ItemRes = value; }
    }
    private string eIR_Remaks;

    public string EIR_Remaks
    {
        get { return eIR_Remaks; }
        set { eIR_Remaks = value; }
    }

    private string eST_SampleType;

    public string EST_SampleType
    {
        get { return eST_SampleType; }
        set { eST_SampleType = value; }
    }
    
    private Guid eTA_ExpID;

    public Guid ETA_ExpID
    {
        get { return eTA_ExpID; }
        set { eTA_ExpID = value; }
    }
    private Guid eST_SampleTypeID;

    public Guid EST_SampleTypeID
    {
        get { return eST_SampleTypeID; }
        set { eST_SampleTypeID = value; }
    }
    private string eTA_ExpAppNO;

    public string ETA_ExpAppNO
    {
        get { return eTA_ExpAppNO; }
        set { eTA_ExpAppNO = value; }
    }
    private string eTA_ProIdentify;

    public string ETA_ProIdentify
    {
        get { return eTA_ProIdentify; }
        set { eTA_ProIdentify = value; }
    }
    private int eTA_SamNum;

    public int ETA_SamNum
    {
        get { return eTA_SamNum; }
        set { eTA_SamNum = value; }
    }
    private string eTA_Units;

    public string ETA_Units
    {
        get { return eTA_Units; }
        set { eTA_Units = value; }
    }

    private string eTA_AppPer;

    public string ETA_AppPer
    {
        get { return eTA_AppPer; }
        set { eTA_AppPer = value; }
    }
    private DateTime eTA_AppTime;

    public DateTime ETA_AppTime
    {
        get { return eTA_AppTime; }
        set { eTA_AppTime = value; }
    }
    private DateTime eTA_AppTime1;

    public DateTime ETA_AppTime1
    {
        get { return eTA_AppTime1; }
        set { eTA_AppTime1 = value; }
    }
    private DateTime eTA_AppTime2;

    public DateTime ETA_AppTime2
    {
        get { return eTA_AppTime2; }
        set { eTA_AppTime2 = value; }
    }
    private string eTA_AppDep;

    public string ETA_AppDep
    {
        get { return eTA_AppDep; }
        set { eTA_AppDep = value; }
    }
    private string eTA_AppStatus;

    public string ETA_AppStatus
    {
        get { return eTA_AppStatus; }
        set { eTA_AppStatus = value; }
    }
    private string eTA_EmergDegree;

    public string ETA_EmergDegree
    {
        get { return eTA_EmergDegree; }
        set { eTA_EmergDegree = value; }
    }
    private string eTA_Remaks;

    public string ETA_Remaks
    {
        get { return eTA_Remaks; }
        set { eTA_Remaks = value; }
    }
    private string eTA_Auditor;

    public string ETA_Auditor
    {
        get { return eTA_Auditor; }
        set { eTA_Auditor = value; }
    }
    private DateTime eTA_AuTime;

    public DateTime ETA_AuTime
    {
        get { return eTA_AuTime; }
        set { eTA_AuTime = value; }
    }
    private string eTA_AuSugg;

    public string ETA_AuSugg
    {
        get { return eTA_AuSugg; }
        set { eTA_AuSugg = value; }
    }
    private string eTA_AuRes;

    public string ETA_AuRes
    {
        get { return eTA_AuRes; }
        set { eTA_AuRes = value; }
    }
    private string eTA_AckPer;

    public string ETA_AckPer
    {
        get { return eTA_AckPer; }
        set { eTA_AckPer = value; }
    }
    private DateTime eTA_AckTime;

    public DateTime ETA_AckTime
    {
        get { return eTA_AckTime; }
        set { eTA_AckTime = value; }
    }
    private DateTime eTA_EstimateT;

    public DateTime ETA_EstimateT
    {
        get { return eTA_EstimateT; }
        set { eTA_EstimateT = value; }
    }
    private string eTA_ExpPer;

    public string ETA_ExpPer
    {
        get { return eTA_ExpPer; }
        set { eTA_ExpPer = value; }
    }
    private DateTime eTA_ActFinishT;

    public DateTime ETA_ActFinishT
    {
        get { return eTA_ActFinishT; }
        set { eTA_ActFinishT = value; }
    }
    private string eTA_ExpRes;

    public string ETA_ExpRes
    {
        get { return eTA_ExpRes; }
        set { eTA_ExpRes = value; }
    }
    private string eTA_ResInstruction;

    public string ETA_ResInstruction
    {
        get { return eTA_ResInstruction; }
        set { eTA_ResInstruction = value; }
    }
    private string eTA_Approver;

    public string ETA_Approver
    {
        get { return eTA_Approver; }
        set { eTA_Approver = value; }
    }
    private DateTime eTA_ApprovalT;

    public DateTime ETA_ApprovalT
    {
        get { return eTA_ApprovalT; }
        set { eTA_ApprovalT = value; }
    }
    private string eTA_ApprovalSugg;

    public string ETA_ApprovalSugg
    {
        get { return eTA_ApprovalSugg; }
        set { eTA_ApprovalSugg = value; }
    }
    private string eTA_ApprovalRes;

    public string ETA_ApprovalRes
    {
        get { return eTA_ApprovalRes; }
        set { eTA_ApprovalRes = value; }
    }
}