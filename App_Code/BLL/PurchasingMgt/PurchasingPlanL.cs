using System;
using System.Data;

/// <summary>
///PurchasingPlanL 的摘要说明
/// </summary>
public class PurchasingPlanL
{
    private static readonly IPurchasingPlan pp = DALFactory.PurchasingPlan();
    public PurchasingPlanL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet Select_PlanMain(string condition)
    {
        return pp.Select_PlanMain(condition);
    }
    public void Delete_PlanMain(Guid id)
    {
        pp.Delete_PlanMain(id);
    }
    public void Insert_PlanMain(int year, int month, string man)
    {
        pp.Insert_PlanMain(year, month, man);
    }
    public void Update_PlanMain_Check(Guid id, string result, string opinion)
    {
        pp.Update_PlanMain_Check(id, result, opinion);
    }
    public DataSet Select_PlanDetail(Guid id)
    {
        return pp.Select_PlanDetail(id);
    }
    public void Insert_ShouhouSort(Guid id, decimal num)
    {
        pp.Insert_ShouhouSort(id, num);
    }
    public void Update_PlanMain_Tijiao(Guid id)
    {
        pp.Update_PlanMain_Tijiao(id);
    }
    public void Update_PlanDetail_Edit(Guid id, string remark, string request)
    {
        pp.Update_PlanDetail_Edit(id, remark, request);
    }
    public DataSet Select_MatPlan_Original(string condition)
    {
        return pp.Select_MatPlan_Original(condition);
    }
    public DataSet Select_MatPlan_Add(string condition)
    {
        return pp.Select_MatPlan_Add(condition);
    }
    public DataSet Select_MatPlan_Week(string condition)
    {
        return pp.Select_MatPlan_Week(condition);
    }
    public void Insert_DetailPlan_Mat(Guid id, Guid Mid, decimal num, string request)
    {
        pp.Insert_DetailPlan_Mat(id, Mid, num, request);
    }
    public void Insert_PurchaseOrder(Guid Pid, Guid SIid, string way, int paytime, DateTime arrtime, DateTime remindtime, string man)
    {
        pp.Insert_PurchaseOrder(Pid, SIid, way, paytime, arrtime, remindtime, man);
    }
    public void Insert_Material_MonthPlan(Guid orderID, Guid pdID, Guid Mid, decimal num)
    {
        pp.Insert_Material_MonthPlan(orderID, pdID, Mid, num);
    }
    public void Insert_Material_WeekPlan(Guid orderID, Guid wID, Guid Mid, decimal num)
    {
        pp.Insert_Material_WeekPlan(orderID, wID, Mid, num);
    }
    public void Update_PurchaseOrder(Guid id, Guid sid, string way, int paytime, DateTime arrtime, DateTime remindtime)
    {
        pp.Update_PurchaseOrder(id, sid, way, paytime, arrtime, remindtime);
    }
    public void Update_PurchaseOrder_Detail(Guid id, decimal num, decimal price, string remark, string request)
    {
        pp.Update_PurchaseOrder_Detail(id, num, price, remark, request);
    }
    public DataSet Select_Supply(string condition)
    {
        return pp.Select_Supply(condition);
    }
    public void Delete_Plan_Detail(Guid id)
    {
        pp.Delete_Plan_Detail(id);
    }
    public DataSet Select_Order_Detail(Guid id)
    {
        return pp.Select_Order_Detail(id);
    }
    public DataSet Select_Order_Main(string condition)
    {
        return pp.Select_Order_Main(condition);
    }
    public void Delete_Order_Detail(Guid id)
    {
        pp.Delete_Order_Detail(id);
    }
    public void Delete_Order(Guid id)
    {
        pp.Delete_Order(id);
    }
    public void Update_Order_Tijiao(Guid id)
    {
        pp.Update_Order_Tijiao(id);
    }
    public DataSet SelectIMMaterial_Price_PurchasePlan(string condition)
    {
        return pp.SelectIMMaterial_Price_PurchasePlan(condition);
    }
    public void UpdatePMPMaterial_Price(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
    {
        pp.UpdatePMPMaterial_Price(pMPurchaseingApplyRuleinfo);
    }
}