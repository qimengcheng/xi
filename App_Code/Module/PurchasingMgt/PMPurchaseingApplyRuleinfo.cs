using System;

/// <summary>
///PMPurchaseingApplyRuleinfo 的摘要说明
/// </summary>
public class PMPurchaseingApplyRuleinfo
{
    private Guid pMPAR_ID;

    
    private DateTime pMPAR_Time;

   
    private string pMPAR_Man;

   
    private string pMPAR_Rule;


    private bool pMPAR_Use;



    private Guid pMPAM_ID;


    private string pMPAM_ApplyNum;

   
    private string pMPAM_ApplyMan;


    private DateTime pMPAM_ApplyTime;


    private string pMPAM_Department;


    private string pMPAM_State;


    private string pMPAM_AppDepartMangResult;


    private string pMPAM_AppDepartMangOpinion;


    private DateTime pMPAM_AppDepartMangTime;


    private string pMPAM_CFECheckResult;


    private string pMPAM_CFECheckOpinion;


    private DateTime pMPAM_CFECheckTime;

    private string pMPAM_CFOCheckResult;


    private string pMPAM_CFOCheckOpinion;


    private DateTime pMPAM_CFOCheckTime;


    private string pMPAM_EmergencyPur;


    private string pMPAM_EmergencyMakeMan;


    private DateTime pMPAM_EmergencyTime;


    private string pMPAM_AppDepartMangName;


    private string pMPAM_CFECheckMan;


    private string pMPAM_CFOCheckMan;

    private Guid pMPO_PurchaseOrderID;


    private Guid iMMBD_MaterialID;


    private Guid pMPAD_ID;


    private int pMPAD_Num;

    private string pMPAD_Require;

    private string pMPAD_Purchase;

    private string pMPAD_TotalMoney;

    private int pMPAD_Price;

    private Guid hSFRL_RiskLevelID;

    private Guid iMMt_MaterialTypeID;

    private string iMMBD_MaterialName;

    private string iMMBD_MaterialCode;

    private string iMMBD_SpecificationModel;

    private string iMMBD_IsHarmful;

    private string iMMBD_UnitOfMeasurement;

    private string iMMBD_SafeStock;

    private int iMMBD_StorageDay;

    private string iMMBD_Comment;

    private string iMMBD_IsDeleted;

    private string iMMBD_CharacterPara;

    private string iMMBD_IsIQC;

    private string iMMBD_IsBelongHSF;

    private string iMMT_MaterialType;

    private string iMMT_Statement;

    private string iMMT_IsDeleted;

    private Guid  iMUC_ID;

    private Guid  unitID;

    private string iMUC_Default;

    private string iMUC_Rate;

    private string iMUC_IsDeleted;

    private string unitName;

    private string uNDeleted;

    private DateTime pMPAD_NeedTime;

    private Decimal pMPAD_PriceIndication;

    public Decimal PMPAD_PriceIndication
    {
        get { return pMPAD_PriceIndication; }
        set { pMPAD_PriceIndication = value; }
    }

    private string pMPAM_DeptMangCheckResult;

    public string PMPAM_DeptMangCheckResult
    {
        get { return pMPAM_DeptMangCheckResult; }
        set { pMPAM_DeptMangCheckResult = value; }
    }
    private string pMPAM_DeptMangCheckOpinion;

    public string PMPAM_DeptMangCheckOpinion
    {
        get { return pMPAM_DeptMangCheckOpinion; }
        set { pMPAM_DeptMangCheckOpinion = value; }
    }
    private DateTime pMPAM_DeptMangCheckTime;

    public DateTime PMPAM_DeptMangCheckTime
    {
        get { return pMPAM_DeptMangCheckTime; }
        set { pMPAM_DeptMangCheckTime = value; }
    }
    private string pMPAM_DeptMangName;

    public string PMPAM_DeptMangName
    {
        get { return pMPAM_DeptMangName; }
        set { pMPAM_DeptMangName = value; }
    }
    private string pMPAM_DesignMangCheckResult;

    public string PMPAM_DesignMangCheckResult
    {
        get { return pMPAM_DesignMangCheckResult; }
        set { pMPAM_DesignMangCheckResult = value; }
    }
    private string pMPAM_DesignMangCheckOpinion;

    public string PMPAM_DesignMangCheckOpinion
    {
        get { return pMPAM_DesignMangCheckOpinion; }
        set { pMPAM_DesignMangCheckOpinion = value; }
    }
    private DateTime pMPAM_DesignMangCheckTime;

    public DateTime PMPAM_DesignMangCheckTime
    {
        get { return pMPAM_DesignMangCheckTime; }
        set { pMPAM_DesignMangCheckTime = value; }
    }
    private string pMPAM_DesignMangName;

    public string PMPAM_DesignMangName
    {
        get { return pMPAM_DesignMangName; }
        set { pMPAM_DesignMangName = value; }
    }

    private decimal iMMBD_Price;

    public decimal IMMBD_Price
    {
        get { return iMMBD_Price; }
        set { iMMBD_Price = value; }
    }
    private int pMP_Year;

    public int PMP_Year
    {
        get { return pMP_Year; }
        set { pMP_Year = value; }
    }

    private int pMP_Month;

    public int PMP_Month
    {
        get { return pMP_Month; }
        set { pMP_Month = value; }
    }

    private string pMPAM_PersonnalCheckResult;

    public string PMPAM_PersonnalCheckResult
    {
        get { return pMPAM_PersonnalCheckResult; }
        set { pMPAM_PersonnalCheckResult = value; }
    }
    private string pMPAM_PersonnalCheckOpinion;

    public string PMPAM_PersonnalCheckOpinion
    {
        get { return pMPAM_PersonnalCheckOpinion; }
        set { pMPAM_PersonnalCheckOpinion = value; }
    }
    private DateTime pMPAM_PersonnalCheckTime;

    public DateTime PMPAM_PersonnalCheckTime
    {
        get { return pMPAM_PersonnalCheckTime; }
        set { pMPAM_PersonnalCheckTime = value; }
    }
    private string pMPAM_PersonnalCheckMan;

    public string PMPAM_PersonnalCheckMan
    {
        get { return pMPAM_PersonnalCheckMan; }
        set { pMPAM_PersonnalCheckMan = value; }
    }
    private string pMPAD_Remark;

    public string PMPAD_Remark
    {
        get { return pMPAD_Remark; }
        set { pMPAD_Remark = value; }
    }
	public PMPurchaseingApplyRuleinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public PMPurchaseingApplyRuleinfo(string _pMPAM_CFOCheckMan, string _pMPAM_CFECheckMan, string _pMPAM_AppDepartMangName, DateTime _pMPAM_EmergencyTime, string _pMPAM_EmergencyMakeMan,
        string _pMPAM_EmergencyPur, DateTime _pMPAM_CFOCheckTime, string _pMPAM_CFOCheckOpinion, string _pMPAM_CFOCheckResult, DateTime _pMPAM_CFECheckTime, string _pMPAM_CFECheckOpinion,
        string _pMPAM_CFECheckResult, DateTime _pMPAM_AppDepartMangTime, string _pMPAM_AppDepartMangOpinion, string _pMPAM_AppDepartMangResult, string _pMPAM_State, string _pMPAM_Department,
        DateTime _pMPAM_ApplyTime, string _PMPAM_ApplyMan, string _pMPAM_ApplyNum, Guid _pMPAM_ID, Guid _pMPAR_ID, DateTime _pMPAR_Time, string _pMPAR_Man, string _pMPAR_Rule, bool _pMPAR_Use,
        Guid _pMPO_PurchaseOrderID, Guid _iMMBD_MaterialID, int _pMPAD_Num, string _pMPAD_Require, string _pMPAD_Purchase, string _pMPAD_TotalMoney, int _pMPAD_Price, Guid _hSFRL_RiskLevelID,
        Guid _iMMt_MaterialTypeID, string _iMMBD_MaterialName, string _iMMBD_MaterialCode, string _iMMBD_SpecificationModel, string _iMMBD_IsHarmful, string _iMMBD_UnitOfMeasurement,
        string _iMMBD_SafeStock, int _iMMBD_StorageDay, string _iMMBD_Comment, string _iMMBD_IsDeleted, string _iMMBD_CharacterPara, string _iMMBD_IsIQC, string _iMMBD_IsBelongHSF,
        string _iMMT_MaterialType, string _iMMT_Statement, string _iMMT_IsDeleted, Guid _pMPAD_ID, Guid  _iMUC_ID, Guid  _unitID, string _iMUC_Default, string _iMUC_Rate, string _iMUC_IsDeleted,
        string _unitName, string _uNDeleted, DateTime _pMPAD_NeedTime)
    {
        pMPAD_NeedTime = _pMPAD_NeedTime;
        iMUC_ID = _iMUC_ID;
        unitID = _unitID;
        iMUC_Default = _iMUC_Default;
        iMUC_Rate = _iMUC_Rate;
        iMUC_IsDeleted = _iMUC_IsDeleted;
        unitName = _unitName;
        uNDeleted = _uNDeleted;
        pMPAD_ID = _pMPAD_ID;
        iMMT_MaterialType = _iMMT_MaterialType;
        iMMT_Statement = _iMMT_Statement;
        iMMT_IsDeleted = _iMMT_IsDeleted;
        pMPO_PurchaseOrderID = _pMPO_PurchaseOrderID;
        iMMBD_MaterialID = _iMMBD_MaterialID;
        pMPAD_Num = _pMPAD_Num;
        pMPAD_Require = _pMPAD_Require;
        pMPAD_Purchase = _pMPAD_Purchase;
        pMPAD_TotalMoney = _pMPAD_TotalMoney;
        pMPAD_Price = _pMPAD_Price;
        hSFRL_RiskLevelID = _hSFRL_RiskLevelID;
        iMMt_MaterialTypeID = _iMMt_MaterialTypeID;
        iMMBD_MaterialName = _iMMBD_MaterialName;
        iMMBD_MaterialCode = _iMMBD_MaterialCode;
        iMMBD_SpecificationModel = _iMMBD_SpecificationModel;
        iMMBD_IsHarmful = _iMMBD_IsHarmful;
        iMMBD_UnitOfMeasurement = _iMMBD_UnitOfMeasurement;
        iMMBD_SafeStock = _iMMBD_SafeStock;
        iMMBD_StorageDay = _iMMBD_StorageDay;
        iMMBD_Comment = _iMMBD_Comment;
        iMMBD_IsDeleted = _iMMBD_IsDeleted;
        iMMBD_CharacterPara = _iMMBD_CharacterPara;
        iMMBD_IsIQC = _iMMBD_IsIQC;
        iMMBD_IsBelongHSF = _iMMBD_IsBelongHSF;

        pMPAM_CFECheckTime = _pMPAM_CFECheckTime;
        pMPAM_CFOCheckResult = _pMPAM_CFOCheckResult;
        pMPAM_CFOCheckOpinion = _pMPAM_CFOCheckOpinion;
        pMPAM_CFOCheckMan = _pMPAM_CFOCheckMan;
        pMPAM_CFECheckMan = _pMPAM_CFECheckMan;
        pMPAM_AppDepartMangName = _pMPAM_AppDepartMangName;
        pMPAM_EmergencyTime = _pMPAM_EmergencyTime;
        pMPAM_EmergencyMakeMan = _pMPAM_EmergencyMakeMan;
        pMPAM_EmergencyPur = _pMPAM_EmergencyPur;
        pMPAM_CFOCheckTime = _pMPAM_CFOCheckTime;
        pMPAM_CFECheckOpinion = _pMPAM_CFECheckOpinion;
        pMPAM_CFECheckResult = _pMPAM_CFECheckResult;
        pMPAM_AppDepartMangTime = _pMPAM_AppDepartMangTime;
        pMPAM_AppDepartMangOpinion = _pMPAM_AppDepartMangOpinion;
        pMPAM_AppDepartMangResult = _pMPAM_AppDepartMangResult;
        pMPAM_State = _pMPAM_State;
        pMPAM_Department = _pMPAM_Department;
        pMPAM_ApplyTime = _pMPAM_ApplyTime;
        PMPAM_ApplyMan = _PMPAM_ApplyMan;
        pMPAM_ApplyNum = _pMPAM_ApplyNum;
        pMPAM_ID = _pMPAM_ID;
        pMPAR_ID = _pMPAR_ID;
        pMPAR_Time = _pMPAR_Time;
        pMPAR_Man = _pMPAR_Man;
        pMPAR_Rule = _pMPAR_Rule;
        pMPAR_Use = _pMPAR_Use;
    }
    public bool PMPAR_Use
    {
        get { return pMPAR_Use; }
        set { pMPAR_Use = value; }
    }
 public string PMPAR_Rule
    {
        get { return pMPAR_Rule; }
        set { pMPAR_Rule = value; }
    }
    public DateTime PMPAR_Time
    {
        get { return pMPAR_Time; }
        set { pMPAR_Time = value; }
    }

 public string PMPAR_Man
    {
        get { return pMPAR_Man; }
        set { pMPAR_Man = value; }
    }
public Guid PMPAR_ID
    {
        get { return pMPAR_ID; }
        set { pMPAR_ID = value; }
    }
public Guid PMPAM_ID
{
    get { return pMPAM_ID; }
    set { pMPAM_ID = value; }
}
public string PMPAM_ApplyNum
{
    get { return pMPAM_ApplyNum; }
    set { pMPAM_ApplyNum = value; }
}
public string PMPAM_ApplyMan
{
    get { return pMPAM_ApplyMan; }
    set { pMPAM_ApplyMan = value; }
}
public DateTime PMPAM_ApplyTime
{
    get { return pMPAM_ApplyTime; }
    set { pMPAM_ApplyTime = value; }
}
public string PMPAM_Department
{
    get { return pMPAM_Department; }
    set { pMPAM_Department = value; }
}
public string PMPAM_State
{
    get { return pMPAM_State; }
    set { pMPAM_State = value; }
}
public string PMPAM_AppDepartMangResult
{
    get { return pMPAM_AppDepartMangResult; }
    set { pMPAM_AppDepartMangResult = value; }
}
public string PMPAM_AppDepartMangOpinion
{
    get { return pMPAM_AppDepartMangOpinion; }
    set { pMPAM_AppDepartMangOpinion = value; }
}
public DateTime PMPAM_AppDepartMangTime
{
    get { return pMPAM_AppDepartMangTime; }
    set { pMPAM_AppDepartMangTime = value; }
}
public string PMPAM_CFECheckResult
{
    get { return pMPAM_CFECheckResult; }
    set { pMPAM_CFECheckResult = value; }
}
public string PMPAM_CFECheckOpinion
{
    get { return pMPAM_CFECheckOpinion; }
    set { pMPAM_CFECheckOpinion = value; }
}

public DateTime PMPAM_CFECheckTime
{
    get { return pMPAM_CFECheckTime; }
    set { pMPAM_CFECheckTime = value; }
}
public string PMPAM_CFOCheckResult
{
    get { return pMPAM_CFOCheckResult; }
    set { pMPAM_CFOCheckResult = value; }
}
public string PMPAM_CFOCheckOpinion
{
    get { return pMPAM_CFOCheckOpinion; }
    set { pMPAM_CFOCheckOpinion = value; }
}
public DateTime PMPAM_CFOCheckTime
{
    get { return pMPAM_CFOCheckTime; }
    set { pMPAM_CFOCheckTime = value; }
}
public string PMPAM_EmergencyPur
{
    get { return pMPAM_EmergencyPur; }
    set { pMPAM_EmergencyPur = value; }
}
public string PMPAM_EmergencyMakeMan
{
    get { return pMPAM_EmergencyMakeMan; }
    set { pMPAM_EmergencyMakeMan = value; }
}
public DateTime PMPAM_EmergencyTime
{
    get { return pMPAM_EmergencyTime; }
    set { pMPAM_EmergencyTime = value; }
}
public string PMPAM_AppDepartMangName
{
    get { return pMPAM_AppDepartMangName; }
    set { pMPAM_AppDepartMangName = value; }
}
public string PMPAM_CFECheckMan
{
    get { return pMPAM_CFECheckMan; }
    set { pMPAM_CFECheckMan = value; }
}
public string PMPAM_CFOCheckMan
{
    get { return pMPAM_CFOCheckMan; }
    set { pMPAM_CFOCheckMan = value; }
}
public Guid PMPO_PurchaseOrderID
{
    get { return pMPO_PurchaseOrderID; }
    set { pMPO_PurchaseOrderID = value; }
}
public int PMPAD_Num
{
    get { return pMPAD_Num; }
    set { pMPAD_Num = value; }
}

public string PMPAD_Require
{
    get { return pMPAD_Require; }
    set { pMPAD_Require = value; }
}

public string PMPAD_Purchase
{
    get { return pMPAD_Purchase; }
    set { pMPAD_Purchase = value; }
}

public string PMPAD_TotalMoney
{
    get { return pMPAD_TotalMoney; }
    set { pMPAD_TotalMoney = value; }
}

public int PMPAD_Price
{
    get { return pMPAD_Price; }
    set { pMPAD_Price = value; }
}

public Guid HSFRL_RiskLevelID
{
    get { return hSFRL_RiskLevelID; }
    set { hSFRL_RiskLevelID = value; }
}

public Guid IMMt_MaterialTypeID
{
    get { return iMMt_MaterialTypeID; }
    set { iMMt_MaterialTypeID = value; }
}

public string IMMBD_MaterialName
{
    get { return iMMBD_MaterialName; }
    set { iMMBD_MaterialName = value; }
}

public string IMMBD_MaterialCode
{
    get { return iMMBD_MaterialCode; }
    set { iMMBD_MaterialCode = value; }
}

public string IMMBD_SpecificationModel
{
    get { return iMMBD_SpecificationModel; }
    set { iMMBD_SpecificationModel = value; }
}

public string IMMBD_IsHarmful
{
    get { return iMMBD_IsHarmful; }
    set { iMMBD_IsHarmful = value; }
}

public string IMMBD_UnitOfMeasurement
{
    get { return iMMBD_UnitOfMeasurement; }
    set { iMMBD_UnitOfMeasurement = value; }
}

public string IMMBD_SafeStock
{
    get { return iMMBD_SafeStock; }
    set { iMMBD_SafeStock = value; }
}

public int IMMBD_StorageDay
{
    get { return iMMBD_StorageDay; }
    set { iMMBD_StorageDay = value; }
}

public string IMMBD_Comment
{
    get { return iMMBD_Comment; }
    set { iMMBD_Comment = value; }
}

public string IMMBD_IsDeleted
{
    get { return iMMBD_IsDeleted; }
    set { iMMBD_IsDeleted = value; }
}

public string IMMBD_CharacterPara
{
    get { return iMMBD_CharacterPara; }
    set { iMMBD_CharacterPara = value; }
}

public string IMMBD_IsIQC
{
    get { return iMMBD_IsIQC; }
    set { iMMBD_IsIQC = value; }
}

public string IMMBD_IsBelongHSF
{
    get { return iMMBD_IsBelongHSF; }
    set { iMMBD_IsBelongHSF = value; }
}
public string IMMT_MaterialType
{
    get { return iMMT_MaterialType; }
    set { iMMT_MaterialType = value; }
}


public string IMMT_Statement
{
    get { return iMMT_Statement; }
    set { iMMT_Statement = value; }
}


public string IMMT_IsDeleted
{
    get { return iMMT_IsDeleted; }
    set { iMMT_IsDeleted = value; }
}
public Guid IMMBD_MaterialID
{
    get { return iMMBD_MaterialID; }
    set { iMMBD_MaterialID = value; }
}
public Guid PMPAD_ID
{
    get { return pMPAD_ID; }
    set { pMPAD_ID = value; }
}
public Guid  IMUC_ID
{
    get { return iMUC_ID; }
    set { iMUC_ID = value; }
}


public Guid  UnitID
{
    get { return unitID; }
    set { unitID = value; }
}


public string IMUC_Default
{
    get { return iMUC_Default; }
    set { iMUC_Default = value; }
}


public string IMUC_Rate
{
    get { return iMUC_Rate; }
    set { iMUC_Rate = value; }
}


public string IMUC_IsDeleted
{
    get { return iMUC_IsDeleted; }
    set { iMUC_IsDeleted = value; }
}


public string UnitName
{
    get { return unitName; }
    set { unitName = value; }
}


public string UNDeleted
{
    get { return uNDeleted; }
    set { uNDeleted = value; }
}
public DateTime PMPAD_NeedTime
{
    get { return pMPAD_NeedTime; }
    set { pMPAD_NeedTime = value; }
}
}