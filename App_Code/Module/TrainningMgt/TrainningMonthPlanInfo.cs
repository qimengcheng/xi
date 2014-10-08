using System;

/// <summary>
///TrainningMonthPlanInfo 的摘要说明
/// </summary>
public class TrainningMonthPlanInfo
{

    //培训年度计划主表
    private Guid tYPM_ID;
    private int tYPM_Year;
    private string tYPM_State;

    //培训类型表
    private Guid _tTT_TypeID;
    private string _TTT_Type;

    public string TTT_Type
    {
        get { return _TTT_Type; }
        set { _TTT_Type = value; }
    }
    public Guid TTT_TypeID1
    {
        get { return _tTT_TypeID; }
        set { _tTT_TypeID = value; }
    }


    //培训项目明细表
    private Guid tID_ID;
    private Guid tTT_TypeID;
    //private Guid tYPM_ID;与上表重复
    private string bDOS_Code;
    private string uMUI_UserID;
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
    private DateTime tID_InputTime;
    private string tID_IsCha;


    //各员工培训结果记录表
    private Guid tEER_ID;
    private Guid hRDD_ID;
    //private Guid tID_ID;与上表重复
    private string tEER_Result;
    private string tEER_Remark;


    //其他表
    private string _BDOS_Name;
    private string _UMUI_UserName;

    //特殊字段（非数据库字段，作用：用于接收时间格式和小数格式的字段(其可能为null)，让其是null时显示为“”）
    private string recordTID_PTime;
    private string recordTID_ActTime;
    private string recordTID_MTime;
    private string recordTID_InputTime;
    private string recordTID_CreditHours;
    private string recordTYPM_Year;
    private string recordTID_Month;

    public string RecordTID_Month
    {
        get { return recordTID_Month; }
        set { recordTID_Month = value; }
    }

    public string RecordTYPM_Year
    {
        get { return recordTYPM_Year; }
        set { recordTYPM_Year = value; }
    }

    public string RecordTID_MTime
    {
        get { return recordTID_MTime; }
        set { recordTID_MTime = value; }
    }
    

    public string RecordTID_CreditHours
    {
        get { return recordTID_CreditHours; }
        set { recordTID_CreditHours = value; }
    }

    public string RecordTID_InputTime
    {
        get { return recordTID_InputTime; }
        set { recordTID_InputTime = value; }
    }


    public string RecordTID_ActTime
    {
        get { return recordTID_ActTime; }
        set { recordTID_ActTime = value; }
    }


    public string RecordTID_PTime
    {
        get { return recordTID_PTime; }
        set { recordTID_PTime = value; }
    }

    public string UMUI_UserName
    {
        get { return _UMUI_UserName; }
        set { _UMUI_UserName = value; }
    }
    public string BDOS_Name
    {
        get { return _BDOS_Name; }
        set { _BDOS_Name = value; }
    }

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

    public string TID_IsCha
    {
        get { return tID_IsCha; }
        set { tID_IsCha = value; }
    }

    public DateTime TID_InputTime
    {
        get { return tID_InputTime; }
        set { tID_InputTime = value; }
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

    public string UMUI_UserID
    {
        get { return uMUI_UserID; }
        set { uMUI_UserID = value; }
    }

    public string BDOS_Code
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
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

    public string TYPM_State
    {
        get { return tYPM_State; }
        set { tYPM_State = value; }
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
    public TrainningMonthPlanInfo()
    { }

    public TrainningMonthPlanInfo(string TYPM_Year, string TID_Month, string TTT_Type, string TID_TLesson, string TID_Target, string TID_Place, string TID_CreditHours,
        string TID_Teacher, string TID_PTime, string BDOS_Name, string UMUI_UserName, string UMUI_UserID)
	{
        recordTYPM_Year = TYPM_Year;
        recordTID_Month = TID_Month;
        _TTT_Type = TTT_Type;
        tID_TLesson = TID_TLesson;
        tID_Target = TID_Target;
        tID_Place = TID_Place;
        recordTID_CreditHours = TID_CreditHours;
        tID_Teacher = TID_Teacher;
        recordTID_PTime = TID_PTime;
        _BDOS_Name = BDOS_Name;
        _UMUI_UserName = UMUI_UserName;
        uMUI_UserID = UMUI_UserID;
        
	}
}