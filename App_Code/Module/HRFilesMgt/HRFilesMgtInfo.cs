using System;

/// <summary>
///HRFilesMgtInfo 的摘要说明
/// </summary>
public class HRFilesMgtInfo
{
    public HRFilesMgtInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private Guid hRP_ID;
    private string bDOS_Code;
    private string hRP_Post;
    private string bDOS_Name;
    private bool hRP_IsDeleted;

    public Guid HRP_ID
    {
        get { return hRP_ID; }
        set { hRP_ID = value; }
    }


    public string BDOS_Code
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
    }
    

    public string HRP_Post
    {
        get { return hRP_Post; }
        set { hRP_Post = value; }
    }
    

    public string BDOS_Name
    {
        get { return bDOS_Name; }
        set { bDOS_Name = value; }
    }
    

    public bool HRP_IsDeleted
    {
        get { return hRP_IsDeleted; }
        set { hRP_IsDeleted = value; }
    }

    public HRFilesMgtInfo(string _bDOS_Name, string _bDOS_Code, string _hRP_Post)
    {
        bDOS_Name = _bDOS_Name;
        bDOS_Code = _bDOS_Code;
        hRP_Post = _hRP_Post;
    }
}