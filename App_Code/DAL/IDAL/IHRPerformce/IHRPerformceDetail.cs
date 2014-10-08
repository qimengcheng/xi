using System;
using System.Data;

/// <summary>
///IHRPerformceDetail 的摘要说明
/// </summary>
public interface IHRPerformceDetail
{
    int Insert_HRPerformceDetail(HRPerformceDetailInfo hr);
    int Insert_HRPerformceDetail_HRDD_ID(Guid HRDD_ID, string HRPD_APerson, DateTime HRPD_Atime);
    DataSet Search_HRPerformAssessType_HRDDetail_HRPerformceDetail(string condition);
    int Update_HRPerformceDetail(HRPerformceDetailInfo hr);
    int Update_HRPerformceDetail_CHECK(HRPerformceDetailInfo hr);
    DataSet Search_HRDDetail_HRPerformceDetail(string condition);
    DataSet Search_HRPerformceDetail(string condition);
}