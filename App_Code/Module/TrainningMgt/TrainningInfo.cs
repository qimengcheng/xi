using System;

/// <summary>
///TrainningInfo 的摘要说明
/// </summary>
public class TrainningInfo
{
    /// <summary>
    /// 培训年度计划主表:TrainingYPlanMain
    /// </summary>
    private Guid tYPM_ID;
    private int tYPM_Year;
    private string tYPM_State;
    private string tYPM_Maker;
    private DateTime tYPM_Time;

    /// <summary>
    /// 培训项目明细表:TrainingItemDetail
    /// </summary>
    private Guid tID_ID;
    private Guid tTT_TypeID;
    private string _bDOS_Code;

    public string BDOS_Code
    {
        get { return _bDOS_Code; }
        set { _bDOS_Code = value; }
    }
    private int tID_Month;
    private string tID_TLesson;
    private string tID_Target;
    private string tID_Place;
    private DateTime tID_PTime;
    private DateTime tID_ActTime;
    private string tID_Teacher;
    private decimal tID_CreditHours;
    private string tID_Maker;
    private DateTime tID_MTime;
    private string tID_State;
    private string tID_ResourceName;
    private string tID_ResourceRoute;
    private string tID_InputPer;
    private DateTime tID_InputTime;


    /// <summary>
    /// 各员工培训结果记录表:TrainingEachEmRecord
    /// </summary>
    private Guid tEER_ID;
    private Guid hRDD_ID;
    private string tEER_Result;
    private string tEER_Remark;

    public string TEER_Remark
    {
        get { return tEER_Remark; }
        set { tEER_Remark = value; }
    }

    public string TEER_Result
    {
        get { return tEER_Result; }
        set { tEER_Result = value; }
    }

    public Guid HRDD_ID
    {
        get { return hRDD_ID; }
        set { hRDD_ID = value; }
    }

    public Guid TEER_ID
    {
        get { return tEER_ID; }
        set { tEER_ID = value; }
    }


    public DateTime TID_InputTime
    {
        get { return tID_InputTime; }
        set { tID_InputTime = value; }
    }

    public string TID_InputPer
    {
        get { return tID_InputPer; }
        set { tID_InputPer = value; }
    }

    public string TID_ResourceRoute
    {
        get { return tID_ResourceRoute; }
        set { tID_ResourceRoute = value; }
    }

    public string TID_ResourceName
    {
        get { return tID_ResourceName; }
        set { tID_ResourceName = value; }
    }

    public string TID_State
    {
        get { return tID_State; }
        set { tID_State = value; }
    }

    public DateTime TID_MTime
    {
        get { return tID_MTime; }
        set { tID_MTime = value; }
    }

    public string TID_Maker
    {
        get { return tID_Maker; }
        set { tID_Maker = value; }
    }

    public decimal TID_CreditHours
    {
        get { return tID_CreditHours; }
        set { tID_CreditHours = value; }
    }

    public string TID_Teacher
    {
        get { return tID_Teacher; }
        set { tID_Teacher = value; }
    }

    public DateTime TID_ActTime
    {
        get { return tID_ActTime; }
        set { tID_ActTime = value; }
    }

    public DateTime TID_PTime
    {
        get { return tID_PTime; }
        set { tID_PTime = value; }
    }

    public string TID_Place
    {
        get { return tID_Place; }
        set { tID_Place = value; }
    }

    public string TID_Target
    {
        get { return tID_Target; }
        set { tID_Target = value; }
    }

    public string TID_TLesson
    {
        get { return tID_TLesson; }
        set { tID_TLesson = value; }
    }

    public int TID_Month
    {
        get { return tID_Month; }
        set { tID_Month = value; }
    }

    public Guid TTT_TypeID
    {
        get { return tTT_TypeID; }
        set { tTT_TypeID = value; }
    }

    public Guid TID_ID
    {
        get { return tID_ID; }
        set { tID_ID = value; }
    }


    public DateTime TYPM_Time
    {
        get { return tYPM_Time; }
        set { tYPM_Time = value; }
    }


    public string TYPM_State
    {
        get { return tYPM_State; }
        set { tYPM_State = value; }
    }
    

    public string TYPM_Maker
    {
        get { return tYPM_Maker; }
        set { tYPM_Maker = value; }
    }


    public int TYPM_Year
    {
        get { return tYPM_Year; }
        set { tYPM_Year = value; }
    }


    public Guid TYPM_ID
    {
        get { return tYPM_ID; }
        set { tYPM_ID = value; }
    }





















	public TrainningInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
}