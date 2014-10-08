using System;
using System.Data;

/// <summary>
///TypeTestL 的摘要说明
/// </summary>
public class TypeTestL
{
    private static readonly ITypeTest equipm = DALFactory.CreateTypeTest();
	public TypeTestL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public void Insert_TypeTestMan(Int16 TTM_Year, Byte TTM_Month, string TTM_State, string TTM_Maker, DateTime TTM_Time)
    {
        equipm.Insert_TypeTestMan(TTM_Year, TTM_Month, TTM_State, TTM_Maker, TTM_Time);
    }
    public int Delete_TypeTestMan(Guid TTM_TypePlanID)
    {
        return equipm.Delete_TypeTestMan(TTM_TypePlanID);
    }
    public void Update_TypeTestMan(Guid TTM_TypePlanID, Int16 TTM_Year, Byte TTM_Month, string TTM_Maker, DateTime TTM_Time)
    {
        equipm.Update_TypeTestMan(TTM_TypePlanID, TTM_Year, TTM_Month, TTM_Maker, TTM_Time);
    }
    public DataSet Search_TypeTestMan(string condition)
    {
        return equipm.Search_TypeTestMan( condition);
    }
    public DataSet Search_ProType_ProSeries(string condition)
    {
        return equipm.Search_ProType_ProSeries( condition);
    }
    public void Insert_TypeTestDetail(Guid PT_ID, Guid TTM_TypePlanID, string TTD_IsUploaded)
    {
        equipm.Insert_TypeTestDetail(PT_ID, TTM_TypePlanID, TTD_IsUploaded);
    }
    public int Delete_TypeTestDetail(Guid TTD_DetailID)
    {
        return equipm.Delete_TypeTestDetail(TTD_DetailID);
    }
    public DataSet Search_TypeTestDetail(string condition)
    {
        return equipm.Search_TypeTestDetail(condition);
    }
    public void Update_TypeTestDetail(Guid TTD_DetailID, string TTD_IsUploaded, string TTD_ReportNO, string TTD_UpPer, DateTime TTD_UpTime, string TTD_RepRoute, string TTD_IsPass)
    {
        equipm.Update_TypeTestDetail(TTD_DetailID, TTD_IsUploaded, TTD_ReportNO, TTD_UpPer, TTD_UpTime, TTD_RepRoute, TTD_IsPass);
    }
    public void Update_TypeTestMan_done(Guid TTM_TypePlanID,string TTM_State)
    {
        equipm.Update_TypeTestMan_done(TTM_TypePlanID,TTM_State);
    }
    public DataSet Search_TypeTestMan_TypeTestDetail(Guid TTM_TypePlanID)
    {
        return equipm.Search_TypeTestMan_TypeTestDetail(TTM_TypePlanID);
    }
    public DataSet Search_TypeTestMan_TypeTestDetail_not(Guid TTM_TypePlanID)
    {
        return equipm.Search_TypeTestMan_TypeTestDetail_not(TTM_TypePlanID);
    }
    public void Update_TypeTestDetail_company(Guid TTD_DetailID, string TTD_Company)
    {
        equipm.Update_TypeTestDetail_company( TTD_DetailID, TTD_Company);
    }
}