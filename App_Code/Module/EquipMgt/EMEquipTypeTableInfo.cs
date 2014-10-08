using System;

/// <summary>
///EMEquipTypeTableInfo 的摘要说明
/// </summary>
public class EMEquipTypeTableInfo
{
    private Guid eTT_ID;
    private string eTT_Type;
    private bool eTT_IsDeleted;

	public EMEquipTypeTableInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
    }
    public EMEquipTypeTableInfo(Guid _eTT_ID, string _eTT_Type, bool _eTT_IsDeleted)
    {
        eTT_ID = _eTT_ID;
        eTT_Type = _eTT_Type;
        eTT_IsDeleted = _eTT_IsDeleted;
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
}
