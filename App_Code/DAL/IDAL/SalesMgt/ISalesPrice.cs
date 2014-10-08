using System;
using System.Data;

/// <summary>
///ISalsePrice 的摘要说明
/// </summary>
public interface ISalsePrice
{
    DataSet Select_PT(string condition);
    void Delete_Apply(Guid id);
    DataSet Select_Apply(string condition);
    void Update_Apply(Guid id, decimal price, int day, string reason);
    void Insert_Apply(Guid id, decimal price, int day, string name, string reason);
    void Update_TousuSort(Guid cID, Guid pID, Decimal price, int day, string man);
    void Delete_JiageZhangqi(Guid id);
    DataSet Select_JiageZhangqi(string condition);
    void Update_Apply_Check(Guid id, string result, string op, string man);

}