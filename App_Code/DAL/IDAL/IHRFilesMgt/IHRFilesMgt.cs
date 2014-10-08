using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///IHRFilesMgt 的摘要说明
/// </summary>
public interface IHRFilesMgt
{

    int Insert_HRPost(HRFilesMgtInfo hr);
    int Update_HRPost(HRFilesMgtInfo hr);
    void Delete_HRPost(Guid ID);
    DataSet Search_HRPost(string BDOS_Name, string HRP_Post);
    DataSet Search_HRPost();
    DataSet Search_NETrainingItem_BDOrganizationSheet();
    IList<HRFilesMgtInfo> SearchByID_HRPost_BDOrganizationSheet(Guid NETI_ID);
}