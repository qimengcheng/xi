using System.Collections.Generic;

/// <summary>
///BasicData 的摘要说明
/// </summary>
public class BasicData
{
    private static IBasicData bd = DALFactory.CreateBasicData();
	public BasicData()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_BDOrganizationSheet(BDOrganizationSheet bDOrganizationSheet)
    {
       return  bd.Insert_BDOrganizationSheet(bDOrganizationSheet);
    }
    public int Update_BDOrganizationSheet(BDOrganizationSheet bDOrganizationSheet)
    {
        return bd.Update_BDOrganizationSheet(bDOrganizationSheet);
    }
    public int Delete_BDOrganizationSheet(string bDOS_Code)
    {
        return bd.Delete_BDOrganizationSheet(bDOS_Code);
    }
    public IList<BDOrganizationSheet> Select_BDOrganizationSheet(string condition)
    {
        return bd.Select_BDOrganizationSheet(condition);
    }

    public int Update_SingleCol(string colname, string colvalue, string keyname, string keyvalue, string tabname)
    {
        return bd.Update_SingleCol(colname, colvalue, keyname, keyvalue, tabname);
    }
    public string Select_SingleCol(string colname,  string keyname, string keyvalue, string tabname)
    {
        return bd.Select_SingleCol(colname, keyname, keyvalue, tabname);
    }
}
