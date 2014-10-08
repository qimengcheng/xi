using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///HRDDetailL 的摘要说明
/// </summary>
public class HRDDetailL
{
    private static readonly IHRDDetail iHR = DALFactory.CreateIHRDDetail();
	public HRDDetailL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_HRDDetail(HRDDetailInfo hr)
    {
        return iHR.Insert_HRDDetail(hr);
    }
    public int Update_HRDDetail(HRDDetailInfo hr)
    {
        return iHR.Update_HRDDetail(hr);
    }
    public void Delete_HRDDetail(Guid ID)
    {
        iHR.Delete_HRDDetail(ID);
    }
    public DataSet Search_HRDDetail(string condition)
    {
        return iHR.Search_HRDDetail(condition);
    }
    public DataSet SearchByID_HRDDetail_Type_Post(Guid HRDD_ID)
    {
        return iHR.SearchByID_HRDDetail_Type_Post(HRDD_ID);
    }
    public DataSet SearchDdl_HRDDetail_BDOrganizationSheet()
    {
        return iHR.SearchDdl_HRDDetail_BDOrganizationSheet();
    }
    public DataSet SearchDdl_HRDDetail(string BDOS_Code)
    {
        return iHR.SearchDdl_HRDDetail(BDOS_Code);
    }
    public DataSet SearchDdl_HRDDetail_HREmployeeType()
    {
        return iHR.SearchDdl_HRDDetail_HREmployeeType();
    }
    public IList<HRDDetailInfo> SearchByIDPart_HRDDetail(Guid HRDD_ID)
    {
        return iHR.SearchByIDPart_HRDDetail(HRDD_ID);
    }
    public int Insert_HRPersonnelChangesRecord(HRDDetailInfo hr)
    {
        return iHR.Insert_HRPersonnelChangesRecord(hr);
    }
    public DataSet Search_HRPersonnelChangesRecord(Guid HRDD_ID)
    {
        return iHR.Search_HRPersonnelChangesRecord(HRDD_ID);
    }
    public IList<HRDDetailInfo> SearchByIDPartForSalary_HRDDetail(Guid HRDD_ID)
    {
        return iHR.SearchByIDPartForSalary_HRDDetail(HRDD_ID);
    }
    public int Insert_HRSalaryRecord(HRDDetailInfo hr)
    {
        return iHR.Insert_HRSalaryRecord(hr);
    }
    public DataSet Search_HRSalaryRecord(Guid HRDD_ID)

    {
        return iHR.Search_HRSalaryRecord(HRDD_ID);
    }
    //离职相关
    public int Update_HRDDetail_Quit(HRDDetailInfo hr)
    {
        return iHR.Update_HRDDetail_Quit(hr);
    }
    public void Delete_HRDDetail_Quit(Guid ID)
    {
        iHR.Delete_HRDDetail_Quit(ID);
    }
    public DataSet Search_HRDDetail_Quit(string condition)
    {
        return iHR.Search_HRDDetail_Quit(condition);
    }
    public DataSet SearchByID_HRDDetail_Type_Post_Quit(Guid HRDD_ID)
    {
        return iHR.SearchByID_HRDDetail_Type_Post_Quit(HRDD_ID);
    }
    //奖惩相关
    public int Insert_HRRewardsPublishment(HRDDetailInfo hr)
    {
        return iHR.Insert_HRRewardsPublishment(hr);
    }
    public int Update_HRRewardsPublishment(HRDDetailInfo hr)
    {
        return iHR.Update_HRRewardsPublishment(hr);
    }
    public void Delete_HRRewardsPublishment(Guid HRRewards_ID)
    {
        iHR.Delete_HRRewardsPublishment(HRRewards_ID);
    }
    public DataSet Search_HRRewardsPublishment(string condition)
    {
        return iHR.Search_HRRewardsPublishment(condition);
    }

    public int Update_HRDDetail_Worklength()
    {
        return iHR.Update_HRDDetail_Worklength();
    }
    public DataSet Search_HRDDetail_Type_Post_Senior(string condition)
    {
        return iHR.Search_HRDDetail_Type_Post_Senior(condition);
    }
}