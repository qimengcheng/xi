using System;

/// <summary>
///EMEquipmentInfInfo 的摘要说明
/// </summary>
public class EMEquipmentInfInfo
{
    private Guid eTT_ID;
    private string eTT_Type;
    private bool eTT_IsDeleted;

    private Guid eN_ID;
    private string eN_EquipName;
    private bool eN_IsDeleted;

    private Guid eMT_ID;
    private string eMT_Type;

    private Guid eI_ID;
    private string eI_No;
    private string eI_Location;
    private string eI_Providor;
    private string eI_IsToCare;
    public DateTime eI_AcceptDate;
    private string eI_State;
    private bool eI_IsDeleted;

	public EMEquipmentInfInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public EMEquipmentInfInfo(Guid _eTT_ID,string _eTT_Type,bool _eTT_IsDeleted,Guid _eN_ID,string _eN_EquipName,bool _eN_IsDeleted,
        Guid _eMT_ID,string _eMT_Type,Guid _eI_ID,string _eI_No,string _eI_Location,string _eI_Providor,string _eI_IsToCare,
        DateTime _eI_AcceptDate,string _eI_State,bool _eI_IsDeleted)
    {
        eTT_ID = _eTT_ID;
        eTT_Type = _eTT_Type;
        eTT_IsDeleted = _eTT_IsDeleted;
        eN_ID = _eN_ID;
        eN_EquipName = _eN_EquipName;
        eN_IsDeleted = _eN_IsDeleted;
        eMT_ID = _eMT_ID;
        eMT_Type = _eMT_Type;
        eI_ID = _eN_ID;
        eI_No = _eI_No;
        eI_Location = _eI_Location;
        eI_Providor = _eI_Providor;
        eI_IsToCare = _eI_IsToCare;
        eI_AcceptDate = _eI_AcceptDate;
        eI_State = _eI_State;
        eI_IsDeleted = _eI_IsDeleted;
    }

    public Guid ETT_ID
    {
        get { return eTT_ID; }
        set { eTT_ID = value; }
    }
    public string ETT_Type
    {
        get { return eTT_Type; }
        set { eTT_Type = value; }
    }
    public bool ETT_IsDeleted
    {
        get { return eTT_IsDeleted; }
        set { eTT_IsDeleted = value; }
    }


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


    public Guid EI_ID
    {
        get { return eI_ID; }
        set { eI_ID = value; }
    }
    public string EI_No
    {
        get { return eI_No; }
        set { eI_No = value; }
    }
    public string EI_Location
    {
        get { return eI_Location; }
        set { eI_Location = value; }
    }
    public string EI_Providor
    {
        get { return eI_Providor; }
        set { eI_Providor = value; }
    }
    public string EI_IsToCare
    {
        get { return eI_IsToCare; }
        set { eI_IsToCare = value; }
    }
    public DateTime EI_AcceptDate
    {
        get { return eI_AcceptDate; }
        set { eI_AcceptDate = value; }
    }
    public string EI_State
    {
        get { return eI_State; }
        set { eI_State = value; }
    }
    public bool EI_IsDeleted
    {
        get { return eI_IsDeleted; }
        set { eI_IsDeleted = value; }
    }
}