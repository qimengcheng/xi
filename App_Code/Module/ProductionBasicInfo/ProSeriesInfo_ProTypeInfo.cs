using System;

/// <summary>
///ProSeriesInfo_ProTypeInfo 的摘要说明
/// </summary>
public class ProSeriesInfo_ProTypeInfo
{
    private Guid pS_ID;



    public Guid PS_ID
    {
        get { return pS_ID; }
        set { pS_ID = value; }
    }
    private string pS_Name;

    public string PS_Name
    {
        get { return pS_Name; }
        set { pS_Name = value; }
    }
    private Guid pT_ID;

    public Guid PT_ID
    {
        get { return pT_ID; }
        set { pT_ID = value; }
    }
    private Guid pR_ID;

    public Guid PR_ID
    {
        get { return pR_ID; }
        set { pR_ID = value; }
    }
    private Guid bOM_ID;

    public Guid BOM_ID
    {
        get { return bOM_ID; }
        set { bOM_ID = value; }
    }
    private string pT_Name;

    public string PT_Name
    {
        get { return pT_Name; }
        set { pT_Name = value; }
    }
    private string pT_SpecialNeed;

    public string PT_SpecialNeed
    {
        get { return pT_SpecialNeed; }
        set { pT_SpecialNeed = value; }
    }
    private string pT_Man;

    public string PT_Man
    {
        get { return pT_Man; }
        set { pT_Man = value; }
    }
    private DateTime pT_Time;
    private DateTime pT_T1;


    public DateTime PT_Time
    {
        get { return pT_Time; }
        set { pT_Time = value; }
    }
    private string pT_ReviewMan;

    public string PT_ReviewMan
    {
        get { return pT_ReviewMan; }
        set { pT_ReviewMan = value; }
    }
    private DateTime pT_ReviewTime;

    public DateTime PT_ReviewTime
    {
        get { return pT_ReviewTime; }
        set { pT_ReviewTime = value; }
    }
    private string pT_State;

    public string PT_State
    {
        get { return pT_State; }
        set { pT_State = value; }
    }
    private string pT_Note;

    public string PT_Note
    {
        get { return pT_Note; }
        set { pT_Note = value; }
    }
    private string pT_Special;

    public string PT_Special
    {
        get { return pT_Special; }
        set { pT_Special = value; }
    }
    private string pT_Parameters;

    public string PT_Parameters
    {
        get { return pT_Parameters; }
        set { pT_Parameters = value; }
    }

    private Guid pBC_ID;

    public Guid PBC_ID
    {
        get { return pBC_ID; }
        set { pBC_ID = value; }
    }
    private string pPP_Note;

    public string PPP_Note
    {
        get { return pPP_Note; }
        set { pPP_Note = value; }
    }

    private string pPP_Parameter;

    public string PPP_Parameter
    {
        get { return pPP_Parameter; }
        set { pPP_Parameter = value; }
    }

    private decimal pPP_PassRate;

    public decimal PPP_PassRate
    {
        get { return pPP_PassRate; }
        set { pPP_PassRate = value; }
    }

        public ProSeriesInfo_ProTypeInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public ProSeriesInfo_ProTypeInfo(Guid _pS_ID, string _pS_Name, string _pT_Name, string _pT_Special
        , Guid _bOM_ID, Guid _pR_ID, Guid _pBC_ID, string _pPP_Note, string _pPP_Parameter, decimal _pPP_PassRate,string _pT_Man)
    {
        pT_Man = _pT_Man;
        pS_ID= _pS_ID;
        pS_Name=_pS_Name;
        pT_Name=_pT_Name; 
        pT_Special=_pT_Special; 
        bOM_ID=_bOM_ID;  
        pR_ID=_pR_ID; 
        pBC_ID=_pBC_ID; 
        pPP_Note= _pPP_Note; 
        pPP_Parameter=_pPP_Parameter;
        pPP_PassRate = _pPP_PassRate;

    }
}