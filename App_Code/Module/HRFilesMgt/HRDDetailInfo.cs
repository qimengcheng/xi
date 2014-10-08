using System;

/// <summary>
///HRDDetailInfo 的摘要说明
/// </summary>
public class HRDDetailInfo
{
    public HRDDetailInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private Guid hRDD_ID;
    private Guid hRP_ID;

    private string hRP_Post;
    private string hRET_EmpType;
    private string bDOS_Code;

    public string BDOS_Code
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
    }
    private string bDOS_Name;

    public string BDOS_Name
    {
        get { return bDOS_Name; }
        set { bDOS_Name = value; }
    }
    private Guid hRET_ID;
    private string hRDD_StaffNO;
    private string hRDD_Name;
    private string hRDD_Registration;
    private int workAge;

    public int WorkAge
    {
        get { return workAge; }
        set { workAge = value; }
    }
    private decimal hRDD_BasicWage;
    private decimal hRDD_FullTimeWage;
    private decimal hRDD_PerformWage;
    private decimal hRDD_OverTimeWage;
    private DateTime hRDD_ConverseDate;
    private DateTime hRDD_ContactSDate;
    private DateTime hRDD_ContactEDate;
    private Int32 hRDD_Worklength;
    private DateTime hRDD_EntryDate;
    private DateTime hRDD_DateOfBirth;
    private string hRDD_Sex;
    private string hRDD_IDCard;
    private string hRDD_Nationality;
    private string hRDD_IsMarried;
    private string hRDD_EduBackg;
    private string hRDD_Major;
    private string hRDD_GSchool;
    private string hRDD_HAddress;
    private string hRDD_Tel;
    private string hRDD_HasSocial;
    private string hRDD_HasAccumulation;
    private string hRDD_CertificateComplete;
    private string hRDD_EmergencyPer;
    private string hRDD_EmergencyNo;
    private bool hRDD_IsDeleted;
    private Guid hRPCR_ID;
    private string hRPCR_Dep;
    private string hRPCR_Post;
    private string hRPCR_FormerDep;
    private string hRPCR_FormerPost;

    public string HRPCR_FormerPost
    {
        get { return hRPCR_FormerPost; }
        set { hRPCR_FormerPost = value; }
    }
    private string hRPCR_Administrator;
    private DateTime hRPCR_Time;
    private string hRPCR_Remarks;

    private Guid hRSR_ID;
    private decimal hRSR_AdjBasicWage;
    private decimal hRSR_AdjFTWage;
    private decimal hRSR_AdjPWage;
    private decimal hRSR_AdjOTWage;
    private string hRSR_ChargePer;
    private string hRSR_Reason;

    public string HRSR_Reason
    {
        get { return hRSR_Reason; }
        set { hRSR_Reason = value; }
    }
    public string HRSR_ChargePer
    {
        get { return hRSR_ChargePer; }
        set { hRSR_ChargePer = value; }
    }
    public decimal HRSR_AdjOTWage
    {
        get { return hRSR_AdjOTWage; }
        set { hRSR_AdjOTWage = value; }
    }
    public decimal HRSR_AdjPWage
    {
        get { return hRSR_AdjPWage; }
        set { hRSR_AdjPWage = value; }
    }
    public decimal HRSR_AdjFTWage
    {
        get { return hRSR_AdjFTWage; }
        set { hRSR_AdjFTWage = value; }
    }
    public decimal HRSR_AdjBasicWage
    {
        get { return hRSR_AdjBasicWage; }
        set { hRSR_AdjBasicWage = value; }
    }
    public Guid HRSR_ID
    {
        get { return hRSR_ID; }
        set { hRSR_ID = value; }
    }

    public string HRPCR_Administrator
    {
        get { return hRPCR_Administrator; }
        set { hRPCR_Administrator = value; }
    }


    public DateTime HRPCR_Time
    {
        get { return hRPCR_Time; }
        set { hRPCR_Time = value; }
    }


    public string HRPCR_Remarks
    {
        get { return hRPCR_Remarks; }
        set { hRPCR_Remarks = value; }
    }
    public string HRPCR_FormerDep
    {
        get { return hRPCR_FormerDep; }
        set { hRPCR_FormerDep = value; }
    }

    public string HRPCR_Post
    {
        get { return hRPCR_Post; }
        set { hRPCR_Post = value; }
    }


    public Guid HRPCR_ID
    {
        get { return hRPCR_ID; }
        set { hRPCR_ID = value; }
    }

    public string HRPCR_Dep
    {
        get { return hRPCR_Dep; }
        set { hRPCR_Dep = value; }
    }
    public Guid HRDD_ID
    {
        get { return hRDD_ID; }
        set { hRDD_ID = value; }
    }

    public Guid HRP_ID
    {
        get { return hRP_ID; }
        set { hRP_ID = value; }
    }

    public string HRP_Post
    {
        get { return hRP_Post; }
        set { hRP_Post = value; }
    }

    public string HRET_EmpType
    {
        get { return hRET_EmpType; }
        set { hRET_EmpType = value; }
    }

    public Guid HRET_ID
    {
        get { return hRET_ID; }
        set { hRET_ID = value; }
    }

    public string HRDD_StaffNO
    {
        get { return hRDD_StaffNO; }
        set { hRDD_StaffNO = value; }
    }

    public string HRDD_Name
    {
        get { return hRDD_Name; }
        set { hRDD_Name = value; }
    }

    public string HRDD_Registration
    {
        get { return hRDD_Registration; }
        set { hRDD_Registration = value; }
    }

    public decimal HRDD_BasicWage
    {
        get { return hRDD_BasicWage; }
        set { hRDD_BasicWage = value; }
    }

    public decimal HRDD_FullTimeWage
    {
        get { return hRDD_FullTimeWage; }
        set { hRDD_FullTimeWage = value; }
    }


    public decimal HRDD_PerformWage
    {
        get { return hRDD_PerformWage; }
        set { hRDD_PerformWage = value; }
    }


    public decimal HRDD_OverTimeWage
    {
        get { return hRDD_OverTimeWage; }
        set { hRDD_OverTimeWage = value; }
    }

    public DateTime HRDD_ConverseDate
    {
        get { return hRDD_ConverseDate; }
        set { hRDD_ConverseDate = value; }
    }

    public DateTime HRDD_ContactSDate
    {
        get { return hRDD_ContactSDate; }
        set { hRDD_ContactSDate = value; }
    }

    public DateTime HRDD_ContactEDate
    {
        get { return hRDD_ContactEDate; }
        set { hRDD_ContactEDate = value; }
    }


    public Int32 HRDD_Worklength
    {
        get { return hRDD_Worklength; }
        set { hRDD_Worklength = value; }
    }


    public DateTime HRDD_EntryDate
    {
        get { return hRDD_EntryDate; }
        set { hRDD_EntryDate = value; }
    }

    public DateTime HRDD_DateOfBirth
    {
        get { return hRDD_DateOfBirth; }
        set { hRDD_DateOfBirth = value; }
    }

    public string HRDD_Sex
    {
        get { return hRDD_Sex; }
        set { hRDD_Sex = value; }
    }

    public string HRDD_IDCard
    {
        get { return hRDD_IDCard; }
        set { hRDD_IDCard = value; }
    }

    public string HRDD_Nationality
    {
        get { return hRDD_Nationality; }
        set { hRDD_Nationality = value; }
    }

    public string HRDD_IsMarried
    {
        get { return hRDD_IsMarried; }
        set { hRDD_IsMarried = value; }
    }

    public string HRDD_EduBackg
    {
        get { return hRDD_EduBackg; }
        set { hRDD_EduBackg = value; }
    }

    public string HRDD_Major
    {
        get { return hRDD_Major; }
        set { hRDD_Major = value; }
    }

    public string HRDD_GSchool
    {
        get { return hRDD_GSchool; }
        set { hRDD_GSchool = value; }
    }

    public string HRDD_HAddress
    {
        get { return hRDD_HAddress; }
        set { hRDD_HAddress = value; }
    }

    public string HRDD_Tel
    {
        get { return hRDD_Tel; }
        set { hRDD_Tel = value; }
    }

    public string HRDD_HasSocial
    {
        get { return hRDD_HasSocial; }
        set { hRDD_HasSocial = value; }
    }

    public string HRDD_CertificateComplete
    {
        get { return hRDD_CertificateComplete; }
        set { hRDD_CertificateComplete = value; }
    }

    public string HRDD_HasAccumulation
    {
        get { return hRDD_HasAccumulation; }
        set { hRDD_HasAccumulation = value; }
    }

    public string HRDD_EmergencyPer
    {
        get { return hRDD_EmergencyPer; }
        set { hRDD_EmergencyPer = value; }
    }

    public string HRDD_EmergencyNo
    {
        get { return hRDD_EmergencyNo; }
        set { hRDD_EmergencyNo = value; }
    }

    private decimal hRSR_BasicWage;

    public decimal HRSR_BasicWage
    {
        get { return hRSR_BasicWage; }
        set { hRSR_BasicWage = value; }
    }
    private decimal hRSR_PWage;

    public decimal HRSR_PWage
    {
        get { return hRSR_PWage; }
        set { hRSR_PWage = value; }
    }

    private decimal hRSR_FTWage;

    public decimal HRSR_FTWage
    {
        get { return hRSR_FTWage; }
        set { hRSR_FTWage = value; }
    }

    private decimal hRSR_OTWage;

    public decimal HRSR_OTWage
    {
        get { return hRSR_OTWage; }
        set { hRSR_OTWage = value; }
    }


    public HRDDetailInfo(Guid _hRET_ID, Guid _hRP_ID, string _bDOS_Code, string _hRDD_StaffNO, string _hRDD_Name, string _hRDD_Registration,
        decimal _hRDD_BasicWage, decimal _hRDD_FullTimeWage, decimal _hRDD_PerformWage, decimal _hRDD_OverTimeWage, DateTime _hRDD_ConverseDate,
        DateTime _hRDD_ContactSDate, DateTime _hRDD_ContactEDate, Int32 _hRDD_Worklength, DateTime _hRDD_EntryDate, DateTime _hRDD_DateOfBirth,
    string _hRDD_Sex, string _hRDD_IDCard, string _hRDD_Nationality, string _hRDD_IsMarried, string _hRDD_EduBackg, string _hRDD_Major, string _hRDD_GSchool,
       string _hRDD_HAddress, string _hRDD_Tel, string _hRDD_HasSocial, string _hRDD_HasAccumulation, string _hRDD_CertificateComplete, string _hRDD_EmergencyPer, string _hRDD_EmergencyNo)
    {
        hRET_ID = _hRET_ID;
        hRP_ID = _hRP_ID;
        bDOS_Code = _bDOS_Code;
        hRDD_StaffNO = _hRDD_StaffNO;
        hRDD_Name = _hRDD_Name;
        hRDD_Registration = _hRDD_Registration;
        hRDD_BasicWage = _hRDD_BasicWage;
        hRDD_FullTimeWage = _hRDD_FullTimeWage;
        hRDD_PerformWage = _hRDD_PerformWage;
        hRDD_OverTimeWage = _hRDD_OverTimeWage;
        hRDD_ConverseDate = _hRDD_ConverseDate;
        hRDD_ContactSDate = _hRDD_ContactSDate;
        hRDD_ContactEDate = _hRDD_ContactEDate;
        hRDD_Worklength = _hRDD_Worklength;
        hRDD_EntryDate = _hRDD_EntryDate;
        hRDD_DateOfBirth = _hRDD_DateOfBirth;
        hRDD_Sex = _hRDD_Sex;
        hRDD_IDCard = _hRDD_IDCard;
        hRDD_Nationality = _hRDD_Nationality;
        hRDD_IsMarried = _hRDD_IsMarried;
        hRDD_EduBackg = _hRDD_EduBackg;
        hRDD_Major = _hRDD_Major;
        hRDD_GSchool = _hRDD_GSchool;
        hRDD_HAddress = _hRDD_HAddress;
        hRDD_Tel = _hRDD_Tel;
        hRDD_HasSocial = _hRDD_HasSocial;
        hRDD_HasAccumulation = _hRDD_HasAccumulation;
        hRDD_CertificateComplete = _hRDD_CertificateComplete;
        hRDD_EmergencyPer = _hRDD_EmergencyPer;
        hRDD_EmergencyNo = _hRDD_EmergencyNo;
    }
    public HRDDetailInfo(Guid _hRP_ID, string _bDOS_Code, string _hRDD_StaffNO, string _hRDD_Name)
    {
        hRP_ID = _hRP_ID;
        bDOS_Code = _bDOS_Code;
        hRDD_StaffNO = _hRDD_StaffNO;
        hRDD_Name = _hRDD_Name;
    }
    public HRDDetailInfo(string _hRDD_StaffNO, string _hRDD_Name, decimal _hRDD_BasicWage, decimal _hRDD_FullTimeWage, decimal _hRDD_PerformWage, decimal _hRDD_OverTimeWage)
    {
        hRDD_StaffNO = _hRDD_StaffNO;
        hRDD_Name = _hRDD_Name;
        hRDD_BasicWage = _hRDD_BasicWage;
        hRDD_FullTimeWage = _hRDD_FullTimeWage;
        hRDD_PerformWage = _hRDD_PerformWage;
        hRDD_OverTimeWage = _hRDD_OverTimeWage;
    }

    //离职
     private Guid sAS_ASID;
	 private Guid hRPAT_ID;
	 private bool hRDD_HasSalarySet;
	 private bool hRDD_HasPerform;
	 private string hRDD_NETResult ;
	 private string hRDD_EState;
	 private DateTime hRDD_QuitTime;
	 private string hRDD_QuitRes ;
	 private string hRDD_QuitMan ;

     public HRDDetailInfo(Guid _sAS_ASID,Guid _hRPAT_ID,bool _hRDD_HasSalarySet,bool _hRDD_HasPerform,string _hRDD_NETResult,
         string _hRDD_EState, DateTime _hRDD_QuitTime, string _hRDD_QuitRes, string _hRDD_QuitMan, bool _hRDD_IsDeleted)
    {
        sAS_ASID=_sAS_ASID;
	    hRPAT_ID=_hRPAT_ID;
	    hRDD_HasSalarySet=_hRDD_HasSalarySet;
	    hRDD_HasPerform=_hRDD_HasPerform;
	    hRDD_NETResult= _hRDD_NETResult;
	    hRDD_EState=_hRDD_EState;
	    hRDD_QuitTime=_hRDD_QuitTime;
	    hRDD_QuitRes= _hRDD_QuitRes;
        hRDD_QuitMan = _hRDD_QuitMan;
        hRDD_IsDeleted = _hRDD_IsDeleted;
    }

     public Guid SAS_ASID
     {
         get { return sAS_ASID; }
         set { sAS_ASID = value; }
     }
     public Guid HRPAT_ID
     {
         get { return hRPAT_ID; }
         set { hRPAT_ID = value; }
     }
     public bool HRDD_HasSalarySet
     {
         get { return hRDD_HasSalarySet; }
         set { hRDD_HasSalarySet = value; }
     }
     public bool HRDD_HasPerform
     {
         get { return hRDD_HasPerform; }
         set { hRDD_HasPerform = value; }
     }
     public string HRDD_NETResult
     {
         get { return hRDD_NETResult; }
         set { hRDD_NETResult = value; }
     }
     public string HRDD_EState
     {
         get { return hRDD_EState; }
         set { hRDD_EState = value; }
     }
     public DateTime HRDD_QuitTime
     {
         get { return hRDD_QuitTime; }
         set { hRDD_QuitTime = value; }
     }
     public string HRDD_QuitRes
     {
         get { return hRDD_QuitRes; }
         set { hRDD_QuitRes = value; }
     }
     public string HRDD_QuitMan
     {
         get { return hRDD_QuitMan; }
         set { hRDD_QuitMan = value; }
     }
     public bool HRDD_IsDeleted
     {
         get { return hRDD_IsDeleted; }
         set { hRDD_IsDeleted = value; }
     }

     //奖惩
     private Guid hRRewards_ID;
     private string hRRewards_Type;
     private DateTime hRRewards_Time;
     private string hRRewards_Content;
     private string hRRewards_Note;
     private decimal hRRewards_Money;
     private string hRRewards_Agree;
     private DateTime hRRewards_OkTime;

     public HRDDetailInfo(Guid _hRRewards_ID, string _hRRewards_Type, DateTime _hRRewards_Time, string _hRRewards_Content, string _hRRewards_Note, decimal _hRRewards_Money, string _hRRewards_Agree, DateTime _hRRewards_OkTime)
     {
         hRRewards_ID = _hRRewards_ID;
         hRRewards_Type = _hRRewards_Type;
         hRRewards_Time = _hRRewards_Time;
         hRRewards_Content = _hRRewards_Content;
         hRRewards_Note = _hRRewards_Note;
         hRRewards_Money = _hRRewards_Money;
         hRRewards_Agree = _hRRewards_Agree;
         hRRewards_OkTime = _hRRewards_OkTime;
     }

     public decimal HRRewards_Money
     {
         get { return hRRewards_Money; }
         set { hRRewards_Money = value; }
     }
     public string HRRewards_Agree
     {
         get { return hRRewards_Agree; }
         set { hRRewards_Agree = value; }
     }
     public DateTime HRRewards_OkTime
     {
         get { return hRRewards_OkTime; }
         set { hRRewards_OkTime = value; }
     }
     public Guid HRRewards_ID
     {
         get { return hRRewards_ID; }
         set { hRRewards_ID = value; }
     }
     public string HRRewards_Type
     {
         get { return hRRewards_Type; }
         set { hRRewards_Type = value; }
     }
     public DateTime HRRewards_Time
     {
         get { return hRRewards_Time; }
         set { hRRewards_Time = value; }
     }
     public string HRRewards_Content
     {
         get { return hRRewards_Content; }
         set { hRRewards_Content = value; }
     }
     public string HRRewards_Note
     {
         get { return hRRewards_Note; }
         set { hRRewards_Note = value; }
     }
}