using System;
using System.Data;

/// <summary>
///SMOrderDeliverPlanL 的摘要说明
/// </summary>
public class SMOrderDeliverPlanL
{
    private static readonly ISMOrderDeliverPlan dp = DALFactory.OrderDeliverPlan();
    public SMOrderDeliverPlanL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet Select_DeliverPlan_Order(string condition)
    {
        return dp.Select_DeliverPlan_Order(condition);
    }
    public DataSet Select_DeliverPlan(string condition)
    {
        return dp.Select_DeliverPlan(condition);
    }
    public void Insert_DeliverPlan(Guid ID, DateTime time)
    {
        dp.Insert_DeliverPlan(ID, time);
    }
    public void Update_DeliverPlan(Guid ID, decimal num)
    {
        dp.Update_DeliverPlan(ID, num);
    }
    public void Delete_DeliverPlan(Guid ID)
    {
        dp.Delete_DeliverPlan(ID);
    }
    public void Insert_Apply(Guid ID, string man, string opinion)
    {
        dp.Insert_Apply(ID, man, opinion);
    }
    public DataSet Select_SepcialApply(string condition)
    {
        return dp.Select_SepcialApply(condition);
    }
    public void Delete_Apply(Guid ID)
    {
        dp.Delete_Apply(ID);
    }
    public void Update_Apply_Check(Guid ID, string result, string opinion, string man)
    {
        dp.Update_Apply_Check(ID, result, opinion, man);
    }
}