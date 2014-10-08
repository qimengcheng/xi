using System;

/// <summary>
///HSFMaterialItemRelationInfo 的摘要说明
/// </summary>
public class HSFMaterialItemRelationInfo
{
    private Guid hSFMIR_RelationID;

    public Guid HSFMIR_RelationID
    {
        get { return hSFMIR_RelationID; }
        set { hSFMIR_RelationID = value; }
    }

    private Guid hSFCI_ItemID;

    public Guid HSFCI_ItemID
    {
        get { return hSFCI_ItemID; }
        set { hSFCI_ItemID = value; }
    }

    private Guid iMMBD_MaterialID;

    public Guid IMMBD_MaterialID
    {
        get { return iMMBD_MaterialID; }
        set { iMMBD_MaterialID = value; }
    }

    public HSFMaterialItemRelationInfo(Guid _hSFMIR_RelationID, Guid _hSFCI_ItemID, Guid _iMMBD_MaterialID)
    {
        hSFMIR_RelationID = _hSFMIR_RelationID;
        hSFCI_ItemID = _hSFCI_ItemID;
        iMMBD_MaterialID = _iMMBD_MaterialID;
    }

	public HSFMaterialItemRelationInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
}