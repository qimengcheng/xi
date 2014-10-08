using System;
using System.Data;

/// <summary>
///ITypeTest 的摘要说明
/// </summary>
public interface ITypeTest
{
    void Insert_TypeTestMan(Int16 TTM_Year, Byte TTM_Month, string TTM_State, string TTM_Maker, DateTime TTM_Time);
    int Delete_TypeTestMan(Guid TTM_TypePlanID);
    void Update_TypeTestMan(Guid TTM_TypePlanID, Int16 TTM_Year, Byte TTM_Month, string TTM_Maker, DateTime TTM_Time);
    DataSet Search_TypeTestMan(string condition);
    DataSet Search_ProType_ProSeries(string condition);
    void Insert_TypeTestDetail(Guid PT_ID, Guid TTM_TypePlanID, string TTD_IsUploaded);
    int Delete_TypeTestDetail(Guid TTD_DetailID);
    DataSet Search_TypeTestDetail(string condition);
    void Update_TypeTestDetail(Guid TTD_DetailID, string TTD_IsUploaded, string TTD_ReportNO, string TTD_UpPer, DateTime TTD_UpTime, string TTD_RepRoute, string TTD_IsPass);
    void Update_TypeTestMan_done(Guid TTM_TypePlanID,string TTM_State);
    DataSet Search_TypeTestMan_TypeTestDetail(Guid TTM_TypePlanID);
    DataSet Search_TypeTestMan_TypeTestDetail_not(Guid TTM_TypePlanID);
    void Update_TypeTestDetail_company(Guid TTD_DetailID, string TTD_Company);
}