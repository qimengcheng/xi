using System;

/// <summary>
///HRPerformceYearInfo 的摘要说明
/// </summary>
public class HRPerformceYearInfo
{
	public HRPerformceYearInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private Guid hRPYear_ID;
    private int hRP_Year;
    private int hRP_Month;
    private string hRP_A_State;
    private string hRP_C_State;
    private string hRP_A_Person;
    private string hRP_C_Person;
    private bool hRPYear_IsDeleted;
    private string hRP_M_State;

    public Guid HRPYear_ID
    {
        get { return hRPYear_ID; }
        set { hRPYear_ID = value; }
    }
    public int HRP_Year
    {
        get { return hRP_Year; }
        set { hRP_Year = value; }
    }
    public int HRP_Month
    {
        get { return hRP_Month; }
        set { hRP_Month = value; }
    }
    public string HRP_A_State
    {
        get { return hRP_A_State; }
        set { hRP_A_State = value; }
    }
    public string HRP_C_State
    {
        get { return hRP_C_State; }
        set { hRP_C_State = value; }
    }
    public string HRP_A_Person
    {
        get { return hRP_A_Person; }
        set { hRP_A_Person = value; }
    }
    public string HRP_C_Person
    {
        get { return hRP_C_Person; }
        set { hRP_C_Person = value; }
    }
    public bool HRPYear_IsDeleted
    {
        get { return hRPYear_IsDeleted; }
        set { hRPYear_IsDeleted = value; }
    }
    public string HRP_M_State
    {
        get { return hRP_M_State; }
        set { hRP_M_State = value; }
    }
}