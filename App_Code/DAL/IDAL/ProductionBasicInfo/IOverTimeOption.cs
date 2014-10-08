using System;
using System.Data;
using EntityOfOverTime;
/// <summary>
///IOverTimeOption 的摘要说明
/// </summary>
public interface IOverTimeOption
{
    bool NewOverTime(string name);//新增超时原因选项
    DataSet SearchOverTime(string name);//模糊检索超时原因
    bool DeleteOverTime(Guid id);//删除超时原因，并非真的物理删除，只是把deleted变为1
    DataSet DisplayOverTime();//显示超时原因
    bool UpdateOverTime(ModuleOfOverTime info);//修改超时原因
    DataSet SearchSameOverTime(string name);//搜索同名的超时原因选项
    DataSet S_OverTimeOptionDetail(string OTO_ID, string condition);//查询选项详细项目
    void U_OverTimeOptionDetail(Guid OTOD_ID, string OTOD_Name, Guid PBC_ID);//编辑选项详细项目
    void I_OverTimeOptionDetail(Guid OTO_ID, string OTOD_Name, Guid PBC_ID);//新建选项详细项目
    void D_OverTimeOptionDetail(Guid OTOD_ID);//删除选项详细项目
    
}