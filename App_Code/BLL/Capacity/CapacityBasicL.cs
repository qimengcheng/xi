using System;
using System.Data;

/// <summary>
///CapacityBasicL 的摘要说明
/// </summary>
public class CapacityBasicL
{ private static readonly ICapacityBasic cb = DALFactory.CreateCapacity();
	public CapacityBasicL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet S_CSName(string condition)//检索产能核定系列名称表
    {
        return cb.S_CSName(condition);
    
    }
    public void I_CSName(string cSN_Name)//新增产能核定系列名称

    {
         cb.I_CSName(cSN_Name);
    }
    public void D_CSName(Guid cSN_ID)//删除产能核定系列名称
    {
        cb.D_CSName(cSN_ID);
    }
    public void U_CSName(Guid cSN_ID, string cSN_Name)//编辑产能核定系列名称

    {
        cb.U_CSName(cSN_ID, cSN_Name);
    }
    public DataSet S_CSName_ProType(string cSN_ID, string condition)//检索产能核定系列所属产品型号

    {
        return cb.S_CSName_ProType(cSN_ID, condition);
    }
    public void I_CSName_ProType(Guid cSN_ID, Guid pT_ID)//添加产品型号至产能核定系列

    {
        cb.I_CSName_ProType(cSN_ID, pT_ID);
    }

    public void D_CSName_ProType(Guid pT_ID)//删除产能核定系列所属产品型号
    {
        cb.D_CSName_ProType(pT_ID);
    }
    public DataSet S_ProTypeForCSName(string condition)//检索产能核定系列所属待选产品型号
    {
       return cb.S_ProTypeForCSName(condition);
    }
    public DataSet S_CSeries(string cSN_ID, string condition)//检索产能核定系列基础信息
    {
        return cb.S_CSeries(cSN_ID, condition);
    }
    public void I_CSeries(Guid cSN_ID, Guid pBC_ID, int cS_LaborC, int cS_MacC, string CS_Formulate)//新增产能核定系列基础信息
    {
        cb.I_CSeries(cSN_ID, pBC_ID, cS_LaborC, cS_MacC, CS_Formulate);
    }
    public void D_CSeries(Guid cS_ID)//删除产能核定系列基础信息

    {
        cb.D_CSeries(cS_ID);
    }
    public void U_CSeries(Guid cS_ID, int cS_LaborC, int cS_MacC, string CS_Formulate)//编辑产能核定系列基础信息

    {
        cb.U_CSeries(cS_ID, cS_LaborC, cS_MacC, CS_Formulate);
    }
    public DataSet S_PBCraft_Capacity(Guid cSN_ID)//检索产能核定系列基础信息

    {
      return  cb.S_PBCraft_Capacity(cSN_ID);
    }

    public DataSet S_CapacityInfo(string condition)//检索产能核定信息
    {
        return cb.S_CapacityInfo(condition);
    }
    public void I_CapacityInfo(string cI_P, string cI_Note)//新增产能核定信息
    {
        cb.I_CapacityInfo(cI_P, cI_Note);
    }
    public void U_CapacityInfo(Guid cI_ID, string cI_P, string cI_Note)//编辑产能核定信息

    {
        cb.U_CapacityInfo(cI_ID, cI_P, cI_Note);
    }
    public void D_CapacityInfo(Guid cI_ID)//删除产能核定信息
    {
        cb.D_CapacityInfo(cI_ID);
    }
    public DataSet S_CapacityDetailInfo(string condition, string pBC_ID, string cI_ID)//检索产能核定详细信息

    {
        return cb.S_CapacityDetailInfo(condition, pBC_ID, cI_ID);
    }
    public DataSet S_CSeries_PBCraftInfo()//检索产能核定主要工序

    {
        return cb.S_CSeries_PBCraftInfo();
    }
    public void I_CapacityDetailInfo(Guid cI_ID, Guid cS_ID, int cDI_MachineNum, decimal cDI_MachineHours, int cDI_PeopleNum, decimal cDI_PeopleHours)//新增产能核定详细信息
    {
         cb.I_CapacityDetailInfo(cI_ID, cS_ID, cDI_MachineNum, cDI_MachineHours, cDI_PeopleNum, cDI_PeopleHours);
    }
    public void U_CapacityDetailInfo(Guid cDI_ID, int cDI_MachineNum, decimal cDI_MachineHours, int cDI_PeopleNum, decimal cDI_PeopleHours)//编辑产能核定详细信息
    {

        cb.U_CapacityDetailInfo(cDI_ID, cDI_MachineNum, cDI_MachineHours, cDI_PeopleNum, cDI_PeopleHours);
    }
    public DataSet S_CapacityDetailInfo_ResultCheck(string cI_ID)//检索产能核定最终结果

    {
        return cb.S_CapacityDetailInfo_ResultCheck(cI_ID);
    }
}