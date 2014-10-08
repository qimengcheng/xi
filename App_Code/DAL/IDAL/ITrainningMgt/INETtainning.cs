using System;
using System.Data;
using System.Collections.Generic;

/// <summary>
///INETtainning 的摘要说明
/// </summary>
public interface INETtainning
{
	//新员工培训 QZL
    int Insert_NETrainingItem(NETtainningInfo nETtainningInfo);
    int Update_NETrainingItem(NETtainningInfo nETtainningInfo);
    bool Delete_NETrainingItem(Guid _NETI_ID);
    DataSet Search_NETrainingItem(string _BDOS_Name, string _NETI_TraningCourse, string _NETI_TraningType);
    DataSet Search_NETrainingItem();
    DataSet Search_NETrainingItem_BDOrganizationSheet();
    IList<NETtainningInfo> SearchByID_NETrainingItem_BDOrganizationSheet(Guid NETI_ID);
}