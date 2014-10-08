using System.Collections.Generic;

/// <summary>
///IBasicData 的摘要说明
/// </summary>
public interface IBasicData
{
    int Insert_BDOrganizationSheet(BDOrganizationSheet bDOrganizationSheet);
    int Update_BDOrganizationSheet(BDOrganizationSheet bDOrganizationSheet);
    int Delete_BDOrganizationSheet(string bDOS_Code);
    IList<BDOrganizationSheet> Select_BDOrganizationSheet(string condition);

    int Update_SingleCol(string colname, string colvalue, string keyname, string keyvalue, string tabname);
    string Select_SingleCol(string colname, string keyname, string keyvalue, string tabname);
}
