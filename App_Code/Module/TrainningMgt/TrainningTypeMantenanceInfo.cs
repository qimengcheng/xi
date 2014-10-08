using System;

/// <summary>
///TrainningTypeMantenanceInfo 的摘要说明
/// </summary>
public class TrainningTypeMantenanceInfo
{
    private Guid tTT_TypeID;

    
    private string tTT_Type;


    private bool tTT_IsDeleted;

    public Guid TTT_TypeID
    {
        get { return tTT_TypeID; }
        set { tTT_TypeID = value; }
    }

    public string TTT_Type
    {
        get { return tTT_Type; }
        set { tTT_Type = value; }
    }

    public bool TTT_IsDeleted
    {
        get { return tTT_IsDeleted; }
        set { tTT_IsDeleted = value; }
    }
	public TrainningTypeMantenanceInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public TrainningTypeMantenanceInfo(string tTT_Type)
    {
        this.tTT_Type = tTT_Type;
    }
}