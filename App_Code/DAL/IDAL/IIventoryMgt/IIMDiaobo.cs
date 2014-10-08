using System;
using System.Data;

/// <summary>
///IIMDiaobo 的摘要说明
/// </summary>
public interface IIMDiaobo
{
    DataSet Select_Allot(string condition);
    DataSet Select_IMStoreALL();
    void Insert_Allot(Guid outID, Guid inID, string man);
    void Update_Allot(Guid ID);
    void Update_AllotDetail(Guid AllotID, decimal num,Guid Aid);
    DataSet Select_AllotDetail(Guid id);
    DataSet Select_AllotDetail_Count(Guid id);
    void Update_Allot_Yichang(Guid AllotID, string man, string result);
     void Insert_AllotDetail(Guid AllotID, Guid imID, decimal num);
     DataSet Select_Area(Guid id);
     DataSet Select_IMIM_Pubian(string condition);
     void Update_Allot_IMID(Guid AllotID);
}