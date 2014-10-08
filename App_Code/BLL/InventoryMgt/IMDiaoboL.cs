using System;
using System.Data;


/// <summary>
///IMDiaoboL 的摘要说明
/// </summary>
public class IMDiaoboL
{
    private static readonly IIMDiaobo db = DALFactory.Diaobo();
    public IMDiaoboL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet Select_Allot(string condition)
    {
        return db.Select_Allot(condition);
    }
    public DataSet Select_IMStoreALL()
    {
        return db.Select_IMStoreALL();
    }
    public void Insert_Allot(Guid outID, Guid inID, string man)
    {
        db.Insert_Allot(outID, inID, man);
    }
    public void Update_Allot(Guid ID)
    {
        db.Update_Allot(ID);
    }
    public void Update_AllotDetail(Guid AllotID, decimal num,Guid Aid)
    {
        db.Update_AllotDetail(AllotID, num,Aid);
    }
    public DataSet Select_AllotDetail(Guid id)
    {
        return db.Select_AllotDetail(id);
    }
    public DataSet Select_AllotDetail_Count(Guid id)
    {
        return db.Select_AllotDetail_Count(id);
    }
    public void Update_Allot_Yichang(Guid AllotID, string man, string result)
    {
        db.Update_Allot_Yichang(AllotID, man, result);
    }
    public void Insert_AllotDetail(Guid AllotID, Guid imID, decimal num)
    {
        db.Insert_AllotDetail(AllotID, imID, num);
    }
    public DataSet Select_Area(Guid id)
    {
        return db.Select_Area(id);
    }
    public DataSet Select_IMIM_Pubian(string condition)
    {
        return db.Select_IMIM_Pubian(condition);
    }
    public void Update_Allot_IMID(Guid AllotID)
    {
        db.Update_Allot_IMID(AllotID);
    }
}