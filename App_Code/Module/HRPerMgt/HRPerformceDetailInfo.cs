using System;

/// <summary>
///HRPerformceDetailInfo 的摘要说明
/// </summary>
public class HRPerformceDetailInfo
{
	public HRPerformceDetailInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private Guid hRPD_ID;
    private Guid hRDD_ID;
    private Guid hRPYear_ID;
    private string hRPD_APerson;
    private DateTime hRPD_Atime;
    private string hRPD_Auditor;
    private DateTime hRPD_AuTime;
    private int hRPD_FinalScore;
    private int hRPD_Year;
    private int hRPD_Month;
    private int hRPD_C_FinalScore;
    private bool hRPD_State;
    private bool hRPD_AState;
    private int hRPD_M_Score;
    public Guid HRPD_ID
    {
        get { return hRPD_ID; }
        set { hRPD_ID = value; }
    }
    public Guid HRDD_ID
    {
        get { return hRDD_ID; }
        set { hRDD_ID = value; }
    }
    public Guid HRPYear_ID
    {
        get { return hRPYear_ID; }
        set { hRPYear_ID = value; }
    }
    public string HRPD_APerson
    {
        get { return hRPD_APerson; }
        set { hRPD_APerson = value; }
    }
    public DateTime HRPD_Atime
    {
        get { return hRPD_Atime; }
        set { hRPD_Atime = value; }
    }
    public string HRPD_Auditor
    {
        get { return hRPD_Auditor; }
        set { hRPD_Auditor = value; }
    }

    public DateTime HRPD_AuTime
    {
        get { return hRPD_AuTime; }
        set { hRPD_AuTime = value; }
    }
    public int HRPD_FinalScore
    {
        get { return hRPD_FinalScore; }
        set { hRPD_FinalScore = value; }
    }
    public int HRPD_Year
    {
        get { return hRPD_Year; }
        set { hRPD_Year = value; }
    }
    public int HRPD_Month
    {
        get { return hRPD_Month; }
        set { hRPD_Month = value; }
    }
    public int HRPD_C_FinalScore
    {
        get { return hRPD_C_FinalScore; }
        set { hRPD_C_FinalScore = value; }
    }
    public bool HRPD_State
    {
        get { return hRPD_State; }
        set { hRPD_State = value; }
     }
    public bool HRPD_AState
    {
        get { return hRPD_AState; }
        set { hRPD_AState = value; }
    }
    public int HRPD_M_Score
    {
        get { return hRPD_M_Score; }
        set { hRPD_M_Score = value; }
    }
}