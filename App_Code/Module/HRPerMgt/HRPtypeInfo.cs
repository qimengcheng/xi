using System;

/// <summary>
///HRPAtypeinfo 的摘要说明
/// </summary>
public class HRPtypeInfo
{
	public HRPtypeInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private Guid hRPAT_ID;
    private string hRPAT_PType;
    private string hRPAT_APerson;
    private string hRPAT_CPerson;
    private bool hRPAT_IsDeleted;
    private string hRPAT_M_State;

    public Guid HRPAT_ID
    {
        get { return hRPAT_ID; }
        set { hRPAT_ID = value; }
    }
    public string HRPAT_PType
    {
        get { return hRPAT_PType; }
        set { hRPAT_PType = value; }
    }
    public string HRPAT_APerson
    {
        get { return hRPAT_APerson; }
        set { hRPAT_APerson = value; }
    }
    public string HRPAT_CPerson
    {
        get { return hRPAT_CPerson; }
        set { hRPAT_CPerson = value; }
    }
    public bool HRPAT_IsDeleted
    {
        get { return hRPAT_IsDeleted; }
        set { hRPAT_IsDeleted = value; }
    }
    public string HRPAT_M_State
    {
        get { return hRPAT_M_State; }
        set { hRPAT_M_State = value; }
    }
    public HRPtypeInfo(string _hRPAT_PType, string _hRPAT_APerson, string _hRPAT_CPerson,string _hRPAT_M_State)
    {
        hRPAT_PType = _hRPAT_PType;
        hRPAT_APerson = _hRPAT_APerson;
        hRPAT_CPerson = _hRPAT_CPerson;
        hRPAT_M_State = _hRPAT_M_State;
    }
}