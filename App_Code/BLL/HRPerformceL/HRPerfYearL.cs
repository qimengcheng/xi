using System;
using System.Data;

/// <summary>
///HRPerfYearL 的摘要说明
/// </summary>
public class HRPerfYearL
{
    private static readonly IHRerfYear iHR = DALFactory.CreatIHRPerformceYear();
	public HRPerfYearL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_HRPerformceYear(HRPerformceYearInfo hr)
    {
        return iHR.Insert_HRPerformceYear(hr);
    }
    public DataSet Search_HRPerformceYear_State(Guid guid, String HRPAT_APerson)
    {
        return iHR.Search_HRPerformceYear_State(guid, HRPAT_APerson);
    }
    public int Update_HRPerformceYear(HRPerformceYearInfo hr)
    {
        return iHR.Update_HRPerformceYear(hr);
    }
    public DataSet Search_HRPerformceYear(string condition)
    {
        return iHR.Search_HRPerformceYear(condition);
    }
    public int Search_HRPerformceYear_CHECK_State(int year, int month, string person)
    {
        return iHR.Search_HRPerformceYear_CHECK_State(year,month,person);
    }

    public DataSet Search_HRPerformceYear_HRPerformceDetail_State(string condition)
    {
        return iHR.Search_HRPerformceYear_HRPerformceDetail_State(condition);
    }
    public DataSet Search_HRPerformceYear_Manager(string condition)
    {
        return iHR.Search_HRPerformceYear_Manager(condition);
    }
    public DataSet Search_HRPerformceDetail_Manager(string condition)
    {
        return iHR.Search_HRPerformceDetail_Manager(condition);
    }

    public int Update_HRPerformceDetail_Manager(HRPerformceDetailInfo hr)
    {
        return iHR.Update_HRPerformceDetail_Manager(hr);
    }

    public DataSet Search_HRPerformceDetail_Manager_View(string condition)
    {
        return iHR.Search_HRPerformceDetail_Manager_View(condition);
    }

    public int Search_HRPerformceYear_Manager_State(int year, int month)
    {
        return iHR.Search_HRPerformceYear_Manager_State(year,month);
    }
    public int Update_HRPerformceYear_Manager(HRPerformceYearInfo hr)
    {
        return iHR.Update_HRPerformceYear_Manager(hr);
    }
}