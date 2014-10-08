using System;

/// <summary>
///ProductionPlanInfo 的摘要说明
/// </summary>
public class ProductionPlanInfo
{
    private Guid pMP_ID;
    public Guid PMP_ID
    {
        get { return pMP_ID; }
        set { pMP_ID = value; }
    }

    private Guid sMSMPM_ID;
    public Guid SMSMPM_ID
    {
        get { return sMSMPM_ID; }
        set { sMSMPM_ID = value; }
    }

    private Int16 pMP_Year;
    public Int16 PMP_Year
    {
        get { return pMP_Year; }
        set { pMP_Year = value; }
    }
    private Int16 pMP_Month;

    public Int16 PMP_Month
    {
        get { return pMP_Month; }
        set { pMP_Month = value; }
    }
    private DateTime pMP_STime;

    public DateTime PMP_STime
    {
        get { return pMP_STime; }
        set { pMP_STime = value; }
    }
    private DateTime pMP_ETime;

    public DateTime PMP_ETime
    {
        get { return pMP_ETime; }
        set { pMP_ETime = value; }
    }
    private string pMP_Man;

    public string PMP_Man
    {
        get { return pMP_Man; }
        set { pMP_Man = value; }
    }

    private string pMP_RMan;

    public string PMP_RMan
    {
        get { return pMP_RMan; }
        set { pMP_RMan = value; }
    }
    private string pMP_RSuggstion;

    public string PMP_RSuggstion
    {
        get { return pMP_RSuggstion; }
        set { pMP_RSuggstion = value; }
    }

    private string pMP_State;

    public string PMP_State
    {
        get { return pMP_State; }
        set { pMP_State = value; }
    }

    private string pMPD_ProdType;

    public string PMPD_ProdType
    {
        get { return pMPD_ProdType; }
        set { pMPD_ProdType = value; }
    }
    private string pMPD_PSName;

    public string PMPD_PSName
    {
        get { return pMPD_PSName; }
        set { pMPD_PSName = value; }
    }
    private int pMPD_MPNum;

    public int PMPD_MPNum
    {
        get { return pMPD_MPNum; }
        set { pMPD_MPNum = value; }
    }
    private string pPMPD_Note;

    public string PPMPD_Note
    {
        get { return pPMPD_Note; }
        set { pPMPD_Note = value; }
    }
    private int sMSMPD_PMPNum;

    public int SMSMPD_PMPNum
    {
        get { return sMSMPD_PMPNum; }
        set { sMSMPD_PMPNum = value; }
    }

    private string sMSMPD_PMPNote;

    public string SMSMPD_PMPNote
    {
        get { return sMSMPD_PMPNote; }
        set { sMSMPD_PMPNote = value; }
    }

    private Guid sMSMPD_ID;
    public Guid PMPC_ID;

    public Guid SMSMPD_ID
    {
        get { return sMSMPD_ID; }
        set { sMSMPD_ID = value; }
    }

    public int Proline { get; set; }

    // private Int16 sMSMPM_Year;
    // private Int16 sMSMPM_Month;
    // private string sMSMPM_MakeMan;



    public ProductionPlanInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public ProductionPlanInfo(Guid _sMSMPD_ID, int _sMSMPD_PMPNum, string _sMSMPD_PMPNote, string _pPMPD_Note, int _pMPD_MPNum, string _pMPD_PSName, string _pMPD_ProdType, string _pMP_State, Guid _pMP_ID, Guid _sMSMPM_ID, Int16 _pMP_Year, Int16 _pMP_Month, DateTime _pMP_STime, DateTime _pMP_ETime, string _pMP_Man, string _pMP_RMan, string _pMP_RSuggstion)
    {
        sMSMPD_ID = _sMSMPD_ID;
        sMSMPD_PMPNum = _sMSMPD_PMPNum;
        sMSMPD_PMPNote = _sMSMPD_PMPNote;
        pPMPD_Note = _pPMPD_Note;
        pMPD_MPNum = _pMPD_MPNum;
        pMPD_PSName = _pMPD_PSName;
        pMPD_ProdType = _pMPD_ProdType;
        pMP_State = _pMP_State;
        pMP_RMan = _pMP_RMan;
        pMP_RSuggstion = _pMP_RSuggstion;
        pMP_ID = _pMP_ID;
        sMSMPM_ID = _sMSMPM_ID;

        pMP_Year = _pMP_Year;
        pMP_Month = _pMP_Month;

        pMP_STime = _pMP_STime;
        pMP_ETime = _pMP_ETime;
        pMP_Man = _pMP_Man;
    }
}