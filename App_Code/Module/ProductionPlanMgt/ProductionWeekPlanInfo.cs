using System;

/// <summary>
///ProductionWeekPlanInfo 的摘要说明
/// </summary>
public class ProductionWeekPlanInfo
{
    private Guid pWP_ID;

    public Guid PWP_ID
    {
        get { return pWP_ID; }
        set { pWP_ID = value; }
    }
    private Guid sMSWPM_ID;

    public Guid SMSWPM_ID
    {
        get { return sMSWPM_ID; }
        set { sMSWPM_ID = value; }
    }
    private Int16 pWP_Year;
    public Guid PWPCID { get; set; }  
    public Int16 PWP_Year
    {
        get { return pWP_Year; }
        set { pWP_Year = value; }
    }
    private Int16 pWP_Month;

    public Int16 PWP_Month
    {
        get { return pWP_Month; }
        set { pWP_Month = value; }
    }
    private DateTime pWP_STime;

    public DateTime PWP_STime
    {
        get { return pWP_STime; }
        set { pWP_STime = value; }
    }
    private DateTime pWP_ETime;

    public DateTime PWP_ETime
    {
        get { return pWP_ETime; }
        set { pWP_ETime = value; }
    }
    private string pWP_Man;

    public string PWP_Man
    {
        get { return pWP_Man; }
        set { pWP_Man = value; }
    }

    private string pWP_RMan;

    public string PWP_RMan
    {
        get { return pWP_RMan; }
        set { pWP_RMan = value; }
    }
    private string pWP_Suggstion;

    public string PWP_Suggstion
    {
        get { return pWP_Suggstion; }
        set { pWP_Suggstion = value; }
    }
    private string pWP_State;

    public string PWP_State
    {
        get { return pWP_State; }
        set { pWP_State = value; }
    }

    public int Linenum { get; set; }


    public ProductionWeekPlanInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public ProductionWeekPlanInfo(Guid _pWP_ID, Guid _sMSWPM_ID, Int16 _pWP_Year,
        Int16 _pWP_Month, DateTime _pWP_STime, DateTime _PWP_ETime, string _pWP_Man, 
        string _pWP_RMan, string _pWP_Suggstion, string _pWP_State)
    {
        pWP_ID = _pWP_ID;
        sMSWPM_ID = _sMSWPM_ID;
        pWP_Year = _pWP_Year;
        pWP_Month = _pWP_Month;
        pWP_STime = _pWP_STime;
        pWP_Man = _pWP_Man;
        pWP_RMan = _pWP_RMan;
        pWP_Suggstion = _pWP_Suggstion;
        pWP_State = _pWP_State;
    }


}