using System;

/// <summary>
///IQCBasicDataInfo 的摘要说明
/// </summary>
public class IQCBasicDataInfo
{
    private string state;

    public string State
    {
        get { return state; }
        set { state = value; }
    }
    private string code;

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    private string oP;
    public string OP
    {
        get { return oP; }
        set { oP = value; }
    }
    private Guid iQCDT_ID;

    public Guid IQCDT_ID
    {
        get { return iQCDT_ID; }
        set { iQCDT_ID = value; }
    }
    private string iQCDT_DownDetail;

    public string IQCDT_DownDetail
    {
        get { return iQCDT_DownDetail; }
        set { iQCDT_DownDetail = value; }
    } 
    private string iQCDT_ASugg;

    public string IQCDT_ASugg
    {
        get { return iQCDT_ASugg; }
        set { iQCDT_ASugg = value; }
    }
    private string iQCDT_AResult;

    public string IQCDT_AResult
    {
        get { return iQCDT_AResult; }
        set { iQCDT_AResult = value; }
    }
    private string iQCDT_Auditor;

    public string IQCDT_Auditor
    {
        get { return iQCDT_Auditor; }
        set { iQCDT_Auditor = value; }
    }
    private string iQCDT_Description;

    public string IQCDT_Description
    {
        get { return iQCDT_Description; }
        set { iQCDT_Description = value; }
    }
    private DateTime iQCDT_TestTime;

    public DateTime IQCDT_TestTime
    {
        get { return iQCDT_TestTime; }
        set { iQCDT_TestTime = value; }
    }
    private string iQCDT_TestPer;

    public string IQCDT_TestPer
    {
        get { return iQCDT_TestPer; }
        set { iQCDT_TestPer = value; }
    }
    private decimal iQCDT_Input;

    public decimal IQCDT_Input
    {
        get { return iQCDT_Input; }
        set { iQCDT_Input = value; }
    }
    private string iQCDT_Result;

    public string IQCDT_Result
    {
        get { return iQCDT_Result; }
        set { iQCDT_Result = value; }
    }
    private string iMIDS_QA;

    public string IMIDS_QA
    {
        get { return iMIDS_QA; }
        set { iMIDS_QA = value; }
    }
    private Guid iQCIT_ID;

    public Guid IQCIT_ID
    {
        get { return iQCIT_ID; }
        set { iQCIT_ID = value; }
    }

    private Guid iMMBD_MaterialID;

    public Guid IMMBD_MaterialID
    {
        get { return iMMBD_MaterialID; }
        set { iMMBD_MaterialID = value; }
    }

    private string iQCIT_Items;

    public string IQCIT_Items
    {
        get { return iQCIT_Items; }
        set { iQCIT_Items = value; }
    }

    private string iQCIT_NeedValue;

    public string IQCIT_NeedValue
    {
        get { return iQCIT_NeedValue; }
        set { iQCIT_NeedValue = value; }
    }

    private Guid iQCST_ID;

    public Guid IQCST_ID
    {
        get { return iQCST_ID; }
        set { iQCST_ID = value; }
    }

    private string iQCIT_Standard;

    public string IQCIT_Standard
    {
        get { return iQCIT_Standard; }
        set { iQCIT_Standard = value; }
    }

    private string iQCIT_Remarks;

    public string IQCIT_Remarks
    {
        get { return iQCIT_Remarks; }
        set { iQCIT_Remarks = value; }
    }

    private string pT_Name;

    public string PT_Name
    {
        get { return pT_Name; }
        set { pT_Name = value; }
    }



    private DateTime iMISM_InStoreTime;

    public DateTime IMISM_InStoreTime
    {
        get { return iMISM_InStoreTime; }
        set { iMISM_InStoreTime = value; }
    }

    private string unitName;

    public string UnitName
    {
        get { return unitName; }
        set { unitName = value; }
    }

    private decimal iMIDS_ActualArrNum;

    public decimal IMIDS_ActualArrNum
    {
        get { return iMIDS_ActualArrNum; }
        set { iMIDS_ActualArrNum = value; }
    }

    private string pMSI_SupplyName;

    public string PMSI_SupplyName
    {
        get { return pMSI_SupplyName; }
        set { pMSI_SupplyName = value; }
    }

    private string iMMBD_SpecificationModel;

    public string IMMBD_SpecificationModel
    {
        get { return iMMBD_SpecificationModel; }
        set { iMMBD_SpecificationModel = value; }
    }

    private string iMMBD_MaterialCode;

    public string IMMBD_MaterialCode
    {
        get { return iMMBD_MaterialCode; }
        set { iMMBD_MaterialCode = value; }
    }

    private string iMMBD_MaterialName;

    public string IMMBD_MaterialName
    {
        get { return iMMBD_MaterialName; }
        set { iMMBD_MaterialName = value; }
    }

    private string iMMT_MaterialType;

    public string IMMT_MaterialType
    {
        get { return iMMT_MaterialType; }
        set { iMMT_MaterialType = value; }
    }

    private Guid iMISD_ID;

    public Guid IMISD_ID
    {
        get { return iMISD_ID; }
        set { iMISD_ID = value; }
    }

    private string wO_Num;

    public string WO_Num
    {
        get { return wO_Num; }
        set { wO_Num = value; }
    }

    private string wO_Type;

    public string WO_Type
    {
        get { return wO_Type; }
        set { wO_Type = value; }
    }

    private string wO_ProType;

    public string WO_ProType
    {
        get { return wO_ProType; }
        set { wO_ProType = value; }
    }
    private string wO_SN;

    public string WO_SN
    {
        get { return wO_SN; }
        set { wO_SN = value; }
    }
    private string wO_Level;

    public string WO_Level
    {
        get { return wO_Level; }
        set { wO_Level = value; }
    }
    private string wO_ChipNum;

    public string WO_ChipNum
    {
        get { return wO_ChipNum; }
        set { wO_ChipNum = value; }
    }
    private int wO_PNum;

    public int WO_PNum
    {
        get { return wO_PNum; }
        set { wO_PNum = value; }
    }
    private string wO_Note;

    public string WO_Note
    {
        get { return wO_Note; }
        set { wO_Note = value; }
    }
    private string wO_People;

    public string WO_People
    {
        get { return wO_People; }
        set { wO_People = value; }
    }

    private DateTime iQCDT_ATime;

    public DateTime IQCDT_ATime
    {
        get { return iQCDT_ATime; }
        set { iQCDT_ATime = value; }
    }

    private string iMISM_InStoreNum;

    public string IMISM_InStoreNum
    {
        get { return iMISM_InStoreNum; }
        set { iMISM_InStoreNum = value; }
    }

    private int wO_IsShengchan;

    public int WO_IsShengchan
    {
        get { return wO_IsShengchan; }
        set { wO_IsShengchan = value; }
    }

    public IQCBasicDataInfo(string _iQCDT_Auditor, DateTime _iQCDT_ATime, string _iQCDT_AResult, string _iQCDT_ASugg, string _iQCDT_DownDetail,
       int _wO_IsShengchan,string _wO_Level)
    {
        iQCDT_Auditor = _iQCDT_Auditor;
        iQCDT_ATime = _iQCDT_ATime;
        iQCDT_AResult = _iQCDT_AResult;
        iQCDT_ASugg = _iQCDT_ASugg;
        iQCDT_DownDetail = _iQCDT_DownDetail;
        wO_IsShengchan=_wO_IsShengchan;
        wO_Level = _wO_Level;
    }

    public IQCBasicDataInfo(decimal _iQCDT_Input, string _iQCDT_TestPer, DateTime _iQCDT_TestTime, string _iQCDT_Description,string _iQCDT_Result)
    {
        iQCDT_Input = _iQCDT_Input;
        iQCDT_TestPer = _iQCDT_TestPer;
        iQCDT_TestTime = _iQCDT_TestTime;
        iQCDT_Description = _iQCDT_Description;
        iQCDT_Result = _iQCDT_Result;
    }

    public IQCBasicDataInfo(string _wO_Num, string _wO_Type, string _wO_ProType, string _wO_SN,string _wO_Level,
        string _wO_ChipNum,int _wO_PNum,string _wO_Note,string _wO_People)
    {
        wO_Num = _wO_Num;
        wO_Type = _wO_Type;
        wO_ProType = _wO_ProType;
        wO_SN = _wO_SN;
        wO_Level=_wO_Level;
            wO_ChipNum=_wO_ChipNum;
            wO_PNum=_wO_PNum;
                wO_Note=_wO_Note;
                wO_People = _wO_People;
    }

	public IQCBasicDataInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public IQCBasicDataInfo(Guid _iQCIT_ID, Guid _iMMBD_MaterialID, string _iQCIT_Items, string _iQCIT_NeedValue)
    {
        iQCIT_ID = _iQCIT_ID;
        iMMBD_MaterialID = _iMMBD_MaterialID;
        iQCIT_Items = _iQCIT_Items;
        iQCIT_NeedValue = _iQCIT_NeedValue;
    }

    public IQCBasicDataInfo(Guid _iQCST_ID, string _iQCIT_Standard, Guid _iQCIT_ID, string _iQCIT_Remarks)
    {
        iQCST_ID = _iQCST_ID;
        iQCIT_ID = _iQCIT_ID;
        iQCIT_Standard = _iQCIT_Standard;
        iQCIT_Remarks = _iQCIT_Remarks;
    }

    public IQCBasicDataInfo(string _pT_Name)
    {
        pT_Name = _pT_Name;
    }

    public IQCBasicDataInfo(Guid _iMISD_ID, Guid _iMMBD_MaterialID,string _iMISM_InStoreNum, string _iMMT_MaterialType, string _iMMBD_MaterialName, string _iMMBD_MaterialCode,
        string _iMMBD_SpecificationModel, string _pMSI_SupplyName, decimal _iMIDS_ActualArrNum, string _unitName, DateTime _iMISM_InStoreTime)
    {
        iMISD_ID = _iMISD_ID;
        iMMBD_MaterialID = _iMMBD_MaterialID;
        iMISM_InStoreNum = _iMISM_InStoreNum;
        iMMT_MaterialType = _iMMT_MaterialType;
        iMMBD_MaterialName = _iMMBD_MaterialName;
        iMMBD_MaterialCode = _iMMBD_MaterialCode;
        iMMBD_SpecificationModel = _iMMBD_SpecificationModel;
        pMSI_SupplyName = _pMSI_SupplyName;
        iMIDS_ActualArrNum = _iMIDS_ActualArrNum;
        unitName = _unitName;
        iMISM_InStoreTime = _iMISM_InStoreTime;
    }

    public IQCBasicDataInfo(Guid _iMISD_ID,Guid _iQCDT_ID, Guid _iMMBD_MaterialID, string _iMMT_MaterialType, string _iMMBD_MaterialName, string _iMMBD_MaterialCode,
        string _iMMBD_SpecificationModel, string _pMSI_SupplyName, decimal _iMIDS_ActualArrNum, string _unitName, DateTime _iMISM_InStoreTime)
    {
        iMISD_ID = _iMISD_ID;
        iQCDT_ID = _iQCDT_ID;
        iMMBD_MaterialID = _iMMBD_MaterialID;
        iMMT_MaterialType = _iMMT_MaterialType;
        iMMBD_MaterialName = _iMMBD_MaterialName;
        iMMBD_MaterialCode = _iMMBD_MaterialCode;
        iMMBD_SpecificationModel = _iMMBD_SpecificationModel;
        pMSI_SupplyName = _pMSI_SupplyName;
        iMIDS_ActualArrNum = _iMIDS_ActualArrNum;
        unitName = _unitName;
        iMISM_InStoreTime = _iMISM_InStoreTime;
    }
    public IQCBasicDataInfo(Guid _iMISD_ID, Guid _iQCDT_ID, Guid _iMMBD_MaterialID, string _iMMT_MaterialType, string _iMMBD_MaterialName, string _iMMBD_MaterialCode,
        string _iMMBD_SpecificationModel, string _pMSI_SupplyName, decimal _iMIDS_ActualArrNum, string _unitName, DateTime _iMISM_InStoreTime,string _op)
    {
        iMISD_ID = _iMISD_ID;
        iQCDT_ID = _iQCDT_ID;
        iMMBD_MaterialID = _iMMBD_MaterialID;
        iMMT_MaterialType = _iMMT_MaterialType;
        iMMBD_MaterialName = _iMMBD_MaterialName;
        iMMBD_MaterialCode = _iMMBD_MaterialCode;
        iMMBD_SpecificationModel = _iMMBD_SpecificationModel;
        pMSI_SupplyName = _pMSI_SupplyName;
        iMIDS_ActualArrNum = _iMIDS_ActualArrNum;
        unitName = _unitName;
        iMISM_InStoreTime = _iMISM_InStoreTime;
        oP = _op;
    }
}