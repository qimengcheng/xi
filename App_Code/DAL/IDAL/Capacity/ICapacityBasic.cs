using System;
using System.Data;
/// <summary>
///ICapacityBasic 的摘要说明
/// </summary>
public interface ICapacityBasic
{
    DataSet S_CSName(string condition);//检索产能核定系列名称表
    void I_CSName(string cSN_Name);//新增产能核定系列名称
    void D_CSName(Guid cSN_ID);//删除产能核定系列名称
    void U_CSName(Guid cSN_ID, string cSN_Name);//编辑产能核定系列名称
    DataSet S_CSName_ProType(string cSN_ID, string condition);//检索产能核定系列所属产品型号
    void I_CSName_ProType(Guid cSN_ID, Guid pT_ID);//添加产品型号至产能核定系列
    void D_CSName_ProType(Guid pT_ID);//删除产能核定系列所属产品型号
    DataSet S_ProTypeForCSName(string condition);//检索产能核定系列所属待选产品型号
    DataSet S_CSeries(string cSN_ID, string condition);//检索产能核定系列基础信息
    void I_CSeries(Guid cSN_ID, Guid pBC_ID, int cS_LaborC, int cS_MacC, string CS_Formulate);//新增产能核定系列基础信息
    void D_CSeries(Guid cS_ID);//删除产能核定系列基础信息
    void U_CSeries(Guid cS_ID, int cS_LaborC, int cS_MacC, string CS_Formulate);//编辑产能核定系列基础信息
    DataSet S_PBCraft_Capacity(Guid cSN_ID);//检索产能核定系列基础信息
    DataSet S_CapacityInfo(string condition);//检索产能核定信息
    void I_CapacityInfo(string cI_P, string cI_Note);//新增产能核定信息
    void U_CapacityInfo(Guid cI_ID, string cI_P, string cI_Note);//编辑产能核定信息
    void D_CapacityInfo(Guid cI_ID);//删除产能核定信息
    DataSet S_CapacityDetailInfo(string condition, string pBC_ID, string cI_ID);//检索产能核定详细信息
    DataSet S_CSeries_PBCraftInfo();//检索产能核定主要工序
    void I_CapacityDetailInfo(Guid cI_ID, Guid cS_ID, int cDI_MachineNum, decimal cDI_MachineHours, int cDI_PeopleNum, decimal cDI_PeopleHours);//新增产能核定详细信息
    void U_CapacityDetailInfo(Guid cDI_ID, int cDI_MachineNum, decimal cDI_MachineHours, int cDI_PeopleNum, decimal cDI_PeopleHours);//编辑产能核定详细信息
    DataSet S_CapacityDetailInfo_ResultCheck(string cI_ID);//检索产能核定最终结果
}