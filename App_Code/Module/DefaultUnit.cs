using System;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class DefaultUnit
{
    Guid defaultid;

    public Guid Defaultid
    {
        get { return defaultid; }
        set { defaultid = value; }
    }
    string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
	public DefaultUnit()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
}