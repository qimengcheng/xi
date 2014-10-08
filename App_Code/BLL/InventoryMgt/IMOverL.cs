using System;
using System.Data;

/// <summary>
///IMOverL 的摘要说明
/// </summary>
public class IMOverL
{
    private static readonly IIMOver over = DALFactory.IMOver();
    public IMOverL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet Select_Kucun(string condition)
    {
        return over.Select_Kucun(condition);
    }
    public void Insert_Apply(Guid ID, string man, string reason)
    {
        over.Insert_Apply(ID, man, reason);

    }
    public DataSet Select_Kufang_DropdownList(string department, string man)
    {
        return over.Select_Kufang_DropdownList(department, man);
    }
    public DataSet Select_Apply(string condition)
    {
        return over.Select_Apply(condition);
    }
    public void Update_Apply(Guid ID, string result, string man)
    {
        over.Update_Apply(ID, result, man);
    }
    public void Update_Apply_Check(Guid ID, string result, string man, string opinion)
    {
        over.Update_Apply_Check(ID, result, man, opinion);
    }
    public void Update_Apply_Zhixing(Guid ID)
    {
        over.Update_Apply_Zhixing(ID);
    }

}