using System;
using System.Data;

/// <summary>
///SalesMonthPlanL 的摘要说明
/// </summary>
public class SalesMonthPlanL
{
    private static readonly ISalesMonthPlan mp=DALFactory.MonthPlan();
	public SalesMonthPlanL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    //默认绑定销售月计划表
    public DataSet Select_SalesMonthPlan_Bindgridview()
    {
        return mp.Select_SalesMonthPlan_Bindgridview();
    }
    public DataSet Select_SalesMonthPlan(string condition)
    {
        return mp.Select_SalesMonthPlan(condition);
    }
    public int Insert_SalesMonthPlan(int year, int month, string man, DateTime start, DateTime end)
    {
         return mp.Insert_SalesMonthPlan(year, month, man, start, end);
    }
    public DataSet Select_MonthPlanDetail_FromGridview(Guid MonthPlanID)
    {
       return mp.Select_MonthPlanDetail_FromGridview(MonthPlanID);
    }
    public DataSet Select_MonthPlanDetail_FromGridview_Add(Guid MonthPlanID)
    {
        return mp.Select_MonthPlanDetail_FromGridview_Add(MonthPlanID);
    }
    public void Update_SMSalesMonthPlanMain_CheckOK(Guid MonthPlanID, string CheckMan, string CheckOpinion)
    {
         mp.Update_SMSalesMonthPlanMain_CheckOK(MonthPlanID, CheckMan, CheckOpinion);
    }
    public void Update_SMSalesMonthPlanMain_SingOK(Guid MonthPlanID, string CheckMan, string CheckOpinion, string Department)
    {
        mp.Update_SMSalesMonthPlanMain_SingOK(MonthPlanID, CheckMan, CheckOpinion, Department);
    }
    public DataSet Select_SMSalesMonthPlanMain_BindSign(Guid MonthPlanID)
    {
        return mp.Select_SMSalesMonthPlanMain_BindSign(MonthPlanID);
    }
    public void Update_SMSalesMonthPlanMain_CheckNotOK(Guid MonthPlanID, string CheckMan, string CheckOpinion)
    {
        mp.Update_SMSalesMonthPlanMain_CheckNotOK(MonthPlanID, CheckMan, CheckOpinion);
    }
    public void Update_SMSalesMonthPlanMain_SingNotOK(Guid MonthPlanID, string CheckMan, string CheckOpinion, string Department)
    {
        mp.Update_SMSalesMonthPlanMain_SingNotOK(MonthPlanID, CheckMan, CheckOpinion, Department);
    }
    public DataSet Select_ProType(string condition)
    {
        return mp.Select_ProType(condition);
    }
    public void Insert_ProType_MonthPlanDetail(Guid MonthPlanID, Guid PT_ID,string grid)
    {
        mp.Insert_ProType_MonthPlanDetail(MonthPlanID, PT_ID,grid);
    }
    public DataSet Select_CheckMonthPlanDetail(Guid MonthPlanID, Guid PT_ID)
    {
        return mp.Select_CheckMonthPlanDetail(MonthPlanID, PT_ID);
    }
    public void Update_MonthPlanDetail_Main(Guid MonthPlanMainID, Guid MonthPlanDetailID, decimal amount, decimal first, decimal second, decimal third, decimal forth, string request, string remark, string way)
    {
         mp.Update_MonthPlanDetail_Main(MonthPlanMainID, MonthPlanDetailID, amount, first, second, third, forth, request, remark,way);
    }
    public void Delete_MonthPlanDetail(Guid DetailID)
    {
        mp.Delete_MonthPlanDetail(DetailID);
    }
    public void Delete_MonthPlanMain(Guid MainID)
    {
        mp.Delete_MonthPlanMain(MainID);
    }
     public void Update_MonthPlanDetail_ADD(Guid DetailID,decimal amount,string  request,string man,string remark, string way)
     {
          mp.Update_MonthPlanDetail_ADD(DetailID,amount,request,man,remark,way);
     }
     public void Update_MonthPlanDetail_ADD_Check(Guid DetailID, string opinion, string man,string key)
     {
         mp.Update_MonthPlanDetail_ADD_Check(DetailID, opinion, man,key);
     }
     public void Insert_MonthPlanDetail_Auto(Guid mainID)
     {
         mp.Insert_MonthPlanDetail_Auto(mainID);
     }
     public DataSet SelectMonthPlanMainID(int year, int month)
     {
        return  mp.SelectMonthPlanMainID(year, month);
     }

   //   //从表格点击查询物料
   // public  DataSet Select_MaterialBasicDataForGridview(Guid MaterialTypeID)
   // {
   //     return mat.Select_MaterialBasicDataForGridview(MaterialTypeID);
   // }
   // //修改物料类型
   //public  void Update_MaterialType(Guid MaterialTypeID, string MaterialTypeName, string Statement)
   // {
   //      mat.Update_MaterialType(MaterialTypeID, MaterialTypeName, Statement);
   // }

}