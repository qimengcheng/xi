using System;


/// <summary>
///UMModelInfo 的摘要说明
/// </summary>
public class UMModelInfoinfo
{
    private Guid uMMI_ModelID;
    private string  uMMI_ModelName;
    private int  uMMI_StandardNumber;
    private int  uMMI_StandardCapacity;
    private Guid pMPK_ID;

    public UMModelInfoinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public UMModelInfoinfo(Guid _uMMI_ModelID, string _uMMI_ModelName, int _uMMI_StandardNumber, int _uMMI_StandardCapacity, Guid _pMPK_ID)
    {
        uMMI_ModelID = _uMMI_ModelID;
        uMMI_ModelName = _uMMI_ModelName;
        uMMI_StandardNumber = _uMMI_StandardNumber;
        uMMI_StandardCapacity = _uMMI_StandardNumber;
        pMPK_ID = _pMPK_ID;
    
    }
    public UMModelInfoinfo(string _uMMI_ModelName,Guid _uMMI_ModelID)
    {
        
        uMMI_ModelName = _uMMI_ModelName;
        uMMI_ModelID = _uMMI_ModelID;

    }
    public Guid UMMI_ModelID
    {
        get { return uMMI_ModelID; }
        set { uMMI_ModelID = value; }
    }
    public string UMMI_ModelName
    {
        get { return uMMI_ModelName; }
        set { uMMI_ModelName = value; }
    }
    public int UMMI_StandardNumber
    {
        get { return uMMI_StandardNumber; }
        set { uMMI_StandardNumber = value; }
    }
    public int UMMI_StandardCapacity
    {
        get { return uMMI_StandardCapacity; }
        set { uMMI_StandardCapacity = value; }
    }
    public Guid PMPK_ID
    {
        get { return pMPK_ID; }
        set { pMPK_ID = value; }
    }

}
