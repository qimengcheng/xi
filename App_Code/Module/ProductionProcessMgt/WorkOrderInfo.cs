using System;

/// <summary>
///WorkOrderInfo 的摘要说明
/// </summary>
public class WorkOrderInfo
{
    private Guid wO_ID;

    public Guid WO_ID
    {
        get { return wO_ID; }
        set { wO_ID = value; }
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

    private string wO_State;

    public string WO_State
    {
        get { return wO_State; }
        set { wO_State = value; }
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
    private DateTime wO_Time;

    public DateTime WO_Time
    {
        get { return wO_Time; }
        set { wO_Time = value; }
    }

    private string wO_OrderNum;

    public string WO_OrderNum
    {
        get { return wO_OrderNum; }
        set { wO_OrderNum = value; }
    }

    private Guid sMSO_ID;

    public Guid SMSO_ID
    {
        get { return sMSO_ID; }
        set { sMSO_ID = value; }
    }


	public WorkOrderInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public WorkOrderInfo(Guid _wO_ID, string _wO_Num, string _wO_Type, string _wO_State, string _wO_ProType, 
  string _wO_SN , string _wO_Level, string _wO_ChipNum, int _wO_PNum, string _wO_Note, string _wO_People, 
        DateTime _wO_Time, Guid _sMSO_ID)
    {
        wO_ID = _wO_ID;
        wO_Num = _wO_Num;
        wO_Type = _wO_Type;
        wO_State = _wO_State;
        wO_ProType = _wO_ProType;
        wO_SN = _wO_SN;
        wO_Level = _wO_Level;
        wO_ChipNum = _wO_ChipNum;
        wO_PNum = _wO_PNum;
        wO_Note = _wO_Note;
        wO_People = _wO_People;
        wO_Time = _wO_Time;
        sMSO_ID = _sMSO_ID;
    }
}