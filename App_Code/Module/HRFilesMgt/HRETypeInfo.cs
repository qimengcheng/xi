using System;

/// <summary>
///HRETypeInfo 的摘要说明
/// </summary>
public class HRETypeInfo
{
	public HRETypeInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private Guid hRET_ID;
    private string hRET_EmpType;
    private bool hRET_IsDeleted;

    
    
    public Guid HRET_ID
    {
        get { return hRET_ID; }
        set { hRET_ID = value; }
    }
    public string HRET_EmpType
    {
        get { return hRET_EmpType; }
        set { hRET_EmpType = value; }
    }
    public bool HRET_IsDeleted
    {
        get { return hRET_IsDeleted; }
        set { hRET_IsDeleted = value; }
    }
}