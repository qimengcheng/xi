using System;
using System.Data;


/// <summary>
///ISMOrderDeliverPlan 的摘要说明
/// </summary>
public interface ISMOrderDeliverPlan
{
    DataSet Select_DeliverPlan_Order(string condition);
    DataSet Select_DeliverPlan(string condition);
    void Insert_DeliverPlan(Guid ID, DateTime time);
    void Update_DeliverPlan(Guid ID, decimal num);
    void Delete_DeliverPlan(Guid ID);
    void Insert_Apply(Guid ID, string man, string opinion);
    DataSet Select_SepcialApply(string condition);
    void Delete_Apply(Guid ID);
    void Update_Apply_Check(Guid ID, string result, string opinion, string man);
}