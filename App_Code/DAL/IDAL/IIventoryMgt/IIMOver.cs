using System;
using System.Data;

/// <summary>
///IIMOver 的摘要说明
/// </summary>
public interface IIMOver
{
    DataSet Select_Kucun(string condition);
    void Insert_Apply(Guid ID, string man, string reason);
    DataSet Select_Kufang_DropdownList(string department, string man);
    DataSet Select_Apply(string condition);
    void Update_Apply(Guid ID, string result, string man);
    void Update_Apply_Check(Guid ID, string result, string man, string opinion);
    void Update_Apply_Zhixing(Guid ID);
}