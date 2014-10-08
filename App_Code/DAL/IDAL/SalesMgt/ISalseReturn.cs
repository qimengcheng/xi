using System;
using System.Data;

/// <summary>
///ISalseDeliver 的摘要说明
/// </summary>
public interface ISalseReturn
{
    //public ISalseDeliver()
    //{
    //    //
    //    //TODO: 在此处添加构造函数逻辑
    //    //
    //}
    DataSet Select_Fahuodan(string condition);
    void Update_Fahuodan_Queren(Guid id);
    void Update_Fahuodan_Tuihuo(Guid id, string man, int num, string reason);
    void Update_Fahuodan_Huanhuo(Guid id, string man, int num, string reason);
    DataSet Select_Tuihuodan(string condition);
    void Update_Tuihuodan_Chuli(string result, string man, Guid id);
    void Delete_Tuihuodan(Guid id);
}