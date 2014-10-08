using System;

/// <summary>
///EMEquipName_EMEquipModelTableInfo 的摘要说明
/// </summary>
public class EMEquipName_EMEquipModelTableInfo
{
    private Guid eN_ID;
    private string eN_EquipName;
    private bool eN_IsDeleted;

    private Guid eMT_ID;
    private string eMT_Type;

    private Guid eFUS_ID;
    private Guid iMMt_MaterialTypeID;
    private string iMMT_MaterialType;
    private Guid iMMBD_MaterialID;
    private string iMMBD_MaterialName;
    private string iMMBD_MaterialCode;
    private string iMMBD_SpecificationModel;
    private decimal iMMBD_SafeStock;
    private bool iMMT_IsDeleted;
    private decimal iMIM_TotalNum;

    public EMEquipName_EMEquipModelTableInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
    }
    public EMEquipName_EMEquipModelTableInfo(Guid _eN_ID, string _eN_EquipName, bool _eN_IsDeleted, Guid _eMT_ID, string _eMT_Type,
                                             Guid _eFUS_ID, Guid _iMMt_MaterialTypeID, string _iMMT_MaterialType, Guid _iMMBD_MaterialID,
                                             string _iMMBD_MaterialName, string _iMMBD_MaterialCode, string _iMMBD_SpecificationModel,
                                             decimal _iMMBD_SafeStock, bool _iMMT_IsDeleted, decimal _iMIM_TotalNum)
    {
        eN_ID = _eN_ID;
        eN_EquipName = _eN_EquipName;

        eN_IsDeleted = _eN_IsDeleted;
        eMT_ID = _eMT_ID;
        eMT_Type = _eMT_Type;

        eFUS_ID = _eFUS_ID;
        iMMt_MaterialTypeID = _iMMt_MaterialTypeID;
        iMMT_MaterialType = _iMMT_MaterialType;
        iMMBD_MaterialID = _iMMBD_MaterialID;
        iMMBD_MaterialName = _iMMBD_MaterialName;
        iMMBD_MaterialCode=_iMMBD_MaterialCode;
        iMMBD_SpecificationModel = _iMMBD_SpecificationModel;
        iMMBD_SafeStock = _iMMBD_SafeStock;
        iMMT_IsDeleted = _iMMT_IsDeleted;
        iMIM_TotalNum = _iMIM_TotalNum;
    }

    //名称
    public Guid EN_ID
    {
        get { return eN_ID; }
        set { eN_ID = value; }
    }
    public string EN_EquipName
    {
        get { return eN_EquipName; }
        set { eN_EquipName = value; }
    }
    public bool EN_IsDeleted
    {
        get { return eN_IsDeleted; }
        set { eN_IsDeleted = value; }
    }

    //型号
    public Guid EMT_ID
    {
        get { return eMT_ID; }
        set { eMT_ID = value; }
    }
    public string EMT_Type
    {
        get { return eMT_Type; }
        set { eMT_Type = value; }
    }

    //备件
    public Guid EFUS_ID
    {
        get { return eFUS_ID; }
        set { eFUS_ID = value; }
    }
    public Guid IMMt_MaterialTypeID
    {
        get { return iMMt_MaterialTypeID; }
        set { iMMt_MaterialTypeID = value; }
    }
    public string IMMT_MaterialType
    {
        get { return iMMT_MaterialType; }
        set { iMMT_MaterialType = value; }
    }
    public Guid IMMBD_MaterialID
    {
        get { return iMMBD_MaterialID; }
        set { iMMBD_MaterialID = value; }
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
    public decimal IMMBD_SafeStock
    {
        get { return iMMBD_SafeStock; }
        set { iMMBD_SafeStock = value; }
    }
    public bool IMMT_IsDeleted
    {
        get { return iMMT_IsDeleted; }
        set { iMMT_IsDeleted = value; }
    }
    public decimal IMIM_TotalNum
    {
        get { return iMIM_TotalNum; }
        set { iMIM_TotalNum = value; }
    }
}