using System;


/// <summary>
///EM_Equip 的摘要说明
/// </summary>
public class PMPAudit
{
    private String PMP_MFDepSignSuggestion;

    public String PMP_MFDepSignSuggestion1
    {
        get { return PMP_MFDepSignSuggestion; }
        set { PMP_MFDepSignSuggestion = value; }
    }
    private String PMP_MFDepSignMan;

    public String PMP_MFDepSignMan1
    {
        get { return PMP_MFDepSignMan; }
        set { PMP_MFDepSignMan = value; }
    }
    private String PMP_MFDepSignResult;

    public String PMP_MFDepSignResult1
    {
        get { return PMP_MFDepSignResult; }
        set { PMP_MFDepSignResult = value; }
    }
    private String PMP_MBossSignSuggestion;

    public String PMP_MBossSignSuggestion1
    {
        get { return PMP_MBossSignSuggestion; }
        set { PMP_MBossSignSuggestion = value; }
    }
    private String PMP_MBossSignMan;

    public String PMP_MBossSignMan1
    {
        get { return PMP_MBossSignMan; }
        set { PMP_MBossSignMan = value; }
    }
    private String PMP_MBossSignResult;

    public String PMP_MBossSignResult1
    {
        get { return PMP_MBossSignResult; }
        set { PMP_MBossSignResult = value; }
    }
    private String PMP_MPDepSignSuggestion;

    public String PMP_MPDepSignSuggestion1
    {
        get { return PMP_MPDepSignSuggestion; }
        set { PMP_MPDepSignSuggestion = value; }
    }
    private String PMP_MPDepSignMan;

    public String PMP_MPDepSignMan1
    {
        get { return PMP_MPDepSignMan; }
        set { PMP_MPDepSignMan = value; }
    }
    private String PMP_MPDepSignResult;

    public String PMP_MPDepSignResult1
    {
        get { return PMP_MPDepSignResult; }
        set { PMP_MPDepSignResult = value; }
    }
    private String PMP_MFDepSignTime;

    public String PMP_MFDepSignTime1
    {
        get { return PMP_MFDepSignTime; }
        set { PMP_MFDepSignTime = value; }
    }
    private String PMP_MBossSignTime;

    public String PMP_MBossSignTime1
    {
        get { return PMP_MBossSignTime; }
        set { PMP_MBossSignTime = value; }
    }
    private String PMP_MPDepSignTime;

    public String PMP_MPDepSignTime1
    {
        get { return PMP_MPDepSignTime; }
        set { PMP_MPDepSignTime = value; }
    }
    public PMPAudit getAudit()
    {
        PMPAudit au = new PMPAudit();
        au.PMP_MBossSignMan1 = PMP_MBossSignMan1;
        au.PMP_MBossSignResult1 = PMP_MBossSignResult1;
        au.PMP_MBossSignSuggestion1 = PMP_MBossSignSuggestion1;
        au.PMP_MBossSignTime1 = PMP_MBossSignTime1;
        au.PMP_MFDepSignMan1 = PMP_MFDepSignMan1;
        au.PMP_MFDepSignResult1 = PMP_MFDepSignResult1;
        au.PMP_MFDepSignSuggestion1 = PMP_MFDepSignSuggestion1;
        au.PMP_MFDepSignTime1 = PMP_MFDepSignTime1;
        au.PMP_MPDepSignMan1 = PMP_MPDepSignMan1;
        au.PMP_MPDepSignResult1 = PMP_MPDepSignResult1;
        au.PMP_MPDepSignSuggestion1 = PMP_MPDepSignSuggestion1;
        au.PMP_MPDepSignTime1 = PMP_MPDepSignTime1;
        return au;
    }
    public void setAudit(String _PMP_MFDepSignSuggestion, String _PMP_MFDepSignMan, String _PMP_MFDepSignResult,
    String _PMP_MBossSignSuggestion,
    String _PMP_MBossSignMan,
    String _PMP_MBossSignResult,
    String _PMP_MPDepSignSuggestion,
    String _PMP_MPDepSignMan,
    String _PMP_MPDepSignResult,
    String _PMP_MFDepSignTime,
    String _PMP_MBossSignTime,
    String _PMP_MPDepSignTime)
    {
      
        PMP_MBossSignMan1 = _PMP_MBossSignMan;
        PMP_MBossSignResult1 = _PMP_MBossSignResult;
        PMP_MBossSignSuggestion1 = _PMP_MBossSignSuggestion;
        PMP_MBossSignTime1 = _PMP_MBossSignTime;
        PMP_MFDepSignMan1 = _PMP_MFDepSignMan;
        PMP_MFDepSignResult1 = _PMP_MFDepSignResult;
        PMP_MFDepSignSuggestion1 = _PMP_MFDepSignSuggestion;
        PMP_MFDepSignTime1 = _PMP_MFDepSignTime;
        PMP_MPDepSignMan1 = _PMP_MPDepSignMan;
        PMP_MPDepSignResult1 = _PMP_MPDepSignResult;
        PMP_MPDepSignSuggestion1 = _PMP_MPDepSignSuggestion;
        PMP_MPDepSignTime1 = _PMP_MPDepSignTime;
    }

}

