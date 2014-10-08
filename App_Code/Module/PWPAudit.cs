using System;


/// <summary>
///EM_Equip 的摘要说明
/// </summary>
public class PWPAudit
{
    private String PWP_MFDepSignSuggestion;

    public String PWP_MFDepSignSuggestion1
    {
        get { return PWP_MFDepSignSuggestion; }
        set { PWP_MFDepSignSuggestion = value; }
    }
    private String PWP_MFDepSignMan;

    public String PWP_MFDepSignMan1
    {
        get { return PWP_MFDepSignMan; }
        set { PWP_MFDepSignMan = value; }
    }
    private String PWP_MFDepSignResult;

    public String PWP_MFDepSignResult1
    {
        get { return PWP_MFDepSignResult; }
        set { PWP_MFDepSignResult = value; }
    }
    private String PWP_MBossSignSuggestion;

    public String PWP_MBossSignSuggestion1
    {
        get { return PWP_MBossSignSuggestion; }
        set { PWP_MBossSignSuggestion = value; }
    }
    private String PWP_MBossSignMan;

    public String PWP_MBossSignMan1
    {
        get { return PWP_MBossSignMan; }
        set { PWP_MBossSignMan = value; }
    }
    private String PWP_MBossSignResult;

    public String PWP_MBossSignResult1
    {
        get { return PWP_MBossSignResult; }
        set { PWP_MBossSignResult = value; }
    }
    private String PWP_MPDepSignSuggestion;

    public String PWP_MPDepSignSuggestion1
    {
        get { return PWP_MPDepSignSuggestion; }
        set { PWP_MPDepSignSuggestion = value; }
    }
    private String PWP_MPDepSignMan;

    public String PWP_MPDepSignMan1
    {
        get { return PWP_MPDepSignMan; }
        set { PWP_MPDepSignMan = value; }
    }
    private String PWP_MPDepSignResult;

    public String PWP_MPDepSignResult1
    {
        get { return PWP_MPDepSignResult; }
        set { PWP_MPDepSignResult = value; }
    }
    private String PWP_MFDepSignTime;

    public String PWP_MFDepSignTime1
    {
        get { return PWP_MFDepSignTime; }
        set { PWP_MFDepSignTime = value; }
    }
    private String PWP_MBossSignTime;

    public String PWP_MBossSignTime1
    {
        get { return PWP_MBossSignTime; }
        set { PWP_MBossSignTime = value; }
    }
    private String PWP_MPDepSignTime;

    public String PWP_MPDepSignTime1
    {
        get { return PWP_MPDepSignTime; }
        set { PWP_MPDepSignTime = value; }
    }
    public PWPAudit getAudit()
    {
        PWPAudit au = new PWPAudit();
        au.PWP_MBossSignMan1 = PWP_MBossSignMan1;
        au.PWP_MBossSignResult1 = PWP_MBossSignResult1;
        au.PWP_MBossSignSuggestion1 = PWP_MBossSignSuggestion1;
        au.PWP_MBossSignTime1 = PWP_MBossSignTime1;
        au.PWP_MFDepSignMan1 = PWP_MFDepSignMan1;
        au.PWP_MFDepSignResult1 = PWP_MFDepSignResult1;
        au.PWP_MFDepSignSuggestion1 = PWP_MFDepSignSuggestion1;
        au.PWP_MFDepSignTime1 = PWP_MFDepSignTime1;
        au.PWP_MPDepSignMan1 = PWP_MPDepSignMan1;
        au.PWP_MPDepSignResult1 = PWP_MPDepSignResult1;
        au.PWP_MPDepSignSuggestion1 = PWP_MPDepSignSuggestion1;
        au.PWP_MPDepSignTime1 = PWP_MPDepSignTime1;
        return au;
    }
    public void setAudit(String _PWP_MFDepSignSuggestion, String _PWP_MFDepSignMan, String _PWP_MFDepSignResult,
    String _PWP_MBossSignSuggestion,
    String _PWP_MBossSignMan,
    String _PWP_MBossSignResult,
    String _PWP_MPDepSignSuggestion,
    String _PWP_MPDepSignMan,
    String _PWP_MPDepSignResult,
    String _PWP_MFDepSignTime,
    String _PWP_MBossSignTime,
    String _PWP_MPDepSignTime)
    {
      
        PWP_MBossSignMan1 = _PWP_MBossSignMan;
        PWP_MBossSignResult1 = _PWP_MBossSignResult;
        PWP_MBossSignSuggestion1 = _PWP_MBossSignSuggestion;
        PWP_MBossSignTime1 = _PWP_MBossSignTime;
        PWP_MFDepSignMan1 = _PWP_MFDepSignMan;
        PWP_MFDepSignResult1 = _PWP_MFDepSignResult;
        PWP_MFDepSignSuggestion1 = _PWP_MFDepSignSuggestion;
        PWP_MFDepSignTime1 = _PWP_MFDepSignTime;
        PWP_MPDepSignMan1 = _PWP_MPDepSignMan;
        PWP_MPDepSignResult1 = _PWP_MPDepSignResult;
        PWP_MPDepSignSuggestion1 = _PWP_MPDepSignSuggestion;
        PWP_MPDepSignTime1 = _PWP_MPDepSignTime;
    }

}

