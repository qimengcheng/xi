using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///NETtainningL 的摘要说明
/// </summary>
public class NETtainningL
{
    private static readonly INETtainning iNET = DALFactory.CreateNET();
	public NETtainningL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public int Insert_NETrainingItem(NETtainningInfo nETtainningInfo)
    {
       return iNET.Insert_NETrainingItem(nETtainningInfo);

    }
    public int Update_NETrainingItem(NETtainningInfo nETtainningInfo)
    {
        return iNET.Update_NETrainingItem(nETtainningInfo);
    }
    public bool Delete_NETrainingItem(Guid _NETI_ID)
    {
        return iNET.Delete_NETrainingItem(_NETI_ID);
    }
    public DataSet Search_NETrainingItem(string _BDOS_Name, string _NETI_TraningCourse, string _NETI_TraningType)
    {
        return iNET.Search_NETrainingItem(_BDOS_Name, _NETI_TraningCourse, _NETI_TraningType);
    }
    public DataSet Search_NETrainingItem()
    {
        return iNET.Search_NETrainingItem();
    }
    public DataSet Search_NETrainingItem_BDOrganizationSheet()
    {
        return iNET.Search_NETrainingItem_BDOrganizationSheet();
    }
    public IList<NETtainningInfo> SearchByID_NETrainingItem_BDOrganizationSheet(Guid NETI_ID)
    {
        return iNET.SearchByID_NETrainingItem_BDOrganizationSheet(NETI_ID);
    }
}