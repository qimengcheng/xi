using System;
using System.Data;
using EntityOfCraftBasicInfoMgt;
/// <summary>
///ICraftBasicInfo 的摘要说明
/// </summary>
public interface ICraftBasicInfo
{
    bool NewUnit(string name);//新增用量单位
    DataSet SearchUnit(string name);//模糊检索用量单位
    bool DeleteUnit(Guid id);//删除用量单位，并非真的物理删除，只是把deleted变为1
    DataSet DisplayUnit();//显示用量单位
    bool UpdateUnit(CraftBasicInfoMgt info);//修改用量单位
    DataSet SearchSameUnit(string name);//搜索同名的用量单位
}