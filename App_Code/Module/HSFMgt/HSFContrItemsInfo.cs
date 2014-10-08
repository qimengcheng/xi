using System;

/// <summary>
///HSFContrItemsInfo 的摘要说明
/// </summary>
public class HSFContrItemsInfo
{
    private Guid hSFCI_ItemID;

    public Guid HSFCI_ItemID
    {
        get { return hSFCI_ItemID; }
        set { hSFCI_ItemID = value; }
    }

    private string hSFCI_ItemName;

    public string HSFCI_ItemName
    {
        get { return hSFCI_ItemName; }
        set { hSFCI_ItemName = value; }
    }

    private string hSFCI_Standard;

    public string HSFCI_Standard
    {
        get { return hSFCI_Standard; }
        set { hSFCI_Standard = value; }
    }

    private string hSFCI_Boundary;

    public string HSFCI_Boundary
    {
        get { return hSFCI_Boundary; }
        set { hSFCI_Boundary = value; }
    }

    private int hSFCI_Period;

    public int HSFCI_Period
    {
        get { return hSFCI_Period; }
        set { hSFCI_Period = value; }
    }

    private int hSFCI_RemindDay;

    public int HSFCI_RemindDay
    {
        get { return hSFCI_RemindDay; }
        set { hSFCI_RemindDay = value; }
    }

    private bool hSFCI_IsDeleted;

    public bool HSFCI_IsDeleted
    {
        get { return hSFCI_IsDeleted; }
        set { hSFCI_IsDeleted = value; }
    }

    private Guid iMMBD_MaterialID;

    public Guid IMMBD_MaterialID
    {
        get { return iMMBD_MaterialID; }
        set { iMMBD_MaterialID = value; }
    }

    private string iMMT_MaterialType;

    public string IMMT_MaterialType
    {
        get { return iMMT_MaterialType; }
        set { iMMT_MaterialType = value; }
    }

    private string iMMBD_MaterialName;

    public string IMMBD_MaterialName
    {
        get { return iMMBD_MaterialName; }
        set { iMMBD_MaterialName = value; }
    }

    public HSFContrItemsInfo(Guid _hSFCI_ItemID, string _hSFCI_ItemName, string _hSFCI_Standard,
        string _hSFCI_Boundary, int _hSFCI_Period, int _hSFCI_RemindDay, bool _hSFCI_IsDeleted)
    {
        hSFCI_ItemID = _hSFCI_ItemID;
        hSFCI_ItemName = _hSFCI_ItemName;
        hSFCI_Standard = _hSFCI_Standard;
        hSFCI_Boundary = _hSFCI_Boundary;
        hSFCI_Period = _hSFCI_Period;    
        hSFCI_RemindDay=_hSFCI_RemindDay;
        hSFCI_IsDeleted = _hSFCI_IsDeleted;
    }

    public HSFContrItemsInfo(string _hSFCI_ItemName, string _hSFCI_Standard,string _hSFCI_Boundary, int _hSFCI_Period, int _hSFCI_RemindDay)
    {
        hSFCI_ItemName = _hSFCI_ItemName;
        hSFCI_Standard = _hSFCI_Standard;
        hSFCI_Boundary = _hSFCI_Boundary;
        hSFCI_Period = _hSFCI_Period;
        hSFCI_RemindDay = _hSFCI_RemindDay;
    }

    public HSFContrItemsInfo(Guid _hSFCI_ItemID, string _hSFCI_ItemName, string _hSFCI_Standard,
        string _hSFCI_Boundary, int _hSFCI_Period, int _hSFCI_RemindDay)
    {
        hSFCI_ItemID = _hSFCI_ItemID;
        hSFCI_ItemName = _hSFCI_ItemName;
        hSFCI_Standard = _hSFCI_Standard;
        hSFCI_Boundary = _hSFCI_Boundary;
        hSFCI_Period = _hSFCI_Period;
        hSFCI_RemindDay = _hSFCI_RemindDay;
    }

    public HSFContrItemsInfo(Guid _iMMBD_MaterialID, string _iMMT_MaterialType, string _iMMBD_MaterialName)
    {
        iMMBD_MaterialID = _iMMBD_MaterialID;
        iMMT_MaterialType = _iMMT_MaterialType;
        iMMBD_MaterialName = _iMMBD_MaterialName;
    }

	public HSFContrItemsInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
}