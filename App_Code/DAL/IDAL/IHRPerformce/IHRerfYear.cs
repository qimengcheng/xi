using System;
using System.Data;

/// <summary>
///IHRerfYear 的摘要说明
/// </summary>
public interface IHRerfYear
{
    int Insert_HRPerformceYear(HRPerformceYearInfo hr);
    DataSet Search_HRPerformceYear_State(Guid guid, String HRPAT_APerson);
    int Update_HRPerformceYear(HRPerformceYearInfo hr);
    DataSet Search_HRPerformceYear(string condition);
    int  Search_HRPerformceYear_CHECK_State(int year,int month,string person);
    DataSet Search_HRPerformceYear_HRPerformceDetail_State(string condition);
    DataSet Search_HRPerformceYear_Manager(string condition);
    DataSet Search_HRPerformceDetail_Manager(string condition);
    int Update_HRPerformceDetail_Manager(HRPerformceDetailInfo hr);
    DataSet Search_HRPerformceDetail_Manager_View(string condition);
    int Search_HRPerformceYear_Manager_State(int year, int month);
    int Update_HRPerformceYear_Manager(HRPerformceYearInfo hr);
}