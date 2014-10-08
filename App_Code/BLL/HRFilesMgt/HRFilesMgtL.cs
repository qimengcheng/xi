using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///HRFilesMgtL 的摘要说明
/// </summary>
public class HRFilesMgtL
{
    private static readonly IHRFilesMgt iHR = DALFactory.CreateIHRFilesMgt();
    public HRFilesMgtL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public int Insert_HRPost(HRFilesMgtInfo hr)
    {
        return iHR.Insert_HRPost(hr);
    }
    public int Update_HRPost(HRFilesMgtInfo hr)
    {
        return iHR.Update_HRPost(hr);

    }
    public void Delete_HRPost(Guid ID)
    {
        iHR.Delete_HRPost(ID);
    }
    public DataSet Search_HRPost(string BDOS_Name, string HRP_Post)
    {
        return iHR.Search_HRPost(BDOS_Name, HRP_Post);
    }
    public DataSet Search_HRPost()
    {
        return iHR.Search_HRPost();
    }
    public DataSet Search_HRPost_BDOrganizationSheet()
    {
        return iHR.Search_NETrainingItem_BDOrganizationSheet();
    }
    public IList<HRFilesMgtInfo> SearchByID_HRPost_BDOrganizationSheet(Guid NETI_ID)
    {
        return iHR.SearchByID_HRPost_BDOrganizationSheet(NETI_ID);
    }
}