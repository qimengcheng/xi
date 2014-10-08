using System;
using System.Data;

/// <summary>
///ISalsePayBill 的摘要说明
/// </summary>
public interface IPurchasingPlan
{
    DataSet Select_PlanMain(string condition);
    void Delete_PlanMain(Guid id);
    void Insert_PlanMain(int year, int month, string man);
    void Update_PlanMain_Check(Guid id, string result, string opinion);
    DataSet Select_PlanDetail(Guid id);
    void Insert_ShouhouSort(Guid id, decimal num);
    void Update_PlanMain_Tijiao(Guid id);
    void Update_PlanDetail_Edit(Guid id, string remark, string request);
    DataSet Select_MatPlan_Original(string condition);
    DataSet Select_MatPlan_Add(string condition);
    DataSet Select_MatPlan_Week(string condition);
    void Insert_DetailPlan_Mat(Guid id, Guid Mid, decimal num, string request);
    void Insert_PurchaseOrder(Guid Pid, Guid SIid, string way, int paytime, DateTime arrtime, DateTime remindtime, string man);
    void Insert_Material_MonthPlan(Guid orderID, Guid pdID, Guid Mid, decimal num);
    void Insert_Material_WeekPlan(Guid orderID, Guid wID, Guid Mid, decimal num);
    void Update_PurchaseOrder(Guid id, Guid sid, string way, int paytime, DateTime arrtime, DateTime remindtime);
    void Update_PurchaseOrder_Detail(Guid id, decimal num, decimal price, string remark, string request);
    DataSet Select_Supply(string condition);
    void Delete_Plan_Detail(Guid id);
    DataSet Select_Order_Detail(Guid id);
    DataSet Select_Order_Main(string condition);
    void Delete_Order_Detail(Guid id);
    void Delete_Order(Guid id);
    void Update_Order_Tijiao(Guid id);
    DataSet SelectIMMaterial_Price_PurchasePlan(string condition);
    void UpdatePMPMaterial_Price(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo);

}